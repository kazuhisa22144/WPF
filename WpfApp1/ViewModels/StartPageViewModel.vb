Public Class StartPageViewModel

    Dim _message As String
    Public Property Message As String
        Get
            Return _message
        End Get
        Set(value As String)
            _message = SetProperty(ref _message, value)
        End Set
    End Property

    'コンストラクタ
    Public Sub New(StartPageViewModel As String)
        Message = "最初のページです。"
    End Sub
End Class
