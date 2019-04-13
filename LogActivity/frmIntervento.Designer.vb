<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIntervento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIntervento))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblIdItervento = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDescrizione = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblDataInserimento = New System.Windows.Forms.Label()
        Me.lblDataChiusura = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.lblSezione = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblProfondita = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmdChiude = New System.Windows.Forms.Button()
        Me.cmdAggiorna = New System.Windows.Forms.Button()
        Me.lblTitPadre = New System.Windows.Forms.Label()
        Me.lblPadre = New System.Windows.Forms.Label()
        Me.lblDataPresaInCarico = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Id"
        '
        'lblIdItervento
        '
        Me.lblIdItervento.AutoSize = True
        Me.lblIdItervento.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdItervento.Location = New System.Drawing.Point(43, 13)
        Me.lblIdItervento.Name = "lblIdItervento"
        Me.lblIdItervento.Size = New System.Drawing.Size(46, 16)
        Me.lblIdItervento.TabIndex = 1
        Me.lblIdItervento.Text = "Label2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Intervento"
        '
        'txtDescrizione
        '
        Me.txtDescrizione.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescrizione.Location = New System.Drawing.Point(92, 89)
        Me.txtDescrizione.MaxLength = 255
        Me.txtDescrizione.Multiline = True
        Me.txtDescrizione.Name = "txtDescrizione"
        Me.txtDescrizione.Size = New System.Drawing.Size(598, 104)
        Me.txtDescrizione.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 196)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Inserimento"
        '
        'lblDataInserimento
        '
        Me.lblDataInserimento.AutoSize = True
        Me.lblDataInserimento.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDataInserimento.Location = New System.Drawing.Point(89, 196)
        Me.lblDataInserimento.Name = "lblDataInserimento"
        Me.lblDataInserimento.Size = New System.Drawing.Size(75, 16)
        Me.lblDataInserimento.TabIndex = 5
        Me.lblDataInserimento.Text = "Inserimento"
        '
        'lblDataChiusura
        '
        Me.lblDataChiusura.AutoSize = True
        Me.lblDataChiusura.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDataChiusura.Location = New System.Drawing.Point(89, 224)
        Me.lblDataChiusura.Name = "lblDataChiusura"
        Me.lblDataChiusura.Size = New System.Drawing.Size(75, 16)
        Me.lblDataChiusura.TabIndex = 7
        Me.lblDataChiusura.Text = "Inserimento"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 224)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Chiusura"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 282)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 16)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Note"
        '
        'txtNote
        '
        Me.txtNote.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNote.Location = New System.Drawing.Point(92, 282)
        Me.txtNote.MaxLength = 255
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(598, 107)
        Me.txtNote.TabIndex = 9
        '
        'lblSezione
        '
        Me.lblSezione.AutoSize = True
        Me.lblSezione.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSezione.Location = New System.Drawing.Point(92, 430)
        Me.lblSezione.Name = "lblSezione"
        Me.lblSezione.Size = New System.Drawing.Size(75, 16)
        Me.lblSezione.TabIndex = 13
        Me.lblSezione.Text = "Inserimento"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 430)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 16)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Sezione"
        '
        'lblProfondita
        '
        Me.lblProfondita.AutoSize = True
        Me.lblProfondita.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProfondita.Location = New System.Drawing.Point(92, 402)
        Me.lblProfondita.Name = "lblProfondita"
        Me.lblProfondita.Size = New System.Drawing.Size(75, 16)
        Me.lblProfondita.TabIndex = 11
        Me.lblProfondita.Text = "Inserimento"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(15, 402)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 16)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Profondità"
        '
        'cmdChiude
        '
        Me.cmdChiude.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChiude.Location = New System.Drawing.Point(618, 449)
        Me.cmdChiude.Name = "cmdChiude"
        Me.cmdChiude.Size = New System.Drawing.Size(75, 23)
        Me.cmdChiude.TabIndex = 14
        Me.cmdChiude.Text = "Chiude"
        Me.cmdChiude.UseVisualStyleBackColor = True
        '
        'cmdAggiorna
        '
        Me.cmdAggiorna.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAggiorna.Location = New System.Drawing.Point(537, 449)
        Me.cmdAggiorna.Name = "cmdAggiorna"
        Me.cmdAggiorna.Size = New System.Drawing.Size(75, 23)
        Me.cmdAggiorna.TabIndex = 15
        Me.cmdAggiorna.Text = "Aggiorna"
        Me.cmdAggiorna.UseVisualStyleBackColor = True
        '
        'lblTitPadre
        '
        Me.lblTitPadre.AutoSize = True
        Me.lblTitPadre.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitPadre.Location = New System.Drawing.Point(99, 13)
        Me.lblTitPadre.Name = "lblTitPadre"
        Me.lblTitPadre.Size = New System.Drawing.Size(63, 16)
        Me.lblTitPadre.TabIndex = 16
        Me.lblTitPadre.Text = "Intervento"
        '
        'lblPadre
        '
        Me.lblPadre.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPadre.Location = New System.Drawing.Point(168, 13)
        Me.lblPadre.Name = "lblPadre"
        Me.lblPadre.Size = New System.Drawing.Size(522, 73)
        Me.lblPadre.TabIndex = 17
        Me.lblPadre.Text = "Intervento"
        '
        'lblDataPresaInCarico
        '
        Me.lblDataPresaInCarico.AutoSize = True
        Me.lblDataPresaInCarico.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDataPresaInCarico.Location = New System.Drawing.Point(90, 251)
        Me.lblDataPresaInCarico.Name = "lblDataPresaInCarico"
        Me.lblDataPresaInCarico.Size = New System.Drawing.Size(75, 16)
        Me.lblDataPresaInCarico.TabIndex = 19
        Me.lblDataPresaInCarico.Text = "Inserimento"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 251)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 16)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "P. in carico"
        '
        'frmIntervento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 480)
        Me.Controls.Add(Me.lblDataPresaInCarico)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblPadre)
        Me.Controls.Add(Me.lblTitPadre)
        Me.Controls.Add(Me.cmdAggiorna)
        Me.Controls.Add(Me.cmdChiude)
        Me.Controls.Add(Me.lblSezione)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblProfondita)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtNote)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblDataChiusura)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblDataInserimento)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDescrizione)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblIdItervento)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmIntervento"
        Me.Text = "frmIntervento"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblIdItervento As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDescrizione As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblDataInserimento As System.Windows.Forms.Label
    Friend WithEvents lblDataChiusura As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblSezione As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblProfondita As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdChiude As System.Windows.Forms.Button
    Friend WithEvents cmdAggiorna As System.Windows.Forms.Button
    Friend WithEvents lblTitPadre As System.Windows.Forms.Label
    Friend WithEvents lblPadre As System.Windows.Forms.Label
    Friend WithEvents lblDataPresaInCarico As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
