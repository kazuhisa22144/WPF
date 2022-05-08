Public Class ChainTableModel

    Dim _chainId As String
        Dim _chainType As String

        Public Property ChainId As String
            Get
                Return _chainId
            End Get
            Set(value As String)
                _chainId = value
            End Set
        End Property

        Public Property ChainType As String
            Get
                Return _chainType
            End Get
            Set(value As String)
                _chainType = value
            End Set
        End Property

    Dim _progressText As String
    Dim _progressValue As String
    Dim _pageTitle As String
    Public Property ProgressText As String
        Get
            Return _progressText
        End Get
        Set(value As String)
            _progressText = value
        End Set
    End Property

    Public Property ProgressValue As Integer
        Get
            Return _progressValue
        End Get
        Set(value As Integer)
            _progressValue = value
        End Set
    End Property

    Public Property PageTitle As String
        Get
            Return _pageTitle
        End Get
        Set(value As String)
            _pageTitle = value
        End Set
    End Property

    'コンストラクタ
    Public Sub New(chainId As String, chainType As String)
        _chainId = chainId
        _chainType = chainType
    End Sub

    Public Sub New(ProgressText As String, ProgressValue As Integer)
        _progressText = ProgressText
        _progressValue = ProgressValue
    End Sub

    Public Sub New(PageTitle As String)
        _pageTitle = PageTitle
    End Sub

End Class
