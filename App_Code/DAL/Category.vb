Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class Category

#Region "Fields"
    Private _ID As Integer
    Private _Code As String = String.Empty
    Private _Name As String = String.Empty
    Private _Picture As String = String.Empty
    Private _Inactive As Integer
    Private _DateCreated As DateTime
    Private _LastUpdated As DateTime
    Private _UID As String = String.Empty
#End Region

#Region "Properties"
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal Value As Integer)
            _ID = Value
        End Set
    End Property
    Public Property Code() As String
        Get
            Return _Code
        End Get
        Set(ByVal Value As String)
            _Code = Value
        End Set
    End Property
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal Value As String)
            _Name = Value
        End Set
    End Property
    Public Property Picture() As String
        Get
            Return _Picture
        End Get
        Set(ByVal Value As String)
            _Picture = Value
        End Set
    End Property
    Public Property Inactive() As Integer
        Get
            Return _Inactive
        End Get
        Set(ByVal Value As Integer)
            _Inactive = Value
        End Set
    End Property
    Public Property DateCreated() As DateTime
        Get
            Return _DateCreated
        End Get
        Set(ByVal Value As DateTime)
            _DateCreated = Value
        End Set
    End Property
    Public Property LastUpdated() As DateTime
        Get
            Return _LastUpdated
        End Get
        Set(ByVal Value As DateTime)
            _LastUpdated = Value
        End Set
    End Property
    Public Property UID() As String
        Get
            Return _UID
        End Get
        Set(ByVal Value As String)
            _UID = Value
        End Set
    End Property
#End Region

#Region "Constructor"
    Public Sub New()
    End Sub

    Public Sub New(ID As Integer, Code As String, Name As String, Picture As String, Inactive As Integer, DateCreated As DateTime, LastUpdated As DateTime, UID As String)
        _ID = ID
        _Code = Code
        _Name = Name
        _Picture = Picture
        _Inactive = Inactive
        _DateCreated = DateCreated
        _LastUpdated = LastUpdated
        _UID = UID
    End Sub
#End Region

