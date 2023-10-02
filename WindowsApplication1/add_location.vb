Imports System.Data.OleDb

Public Class add_location
    Dim mycon As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\luckyluke\Documents\forkliftmanage.accdb")

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        menus.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim truckNo As Integer

        ' Assuming TextBox1 contains the truck_no value to be updated
        If Integer.TryParse(TextBox1.Text, truckNo) Then
            Dim newLocation As String = TextBox2.Text

            ' Assuming TextBox2 contains the new location
            Dim query As String = "UPDATE vehicle SET location = ? WHERE truck_no = ?"
            Dim mycmd As New OleDbCommand(query, mycon)

            Try
                mycmd.Parameters.AddWithValue("@new_location", newLocation)
                mycmd.Parameters.AddWithValue("@truck_no", truckNo)

                ' Open the connection if it's not already open
                If mycon.State <> ConnectionState.Open Then
                    mycon.Open()
                End If

                Dim rowsAffected As Integer = mycmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    MsgBox("Location updated successfully.")
                Else
                    MsgBox("No record found for the given truck_no.")
                End If

            Catch ex As Exception
                MsgBox("Exception: " & ex.Message)
            Finally
                ' Close the connection when done
                If mycon.State = ConnectionState.Open Then
                    mycon.Close()
                End If
            End Try
        Else
            MsgBox("Please enter a valid truck_no.")
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class