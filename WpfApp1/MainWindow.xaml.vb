
Class MainWindow
    Dim ymdS As Date
    Private Sub Button1_Click(sender As Object, e As RoutedEventArgs)
        Label2.DataContext = Format(Now, "yyyy年mm月dd日")

        'ymdS = Format(Now, "yyyy年mm月dd日")
        Label1.DataContext = 1

        Label1.DataContext = Label1.DataContext + 2

    End Sub

    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        testText.Text = "Hello! .NET"
    End Sub
End Class
