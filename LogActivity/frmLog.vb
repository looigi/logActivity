Public Class frmLog
    Private idAttivita As Integer

    Public Sub ImpostaIdAttivita(id As String)
        idAttivita = id
    End Sub

    Private Sub frmLog_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        frmMain.Show()
    End Sub

    Private Sub frmLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim DataPrec As Date = Now.AddDays(-1)
        Dim DataInizioRicerca As String = DataPrec.Day & "/" & DataPrec.Month & "/" & DataPrec.Year & " 00:00:00.000"
        Dim DataFineRicerca As String = Now.Day & "/" & Now.Month & "/" & Now.Year & " 23:59:59.000"

        txtDataInizio.Text = DataInizioRicerca
        txtDataFine.Text = DataFineRicerca

        Dim l As New Log
        l.RitornaAttivitaChiuse(idAttivita, lstLog, DataInizioRicerca, DataFineRicerca)
        l = Nothing
    End Sub

    Private Sub cmdRicerca_Click(sender As Object, e As EventArgs) Handles cmdRicerca.Click
        Dim DataInizioRicerca As String = txtDataInizio.Text
        Dim DataFineRicerca As String = txtDataFine.Text

        Dim l As New Log
        l.RitornaAttivitaChiuse(idAttivita, lstLog, DataInizioRicerca, DataFineRicerca)
        l = Nothing
    End Sub

    Private Sub cmdStampa_Click(sender As Object, e As EventArgs) Handles cmdStampa.Click
        Dim g As New GestioneFilesDirectory
        Dim NomeFile As String = Application.StartupPath & "\Files\Log_" & Now.Year & Now.Month & Now.Day & Now.Hour & Now.Minute & Now.Second & ".txt"
        g.CreaDirectoryDaPercorso(Application.StartupPath & "\Files\")
        g.ApreFileDiTestoPerScrittura(NomeFile)
        For i As Integer = 0 To lstLog.Items.Count - 1
            g.ScriveTestoSuFileAperto(lstLog.Items(i))
        Next
        g.ChiudeFileDiTestoDopoScrittura()
        g = Nothing

        System.Diagnostics.Process.Start("notepad.exe", NomeFile)
    End Sub
End Class