Module globalVariable
    Private mTetrisX As Integer
    Public Property TetrisX() As Integer
        Get
            Return mTetrisX
        End Get
        Set(ByVal value As Integer)
            mTetrisX = value
        End Set
    End Property
    Private mTetrisY As Integer
    Public Property TetrisY() As Integer
        Get
            Return mTetrisY
        End Get
        Set(ByVal value As Integer)
            mTetrisY = value
        End Set
    End Property
End Module
