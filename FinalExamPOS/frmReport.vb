Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class frmReport
    Dim rds As ReportDataSource
    Dim rpt As New rptDataSet
    Private Sub frmReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Try
            Me.ReportViewer1.Reset()
            mda = New MySqlDataAdapter("", connect)

            With mda.SelectCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = "monthlyReport"
                .Parameters.Clear()
                .Parameters.Add("txtdate", MySqlDbType.Text).Value = DateTimePicker1.Value.ToString("yyyy/MM/dd")
                .Parameters.Add("txtdate1", MySqlDbType.Text).Value = DateTimePicker2.Value.ToString("yyyy/MM/dd")
            End With
            rpt.rptProduct.Reset()
            mda.Fill(rpt.rptProduct)

            rds = New ReportDataSource("rptDataSet", rpt.Tables("rptProduct"))

            With Me.ReportViewer1
                Cursor = Cursors.WaitCursor
                .LocalReport.ReportEmbeddedResource = "FinalExamPOS.productReport.rdlc"
                .LocalReport.DataSources.Clear()
                .LocalReport.DataSources.Add(rds)
                .SetDisplayMode(DisplayMode.PrintLayout)
                .ZoomPercent = 90
            End With
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub DataTable1BindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles DataTable1BindingSource.CurrentChanged

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub txtReport_TextChanged(sender As Object, e As EventArgs)

    End Sub


End Class