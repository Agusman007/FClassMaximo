Imports System.IO
Imports System.Configuration

Public Class CBLog
    Public ReadOnly LOG_DIRECTORY As String = (ConfigurationManager.AppSettings("LogDirectory").ToString)
    Dim s1 As StreamWriter
    Public Sub GeneralInfo(ByVal strFunction As String, Optional ByVal strCustomNote As String = "")

        Dim strIP As String = System.Web.HttpContext.Current.Request.UserHostAddress
        Dim strUser As String = ""
        Dim strDate As String = Year(Now()).ToString & "-" & ZeroPadding(Month(Now()).ToString, 2) & "-" & ZeroPadding(Microsoft.VisualBasic.DateAndTime.Day(Now()).ToString, 2) & " " & ZeroPadding(Hour(Now()).ToString, 2) & ":" & ZeroPadding(Minute(Now()).ToString, 2) & ":" & ZeroPadding(Second(Now()).ToString, 2)
        Dim strPage As String = HttpContext.Current.Request.Url.AbsoluteUri

        strUser = "NONE"

        WriteLog(strDate & "~" & strIP & "~" & strUser & "~" & strPage & "~" & strFunction & "~" & "NO ERROR" & "~" & strCustomNote)


    End Sub

    Public Sub ErrorLog(ByVal strFunction As String, Optional ByVal strError As String = "", Optional ByVal strCustomNote As String = "")

        Dim strIP As String = System.Web.HttpContext.Current.Request.UserHostAddress
        Dim strUser As String = ""
        Dim strDate As String = Year(Now()).ToString & "-" & ZeroPadding(Month(Now()).ToString, 2) & "-" & ZeroPadding(Microsoft.VisualBasic.DateAndTime.Day(Now()).ToString, 2) & " " & ZeroPadding(Hour(Now()).ToString, 2) & ":" & ZeroPadding(Minute(Now()).ToString, 2) & ":" & ZeroPadding(Second(Now()).ToString, 2)
        Dim strPage As String = HttpContext.Current.Request.Url.AbsoluteUri
        Try
            strUser = "NONE"

            WriteLog(strDate & "~" & strIP & "~" & strUser & "~" & strPage & "~" & strFunction & "~" & strError & "~" & strCustomNote)
        Catch ex As Exception
            Dim x As String = ex.Message
        End Try
    End Sub


    Private Sub WriteLog(ByVal strMessage As String)
        CreateLogFile()
        s1.WriteLine(strMessage)
        CloseLogFile()
    End Sub

    Private Sub CreateLogFile()
        Dim strFileName As String = Year(Now()).ToString & "-" & ZeroPadding(Month(Now()).ToString, 2) & "-" & ZeroPadding(Microsoft.VisualBasic.DateAndTime.Day(Now()).ToString, 2)
        If Not System.IO.Directory.Exists(LOG_DIRECTORY) Then
            System.IO.Directory.CreateDirectory(LOG_DIRECTORY)
        End If

        If Dir(LOG_DIRECTORY & strFileName & ".txt") = "" Then
            'check the file
            Dim fs As FileStream = New FileStream(LOG_DIRECTORY & strFileName & ".txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)
            Dim s As StreamWriter = New StreamWriter(fs)
            s.Close()
            fs.Close()
        End If
        Dim intNoOfTrial As Integer = 10
        Dim blnDone As Boolean = False

        For i = 1 To intNoOfTrial
            Try
                s1 = File.AppendText(LOG_DIRECTORY & strFileName & ".txt")
                blnDone = True
                Exit For
            Catch ex As Exception
                Dim err As String = ex.Message
            End Try
        Next

        If blnDone = False Then

            If Dir(LOG_DIRECTORY & strFileName & "-" & ZeroPadding(Hour(Now()).ToString, 2) & "-" & ZeroPadding(Minute(Now()).ToString, 2) & "-" & ZeroPadding(Second(Now()).ToString, 2) & ".txt") = "" Then
                'check the file
                Dim fs As FileStream = New FileStream(LOG_DIRECTORY & strFileName & "-" & ZeroPadding(Hour(Now()).ToString, 2) & "-" & ZeroPadding(Minute(Now()).ToString, 2) & "-" & ZeroPadding(Second(Now()).ToString, 2) & ".txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)
                Dim s As StreamWriter = New StreamWriter(fs)
                s.Close()
                fs.Close()
            End If

            s1 = File.AppendText(LOG_DIRECTORY & strFileName & "-" & ZeroPadding(Hour(Now()).ToString, 2) & "-" & ZeroPadding(Minute(Now()).ToString, 2) & "-" & ZeroPadding(Second(Now()).ToString, 2) & ".txt")
            blnDone = True
        End If

    End Sub
    Private Sub CloseLogFile()
        s1.Close()
        s1.Dispose()
    End Sub

    Function ZeroPadding(ByVal strIn As String, ByVal intDec As Integer) As String
        Dim strResult As String = "" & strIn
        For i = Len(strIn) + 1 To intDec
            strResult = "0" + strResult
        Next i
        Return strResult
    End Function

End Class
