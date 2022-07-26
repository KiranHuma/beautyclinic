<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class regmmberfrm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(regmmberfrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.welcomemsg = New System.Windows.Forms.Label()
        Me.Btnadd = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.mid_txt = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.m_dtetxt = New System.Windows.Forms.DateTimePicker()
        Me.midtxt = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.addresstxt = New System.Windows.Forms.RichTextBox()
        Me.agetxt = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnupdte = New System.Windows.Forms.Button()
        Me.Btndel = New System.Windows.Forms.Button()
        Me.svemem = New System.Windows.Forms.Button()
        Me.cntcttxt = New System.Windows.Forms.TextBox()
        Me.nametxt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.memberdata = New System.Windows.Forms.DataGridView()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.memberdata, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(840, 653)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.Button12)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.welcomemsg)
        Me.TabPage1.Controls.Add(Me.Btnadd)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.mid_txt)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.m_dtetxt)
        Me.TabPage1.Controls.Add(Me.midtxt)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.addresstxt)
        Me.TabPage1.Controls.Add(Me.agetxt)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.btnupdte)
        Me.TabPage1.Controls.Add(Me.Btndel)
        Me.TabPage1.Controls.Add(Me.svemem)
        Me.TabPage1.Controls.Add(Me.cntcttxt)
        Me.TabPage1.Controls.Add(Me.nametxt)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.ForeColor = System.Drawing.Color.LightCoral
        Me.TabPage1.Location = New System.Drawing.Point(4, 28)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(832, 621)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Members Registration"
        '
        'Button12
        '
        Me.Button12.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button12.BackColor = System.Drawing.Color.White
        Me.Button12.BackgroundImage = CType(resources.GetObject("Button12.BackgroundImage"), System.Drawing.Image)
        Me.Button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button12.ForeColor = System.Drawing.Color.White
        Me.Button12.Location = New System.Drawing.Point(805, 5)
        Me.Button12.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(23, 23)
        Me.Button12.TabIndex = 334
        Me.Button12.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(829, -48)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(28, 30)
        Me.Button1.TabIndex = 333
        Me.Button1.UseVisualStyleBackColor = False
        '
        'welcomemsg
        '
        Me.welcomemsg.AutoSize = True
        Me.welcomemsg.BackColor = System.Drawing.Color.White
        Me.welcomemsg.Font = New System.Drawing.Font("Tempus Sans ITC", 10.2!, System.Drawing.FontStyle.Bold)
        Me.welcomemsg.ForeColor = System.Drawing.Color.White
        Me.welcomemsg.Location = New System.Drawing.Point(44, 554)
        Me.welcomemsg.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.welcomemsg.Name = "welcomemsg"
        Me.welcomemsg.Size = New System.Drawing.Size(86, 22)
        Me.welcomemsg.TabIndex = 332
        Me.welcomemsg.Text = "Welcome"
        Me.welcomemsg.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Btnadd
        '
        Me.Btnadd.BackColor = System.Drawing.Color.Transparent
        Me.Btnadd.BackgroundImage = CType(resources.GetObject("Btnadd.BackgroundImage"), System.Drawing.Image)
        Me.Btnadd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btnadd.ForeColor = System.Drawing.Color.White
        Me.Btnadd.Location = New System.Drawing.Point(589, 539)
        Me.Btnadd.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Btnadd.Name = "Btnadd"
        Me.Btnadd.Size = New System.Drawing.Size(40, 35)
        Me.Btnadd.TabIndex = 330
        Me.Btnadd.UseVisualStyleBackColor = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.LightCoral
        Me.Label19.Location = New System.Drawing.Point(556, 579)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(83, 20)
        Me.Label19.TabIndex = 331
        Me.Label19.Text = "Add New"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightCoral
        Me.Panel1.ForeColor = System.Drawing.Color.Snow
        Me.Panel1.Location = New System.Drawing.Point(-15, 653)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1021, 19)
        Me.Panel1.TabIndex = 328
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label13.Location = New System.Drawing.Point(86, 206)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 17)
        Me.Label13.TabIndex = 271
        Me.Label13.Text = "Entry#"
        '
        'mid_txt
        '
        Me.mid_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mid_txt.ForeColor = System.Drawing.Color.Black
        Me.mid_txt.Location = New System.Drawing.Point(203, 206)
        Me.mid_txt.Name = "mid_txt"
        Me.mid_txt.ReadOnly = True
        Me.mid_txt.Size = New System.Drawing.Size(151, 22)
        Me.mid_txt.TabIndex = 270
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label11.Location = New System.Drawing.Point(86, 401)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 17)
        Me.Label11.TabIndex = 268
        Me.Label11.Text = "Date"
        '
        'm_dtetxt
        '
        Me.m_dtetxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_dtetxt.Location = New System.Drawing.Point(203, 396)
        Me.m_dtetxt.Name = "m_dtetxt"
        Me.m_dtetxt.Size = New System.Drawing.Size(151, 22)
        Me.m_dtetxt.TabIndex = 267
        '
        'midtxt
        '
        Me.midtxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.midtxt.ForeColor = System.Drawing.Color.Black
        Me.midtxt.Location = New System.Drawing.Point(203, 244)
        Me.midtxt.Name = "midtxt"
        Me.midtxt.ReadOnly = True
        Me.midtxt.Size = New System.Drawing.Size(151, 22)
        Me.midtxt.TabIndex = 264
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label9.Location = New System.Drawing.Point(86, 249)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 17)
        Me.Label9.TabIndex = 263
        Me.Label9.Text = "MemberID"
        '
        'addresstxt
        '
        Me.addresstxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addresstxt.ForeColor = System.Drawing.Color.Black
        Me.addresstxt.Location = New System.Drawing.Point(471, 208)
        Me.addresstxt.Name = "addresstxt"
        Me.addresstxt.Size = New System.Drawing.Size(207, 102)
        Me.addresstxt.TabIndex = 262
        Me.addresstxt.Text = ""
        '
        'agetxt
        '
        Me.agetxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.agetxt.ForeColor = System.Drawing.Color.Black
        Me.agetxt.Location = New System.Drawing.Point(203, 358)
        Me.agetxt.Name = "agetxt"
        Me.agetxt.Size = New System.Drawing.Size(151, 22)
        Me.agetxt.TabIndex = 260
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label6.Location = New System.Drawing.Point(398, 211)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 17)
        Me.Label6.TabIndex = 259
        Me.Label6.Text = "Address"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label8.Location = New System.Drawing.Point(86, 363)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 17)
        Me.Label8.TabIndex = 258
        Me.Label8.Text = "Age"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Vivaldi", 36.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label4.ForeColor = System.Drawing.Color.LightCoral
        Me.Label4.Location = New System.Drawing.Point(242, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(436, 71)
        Me.Label4.TabIndex = 257
        Me.Label4.Text = "&Register Members"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.LightCoral
        Me.Label3.Location = New System.Drawing.Point(644, 580)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 20)
        Me.Label3.TabIndex = 256
        Me.Label3.Text = "Save"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.LightCoral
        Me.Label15.Location = New System.Drawing.Point(754, 580)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 20)
        Me.Label15.TabIndex = 255
        Me.Label15.Text = "Delete"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.LightCoral
        Me.Label7.Location = New System.Drawing.Point(702, 580)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 20)
        Me.Label7.TabIndex = 254
        Me.Label7.Text = "Edit"
        '
        'btnupdte
        '
        Me.btnupdte.BackColor = System.Drawing.Color.White
        Me.btnupdte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnupdte.Enabled = False
        Me.btnupdte.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnupdte.ForeColor = System.Drawing.Color.White
        Me.btnupdte.Image = CType(resources.GetObject("btnupdte.Image"), System.Drawing.Image)
        Me.btnupdte.Location = New System.Drawing.Point(703, 544)
        Me.btnupdte.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnupdte.Name = "btnupdte"
        Me.btnupdte.Size = New System.Drawing.Size(40, 35)
        Me.btnupdte.TabIndex = 252
        Me.btnupdte.UseVisualStyleBackColor = False
        '
        'Btndel
        '
        Me.Btndel.BackColor = System.Drawing.Color.White
        Me.Btndel.BackgroundImage = CType(resources.GetObject("Btndel.BackgroundImage"), System.Drawing.Image)
        Me.Btndel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btndel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btndel.ForeColor = System.Drawing.Color.White
        Me.Btndel.Location = New System.Drawing.Point(763, 544)
        Me.Btndel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Btndel.Name = "Btndel"
        Me.Btndel.Size = New System.Drawing.Size(40, 35)
        Me.Btndel.TabIndex = 253
        Me.Btndel.UseVisualStyleBackColor = False
        '
        'svemem
        '
        Me.svemem.BackColor = System.Drawing.Color.White
        Me.svemem.BackgroundImage = CType(resources.GetObject("svemem.BackgroundImage"), System.Drawing.Image)
        Me.svemem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.svemem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.svemem.ForeColor = System.Drawing.Color.White
        Me.svemem.Location = New System.Drawing.Point(647, 543)
        Me.svemem.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.svemem.Name = "svemem"
        Me.svemem.Size = New System.Drawing.Size(40, 35)
        Me.svemem.TabIndex = 248
        Me.svemem.UseVisualStyleBackColor = False
        '
        'cntcttxt
        '
        Me.cntcttxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cntcttxt.ForeColor = System.Drawing.Color.Black
        Me.cntcttxt.Location = New System.Drawing.Point(203, 320)
        Me.cntcttxt.Name = "cntcttxt"
        Me.cntcttxt.Size = New System.Drawing.Size(151, 22)
        Me.cntcttxt.TabIndex = 3
        '
        'nametxt
        '
        Me.nametxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nametxt.ForeColor = System.Drawing.Color.Black
        Me.nametxt.Location = New System.Drawing.Point(203, 282)
        Me.nametxt.Name = "nametxt"
        Me.nametxt.Size = New System.Drawing.Size(151, 22)
        Me.nametxt.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label2.Location = New System.Drawing.Point(86, 325)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Contact"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(86, 287)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.White
        Me.TabPage2.Controls.Add(Me.RadioButton1)
        Me.TabPage2.Controls.Add(Me.Label24)
        Me.TabPage2.Controls.Add(Me.DateTimePicker2)
        Me.TabPage2.Controls.Add(Me.DateTimePicker1)
        Me.TabPage2.Controls.Add(Me.Label21)
        Me.TabPage2.Controls.Add(Me.TextBox3)
        Me.TabPage2.Controls.Add(Me.Button6)
        Me.TabPage2.Controls.Add(Me.memberdata)
        Me.TabPage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 28)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(832, 621)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Members Record"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton1.ForeColor = System.Drawing.Color.SteelBlue
        Me.RadioButton1.Location = New System.Drawing.Point(14, 55)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(147, 21)
        Me.RadioButton1.TabIndex = 339
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Search By  Date"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label24.Location = New System.Drawing.Point(187, 82)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(22, 17)
        Me.Label24.TabIndex = 338
        Me.Label24.Text = "to"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Location = New System.Drawing.Point(237, 82)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(151, 22)
        Me.DateTimePicker2.TabIndex = 337
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(14, 82)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(151, 22)
        Me.DateTimePicker1.TabIndex = 336
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label21.Location = New System.Drawing.Point(9, 126)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(190, 17)
        Me.Label21.TabIndex = 335
        Me.Label21.Text = "Search By Member Name"
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(11, 146)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(151, 22)
        Me.TextBox3.TabIndex = 334
        '
        'Button6
        '
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.SteelBlue
        Me.Button6.Location = New System.Drawing.Point(632, 138)
        Me.Button6.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(191, 31)
        Me.Button6.TabIndex = 317
        Me.Button6.Text = "&Select Rows to Remove"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'memberdata
        '
        Me.memberdata.AllowUserToAddRows = False
        Me.memberdata.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.LightCoral
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightCoral
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.memberdata.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.memberdata.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.memberdata.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.memberdata.BackgroundColor = System.Drawing.Color.LightCoral
        Me.memberdata.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.memberdata.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightCoral
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.LightCoral
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.memberdata.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.memberdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.LightCoral
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCoral
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.memberdata.DefaultCellStyle = DataGridViewCellStyle3
        Me.memberdata.EnableHeadersVisualStyles = False
        Me.memberdata.GridColor = System.Drawing.Color.LightCoral
        Me.memberdata.Location = New System.Drawing.Point(8, 179)
        Me.memberdata.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.memberdata.Name = "memberdata"
        Me.memberdata.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.LightCoral
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightCoral
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.memberdata.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.memberdata.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.LightCoral
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightCoral
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        Me.memberdata.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.memberdata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.memberdata.Size = New System.Drawing.Size(817, 375)
        Me.memberdata.TabIndex = 150
        '
        'regmmberfrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(840, 653)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "regmmberfrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "regmmberfrm"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.memberdata, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents memberdata As System.Windows.Forms.DataGridView
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents welcomemsg As System.Windows.Forms.Label
    Friend WithEvents Btnadd As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents mid_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents m_dtetxt As System.Windows.Forms.DateTimePicker
    Friend WithEvents midtxt As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents addresstxt As System.Windows.Forms.RichTextBox
    Friend WithEvents agetxt As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnupdte As System.Windows.Forms.Button
    Friend WithEvents Btndel As System.Windows.Forms.Button
    Friend WithEvents svemem As System.Windows.Forms.Button
    Friend WithEvents cntcttxt As System.Windows.Forms.TextBox
    Friend WithEvents nametxt As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
End Class
