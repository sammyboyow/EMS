Imports System.Data.SqlClient
Imports System.IO

Public Class Form4
    Dim w As Integer
    Private bitmap As Bitmap


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Are sure want to close?", vbYesNo + vbQuestion, "Confirm...") = MsgBoxResult.Yes Then

            Me.Close()

        End If

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        If txtid.Text = "" Then
            Form5.Show()

        End If

        Dim query As String = ("SELECT * FROM employee where empid = '" & txtid.Text & "'")
        Using con As SqlConnection = New SqlConnection("Data Source=192.175.10.40;Initial Catalog=HPCOMMON_TEST;Integrated Security=False;UID=sapdb;Pwd=sapdb")
            Using cmd As SqlCommand = New SqlCommand(query, con)
                Using da As New SqlDataAdapter()
                    da.SelectCommand = cmd
                    Using dt As New DataTable()
                        da.Fill(dt)
                        PictureBox3.BringToFront()
                        If dt.Rows.Count > 0 Then

                            txtFirstname.Text = dt.Rows(0)(1).ToString()
                            txtLastname.Text = dt.Rows(0)(2).ToString()
                            ComboBox3.Text = dt.Rows(0)(4).ToString()
                            DateTimePicker1.Value = dt.Rows(0)(5).ToString()
                            txtAge.Text = dt.Rows(0)(6).ToString()
                            txtAddress.Text = dt.Rows(0)(7).ToString()

                            Dim img() As Byte
                            img = dt.Rows(0)(11)
                            Dim ms As New MemoryStream(img)
                            PictureBox3.Image = System.Drawing.Image.FromStream(ms)



                        End If

                    End Using

                End Using

            End Using

        End Using

    End Sub



    Private Sub txtid_KeyDown(sender As Object, e As KeyEventArgs) Handles txtid.KeyDown

        If e.KeyCode = Keys.F9 Then
            Form5.Show()

        ElseIf e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()

            'If e.KeyCode = Keys.Enter Then
            'btnSearch.Focus()

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If MsgBox("Clear all Fields?", vbYesNo + vbQuestion, "Confirm...") = MsgBoxResult.Yes Then

            Label1.BringToFront()

            'clear all the record
            txtid.Text = ""
            txtFirstname.Text = ""
            txtLastname.Text = ""
            cmbDesig.Text = ""
            PictureBox3.Image = Nothing
            txtAge.Text = ""
            txtAddress.Text = ""
            ComboBox3.Text = ""
            cmbDesig.Text = ""
            cmbBenefits.Text = ""
            TextBox3.Text = "0.00"
            TextBox5.Text = "0.00"
            TextBox7.Text = "0.00"
            cmBasic.Text = "0.00"

        End If


    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If cmbDesig.Text = "" Then

            ErrorProvider1.SetError(cmbDesig, "Please enter the text do not leave blank")

        Else

            ErrorProvider1.SetError(cmbDesig, "")

            cmbDesig.Focus()

        End If

        Dim sal As Double
        Dim hou As Double
        Dim con As Double
        Dim med As Double
        Dim tran As Double
        Dim util As Double
        Dim bonus As Double
        Dim gross As Double
        Dim net As Double
        Dim tax As Double

        If txtAddress.Text = "" Then

            MessageBox.Show("Please Enter Employee details",
                                    "User Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtid.Focus()
            Exit Sub

        End If

        sal = Convert.ToDecimal(cmBasic.Text)
        If CheckBox1.Checked = True Then
            hou = (35 / 100) * sal


        End If

        If CheckBox2.Checked = True Then
            con = (8.5 / 100) * sal

        End If

        If CheckBox3.Checked = True Then
            tran = (9 / 100) * sal

        End If

        If CheckBox4.Checked = True Then
            med = (7 / 100) * sal

        End If

        If CheckBox6.Checked = True Then
            util = (12 / 100) * sal


        End If

        If CheckBox5.Checked Then

            If cmbBenefits.Text = " New Year Bonus" Then

                bonus = 3500

            End If

            If cmbBenefits.Text = "Overtime Bonus" Then

                bonus = (2 / 100) * sal


            End If

            If cmbBenefits.Text = "  Weekend Bonus" Then

                bonus = 6500

            End If
        End If

        gross = bonus + hou + med + tran + con + util + sal
        tax = (15 / 100) * sal
        net = gross - tax

        TextBox3.Text = Convert.ToDouble(gross)
        TextBox5.Text = Convert.ToDouble(net)
        TextBox7.Text = Convert.ToDouble(tax)


    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Start()

    End Sub


    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim panel As New Panel()
        Me.Controls.Add(panel)

        'Create a Bitmap of size same as that of the Form.
        Dim grp As Graphics = panel.CreateGraphics()
        Dim formSize As Size = Me.ClientSize
        Bitmap = New Bitmap(formSize.Width, formSize.Height, grp)
        grp = Graphics.FromImage(Bitmap)

        'Copy screen area that that the Panel covers.
        Dim panelLocation As Point = PointToScreen(panel.Location)
        grp.CopyFromScreen(panelLocation.X, panelLocation.Y, 0, 0, formSize)

        'Show the Print Preview Dialog.
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
        PrintPreviewDialog1.ShowDialog()

    End Sub


    Private Sub PrintPage(sender As Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        'Print the contents.
        e.Graphics.DrawImage(Bitmap, 0, 0)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Select Case Label2.Text
            Case ""
                Label2.Text = "P"
            Case "P"
                Label2.Text = "PA"
            Case "PA"
                Label2.Text = "PAY"
            Case "PAY"
                Label2.Text = "PAYR"
            Case "PAYR"
                Label2.Text = "PAYRO"
            Case "PAYRO"
                Label2.Text = "PAYROL"
            Case "PAYROL"
                Label2.Text = "PAYROLL"
            Case "PAYROLL"
                Label2.Text = "PAYROLL "
            Case "PAYROLL "
                Label2.Text = "PAYROLL E"
            Case "PAYROLL E"
                Label2.Text = "PAYROLL EM"
            Case "PAYROLL EM"
                Label2.Text = "PAYROLL EMP"
            Case "PAYROLL EMP"

        End Select
    End Sub

End Class
