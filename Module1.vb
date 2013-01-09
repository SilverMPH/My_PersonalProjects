'----------------------------------------------
' Name       : Jordan Greisinger and Michael Hankins
' Course     : CS2340, Section 1, Fall 2012
' Description: Final Project
'              Module
'----------------------------------------------
Module Module1
    Friend user, pass As String
    Friend Const DIVIDE_BY_TWO As Integer = 2
    Friend Const DIVIDE_BY_FOUR As Integer = 4
    Friend Const DIVIDE_BY_FIVE As Integer = 5
    Friend Const DIVIDE_BY_TWELVE As Integer = 12

    Friend Const MULTIPLY_BY_TWO As Integer = 2
    Friend Const MULTIPLY_BY_THREE As Integer = 3
    Friend Const MULTIPLY_BY_FIVE As Integer = 5

    ''' <summary>
    ''' Refuses to close a form when the user tries to close it
    ''' by clicking on the form close button or press Alt+F4.
    ''' </summary>
    ''' <param name="e"> Copied from the FormClosing event procedure of any form. </param>
    ''' <remarks>You add remarks here</remarks>
    Friend Sub UserClosingForm(ByVal e As System.Windows.Forms.FormClosingEventArgs)
        If e.CloseReason = CloseReason.ApplicationExitCall Then
            Application.Exit()
        Else
            e.Cancel = True
        End If
    End Sub

    '----------------------------------------------
    'This is the main that is used to start up the entire program and load the correct form in the
    'beginning.
    '----------------------------------------------
    Sub main()
        Dim frmLogin As New FormClassLogin
        Dim frmAdmin As New FormClassAdmin
        Dim frmRace As New FormClassRace
        Application.Run(frmLogin)
    End Sub
End Module
