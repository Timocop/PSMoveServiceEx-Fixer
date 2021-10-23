Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions

Public Class UC_PSEyeBench
    Private g_mBenchThread As Threading.Thread
    Private g_mThreadLock As New Object

    Private Sub Button_StartBench_Click(sender As Object, e As EventArgs) Handles Button_StartBench.Click
        If (g_mBenchThread IsNot Nothing AndAlso g_mBenchThread.IsAlive) Then
            Return
        End If

        g_mBenchThread = New Threading.Thread(Sub() BenchmarkThread(1000))
        g_mBenchThread.IsBackground = True
        g_mBenchThread.Start()
    End Sub

    Private Sub Button_StartQuickBench_Click(sender As Object, e As EventArgs) Handles Button_StartQuickBench.Click
        If (g_mBenchThread IsNot Nothing AndAlso g_mBenchThread.IsAlive) Then
            Return
        End If

        g_mBenchThread = New Threading.Thread(Sub() BenchmarkThread(100))
        g_mBenchThread.IsBackground = True
        g_mBenchThread.Start()
    End Sub

    Private Sub Button_BenchAbort_Click(sender As Object, e As EventArgs) Handles Button_BenchAbort.Click
        If (g_mBenchThread IsNot Nothing AndAlso g_mBenchThread.IsAlive) Then
            g_mBenchThread.Abort()
            g_mBenchThread.Join()
            g_mBenchThread = Nothing
            Return
        End If
    End Sub

    Const MAX_FPS_DIFF As Integer = 10

    Private Sub BenchmarkThread(iMaxFpsSamples As Integer)
        Try
            Me.Invoke(Sub() Button_StartBench.Enabled = False)
            Me.Invoke(Sub() Button_StartQuickBench.Enabled = False)
            Me.Invoke(Sub() Button_BenchAbort.Enabled = True)

            Dim bHang As Boolean = False
            Dim bBadFPS As Boolean = False
            Dim bNoCameras As Boolean = False
            Dim bFailed As Boolean = False
            Dim iFpsChecks As Integer() = New Integer() {10, 20, 30, 40, 50, 60, 75, 83}
            Dim i As Integer

            Dim sTestCamFile As String = IO.Path.Combine(IO.Path.GetTempPath(), IO.Path.GetRandomFileName() & ".exe")
            Try

                Me.Invoke(Sub() ProgressBar1.Maximum = iFpsChecks.Length)
                Me.Invoke(Sub() ProgressBar1.Value = 0)
                Me.Invoke(Sub() Label_BenchStatus.Text = "Creating files...")

                IO.File.WriteAllBytes(sTestCamFile, My.Resources.test_camera_bin)

                Me.Invoke(Sub() Label_BenchStatus.Text = "Running test...")

                Dim sReadLines As New List(Of String)
                Dim mReadLinesTimeout As New Stopwatch

                For i = 0 To iFpsChecks.Length - 1
                    Dim mCamProcess As New Process()

                    Try
                        mCamProcess.StartInfo.FileName = sTestCamFile
                        mCamProcess.StartInfo.UseShellExecute = False
                        mCamProcess.StartInfo.CreateNoWindow = True

                        mCamProcess.StartInfo.RedirectStandardInput = True
                        mCamProcess.StartInfo.RedirectStandardOutput = True

                        mCamProcess.Start()

                        mCamProcess.StandardInput.WriteLine(CStr(iFpsChecks(i)))
                        mCamProcess.StandardInput.WriteLine("480")

                        AddHandler mCamProcess.OutputDataReceived, Sub(sender As Object, e As DataReceivedEventArgs)
                                                                       If (e.Data Is Nothing) Then
                                                                           Return
                                                                       End If

                                                                       SyncLock g_mThreadLock
                                                                           sReadLines.Add(e.Data)

                                                                           mReadLinesTimeout.Reset()
                                                                           mReadLinesTimeout.Start()
                                                                       End SyncLock
                                                                   End Sub
                        mCamProcess.BeginOutputReadLine()

                        Dim iFPSList As New List(Of Double)

                        While True
                            Threading.Thread.Sleep(100)

                            'Detect camera frezze 
                            For Each hHandle In ClassWndSearcher.SearchForWindow("", "")
                                Dim sWindowText As New Text.StringBuilder(1024)
                                ClassWndSearcher.GetWindowText(hHandle, sWindowText, sWindowText.Capacity)

                                Dim iProcessId As Integer = -1
                                ClassWndSearcher.GetWindowThreadProcessId(hHandle, iProcessId)
                                If (mCamProcess.Id <> iProcessId) Then
                                    Continue For
                                End If

                                ClassWndSearcher.ShowWindow(hHandle, 0)
                            Next

                            'Read FPS
                            If (True) Then
                                SyncLock g_mThreadLock
                                    If (sReadLines.Count = 0) Then
                                        If (mReadLinesTimeout.Elapsed > New TimeSpan(0, 0, 10)) Then
                                            bHang = True
                                            Exit While
                                        End If
                                    End If

                                    For Each sLine In sReadLines
                                        If (sLine.Contains("found 0 devices.")) Then
                                            bNoCameras = True
                                            Exit While
                                        End If

                                        If (sLine.Contains("Fame rate is set to") AndAlso sLine.Contains("and was actually") AndAlso sLine.Contains("fps")) Then
                                            Dim sSplit As String() = sLine.Split(" "c)
                                            If (sSplit.Length > 2) Then
                                                Dim sFPS As String = sSplit(sSplit.Length - 2)

                                                Dim iFPS As Double = Double.Parse(sFPS, Globalization.NumberStyles.Float, Globalization.CultureInfo.InvariantCulture)

                                                iFPSList.Add(iFPS)
                                            End If
                                        End If
                                    Next

                                    sReadLines.Clear()
                                End SyncLock
                            End If

                            If (iFPSList.Count > iMaxFpsSamples) Then
                                Dim iFPSCount As ULong = 0

                                For j = 0 To iFPSList.Count - 1
                                    iFPSCount += CULng(Math.Ceiling(iFPSList(j)))
                                Next

                                Dim iAvgFPS = (iFPSCount / iFPSList.Count - 1)

                                If (iAvgFPS < iFpsChecks(i) - MAX_FPS_DIFF) Then
                                    bBadFPS = True
                                    Exit While
                                End If

                                iFPSList.Clear()
                                Exit While
                            End If
                        End While
                    Finally
                        Try
                            mCamProcess.Kill()
                            mCamProcess.WaitForExit()
                        Catch ex As Exception
                        End Try
                    End Try

                    If (bHang OrElse bBadFPS OrElse bNoCameras) Then
                        Exit For
                    End If

                    Me.Invoke(Sub() ProgressBar1.Increment(1))
                Next
            Finally
                Try
                    IO.File.Delete(sTestCamFile)
                Catch ex As Exception
                End Try
            End Try

            If (bNoCameras) Then
                Me.Invoke(Sub() ProgressBar1.Value = ProgressBar1.Maximum)
                Me.Invoke(Sub() Label_BenchStatus.Text = String.Format("Test ended!{0}Result: Aborted, no cameras found!", Environment.NewLine))

            ElseIf (bHang) Then
                Me.Invoke(Sub() ProgressBar1.Value = ProgressBar1.Maximum)
                Me.Invoke(Sub() Label_BenchStatus.Text = String.Format("Test ended!{0}Result: Aborted, camera stream Hung! FPS reached: {1}", Environment.NewLine, iFpsChecks(Math.Max(0, i - 1))))

            ElseIf (bBadFPS) Then
                Me.Invoke(Sub() ProgressBar1.Value = ProgressBar1.Maximum)
                Me.Invoke(Sub() Label_BenchStatus.Text = String.Format("Test ended!{0}Result: Aborted, unstable framerate! FPS reached: {1}", Environment.NewLine, iFpsChecks(Math.Max(0, i - 1))))

            Else
                Me.Invoke(Sub() Label_BenchStatus.Text = String.Format("Test ended!{0}Result: Finished! FPS reached: {1}", Environment.NewLine, iFpsChecks(iFpsChecks.Length - 1)))
            End If

        Catch ex As Threading.ThreadAbortException
            Me.BeginInvoke(Sub() Label_BenchStatus.Text = String.Format("Test aborted!"))
            Throw
        Catch ex As Exception
            Me.BeginInvoke(Sub() Label_BenchStatus.Text = String.Format("Test error!{1}Error: {0}", ex.Message, Environment.NewLine))
        Finally
            Me.BeginInvoke(Sub() Button_StartBench.Enabled = True)
            Me.BeginInvoke(Sub() Button_StartQuickBench.Enabled = True)
            Me.BeginInvoke(Sub() Button_BenchAbort.Enabled = False)
        End Try
    End Sub

    Private Sub CleanUp()
        If (g_mBenchThread IsNot Nothing AndAlso g_mBenchThread.IsAlive) Then
            g_mBenchThread.Abort()
            g_mBenchThread.Join()
            g_mBenchThread = Nothing
        End If
    End Sub

    Private Class ClassWndSearcher
        Public Shared Function SearchForWindow(sWndClass As String, sWndTitle As String) As IntPtr()
            Dim mSearchData As New ClassSearchData() With {
                                                    .sWndClass = sWndClass,
                                                    .sWndTitle = sWndTitle}
            EnumWindows(New EnumWindowsProc(AddressOf EnumProc), mSearchData)
            Return mSearchData.hWndList.ToArray
        End Function

        Public Shared Function EnumProc(hWnd As IntPtr, ByRef mSearchData As ClassSearchData) As Boolean
            Dim SB As New Text.StringBuilder(1024)
            GetClassName(hWnd, SB, SB.Capacity)

            If (String.IsNullOrEmpty(mSearchData.sWndClass) OrElse SB.ToString() = mSearchData.sWndClass) Then
                SB = New Text.StringBuilder(1024)
                GetWindowText(hWnd, SB, SB.Capacity)

                If (String.IsNullOrEmpty(mSearchData.sWndTitle) OrElse SB.ToString() = mSearchData.sWndTitle) Then
                    mSearchData.hWndList.Add(hWnd)
                    'Uncomment to only send to one instance
                    'Return False
                End If
            End If

            Return True
        End Function

        Public Class ClassSearchData
            Public sWndClass As String
            Public sWndTitle As String
            Public hWndList As New List(Of IntPtr)
        End Class

        Private Delegate Function EnumWindowsProc(hWnd As IntPtr, ByRef data As ClassSearchData) As Boolean

        <DllImport("user32.dll")>
        Public Shared Function ShowWindow(ByVal hWnd As IntPtr, ByVal nCmdShow As Integer) As Boolean
        End Function

        <DllImport("user32.dll")>
        Public Shared Function GetWindowThreadProcessId(ByVal hWnd As IntPtr, <Out> ByRef lpdwProcessId As Integer) As Integer
        End Function

        <DllImport("user32.dll")>
        Public Shared Function IsHungAppWindow(ByVal hWnd As IntPtr) As Boolean
        End Function

        <DllImport("user32.dll")>
        Private Shared Function EnumWindows(mEnumWindowsProc As EnumWindowsProc, ByRef mSearchData As ClassSearchData) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
        Public Shared Function GetClassName(hWnd As IntPtr, sbClassname As System.Text.StringBuilder, iMaxCount As Integer) As Integer
        End Function

        <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
        Public Shared Function GetWindowText(hWnd As IntPtr, sbTitle As System.Text.StringBuilder, iMaxCount As Integer) As Integer
        End Function
    End Class
End Class
