Imports Microsoft.VisualBasic
Imports System.Globalization

Public Class CommonFunction
    Public Shared Function PrepareDateStr(ByVal strValue As DateTime) As String
        If IsDBNull(strValue) Then
            Return "''"
        Else
            Return "'" & CStr(strValue.ToString("yyyy-MM-dd HH:mm:ss")) & "'"
        End If
    End Function

    Public Shared Function PrepareStr(ByVal strValue As String) As String
        Try
            If strValue Is Nothing Then
                Return "''"
            End If
            If strValue.Trim() = "" Then
                Return "''"
            ElseIf IsDBNull(strValue) Then
                Return "''"
            Else
                strValue = Replace(strValue, "'", "''")
                Return "N'" & strValue.Trim() & "'"
            End If
        Catch ex As Exception
            Return "''"
        End Try

    End Function

    Public Shared Function PrepareDate(ByVal dtm As DateTime) As String
        Return dtm.ToString("yyyy-MM-dd HH:mm:ss")
    End Function

    Public Shared Function ToDate(ByVal dtm As DateTime) As String
        Return dtm.ToString("dd-MM-yyyy")
    End Function

    Public Shared Function ToTime(ByVal dtm As DateTime) As String
        Return dtm.ToString("HH:mm")
    End Function

    '----- Function convert string to datetime -----'
    Public Shared Function ConvertStringToDateTime(Value As String) As DateTime
        Dim dt = DateTime.Parse(Value)
        Return dt
    End Function

    '------ Function convert rupiah --------'
    Public Shared Function FormatRupiah(value As Integer) As String
        Dim convert As String = String.Empty
        Dim hasil As String = String.Empty
        convert = Format(value.ToString("#,#", CultureInfo.InvariantCulture))
        hasil = String.Format(CultureInfo.InvariantCulture, "{0:#,#}", convert)
        Return hasil
    End Function

    Public Shared Function ChangeFormatDate(ByVal dtm As DateTime, ByVal format As String) As String
        Return dtm.ToString(format)
    End Function

    Public Shared Function ChangeFormatDate1(ByVal dtm As DateTime, ByVal format As String) As String
        Return dtm.ToString(format)
    End Function

    Public Shared Function ConvertBitToInteger(Value As Boolean) As Integer
        Dim Result As Integer = 0

        Select Case Value
            Case True
                Result = 1
            Case False
                Result = 0
        End Select

        Return Result
    End Function
    Public Shared Function ConvertStringToBit(Value As String) As Integer
        Dim Result As Integer = 0

        Select Case Value
            Case "on"
                Result = 1
            Case ""
                Result = 0
            Case Nothing
                Result = 0
        End Select

        Return Result
    End Function
	
	'Get the first day of the month
    Public Shared Function FirstDayOfMonth(ByVal sourceDate As DateTime) As DateTime
        Return New DateTime(sourceDate.Year, sourceDate.Month, 1)
    End Function

    'Get the last day of the month
    Public Shared Function LastDayOfMonth(ByVal sourceDate As DateTime) As DateTime
        Dim lastDay As DateTime = New DateTime(sourceDate.Year, sourceDate.Month, 1)
        Return lastDay.AddMonths(1).AddDays(-1)
    End Function

End Class
