Public Class MainWindow
	Public Shared ReadOnly Navigate As New RoutedCommand

	Public Sub Navigate_Execute(sender As Object, e As RoutedEventArgs)
		If (Me.DataContext Is Nothing) Then Return
		If (Me.browser Is Nothing) Then Return

		Dim navigateString = DirectCast(Me.DataContext, ViewModel).NavigateString
		Me.browser.NavigateToString(navigateString)
	End Sub
End Class
