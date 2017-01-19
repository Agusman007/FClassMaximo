Imports System.Data.SqlClient
Imports System.Data

Partial Class Login
    Inherits System.Web.UI.Page

#Region "Button"
    Protected Sub btnSubmit_Click(sender As Object, e As System.EventArgs) Handles btnSubmit.Click
        FirstLogin(txtUsername.Text, txtPassword.Text)
    End Sub

    Protected Sub bntLogin_Click(sender As Object, e As System.EventArgs) Handles bntLogin.Click
        Session("AuthRole") = ddRole.SelectedValue
        Response.Redirect(Bll_Authentication.RedirectPage(ddRole.SelectedValue))
    End Sub
#End Region

#Region "Function"

    Public Sub FirstLogin(Username As String, Password As String)
        Dim Value As Integer = 0

        Try
            Value = Bll_Authentication.FirstValidate(Username, Password)
            Select Case Value
                Case 1
                    ScriptManager.RegisterStartupScript(Me, GetType(Page), "UpdateMsg", "showMessageWarning('Account is not registered')", True)
                Case 2
                    SetFirstSession(Username)
                    ddRole.Visible = True
                    bntLogin.Visible = True
                    txtPassword.Visible = False
                    txtUsername.Visible = False
                    btnSubmit.Visible = False
                Case 3
                    ScriptManager.RegisterStartupScript(Me, GetType(Page), "UpdateMsg", "showMessageDanger('Password Invalid')", True)
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Public Sub SetFirstSession(Username As String)
        Dim dv As New DataView

        Try
            dv = Bll_Authentication.GetEmployeeByUsername(Username)
            If dv.Count > 0 Then
                For i As Integer = 0 To dv.Count - 1
                    Session("AuthID") = dv(i)("ID")
                    Session("AuthUsername") = dv(i)("Username")
                    Session("AuthPassword") = dv(i)("Password")

                    PopulateRoleEmployee(dv(i)("ID"))
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "Populate Data"
    Public Sub PopulateRoleEmployee(EmployeeID As Integer)
        Dim dt As New DataTable
        dt = Bll_Employee_Role.ViewAllDataEmployeeRole(EmployeeID)

        ddRole.DataSource = dt
        ddRole.DataTextField = "RoleName"
        ddRole.DataValueField = "RoleID"
        ddRole.DataBind()
    End Sub
#End Region

End Class
