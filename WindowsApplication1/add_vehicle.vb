Imports System.Data.OleDb

Public Class add_vehicle
    Dim mycon As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\luckyluke\Documents\forkliftmanage.accdb")

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        menus.Show()
        Me.Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub add_vehicle_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
       
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text Then
            Try
                mycon.Open()
            Catch ex As Exception
                MsgBox("failed first")
            End Try
            Dim query As String = "INSERT INTO vehicle (truck_no, truck_name, build_year, location, repair_status) VALUES (?, ?, ?, ?, ?)"
            Dim mycmd As New OleDbCommand(query, mycon)

            Try
                mycmd.Parameters.AddWithValue("@truck_no", Convert.ToInt32(TextBox1.Text))
                mycmd.Parameters.AddWithValue("@truck_name", TextBox2.Text)
                mycmd.Parameters.AddWithValue("@build_year", Convert.ToInt32(TextBox3.Text))
                mycmd.Parameters.AddWithValue("@location", TextBox4.Text)
                mycmd.Parameters.AddWithValue("@repair_status", TextBox5.Text)

                mycmd.ExecuteNonQuery()
                mycon.Close()
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                MsgBox("Record inserted successfully.")

            Catch ex As Exception
                MsgBox("Exception: " & ex.Message)
            End Try
        Else
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            MsgBox("Numberplate must have a value")
        End If
    End Sub


End Class