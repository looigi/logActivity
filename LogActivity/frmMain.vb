Public Class frmMain
    Private myMenu As New ContextMenu()
    Private RigaSelezionata As String
    Private RigaTesto As String
    Private RigaData As String

    Private mnuCarico As New GestioneMenu
    Private mnuEdit As New GestioneMenu
    Private mnuNuova As New GestioneMenu
    Private mnuElimina As New GestioneMenu
    Private mnuModifica As New GestioneMenu

    Private Modifica As Boolean
    Private AttivitaOriginale As String

    Private NotifyIcon1 As NotifyIcon = New NotifyIcon
    Private contextMenu1 As System.Windows.Forms.ContextMenu = New System.Windows.Forms.ContextMenu
    Private menuItem1 As GestioneMenu
    Private menuItem2 As GestioneMenu
    Private menuItemSeparatore As GestioneMenu

    Private MascheraAperta As Boolean

    Public Sub New()
        MyBase.New()

        InitializeComponent()

        menuItem1 = New GestioneMenu("Verdana", 9, "Apre maschera", "Immagini\visualizzato_tondo.png", 24, New EventHandler(AddressOf ApreChiude), Nothing)
        menuItem2 = New GestioneMenu("Verdana", 9, "Uscita", "Immagini\icona_Uscita.png", 24, New EventHandler(AddressOf Uscita), Nothing)
        menuItemSeparatore = New GestioneMenu("Verdana", 9, "-", "", 0, Nothing, Nothing)

        Me.contextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() _
                            {Me.menuItem1, Me.menuItemSeparatore, Me.menuItem2})

        NotifyIcon1.Icon = New Icon("Immagini\logActivity.ico")
        NotifyIcon1.Text = "Log Activity"
        NotifyIcon1.ContextMenu = Me.contextMenu1
        NotifyIcon1.Visible = True
    End Sub

    Private Sub Uscita()
        NotifyIcon1.Visible = False
        End
    End Sub

    Private Sub ApreChiude()
        If MascheraAperta Then
            MascheraAperta = False
            Me.Hide()
            menuItem1.ImpostaTesto("Apre maschera")
            menuItem1.ImpostaImmagine("Immagini\visualizzato_tondo.png", 24)
        Else
            MascheraAperta = True
            Me.Show()
            menuItem1.ImpostaTesto("Chiude maschera")
            menuItem1.ImpostaImmagine("Immagini\no_visualizzato_tondo.png", 24)
        End If
    End Sub

    Private Sub AzzeraSelezione()
        cmdElimina.Enabled = False
        Modifica = False
        AttivitaOriginale = ""
        txtAttivita.Text = ""
    End Sub

    Private Sub frmMain_Click(sender As Object, e As EventArgs) Handles Me.Click
        If Modifica Then
            AzzeraSelezione()
        End If
    End Sub

    Private Sub frmMain_Deactivate(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MascheraAperta Then
            Timer1.Enabled = True

            menuItem1.ImpostaTesto("Apre maschera")
            menuItem1.ImpostaImmagine("Immagini\Apre.png", 24)
        End If
        e.Cancel = True
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Log Activity"

        PathDB = Application.StartupPath & "\DB\logActivity.sdf"

        Dim att As New Attivita
        att.CaricaAttivita(lstAttivita, AttivitaDefault)
        att = Nothing

        idAttivitaDefault = GetSetting("LogActivity", "Impostazioni", "idAttivitaDefault", -1)
        AttivitaDefault = GetSetting("LogActivity", "Impostazioni", "AttivitaDefault", "")
        TipoVisualizzazione = GetSetting("LogActivity", "Impostazioni", "TipoVisualizzazione", TipoRitornoLog.SoloDaEseguire)

        AddContextMenu(sender)

        ImpostaSchermata()

        Timer1.Enabled = True
    End Sub

    Public Sub ImpostaSchermata()
        Select Case TipoVisualizzazione
            Case TipoRitornoLog.Eseguiti
                optEseguite.Checked = True
                optDaEseguire.Checked = False
                optTutte.Checked = False
            Case TipoRitornoLog.SoloDaEseguire
                optEseguite.Checked = False
                optDaEseguire.Checked = True
                optTutte.Checked = False
            Case TipoRitornoLog.Tutti
                optEseguite.Checked = False
                optDaEseguire.Checked = False
                optTutte.Checked = True
        End Select

        Dim l As New Log
        lblCaricate.Text = "Righe: " & l.CaricaLogAttivita(lstLog, idAttivitaDefault, TipoVisualizzazione)
        l = Nothing

        lblLog.Text = ""

        AzzeraSelezione()
    End Sub

    Private Sub cmdCaricaDaFile_Click(sender As Object, e As EventArgs) Handles cmdCaricaDaFile.Click
        AzzeraSelezione()

        Dim g As New GestioneFilesDirectory
        Dim l As New Log
        Dim idAttivita As Integer = 1
        Dim NomeFile As String = g.SceltaFile(Application.StartupPath)

        If NomeFile <> "" Then
            Me.Cursor = Cursors.WaitCursor

            Dim sRiga As String
            Dim Righe() As String = {}
            Dim qRighe As Integer = 0

            g.ApreFilePerLettura(NomeFile)
            Do
                sRiga = g.RitornaRiga
                If Not sRiga Is Nothing Then
                    ReDim Preserve Righe(qRighe)
                    Righe(qRighe) = sRiga
                    qRighe += 1
                End If
            Loop Until sRiga Is Nothing
            g.ChiudeFile()

            Dim Progressivo As Integer
            Dim VecchiaProfondita As Integer
            Dim DataInizio As String = ""
            Dim DataFine As String = ""
            Dim Profondita As Integer
            Dim Punto As Integer
            Dim Riga As String

            If chkPulisce.Checked Then
                l.EliminaTuttoLogAttivita(idAttivitaDefault)
            End If

            Dim Sezione As Integer = l.RitornaMaxSezione(idAttivitaDefault)

            ' Conteggio righe per calcolo sezione
            For i As Integer = 0 To qRighe - 1
                Riga = Righe(i)
                If Riga.Trim <> "" Then
                    If Mid(Riga, 1, 5) = "-----" Then
                        DataInizio = Riga.Replace("-", "").Trim
                    Else
                        Riga = Riga.Replace("^", "")

                        Profondita = l.RitornaProfondita(Riga)
                        Riga = Riga.Replace(Chr(9), "")

                        If Riga.Contains("*") Then
                            Riga = Riga.Replace("*", "").Trim
                            DataFine = Now ' DataInizio

                            VecchiaProfondita = Profondita
                        Else
                            If (Profondita > 0 And Profondita > VecchiaProfondita And DataFine <> "") Then
                            Else
                                DataFine = ""
                            End If
                        End If

                        If Profondita = 0 Then
                            Sezione += 1
                        End If
                    End If
                End If
            Next
            ' Conteggio righe per calcolo sezione

            Dim RigaSezione As Integer = Sezione + qRighe

            For i As Integer = 0 To qRighe - 1
                Me.Text = "Caricamento: " & i + 1 & "/" & qRighe
                Application.DoEvents()

                Riga = Righe(i)
                If Riga.Trim <> "" Then
                    If Mid(Riga, 1, 5) = "-----" Then
                        DataInizio = Riga.Replace("-", "").Trim
                    Else
                        Riga = Riga.Replace("^", "")

                        Profondita = l.RitornaProfondita(Riga)
                        Riga = Riga.Replace(Chr(9), "")

                        If Riga.Contains("*") Then
                            Riga = Riga.Replace("*", "").Trim
                            DataFine = Now ' DataInizio

                            VecchiaProfondita = Profondita
                        Else
                            If (Profondita > 0 And Profondita > VecchiaProfondita And DataFine <> "") Then
                            Else
                                DataFine = ""
                            End If
                        End If

                        If Profondita = 0 Then
                            RigaSezione -= 1
                        End If

                        Punto = Riga.IndexOf(".")
                        If Punto < 4 And Punto > -1 Then
                            Riga = Mid(Riga, Punto + 2, Riga.Length)

                            If Mid(Riga, 1, 2) = "- " Then
                                Riga = Mid(Riga, 3, Riga.Length)
                            End If

                            Riga = Riga.Trim

                            If DataInizio = "" Then DataInizio = Now.Day & "/" & Now.Month & "/" & Now.Year & " " & Now.Hour & ":" & Now.Minute & ":" & Now.Second

                            Dim Datella As Date = DataInizio
                            If Datella.Hour = 0 And Datella.Second = 0 Then
                                DataInizio &= " " & Now.Hour & ":" & Now.Minute & ":" & Now.Second
                            End If

                            Progressivo = l.InserisceLogAttivita(idAttivitaDefault, Riga, Profondita, DataInizio, RigaSezione)

                            If DataFine <> "" Then
                                l.ModificaLogAttivita(idAttivitaDefault, Progressivo, Riga, DataInizio, DataFine, "", "")
                            End If
                        Else
                            ' Commento Mio
                            l.ModificaLogAttivita(idAttivitaDefault, Progressivo, "", DataInizio, DataFine, Riga, "")
                        End If
                    End If
                End If
            Next

            Me.Cursor = Cursors.Default
        End If
        g = Nothing
        l = Nothing

        ImpostaSchermata()

        Me.Text = "Log Activity"
        Application.DoEvents()
    End Sub

    Private Sub optDaEseguire_Click(sender As Object, e As EventArgs) Handles optDaEseguire.Click
        If optDaEseguire.Checked = True Then
            TipoVisualizzazione = TipoRitornoLog.SoloDaEseguire
            SaveSetting("LogActivity", "Impostazioni", "TipoVisualizzazione", TipoVisualizzazione)

            ImpostaSchermata()
        End If
    End Sub

    Private Sub optEseguite_Click(sender As Object, e As EventArgs) Handles optEseguite.Click
        If optEseguite.Checked = True Then
            TipoVisualizzazione = TipoRitornoLog.Eseguiti
            SaveSetting("LogActivity", "Impostazioni", "TipoVisualizzazione", TipoVisualizzazione)

            ImpostaSchermata()
        End If
    End Sub

    Private Sub optTutte_Click(sender As Object, e As EventArgs) Handles optTutte.Click
        If optTutte.Checked = True Then
            TipoVisualizzazione = TipoRitornoLog.Tutti
            SaveSetting("LogActivity", "Impostazioni", "TipoVisualizzazione", TipoVisualizzazione)

            ImpostaSchermata()
        End If
    End Sub

    Private Sub lstAttivita_Click(sender As Object, e As EventArgs) Handles lstAttivita.Click
        txtAttivita.Text = lstAttivita.Text
        Modifica = True
        AttivitaOriginale = Mid(lstAttivita.Text, 1, 35).Trim
        cmdElimina.Enabled = True
    End Sub

    Private Sub lstAttivita_DoubleClick(sender As Object, e As EventArgs) Handles lstAttivita.DoubleClick
        If lstAttivita.Text <> "" Then
            Dim a As New Attivita
            idAttivitaDefault = a.RitornaIdAttivita(Mid(lstAttivita.Text, 1, 35).Trim)

            SaveSetting("LogActivity", "Impostazioni", "idAttivitaDefault", idAttivitaDefault)

            ImpostaSchermata()
        End If
    End Sub

    Private Sub AddContextMenu(ByVal sender As Object)
        mnuCarico = New GestioneMenu("Verdana", 12, "Carica", "Immagini\Carico.png", 24, New EventHandler(AddressOf mnuCarico_Click), Nothing)
        mnuEdit = New GestioneMenu("Verdana", 12, "Edit", "Immagini\Edit.png", 24, New EventHandler(AddressOf mnuEdit_Click), Nothing)
        mnuNuova = New GestioneMenu("Verdana", 12, "Nuovo", "Immagini\matitadx.png", 24, New EventHandler(AddressOf mnuNuovo_Click), Nothing)
        mnuElimina = New GestioneMenu("Verdana", 12, "Elimina", "Immagini\eliminadx.png", 24, New EventHandler(AddressOf mnuElimina_Click), Nothing)
        mnuModifica = New GestioneMenu("Verdana", 12, "Modifica", "Immagini\icona_equalizz.png", 24, New EventHandler(AddressOf mnuModifica_Click), Nothing)

        myMenu.MenuItems.Add(mnuCarico)
        myMenu.MenuItems.Add(mnuEdit)
        myMenu.MenuItems.Add(mnuModifica)
        myMenu.MenuItems.Add(mnuNuova)
        myMenu.MenuItems.Add(mnuElimina)

        lstLog.ContextMenu = myMenu
    End Sub

    Private Sub mnuModifica_Click()
        If RigaSelezionata <> "" Then
            Dim l As New Log
            Dim Testo As String = RigaSelezionata
            Dim Data As String = Testo
            Dim a1 As Integer = Testo.IndexOf(" ") + 2
            Dim a2 As Integer = Mid(Testo, a1 + 2, Testo.Length).IndexOf(" ") + 2
            Data = Mid(Testo, 1, a1 + a2).Trim
            Testo = Testo.Replace(Data, "")
            If Mid(Testo, Testo.Length, Testo.Length) <> " " Then
                Testo = Mid(Testo, 1, Testo.Length - 30)
            End If
            Testo = Testo.Trim
            Dim id As Integer = l.RitornaProgressivoLogAttivita(idAttivitaDefault, Testo, Data)

            Dim Ritorno As String = InputBox("Nuova descrizione", "logActivity", Testo)
            If Ritorno <> Testo And Ritorno <> "" Then
                l.ModificaDescrizioneAttivita(idAttivitaDefault, id, Ritorno)

                ImpostaSchermata()
            End If
        End If
    End Sub

    Private Sub mnuCarico_Click()
        If RigaSelezionata <> "" Then
            Dim l As New Log
            Dim idLog As Integer = RitornaId 
            l.PrendeInCarico(idAttivitaDefault, idLog)

            lstLog.Invalidate()

            MsgBox("Attività presa in carico", vbInformation)
        End If
    End Sub

    Private Sub mnuElimina_Click()
        If RigaSelezionata <> "" Then
            Dim Risposta As Integer = MsgBox("Si vuole eliminare l'intervento selezionato." & vbCrLf & "Si elimineranno anche tutti gli eventuali interventi figlio.", vbYesNo + vbInformation)
            Select Case Risposta
                Case vbYes
                    Dim idLog As Integer = RitornaId()
                    Dim l As New Log

                    l.EliminaIntervento(idAttivitaDefault, idLog)

                    ImpostaSchermata()
                Case vbNo
                    Exit Sub
            End Select
        End If
    End Sub

    Private Function RitornaId()
        Dim l As New Log
        Dim Testo As String = RigaSelezionata
        Dim Data As String = Testo
        Dim a1 As Integer = Testo.IndexOf(" ") + 2
        Dim a2 As Integer = Mid(Testo, a1 + 2, Testo.Length).IndexOf(" ") + 2
        Data = Mid(Testo, 1, a1 + a2).Trim
        Testo = Testo.Replace(Data, "")
        If Mid(Testo, Testo.Length, Testo.Length) <> " " Then
            Testo = Mid(Testo, 1, Testo.Length - 30)
        End If
        Testo = Testo.Trim
        Dim id As Integer = l.RitornaProgressivoLogAttivita(idAttivitaDefault, Testo, Data)

        RigaTesto = Testo
        RigaData = Data

        Return id
    End Function

    Private Sub mnuNuovo_Click()
        If RigaSelezionata <> "" Then
            Dim Risposta As Integer = MsgBox("Si vuole aggiungere un nuovo intervento oppure un figlio del selezionato?" & vbCrLf & vbCrLf & "SI = Nuovo intervento" & vbCrLf & "NO = Figlio del selezionato", MsgBoxStyle.YesNoCancel + vbInformation)

            Select Case Risposta
                Case vbYes
                    frmIntervento.ImpostaId(-1)
                    frmIntervento.Show()
                Case vbNo
                    Dim Padre As Integer = RitornaId()

                    frmIntervento.ImpostaId(-2, RigaTesto, Padre)
                    frmIntervento.Show()
                Case vbCancel
                    Exit Sub
            End Select
        Else
            frmIntervento.ImpostaId(-1)
            frmIntervento.Show()
        End If
    End Sub

    Private Sub mnuEdit_Click()
        If RigaSelezionata <> "" Then
            Dim l As New Log
            Dim idLog As Integer = RitornaId()

            frmIntervento.ImpostaId(l.RitornaProgressivoLogAttivita(idAttivitaDefault, RigaTesto, RigaData))
            frmIntervento.Show()
        End If
    End Sub

    Private Sub lstLog_DrawItem(sender As Object, e As DrawItemEventArgs) Handles lstLog.DrawItem
        If e.Index > -1 Then
            Dim Riga As String = lstLog.Items(e.Index).ToString()
            Dim Spazi As Integer = 0

            If Riga <> "" Then
                If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                    e.Graphics.FillRectangle(New SolidBrush(Color.LightCoral), e.Bounds)
                    e.Graphics.DrawString(lstLog.Items(e.Index).ToString(), e.Font, Brushes.White, New System.Drawing.PointF(e.Bounds.X, e.Bounds.Y))
                Else
                    If Mid(Riga, Riga.Length, Riga.Length) <> " " Then
                        e.DrawBackground()

                        e.Graphics.FillRectangle(Brushes.LightGreen, e.Bounds)
                    End If

                    e.Graphics.DrawString(lstLog.Items(e.Index).ToString(), e.Font, Brushes.Black, New System.Drawing.PointF(e.Bounds.X, e.Bounds.Y))
                End If

                e.DrawFocusRectangle()
            End If
        End If
    End Sub

    Private Sub AbilitaVociMenu()
        If RigaSelezionata <> "" Then
            mnuModifica.Abilita()
            mnuElimina.Abilita()

            Dim l As New Log
            Dim idLog As Integer = RitornaId()
            Dim DataPresaInCarico As String = l.RitornaDataPresaInCarico(idAttivitaDefault, idLog)
            If DataPresaInCarico <> "" Then
                mnuCarico.Disabilita()
                mnuEdit.Abilita()
            Else
                mnuCarico.Abilita()
                mnuEdit.Disabilita()
            End If
        Else
            mnuCarico.Disabilita()
            mnuEdit.Disabilita()
            mnuElimina.Disabilita()
            mnuModifica.Disabilita()
        End If
    End Sub

    Private Sub lstLog_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles lstLog.MouseDown
        If e.Button = MouseButtons.Right Then
            lstLog.SelectedIndex = lstLog.IndexFromPoint(e.X, e.Y)
            RigaSelezionata = lstLog.Text

            lstLog.Invalidate()

            AbilitaVociMenu()
        End If
    End Sub

    Private Sub lstLog_Click(ByVal sender As Object, ByVal e As MouseEventArgs) Handles lstLog.Click
        Dim conta As Integer = 0

        lstLog.SelectedIndex = lstLog.IndexFromPoint(e.X, e.Y)
        RigaSelezionata = lstLog.Text
        If RigaSelezionata <> "" Then
            If Mid(RigaSelezionata, RigaSelezionata.Length, RigaSelezionata.Length) <> " " Then
                For i As Integer = RigaSelezionata.Length To 1 Step -1
                    If Mid(RigaSelezionata, i, 1) = " " Then
                        conta += 1
                        If conta = 2 Then
                            lblLog.Text = Mid(RigaSelezionata, 1, i).Trim
                            lblLog.Text &= " Presa in carico: " & Mid(RigaSelezionata, i + 1, RigaSelezionata.Length).Trim
                            Exit For
                        End If
                    End If
                Next
            Else
                lblLog.Text = RigaSelezionata.Trim
            End If

            If lblLog.Text <> "" Then
                conta = 0

                For i As Integer = 1 To lblLog.Text.Length
                    If Mid(lblLog.Text, i, 1) = " " Then
                        conta += 1
                        If conta = 2 Then
                            lblLog.Text = Mid(lblLog.Text, 1, i).Trim & " " & Mid(lblLog.Text, i + 1, lblLog.Text.Length).Trim
                            Exit For
                        End If
                    End If
                Next
            End If
        End If

        lstLog.Invalidate()

        AzzeraSelezione()
        AbilitaVociMenu()
    End Sub

    Private Sub cmdSalva_Click(sender As Object, e As EventArgs) Handles cmdSalva.Click
        If txtAttivita.Text = "" Then
            MsgBox("Inserire la descrizione dell'attività", vbInformation)
            Exit Sub
        End If

        Dim a As New Attivita
        Dim r As New RoutineVarie

        If Modifica Then
            a.ModificaAttivita(AttivitaOriginale, r.SistemaTestoPerDB(r.MetteMaiuscole(txtAttivita.Text)))
        Else
            a.InserisceAttivita(r.SistemaTestoPerDB(r.MetteMaiuscole(txtAttivita.Text)), Now, Nothing)
        End If

        a.CaricaAttivita(lstAttivita, AttivitaDefault)

        a = Nothing
        r = Nothing

        AzzeraSelezione()
    End Sub

    Private Sub cmdElimina_Click(sender As Object, e As EventArgs) Handles cmdElimina.Click
        If MsgBox("Si vuole eliminare l'attività '" & AttivitaOriginale & "' ?", vbYesNo + vbInformation) = vbYes Then
            Dim a As New Attivita
            a.EliminaAttivita(AttivitaOriginale)
            a.CaricaAttivita(lstAttivita, AttivitaDefault)
            a = Nothing

            AzzeraSelezione()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        MascheraAperta = False
        Me.Hide()
    End Sub

    Private Sub cmdGeneraLog_Click(sender As Object, e As EventArgs) Handles cmdGeneraLog.Click
        frmLog.ImpostaIdAttivita(idAttivitaDefault)
        frmLog.Show()
        Me.Hide()
    End Sub
End Class
