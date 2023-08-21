<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frmloading
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frmloading))
        Me.pbload = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbload = New System.Windows.Forms.Label()
        CType(Me.pbload, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbload
        '
        Me.pbload.BackColor = System.Drawing.Color.White
        Me.pbload.Image = CType(resources.GetObject("pbload.Image"), System.Drawing.Image)
        Me.pbload.Location = New System.Drawing.Point(97, 40)
        Me.pbload.Name = "pbload"
        Me.pbload.Size = New System.Drawing.Size(70, 61)
        Me.pbload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbload.TabIndex = 1
        Me.pbload.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SeaGreen
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(267, 26)
        Me.Panel1.TabIndex = 2
        '
        'lbload
        '
        Me.lbload.AutoSize = True
        Me.lbload.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbload.ForeColor = System.Drawing.Color.DimGray
        Me.lbload.Location = New System.Drawing.Point(89, 108)
        Me.lbload.Name = "lbload"
        Me.lbload.Size = New System.Drawing.Size(91, 17)
        Me.lbload.TabIndex = 2
        Me.lbload.Text = "Loading Data"
        '
        'Frmloading
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(267, 141)
        Me.Controls.Add(Me.lbload)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pbload)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Frmloading"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Frmloading"
        CType(Me.pbload, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pbload As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lbload As Label
End Class
