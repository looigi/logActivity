Module mdlLogActivity
    Public PathDB As String
    Public idAttivitaDefault As Integer
    Public AttivitaDefault As String
    Public TipoVisualizzazione As Integer
    Public Separatore As String = "§"

    Public Enum TipoRitornoLog
        SoloDaEseguire = 1
        Eseguiti = 2
        Tutti = 3
    End Enum
End Module
