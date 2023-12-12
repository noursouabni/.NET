Imports System.IO

Public Class Form2


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Using sauve As New SaveFileDialog()
            sauve.Filter = "fichepatient|*.txt"
            If sauve.ShowDialog() = DialogResult.OK Then
                sauvegard(ListView1, sauve.FileName)

            End If
        End Using
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
    Sub recharger(ByVal Liste As ListView, ByVal fichier As String)
        Liste.Items.Clear()
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
                        Liste.Items.Add(nouveauelement)

                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "erreur")

        End Try
    End Sub

    Sub recharger1(ByVal Liste As ListView, ByVal fichier As String)
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
                        Liste.Items.Add(nouveauelement)

                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "erreur")

        End Try
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Using ouvrir As New OpenFileDialog
            ouvrir.Filter = "fichepatient|* .txt"
            If ouvrir.ShowDialog() = DialogResult.OK Then
                recharger(ListView1, ouvrir.FileName)

            End If
        End Using
    End Sub
    Dim r1 As IO.StreamReader
    Dim r
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MsgBox("veuillez choisir le fichier 'new1.txt'")
        Using ouvrir As New OpenFileDialog
            ouvrir.Filter = "new1|* .txt"
            If ouvrir.ShowDialog() = DialogResult.OK Then
                recharger1(ListView1, ouvrir.FileName)

            End If
        End Using
        MsgBox("Nouveau patient affiché avec succés")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ListView1.BackColor = Color.LightBlue
        For i As Integer = 0 To ListView1.Items.Count - 1

            If i Mod 2 = 0 Then
                ListView1.Items(i).BackColor = Color.Violet
            Else
                ListView1.Items(i).BackColor = Color.LightBlue

            End If
        Next
    End Sub
End Class