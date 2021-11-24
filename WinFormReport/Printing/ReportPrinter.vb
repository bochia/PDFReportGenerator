Imports System.Drawing.Printing
Imports System.IO

Public Class ReportPrinter
    Implements IReportPrinter

    Private _pdfPath As String
    Private Const _printerName As String = "blah"
    Private WithEvents _printDocument As PrintDocument = Nothing

    Public Sub New(pdfPath As String)
        _pdfPath = pdfPath
    End Sub


    ''' <summary>
    ''' Prints to the default printer using Acrobat Reader
    ''' </summary>
    Public Sub Print() Implements IReportPrinter.Print
        Dim info As ProcessStartInfo = New ProcessStartInfo()
        info.Verb = "print"
        info.FileName = _pdfPath
        info.CreateNoWindow = True
        info.WindowStyle = ProcessWindowStyle.Hidden
        Dim p As Process = New Process()
        p.StartInfo = info
        p.Start()
        p.WaitForInputIdle()
        System.Threading.Thread.Sleep(3000)
        If False = p.CloseMainWindow() Then p.Kill()
    End Sub

End Class
