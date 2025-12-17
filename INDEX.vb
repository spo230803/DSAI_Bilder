Imports System.IO

Public Class INDEX

    Private Sub bnt_Avvia_Click(sender As Object, e As EventArgs) Handles bnt_Avvia.Click

        pb_2.Visible = True
        l_desc2.Visible = True
        l_pb2.Visible = True

        Dim siamoInErrore As Boolean = False

        ' Reset output
        ImageClassifierV2.ai_dirImg_Output = ""

        ' ========== MODALITÀ: MODELLO GIÀ ADDESTRATO ==========
        If tb_setFile_Bin.Text <> "" AndAlso tb_setFile_Categorie.Text <> "" Then

            If Not File.Exists(tb_setFile_Bin.Text) Then
                MsgBox("Il file del modello (.bin) selezionato non esiste!", MsgBoxStyle.Exclamation)
                siamoInErrore = True
            ElseIf Not File.Exists(tb_setFile_Categorie.Text) Then
                MsgBox("Il file delle categorie (.txt) selezionato non esiste!", MsgBoxStyle.Exclamation)
                siamoInErrore = True
            Else
                ImageClassifierV2.ai_fileAdestramento_BIN = tb_setFile_Bin.Text
                ImageClassifierV2.ai_fileAdestramento_Categorie = tb_setFile_Categorie.Text

                ImageClassifierV2.ai_dirAdestramento_DaAdestrare = ""
                ImageClassifierV2.ai_dirAdestramento_Salvataggio = ""
            End If

        Else
            ' ========== MODALITÀ: TRAINING ==========
            If tb_DirAdestra.Text = "" OrElse Not Directory.Exists(tb_DirAdestra.Text) Then
                MsgBox("Selezionare la cartella di addestramento!", MsgBoxStyle.Exclamation)
                siamoInErrore = True
            Else
                ImageClassifierV2.ai_dirAdestramento_DaAdestrare = tb_DirAdestra.Text
            End If

            If tb_setDir_SalvaAlenaemnto.Text = "" OrElse Not Directory.Exists(tb_setDir_SalvaAlenaemnto.Text) Then
                MsgBox("Selezionare la cartella di salvataggio!", MsgBoxStyle.Exclamation)
                siamoInErrore = True
            Else
                Dim baseDir As String = tb_setDir_SalvaAlenaemnto.Text

                Dim nomeFileModel As String = "addestramento"
                Dim nomeFileCategorie As String = "categorie"

                If tb_setFile_NomeAadestramento_BIN.Text <> "" Then
                    nomeFileModel = tb_setFile_NomeAadestramento_BIN.Text.Trim()
                End If
                If tb_setFile_NomeCategoria.Text <> "" Then
                    nomeFileCategorie = tb_setFile_NomeCategoria.Text.Trim()
                End If

                ImageClassifierV2.ai_dirAdestramento_Salvataggio = Path.Combine(baseDir, nomeFileModel & ".bin")
                ImageClassifierV2.ai_fileAdestramento_BIN = ImageClassifierV2.ai_dirAdestramento_Salvataggio
                ImageClassifierV2.ai_fileAdestramento_Categorie = Path.Combine(baseDir, nomeFileCategorie & ".txt")
            End If
        End If

        ' ========== CARTELLA IMMAGINI DA CLASSIFICARE ==========
        If tb_setDir_ImgDaClasifirare.Text = "" OrElse Not Directory.Exists(tb_setDir_ImgDaClasifirare.Text) Then
            MsgBox("Selezionare la cartella delle immagini da classificare!", MsgBoxStyle.Exclamation)
            siamoInErrore = True
        Else
            ImageClassifierV2.ai_dirIMG_daClassificare = tb_setDir_ImgDaClasifirare.Text
        End If

        ' ========== CARTELLA OUTPUT (OPZIONALE) ==========
        If tb_setDir_Output.Text <> "" Then
            If Directory.Exists(tb_setDir_Output.Text) Then
                ImageClassifierV2.ai_dirImg_Output = tb_setDir_Output.Text
            Else
                MsgBox("La cartella di output non esiste.", MsgBoxStyle.Exclamation)
                siamoInErrore = True
            End If
        End If

        If Not siamoInErrore Then
            ImageClassifierV2.Start()
            MsgBox("Elaborazione completata!", MsgBoxStyle.Information)
        Else
            MsgBox("Errore: controllare i campi obbligatori!", MsgBoxStyle.Critical)
        End If

    End Sub


    ' --- Selezione cartella salvataggio modello ---
    Private Sub bnt_setDir_Alenamento_Click(sender As Object, e As EventArgs) Handles bnt_setDir_Alenamento.Click
        FBD.Reset()
        If tb_setDir_SalvaAlenaemnto.Text <> "" Then
            FBD.SelectedPath = tb_setDir_SalvaAlenaemnto.Text
        End If

        FBD.ShowDialog()

        If Not String.IsNullOrEmpty(FBD.SelectedPath) Then
            tb_setDir_SalvaAlenaemnto.Text = FBD.SelectedPath
        End If
    End Sub

    ' --- Selezione modello bin già addestrato ---
    Private Sub bnt_setCartella_bin_Click(sender As Object, e As EventArgs) Handles bnt_setCartella_bin.Click
        OFD.Reset()
        If tb_setFile_Bin.Text <> "" Then
            OFD.FileName = tb_setFile_Bin.Text
        End If
        OFD.Filter = "File binario (*.bin)|*.bin"
        OFD.ShowDialog()

        If OFD.FileName <> "" Then
            tb_setFile_Bin.Text = OFD.FileName
            ' Se scegli un modello già addestrato, svuoto training dir per evitare ambiguità
            tb_DirAdestra.Text = ""
        End If
    End Sub

    ' --- Selezione file categorie già addestrato ---
    Private Sub bnt_setFiel_Categorie_Click(sender As Object, e As EventArgs) Handles bnt_setFiel_Categorie.Click
        OFD.Reset()
        If tb_setFile_Categorie.Text <> "" Then
            OFD.FileName = tb_setFile_Categorie.Text
        End If
        OFD.Filter = "File di testo (*.txt)|*.txt"
        OFD.ShowDialog()

        If OFD.FileName <> "" Then
            tb_setFile_Categorie.Text = OFD.FileName
            tb_DirAdestra.Text = ""
        End If
    End Sub

    ' --- Selezione cartella training ---
    Private Sub bnt_SetDir_Adestra_Click(sender As Object, e As EventArgs) Handles bnt_SetDir_Adestra.Click
        FBD.Reset()
        If tb_DirAdestra.Text <> "" Then
            FBD.SelectedPath = tb_DirAdestra.Text
        End If

        FBD.ShowDialog()

        If Not String.IsNullOrEmpty(FBD.SelectedPath) Then
            tb_DirAdestra.Text = FBD.SelectedPath
            ' Se scegli training, svuoto eventuali file già addestrati per evitare ambiguità
            ' (se vuoi permettere entrambe le cose, commenta queste due righe)
            tb_setFile_Bin.Text = ""
            tb_setFile_Categorie.Text = ""
        End If
    End Sub

    ' --- Selezione cartella immagini da classificare ---
    Private Sub bnt_setDir_ImgDaClasificare_Click(sender As Object, e As EventArgs) Handles bnt_setDir_ImgDaClasificare.Click
        FBD.Reset()
        If tb_setDir_ImgDaClasifirare.Text <> "" Then
            FBD.SelectedPath = tb_setDir_ImgDaClasifirare.Text
        End If

        FBD.ShowDialog()

        If Not String.IsNullOrEmpty(FBD.SelectedPath) Then
            tb_setDir_ImgDaClasifirare.Text = FBD.SelectedPath
        End If
    End Sub

    ' --- Selezione cartella output ---
    Private Sub bnt_setDir_Output_Click(sender As Object, e As EventArgs) Handles bnt_setDir_Output.Click
        FBD.Reset()
        If tb_setDir_Output.Text <> "" Then
            FBD.SelectedPath = tb_setDir_Output.Text
        End If

        FBD.ShowDialog()

        If Not String.IsNullOrEmpty(FBD.SelectedPath) Then
            tb_setDir_Output.Text = FBD.SelectedPath
        End If
    End Sub


End Class
