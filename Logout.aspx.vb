
Partial Class Logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Session("AuthID") = Nothing
        Session("AuthUsername") = Nothing
        Session("AuthPassword") = Nothing
        Session("AuthRole") = Nothing

        FormsAuthentication.SignOut()
        Response.Redirect("~/Login.aspx")
    End Sub
End Class
