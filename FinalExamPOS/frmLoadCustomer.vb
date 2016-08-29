Public Class frmLoadCustomer
    Dim ds1 As New DataSet
    Dim dt1 As New DataTable
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        frmcustomertext()
        frmAddCustomer.ShowDialog()
    End Sub
    Public Sub CustomerList()
        Try

            With mda.SelectCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = "customerList"
                .Parameters.Clear()
                ds1.Clear()
                dt1.Clear()
                mda.Fill(dt1)
                DataGridView1.DataSource = dt1
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmLoadCustomer_Load(sender As Object, e As EventArgs) Handles Me.Load
        CustomerList()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        'Dim i As String = "Ok"
        'i = MsgBox("Do you want to Update Record", MessageBoxButtons.OKCancel).ToString()

        'If (i = "Ok") Then
        '    Dim cell0 As Object = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        '    Dim cell1 As Object = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        '    Dim cell2 As Object = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        '    Dim cell3 As Object = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        '    Dim cell4 As Object = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        '    With frmAddCustomer
        '        .txtCustomerid.Text = Convert.ToString(cell0)
        '        .txtLname.Text = cell1
        '        .txtFname.Text = cell2
        '        .txtContact.Text = cell3
        '        .txtAddress.Text = cell4
        '        .ShowDialog()
        '    End With
        'End If

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim i As String = "Ok"
        i = MsgBox("Do you want to Update Record", MessageBoxButtons.OKCancel).ToString()

        If (i = "Ok") Then
            With DataGridView1
                If (.Rows(.CurrentRow.Index).Cells(0).Selected Or .Rows(.CurrentRow.Index).Cells(1).Selected Or .Rows(.CurrentRow.Index).Cells(2).Selected Or .Rows(.CurrentRow.Index).Cells(3).Selected Or .Rows(.CurrentRow.Index).Cells(4).Selected = True) Then
                    Dim cell0 As Object = .Rows(.CurrentRow.Index).Cells(0).Value
                    Dim cell1 As Object = .Rows(.CurrentRow.Index).Cells(1).Value
                    Dim cell2 As Object = .Rows(.CurrentRow.Index).Cells(2).Value
                    Dim cell3 As Object = .Rows(.CurrentRow.Index).Cells(3).Value
                    Dim cell4 As Object = .Rows(.CurrentRow.Index).Cells(4).Value

                    With frmAddCustomer
                        .txtCustomerid.Enabled = False
                        .txtCustomerid.Text = Convert.ToString(cell0)
                        .txtLname.Text = cell1
                        .txtFname.Text = cell2
                        .txtContact.Text = cell3
                        .txtAddress.Text = cell4
                        .ShowDialog()
                    End With
                Else
                    MsgBox("Select cell to update Record")
                End If
            End With

        End If
    End Sub
    Private Sub frmcustomertext()
        With frmAddCustomer
            .txtCustomerid.Clear()
            .txtLname.Clear()
            .txtFname.Clear()
            .txtContact.Clear()
            .txtAddress.Clear()
        End With
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class











