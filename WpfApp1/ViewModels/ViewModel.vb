Option Explicit On
Option Strict On

Imports System.Collections.ObjectModel
Imports System.ComponentModel


Public Class ViewModel
	Implements INotifyPropertyChanged

	Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

#Region "コンストラクタ"
	Public Sub New()
		_customers.Add(New Customer() With {.Address = "東京駅"})
	End Sub
#End Region

#Region "プロパティ"
	Private _address As String
	Public Property Address() As String
		Get
			Return _address
		End Get
		Set(ByVal value As String)
			If (_address = value) Then Return
			_address = value
			RaisePropertyChanged("Address")

			Me.AddItem = New RelayCommand(AddressOf AddItemCommand, AddressOf CanAddItem)
		End Set
	End Property

	Private _customer As Customer
	Public Property Customer() As Customer
		Get
			Return _customer
		End Get
		Set(ByVal value As Customer)
			_customer = value
			RaisePropertyChanged("Customer")
		End Set
	End Property

	Private _customers As New ObservableCollection(Of Customer)
	Public Property Customers() As ObservableCollection(Of Customer)
		Get
			Return _customers
		End Get
		Set(ByVal value As ObservableCollection(Of Customer))
			_customers = value
			RaisePropertyChanged("Customers")
		End Set
	End Property

	Public ReadOnly Property NavigateString() As String
		Get
			Return GetNavigateString()
		End Get
	End Property
#End Region

#Region "コマンド"

#Region "AddItem"
	Private _addItem As RelayCommand

	Public Property AddItem() As RelayCommand
		Get
			If _addItem Is Nothing Then
				_addItem = New RelayCommand(AddressOf AddItemCommand, AddressOf CanAddItem)
			End If
			Return _addItem
		End Get
		Set(value As RelayCommand)
			_addItem = value
			RaisePropertyChanged("AddItem")
		End Set
	End Property

	Public Function CanAddItem(ByVal parameter As Object) As Boolean
		If (String.IsNullOrEmpty(Me.Address)) Then
			Return False
		End If
		Return _customers.Count <= 25
	End Function

	Private Sub AddItemCommand(ByVal parameter As Object)
		_customers.Add(New Customer() With {.Address = Me.Address})
		Me.Address = String.Empty
	End Sub
#End Region

#Region "Delete"
	Private _delete As RelayCommand

	Public ReadOnly Property Delete() As RelayCommand
		Get
			If _delete Is Nothing Then
				_delete = New RelayCommand(AddressOf DeleteCommand, AddressOf CanDelete)
			End If
			Return _delete
		End Get
	End Property

	Private Function CanDelete(ByVal parameter As Object) As Boolean
		Return True
	End Function

	Private Sub DeleteCommand(ByVal parameter As Object)
		_customers.Remove(Me.Customer)
	End Sub
#End Region

#End Region

#Region "メソッド"

	Public Function GetNavigateString() As String
		Dim html As New System.Text.StringBuilder()
		With html
			.AppendLine("<!DOCTYPE html '-//W3C//DTD XHTML 1.0 Strict//EN'  ")
			.AppendLine("  'http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd'> ")
			.AppendLine("<!-- saved from url=(0017)http://localhost/ -->")
			.AppendLine("<html xmlns='http://www.w3.org/1999/xhtml'> ")
			.AppendLine("	<head> ")
			.AppendLine("	<meta http-equiv='content-type' content='text/html; charset=utf-8'/> ")
			.AppendLine("	<script type='text/javascript' src='http://maps.google.com/maps?file=api&key=(key)&sensor=false'></script> ")
			.AppendLine("	<script type='text/javascript'> ")
			.AppendLine("		var map; ")
			.AppendLine("		var directions; ")
			.AppendLine()
			.AppendLine("		function initialize() { ")
			.AppendLine("			if (GBrowserIsCompatible()) { ")
			.AppendLine("				map = new GMap2(document.getElementById('map_canvas')); ")
			.AppendLine("				map.enableScrollWheelZoom(); ")
			.AppendLine("				map.setCenter(new GLatLng(35.681379, 139.765577), 13); ")
			.AppendLine("				directions = new GDirections(map, document.getElementById('route')); ")
			.AppendFormat("				var pointArray = [{0}]; ", GetPointList())
			.AppendLine()
			.AppendLine("				directions.loadFromWaypoints(pointArray,{ locale: 'ja_JP' }); ")
			.AppendLine("			} ")
			.AppendLine("		} ")
			.AppendLine("	</script> ")
			.AppendLine("</head> ")
			.AppendLine("	<body onload='initialize()'> ")
			.AppendLine("		<div id='map_canvas' style='width: 100%; height: 400px'></div> ")
			.AppendLine("		<div id='route' style='width: 100%; height: Auto'></div> ")
			.AppendLine("	</body> ")
			.AppendLine("</html> ")
		End With
		Return html.ToString()
	End Function

	Private Function GetPointList() As String
		Dim ret As String = String.Empty
		For Each item In _customers
			ret += "'" + item.Address + "',"
		Next
		If (Not String.IsNullOrEmpty(ret)) Then
			ret = ret.Substring(0, ret.Length - 1)
		End If
		Return ret
	End Function

	Public Sub RaisePropertyChanged(propertyName As String)
		RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
	End Sub

#End Region

End Class
