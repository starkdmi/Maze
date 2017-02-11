Imports System.IO

Public Class MainForm
    'Declare Function Beep Lib "kernel32" (ByVal dwFreq As Long, ByVal dwDuration As Long) As Long

    'Declare Auto Function SendMessage Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    'Enum ProgressBarColor
    '    Green = &H1
    '    Red = &H2
    '    Yellow = &H3
    'End Enum
    'Private Shared Sub ChangeProgressBarColor(ByVal ProgressBarName As Windows.Forms.ProgressBar, ByVal ProgressBarColor As ProgressBarColor)
    '    SendMessage(ProgressBarName.Handle, &H410, ProgressBarColor, 0)
    'End Sub

    Dim Rand As Random = New Random
    Dim Field_Size As Int32 = 30
    Dim GameLevel As Integer = 1 ' 1 , 2 , 2.5
    Dim GameMode As Integer = 1 ' 1, 2

    Dim WorkPanelBounds As Rectangle

    Dim Max_X As Int32
    Dim Max_Y As Int32

    Dim FormSize As Point
    Dim WorkPanelSize As Point
    'Dim ProgressBarSize As Integer

    Dim AutoRun As Boolean = False
    Dim User As RoundLabel = New RoundLabel
    Dim User2 As RoundLabel = New RoundLabel
    Dim UserScore As Integer
    Dim Record As Integer
    Dim GameMatrix(,) As Integer
    Dim CurrentMatrixPosition As Point
    Dim CurrentMatrixPosition2 As Point
    Dim GameStatus As Boolean = False
    Dim LastMove As String
    Dim ActualFinishPoint As Point
    'Dim Sound As Boolean = True

    Dim BotMode As Boolean = True
    Dim Bots As ArrayList = New ArrayList
    Dim BotsMatrixLocations As ArrayList = New ArrayList
    Dim BotsCurrentWay As ArrayList = New ArrayList
    Dim BotLifeStyle As Integer = 2 ' 1, 2
    Dim BotsCount As Integer = 3 ' {3, 5, 7} * GameLevel

    Dim OnePoints As ArrayList = New ArrayList
    Dim ArrayOnePoints As ArrayList = New ArrayList

    Private Sub LabirintForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormSize = New Point(Me.Width, Me.Height)
        WorkPanelSize = New Point(WorkPanel.Width, WorkPanel.Height)
        'ProgressBarSize = LoadingProgress.Width
        'ChangeProgressBarColor(LoadingProgress, ProgressBarColor.Yellow)

        For Each menuitem1 As ToolStripMenuItem In MainGameMenu.Items
            menuitem1.BackColor = Color.FromArgb(119, 136, 153)
            menuitem1.ForeColor = Color.FromArgb(255, 215, 0)
            For Each menuitem2 As ToolStripMenuItem In menuitem1.DropDownItems
                menuitem2.BackColor = Color.FromArgb(119, 136, 153)
                menuitem2.ForeColor = Color.FromArgb(255, 215, 0)
                For Each menuitem3 As ToolStripMenuItem In menuitem2.DropDownItems
                    menuitem3.BackColor = Color.FromArgb(119, 136, 153)
                    menuitem3.ForeColor = Color.FromArgb(255, 215, 0)
                    For Each menuitem4 As ToolStripMenuItem In menuitem3.DropDownItems
                        menuitem4.BackColor = Color.FromArgb(119, 136, 153)
                        menuitem4.ForeColor = Color.FromArgb(255, 215, 0)
                    Next
                Next
            Next
        Next
    End Sub

    Private Sub NewGameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewGameToolStripMenuItem.Click
        If GameMode = 1 Then
            If GameLevel > 1 Then
                Me.Width = FormSize.X - Field_Size
                Me.Height = FormSize.Y - Field_Size
                WorkPanel.Width = WorkPanelSize.X
                'LoadingProgress.Width = ProgressBarSize - Field_Size
            Else
                Me.Width = FormSize.X
                Me.Height = FormSize.Y
                WorkPanel.Width = WorkPanelSize.X
                'LoadingProgress.Width = ProgressBarSize
            End If
        ElseIf GameMode = 2 Then
            Me.Width = FormSize.X
            Me.Height = FormSize.Y
            'LoadingProgress.Width = ProgressBarSize

            GameLevel = 1
            AutoRun = False

            ToolStripMenuItem2.Checked = True
            ToolStripMenuItem3.Checked = False
            HardToolStripMenuItem.Checked = False

            YesToolStripMenuItem.Checked = False
            NoToolStripMenuItem.Checked = True

            Me.Width = FormSize.X + WorkPanelSize.X - Field_Size
            WorkPanel.Width = WorkPanelSize.X * 2

            'LoadingProgress.Width = ProgressBarSize + WorkPanelSize.X - 1.6 * Field_Size
        End If

        Max_X = WorkPanel.Size.Width / Field_Size * GameLevel
        Max_Y = WorkPanel.Size.Height / Field_Size * GameLevel

        Dim Matrix(Max_X - 1, Max_Y - 1) As Integer

        WorkPanel.Visible = False

        'WorkPanel.Controls.Clear()
        Do While WorkPanel.Controls.Count > 0
            WorkPanel.Controls.RemoveAt(WorkPanel.Controls.Count - 1)
            'LoadingProgress.Value = WorkPanel.Controls.Count
            LoadingProgressBar.Value = WorkPanel.Controls.Count
        Loop

        WorkPanel.Enabled = True

        'LoadingProgress.Value = 0
        'LoadingProgress.Maximum = Max_X * Max_Y

        LoadingProgressBar.Value = 0
        LoadingProgressBar.Maximum = Max_X * Max_Y

        LastMove = 0

        ' -1 - start
        ' 0  -  nothing
        ' 1  -  way
        ' 2  -  wall

        Dim ArrayStartPoints As ArrayList = New ArrayList

        For x As Integer = 0 To Max_X - 1
            For y As Integer = 0 To Max_Y - 1
                If x Mod 2 <> 0 And y Mod 2 <> 0 And (x < Max_X - 1 And y < Max_Y - 1) Then
                    Matrix(x, y) = 0

                    ArrayStartPoints.Add(New Point(x, y))
                Else
                    Matrix(x, y) = 2
                End If
            Next
        Next

        CurrentMatrixPosition = ArrayStartPoints(Rand.Next(0, ArrayStartPoints.Count))

        ArrayStartPoints.Remove(CurrentMatrixPosition)
        CurrentMatrixPosition2 = ArrayStartPoints(Rand.Next(0, ArrayStartPoints.Count))

        Dim Queue As ArrayList = New ArrayList
        Dim CurrentPoint As Point = CurrentMatrixPosition 'StartPoint

        Dim ArrayFinishPoints As ArrayList = New ArrayList
        Dim ReservArrayFinishPoints As ArrayList = New ArrayList
        Dim IdealFinishPoint As Point = New Point(-1, -1)

        Dim ArrayBotsRespawnPoints As ArrayList = New ArrayList

        Do While GetRandomFreeField(Matrix) <> New Point(-1, -1)
            Dim NewPoint As Point = GetRandomFreeFieldAroundCurrent(Matrix, CurrentPoint)
            If NewPoint <> New Point(-1, -1) Then
                Queue.Add(CurrentPoint)

                If GameMode = 2 Then
                    If NewPoint <> CurrentMatrixPosition2 And NewPoint <> CurrentPoint Then
                        ReservArrayFinishPoints.Add(NewPoint)

                    End If
                Else
                    If NewPoint <> CurrentPoint Then
                        ReservArrayFinishPoints.Add(NewPoint)
                    End If
                End If

                Matrix(NewPoint.X, NewPoint.Y) = 1
                Matrix((CurrentPoint.X + NewPoint.X) / 2, (CurrentPoint.Y + NewPoint.Y) / 2) = 1

                If Not ArrayBotsRespawnPoints.Contains(NewPoint) Then
                    ArrayBotsRespawnPoints.Add(NewPoint)
                End If

                If Not ArrayBotsRespawnPoints.Contains(CurrentPoint) Then
                    ArrayBotsRespawnPoints.Add(CurrentPoint)
                End If

                CurrentPoint = NewPoint

            ElseIf Queue.Count > 0 Then
                If IdealFinishPoint = New Point(-1, -1) Then
                    IdealFinishPoint = CurrentPoint
                End If

                If NewPoint <> CurrentPoint Then
                    ArrayFinishPoints.Add(CurrentPoint)
                End If

                CurrentPoint = Queue(Queue.Count - 1)
                Queue.RemoveAt(Queue.Count - 1)
            Else
                NewPoint = GetRandomFreeField(Matrix)
                If NewPoint <> New Point(-1, -1) Then
                    CurrentPoint = NewPoint
                Else
                    ArrayFinishPoints.Add(New Point(CurrentPoint.X, CurrentPoint.Y))
                    Exit Do
                End If
            End If
        Loop

        ReservArrayFinishPoints.Remove(CurrentMatrixPosition)
        ArrayFinishPoints.Remove(CurrentMatrixPosition)

        If GameMode = 2 Then
            ArrayFinishPoints.Remove(CurrentMatrixPosition2)
            ReservArrayFinishPoints.Remove(CurrentMatrixPosition2)
        End If

        Dim FinishPoint As Point

        If IdealFinishPoint <> New Point(-1, -1) And IdealFinishPoint <> CurrentMatrixPosition Then
            FinishPoint = IdealFinishPoint
            Matrix(FinishPoint.X, FinishPoint.Y) = 0
        Else
            If ArrayFinishPoints.Count > 0 Then
                FinishPoint = ArrayFinishPoints(Rand.Next(0, ArrayFinishPoints.Count))
                Matrix(FinishPoint.X, FinishPoint.Y) = 0
            ElseIf ReservArrayFinishPoints.Count > 0 Then
                FinishPoint = ReservArrayFinishPoints(Rand.Next(0, ArrayFinishPoints.Count))
                Matrix(FinishPoint.X, FinishPoint.Y) = 0
            End If
        End If

        ActualFinishPoint = FinishPoint

        GameMatrix = Matrix

        DrawField(New Point(FinishPoint.X * Field_Size, FinishPoint.Y * Field_Size), Color.OrangeRed, Matrix(FinishPoint.X, FinishPoint.Y))

        User.AutoSize = False
        User.Size = New Size(Field_Size / 2, Field_Size / 2)
        User.Location = New Point(CurrentMatrixPosition.X * Field_Size + Field_Size / 4, CurrentMatrixPosition.Y * Field_Size + Field_Size / 4)
        User.BackColor = Color.LimeGreen
        'User.Text = "1"
        WorkPanel.Controls.Add(User)
        'LoadingProgress.Maximum += 1
        'LoadingProgress.Value += 1

        LoadingProgressBar.Maximum += 1
        LoadingProgressBar.Value += 1

        If GameMode = 2 Then
            User2.AutoSize = False
            User2.Size = New Size(Field_Size / 2, Field_Size / 2)
            User2.Location = New Point(CurrentMatrixPosition2.X * Field_Size + Field_Size / 4, CurrentMatrixPosition2.Y * Field_Size + Field_Size / 4)
            User2.BackColor = Color.LawnGreen
            'User2.Text = "2"
            WorkPanel.Controls.Add(User2)
            'LoadingProgress.Maximum += 1
            'LoadingProgress.Value += 1

            LoadingProgressBar.Maximum += 1
            LoadingProgressBar.Value += 1
        End If

        If BotMode And BotsCount > 0 And GameLevel = 1 Then
            Bots.Clear()
            BotsMatrixLocations.Clear()
            BotsCurrentWay.Clear()

            ArrayBotsRespawnPoints.Remove(CurrentMatrixPosition)

            If GameMode = 2 Then
                ArrayBotsRespawnPoints.Remove(CurrentMatrixPosition2)
            End If

            For bot_index As Integer = 0 To BotsCount
                Dim BotStartPoint As Point = ArrayBotsRespawnPoints(Rand.Next(0, ArrayBotsRespawnPoints.Count))
                ArrayBotsRespawnPoints.Remove(BotStartPoint)

                Dim Bot As RoundLabel = New RoundLabel
                Bot.AutoSize = False
                Bot.Size = New Size(Field_Size / 2, Field_Size / 2)
                Bot.Location = New Point(BotStartPoint.X * Field_Size + Field_Size / 4, BotStartPoint.Y * Field_Size + Field_Size / 4)
                Bot.BackColor = Color.OrangeRed
                BotsMatrixLocations.Add(BotStartPoint)

                Bots.Add(Bot)
                WorkPanel.Controls.Add(Bot)
                BotsCurrentWay.Add(GetNextBotWay(GameMatrix, BotStartPoint))

                'LoadingProgress.Maximum += 1
                'LoadingProgress.Value += 1

                LoadingProgressBar.Maximum += 1
                LoadingProgressBar.Value += 1
            Next

            BotsMoving.Start()
        End If

        If GameMode = 1 Then
            Try
                Record = File.ReadAllText("Record.txt")
                StatusLabelHighScore.Text = "HighScore: " + Record.ToString()
            Catch
                Record = 0
                StatusLabelHighScore.Text = "HighScore: " + Record.ToString()
            End Try

            UserScore = 0
            StatusLabelScore.Text = "Score: 0"

            OnePoints.Clear()
            ArrayOnePoints.Clear()
            ArrayBotsRespawnPoints.Remove(FinishPoint)

            For point_index As Integer = 0 To ArrayBotsRespawnPoints.Count - 1
                Dim OnePoint As RoundLabel = New RoundLabel

                OnePoint.AutoSize = False
                OnePoint.Size = New Size(Field_Size / 3, Field_Size / 3)
                OnePoint.Location = New Point(ArrayBotsRespawnPoints(point_index).X * Field_Size + Field_Size / 2.9, ArrayBotsRespawnPoints(point_index).Y * Field_Size + Field_Size / 2.9)
                OnePoint.BackColor = Color.FromArgb(255, 215, 0)

                WorkPanel.Controls.Add(OnePoint)
                ArrayOnePoints.Add(OnePoint)
                OnePoints.Add(New Point(ArrayBotsRespawnPoints(point_index).X, ArrayBotsRespawnPoints(point_index).Y))

                'LoadingProgress.Maximum += 1
                'LoadingProgress.Value += 1

                LoadingProgressBar.Maximum += 1
                LoadingProgressBar.Value += 1

                point_index += 2
            Next
        End If

        For x As Integer = 0 To Max_X - 1
            For y As Integer = 0 To Max_Y - 1
                Dim Field_Color As Color

                If Matrix(x, y) = 2 Then
                    Field_Color = WorkPanel.BackColor
                ElseIf Matrix(x, y) = 1 Then
                    Field_Color = Color.White
                    'ElseIf Matrix(x, y) = 0 Then
                    '    Field_Color = Color.White
                    '    DrawFinish(New Point(x * Field_Size, y * Field_Size), Color.OrangeRed, Matrix(x, y))
                ElseIf Matrix(x, y) = -1 Then
                    Field_Color = Color.LimeGreen
                End If

                DrawField(New Point(x * Field_Size, y * Field_Size), Field_Color, Matrix(x, y))

                'LoadingProgress.Value += 1
                LoadingProgressBar.Value += 1

                Application.DoEvents()
            Next
        Next
        WorkPanel.Update()
        WorkPanel.Visible = True

        GameStatus = True

        WorkPanelBounds = WorkPanel.ClientRectangle
        WorkPanel.HorizontalScroll.Maximum = WorkPanelBounds.Width * GameLevel - Field_Size
        WorkPanel.VerticalScroll.Maximum = WorkPanelBounds.Height * GameLevel - Field_Size

        MoveWorkPanelScreen()

        WorkPanel.AutoScroll = True

        LastMove = ""
        GoNextEveryTime.Start()

        If HelpPanel.Visible Then
            HelpPanel.Visible = False
            Me.Hide()
            Me.Show()
        End If

        'Drawning small map
        'Dim WorkPanel2 As Panel = New Panel
        'WorkPanel2.AutoScroll = True
        'WorkPanel2.Cursor = Cursors.Hand
        'WorkPanel2.BackColor = WorkPanel.BackColor
        'WorkPanel2.Size = New Point(200, 200)
        'WorkPanel2.Location = New Point(0, 25)
        'Me.Controls.Add(WorkPanel2)
        ''WorkPanel2.TopLevelControl = True
        'WorkPanel.Visible = False
    End Sub

    Private Sub FinishGame()
        GoNextEveryTime.Stop()
        BotsMoving.Stop()

        If GameMode = 2 Then
            If CurrentMatrixPosition = ActualFinishPoint Then
                MessageBox.Show("Win user 1")
            ElseIf CurrentMatrixPosition2 = ActualFinishPoint Then
                MessageBox.Show("Win user 2")
            Else
                MessageBox.Show("You lose")
            End If
        Else
            If CurrentMatrixPosition = ActualFinishPoint Then
                MessageBox.Show("You win")

                'If Sound Then
                '    Dim a As Integer
                '    a = 750

                '    Beep(392, a)
                '    Beep(392, a)
                '    Beep(392, a)

                '    Beep(311, a * 0.75)
                '    Beep(466, a * 0.25)

                '    Beep(392, a)
                '    Beep(311, a * 0.75)
                '    Beep(466, a * 0.25)
                '    Beep(392, a * 2)

                '    Beep(587, a)
                '    Beep(587, a)
                '    Beep(587, a)
                '    Beep(622, a * 0.75)
                '    Beep(466, a * 0.25)

                '    Beep(369, a)
                '    Beep(311, a * 0.75)
                '    Beep(466, a * 0.25)
                '    Beep(392, a * 2)
                'End If

                If UserScore > Record Then
                    Record = UserScore
                    StatusLabelHighScore.Text = "HighScore: " + Record.ToString()
                    File.WriteAllText("Record.txt", Record)
                End If
            Else
                MessageBox.Show("You lose")
            End If
        End If

        GameStatus = False
    End Sub

    Private Sub BotsMoving_Tick(sender As Object, e As EventArgs) Handles BotsMoving.Tick
        If BotLifeStyle = 1 Then
            For bot_index As Integer = (bot_index) To Bots.Count - 1
                Select Case BotsCurrentWay((bot_index))
                    Case "right"
                        If BotsMatrixLocations(bot_index).X < Max_X - 1 Then
                            If GameMatrix(BotsMatrixLocations((bot_index)).X + 1, BotsMatrixLocations((bot_index)).Y) <> 2 Then
                                BotsMatrixLocations((bot_index)) = New Point(BotsMatrixLocations((bot_index)).X + 1, BotsMatrixLocations((bot_index)).Y)
                                Bots((bot_index)).Location = New Point(BotsMatrixLocations((bot_index)).X * Field_Size + Field_Size / 4, BotsMatrixLocations((bot_index)).Y * Field_Size + Field_Size / 4)
                            Else
                                BotsCurrentWay((bot_index)) = GetNextBotWay(GameMatrix, New Point(BotsMatrixLocations((bot_index)).X, BotsMatrixLocations((bot_index)).Y))
                            End If
                        Else
                            BotsCurrentWay((bot_index)) = GetNextBotWay(GameMatrix, New Point(BotsMatrixLocations((bot_index)).X, BotsMatrixLocations((bot_index)).Y))
                        End If
                    Case "left"
                        If BotsMatrixLocations((bot_index)).X > (bot_index) Then
                            If GameMatrix(BotsMatrixLocations((bot_index)).X - 1, BotsMatrixLocations((bot_index)).Y) <> 2 Then
                                BotsMatrixLocations((bot_index)) = New Point(BotsMatrixLocations((bot_index)).X - 1, BotsMatrixLocations((bot_index)).Y)
                                Bots((bot_index)).Location = New Point(BotsMatrixLocations((bot_index)).X * Field_Size + Field_Size / 4, BotsMatrixLocations((bot_index)).Y * Field_Size + Field_Size / 4)
                            Else
                                BotsCurrentWay((bot_index)) = GetNextBotWay(GameMatrix, New Point(BotsMatrixLocations((bot_index)).X, BotsMatrixLocations((bot_index)).Y))
                            End If
                        Else
                            BotsCurrentWay((bot_index)) = GetNextBotWay(GameMatrix, New Point(BotsMatrixLocations((bot_index)).X, BotsMatrixLocations((bot_index)).Y))
                        End If
                    Case "up"
                        If BotsMatrixLocations((bot_index)).Y > (bot_index) Then
                            If GameMatrix(BotsMatrixLocations((bot_index)).X, BotsMatrixLocations((bot_index)).Y - 1) <> 2 Then
                                BotsMatrixLocations((bot_index)) = New Point(BotsMatrixLocations((bot_index)).X, BotsMatrixLocations((bot_index)).Y - 1)
                                Bots((bot_index)).Location = New Point(BotsMatrixLocations((bot_index)).X * Field_Size + Field_Size / 4, BotsMatrixLocations((bot_index)).Y * Field_Size + Field_Size / 4)
                            Else
                                BotsCurrentWay((bot_index)) = GetNextBotWay(GameMatrix, New Point(BotsMatrixLocations((bot_index)).X, BotsMatrixLocations((bot_index)).Y))
                            End If
                        Else
                            BotsCurrentWay((bot_index)) = GetNextBotWay(GameMatrix, New Point(BotsMatrixLocations((bot_index)).X, BotsMatrixLocations((bot_index)).Y))
                        End If
                    Case "down"
                        If BotsMatrixLocations((bot_index)).Y < Max_Y - 1 Then
                            If GameMatrix(BotsMatrixLocations((bot_index)).X, BotsMatrixLocations((bot_index)).Y + 1) <> 2 Then
                                BotsMatrixLocations((bot_index)) = New Point(BotsMatrixLocations((bot_index)).X, BotsMatrixLocations((bot_index)).Y + 1)
                                Bots((bot_index)).Location = New Point(BotsMatrixLocations((bot_index)).X * Field_Size + Field_Size / 4, BotsMatrixLocations((bot_index)).Y * Field_Size + Field_Size / 4)
                            Else
                                BotsCurrentWay((bot_index)) = GetNextBotWay(GameMatrix, New Point(BotsMatrixLocations((bot_index)).X, BotsMatrixLocations((bot_index)).Y))
                            End If
                        Else
                            BotsCurrentWay((bot_index)) = GetNextBotWay(GameMatrix, New Point(BotsMatrixLocations((bot_index)).X, BotsMatrixLocations((bot_index)).Y))
                        End If
                End Select

                Dim UsersAliveCount As Integer = 2

                If BotsMatrixLocations(bot_index) = CurrentMatrixPosition Then
                    WorkPanel.Controls.Remove(User)
                    UsersAliveCount -= 1
                End If

                If GameMode = 2 Then
                    If BotsMatrixLocations(bot_index) = CurrentMatrixPosition2 Then
                        WorkPanel.Controls.Remove(User2)
                        UsersAliveCount -= 1
                    End If
                Else
                    UsersAliveCount -= 1
                End If

                If UsersAliveCount <= 0 Then
                    FinishGame()
                End If
            Next
        ElseIf BotLifeStyle = 2 Then
            For bot_index As Integer = (bot_index) To Bots.Count - 1
                Dim NewPoint As Point = GetNextBotField(GameMatrix, New Point(BotsMatrixLocations((bot_index)).X, BotsMatrixLocations((bot_index)).Y))
                Bots(bot_index).Location = New Point(NewPoint.X * Field_Size + Field_Size / 4, NewPoint.Y * Field_Size + Field_Size / 4)
                BotsMatrixLocations(bot_index) = NewPoint

                Dim UsersAliveCount As Integer = 2

                If BotsMatrixLocations(bot_index) = CurrentMatrixPosition Then
                    WorkPanel.Controls.Remove(User)
                    UsersAliveCount -= 1
                End If

                If GameMode = 2 Then
                    If BotsMatrixLocations(bot_index) = CurrentMatrixPosition2 Then
                        WorkPanel.Controls.Remove(User2)
                        UsersAliveCount -= 1
                    End If
                Else
                    UsersAliveCount -= 1
                End If

                If UsersAliveCount <= 0 Then
                    FinishGame()
                End If
            Next
        End If
    End Sub

    Private Function GetNextBotField(Matrix(,) As Integer, CurrentPoint As Point) As Point
        Dim FreeFieldsAround As ArrayList = New ArrayList
        Dim NewPoint As Point = New Point(-1, -1)

        If CurrentPoint.X < Max_X - 1 Then
            If Matrix(CurrentPoint.X + 1, CurrentPoint.Y) <> 2 Then
                FreeFieldsAround.Add("right")
            End If
        End If

        If CurrentPoint.X > 0 Then
            If Matrix(CurrentPoint.X - 1, CurrentPoint.Y) <> 2 Then
                FreeFieldsAround.Add("left")
            End If
        End If

        If CurrentPoint.Y > 0 Then
            If Matrix(CurrentPoint.X, CurrentPoint.Y - 1) <> 2 Then
                FreeFieldsAround.Add("up")
            End If
        End If

        If CurrentPoint.Y < Max_Y - 1 Then
            If Matrix(CurrentPoint.X, CurrentPoint.Y + 1) <> 2 Then
                FreeFieldsAround.Add("down")
            End If
        End If

        If FreeFieldsAround.Count > 0 Then
            NewPoint = CurrentPoint

            Dim NewWay As String = FreeFieldsAround(Rand.Next(0, FreeFieldsAround.Count))
            Select Case NewWay
                Case "right"
                    NewPoint.X += 1
                Case "left"
                    NewPoint.X -= 1
                Case "up"
                    NewPoint.Y -= 1
                Case "down"
                    NewPoint.Y += 1
            End Select
        End If

        Return NewPoint
    End Function

    Private Function GetNextBotWay(Matrix(,) As Integer, CurrentPoint As Point) As String
        Dim FreeFieldsAround As ArrayList = New ArrayList

        If CurrentPoint.X < Max_X - 1 Then
            If Matrix(CurrentPoint.X + 1, CurrentPoint.Y) <> 2 Then
                FreeFieldsAround.Add("right")
            End If
        End If

        If CurrentPoint.X > 0 Then
            If Matrix(CurrentPoint.X - 1, CurrentPoint.Y) <> 2 Then
                FreeFieldsAround.Add("left")
            End If
        End If

        If CurrentPoint.Y > 0 Then
            If Matrix(CurrentPoint.X, CurrentPoint.Y - 1) <> 2 Then
                FreeFieldsAround.Add("up")
            End If
        End If

        If CurrentPoint.Y < Max_Y - 1 Then
            If Matrix(CurrentPoint.X, CurrentPoint.Y + 1) <> 2 Then
                FreeFieldsAround.Add("down")
            End If
        End If

        Return FreeFieldsAround(Rand.Next(0, FreeFieldsAround.Count))
    End Function

    Private Sub MoveWorkPanelScreen()
        If GameLevel > 1 Then
            Dim HalfScreen_X As Double = WorkPanelBounds.Width / 2 / Field_Size

            If CurrentMatrixPosition.X - HalfScreen_X < 0 Then
                WorkPanel.HorizontalScroll.Value = 0
            ElseIf CurrentMatrixPosition.X - HalfScreen_X >= 0 And CurrentMatrixPosition.X + HalfScreen_X <= Max_X - 1 Then
                WorkPanel.HorizontalScroll.Value = (CurrentMatrixPosition.X - HalfScreen_X) * Field_Size + 6
            ElseIf CurrentMatrixPosition.X + HalfScreen_X > Max_X - 1 Then
                WorkPanel.HorizontalScroll.Value = (CurrentMatrixPosition.X - HalfScreen_X - (HalfScreen_X - (Max_X - 1 - CurrentMatrixPosition.X))) * Field_Size + 13
            End If

            Dim HalfScreen_Y As Double = WorkPanelBounds.Height / 2 / Field_Size

            If CurrentMatrixPosition.Y - HalfScreen_Y < 0 Then
                WorkPanel.VerticalScroll.Value = 0
            ElseIf CurrentMatrixPosition.Y - HalfScreen_Y >= 0 And CurrentMatrixPosition.Y + HalfScreen_Y <= Max_Y - 1 Then
                WorkPanel.VerticalScroll.Value = (CurrentMatrixPosition.Y - HalfScreen_Y) * Field_Size + 6
            ElseIf CurrentMatrixPosition.Y + HalfScreen_Y > Max_Y - 1 Then
                WorkPanel.VerticalScroll.Value = (CurrentMatrixPosition.Y - HalfScreen_Y - (HalfScreen_Y - (Max_Y - 1 - CurrentMatrixPosition.Y))) * Field_Size + 13
            End If
        End If
    End Sub

    Private Function GetRandomFreeField(Matrix(,) As Integer) As Point
        For x As Integer = 0 To Max_X - 1
            For y As Integer = 0 To Max_Y - 1
                If Matrix(x, y) = 0 Then
                    Return New Point(x, y)
                End If
            Next
        Next

        Return New Point(-1, -1)
    End Function

    Private Function GetCountFreeFieldAroundCurrent(Matrix(,) As Integer, CurrentPoint As Point) As Integer
        Dim FreeFieldsAround As ArrayList = New ArrayList

        If CurrentPoint.X < Max_X - 2 Then
            If Matrix(CurrentPoint.X + 2, CurrentPoint.Y) <> 0 Then
                FreeFieldsAround.Add("right")
            End If
        End If

        If CurrentPoint.X > 1 Then
            If Matrix(CurrentPoint.X - 2, CurrentPoint.Y) <> 0 Then
                FreeFieldsAround.Add("left")
            End If
        End If

        If CurrentPoint.Y > 1 Then
            If Matrix(CurrentPoint.X, CurrentPoint.Y - 2) <> 0 Then
                FreeFieldsAround.Add("up")
            End If
        End If

        If CurrentPoint.Y < Max_Y - 2 Then
            If Matrix(CurrentPoint.X, CurrentPoint.Y + 2) <> 0 Then
                FreeFieldsAround.Add("down")
            End If
        End If

        Return FreeFieldsAround.Count
    End Function

    Private Function GetRandomFreeFieldAroundCurrent(Matrix(,) As Integer, CurrentPoint As Point) As Point
        Dim FreeFieldsAround As ArrayList = New ArrayList
        Dim NewPoint As Point = New Point(-1, -1)

        If CurrentPoint.X < Max_X - 2 Then
            If Matrix(CurrentPoint.X + 2, CurrentPoint.Y) = 0 Then
                FreeFieldsAround.Add("right")
            End If
        End If

        If CurrentPoint.X > 1 Then
            If Matrix(CurrentPoint.X - 2, CurrentPoint.Y) = 0 Then
                FreeFieldsAround.Add("left")
            End If
        End If

        If CurrentPoint.Y > 1 Then
            If Matrix(CurrentPoint.X, CurrentPoint.Y - 2) = 0 Then
                FreeFieldsAround.Add("up")
            End If
        End If

        If CurrentPoint.Y < Max_Y - 2 Then
            If Matrix(CurrentPoint.X, CurrentPoint.Y + 2) = 0 Then
                FreeFieldsAround.Add("down")
            End If
        End If

        If FreeFieldsAround.Count > 0 Then
            NewPoint = CurrentPoint

            Dim NewWay As String = FreeFieldsAround(Rand.Next(0, FreeFieldsAround.Count))
            Select Case NewWay
                Case "right"
                    NewPoint.X += 2
                Case "left"
                    NewPoint.X -= 2
                Case "up"
                    NewPoint.Y -= 2
                Case "down"
                    NewPoint.Y += 2
            End Select
        End If

        Return NewPoint
    End Function

    Private Sub DrawField(ByVal Point_XY As Point, ByVal Field_Color As Color, ByVal Field_Value As Integer)
        Dim Field As Label = New Label

        Field.AutoSize = False
        Field.Size = New Size(Field_Size, Field_Size)
        Field.Location = New Point(Point_XY)
        Field.BackColor = Field_Color

        WorkPanel.Controls.Add(Field)
    End Sub

    'Private Sub DrawFinish(ByVal Point_XY As Point, ByVal Field_Color As Color, ByVal Field_Value As Integer)
    '    Dim Field As Label = New Label

    '    Field.AutoSize = False
    '    Field.Size = New Size(Field_Size / 1.4, Field_Size / 1.4)
    '    Field.Location = New Point(Point_XY.X + Field_Size / 5.6, Point_XY.Y + Field_Size / 5.6)
    '    Field.BackColor = Field_Color

    '    WorkPanel.Controls.Add(Field)
    'End Sub

    Private Sub StopToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopToolStripMenuItem.Click
        WorkPanel.Enabled = False
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        GameLevel = 1
        ToolStripMenuItem2.Checked = True
        ToolStripMenuItem3.Checked = False
        HardToolStripMenuItem.Checked = False
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        GameLevel = 2
        ToolStripMenuItem2.Checked = False
        ToolStripMenuItem3.Checked = True
        HardToolStripMenuItem.Checked = False
    End Sub

    Private Sub HardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HardToolStripMenuItem.Click
        GameLevel = 2.5
        ToolStripMenuItem2.Checked = False
        ToolStripMenuItem3.Checked = False
        HardToolStripMenuItem.Checked = True
    End Sub

    Private Sub LabirintForm_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If GameStatus Then
            Dim CurrentUserLocation As Point = WorkPanel.PointToClient(User.Location)

            Dim CurrentUser2Location As Point
            If GameMode = 2 Then
                CurrentUser2Location = WorkPanel.PointToClient(User2.Location)
            End If

            Dim NextMatrixPositionValue As Integer = 0

            If e.KeyCode = Keys.Escape Or e.KeyCode = Keys.F1 Then
                RulesToolStripMenuItem.PerformClick()
                NextMatrixPositionValue = -1
            ElseIf e.KeyCode = Keys.W And CurrentMatrixPosition.Y > 0 Then
                NextMatrixPositionValue = GameMatrix(CurrentMatrixPosition.X, CurrentMatrixPosition.Y - 1)
                If NextMatrixPositionValue = 1 Or NextMatrixPositionValue = 0 Then
                    CurrentUserLocation.Y -= Field_Size
                    CurrentMatrixPosition.Y -= 1
                    User.Location = WorkPanel.PointToScreen(CurrentUserLocation)
                    LastMove = "up"
                    GoNextEveryTime.Stop()
                    GoNextEveryTime.Start()
                End If
            ElseIf e.KeyCode = Keys.A And CurrentMatrixPosition.X > 0 Then
                NextMatrixPositionValue = GameMatrix(CurrentMatrixPosition.X - 1, CurrentMatrixPosition.Y)
                If NextMatrixPositionValue = 1 Or NextMatrixPositionValue = 0 Then
                    CurrentUserLocation.X -= Field_Size
                    CurrentMatrixPosition.X -= 1
                    User.Location = WorkPanel.PointToScreen(CurrentUserLocation)
                    LastMove = "left"
                    GoNextEveryTime.Stop()
                    GoNextEveryTime.Start()
                End If
            ElseIf e.KeyCode = Keys.S And CurrentMatrixPosition.Y < Max_Y Then
                NextMatrixPositionValue = GameMatrix(CurrentMatrixPosition.X, CurrentMatrixPosition.Y + 1)
                If NextMatrixPositionValue = 1 Or NextMatrixPositionValue = 0 Then
                    CurrentUserLocation.Y += Field_Size
                    CurrentMatrixPosition.Y += 1
                    User.Location = WorkPanel.PointToScreen(CurrentUserLocation)
                    LastMove = "down"
                    GoNextEveryTime.Stop()
                    GoNextEveryTime.Start()
                End If
            ElseIf e.KeyCode = Keys.D And CurrentMatrixPosition.X < Max_X Then
                NextMatrixPositionValue = GameMatrix(CurrentMatrixPosition.X + 1, CurrentMatrixPosition.Y)
                If NextMatrixPositionValue = 1 Or NextMatrixPositionValue = 0 Then
                    CurrentMatrixPosition.X += 1
                    CurrentUserLocation.X += Field_Size
                    User.Location = WorkPanel.PointToScreen(CurrentUserLocation)
                    LastMove = "right"
                    GoNextEveryTime.Stop()
                    GoNextEveryTime.Start()
                End If

            ElseIf GameMode = 2 And e.KeyCode = Keys.Up And CurrentMatrixPosition2.Y > 0 Then
                NextMatrixPositionValue = GameMatrix(CurrentMatrixPosition2.X, CurrentMatrixPosition2.Y - 1)
                If NextMatrixPositionValue = 1 Or NextMatrixPositionValue = 0 Then
                    CurrentUser2Location.Y -= Field_Size
                    CurrentMatrixPosition2.Y -= 1
                    User2.Location = WorkPanel.PointToScreen(CurrentUser2Location)
                End If
            ElseIf GameMode = 2 And e.KeyCode = Keys.Left And CurrentMatrixPosition2.X > 0 Then
                NextMatrixPositionValue = GameMatrix(CurrentMatrixPosition2.X - 1, CurrentMatrixPosition2.Y)
                If NextMatrixPositionValue = 1 Or NextMatrixPositionValue = 0 Then
                    CurrentUser2Location.X -= Field_Size
                    CurrentMatrixPosition2.X -= 1
                    User2.Location = WorkPanel.PointToScreen(CurrentUser2Location)
                End If
            ElseIf GameMode = 2 And e.KeyCode = Keys.Down And CurrentMatrixPosition2.Y < Max_Y Then
                NextMatrixPositionValue = GameMatrix(CurrentMatrixPosition2.X, CurrentMatrixPosition2.Y + 1)
                If NextMatrixPositionValue = 1 Or NextMatrixPositionValue = 0 Then
                    CurrentUser2Location.Y += Field_Size
                    CurrentMatrixPosition2.Y += 1
                    User2.Location = WorkPanel.PointToScreen(CurrentUser2Location)
                End If
            ElseIf GameMode = 2 And e.KeyCode = Keys.Right And CurrentMatrixPosition2.X < Max_X Then
                NextMatrixPositionValue = GameMatrix(CurrentMatrixPosition2.X + 1, CurrentMatrixPosition2.Y)
                If NextMatrixPositionValue = 1 Or NextMatrixPositionValue = 0 Then
                    CurrentMatrixPosition2.X += 1
                    CurrentUser2Location.X += Field_Size
                    User2.Location = WorkPanel.PointToScreen(CurrentUser2Location)
                End If
            Else
                NextMatrixPositionValue = -1
            End If

            MoveWorkPanelScreen()

            If BotMode And GameLevel = 1 Then
                For bot_index As Integer = (bot_index) To Bots.Count - 1
                    Dim UsersAliveCount As Integer = 2

                    If BotsMatrixLocations(bot_index) = CurrentMatrixPosition Then
                        WorkPanel.Controls.Remove(User)
                        UsersAliveCount -= 1
                    End If

                    If GameMode = 2 Then
                        If BotsMatrixLocations(bot_index) = CurrentMatrixPosition2 Then
                            WorkPanel.Controls.Remove(User2)
                            UsersAliveCount -= 1
                        End If
                    Else
                        UsersAliveCount -= 1
                    End If

                    If UsersAliveCount <= 0 Then
                        FinishGame()
                    End If
                Next
            End If

            If OnePoints.Contains(CurrentMatrixPosition) Then
                Dim Index As Integer = OnePoints.IndexOf(CurrentMatrixPosition)
                WorkPanel.Controls.Remove(ArrayOnePoints(Index))
                ArrayOnePoints.RemoveAt(Index)
                OnePoints.RemoveAt(Index)
                UserScore += 100
                StatusLabelScore.Text = "Score: " + UserScore.ToString()
            End If

            If CurrentMatrixPosition = ActualFinishPoint Then
                FinishGame()
            End If

            If GameMode = 2 Then
                If CurrentMatrixPosition2 = ActualFinishPoint Then
                    FinishGame()
                End If
            End If
        End If

    End Sub

    Private Sub GoNextEveryTime_Tick(sender As Object, e As EventArgs) Handles GoNextEveryTime.Tick
        If GameStatus And AutoRun And GameMode <> 2 And LastMove <> "" Then
            Dim CurrentUserLocation As Point = WorkPanel.PointToClient(User.Location)
            Dim NextMatrixPositionValue As Integer = 0

            Select Case LastMove
                Case "up"
                    If CurrentMatrixPosition.Y > 0 Then
                        NextMatrixPositionValue = GameMatrix(CurrentMatrixPosition.X, CurrentMatrixPosition.Y - 1)
                        If NextMatrixPositionValue = 1 Or NextMatrixPositionValue = 0 Then
                            CurrentUserLocation.Y -= Field_Size
                            CurrentMatrixPosition.Y -= 1
                            User.Location = WorkPanel.PointToScreen(CurrentUserLocation)
                            LastMove = "up"
                        End If
                    End If
                Case "left"
                    If CurrentMatrixPosition.X > 0 Then
                        NextMatrixPositionValue = GameMatrix(CurrentMatrixPosition.X - 1, CurrentMatrixPosition.Y)
                        If NextMatrixPositionValue = 1 Or NextMatrixPositionValue = 0 Then
                            CurrentUserLocation.X -= Field_Size
                            CurrentMatrixPosition.X -= 1
                            User.Location = WorkPanel.PointToScreen(CurrentUserLocation)
                            LastMove = "left"
                        End If
                    End If
                Case "down"
                    If CurrentMatrixPosition.Y < Max_Y Then
                        NextMatrixPositionValue = GameMatrix(CurrentMatrixPosition.X, CurrentMatrixPosition.Y + 1)
                        If NextMatrixPositionValue = 1 Or NextMatrixPositionValue = 0 Then
                            CurrentUserLocation.Y += Field_Size
                            CurrentMatrixPosition.Y += 1
                            User.Location = WorkPanel.PointToScreen(CurrentUserLocation)
                            LastMove = "down"
                        End If
                    End If
                Case "right"
                    If CurrentMatrixPosition.X < Max_X Then
                        NextMatrixPositionValue = GameMatrix(CurrentMatrixPosition.X + 1, CurrentMatrixPosition.Y)
                        If NextMatrixPositionValue = 1 Or NextMatrixPositionValue = 0 Then
                            CurrentMatrixPosition.X += 1
                            CurrentUserLocation.X += Field_Size
                            User.Location = WorkPanel.PointToScreen(CurrentUserLocation)
                            LastMove = "right"
                        End If
                    End If
                Case Else
                    NextMatrixPositionValue = -1
            End Select

            MoveWorkPanelScreen()

            If BotMode And GameLevel = 1 Then
                For bot_index As Integer = (bot_index) To Bots.Count - 1
                    Dim UsersAliveCount As Integer = 2

                    If BotsMatrixLocations(bot_index) = CurrentMatrixPosition Then
                        WorkPanel.Controls.Remove(User)
                        UsersAliveCount -= 1
                    End If

                    If GameMode = 2 Then
                        If BotsMatrixLocations(bot_index) = CurrentMatrixPosition2 Then
                            WorkPanel.Controls.Remove(User2)
                            UsersAliveCount -= 1
                        End If
                    Else
                        UsersAliveCount -= 1
                    End If

                    If UsersAliveCount <= 0 Then
                        FinishGame()
                    End If
                Next
            End If

            If OnePoints.Contains(CurrentMatrixPosition) Then
                Dim Index As Integer = OnePoints.IndexOf(CurrentMatrixPosition)
                WorkPanel.Controls.Remove(ArrayOnePoints(Index))
                ArrayOnePoints.RemoveAt(Index)
                OnePoints.RemoveAt(Index)
                UserScore += 100
                StatusLabelScore.Text = "Score: " + UserScore.ToString()
            End If

            If CurrentMatrixPosition = ActualFinishPoint Then
                FinishGame()
            End If
        End If
    End Sub

    Private Sub SinglePlayerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SinglePlayerToolStripMenuItem.Click
        GameMode = 1
        SinglePlayerToolStripMenuItem.Checked = True
        MultiplayerToolStripMenuItem.Checked = False
    End Sub

    Private Sub MultiplayerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MultiplayerToolStripMenuItem.Click
        GameMode = 2
        SinglePlayerToolStripMenuItem.Checked = False
        MultiplayerToolStripMenuItem.Checked = True
    End Sub

    Private Sub YesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YesToolStripMenuItem.Click
        AutoRun = True
        YesToolStripMenuItem.Checked = True
        NoToolStripMenuItem.Checked = False
    End Sub

    Private Sub NoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NoToolStripMenuItem.Click
        AutoRun = False
        YesToolStripMenuItem.Checked = False
        NoToolStripMenuItem.Checked = True
    End Sub

    Private Sub OnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OnToolStripMenuItem.Click
        BotMode = True
        OnToolStripMenuItem.Checked = True
        OffToolStripMenuItem.Checked = False
    End Sub

    Private Sub OffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OffToolStripMenuItem.Click
        BotMode = False
        OnToolStripMenuItem.Checked = False
        OffToolStripMenuItem.Checked = True
    End Sub

    Private Sub SlowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SlowToolStripMenuItem.Click
        BotsMoving.Interval = 1000
        SlowToolStripMenuItem.Checked = True
        NormalToolStripMenuItem.Checked = False
        FastToolStripMenuItem.Checked = False
    End Sub

    Private Sub NormalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NormalToolStripMenuItem.Click
        BotsMoving.Interval = 750
        SlowToolStripMenuItem.Checked = False
        NormalToolStripMenuItem.Checked = True
        FastToolStripMenuItem.Checked = False
    End Sub

    Private Sub FastToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FastToolStripMenuItem.Click
        BotsMoving.Interval = 500
        SlowToolStripMenuItem.Checked = False
        NormalToolStripMenuItem.Checked = False
        FastToolStripMenuItem.Checked = True
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        BotLifeStyle = 1
        ToolStripMenuItem4.Checked = True
        ToolStripMenuItem5.Checked = False
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        BotLifeStyle = 2
        ToolStripMenuItem4.Checked = False
        ToolStripMenuItem5.Checked = True
    End Sub

    Private Sub EasyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EasyToolStripMenuItem.Click
        BotsCount = 3 * GameLevel
        EasyToolStripMenuItem.Checked = False
        MediumToolStripMenuItem.Checked = False
        HardToolStripMenuItem1.Checked = True
    End Sub

    Private Sub MediumToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MediumToolStripMenuItem.Click
        BotsCount = 5 * GameLevel
        EasyToolStripMenuItem.Checked = False
        MediumToolStripMenuItem.Checked = False
        HardToolStripMenuItem1.Checked = True
    End Sub

    Private Sub HardToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles HardToolStripMenuItem1.Click
        BotsCount = 7 * GameLevel
        EasyToolStripMenuItem.Checked = False
        MediumToolStripMenuItem.Checked = False
        HardToolStripMenuItem1.Checked = True
    End Sub

    Private Sub RulesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RulesToolStripMenuItem.Click
        If GameMode = 1 Then
            If GameLevel > 1 Then
                HelpPanel.Location = New Point(55, HelpPanel.Location.Y)
            Else
                HelpPanel.Location = New Point(75, HelpPanel.Location.Y)
            End If
        ElseIf GameMode = 2 Then
            HelpPanel.Location = New Point(150 + WorkPanelSize.X / 4, HelpPanel.Location.Y)
        End If

        BotsMoving.Stop()

        HelpPanel.Visible = True
    End Sub

    Private Sub CloseHelpLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles CloseHelpLink.LinkClicked
        HelpPanel.Visible = False
        Me.Hide()
        Me.Show()

        If BotMode And BotsCount > 0 And GameLevel = 1 Then
            BotsMoving.Start()
        End If
    End Sub

    Private Sub LinkAuthor_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkAuthor.LinkClicked
        MessageBox.Show("Starkov Dima")
    End Sub
End Class