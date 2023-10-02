Imports System.Data.OleDb

Public Class register
    Dim mycon As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\luckyluke\Documents\forkliftmanage.accdb")
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            mycon.Open()
        Catch ex As Exception
            MsgBox("failed first")
        End Try
        Dim mycmd As New OleDbCommand("Insert into userzz(usernamezz,passwordzz) Values ('" & TextBox1.Text & "','" & TextBox2.Text & "')", mycon)
        Try
            mycmd.ExecuteNonQuery()
            mycon.Close()
            TextBox1.Clear()
            TextBox2.Clear()
            MsgBox("account success plz login")
        Catch ex As Exception
            MsgBox("failed bruh")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class
