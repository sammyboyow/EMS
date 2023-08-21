Imports System.Data.SqlClient


Public Class Form6

    Public MoveForm As Boolean
    Public MoveForm_MousePosition As Point

    Dim conn As String = "Data Source=192.175.10.40;Initial Catalog=HPCOMMON_TEST;Integrated Security=False;UID=sapdb;Pwd=sapdb"
    Dim connectionstring As String = "Data Source=172.30.0.17;Initial Catalog=HPCOMMON;Integrated Security=False;UID=sapdb;Pwd=sapdb"

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        'Dim cn As New SqlConnection(conn)
        'Dim str As String = ""
        'Dim cmd As New SqlCommand
        'Dim dr As SqlDataReader

        'Try
        'cn.Open()
        'MessageBox.Show("My Database Connection Successfully Connected")

        'cn.Close()
        'Catch erre As Exception

        'MessageBox.Show("My Database Connection Problem")

        'End Try

        'Using cn

        'cn.Open()
        'str = "exec userlogin '" & txtUser.Text & "','" & txtPass.Text & "' "
        'cmd = New SqlCommand(str, cn)
        'dr = cmd.ExecuteReader()
        'While dr.Read()

        'MsgBox(dr("empid") & " ' " & dr.Item("empname"))

        'End While
        'cmd.Dispose()
        'cn.Close()

        'End Using

        If txtUser.Text = "" Then
            MsgBox("Username is Required!", MsgBoxStyle.Critical, "Login")
            txtUser.Focus()
        ElseIf txtPass.Text = "" Then
            MsgBox("Password is Required!", MsgBoxStyle.Critical, "Login")
            txtPass.Focus()
        Else


            If txtUser.Text = "admin" And txtPass.Text = "admin" Then

                MsgBox("Login successfully!", MsgBoxStyle.Information, "Welcome")

                txtUser.Text = ""
                txtPass.Text = ""
                Form3.Show()
                Me.Hide()

            Else
                MsgBox("Wrong Username & Password", MsgBoxStyle.Exclamation, "Error")

                txtPass.Focus()

            End If

        End If

    End Sub

    Private Sub btnClosed_Click(sender As Object, e As EventArgs) Handles btnClosed.Click
        If MsgBox("Are you sure want to Close?", vbYesNo + vbQuestion, "Confirm...") = MsgBoxResult.Yes Then

            Application.Exit()

        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged_1(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If txtPass.UseSystemPasswordChar = True Then

            'hide password
            txtPass.UseSystemPasswordChar = False

        Else

            'show password
            txtPass.UseSystemPasswordChar = True

        End If
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtUser_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUser.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()


        End If
    End Sub

    Private Sub txtPass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPass.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If MsgBox("Close program?", vbYesNo + vbQuestion, "Confirm...") = MsgBoxResult.Yes Then

            Application.Exit()

        End If

    End Sub


    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown

        If e.Button = MouseButtons.Left Then
            MoveForm = True
            Me.Cursor = Cursors.Default
            MoveForm_MousePosition = e.Location
        End If

    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp

        If e.Button = MouseButtons.Left Then
            MoveForm = False
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If e.Button = MouseButtons.Left Then

            If MoveForm Then
                Me.Location = Me.Location + (e.Location - MoveForm_MousePosition)
            End If

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Me.WindowState Or FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Minimized

        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class