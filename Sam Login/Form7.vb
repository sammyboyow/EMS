Imports System.Data.SqlClient
Imports System.IO


Public Class Form7

    Dim maroon, blue, yellow, white As String


    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Timer1.Start()
        Timer1.Interval = 400

    End Sub


    Private Sub btnload_Click(sender As Object, e As EventArgs) Handles btnload.Click

        BlinData()

    End Sub

    Public Sub BlinData()

        Dim query As String = "select * from employee"
        Using con As SqlConnection = New SqlConnection("Data Source=192.175.10.40;Initial Catalog=HPCOMMON_TEST;Integrated Security=False;UID=sapdb;Pwd=sapdb")
            Using cmd As SqlCommand = New SqlCommand(query, con)
                Using da As New SqlDataAdapter()
                    da.SelectCommand = cmd
                    Using dt As New DataTable()
                        dt.Clear()
                        da.Fill(dt)
                        DataGridView1.DataSource = dt
                        DataGridView1.EnableHeadersVisualStyles = False

                        DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

                        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue

                        DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

                        DataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.LightGray

                        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8)

                        DataGridView1.Columns(3).Visible = False
                        DataGridView1.Columns(4).Visible = False
                        DataGridView1.Columns(5).Visible = False
                        DataGridView1.Columns(6).Visible = False
                        DataGridView1.Columns(7).Visible = False
                        DataGridView1.Columns(8).Visible = False
                        DataGridView1.Columns(9).Visible = False
                        DataGridView1.Columns(10).Visible = False
                        DataGridView1.Columns(11).Visible = False


                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Are you sure want to Close?", vbYesNo + vbQuestion, "Confirm...") = MsgBoxResult.Yes Then
            Me.Close()

        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Panel1.BackColor = Color.White

    End Sub

    Private Sub btnselect_Click(sender As Object, e As EventArgs) Handles btnselect.Click

        Dim query As String = ("SELECT * FROM employee where empid = '" & txtId.Text & "'")
        Using con As SqlConnection = New SqlConnection("Data Source=192.175.10.40;Initial Catalog=HPCOMMON_TEST;Integrated Security=False;UID=sapdb;Pwd=sapdb")
            Using cmd As SqlCommand = New SqlCommand(query, con)
                Using da As New SqlDataAdapter()
                    da.SelectCommand = cmd
                    Using dt As New DataTable()
                        da.Fill(dt)
                        If dt.Rows.Count > 0 Then


                            txtId.Text = dt.Rows(0)(0).ToString()
                            txtFirstName.Text = dt.Rows(0)(1).ToString()
                            lblfirstname.Text = dt.Rows(0)(1).ToString()
                            txtLastName.Text = dt.Rows(0)(2).ToString()
                            lblLastname.Text = dt.Rows(0)(2).ToString()
                            txtContact.Text = dt.Rows(0)(3).ToString()
                            ComboBox1.Text = dt.Rows(0)(4).ToString()
                            DateTimePicker1.Value = dt.Rows(0)(5).ToString()
                            txtAge.Text = dt.Rows(0)(6).ToString()
                            txtAddress.Text = dt.Rows(0)(7).ToString()
                            txtEmail.Text = dt.Rows(0)(10).ToString()


                            Dim img() As Byte
                            img = dt.Rows(0)(11)
                            Dim ms As New MemoryStream(img)
                            PictureBox1.Image = System.Drawing.Image.FromStream(ms)


                        End If

                    End Using
                End Using
            End Using
        End Using

        txtFirstName.Enabled = False
        txtLastName.Enabled = False
        txtAge.Enabled = False
        txtAddress.Enabled = False
        txtContact.Enabled = False
        txtEmail.Enabled = False
        ComboBox1.Enabled = False
        DateTimePicker1.Enabled = False

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If MsgBox("Clear all Fields?", vbYesNo + vbQuestion, "Confirm...") = MsgBoxResult.Yes Then

            txtId.Text = ""
            txtFirstName.Text = ""
            txtLastName.Text = ""
            txtContact.Text = ""
            ComboBox1.Text = ""
            PictureBox1.Image = Nothing
            txtAge.Text = ""
            txtAddress.Text = ""
            txtEmail.Text = ""
            lblfirstname.Text = ""
            lblLastname.Text = ""
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""

            txtFirstName.Enabled = False
            txtLastName.Enabled = False
            txtAge.Enabled = False
            txtAddress.Enabled = False
            txtContact.Enabled = False
            txtEmail.Enabled = False
            ComboBox1.Enabled = False
            DateTimePicker1.Enabled = False

        End If

    End Sub

    Private Sub txtId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtId.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnselect.PerformClick()

        End If


    End Sub

    Private Sub btnEducational_Click_1(sender As Object, e As EventArgs) Handles btnEducational.Click

        'display the educational panel

        Panel1.BringToFront()

        btnEducational.BackColor = Color.FromArgb(34, 167, 240)
        btnEducational.ForeColor = Color.White
        Panel_educational.BackColor = Color.Red

        btnPersonal.BackColor = Color.White
        btnPersonal.ForeColor = Color.Black
        Panel_personal.BackColor = Color.FromArgb(34, 167, 240)

    End Sub


    Private Sub btnPersonal_Click(sender As Object, e As EventArgs) Handles btnPersonal.Click
        'display the personal info panel

        Panel2.BringToFront()

        btnPersonal.BackColor = Color.FromArgb(34, 167, 240)
        btnPersonal.ForeColor = Color.White
        Panel_personal.BackColor = Color.Red

        btnEducational.BackColor = Color.White
        btnEducational.ForeColor = Color.Black
        Panel_educational.BackColor = Color.FromArgb(34, 167, 240)


    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        ControlPaint.DrawBorder(e.Graphics, Panel1.ClientRectangle, Color.Gray, ButtonBorderStyle.Solid)
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

        ControlPaint.DrawBorder(e.Graphics, Panel1.ClientRectangle, Color.Gray, ButtonBorderStyle.Solid)

    End Sub

    Private Sub Panel_personal_Paint(sender As Object, e As PaintEventArgs) Handles Panel_personal.Paint
        ControlPaint.DrawBorder(e.Graphics, Panel1.ClientRectangle, Color.Black, ButtonBorderStyle.Solid)
    End Sub

    Private Sub Panel_educational_Paint(sender As Object, e As PaintEventArgs) Handles Panel_educational.Paint
        ControlPaint.DrawBorder(e.Graphics, Panel1.ClientRectangle, Color.Black, ButtonBorderStyle.Solid)
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs)
        Label9.BringToFront()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        maroon = Int(Rnd() * 255)
        blue = Int(Rnd() * 255)
        yellow = Int(Rnd() * 255)
        white = Int(Rnd() * 255)

        Label9.ForeColor = Color.FromArgb(maroon, blue, yellow, white)


    End Sub

End Class