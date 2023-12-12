Imports System.Security.Cryptography.X509Certificates

Public Class Form5
    Public Property st1 As String
    Public Property st2 As String

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If (RichTextBox1.Text = "") Then
            MsgBox("Veuillez remplir le champ")

        Else
            ListBox2.Items.Add(DateTimePicker1.Text)
            ListBox2.Items.Add(RichTextBox1.Text)
        End If
        MsgBox("Traitement ajouté avec succés")
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        str3.Text = st1
        str4.Text = st2
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub
End Class