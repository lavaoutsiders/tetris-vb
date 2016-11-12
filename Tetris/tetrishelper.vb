Public Class tetrishelper

    Public Shared Function relativeCoordinates(ByVal tetrisType As Integer) As Integer(,)
        Select Case tetrisType
            ' 1st coordinate is the middlepoint, which never changes when rotate
            Case 0 ' ---- 
                Return {{0, 0}, {2, 0}, {1, 0}, {3, 0}}
            Case 1 ' --'
                Return {{1, 2}, {0, 2}, {1, 0}, {1, 1}}
            Case 2 ' '--
                Return {{1, 1}, {0, 0}, {1, 2}, {1, 0}}
            Case 3 ' +
                Return {{0, 0}, {1, 0}, {0, 1}, {1, 1}}
            Case 4 ' _+-
                Return {{1, 1}, {0, 1}, {0, 2}, {1, 0}}
            Case 5 ' _+_
                Return {{1, 1}, {1, 2}, {0, 1}, {1, 0}}
            Case 6 ' -+_
                Return {{0, 1}, {0, 0}, {1, 1}, {1, 2}}
        End Select

    End Function

    'Position indicates the n-th element of the relative coordinates array
    ''' <summary>
    ''' Returns the Absolute coordinate of the given position (from the iteration from the caller)
    ''' using multipication with vectors.
    ''' |0  1|
    ''' |-1 0|
    ''' </summary>
    ''' <param name="tetrisType">The type of the tetris</param>
    ''' <param name="position">The position of the matrix relative coordinate, please use iteration from 0 to 3</param>
    ''' <param name="startX">The absolute X value (the start X coordinate)</param>
    ''' <param name="startY">The absolute Y value (the start Y coordinate)</param>
    ''' <param name="tetrisStand">The stand of the tetris (0-3) 0 - 270 degrees</param>
    ''' <returns></returns>
    Public Shared Function coordinateCalculator(ByVal tetrisType As Integer, ByVal position As Integer, ByVal startX As Integer, ByVal startY As Integer, ByVal tetrisStand As Integer) As Integer()
        Dim relativeCoordinate As Integer(,) = relativeCoordinates(tetrisType)
        Dim absoluteX As Integer
        Dim absoluteY As Integer

        Select Case tetrisStand

            Case 0
                absoluteX = relativeCoordinate(position, 0) + startX
                absoluteY = relativeCoordinate(position, 1) + startY
            Case 1

                Dim rotationX As Integer = relativeCoordinate(0, 0)
                Dim rotationY As Integer = relativeCoordinate(0, 1)
                Dim differenceX As Integer = rotationX - relativeCoordinate(position, 0)
                Dim differenceY As Integer = rotationY - relativeCoordinate(position, 1)

                Dim reversedX As Integer = 1 * differenceY
                Dim reversedY As Integer = -1 * differenceX

                absoluteX = startX + reversedX
                absoluteY = startY + reversedY + 1
            Case 2

                Dim rotationX As Integer = relativeCoordinate(0, 0)
                Dim rotationY As Integer = relativeCoordinate(0, 1)
                Dim differenceX As Integer = relativeCoordinate(position, 0) - rotationX
                Dim differenceY As Integer = relativeCoordinate(position, 1) - rotationY
                Dim reversedX As Integer = -1 * differenceX
                Dim reversedY As Integer = -1 * differenceY

                absoluteX = startX + reversedX
                absoluteY = startY + reversedY
            Case 3
                Dim rotationX As Integer = relativeCoordinate(0, 0)
                Dim rotationY As Integer = relativeCoordinate(0, 1)
                Dim differenceX As Integer = relativeCoordinate(position, 0) - rotationX
                Dim differenceY As Integer = relativeCoordinate(position, 1) - rotationY
                Dim reversedX As Integer = 1 * differenceY
                Dim reversedY As Integer = -1 * differenceX

                absoluteX = startX + reversedX
                absoluteY = startY + reversedY + 1

        End Select
        'Return the absolute x en y

        Return {absoluteX, absoluteY}
    End Function
    ''' <summary>
    ''' Returns the corresponding color of the the type tetermino
    ''' </summary>
    ''' <param name="tetrisType"></param>
    ''' <returns></returns>
    Public Shared Function returnColor(ByVal tetrisType As Integer) As Color
        Select Case tetrisType
            Case 0
                Return Color.Aqua
            Case 1
                Return Color.Blue
            Case 2
                Return Color.Orange
            Case 3
                Return Color.Yellow
            Case 4
                Return Color.Green
            Case 5
                Return Color.Violet
            Case 6
                Return Color.Red

        End Select
    End Function

End Class
