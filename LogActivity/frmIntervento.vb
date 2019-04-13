Public Class frmIntervento
    Private idIntervento As Integer = -1
    Private Campi() As String
    Private Padre As String
    Private idPadre As Integer = -1

    Public Sub ImpostaId(id As Integer, Optional sPadre As String = "", Optional idP As Integer = -1)
        Erase Campi

        idIntervento = id

        If id <> -1 And id <> -2 Then
            Dim l As New Log
            Dim Intervento As String = l.RitornaDatiLogIntervento(idAttivitaDefault, idIntervento)
            Campi = Intervento.Split("§")
        Else
            Padre = sPadre
            idPadre = idP
        End If
    End Sub

    Private Sub frmIntervento_Load(sender As Object, e As EventArgs) Handles Me.Load
        If idIntervento <> -1 And idIntervento <> -2 Then
            lblIdItervento.Text = Campi(1)
            txtDescrizione.Text = Campi(2)
            lblDataInserimento.Text = Campi(3)
            lblDataChiusura.Text = Campi(4)
            txtNote.Text = Campi(5)
            lblProfondita.Text = Campi(6)
            lblSezione.Text = Campi(7)
            lblDataPresaInCarico.Text = Campi(8)
            txtNote.Enabled = True

            cmdChiude.Text = "Chiude"
            If frmMain.optDaEseguire.Checked Then
                If lblDataChiusura.Text <> "" Then
                    cmdAggiorna.Enabled = True
                    cmdChiude.Enabled = False
                Else
                    cmdAggiorna.Enabled = True
                    cmdChiude.Enabled = True
                End If
            Else
                cmdAggiorna.Enabled = False
                cmdChiude.Enabled = False
            End If

            lblTitPadre.Visible = False
            lblPadre.Visible = False
        Else
            Dim l As New Log

            lblIdItervento.Text = l.RitornaMaxProgressivoGiaIncrementato(idAttivitaDefault)
            txtDescrizione.Text = ""
            lblDataInserimento.Text = ""
            lblDataChiusura.Text = ""
            txtNote.Text = ""
            txtNote.Enabled = False
            If idIntervento = -1 Then
                lblSezione.Text = ""
                lblProfondita.Text = ""
            Else
                lblSezione.Text = l.RitornaSezioneDaProgressivo(idAttivitaDefault, idPadre)
                lblProfondita.Text = l.RitornaProfonditaDaProgressivo(idAttivitaDefault, idPadre) + 1
            End If
            lblDataPresaInCarico.Text = ""

            cmdAggiorna.Visible = False
            cmdChiude.Text = "Salva"

            If idIntervento = -2 Then
                lblTitPadre.Visible = True
                lblPadre.Visible = True
                lblPadre.Text = Padre
            Else
                lblTitPadre.Visible = False
                lblPadre.Visible = False
                lblPadre.Text = ""
            End If
        End If
    End Sub

    Private Sub cmdChiude_Click(sender As Object, e As EventArgs) Handles cmdChiude.Click
        Dim Ok As Boolean = False
        Dim r As New RoutineVarie
        Dim l As New Log

        txtDescrizione.Text = r.MetteMaiuscoleDopoPunto(txtDescrizione.Text)
        txtNote.Text = r.MetteMaiuscoleDopoPunto(txtNote.Text)

        If cmdChiude.Text = "Chiude" Then
            If MsgBox("Sei sicuro di voler chiudere l'intervento ?", vbYesNo + vbInformation) = vbYes Then
                Dim DataChiusura As String
                Dim DataPresaInCarico As String

                If lblDataChiusura.Text = "" Then
                    DataChiusura = Now
                Else
                    DataChiusura = lblDataChiusura.Text
                End If

                If lblDataPresaInCarico.Text = "" Then
                    DataPresaInCarico = Now
                Else
                    DataPresaInCarico = lblDataPresaInCarico.Text
                End If

                l.ModificaLogAttivita(idAttivitaDefault, idIntervento, txtDescrizione.Text, lblDataInserimento.Text, DataChiusura, txtNote.Text, DataPresaInCarico)
                l.ControllaSeCiSonoInterventiApertiPerProfondita(idAttivitaDefault, idIntervento, lblSezione.Text, DataChiusura, txtNote.Text, DataPresaInCarico)

                Ok = True
            End If
        Else
            If idIntervento = -1 Then
                l.InserisceLogAttivita(idAttivitaDefault, txtDescrizione.Text, 0)
            Else
                l.InserisceLogAttivitaComeFiglio(idAttivitaDefault, txtDescrizione.Text, lblProfondita.Text, lblSezione.Text, idPadre)
            End If

            Ok = True
        End If

        l = Nothing

        If Ok Then
            Erase Campi
            idIntervento = -1
            Me.Close()

            frmMain.ImpostaSchermata()
        End If
    End Sub
End Class