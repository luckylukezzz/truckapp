Imports System.Data.OleDb

Public Class check_repair_status

    Dim mycon As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\luckyluke\Documents\forkliftmanage.accdb")

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        menus.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim truckNo As Integer

        ' Assuming TextBox1 contains the truck_no value to be queried
        If Integer.TryParse(TextBox1.Text, truckNo) Then
            Dim query As String = "SELECT repair_status FROM vehicle WHERE truck_no = ?"
            Dim mycmd As New OleDbCommand(query, mycon)

            Try
                mycmd.Parameters.AddWithValue("@truck_no", truckNo)

                ' Open the connection if it's not already open
                If mycon.State <> ConnectionState.Open Then
                    mycon.Open()
                End If

                Dim result As Object = mycmd.ExecuteScalar()

                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    MsgBox("Vehicle Repair status: " & result.ToString())
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
        TextBox1.Clear()
    End Sub
End Class