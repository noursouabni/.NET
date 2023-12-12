Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form6
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label1.Text = TextBox1.Text
        Label2.Text = TextBox2.Text
        Label3.Text = DateTimePicker1.Text
        If (TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "") Then
            MsgBox("Veuillez remplir tout les champs")
        End If
        If CheckBox1.Checked Then
            ListBox1.Items.Add("Antibiotiques")
        End If
        If CheckBox3.Checked Then
            ListBox1.Items.Add("Anésthésiques")
        End If
        If CheckBox4.Checked Then
            ListBox1.Items.Add("Anxioletiques")
        End If
        If CheckBox5.Checked Then
            ListBox1.Items.Add(TextBox3.Text)
        End If
        If (TextBox1.Text <> "" Or TextBox2.Text <> "" Or TextBox3.Text <> "") Then
            MsgBox("L'ordonnance est prête pour l'impression.")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class