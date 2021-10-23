<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_PSEyeBench
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button_StartBench = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label_BenchStatus = New System.Windows.Forms.Label()
        Me.Button_StartQuickBench = New System.Windows.Forms.Button()
        Me.Button_BenchAbort = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(634, 45)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "A simple PSEye camera stability test tool to check if your cameras are stable eno" &
    "ugh on different framerates."
        '
        'Button_StartBench
        '
        Me.Button_StartBench.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_StartBench.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button_StartBench.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_StartBench.Location = New System.Drawing.Point(516, 147)
        Me.Button_StartBench.Name = "Button_StartBench"
        Me.Button_StartBench.Size = New System.Drawing.Size(121, 23)
        Me.Button_StartBench.TabIndex = 1
        Me.Button_StartBench.Text = "Run test"
        Me.Button_StartBench.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(6, 118)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(631, 23)
        Me.ProgressBar1.TabIndex = 2
        '
        'Label_BenchStatus
        '
        Me.Label_BenchStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_BenchStatus.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_BenchStatus.Location = New System.Drawing.Point(3, 51)
        Me.Label_BenchStatus.Name = "Label_BenchStatus"
        Me.Label_BenchStatus.Size = New System.Drawing.Size(634, 64)
        Me.Label_BenchStatus.TabIndex = 3
        Me.Label_BenchStatus.Text = "Click ""Run Test"" to start."
        Me.Label_BenchStatus.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Button_StartQuickBench
        '
        Me.Button_StartQuickBench.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_StartQuickBench.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button_StartQuickBench.Location = New System.Drawing.Point(389, 147)
        Me.Button_StartQuickBench.Name = "Button_StartQuickBench"
        Me.Button_StartQuickBench.Size = New System.Drawing.Size(121, 23)
        Me.Button_StartQuickBench.TabIndex = 4
        Me.Button_StartQuickBench.Text = "Run quick test"
        Me.Button_StartQuickBench.UseVisualStyleBackColor = True
        '
        'Button_BenchAbort
        '
        Me.Button_BenchAbort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_BenchAbort.Enabled = False
        Me.Button_BenchAbort.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button_BenchAbort.Location = New System.Drawing.Point(262, 147)
        Me.Button_BenchAbort.Name = "Button_BenchAbort"
        Me.Button_BenchAbort.Size = New System.Drawing.Size(121, 23)
        Me.Button_BenchAbort.TabIndex = 5
        Me.Button_BenchAbort.Text = "Abort test"
        Me.Button_BenchAbort.UseVisualStyleBackColor = True
        '
        'UC_PSEyeBench
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Button_BenchAbort)
        Me.Controls.Add(Me.Button_StartQuickBench)
        Me.Controls.Add(Me.Label_BenchStatus)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Button_StartBench)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "UC_PSEyeBench"
        Me.Size = New System.Drawing.Size(640, 297)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Button_StartBench As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label_BenchStatus As Label
    Friend WithEvents Button_StartQuickBench As Button
    Friend WithEvents Button_BenchAbort As Button
End Class
