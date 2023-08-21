
Imports System.Data.SqlClient

Public Class Form5
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Form4.Show()


    End Sub

    Public Sub BlinData()
        Dim query As String = "Select * FROM employee"
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

                        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Maroon

                        DataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.LightGray

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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        BlinData()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()

    End Sub


    Private Sub DataGridView1_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellMouseEnter
        If e.RowIndex > -1 Then
            DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.BlanchedAlmond
        End If
    End Sub

    Private Sub DataGridView1_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellMouseLeave
        If e.RowIndex > -1 Then
            DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White

        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form4.txtid.Text = TextBox1.Text
        Form4.txtFirstname.Text = ""
        Form4.txtLastname.Text = ""
        Form4.txtAge.Text = ""
        Form4.ComboBox3.Text = ""
        Form4.txtAddress.Text = ""
        Form4.PictureBox3.Image = Nothing


        Me.Close()

    End Sub


    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button2.PerformClick()

        End If
    End Sub

    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick

        Form4.txtFirstname.Text = TextBox1.Text

    End Sub

End Class