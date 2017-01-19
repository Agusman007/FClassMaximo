Imports System.Data.SqlClient
Imports System.Data

Partial Class Index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            PopulateInfo()
        End If
    End Sub

    Private Sub PopulateInfo()
        Dim StackFrame As Diagnostics.StackFrame
        Dim l As CBLog = New CBLog
        Dim strEvent As String = ""
        StackFrame = New Diagnostics.StackFrame
        Dim FunctionName As String = StackFrame.GetMethod.Name.ToString

        Dim strConnection As String = System.Configuration.ConfigurationManager.ConnectionStrings("Cellbox-connectionString").ConnectionString
        Dim cnSQL As New SqlConnection
        Dim cmSQL As New SqlCommand
        Dim strSql As String = String.Empty
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable
        Dim strInnerHtml As String = ""

        Try

            strSql = "Select * from PD_Workstation WHERE INactive = 0"

            cnSQL = New SqlConnection(strConnection)
            cnSQL.Open()
            cmSQL = New SqlCommand(strSql, cnSQL)
            da = New SqlDataAdapter(cmSQL)
            da.Fill(dt)

            For i As Integer = 0 To dt.Rows.Count - 1
                If i + 2 Mod 2 = 0 Then
                    strInnerHtml &= "<div class='ui-block-a'>" & _
                                    " <a href='Workstation/index.aspx?wsid=" & dt(i)("ID") & "' class='main-section-link' style='font-weight: 400;' data-ajax='false'> " & _
                                            " <div class='main-section-icon-container'>" & _
                                                " <div style='padding: 15px;' align='center'>" & _
                                                " <i class='fa fa-building' style='color: rgb(219, 219, 219); font-size: 45pt;'></i> " & _
                                            " </div>" & _
                                            " <div class='main-section-icon-text'>" & _
                                                dt(i)("Name") & _
                                            " </div> " & _
                                        "</div>" & _
                                    " </a>" & _
                                " </div>"
                Else
                    strInnerHtml &= "<div class='ui-block-b'>" & _
                                    " <a href='Workstation/index.aspx?wsid=" & dt(i)("ID") & "' class='main-section-link' style='font-weight: 400;' data-ajax='false'> " & _
                                            " <div class='main-section-icon-container'>" & _
                                                " <div style='padding: 15px;' align='center'>" & _
                                                " <i class='fa fa-building' style='color: rgb(219, 219, 219); font-size: 45pt;'></i> " & _
                                            " </div>" & _
                                            " <div class='main-section-icon-text'>" & _
                                                dt(i)("Name") & _
                                            " </div> " & _
                                        "</div>" & _
                                    " </a>" & _
                                " </div>"
                End If
                
            Next

            wsList.InnerHtml = strInnerHtml

            cnSQL.Close()
            cmSQL.Dispose()
            cnSQL.Dispose()
        Catch ex As Exception
            dt = Nothing
            l.ErrorLog("Main Index - " & FunctionName, Nothing, ex.Message)
        End Try
    End Sub
End Class
