Imports System.Data.OleDb

Public Class Form1
    Dim mycon As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\luckyluke\Documents\forkliftmanage.accdb")

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        register.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mycon.Open()
        Dim query As String = "SELECT * FROM userzz WHERE usernamezz = ? AND passwordzz = ?"
        Dim mycmd As New OleDbCommand(query, mycon)

        Try
            mycmd.Parameters.AddWithValue("@username", TextBox1.Text)
            mycmd.Parameters.AddWithValue("@password", TextBox2.Text)

            Dim myread As OleDbDataReader = mycmd.ExecuteReader()

            If myread.Read() Then
                MsgBox("Success")
                menus.Show()
                Me.Close()
            Else
                MsgBox("Failed. Check username and password.")
            End If
        Catch ex As Exception
            MsgBox("Exception: " & ex.Message)
        End Try
        mycon.Close()
    End Sub


    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class