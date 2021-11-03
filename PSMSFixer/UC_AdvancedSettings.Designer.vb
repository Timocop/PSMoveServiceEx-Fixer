<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_AdvancedSettings
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NumericUpDown_ControllerSmoothing = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CheckBox_TriangulationOnly = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NumericUpDown_OpticalTimeout = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NumericUpDown_TrackerSleep = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.NumericUpDown_MinProjectArea = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CheckBox_DisableRoI = New System.Windows.Forms.CheckBox()
        Me.GroupBox_ExtensionSettings = New System.Windows.Forms.GroupBox()
        Me.CheckBox_OptimizedRoI = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.NumericUpDown_OccludeArea = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button_Apply = New System.Windows.Forms.Button()
        Me.Button_Refresh = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button_FactoryAll = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Button_FactoryControllers = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Button_FactoryTracker = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button_ResetTrackerHz10 = New System.Windows.Forms.Button()
        Me.Button_ResetTrackerHz40 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.CheckBox_ExlcudeCameras = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.NumericUpDown_ControllerPrediction = New System.Windows.Forms.NumericUpDown()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.NumericUpDown_ControllerPredictionSmoothing = New System.Windows.Forms.NumericUpDown()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.NumericUpDown_ControllerPredictionHistory = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown_MinPointsInContour = New System.Windows.Forms.NumericUpDown()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.NumericUpDown_MinTrackerDeviation = New System.Windows.Forms.NumericUpDown()
        Me.Label19 = New System.Windows.Forms.Label()
        CType(Me.NumericUpDown_ControllerSmoothing, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_OpticalTimeout, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_TrackerSleep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_MinProjectArea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_ExtensionSettings.SuspendLayout()
        CType(Me.NumericUpDown_OccludeArea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NumericUpDown_ControllerPrediction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_ControllerPredictionSmoothing, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_ControllerPredictionHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_MinPointsInContour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_MinTrackerDeviation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(634, 48)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Edit hidden advanced settings to adjust or improve your tracking."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 60)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(167, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Controller position smoothing:"
        '
        'NumericUpDown_ControllerSmoothing
        '
        Me.NumericUpDown_ControllerSmoothing.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDown_ControllerSmoothing.DecimalPlaces = 2
        Me.NumericUpDown_ControllerSmoothing.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.NumericUpDown_ControllerSmoothing.Location = New System.Drawing.Point(432, 58)
        Me.NumericUpDown_ControllerSmoothing.Maximum = New Decimal(New Integer() {99, 0, 0, 131072})
        Me.NumericUpDown_ControllerSmoothing.Name = "NumericUpDown_ControllerSmoothing"
        Me.NumericUpDown_ControllerSmoothing.Size = New System.Drawing.Size(205, 22)
        Me.NumericUpDown_ControllerSmoothing.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 85)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(289, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Ignore pose frome one tracker (use triangulation only):"
        '
        'CheckBox_TriangulationOnly
        '
        Me.CheckBox_TriangulationOnly.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox_TriangulationOnly.AutoSize = True
        Me.CheckBox_TriangulationOnly.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CheckBox_TriangulationOnly.Location = New System.Drawing.Point(432, 83)
        Me.CheckBox_TriangulationOnly.Name = "CheckBox_TriangulationOnly"
        Me.CheckBox_TriangulationOnly.Size = New System.Drawing.Size(35, 18)
        Me.CheckBox_TriangulationOnly.TabIndex = 4
        Me.CheckBox_TriangulationOnly.Text = " "
        Me.CheckBox_TriangulationOnly.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 109)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(135, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Optical tracking timeout:"
        '
        'NumericUpDown_OpticalTimeout
        '
        Me.NumericUpDown_OpticalTimeout.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDown_OpticalTimeout.Location = New System.Drawing.Point(432, 107)
        Me.NumericUpDown_OpticalTimeout.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.NumericUpDown_OpticalTimeout.Name = "NumericUpDown_OpticalTimeout"
        Me.NumericUpDown_OpticalTimeout.Size = New System.Drawing.Size(205, 22)
        Me.NumericUpDown_OpticalTimeout.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 134)
        Me.Label5.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Tracker sleep (ms):"
        '
        'NumericUpDown_TrackerSleep
        '
        Me.NumericUpDown_TrackerSleep.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDown_TrackerSleep.Location = New System.Drawing.Point(432, 132)
        Me.NumericUpDown_TrackerSleep.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.NumericUpDown_TrackerSleep.Name = "NumericUpDown_TrackerSleep"
        Me.NumericUpDown_TrackerSleep.Size = New System.Drawing.Size(205, 22)
        Me.NumericUpDown_TrackerSleep.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 184)
        Me.Label6.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(166, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Minimum valid projection area:"
        '
        'NumericUpDown_MinProjectArea
        '
        Me.NumericUpDown_MinProjectArea.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDown_MinProjectArea.Location = New System.Drawing.Point(432, 182)
        Me.NumericUpDown_MinProjectArea.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.NumericUpDown_MinProjectArea.Name = "NumericUpDown_MinProjectArea"
        Me.NumericUpDown_MinProjectArea.Size = New System.Drawing.Size(205, 22)
        Me.NumericUpDown_MinProjectArea.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 209)
        Me.Label7.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(167, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Disable RoI (region of interest):"
        '
        'CheckBox_DisableRoI
        '
        Me.CheckBox_DisableRoI.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox_DisableRoI.AutoSize = True
        Me.CheckBox_DisableRoI.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CheckBox_DisableRoI.Location = New System.Drawing.Point(432, 207)
        Me.CheckBox_DisableRoI.Name = "CheckBox_DisableRoI"
        Me.CheckBox_DisableRoI.Size = New System.Drawing.Size(35, 18)
        Me.CheckBox_DisableRoI.TabIndex = 12
        Me.CheckBox_DisableRoI.Text = " "
        Me.CheckBox_DisableRoI.UseVisualStyleBackColor = True
        '
        'GroupBox_ExtensionSettings
        '
        Me.GroupBox_ExtensionSettings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_ExtensionSettings.Controls.Add(Me.Label19)
        Me.GroupBox_ExtensionSettings.Controls.Add(Me.NumericUpDown_MinTrackerDeviation)
        Me.GroupBox_ExtensionSettings.Controls.Add(Me.NumericUpDown_MinPointsInContour)
        Me.GroupBox_ExtensionSettings.Controls.Add(Me.Label18)
        Me.GroupBox_ExtensionSettings.Controls.Add(Me.NumericUpDown_ControllerPredictionHistory)
        Me.GroupBox_ExtensionSettings.Controls.Add(Me.Label17)
        Me.GroupBox_ExtensionSettings.Controls.Add(Me.NumericUpDown_ControllerPredictionSmoothing)
        Me.GroupBox_ExtensionSettings.Controls.Add(Me.Label16)
        Me.GroupBox_ExtensionSettings.Controls.Add(Me.NumericUpDown_ControllerPrediction)
        Me.GroupBox_ExtensionSettings.Controls.Add(Me.Label15)
        Me.GroupBox_ExtensionSettings.Controls.Add(Me.CheckBox_OptimizedRoI)
        Me.GroupBox_ExtensionSettings.Controls.Add(Me.Label9)
        Me.GroupBox_ExtensionSettings.Controls.Add(Me.NumericUpDown_OccludeArea)
        Me.GroupBox_ExtensionSettings.Controls.Add(Me.Label8)
        Me.GroupBox_ExtensionSettings.Location = New System.Drawing.Point(3, 231)
        Me.GroupBox_ExtensionSettings.Name = "GroupBox_ExtensionSettings"
        Me.GroupBox_ExtensionSettings.Size = New System.Drawing.Size(634, 208)
        Me.GroupBox_ExtensionSettings.TabIndex = 13
        Me.GroupBox_ExtensionSettings.TabStop = False
        Me.GroupBox_ExtensionSettings.Text = "PSMoveServiceEx"
        '
        'CheckBox_OptimizedRoI
        '
        Me.CheckBox_OptimizedRoI.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox_OptimizedRoI.AutoSize = True
        Me.CheckBox_OptimizedRoI.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CheckBox_OptimizedRoI.Location = New System.Drawing.Point(429, 175)
        Me.CheckBox_OptimizedRoI.Name = "CheckBox_OptimizedRoI"
        Me.CheckBox_OptimizedRoI.Size = New System.Drawing.Size(35, 18)
        Me.CheckBox_OptimizedRoI.TabIndex = 14
        Me.CheckBox_OptimizedRoI.Text = " "
        Me.CheckBox_OptimizedRoI.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 177)
        Me.Label9.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(218, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Enable optimized RoI (region of interest):"
        '
        'NumericUpDown_OccludeArea
        '
        Me.NumericUpDown_OccludeArea.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDown_OccludeArea.Location = New System.Drawing.Point(429, 100)
        Me.NumericUpDown_OccludeArea.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.NumericUpDown_OccludeArea.Name = "NumericUpDown_OccludeArea"
        Me.NumericUpDown_OccludeArea.Size = New System.Drawing.Size(199, 22)
        Me.NumericUpDown_OccludeArea.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 102)
        Me.Label8.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(218, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Minimum occluded area on tracking loss:"
        '
        'Button_Apply
        '
        Me.Button_Apply.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Apply.Enabled = False
        Me.Button_Apply.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button_Apply.Location = New System.Drawing.Point(509, 445)
        Me.Button_Apply.Name = "Button_Apply"
        Me.Button_Apply.Size = New System.Drawing.Size(128, 32)
        Me.Button_Apply.TabIndex = 14
        Me.Button_Apply.Text = "Apply"
        Me.Button_Apply.UseVisualStyleBackColor = True
        '
        'Button_Refresh
        '
        Me.Button_Refresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button_Refresh.Location = New System.Drawing.Point(375, 445)
        Me.Button_Refresh.Name = "Button_Refresh"
        Me.Button_Refresh.Size = New System.Drawing.Size(128, 32)
        Me.Button_Refresh.TabIndex = 15
        Me.Button_Refresh.Text = "Refresh"
        Me.Button_Refresh.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Button_FactoryAll)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Button_FactoryControllers)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Button_FactoryTracker)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Button_ResetTrackerHz10)
        Me.GroupBox2.Controls.Add(Me.Button_ResetTrackerHz40)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 483)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(634, 126)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Troubleshooting"
        '
        'Button_FactoryAll
        '
        Me.Button_FactoryAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_FactoryAll.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button_FactoryAll.Location = New System.Drawing.Point(429, 94)
        Me.Button_FactoryAll.Name = "Button_FactoryAll"
        Me.Button_FactoryAll.Size = New System.Drawing.Size(199, 23)
        Me.Button_FactoryAll.TabIndex = 24
        Me.Button_FactoryAll.Text = "Reset"
        Me.Button_FactoryAll.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 99)
        Me.Label13.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(132, 13)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Factory reset everything:"
        '
        'Button_FactoryControllers
        '
        Me.Button_FactoryControllers.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_FactoryControllers.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button_FactoryControllers.Location = New System.Drawing.Point(429, 69)
        Me.Button_FactoryControllers.Name = "Button_FactoryControllers"
        Me.Button_FactoryControllers.Size = New System.Drawing.Size(199, 23)
        Me.Button_FactoryControllers.TabIndex = 22
        Me.Button_FactoryControllers.Text = "Reset"
        Me.Button_FactoryControllers.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 74)
        Me.Label12.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(133, 13)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Factory reset controllers:"
        '
        'Button_FactoryTracker
        '
        Me.Button_FactoryTracker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_FactoryTracker.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button_FactoryTracker.Location = New System.Drawing.Point(429, 44)
        Me.Button_FactoryTracker.Name = "Button_FactoryTracker"
        Me.Button_FactoryTracker.Size = New System.Drawing.Size(199, 23)
        Me.Button_FactoryTracker.TabIndex = 20
        Me.Button_FactoryTracker.Text = "Reset"
        Me.Button_FactoryTracker.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 49)
        Me.Label11.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(118, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Factory reset trackers:"
        '
        'Button_ResetTrackerHz10
        '
        Me.Button_ResetTrackerHz10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_ResetTrackerHz10.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button_ResetTrackerHz10.Location = New System.Drawing.Point(429, 19)
        Me.Button_ResetTrackerHz10.Name = "Button_ResetTrackerHz10"
        Me.Button_ResetTrackerHz10.Size = New System.Drawing.Size(92, 23)
        Me.Button_ResetTrackerHz10.TabIndex = 18
        Me.Button_ResetTrackerHz10.Text = "Reset (10 Hz)"
        Me.Button_ResetTrackerHz10.UseVisualStyleBackColor = True
        '
        'Button_ResetTrackerHz40
        '
        Me.Button_ResetTrackerHz40.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_ResetTrackerHz40.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button_ResetTrackerHz40.Location = New System.Drawing.Point(536, 19)
        Me.Button_ResetTrackerHz40.Name = "Button_ResetTrackerHz40"
        Me.Button_ResetTrackerHz40.Size = New System.Drawing.Size(92, 23)
        Me.Button_ResetTrackerHz40.TabIndex = 17
        Me.Button_ResetTrackerHz40.Text = "Reset (40 Hz)"
        Me.Button_ResetTrackerHz40.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 24)
        Me.Label10.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(107, 13)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Reset all tracker Hz:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(3, 159)
        Me.Label14.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(142, 13)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "Exclude opposed cameras:"
        '
        'CheckBox_ExlcudeCameras
        '
        Me.CheckBox_ExlcudeCameras.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBox_ExlcudeCameras.AutoSize = True
        Me.CheckBox_ExlcudeCameras.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CheckBox_ExlcudeCameras.Location = New System.Drawing.Point(432, 157)
        Me.CheckBox_ExlcudeCameras.Name = "CheckBox_ExlcudeCameras"
        Me.CheckBox_ExlcudeCameras.Size = New System.Drawing.Size(35, 18)
        Me.CheckBox_ExlcudeCameras.TabIndex = 18
        Me.CheckBox_ExlcudeCameras.Text = " "
        Me.CheckBox_ExlcudeCameras.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 24)
        Me.Label15.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(200, 13)
        Me.Label15.TabIndex = 16
        Me.Label15.Text = "Controller position prediction power:"
        '
        'NumericUpDown_ControllerPrediction
        '
        Me.NumericUpDown_ControllerPrediction.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDown_ControllerPrediction.DecimalPlaces = 2
        Me.NumericUpDown_ControllerPrediction.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.NumericUpDown_ControllerPrediction.Location = New System.Drawing.Point(429, 22)
        Me.NumericUpDown_ControllerPrediction.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NumericUpDown_ControllerPrediction.Name = "NumericUpDown_ControllerPrediction"
        Me.NumericUpDown_ControllerPrediction.Size = New System.Drawing.Size(199, 22)
        Me.NumericUpDown_ControllerPrediction.TabIndex = 17
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(35, 49)
        Me.Label16.Margin = New System.Windows.Forms.Padding(32, 6, 3, 6)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(223, 13)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "Controller position prediction smoothing:"
        '
        'NumericUpDown_ControllerPredictionSmoothing
        '
        Me.NumericUpDown_ControllerPredictionSmoothing.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDown_ControllerPredictionSmoothing.DecimalPlaces = 2
        Me.NumericUpDown_ControllerPredictionSmoothing.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.NumericUpDown_ControllerPredictionSmoothing.Location = New System.Drawing.Point(429, 47)
        Me.NumericUpDown_ControllerPredictionSmoothing.Maximum = New Decimal(New Integer() {99, 0, 0, 131072})
        Me.NumericUpDown_ControllerPredictionSmoothing.Name = "NumericUpDown_ControllerPredictionSmoothing"
        Me.NumericUpDown_ControllerPredictionSmoothing.Size = New System.Drawing.Size(199, 22)
        Me.NumericUpDown_ControllerPredictionSmoothing.TabIndex = 19
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(35, 74)
        Me.Label17.Margin = New System.Windows.Forms.Padding(32, 6, 3, 6)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(202, 13)
        Me.Label17.TabIndex = 20
        Me.Label17.Text = "Controller position prediction history:"
        '
        'NumericUpDown_ControllerPredictionHistory
        '
        Me.NumericUpDown_ControllerPredictionHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDown_ControllerPredictionHistory.Location = New System.Drawing.Point(429, 72)
        Me.NumericUpDown_ControllerPredictionHistory.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.NumericUpDown_ControllerPredictionHistory.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown_ControllerPredictionHistory.Name = "NumericUpDown_ControllerPredictionHistory"
        Me.NumericUpDown_ControllerPredictionHistory.Size = New System.Drawing.Size(199, 22)
        Me.NumericUpDown_ControllerPredictionHistory.TabIndex = 21
        Me.NumericUpDown_ControllerPredictionHistory.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumericUpDown_MinPointsInContour
        '
        Me.NumericUpDown_MinPointsInContour.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDown_MinPointsInContour.Location = New System.Drawing.Point(429, 125)
        Me.NumericUpDown_MinPointsInContour.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.NumericUpDown_MinPointsInContour.Name = "NumericUpDown_MinPointsInContour"
        Me.NumericUpDown_MinPointsInContour.Size = New System.Drawing.Size(199, 22)
        Me.NumericUpDown_MinPointsInContour.TabIndex = 22
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 127)
        Me.Label18.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(151, 13)
        Me.Label18.TabIndex = 23
        Me.Label18.Text = "Minimum points in contour:"
        '
        'NumericUpDown_MinTrackerDeviation
        '
        Me.NumericUpDown_MinTrackerDeviation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDown_MinTrackerDeviation.DecimalPlaces = 2
        Me.NumericUpDown_MinTrackerDeviation.Location = New System.Drawing.Point(429, 150)
        Me.NumericUpDown_MinTrackerDeviation.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.NumericUpDown_MinTrackerDeviation.Name = "NumericUpDown_MinTrackerDeviation"
        Me.NumericUpDown_MinTrackerDeviation.Size = New System.Drawing.Size(199, 22)
        Me.NumericUpDown_MinTrackerDeviation.TabIndex = 24
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 152)
        Me.Label19.Margin = New System.Windows.Forms.Padding(3, 6, 3, 6)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(194, 13)
        Me.Label19.TabIndex = 25
        Me.Label19.Text = "Maximum tracker position deviation:"
        '
        'UC_AdvancedSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.CheckBox_ExlcudeCameras)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button_Refresh)
        Me.Controls.Add(Me.Button_Apply)
        Me.Controls.Add(Me.GroupBox_ExtensionSettings)
        Me.Controls.Add(Me.CheckBox_DisableRoI)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.NumericUpDown_MinProjectArea)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.NumericUpDown_TrackerSleep)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.NumericUpDown_OpticalTimeout)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CheckBox_TriangulationOnly)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.NumericUpDown_ControllerSmoothing)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "UC_AdvancedSettings"
        Me.Size = New System.Drawing.Size(640, 673)
        CType(Me.NumericUpDown_ControllerSmoothing, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown_OpticalTimeout, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown_TrackerSleep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown_MinProjectArea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_ExtensionSettings.ResumeLayout(False)
        Me.GroupBox_ExtensionSettings.PerformLayout()
        CType(Me.NumericUpDown_OccludeArea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NumericUpDown_ControllerPrediction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown_ControllerPredictionSmoothing, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown_ControllerPredictionHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown_MinPointsInContour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown_MinTrackerDeviation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents NumericUpDown_ControllerSmoothing As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents CheckBox_TriangulationOnly As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents NumericUpDown_OpticalTimeout As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents NumericUpDown_TrackerSleep As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents NumericUpDown_MinProjectArea As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents CheckBox_DisableRoI As CheckBox
    Friend WithEvents GroupBox_ExtensionSettings As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents CheckBox_OptimizedRoI As CheckBox
    Friend WithEvents Label9 As Label
    Friend WithEvents NumericUpDown_OccludeArea As NumericUpDown
    Friend WithEvents Button_Apply As Button
    Friend WithEvents Button_Refresh As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Button_ResetTrackerHz10 As Button
    Friend WithEvents Button_ResetTrackerHz40 As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents Button_FactoryAll As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents Button_FactoryControllers As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents Button_FactoryTracker As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents CheckBox_ExlcudeCameras As CheckBox
    Friend WithEvents Label19 As Label
    Friend WithEvents NumericUpDown_MinTrackerDeviation As NumericUpDown
    Friend WithEvents NumericUpDown_MinPointsInContour As NumericUpDown
    Friend WithEvents Label18 As Label
    Friend WithEvents NumericUpDown_ControllerPredictionHistory As NumericUpDown
    Friend WithEvents Label17 As Label
    Friend WithEvents NumericUpDown_ControllerPredictionSmoothing As NumericUpDown
    Friend WithEvents Label16 As Label
    Friend WithEvents NumericUpDown_ControllerPrediction As NumericUpDown
    Friend WithEvents Label15 As Label
End Class
