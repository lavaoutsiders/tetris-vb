Imports Tetris.tetrishelper
Public Class tetrisblock
    Sub New()
    End Sub
    Sub New(ByVal absoluteX As Integer, ByVal absoluteY As Integer, ByVal tetromino As Integer)
        mAbsoluteX = absoluteX
        mAbsoluteY = absoluteY
        mTetromino = tetromino
        mTetrominoColor = returnColor(tetromino)
    End Sub

    Private mAbsoluteX As Integer
    Public Property AbsoluteX() As Integer
        Get
            Return mAbsoluteX
        End Get
        Set(ByVal value As Integer)
            mAbsoluteX = value
        End Set
    End Property
    Private mAbsoluteY As Integer
    Public Property AbsoluteY() As Integer
        Get
            Return mAbsoluteY
        End Get
        Set(ByVal value As Integer)
            mAbsoluteY = value
        End Set
    End Property
    Private mIsLocked As Boolean
    Public Property IsLocked() As Boolean
        Get
            Return mIsLocked
        End Get
        Set(ByVal value As Boolean)
            mIsLocked = value
        End Set
    End Property
    Private mTetromino As Integer
    Public Property Tetromino() As Integer
        Get
            Return mTetromino
        End Get
        Set(ByVal value As Integer)
            mTetromino = value
        End Set
    End Property
    Private mTetrominoColor As Color
    Public ReadOnly Property TetrominoColor() As Color
        Get
            Return mTetrominoColor
        End Get

    End Property
    Private mTetrisStand As Integer
    Public Property TetrisStand() As Integer
        Get
            Return mTetrisStand
        End Get
        Set(ByVal value As Integer)
            mTetrisStand = value
        End Set
    End Property
    Public Sub moveToLeft()
        mAbsoluteX -= 1
    End Sub
    Public Sub moveToRight()
        mAbsoluteX += 1

    End Sub
    Public Sub moveToButton()

        mAbsoluteY += 1
    End Sub
    ''' <summary>
    ''' Rotates the tetrisblock
    ''' </summary>
    Public Sub rotate()

        If Not mTetromino = 0 Then

            If mTetrisStand < 3 Then
                mTetrisStand += 1
            ElseIf mTetrisStand = 3 Then
                mTetrisStand = 0
            End If
            ' If mTetromino = +
            ' Only one stand possible, at 0 degree
            If mTetromino = 3 Then
                'Always the origin position
                mTetrisStand = 0
            End If
        Else ' If mTetromino = ----
            'Only two stand possible, the 0 and 90 degrees
            If mTetrisStand = 0 Then
                mTetrisStand = 1
            ElseIf mTetrisStand = 1 Then
                mTetrisStand = 0
            End If

        End If
    End Sub
End Class
