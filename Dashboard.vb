Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Net
Imports System.Diagnostics
Imports System.Text.Json
Imports System.Runtime.InteropServices
Imports System.Security.Policy
Imports System.Text.RegularExpressions
Imports Tesseract
Public Class WZtracker
    Private isMouseDown As Boolean = False
    Private MouseOffset As Point

    'SR compare
    Dim oldSR As String
    Dim newSR As String

    'Updater
    Private Const githubApiUrl As String = "https://api.github.com/repos/IamGatsu/SRtracker/releases/latest"
    Private Const downloadFileName As String = "new_version.exe"
    Private Const updaterExeName As String = "updater.exe"

    Dim hotkey As String
    Dim screenposition As String
    Dim currentsr As String
    Dim overlay As String

    ' Hotkey-Konstanten
    Private Const MOD_NONE As Integer = 0
    Private Const WM_HOTKEY As Integer = &H312
    Private Const HOTKEY_ID As Integer = 100

    ' Declare Screenshot Area
    Private screenshotRect As Rectangle = Rectangle.Empty
    Private selectingArea As Boolean = False
    Private selectionForm As Form
    Private startPoint As Point

    Dim settingspath As String = Application.StartupPath & "/settings/settings.ini"

    ' Register Hotkey Windows API
    <DllImport("user32.dll")>
    Public Shared Function RegisterHotKey(hWnd As IntPtr, id As Integer, fsModifiers As Integer, vk As Integer) As Boolean
    End Function

    <DllImport("user32.dll")>
    Public Shared Function UnregisterHotKey(hWnd As IntPtr, id As Integer) As Boolean
    End Function

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = WM_HOTKEY AndAlso m.WParam.ToInt32() = HOTKEY_ID Then
            If btnScreenshot.Enabled = True Then CaptureAndExtractNumber()
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub WZtracker_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' Get the new position
            MouseOffset = New Point(-e.X, -e.Y)
            ' Set that left button is pressed
            isMouseDown = True
        End If
    End Sub

    Private Sub WZtracker_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If isMouseDown Then
            Dim mousePos As Point = Control.MousePosition
            ' Get the new form position
            mousePos.Offset(MouseOffset.X, MouseOffset.Y)
            Me.Location = mousePos
        End If
    End Sub

    Private Sub WZtracker_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            isMouseDown = False
        End If
    End Sub

    Private Sub clsBtn_MouseHover(sender As Object, e As EventArgs) Handles clsBtn.MouseHover
        clsBtn.BackgroundImage = My.Resources.clsbtn_hover
    End Sub

    Private Sub clsBtn_MouseLeave(sender As Object, e As EventArgs) Handles clsBtn.MouseLeave
        clsBtn.BackgroundImage = My.Resources.clsbtn
    End Sub

    Private Sub clsBtn_Click(sender As Object, e As EventArgs) Handles clsBtn.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub mmzBtn_MouseHover(sender As Object, e As EventArgs) Handles mmzBtn.MouseHover
        mmzBtn.BackgroundImage = My.Resources.mmzbtn_hover
    End Sub

    Private Sub mmzBtn_MouseLeave(sender As Object, e As EventArgs) Handles mmzBtn.MouseLeave
        mmzBtn.BackgroundImage = My.Resources.mmzbtn
    End Sub

    Private Sub mmzBtn_Click(sender As Object, e As EventArgs) Handles mmzBtn.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub WZtracker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load Settings
        Dim loaded = LoadSettings(settingspath)
        If Not loaded Then
            MessageBox.Show("Settings file could not be located, exiting!")
            Application.Exit()
            Return
        End If
        'Load Settings Values
        cmboxHotkey.Items.AddRange(New String() {"F10", "F11", "F12"})
        cmboxOverlay.Items.AddRange(New String() {"Classic", "Modern"})
        hotkey = SettingsLoader.Hotkey
        screenposition = SettingsLoader.ScreenPosition
        currentsr = SettingsLoader.CurrentSR
        overlay = SettingsLoader.Overlay

        If cmboxHotkey.Items.Contains(SettingsLoader.Hotkey) Then
            cmboxHotkey.SelectedItem = hotkey
        Else
            cmboxHotkey.SelectedIndex = 0
        End If

        If Not screenposition = Nothing Then
            btnScreenshot.Enabled = True
        Else
            btnScreenshot.Enabled = False
        End If

        lblCurrentSR.Text = "Current SR: " & currentsr

        If cmboxOverlay.Items.Contains(SettingsLoader.Overlay) Then
            cmboxOverlay.SelectedItem = overlay
        Else
            cmboxOverlay.SelectedIndex = 0
        End If

        'Load Screenposition
        LoadScreenshotRect()

        If My.Settings.hotkeymod = False Then
            chkboxHotkey.Checked = False
        Else
            chkboxHotkey.Checked = True
        End If
        'Check Hotkey
        If chkboxHotkey.Checked = True Then
            If cmboxHotkey.SelectedItem.ToString.Contains("F10") Then RegisterHotKey(Me.Handle, HOTKEY_ID, 2, Keys.F10)
            If cmboxHotkey.SelectedItem.ToString.Contains("F11") Then RegisterHotKey(Me.Handle, HOTKEY_ID, 2, Keys.F11)
            If cmboxHotkey.SelectedItem.ToString.Contains("F12") Then RegisterHotKey(Me.Handle, HOTKEY_ID, 2, Keys.F12)
        End If
        If chkboxHotkey.Checked = False Then
            If cmboxHotkey.SelectedItem.ToString.Contains("F10") Then RegisterHotKey(Me.Handle, HOTKEY_ID, 0, Keys.F10)
            If cmboxHotkey.SelectedItem.ToString.Contains("F11") Then RegisterHotKey(Me.Handle, HOTKEY_ID, 0, Keys.F11)
            If cmboxHotkey.SelectedItem.ToString.Contains("F12") Then RegisterHotKey(Me.Handle, HOTKEY_ID, 0, Keys.F12)
        End If

    End Sub

    Private Sub WZtracker_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'Unregister Hotkey
        UnregisterHotKey(Me.Handle, HOTKEY_ID)
    End Sub

    Private Sub chkboxHotkey_Click(sender As Object, e As EventArgs) Handles chkboxHotkey.Click
        If chkboxHotkey.Checked = True Then
            My.Settings.hotkeymod = True
        Else
            My.Settings.hotkeymod = False
        End If
        My.Settings.Save()
    End Sub

    Private Sub cmboxOverlay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmboxOverlay.SelectedIndexChanged
        SettingsLoader.Overlay = cmboxOverlay.SelectedItem?.ToString
        SettingsLoader.SaveSettings(settingspath)
    End Sub

    Private Sub btnChangeHotkey_Click(sender As Object, e As EventArgs) Handles btnChangeHotkey.Click
        SettingsLoader.Hotkey = cmboxHotkey.SelectedItem?.ToString
        SettingsLoader.SaveSettings(settingspath)
        'Check Hotkey
        If chkboxHotkey.Checked = True Then
            If cmboxHotkey.SelectedItem.ToString.Contains("F10") Then RegisterHotKey(Me.Handle, HOTKEY_ID, 2, Keys.F10)
            If cmboxHotkey.SelectedItem.ToString.Contains("F11") Then RegisterHotKey(Me.Handle, HOTKEY_ID, 2, Keys.F11)
            If cmboxHotkey.SelectedItem.ToString.Contains("F12") Then RegisterHotKey(Me.Handle, HOTKEY_ID, 2, Keys.F12)
        End If
        If chkboxHotkey.Checked = False Then
            If cmboxHotkey.SelectedItem.ToString.Contains("F10") Then RegisterHotKey(Me.Handle, HOTKEY_ID, 0, Keys.F10)
            If cmboxHotkey.SelectedItem.ToString.Contains("F11") Then RegisterHotKey(Me.Handle, HOTKEY_ID, 0, Keys.F11)
            If cmboxHotkey.SelectedItem.ToString.Contains("F12") Then RegisterHotKey(Me.Handle, HOTKEY_ID, 0, Keys.F12)
        End If
        MessageBox.Show("Hotkey saved!")
    End Sub

    Private Sub btnGrabScreen_Click(sender As Object, e As EventArgs) Handles btnGrabScreen.Click
        screenshotRect = Rectangle.Empty
        startPoint = Point.Empty
        selectingArea = False

        ' Prepare Selection
        selectionForm = New Form With {
        .FormBorderStyle = FormBorderStyle.None,
        .Bounds = Screen.PrimaryScreen.Bounds,
        .TopMost = True,
        .BackColor = Color.Black,
        .Opacity = 0.25,
        .Cursor = Cursors.Cross
    }

        ' Register Event Handlers
        AddHandler selectionForm.MouseDown, AddressOf SelectionForm_MouseDown
        AddHandler selectionForm.MouseMove, AddressOf SelectionForm_MouseMove
        AddHandler selectionForm.MouseUp, AddressOf SelectionForm_MouseUp
        AddHandler selectionForm.Paint, AddressOf SelectionForm_Paint

        selectionForm.Show()
    End Sub

    Private Sub SaveScreenshotRect()
        Try
            Dim rectText As String = $"{screenshotRect.X},{screenshotRect.Y},{screenshotRect.Width},{screenshotRect.Height}"
            SettingsLoader.ScreenPosition = rectText
            SettingsLoader.SaveSettings(settingspath)
        Catch ex As Exception
            MessageBox.Show("Error while saving your Settings: " & ex.Message)
        End Try
    End Sub
    Private Sub LoadScreenshotRect()
        Try
            Dim parts = SettingsLoader.ScreenPosition.Split(","c)
            If parts.Length = 4 Then
                screenshotRect = New Rectangle(
                Integer.Parse(parts(0).Trim()),
                Integer.Parse(parts(1).Trim()),
                Integer.Parse(parts(2).Trim()),
                Integer.Parse(parts(3).Trim())
            )
            Else
                MessageBox.Show("Screenposition is wrong.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading Screen Position: " & ex.Message)
        End Try
    End Sub

    Private Sub SelectionForm_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            startPoint = e.Location
            screenshotRect = New Rectangle(startPoint, New Size(0, 0))
            selectingArea = True
        End If
    End Sub

    Private Sub SelectionForm_MouseMove(sender As Object, e As MouseEventArgs)
        If selectingArea Then
            Dim currentPoint As Point = e.Location

            ' Rechteck vom Startpunkt zur aktuellen Mausposition berechnen
            Dim x = Math.Min(startPoint.X, currentPoint.X)
            Dim y = Math.Min(startPoint.Y, currentPoint.Y)
            Dim width = Math.Abs(startPoint.X - currentPoint.X)
            Dim height = Math.Abs(startPoint.Y - currentPoint.Y)

            screenshotRect = New Rectangle(x, y, width, height)
            selectionForm.Invalidate()
        End If
    End Sub

    Private Sub SelectionForm_MouseUp(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left AndAlso selectingArea Then
            selectingArea = False
            selectionForm.Close()
            selectionForm.Dispose()
            selectionForm = Nothing

            ' Nur speichern, wenn Breite/Höhe > 0
            If screenshotRect.Width > 0 AndAlso screenshotRect.Height > 0 Then
                SaveScreenshotRect()
                MessageBox.Show($"Selected Region: {screenshotRect.Width}x{screenshotRect.Height} bei {screenshotRect.Location}")
                btnScreenshot.Enabled = True
            Else
                MessageBox.Show("Wrong Region selection – please try again.")
            End If
        End If
    End Sub

    Private Sub SelectionForm_Paint(sender As Object, e As PaintEventArgs)
        If selectingArea AndAlso Not screenshotRect.IsEmpty Then
            Using pen As New Pen(Color.Red, 2)
                e.Graphics.DrawRectangle(pen, screenshotRect)
            End Using
        End If
    End Sub

    Private Sub btnScreenshot_Click(sender As Object, e As EventArgs) Handles btnScreenshot.Click
        CaptureAndExtractNumber()
    End Sub

    Public Sub CaptureAndExtractNumber()
        Try
            Dim rect As Rectangle = SettingsLoader.GetScreenshotRectangle
            If rect.IsEmpty Then
                MessageBox.Show("Wrong Screen coordinates!")
                Return
            End If
            'Create Screenshot
            Dim bmp As New Bitmap(rect.Width, rect.Height)
            Using g As Graphics = Graphics.FromImage(bmp)
                g.CopyFromScreen(rect.X, rect.Y, 0, 0, rect.Size)
            End Using
            Dim rawBmp As New Bitmap(rect.Width, rect.Height)
            Using g As Graphics = Graphics.FromImage(rawBmp)
                g.CopyFromScreen(rect.X, rect.Y, 0, 0, rect.Size)
            End Using
            ' Preperation
            Dim processedBmp As Bitmap = PreprocessImage(rawBmp)
            'Tesseract OCR
            Dim ocrText As String = ""
            Using engine As New TesseractEngine("tessdata", "eng", EngineMode.Default)
                engine.SetVariable("tessedit_char_whitelist", "0123456789")
                Using img = PixConverter.ToPix(processedBmp)
                    Using page = engine.Process(img)
                        ocrText = page.GetText()
                    End Using
                End Using
            End Using

            ' Extract only Numbers
            Dim numbers = Regex.Matches(ocrText, "\d+")
            Dim result As New Text.StringBuilder()

            For Each m As Match In numbers
                result.AppendLine(m.Value)
            Next
            'Compare SR

            'Output SR Number
            lblCurrentSR.Text = "Current SR: " & result.ToString
            'Save SR to Settings
            SettingsLoader.CurrentSR = result.ToString
            SettingsLoader.SaveSettings(settingspath)
            UpdateJsonFileSR(result.ToString)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub UpdateJsonFileSR(currentNumber As Integer)
        Dim jsonPath As String = IO.Path.Combine(Application.StartupPath, "obs_widget/data.json")
        Dim jsonContent As String = JsonSerializer.Serialize(New With {.currentNumber = currentNumber})

        Try
            IO.File.WriteAllText(jsonPath, jsonContent)
        Catch ex As Exception
            MessageBox.Show("Error while writing Json File: " & ex.Message)
        End Try
    End Sub

    Private Sub UpdateJsonFileDaily(currentNumber As Integer)
        Dim jsonPath As String = IO.Path.Combine(Application.StartupPath, "obs_widget/daily.json")
        Dim jsonContent As String = JsonSerializer.Serialize(New With {.currentNumber = currentNumber})

        Try
            IO.File.WriteAllText(jsonPath, jsonContent)
        Catch ex As Exception
            MessageBox.Show("Error while writing Json File: " & ex.Message)
        End Try
    End Sub

    Private Function PreprocessImage(input As Bitmap) As Bitmap
        Dim grayBmp As New Bitmap(input.Width, input.Height)

        For y = 0 To input.Height - 1
            For x = 0 To input.Width - 1
                Dim pixelColor = input.GetPixel(x, y)
                Dim gray = CInt(0.3 * pixelColor.R + 0.59 * pixelColor.G + 0.11 * pixelColor.B)
                Dim binaryColor As Color = If(gray > 140, Color.White, Color.Black)
                grayBmp.SetPixel(x, y, binaryColor)
            Next
        Next

        Return grayBmp
    End Function

    Private Sub btnResetSR_Click(sender As Object, e As EventArgs) Handles btnResetSR.Click
        SettingsLoader.CurrentSR = "0"
        SettingsLoader.SaveSettings(settingspath)
        lblCurrentSR.Text = "Current SR: " & "0"
    End Sub

    Public Sub CheckForUpdate()
        Try
            Dim client As New WebClient()
            client.Headers.Add("User-Agent", "VB.NET Updater")


            Dim json As String = client.DownloadString(githubApiUrl)


            Dim latestVersion As String = Regex.Match(json, """tag_name"":\s*""v?([\d\.]+)""").Groups(1).Value


            Dim assetMatch = Regex.Match(json, """browser_download_url"":\s*""(https:[^""]+wztracker\.exe)""")
            If Not assetMatch.Success Then
                MessageBox.Show("Couldnt find download Link for new Version.")
                Exit Sub
            End If

            Dim downloadUrl As String = assetMatch.Groups(1).Value
            Dim currentVersion As String = Application.ProductVersion

            If Version.Parse(latestVersion) > Version.Parse(currentVersion) Then
                If MessageBox.Show($"New Version {latestVersion} available. update now?",
                                   "Update available", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    DownloadAndUpdate(downloadUrl)
                End If
            Else
                MessageBox.Show("Your Version is already up to Date.", "No Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error while checking for Updates: " & ex.Message, "UpdateError", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DownloadAndUpdate(downloadUrl As String)
        Try
            Dim client As New WebClient()
            client.DownloadFile(downloadUrl, downloadFileName)


            File.WriteAllBytes(updaterExeName, My.Resources.updater)


            Dim currentExePath As String = Application.ExecutablePath


            Process.Start(updaterExeName, $"""{currentExePath}"" ""{downloadFileName}""")
            Application.Exit()

        Catch ex As Exception
            MessageBox.Show("Error while updating: " & ex.Message)
        End Try
    End Sub

    Private Sub btnCheckUpdates_Click(sender As Object, e As EventArgs) Handles btnCheckUpdates.Click
        Dim u As New WZtracker()
        u.CheckForUpdate()
    End Sub
End Class

