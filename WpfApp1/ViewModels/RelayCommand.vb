Option Explicit On
Option Strict On

Imports System.ComponentModel
Imports System.Windows.Input

Public Class RelayCommand
	Implements ICommand

	Private _canExecuteAction As Func(Of Object, Boolean)
	Private _executeAction As Action(Of Object)

	Public Sub New(ByVal executeAction As Action(Of Object),
				   ByVal canExecuteAction As Func(Of Object, Boolean))
		Me._executeAction = executeAction
		Me._canExecuteAction = canExecuteAction
	End Sub

	Public Function CanExecute(ByVal parameter As Object) As Boolean Implements ICommand.CanExecute
		Return _canExecuteAction(parameter)
	End Function

	Public Event CanExecuteChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements ICommand.CanExecuteChanged

	Public Sub Execute(ByVal parameter As Object) Implements ICommand.Execute
		_executeAction(parameter)
	End Sub
End Class
