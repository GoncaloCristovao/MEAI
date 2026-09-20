Imports System
Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Mach4

Public Class MainForm
    'Variaveis modo escrita
    Dim string_texto As String
    Dim file As System.IO.StreamWriter
    Dim counter As Integer
    Dim max_counter As Integer

    ' Comando Numérico de Máquinas Ferramentas
    ' 20 Nov 2025

    Public mach As Mach4.IMach4
    Public scriptObject As Mach4.IMyScriptObject

    ' Variável de demonstração do ficheiro de configuração
    Public Manual_ManualFeedRate As Integer

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim aux As String

        ' Propriedades Iniciais
        ' Modo Manual
        StatusStripLbl_Modo.Text = "Modo Manual"

        ' Abertura das comunicações com o Match3
        mach = GetObject(, "Mach4.Document")
        scriptObject = mach.GetScriptDispatch()

        ' Necessário confirmar se o Match3 está OK

        ' Definições do temporizador para leitura de posição dos eixos (Match3)
        tmr_match3.Interval = 250
        tmr_match3.Enabled = True

        ' Ficheiro de configurações - Modo Manual
        FileOpen(1, "Config\CmdNum_Manual.Ini", OpenMode.Input
                 )
        For i = 1 To 8
            aux = LineInput(1)
        Next
        ' Leitura da velocidade de deslocamento
        aux = LineInput(1)
        Dim words As String() = aux.Split(New Char() {" "c})

        Manual_ManualFeedRate = Integer.Parse(words(2))

        ' Visualizaçºao da Velocidade de Deslocamento
        txt_ManFeedRate.Text = Manual_ManualFeedRate.ToString


        ' PrintLine  para escerever em ficheiro...
        'PrintLine (1, "teste teste")

        FileClose(1)

    End Sub

    Private Sub TabCtrl_Option_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles TabCtrl_Option.Selecting
        ' Selecao de uma determinada página
        Dim PaginaSelecionada As String = TabCtrl_Option.SelectedIndex.ToString

        Select Case PaginaSelecionada
            Case "0"
                StatusStripLbl_Modo.Text = "Modo Manual"
            Case "1"
                StatusStripLbl_Modo.Text = "Modo Automático"
        End Select
    End Sub

    '*******************************************************************
    '*******************************************************************


    ' *******************************************
    ' ROTINAS MODO MANUAL
    ' *******************************************
    Private Sub btn_ManSet_Click(sender As Object, e As EventArgs) Handles btn_ManSet.Click
        ' Zero Maquina
        Manual_SetRefPoint()
    End Sub

    ' ==========================
    ' MOVIMENTAÇÃO EIXO X     
    ' ==========================

    Private Sub btn_ManXmenos_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_ManXmenos.MouseDown
        ' Deslocamento Eixo X-
        scriptObject.DoOEMButton(308)
    End Sub

    Private Sub btn_ManXmenos_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_ManXmenos.MouseUp
        ' Quando Liberta o X- Interrompe movimento
        scriptObject.DoOEMButton(334)
    End Sub

    Private Sub btn_ManXmais_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_ManXmais.MouseUp
        ' Quando Liberta o X+ Interrompe movimento
        scriptObject.DoOEMButton(334)
    End Sub

    Private Sub btn_ManXmais_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_ManXmais.MouseDown
        ' Movimento Manual X+
        scriptObject.DoOEMButton(307)
    End Sub

    ' ==========================
    ' MOVIMENTAÇÃO EIXO Y     
    ' ==========================
    Private Sub btn_ManYmenos_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_ManYmenos.MouseDown
        ' Deslocamento Eixo Y-
        scriptObject.DoOEMButton(310)
    End Sub

    Private Sub btn_ManYmenos_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_ManYmenos.MouseUp
        ' Quando Liberta o Y- Interrompe movimento
        scriptObject.DoOEMButton(335)
    End Sub

    Private Sub btn_ManYmais_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_ManYmais.MouseUp
        ' Quando Liberta o Y+ Interrompe movimento
        scriptObject.DoOEMButton(335)
    End Sub

    Private Sub btn_ManYmais_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_ManYmais.MouseDown
        ' Movimento Manual Y+
        scriptObject.DoOEMButton(309)
    End Sub

    ' ==========================
    ' MOVIMENTAÇÃO EIXO Z     
    ' ==========================
    Private Sub btn_ManZmenos_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_ManZmenos.MouseDown
        ' Deslocamento Eixo Z-
        scriptObject.DoOEMButton(312)
    End Sub

    Private Sub btn_ManZmenos_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_ManZmenos.MouseUp
        ' Quando Liberta o Z- Interrompe movimento
        scriptObject.DoOEMButton(336)
    End Sub

    Private Sub btn_ManZmais_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_ManZmais.MouseUp
        ' Quando Liberta o Z+ Interrompe movimento
        scriptObject.DoOEMButton(336)
    End Sub

    Private Sub btn_ManZmais_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_ManZmais.MouseDown
        ' Movimento Manual Z+
        scriptObject.DoOEMButton(311)
    End Sub

    ' ==========================
    ' MOVE PARA POSIÇÃO DEFINIDA
    ' ==========================

    Private Sub btn_ManMovToPos_Click(sender As Object, e As EventArgs) Handles btn_ManMovToPos.Click
        ' Modo Manual
        ' Move para o ponto definido...
        Dim auxMDI As String

        ' Abertura das comunicações com o Match3
        mach = GetObject(, "Mach4.Document")
        scriptObject = mach.GetScriptDispatch()

        auxMDI = "G90 G01 F" + Manual_ManualFeedRate.ToString + " X" + txt_PosManEixoX.Text + " Y" + txt_PosManEixoY.Text + " Z" + txt_PosManEixoZ.Text

        scriptObject.Code(auxMDI.Trim())



    End Sub

    ' ==========================
    ' TMR - ATUALIZA DRO
    ' ==========================
    Private Sub tmr_match3_Tick(sender As Object, e As EventArgs) Handles tmr_match3.Tick
        If scriptObject Is Nothing Then Return
        ' Leitura Posição Eixo X
        txt_ManPosX.Text = Format(scriptObject.GetABSPostion(0), "###,##0.#0")
        txt_PosAutEixoX.Text = Format(scriptObject.GetABSPostion(0), "###,##0.#0")
        txt_PosAutEixoXCircular.Text = Format(scriptObject.GetABSPostion(0), "###,##0.#0")
        txt_PosAutEixoX_L.Text = Format(scriptObject.GetABSPostion(0), "###,##0.#0")

        ' Leitura Posição Eixo Y
        txt_ManPosY.Text = Format(scriptObject.GetABSPostion(1), "###,##0.#0")
        txt_PosAutEixoY.Text = Format(scriptObject.GetABSPostion(1), "###,##0.#0")
        txt_PosAutEixoYCircular.Text = Format(scriptObject.GetABSPostion(1), "###,##0.#0")
        txt_PosAutEixoY_L.Text = Format(scriptObject.GetABSPostion(1), "###,##0.#0")

        ' Leitura Posição Eixo Z
        txt_ManPosZ.Text = Format(scriptObject.GetABSPostion(2), "###,##0.#0")
        txt_PosAutEixoZ.Text = Format(scriptObject.GetABSPostion(2), "###,##0.#0")
        txt_PosAutEixoZCircular.Text = Format(scriptObject.GetABSPostion(2), "###,##0.#0")
        txt_PosAutEixoZ_L.Text = Format(scriptObject.GetABSPostion(2), "###,##0.#0")

    End Sub
    Private Sub trackBar_AutFeed_MouseUp(sender As Object, e As MouseEventArgs) Handles trackBar_ManFeed.MouseUp
        txt_ManFeedRate.Text = trackBar_ManFeed.Value.ToString

    End Sub

    Function Cmd_Line(ByVal posX As String, ByVal velocidade As String) As String
        ' Execução cmd MDI
        Dim cmd As String = ""
        cmd = " G91" + " G01 X" + posX + " F" + velocidade
        Cmd_Line = cmd
    End Function

    ' ===============================
    ' MODO AUTOMÁTICO - CORTE RETANGULAR
    ' ===============================

    Private Sub btn_ManValidCodeG_Click(sender As Object, e As EventArgs) Handles btn_ManValidCodeG.Click
        Try
            Automatico.CaixaAutomatica()  ' Gera código retangular
        Catch ex As Exception
            MessageBox.Show("Erro ao validar código G: " & ex.Message)
        End Try
    End Sub

    Private Sub btn_ManRun_Click(sender As Object, e As EventArgs) Handles btn_ManRun.Click
        Try
            Automatico.Run()  ' Executa G-Code retangular
        Catch ex As Exception
            MessageBox.Show("Erro ao executar o corte retangular: " & ex.Message)
        End Try
    End Sub


    ' ===============================
    ' MODO AUTOMÁTICO - CORTE CIRCULAR
    ' ===============================
    Private Sub btn_ManValidCodeGCircular_Click(sender As Object, e As EventArgs) Handles btn_ManValidCodeGCircular.Click
        Try
            AutomaticoCircular.CaixaAutomaticaCircular()    ' Gera código Circular
        Catch ex As Exception
            MessageBox.Show("Erro ao validar código G circular: " & ex.Message)
        End Try
    End Sub

    Private Sub btn_ManRunCircular_Click(sender As Object, e As EventArgs) Handles btn_ManRunCircular.Click
        Try
            AutomaticoCircular.Run()    ' Executa G-Code Circular
        Catch ex As Exception
            MessageBox.Show("Erro ao executar o G-code circular: " & ex.Message)
        End Try
    End Sub

    ' ===============================
    ' MODO AUTOMÁTICO - CORTE L
    ' ===============================
    Private Sub btn_ManValidCodeG_L_Click(sender As Object, e As EventArgs) Handles btn_ManValidCodeG_L.Click
        Try
            ' NOME CORRIGIDO: AutomaticoL (sem traço baixo)
            Automatico_L.CaixaAutomaticaL()
        Catch ex As Exception
            MessageBox.Show("Erro ao validar código G em L: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_ManRun_L_Click(sender As Object, e As EventArgs) Handles btn_ManRun_L.Click
        Try
            ' NOME CORRIGIDO: AutomaticoL (sem traço baixo)
            Automatico_L.Run()
        Catch ex As Exception
            MessageBox.Show("Erro ao executar o G-code em L: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ==========================
    ' FECHAR APLICAÇÃO 
    ' ==========================
    Private Sub Button_close_Click(sender As Object, e As EventArgs) Handles Button_close.Click
        tmr_match3.Enabled = False
        End
    End Sub

End Class