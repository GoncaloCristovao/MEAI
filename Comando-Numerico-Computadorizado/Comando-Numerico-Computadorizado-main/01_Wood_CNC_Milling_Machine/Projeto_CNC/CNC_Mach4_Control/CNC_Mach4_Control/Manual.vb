Module Manual
    ' Rotinas Modo Manual

    Class ManualRotinas
        Public Per As Double


        ' Exemplo de uma subrotina
        Public Sub Perimetro(ByVal raio As Double)
            ' Calculo do Perimetro
            Per = 2 * 3.14 * raio
        End Sub

        ' Exemplo de uma função
        Public Function PosicaoX(ByVal comp As Double) As Double
            PosicaoX = comp * 2
            MainForm.txt_ManPosX.Text = "555"
            Return PosicaoX
        End Function
    End Class

    ' *************************************************************************
    ' Declaração de Rotinas a ser utilizadas pelo programa principal: MainForm
    ' *************************************************************************
    Public Sub Manual_SetRefPoint()
        ' Definição do Ponto de Referência do Equipamento (POM)
        MainForm.mach = Microsoft.VisualBasic.Interaction.GetObject(, "Mach4.Document")
        MainForm.scriptObject = MainForm.mach.GetScriptDispatch()

        MainForm.scriptObject.SetMachZero(0) ' Zera o Eixo X
        MainForm.scriptObject.SetMachZero(1) ' Zera o Eixo Y
        MainForm.scriptObject.SetMachZero(2) ' Zera o Eixo Z
    End Sub

End Module