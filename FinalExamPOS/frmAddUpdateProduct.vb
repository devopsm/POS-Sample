Imports MySql.Data.MySqlClient
Public Class frmAddUpdateProduct
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            connect.Open()
            With comm
                .CommandType = CommandType.StoredProcedure
                .CommandText = "InsertUpdateProduct"
                .Parameters.Clear()
                .Parameters.Add("productid_", MySqlDbType.Int16).Value = Val(txtProductid.Text)
                .Parameters.Add("product_", MySqlDbType.Text).Value = txtProductname.Text
                .Parameters.Add("price_", MySqlDbType.Double).Value = Val(txtPrice.Text)
                .Parameters.Add("quantity_", MySqlDbType.Int16).Value = Val(txtQty.Text)
                .ExecuteNonQuery()
            End With
            If (txtProductId.Text = "") Then
                MsgBox("Data successfully save!")
                With frmLoadProduct
                    .productList()
                End With
            Else
                MsgBox("Data Updated")
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