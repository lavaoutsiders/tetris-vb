<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tetris
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.timerTetris = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPoints = New System.Windows.Forms.Label()
        Me.btnJoker = New System.Windows.Forms.Button()
        Me.jokerTimer = New System.Windows.Forms.Timer(Me.components)
        Me.btnStart = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblMaxScore = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'timerTetris
        '
        Me.timerTetris.Enabled = True
        Me.timerTetris.Interval = 1000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(207, 173)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Point"
        '
        'lblPoints
        '
        Me.lblPoints.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lblPoints.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPoints.Location = New System.Drawing.Point(278, 166)
        Me.lblPoints.Name = "lblPoints"
        Me.lblPoints.Size = New System.Drawing.Size(42, 27)
        Me.lblPoints.TabIndex = 2
        Me.lblPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnJoker
        '
        Me.btnJoker.Location = New System.Drawing.Point(230, 328)
        Me.btnJoker.Name = "btnJoker"
        Me.btnJoker.Size = New System.Drawing.Size(75, 23)
        Me.btnJoker.TabIndex = 0
        Me.btnJoker.TabStop = False
        Me.btnJoker.Text = "Joker"
        Me.btnJoker.UseVisualStyleBackColor = True
        '
        'jokerTimer
        '
        Me.jokerTimer.Interval = 30000
        '
        'btnStart
        '
        Me.btnStart.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.btnStart.Location = New System.Drawing.Point(231, 302)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(74, 23)
        Me.btnStart.TabIndex = 3
        Me.btnStart.Text = "Start"
        Me.btnStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(207, 210)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Max Score"
        '
        'lblMaxScore
        '
        Me.lblMaxScore.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lblMaxScore.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblMaxScore.Location = New System.Drawing.Point(278, 203)
        Me.lblMaxScore.Name = "lblMaxScore"
        Me.lblMaxScore.Size = New System.Drawing.Size(42, 27)
        Me.lblMaxScore.TabIndex = 5
        Me.lblMaxScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tetris
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(332, 417)
        Me.Controls.Add(Me.lblMaxScore)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.btnJoker)
        Me.Controls.Add(Me.lblPoints)
        Me.Controls.Add(Me.Label1)
        Me.Name = "tetris"
        Me.Text = "Tetris"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents timerTetris As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents lblPoints As Label
    Friend WithEvents btnJoker As Button
    Friend WithEvents jokerTimer As Timer
    Friend WithEvents btnStart As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblMaxScore As Label
End Class
