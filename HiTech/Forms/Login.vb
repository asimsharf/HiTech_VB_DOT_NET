Imports System.Security.AccessControl
Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.Win32
Imports System.Runtime.InteropServices
Imports System.Drawing.Text

Public Class Login

    <DllImport("gdi32.dll", EntryPoint:="AddFontResourceW")>
    Private Shared Function AddFontResourceW(<MarshalAs(UnmanagedType.LPWStr)> ByVal lpFilename As String) As Integer
    End Function

    <DllImport("gdi32.dll", EntryPoint:="RemoveFontResourceW")>
    Private Shared Function RemoveFontResourceW(<MarshalAs(UnmanagedType.LPWStr)> ByVal lpFileName As String) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    <DllImport("user32.dll", EntryPoint:="SendMessageW")>
    Private Shared Function SendMessageW(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
    End Function

    Private Const WM_FONTCHANGE As Integer = &H1D
    Private Const HWND_BROADCAST As Integer = &HFFFF















    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Application.Exit()
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        changefont(Panel1)

        If System.IO.File.Exists(Application.StartupPath & "\SQLSettings.dat") Then
            Try
                Dim FolderPath As String = Application.StartupPath  'Specify the folder here
                Dim UserAccount As String = Environment.UserName  'Specify the user here
                Dim FolderInfo As IO.DirectoryInfo = New IO.DirectoryInfo(FolderPath)
                Dim FolderAcl As New DirectorySecurity
                FolderAcl.AddAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow))
                'FolderAcl.SetAccessRuleProtection(True, False) 'uncomment to remove existing permissions
                FolderInfo.SetAccessControl(FolderAcl)
            Catch ex As Exception

            End Try
        Else
            Me.Hide()
            SqlServerSetting.Reset()
            SqlServerSetting.ShowDialog()
        End If

        Try
            Dim st As String
            Using sr As StreamReader = New StreamReader(Application.StartupPath & "\SQLSettings.dat")
                st = sr.ReadLine()
            End Using

            Dim sSource As String = st
            Dim servst As String = "Source="
            Dim serven As String = ";Initial"
            Dim servIndexStart As Integer = sSource.IndexOf(servst)
            Dim servIndexEnd As Integer = sSource.IndexOf(serven)

            If servIndexStart > -1 AndAlso servIndexEnd > -1 Then
                Dim ser As String = Microsoft.VisualBasic.Strings.Mid(sSource, servIndexStart + servst.Length + 1, servIndexEnd - servIndexStart - servst.Length)
                server = ser
            Else

            End If



            Dim dbst As String = "Catalog="
            Dim dben As String = ";User ID"
            Dim dbIndexStart As Integer = sSource.IndexOf(dbst)
            Dim dbIndexEnd As Integer = sSource.IndexOf(dben)

            If dbIndexStart > -1 AndAlso dbIndexEnd > -1 Then
                Dim dtb As String = Microsoft.VisualBasic.Strings.Mid(sSource, dbIndexStart + dbst.Length + 1, dbIndexEnd - dbIndexStart - dbst.Length)
                db = dtb
            Else

            End If




            Dim userst As String = "User ID="
            Dim useren As String = ";Password="
            Dim userIndexStart As Integer = sSource.IndexOf(userst)
            Dim userIndexEnd As Integer = sSource.IndexOf(useren)

            If userIndexStart > -1 AndAlso userIndexEnd > -1 Then
                Dim usr As String = Microsoft.VisualBasic.Strings.Mid(sSource, userIndexStart + userst.Length + 1, userIndexEnd - userIndexStart - userst.Length)
                userid = usr
            Else

            End If




            Dim passst As String = "Password="
            Dim passen As String = ";MultipleActiveResultSets"
            Dim passIndexStart As Integer = sSource.IndexOf(passst)
            Dim passIndexEnd As Integer = sSource.IndexOf(passen)

            If passIndexStart > -1 AndAlso passIndexEnd > -1 Then
                Dim pss As String = Microsoft.VisualBasic.Strings.Mid(sSource, passIndexStart + passst.Length + 1, passIndexEnd - passIndexStart - passst.Length)
                passw = pss
            Else

            End If
        Catch ex As Exception

        End Try




        Try
            Dim SourceFontFile As String = Application.StartupPath & "\Fonts\Code39AzaleaWide2.ttf"
            Dim DestinationFontFile As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), Path.GetFileName(SourceFontFile))
            If Not File.Exists(DestinationFontFile) Then
                Try
                    File.Copy(SourceFontFile, DestinationFontFile) 'copy the font file to the system's font folder
                Catch ex As Exception

                    Exit Sub
                End Try
                If AddFontResourceW(DestinationFontFile) > 0 Then
                    Dim FontRegKey As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts", True)
                    If FontRegKey IsNot Nothing Then
                        Try
                            FontRegKey.SetValue(Path.GetFileNameWithoutExtension(DestinationFontFile) & " (TrueType)", Path.GetFileName(DestinationFontFile)) 'add a Value to the Fonts registry key for your font.
                        Catch ex As Exception

                        End Try
                        FontRegKey.Close()
                    Else

                    End If
                    SendMessageW(New IntPtr(HWND_BROADCAST), WM_FONTCHANGE, IntPtr.Zero, IntPtr.Zero)
                Else

                End If

            Else
            End If
        Catch ex As Exception

        End Try



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Cursor = Cursors.WaitCursor
        connect()
        Try
            copen()
            cmd = New SqlCommand("SELECT * FROM users WHERE uname = '" & user.Text & "' and upass = '" & pass.Text & "'", con)
            Dim rdr As SqlDataReader = cmd.ExecuteReader

            If Not rdr.HasRows Then
                Cursor = Cursors.Default
                alert("خطأ في اسم المستخدم / كلمة المرور", 0)
                Exit Sub
            End If

            While rdr.Read
                If rdr("ustat").ToString = "Deactive" Then
                    Cursor = Cursors.Default
                    alert("الحساب موقوف", 0)
                    Exit Sub
                End If

                un = rdr("uname")
                ugroup = rdr("ugroup")

                Me.Hide()
                Main.Show()
                Main.BringToFront()
            End While
            cclose()
        Catch ex As Exception
            Cursor = Cursors.Default
            Exit Sub
            Me.BringToFront()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub user_TextChanged_1(sender As Object, e As EventArgs) Handles user.TextChanged
        AcceptButton = Button1
    End Sub

    Private Sub pass_TextChanged(sender As Object, e As EventArgs) Handles pass.TextChanged
        AcceptButton = Button1
    End Sub
End Class