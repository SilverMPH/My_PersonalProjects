'----------------------------------------------
' Name       : Jordan Greisinger and Michael Hankins
' Course     : CS2340, Section 1, Fall 2012
' Description: Final Project
'              Form Login
'----------------------------------------------
Public Class FormClassLogin

    'This sub handles what happens when the user tries to close the form the wrong way. If this form isn't being closed the 
    'right way, it will ignore the users request to close the form.
    Private Sub FormClassLogin_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        UserClosingForm(e)
    End Sub

    'When the form loads, the admin radio button will be checked and the user textbox will have the focus.
    'Also the character casing for the user textbox will be set to upper.
    Private Sub FormClassLogin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        rdbAdmin.Checked = True
        txtUser.Focus()
        txtUser.CharacterCasing = CharacterCasing.Upper
        txtUser.Text = user
        txtPass.Text = pass
    End Sub

    'When the user hits the Cancel button, the application will exit entirely.
    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Application.Exit()
    End Sub

    'When the user clicks the login button, one of few things can happen. The first thing is that
    'the sub will check whether or not both textboxes have been filled correctly. It will send an
    'error message if they haven't. Then the sub will check if the admin or the player radio button
    'has been checked. It will then check make sure the userID and password is correct before
    'redirecting the user to the corresponding form.
    Private Sub btnLogin_Click(sender As System.Object, e As System.EventArgs) Handles btnLogin.Click
        If txtUser.Text.Trim = "" Then
            MsgBox("Please enter the UserID!", MsgBoxStyle.Information)
            txtUser.Focus()
        ElseIf txtPass.Text.Trim = "" Then
            MsgBox("Please enter the Password!", MsgBoxStyle.Information)
            txtPass.Focus()
        Else
            If rdbAdmin.Checked = True Then
                Try
                    FormClassAdmin.EmployeeTableAdapter.LoginAdmin(FormClassAdmin.CarRaceDataSet.Employee, txtUser.Text, txtPass.Text)
                    If FormClassAdmin.EmployeeBindingSource.Count > 0 Then
                        user = txtUser.Text
                        pass = txtPass.Text
                        Me.Hide()
                        FormClassAdmin.Show()
                    Else
                        MsgBox("Incorrect UserID or Password!" + vbCrLf + "Try again!", MsgBoxStyle.OkOnly)
                    End If
                Catch ex As System.Exception
                    System.Windows.Forms.MessageBox.Show(ex.Message)
                End Try
            ElseIf rdbPlayer.Checked = True Then
                Try
                    FormClassAdmin.EmployeeTableAdapter.LoginPlayer(FormClassAdmin.CarRaceDataSet.Employee, txtUser.Text, txtPass.Text)
                    If FormClassAdmin.EmployeeBindingSource.Count > 0 Then
                        Me.Hide()
                        FormClassRace.Show()
                    Else
                        MsgBox("Incorrect UserID or Password!" + vbCrLf + "Try again!", MsgBoxStyle.OkOnly)
                    End If
                Catch ex As System.Exception
                    System.Windows.Forms.MessageBox.Show(ex.Message)
                End Try
            End If
        End If
    End Sub
End Class
