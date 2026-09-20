<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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


    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TabCtrl_Option = New System.Windows.Forms.TabControl()
        Me.TabPage_Manual = New System.Windows.Forms.TabPage()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusStripLbl_Modo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.grp_PosicaoAtual = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_ManPosZ = New System.Windows.Forms.TextBox()
        Me.txt_ManPosY = New System.Windows.Forms.TextBox()
        Me.txt_ManPosX = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.grp_MoverPosicao = New System.Windows.Forms.GroupBox()
        Me.btn_ManSet = New System.Windows.Forms.Button()
        Me.btn_ManMovToPos = New System.Windows.Forms.Button()
        Me.lbl_PosY = New System.Windows.Forms.Label()
        Me.lbl_PosX = New System.Windows.Forms.Label()
        Me.lbl_PosZ = New System.Windows.Forms.Label()
        Me.txt_PosManEixoZ = New System.Windows.Forms.TextBox()
        Me.txt_PosManEixoY = New System.Windows.Forms.TextBox()
        Me.txt_PosManEixoX = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.grp_ControloManual = New System.Windows.Forms.GroupBox()
        Me.txt_ManFeedRate = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_ManXmenos = New System.Windows.Forms.Button()
        Me.btn_ManZmenos = New System.Windows.Forms.Button()
        Me.btn_ManYmenos = New System.Windows.Forms.Button()
        Me.lbl_Velocidade = New System.Windows.Forms.Label()
        Me.btn_ManZmais = New System.Windows.Forms.Button()
        Me.btn_ManYmais = New System.Windows.Forms.Button()
        Me.trackBar_ManFeed = New System.Windows.Forms.TrackBar()
        Me.btn_ManXmais = New System.Windows.Forms.Button()
        Me.TabPage_Automatico = New System.Windows.Forms.TabPage()
        Me.TabControl_AutoModos = New System.Windows.Forms.TabControl()
        Me.TabPage_CorteRetangular = New System.Windows.Forms.TabPage()
        Me.grp_ControloProgramaAuto = New System.Windows.Forms.GroupBox()
        Me.txt_ManCodG = New System.Windows.Forms.TextBox()
        Me.btn_ManRun = New System.Windows.Forms.Button()
        Me.btn_ManValidCodeG = New System.Windows.Forms.Button()
        Me.txt_AutF = New System.Windows.Forms.TextBox()
        Me.txt_AutS = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txt_diamfresa = New System.Windows.Forms.TextBox()
        Me.txt_increz = New System.Windows.Forms.TextBox()
        Me.txt_AutZ = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txt_Zinterior = New System.Windows.Forms.TextBox()
        Me.txt_Yinterior = New System.Windows.Forms.TextBox()
        Me.txt_Xinterior = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_Zexterior = New System.Windows.Forms.TextBox()
        Me.txt_Yexterior = New System.Windows.Forms.TextBox()
        Me.txt_Xexterior = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.grp_PosicaoEixos = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_PosAutEixoZ = New System.Windows.Forms.TextBox()
        Me.txt_PosAutEixoY = New System.Windows.Forms.TextBox()
        Me.txt_PosAutEixoX = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TabPage_CorteCircular = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txt_raioCirculo = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txt_ManCodGCircular = New System.Windows.Forms.TextBox()
        Me.btn_ManRunCircular = New System.Windows.Forms.Button()
        Me.btn_ManValidCodeGCircular = New System.Windows.Forms.Button()
        Me.txt_AutFCricular = New System.Windows.Forms.TextBox()
        Me.txt_AutSCircular = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txt_diamfresaCricular = New System.Windows.Forms.TextBox()
        Me.txt_increzCircular = New System.Windows.Forms.TextBox()
        Me.txt_AutZCircular = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txt_ZinteriorCricular = New System.Windows.Forms.TextBox()
        Me.txt_YinteriorCircular = New System.Windows.Forms.TextBox()
        Me.txt_XinteriorCircular = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txt_ZexteriorCircular = New System.Windows.Forms.TextBox()
        Me.txt_YexteriorCircular = New System.Windows.Forms.TextBox()
        Me.txt_XexteriorCircular = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.TextBox18 = New System.Windows.Forms.TextBox()
        Me.TextBox22 = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txt_PosAutEixoZCircular = New System.Windows.Forms.TextBox()
        Me.txt_PosAutEixoYCircular = New System.Windows.Forms.TextBox()
        Me.txt_PosAutEixoXCircular = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.TabPage_CorteL = New System.Windows.Forms.TabPage()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.txt_ManCodG_L = New System.Windows.Forms.TextBox()
        Me.btn_ManRun_L = New System.Windows.Forms.Button()
        Me.btn_ManValidCodeG_L = New System.Windows.Forms.Button()
        Me.txt_AutF_L = New System.Windows.Forms.TextBox()
        Me.txt_AutS_L = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.txt_diamfresa_L = New System.Windows.Forms.TextBox()
        Me.txt_increz_L = New System.Windows.Forms.TextBox()
        Me.txt_AutZ_L = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.txt_Zinterior_L = New System.Windows.Forms.TextBox()
        Me.txt_AlturaPerna_L = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.txt_Zexterior_L = New System.Windows.Forms.TextBox()
        Me.txt_Yexterior_L = New System.Windows.Forms.TextBox()
        Me.txt_Xexterior_L = New System.Windows.Forms.TextBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.TextBox20 = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.txt_PosAutEixoZ_L = New System.Windows.Forms.TextBox()
        Me.txt_PosAutEixoY_L = New System.Windows.Forms.TextBox()
        Me.txt_PosAutEixoX_L = New System.Windows.Forms.TextBox()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.tmr_match3 = New System.Windows.Forms.Timer(Me.components)
        Me.Label63 = New System.Windows.Forms.Label()
        Me.txt_CompBase_L = New System.Windows.Forms.TextBox()
        Me.txt_Espessura_L = New System.Windows.Forms.TextBox()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.TabCtrl_Option.SuspendLayout()
        Me.TabPage_Manual.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.grp_PosicaoAtual.SuspendLayout()
        Me.grp_MoverPosicao.SuspendLayout()
        Me.grp_ControloManual.SuspendLayout()
        CType(Me.trackBar_ManFeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage_Automatico.SuspendLayout()
        Me.TabControl_AutoModos.SuspendLayout()
        Me.TabPage_CorteRetangular.SuspendLayout()
        Me.grp_ControloProgramaAuto.SuspendLayout()
        Me.grp_PosicaoEixos.SuspendLayout()
        Me.TabPage_CorteCircular.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage_CorteL.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabCtrl_Option
        '
        Me.TabCtrl_Option.Controls.Add(Me.TabPage_Manual)
        Me.TabCtrl_Option.Controls.Add(Me.TabPage_Automatico)
        Me.TabCtrl_Option.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabCtrl_Option.ItemSize = New System.Drawing.Size(80, 20)
        Me.TabCtrl_Option.Location = New System.Drawing.Point(0, 0)
        Me.TabCtrl_Option.Name = "TabCtrl_Option"
        Me.TabCtrl_Option.SelectedIndex = 0
        Me.TabCtrl_Option.Size = New System.Drawing.Size(1284, 663)
        Me.TabCtrl_Option.TabIndex = 0
        '
        'TabPage_Manual
        '
        Me.TabPage_Manual.Controls.Add(Me.StatusStrip1)
        Me.TabPage_Manual.Controls.Add(Me.TextBox3)
        Me.TabPage_Manual.Controls.Add(Me.grp_PosicaoAtual)
        Me.TabPage_Manual.Controls.Add(Me.TextBox2)
        Me.TabPage_Manual.Controls.Add(Me.grp_MoverPosicao)
        Me.TabPage_Manual.Controls.Add(Me.TextBox1)
        Me.TabPage_Manual.Controls.Add(Me.grp_ControloManual)
        Me.TabPage_Manual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage_Manual.Location = New System.Drawing.Point(4, 24)
        Me.TabPage_Manual.Name = "TabPage_Manual"
        Me.TabPage_Manual.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Manual.Size = New System.Drawing.Size(1276, 635)
        Me.TabPage_Manual.TabIndex = 0
        Me.TabPage_Manual.Text = "Modo Manual"
        Me.TabPage_Manual.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusStripLbl_Modo})
        Me.StatusStrip1.Location = New System.Drawing.Point(3, 610)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1270, 22)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusStripLbl_Modo
        '
        Me.StatusStripLbl_Modo.Name = "StatusStripLbl_Modo"
        Me.StatusStripLbl_Modo.Size = New System.Drawing.Size(16, 17)
        Me.StatusStripLbl_Modo.Text = "..."
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.SteelBlue
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox3.Location = New System.Drawing.Point(853, 6)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(400, 22)
        Me.TextBox3.TabIndex = 5
        Me.TextBox3.Text = "Posição Atual"
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'grp_PosicaoAtual
        '
        Me.grp_PosicaoAtual.BackColor = System.Drawing.Color.AliceBlue
        Me.grp_PosicaoAtual.Controls.Add(Me.Label2)
        Me.grp_PosicaoAtual.Controls.Add(Me.Label4)
        Me.grp_PosicaoAtual.Controls.Add(Me.Label5)
        Me.grp_PosicaoAtual.Controls.Add(Me.txt_ManPosZ)
        Me.grp_PosicaoAtual.Controls.Add(Me.txt_ManPosY)
        Me.grp_PosicaoAtual.Controls.Add(Me.txt_ManPosX)
        Me.grp_PosicaoAtual.Controls.Add(Me.Label6)
        Me.grp_PosicaoAtual.Location = New System.Drawing.Point(853, 32)
        Me.grp_PosicaoAtual.Name = "grp_PosicaoAtual"
        Me.grp_PosicaoAtual.Size = New System.Drawing.Size(400, 189)
        Me.grp_PosicaoAtual.TabIndex = 4
        Me.grp_PosicaoAtual.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(78, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 15)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Eixo Y:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(77, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 15)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Eixo X:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(78, 145)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 15)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Eixo Z:"
        '
        'txt_ManPosZ
        '
        Me.txt_ManPosZ.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_ManPosZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ManPosZ.Enabled = False
        Me.txt_ManPosZ.Location = New System.Drawing.Point(158, 143)
        Me.txt_ManPosZ.Name = "txt_ManPosZ"
        Me.txt_ManPosZ.Size = New System.Drawing.Size(144, 20)
        Me.txt_ManPosZ.TabIndex = 9
        Me.txt_ManPosZ.Text = "0.0"
        Me.txt_ManPosZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_ManPosY
        '
        Me.txt_ManPosY.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_ManPosY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ManPosY.Enabled = False
        Me.txt_ManPosY.Location = New System.Drawing.Point(158, 107)
        Me.txt_ManPosY.Name = "txt_ManPosY"
        Me.txt_ManPosY.Size = New System.Drawing.Size(144, 20)
        Me.txt_ManPosY.TabIndex = 8
        Me.txt_ManPosY.Text = "0.0"
        Me.txt_ManPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_ManPosX
        '
        Me.txt_ManPosX.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_ManPosX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ManPosX.Enabled = False
        Me.txt_ManPosX.Location = New System.Drawing.Point(158, 68)
        Me.txt_ManPosX.Name = "txt_ManPosX"
        Me.txt_ManPosX.Size = New System.Drawing.Size(144, 20)
        Me.txt_ManPosX.TabIndex = 7
        Me.txt_ManPosX.Text = "0.0"
        Me.txt_ManPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label6.Location = New System.Drawing.Point(155, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 15)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Posição (mm)"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.SteelBlue
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox2.Location = New System.Drawing.Point(438, 6)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(400, 22)
        Me.TextBox2.TabIndex = 3
        Me.TextBox2.Text = "Posicionamento dos Eixos"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'grp_MoverPosicao
        '
        Me.grp_MoverPosicao.BackColor = System.Drawing.Color.AliceBlue
        Me.grp_MoverPosicao.Controls.Add(Me.btn_ManSet)
        Me.grp_MoverPosicao.Controls.Add(Me.btn_ManMovToPos)
        Me.grp_MoverPosicao.Controls.Add(Me.lbl_PosY)
        Me.grp_MoverPosicao.Controls.Add(Me.lbl_PosX)
        Me.grp_MoverPosicao.Controls.Add(Me.lbl_PosZ)
        Me.grp_MoverPosicao.Controls.Add(Me.txt_PosManEixoZ)
        Me.grp_MoverPosicao.Controls.Add(Me.txt_PosManEixoY)
        Me.grp_MoverPosicao.Controls.Add(Me.txt_PosManEixoX)
        Me.grp_MoverPosicao.Controls.Add(Me.Label3)
        Me.grp_MoverPosicao.Location = New System.Drawing.Point(438, 32)
        Me.grp_MoverPosicao.Name = "grp_MoverPosicao"
        Me.grp_MoverPosicao.Size = New System.Drawing.Size(400, 294)
        Me.grp_MoverPosicao.TabIndex = 2
        Me.grp_MoverPosicao.TabStop = False
        '
        'btn_ManSet
        '
        Me.btn_ManSet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ManSet.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btn_ManSet.Location = New System.Drawing.Point(57, 203)
        Me.btn_ManSet.Name = "btn_ManSet"
        Me.btn_ManSet.Size = New System.Drawing.Size(140, 40)
        Me.btn_ManSet.TabIndex = 14
        Me.btn_ManSet.Text = "Zero Máquina"
        Me.btn_ManSet.UseVisualStyleBackColor = True
        '
        'btn_ManMovToPos
        '
        Me.btn_ManMovToPos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ManMovToPos.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btn_ManMovToPos.Location = New System.Drawing.Point(219, 203)
        Me.btn_ManMovToPos.Name = "btn_ManMovToPos"
        Me.btn_ManMovToPos.Size = New System.Drawing.Size(140, 40)
        Me.btn_ManMovToPos.TabIndex = 13
        Me.btn_ManMovToPos.Text = "Inserir Eixos"
        Me.btn_ManMovToPos.UseVisualStyleBackColor = True
        '
        'lbl_PosY
        '
        Me.lbl_PosY.AutoSize = True
        Me.lbl_PosY.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PosY.Location = New System.Drawing.Point(78, 109)
        Me.lbl_PosY.Name = "lbl_PosY"
        Me.lbl_PosY.Size = New System.Drawing.Size(44, 15)
        Me.lbl_PosY.TabIndex = 12
        Me.lbl_PosY.Text = "Eixo Y:"
        '
        'lbl_PosX
        '
        Me.lbl_PosX.AutoSize = True
        Me.lbl_PosX.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PosX.Location = New System.Drawing.Point(77, 70)
        Me.lbl_PosX.Name = "lbl_PosX"
        Me.lbl_PosX.Size = New System.Drawing.Size(45, 15)
        Me.lbl_PosX.TabIndex = 11
        Me.lbl_PosX.Text = "Eixo X:"
        '
        'lbl_PosZ
        '
        Me.lbl_PosZ.AutoSize = True
        Me.lbl_PosZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_PosZ.Location = New System.Drawing.Point(78, 145)
        Me.lbl_PosZ.Name = "lbl_PosZ"
        Me.lbl_PosZ.Size = New System.Drawing.Size(44, 15)
        Me.lbl_PosZ.TabIndex = 10
        Me.lbl_PosZ.Text = "Eixo Z:"
        '
        'txt_PosManEixoZ
        '
        Me.txt_PosManEixoZ.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_PosManEixoZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_PosManEixoZ.Location = New System.Drawing.Point(158, 143)
        Me.txt_PosManEixoZ.Name = "txt_PosManEixoZ"
        Me.txt_PosManEixoZ.Size = New System.Drawing.Size(144, 20)
        Me.txt_PosManEixoZ.TabIndex = 9
        Me.txt_PosManEixoZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_PosManEixoY
        '
        Me.txt_PosManEixoY.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_PosManEixoY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_PosManEixoY.Location = New System.Drawing.Point(158, 107)
        Me.txt_PosManEixoY.Name = "txt_PosManEixoY"
        Me.txt_PosManEixoY.Size = New System.Drawing.Size(144, 20)
        Me.txt_PosManEixoY.TabIndex = 8
        Me.txt_PosManEixoY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_PosManEixoX
        '
        Me.txt_PosManEixoX.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_PosManEixoX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_PosManEixoX.Location = New System.Drawing.Point(158, 68)
        Me.txt_PosManEixoX.Name = "txt_PosManEixoX"
        Me.txt_PosManEixoX.Size = New System.Drawing.Size(144, 20)
        Me.txt_PosManEixoX.TabIndex = 7
        Me.txt_PosManEixoX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label3.Location = New System.Drawing.Point(155, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Posição (mm)"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.SteelBlue
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox1.Location = New System.Drawing.Point(23, 6)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(400, 22)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "Velocidade de Deslocamento"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'grp_ControloManual
        '
        Me.grp_ControloManual.BackColor = System.Drawing.Color.AliceBlue
        Me.grp_ControloManual.Controls.Add(Me.txt_ManFeedRate)
        Me.grp_ControloManual.Controls.Add(Me.Label1)
        Me.grp_ControloManual.Controls.Add(Me.btn_ManXmenos)
        Me.grp_ControloManual.Controls.Add(Me.btn_ManZmenos)
        Me.grp_ControloManual.Controls.Add(Me.btn_ManYmenos)
        Me.grp_ControloManual.Controls.Add(Me.lbl_Velocidade)
        Me.grp_ControloManual.Controls.Add(Me.btn_ManZmais)
        Me.grp_ControloManual.Controls.Add(Me.btn_ManYmais)
        Me.grp_ControloManual.Controls.Add(Me.trackBar_ManFeed)
        Me.grp_ControloManual.Controls.Add(Me.btn_ManXmais)
        Me.grp_ControloManual.Location = New System.Drawing.Point(23, 32)
        Me.grp_ControloManual.Name = "grp_ControloManual"
        Me.grp_ControloManual.Size = New System.Drawing.Size(400, 311)
        Me.grp_ControloManual.TabIndex = 0
        Me.grp_ControloManual.TabStop = False
        '
        'txt_ManFeedRate
        '
        Me.txt_ManFeedRate.Location = New System.Drawing.Point(169, 94)
        Me.txt_ManFeedRate.Name = "txt_ManFeedRate"
        Me.txt_ManFeedRate.Size = New System.Drawing.Size(52, 20)
        Me.txt_ManFeedRate.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label1.Location = New System.Drawing.Point(97, 128)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(204, 15)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Deslocamento por incremento:"
        '
        'btn_ManXmenos
        '
        Me.btn_ManXmenos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ManXmenos.Location = New System.Drawing.Point(251, 159)
        Me.btn_ManXmenos.Name = "btn_ManXmenos"
        Me.btn_ManXmenos.Size = New System.Drawing.Size(100, 40)
        Me.btn_ManXmenos.TabIndex = 9
        Me.btn_ManXmenos.Text = "X -" & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_ManXmenos.UseVisualStyleBackColor = True
        '
        'btn_ManZmenos
        '
        Me.btn_ManZmenos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ManZmenos.Location = New System.Drawing.Point(251, 251)
        Me.btn_ManZmenos.Name = "btn_ManZmenos"
        Me.btn_ManZmenos.Size = New System.Drawing.Size(100, 40)
        Me.btn_ManZmenos.TabIndex = 8
        Me.btn_ManZmenos.Text = "Z- " & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_ManZmenos.UseVisualStyleBackColor = True
        '
        'btn_ManYmenos
        '
        Me.btn_ManYmenos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ManYmenos.Location = New System.Drawing.Point(251, 205)
        Me.btn_ManYmenos.Name = "btn_ManYmenos"
        Me.btn_ManYmenos.Size = New System.Drawing.Size(100, 40)
        Me.btn_ManYmenos.TabIndex = 7
        Me.btn_ManYmenos.Text = "Y -" & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_ManYmenos.UseVisualStyleBackColor = True
        '
        'lbl_Velocidade
        '
        Me.lbl_Velocidade.AutoSize = True
        Me.lbl_Velocidade.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Velocidade.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.lbl_Velocidade.Location = New System.Drawing.Point(129, 16)
        Me.lbl_Velocidade.Name = "lbl_Velocidade"
        Me.lbl_Velocidade.Size = New System.Drawing.Size(128, 15)
        Me.lbl_Velocidade.TabIndex = 6
        Me.lbl_Velocidade.Text = "Velocidade (mm/min):"
        '
        'btn_ManZmais
        '
        Me.btn_ManZmais.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ManZmais.Location = New System.Drawing.Point(48, 251)
        Me.btn_ManZmais.Name = "btn_ManZmais"
        Me.btn_ManZmais.Size = New System.Drawing.Size(100, 40)
        Me.btn_ManZmais.TabIndex = 5
        Me.btn_ManZmais.Text = "Z +"
        Me.btn_ManZmais.UseVisualStyleBackColor = True
        '
        'btn_ManYmais
        '
        Me.btn_ManYmais.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ManYmais.Location = New System.Drawing.Point(48, 205)
        Me.btn_ManYmais.Name = "btn_ManYmais"
        Me.btn_ManYmais.Size = New System.Drawing.Size(100, 40)
        Me.btn_ManYmais.TabIndex = 4
        Me.btn_ManYmais.Text = "Y +"
        Me.btn_ManYmais.UseVisualStyleBackColor = True
        '
        'trackBar_ManFeed
        '
        Me.trackBar_ManFeed.Location = New System.Drawing.Point(48, 43)
        Me.trackBar_ManFeed.Maximum = 100
        Me.trackBar_ManFeed.Name = "trackBar_ManFeed"
        Me.trackBar_ManFeed.Size = New System.Drawing.Size(303, 45)
        Me.trackBar_ManFeed.TabIndex = 3
        '
        'btn_ManXmais
        '
        Me.btn_ManXmais.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ManXmais.Location = New System.Drawing.Point(48, 159)
        Me.btn_ManXmais.Name = "btn_ManXmais"
        Me.btn_ManXmais.Size = New System.Drawing.Size(100, 40)
        Me.btn_ManXmais.TabIndex = 0
        Me.btn_ManXmais.Text = "X + " & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btn_ManXmais.UseVisualStyleBackColor = True
        '
        'TabPage_Automatico
        '
        Me.TabPage_Automatico.Controls.Add(Me.TabControl_AutoModos)
        Me.TabPage_Automatico.Location = New System.Drawing.Point(4, 24)
        Me.TabPage_Automatico.Name = "TabPage_Automatico"
        Me.TabPage_Automatico.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Automatico.Size = New System.Drawing.Size(1276, 635)
        Me.TabPage_Automatico.TabIndex = 1
        Me.TabPage_Automatico.Text = "Modo Automático"
        Me.TabPage_Automatico.UseVisualStyleBackColor = True
        '
        'TabControl_AutoModos
        '
        Me.TabControl_AutoModos.Controls.Add(Me.TabPage_CorteRetangular)
        Me.TabControl_AutoModos.Controls.Add(Me.TabPage_CorteCircular)
        Me.TabControl_AutoModos.Controls.Add(Me.TabPage_CorteL)
        Me.TabControl_AutoModos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl_AutoModos.Location = New System.Drawing.Point(3, 3)
        Me.TabControl_AutoModos.Name = "TabControl_AutoModos"
        Me.TabControl_AutoModos.SelectedIndex = 0
        Me.TabControl_AutoModos.Size = New System.Drawing.Size(1270, 629)
        Me.TabControl_AutoModos.TabIndex = 0
        '
        'TabPage_CorteRetangular
        '
        Me.TabPage_CorteRetangular.Controls.Add(Me.grp_ControloProgramaAuto)
        Me.TabPage_CorteRetangular.Controls.Add(Me.TextBox8)
        Me.TabPage_CorteRetangular.Controls.Add(Me.TextBox4)
        Me.TabPage_CorteRetangular.Controls.Add(Me.grp_PosicaoEixos)
        Me.TabPage_CorteRetangular.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_CorteRetangular.Name = "TabPage_CorteRetangular"
        Me.TabPage_CorteRetangular.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_CorteRetangular.Size = New System.Drawing.Size(1262, 603)
        Me.TabPage_CorteRetangular.TabIndex = 0
        Me.TabPage_CorteRetangular.Text = "Corte Retangular"
        Me.TabPage_CorteRetangular.UseVisualStyleBackColor = True
        '
        'grp_ControloProgramaAuto
        '
        Me.grp_ControloProgramaAuto.BackColor = System.Drawing.Color.AliceBlue
        Me.grp_ControloProgramaAuto.Controls.Add(Me.txt_ManCodG)
        Me.grp_ControloProgramaAuto.Controls.Add(Me.btn_ManRun)
        Me.grp_ControloProgramaAuto.Controls.Add(Me.btn_ManValidCodeG)
        Me.grp_ControloProgramaAuto.Controls.Add(Me.txt_AutF)
        Me.grp_ControloProgramaAuto.Controls.Add(Me.txt_AutS)
        Me.grp_ControloProgramaAuto.Controls.Add(Me.Label24)
        Me.grp_ControloProgramaAuto.Controls.Add(Me.Label23)
        Me.grp_ControloProgramaAuto.Controls.Add(Me.Label22)
        Me.grp_ControloProgramaAuto.Controls.Add(Me.txt_diamfresa)
        Me.grp_ControloProgramaAuto.Controls.Add(Me.txt_increz)
        Me.grp_ControloProgramaAuto.Controls.Add(Me.txt_AutZ)
        Me.grp_ControloProgramaAuto.Controls.Add(Me.Label21)
        Me.grp_ControloProgramaAuto.Controls.Add(Me.Label20)
        Me.grp_ControloProgramaAuto.Controls.Add(Me.Label17)
        Me.grp_ControloProgramaAuto.Controls.Add(Me.Label18)
        Me.grp_ControloProgramaAuto.Controls.Add(Me.Label19)
        Me.grp_ControloProgramaAuto.Controls.Add(Me.txt_Zinterior)
        Me.grp_ControloProgramaAuto.Controls.Add(Me.txt_Yinterior)
        Me.grp_ControloProgramaAuto.Controls.Add(Me.txt_Xinterior)
        Me.grp_ControloProgramaAuto.Controls.Add(Me.Label16)
        Me.grp_ControloProgramaAuto.Controls.Add(Me.Label15)
        Me.grp_ControloProgramaAuto.Controls.Add(Me.Label11)
        Me.grp_ControloProgramaAuto.Controls.Add(Me.Label12)
        Me.grp_ControloProgramaAuto.Controls.Add(Me.Label13)
        Me.grp_ControloProgramaAuto.Controls.Add(Me.txt_Zexterior)
        Me.grp_ControloProgramaAuto.Controls.Add(Me.txt_Yexterior)
        Me.grp_ControloProgramaAuto.Controls.Add(Me.txt_Xexterior)
        Me.grp_ControloProgramaAuto.Controls.Add(Me.Label14)
        Me.grp_ControloProgramaAuto.Location = New System.Drawing.Point(0, 236)
        Me.grp_ControloProgramaAuto.Name = "grp_ControloProgramaAuto"
        Me.grp_ControloProgramaAuto.Size = New System.Drawing.Size(1262, 371)
        Me.grp_ControloProgramaAuto.TabIndex = 15
        Me.grp_ControloProgramaAuto.TabStop = False
        '
        'txt_ManCodG
        '
        Me.txt_ManCodG.BackColor = System.Drawing.Color.LightCyan
        Me.txt_ManCodG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ManCodG.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ManCodG.Location = New System.Drawing.Point(510, 33)
        Me.txt_ManCodG.Multiline = True
        Me.txt_ManCodG.Name = "txt_ManCodG"
        Me.txt_ManCodG.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_ManCodG.Size = New System.Drawing.Size(730, 250)
        Me.txt_ManCodG.TabIndex = 33
        '
        'btn_ManRun
        '
        Me.btn_ManRun.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ManRun.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btn_ManRun.Location = New System.Drawing.Point(1081, 293)
        Me.btn_ManRun.Name = "btn_ManRun"
        Me.btn_ManRun.Size = New System.Drawing.Size(140, 40)
        Me.btn_ManRun.TabIndex = 32
        Me.btn_ManRun.Text = "Run"
        Me.btn_ManRun.UseVisualStyleBackColor = True
        '
        'btn_ManValidCodeG
        '
        Me.btn_ManValidCodeG.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ManValidCodeG.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btn_ManValidCodeG.Location = New System.Drawing.Point(338, 291)
        Me.btn_ManValidCodeG.Name = "btn_ManValidCodeG"
        Me.btn_ManValidCodeG.Size = New System.Drawing.Size(140, 40)
        Me.btn_ManValidCodeG.TabIndex = 31
        Me.btn_ManValidCodeG.Text = "Validar (G Code)"
        Me.btn_ManValidCodeG.UseVisualStyleBackColor = True
        '
        'txt_AutF
        '
        Me.txt_AutF.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_AutF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_AutF.Location = New System.Drawing.Point(368, 205)
        Me.txt_AutF.Name = "txt_AutF"
        Me.txt_AutF.Size = New System.Drawing.Size(110, 20)
        Me.txt_AutF.TabIndex = 30
        Me.txt_AutF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_AutS
        '
        Me.txt_AutS.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_AutS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_AutS.Location = New System.Drawing.Point(368, 172)
        Me.txt_AutS.Name = "txt_AutS"
        Me.txt_AutS.Size = New System.Drawing.Size(110, 20)
        Me.txt_AutS.TabIndex = 29
        Me.txt_AutS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(236, 207)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(124, 15)
        Me.Label24.TabIndex = 28
        Me.Label24.Text = "Feed Rate (mm/min):"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(236, 174)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(91, 15)
        Me.Label23.TabIndex = 27
        Me.Label23.Text = "Spindle (RPM):"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label22.Location = New System.Drawing.Point(236, 33)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(156, 15)
        Me.Label22.TabIndex = 26
        Me.Label22.Text = "Ferramenta e Processo"
        '
        'txt_diamfresa
        '
        Me.txt_diamfresa.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_diamfresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_diamfresa.Location = New System.Drawing.Point(368, 99)
        Me.txt_diamfresa.Name = "txt_diamfresa"
        Me.txt_diamfresa.Size = New System.Drawing.Size(110, 20)
        Me.txt_diamfresa.TabIndex = 25
        Me.txt_diamfresa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_increz
        '
        Me.txt_increz.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_increz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_increz.Location = New System.Drawing.Point(368, 135)
        Me.txt_increz.Name = "txt_increz"
        Me.txt_increz.Size = New System.Drawing.Size(110, 20)
        Me.txt_increz.TabIndex = 24
        Me.txt_increz.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_AutZ
        '
        Me.txt_AutZ.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_AutZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_AutZ.Location = New System.Drawing.Point(368, 63)
        Me.txt_AutZ.Name = "txt_AutZ"
        Me.txt_AutZ.Size = New System.Drawing.Size(110, 20)
        Me.txt_AutZ.TabIndex = 23
        Me.txt_AutZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(236, 137)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(115, 15)
        Me.Label21.TabIndex = 22
        Me.Label21.Text = "Incremento Z (mm):"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(236, 101)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(124, 15)
        Me.Label20.TabIndex = 21
        Me.Label20.Text = "Diâmtro Fresa (mm): "
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(32, 293)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(44, 15)
        Me.Label17.TabIndex = 20
        Me.Label17.Text = "Eixo Z:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(32, 257)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(44, 15)
        Me.Label18.TabIndex = 19
        Me.Label18.Text = "Eixo Y:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(31, 221)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(45, 15)
        Me.Label19.TabIndex = 18
        Me.Label19.Text = "Eixo X:"
        '
        'txt_Zinterior
        '
        Me.txt_Zinterior.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_Zinterior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Zinterior.Location = New System.Drawing.Point(93, 291)
        Me.txt_Zinterior.Name = "txt_Zinterior"
        Me.txt_Zinterior.Size = New System.Drawing.Size(110, 20)
        Me.txt_Zinterior.TabIndex = 17
        Me.txt_Zinterior.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_Yinterior
        '
        Me.txt_Yinterior.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_Yinterior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Yinterior.Location = New System.Drawing.Point(93, 255)
        Me.txt_Yinterior.Name = "txt_Yinterior"
        Me.txt_Yinterior.Size = New System.Drawing.Size(110, 20)
        Me.txt_Yinterior.TabIndex = 16
        Me.txt_Yinterior.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_Xinterior
        '
        Me.txt_Xinterior.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_Xinterior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Xinterior.Location = New System.Drawing.Point(93, 219)
        Me.txt_Xinterior.Name = "txt_Xinterior"
        Me.txt_Xinterior.Size = New System.Drawing.Size(110, 20)
        Me.txt_Xinterior.TabIndex = 15
        Me.txt_Xinterior.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(236, 65)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(103, 15)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "Retração Z (mm):"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label15.Location = New System.Drawing.Point(31, 194)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(168, 15)
        Me.Label15.TabIndex = 13
        Me.Label15.Text = "Dimensão do Corte (mm)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(32, 137)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 15)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Eixo Z:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(32, 101)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 15)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Eixo Y:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(31, 65)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 15)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "Eixo X:"
        '
        'txt_Zexterior
        '
        Me.txt_Zexterior.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_Zexterior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Zexterior.Location = New System.Drawing.Point(93, 135)
        Me.txt_Zexterior.Name = "txt_Zexterior"
        Me.txt_Zexterior.Size = New System.Drawing.Size(110, 20)
        Me.txt_Zexterior.TabIndex = 9
        Me.txt_Zexterior.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_Yexterior
        '
        Me.txt_Yexterior.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_Yexterior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Yexterior.Location = New System.Drawing.Point(93, 99)
        Me.txt_Yexterior.Name = "txt_Yexterior"
        Me.txt_Yexterior.Size = New System.Drawing.Size(110, 20)
        Me.txt_Yexterior.TabIndex = 8
        Me.txt_Yexterior.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_Xexterior
        '
        Me.txt_Xexterior.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_Xexterior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Xexterior.Location = New System.Drawing.Point(93, 63)
        Me.txt_Xexterior.Name = "txt_Xexterior"
        Me.txt_Xexterior.Size = New System.Drawing.Size(110, 20)
        Me.txt_Xexterior.TabIndex = 7
        Me.txt_Xexterior.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label14.Location = New System.Drawing.Point(31, 33)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(170, 15)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Dimensão do Bloco (mm)"
        '
        'TextBox8
        '
        Me.TextBox8.BackColor = System.Drawing.Color.SteelBlue
        Me.TextBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox8.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox8.Location = New System.Drawing.Point(0, 210)
        Me.TextBox8.Multiline = True
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(1262, 26)
        Me.TextBox8.TabIndex = 14
        Me.TextBox8.Text = "Geração do Corte Retangular em Modo Automático"
        Me.TextBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.Color.SteelBlue
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox4.Location = New System.Drawing.Point(430, 6)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(400, 22)
        Me.TextBox4.TabIndex = 12
        Me.TextBox4.Text = "Posição Atual dos Eixos"
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'grp_PosicaoEixos
        '
        Me.grp_PosicaoEixos.BackColor = System.Drawing.Color.AliceBlue
        Me.grp_PosicaoEixos.Controls.Add(Me.Label7)
        Me.grp_PosicaoEixos.Controls.Add(Me.Label8)
        Me.grp_PosicaoEixos.Controls.Add(Me.Label9)
        Me.grp_PosicaoEixos.Controls.Add(Me.txt_PosAutEixoZ)
        Me.grp_PosicaoEixos.Controls.Add(Me.txt_PosAutEixoY)
        Me.grp_PosicaoEixos.Controls.Add(Me.txt_PosAutEixoX)
        Me.grp_PosicaoEixos.Controls.Add(Me.Label10)
        Me.grp_PosicaoEixos.Location = New System.Drawing.Point(430, 31)
        Me.grp_PosicaoEixos.Name = "grp_PosicaoEixos"
        Me.grp_PosicaoEixos.Size = New System.Drawing.Size(400, 173)
        Me.grp_PosicaoEixos.TabIndex = 11
        Me.grp_PosicaoEixos.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(78, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 15)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Eixo Y:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(77, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 15)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Eixo X:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(78, 126)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 15)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Eixo Z:"
        '
        'txt_PosAutEixoZ
        '
        Me.txt_PosAutEixoZ.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_PosAutEixoZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_PosAutEixoZ.Enabled = False
        Me.txt_PosAutEixoZ.Location = New System.Drawing.Point(158, 124)
        Me.txt_PosAutEixoZ.Name = "txt_PosAutEixoZ"
        Me.txt_PosAutEixoZ.Size = New System.Drawing.Size(144, 20)
        Me.txt_PosAutEixoZ.TabIndex = 9
        Me.txt_PosAutEixoZ.Text = "0.0"
        Me.txt_PosAutEixoZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_PosAutEixoY
        '
        Me.txt_PosAutEixoY.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_PosAutEixoY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_PosAutEixoY.Enabled = False
        Me.txt_PosAutEixoY.Location = New System.Drawing.Point(158, 88)
        Me.txt_PosAutEixoY.Name = "txt_PosAutEixoY"
        Me.txt_PosAutEixoY.Size = New System.Drawing.Size(144, 20)
        Me.txt_PosAutEixoY.TabIndex = 8
        Me.txt_PosAutEixoY.Text = "0.0"
        Me.txt_PosAutEixoY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_PosAutEixoX
        '
        Me.txt_PosAutEixoX.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_PosAutEixoX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_PosAutEixoX.Enabled = False
        Me.txt_PosAutEixoX.Location = New System.Drawing.Point(158, 49)
        Me.txt_PosAutEixoX.Name = "txt_PosAutEixoX"
        Me.txt_PosAutEixoX.Size = New System.Drawing.Size(144, 20)
        Me.txt_PosAutEixoX.TabIndex = 7
        Me.txt_PosAutEixoX.Text = "0.0"
        Me.txt_PosAutEixoX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label10.Location = New System.Drawing.Point(155, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 15)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Posição (mm)"
        '
        'TabPage_CorteCircular
        '
        Me.TabPage_CorteCircular.Controls.Add(Me.GroupBox1)
        Me.TabPage_CorteCircular.Controls.Add(Me.TextBox18)
        Me.TabPage_CorteCircular.Controls.Add(Me.TextBox22)
        Me.TabPage_CorteCircular.Controls.Add(Me.GroupBox2)
        Me.TabPage_CorteCircular.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_CorteCircular.Name = "TabPage_CorteCircular"
        Me.TabPage_CorteCircular.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_CorteCircular.Size = New System.Drawing.Size(1262, 603)
        Me.TabPage_CorteCircular.TabIndex = 1
        Me.TabPage_CorteCircular.Text = "Corte Circular"
        Me.TabPage_CorteCircular.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.AliceBlue
        Me.GroupBox1.Controls.Add(Me.txt_raioCirculo)
        Me.GroupBox1.Controls.Add(Me.Label43)
        Me.GroupBox1.Controls.Add(Me.txt_ManCodGCircular)
        Me.GroupBox1.Controls.Add(Me.btn_ManRunCircular)
        Me.GroupBox1.Controls.Add(Me.btn_ManValidCodeGCircular)
        Me.GroupBox1.Controls.Add(Me.txt_AutFCricular)
        Me.GroupBox1.Controls.Add(Me.txt_AutSCircular)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.txt_diamfresaCricular)
        Me.GroupBox1.Controls.Add(Me.txt_increzCircular)
        Me.GroupBox1.Controls.Add(Me.txt_AutZCircular)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.Label32)
        Me.GroupBox1.Controls.Add(Me.txt_ZinteriorCricular)
        Me.GroupBox1.Controls.Add(Me.txt_YinteriorCircular)
        Me.GroupBox1.Controls.Add(Me.txt_XinteriorCircular)
        Me.GroupBox1.Controls.Add(Me.Label33)
        Me.GroupBox1.Controls.Add(Me.Label34)
        Me.GroupBox1.Controls.Add(Me.Label35)
        Me.GroupBox1.Controls.Add(Me.Label36)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.txt_ZexteriorCircular)
        Me.GroupBox1.Controls.Add(Me.txt_YexteriorCircular)
        Me.GroupBox1.Controls.Add(Me.txt_XexteriorCircular)
        Me.GroupBox1.Controls.Add(Me.Label38)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 236)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1262, 371)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        '
        'txt_raioCirculo
        '
        Me.txt_raioCirculo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_raioCirculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_raioCirculo.Location = New System.Drawing.Point(93, 291)
        Me.txt_raioCirculo.Name = "txt_raioCirculo"
        Me.txt_raioCirculo.Size = New System.Drawing.Size(110, 20)
        Me.txt_raioCirculo.TabIndex = 35
        Me.txt_raioCirculo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(32, 331)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(44, 15)
        Me.Label43.TabIndex = 34
        Me.Label43.Text = "Eixo Z:"
        '
        'txt_ManCodGCircular
        '
        Me.txt_ManCodGCircular.BackColor = System.Drawing.Color.LightCyan
        Me.txt_ManCodGCircular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ManCodGCircular.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ManCodGCircular.Location = New System.Drawing.Point(510, 33)
        Me.txt_ManCodGCircular.Multiline = True
        Me.txt_ManCodGCircular.Name = "txt_ManCodGCircular"
        Me.txt_ManCodGCircular.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_ManCodGCircular.Size = New System.Drawing.Size(730, 250)
        Me.txt_ManCodGCircular.TabIndex = 33
        '
        'btn_ManRunCircular
        '
        Me.btn_ManRunCircular.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ManRunCircular.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btn_ManRunCircular.Location = New System.Drawing.Point(1085, 293)
        Me.btn_ManRunCircular.Name = "btn_ManRunCircular"
        Me.btn_ManRunCircular.Size = New System.Drawing.Size(140, 40)
        Me.btn_ManRunCircular.TabIndex = 32
        Me.btn_ManRunCircular.Text = "Run"
        Me.btn_ManRunCircular.UseVisualStyleBackColor = True
        '
        'btn_ManValidCodeGCircular
        '
        Me.btn_ManValidCodeGCircular.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ManValidCodeGCircular.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btn_ManValidCodeGCircular.Location = New System.Drawing.Point(338, 293)
        Me.btn_ManValidCodeGCircular.Name = "btn_ManValidCodeGCircular"
        Me.btn_ManValidCodeGCircular.Size = New System.Drawing.Size(140, 40)
        Me.btn_ManValidCodeGCircular.TabIndex = 31
        Me.btn_ManValidCodeGCircular.Text = "Validar (G Code)"
        Me.btn_ManValidCodeGCircular.UseVisualStyleBackColor = True
        '
        'txt_AutFCricular
        '
        Me.txt_AutFCricular.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_AutFCricular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_AutFCricular.Location = New System.Drawing.Point(368, 205)
        Me.txt_AutFCricular.Name = "txt_AutFCricular"
        Me.txt_AutFCricular.Size = New System.Drawing.Size(110, 20)
        Me.txt_AutFCricular.TabIndex = 30
        Me.txt_AutFCricular.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_AutSCircular
        '
        Me.txt_AutSCircular.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_AutSCircular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_AutSCircular.Location = New System.Drawing.Point(368, 172)
        Me.txt_AutSCircular.Name = "txt_AutSCircular"
        Me.txt_AutSCircular.Size = New System.Drawing.Size(110, 20)
        Me.txt_AutSCircular.TabIndex = 29
        Me.txt_AutSCircular.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(236, 207)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(124, 15)
        Me.Label25.TabIndex = 28
        Me.Label25.Text = "Feed Rate (mm/min):"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(236, 174)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(91, 15)
        Me.Label26.TabIndex = 27
        Me.Label26.Text = "Spindle (RPM):"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label27.Location = New System.Drawing.Point(236, 33)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(156, 15)
        Me.Label27.TabIndex = 26
        Me.Label27.Text = "Ferramenta e Processo"
        '
        'txt_diamfresaCricular
        '
        Me.txt_diamfresaCricular.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_diamfresaCricular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_diamfresaCricular.Location = New System.Drawing.Point(368, 99)
        Me.txt_diamfresaCricular.Name = "txt_diamfresaCricular"
        Me.txt_diamfresaCricular.Size = New System.Drawing.Size(110, 20)
        Me.txt_diamfresaCricular.TabIndex = 25
        Me.txt_diamfresaCricular.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_increzCircular
        '
        Me.txt_increzCircular.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_increzCircular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_increzCircular.Location = New System.Drawing.Point(368, 135)
        Me.txt_increzCircular.Name = "txt_increzCircular"
        Me.txt_increzCircular.Size = New System.Drawing.Size(110, 20)
        Me.txt_increzCircular.TabIndex = 24
        Me.txt_increzCircular.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_AutZCircular
        '
        Me.txt_AutZCircular.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_AutZCircular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_AutZCircular.Location = New System.Drawing.Point(368, 63)
        Me.txt_AutZCircular.Name = "txt_AutZCircular"
        Me.txt_AutZCircular.Size = New System.Drawing.Size(110, 20)
        Me.txt_AutZCircular.TabIndex = 23
        Me.txt_AutZCircular.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(236, 137)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(115, 15)
        Me.Label28.TabIndex = 22
        Me.Label28.Text = "Incremento Z (mm):"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(236, 101)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(124, 15)
        Me.Label29.TabIndex = 21
        Me.Label29.Text = "Diâmtro Fresa (mm): "
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(32, 293)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(36, 15)
        Me.Label30.TabIndex = 20
        Me.Label30.Text = "Raio:"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(32, 257)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(56, 15)
        Me.Label31.TabIndex = 19
        Me.Label31.Text = "Centro Y:"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(31, 221)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(57, 15)
        Me.Label32.TabIndex = 18
        Me.Label32.Text = "Centro X:"
        '
        'txt_ZinteriorCricular
        '
        Me.txt_ZinteriorCricular.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_ZinteriorCricular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ZinteriorCricular.Location = New System.Drawing.Point(93, 329)
        Me.txt_ZinteriorCricular.Name = "txt_ZinteriorCricular"
        Me.txt_ZinteriorCricular.Size = New System.Drawing.Size(110, 20)
        Me.txt_ZinteriorCricular.TabIndex = 17
        Me.txt_ZinteriorCricular.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_YinteriorCircular
        '
        Me.txt_YinteriorCircular.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_YinteriorCircular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_YinteriorCircular.Location = New System.Drawing.Point(93, 255)
        Me.txt_YinteriorCircular.Name = "txt_YinteriorCircular"
        Me.txt_YinteriorCircular.Size = New System.Drawing.Size(110, 20)
        Me.txt_YinteriorCircular.TabIndex = 16
        Me.txt_YinteriorCircular.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_XinteriorCircular
        '
        Me.txt_XinteriorCircular.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_XinteriorCircular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_XinteriorCircular.Location = New System.Drawing.Point(93, 219)
        Me.txt_XinteriorCircular.Name = "txt_XinteriorCircular"
        Me.txt_XinteriorCircular.Size = New System.Drawing.Size(110, 20)
        Me.txt_XinteriorCircular.TabIndex = 15
        Me.txt_XinteriorCircular.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(236, 65)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(103, 15)
        Me.Label33.TabIndex = 14
        Me.Label33.Text = "Retração Z (mm):"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label34.Location = New System.Drawing.Point(31, 194)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(168, 15)
        Me.Label34.TabIndex = 13
        Me.Label34.Text = "Dimensão do Corte (mm)"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(32, 137)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(44, 15)
        Me.Label35.TabIndex = 12
        Me.Label35.Text = "Eixo Z:"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(32, 101)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(44, 15)
        Me.Label36.TabIndex = 11
        Me.Label36.Text = "Eixo Y:"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(31, 65)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(45, 15)
        Me.Label37.TabIndex = 10
        Me.Label37.Text = "Eixo X:"
        '
        'txt_ZexteriorCircular
        '
        Me.txt_ZexteriorCircular.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_ZexteriorCircular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ZexteriorCircular.Location = New System.Drawing.Point(93, 135)
        Me.txt_ZexteriorCircular.Name = "txt_ZexteriorCircular"
        Me.txt_ZexteriorCircular.Size = New System.Drawing.Size(110, 20)
        Me.txt_ZexteriorCircular.TabIndex = 9
        Me.txt_ZexteriorCircular.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_YexteriorCircular
        '
        Me.txt_YexteriorCircular.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_YexteriorCircular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_YexteriorCircular.Location = New System.Drawing.Point(93, 99)
        Me.txt_YexteriorCircular.Name = "txt_YexteriorCircular"
        Me.txt_YexteriorCircular.Size = New System.Drawing.Size(110, 20)
        Me.txt_YexteriorCircular.TabIndex = 8
        Me.txt_YexteriorCircular.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_XexteriorCircular
        '
        Me.txt_XexteriorCircular.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_XexteriorCircular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_XexteriorCircular.Location = New System.Drawing.Point(93, 63)
        Me.txt_XexteriorCircular.Name = "txt_XexteriorCircular"
        Me.txt_XexteriorCircular.Size = New System.Drawing.Size(110, 20)
        Me.txt_XexteriorCircular.TabIndex = 7
        Me.txt_XexteriorCircular.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label38.Location = New System.Drawing.Point(31, 33)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(170, 15)
        Me.Label38.TabIndex = 6
        Me.Label38.Text = "Dimensão do Bloco (mm)"
        '
        'TextBox18
        '
        Me.TextBox18.BackColor = System.Drawing.Color.SteelBlue
        Me.TextBox18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox18.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox18.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox18.Location = New System.Drawing.Point(0, 210)
        Me.TextBox18.Multiline = True
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Size = New System.Drawing.Size(1262, 26)
        Me.TextBox18.TabIndex = 18
        Me.TextBox18.Text = "Geração do Corte Circular em Modo Automático"
        Me.TextBox18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox22
        '
        Me.TextBox22.BackColor = System.Drawing.Color.SteelBlue
        Me.TextBox22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox22.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox22.Location = New System.Drawing.Point(430, 6)
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.Size = New System.Drawing.Size(400, 22)
        Me.TextBox22.TabIndex = 17
        Me.TextBox22.Text = "Posição Atual dos Eixos"
        Me.TextBox22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.AliceBlue
        Me.GroupBox2.Controls.Add(Me.Label39)
        Me.GroupBox2.Controls.Add(Me.Label40)
        Me.GroupBox2.Controls.Add(Me.Label41)
        Me.GroupBox2.Controls.Add(Me.txt_PosAutEixoZCircular)
        Me.GroupBox2.Controls.Add(Me.txt_PosAutEixoYCircular)
        Me.GroupBox2.Controls.Add(Me.txt_PosAutEixoXCircular)
        Me.GroupBox2.Controls.Add(Me.Label42)
        Me.GroupBox2.Location = New System.Drawing.Point(430, 31)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(400, 173)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(78, 90)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(44, 15)
        Me.Label39.TabIndex = 12
        Me.Label39.Text = "Eixo Y:"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(77, 51)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(45, 15)
        Me.Label40.TabIndex = 11
        Me.Label40.Text = "Eixo X:"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(78, 126)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(44, 15)
        Me.Label41.TabIndex = 10
        Me.Label41.Text = "Eixo Z:"
        '
        'txt_PosAutEixoZCircular
        '
        Me.txt_PosAutEixoZCircular.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_PosAutEixoZCircular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_PosAutEixoZCircular.Enabled = False
        Me.txt_PosAutEixoZCircular.Location = New System.Drawing.Point(158, 124)
        Me.txt_PosAutEixoZCircular.Name = "txt_PosAutEixoZCircular"
        Me.txt_PosAutEixoZCircular.Size = New System.Drawing.Size(144, 20)
        Me.txt_PosAutEixoZCircular.TabIndex = 9
        Me.txt_PosAutEixoZCircular.Text = "0.0"
        Me.txt_PosAutEixoZCircular.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_PosAutEixoYCircular
        '
        Me.txt_PosAutEixoYCircular.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_PosAutEixoYCircular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_PosAutEixoYCircular.Enabled = False
        Me.txt_PosAutEixoYCircular.Location = New System.Drawing.Point(158, 88)
        Me.txt_PosAutEixoYCircular.Name = "txt_PosAutEixoYCircular"
        Me.txt_PosAutEixoYCircular.Size = New System.Drawing.Size(144, 20)
        Me.txt_PosAutEixoYCircular.TabIndex = 8
        Me.txt_PosAutEixoYCircular.Text = "0.0"
        Me.txt_PosAutEixoYCircular.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_PosAutEixoXCircular
        '
        Me.txt_PosAutEixoXCircular.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_PosAutEixoXCircular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_PosAutEixoXCircular.Enabled = False
        Me.txt_PosAutEixoXCircular.Location = New System.Drawing.Point(158, 49)
        Me.txt_PosAutEixoXCircular.Name = "txt_PosAutEixoXCircular"
        Me.txt_PosAutEixoXCircular.Size = New System.Drawing.Size(144, 20)
        Me.txt_PosAutEixoXCircular.TabIndex = 7
        Me.txt_PosAutEixoXCircular.Text = "0.0"
        Me.txt_PosAutEixoXCircular.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label42.Location = New System.Drawing.Point(155, 16)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(84, 15)
        Me.Label42.TabIndex = 6
        Me.Label42.Text = "Posição (mm)"
        '
        'TabPage_CorteL
        '
        Me.TabPage_CorteL.Controls.Add(Me.TextBox5)
        Me.TabPage_CorteL.Controls.Add(Me.GroupBox3)
        Me.TabPage_CorteL.Controls.Add(Me.TextBox20)
        Me.TabPage_CorteL.Controls.Add(Me.GroupBox4)
        Me.TabPage_CorteL.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_CorteL.Name = "TabPage_CorteL"
        Me.TabPage_CorteL.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_CorteL.Size = New System.Drawing.Size(1262, 603)
        Me.TabPage_CorteL.TabIndex = 2
        Me.TabPage_CorteL.Text = "Corte L"
        Me.TabPage_CorteL.UseVisualStyleBackColor = True
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.Color.SteelBlue
        Me.TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox5.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox5.Location = New System.Drawing.Point(-1, 213)
        Me.TextBox5.Multiline = True
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(1262, 26)
        Me.TextBox5.TabIndex = 34
        Me.TextBox5.Text = "Geração do Corte L em Modo Automático"
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.AliceBlue
        Me.GroupBox3.Controls.Add(Me.Label65)
        Me.GroupBox3.Controls.Add(Me.Label64)
        Me.GroupBox3.Controls.Add(Me.txt_Espessura_L)
        Me.GroupBox3.Controls.Add(Me.txt_CompBase_L)
        Me.GroupBox3.Controls.Add(Me.Label63)
        Me.GroupBox3.Controls.Add(Me.Label62)
        Me.GroupBox3.Controls.Add(Me.txt_ManCodG_L)
        Me.GroupBox3.Controls.Add(Me.btn_ManRun_L)
        Me.GroupBox3.Controls.Add(Me.btn_ManValidCodeG_L)
        Me.GroupBox3.Controls.Add(Me.txt_AutF_L)
        Me.GroupBox3.Controls.Add(Me.txt_AutS_L)
        Me.GroupBox3.Controls.Add(Me.Label44)
        Me.GroupBox3.Controls.Add(Me.Label45)
        Me.GroupBox3.Controls.Add(Me.Label46)
        Me.GroupBox3.Controls.Add(Me.txt_diamfresa_L)
        Me.GroupBox3.Controls.Add(Me.txt_increz_L)
        Me.GroupBox3.Controls.Add(Me.txt_AutZ_L)
        Me.GroupBox3.Controls.Add(Me.Label47)
        Me.GroupBox3.Controls.Add(Me.Label48)
        Me.GroupBox3.Controls.Add(Me.Label49)
        Me.GroupBox3.Controls.Add(Me.Label50)
        Me.GroupBox3.Controls.Add(Me.txt_Zinterior_L)
        Me.GroupBox3.Controls.Add(Me.txt_AlturaPerna_L)
        Me.GroupBox3.Controls.Add(Me.Label52)
        Me.GroupBox3.Controls.Add(Me.Label53)
        Me.GroupBox3.Controls.Add(Me.Label54)
        Me.GroupBox3.Controls.Add(Me.Label55)
        Me.GroupBox3.Controls.Add(Me.Label56)
        Me.GroupBox3.Controls.Add(Me.txt_Zexterior_L)
        Me.GroupBox3.Controls.Add(Me.txt_Yexterior_L)
        Me.GroupBox3.Controls.Add(Me.txt_Xexterior_L)
        Me.GroupBox3.Controls.Add(Me.Label57)
        Me.GroupBox3.Location = New System.Drawing.Point(0, 236)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1262, 371)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.ForeColor = System.Drawing.Color.CadetBlue
        Me.Label62.Location = New System.Drawing.Point(18, 276)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(101, 15)
        Me.Label62.TabIndex = 34
        Me.Label62.Text = "Perna Vertical "
        '
        'txt_ManCodG_L
        '
        Me.txt_ManCodG_L.BackColor = System.Drawing.Color.LightCyan
        Me.txt_ManCodG_L.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ManCodG_L.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ManCodG_L.Location = New System.Drawing.Point(510, 33)
        Me.txt_ManCodG_L.Multiline = True
        Me.txt_ManCodG_L.Name = "txt_ManCodG_L"
        Me.txt_ManCodG_L.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_ManCodG_L.Size = New System.Drawing.Size(730, 250)
        Me.txt_ManCodG_L.TabIndex = 33
        '
        'btn_ManRun_L
        '
        Me.btn_ManRun_L.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ManRun_L.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btn_ManRun_L.Location = New System.Drawing.Point(1081, 293)
        Me.btn_ManRun_L.Name = "btn_ManRun_L"
        Me.btn_ManRun_L.Size = New System.Drawing.Size(140, 40)
        Me.btn_ManRun_L.TabIndex = 32
        Me.btn_ManRun_L.Text = "Run"
        Me.btn_ManRun_L.UseVisualStyleBackColor = True
        '
        'btn_ManValidCodeG_L
        '
        Me.btn_ManValidCodeG_L.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ManValidCodeG_L.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btn_ManValidCodeG_L.Location = New System.Drawing.Point(338, 291)
        Me.btn_ManValidCodeG_L.Name = "btn_ManValidCodeG_L"
        Me.btn_ManValidCodeG_L.Size = New System.Drawing.Size(140, 40)
        Me.btn_ManValidCodeG_L.TabIndex = 31
        Me.btn_ManValidCodeG_L.Text = "Validar (G Code)"
        Me.btn_ManValidCodeG_L.UseVisualStyleBackColor = True
        '
        'txt_AutF_L
        '
        Me.txt_AutF_L.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_AutF_L.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_AutF_L.Location = New System.Drawing.Point(368, 205)
        Me.txt_AutF_L.Name = "txt_AutF_L"
        Me.txt_AutF_L.Size = New System.Drawing.Size(110, 20)
        Me.txt_AutF_L.TabIndex = 30
        Me.txt_AutF_L.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_AutS_L
        '
        Me.txt_AutS_L.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_AutS_L.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_AutS_L.Location = New System.Drawing.Point(368, 172)
        Me.txt_AutS_L.Name = "txt_AutS_L"
        Me.txt_AutS_L.Size = New System.Drawing.Size(110, 20)
        Me.txt_AutS_L.TabIndex = 29
        Me.txt_AutS_L.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(236, 207)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(124, 15)
        Me.Label44.TabIndex = 28
        Me.Label44.Text = "Feed Rate (mm/min):"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(236, 174)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(91, 15)
        Me.Label45.TabIndex = 27
        Me.Label45.Text = "Spindle (RPM):"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label46.Location = New System.Drawing.Point(236, 33)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(156, 15)
        Me.Label46.TabIndex = 26
        Me.Label46.Text = "Ferramenta e Processo"
        '
        'txt_diamfresa_L
        '
        Me.txt_diamfresa_L.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_diamfresa_L.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_diamfresa_L.Location = New System.Drawing.Point(368, 99)
        Me.txt_diamfresa_L.Name = "txt_diamfresa_L"
        Me.txt_diamfresa_L.Size = New System.Drawing.Size(110, 20)
        Me.txt_diamfresa_L.TabIndex = 25
        Me.txt_diamfresa_L.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_increz_L
        '
        Me.txt_increz_L.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_increz_L.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_increz_L.Location = New System.Drawing.Point(368, 135)
        Me.txt_increz_L.Name = "txt_increz_L"
        Me.txt_increz_L.Size = New System.Drawing.Size(110, 20)
        Me.txt_increz_L.TabIndex = 24
        Me.txt_increz_L.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_AutZ_L
        '
        Me.txt_AutZ_L.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_AutZ_L.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_AutZ_L.Location = New System.Drawing.Point(368, 63)
        Me.txt_AutZ_L.Name = "txt_AutZ_L"
        Me.txt_AutZ_L.Size = New System.Drawing.Size(110, 20)
        Me.txt_AutZ_L.TabIndex = 23
        Me.txt_AutZ_L.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(236, 137)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(115, 15)
        Me.Label47.TabIndex = 22
        Me.Label47.Text = "Incremento Z (mm):"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(236, 101)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(124, 15)
        Me.Label48.TabIndex = 21
        Me.Label48.Text = "Diâmtro Fresa (mm): "
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(18, 223)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(44, 15)
        Me.Label49.TabIndex = 20
        Me.Label49.Text = "Eixo Z:"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(18, 300)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(59, 15)
        Me.Label50.TabIndex = 19
        Me.Label50.Text = "Altura (Y):"
        '
        'txt_Zinterior_L
        '
        Me.txt_Zinterior_L.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_Zinterior_L.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Zinterior_L.Location = New System.Drawing.Point(93, 221)
        Me.txt_Zinterior_L.Name = "txt_Zinterior_L"
        Me.txt_Zinterior_L.Size = New System.Drawing.Size(110, 20)
        Me.txt_Zinterior_L.TabIndex = 17
        Me.txt_Zinterior_L.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_AlturaPerna_L
        '
        Me.txt_AlturaPerna_L.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_AlturaPerna_L.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_AlturaPerna_L.Location = New System.Drawing.Point(93, 298)
        Me.txt_AlturaPerna_L.Name = "txt_AlturaPerna_L"
        Me.txt_AlturaPerna_L.Size = New System.Drawing.Size(110, 20)
        Me.txt_AlturaPerna_L.TabIndex = 15
        Me.txt_AlturaPerna_L.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(236, 65)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(103, 15)
        Me.Label52.TabIndex = 14
        Me.Label52.Text = "Retração Z (mm):"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label53.Location = New System.Drawing.Point(18, 194)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(168, 15)
        Me.Label53.TabIndex = 13
        Me.Label53.Text = "Dimensão do Corte (mm)"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(32, 137)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(44, 15)
        Me.Label54.TabIndex = 12
        Me.Label54.Text = "Eixo Z:"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(32, 101)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(44, 15)
        Me.Label55.TabIndex = 11
        Me.Label55.Text = "Eixo Y:"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.Location = New System.Drawing.Point(31, 65)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(45, 15)
        Me.Label56.TabIndex = 10
        Me.Label56.Text = "Eixo X:"
        '
        'txt_Zexterior_L
        '
        Me.txt_Zexterior_L.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_Zexterior_L.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Zexterior_L.Location = New System.Drawing.Point(93, 135)
        Me.txt_Zexterior_L.Name = "txt_Zexterior_L"
        Me.txt_Zexterior_L.Size = New System.Drawing.Size(110, 20)
        Me.txt_Zexterior_L.TabIndex = 9
        Me.txt_Zexterior_L.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_Yexterior_L
        '
        Me.txt_Yexterior_L.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_Yexterior_L.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Yexterior_L.Location = New System.Drawing.Point(93, 99)
        Me.txt_Yexterior_L.Name = "txt_Yexterior_L"
        Me.txt_Yexterior_L.Size = New System.Drawing.Size(110, 20)
        Me.txt_Yexterior_L.TabIndex = 8
        Me.txt_Yexterior_L.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_Xexterior_L
        '
        Me.txt_Xexterior_L.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_Xexterior_L.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Xexterior_L.Location = New System.Drawing.Point(93, 63)
        Me.txt_Xexterior_L.Name = "txt_Xexterior_L"
        Me.txt_Xexterior_L.Size = New System.Drawing.Size(110, 20)
        Me.txt_Xexterior_L.TabIndex = 7
        Me.txt_Xexterior_L.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label57.Location = New System.Drawing.Point(31, 33)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(170, 15)
        Me.Label57.TabIndex = 6
        Me.Label57.Text = "Dimensão do Bloco (mm)"
        '
        'TextBox20
        '
        Me.TextBox20.BackColor = System.Drawing.Color.SteelBlue
        Me.TextBox20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox20.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextBox20.Location = New System.Drawing.Point(430, 6)
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Size = New System.Drawing.Size(400, 22)
        Me.TextBox20.TabIndex = 17
        Me.TextBox20.Text = "Posição Atual dos Eixos"
        Me.TextBox20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.AliceBlue
        Me.GroupBox4.Controls.Add(Me.Label58)
        Me.GroupBox4.Controls.Add(Me.Label59)
        Me.GroupBox4.Controls.Add(Me.Label60)
        Me.GroupBox4.Controls.Add(Me.txt_PosAutEixoZ_L)
        Me.GroupBox4.Controls.Add(Me.txt_PosAutEixoY_L)
        Me.GroupBox4.Controls.Add(Me.txt_PosAutEixoX_L)
        Me.GroupBox4.Controls.Add(Me.Label61)
        Me.GroupBox4.Location = New System.Drawing.Point(430, 34)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(400, 173)
        Me.GroupBox4.TabIndex = 16
        Me.GroupBox4.TabStop = False
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.Location = New System.Drawing.Point(78, 90)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(44, 15)
        Me.Label58.TabIndex = 12
        Me.Label58.Text = "Eixo Y:"
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.Location = New System.Drawing.Point(77, 51)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(45, 15)
        Me.Label59.TabIndex = 11
        Me.Label59.Text = "Eixo X:"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.Location = New System.Drawing.Point(78, 126)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(44, 15)
        Me.Label60.TabIndex = 10
        Me.Label60.Text = "Eixo Z:"
        '
        'txt_PosAutEixoZ_L
        '
        Me.txt_PosAutEixoZ_L.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_PosAutEixoZ_L.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_PosAutEixoZ_L.Enabled = False
        Me.txt_PosAutEixoZ_L.Location = New System.Drawing.Point(158, 124)
        Me.txt_PosAutEixoZ_L.Name = "txt_PosAutEixoZ_L"
        Me.txt_PosAutEixoZ_L.Size = New System.Drawing.Size(144, 20)
        Me.txt_PosAutEixoZ_L.TabIndex = 9
        Me.txt_PosAutEixoZ_L.Text = "0.0"
        Me.txt_PosAutEixoZ_L.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_PosAutEixoY_L
        '
        Me.txt_PosAutEixoY_L.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_PosAutEixoY_L.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_PosAutEixoY_L.Enabled = False
        Me.txt_PosAutEixoY_L.Location = New System.Drawing.Point(158, 88)
        Me.txt_PosAutEixoY_L.Name = "txt_PosAutEixoY_L"
        Me.txt_PosAutEixoY_L.Size = New System.Drawing.Size(144, 20)
        Me.txt_PosAutEixoY_L.TabIndex = 8
        Me.txt_PosAutEixoY_L.Text = "0.0"
        Me.txt_PosAutEixoY_L.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_PosAutEixoX_L
        '
        Me.txt_PosAutEixoX_L.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_PosAutEixoX_L.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_PosAutEixoX_L.Enabled = False
        Me.txt_PosAutEixoX_L.Location = New System.Drawing.Point(158, 49)
        Me.txt_PosAutEixoX_L.Name = "txt_PosAutEixoX_L"
        Me.txt_PosAutEixoX_L.Size = New System.Drawing.Size(144, 20)
        Me.txt_PosAutEixoX_L.TabIndex = 7
        Me.txt_PosAutEixoX_L.Text = "0.0"
        Me.txt_PosAutEixoX_L.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label61.Location = New System.Drawing.Point(155, 16)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(84, 15)
        Me.Label61.TabIndex = 6
        Me.Label61.Text = "Posição (mm)"
        '
        'tmr_match3
        '
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.ForeColor = System.Drawing.Color.CadetBlue
        Me.Label63.Location = New System.Drawing.Point(18, 323)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(109, 15)
        Me.Label63.TabIndex = 35
        Me.Label63.Text = "Base Horizontal"
        '
        'txt_CompBase_L
        '
        Me.txt_CompBase_L.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_CompBase_L.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_CompBase_L.Location = New System.Drawing.Point(93, 346)
        Me.txt_CompBase_L.Name = "txt_CompBase_L"
        Me.txt_CompBase_L.Size = New System.Drawing.Size(110, 20)
        Me.txt_CompBase_L.TabIndex = 36
        Me.txt_CompBase_L.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_Espessura_L
        '
        Me.txt_Espessura_L.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txt_Espessura_L.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Espessura_L.Location = New System.Drawing.Point(93, 250)
        Me.txt_Espessura_L.Name = "txt_Espessura_L"
        Me.txt_Espessura_L.Size = New System.Drawing.Size(110, 20)
        Me.txt_Espessura_L.TabIndex = 37
        Me.txt_Espessura_L.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.Location = New System.Drawing.Point(18, 348)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(65, 15)
        Me.Label64.TabIndex = 38
        Me.Label64.Text = "Comp. (X):"
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label65.Location = New System.Drawing.Point(18, 252)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(68, 15)
        Me.Label65.TabIndex = 39
        Me.Label65.Text = "Espessura:"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 663)
        Me.Controls.Add(Me.TabCtrl_Option)
        Me.Name = "MainForm"
        Me.Text = "CNC Control"
        Me.TabCtrl_Option.ResumeLayout(False)
        Me.TabPage_Manual.ResumeLayout(False)
        Me.TabPage_Manual.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.grp_PosicaoAtual.ResumeLayout(False)
        Me.grp_PosicaoAtual.PerformLayout()
        Me.grp_MoverPosicao.ResumeLayout(False)
        Me.grp_MoverPosicao.PerformLayout()
        Me.grp_ControloManual.ResumeLayout(False)
        Me.grp_ControloManual.PerformLayout()
        CType(Me.trackBar_ManFeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage_Automatico.ResumeLayout(False)
        Me.TabControl_AutoModos.ResumeLayout(False)
        Me.TabPage_CorteRetangular.ResumeLayout(False)
        Me.TabPage_CorteRetangular.PerformLayout()
        Me.grp_ControloProgramaAuto.ResumeLayout(False)
        Me.grp_ControloProgramaAuto.PerformLayout()
        Me.grp_PosicaoEixos.ResumeLayout(False)
        Me.grp_PosicaoEixos.PerformLayout()
        Me.TabPage_CorteCircular.ResumeLayout(False)
        Me.TabPage_CorteCircular.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage_CorteL.ResumeLayout(False)
        Me.TabPage_CorteL.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabCtrl_Option As System.Windows.Forms.TabControl
    Friend WithEvents TabPage_Manual As System.Windows.Forms.TabPage
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents grp_PosicaoAtual As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents grp_MoverPosicao As System.Windows.Forms.GroupBox
    Friend WithEvents btn_ManSet As System.Windows.Forms.Button
    Friend WithEvents btn_ManMovToPos As System.Windows.Forms.Button
    Friend WithEvents lbl_PosY As System.Windows.Forms.Label
    Friend WithEvents lbl_PosX As System.Windows.Forms.Label
    Friend WithEvents lbl_PosZ As System.Windows.Forms.Label
    Friend WithEvents txt_PosManEixoZ As System.Windows.Forms.TextBox
    Friend WithEvents txt_PosManEixoY As System.Windows.Forms.TextBox
    Friend WithEvents txt_PosManEixoX As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents grp_ControloManual As System.Windows.Forms.GroupBox
    Friend WithEvents txt_ManFeedRate As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_ManXmenos As System.Windows.Forms.Button
    Friend WithEvents btn_ManZmenos As System.Windows.Forms.Button
    Friend WithEvents btn_ManYmenos As System.Windows.Forms.Button
    Friend WithEvents lbl_Velocidade As System.Windows.Forms.Label
    Friend WithEvents btn_ManZmais As System.Windows.Forms.Button
    Friend WithEvents btn_ManYmais As System.Windows.Forms.Button
    Friend WithEvents trackBar_ManFeed As System.Windows.Forms.TrackBar
    Friend WithEvents btn_ManXmais As System.Windows.Forms.Button
    Friend WithEvents TabPage_Automatico As System.Windows.Forms.TabPage
    Friend WithEvents tmr_match3 As System.Windows.Forms.Timer
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusStripLbl_Modo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Button_close As System.Windows.Forms.Button
    Public WithEvents txt_ManPosX As System.Windows.Forms.TextBox
    Public WithEvents txt_ManPosZ As System.Windows.Forms.TextBox
    Public WithEvents txt_ManPosY As System.Windows.Forms.TextBox
    Friend WithEvents TabControl_AutoModos As System.Windows.Forms.TabControl
    Friend WithEvents TabPage_CorteRetangular As System.Windows.Forms.TabPage
    Friend WithEvents grp_ControloProgramaAuto As System.Windows.Forms.GroupBox
    Friend WithEvents txt_ManCodG As System.Windows.Forms.TextBox
    Friend WithEvents btn_ManRun As System.Windows.Forms.Button
    Friend WithEvents btn_ManValidCodeG As System.Windows.Forms.Button
    Friend WithEvents txt_AutF As System.Windows.Forms.TextBox
    Friend WithEvents txt_AutS As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txt_diamfresa As System.Windows.Forms.TextBox
    Friend WithEvents txt_increz As System.Windows.Forms.TextBox
    Friend WithEvents txt_AutZ As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txt_Zinterior As System.Windows.Forms.TextBox
    Friend WithEvents txt_Yinterior As System.Windows.Forms.TextBox
    Friend WithEvents txt_Xinterior As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_Zexterior As System.Windows.Forms.TextBox
    Friend WithEvents txt_Yexterior As System.Windows.Forms.TextBox
    Friend WithEvents txt_Xexterior As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents grp_PosicaoEixos As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents txt_PosAutEixoZ As System.Windows.Forms.TextBox
    Public WithEvents txt_PosAutEixoY As System.Windows.Forms.TextBox
    Public WithEvents txt_PosAutEixoX As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TabPage_CorteCircular As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_raioCirculo As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents txt_ManCodGCircular As System.Windows.Forms.TextBox
    Friend WithEvents btn_ManRunCircular As System.Windows.Forms.Button
    Friend WithEvents btn_ManValidCodeGCircular As System.Windows.Forms.Button
    Friend WithEvents txt_AutFCricular As System.Windows.Forms.TextBox
    Friend WithEvents txt_AutSCircular As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txt_diamfresaCricular As System.Windows.Forms.TextBox
    Friend WithEvents txt_increzCircular As System.Windows.Forms.TextBox
    Friend WithEvents txt_AutZCircular As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txt_ZinteriorCricular As System.Windows.Forms.TextBox
    Friend WithEvents txt_YinteriorCircular As System.Windows.Forms.TextBox
    Friend WithEvents txt_XinteriorCircular As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txt_ZexteriorCircular As System.Windows.Forms.TextBox
    Friend WithEvents txt_YexteriorCircular As System.Windows.Forms.TextBox
    Friend WithEvents txt_XexteriorCircular As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents TextBox18 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox22 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Public WithEvents txt_PosAutEixoZCircular As System.Windows.Forms.TextBox
    Public WithEvents txt_PosAutEixoYCircular As System.Windows.Forms.TextBox
    Public WithEvents txt_PosAutEixoXCircular As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents TabPage_CorteL As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txt_ManCodG_L As System.Windows.Forms.TextBox
    Friend WithEvents btn_ManRun_L As System.Windows.Forms.Button
    Friend WithEvents btn_ManValidCodeG_L As System.Windows.Forms.Button
    Friend WithEvents txt_AutF_L As System.Windows.Forms.TextBox
    Friend WithEvents txt_AutS_L As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents txt_diamfresa_L As System.Windows.Forms.TextBox
    Friend WithEvents txt_increz_L As System.Windows.Forms.TextBox
    Friend WithEvents txt_AutZ_L As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents txt_Zinterior_L As System.Windows.Forms.TextBox
    Friend WithEvents txt_AlturaPerna_L As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents txt_Zexterior_L As System.Windows.Forms.TextBox
    Friend WithEvents txt_Yexterior_L As System.Windows.Forms.TextBox
    Friend WithEvents txt_Xexterior_L As System.Windows.Forms.TextBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents TextBox20 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Public WithEvents txt_PosAutEixoZ_L As System.Windows.Forms.TextBox
    Public WithEvents txt_PosAutEixoY_L As System.Windows.Forms.TextBox
    Public WithEvents txt_PosAutEixoX_L As System.Windows.Forms.TextBox
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents txt_Espessura_L As System.Windows.Forms.TextBox
    Friend WithEvents txt_CompBase_L As System.Windows.Forms.TextBox
    Friend WithEvents Label63 As System.Windows.Forms.Label
End Class