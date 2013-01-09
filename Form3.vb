'----------------------------------------------
' Name       : Jordan Greisinger and Michael Hankins
' Course     : CS2340, Section 1, Fall 2012
' Description: Final Project
'              Form Race
'----------------------------------------------
Public Class FormClassRace
    Dim numPixels, numLaps As Integer
    Dim raceStarted As Boolean = False
    Dim oneOrTwo As Boolean = True 'True stands for car one being the primary moving car and vice versa
    Dim bothOnScreen As Boolean = False 'True means that you can see both cars on the screen 

    Private Const HIDE_CAR As Integer = -150
    Private Const CONTROL_SPEED As Integer = 2
    Private Const START_SPEED As Integer = 3
    Private Const MAX_SPEED As Integer = 9

    '----------------------------------------------
    'This method is called when the Exit button is clicked it then closes the application.
    '----------------------------------------------
    Private Sub btnExit_Click(sender As System.Object, e As System.EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    '----------------------------------------------
    'This method is used to initialize all the necessary variables in the beginning of the program to
    'make the program is all set up both behind the scenes and on the form.
    '----------------------------------------------
    Private Sub FormClassRace_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        CarBox2.Left = HIDE_CAR
        btnSlowDown.Enabled = False
        btnSpeedUp.Enabled = False

        CarBox1.BringToFront()
        CarBox2.BringToFront()
    End Sub

    '----------------------------------------------
    'This method checks if the defined form close event is used otherwise it stops the action from taking
    'place. (ex. ALT + F4)
    '----------------------------------------------
    Private Sub FormClassRace_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        UserClosingForm(e)
    End Sub

    '----------------------------------------------
    'This method is used to initialize all the variables and properties to there correct values and settins
    'so that the form is set up properly before the race starts.
    '----------------------------------------------
    Private Sub startRace()
        lblLaps.Text = "Laps to go: " & Dialog1.TextBox1.Text
        CarBox1.Left = 0
        CarBox2.Left = HIDE_CAR
        Timer1.Enabled = True
        Me.ControlBox = False
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
        numPixels = START_SPEED
        btnExit.Enabled = False
        btnStart.Text = "STOP"
        btnSlowDown.Enabled = True
        btnSpeedUp.Enabled = True
        raceStarted = True
        numLaps = Dialog1.TextBox1.Text
    End Sub

    '----------------------------------------------
    'This method is used to get the race set up in terms of how many laps are done (the input is checked to
    'make sure that it is valid based on the given requirements and outputs a message if the input is
    'invalid) from there it calls start race to get the race started.
    '----------------------------------------------
    Private Sub btnStart_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click
        If btnStart.Text = "START" And raceStarted = True Then
            btnStart.Text = "STOP"
            Timer1.Enabled = True
        ElseIf btnStart.Text = "STOP" And raceStarted = True Then
            btnStart.Text = "START"
            Timer1.Enabled = False
        ElseIf btnStart.Text = "START" And raceStarted = False Then
            Dialog1.ShowDialog()
            If Dialog1.DialogResult = DialogResult.OK Then
                If IsNumeric(Dialog1.TextBox1.Text) Then
                    If Dialog1.TextBox1.Text.Contains("e") Or Dialog1.TextBox1.Text.Contains("E") Then
                        MsgBox("Incorrect input!" + vbCrLf + "Try again!", MsgBoxStyle.OkOnly)
                    ElseIf Dialog1.TextBox1.Text <= 0 Then
                        MsgBox("Incorrect input!" + vbCrLf + "Try again!", MsgBoxStyle.OkOnly)
                    Else
                        startRace()
                    End If
                Else
                    MsgBox("Incorrect input!" + vbCrLf + "Try again!", MsgBoxStyle.OkOnly)
                End If
            Else
                MsgBox("Incorrect input!" + vbCrLf + "Try again!", MsgBoxStyle.OkOnly)
            End If
        End If
    End Sub

    '----------------------------------------------
    'This method is used to increase the interval of pixels the car moves at each timer tick.
    '----------------------------------------------
    Private Sub btnSpeedUp_Click(sender As System.Object, e As System.EventArgs) Handles btnSpeedUp.Click
        If numPixels < MAX_SPEED Then
            numPixels += CONTROL_SPEED
            btnSlowDown.Enabled = True
            If numPixels = MAX_SPEED Then
                btnSpeedUp.Enabled = False
            End If
        End If
    End Sub

    '----------------------------------------------
    ''This method is used to decrease the interval of pixels the car moves at each timer tick.
    '----------------------------------------------
    Private Sub btnSlowDown_Click(sender As System.Object, e As System.EventArgs) Handles btnSlowDown.Click
        If numPixels > 1 Then
            numPixels -= CONTROL_SPEED
            btnSpeedUp.Enabled = True
            If numPixels = 1 Then
                btnSlowDown.Enabled = False
            End If
        End If
    End Sub

    '----------------------------------------------
    'This method is meant to take the set interval and move the car that amount each time the timer ticks.
    '----------------------------------------------
    Private Sub moveCars()
        If bothOnScreen = False Then
            If oneOrTwo Then
                CarBox1.Left += numPixels
            Else
                CarBox2.Left += numPixels
            End If
        Else
            CarBox1.Left += numPixels
            CarBox2.Left += numPixels
        End If
    End Sub

    '----------------------------------------------
    'This method is used to alternate each car on the screen and change the "switch" variables according
    'to the current state the cars are in (which one is leaving the screen and which is entering).
    'It also is used to update the laps label at the correct point during the race.
    '----------------------------------------------
    Private Sub whichCarToDisplay()
        If CarBox1.Right >= Me.ClientSize.Width Then
            oneOrTwo = False
            bothOnScreen = True
            If CarBox1.Left >= Me.ClientSize.Width Then
                CarBox1.Left = HIDE_CAR
                bothOnScreen = False
                numLaps -= 1
                lblLaps.Text = "Laps to go: " + numLaps.ToString
            End If
        ElseIf CarBox2.Right >= Me.ClientSize.Width Then
            oneOrTwo = True
            bothOnScreen = True
            If CarBox2.Left >= Me.ClientSize.Width Then
                CarBox2.Left = HIDE_CAR
                bothOnScreen = False
                numLaps -= 1
                lblLaps.Text = "Laps to go: " + numLaps.ToString
            End If
        End If
    End Sub

    '----------------------------------------------
    'This method is used to set all the appropriate variables and properties needed before a race is started.
    '----------------------------------------------
    Private Sub resetForNextRace()
        Me.ControlBox = True
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        btnExit.Enabled = True
        oneOrTwo = True
        bothOnScreen = False
        btnSlowDown.Enabled = False
        btnSpeedUp.Enabled = False
    End Sub

    '----------------------------------------------
    'This method is used to make sure the car is in the right spot at the end of the race along with the
    'timer being disabled and all the appropriate variables being set to the correct value for when the race
    'ends.
    '----------------------------------------------
    Private Sub endOfRace()
        If numLaps = 0 Then
            If oneOrTwo Then
                If CarBox1.Left >= 0 Then
                    CarBox1.Left = 0
                    Timer1.Enabled = False
                    raceStarted = False
                    btnStart.Text = "START"
                End If
            Else
                If CarBox2.Left >= 0 Then
                    CarBox2.Left = 0
                    Timer1.Enabled = False
                    raceStarted = False
                    btnStart.Text = "START"
                End If
            End If
            resetForNextRace()
        End If
    End Sub

    '----------------------------------------------
    'This method is used to call all the appropriate methods to run the race such as moving the car
    'along with setting the lap label to the appropriate amount of laps.
    '----------------------------------------------
    Private Sub Timer1_Tick(sender As Object, e As System.EventArgs) Handles Timer1.Tick
        moveCars()
        whichCarToDisplay()
        endOfRace()
    End Sub

    '----------------------------------------------
    'This method takes the size of the form and adjusts all the controls on the form so that
    'they are spaced as stated in the requirements.
    '----------------------------------------------
    Private Sub FormClassRace_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Dim FormWidth As Integer
        Dim FormHeight As Integer
        Dim temp_W1 As Integer
        Dim temp_W2 As Integer
        Dim temp_W3 As Integer

        Dim temp_H1 As Integer
        Dim temp_H2 As Integer
        Dim one_half_H1 As Integer
        Dim one_fourth_H2 As Integer

        FormWidth = Me.ClientSize.Width
        FormHeight = Me.ClientSize.Height

        lblTrack.Width = FormWidth

        'Vertical positioning for the track, car, title label, Start/Stop button, and Exit button
        temp_H1 = (FormHeight - lblTrack.Height) / DIVIDE_BY_TWO
        one_half_H1 = temp_H1 / DIVIDE_BY_TWO

        lblTrack.Top = temp_H1
        CarBox1.Top = lblTrack.Top - CarBox1.Height
        CarBox2.Top = lblTrack.Top - CarBox1.Height
        lblTitle.Top = one_half_H1 - (lblTitle.Height / DIVIDE_BY_TWO)
        btnStart.Top = lblTrack.Bottom + (one_half_H1 - (btnStart.Height / DIVIDE_BY_TWO))
        btnExit.Top = lblTrack.Bottom + (one_half_H1 - (btnStart.Height / DIVIDE_BY_TWO))

        'Horizontal positioning for the title label, Start/Stop button, and Exit button
        temp_W1 = (FormWidth - lblTitle.Width) / DIVIDE_BY_TWO
        temp_W2 = (MULTIPLY_BY_FIVE * (FormWidth - (MULTIPLY_BY_TWO * btnStart.Width))) / DIVIDE_BY_TWELVE

        lblTitle.Left = temp_W1
        btnStart.Left = temp_W2
        btnExit.Left = btnStart.Right + ((MULTIPLY_BY_TWO / DIVIDE_BY_FIVE) * temp_W2)

        'Vertical positioning for the Speed Up and Speed Down buttons along with the laps label
        temp_H2 = (MULTIPLY_BY_TWO * (temp_H1 - (lblLaps.Height +
                                                 (MULTIPLY_BY_TWO * btnSpeedUp.Height)))) / DIVIDE_BY_FIVE
        one_fourth_H2 = temp_H2 / DIVIDE_BY_FOUR

        lblLaps.Top = temp_H2
        btnSpeedUp.Top = lblLaps.Bottom + one_fourth_H2
        btnSlowDown.Top = btnSpeedUp.Bottom + one_fourth_H2

        'Horizontal positioning for the Speed Up and Speed Down buttons along with the laps label
        temp_W3 = (MULTIPLY_BY_THREE * (temp_W1 - btnSpeedUp.Width)) / DIVIDE_BY_FIVE

        btnSpeedUp.Left = lblTitle.Right + temp_W3
        btnSlowDown.Left = lblTitle.Right + temp_W3
        lblLaps.Left = btnSpeedUp.Left
    End Sub
End Class