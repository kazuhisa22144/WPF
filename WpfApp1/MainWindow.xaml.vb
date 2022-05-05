
Class MainWindow
    Dim ymdS As Date
    Private Sub Button1_Click(sender As Object, e As RoutedEventArgs)


    End Sub

    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        testText.Text = Format(Now, "yyyy年MM月dd日")
    End Sub
End Class
