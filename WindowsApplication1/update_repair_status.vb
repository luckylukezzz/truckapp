Imports System.Data.OleDb

Public Class update_repair_status

    Dim mycon As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\luckyluke\Documents\forkliftmanage.accdb")

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        menus.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim truckNo As Integer

        ' Assuming TextBox1 contains the truck_no value to be updated
        If Integer.TryParse(TextBox1.Text, truckNo) Then
            Dim newrepair As String = TextBox2.Text

            ' Assuming TextBox2 contains the new location
            Dim query As String = "UPDATE vehicle SET repair_status = ? WHERE truck_no = ?"
            Dim mycmd As New OleDbCommand(query, mycon)

            Try
                mycmd.Parameters.AddWithValue("@repair_status", newrepair)
                mycmd.Parameters.AddWithValue("@truck_no", truckNo)

                ' Open the connection if it's not already open
                If mycon.State <> ConnectionState.Open Then
                    mycon.Open()
                End If

                Dim rowsAffected As Integer = mycmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    MsgBox("repairs updated successfully.")
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
End Class