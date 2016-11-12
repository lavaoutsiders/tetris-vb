<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class startChoice
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
        Me.btnNormal = New System.Windows.Forms.Button()
        Me.btnCustom = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnNormal
        '
        Me.btnNormal.Location = New System.Drawing.Point(54, 41)
        Me.btnNormal.Name = "btnNormal"
        Me.btnNormal.Size = New System.Drawing.Size(184, 70)
        Me.btnNormal.TabIndex = 0
        Me.btnNormal.Text = "Normal - 10 * 20 Game"
        Me.btnNormal.UseVisualStyleBackColor = True
        '
        'btnCustom
        '
        Me.btnCustom.Location = New System.Drawing.Point(54, 146)
        Me.btnCustom.Name = "btnCustom"
        Me.btnCustom.Size = New System.Drawing.Size(184, 70)
        Me.btnCustom.TabIndex = 1
        Me.btnCustom.Text = "Define a new Game"
        Me.btnCustom.UseVisualStyleBackColor = True
        '
        'startChoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.btnCustom)
        Me.Controls.Add(Me.btnNormal)
        Me.Name = "startChoice"
        Me.Text = "startChoice"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnNormal As Button
    Friend WithEvents btnCustom As Button
End Class
