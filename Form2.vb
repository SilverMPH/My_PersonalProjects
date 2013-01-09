'----------------------------------------------
' Name       : Jordan Greisinger and Michael Hankins
' Course     : CS2340, Section 1, Fall 2012
' Description: Final Project
'              Form Admin
'----------------------------------------------
Public Class FormClassAdmin

    '----------------------------------------------
    'This method checks if the defined form close event is used otherwise it stops the action from taking
    'place. (ex. ALT + F4)
    '----------------------------------------------
    Private Sub FormClassAdmin_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        UserClosingForm(e)
    End Sub

    '----------------------------------------------
    'This method sets up the Admin Grid with the connected table and sets it to display the first item
    'in the table.
    '----------------------------------------------
    Private Sub FormClassAdmin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'CarRaceDataSet.Employee' table. You can move, or remove it, as needed.
        Try
            Me.EmployeeTableAdapter.Fill(Me.CarRaceDataSet.Employee)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '----------------------------------------------
    'This method is used to enable or disable all the appropriate buttons when it is called based on the 
    'boolean variable that is passed to it.
    '----------------------------------------------
    Private Sub enable_Disable(ByVal enableDisable_All As Boolean)
        If enableDisable_All Then
            BindingNavigator1.MoveFirstItem = bnMoveFirstItem
            BindingNavigator1.MovePreviousItem = bnMovePreviousItem
            BindingNavigator1.MoveNextItem = bnMoveNextItem
            BindingNavigator1.MoveLastItem = bnMoveLastItem
            bnMoveFirstItem.Enabled = enableDisable_All
            bnMovePreviousItem.Enabled = enableDisable_All
            bnMoveNextItem.Enabled = enableDisable_All
            bnMoveLastItem.Enabled = enableDisable_All
            bnAddNewItem.Enabled = enableDisable_All
            toolReload.Enabled = enableDisable_All
            toolBack.Enabled = enableDisable_All
            toolExit.Enabled = enableDisable_All
        ElseIf enableDisable_All = False Then
            BindingNavigator1.MoveFirstItem = Nothing
            BindingNavigator1.MovePreviousItem = Nothing
            BindingNavigator1.MoveNextItem = Nothing
            BindingNavigator1.MoveLastItem = Nothing
            bnMoveFirstItem.Enabled = enableDisable_All
            bnMovePreviousItem.Enabled = enableDisable_All
            bnMoveNextItem.Enabled = enableDisable_All
            bnMoveLastItem.Enabled = enableDisable_All
            bnAddNewItem.Enabled = enableDisable_All
            toolReload.Enabled = enableDisable_All
            toolBack.Enabled = enableDisable_All
            toolExit.Enabled = enableDisable_All
        End If
    End Sub

    '----------------------------------------------
    'This method is called when the Exit button is clicked it then closes the application.
    '----------------------------------------------
    Private Sub toolExit_Click(sender As System.Object, e As System.EventArgs) Handles toolExit.Click
        Application.Exit()
    End Sub

    '----------------------------------------------
    'This method is called when the "Back to Login" button is pressed it then takes the user to the 
    'previous form hiding this one.
    '----------------------------------------------
    Private Sub toolBack_Click(sender As System.Object, e As System.EventArgs) Handles toolBack.Click
        Me.Hide()
        FormClassLogin.Show()
        FormClassLogin.BringToFront()
    End Sub

    '----------------------------------------------
    'This method reloads the table and any changes that may have been saved to it.
    '----------------------------------------------
    Private Sub toolReload_Click(sender As System.Object, e As System.EventArgs) Handles toolReload.Click
        Try
            Me.EmployeeTableAdapter.Fill(Me.CarRaceDataSet.Employee)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '----------------------------------------------
    'This method saves the current values in the displayed/modified table to the connected data source.
    'After that, if an item was added to the table it then calls the enable_disable and enables the 
    'appropriate buttons.
    '----------------------------------------------
    Private Sub toolSave_Click(sender As System.Object, e As System.EventArgs) Handles toolSave.Click
        Try
            Me.Validate()
            Me.EmployeeBindingSource.EndEdit()
            Me.EmployeeTableAdapter.Update(Me.CarRaceDataSet.Employee)
            If bnAddNewItem.Enabled = False Then
                enable_Disable(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '----------------------------------------------
    'This method deletes the item you are on from the table. After that it calls enable_Disable and then 
    'disables the appropriate buttons.
    '----------------------------------------------
    Private Sub BindingNavigatorDeleteItem_Click(sender As System.Object, e As System.EventArgs) Handles BindingNavigatorDeleteItem.Click
        enable_Disable(True)
    End Sub

    '----------------------------------------------
    'This method sets up the textboxes and such so that you can enter a new item into the table. After
    'that it calls enable_Disable and then disables the appropriate buttons.
    '----------------------------------------------
    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bnAddNewItem.Click
        enable_Disable(False)
    End Sub

    '----------------------------------------------
    'This method is called when a new item is selected or navigated to with the nav bar on top. It then
    'enables and disables the appropriate buttons.
    '----------------------------------------------
    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        If EmployeeBindingSource.Position < EmployeeBindingSource.Count Then
            BindingNavigator1.MoveNextItem = bnMoveNextItem
            BindingNavigator1.MoveLastItem = bnMoveLastItem
            bnMoveNextItem.Enabled = True
            bnMoveLastItem.Enabled = True
        Else
            BindingNavigator1.MoveNextItem = Nothing
            BindingNavigator1.MoveLastItem = Nothing
            bnMoveNextItem.Enabled = False
            bnMoveLastItem.Enabled = False
        End If
    End Sub
End Class