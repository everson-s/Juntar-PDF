Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Public Class Form1

    Dim EnderecoDiretorio As String
    Dim NumeroDePaginas As Integer
    Public EnderecoDeArquivos As List(Of String)

    Private Sub AbrirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirToolStripMenuItem.Click

        'Adiciona uma descrição para o Folder Browser Dialog
        FBD.Description = "Escolha uma pasta para salvar o arquivo"

        'Se a pasta for selecionada e for clicado o "OK", o endereço do diretório será guaradado na variável EnderecoDiretorio
        If FBD.ShowDialog = DialogResult.OK Then

            EnderecoDiretorio = FBD.SelectedPath

        End If


#Region "Para Selecionar os arquivos PDF"

        'Título da pasta que que contém os arquivos em PDF
        OFD.Title = "Selecione os arquivos em PDF"

        'O filter irá filtrar somente arquivos PDF's encontrados na pasta
        OFD.Filter = "Arquivos em PDF |*.pdf"

        'O Multiselect, sendo habilitado para verdadeiro, irá possibilitar que vários PDF's sejam selecionados
        OFD.Multiselect = True

        'Será o nome apresentado no TextBox antes da seleção dos arquivos
        OFD.FileName = "Arquivos em PDF"

        'Abre a pasta selecionada para salvar o arquivo no formato PDF
        OFD.InitialDirectory = EnderecoDiretorio

#End Region

        'Crie uma nova instância de Documento (Document).
        Dim NovoPDF As New Document

        'Crie uma nova instância para copiar os arquivos em PDF.
        'Passe o nome do documento (NovoPDF) e endereço do diretório, com o nome do arquivo que será criado.
        Dim CopiaPDF As New PdfCopy(NovoPDF, New FileStream(EnderecoDiretorio + "\Novo Documento.pdf", FileMode.Create))

        'Abra o novo documento (NovoPDF).
        NovoPDF.Open()

        'Abre uma pasta para selecionar os arquivos em PDF
        If OFD.ShowDialog = DialogResult.OK Then

            'Para cada arquivo em PDF selecionado faça
            For Each arquivo In OFD.FileNames

                'Escreva os nomes dos arquivos e armazene esta lista na variável EnderecoDeArquivos.
                EnderecoDeArquivos = New List(Of String)() From {arquivo}

                'Leia o primeira arquivo em PDF.
                Dim LeiaPDF As New PdfReader(arquivo)

                'Conte o número de páginas que o primeiro arquivo em PDF possui.
                NumeroDePaginas = LeiaPDF.NumberOfPages

                'Para cada página, partindo da primeira página(1) até a última (NumeroDePaginas), faça
                For i As Integer = 1 To NumeroDePaginas

                    'Crie uma nova instância, chamada PaginaImportada, copie a página atual no documento
                    ' que está sendo lido (LeiaPDF). 
                    Dim PaginaImportada As PdfImportedPage = CopiaPDF.GetImportedPage(LeiaPDF, i)

                    'Adicione esta página copiada ao novo documento (CopiaPDF).
                    CopiaPDF.AddPage(PaginaImportada)

                Next

            Next

        End If

        'Feche o documento (NovoPDF).
        NovoPDF.Close()

        MessageBox.Show("Arquivo criado com sucesso!")

    End Sub

End Class
