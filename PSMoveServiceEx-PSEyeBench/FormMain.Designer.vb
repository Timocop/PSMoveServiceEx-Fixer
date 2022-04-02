<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If (disposing) Then
                CleanUp()
            End If

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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.Button_BenchAbort = New System.Windows.Forms.Button()
        Me.Button_StartQuickBench = New System.Windows.Forms.Button()
        Me.Label_BenchStatus = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Button_StartBench = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox_Sensitivity = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button_BenchAbort
        '
        Me.Button_BenchAbort.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_BenchAbort.Enabled = False
        Me.Button_BenchAbort.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button_BenchAbort.Location = New System.Drawing.Point(316, 246)
        Me.Button_BenchAbort.Name = "Button_BenchAbort"
        Me.Button_BenchAbort.Size = New System.Drawing.Size(121, 23)
        Me.Button_BenchAbort.TabIndex = 11
        Me.Button_BenchAbort.Text = "Abort test"
        Me.Button_BenchAbort.UseVisualStyleBackColor = True
        '
        'Button_StartQuickBench
        '
        Me.Button_StartQuickBench.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_StartQuickBench.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button_StartQuickBench.Location = New System.Drawing.Point(443, 246)
        Me.Button_StartQuickBench.Name = "Button_StartQuickBench"
        Me.Button_StartQuickBench.Size = New System.Drawing.Size(121, 23)
        Me.Button_StartQuickBench.TabIndex = 10
        Me.Button_StartQuickBench.Text = "Run quick test"
        Me.Button_StartQuickBench.UseVisualStyleBackColor = True
        '
        'Label_BenchStatus
        '
        Me.Label_BenchStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_BenchStatus.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_BenchStatus.Location = New System.Drawing.Point(12, 60)
        Me.Label_BenchStatus.Name = "Label_BenchStatus"
        Me.Label_BenchStatus.Size = New System.Drawing.Size(679, 64)
        Me.Label_BenchStatus.TabIndex = 9
        Me.Label_BenchStatus.Text = "Click ""Run Test"" to start."
        Me.Label_BenchStatus.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(15, 127)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(676, 23)
        Me.ProgressBar1.TabIndex = 8
        '
        'Button_StartBench
        '
        Me.Button_StartBench.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_StartBench.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button_StartBench.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_StartBench.Location = New System.Drawing.Point(570, 246)
        Me.Button_StartBench.Name = "Button_StartBench"
        Me.Button_StartBench.Size = New System.Drawing.Size(121, 23)
        Me.Button_StartBench.TabIndex = 7
        Me.Button_StartBench.Text = "Run test"
        Me.Button_StartBench.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(679, 45)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "A simple PSEye camera stability test tool to check if your cameras are stable eno" &
    "ugh on different framerates."
        '
        'ComboBox_Sensitivity
        '
        Me.ComboBox_Sensitivity.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ComboBox_Sensitivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Sensitivity.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBox_Sensitivity.FormattingEnabled = True
        Me.ComboBox_Sensitivity.Location = New System.Drawing.Point(79, 248)
        Me.ComboBox_Sensitivity.Name = "ComboBox_Sensitivity"
        Me.ComboBox_Sensitivity.Size = New System.Drawing.Size(129, 21)
        Me.ComboBox_Sensitivity.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 251)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Sensitivity:"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(703, 281)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBox_Sensitivity)
        Me.Controls.Add(Me.Button_BenchAbort)
        Me.Controls.Add(Me.Button_StartQuickBench)
        Me.Controls.Add(Me.Label_BenchStatus)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Button_StartBench)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PSMoveServiceEx - PSEye Stability Test"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button_BenchAbort As Button
    Friend WithEvents Button_StartQuickBench As Button
    Friend WithEvents Label_BenchStatus As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Button_StartBench As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox_Sensitivity As ComboBox
    Friend WithEvents Label2 As Label
End Class
