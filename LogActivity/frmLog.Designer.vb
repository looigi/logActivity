<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLog
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLog))
        Me.lstLog = New System.Windows.Forms.ListBox()
        Me.cmdRicerca = New System.Windows.Forms.Button()
        Me.txtDataFine = New System.Windows.Forms.TextBox()
        Me.txtDataInizio = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdStampa = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstLog
        '
        Me.lstLog.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstLog.FormattingEnabled = True
        Me.lstLog.ItemHeight = 16
        Me.lstLog.Location = New System.Drawing.Point(12, 12)
        Me.lstLog.Name = "lstLog"
        Me.lstLog.Size = New System.Drawing.Size(735, 356)
        Me.lstLog.TabIndex = 0
        '
        'cmdRicerca
        '
        Me.cmdRicerca.Location = New System.Drawing.Point(529, 372)
        Me.cmdRicerca.Name = "cmdRicerca"
        Me.cmdRicerca.Size = New System.Drawing.Size(75, 23)
        Me.cmdRicerca.TabIndex = 1
        Me.cmdRicerca.Text = "Ricerca"
        Me.cmdRicerca.UseVisualStyleBackColor = True
        '
        'txtDataFine
        '
        Me.txtDataFine.Location = New System.Drawing.Point(331, 374)
        Me.txtDataFine.Name = "txtDataFine"
        Me.txtDataFine.Size = New System.Drawing.Size(179, 20)
        Me.txtDataFine.TabIndex = 2
        '
        'txtDataInizio
        '
        Me.txtDataInizio.Location = New System.Drawing.Point(74, 373)
        Me.txtDataInizio.Name = "txtDataInizio"
        Me.txtDataInizio.Size = New System.Drawing.Size(184, 20)
        Me.txtDataInizio.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(275, 377)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Data fine"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 377)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Data inizio"
        '
        'cmdStampa
        '
        Me.cmdStampa.Location = New System.Drawing.Point(672, 371)
        Me.cmdStampa.Name = "cmdStampa"
        Me.cmdStampa.Size = New System.Drawing.Size(75, 23)
        Me.cmdStampa.TabIndex = 6
        Me.cmdStampa.Text = "Stampa"
        Me.cmdStampa.UseVisualStyleBackColor = True
        '
        'frmLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 406)
        Me.Controls.Add(Me.cmdStampa)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDataInizio)
        Me.Controls.Add(Me.txtDataFine)
        Me.Controls.Add(Me.cmdRicerca)
        Me.Controls.Add(Me.lstLog)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Genera Log"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstLog As System.Windows.Forms.ListBox
    Friend WithEvents cmdRicerca As System.Windows.Forms.Button
    Friend WithEvents txtDataFine As System.Windows.Forms.TextBox
    Friend WithEvents txtDataInizio As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdStampa As System.Windows.Forms.Button
End Class
