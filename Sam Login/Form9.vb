Imports System.Text

Public Class Form9

    Private Sub btnMap_Click(sender As Object, e As EventArgs) Handles btnMap.Click

        Dim state As String
        Dim city As String
        Dim street As String
        state = txtState.Text
        city = TxtCity.Text
        street = TxtStreet.Text
        Dim Address As New StringBuilder
        Address.Append("https://www.google.com/maps")
        If txtState.Text <> "" Then
            Address.Append(state = "," & "+")
        End If

        If TxtCity.Text <> "" Then
            Address.Append(city = "," & "+")
        End If

        If TxtStreet.Text <> "" Then
            Address.Append(street = "," & "+")
        End If

        Browser.Navigate(Address.ToString)


    End Sub

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class