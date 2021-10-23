<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.Button_RestartPSMS = New System.Windows.Forms.Button()
        Me.TabPage_ControllerMagDrift = New System.Windows.Forms.TabPage()
        Me.UC_ControllerMagDriftFix1 = New PSMSFixer.UC_ControllerMagDriftFix()
        Me.TabPage_PlayspaceScale = New System.Windows.Forms.TabPage()
        Me.UC_PlayspaceFix1 = New PSMSFixer.UC_PlayspaceFix()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage_PSEyeBench = New System.Windows.Forms.TabPage()
        Me.UC_PSEyeBench1 = New PSMSFixer.UC_PSEyeBench()
        Me.TabPage_AdvancedSettings = New System.Windows.Forms.TabPage()
        Me.UC_AdvancedSettings1 = New PSMSFixer.UC_AdvancedSettings()
        Me.TabPage_ControllerMagDrift.SuspendLayout()
        Me.TabPage_PlayspaceScale.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage_PSEyeBench.SuspendLayout()
        Me.TabPage_AdvancedSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button_RestartPSMS
        '
        Me.Button_RestartPSMS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_RestartPSMS.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button_RestartPSMS.Location = New System.Drawing.Point(455, 393)
        Me.Button_RestartPSMS.Name = "Button_RestartPSMS"
        Me.Button_RestartPSMS.Size = New System.Drawing.Size(157, 36)
        Me.Button_RestartPSMS.TabIndex = 1
        Me.Button_RestartPSMS.Text = "Restart PSMoveService"
        Me.Button_RestartPSMS.UseVisualStyleBackColor = True
        '
        'TabPage_ControllerMagDrift
        '
        Me.TabPage_ControllerMagDrift.AutoScroll = True
        Me.TabPage_ControllerMagDrift.Controls.Add(Me.UC_ControllerMagDriftFix1)
        Me.TabPage_ControllerMagDrift.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_ControllerMagDrift.Name = "TabPage_ControllerMagDrift"
        Me.TabPage_ControllerMagDrift.Size = New System.Drawing.Size(592, 349)
        Me.TabPage_ControllerMagDrift.TabIndex = 1
        Me.TabPage_ControllerMagDrift.Text = "Controller Magnetic Drift"
        Me.TabPage_ControllerMagDrift.UseVisualStyleBackColor = True
        '
        'UC_ControllerMagDriftFix1
        '
        Me.UC_ControllerMagDriftFix1.AutoSize = True
        Me.UC_ControllerMagDriftFix1.BackColor = System.Drawing.Color.White
        Me.UC_ControllerMagDriftFix1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UC_ControllerMagDriftFix1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UC_ControllerMagDriftFix1.Location = New System.Drawing.Point(0, 0)
        Me.UC_ControllerMagDriftFix1.Name = "UC_ControllerMagDriftFix1"
        Me.UC_ControllerMagDriftFix1.Size = New System.Drawing.Size(575, 690)
        Me.UC_ControllerMagDriftFix1.TabIndex = 0
        '
        'TabPage_PlayspaceScale
        '
        Me.TabPage_PlayspaceScale.AutoScroll = True
        Me.TabPage_PlayspaceScale.Controls.Add(Me.UC_PlayspaceFix1)
        Me.TabPage_PlayspaceScale.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_PlayspaceScale.Name = "TabPage_PlayspaceScale"
        Me.TabPage_PlayspaceScale.Size = New System.Drawing.Size(592, 349)
        Me.TabPage_PlayspaceScale.TabIndex = 0
        Me.TabPage_PlayspaceScale.Text = "Playspace Scaling"
        Me.TabPage_PlayspaceScale.UseVisualStyleBackColor = True
        '
        'UC_PlayspaceFix1
        '
        Me.UC_PlayspaceFix1.AutoSize = True
        Me.UC_PlayspaceFix1.BackColor = System.Drawing.Color.White
        Me.UC_PlayspaceFix1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UC_PlayspaceFix1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UC_PlayspaceFix1.Location = New System.Drawing.Point(0, 0)
        Me.UC_PlayspaceFix1.Margin = New System.Windows.Forms.Padding(0)
        Me.UC_PlayspaceFix1.Name = "UC_PlayspaceFix1"
        Me.UC_PlayspaceFix1.Size = New System.Drawing.Size(592, 310)
        Me.UC_PlayspaceFix1.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage_PlayspaceScale)
        Me.TabControl1.Controls.Add(Me.TabPage_ControllerMagDrift)
        Me.TabControl1.Controls.Add(Me.TabPage_PSEyeBench)
        Me.TabControl1.Controls.Add(Me.TabPage_AdvancedSettings)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(600, 375)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage_PSEyeBench
        '
        Me.TabPage_PSEyeBench.AutoScroll = True
        Me.TabPage_PSEyeBench.Controls.Add(Me.UC_PSEyeBench1)
        Me.TabPage_PSEyeBench.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_PSEyeBench.Name = "TabPage_PSEyeBench"
        Me.TabPage_PSEyeBench.Size = New System.Drawing.Size(592, 349)
        Me.TabPage_PSEyeBench.TabIndex = 2
        Me.TabPage_PSEyeBench.Text = "PSEye Camera Stability Test"
        Me.TabPage_PSEyeBench.UseVisualStyleBackColor = True
        '
        'UC_PSEyeBench1
        '
        Me.UC_PSEyeBench1.AutoSize = True
        Me.UC_PSEyeBench1.BackColor = System.Drawing.Color.White
        Me.UC_PSEyeBench1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UC_PSEyeBench1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UC_PSEyeBench1.Location = New System.Drawing.Point(0, 0)
        Me.UC_PSEyeBench1.Name = "UC_PSEyeBench1"
        Me.UC_PSEyeBench1.Size = New System.Drawing.Size(592, 173)
        Me.UC_PSEyeBench1.TabIndex = 0
        '
        'TabPage_AdvancedSettings
        '
        Me.TabPage_AdvancedSettings.AutoScroll = True
        Me.TabPage_AdvancedSettings.Controls.Add(Me.UC_AdvancedSettings1)
        Me.TabPage_AdvancedSettings.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_AdvancedSettings.Name = "TabPage_AdvancedSettings"
        Me.TabPage_AdvancedSettings.Size = New System.Drawing.Size(592, 349)
        Me.TabPage_AdvancedSettings.TabIndex = 3
        Me.TabPage_AdvancedSettings.Text = "Advanced Settings"
        Me.TabPage_AdvancedSettings.UseVisualStyleBackColor = True
        '
        'UC_AdvancedSettings1
        '
        Me.UC_AdvancedSettings1.AutoSize = True
        Me.UC_AdvancedSettings1.BackColor = System.Drawing.Color.White
        Me.UC_AdvancedSettings1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UC_AdvancedSettings1.Location = New System.Drawing.Point(0, 0)
        Me.UC_AdvancedSettings1.Name = "UC_AdvancedSettings1"
        Me.UC_AdvancedSettings1.Size = New System.Drawing.Size(575, 461)
        Me.UC_AdvancedSettings1.TabIndex = 0
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(624, 441)
        Me.Controls.Add(Me.Button_RestartPSMS)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimumSize = New System.Drawing.Size(640, 480)
        Me.Name = "FormMain"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PSMS Fixer"
        Me.TabPage_ControllerMagDrift.ResumeLayout(False)
        Me.TabPage_ControllerMagDrift.PerformLayout()
        Me.TabPage_PlayspaceScale.ResumeLayout(False)
        Me.TabPage_PlayspaceScale.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage_PSEyeBench.ResumeLayout(False)
        Me.TabPage_PSEyeBench.PerformLayout()
        Me.TabPage_AdvancedSettings.ResumeLayout(False)
        Me.TabPage_AdvancedSettings.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button_RestartPSMS As Button
    Friend WithEvents TabPage_ControllerMagDrift As TabPage
    Friend WithEvents TabPage_PlayspaceScale As TabPage
    Friend WithEvents UC_PlayspaceFix1 As UC_PlayspaceFix
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents UC_ControllerMagDriftFix1 As UC_ControllerMagDriftFix
    Friend WithEvents TabPage_PSEyeBench As TabPage
    Friend WithEvents UC_PSEyeBench1 As UC_PSEyeBench
    Friend WithEvents TabPage_AdvancedSettings As TabPage
    Friend WithEvents UC_AdvancedSettings1 As UC_AdvancedSettings
End Class
