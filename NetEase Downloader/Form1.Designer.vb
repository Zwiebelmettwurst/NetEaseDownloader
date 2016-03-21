<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_changesavepath = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_savepath = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbl_status = New System.Windows.Forms.Label()
        Me.lvw_Songs = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btn_searchQuery = New System.Windows.Forms.Button()
        Me.txt_searchQuery = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lbl_downloadprogress = New System.Windows.Forms.Label()
        Me.btn_download = New System.Windows.Forms.Button()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btn_listen = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_changesavepath)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lbl_savepath)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(410, 54)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Settings"
        '
        'btn_changesavepath
        '
        Me.btn_changesavepath.Location = New System.Drawing.Point(59, 23)
        Me.btn_changesavepath.Name = "btn_changesavepath"
        Me.btn_changesavepath.Size = New System.Drawing.Size(40, 22)
        Me.btn_changesavepath.TabIndex = 2
        Me.btn_changesavepath.Text = "..."
        Me.btn_changesavepath.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Save to:"
        '
        'lbl_savepath
        '
        Me.lbl_savepath.AutoSize = True
        Me.lbl_savepath.Location = New System.Drawing.Point(112, 28)
        Me.lbl_savepath.Name = "lbl_savepath"
        Me.lbl_savepath.Size = New System.Drawing.Size(67, 13)
        Me.lbl_savepath.TabIndex = 0
        Me.lbl_savepath.Text = "lbl_savepath"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_status)
        Me.GroupBox2.Controls.Add(Me.lvw_Songs)
        Me.GroupBox2.Controls.Add(Me.btn_searchQuery)
        Me.GroupBox2.Controls.Add(Me.txt_searchQuery)
        Me.GroupBox2.Location = New System.Drawing.Point(20, 78)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(410, 260)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Search"
        '
        'lbl_status
        '
        Me.lbl_status.AutoSize = True
        Me.lbl_status.Location = New System.Drawing.Point(311, 23)
        Me.lbl_status.Name = "lbl_status"
        Me.lbl_status.Size = New System.Drawing.Size(23, 13)
        Me.lbl_status.TabIndex = 17
        Me.lbl_status.Text = "idle"
        '
        'lvw_Songs
        '
        Me.lvw_Songs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvw_Songs.FullRowSelect = True
        Me.lvw_Songs.Location = New System.Drawing.Point(9, 45)
        Me.lvw_Songs.MultiSelect = False
        Me.lvw_Songs.Name = "lvw_Songs"
        Me.lvw_Songs.Size = New System.Drawing.Size(394, 209)
        Me.lvw_Songs.TabIndex = 5
        Me.lvw_Songs.UseCompatibleStateImageBehavior = False
        Me.lvw_Songs.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Title"
        Me.ColumnHeader1.Width = 215
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Artist"
        Me.ColumnHeader2.Width = 98
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Quality"
        Me.ColumnHeader3.Width = 65
        '
        'btn_searchQuery
        '
        Me.btn_searchQuery.Location = New System.Drawing.Point(201, 19)
        Me.btn_searchQuery.Name = "btn_searchQuery"
        Me.btn_searchQuery.Size = New System.Drawing.Size(104, 20)
        Me.btn_searchQuery.TabIndex = 1
        Me.btn_searchQuery.Text = "search"
        Me.btn_searchQuery.UseVisualStyleBackColor = True
        '
        'txt_searchQuery
        '
        Me.txt_searchQuery.AcceptsReturn = True
        Me.txt_searchQuery.Location = New System.Drawing.Point(9, 19)
        Me.txt_searchQuery.Name = "txt_searchQuery"
        Me.txt_searchQuery.Size = New System.Drawing.Size(186, 20)
        Me.txt_searchQuery.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btn_listen)
        Me.GroupBox3.Controls.Add(Me.lbl_downloadprogress)
        Me.GroupBox3.Controls.Add(Me.btn_download)
        Me.GroupBox3.Controls.Add(Me.lbl_title)
        Me.GroupBox3.Controls.Add(Me.ProgressBar1)
        Me.GroupBox3.Location = New System.Drawing.Point(20, 344)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(409, 119)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Download"
        '
        'lbl_downloadprogress
        '
        Me.lbl_downloadprogress.AutoSize = True
        Me.lbl_downloadprogress.Location = New System.Drawing.Point(6, 68)
        Me.lbl_downloadprogress.Name = "lbl_downloadprogress"
        Me.lbl_downloadprogress.Size = New System.Drawing.Size(182, 13)
        Me.lbl_downloadprogress.TabIndex = 3
        Me.lbl_downloadprogress.Text = "Download:  999/999 - 100% - 0 KB/s"
        Me.lbl_downloadprogress.Visible = False
        '
        'btn_download
        '
        Me.btn_download.Enabled = False
        Me.btn_download.Location = New System.Drawing.Point(332, 17)
        Me.btn_download.Name = "btn_download"
        Me.btn_download.Size = New System.Drawing.Size(71, 28)
        Me.btn_download.TabIndex = 2
        Me.btn_download.Text = "Download"
        Me.btn_download.UseVisualStyleBackColor = True
        '
        'lbl_title
        '
        Me.lbl_title.AutoSize = True
        Me.lbl_title.Location = New System.Drawing.Point(6, 52)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(39, 13)
        Me.lbl_title.TabIndex = 1
        Me.lbl_title.Text = "Title: - "
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(6, 92)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(397, 21)
        Me.ProgressBar1.TabIndex = 0
        '
        'btn_listen
        '
        Me.btn_listen.Location = New System.Drawing.Point(332, 67)
        Me.btn_listen.Name = "btn_listen"
        Me.btn_listen.Size = New System.Drawing.Size(71, 23)
        Me.btn_listen.TabIndex = 4
        Me.btn_listen.Text = "listen"
        Me.btn_listen.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AcceptButton = Me.btn_searchQuery
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(451, 470)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NetEase Downloader"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btn_changesavepath As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents lbl_savepath As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lvw_Songs As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents btn_searchQuery As Button
    Friend WithEvents txt_searchQuery As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btn_download As Button
    Friend WithEvents lbl_title As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents lbl_status As Label
    Friend WithEvents lbl_downloadprogress As Label
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents btn_listen As Button
End Class
