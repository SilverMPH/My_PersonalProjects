<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormClassRace
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
        Me.CarBox1 = New System.Windows.Forms.PictureBox()
        Me.lblTrack = New System.Windows.Forms.Label()
        Me.btnSpeedUp = New System.Windows.Forms.Button()
        Me.btnSlowDown = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblLaps = New System.Windows.Forms.Label()
        Me.CarBox2 = New System.Windows.Forms.PictureBox()
        Me.lblTest = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        CType(Me.CarBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CarBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CarBox1
        '
        Me.CarBox1.Image = Global.GreisingerJ_Project.My.Resources.Resources.CAR
        Me.CarBox1.Location = New System.Drawing.Point(-2, 159)
        Me.CarBox1.Name = "CarBox1"
        Me.CarBox1.Size = New System.Drawing.Size(150, 50)
        Me.CarBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.CarBox1.TabIndex = 0
        Me.CarBox1.TabStop = False
        '
        'lblTrack
        '
        Me.lblTrack.BackColor = System.Drawing.SystemColors.Desktop
        Me.lblTrack.Location = New System.Drawing.Point(0, 204)
        Me.lblTrack.Name = "lblTrack"
        Me.lblTrack.Size = New System.Drawing.Size(794, 5)
        Me.lblTrack.TabIndex = 1
        Me.lblTrack.Text = "Label1"
        '
        'btnSpeedUp
        '
        Me.btnSpeedUp.Location = New System.Drawing.Point(602, 89)
        Me.btnSpeedUp.Name = "btnSpeedUp"
        Me.btnSpeedUp.Size = New System.Drawing.Size(93, 23)
        Me.btnSpeedUp.TabIndex = 2
        Me.btnSpeedUp.Text = "SPEED UP"
        Me.btnSpeedUp.UseVisualStyleBackColor = True
        '
        'btnSlowDown
        '
        Me.btnSlowDown.Location = New System.Drawing.Point(602, 118)
        Me.btnSlowDown.Name = "btnSlowDown"
        Me.btnSlowDown.Size = New System.Drawing.Size(93, 23)
        Me.btnSlowDown.TabIndex = 3
        Me.btnSlowDown.Text = "SLOW DOWN"
        Me.btnSlowDown.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(259, 313)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 4
        Me.btnStart.Text = "START"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(459, 313)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "EXIT"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 50
        '
        'lblLaps
        '
        Me.lblLaps.AutoSize = True
        Me.lblLaps.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLaps.Location = New System.Drawing.Point(588, 52)
        Me.lblLaps.Name = "lblLaps"
        Me.lblLaps.Size = New System.Drawing.Size(101, 20)
        Me.lblLaps.TabIndex = 6
        Me.lblLaps.Text = "Laps to go: 0"
        '
        'CarBox2
        '
        Me.CarBox2.Image = Global.GreisingerJ_Project.My.Resources.Resources.CAR
        Me.CarBox2.Location = New System.Drawing.Point(-2, 154)
        Me.CarBox2.Name = "CarBox2"
        Me.CarBox2.Size = New System.Drawing.Size(150, 50)
        Me.CarBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.CarBox2.TabIndex = 7
        Me.CarBox2.TabStop = False
        '
        'lblTest
        '
        Me.lblTest.AutoSize = True
        Me.lblTest.Location = New System.Drawing.Point(656, 387)
        Me.lblTest.Name = "lblTest"
        Me.lblTest.Size = New System.Drawing.Size(0, 13)
        Me.lblTest.TabIndex = 8
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(344, 60)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(110, 25)
        Me.lblTitle.TabIndex = 9
        Me.lblTitle.Text = "Car Race"
        '
        'FormClassRace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 412)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblTest)
        Me.Controls.Add(Me.CarBox2)
        Me.Controls.Add(Me.lblLaps)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.btnSlowDown)
        Me.Controls.Add(Me.btnSpeedUp)
        Me.Controls.Add(Me.lblTrack)
        Me.Controls.Add(Me.CarBox1)
        Me.MinimumSize = New System.Drawing.Size(400, 250)
        Me.Name = "FormClassRace"
        Me.Text = "CS234 Project (Jordan Greisinger & Michael Hankins)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.CarBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CarBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CarBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblTrack As System.Windows.Forms.Label
    Friend WithEvents btnSpeedUp As System.Windows.Forms.Button
    Friend WithEvents btnSlowDown As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblLaps As System.Windows.Forms.Label
    Friend WithEvents CarBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblTest As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
End Class
