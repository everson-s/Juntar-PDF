Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Public Class Form1

    Dim EnderecoDiretorio As String

    Private Sub AbrirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirToolStripMenuItem.Click


#Region "Para abrir os arquivos"

        'Título da pasta que que contém os arquivos em PDF
        OFD.Title = "Selecione os arquivos em PDF"

        'O filter irá filtrar somente arquivos PDF's encontrados na pasta
        OFD.Filter = "Arquivos em PDF |*.pdf"

        'O Multiselect, sendo habilitado para verdadeiro, irá possibilitar que vários PDF's sejam selecionados
        OFD.Multiselect = True

        'Será o nome apresentado no TextBox antes da seleção dos arquivos
        OFD.FileName = "Arquivos em PDF"

        'Abre a pasta de Documentos do usuário
        OFD.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments

#End Region

        'Abre uma pasta para selecionar os arquivos em PDF
        If OFD.ShowDialog = DialogResult.OK Then



            EnderecoDiretorio = 

        End If

        MessageBox.Show("Endereço do Diretório: " + EnderecoDiretorio)

    End Sub

End Class
