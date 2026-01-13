<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class INDEX
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        bnt_Avvia = New Button()
        tb_debug = New TextBox()
        l_desDebug = New Label()
        OFD = New OpenFileDialog()
        Label5 = New Label()
        BindingSource1 = New BindingSource(components)
        FBD = New FolderBrowserDialog()
        TabConteiner = New TabControl()
        TabGiaAlenato = New TabPage()
        bnt_setFiel_Categorie = New Button()
        Label4 = New Label()
        tb_setFile_Categorie = New TextBox()
        tb_setFile_Bin = New TextBox()
        bnt_setCartella_bin = New Button()
        Label2 = New Label()
        TabDaAlenare = New TabPage()
        Label12 = New Label()
        Label10 = New Label()
        tb_setFile_NomeCategoria = New TextBox()
        tb_setFile_NomeAadestramento_BIN = New TextBox()
        Label11 = New Label()
        Label9 = New Label()
        tb_setDir_SalvaAlenaemnto = New TextBox()
        tb_DirAdestra = New TextBox()
        bnt_setDir_Alenamento = New Button()
        bnt_SetDir_Adestra = New Button()
        Label7 = New Label()
        Label6 = New Label()
        TabImgCalsifica = New TabPage()
        cb_cancellaFileOrignale = New CheckBox()
        tb_setDir_Output = New TextBox()
        Label13 = New Label()
        bnt_setDir_Output = New Button()
        bnt_setDir_ImgDaClasificare = New Button()
        tb_setDir_ImgDaClasifirare = New TextBox()
        Label8 = New Label()
        l_desc1 = New Label()
        pb_1 = New ProgressBar()
        pb_2 = New ProgressBar()
        l_desc2 = New Label()
        l_pb2 = New Label()
        l_pb1 = New Label()
        Label1 = New Label()
        CType(BindingSource1, ComponentModel.ISupportInitialize).BeginInit()
        TabConteiner.SuspendLayout()
        TabGiaAlenato.SuspendLayout()
        TabDaAlenare.SuspendLayout()
        TabImgCalsifica.SuspendLayout()
        SuspendLayout()
        ' 
        ' bnt_Avvia
        ' 
        bnt_Avvia.Font = New Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        bnt_Avvia.Location = New Point(97, 475)
        bnt_Avvia.Margin = New Padding(4)
        bnt_Avvia.Name = "bnt_Avvia"
        bnt_Avvia.Size = New Size(454, 81)
        bnt_Avvia.TabIndex = 0
        bnt_Avvia.Text = "START"
        bnt_Avvia.UseVisualStyleBackColor = True
        ' 
        ' tb_debug
        ' 
        tb_debug.Location = New Point(675, 41)
        tb_debug.Margin = New Padding(4)
        tb_debug.Multiline = True
        tb_debug.Name = "tb_debug"
        tb_debug.ReadOnly = True
        tb_debug.ScrollBars = ScrollBars.Vertical
        tb_debug.Size = New Size(456, 516)
        tb_debug.TabIndex = 1
        ' 
        ' l_desDebug
        ' 
        l_desDebug.AutoSize = True
        l_desDebug.Location = New Point(869, 9)
        l_desDebug.Margin = New Padding(4, 0, 4, 0)
        l_desDebug.Name = "l_desDebug"
        l_desDebug.Size = New Size(56, 21)
        l_desDebug.TabIndex = 2
        l_desDebug.Text = "Debug"
        ' 
        ' OFD
        ' 
        OFD.FileName = "Open File"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.ForeColor = Color.Red
        Label5.Location = New Point(810, 561)
        Label5.Name = "Label5"
        Label5.Size = New Size(183, 21)
        Label5.TabIndex = 8
        Label5.Text = "Ver 1.1.3 del 2026-01-13"
        ' 
        ' TabConteiner
        ' 
        TabConteiner.Controls.Add(TabGiaAlenato)
        TabConteiner.Controls.Add(TabDaAlenare)
        TabConteiner.Controls.Add(TabImgCalsifica)
        TabConteiner.Location = New Point(7, 9)
        TabConteiner.Name = "TabConteiner"
        TabConteiner.SelectedIndex = 0
        TabConteiner.Size = New Size(657, 290)
        TabConteiner.TabIndex = 13
        ' 
        ' TabGiaAlenato
        ' 
        TabGiaAlenato.Controls.Add(bnt_setFiel_Categorie)
        TabGiaAlenato.Controls.Add(Label4)
        TabGiaAlenato.Controls.Add(tb_setFile_Categorie)
        TabGiaAlenato.Controls.Add(tb_setFile_Bin)
        TabGiaAlenato.Controls.Add(bnt_setCartella_bin)
        TabGiaAlenato.Controls.Add(Label2)
        TabGiaAlenato.Location = New Point(4, 30)
        TabGiaAlenato.Name = "TabGiaAlenato"
        TabGiaAlenato.Padding = New Padding(3)
        TabGiaAlenato.Size = New Size(649, 256)
        TabGiaAlenato.TabIndex = 0
        TabGiaAlenato.Text = "Schon Fit"
        TabGiaAlenato.UseVisualStyleBackColor = True
        ' 
        ' bnt_setFiel_Categorie
        ' 
        bnt_setFiel_Categorie.Location = New Point(528, 140)
        bnt_setFiel_Categorie.Name = "bnt_setFiel_Categorie"
        bnt_setFiel_Categorie.Size = New Size(99, 38)
        bnt_setFiel_Categorie.TabIndex = 10
        bnt_setFiel_Categorie.Text = "Set File"
        bnt_setFiel_Categorie.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(6, 154)
        Label4.Name = "Label4"
        Label4.Size = New Size(185, 21)
        Label4.TabIndex = 8
        Label4.Text = "Set File List Kategori .txt *"
        ' 
        ' tb_setFile_Categorie
        ' 
        tb_setFile_Categorie.Location = New Point(6, 185)
        tb_setFile_Categorie.Name = "tb_setFile_Categorie"
        tb_setFile_Categorie.Size = New Size(621, 29)
        tb_setFile_Categorie.TabIndex = 7
        ' 
        ' tb_setFile_Bin
        ' 
        tb_setFile_Bin.Location = New Point(6, 59)
        tb_setFile_Bin.Name = "tb_setFile_Bin"
        tb_setFile_Bin.Size = New Size(621, 29)
        tb_setFile_Bin.TabIndex = 6
        ' 
        ' bnt_setCartella_bin
        ' 
        bnt_setCartella_bin.Location = New Point(528, 6)
        bnt_setCartella_bin.Name = "bnt_setCartella_bin"
        bnt_setCartella_bin.Size = New Size(99, 47)
        bnt_setCartella_bin.TabIndex = 5
        bnt_setCartella_bin.Text = "Set File"
        bnt_setCartella_bin.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(6, 28)
        Label2.Name = "Label2"
        Label2.Size = New Size(177, 21)
        Label2.TabIndex = 4
        Label2.Text = "Set File  .bin di Trading *"
        ' 
        ' TabDaAlenare
        ' 
        TabDaAlenare.Controls.Add(Label12)
        TabDaAlenare.Controls.Add(Label10)
        TabDaAlenare.Controls.Add(tb_setFile_NomeCategoria)
        TabDaAlenare.Controls.Add(tb_setFile_NomeAadestramento_BIN)
        TabDaAlenare.Controls.Add(Label11)
        TabDaAlenare.Controls.Add(Label9)
        TabDaAlenare.Controls.Add(tb_setDir_SalvaAlenaemnto)
        TabDaAlenare.Controls.Add(tb_DirAdestra)
        TabDaAlenare.Controls.Add(bnt_setDir_Alenamento)
        TabDaAlenare.Controls.Add(bnt_SetDir_Adestra)
        TabDaAlenare.Controls.Add(Label7)
        TabDaAlenare.Controls.Add(Label6)
        TabDaAlenare.Location = New Point(4, 30)
        TabDaAlenare.Name = "TabDaAlenare"
        TabDaAlenare.Padding = New Padding(3)
        TabDaAlenare.Size = New Size(649, 256)
        TabDaAlenare.TabIndex = 1
        TabDaAlenare.Text = "To Tradign "
        TabDaAlenare.UseVisualStyleBackColor = True
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(593, 217)
        Label12.Name = "Label12"
        Label12.Size = New Size(30, 21)
        Label12.TabIndex = 17
        Label12.Text = ".txt"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(237, 217)
        Label10.Name = "Label10"
        Label10.Size = New Size(35, 21)
        Label10.TabIndex = 17
        Label10.Text = ".bin"
        ' 
        ' tb_setFile_NomeCategoria
        ' 
        tb_setFile_NomeCategoria.Location = New Point(308, 209)
        tb_setFile_NomeCategoria.Name = "tb_setFile_NomeCategoria"
        tb_setFile_NomeCategoria.Size = New Size(279, 29)
        tb_setFile_NomeCategoria.TabIndex = 16
        ' 
        ' tb_setFile_NomeAadestramento_BIN
        ' 
        tb_setFile_NomeAadestramento_BIN.Location = New Point(8, 209)
        tb_setFile_NomeAadestramento_BIN.Name = "tb_setFile_NomeAadestramento_BIN"
        tb_setFile_NomeAadestramento_BIN.Size = New Size(231, 29)
        tb_setFile_NomeAadestramento_BIN.TabIndex = 15
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(308, 179)
        Label11.Name = "Label11"
        Label11.Size = New Size(112, 21)
        Label11.TabIndex = 14
        Label11.Text = "Name File List "
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(8, 178)
        Label9.Name = "Label9"
        Label9.Size = New Size(136, 21)
        Label9.TabIndex = 14
        Label9.Text = "Name File Trading"
        ' 
        ' tb_setDir_SalvaAlenaemnto
        ' 
        tb_setDir_SalvaAlenaemnto.Location = New Point(3, 136)
        tb_setDir_SalvaAlenaemnto.Name = "tb_setDir_SalvaAlenaemnto"
        tb_setDir_SalvaAlenaemnto.Size = New Size(623, 29)
        tb_setDir_SalvaAlenaemnto.TabIndex = 13
        ' 
        ' tb_DirAdestra
        ' 
        tb_DirAdestra.Location = New Point(9, 51)
        tb_DirAdestra.Name = "tb_DirAdestra"
        tb_DirAdestra.Size = New Size(623, 29)
        tb_DirAdestra.TabIndex = 13
        ' 
        ' bnt_setDir_Alenamento
        ' 
        bnt_setDir_Alenamento.Location = New Point(530, 91)
        bnt_setDir_Alenamento.Name = "bnt_setDir_Alenamento"
        bnt_setDir_Alenamento.Size = New Size(99, 39)
        bnt_setDir_Alenamento.TabIndex = 12
        bnt_setDir_Alenamento.Text = "Set Dir"
        bnt_setDir_Alenamento.UseVisualStyleBackColor = True
        ' 
        ' bnt_SetDir_Adestra
        ' 
        bnt_SetDir_Adestra.Location = New Point(530, 9)
        bnt_SetDir_Adestra.Name = "bnt_SetDir_Adestra"
        bnt_SetDir_Adestra.Size = New Size(99, 35)
        bnt_SetDir_Adestra.TabIndex = 12
        bnt_SetDir_Adestra.Text = "Set Dir"
        bnt_SetDir_Adestra.UseVisualStyleBackColor = True
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(8, 105)
        Label7.Name = "Label7"
        Label7.Size = New Size(124, 21)
        Label7.TabIndex = 8
        Label7.Text = "Dir Save Tradign"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(6, 14)
        Label6.Name = "Label6"
        Label6.Size = New Size(128, 21)
        Label6.TabIndex = 8
        Label6.Text = "Set Dir Trading  *"
        ' 
        ' TabImgCalsifica
        ' 
        TabImgCalsifica.Controls.Add(cb_cancellaFileOrignale)
        TabImgCalsifica.Controls.Add(tb_setDir_Output)
        TabImgCalsifica.Controls.Add(Label13)
        TabImgCalsifica.Controls.Add(bnt_setDir_Output)
        TabImgCalsifica.Controls.Add(bnt_setDir_ImgDaClasificare)
        TabImgCalsifica.Controls.Add(tb_setDir_ImgDaClasifirare)
        TabImgCalsifica.Controls.Add(Label8)
        TabImgCalsifica.Location = New Point(4, 30)
        TabImgCalsifica.Name = "TabImgCalsifica"
        TabImgCalsifica.Padding = New Padding(3)
        TabImgCalsifica.Size = New Size(649, 256)
        TabImgCalsifica.TabIndex = 2
        TabImgCalsifica.Text = "Set Img Input"
        TabImgCalsifica.UseVisualStyleBackColor = True
        ' 
        ' cb_cancellaFileOrignale
        ' 
        cb_cancellaFileOrignale.AutoSize = True
        cb_cancellaFileOrignale.Location = New Point(6, 198)
        cb_cancellaFileOrignale.Name = "cb_cancellaFileOrignale"
        cb_cancellaFileOrignale.Size = New Size(167, 25)
        cb_cancellaFileOrignale.TabIndex = 5
        cb_cancellaFileOrignale.Text = "Delte Foto (in Input)"
        cb_cancellaFileOrignale.UseVisualStyleBackColor = True
        ' 
        ' tb_setDir_Output
        ' 
        tb_setDir_Output.Location = New Point(6, 158)
        tb_setDir_Output.Name = "tb_setDir_Output"
        tb_setDir_Output.Size = New Size(623, 29)
        tb_setDir_Output.TabIndex = 4
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(3, 128)
        Label13.Name = "Label13"
        Label13.Size = New Size(170, 21)
        Label13.TabIndex = 3
        Label13.Text = "Set Dir IMG - OUTPUT*"
        ' 
        ' bnt_setDir_Output
        ' 
        bnt_setDir_Output.Location = New Point(528, 122)
        bnt_setDir_Output.Name = "bnt_setDir_Output"
        bnt_setDir_Output.Size = New Size(101, 32)
        bnt_setDir_Output.TabIndex = 2
        bnt_setDir_Output.Text = "Set Dir"
        bnt_setDir_Output.UseVisualStyleBackColor = True
        ' 
        ' bnt_setDir_ImgDaClasificare
        ' 
        bnt_setDir_ImgDaClasificare.Location = New Point(528, 10)
        bnt_setDir_ImgDaClasificare.Name = "bnt_setDir_ImgDaClasificare"
        bnt_setDir_ImgDaClasificare.Size = New Size(101, 47)
        bnt_setDir_ImgDaClasificare.TabIndex = 2
        bnt_setDir_ImgDaClasificare.Text = "Set Dir"
        bnt_setDir_ImgDaClasificare.UseVisualStyleBackColor = True
        ' 
        ' tb_setDir_ImgDaClasifirare
        ' 
        tb_setDir_ImgDaClasifirare.Location = New Point(3, 63)
        tb_setDir_ImgDaClasifirare.Name = "tb_setDir_ImgDaClasifirare"
        tb_setDir_ImgDaClasifirare.Size = New Size(623, 29)
        tb_setDir_ImgDaClasifirare.TabIndex = 1
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(6, 29)
        Label8.Name = "Label8"
        Label8.Size = New Size(159, 21)
        Label8.TabIndex = 0
        Label8.Text = "Set Dir IMG - INPUT *"
        ' 
        ' l_desc1
        ' 
        l_desc1.Location = New Point(7, 302)
        l_desc1.Name = "l_desc1"
        l_desc1.Size = New Size(653, 21)
        l_desc1.TabIndex = 14
        l_desc1.Text = "--"
        ' 
        ' pb_1
        ' 
        pb_1.Location = New Point(7, 345)
        pb_1.Name = "pb_1"
        pb_1.Size = New Size(653, 23)
        pb_1.TabIndex = 15
        ' 
        ' pb_2
        ' 
        pb_2.Location = New Point(7, 424)
        pb_2.Name = "pb_2"
        pb_2.Size = New Size(653, 23)
        pb_2.TabIndex = 15
        ' 
        ' l_desc2
        ' 
        l_desc2.Location = New Point(7, 394)
        l_desc2.Name = "l_desc2"
        l_desc2.Size = New Size(653, 26)
        l_desc2.TabIndex = 14
        l_desc2.Text = "--"
        ' 
        ' l_pb2
        ' 
        l_pb2.Location = New Point(539, 450)
        l_pb2.Name = "l_pb2"
        l_pb2.Size = New Size(114, 29)
        l_pb2.TabIndex = 16
        l_pb2.Text = "0 di 0"
        l_pb2.TextAlign = ContentAlignment.TopRight
        ' 
        ' l_pb1
        ' 
        l_pb1.Location = New Point(539, 372)
        l_pb1.Name = "l_pb1"
        l_pb1.Size = New Size(114, 25)
        l_pb1.TabIndex = 16
        l_pb1.Text = "0 di 0"
        l_pb1.TextAlign = ContentAlignment.TopRight
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.ForeColor = Color.Blue
        Label1.Location = New Point(672, 11)
        Label1.Name = "Label1"
        Label1.Size = New Size(79, 21)
        Label1.TabIndex = 17
        Label1.Text = "* = Pflicht"
        ' 
        ' INDEX
        ' 
        AutoScaleDimensions = New SizeF(9F, 21F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1144, 598)
        Controls.Add(Label1)
        Controls.Add(l_pb1)
        Controls.Add(l_pb2)
        Controls.Add(pb_2)
        Controls.Add(pb_1)
        Controls.Add(l_desc2)
        Controls.Add(l_desc1)
        Controls.Add(TabConteiner)
        Controls.Add(Label5)
        Controls.Add(l_desDebug)
        Controls.Add(tb_debug)
        Controls.Add(bnt_Avvia)
        Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.Fixed3D
        Margin = New Padding(4)
        MaximizeBox = False
        MinimizeBox = False
        Name = "INDEX"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Ordina Foto"
        CType(BindingSource1, ComponentModel.ISupportInitialize).EndInit()
        TabConteiner.ResumeLayout(False)
        TabGiaAlenato.ResumeLayout(False)
        TabGiaAlenato.PerformLayout()
        TabDaAlenare.ResumeLayout(False)
        TabDaAlenare.PerformLayout()
        TabImgCalsifica.ResumeLayout(False)
        TabImgCalsifica.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents bnt_Avvia As Button
    Friend WithEvents tb_debug As TextBox
    Friend WithEvents l_desDebug As Label
    Friend WithEvents OFD As OpenFileDialog
    Friend WithEvents Label5 As Label
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents FBD As FolderBrowserDialog
    Friend WithEvents TabConteiner As TabControl
    Friend WithEvents TabGiaAlenato As TabPage
    Friend WithEvents TabDaAlenare As TabPage
    Friend WithEvents bnt_setFiel_Categorie As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents tb_setFile_Categorie As TextBox
    Friend WithEvents tb_setFile_Bin As TextBox
    Friend WithEvents bnt_setCartella_bin As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents tb_setDir_SalvaAlenaemnto As TextBox
    Friend WithEvents tb_DirAdestra As TextBox
    Friend WithEvents bnt_setDir_Alenamento As Button
    Friend WithEvents bnt_SetDir_Adestra As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents l_desc1 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents tb_setFile_NomeCategoria As TextBox
    Friend WithEvents tb_setFile_NomeAadestramento_BIN As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents pb_1 As ProgressBar
    Friend WithEvents pb_2 As ProgressBar
    Friend WithEvents l_desc2 As Label
    Friend WithEvents l_pb2 As Label
    Friend WithEvents l_pb1 As Label
    Friend WithEvents TabImgCalsifica As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents bnt_setDir_ImgDaClasificare As Button
    Friend WithEvents tb_setDir_ImgDaClasifirare As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents tb_setDir_Output As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents bnt_setDir_Output As Button
    Friend WithEvents cb_cancellaFileOrignale As CheckBox

End Class
