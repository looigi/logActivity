Public Class Log
    Public Function CaricaLogAttivita(lstLog As ListBox, idAttivita As String, Modalita As Integer) As Integer
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Altro As String = ""
        Dim DataPresaInCarico As String = ""

        Select Case Modalita
            Case 1
                Altro = " And (DataChiusura = '' Or DataChiusura Is Null)"
            Case 2
                Altro = " And DataChiusura Is Not Null And DataChiusura <> ''"
            Case 3
                Altro = ""
        End Select
        Dim Sql As String = "Select * From Log Where idAttivita=" & idAttivita & Altro & " And Eliminata='N' Order By Sezione Desc, Progressivo, Profondita"
        Dim Profondita As Integer
        Dim VecchiaSezione As Integer = -1
        Dim PreScritta As String = ""
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Dim Righe As Integer = 0
        Dim Datella As String

        lstLog.Items.Clear()
        rec = DB.LeggeQuery(conn, Sql)
        Do Until rec.eof
            Profondita = rec("Profondita").Value
            PreScritta = ""
            For i As Integer = 0 To Profondita - 1
                PreScritta += Space(4)
            Next

            If (VecchiaSezione <> rec("Sezione").Value) And VecchiaSezione <> -1 Then
                VecchiaSezione = rec("Sezione").Value
                lstLog.Items.Add("")
            Else
                If VecchiaSezione = -1 Then
                    VecchiaSezione = rec("Sezione").Value
                End If
            End If
            Datella = rec("DataInserimento").Value
            DataPresaInCarico = "" & rec("DataPresaInCarico").Value

            lstLog.Items.Add(Datella & " " & PreScritta & rec(2).Value & Space(200) & DataPresaInCarico)

            Righe += 1

            rec.movenext()
        Loop
        rec.close()

        conn.close()
        DB = Nothing

        Return Righe
    End Function

    Public Function RitornaMaxProgressivoGiaIncrementato(idAttivita As Integer) As Integer
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()
        Dim Progressivo As Integer

        Sql = "Select Max(Progressivo)+1 From Log Where idAttivita=" & idAttivita
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

    Public Function RitornaDataPresaInCarico(idAttivita As Integer, idLog As Integer) As String
        Dim DataPresaInCarico As String = ""

        If idLog > -1 Then
            Dim DB As New SQLSERVERCE
            Dim conn As Object = CreateObject("ADODB.Connection")
            Dim rec As Object = CreateObject("ADODB.Recordset")
            Dim Sql As String
            DB.ImpostaNomeDB(PathDB)
            DB.LeggeImpostazioniDiBase()
            conn = DB.ApreDB()

            Sql = "Select DataPresaInCarico From Log Where idAttivita=" & idAttivita & " And Progressivo=" & idLog
            rec = DB.LeggeQuery(conn, Sql)
            If rec(0).Value Is DBNull.Value Then
                DataPresaInCarico = ""
            Else
                DataPresaInCarico = rec(0).Value
            End If
            rec.close()

            conn.close()
            DB = Nothing
        End If

        Return DataPresaInCarico
    End Function

    Public Sub PrendeInCarico(idAttivita As Integer, idLog As Integer)
        Dim r As New RoutineVarie
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim Sql As String
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Sql = "Update Log Set DataPresaInCarico=" & r.ConverteDataPerDB(Now) & " Where idAttivita=" & idAttivita & " And Progressivo=" & idLog
        DB.EsegueSql(conn, Sql)

        conn.close()
        DB = Nothing
        r = Nothing
    End Sub

    Public Function RitornaMaxSezione(idAttivita As Integer) As Integer
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()
        Dim Sezione As Integer

        Sql = "Select Max(Sezione)+1 From Log Where idAttivita=" & idAttivita
        rec = DB.LeggeQuery(conn, Sql)
        If rec(0).Value Is DBNull.Value Then
            Sezione = 1
        Else
            Sezione = rec(0).Value
        End If
        rec.close()

        conn.close()
        DB = Nothing

        Return Sezione
    End Function

    Public Function RitornaSezioneDaProgressivo(idAttivita As Integer, idIntervento As Integer) As Integer
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()
        Dim Sezione As Integer

        Sql = "Select Sezione From Log Where idAttivita=" & idAttivita & " And Progressivo=" & idIntervento
        rec = DB.LeggeQuery(conn, Sql)
        If rec(0).Value Is DBNull.Value Then
            Sezione = 1
        Else
            Sezione = rec(0).Value
        End If
        rec.close()

        conn.close()
        DB = Nothing

        Return Sezione
    End Function

    Public Function RitornaProfonditaDaProgressivo(idAttivita As Integer, idIntervento As Integer) As Integer
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()
        Dim Profondita As Integer

        Sql = "Select Profondita From Log Where idAttivita=" & idAttivita & " And Progressivo=" & idIntervento
        rec = DB.LeggeQuery(conn, Sql)
        If rec(0).Value Is DBNull.Value Then
            Profondita = 1
        Else
            Profondita = rec(0).Value
        End If
        rec.close()

        conn.close()
        DB = Nothing

        Return Profondita
    End Function

    Public Sub InserisceLogAttivitaComeFiglio(idAttivita As Integer, Descrizione As String, Profondita As Integer, Sezione As Integer, Padre As Integer)
        Dim Progressivo As Integer = RitornaMaxProgressivoGiaIncrementato(idAttivita)

        Dim r As New RoutineVarie
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Dim NuovoProgressivo As Integer = Progressivo + 1
        Dim nPadre As Integer
        Dim vecchioProgr As Integer
        Dim RigheDiInsert() As String = {}
        Dim qRigheInsert As Integer = 0
        Dim RigheDiDelete() As String = {}
        Dim qRigheDelete As Integer = 0
        Dim c As Integer = 0

        Sql = "Select * From Log Where idAttivita=" & idAttivita & " And Sezione=" & Sezione & " And Progressivo>" & Padre & " Order By Sezione Desc, Progressivo, Profondita"
        rec = DB.LeggeQuery(conn, Sql)
        Do Until rec.eof
            vecchioProgr = rec("Progressivo").Value

            nPadre = rec("Padre").Value
            If nPadre > Padre Then
                nPadre = (nPadre + ((Progressivo) - nPadre)) + c
            End If

            ReDim Preserve RigheDiInsert(qRigheInsert)
            Sql = "Insert Into Log Values (" &
                " " & rec("idAttivita").Value & ", " &
                " " & NuovoProgressivo & ", " &
                "'" & r.SistemaTestoPerDB(rec("Descrizione").Value) & "', " &
                " " & r.ConverteDataPerDB("" & rec("DataInserimento").Value) & ", " &
                " " & r.ConverteDataPerDB("" & rec("DataChiusura").Value) & ", " &
                "'" & r.SistemaTestoPerDB(rec("NoteChiusura").Value) & "', " &
                " " & rec("Profondita").Value & ", " &
                " " & rec("Sezione").Value & ", " &
                " " & nPadre & ", " &
                " " & r.ConverteDataPerDB("" & rec("DataPresaInCarico").Value) & ", " &
                "'N' " &
                ")"
            RigheDiInsert(qRigheInsert) = Sql

            ReDim Preserve RigheDiDelete(qRigheDelete)
            Sql = "Update Log Set Eliminata='S' Where idAttivita=" & idAttivita & " And Sezione=" & Sezione & " And Progressivo=" & vecchioProgr
            RigheDiDelete(qRigheDelete) = Sql

            NuovoProgressivo += 1
            qRigheInsert += 1
            qRigheDelete += 1

            c += 1

            rec.movenext()
        Loop
        rec.close()

        For i As Integer = 0 To qRigheInsert - 1
            DB.EsegueSql(conn, RigheDiInsert(i))
            DB.EsegueSql(conn, RigheDiDelete(i))
        Next

        Sql = "Insert Into Log Values (" & idAttivita & ", " & Progressivo & ", '" & r.SistemaTestoPerDB(r.ConverteStringaInUTF8(Descrizione)) & "', " & r.ConverteDataPerDB(Now) & ", Null, '', " & Profondita & ", " & Sezione & ", " & Padre & ", Null, 'N')"
        DB.EsegueSql(conn, Sql)

        conn.close()
        DB = Nothing
        r = Nothing
    End Sub

    Public Function InserisceLogAttivita(idAttivita As Integer, Descrizione As String, Profondita As Integer, Optional DataInserimento As String = "", Optional SezionePass As Integer = -1) As Integer
        Dim Progressivo As Integer = RitornaMaxProgressivoGiaIncrementato(idAttivita)

        Dim r As New RoutineVarie
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Dim Sezione As Integer

        If Profondita = 0 Then
            If SezionePass = -1 Then
                Sql = "Select Max(Sezione)+1 From Log Where idAttivita=" & idAttivita
                rec = DB.LeggeQuery(conn, Sql)
                If rec(0).Value Is DBNull.Value Then
                    Sezione = 1
                Else
                    Sezione = rec(0).Value
                End If
                rec.close()
            Else
                Sezione = SezionePass
            End If
        Else
            If SezionePass = -1 Then
                Sql = "Select Max(Sezione) From Log Where idAttivita=" & idAttivita
                rec = DB.LeggeQuery(conn, Sql)
                If rec(0).Value Is DBNull.Value Then
                    Sezione = 1
                Else
                    Sezione = rec(0).Value
                End If
                rec.close()
            Else
                Sezione = SezionePass
            End If
        End If

        Dim Padre As Integer = 0

        Sql = "Select Max(Progressivo) From Log Where idAttivita=" & idAttivita & " And Sezione=" & Sezione & " And Profondita=" & Profondita - 1
        rec = DB.LeggeQuery(conn, Sql)
        If rec(0).Value Is DBNull.Value Then
            Padre = 0
        Else
            Padre = rec(0).Value
        End If
        rec.close()

        Dim DataIns As String

        If DataInserimento <> "" Then
            DataIns = DataInserimento
        Else
            DataIns = Now
        End If

        Sql = "Insert Into Log Values (" & idAttivita & ", " & Progressivo & ", '" & r.SistemaTestoPerDB(r.ConverteStringaInUTF8(Descrizione)) & "', " & r.ConverteDataPerDB(DataIns) & ", Null, '', " & Profondita & ", " & Sezione & ", " & Padre & ", Null, 'N')"
        DB.EsegueSql(conn, Sql)

        conn.close()
        DB = Nothing
        r = Nothing

        Return Progressivo
    End Function

    Public Sub ModificaDescrizioneAttivita(idAttivita As Integer, Progressivo As Integer, Descrizione As String)
        Dim r As New RoutineVarie
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim Sql As String
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Sql = "Update Log Set "
        Sql &= "Descrizione='" & r.SistemaTestoPerDB(r.ConverteStringaInUTF8(Descrizione)) & "' "
        Sql &= "Where idAttivita=" & idAttivita & " And Progressivo=" & Progressivo
        DB.EsegueSql(conn, Sql)

        conn.close()
        DB = Nothing
        r = Nothing
    End Sub

    Public Sub ModificaLogAttivita(idAttivita As Integer, Progressivo As Integer, Descrizione As String, DataInserimento As String, DataChiusura As String, Notelle As String, DataPresaInCarico As String)
        Dim r As New RoutineVarie
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim Sql As String
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Sql = "Update Log Set "
        If Descrizione <> "" Then
            Sql &= "Descrizione='" & r.SistemaTestoPerDB(r.ConverteStringaInUTF8(Descrizione)) & "', "
        End If
        Sql &= "DataChiusura=" & r.ConverteDataPerDB(DataChiusura) & ", "
        Sql &= "NoteChiusura='" & r.SistemaTestoPerDB(r.ConverteStringaInUTF8(Notelle)) & "', "
        Sql &= "DataPresaInCarico=" & r.ConverteDataPerDB(DataPresaInCarico) & " "
        Sql &= "Where idAttivita=" & idAttivita & " And Progressivo=" & Progressivo
        DB.EsegueSql(conn, Sql)

        conn.close()
        DB = Nothing
        r = Nothing
    End Sub

    Public Sub EliminaTuttoLogAttivita(idAttivita As Integer)
        Dim r As New RoutineVarie
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim Sql As String
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Sql = "Update Log Set Eliminata='S' " &
            "Where idAttivita=" & idAttivita
        DB.EsegueSql(conn, Sql)

        conn.close()
        DB = Nothing
        r = Nothing
    End Sub

    Public Function RitornaDatiLogIntervento(idAttivita As Integer, Progressivo As Integer) As String
        Dim Ritorno As String = ""
        Dim r As New RoutineVarie
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Sql = "Select * From Log Where idAttivita=" & idAttivita & " And Progressivo=" & Progressivo
        rec = DB.LeggeQuery(conn, Sql)
        If Not rec.eof Then
            Ritorno &= rec("idAttivita").Value & Separatore
            Ritorno &= rec("Progressivo").Value & Separatore
            Ritorno &= rec("Descrizione").Value & Separatore
            Ritorno &= rec("DataInserimento").Value & Separatore
            Ritorno &= rec("DataChiusura").Value & Separatore
            Ritorno &= rec("NoteChiusura").Value & Separatore
            Ritorno &= rec("Profondita").Value & Separatore
            Ritorno &= rec("Sezione").Value & Separatore
            Ritorno &= rec("DataPresaInCarico").Value & Separatore
        End If
        rec.close()

        conn.close()
        DB = Nothing
        r = Nothing

        Return Ritorno
    End Function

    Public Sub ControllaSeCiSonoInterventiApertiPerProfondita(idAttivita As Integer, ProgrAttuale As Integer, Sezione As Integer, DataChiusura As String, Notelle As String, DataPresaInCarico As String)
        Dim Ritorno As String = ""
        Dim r As New RoutineVarie
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        'Dim prof() As Integer = {}
        'Dim numProf As Integer = 0

        Sql = "Select Profondita From Log Where idAttivita=" & idAttivita & " And Progressivo=" & ProgrAttuale
        rec = DB.LeggeQuery(conn, Sql)
        Dim ProfonditaSelezionato As Integer = rec("Profondita").Value
        rec.Close()

        Sql = "Select * From Log Where idAttivita=" & idAttivita & " And Sezione=" & Sezione & " And Progressivo>" & ProgrAttuale & " Order By Progressivo, Profondita"
        rec = DB.LeggeQuery(conn, Sql)
        Do Until rec.eof
            'ReDim Preserve prof(numProf)
            'prof(numProf) = rec(0).Value
            'numProf += 1
            If rec("Profondita").Value <= ProfonditaSelezionato Then
                Exit Do
            End If

            Sql = "Update Log Set DataChiusura=" & r.ConverteDataPerDB(Now) & ", NoteChiusura='" & r.SistemaTestoPerDB(Notelle) & "' Where " &
                "idAttivita=" & idAttivita & " And " &
                "Progressivo=" & rec("Progressivo").Value
            DB.EsegueSql(conn, Sql)

            rec.movenext()
        Loop
        rec.close()

        'Dim Padre As Integer = -1

        'For i As Integer = 0 To numProf - 1
        '    ' Elimina i padre del figlio
        '    Padre = -1
        '    Dim TuttiChiusi As Boolean = True
        '    Dim oldPadre As Integer = -1

        '    Sql = "Select * From Log Where idAttivita=" & idAttivita & " And Sezione=" & Sezione & " And Profondita=" & prof(i) & " And (DataChiusura Is Null Or DataChiusura='') Order By Padre"
        '    rec = DB.LeggeQuery(conn, Sql)
        '    Do Until rec.eof
        '        If rec("Padre").Value <> "0" Then
        '            Padre = rec("Padre").Value
        '        End If

        '        If oldPadre <> Padre Then
        '            If oldPadre <> -1 Then
        '                Sql = "Update Log Set " &
        '                    "DataChiusura=" & r.ConverteDataPerDB(Now) & ", " &
        '                    "NoteChiusura='" & r.SistemaTestoPerDB(Notelle) & "' " &
        '                    "Where idAttivita=" & idAttivita & " And Progressivo=" & oldPadre
        '                DB.EsegueSql(conn, Sql)
        '            End If
        '            oldPadre = Padre
        '        End If

        '        rec.movenext()
        '    Loop
        '    rec.Close()

        '    If oldPadre <> -1 Then
        '        Sql = "Update Log Set " &
        '            "DataChiusura=" & r.ConverteDataPerDB(Now) & ", " &
        '            "NoteChiusura='" & r.SistemaTestoPerDB(Notelle) & "' " &
        '            "Where idAttivita=" & idAttivita & " And Progressivo=" & oldPadre
        '        DB.EsegueSql(conn, Sql)
        '    End If
        '    ' Elimina i padre del figlio

        '    'If Padre > -1 Then
        '    Sql = "Select * From Log Where idAttivita=" & idAttivita & " And Sezione=" & Sezione & " And Progressivo>" & ProgrAttuale & " And DataChiusura Is Null"
        '    rec = DB.LeggeQuery(conn, Sql)
        '    Do Until rec.eof
        '        Sql = "Update Log Set " &
        '            "DataChiusura=" & r.ConverteDataPerDB(DataChiusura) & ", " &
        '            "NoteChiusura='" & r.SistemaTestoPerDB(Notelle) & "' " &
        '            "Where idAttivita=" & idAttivita & " And Progressivo=" & rec("Progressivo").Value
        '        DB.EsegueSql(conn, Sql)

        '        rec.movenext()
        '    Loop
        '    rec.close()
        '    'End If
        '    'End If

        'Next

        'Sql = "Select * From Log Where idAttivita=" & idAttivita & " And Sezione=" & Sezione & " And Padre=" & ProgrAttuale & " And DataChiusura Is Null"
        'rec = DB.LeggeQuery(conn, Sql)
        'Do Until rec.eof
        '    Sql = "Update Log Set " &
        '        "DataChiusura=" & r.ConverteDataPerDB(DataChiusura) & ", " &
        '        "NoteChiusura='" & r.SistemaTestoPerDB(Notelle) & "', " &
        '        "DataPresaInCarico=" & r.ConverteDataPerDB(DataPresaInCarico) & ", " &
        '        "Where idAttivita=" & idAttivita & " And Progressivo=" & rec("Progressivo").Value
        '    DB.EsegueSql(conn, Sql)

        '    rec.movenext()
        'Loop
        'rec.close()

        conn.close()
        DB = Nothing
        r = Nothing
    End Sub

    Public Sub EliminaIntervento(idAttivita As Integer, idLog As Integer)
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Dim Eliminare() As Integer = {}
        Dim qEliminare As Integer = 0

        Sql = "Select Distinct(Progressivo) From Log Where idAttivita=" & idAttivita & " And Padre=" & idLog
        rec = DB.LeggeQuery(conn, Sql)
        Do Until rec.eof
            ReDim Preserve Eliminare(qEliminare)
            Eliminare(qEliminare) = rec(0).Value
            qEliminare += 1

            rec.movenext()
        Loop
        rec.close()

        For i As Integer = 0 To qEliminare - 1
            Sql = "Update Log Set Eliminata='S' Where idAttivita=" & idAttivita & " And Padre=" & Eliminare(i)
            DB.EsegueSql(conn, Sql)
        Next
        Sql = "Update Log Set Eliminata='S'  Where idAttivita=" & idAttivita & " And Padre=" & idLog
        DB.EsegueSql(conn, Sql)

        Sql = "Update Log Set Eliminata='S'  Where idAttivita=" & idAttivita & " And Progressivo=" & idLog
        DB.EsegueSql(conn, Sql)

        conn.Close()
        DB = Nothing
    End Sub

    Public Function RitornaProgressivoLogAttivita(idAttivita As Integer, Descrizione As String, DataInserimento As String) As Integer
        Dim r As New RoutineVarie
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Dim Progressivo As Integer = -1
        Sql = "Select Progressivo From Log Where idAttivita=" & idAttivita & " And Descrizione='" & r.SistemaTestoPerDB(Descrizione) & "' And DataInserimento=" & r.ConverteDataPerDB(DataInserimento)
        rec = DB.LeggeQuery(conn, Sql)
        If Not rec.eof Then
            Progressivo = rec(0).Value
        End If
        rec.close()

        conn.close()
        DB = Nothing
        r = Nothing

        Return Progressivo
    End Function

    Public Sub RitornaAttivitaChiuse(idAttivita As Integer, lstLog As ListBox, DataChiusuraInizio As String, DataChiusuraFine As String)
        Dim r As New RoutineVarie
        Dim DB As New SQLSERVERCE
        Dim conn As Object = CreateObject("ADODB.Connection")
        Dim rec As Object = CreateObject("ADODB.Recordset")
        Dim Sql As String
        DB.ImpostaNomeDB(PathDB)
        DB.LeggeImpostazioniDiBase()
        conn = DB.ApreDB()

        Dim Profondita As Integer
        Dim PreScritta As String = ""
        Dim VecchiaSezione As Integer = -1
        Dim Righe As Integer = 0
        Dim Contatore As Integer = 0
        Dim Altro As String

        Sql = "Select * From Log Where idAttivita=" & idAttivita & " And DataChiusura Is Not Null And DataChiusura Between " & r.ConverteDataPerDB(DataChiusuraInizio) & " And " & r.ConverteDataPerDB(DataChiusuraFine) & " And Eliminata='N' Order By Sezione Desc, Progressivo, Profondita"
        lstLog.Items.Clear()
        rec = DB.LeggeQuery(conn, Sql)
        Do Until rec.eof
            Altro = ""

            Profondita = rec("Profondita").Value
            If Profondita = 0 Then
                Contatore += 1
                Altro = Contatore
                If Altro.Length = 1 Then
                    Altro = " " & Altro
                End If
                Altro &= ". "
            Else
                Altro = "   "
            End If

            PreScritta = ""
            For i As Integer = 0 To Profondita - 1
                PreScritta += Space(4)
            Next

            If (VecchiaSezione <> rec("Sezione").Value) And VecchiaSezione <> -1 Then
                VecchiaSezione = rec("Sezione").Value
                'lstLog.Items.Add("")
            Else
                If VecchiaSezione = -1 Then
                    VecchiaSezione = rec("Sezione").Value
                End If
            End If

            lstLog.Items.Add(Altro & PreScritta & rec(2).Value)
            If "" & rec("NoteChiusura").Value <> "" Then
                lstLog.Items.Add(Altro & PreScritta & "--- " & rec("NoteChiusura").Value & " ---")
            End If

            Righe += 1

            rec.movenext()
        Loop
        rec.close()

        conn.close()
        DB = Nothing
        r = Nothing
    End Sub

    Public Function RitornaProfondita(Cosa As String) As Integer
        Dim Ritorno As Integer = 0

        For i As Integer = 1 To Cosa.Length
            If Asc(Mid(Cosa, i, 1)) = 9 Then
                Ritorno += 1
            Else
                Exit For
            End If
        Next

        Return Ritorno
    End Function
End Class
