Imports System.Runtime.InteropServices

Public Class FormMain
    Private g_mBenchThread As Threading.Thread
    Private g_mThreadLock As New Object

    Private g_iFpsChecks As Integer() = New Integer() {10, 20, 30, 40, 50, 60, 75, 83}

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ComboBox_Sensitivity.Items.Clear()
        ComboBox_Sensitivity.Items.Add("Low")
        ComboBox_Sensitivity.Items.Add("Normal")
        ComboBox_Sensitivity.Items.Add("High")
        ComboBox_Sensitivity.SelectedIndex = 1

        Me.Text &= String.Format(" v.{0}", Application.ProductVersion)
    End Sub

    Private Sub Button_StartBench_Click(sender As Object, e As EventArgs) Handles Button_StartBench.Click
        If (g_mBenchThread IsNot Nothing AndAlso g_mBenchThread.IsAlive) Then
            Return
        End If

        Dim iMaxAvgFPs = 5
        Select Case (ComboBox_Sensitivity.SelectedIndex)
            Case 0
                iMaxAvgFPs = 15
            Case 1
                iMaxAvgFPs = 10
            Case 2
                iMaxAvgFPs = 5
        End Select

        g_mBenchThread = New Threading.Thread(Sub() BenchmarkThread(New TimeSpan(0, 0, 30), 100, iMaxAvgFPs))
        g_mBenchThread.IsBackground = True
        g_mBenchThread.Start()
    End Sub

    Private Sub Button_StartQuickBench_Click(sender As Object, e As EventArgs) Handles Button_StartQuickBench.Click
        If (g_mBenchThread IsNot Nothing AndAlso g_mBenchThread.IsAlive) Then
            Return
        End If

        Dim iMaxAvgFPs = 5
        Select Case (ComboBox_Sensitivity.SelectedIndex)
            Case 0
                iMaxAvgFPs = 15
            Case 1
                iMaxAvgFPs = 10
            Case 2
                iMaxAvgFPs = 5
        End Select

        g_mBenchThread = New Threading.Thread(Sub() BenchmarkThread(New TimeSpan(0, 0, 5), 100, iMaxAvgFPs))
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

    Private Sub BenchmarkThread(mBenchTime As TimeSpan, iSamplesSplit As Integer, iMaxFpsDiff As Integer, Optional iStartFpsIndex As Integer = 0)
        Try
            Me.Invoke(Sub() Button_StartBench.Enabled = False)
            Me.Invoke(Sub() Button_StartQuickBench.Enabled = False)
            Me.Invoke(Sub() ComboBox_Sensitivity.Enabled = False)
            Me.Invoke(Sub() Button_BenchAbort.Enabled = True)

            Dim bHang As Boolean = False
            Dim bBadFPS As Boolean = False
            Dim iTotalCameras As Integer = 0
            Dim bFailed As Boolean = False
            Dim i As Integer

            Dim sTestCamFile As String = IO.Path.Combine(IO.Path.GetTempPath(), IO.Path.GetRandomFileName() & ".exe")
            Try

                Me.Invoke(Sub() ProgressBar1.Maximum = g_iFpsChecks.Length)
                Me.Invoke(Sub() ProgressBar1.Value = 0)
                Me.Invoke(Sub() Label_BenchStatus.Text = "Creating files...")

                Dim iTestCameraBin As Byte() = My.Resources.test_camera_bin

                'WORKAROUND: Use this instead of IO.File.WriteAllBytes(). Avira AntiVirus hates it!
                IO.File.Delete(sTestCamFile)

                Using mStream As New IO.FileStream(sTestCamFile, IO.FileMode.Create, IO.FileAccess.Write)
                    mStream.Write(iTestCameraBin, 0, iTestCameraBin.Length)
                End Using

                Me.Invoke(Sub() Label_BenchStatus.Text = "Running test...")

                Dim sReadLines As New List(Of String)
                Dim mReadLinesTimeout As New Stopwatch

                For i = iStartFpsIndex To g_iFpsChecks.Length - 1
                    Dim mCamProcess As New Process()

                    Try
                        mCamProcess.StartInfo.FileName = sTestCamFile
                        mCamProcess.StartInfo.WorkingDirectory = IO.Path.GetDirectoryName(sTestCamFile)
                        mCamProcess.StartInfo.UseShellExecute = False
                        mCamProcess.StartInfo.CreateNoWindow = True

                        mCamProcess.StartInfo.RedirectStandardInput = True
                        mCamProcess.StartInfo.RedirectStandardOutput = True

                        mCamProcess.Start()

                        mCamProcess.StandardInput.WriteLine(CStr(g_iFpsChecks(i)))
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
                        Dim mSampleTime As New Stopwatch
                        mSampleTime.Start()

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
                                        If (sLine.Contains("ps3eye::PS3EYECam::getDevices() found") AndAlso sLine.Contains("devices.")) Then
                                            Dim sSplit As String() = sLine.Split(" "c)
                                            If (sSplit.Length > 2) Then
                                                Dim sCameras As String = sSplit(sSplit.Length - 2)
                                                Dim iCameras As Integer = CInt(sCameras)

                                                iTotalCameras = iCameras
                                            End If
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

                            If (iTotalCameras < 1) Then
                                Exit While
                            End If

                            If (iFPSList.Count > iSamplesSplit) Then
                                Dim iFPSCount As ULong = 0

                                For j = 0 To iFPSList.Count - 1
                                    iFPSCount += CULng(Math.Ceiling(iFPSList(j)))
                                Next

                                Dim iAvgFPS = (iFPSCount / iFPSList.Count - 1)

                                Debug.WriteLine("AVG FPS: " & iAvgFPS)

                                If (iAvgFPS < g_iFpsChecks(i) - iMaxFpsDiff) Then
                                    bBadFPS = True
                                    Exit While
                                End If

                                iFPSList.Clear()

                                If (mSampleTime.ElapsedTicks > mBenchTime.Ticks) Then
                                    Exit While
                                End If
                            End If
                        End While
                    Finally
                        Try
                            mCamProcess.Kill()
                            mCamProcess.WaitForExit()
                        Catch ex As Exception
                        End Try
                    End Try

                    If (bHang OrElse bBadFPS OrElse iTotalCameras < 1) Then
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

            If (iTotalCameras < 1) Then
                Me.Invoke(Sub() ProgressBar1.Value = ProgressBar1.Maximum)
                Me.Invoke(Sub() Label_BenchStatus.Text = String.Format("Test ended!{0}Result: Aborted, no cameras found!", Environment.NewLine))

            ElseIf (bHang) Then
                Me.Invoke(Sub() ProgressBar1.Value = ProgressBar1.Maximum)
                Me.Invoke(Sub() Label_BenchStatus.Text = String.Format("Test ended!{0}Result: Aborted, camera stream Hung! Cameras: {1}, FPS reached: {2}", Environment.NewLine, iTotalCameras, g_iFpsChecks(Math.Max(0, i - 1))))

            ElseIf (bBadFPS) Then
                Me.Invoke(Sub() ProgressBar1.Value = ProgressBar1.Maximum)
                Me.Invoke(Sub() Label_BenchStatus.Text = String.Format("Test ended!{0}Result: Aborted, unstable framerate! Cameras: {1}, FPS reached: {2}", Environment.NewLine, iTotalCameras, g_iFpsChecks(Math.Max(0, i - 1))))

            Else
                Me.Invoke(Sub() ProgressBar1.Value = ProgressBar1.Maximum)
                Me.Invoke(Sub() Label_BenchStatus.Text = String.Format("Test ended!{0}Result: Finished! Cameras: {1}, FPS reached: {2}", Environment.NewLine, iTotalCameras, g_iFpsChecks(g_iFpsChecks.Length - 1)))
            End If

        Catch ex As Threading.ThreadAbortException
            Me.BeginInvoke(Sub() ProgressBar1.Value = ProgressBar1.Maximum)
            Me.BeginInvoke(Sub() Label_BenchStatus.Text = String.Format("Test aborted!"))
            Throw
        Catch ex As Exception
            Me.BeginInvoke(Sub() ProgressBar1.Value = ProgressBar1.Maximum)
            Me.BeginInvoke(Sub() Label_BenchStatus.Text = String.Format("Test error!{1}Error: {0}", ex.Message, Environment.NewLine))
        Finally
            Me.BeginInvoke(Sub() Button_StartBench.Enabled = True)
            Me.BeginInvoke(Sub() Button_StartQuickBench.Enabled = True)
            Me.BeginInvoke(Sub() ComboBox_Sensitivity.Enabled = True)
            Me.BeginInvoke(Sub() Button_BenchAbort.Enabled = False)
        End Try
    End Sub

    Private Sub FormMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        CleanUp()
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
                .sWndTitle = sWndTitle
            }
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
