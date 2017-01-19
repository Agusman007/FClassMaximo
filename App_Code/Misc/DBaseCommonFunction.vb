Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class DBaseCommonFunction
    Public Shared Function GetDataTableFromQuery(ByVal StrQuery As String) As DataTable
        Dim cnSQL As SqlConnection = New SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings("ConnectionString"))
        Dim cmSQL As New SqlCommand
        Dim strSQL As String = String.Empty
        Dim da As New SqlDataAdapter
        Dim dt As DataTable = Nothing

        Try
            strSQL = StrQuery

            cnSQL.Open()

            da = New SqlDataAdapter(strSQL, cnSQL)
            dt = New DataTable
            da.Fill(dt)
        Catch ex As Exception
        Finally
            If cnSQL.State = ConnectionState.Broken Or cnSQL.State = ConnectionState.Open Or cnSQL.State = ConnectionState.Connecting Or cnSQL.State = ConnectionState.Executing Or cnSQL.State = ConnectionState.Fetching Then
                cnSQL.Close()
                cnSQL.Dispose()
            End If

            cmSQL.Dispose()
        End Try

        Return dt
    End Function

    Public Shared Function SQLExecuteNonQuery(ByVal StrSql As String) As Boolean
        Dim result As Boolean = False

        Dim strConnection As String = System.Configuration.ConfigurationManager.AppSettings("ConnectionString")
        Dim cnSQL As SqlConnection = New SqlConnection(strConnection)
        Dim cmSQL As SqlCommand = Nothing

        Try
            cnSQL = New SqlConnection(strConnection)
            cnSQL.Open()

            cmSQL = New SqlCommand(StrSql, cnSQL)
            cmSQL.ExecuteNonQuery()

            result = True

        Catch ex As Exception
        Finally
            If cnSQL.State = ConnectionState.Broken Or cnSQL.State = ConnectionState.Open Or cnSQL.State = ConnectionState.Connecting Or cnSQL.State = ConnectionState.Executing Or cnSQL.State = ConnectionState.Fetching Then
                cnSQL.Close()
                cnSQL.Dispose()
            End If

            cmSQL.Dispose()
        End Try

        Return result
    End Function

    Public Shared Function GetDataTableFromStoreProcedure(ByVal StrStoreProcedure As String, ByVal ParamList As List(Of SqlParameter)) As DataTable
        Dim cnSQL As SqlConnection = New SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings("ConnectionString"))
        Dim cmSQL As New SqlCommand
        Dim strSQL As String = String.Empty
        Dim da As New SqlDataAdapter
        Dim dt As DataTable = Nothing
        Dim cmd As New SqlCommand

        Try
            strSQL = StrStoreProcedure

            cnSQL.Open()

            cmd.Connection = cnSQL
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = strSQL

            If ParamList IsNot Nothing Then
                If ParamList.Count > 0 Then
                    For Each Prm As SqlParameter In ParamList
                        cmd.Parameters.Add(Prm)
                    Next
                End If
            End If

            da = New SqlDataAdapter(cmd)
            dt = New DataTable
            da.Fill(dt)
        Catch ex As Exception
        Finally
            If cnSQL.State = ConnectionState.Broken Or cnSQL.State = ConnectionState.Open Or cnSQL.State = ConnectionState.Connecting Or cnSQL.State = ConnectionState.Executing Or cnSQL.State = ConnectionState.Fetching Then
                cnSQL.Close()
                cnSQL.Dispose()
                cmd.Dispose()
            End If

            cmSQL.Dispose()
        End Try

        Return dt
    End Function
End Class
