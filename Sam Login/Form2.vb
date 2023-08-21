
Imports System.Data.SqlClient
Imports System.IO

Public Class Form2

    Private bitmap As Bitmap
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtposition.BackColor = Color.FromArgb(100, 30, 139, 195)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles txtposition.Paint

        ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.Black, ButtonBorderStyle.Solid)

    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click

        ' Dim empid As Integer = txtid.Text
        Dim Firstname As String = txtFirstName.Text
        Dim Lastname As String = txtLastName.Text
        Dim Contact As String = txtContact.Text
        Dim Gender As String = ComboBox1.SelectedItem
        Dim Birthdate As Date = DateTimePicker1.Value
        Dim Age As String = txtAge.Text
        Dim Address As String = txtAddress.Text
        Dim Citizenship As String = txtCitinzen.Text
        Dim ZIP_Code As String = txtZipcode.Text
        Dim Email_Address As String = txtEmail.Text
        Dim Position As String = txtposition.Text
        Dim DAteHired As String = DateTimePicker2.Text

        If txtEmail.Text = "" Then
            MessageBox.Show("Text cannot be empty, fill in before proceeding",
                                    "User Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtFirstName.Focus()
            Exit Sub

        End If
        If MsgBox("Are you sure want to save?", vbYesNo + vbQuestion, "Confirm...") = MsgBoxResult.Yes Then

            PictureBox1.BringToFront()

            Dim query As String = "INSERT INTO employee VALUES(@Firstname,@Lastname,@Contact,@Gender, @Birthdate, @Age, @Address,@Citizenship, @ZIP_Code, @Email_Address, @Photos,@Position, @DateHired)"
            Using con As SqlConnection = New SqlConnection("Data Source=192.175.10.40;Initial Catalog=HPCOMMON_TEST;Integrated Security=False;UID=sapdb;Pwd=sapdb")
                Using cmd As SqlCommand = New SqlCommand(query, con)
                    Using ms As New MemoryStream
                        PictureBox3.Image.Save(ms, PictureBox3.Image.RawFormat)

                        'cmd.Parameters.AddWithValue("@empid", empid)
                        cmd.Parameters.AddWithValue("@Firstname", Firstname)
                        cmd.Parameters.AddWithValue("@Lastname", Lastname)
                        cmd.Parameters.AddWithValue("@Contact", Contact)
                        cmd.Parameters.AddWithValue("@Gender", Gender)
                        cmd.Parameters.AddWithValue("@Birthdate", Birthdate)
                        cmd.Parameters.AddWithValue("@Age", Age)
                        cmd.Parameters.AddWithValue("@Address", Address)
                        cmd.Parameters.AddWithValue("@Citizenship", Citizenship)
                        cmd.Parameters.AddWithValue("@Zip_Code", ZIP_Code)
                        cmd.Parameters.AddWithValue("@Email_Address", Email_Address)
                        cmd.Parameters.AddWithValue("@Position", Position)
                        cmd.Parameters.AddWithValue("@Datehired", DAteHired)
                        cmd.Parameters.Add("@Photos", SqlDbType.Image).Value = ms.ToArray()

                        con.Open()

                        cmd.ExecuteNonQuery()
                        con.Close()

                        txtid.Text = ""
                        txtFirstName.Text = ""
                        txtLastName.Text = ""
                        txtContact.Text = ""
                        ComboBox1.Text = ""
                        PictureBox3.Image = Nothing
                        TextBox2.Text = ""
                        txtAge.Text = ""
                        txtAddress.Text = ""
                        txtCitinzen.Text = ""
                        txtZipcode.Text = ""
                        txtEmail.Text = ""
                        txtposition.Text = ""

                        MessageBox.Show("Insert successfully!", "Thank you", MessageBoxButtons.OK)

                        BlinData()

                    End Using
                End Using
            End Using
        End If

        'MessageBox.Show("Successfully Inserted!")

    End Sub

    Public Sub BlinData()

        Frmloading.Show()

        Dim query As String = "Select * FROM employee"
        Using con As SqlConnection = New SqlConnection("Data Source=192.175.10.40;Initial Catalog=HPCOMMON_TEST;Integrated Security=False;UID=sapdb;Pwd=sapdb")
            Using cmd As SqlCommand = New SqlCommand(query, con)
                Using da As New SqlDataAdapter()
                    da.SelectCommand = cmd
                    Using dt As New DataTable()
                        dt.Clear()
                        da.Fill(dt)
                        DataGridView1.DataSource = dt
                        Label8.Text = DataGridView1.RowCount

                        DataGridView1.EnableHeadersVisualStyles = False

                        DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

                        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Maroon

                        DataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.LightGray

                        DataGridView1.Columns(11).Visible = False

                        DataGridView1.DefaultCellStyle.Font = New Font("Tahoma", 9)

                    End Using
                End Using
            End Using
        End Using
        Frmloading.Dispose()
    End Sub

    Private Sub btnRead_Click(sender As Object, e As EventArgs) Handles btnRead.Click

        PictureBox3.BringToFront()

        Dim query As String = ("SELECT * FROM employee where empid = '" & txtid.Text & "'or Firstname = '" & TextBox1.Text & "'or Lastname ='" & TextBox1.Text & "'")
        Using con As SqlConnection = New SqlConnection("Data Source=192.175.10.40;Initial Catalog=HPCOMMON_TEST;Integrated Security=False;UID=sapdb;Pwd=sapdb")
            Using cmd As SqlCommand = New SqlCommand(query, con)
                Using da As New SqlDataAdapter()
                    da.SelectCommand = cmd
                    Using dt As New DataTable()
                        da.Fill(dt)
                        If dt.Rows.Count > 0 Then

                            txtid.Text = dt.Rows(0)(0).ToString()
                            txtFirstName.Text = dt.Rows(0)(1).ToString()
                            txtLastName.Text = dt.Rows(0)(2).ToString()
                            txtContact.Text = dt.Rows(0)(3).ToString()
                            ComboBox1.Text = dt.Rows(0)(4).ToString()
                            DateTimePicker1.Value = dt.Rows(0)(5).ToString()
                            txtAge.Text = dt.Rows(0)(6).ToString()
                            txtAddress.Text = dt.Rows(0)(7).ToString()
                            txtCitinzen.Text = dt.Rows(0)(8).ToString()
                            txtZipcode.Text = dt.Rows(0)(9).ToString()
                            txtEmail.Text = dt.Rows(0)(10).ToString()
                            txtposition.Text = dt.Rows(0)(12).ToString()
                            DateTimePicker2.Value = dt.Rows(0)(13).ToString()

                            Dim img() As Byte
                            img = dt.Rows(0)(11)
                            Dim ms As New MemoryStream(img)
                            PictureBox3.Image = System.Drawing.Image.FromStream(ms)


                        Else
                            'MsgBox("No records found")

                            MessageBox.Show("No records found!",
                                                    "Details", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub

                        End If

                        'Else

                        'txtFirstName.Text = ""
                        'txtLastName.Text = ""
                        'txtContact.Text = ""
                        'ComboBox1.Text = ""
                        'DateTimePicker1.Value = ""
                        'PictureBox3.Image = Nothing
                        'txtAge.Text = ""
                        'txtAddress.Text = ""
                        'txtCitinzen.Text = ""
                        'txtZipcode.Text = ""
                        'txtEmail.Text = ""


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
        txtCitinzen.Enabled = False
        txtZipcode.Enabled = False
        ComboBox1.Enabled = False
        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False
        txtposition.Enabled = False
        'BlinData()

    End Sub


    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        If txtid.Text = "" Then

            MessageBox.Show("Please Select Details",
                                    "User Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Button3.Focus()
            Exit Sub

        End If

        Dim empid As Integer = txtid.Text
        Dim Firstname As String = txtFirstName.Text
        Dim Lastname As String = txtLastName.Text
        Dim Contact As String = txtContact.Text
        Dim Gender As String = ComboBox1.SelectedItem
        Dim Birthdate As Date = DateTimePicker1.Value
        Dim Age As String = txtAge.Text
        Dim Address As String = txtAddress.Text
        Dim Citizenship As String = txtCitinzen.Text
        Dim ZIP_Code As String = txtZipcode.Text
        Dim Email_Address As String = txtEmail.Text
        Dim Position As String = txtposition.Text
        Dim DateHired As String = DateTimePicker2.Text

        If MsgBox("Are you sure want to Update now?", MsgBoxStyle.YesNo, "Warning...") = MsgBoxResult.Yes Then

            PictureBox1.BringToFront()

            Dim query As String = "UPDATE employee set Firstname =@Firstname, Lastname =@Lastname, Contact =@Contact, Gender =@Gender, Birthdate =@Birthdate, Age =@Age, Address =@Address, Citizenship =@Citizenship, ZIP_Code =@ZIP_Code, 
                                   Email_Address =@Email_Address, Photos =@Photos, Position=@Position, DateHired =@DateHired where empid=@empid"
            Using con As SqlConnection = New SqlConnection("Data Source=192.175.10.40;Initial Catalog=HPCOMMON_TEST;Integrated Security=False;UID=sapdb;Pwd=sapdb")
                Using cmd As SqlCommand = New SqlCommand(query, con)

                    Using ms As New MemoryStream
                        PictureBox3.Image.Save(ms, PictureBox3.Image.RawFormat)

                        cmd.Parameters.AddWithValue("@empid", empid)
                        cmd.Parameters.AddWithValue("@Firstname", Firstname)
                        cmd.Parameters.AddWithValue("@Lastname", Lastname)
                        cmd.Parameters.AddWithValue("@Contact", Contact)
                        cmd.Parameters.AddWithValue("@Gender", Gender)
                        cmd.Parameters.AddWithValue("@Birthdate", Birthdate)
                        cmd.Parameters.AddWithValue("@Age", Age)
                        cmd.Parameters.AddWithValue("@Address", Address)
                        cmd.Parameters.AddWithValue("@Citizenship", Citizenship)
                        cmd.Parameters.AddWithValue("@Zip_Code", ZIP_Code)
                        cmd.Parameters.AddWithValue("@Email_Address", Email_Address)
                        cmd.Parameters.AddWithValue("@Position", Position)
                        cmd.Parameters.AddWithValue("DateHired", DateHired)
                        cmd.Parameters.Add("@Photos", SqlDbType.Image).Value = ms.ToArray()

                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()

                        txtid.Clear()
                        txtFirstName.Clear()
                        txtLastName.Clear()
                        txtContact.Clear()
                        ComboBox1.Text = ""
                        PictureBox3.Image = Nothing
                        TextBox2.Clear()
                        txtAge.Clear()
                        txtAddress.Clear()
                        txtCitinzen.Clear()
                        txtZipcode.Clear()
                        txtEmail.Clear()
                        txtposition.Text = ""


                        'MessageBox.Show("Successfully Updated!")

                        BlinData()
                    End Using
                End Using
            End Using
            MsgBox("Successfully Updated!", MsgBoxStyle.Information, " Details")
        Else
            MsgBox(“Operation Cancelled…”, MsgBoxStyle.Critical, “Opps!")

            Exit Sub
        End If

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If txtid.Text = "" Then
            MessageBox.Show("Please Select Details", "User Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Button3.Focus()
            Exit Sub
        End If

        Dim empid As Integer = txtid.Text
        If MsgBox("Are you sure want to delete now?", MsgBoxStyle.YesNo, "Warning...") = MsgBoxResult.Yes Then
            PictureBox1.BringToFront()

            Dim query As String = "DELETE from employee where empid=@empid"
            Using con As SqlConnection = New SqlConnection("Data Source=192.175.10.40;Initial Catalog=HPCOMMON_TEST;Integrated Security=False;UID=sapdb;Pwd=sapdb")
                Using cmd As SqlCommand = New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@empid", empid)
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    txtFirstName.Text = ""
                    txtLastName.Text = ""
                    txtContact.Text = ""
                    ComboBox1.Text = ""
                    txtid.Text = ""
                    PictureBox3.Image = Nothing
                    txtAge.Text = ""
                    txtAddress.Text = ""
                    txtCitinzen.Text = ""
                    txtZipcode.Text = ""
                    txtEmail.Text = ""
                    txtposition.Text = ""


                    'MessageBox.Show("Successfully Deleted!")
                    BlinData()

                End Using
            End Using
            MsgBox("Successfully  deleted", MsgBoxStyle.Information, "Success")
            txtFirstName.Enabled = True
            txtLastName.Enabled = True
            txtAge.Enabled = True
            txtAddress.Enabled = True
            txtContact.Enabled = True
            txtEmail.Enabled = True
            txtCitinzen.Enabled = True
            txtZipcode.Enabled = True
            ComboBox1.Enabled = True
            DateTimePicker1.Enabled = True
            txtposition.Enabled = True
            DateTimePicker2.Enabled = True

        Else
            MsgBox(“Operation Cancelled…”, MsgBoxStyle.Critical, “Opps!")
            Exit Sub
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        BlinData()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        TryCast(DataGridView1.DataSource, DataTable).DefaultView.RowFilter =
        String.Format("Firstname like '%" & TextBox1.Text & "%'")

    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub Datagridview1_CellMouseEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellMouseEnter
        If e.RowIndex > -1 Then
            DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.BlanchedAlmond
        End If
    End Sub

    Private Sub datagridview1_CellMouseLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellMouseLeave
        If e.RowIndex > -1 Then
            DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        If MsgBox("Clear all Fields?", vbYesNo + vbQuestion, "Confirm...") = MsgBoxResult.Yes Then
            PictureBox1.BringToFront()

            'clear all the record
            txtid.Text = ""
            txtFirstName.Text = ""
            txtLastName.Text = ""
            txtContact.Text = ""
            ComboBox1.Text = ""
            TextBox1.Text = ""
            TextBox2.Text = ""
            PictureBox3.Image = Nothing
            txtAge.Text = ""
            txtAddress.Text = ""
            txtCitinzen.Text = ""
            txtZipcode.Text = ""
            txtEmail.Text = ""
            txtposition.Text = ""

            txtFirstName.Enabled = True
            txtLastName.Enabled = True
            txtAge.Enabled = True
            txtAddress.Enabled = True
            txtContact.Enabled = True
            txtEmail.Enabled = True
            txtCitinzen.Enabled = True
            txtZipcode.Enabled = True
            ComboBox1.Enabled = True
            DateTimePicker1.Enabled = True
            txtposition.Enabled = True
            DateTimePicker2.Enabled = True

        End If

    End Sub

    Private Sub Image_Click(sender As Object, e As EventArgs) Handles Image.Click
        Try
            Dim opf As New OpenFileDialog
            opf.Filter = "Choose Image(*.JPG;*.JPEG;*.PNG;*.GIF)|*.jpg;*.jpeg;*.png;*.gif"

            If opf.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Dim aa As String = opf.FileName

                If aa.ToUpper.Contains(".JPG") Or aa.ToUpper.Contains(".JPEG") Or aa.ToUpper.Contains(".PNG") Or aa.ToUpper.Contains(".GIF") Then
                    PictureBox3.Image = System.Drawing.Image.FromFile(opf.FileName)
                    TextBox2.Text = opf.FileName

                    PictureBox3.BringToFront()
                Else
                    MsgBox("The file you are trying to upload cannot be accepted, Please upload file in IMAGE FORMAT.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("Are you sure want to Close?", vbYesNo + vbQuestion, "Confirm...") = MsgBoxResult.Yes Then
            Me.Close()
        End If

    End Sub

    Private Sub txtid_KeyDown(sender As Object, e As KeyEventArgs) Handles txtid.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnRead.PerformClick()
            txtFirstName.Enabled = False
            txtLastName.Enabled = False
            txtAge.Enabled = False
            txtAddress.Enabled = False
            txtContact.Enabled = False
            txtEmail.Enabled = False
            txtCitinzen.Enabled = False
            txtZipcode.Enabled = False
            ComboBox1.Enabled = False
            DateTimePicker1.Enabled = False
            txtposition.Enabled = False
            DateTimePicker2.Enabled = False


        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim panel As New Panel()
        Me.Controls.Add(panel)

        'Create a Bitmap of size same as that of the Form.
        Dim grp As Graphics = panel.CreateGraphics()
        Dim formSize As Size = Me.ClientSize
        bitmap = New Bitmap(formSize.Width, formSize.Height, grp)
        grp = Graphics.FromImage(bitmap)

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
        e.Graphics.DrawImage(bitmap, 0, 0)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Form4.Show()
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click

        txtFirstName.Enabled = True
        txtLastName.Enabled = True
        txtAge.Enabled = True
        txtAddress.Enabled = True
        txtContact.Enabled = True
        txtEmail.Enabled = True
        txtCitinzen.Enabled = True
        txtZipcode.Enabled = True
        ComboBox1.Enabled = True
        DateTimePicker1.Enabled = True
        txtposition.Enabled = True
        DateTimePicker2.Enabled = True

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnRead.PerformClick()

        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If Label5.BackColor = Color.Green Then
            Label5.BackColor = Color.Yellow
        ElseIf Label5.BackColor = Color.Yellow Then
            Label5.BackColor = Color.Green
        End If

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Label5.BackColor = Color.Yellow

    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint
        ControlPaint.DrawBorder(e.Graphics, Panel5.ClientRectangle, Color.Black, ButtonBorderStyle.Solid)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub btnMoveUp_Click(sender As Object, e As EventArgs) Handles btnMoveUp.Click
        If DataGridView1.SelectedRows.Count > 0 AndAlso DataGridView1.SelectedRows(0).Index <> 0 Then
            Dim currentIndex As Integer = DataGridView1.SelectedRows(0).Index
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
            DataGridView1.Rows.Remove(selectedRow)
            DataGridView1.Rows.Insert(currentIndex - 1, selectedRow)
            DataGridView1.ClearSelection()
            DataGridView1.Rows(currentIndex - 1).Selected = True
        End If
    End Sub

    Private Sub btnMoveDown_Click(sender As Object, e As EventArgs) Handles btnMoveDown.Click
        If DataGridView1.SelectedRows.Count > 0 AndAlso DataGridView1.SelectedRows(0).Index <> DataGridView1.Rows.Count - 1 Then
            Dim currentIndex As Integer = DataGridView1.SelectedRows(0).Index
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
            DataGridView1.Rows.Remove(selectedRow)
            DataGridView1.Rows.Insert(currentIndex + 1, selectedRow)
            DataGridView1.ClearSelection()
            DataGridView1.Rows(currentIndex + 1).Selected = True
        End If
    End Sub


    Private Sub BindDataToDataGridView(dataTable As DataTable)
        DataGridView1.DataSource = dataTable
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        openFileDialog.Title = "Select an Excel file"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = openFileDialog.FileName
        End If
    End Sub
End Class


