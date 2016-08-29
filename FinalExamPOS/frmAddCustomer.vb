Imports MySql.Data.MySqlClient
Public Class frmAddCustomer
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            connect.Open()
            With comm
                .CommandType = CommandType.StoredProcedure
                .CommandText = "InsertCustomer"
                .Parameters.Clear()
                .Parameters.Add("customerid_", MySqlDbType.Int16).Value = Val(txtCustomerid.Text)
                .Parameters.Add("lname_", MySqlDbType.Text).Value = txtLname.Text
                .Parameters.Add("fname_", MySqlDbType.Text).Value = txtFname.Text
                .Parameters.Add("contact_", MySqlDbType.Text).Value = txtContact.Text
                .Parameters.Add("address_", MySqlDbType.Text).Value = txtAddress.Text
                .ExecuteNonQuery()
            End With
            If (txtCustomerid.Text = "") Then
                MsgBox("Data successfully save!")
                With frmLoadCustomer
                    .CustomerList()
                End With
                Me.Close()
            Else
                MsgBox("Data Updated")
                With frmLoadCustomer
                    .CustomerList()
                End With
                Me.Close()
            End If
            '  loadlist()
            'clear()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            connect.Close()
        End Try
    End Sub
End Class