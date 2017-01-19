Imports System.Data
Imports System.IO

Partial Class FClass_Maximo_Index
    Inherits System.Web.UI.Page

    Private Sub FClass_Maximo_Index_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            PopulateFClass()
        End If
    End Sub


    Public Sub PopulateFClass()
        Dim objFClass As New FClass_Maximo
        objFClass = New FClass_Maximo
        Dim dt As New DataTable
        dt = objFClass.GetAllData()
        Dim strInnerHtml As String = String.Empty
        Dim Index As Integer = 1

        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1

                strInnerHtml &=
                    "<tr>" &
                        "<td>" &
                            Index &
                        "</td>" &
                        "<td class='text-center'>" &
                            dt.Rows(i)("Class") &
                        "</td>" &
                        "<td>" &
                            dt.Rows(i)("DClass") &
                        "</td>" &
                        "<td>" &
                            dt.Rows(i)("Code") &
                        "</td>" &
                         "<td>" &
                            dt.Rows(i)("DCode") &
                        "</td>" &
                    "</tr>"

                Index = Index + 1
            Next
        End If
        tblFClass_Maximo.InnerHtml = strInnerHtml
    End Sub

End Class