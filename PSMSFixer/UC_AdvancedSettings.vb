Imports System.Text.RegularExpressions

Public Class UC_AdvancedSettings
    Private g_bIgnoreEvents As Boolean = False
    Private g_bInit As Boolean = True

    Private g_mSettignsDic As New Dictionary(Of String, ClassSettingsKey)
    Private g_mSettignsExDic As New Dictionary(Of String, ClassSettingsKey)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        g_bInit = False
    End Sub

    Protected Overrides Sub OnParentVisibleChanged(e As EventArgs)
        If (g_bInit) Then
            Return
        End If

        g_bInit = True

        Try
            RefreshConfig()

            Button_Apply.Enabled = True
        Catch ex As Exception
            Button_Apply.Enabled = False

            MessageBox.Show(ex.Message, "Unable to read configs", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        MyBase.OnParentVisibleChanged(e)
    End Sub

    Private Sub RefreshConfig()
        Try
            g_bIgnoreEvents = True

            Dim sPsmsPath As String = Environment.ExpandEnvironmentVariables("%AppData%\PSMoveService")
            If (Not IO.Directory.Exists(sPsmsPath)) Then
                Throw New ArgumentException("PSMoveService configs not found. Please setup PSMoveService first.")
            End If

            Dim sTrackerSettings As String = IO.Path.Combine(sPsmsPath, "TrackerManagerConfig.json")

            g_mSettignsDic.Clear()
            g_mSettignsDic(NumericUpDown_ControllerSmoothing.Name) = New ClassSettingsKey(sTrackerSettings, "controller_position_smoothing", ClassSettingsKey.ENUM_TYPE.NUM)
            g_mSettignsDic(CheckBox_TriangulationOnly.Name) = New ClassSettingsKey(sTrackerSettings, "ignore_pose_from_one_tracker", ClassSettingsKey.ENUM_TYPE.BOOL)
            g_mSettignsDic(NumericUpDown_OpticalTimeout.Name) = New ClassSettingsKey(sTrackerSettings, "optical_tracking_timeout", ClassSettingsKey.ENUM_TYPE.NUM)
            g_mSettignsDic(NumericUpDown_TrackerSleep.Name) = New ClassSettingsKey(sTrackerSettings, "tracker_sleep_ms", ClassSettingsKey.ENUM_TYPE.NUM)
            g_mSettignsDic(CheckBox_ExlcudeCameras.Name) = New ClassSettingsKey(sTrackerSettings, "excluded_opposed_cameras", ClassSettingsKey.ENUM_TYPE.BOOL)
            g_mSettignsDic(NumericUpDown_MinProjectArea.Name) = New ClassSettingsKey(sTrackerSettings, "min_valid_projection_area", ClassSettingsKey.ENUM_TYPE.NUM)
            g_mSettignsDic(CheckBox_DisableRoI.Name) = New ClassSettingsKey(sTrackerSettings, "disable_roi", ClassSettingsKey.ENUM_TYPE.BOOL)

            g_mSettignsExDic(NumericUpDown_ControllerPrediction.Name) = New ClassSettingsKey(sTrackerSettings, "controller_position_prediction", ClassSettingsKey.ENUM_TYPE.NUM)
            g_mSettignsExDic(NumericUpDown_ControllerPredictionSmoothing.Name) = New ClassSettingsKey(sTrackerSettings, "controller_position_prediction_smoothing", ClassSettingsKey.ENUM_TYPE.NUM)
            g_mSettignsExDic(NumericUpDown_ControllerPredictionHistory.Name) = New ClassSettingsKey(sTrackerSettings, "controller_position_prediction_history", ClassSettingsKey.ENUM_TYPE.NUM)
            g_mSettignsExDic(NumericUpDown_OccludeArea.Name) = New ClassSettingsKey(sTrackerSettings, "min_occluded_area_on_loss", ClassSettingsKey.ENUM_TYPE.NUM)
            g_mSettignsExDic(NumericUpDown_MinPointsInContour.Name) = New ClassSettingsKey(sTrackerSettings, "min_points_in_contour", ClassSettingsKey.ENUM_TYPE.NUM)
            g_mSettignsExDic(NumericUpDown_MinTrackerDeviation.Name) = New ClassSettingsKey(sTrackerSettings, "max_tracker_position_deviation", ClassSettingsKey.ENUM_TYPE.NUM)
            g_mSettignsExDic(CheckBox_OptimizedRoI.Name) = New ClassSettingsKey(sTrackerSettings, "optimized_roi", ClassSettingsKey.ENUM_TYPE.BOOL)

            Dim bExtensionAvaliable As Boolean = True

            For Each sKey As String In g_mSettignsDic.Keys
                Try
                    g_mSettignsDic(sKey).Load()
                Catch ex As Exception
                    Throw New ArgumentException(String.Format("Unable to load key '{0}'", sKey))
                End Try
            Next

            For Each sKey As String In g_mSettignsExDic.Keys
                Try
                    g_mSettignsExDic(sKey).Load()
                Catch ex As Exception
                    bExtensionAvaliable = False
                End Try
            Next

            GroupBox_ExtensionSettings.Enabled = bExtensionAvaliable

            NumericUpDown_ControllerSmoothing.Value = NumericUpDownValueClamp(NumericUpDown_ControllerSmoothing, CDec(g_mSettignsDic(NumericUpDown_ControllerSmoothing.Name).m_ValueF))
            CheckBox_TriangulationOnly.Checked = g_mSettignsDic(CheckBox_TriangulationOnly.Name).m_ValueB
            NumericUpDown_OpticalTimeout.Value = NumericUpDownValueClamp(NumericUpDown_OpticalTimeout, CDec(g_mSettignsDic(NumericUpDown_OpticalTimeout.Name).m_ValueF))
            NumericUpDown_TrackerSleep.Value = NumericUpDownValueClamp(NumericUpDown_TrackerSleep, CDec(g_mSettignsDic(NumericUpDown_TrackerSleep.Name).m_ValueF))
            CheckBox_ExlcudeCameras.Checked = g_mSettignsDic(CheckBox_ExlcudeCameras.Name).m_ValueB
            NumericUpDown_MinProjectArea.Value = NumericUpDownValueClamp(NumericUpDown_MinProjectArea, CDec(g_mSettignsDic(NumericUpDown_MinProjectArea.Name).m_ValueF))
            CheckBox_DisableRoI.Checked = g_mSettignsDic(CheckBox_DisableRoI.Name).m_ValueB

            NumericUpDown_ControllerPrediction.Value = NumericUpDownValueClamp(NumericUpDown_ControllerPrediction, CDec(g_mSettignsExDic(NumericUpDown_ControllerPrediction.Name).m_ValueF))
            NumericUpDown_ControllerPredictionSmoothing.Value = NumericUpDownValueClamp(NumericUpDown_ControllerPredictionSmoothing, CDec(g_mSettignsExDic(NumericUpDown_ControllerPredictionSmoothing.Name).m_ValueF))
            NumericUpDown_ControllerPredictionHistory.Value = NumericUpDownValueClamp(NumericUpDown_ControllerPredictionHistory, CDec(g_mSettignsExDic(NumericUpDown_ControllerPredictionHistory.Name).m_ValueF))
            NumericUpDown_OccludeArea.Value = NumericUpDownValueClamp(NumericUpDown_OccludeArea, CDec(g_mSettignsExDic(NumericUpDown_OccludeArea.Name).m_ValueF))
            NumericUpDown_MinPointsInContour.Value = NumericUpDownValueClamp(NumericUpDown_MinPointsInContour, CDec(g_mSettignsExDic(NumericUpDown_MinPointsInContour.Name).m_ValueF))
            NumericUpDown_MinTrackerDeviation.Value = NumericUpDownValueClamp(NumericUpDown_MinTrackerDeviation, CDec(g_mSettignsExDic(NumericUpDown_MinTrackerDeviation.Name).m_ValueF))
            CheckBox_OptimizedRoI.Checked = g_mSettignsExDic(CheckBox_OptimizedRoI.Name).m_ValueB
        Finally
            g_bIgnoreEvents = False
        End Try
    End Sub

    Private Function NumericUpDownValueClamp(mControl As NumericUpDown, iValue As Decimal) As Decimal
        Return Math.Max(mControl.Minimum, Math.Min(mControl.Maximum, iValue))
    End Function

    Private Sub Button_Apply_Click(sender As Object, e As EventArgs) Handles Button_Apply.Click
        Try
            For Each sKey As String In g_mSettignsDic.Keys
                Try
                    Dim mSettingsKey = g_mSettignsDic(sKey)
                    If (Not mSettingsKey.m_Loaded) Then
                        Continue For
                    End If

                    mSettingsKey.Save()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Unable to save some settings", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Next

            For Each sKey As String In g_mSettignsExDic.Keys
                Try
                    Dim mSettingsKey = g_mSettignsExDic(sKey)
                    If (Not mSettingsKey.m_Loaded) Then
                        Continue For
                    End If

                    mSettingsKey.Save()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Unable to save some settings", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Next

            MessageBox.Show("Success!" & Environment.NewLine & "Restart PSMoveService to take effect!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button_Refresh_Click(sender As Object, e As EventArgs) Handles Button_Refresh.Click
        Try
            RefreshConfig()

            Button_Apply.Enabled = True
        Catch ex As Exception
            Button_Apply.Enabled = False

            MessageBox.Show(ex.Message, "Unable to read configs", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub NumericUpDown_ControllerSmoothing_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_ControllerSmoothing.ValueChanged
        SettingsChanged(sender)
    End Sub

    Private Sub CheckBox_TriangulationOnly_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_TriangulationOnly.CheckedChanged
        SettingsChanged(sender)
    End Sub

    Private Sub NumericUpDown_OpticalTimeout_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_OpticalTimeout.ValueChanged
        SettingsChanged(sender)
    End Sub

    Private Sub NumericUpDown_TrackerSleep_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_TrackerSleep.ValueChanged
        SettingsChanged(sender)
    End Sub

    Private Sub CheckBox_ExlcudeCameras_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_ExlcudeCameras.CheckedChanged
        SettingsChanged(sender)
    End Sub

    Private Sub NumericUpDown_MinProjectArea_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_MinProjectArea.ValueChanged
        SettingsChanged(sender)
    End Sub

    Private Sub CheckBox_DisableRoI_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_DisableRoI.CheckedChanged
        SettingsChanged(sender)
    End Sub

    Private Sub NumericUpDown_ControllerPrediction_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_ControllerPrediction.ValueChanged
        SettingsChanged(sender)
    End Sub

    Private Sub NumericUpDown_ControllerPredictionSmoothing_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_ControllerPredictionSmoothing.ValueChanged
        SettingsChanged(sender)
    End Sub

    Private Sub NumericUpDown_ControllerPredictionHistory_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_ControllerPredictionHistory.ValueChanged
        SettingsChanged(sender)
    End Sub

    Private Sub NumericUpDown_OccludeArea_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_OccludeArea.ValueChanged
        SettingsChanged(sender)
    End Sub

    Private Sub NumericUpDown_MinPointsInContour_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_MinPointsInContour.ValueChanged
        SettingsChanged(sender)
    End Sub

    Private Sub NumericUpDown_MinTrackerDeviation_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_MinTrackerDeviation.ValueChanged
        SettingsChanged(sender)
    End Sub

    Private Sub CheckBox_OptimizedRoI_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_OptimizedRoI.CheckedChanged
        SettingsChanged(sender)
    End Sub

    Private Sub SettingsChanged(sender As Object)
        If (g_bIgnoreEvents) Then
            Return
        End If

        Dim mNumericUpDown = TryCast(sender, NumericUpDown)
        If (mNumericUpDown IsNot Nothing) Then
            If (g_mSettignsDic.ContainsKey(mNumericUpDown.Name)) Then
                g_mSettignsDic(mNumericUpDown.Name).m_ValueF = mNumericUpDown.Value
            End If

            If (g_mSettignsExDic.ContainsKey(mNumericUpDown.Name)) Then
                g_mSettignsExDic(mNumericUpDown.Name).m_ValueF = mNumericUpDown.Value
            End If

            Return
        End If

        Dim mCheckBox = TryCast(sender, CheckBox)
        If (mCheckBox IsNot Nothing) Then
            If (g_mSettignsDic.ContainsKey(mCheckBox.Name)) Then
                g_mSettignsDic(mCheckBox.Name).m_ValueB = mCheckBox.Checked
            End If

            If (g_mSettignsExDic.ContainsKey(mCheckBox.Name)) Then
                g_mSettignsExDic(mCheckBox.Name).m_ValueB = mCheckBox.Checked
            End If

            Return
        End If
    End Sub

    Private Sub Button_ResetTrackerHz10_Click(sender As Object, e As EventArgs) Handles Button_ResetTrackerHz10.Click
        Const CAM_HZ As Integer = 10

        Try
            If (MessageBox.Show(String.Format("WARNING: This will set ALL tracker Hz to {1}!{0}Continue?", Environment.NewLine, CAM_HZ), "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.Cancel) Then
                Return
            End If

            ResetTrackerHz(CAM_HZ)

            MessageBox.Show(String.Format("All tracker Hz have been set to {1} Hz!{0}Restart PSMoveService to take effect!", Environment.NewLine, CAM_HZ), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button_ResetTrackerHz40_Click(sender As Object, e As EventArgs) Handles Button_ResetTrackerHz40.Click
        Const CAM_HZ As Integer = 40

        Try
            If (MessageBox.Show(String.Format("WARNING: This will set ALL tracker Hz to {1}!{0}Continue?", Environment.NewLine, CAM_HZ), "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.Cancel) Then
                Return
            End If

            ResetTrackerHz(CAM_HZ)

            MessageBox.Show(String.Format("All tracker Hz have been set to {1} Hz!{0}Restart PSMoveService to take effect!", Environment.NewLine, CAM_HZ), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button_FactoryTracker_Click(sender As Object, e As EventArgs) Handles Button_FactoryTracker.Click
        Try
            If (MessageBox.Show("WARNING: This will factory reset ALL PSMoveService tracker settings!" & Environment.NewLine & "Continue?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.Cancel) Then
                Return
            End If

            Dim sPsmsPath As String = Environment.ExpandEnvironmentVariables("%AppData%\PSMoveService")
            If (Not IO.Directory.Exists(sPsmsPath)) Then
                Throw New ArgumentException("PSMoveService configs not found. Please setup PSMoveService first.")
            End If

            For Each sFile As String In IO.Directory.GetFiles(sPsmsPath, "PS3EyeTrackerConfig_ps3eye_*.json")
                IO.File.Delete(sFile)
            Next

            MessageBox.Show(String.Format("PSMoveService tracker settings have been factory reset!{0}Restart PSMoveService to take effect!", Environment.NewLine), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button_FactoryControllers_Click(sender As Object, e As EventArgs) Handles Button_FactoryControllers.Click
        Try
            If (MessageBox.Show("WARNING: This will factory reset ALL PSMoveService controller settings! Continue?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.Cancel) Then
                Return
            End If

            Dim sPsmsPath As String = Environment.ExpandEnvironmentVariables("%AppData%\PSMoveService")
            If (Not IO.Directory.Exists(sPsmsPath)) Then
                Throw New ArgumentException("PSMoveService configs not found. Please setup PSMoveService first.")
            End If

            For Each sFile As String In IO.Directory.GetFiles(sPsmsPath, "??_??_??_??_??_??.json")
                IO.File.Delete(sFile)
            Next

            MessageBox.Show(String.Format("PSMoveService controller settings have been factory reset!{0}Restart PSMoveService to take effect!", Environment.NewLine), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button_FactoryAll_Click(sender As Object, e As EventArgs) Handles Button_FactoryAll.Click
        Try
            If (MessageBox.Show("WARNING: This will factory reset ALL PSMoveService settings! Continue?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.Cancel) Then
                Return
            End If

            Dim sPsmsPath As String = Environment.ExpandEnvironmentVariables("%AppData%\PSMoveService")
            If (Not IO.Directory.Exists(sPsmsPath)) Then
                Throw New ArgumentException("PSMoveService configs not found. Please setup PSMoveService first.")
            End If

            For Each sFile As String In IO.Directory.GetFiles(sPsmsPath, "*.json")
                IO.File.Delete(sFile)
            Next

            MessageBox.Show(String.Format("PSMoveService settings have been factory reset!{0}Restart PSMoveService to take effect!", Environment.NewLine), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ResetTrackerHz(iHz As Byte)
        Dim sPsmsPath As String = Environment.ExpandEnvironmentVariables("%AppData%\PSMoveService")
        If (Not IO.Directory.Exists(sPsmsPath)) Then
            Throw New ArgumentException("PSMoveService configs not found. Please setup PSMoveService first.")
        End If

        Dim sTrackerFiles As String() = IO.Directory.GetFiles(sPsmsPath, "PS3EyeTrackerConfig_ps3eye_*.json")
        For Each sTrackerFile As String In sTrackerFiles
            Dim sText As String = IO.File.ReadAllText(sTrackerFile)

            Dim mMatchNum = Regex.Match(sText, """frame_rate"":\s*""(?<Value>[0-9]+)"",", RegexOptions.Multiline)
            If (Not mMatchNum.Success) Then
                Continue For
            End If

            sText = sText.Remove(mMatchNum.Groups("Value").Index, mMatchNum.Groups("Value").Length)
            sText = sText.Insert(mMatchNum.Groups("Value").Index, CStr(iHz))

            IO.File.WriteAllText(sTrackerFile, sText)
        Next
    End Sub

    Class ClassSettingsKey
        Enum ENUM_TYPE
            BOOL
            NUM
        End Enum

        Private g_iType As ENUM_TYPE = ENUM_TYPE.BOOL
        Private g_mValue As Object = 0

        Private g_sPath As String = ""
        Private g_sSettingKey As String = ""

        Private g_bLoaded As Boolean = False

        Public Sub New(sPath As String, sSettingKey As String, iType As ENUM_TYPE)
            g_sPath = sPath
            g_sSettingKey = sSettingKey
            g_iType = iType
        End Sub

        ReadOnly Property m_Type As ENUM_TYPE
            Get
                Return g_iType
            End Get
        End Property

        Property m_Value As Object
            Get
                If (Not g_bLoaded) Then
                    Return Nothing
                End If

                Return g_mValue
            End Get
            Set(value As Object)
                g_mValue = value
                g_bLoaded = True
            End Set
        End Property

        Property m_ValueB As Boolean
            Get
                If (Not g_bLoaded) Then
                    Return False
                End If

                Return CBool(g_mValue)
            End Get
            Set(value As Boolean)
                g_mValue = value
                g_bLoaded = True
            End Set
        End Property

        Property m_ValueF As Double
            Get
                If (Not g_bLoaded) Then
                    Return 0.0
                End If

                Return CDbl(g_mValue)
            End Get
            Set(value As Double)
                g_mValue = value
                g_bLoaded = True
            End Set
        End Property

        ReadOnly Property m_Loaded As Boolean
            Get
                Return g_bLoaded
            End Get
        End Property

        Public Sub Load()
            Dim sText As String = IO.File.ReadAllText(g_sPath)

            Dim mMatchBool = Regex.Match(sText, """" & g_sSettingKey & """:\s*""(?<Value>true|false)"",")
            If (mMatchBool.Success) Then
                g_iType = ENUM_TYPE.BOOL
                g_mValue = (mMatchBool.Groups("Value").Value = "true")

                g_bLoaded = True
            Else
                Dim mMatchNum = Regex.Match(sText, """" & g_sSettingKey & """:\s*""(?<Value>[-0-9.]+)"",", RegexOptions.Multiline)
                If (mMatchNum.Success) Then
                    Dim sNum As String = sText.Substring(mMatchNum.Groups("Value").Index, mMatchNum.Groups("Value").Length)
                    Dim iNum As Double = Double.Parse(sNum, Globalization.NumberStyles.Float, Globalization.CultureInfo.InvariantCulture)

                    g_iType = ENUM_TYPE.NUM
                    g_mValue = iNum

                    g_bLoaded = True
                Else
                    Throw New ArgumentException("Unknown value type")
                End If
            End If
        End Sub

        Public Sub Save()
            If (Not g_bLoaded) Then
                Throw New ArgumentException("Value has not been loaded yet")
            End If

            Dim sText As String = IO.File.ReadAllText(g_sPath)
            Dim mMatchNum = Regex.Match(sText, """" & g_sSettingKey & """:\s*""(?<Value>[-a-zA-Z0-9.]+)"",", RegexOptions.Multiline)
            If (Not mMatchNum.Success) Then
                Throw New ArgumentException(String.Format("Could not find key '{0}'", g_sSettingKey))
            End If

            sText = sText.Remove(mMatchNum.Groups("Value").Index, mMatchNum.Groups("Value").Length)

            Select Case (g_iType)
                Case ENUM_TYPE.BOOL
                    sText = sText.Insert(mMatchNum.Groups("Value").Index, If(CBool(g_mValue), "true", "false"))
                Case Else
                    sText = sText.Insert(mMatchNum.Groups("Value").Index, CDbl(g_mValue).ToString(Globalization.CultureInfo.InvariantCulture))
            End Select

            IO.File.WriteAllText(g_sPath, sText)
        End Sub
    End Class
End Class
