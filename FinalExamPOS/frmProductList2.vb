Imports MySql.Data.MySqlClient
Public Class frmProductList2
    Dim ds1 As New DataSet
    Dim dt As New DataTable
    Private Sub frmProductList2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        productList()
    End Sub

    Private Sub productList()
        Try

            With mda.SelectCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = "productList"
                .Parameters.Clear()
                dt.Clear()
                ds1.Clear()
                mda.Fill(dt)
                DataGridView1.DataSource = dt
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'txtQuantity.Text = "0"
        'Dim s As New Integer

        txtProductID.Text = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value
        txtProductName.Text = DataGridView1.Item(1, DataGridView1.CurrentRow.Index).Value
        txtPrice.Text = DataGridView1.Item(2, DataGridView1.CurrentRow.Index).Value
        txtQtyy.Text = DataGridView1.Item(3, DataGridView1.CurrentRow.Index).Value

        's = DataGridView1.Item(3, DataGridView1.CurrentRow.Index).Value

        'txtQuantity.Text = Val(txtQuantity.Text) - Val(s)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub btnAddProduct_Click(sender As Object, e As EventArgs) Handles btnAddProduct.Click
        If txtProductID.Text <> "" And txtProductName.Text <> "" And txtPrice.Text <> "" And Val(txtQuantity.Text) <= Val(txtQtyy.Text) Then


            With frmOrder.DataGridView1


                Dim ii As Integer
                Dim orderproduct As Integer = 0
                Dim count As Integer = 0

                For ii = 0 To .RowCount - 1
                    If txtProductID.Text = .Item(0, ii).Value Then
                        count = count + 1
                        If count <> 0 Then
                            orderproduct = .Item(3, ii).Value + Val(txtQuantity.Text)

                            .Item(3, ii).Value = orderproduct
                            .Item(4, ii).Value = .Item(2, ii).Value * .Item(3, ii).Value

                        Else

                        End If
                    End If

                Next ii



                If count = 0 Then

                    Dim sum As Single = Val(txtPrice.Text) * Val(txtQuantity.Text)
                    .Rows.Add(txtProductID.Text, txtProductName.Text, txtPrice.Text, txtQuantity.Text, sum)
                    count = 0

                    With frmOrder
                        .txtChange.Text = ""
                    End With
                End If

            End With


            txtProductID.Text = ""
            txtProductName.Text = ""
            txtPrice.Text = ""
            txtQuantity.Text = ""

        Else
            MsgBox(DataGridView1.CurrentRow.Cells(1).Value & " Out of Stock")
        End If


    End Sub

    Private Sub txtQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtQuantity.TextChanged
        totalpay()
    End Sub
    Public Sub d()
        Dim dif As Integer = Val(DataGridView1.CurrentRow.Cells(3).Value) - Val(txtQuantity.Text)
    End Sub

    Public Sub totalpay()
        Dim s As Boolean = False
        Dim t As Integer = 0
        Dim v As Integer = 0

        If txtQuantity.Text <> "" Then
            t = Val(txtQtyy.Text) - (txtQuantity.Text)
            DataGridView1.CurrentRow.Cells(3).Value = t
        Else
            v = 0 + Val(txtQtyy.Text)
            DataGridView1.CurrentRow.Cells(3).Value = v
        End If

    End Sub

    Private Sub DataGridView1_TextChanged(sender As Object, e As EventArgs) Handles DataGridView1.TextChanged
        totalpay()
    End Sub
End Class