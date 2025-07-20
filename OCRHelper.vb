Imports Tesseract
Imports System.IO

Public Class OCRHelper
    Public Shared Function ExtractNumberFromImage(imagePath As String) As String
        Dim resultText As String = ""

        Dim tessdataPath As String = Path.Combine(Application.StartupPath, "tessdata")

        Try
            Using engine As New TesseractEngine(tessdataPath, "eng", EngineMode.Default)
                Using img = Pix.LoadFromFile(imagePath)
                    Using page = engine.Process(img)
                        resultText = page.GetText()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Tesseract Error: " & ex.Message)
        End Try

        Dim digitsOnly = New String(resultText.Where(Function(c) Char.IsDigit(c)).ToArray())
        Return digitsOnly
    End Function
End Class

