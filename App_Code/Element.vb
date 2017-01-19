Imports Microsoft.VisualBasic

<Serializable()>
Public Class Element
    Private _Data As String = [String].Empty

    Public Property Data() As String
        Get
            Return _Data
        End Get
        Set(value As String)
            _Data = value
        End Set
    End Property

    ' Support XmlSerialization
    Private Sub New()
    End Sub

    Public Sub New(s As String)
        _Data = s
    End Sub

#If True Then
    Public Sub New(o As Element)
        _Data = o._Data & Convert.ToString(" *COPYCTOR*")
    End Sub
#End If
    'Public Overrides Function Equals(obj As Object) As Boolean
    '    If obj Is Nothing Then
    '        Return False
    '    End If

    '    Dim o As Element = TryCast(obj, Element)
    '    If o Is Nothing Then
    '        Debug.Assert(False)
    '        Return False
    '    End If

    '    Return _Data = o._Data
    'End Function

    Public Overrides Function GetHashCode() As Integer
        Return _Data.GetHashCode()
    End Function

    Public Overrides Function ToString() As String
        Return _Data
    End Function

    Public Function CreateDeepCopy() As Object
        Return New Element(_Data & Convert.ToString(" *DEEPCOPY*"))
    End Function
End Class
