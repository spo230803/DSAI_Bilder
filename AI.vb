Imports Accord.MachineLearning
Imports Accord.IO
Imports OpenCvSharp
Imports System.IO

Module ImageClassifierV2

    Private knn As KNearestNeighbors
    Private labelNames As New List(Of String)()
    Private debugStoria As New List(Of String)()

    Public ai_fileAdestramento_BIN As String
    Public ai_fileAdestramento_Categorie As String
    Public ai_dirAdestramento_DaAdestrare As String
    Public ai_dirAdestramento_Salvataggio As String  ' se già contiene path+nomefile OK
    Public ai_dirIMG_daClassificare As String
    Public ai_dirImg_Output As String

    Private ReadOnly estensioniValide As HashSet(Of String) =
        New HashSet(Of String)(StringComparer.OrdinalIgnoreCase) From
        {".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tiff"}

    ' === Parametri feature (stabili e globali) ===
    Private Const ResizeW As Integer = 128
    Private Const ResizeH As Integer = 128

    ' Istogrammi HSV: H bins + S bins + V bins
    Private Const HBins As Integer = 32
    Private Const SBins As Integer = 32
    Private Const VBins As Integer = 32

    ' HOG su 64x64 per compattezza
    Private ReadOnly hog As HOGDescriptor =
        New HOGDescriptor(
            winSize:=New OpenCvSharp.Size(64, 64),
            blockSize:=New OpenCvSharp.Size(16, 16),
            blockStride:=New OpenCvSharp.Size(8, 8),
            cellSize:=New OpenCvSharp.Size(8, 8),
            nbins:=9
        )

    Sub Start()
        debugStoria.Clear()
        debug("Start")

        Dim expectedFeatureCount As Integer = -1

        ' --- Carica modello se esiste ---
        Dim binPath As String = If(Not String.IsNullOrWhiteSpace(ai_fileAdestramento_BIN), ai_fileAdestramento_BIN, ai_dirAdestramento_Salvataggio)

        If File.Exists(binPath) AndAlso File.Exists(ai_fileAdestramento_Categorie) Then
            knn = Serializer.Load(Of KNearestNeighbors)(binPath)
            labelNames = File.ReadAllLines(ai_fileAdestramento_Categorie).ToList()
            expectedFeatureCount = knn.Inputs(0).Length
            debug("Modello caricato: " & binPath)
            debug("Feature attese: " & expectedFeatureCount)
        Else
            debug("Modello non trovato, avvio training...")
            Try
                TrainModel(binPath)
                expectedFeatureCount = knn.Inputs(0).Length
                debug("Training completato. Feature attese: " & expectedFeatureCount)
            Catch ex As Exception
                MsgBox("Errore durante l'addestramento del modello: " & ex.Message, MsgBoxStyle.Critical, "Exception")
                Exit Sub
            End Try
        End If

        ' --- Classificazione cartella ---
        If String.IsNullOrWhiteSpace(ai_dirIMG_daClassificare) OrElse Not Directory.Exists(ai_dirIMG_daClassificare) Then
            MsgBox("Cartella immagini da classificare non valida.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim files As String() = Directory.GetFiles(ai_dirIMG_daClassificare)

        ' UI
        INDEX.pb_1.Maximum = Math.Max(1, files.Length)
        INDEX.pb_1.Value = 0
        INDEX.pb_2.Visible = False
        INDEX.l_desc2.Visible = False
        INDEX.l_pb2.Visible = False
        Application.DoEvents()

        For Each file_ora As String In files
            INDEX.pb_1.Value = Math.Min(INDEX.pb_1.Value + 1, INDEX.pb_1.Maximum)
            INDEX.l_desc1.Text = "Analizzo: " & Path.GetFileName(file_ora)
            INDEX.l_pb1.Text = INDEX.pb_1.Value & " di " & INDEX.pb_1.Maximum
            Application.DoEvents()

            If Not File.Exists(file_ora) Then Continue For
            If Not estensioniValide.Contains(Path.GetExtension(file_ora)) Then Continue For

            Try
                Using matImg As Mat = Cv2.ImRead(file_ora, ImreadModes.Color)
                    If matImg.Empty() Then
                        debug("Immagine vuota/illeggibile: " & file_ora)
                        Continue For
                    End If

                    Dim testFeatures As Double() = ExtractFeatures(matImg, file_ora)

                    If testFeatures.Length <> expectedFeatureCount Then
                        debug("ERRORE feature count: " & testFeatures.Length & " (attese " & expectedFeatureCount & ") per " & Path.GetFileName(file_ora))
                        Continue For
                    End If

                    Dim predictedLabel As Integer = knn.Decide(testFeatures)
                    Dim categoria As String = If(predictedLabel >= 0 AndAlso predictedLabel < labelNames.Count, labelNames(predictedLabel), "Sconosciuta")

                    debug("Predetta: " & categoria & " -> " & Path.GetFileName(file_ora))

                    If Not String.IsNullOrWhiteSpace(ai_dirImg_Output) Then
                        Dim destDir As String = Path.Combine(ai_dirImg_Output, categoria)
                        If Not Directory.Exists(destDir) Then Directory.CreateDirectory(destDir)

                        Dim destFile As String = Path.Combine(destDir, Path.GetFileName(file_ora))
                        File.Copy(file_ora, destFile, True)

                        If INDEX.cb_cancellaFileOrignale.Checked Then
                            File.Delete(file_ora)
                        End If

                        debug("Output: " & destFile)
                    End If
                End Using
            Catch ex As Exception
                debug("Errore su " & Path.GetFileName(file_ora) & ": " & ex.Message)
            End Try
        Next

        debug("Fine.")
    End Sub

    Private Sub TrainModel(ByVal modelPath As String)
        If String.IsNullOrWhiteSpace(ai_dirAdestramento_DaAdestrare) OrElse Not Directory.Exists(ai_dirAdestramento_DaAdestrare) Then
            Throw New DirectoryNotFoundException("Cartella training non valida: " & ai_dirAdestramento_DaAdestrare)
        End If

        Dim trainingDirs As String() = Directory.GetDirectories(ai_dirAdestramento_DaAdestrare)
        If trainingDirs.Length = 0 Then
            Throw New Exception("Nessuna sottocartella trovata nel training set.")
        End If

        Dim features As New List(Of Double())()
        Dim labels As New List(Of Integer)()
        labelNames.Clear()

        ' UI
        INDEX.pb_1.Maximum = trainingDirs.Length
        INDEX.pb_1.Value = 0
        INDEX.pb_2.Visible = True
        INDEX.l_desc2.Visible = True
        INDEX.l_pb2.Visible = True
        Application.DoEvents()

        Dim labelIndex As Integer = 0

        For Each dir As String In trainingDirs
            Dim category As String = Path.GetFileName(dir)

            Dim imageFiles As String() =
                Directory.GetFiles(dir).
                Where(Function(f) estensioniValide.Contains(Path.GetExtension(f))).ToArray()

            INDEX.pb_1.Value = Math.Min(INDEX.pb_1.Value + 1, INDEX.pb_1.Maximum)
            INDEX.l_desc1.Text = "Addestramento categoria: " & category
            INDEX.l_pb1.Text = INDEX.pb_1.Value & " di " & INDEX.pb_1.Maximum

            INDEX.pb_2.Value = 0
            INDEX.pb_2.Maximum = Math.Max(1, imageFiles.Length)
            Application.DoEvents()

            Dim addedAny As Boolean = False

            For Each imagePath As String In imageFiles
                INDEX.pb_2.Value = Math.Min(INDEX.pb_2.Value + 1, INDEX.pb_2.Maximum)
                INDEX.l_desc2.Text = "Immagine: " & Path.GetFileName(imagePath)
                INDEX.l_pb2.Text = INDEX.pb_2.Value & " di " & INDEX.pb_2.Maximum
                Application.DoEvents()

                Try
                    Using matImg As Mat = Cv2.ImRead(imagePath, ImreadModes.Color)
                        If matImg.Empty() Then
                            debug("Skip (vuota): " & imagePath)
                            Continue For
                        End If

                        Dim descriptor As Double() = ExtractFeatures(matImg, imagePath)
                        features.Add(descriptor)
                        labels.Add(labelIndex)
                        addedAny = True
                    End Using
                Catch ex As Exception
                    debug("Errore lettura " & Path.GetFileName(imagePath) & ": " & ex.Message)
                End Try
            Next

            If addedAny Then
                labelNames.Add(category)
                labelIndex += 1
            Else
                debug("ATTENZIONE: categoria senza immagini valide: " & category)
            End If
        Next

        If features.Count = 0 OrElse labels.Count = 0 OrElse labelNames.Count = 0 Then
            Throw New Exception("Dataset di training vuoto o non valido.")
        End If

        ' kNN
        Dim featureMatrix As Double()() = features.ToArray()
        Dim labelArray As Integer() = labels.ToArray()

        knn = New KNearestNeighbors(k:=3, inputs:=featureMatrix, outputs:=labelArray)
        'Dim learner As New KNearestNeighborsLearning() With {
        '.K = 3
        '}

        'knn = learner.Learn(featureMatrix, labelArray)

        ' Salvataggio
        Dim finalModelPath As String = modelPath
        If String.IsNullOrWhiteSpace(finalModelPath) Then finalModelPath = ai_dirAdestramento_Salvataggio

        Serializer.Save(knn, finalModelPath)
        File.WriteAllLines(ai_fileAdestramento_Categorie, labelNames)

        debug("Modello salvato: " & finalModelPath)
        debug("Categorie salvate: " & ai_fileAdestramento_Categorie)
        debug("Feature length: " & knn.Inputs(0).Length)
    End Sub

    Public Function ExtractFeatures(ByVal matImg As Mat, Optional ByVal imagePath As String = "") As Double()
        ' Ritorna sempre un vettore a lunghezza fissa:
        ' HSV hist (HBins+SBins+VBins) + HOG descriptor

        If matImg Is Nothing OrElse matImg.Empty() Then
            debug("Errore: immagine non valida (ExtractFeatures). " & If(imagePath <> "", Path.GetFileName(imagePath), ""))
            Return CreateZeroVector()
        End If

        ' 1) Resize fisso
        Dim resized As New Mat()
        Cv2.Resize(matImg, resized, New OpenCvSharp.Size(ResizeW, ResizeH), 0, 0, InterpolationFlags.Area)

        ' 2) HSV histogram (global color)
        Dim hsv As New Mat()
        Cv2.CvtColor(resized, hsv, ColorConversionCodes.BGR2HSV)

        Dim hHist As Double() = CalcHist1D(hsv, channel:=0, bins:=HBins, rangeMin:=0, rangeMax:=180)
        Dim sHist As Double() = CalcHist1D(hsv, channel:=1, bins:=SBins, rangeMin:=0, rangeMax:=256)
        Dim vHist As Double() = CalcHist1D(hsv, channel:=2, bins:=VBins, rangeMin:=0, rangeMax:=256)

        ' 3) HOG (texture/shape) su grayscale 64x64
        Dim gray As New Mat()
        Cv2.CvtColor(resized, gray, ColorConversionCodes.BGR2GRAY)

        Dim gray64 As New Mat()
        Cv2.Resize(gray, gray64, New OpenCvSharp.Size(64, 64), 0, 0, InterpolationFlags.Area)

        Dim hogSingle As Single() = hog.Compute(gray64)
        Dim hogD As Double() = hogSingle.Select(Function(x) CDbl(x)).ToArray()

        ' 4) Concat + normalize
        Dim allFeat As Double() = hHist.Concat(sHist).Concat(vHist).Concat(hogD).ToArray()
        NormalizeL2InPlace(allFeat)

        If imagePath <> "" Then
            debug("Analizzata: " & Path.GetFileName(imagePath) & " | Feature: " & allFeat.Length)
        End If

        Return allFeat
    End Function

    Private Function CalcHist1D(ByVal hsv As Mat, ByVal channel As Integer, ByVal bins As Integer, ByVal rangeMin As Single, ByVal rangeMax As Single) As Double()
        Dim channels As Integer() = {channel}
        Dim histSize As Integer() = {bins}
        Dim ranges As Rangef() = {New Rangef(rangeMin, rangeMax)}

        Using hist As New Mat()
            Cv2.CalcHist(
                images:=New Mat() {hsv},
                channels:=channels,
                mask:=New Mat(),
                hist:=hist,
                dims:=1,
                histSize:=histSize,
                ranges:=ranges
            )

            ' Convert to Double() and normalize to sum=1 (L1)
            Dim data As Double() = New Double(bins - 1) {}
            Dim sum As Double = 0

            For i As Integer = 0 To bins - 1
                Dim v As Double = hist.Get(Of Single)(i)
                data(i) = v
                sum += v
            Next

            If sum > 0 Then
                For i As Integer = 0 To bins - 1
                    data(i) /= sum
                Next
            End If

            Return data
        End Using
    End Function

    Private Sub NormalizeL2InPlace(ByVal v As Double())
        Dim s As Double = 0
        For i As Integer = 0 To v.Length - 1
            s += v(i) * v(i)
        Next
        Dim norm As Double = Math.Sqrt(s)
        If norm > 0 Then
            For i As Integer = 0 To v.Length - 1
                v(i) /= norm
            Next
        End If
    End Sub

    Private Function CreateZeroVector() As Double()
        ' Lunghezza: HSV (HBins+SBins+VBins) + HOG
        ' Calcolo HOG length una volta "a runtime" (dipende dai parametri HOG)
        Dim hogLen As Integer
        Try
            Using dummy As New Mat(New OpenCvSharp.Size(64, 64), MatType.CV_8UC1, Scalar.All(0))
                hogLen = hog.Compute(dummy).Length
            End Using
        Catch
            hogLen = 0
        End Try

        Dim total As Integer = (HBins + SBins + VBins) + hogLen
        If total <= 0 Then total = 1
        Return Enumerable.Repeat(0.0, total).ToArray()
    End Function

    Private Sub debug(ByVal message As String)
        debugStoria.Add(message)
        INDEX.tb_debug.Text = ""

        Dim tmpCount As Integer = 0
        For i As Integer = debugStoria.Count - 1 To 0 Step -1
            tmpCount += 1
            If tmpCount > 50 Then Exit For
            INDEX.tb_debug.Text &= debugStoria(i) & vbCrLf
        Next
    End Sub

End Module
