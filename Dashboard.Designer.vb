<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class WZtracker
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WZtracker))
        Me.clsBtn = New System.Windows.Forms.Button()
        Me.pbIcon = New System.Windows.Forms.PictureBox()
        Me.mmzBtn = New System.Windows.Forms.Button()
        Me.Namelbl = New System.Windows.Forms.Label()
        Me.btnScreenshot = New System.Windows.Forms.Button()
        Me.btnGrabScreen = New System.Windows.Forms.Button()
        Me.btnResetSR = New System.Windows.Forms.Button()
        Me.lblCurrentSR = New System.Windows.Forms.Label()
        Me.btnChangeHotkey = New System.Windows.Forms.Button()
        Me.cmboxHotkey = New System.Windows.Forms.ComboBox()
        Me.chkboxHotkey = New System.Windows.Forms.CheckBox()
        Me.btnChangeOverlay = New System.Windows.Forms.Button()
        Me.cmboxOverlay = New System.Windows.Forms.ComboBox()
        Me.btnCheckUpdates = New System.Windows.Forms.Button()
        CType(Me.pbIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'clsBtn
        '
        Me.clsBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.clsBtn.BackColor = System.Drawing.Color.Transparent
        Me.clsBtn.BackgroundImage = CType(resources.GetObject("clsBtn.BackgroundImage"), System.Drawing.Image)
        Me.clsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.clsBtn.FlatAppearance.BorderSize = 0
        Me.clsBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.clsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.clsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.clsBtn.Location = New System.Drawing.Point(542, 2)
        Me.clsBtn.Name = "clsBtn"
        Me.clsBtn.Size = New System.Drawing.Size(44, 40)
        Me.clsBtn.TabIndex = 1
        Me.clsBtn.UseVisualStyleBackColor = False
        '
        'pbIcon
        '
        Me.pbIcon.BackColor = System.Drawing.Color.Transparent
        Me.pbIcon.BackgroundImage = Global.WZtracker.My.Resources.Resources.SRicon
        Me.pbIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbIcon.Location = New System.Drawing.Point(2, 2)
        Me.pbIcon.Name = "pbIcon"
        Me.pbIcon.Size = New System.Drawing.Size(63, 42)
        Me.pbIcon.TabIndex = 0
        Me.pbIcon.TabStop = False
        '
        'mmzBtn
        '
        Me.mmzBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mmzBtn.BackColor = System.Drawing.Color.Transparent
        Me.mmzBtn.BackgroundImage = Global.WZtracker.My.Resources.Resources.mmzbtn
        Me.mmzBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.mmzBtn.FlatAppearance.BorderSize = 0
        Me.mmzBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.mmzBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.mmzBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mmzBtn.Location = New System.Drawing.Point(492, 2)
        Me.mmzBtn.Name = "mmzBtn"
        Me.mmzBtn.Size = New System.Drawing.Size(44, 40)
        Me.mmzBtn.TabIndex = 2
        Me.mmzBtn.UseVisualStyleBackColor = False
        '
        'Namelbl
        '
        Me.Namelbl.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Namelbl.AutoSize = True
        Me.Namelbl.BackColor = System.Drawing.Color.Transparent
        Me.Namelbl.Font = New System.Drawing.Font("Impact", 20.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Namelbl.ForeColor = System.Drawing.Color.White
        Me.Namelbl.Location = New System.Drawing.Point(69, 8)
        Me.Namelbl.Name = "Namelbl"
        Me.Namelbl.Size = New System.Drawing.Size(134, 34)
        Me.Namelbl.TabIndex = 3
        Me.Namelbl.Text = "WZTracker"
        '
        'btnScreenshot
        '
        Me.btnScreenshot.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.btnScreenshot.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow
        Me.btnScreenshot.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray
        Me.btnScreenshot.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.btnScreenshot.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnScreenshot.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnScreenshot.ForeColor = System.Drawing.SystemColors.Control
        Me.btnScreenshot.Location = New System.Drawing.Point(12, 72)
        Me.btnScreenshot.Name = "btnScreenshot"
        Me.btnScreenshot.Size = New System.Drawing.Size(120, 32)
        Me.btnScreenshot.TabIndex = 4
        Me.btnScreenshot.Text = "Screenshot"
        Me.btnScreenshot.UseVisualStyleBackColor = False
        '
        'btnGrabScreen
        '
        Me.btnGrabScreen.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.btnGrabScreen.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow
        Me.btnGrabScreen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray
        Me.btnGrabScreen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.btnGrabScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGrabScreen.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabScreen.ForeColor = System.Drawing.SystemColors.Control
        Me.btnGrabScreen.Location = New System.Drawing.Point(12, 110)
        Me.btnGrabScreen.Name = "btnGrabScreen"
        Me.btnGrabScreen.Size = New System.Drawing.Size(166, 32)
        Me.btnGrabScreen.TabIndex = 5
        Me.btnGrabScreen.Text = "Grab Screenposition"
        Me.btnGrabScreen.UseVisualStyleBackColor = False
        '
        'btnResetSR
        '
        Me.btnResetSR.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.btnResetSR.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow
        Me.btnResetSR.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray
        Me.btnResetSR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.btnResetSR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResetSR.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetSR.ForeColor = System.Drawing.SystemColors.Control
        Me.btnResetSR.Location = New System.Drawing.Point(12, 202)
        Me.btnResetSR.Name = "btnResetSR"
        Me.btnResetSR.Size = New System.Drawing.Size(120, 32)
        Me.btnResetSR.TabIndex = 6
        Me.btnResetSR.Text = "Reset SR"
        Me.btnResetSR.UseVisualStyleBackColor = False
        '
        'lblCurrentSR
        '
        Me.lblCurrentSR.AutoSize = True
        Me.lblCurrentSR.BackColor = System.Drawing.Color.Transparent
        Me.lblCurrentSR.Font = New System.Drawing.Font("Impact", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentSR.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCurrentSR.Location = New System.Drawing.Point(138, 205)
        Me.lblCurrentSR.Name = "lblCurrentSR"
        Me.lblCurrentSR.Size = New System.Drawing.Size(123, 29)
        Me.lblCurrentSR.TabIndex = 7
        Me.lblCurrentSR.Text = "Current SR:"
        '
        'btnChangeHotkey
        '
        Me.btnChangeHotkey.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.btnChangeHotkey.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow
        Me.btnChangeHotkey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray
        Me.btnChangeHotkey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.btnChangeHotkey.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChangeHotkey.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangeHotkey.ForeColor = System.Drawing.SystemColors.Control
        Me.btnChangeHotkey.Location = New System.Drawing.Point(12, 263)
        Me.btnChangeHotkey.Name = "btnChangeHotkey"
        Me.btnChangeHotkey.Size = New System.Drawing.Size(120, 32)
        Me.btnChangeHotkey.TabIndex = 8
        Me.btnChangeHotkey.Text = "Change Hotkey"
        Me.btnChangeHotkey.UseVisualStyleBackColor = False
        '
        'cmboxHotkey
        '
        Me.cmboxHotkey.BackColor = System.Drawing.Color.DimGray
        Me.cmboxHotkey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmboxHotkey.ForeColor = System.Drawing.SystemColors.Control
        Me.cmboxHotkey.FormattingEnabled = True
        Me.cmboxHotkey.Location = New System.Drawing.Point(213, 271)
        Me.cmboxHotkey.MaxDropDownItems = 4
        Me.cmboxHotkey.Name = "cmboxHotkey"
        Me.cmboxHotkey.Size = New System.Drawing.Size(121, 21)
        Me.cmboxHotkey.TabIndex = 9
        '
        'chkboxHotkey
        '
        Me.chkboxHotkey.AutoSize = True
        Me.chkboxHotkey.BackColor = System.Drawing.Color.Transparent
        Me.chkboxHotkey.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkboxHotkey.ForeColor = System.Drawing.SystemColors.Control
        Me.chkboxHotkey.Location = New System.Drawing.Point(143, 271)
        Me.chkboxHotkey.Name = "chkboxHotkey"
        Me.chkboxHotkey.Size = New System.Drawing.Size(64, 24)
        Me.chkboxHotkey.TabIndex = 10
        Me.chkboxHotkey.Text = "Ctrl +"
        Me.chkboxHotkey.UseVisualStyleBackColor = False
        '
        'btnChangeOverlay
        '
        Me.btnChangeOverlay.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.btnChangeOverlay.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow
        Me.btnChangeOverlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray
        Me.btnChangeOverlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.btnChangeOverlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChangeOverlay.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangeOverlay.ForeColor = System.Drawing.SystemColors.Control
        Me.btnChangeOverlay.Location = New System.Drawing.Point(12, 354)
        Me.btnChangeOverlay.Name = "btnChangeOverlay"
        Me.btnChangeOverlay.Size = New System.Drawing.Size(166, 32)
        Me.btnChangeOverlay.TabIndex = 11
        Me.btnChangeOverlay.Text = "Change Overlay"
        Me.btnChangeOverlay.UseVisualStyleBackColor = False
        '
        'cmboxOverlay
        '
        Me.cmboxOverlay.BackColor = System.Drawing.Color.DimGray
        Me.cmboxOverlay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmboxOverlay.ForeColor = System.Drawing.SystemColors.Control
        Me.cmboxOverlay.FormattingEnabled = True
        Me.cmboxOverlay.Location = New System.Drawing.Point(213, 363)
        Me.cmboxOverlay.MaxDropDownItems = 4
        Me.cmboxOverlay.Name = "cmboxOverlay"
        Me.cmboxOverlay.Size = New System.Drawing.Size(121, 21)
        Me.cmboxOverlay.TabIndex = 12
        '
        'btnCheckUpdates
        '
        Me.btnCheckUpdates.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.btnCheckUpdates.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow
        Me.btnCheckUpdates.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray
        Me.btnCheckUpdates.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.btnCheckUpdates.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCheckUpdates.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheckUpdates.ForeColor = System.Drawing.SystemColors.Control
        Me.btnCheckUpdates.Location = New System.Drawing.Point(12, 410)
        Me.btnCheckUpdates.Name = "btnCheckUpdates"
        Me.btnCheckUpdates.Size = New System.Drawing.Size(166, 32)
        Me.btnCheckUpdates.TabIndex = 13
        Me.btnCheckUpdates.Text = "Check for Update"
        Me.btnCheckUpdates.UseVisualStyleBackColor = False
        '
        'WZtracker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.BackgroundImage = Global.WZtracker.My.Resources.Resources.background
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(598, 548)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCheckUpdates)
        Me.Controls.Add(Me.cmboxOverlay)
        Me.Controls.Add(Me.btnChangeOverlay)
        Me.Controls.Add(Me.chkboxHotkey)
        Me.Controls.Add(Me.cmboxHotkey)
        Me.Controls.Add(Me.btnChangeHotkey)
        Me.Controls.Add(Me.lblCurrentSR)
        Me.Controls.Add(Me.btnResetSR)
        Me.Controls.Add(Me.btnGrabScreen)
        Me.Controls.Add(Me.btnScreenshot)
        Me.Controls.Add(Me.Namelbl)
        Me.Controls.Add(Me.mmzBtn)
        Me.Controls.Add(Me.clsBtn)
        Me.Controls.Add(Me.pbIcon)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WZtracker"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "WZtracker"
        CType(Me.pbIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pbIcon As PictureBox
    Friend WithEvents clsBtn As Button
    Friend WithEvents mmzBtn As Button
    Friend WithEvents Namelbl As Label
    Friend WithEvents btnScreenshot As Button
    Friend WithEvents btnGrabScreen As Button
    Friend WithEvents btnResetSR As Button
    Friend WithEvents lblCurrentSR As Label
    Friend WithEvents btnChangeHotkey As Button
    Friend WithEvents cmboxHotkey As ComboBox
    Friend WithEvents chkboxHotkey As CheckBox
    Friend WithEvents btnChangeOverlay As Button
    Friend WithEvents cmboxOverlay As ComboBox
    Friend WithEvents btnCheckUpdates As Button
End Class
