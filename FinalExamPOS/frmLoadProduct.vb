Public Class frmLoadProduct
    Dim ds As New DataSet
    Dim dt As New DataTable
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        With frmAddUpdateProduct
            .ShowDialog()
        End With
    End Sub
    Public Sub productList()
        Try

            With mda.SelectCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = "productList"
                .Parameters.Clear()
                ds.Clear()
                dt.Clear()
                mda.Fill(dt)
                DataGridView1.DataSource = dt
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmLoadProduct_Load(sender As Object, e As EventArgs) Handles Me.Load
        productList()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class