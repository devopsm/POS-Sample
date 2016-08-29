Public Class frmPayment
    Private Sub btnPayment_Click(sender As Object, e As EventArgs) Handles btnPayment.Click

        ' payment()

        If Val(frmOrder.txttotal.Text) > Val(txtCash.Text) Then
            MsgBox("Insuficient cash to paid the total amount", MsgBoxStyle.Exclamation, "payment")
            txtCash.Focus()
        Else

            With frmOrder
                .txttotal.Text = ""
            End With

            Me.Close()
        End If
        '  Me.Close()

    End Sub
    Private Sub payment()
        txtCash.Text = "0"
        Dim total As New Double

        total = Val(frmOrder.txttotal.Text) - txtCash.Text

        frmOrder.txtChange.Text = total

    End Sub

    Private Sub txtCash_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCash.KeyPress
        'If e.KeyChar = ControlChars.Cr Then
        '    If Val(frmOrder.txttotal.Text) < Val(txtCash.Text) Then
        '        MsgBox("Insuficient cash to paid the total amount", MsgBoxStyle.Exclamation, "payment")
        '        txtCash.Focus()
        '    End If
        'End If


    End Sub

    Private Sub txtCash_TextChanged(sender As Object, e As EventArgs) Handles txtCash.TextChanged
        'txtCash.Text = "0"

        Dim total As New Double

        total = Val(txtCash.Text) - Val(frmOrder.txttotal.Text)

        frmOrder.txtChange.Text = total


    End Sub

    Private Sub frmPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCash.Text = ""
    End Sub
End Class