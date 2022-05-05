Public Class Window1
    Dim ymdS As Date
    Dim ymdE As Date


    Private Sub Button1_Click(sender As Object, e As RoutedEventArgs)
        Label2.DataContext = Format(Now, "yyyy年mm月dd日")

        ymdS = Format(Now, "yyyy年mm月dd日")
    End Sub

End Class
