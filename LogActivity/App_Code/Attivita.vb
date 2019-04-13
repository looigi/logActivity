Public Class Attivita
    Public Sub CaricaAttivita(lstAttivita As ListBox, Selezionata As String)
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim rec2 As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String = "Select * From Attivita Where Eliminata='N' Order By Attivita, DataInizio Desc"
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Dim riga As Integer = 0
        Dim rigaSel As Integer = -1

        lstAttivita.Items.Clear()
        rec = DB.LeggeQuery(conn, Sql)
        Do Until rec.eof
            Sql = "Select Count(*) From Log Where idAttivita=" & rec("idAttivita").Value & " And Profondita=0 And (DataChiusura Is Null Or DataChiusura = '')"
            rec2 = DB.LeggeQuery(conn, Sql)
            Dim Interventi As String = rec2(0).Value.ToString
            For i As Integer = Interventi.Length To 3
                Interventi = " " & Interventi
            Next
            rec2.Close()
            Dim Attivita As String = rec(1).Value
            If Attivita.Length < 35 Then
                For i As Integer = Attivita.Length To 35
                    Attivita &= " "
                Next
            Else
                Attivita = Mid(Attivita, 1, 32) & "..."
            End If
            lstAttivita.Items.Add(Attivita & " (" & Interventi & ")")
            If rec(1).Value = Selezionata Then
                rigaSel = riga
            End If

            riga += 1
            rec.movenext()
        Loop
        rec.close()

        conn.close()
        DB = Nothing

        If rigaSel > -1 Then
            lstAttivita.SelectedIndex = rigaSel
        End If
    End Sub

    Public Function RitornaIdAttivita(Attivita As String) As Integer
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String = "Select idAttivita From Attivita Where Attivita='" & Attivita & "'"
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Dim id As Integer = -1
        rec = DB.LeggeQuery(conn, Sql)
        If Not rec.eof Then
            id = rec(0).Value
        End If
        rec.close()

        conn.close()
        DB = Nothing

        Return id
    End Function

    Public Function RitornaDescrizioneAttivita(idAttivita As Integer) As String
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String = "Select Attivita From Attivita Where idAttivita='" & idAttivita & "'"
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Dim Attivita As String = ""
        rec = DB.LeggeQuery(conn, Sql)
        If rec.eof Then
            Attivita = rec(0).Value
        End If
        rec.close()

        conn.close()
        DB = Nothing

        Return Attivita
    End Function

    Public Sub ModificaAttivita(AttivitaOriginale As String, Attivita As String)
        Dim id As Integer = RitornaIdAttivita(AttivitaOriginale)

        Dim r As New RoutineVarie
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim Sql As String = "Update Attivita Set Attivita='" & r.SistemaTestoPerDB(r.MetteMaiuscole(Attivita)) & "' Where idAttivita=" & id
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        DB.EsegueSql(conn, Sql)

        conn.close()
        DB = Nothing
        r = Nothing
    End Sub

    Public Sub EliminaAttivita(AttivitaOriginale As String)
        Dim id As Integer = RitornaIdAttivita(AttivitaOriginale)

        Dim r As New RoutineVarie
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim Sql As String = "Update Attivita Set Eliminata='S' Where idAttivita=" & id
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        DB.EsegueSql(conn, Sql)

        conn.close()
        DB = Nothing
        r = Nothing
    End Sub

    Public Function RitornaMaxIDGiaIncrementato() As Integer
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()
        Dim Progressivo As Integer

        Sql = "Select Max(idAttivita)+1 From Attivita"
        rec = DB.LeggeQuery(conn, Sql)
        If rec(0).Value Is DBNull.Value Then
            Progressivo = 1
        Else
            Progressivo = rec(0).Value
        End If
        rec.close()

        conn.close()
        DB = Nothing

        Return Progressivo
    End Function

    Public Sub InserisceAttivita(Attivita As String, DataInizio As String, DataFine As String)
        Dim r As New RoutineVarie
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim Sql As String = "Insert Into Attivita Values (" & RitornaMaxIDGiaIncrementato() & ", '" & r.SistemaTestoPerDB(Attivita) & "', " & r.ConverteDataPerDB(DataInizio) & ", " & r.ConverteDataPerDB(DataFine) & ", 'N')"
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        DB.EsegueSql(conn, Sql)

        conn.close()
        DB = Nothing
        r = Nothing
    End Sub
End Class
