Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form3

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListView1.Items.Add(New ListViewItem(New String() {NumericUpDown1.Value, TextBox2.Text, DateTimePicker1.Text, TextBox4.Text}))
        TextBox2.Clear()
        TextBox4.Clear()
    End Sub
    Sub recharger(ByVal fichier As String)
        ListView1.Items.Clear()
        Dim itemsplit As String = "#"
        Dim colonnesplit As String = ";"
        Try
            If IO.File.Exists(fichier) Then
                Dim donnees As String = IO.File.ReadAllText(fichier)
                Dim elements() As String = donnees.Split(New String() {itemsplit}, StringSplitOptions.RemoveEmptyEntries)
                For Each element As String In elements
                    If (element.Contains(colonnesplit)) Then
                        Dim lesvaleurs() As String = element.Split(New String() {colonnesplit}, StringSplitOptions.None)
                        Dim nouveauelement As New ListViewItem
                        For i As Integer = 0 To lesvaleurs.Length - 1
                            If i = 0 Then
                                nouveauelement.Text = lesvaleurs(i)
                            Else
                                nouveauelement.SubItems.Add(lesvaleurs(i))
                            End If

                        Next
                        ListView1.Items.Add(nouveauelement)

                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "erreur")

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Using ouvrir As New OpenFileDialog
            ouvrir.Filter = "rdv|* .txt"
            If ouvrir.ShowDialog() = DialogResult.OK Then
                recharger(ouvrir.FileName)

            End If
        End Using
        MsgBox("Succés")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class