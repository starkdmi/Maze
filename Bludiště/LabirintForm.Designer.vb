<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MainGameMenu = New System.Windows.Forms.MenuStrip()
        Me.CreateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewGameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.HardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SinglePlayerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MultiplayerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutoRunToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.YesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BotsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpeedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SlowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NormalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FastToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EasyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MediumToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HardToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LifeStyleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RulesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextGameMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.StopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GoNextEveryTime = New System.Windows.Forms.Timer(Me.components)
        Me.BotsMoving = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusLabelScore = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusLabelHighScore = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LoadingProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.LoadingProgress = New System.Windows.Forms.ProgressBar()
        Me.HelpPanel = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LinkAuthor = New System.Windows.Forms.LinkLabel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.CloseHelpLink = New System.Windows.Forms.LinkLabel()
        Me.HelpPointsIcon = New Bludiště.RoundLabel()
        Me.HelpBotsIcon = New Bludiště.RoundLabel()
        Me.HelpUser2Icon = New Bludiště.RoundLabel()
        Me.HelpUser1Icon = New Bludiště.RoundLabel()
        Me.WorkPanel = New Bludiště.CustomPanel()
        Me.MainGameMenu.SuspendLayout()
        Me.ContextGameMenu.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.HelpPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainGameMenu
        '
        Me.MainGameMenu.BackColor = System.Drawing.Color.LightSlateGray
        Me.MainGameMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreateToolStripMenuItem, Me.SizeToolStripMenuItem, Me.ModeToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MainGameMenu.Location = New System.Drawing.Point(0, 0)
        Me.MainGameMenu.Name = "MainGameMenu"
        Me.MainGameMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MainGameMenu.Size = New System.Drawing.Size(450, 24)
        Me.MainGameMenu.TabIndex = 2
        '
        'CreateToolStripMenuItem
        '
        Me.CreateToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewGameToolStripMenuItem})
        Me.CreateToolStripMenuItem.ForeColor = System.Drawing.Color.Gold
        Me.CreateToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.CreateToolStripMenuItem.Name = "CreateToolStripMenuItem"
        Me.CreateToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.CreateToolStripMenuItem.Text = "Game"
        '
        'NewGameToolStripMenuItem
        '
        Me.NewGameToolStripMenuItem.ForeColor = System.Drawing.Color.Gold
        Me.NewGameToolStripMenuItem.Name = "NewGameToolStripMenuItem"
        Me.NewGameToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.NewGameToolStripMenuItem.Text = "New Game"
        '
        'SizeToolStripMenuItem
        '
        Me.SizeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.HardToolStripMenuItem})
        Me.SizeToolStripMenuItem.ForeColor = System.Drawing.Color.Gold
        Me.SizeToolStripMenuItem.Name = "SizeToolStripMenuItem"
        Me.SizeToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.SizeToolStripMenuItem.Text = "Map"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Checked = True
        Me.ToolStripMenuItem2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripMenuItem2.ForeColor = System.Drawing.Color.Gold
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(119, 22)
        Me.ToolStripMenuItem2.Text = "Small"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.ForeColor = System.Drawing.Color.Gold
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(119, 22)
        Me.ToolStripMenuItem3.Text = "Medium"
        '
        'HardToolStripMenuItem
        '
        Me.HardToolStripMenuItem.ForeColor = System.Drawing.Color.Gold
        Me.HardToolStripMenuItem.Name = "HardToolStripMenuItem"
        Me.HardToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.HardToolStripMenuItem.Text = "Big"
        '
        'ModeToolStripMenuItem
        '
        Me.ModeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SinglePlayerToolStripMenuItem, Me.MultiplayerToolStripMenuItem})
        Me.ModeToolStripMenuItem.ForeColor = System.Drawing.Color.Gold
        Me.ModeToolStripMenuItem.Name = "ModeToolStripMenuItem"
        Me.ModeToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.ModeToolStripMenuItem.Text = "Mode"
        '
        'SinglePlayerToolStripMenuItem
        '
        Me.SinglePlayerToolStripMenuItem.Checked = True
        Me.SinglePlayerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SinglePlayerToolStripMenuItem.ForeColor = System.Drawing.Color.Gold
        Me.SinglePlayerToolStripMenuItem.Name = "SinglePlayerToolStripMenuItem"
        Me.SinglePlayerToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.SinglePlayerToolStripMenuItem.Text = "Single player"
        '
        'MultiplayerToolStripMenuItem
        '
        Me.MultiplayerToolStripMenuItem.ForeColor = System.Drawing.Color.Gold
        Me.MultiplayerToolStripMenuItem.Name = "MultiplayerToolStripMenuItem"
        Me.MultiplayerToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.MultiplayerToolStripMenuItem.Text = "Multiplayer"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AutoRunToolStripMenuItem, Me.BotsToolStripMenuItem})
        Me.SettingsToolStripMenuItem.ForeColor = System.Drawing.Color.Gold
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'AutoRunToolStripMenuItem
        '
        Me.AutoRunToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.YesToolStripMenuItem, Me.NoToolStripMenuItem})
        Me.AutoRunToolStripMenuItem.ForeColor = System.Drawing.Color.Gold
        Me.AutoRunToolStripMenuItem.Name = "AutoRunToolStripMenuItem"
        Me.AutoRunToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.AutoRunToolStripMenuItem.Text = "Auto run"
        '
        'YesToolStripMenuItem
        '
        Me.YesToolStripMenuItem.ForeColor = System.Drawing.Color.Gold
        Me.YesToolStripMenuItem.Name = "YesToolStripMenuItem"
        Me.YesToolStripMenuItem.Size = New System.Drawing.Size(91, 22)
        Me.YesToolStripMenuItem.Text = "Yes"
        '
        'NoToolStripMenuItem
        '
        Me.NoToolStripMenuItem.Checked = True
        Me.NoToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.NoToolStripMenuItem.ForeColor = System.Drawing.Color.Gold
        Me.NoToolStripMenuItem.Name = "NoToolStripMenuItem"
        Me.NoToolStripMenuItem.Size = New System.Drawing.Size(91, 22)
        Me.NoToolStripMenuItem.Text = "No"
        '
        'BotsToolStripMenuItem
        '
        Me.BotsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusToolStripMenuItem, Me.SpeedToolStripMenuItem, Me.CountToolStripMenuItem, Me.LifeStyleToolStripMenuItem})
        Me.BotsToolStripMenuItem.ForeColor = System.Drawing.Color.Gold
        Me.BotsToolStripMenuItem.Name = "BotsToolStripMenuItem"
        Me.BotsToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.BotsToolStripMenuItem.Text = "Bots"
        '
        'StatusToolStripMenuItem
        '
        Me.StatusToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OnToolStripMenuItem, Me.OffToolStripMenuItem})
        Me.StatusToolStripMenuItem.ForeColor = System.Drawing.Color.Gold
        Me.StatusToolStripMenuItem.Name = "StatusToolStripMenuItem"
        Me.StatusToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.StatusToolStripMenuItem.Text = "Status"
        '
        'OnToolStripMenuItem
        '
        Me.OnToolStripMenuItem.Checked = True
        Me.OnToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.OnToolStripMenuItem.ForeColor = System.Drawing.Color.Gold
        Me.OnToolStripMenuItem.Name = "OnToolStripMenuItem"
        Me.OnToolStripMenuItem.Size = New System.Drawing.Size(91, 22)
        Me.OnToolStripMenuItem.Text = "On"
        '
        'OffToolStripMenuItem
        '
        Me.OffToolStripMenuItem.ForeColor = System.Drawing.Color.Gold
        Me.OffToolStripMenuItem.Name = "OffToolStripMenuItem"
        Me.OffToolStripMenuItem.Size = New System.Drawing.Size(91, 22)
        Me.OffToolStripMenuItem.Text = "Off"
        '
        'SpeedToolStripMenuItem
        '
        Me.SpeedToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SlowToolStripMenuItem, Me.NormalToolStripMenuItem, Me.FastToolStripMenuItem})
        Me.SpeedToolStripMenuItem.ForeColor = System.Drawing.Color.Gold
        Me.SpeedToolStripMenuItem.Name = "SpeedToolStripMenuItem"
        Me.SpeedToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.SpeedToolStripMenuItem.Text = "Speed"
        '
        'SlowToolStripMenuItem
        '
        Me.SlowToolStripMenuItem.Checked = True
        Me.SlowToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SlowToolStripMenuItem.ForeColor = System.Drawing.Color.Gold
        Me.SlowToolStripMenuItem.Name = "SlowToolStripMenuItem"
        Me.SlowToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.SlowToolStripMenuItem.Text = "Slow"
        '
        'NormalToolStripMenuItem
        '
        Me.NormalToolStripMenuItem.ForeColor = System.Drawing.Color.Gold
        Me.NormalToolStripMenuItem.Name = "NormalToolStripMenuItem"
        Me.NormalToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.NormalToolStripMenuItem.Text = "Normal"
        '
        'FastToolStripMenuItem
        '
        Me.FastToolStripMenuItem.ForeColor = System.Drawing.Color.Gold
        Me.FastToolStripMenuItem.Name = "FastToolStripMenuItem"
        Me.FastToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.FastToolStripMenuItem.Text = "Fast"
        '
        'CountToolStripMenuItem
        '
        Me.CountToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EasyToolStripMenuItem, Me.MediumToolStripMenuItem, Me.HardToolStripMenuItem1})
        Me.CountToolStripMenuItem.ForeColor = System.Drawing.Color.Gold
        Me.CountToolStripMenuItem.Name = "CountToolStripMenuItem"
        Me.CountToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.CountToolStripMenuItem.Text = "Count"
        '
        'EasyToolStripMenuItem
        '
        Me.EasyToolStripMenuItem.Checked = True
        Me.EasyToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.EasyToolStripMenuItem.ForeColor = System.Drawing.Color.Gold
        Me.EasyToolStripMenuItem.Name = "EasyToolStripMenuItem"
        Me.EasyToolStripMenuItem.Size = New System.Drawing.Size(104, 22)
        Me.EasyToolStripMenuItem.Text = "Few"
        '
        'MediumToolStripMenuItem
        '
        Me.MediumToolStripMenuItem.ForeColor = System.Drawing.Color.Gold
        Me.MediumToolStripMenuItem.Name = "MediumToolStripMenuItem"
        Me.MediumToolStripMenuItem.Size = New System.Drawing.Size(104, 22)
        Me.MediumToolStripMenuItem.Text = "Little"
        '
        'HardToolStripMenuItem1
        '
        Me.HardToolStripMenuItem1.ForeColor = System.Drawing.Color.Gold
        Me.HardToolStripMenuItem1.Name = "HardToolStripMenuItem1"
        Me.HardToolStripMenuItem1.Size = New System.Drawing.Size(104, 22)
        Me.HardToolStripMenuItem1.Text = "Many"
        '
        'LifeStyleToolStripMenuItem
        '
        Me.LifeStyleToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem4, Me.ToolStripMenuItem5})
        Me.LifeStyleToolStripMenuItem.ForeColor = System.Drawing.Color.Gold
        Me.LifeStyleToolStripMenuItem.Name = "LifeStyleToolStripMenuItem"
        Me.LifeStyleToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.LifeStyleToolStripMenuItem.Text = "Life style"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.ForeColor = System.Drawing.Color.Gold
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(114, 22)
        Me.ToolStripMenuItem4.Text = "Mode 1"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Checked = True
        Me.ToolStripMenuItem5.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripMenuItem5.ForeColor = System.Drawing.Color.Gold
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(114, 22)
        Me.ToolStripMenuItem5.Text = "Mode 2"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RulesToolStripMenuItem})
        Me.HelpToolStripMenuItem.ForeColor = System.Drawing.Color.Gold
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'RulesToolStripMenuItem
        '
        Me.RulesToolStripMenuItem.ForeColor = System.Drawing.Color.Gold
        Me.RulesToolStripMenuItem.Name = "RulesToolStripMenuItem"
        Me.RulesToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.RulesToolStripMenuItem.Text = "Rules"
        '
        'ContextGameMenu
        '
        Me.ContextGameMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StopToolStripMenuItem})
        Me.ContextGameMenu.Name = "ContextGameMenu"
        Me.ContextGameMenu.Size = New System.Drawing.Size(93, 26)
        '
        'StopToolStripMenuItem
        '
        Me.StopToolStripMenuItem.Name = "StopToolStripMenuItem"
        Me.StopToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.StopToolStripMenuItem.Text = "Exit"
        '
        'GoNextEveryTime
        '
        Me.GoNextEveryTime.Interval = 500
        '
        'BotsMoving
        '
        Me.BotsMoving.Interval = 1000
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.LightSlateGray
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabelScore, Me.StatusLabelHighScore, Me.LoadingProgressBar})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 475)
        Me.StatusStrip1.Margin = New System.Windows.Forms.Padding(2)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StatusStrip1.Size = New System.Drawing.Size(450, 22)
        Me.StatusStrip1.TabIndex = 5
        '
        'StatusLabelScore
        '
        Me.StatusLabelScore.BackColor = System.Drawing.SystemColors.Control
        Me.StatusLabelScore.ForeColor = System.Drawing.Color.Gold
        Me.StatusLabelScore.Name = "StatusLabelScore"
        Me.StatusLabelScore.Size = New System.Drawing.Size(48, 17)
        Me.StatusLabelScore.Text = "Score: 0"
        '
        'StatusLabelHighScore
        '
        Me.StatusLabelHighScore.ForeColor = System.Drawing.Color.Gold
        Me.StatusLabelHighScore.Name = "StatusLabelHighScore"
        Me.StatusLabelHighScore.Size = New System.Drawing.Size(74, 17)
        Me.StatusLabelHighScore.Text = "HighScore: 0"
        '
        'LoadingProgressBar
        '
        Me.LoadingProgressBar.ForeColor = System.Drawing.Color.Gold
        Me.LoadingProgressBar.Name = "LoadingProgressBar"
        Me.LoadingProgressBar.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.LoadingProgressBar.Size = New System.Drawing.Size(204, 16)
        '
        'LoadingProgress
        '
        Me.LoadingProgress.Location = New System.Drawing.Point(261, 3)
        Me.LoadingProgress.Name = "LoadingProgress"
        Me.LoadingProgress.Size = New System.Drawing.Size(177, 18)
        Me.LoadingProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.LoadingProgress.TabIndex = 3
        Me.LoadingProgress.Visible = False
        '
        'HelpPanel
        '
        Me.HelpPanel.BackColor = System.Drawing.Color.LightSlateGray
        Me.HelpPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HelpPanel.Controls.Add(Me.Label7)
        Me.HelpPanel.Controls.Add(Me.LinkAuthor)
        Me.HelpPanel.Controls.Add(Me.Label6)
        Me.HelpPanel.Controls.Add(Me.RichTextBox2)
        Me.HelpPanel.Controls.Add(Me.Label5)
        Me.HelpPanel.Controls.Add(Me.Label4)
        Me.HelpPanel.Controls.Add(Me.Label3)
        Me.HelpPanel.Controls.Add(Me.HelpPointsIcon)
        Me.HelpPanel.Controls.Add(Me.HelpBotsIcon)
        Me.HelpPanel.Controls.Add(Me.Label2)
        Me.HelpPanel.Controls.Add(Me.HelpUser2Icon)
        Me.HelpPanel.Controls.Add(Me.Label1)
        Me.HelpPanel.Controls.Add(Me.HelpUser1Icon)
        Me.HelpPanel.Controls.Add(Me.RichTextBox1)
        Me.HelpPanel.Controls.Add(Me.CloseHelpLink)
        Me.HelpPanel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.HelpPanel.Location = New System.Drawing.Point(75, 100)
        Me.HelpPanel.Name = "HelpPanel"
        Me.HelpPanel.Size = New System.Drawing.Size(300, 300)
        Me.HelpPanel.TabIndex = 0
        Me.HelpPanel.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Gold
        Me.Label7.Location = New System.Drawing.Point(181, 275)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Create by"
        '
        'LinkAuthor
        '
        Me.LinkAuthor.ActiveLinkColor = System.Drawing.SystemColors.ActiveCaption
        Me.LinkAuthor.AutoSize = True
        Me.LinkAuthor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LinkAuthor.LinkColor = System.Drawing.Color.Gold
        Me.LinkAuthor.Location = New System.Drawing.Point(230, 275)
        Me.LinkAuthor.Name = "LinkAuthor"
        Me.LinkAuthor.Size = New System.Drawing.Size(54, 13)
        Me.LinkAuthor.TabIndex = 13
        Me.LinkAuthor.TabStop = True
        Me.LinkAuthor.Text = "starkov79"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Gold
        Me.Label6.Location = New System.Drawing.Point(101, 183)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Multiplayer"
        '
        'RichTextBox2
        '
        Me.RichTextBox2.BackColor = System.Drawing.Color.LightSlateGray
        Me.RichTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RichTextBox2.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RichTextBox2.ForeColor = System.Drawing.Color.Gold
        Me.RichTextBox2.Location = New System.Drawing.Point(14, 202)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.ReadOnly = True
        Me.RichTextBox2.Size = New System.Drawing.Size(270, 62)
        Me.RichTextBox2.TabIndex = 11
        Me.RichTextBox2.Text = "   Game mode for two users. Use WASD controls for User 1 and Right, Left, Up, Dow" &
    "n keyboard controls for User 2. Try to find finish (red square) first."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Gold
        Me.Label5.Location = New System.Drawing.Point(90, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Single player"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gold
        Me.Label4.Location = New System.Drawing.Point(132, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 14)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Points"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gold
        Me.Label3.Location = New System.Drawing.Point(48, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 14)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Bots"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gold
        Me.Label2.Location = New System.Drawing.Point(132, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 14)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "User 2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gold
        Me.Label1.Location = New System.Drawing.Point(48, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 14)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "User 1"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.LightSlateGray
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RichTextBox1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.RichTextBox1.ForeColor = System.Drawing.Color.Gold
        Me.RichTextBox1.Location = New System.Drawing.Point(14, 94)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.RichTextBox1.Size = New System.Drawing.Size(270, 79)
        Me.RichTextBox1.TabIndex = 1
        Me.RichTextBox1.Text = "   Game mode for one user. Use WASD keyboard controls to move. Try to find all Po" &
    "ints and find field with finish (red square). You can play with Bots only when a" &
    "ctivate map size ""Small""."
        '
        'CloseHelpLink
        '
        Me.CloseHelpLink.ActiveLinkColor = System.Drawing.SystemColors.ActiveCaption
        Me.CloseHelpLink.AutoSize = True
        Me.CloseHelpLink.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CloseHelpLink.LinkColor = System.Drawing.Color.Gold
        Me.CloseHelpLink.Location = New System.Drawing.Point(251, 8)
        Me.CloseHelpLink.Name = "CloseHelpLink"
        Me.CloseHelpLink.Size = New System.Drawing.Size(33, 13)
        Me.CloseHelpLink.TabIndex = 0
        Me.CloseHelpLink.TabStop = True
        Me.CloseHelpLink.Text = "Close"
        '
        'HelpPointsIcon
        '
        Me.HelpPointsIcon.BackColor = System.Drawing.Color.Gold
        Me.HelpPointsIcon.Location = New System.Drawing.Point(106, 37)
        Me.HelpPointsIcon.Name = "HelpPointsIcon"
        Me.HelpPointsIcon.Size = New System.Drawing.Size(20, 20)
        Me.HelpPointsIcon.TabIndex = 7
        '
        'HelpBotsIcon
        '
        Me.HelpBotsIcon.BackColor = System.Drawing.Color.Red
        Me.HelpBotsIcon.Location = New System.Drawing.Point(22, 37)
        Me.HelpBotsIcon.Name = "HelpBotsIcon"
        Me.HelpBotsIcon.Size = New System.Drawing.Size(20, 20)
        Me.HelpBotsIcon.TabIndex = 6
        '
        'HelpUser2Icon
        '
        Me.HelpUser2Icon.BackColor = System.Drawing.Color.LawnGreen
        Me.HelpUser2Icon.Location = New System.Drawing.Point(106, 8)
        Me.HelpUser2Icon.Name = "HelpUser2Icon"
        Me.HelpUser2Icon.Size = New System.Drawing.Size(20, 20)
        Me.HelpUser2Icon.TabIndex = 4
        '
        'HelpUser1Icon
        '
        Me.HelpUser1Icon.BackColor = System.Drawing.Color.LimeGreen
        Me.HelpUser1Icon.Location = New System.Drawing.Point(22, 8)
        Me.HelpUser1Icon.Name = "HelpUser1Icon"
        Me.HelpUser1Icon.Size = New System.Drawing.Size(20, 20)
        Me.HelpUser1Icon.TabIndex = 2
        '
        'WorkPanel
        '
        Me.WorkPanel.AutoScroll = True
        Me.WorkPanel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.WorkPanel.Location = New System.Drawing.Point(0, 25)
        Me.WorkPanel.Name = "WorkPanel"
        Me.WorkPanel.Size = New System.Drawing.Size(450, 450)
        Me.WorkPanel.TabIndex = 4
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(450, 497)
        Me.Controls.Add(Me.HelpPanel)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.WorkPanel)
        Me.Controls.Add(Me.MainGameMenu)
        Me.Controls.Add(Me.LoadingProgress)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MainMenuStrip = Me.MainGameMenu
        Me.Name = "MainForm"
        Me.Text = "Maze"
        Me.MainGameMenu.ResumeLayout(False)
        Me.MainGameMenu.PerformLayout()
        Me.ContextGameMenu.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.HelpPanel.ResumeLayout(False)
        Me.HelpPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainGameMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents CreateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextGameMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents StopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewGameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GoNextEveryTime As Timer
    Friend WithEvents ModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MultiplayerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SinglePlayerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AutoRunToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents YesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RulesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BotsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WorkPanel As CustomPanel
    Friend WithEvents BotsMoving As Timer
    Friend WithEvents StatusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OffToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SpeedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SlowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NormalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FastToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LifeStyleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As ToolStripMenuItem
    Friend WithEvents CountToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EasyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MediumToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HardToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents StatusLabelScore As ToolStripStatusLabel
    Friend WithEvents StatusLabelHighScore As ToolStripStatusLabel
    Friend WithEvents LoadingProgressBar As ToolStripProgressBar
    Friend WithEvents LoadingProgress As ProgressBar
    Friend WithEvents HelpPanel As Panel
    Friend WithEvents CloseHelpLink As LinkLabel
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents HelpUser2Icon As RoundLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents HelpUser1Icon As RoundLabel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents HelpPointsIcon As RoundLabel
    Friend WithEvents HelpBotsIcon As RoundLabel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents RichTextBox2 As RichTextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents LinkAuthor As LinkLabel
End Class
