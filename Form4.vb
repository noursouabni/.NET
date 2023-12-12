Imports System.Diagnostics.Eventing.Reader

Public Class Form4



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim gen As String
        Dim cn As String
        If RadioButton3.Checked = True Then
            gen = "F"
        Else
            gen = "H"
        End If
        If RadioButton1.Checked = True Then
            cn = "OUI"
        Else
            cn = "NON"
        End If
        If (TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox1.SelectedIndex = -1) Then
            MessageBox.Show("veuillez remplir tout les champs")
        End If
        If ComboBox1.SelectedIndex > -1 Then
            Dim index1 As Integer
            index1 = ComboBox1.SelectedIndex
            Dim item1 As Object
            item1 = ComboBox1.SelectedItem

            ListView1.Items.Add(New ListViewItem(New String() {TextBox1.Text, TextBox2.Text, gen, DateTimePicker1.Text, cn, TextBox3.Text, item1}))
            TextBox1.Clear()
            TextBox2.Clear()
        End If
        MsgBox("Patient ajouté avec succés")


    End Sub
    Sub sauvegard(ByVal Liste As ListView, ByVal fichier As String)
        Dim itemsplit As String = "#"
        Dim colonnesplit As String = ";"
        Dim build As New Text.StringBuilder()
        Dim nelement As Integer = Liste.Items.Count
        For Each element As ListViewItem In Liste.Items
            For i As Integer = 0 To Liste.Columns.Count - 1
                build.Append(element.SubItems(i).Text)
                If (i < Liste.Columns.Count - 1) Then
                    build.Append(colonnesplit)

                End If
            Next
            build.Append(itemsplit)
        Next
        Try
            IO.File.WriteAllText(fichier, build.ToString())
            MessageBox.Show("Sauvegardé avec succés")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Erreur")

        End Try

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MsgBox("veuillez choisir le fichier 'new1.txt'")
        Using sauve As New SaveFileDialog()
            sauve.Filter = "fichepatient|*.txt"
            If sauve.ShowDialog() = DialogResult.OK Then
                sauvegard(ListView1, sauve.FileName)

            End If
        End Using
        Form2.Show()
    End Sub

End Class