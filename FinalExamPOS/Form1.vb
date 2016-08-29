Public Class frmMain
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ssDate.Text = Date.Now.ToString("MM/dd/yyyy")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ssTime.Text = Date.Now.ToString("hh:mm:ss")
    End Sub

    Private Sub CalculatorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculatorToolStripMenuItem.Click
        Shell("Calc.exe")
    End Sub

    Private Sub ProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductToolStripMenuItem.Click
        For Each product As Form In Me.MdiChildren
            If TypeOf product Is frmLoadProduct Then
                product.Focus()
                Return
            End If
        Next
        With frmLoadProduct
                .MdiParent = Me
                .Dock = DockStyle.Fill
            .Show()
        End With

    End Sub

    Private Sub CustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerToolStripMenuItem.Click
        For Each customer As Form In Me.MdiChildren
            If TypeOf customer Is frmLoadCustomer Then
                customer.Focus()
                Return
            End If
        Next
        With frmLoadCustomer
            .MdiParent = Me
            .Dock = DockStyle.Fill
            .Show()
        End With
    End Sub

    Private Sub POSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles POSToolStripMenuItem.Click
        For Each order As Form In Me.MdiChildren
            If TypeOf order Is frmOrder Then
                order.Focus()
                Return
            End If
        Next
        With frmOrder
            .MdiParent = Me
            .Dock = DockStyle.Fill
            .Show()
        End With
    End Sub

    Private Sub MonthlyReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MonthlyReportToolStripMenuItem.Click
        frmReport.ShowDialog()
    End Sub
End Class
