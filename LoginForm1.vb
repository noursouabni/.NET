Imports System.IO

Public Class LoginForm1

    ' TODO: insérez le code pour effectuer une authentification personnalisée à l'aide du nom d'utilisateur et du mot de passe fournis 
    ' (Consultez https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' L'objet Principal personnalisé peut ensuite être associé à l'objet Principal du thread actuel comme suit : 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' CustomPrincipal est l'implémentation IPrincipal utilisée pour effectuer l'authentification. 
    ' Par la suite, My.User retournera les informations d'identité encapsulées dans l'objet CustomPrincipal
    ' telles que le nom d'utilisateur, le nom complet, etc.



    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If (TextBox2.Text = "" Or TextBox1.Text = "") Then
            MsgBox("Veuillez remplir les champs requis")
        Else
            Dim obj As New Form5
            obj.st1 = TextBox1.Text
            obj.st2 = TextBox2.Text
            obj.Show()
        End If

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fs As New FileStream("fichepatient.txt", FileMode.Open, FileAccess.Read)
        Dim sr As New StreamReader(fs)
        Dim ch As String = TextBox1.Text & TextBox2.Text
        Dim c, c1, nouv As String
        Dim i, t As Integer
        Dim trouve As Integer = 0
        Dim x(100) As String
        While sr.Peek > -1 And t = 0
                i = 0
                c = sr.ReadLine
                c1 = ""
                While (c.Substring(i, 1) <> ";")
                    c1 = c1.Insert(Len(c1), c.Substring(i, 1))
                    i = i + 1
                End While
                If (TextBox1.Text.ToLower.CompareTo(c1.ToLower) = 0) Then
                    trouve = 1
                End If
            End While
            If trouve = 0 Then
                MsgBox("Ce patient n'existe pas.")
            Else
                MsgBox("Bienvenue!")

            End If
    End Sub


End Class
