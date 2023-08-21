Public Class Form3

    Public MoveForm As Boolean
    Public MoveForm_MousePosition As Point


    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        If MsgBox("Exit System?", vbYesNo + vbQuestion, "Confirm...") = MsgBoxResult.Yes Then

            MsgBox("Exit Successfully", MsgBoxStyle.Information, "Employee")
            Me.Hide()
            Form6.Show()

        End If
    End Sub

    Private Sub RegisToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegisToolStripMenuItem.Click
        Form2.Show()

    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        If MsgBox("Log-out Program?", vbYesNo + vbQuestion, "Confirm...") = MsgBoxResult.Yes Then

            MsgBox("Log-out Successfully", MsgBoxStyle.Information, "Employee")
            Application.Exit()

        End If

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

        ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.Black, ButtonBorderStyle.Solid)

    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Enabled = True

        Panel1.BackColor = Color.FromArgb(100, 30, 139, 195)


        Call CenterToScreen()
        Me.MaximizedBounds = New Rectangle(0, 0, 1370, 727)
        'Me.MaximizedBounds = New Rectangle(0, 0, 1400, 850)
        Me.WindowState = FormWindowState.Maximized

        'Me.Location = New Point(0, 0)
        'Me.Size = Screen.PrimaryScreen.WorkingArea.Size


    End Sub


    Private Sub Panel1_Paint_1(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

        ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.White, ButtonBorderStyle.Solid)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = Date.Now.ToString("dddddd, MMMMMM dd,yyyy | hh:mm:ss")
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Process.Start("https://www.tutorialspoint.com/vb.net/index.htm")
    End Sub

    Private Sub SalaryEmpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalaryEmpToolStripMenuItem.Click
        Form4.Show()
        Form4.txtid.Focus()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If Label2.ForeColor = Color.Green Then
            Label2.ForeColor = Color.Yellow
        ElseIf Label2.ForeColor = Color.Yellow Then
            Label2.ForeColor = Color.Green

        End If

        If Label3.ForeColor = Color.Green Then
            Label3.ForeColor = Color.Yellow
        ElseIf Label3.ForeColor = Color.Yellow Then
            Label3.ForeColor = Color.Green

        End If


    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Label2.ForeColor = Color.Yellow
        Label3.ForeColor = Color.Yellow

    End Sub

    Private Sub ViewingEmpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewingEmpToolStripMenuItem.Click
        Form7.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If MsgBox("Exit Program?", vbYesNo + vbQuestion, "Confirm...") = MsgBoxResult.Yes Then

            Me.Close()
            Form6.Show()
            Form6.txtUser.Focus()

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Me.WindowState Or FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Minimized

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal

        Else
            Me.WindowState = FormWindowState.Maximized

        End If

    End Sub


    Private Sub PictureBox2_MouseDown_1(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseDown
        If e.Button = MouseButtons.Left Then
            MoveForm = True
            Me.Cursor = Cursors.Default
            MoveForm_MousePosition = e.Location
        End If
    End Sub

    Private Sub PictureBox2_MouseUp_1(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseUp

        If e.Button = MouseButtons.Left Then
            MoveForm = False
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub PictureBox2_MouseMove_1(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseMove
        If e.Button = MouseButtons.Left Then

            If MoveForm Then
                Me.Location = Me.Location + (e.Location - MoveForm_MousePosition)
            End If

        End If
    End Sub

    Private Sub PictureBox2_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox2.DoubleClick


        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal

        Else
            Me.WindowState = FormWindowState.Maximized



        End If

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub BulkCopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BulkCopyToolStripMenuItem.Click
        BulkCopy.Show()
    End Sub

    Private Sub GoogleMapToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GoogleMapToolStripMenuItem.Click
        Form9.Show()

    End Sub

    Private Sub OOPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OOPToolStripMenuItem.Click
        OOP.Show()
    End Sub
End Class

