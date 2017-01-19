Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class FClass_Maximo
    Public Function GetAllData() As DataTable
        Dim StackFrame As Diagnostics.StackFrame
        Dim strEvent As String = ""
        StackFrame = New Diagnostics.StackFrame
        Dim FunctionName As String = StackFrame.GetMethod.Name.ToString

        Dim result As New DataTable
        Dim strConnection As String = System.Configuration.ConfigurationManager.ConnectionStrings("Cellbox-connectionString").ConnectionString
        Dim cnSQL As New SqlConnection
        Dim cmSQL As New SqlCommand
        Dim strSql As String = String.Empty
        Dim da As SqlDataAdapter

        Try
            strSql = "SELECT [Class] ,[Dclass] ,[Code] ,[Dcode] ,[Cause] ,[Dcause] FROM [FClass_Maximo].[dbo].[FClass_Maximo]"

            cnSQL = New SqlConnection(strConnection)
            cnSQL.Open()
            cmSQL = New SqlCommand(strSql, cnSQL)
            da = New SqlDataAdapter(cmSQL)
            da.Fill(result)

            da.Dispose()
            cnSQL.Close()
            cmSQL.Dispose()
            cnSQL.Dispose()
        Catch ex As Exception
        End Try

        Return result
    End Function
End Class
