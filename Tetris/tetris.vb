Option Explicit On
Option Strict On
Imports Tetris.tetrishelper

Public Class tetris
    'Matrix van 10 breed (0 tot 9) en 20 hoog (0 tot 3)
    Dim rooster(TetrisX, TetrisY) As Label

    Dim currentBlock As tetrisblock
    Dim emptyColor As Color = Color.LightGray
    Dim gameStarted As Boolean = False

    Dim lineCleared As Integer
    Dim points As Integer = 0
    Dim maxScore As Integer = 0
    Dim KEY_RIGHT As Integer = 0
    Dim KEY_LEFT As Integer = 1
    Dim KEY_UP As Integer = 2
    Dim KEY_DOWN As Integer = 3
    Private Sub tetris_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initializeMatrix()

        Me.KeyPreview = True
    End Sub
    ''' <summary>
    ''' Initialize the matrix (rooster)
    ''' </summary>
    Private Sub initializeMatrix()
        'Initialisatie van het rooster
        For i As Integer = rooster.GetLowerBound(0) To rooster.GetUpperBound(0)
            For j As Integer = rooster.GetLowerBound(1) To rooster.GetUpperBound(1)
                rooster(i, j) = New Label
                rooster(i, j).Size = New Size(20, 20)
                rooster(i, j).Name = "tile_" & i & "_" & j
                'x,y locatie in het venster
                rooster(i, j).Location = New Point(20 * i, 20 * j)
                rooster(i, j).BorderStyle = BorderStyle.Fixed3D
                'kleur van het vierkantje
                rooster(i, j).BackColor = emptyColor

                'voeg toe aan GUI
                Me.Controls.Add(rooster(i, j))
            Next
        Next
    End Sub
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        clearAll()
        If btnStart.Text = "Restart" Then
            timerTetris.Enabled = True
            lblPoints.Text = Convert.ToString(0)
            points = 0
            btnJoker.Enabled = True
            maxScoreHandler()
        End If

        gameStarted = True

        generateNewBlock()
        btnStart.Text = "Restart"
    End Sub
    ''' <summary>
    ''' Handles when the navigation keys are pressed
    ''' </summary>

    Private Sub tetris_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If gameStarted Then

            Select Case e.KeyCode
                Case Keys.Right
                    'Rechts
                    blockActionHandler(KEY_RIGHT)
                Case Keys.Left
                    'Links
                    blockActionHandler(KEY_LEFT)
                Case Keys.Up
                    'Omhoog
                    blockActionHandler(KEY_UP)
                Case Keys.Down
                    'Omlaag
                    blockActionHandler(KEY_DOWN)

            End Select
        End If

    End Sub

    ''' <summary>
    ''' Reset the color of each cell To the defaultcolor 
    ''' </summary>
    Private Sub clearAll()
        For i As Integer = rooster.GetLowerBound(0) To rooster.GetUpperBound(0)
            For j As Integer = rooster.GetLowerBound(1) To rooster.GetUpperBound(1)
                rooster(i, j).BackColor = emptyColor
            Next
        Next
    End Sub

    ''' <summary>
    ''' Check if the block is safe to move according the given direction
    ''' </summary>
    ''' <param name="key">The action to be performed (the direction of the block to be moved)</param>
    ''' <returns>True or False whether the block is safe to move or not</returns>
    Private Function isSafeToMove(ByVal key As Integer) As Boolean
        Dim simulatedAbsoluteX As Integer = currentBlock.AbsoluteX
        Dim simulatedAbsoluteY As Integer = currentBlock.AbsoluteY
        Dim originPosition As Integer = currentBlock.TetrisStand

        Select Case key
            Case KEY_RIGHT
                'Right
                simulatedAbsoluteX += 1
            Case KEY_LEFT
                'Left
                simulatedAbsoluteX -= 1
            Case KEY_UP
                'Up
                currentBlock.rotate()
            Case KEY_DOWN
                'Down
                simulatedAbsoluteY += 1
        End Select
        For position = 0 To 3
            Dim absoluteCoordinates As Integer() = coordinateCalculator(currentBlock.Tetromino, position, simulatedAbsoluteX, simulatedAbsoluteY, currentBlock.TetrisStand)
            Dim x As Integer = absoluteCoordinates(0)
            Dim y As Integer = absoluteCoordinates(1)
            'If the current coordinate is bigger than the max bound or below the lower limit
            'Return False
            If x > rooster.GetUpperBound(0) Or x < rooster.GetLowerBound(0) Then
                currentBlock.TetrisStand = originPosition

                Return False
            End If
            If y > rooster.GetUpperBound(1) Then
                currentBlock.TetrisStand = originPosition

                Return False
            End If
            'If the backcolor of the coordinate is different from the default empty color
            'E.g. the label of x,y has a blue color, then return False
            Try
                If rooster(x, y).BackColor <> emptyColor Then
                    currentBlock.TetrisStand = originPosition
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        Next
        currentBlock.TetrisStand = originPosition

        'Else return True
        Return True
    End Function
    ''' <summary>
    '''Set the color of the current tetrimo to the defaultcolor
    ''' </summary>
    Private Sub clearCurrentTetrimo()
        Try


            For position = 0 To 3
                Dim absoluteCoordinates As Integer() = coordinateCalculator(currentBlock.Tetromino, position, currentBlock.AbsoluteX, currentBlock.AbsoluteY, currentBlock.TetrisStand)
                'absoluteCoordinates(0) = x , absoluteCoordinates(1) = y
                rooster(absoluteCoordinates(0), absoluteCoordinates(1)).BackColor = emptyColor
            Next
        Catch ex As Exception

        End Try
    End Sub
    ''' <summary>
    ''' Update the color of the current board of the tetermino 
    ''' </summary>
    Private Sub updateBoard()
        Try
            For position = 0 To 3
                Dim absoluteCoordinates As Integer() = coordinateCalculator(currentBlock.Tetromino, position, currentBlock.AbsoluteX, currentBlock.AbsoluteY, currentBlock.TetrisStand)
                'absoluteCoordinates(0) = x , absoluteCoordinates(1) = y
                rooster(absoluteCoordinates(0), absoluteCoordinates(1)).BackColor = currentBlock.TetrominoColor

            Next
        Catch ex As Exception

        End Try
    End Sub
    ''' <summary>
    ''' Create a new Tetris block at position 0
    ''' </summary>
    Private Sub generateNewBlock()

        Dim randomTetris As New Random()
        ' Random integer from 0 to 6
        Dim teterminoType As Integer = randomTetris.Next(0, 7)

        'Make a block and set the begin coordinate to (half of the board width,0)
        Dim absoluteX As Integer = Convert.ToInt16(rooster.GetUpperBound(0) / 2)
        ' Update the currentBlock with a new tetrisblock
        currentBlock = New tetrisblock(absoluteX, 0, teterminoType)
        updateBoard()
    End Sub

    ''' <summary>
    ''' A cntral function to process the user navigation key input
    ''' </summary>
    ''' <param name="key"></param>
    Private Sub blockActionHandler(ByVal key As Integer)
        clearCurrentTetrimo()

        Select Case key
            Case KEY_RIGHT
                'Right
                If isSafeToMove(KEY_RIGHT) Then
                    currentBlock.moveToRight()
                End If
                updateBoard()

            Case KEY_LEFT
                'Left
                If isSafeToMove(KEY_LEFT) Then
                    currentBlock.moveToLeft()
                End If
                updateBoard()

            Case KEY_UP
                'Up
                If isSafeToMove(KEY_UP) Then
                    currentBlock.rotate()

                End If
                Try
                    updateBoard()
                Catch ex As Exception

                End Try
            Case KEY_DOWN
                'Down
                If isSafeToMove(KEY_DOWN) Then
                    clearCurrentTetrimo()
                    currentBlock.moveToButton()
                    updateBoard()
                Else
                    If currentBlock.AbsoluteY = 0 Then
                        updateBoard()
                        gameOver()
                        Return
                    End If
                    clearCurrentTetrimo()

                    updateBoard()
                    clearFullLine()

                    generateNewBlock()
                    'If it is not safe to move, then try to clear the full line

                End If
        End Select
    End Sub

    Private Sub timerTetris_Tick(sender As Object, e As EventArgs) Handles timerTetris.Tick
        If gameStarted Then
            'clearCurrentTetrimo()
            blockActionHandler(KEY_DOWN)
        End If
    End Sub
    ''' <summary>
    ''' Clear the full line and move the lines down from the top
    ''' </summary>
    Private Sub clearFullLine()
        'Check from the largest y (row)

        Dim clearedLineRange As Integer = 0

        For j As Integer = rooster.GetLowerBound(1) To rooster.GetUpperBound(1)
            Dim currentLineFull As Boolean = True
            'Check each x on the y
            For i As Integer = rooster.GetLowerBound(0) To rooster.GetUpperBound(0)
                'If found some block with the default color
                If rooster(i, j).BackColor = emptyColor Then
                    'change the variable which indicates the line is full or not, to False
                    currentLineFull = False
                End If
            Next
            'If the current y (row) is full
            If currentLineFull Then
                lineCleared += 1
                clearedLineRange += 1
                'Disable the timer to prevent the new block will be moved while the clock is ticking
                gameStarted = False
                'x from 0 to the upperbound
                For x As Integer = rooster.GetLowerBound(0) To rooster.GetUpperBound(0)
                    'First iteration: (0,j) = (0, j - 1) with j is the line which is full 
                    'Iterate y from the point where full line is found to the lowerbound of y (0) + 1

                    For y As Integer = j To rooster.GetLowerBound(1) + 1 Step -1
                        rooster(x, y).BackColor = rooster(x, y - 1).BackColor
                    Next
                Next
            End If
        Next
        'Re-enable the timer
        gameStarted = True
        points += pointCalculator(clearedLineRange)
        lblPoints.Text = points.ToString()
        maxScoreHandler()
    End Sub
    ''' <summary>
    ''' Calculates te points of the cleared line
    ''' </summary>
    ''' <param name="lineCleared">Cleared line</param>
    ''' <returns>The points, according to the cleared lines</returns>
    Private Function pointCalculator(ByVal lineCleared As Integer) As Integer
        Select Case lineCleared
            Case 1
                Return 40
            Case 2
                Return 100
            Case 3
                Return 300
            Case 4
                Return 1200
        End Select
        Return 0
    End Function
    ''' <summary>
    ''' Upgrades the speed op the game (falling block)
    ''' </summary>
    Private Sub upgradeSpeed()
        If lineCleared >= 5 Then
            timerTetris.Interval = 750
        ElseIf lineCleared >= 10 Then
            timerTetris.Interval = 500
        ElseIf lineCleared >= 15 Then
            timerTetris.Interval = 300
        End If
    End Sub

    Private Sub btnJoker_Click(sender As Object, e As EventArgs) Handles btnJoker.Click
        btnJoker.Enabled = False
        jokerTimer.Enabled = True
        timerTetris.Interval = 1000
    End Sub
    Private Sub maxScoreHandler()
        If points > maxScore Then
            maxScore = points
            lblMaxScore.Text = maxScore.ToString()
        End If
    End Sub
    Private Sub gameOver()
        gameStarted = False
        timerTetris.Enabled = False
        updateBoard()
        maxScoreHandler()
        MessageBox.Show("Unfortunatly, game is over")
    End Sub

    Private Sub jokerTimer_Tick(sender As Object, e As EventArgs) Handles jokerTimer.Tick
        upgradeSpeed()
        jokerTimer.Enabled = False
    End Sub
End Class
