Imports System.IO

Public Class Form1
    Private Sub btnGeneratePdf_Click(sender As Object, e As EventArgs) Handles btnGeneratePdf.Click

        Dim currentDirectory = Directory.GetCurrentDirectory()
        Dim projectFolderPath = Directory.GetParent(currentDirectory).Parent.Parent.FullName
        Dim outputFolderPath = Path.Combine(projectFolderPath, "GeneratedReports\")
        Dim reportName = "\KittingStationReport"

        Dim reportGenerator = New ReportGenerator(reportName,
                                                  currentDirectory,
                                                  outputFolderPath)
        reportGenerator.GeneratePdf()
        MsgBox("Kitting Station Report Has Been Generated")
        Dim pdfPath = reportGenerator.PdfOutputPath

        Dim reportPrinter = New ReportPrinter(pdfPath)
        'reportPrinter.Print()
        MsgBox("Report Printed Succesfully!")

    End Sub
End Class
