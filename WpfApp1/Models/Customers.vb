Option Explicit On
Option Strict On

Imports System.Collections.ObjectModel
Imports System.ComponentModel
Public Class Customers
	Private _customers As ObservableCollection(Of Customer)
	Default Public Property Items(index As Integer) As ObservableCollection(Of Customer)
		Get
			Return _customers
		End Get
		Set(ByVal value As ObservableCollection(Of Customer))
			_customers = value
		End Set
	End Property
End Class
