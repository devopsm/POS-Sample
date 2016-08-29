Imports MySql.Data.MySqlClient
Public Class frmOrder

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        totalpay()
    End Sub
    Private Sub DataGridView1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded

        totalpay()
    End Sub


    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        frmPayment.ShowDialog()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        frmProductList2.ShowDialog()
    End Sub
    Public Sub totalpay()
        Dim a As System.Double
        For i = 0 To DataGridView1.Rows.Count - 1
            a = a + DataGridView1.Item(4, i).Value
        Next
        txttotal.Text = a
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        ' qty1()

        Try

            connect.Open()


            With comm
                For Each row As DataGridViewRow In DataGridView1.Rows
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "InsertOrder"
                    .Parameters.Clear()
                    .Parameters.Add("OrderID_", MySqlDbType.Int16).Value = Val(txtOrderid.Text)
                    .Parameters.Add("Invoice_", MySqlDbType.Text).Value = txtInvoice.Text
                    .Parameters.Add("ProdID_", MySqlDbType.Int16).Value = Val(row.Cells(0).Value)
                    .Parameters.Add("Quantity_", MySqlDbType.Int16).Value = Val(row.Cells(3).Value)
                    .Parameters.Add("Price_", MySqlDbType.Decimal).Value = Val(row.Cells(2).Value)
                    .Parameters.Add("CusID_", MySqlDbType.Int16).Value = cbCustomer.SelectedValue
                    .Parameters.Add("OrderDate_", MySqlDbType.Text).Value = DateTimePicker1.Value.ToString("yyyy/MM/dd")
                    .ExecuteNonQuery()
                Next
            End With


            If (txtOrderid.Text = "") Then
                MsgBox("Data successfully save!")
                DataGridView1.Rows.Clear()
                txttotal.Text = ""
                txtChange.Text = ""
                'With frmLoadCustomer

                '    .CustomerList()
                'End With
                'Me.Close()
            Else
                MsgBox("Data Updated")
                'With frmLoadCustomer
                '    .CustomerList()
                'End With
                'Me.Close()

            End If


            '  loadlist()
            'clear()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            connect.Close()
        End Try
    End Sub
    Private Sub retrieve()
        Try
            connect.Open()
            With comm
                .CommandType = CommandType.StoredProcedure
                .CommandText = "c"
                .Parameters.Clear()

            End With
            Dim ds1 As New DataSet
            With cbCustomer
                mda.SelectCommand = comm
                mda.Fill(ds1)
                .DataSource = ds1.Tables(0)
                .DisplayMember = "Lname"
                .ValueMember = "CustomerID"
            End With
        Catch ex As Exception
        Finally
            connect.Close()
        End Try
    End Sub




    Private Sub frmOrder_Load(sender As Object, e As EventArgs) Handles Me.Load
        retrieve()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        With DataGridView1
            .Rows.Clear()
        End With
        txttotal.Text = ""
        txtChange.Text = ""
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Close()
    End Sub
End Class