Public Class startChoice
    Private Sub btnNormal_Click(sender As Object, e As EventArgs) Handles btnNormal.Click
        TetrisX = 9
        TetrisY = 19
        Dim tetrisForm As New tetris()
        tetrisForm.Show()

    End Sub

    Private Sub btnCustom_Click(sender As Object, e As EventArgs) Handles btnCustom.Click
        Dim inputX As String = InputBox("Dimension x of the game", "Dimension x")

        While (Not IsNumeric(inputX))
            If inputX = "" Then
                Me.Close()
                Return
            End If
            inputX = InputBox("Dimension x of the game", "Dimension x")
        End While
        While inputX < 0
            inputX = InputBox("Dimension x of the game", "Dimension x")

        End While
        Dim inputY As String = InputBox("Dimension y of the game", "Dimension y")
        While Not IsNumeric(inputY)
            If inputY = "" Then
                Me.Close()
                Return
            End If
            inputX = InputBox("Dimension y of the game", "Dimension y")
        End While
        While inputY < 0
            inputX = InputBox("Dimension x of the game", "Dimension x")

        End While
        TetrisX = inputX - 1
        TetrisY = inputY - 1
        Dim tetrisForm As New tetris()
        Dim sizeX As Integer = inputX * 20 + 50
        Dim sizeY As Integer = inputY * 25 + 150
        If sizeX < 350 Then
            sizeX = 350
        End If
        If sizeY < 600 Then
            sizeY = 400
        End If
        tetrisForm.Size = New System.Drawing.Size(sizeX, sizeY)
        tetrisForm.Show()


    End Sub
End Class