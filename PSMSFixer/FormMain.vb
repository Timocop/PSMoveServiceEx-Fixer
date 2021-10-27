Imports System.Runtime.InteropServices

Public Class FormMain
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call. 
        Me.Text &= String.Format(" ({0})", Application.ProductVersion)
    End Sub

    Private Sub Button_RestartPSMS_Click(sender As Object, e As EventArgs) Handles Button_RestartPSMS.Click
        Try
            Dim sPSMSPath As String = Nothing

            Dim pProcesses As Process() = Process.GetProcessesByName("PSMoveService")
            If (pProcesses Is Nothing OrElse pProcesses.Length < 1) Then
                Throw New ArgumentException("PSMoveService not running.")
            End If

            For Each mProcess In pProcesses
                If (sPSMSPath Is Nothing) Then
                    sPSMSPath = mProcess.MainModule.FileName
                End If

                If (mProcess.CloseMainWindow()) Then
                    mProcess.WaitForExit(10000)
                Else
                    mProcess.Kill()
                End If
            Next

            If (sPSMSPath Is Nothing OrElse Not IO.File.Exists(sPSMSPath)) Then
                Throw New ArgumentException("PSMoveService executable not found. Please start manualy.")
            End If

            Dim mNewProcess As New Process()
            mNewProcess.StartInfo.FileName = sPSMSPath
            mNewProcess.StartInfo.WorkingDirectory = IO.Path.GetDirectoryName(sPSMSPath)
            mNewProcess.StartInfo.UseShellExecute = False
            mNewProcess.Start()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub FormMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CleanUp()
    End Sub

    Private Sub CleanUp()
        'Dispose these earlier because mutli-thread aborts
        UC_ControllerMagDriftFix1.Dispose()
        UC_PlayspaceFix1.Dispose()
        UC_PSEyeBench1.Dispose()
    End Sub
End Class
