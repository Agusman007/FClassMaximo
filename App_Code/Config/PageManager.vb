Imports Microsoft.VisualBasic

Public Class PageManager

#Region "Fields"
    Private _EmployeeID As Integer
    Private _PageName As String = String.Empty
#End Region

#Region "Properties"
    Public Property EmployeeID() As Integer
        Get
            Return _EmployeeID
        End Get
        Set(ByVal Value As Integer)
            _EmployeeID = Value
        End Set
    End Property
    Public Property PageName() As String
        Get
            Return _PageName
        End Get
        Set(ByVal Value As String)
            _PageName = Value
        End Set
    End Property
#End Region

#Region "Constructor"
    Public Sub New()

    End Sub

    Public Sub New(PageName As String, EmployeeID As Integer)
        _PageName = PageName
        _EmployeeID = EmployeeID
    End Sub
#End Region

#Region "Function"
    Public Sub setPageName()
        'Dim pageHandler = HttpContext.Current.CurrentHandler
        'If TypeOf pageHandler Is System.Web.UI.Page Then
        '    Dim lblPageName As Label = DirectCast(pageHandler, System.Web.UI.Page).Master.FindControl("lblPageName")
        '    Dim lblPageName2 As Label = DirectCast(pageHandler, System.Web.UI.Page).Master.FindControl("lblPageName2")

        '    'lblPageName.Text = PageName
        '    'lblPageName2.Text = PageName
        'End If
    End Sub

    Public Sub setProfileName()
        'Dim pageHandler = HttpContext.Current.CurrentHandler
        'If TypeOf pageHandler Is System.Web.UI.Page Then
        '    Dim lblEmployeeNameTop As Label = DirectCast(pageHandler, System.Web.UI.Page).Master.FindControl("lblEmployeeNameTop")
        '    Dim EmployeeDetail As HtmlControls.HtmlGenericControl = DirectCast(pageHandler, System.Web.UI.Page).Master.FindControl("EmployeeDetail")
        '    Dim lblEmployeeRole As Label = DirectCast(pageHandler, System.Web.UI.Page).Master.FindControl("lblEmployeeRole")
        '    Dim objEmployee As Employee = Employee.GetEmployeeByID(EmployeeID)
        '    Dim employeeName As String = objEmployee.FirstName & " " & objEmployee.LastName

        '    lblEmployeeNameTop.Text = employeeName
        '    EmployeeDetail.InnerHtml = employeeName & "<br><small>" & "Manager" & "</small>"

        'End If
    End Sub
#End Region

End Class
