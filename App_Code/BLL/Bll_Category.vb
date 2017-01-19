Imports Microsoft.VisualBasic
Imports System.Data

Public Class Bll_Category

    Public Shared Function SaveCategory(Code As String, Name As String, Picture As String) As Boolean
        Dim objCategory As Category
        objCategory = New Category
        Dim boolResult As Boolean = False

        With objCategory
            .Code = Code
            .Name = Name
            .Picture = Picture
        End With

        If objCategory.Created() Then
            boolResult = True
        End If

        Return boolResult
    End Function

    Public Shared Function UpdatedCategory(ID As Integer, Code As String, Name As String, Picture As String) As Boolean
        Dim objCategory As Category
        objCategory = New Category
        Dim boolResult As Boolean = False

        Try
            objCategory = objCategory.GetCategoryByID(ID)
            With objCategory
                .ID = ID
                .Code = Code
                .Name = Name
                .Picture = Picture
                .LastUpdated = Now
            End With

            If objCategory.Update() Then
                boolResult = True
            End If
        Catch ex As Exception
        End Try

        Return boolResult
    End Function

    Public Shared Function ViewCategoryByID(ID As Integer) As Category
        Dim objCategory As Category
        objCategory = New Category

        Try
            objCategory = objCategory.GetCategoryByID(ID)
        Catch ex As Exception
        End Try

        Return objCategory
    End Function

    Public Shared Function ViewCategoryByCode(Code As String) As Category
        Dim objCategory As Category
        objCategory = New Category

        Try
            objCategory = objCategory.GetCategoryByCode(Code)
        Catch ex As Exception
        End Try

        Return objCategory
    End Function

    Public Shared Function ViewAllDataCategory() As DataTable
        Dim objCategory As Category
        objCategory = New Category
        Dim dt As New DataTable

        Try
            dt = objCategory.GetAllData()
        Catch ex As Exception
        End Try

        Return dt
    End Function

    Public Shared Function DeletePermanent(ID As Integer) As Boolean
        Dim objCategory As Category
        objCategory = New Category
        Dim boolResult As Boolean = False

        If objCategory.DeleteByID(ID) Then
            boolResult = True
        End If

        Return boolResult
    End Function
End Class
