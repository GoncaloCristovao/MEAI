Imports System
Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms

Public Module Automatico_L

    ' Variável Global para o ficheiro
    Public filePath As String = String.Empty

    Public Sub CaixaAutomaticaL()

        ' LEITURA DE PARÂMETROS 
        Try
            ' Parâmetros de Processo 
            Dim F As Integer = 0
            Dim S As Integer = 0
            Dim diamfresa As Integer = 0
            Dim increz As Integer = 0
            Dim planoseguranca As Integer = 0

            ' TryParse para evitar erros com campos vazios
            Integer.TryParse(MainForm.txt_AutF_L.Text, F)
            Integer.TryParse(MainForm.txt_AutS_L.Text, S)
            Integer.TryParse(MainForm.txt_diamfresa_L.Text, diamfresa)
            Integer.TryParse(MainForm.txt_increz_L.Text, increz)
            Integer.TryParse(MainForm.txt_AutZ_L.Text, planoseguranca)

            ' GEOMETRIA DO L 
            ' Profundidade
            Dim zInterior As Integer = MainForm.txt_Zinterior_L.Text

            ' Medidas do L
            Dim larguraTotal As Integer = MainForm.txt_CompBase_L.Text    ' X Total
            Dim alturaTotal As Integer = MainForm.txt_AlturaPerna_L.Text  ' Y Total
            Dim espessura As Integer = MainForm.txt_Espessura_L.Text      ' Espessura Única

            ' Dimensões do Bloco 
            Dim xExterior As Integer = MainForm.txt_Xexterior_L.Text
            Dim yExterior As Integer = MainForm.txt_Yexterior_L.Text
            Dim zExterior As Integer = MainForm.txt_Zexterior_L.Text


            ' CÁLCULOS DA GEOMETRIA
            Dim raioFresa As Integer = diamfresa / 2

            ' Verificações de Segurança
            ' Proteção: Fresa não pode ser maior que a espessura
            If espessura < diamfresa Then
                MessageBox.Show("A fresa é demasiado grossa para a espessura definida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Proteção: Espessura não pode ser maior que o tamanho total
            If espessura >= larguraTotal Or espessura >= alturaTotal Then
                MessageBox.Show("A espessura não pode ser maior que o tamanho total!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Proteção: Altura da Perna não pode ser maior que o eixo Y do bloco
            If alturaTotal >= yExterior Then
                MessageBox.Show("O corte deve ser inferior à dimensão y do Bloco.", "Erro de Segurança", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Proteção: Profundidade de corte (Regra dos 2mm)
            If zInterior > (zExterior - 2) Then
                MessageBox.Show("O corte é demasiado profundo (2mm de margem de Segurança).", "Erro de Segurança", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Calcular Offset (Centrar o L no bloco bruto)
            Dim offsetX As Integer = (xExterior - larguraTotal) / 2
            Dim offsetY As Integer = (yExterior - alturaTotal) / 2

            ' DEFINIÇÃO DOS LIMITES DE CORTE 
            ' Limites Exteriores (Caixa envolvente)
            Dim minX As Integer = offsetX + raioFresa
            Dim maxX As Integer = offsetX + larguraTotal - raioFresa
            Dim minY As Integer = offsetY + raioFresa
            Dim maxY As Integer = offsetY + alturaTotal - raioFresa

            ' Limites Interiores (Calculados subtraindo o raio para garantir a espessura correta)
            ' Altura máxima da zona da base (Y)
            Dim maxY_ZonaBaixo As Integer = offsetY + espessura - raioFresa
            ' Largura máxima da zona da perna (X)
            Dim maxX_ZonaCima As Integer = offsetX + espessura - raioFresa

            Dim depth As Integer = zInterior
            Dim stepY As Integer = diamfresa * 0.6
            If stepY < 1 Then stepY = 1


            ' GERAÇÃO DO G-CODE
            Dim sb As New StringBuilder()

            ' Cabeçalho de Segurança 
            sb.AppendLine("( G-CODE AUTOMATICO - CORTE EM L )")
            sb.AppendLine("G21    ; Unidades em mm")
            sb.AppendLine("G90    ; Posicionamento Absoluto")
            sb.AppendLine("G17    ; Plano XY")
            sb.AppendLine("G40    ; Cancela compensacao raio")
            sb.AppendLine("G49    ; Cancela compensacao altura")
            sb.AppendLine("G0 Z" & planoseguranca & "    ; Z de Seguranca")
            sb.AppendLine("M3 S" & S & "    ; Ligar Spindle")
            sb.AppendLine()

            '  Entrada em Rampa
            Dim rampSteps As Integer = Math.Ceiling(planoseguranca / increz)
            If rampSteps < 1 Then rampSteps = 1
            Dim currentZ As Integer = planoseguranca

            ' Centro da área de interseção (quadrado de espessura x espessura)
            Dim entradaX As Integer = minX + ((espessura / 2) - raioFresa)
            Dim entradaY As Integer = minY + ((espessura / 2) - raioFresa)

            sb.AppendLine("( ENTRADA EM RAMPA )")
            sb.AppendLine("G0 X" & entradaX & " Y" & entradaY)

            For i As Integer = 1 To rampSteps
                currentZ -= increz
                If currentZ < 0 Then currentZ = 0
                sb.AppendLine("G1 X" & (entradaX + 1) & " Y" & (entradaY + 1) & " Z" & currentZ & " F" & CInt(F / 2))
                sb.AppendLine("G1 X" & entradaX & " Y" & entradaY & " Z" & currentZ & " F" & F)
                If currentZ = 0 Then Exit For
            Next

            ' Niveis de Z <= Z corte
            While currentZ > -depth

                currentZ -= increz
                If currentZ < -depth Then currentZ = -depth

                sb.AppendLine()
                sb.AppendLine("( NIVEL Z = " & currentZ & " )")
                sb.AppendLine("G1 Z" & currentZ & " F" & CInt(F / 2))

                ' Desbaste em Zig-Zag 
                Dim curY As Integer = minY
                Dim dir As Boolean = True

                ' ZONA 1: BASE 
                sb.AppendLine("( ZONA 1: BASE )")

                While curY <= maxY_ZonaBaixo
                    Dim targetX As Integer
                    If dir Then targetX = maxX Else targetX = minX

                    sb.AppendLine("G1 X" & targetX & " Y" & curY & " F" & F)

                    ' Verifica se vai passar para a zona da coluna
                    If (curY + stepY) > maxY_ZonaBaixo Then
                        curY = maxY_ZonaBaixo
                        sb.AppendLine("G1 Y" & curY & " F" & F)
                        sb.AppendLine("G1 X" & (If(dir, minX, maxX)) & " F" & F)
                        Exit While
                    End If

                    curY += stepY
                    sb.AppendLine("G1 Y" & curY & " F" & F)
                    dir = Not dir
                End While

                ' ZONA 2: PERNA VERTICAL 
                sb.AppendLine("( ZONA 2: PERNA VERTICAL )")

                If curY < maxY Then
                    curY += stepY
                    If curY > maxY Then curY = maxY
                    sb.AppendLine("G1 Y" & curY & " F" & F)
                End If

                While curY <= maxY
                    Dim targetX As Integer
                    ' A espessura limita o movimento em X
                    ' AQUI: Usa-se maxX_ZonaCima para garantir a largura correta da perna
                    If dir Then targetX = maxX_ZonaCima Else targetX = minX

                    sb.AppendLine("G1 X" & targetX & " Y" & curY & " F" & F)

                    If curY >= maxY Then Exit While

                    curY += stepY
                    If curY > maxY Then curY = maxY

                    sb.AppendLine("G1 Y" & curY & " F" & F)
                    dir = Not dir
                End While

                ' Contorno
                sb.AppendLine("( CONTORNO )")

                ' Canto Inferior Esquerdo
                sb.AppendLine("G1 X" & minX & " Y" & minY & " F" & F)
                ' Canto Inferior Direito (Ponta da base)
                sb.AppendLine("G1 X" & maxX & " Y" & minY)
                ' Topo da base (Altura = Espessura)
                sb.AppendLine("G1 X" & maxX & " Y" & maxY_ZonaBaixo)

                ' Canto Interior (Reentrância) 
                ' Usamos maxX_ZonaCima para alinhar com a perna vertical
                sb.AppendLine("G1 X" & maxX_ZonaCima & " Y" & maxY_ZonaBaixo)

                ' Topo interior da coluna
                sb.AppendLine("G1 X" & maxX_ZonaCima & " Y" & maxY)
                ' Topo esquerdo
                sb.AppendLine("G1 X" & minX & " Y" & maxY)
                ' Fecha
                sb.AppendLine("G1 X" & minX & " Y" & minY)

                sb.AppendLine("G0 Z" & planoseguranca)

            End While

            ' Fim do Código G 
            sb.AppendLine("M5")
            sb.AppendLine("G0 Z" & planoseguranca)
            sb.AppendLine("G0 X0 Y0")
            sb.AppendLine("M30")

            ' Substituir vírgulas por pontos para o Mach3
            Dim TextoFinal As String = sb.ToString().Replace(",", ".")
            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "Arquivo Mach3 (*.tap)|*.tap"
            saveDialog.DefaultExt = "tap"

            ' Salvar o ficheiro
            If saveDialog.ShowDialog() = DialogResult.OK Then
                Automatico_L.filePath = saveDialog.FileName
                File.WriteAllText(Automatico_L.filePath, TextoFinal)

                ' Atualiza a caixa de texto específica do L
                If MainForm.txt_ManCodG_L IsNot Nothing Then
                    MainForm.txt_ManCodG_L.Text = TextoFinal
                End If

                MessageBox.Show("Arquivo L gerado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Erro! Verifique se preencheu todos os números.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub Run()
        If Not String.IsNullOrEmpty(filePath) Then
            MainForm.scriptObject.LoadFile(filePath)
            Thread.Sleep(1000)
            MainForm.scriptObject.RunFile()
        End If
    End Sub

End Module