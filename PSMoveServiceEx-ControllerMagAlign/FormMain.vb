Imports System.Text.RegularExpressions

Public Class FormMain
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.Text &= String.Format(" v.{0}", Application.ProductVersion)
    End Sub

    Private Sub ComboBox_SelectedController_DropDown(sender As Object, e As EventArgs) Handles ComboBox_SelectedController.DropDown
        Try
            Dim sPsmsPath As String = Environment.ExpandEnvironmentVariables("%AppData%\PSMoveService")
            If (Not IO.Directory.Exists(sPsmsPath)) Then
                Throw New ArgumentException("PSMoveService configs not found. Please setup PSMoveService first.")
            End If

            For Each sFile In IO.Directory.GetFiles(sPsmsPath, "??_??_??_??_??_??.json")
                Dim sId As String = IO.Path.GetFileNameWithoutExtension(sFile)

                Dim bExist As Boolean = False
                For Each mItem In ComboBox_SelectedController.Items
                    Dim mPSmoveController = TryCast(mItem, ClassPSmoveController)
                    If (mPSmoveController Is Nothing) Then
                        Continue For
                    End If

                    If (mPSmoveController.m_Id = sId) Then
                        bExist = True
                        Exit For
                    End If
                Next

                If (bExist) Then
                    Continue For
                End If

                ComboBox_SelectedController.Items.Add(New ClassPSmoveController(sId))
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Class ClassPSmoveController
        Private g_sConfigFile As String = ""
        Private g_sControllerId As String = ""
        Private g_sColor As String = ""

        Public Sub New(sId As String)
            Dim sPsmsPath As String = Environment.ExpandEnvironmentVariables("%AppData%\PSMoveService")
            If (Not IO.Directory.Exists(sPsmsPath)) Then
                Throw New ArgumentException("PSMoveService configs not found. Please setup PSMoveService first.")
            End If

            Dim sConfigFile As String = IO.Path.Combine(sPsmsPath, String.Format("{0}.json", sId))
            If (Not IO.File.Exists(sConfigFile)) Then
                Throw New ArgumentException("PSmove controller config file not found.")
            End If

            Dim sColor As String = "<Unknown>"
            Dim sConfigText As String = IO.File.ReadAllText(sConfigFile)

            Dim mColorRegex As New Regex("""tracking_color"":\s*""(?<Color>[\w]+)""")
            Dim mColorMatch As Match = mColorRegex.Match(sConfigText)
            If (mColorMatch.Success) Then
                sColor = mColorMatch.Groups("Color").Value
            End If

            g_sConfigFile = sConfigFile
            g_sControllerId = sId
            g_sColor = sColor
        End Sub

        ReadOnly Property m_Id As String
            Get
                Return g_sControllerId
            End Get
        End Property

        ReadOnly Property m_Color As String
            Get
                Return g_sColor
            End Get
        End Property

        Public Sub AdjustCenterX(iValue As Double)
            If (Not IO.File.Exists(g_sConfigFile)) Then
                Throw New ArgumentException("Unable to fine controller config.")
            End If

            Dim sText As String = IO.File.ReadAllText(g_sConfigFile)

            'Can't be fucked with Json right now, this works fine.
            Dim mRegex As New Regex("""Magnetometer"":\s*{\s*""Center"":\s*{\s*""X"":\s*""(?<CenterX>[-0-9.]+)"",")

            Dim mMatch As Match = mRegex.Match(sText)
            If (Not mMatch.Success) Then
                Throw New ArgumentException("Unable to find 'Magnetometer->Center->X' in controller config.")
            End If

            If (mMatch.Groups("CenterX").Value = "0") Then
                Throw New ArgumentException("Magnetometer not yet calibrated.")
            End If

            Dim sNum As String = sText.Substring(mMatch.Groups("CenterX").Index, mMatch.Groups("CenterX").Length)
            Dim iYawAngle As Double = Double.Parse(sNum, Globalization.NumberStyles.Float, Globalization.CultureInfo.InvariantCulture)

            iYawAngle += iValue

            sText = sText.Remove(mMatch.Groups("CenterX").Index, mMatch.Groups("CenterX").Length)
            sText = sText.Insert(mMatch.Groups("CenterX").Index, iYawAngle.ToString(Globalization.CultureInfo.InvariantCulture))

            IO.File.WriteAllText(g_sConfigFile, sText)
        End Sub


        Public Overrides Function ToString() As String
            Return String.Format("ID: {0} (Color: {1})", g_sControllerId.ToUpper, g_sColor.ToLower)
        End Function
    End Class

    Private Sub Button_YawNeg5_Click(sender As Object, e As EventArgs) Handles Button_YawNeg5.Click
        Try
            Dim mPSmoveController = TryCast(ComboBox_SelectedController.SelectedItem, ClassPSmoveController)
            If (mPSmoveController Is Nothing) Then
                Throw New ArgumentException("Unable to find controller")
            End If

            mPSmoveController.AdjustCenterX(-5.0F)

            MessageBox.Show("Success!" & Environment.NewLine & "Preview the controller orientation in PSMoveService Tool to verify!" & Environment.NewLine & Environment.NewLine & "Restart PSMoveService to take effect!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button_YawNeg10_Click(sender As Object, e As EventArgs) Handles Button_YawNeg10.Click
        Try
            Dim mPSmoveController = TryCast(ComboBox_SelectedController.SelectedItem, ClassPSmoveController)
            If (mPSmoveController Is Nothing) Then
                Throw New ArgumentException("Unable to find controller")
            End If

            mPSmoveController.AdjustCenterX(-10.0F)

            MessageBox.Show("Success!" & Environment.NewLine & "Preview the controller orientation in PSMoveService Tool to verify!" & Environment.NewLine & Environment.NewLine & "Restart PSMoveService to take effect!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button_YawPos5_Click(sender As Object, e As EventArgs) Handles Button_YawPos5.Click
        Try
            Dim mPSmoveController = TryCast(ComboBox_SelectedController.SelectedItem, ClassPSmoveController)
            If (mPSmoveController Is Nothing) Then
                Throw New ArgumentException("Unable to find controller")
            End If

            mPSmoveController.AdjustCenterX(5.0F)

            MessageBox.Show("Success!" & Environment.NewLine & "Preview the controller orientation in PSMoveService Tool to verify!" & Environment.NewLine & Environment.NewLine & "Restart PSMoveService to take effect!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button_YawPos10_Click(sender As Object, e As EventArgs) Handles Button_YawPos10.Click
        Try
            Dim mPSmoveController = TryCast(ComboBox_SelectedController.SelectedItem, ClassPSmoveController)
            If (mPSmoveController Is Nothing) Then
                Throw New ArgumentException("Unable to find controller")
            End If

            mPSmoveController.AdjustCenterX(10.0F)

            MessageBox.Show("Success!" & Environment.NewLine & "Preview the controller orientation in PSMoveService Tool to verify!" & Environment.NewLine & Environment.NewLine & "Restart PSMoveService to take effect!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
