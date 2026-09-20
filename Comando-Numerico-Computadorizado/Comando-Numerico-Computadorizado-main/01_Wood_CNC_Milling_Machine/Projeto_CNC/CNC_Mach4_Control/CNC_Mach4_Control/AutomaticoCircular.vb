Imports System
Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms

Public Module AutomaticoCircular

    ' Variável Global para guardar o caminho do ficheiro
    Public filePath As String = String.Empty

    Public Sub CaixaAutomaticaCircular()

        ' LEITURA DE PARÂMETROS 
        Try
            ' Parâmetros de Corte
            Dim F As Integer = MainForm.txt_AutFCricular.Text
            Dim S As Integer = MainForm.txt_AutSCircular.Text
            Dim diamFresa As Integer = MainForm.txt_diamfresaCricular.Text
            Dim increz As Integer = MainForm.txt_increzCircular.Text
            Dim planoseguranca As Integer = MainForm.txt_AutZCircular.Text

            ' GEOMETRIA DO CÍRCULO 
            ' Centro do Círculo
            Dim centroX As Integer = MainForm.txt_XinteriorCircular.Text
            Dim centroY As Integer = MainForm.txt_YinteriorCircular.Text

            ' Raio da Cavidade
            Dim raioCavidade As Integer = MainForm.txt_raioCirculo.Text

            ' Profundidade Total (Lida do Z Interior, como pediu)
            Dim zinterior As Integer = MainForm.txt_ZinteriorCricular.Text

            ' Z Exterior (Altura do bloco) - Não afeta a profundidade do corte
            Dim zexterior As Integer = MainForm.txt_ZexteriorCircular.Text

            ' CÁLCULOS DA GEOMETRIA 
            Dim raioFresa As Integer = diamFresa / 2

            ' Raio do percurso da ferramenta = Raio Cavidade - Raio Fresa
            Dim raioPercurso As Integer = raioCavidade - raioFresa

            ' Verificações de Segurança
            ' Proteção: Se a fresa for maior que o buraco
            If raioPercurso <= 0 Then
                MessageBox.Show("A fresa é demasiado grande para este raio!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            ' Proteção: Profundidade de corte
            If zinterior > (zexterior - 2) Then
                MessageBox.Show("O corte é demasiado profundo (2mm de margem de Segurança).", "Erro de Segurança", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Passo lateral da espiral
            Dim stepRadius As Integer = diamFresa * 0.4
            If stepRadius < 1 Then stepRadius = 1

            ' Profundidade total a cortar
            Dim depth As Integer = zinterior

            ' GERAÇÃO DO G-CODE 
            Dim sb As New StringBuilder()

            ' Cabeçalho
            sb.AppendLine("( G-CODE CIRCULAR AUTOMATICO )")
            sb.AppendLine($"( Centro: X{centroX} Y{centroY} | Raio: {raioCavidade} )")
            sb.AppendLine("G21    ; Metrico")
            sb.AppendLine("G90    ; Absoluto")
            sb.AppendLine("G17    ; Plano XY")
            sb.AppendLine("G40    ; Cancelar compensação")
            sb.AppendLine("G49    ; Cancelar offset")
            sb.AppendLine("G94    ; Avanço em mm/min")
            sb.AppendLine()
            sb.AppendLine("G0 Z" & planoseguranca & "    ; Altura Segura")
            sb.AppendLine("M3 S" & S & "    ; Ligar Spindle")
            sb.AppendLine()

            ' Entrada em Rampa 
            ' Calcula quantos passos são precisos para descer a rampa
            Dim rampSteps As Integer = Math.Ceiling(planoseguranca / increz)
            If rampSteps < 1 Then rampSteps = 1
            Dim currentZ As Integer = planoseguranca

            sb.AppendLine("( ENTRADA EM RAMPA )")
            sb.AppendLine("G0 X" & centroX & " Y" & centroY) ' Vai para o CENTRO exato

            For i As Integer = 1 To rampSteps
                currentZ -= increz
                If currentZ < 0 Then currentZ = 0

                ' Desce no centro suavemente
                sb.AppendLine("G1 Z" & currentZ & " F" & (F / 2))

                If currentZ = 0 Then Exit For
            Next
            sb.AppendLine()

            ' Niveis em Z
            ' Reinicia Z para 0 para começar a afundar no material
            currentZ = 0

            While currentZ > -depth

                ' Calcular próximo nível de profundidade
                Dim zAnterior As Integer = currentZ
                currentZ -= increz
                If currentZ < -depth Then currentZ = -depth

                sb.AppendLine("( NIVEL Z = " & currentZ & " )")

                ' Mergulho no centro (Rampa Linear curta)
                sb.AppendLine("G0 X" & centroX & " Y" & centroY) ' Garante centro
                sb.AppendLine("G0 Z" & (zAnterior + 1)) ' Aproximação rápida
                sb.AppendLine("G1 Z" & currentZ & " F" & (F / 2)) ' Corte vertical lento

                ' Desbaste em espira(~30º)
                Dim rAtual As Double = 0
                Dim angulo As Double = 0

                ' Primeiro ponto de corte no centro
                sb.AppendLine("G1 X" & centroX & " Y" & centroY & " F" & F)

                While rAtual < raioPercurso
                    ' Aumenta o raio suavemente 
                    rAtual += (stepRadius / 12.0)
                    If rAtual > raioPercurso Then rAtual = raioPercurso

                    ' Roda o ângulo
                    angulo += 0.52

                    ' Matemática para converter Polar (Raio/Angulo) em Cartesiano (X/Y)
                    Dim nextX As Double = centroX + (rAtual * Math.Cos(angulo))
                    Dim nextY As Double = centroY + (rAtual * Math.Sin(angulo))

                    sb.AppendLine("G1 X" & Math.Round(nextX, 3) & " Y" & Math.Round(nextY, 3))
                End While

                ' Contorno
                sb.AppendLine()
                sb.AppendLine("( CONTORNO )")

                ' Ponto de início do círculo de acabamento 
                Dim startX As Double = centroX + raioPercurso
                Dim startY As Double = centroY

                ' Move para a parede
                sb.AppendLine("G1 X" & startX & " Y" & startY & " F" & F)

                ' G3 faz um círculo perfeito Anti-Horário
                ' I é a distância do ponto atual ao centro em X 
                sb.AppendLine("G3 X" & startX & " Y" & startY & " I-" & raioPercurso & " J0")

                sb.AppendLine()

                ' Retração de Segurança entre niveis
                sb.AppendLine("G0 Z" & planoseguranca)
                sb.AppendLine()

            End While

            ' Fim do Código G 
            sb.AppendLine("M5")
            sb.AppendLine("G0 X0 Y0")
            sb.AppendLine("M30")

            ' Substituir vírgulas por pontos para o Mach3
            Dim TextoFinal As String = sb.ToString().Replace(",", ".")

            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "Arquivo Mach3 (*.tap)|*.tap|Todos os Arquivos (*.*)|*.*"
            saveDialog.DefaultExt = "tap"
            saveDialog.OverwritePrompt = True

            ' Salvar o ficheiro
            If saveDialog.ShowDialog() = DialogResult.OK Then
                AutomaticoCircular.filePath = saveDialog.FileName

                File.WriteAllText(AutomaticoCircular.filePath, TextoFinal)
                MainForm.txt_ManCodGCircular.Text = TextoFinal

                MessageBox.Show("Arquivo gerado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Erro! Verifique se todos os campos numéricos estão preenchidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub Run()

        MainForm.scriptObject.LoadFile(filePath)
        Thread.Sleep(1000)
        MainForm.scriptObject.RunFile()
    End Sub

End Module