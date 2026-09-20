Imports System
Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Module Automatico

    ' Variável global para o caminho do arquivo
    Public filePath As String = String.Empty

    Public Sub CaixaAutomatica()

        ' LEITURA DE PARÂMETROS
        Try
            ' Variáveis de Corte
            Dim F As Integer = 0
            Dim S As Integer = 0
            Dim diamfresa As Integer = 0
            Dim increz As Integer = 0
            Dim planoseguranca As Integer = 0

            ' Tenta converter os textos para números (evita erros se estiver vazio)
            Integer.TryParse(MainForm.txt_AutF.Text, F)
            Integer.TryParse(MainForm.txt_AutS.Text, S)
            Integer.TryParse(MainForm.txt_diamfresa.Text, diamfresa)
            Integer.TryParse(MainForm.txt_increz.Text, increz)
            Integer.TryParse(MainForm.txt_AutZ.Text, planoseguranca)

            ' Dimensões do "Buraco" (Interior)
            Dim xinterior As Integer = MainForm.txt_Xinterior.Text
            Dim yinterior As Integer = MainForm.txt_Yinterior.Text
            Dim zinterior As Integer = MainForm.txt_Zinterior.Text

            ' Dimensões do Material Bruto (Exterior)
            Dim xexterior As Integer = MainForm.txt_Xexterior.Text
            Dim yexterior As Integer = MainForm.txt_Yexterior.Text
            Dim zexterior As Integer = MainForm.txt_Zexterior.Text

            ' Verifica se o corte deixa pelo menos 2mm de margem no fundo do bloco.
            ' Exemplo: Se Bloco=20 e Corte=19 -> 19 > (20-2) -> 19 > 18 -> ERRO.
            If zinterior > (zexterior - 2) Then
                MessageBox.Show("O corte é demasiado profundo (2mm de margem de Segurança).", "Erro de Segurança", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub '
            End If

            ' CÁLCULOS DA GEOMETRIA
            ' Definições da Ferramenta 
            Dim radiusTool As Integer = diamfresa / 2         ' Raio
            Dim overlap As Double = diamfresa * 0.4           ' 40% de sobreposição

            ' Ajustes da Área de Corte 
            ' Subtrai o diâmetro da fresa para calcular o percurso do centro da ferramenta
            Dim adjustedXInterior As Integer = xinterior - diamfresa
            Dim adjustedYInterior As Integer = yinterior - diamfresa

            ' Cálculo do Zero Peça (Centralização) 
            ' Calcula o offset considerando que X0 Y0 é o canto do bloco bruto
            Dim offsetX As Integer = (xexterior - adjustedXInterior) / 2
            Dim offsetY As Integer = (yexterior - adjustedYInterior) / 2

            ' Limites de Corte (Coordenadas Absolutas) 
            Dim minX As Double = offsetX
            Dim maxX As Double = offsetX + adjustedXInterior
            Dim minY As Double = offsetY
            Dim maxY As Double = offsetY + adjustedYInterior

            ' Parâmetros de Movimento 
            Dim stepY As Double = diamfresa - overlap
            If stepY < 1 Then stepY = 1

            Dim depth As Integer = zinterior

            ' Ponto central para a entrada em rampa
            Dim centroX As Double = minX + (adjustedXInterior / 2.0)
            Dim centroY As Double = minY + (adjustedYInterior / 2.0)

            ' GERAÇÃO DO CÓDIGO G
            Dim sb As New StringBuilder()

            ' Cabeçalho de Segurança 
            sb.AppendLine("( G-CODE RETANGULAR AUTOMATICO )")
            sb.AppendLine("G21    ; Unidades em mm")
            sb.AppendLine("G90    ; Posicionamento Absoluto")
            sb.AppendLine("G17    ; Plano XY")
            sb.AppendLine("G40    ; Cancela compensacao raio")
            sb.AppendLine("G49    ; Cancela compensacao altura")
            sb.AppendLine("G0 Z" & planoseguranca & "    ; Z de Seguranca")
            sb.AppendLine("M3 S" & S & "    ; Ligar Spindle")
            sb.AppendLine()

            Dim zAtual As Integer = 0

            ' Loop Principal de Profundidade (Z) 
            While zAtual > -depth

                ' Define próximo nível Z
                Dim zAnterior As Integer = zAtual
                zAtual -= increz

                ' Garante que não ultrapassa a profundidade final
                If zAtual < -depth Then zAtual = -depth

                sb.AppendLine("( NIVEL Z: " & zAtual & " )")

                ' Vai para o centro (em altura segura ou anterior)
                sb.AppendLine("G0 X" & centroX & " Y" & centroY)
                If zAnterior < 0 Then
                    sb.AppendLine("G0 Z" & (zAnterior + 1)) ' Sobe um pouco se já estiver dentro do buraco
                End If

                ' Entrada em Rampa
                ' Desce rápido até ao nível anterior
                sb.AppendLine("G1 Z" & zAnterior & " F" & (F * 0.8))
                ' Entra na diagonal (X move-se enquanto Z desce)
                sb.AppendLine("G1 X" & (centroX + (diamfresa / 2)) & " Z" & zAtual & " F" & (F * 0.5))
                ' Volta ao centro no nível Z final
                sb.AppendLine("G1 X" & centroX & " Z" & zAtual & " F" & F)

                ' Rotina de Corte (Zig-Zag)
                Dim currentY As Double = minY
                Dim direcaoDireita As Boolean = True

                ' Vai para o início do varrimento
                sb.AppendLine("G1 X" & minX & " Y" & minY & " F" & F)

                Do
                    Dim targetX As Double
                    If direcaoDireita Then
                        targetX = maxX
                    Else
                        targetX = minX
                    End If

                    ' Corte Horizontal
                    sb.AppendLine("G1 X" & targetX & " Y" & currentY)

                    ' Verifica fim do eixo Y
                    If currentY >= maxY Then Exit Do

                    ' Incremento Lateral
                    currentY += stepY
                    If currentY > maxY Then currentY = maxY

                    ' Movimento Vertical
                    sb.AppendLine("G1 Y" & currentY)

                    ' Inverte direção
                    direcaoDireita = Not direcaoDireita
                Loop

                ' Passe de Acabamento (Limpeza de Paredes)
                sb.AppendLine("( CONTORNO )")
                sb.AppendLine("G1 X" & maxX & " Y" & maxY & " F" & F) ' Garante que está no canto certo
                sb.AppendLine("G1 X" & maxX & " Y" & minY)
                sb.AppendLine("G1 X" & minX & " Y" & minY)
                sb.AppendLine("G1 X" & minX & " Y" & maxY)
                sb.AppendLine("G1 X" & maxX & " Y" & maxY) ' Fecha o quadrado

                ' Retração de Segurança
                sb.AppendLine("G0 Z" & planoseguranca)
                sb.AppendLine()

            End While

            ' Finalização
            sb.AppendLine("M5      ; Parar Spindle")
            sb.AppendLine("G0 Z" & planoseguranca)
            sb.AppendLine("G0 X0 Y0 ; Voltar a origem")
            sb.AppendLine("M30     ; Fim de Programa")

            ' Salvar o ficheiro
            ' Correção de decimal (Mach3 exige PONTO, Windows pode dar VIRGULA)
            Dim TextoFinal As String = sb.ToString().Replace(",", ".")

            ' Diálogo Salvar
            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "Arquivo Mach3 (*.tap)|*.tap|Todos os Arquivos (*.*)|*.*"
            saveDialog.DefaultExt = "tap"
            saveDialog.OverwritePrompt = True

            If saveDialog.ShowDialog() = DialogResult.OK Then
                Automatico.filePath = saveDialog.FileName

                ' Escreve no disco
                File.WriteAllText(Automatico.filePath, TextoFinal)

                ' Mostra na Interface (Textbox)
                MainForm.txt_ManCodG.Text = TextoFinal

                MessageBox.Show("Arquivo gerado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Erro ao gerar código: " & ex.Message & vbCrLf & "Verifique se todos os campos numéricos estão preenchidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ' Rotina para executar o arquivo no Mach3
    Public Sub Run()
        If String.IsNullOrEmpty(filePath) Then
            MessageBox.Show("Nenhum arquivo carregado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        MainForm.scriptObject.LoadFile(filePath)
        Thread.Sleep(1000)
        MainForm.scriptObject.RunFile()
    End Sub

End Module