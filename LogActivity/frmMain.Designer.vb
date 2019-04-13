<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.lstAttivita = New System.Windows.Forms.ListBox()
        Me.cmdCaricaDaFile = New System.Windows.Forms.Button()
        Me.lstLog = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.optTutte = New System.Windows.Forms.RadioButton()
        Me.optEseguite = New System.Windows.Forms.RadioButton()
        Me.optDaEseguire = New System.Windows.Forms.RadioButton()
        Me.lblCaricate = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAttivita = New System.Windows.Forms.TextBox()
        Me.cmdSalva = New System.Windows.Forms.Button()
        Me.cmdElimina = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.chkPulisce = New System.Windows.Forms.CheckBox()
        Me.lblLog = New System.Windows.Forms.Label()
        Me.cmdGeneraLog = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstAttivita
        '
        Me.lstAttivita.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstAttivita.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstAttivita.FormattingEnabled = True
        Me.lstAttivita.ItemHeight = 16
        Me.lstAttivita.Location = New System.Drawing.Point(484, 27)
        Me.lstAttivita.Name = "lstAttivita"
        Me.lstAttivita.Size = New System.Drawing.Size(359, 100)
        Me.lstAttivita.TabIndex = 0
        '
        'cmdCaricaDaFile
        '
        Me.cmdCaricaDaFile.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCaricaDaFile.Location = New System.Drawing.Point(15, 125)
        Me.cmdCaricaDaFile.Name = "cmdCaricaDaFile"
        Me.cmdCaricaDaFile.Size = New System.Drawing.Size(141, 23)
        Me.cmdCaricaDaFile.TabIndex = 1
        Me.cmdCaricaDaFile.Text = "Carica LOG da file"
        Me.cmdCaricaDaFile.UseVisualStyleBackColor = True
        '
        'lstLog
        '
        Me.lstLog.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstLog.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lstLog.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstLog.FormattingEnabled = True
        Me.lstLog.ItemHeight = 15
        Me.lstLog.Location = New System.Drawing.Point(10, 154)
        Me.lstLog.Name = "lstLog"
        Me.lstLog.Size = New System.Drawing.Size(833, 439)
        Me.lstLog.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.optTutte)
        Me.Panel1.Controls.Add(Me.optEseguite)
        Me.Panel1.Controls.Add(Me.optDaEseguire)
        Me.Panel1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(15, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(103, 71)
        Me.Panel1.TabIndex = 3
        '
        'optTutte
        '
        Me.optTutte.AutoSize = True
        Me.optTutte.Location = New System.Drawing.Point(3, 49)
        Me.optTutte.Name = "optTutte"
        Me.optTutte.Size = New System.Drawing.Size(55, 20)
        Me.optTutte.TabIndex = 2
        Me.optTutte.TabStop = True
        Me.optTutte.Text = "Tutte"
        Me.optTutte.UseVisualStyleBackColor = True
        '
        'optEseguite
        '
        Me.optEseguite.AutoSize = True
        Me.optEseguite.Location = New System.Drawing.Point(3, 26)
        Me.optEseguite.Name = "optEseguite"
        Me.optEseguite.Size = New System.Drawing.Size(77, 20)
        Me.optEseguite.TabIndex = 1
        Me.optEseguite.TabStop = True
        Me.optEseguite.Text = "Eseguite"
        Me.optEseguite.UseVisualStyleBackColor = True
        '
        'optDaEseguire
        '
        Me.optDaEseguire.AutoSize = True
        Me.optDaEseguire.Location = New System.Drawing.Point(3, 3)
        Me.optDaEseguire.Name = "optDaEseguire"
        Me.optDaEseguire.Size = New System.Drawing.Size(97, 20)
        Me.optDaEseguire.TabIndex = 0
        Me.optDaEseguire.TabStop = True
        Me.optDaEseguire.Text = "Da Eseguire"
        Me.optDaEseguire.UseVisualStyleBackColor = True
        '
        'lblCaricate
        '
        Me.lblCaricate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaricate.Location = New System.Drawing.Point(12, 9)
        Me.lblCaricate.Name = "lblCaricate"
        Me.lblCaricate.Size = New System.Drawing.Size(94, 15)
        Me.lblCaricate.TabIndex = 4
        Me.lblCaricate.Text = "Label1"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(484, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(253, 19)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Lista attività"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtAttivita
        '
        Me.txtAttivita.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAttivita.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAttivita.Location = New System.Drawing.Point(484, 128)
        Me.txtAttivita.Name = "txtAttivita"
        Me.txtAttivita.Size = New System.Drawing.Size(234, 22)
        Me.txtAttivita.TabIndex = 6
        '
        'cmdSalva
        '
        Me.cmdSalva.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSalva.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSalva.Location = New System.Drawing.Point(724, 128)
        Me.cmdSalva.Name = "cmdSalva"
        Me.cmdSalva.Size = New System.Drawing.Size(54, 23)
        Me.cmdSalva.TabIndex = 7
        Me.cmdSalva.Text = "Salva"
        Me.cmdSalva.UseVisualStyleBackColor = True
        '
        'cmdElimina
        '
        Me.cmdElimina.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdElimina.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdElimina.Location = New System.Drawing.Point(784, 128)
        Me.cmdElimina.Name = "cmdElimina"
        Me.cmdElimina.Size = New System.Drawing.Size(59, 23)
        Me.cmdElimina.TabIndex = 8
        Me.cmdElimina.Text = "Elimina"
        Me.cmdElimina.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'chkPulisce
        '
        Me.chkPulisce.AutoSize = True
        Me.chkPulisce.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPulisce.Location = New System.Drawing.Point(15, 102)
        Me.chkPulisce.Name = "chkPulisce"
        Me.chkPulisce.Size = New System.Drawing.Size(131, 20)
        Me.chkPulisce.TabIndex = 9
        Me.chkPulisce.Text = "Pulisce vecchi log"
        Me.chkPulisce.UseVisualStyleBackColor = True
        '
        'lblLog
        '
        Me.lblLog.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLog.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLog.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLog.Location = New System.Drawing.Point(10, 599)
        Me.lblLog.Name = "lblLog"
        Me.lblLog.Size = New System.Drawing.Size(833, 37)
        Me.lblLog.TabIndex = 10
        Me.lblLog.Text = "Lista attività"
        '
        'cmdGeneraLog
        '
        Me.cmdGeneraLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGeneraLog.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGeneraLog.Location = New System.Drawing.Point(743, 1)
        Me.cmdGeneraLog.Name = "cmdGeneraLog"
        Me.cmdGeneraLog.Size = New System.Drawing.Size(100, 23)
        Me.cmdGeneraLog.TabIndex = 11
        Me.cmdGeneraLog.Text = "Genera LOG"
        Me.cmdGeneraLog.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(855, 645)
        Me.Controls.Add(Me.cmdGeneraLog)
        Me.Controls.Add(Me.lblLog)
        Me.Controls.Add(Me.chkPulisce)
        Me.Controls.Add(Me.cmdElimina)
        Me.Controls.Add(Me.cmdSalva)
        Me.Controls.Add(Me.txtAttivita)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblCaricate)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lstLog)
        Me.Controls.Add(Me.cmdCaricaDaFile)
        Me.Controls.Add(Me.lstAttivita)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Log Activity"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstAttivita As System.Windows.Forms.ListBox
    Friend WithEvents cmdCaricaDaFile As System.Windows.Forms.Button
    Friend WithEvents lstLog As System.Windows.Forms.ListBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents optTutte As System.Windows.Forms.RadioButton
    Friend WithEvents optEseguite As System.Windows.Forms.RadioButton
    Friend WithEvents optDaEseguire As System.Windows.Forms.RadioButton
    Friend WithEvents lblCaricate As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAttivita As System.Windows.Forms.TextBox
    Friend WithEvents cmdSalva As System.Windows.Forms.Button
    Friend WithEvents cmdElimina As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents chkPulisce As System.Windows.Forms.CheckBox
    Friend WithEvents lblLog As System.Windows.Forms.Label
    Friend WithEvents cmdGeneraLog As System.Windows.Forms.Button

End Class
