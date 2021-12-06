Imports System.Text.RegularExpressions

Public Class FormMain
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call. 
        Me.Text &= String.Format(" v.{0}", Application.ProductVersion)

        ComboBox_ScaleAxis.SelectedIndex = 0
    End Sub

    Private Sub Button_1_1xSmaller_Click(sender As Object, e As EventArgs) Handles Button_1_1xSmaller.Click
        Try
            ScalePlayspace(CType(ComboBox_ScaleAxis.SelectedIndex, ENUM_SCALE_AXIS), 0.9)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button_1_1xBigger_Click(sender As Object, e As EventArgs) Handles Button_1_1xBigger.Click
        Try
            ScalePlayspace(CType(ComboBox_ScaleAxis.SelectedIndex, ENUM_SCALE_AXIS), 1.1)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button_2xSmaller_Click(sender As Object, e As EventArgs) Handles Button_2xSmaller.Click
        Try
            ScalePlayspace(CType(ComboBox_ScaleAxis.SelectedIndex, ENUM_SCALE_AXIS), 0.5)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button_2xBigger_Click(sender As Object, e As EventArgs) Handles Button_2xBigger.Click
        Try
            ScalePlayspace(CType(ComboBox_ScaleAxis.SelectedIndex, ENUM_SCALE_AXIS), 2.0)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button_3xSmaller_Click(sender As Object, e As EventArgs) Handles Button_3xSmaller.Click
        Try
            ScalePlayspace(CType(ComboBox_ScaleAxis.SelectedIndex, ENUM_SCALE_AXIS), 0.33)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button_3xBigger_Click(sender As Object, e As EventArgs) Handles Button_3xBigger.Click
        Try
            ScalePlayspace(CType(ComboBox_ScaleAxis.SelectedIndex, ENUM_SCALE_AXIS), 3.0)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button_CustomScale_Click(sender As Object, e As EventArgs) Handles Button_CustomScale.Click
        Try
            ScalePlayspace(CType(ComboBox_ScaleAxis.SelectedIndex, ENUM_SCALE_AXIS), NumericUpDown_Scale.Value)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Enum ENUM_SCALE_AXIS
        ALL
        X
        Y
        Z
    End Enum

    Private Sub ScalePlayspace(iAxis As ENUM_SCALE_AXIS, iValue As Double)
        If (iValue <= 0.0) Then
            Throw New ArgumentException("Scale value can not be negative or zero.")
        End If

        NumericUpDown_Scale.Value = CDec(iValue)

        Dim sPsmsPath As String = Environment.ExpandEnvironmentVariables("%AppData%\PSMoveService")
        If (Not IO.Directory.Exists(sPsmsPath)) Then
            Throw New ArgumentException("PSMoveService configs not found. Please setup PSMoveService first.")
        End If

        Dim sTrackerConfigs As String() = IO.Directory.GetFiles(sPsmsPath, "PS3EyeTrackerConfig_ps3eye_*", IO.SearchOption.TopDirectoryOnly)

        'Can't be fucked with Json right now, this works fine.
        Dim mRegexFilter As New Regex("""pose"":\s*{\s*""orientation"":\s*\{\s*""w"":\s*""[\-0-9.]+""\,\s*""x"":\s*""[\-0-9.]+"",\s*""y"":\s*""[\-0-9.]+"",\s*""z"":\s*""[\-0-9.]+""\s*},\s*""position"":\s*{\s*""x"":\s*""(?<X>[-0-9.]+)"",\s*""y"":\s*""(?<Y>[-0-9.]+)"",\s*""z"":\s*""(?<Z>[-0-9.]+)""\s*}\s*},", RegexOptions.Multiline)

        For Each sConfigFile In sTrackerConfigs
            Dim sText As String = IO.File.ReadAllText(sConfigFile)

            If (Not mRegexFilter.IsMatch(sText)) Then
                Continue For
            End If

            Dim mMatch As Match = mRegexFilter.Match(sText)

            For i = mMatch.Groups.Count - 1 To 1 Step -1
                Select Case (iAxis)
                    Case ENUM_SCALE_AXIS.X
                        If (i <> 1) Then
                            Continue For
                        End If

                    Case ENUM_SCALE_AXIS.Y
                        If (i <> 2) Then
                            Continue For
                        End If

                    Case ENUM_SCALE_AXIS.Z
                        If (i <> 3) Then
                            Continue For
                        End If
                End Select

                Dim sNum As String = sText.Substring(mMatch.Groups(i).Index, mMatch.Groups(i).Length)
                Dim iScale As Double = Double.Parse(sNum, Globalization.NumberStyles.Float, Globalization.CultureInfo.InvariantCulture)

                iScale *= iValue

                sText = sText.Remove(mMatch.Groups(i).Index, mMatch.Groups(i).Length)
                sText = sText.Insert(mMatch.Groups(i).Index, iScale.ToString(Globalization.CultureInfo.InvariantCulture))
            Next


            IO.File.WriteAllText(sConfigFile, sText)
        Next

        MessageBox.Show(String.Format("PSMS Playspace scaled by {0} on axis {1}!" & Environment.NewLine & "Restart PSMoveService to take effect!", iValue.ToString("0.00", Globalization.CultureInfo.InvariantCulture), iAxis.ToString), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