#Region "Function"
    Public Function GetCategoryByID(ID As Integer) As Category
        Dim StackFrame As Diagnostics.StackFrame
        Dim l As CBLog = New CBLog
        Dim strEvent As String = ""
        StackFrame = New Diagnostics.StackFrame
        Dim FunctionName As String = StackFrame.GetMethod.Name.ToString

        Dim result As New Category
        Dim strConnection As String = System.Configuration.ConfigurationManager.ConnectionStrings("Cellbox-connectionString").ConnectionString
        Dim cnSQL As New SqlConnection
        Dim cmSQL As New SqlCommand
        Dim strSql As String = String.Empty
        Dim drSql As SqlDataReader

        Try
            strSql = "Select ISNULL(ID, 0) AS ID, ISNULL(Code, '''') AS Code, ISNULL(Name, '''') AS Name, ISNULL(Picture, '''') AS Picture, ISNULL(Inactive, 0) AS Inactive, DateCreated, LastUpdated, UID  FROM Category WHERE ID = " & ID

            cnSQL = New SqlConnection(strConnection)
            cnSQL.Open()
            cmSQL = New SqlCommand(strSql, cnSQL)
            drSql = cmSQL.ExecuteReader

            If drSql.Read Then
                result.ID = drSql.Item("ID")
                result.Code = drSql.Item("Code")
                result.Name = drSql.Item("Name")
                result.Picture = drSql.Item("Picture")
                result.Inactive = drSql.Item("Inactive")
                result.DateCreated = drSql.Item("DateCreated")
                result.LastUpdated = drSql.Item("LastUpdated")
                result.UID = drSql.Item("UID").ToString()
            End If

            drSql.Close()
            cnSQL.Close()
            cmSQL.Dispose()
            cnSQL.Dispose()
        Catch ex As Exception
            l.ErrorLog("Class Category - " & FunctionName, Nothing, ex.Message)
        End Try

        Return result
    End Function

    Public Function GetCategoryByCode(Code As String) As Category
        Dim StackFrame As Diagnostics.StackFrame
        Dim l As CBLog = New CBLog
        Dim strEvent As String = ""
        StackFrame = New Diagnostics.StackFrame
        Dim FunctionName As String = StackFrame.GetMethod.Name.ToString

        Dim result As New Category
        Dim strConnection As String = System.Configuration.ConfigurationManager.ConnectionStrings("Cellbox-connectionString").ConnectionString
        Dim cnSQL As New SqlConnection
        Dim cmSQL As New SqlCommand
        Dim strSql As String = String.Empty
        Dim drSql As SqlDataReader

        Try
            strSql = "Select ISNULL(ID, 0) AS ID, ISNULL(Code, '''') AS Code, ISNULL(Name, '''') AS Name, ISNULL(Picture, '''') AS Picture, ISNULL(Inactive, 0) AS Inactive, DateCreated, LastUpdated, UID  FROM Category WHERE Code = '" & Code & "'"

            cnSQL = New SqlConnection(strConnection)
            cnSQL.Open()
            cmSQL = New SqlCommand(strSql, cnSQL)
            drSql = cmSQL.ExecuteReader

            If drSql.Read Then
                result.ID = drSql.Item("ID")
                result.Code = drSql.Item("Code")
                result.Name = drSql.Item("Name")
                result.Picture = drSql.Item("Picture")
                result.Inactive = drSql.Item("Inactive")
                result.DateCreated = drSql.Item("DateCreated")
                result.LastUpdated = drSql.Item("LastUpdated")
                result.UID = drSql.Item("UID")
            End If

            drSql.Close()
            cnSQL.Close()
            cmSQL.Dispose()
            cnSQL.Dispose()
        Catch ex As Exception
            l.ErrorLog("Class Category - " & FunctionName, Nothing, ex.Message)
        End Try

        Return result
    End Function

    Public Function GetAllData() As DataTable
        Dim StackFrame As Diagnostics.StackFrame
        Dim l As CBLog = New CBLog
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
            strSql = "Select ISNULL(ID, 0) AS ID, ISNULL(Code, '''') AS Code, ISNULL(Name, '''') AS Name, ISNULL(Picture, '''') AS Picture, ISNULL(Inactive, 0) AS Inactive, DateCreated, LastUpdated, UID FROM Category"

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
            l.ErrorLog("Class Category - " & FunctionName, Nothing, ex.Message)
        End Try

        Return result
    End Function

    Public Function Created() As Boolean
        Dim boolResult As Boolean = False
        Dim StackFrame As Diagnostics.StackFrame
        Dim l As CBLog = New CBLog
        Dim strEvent As String = ""
        StackFrame = New Diagnostics.StackFrame
        Dim FunctionName As String = StackFrame.GetMethod.Name.ToString

        Dim strConnection As String = System.Configuration.ConfigurationManager.ConnectionStrings("Cellbox-connectionString").ConnectionString
        Dim cnSQL As New SqlConnection
        Dim cmSQL As New SqlCommand
        Dim strSql As String = String.Empty
        Dim drsql As SqlDataReader

        Try
            strSql = "INSERT INTO Category (Code, Name, Picture, Inactive, DateCreated, LastUpdated) " &
                            " VALUES " &
                            "('" & Code & "', '" & Name & "', '" & Picture & "', '" & Inactive & "', { fn Now() }, { fn Now() });Select @@IDENTITY AS ID;"

            cnSQL = New SqlConnection(strConnection)
            cnSQL.Open()
            cmSQL = New SqlCommand(strSql, cnSQL)
            drsql = cmSQL.ExecuteReader

            If drsql.Read Then
                boolResult = True
            End If

            drsql.Close()
            cnSQL.Close()
            cmSQL.Dispose()
            cnSQL.Dispose()
        Catch ex As Exception
            l.ErrorLog("Class Category - " & FunctionName, Nothing, ex.Message)
        End Try

        Return boolResult
    End Function

    Public Function Update() As Boolean
        Dim StackFrame As Diagnostics.StackFrame
        Dim l As CBLog = New CBLog
        Dim strEvent As String = ""
        StackFrame = New Diagnostics.StackFrame
        Dim FunctionName As String = StackFrame.GetMethod.Name.ToString

        Dim strConnection As String = System.Configuration.ConfigurationManager.ConnectionStrings("Cellbox-connectionString").ConnectionString
        Dim cnSQL As New SqlConnection
        Dim cmSQL As New SqlCommand
        Dim strSql As String = String.Empty
        Dim boolResult As Boolean = False

        Try
            strSql = "UPDATE Category SET " &
                        "Code = '" & Code & "', " &
                        "Name = '" & Name & "', " &
                        "Picture = '" & Picture & "', " &
                        "Inactive = '" & Inactive & "', " &
                        "LastUpdated = '" & CommonFunction.PrepareDate(LastUpdated) & "' " &
                        "WHERE ID = " & ID

            cnSQL = New SqlConnection(strConnection)
            cnSQL.Open()
            cmSQL = New SqlCommand(strSql, cnSQL)

            If cmSQL.ExecuteNonQuery Then
                boolResult = True
            End If

            cnSQL.Close()
            cmSQL.Dispose()
            cnSQL.Dispose()
        Catch ex As Exception
        End Try

        Return boolResult
    End Function

    Public Function DeleteByID(ID As Integer) As Boolean
        Dim StackFrame As Diagnostics.StackFrame
        Dim l As CBLog = New CBLog
        Dim strEvent As String = ""
        StackFrame = New Diagnostics.StackFrame
        Dim FunctionName As String = StackFrame.GetMethod.Name.ToString

        Dim strConnection As String = System.Configuration.ConfigurationManager.ConnectionStrings("Cellbox-connectionString").ConnectionString
        Dim cnSQL As New SqlConnection
        Dim cmSQL As New SqlCommand
        Dim strSql As String = String.Empty
        Dim boolResult As Boolean = False

        Try
            strSql = "DELETE FROM Category " &
                        "WHERE ID = " & ID

            cnSQL = New SqlConnection(strConnection)
            cnSQL.Open()
            cmSQL = New SqlCommand(strSql, cnSQL)

            If cmSQL.ExecuteNonQuery Then
                boolResult = True
            End If

            cnSQL.Close()
            cmSQL.Dispose()
            cnSQL.Dispose()
        Catch ex As Exception
            l.ErrorLog("Class Category - " & FunctionName, Nothing, ex.Message)
        End Try

        Return boolResult
    End Function
#End Region
End Class
