Imports System.IO

Module SettingsLoader

    Public Hotkey As String = ""
    Public ScreenPosition As String = ""
    Public CurrentSR As String = ""
    Public Overlay As String = ""

    Public Function LoadSettings(filePath As String) As Boolean
        If Not File.Exists(filePath) Then Return False

        Dim lines = File.ReadAllLines(filePath)

        For Each line In lines
            Dim parts = line.Split(New Char() {"="c}, 2) ' nur in zwei Teile teilen: key und value
            If parts.Length <> 2 Then Continue For

            Dim key = parts(0).Trim().ToLower()
            Dim value = parts(1).Trim()

            Select Case key
                Case "hotkey"
                    Hotkey = value
                Case "screenposition"
                    ScreenPosition = value
                Case "currentsr"
                    CurrentSR = value
                Case "overlay"
                    overlay = value
            End Select
        Next

        Return True
    End Function

    Public Sub SaveSettings(filePath As String)
        Dim lines As New List(Of String)

        lines.Add("hotkey=" & Hotkey)
        lines.Add("screenposition=" & ScreenPosition)
        lines.Add("currentsr=" & CurrentSR)
        lines.Add("overlay=" & Overlay)

        File.WriteAllLines(filePath, lines)
    End Sub

    Public Function GetScreenshotRectangle() As Rectangle
        Try
            Dim parts = ScreenPosition.Split(","c)
            If parts.Length = 4 Then
                Return New Rectangle(
                    Integer.Parse(parts(0).Trim()),
                    Integer.Parse(parts(1).Trim()),
                    Integer.Parse(parts(2).Trim()),
                    Integer.Parse(parts(3).Trim())
                )
            End If
        Catch

        End Try
        Return Rectangle.Empty
    End Function

End Module
