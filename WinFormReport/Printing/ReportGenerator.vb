Imports System.IO
Imports Microsoft.Reporting.WebForms

Public Class ReportGenerator
    Implements IReportGenerator

    Public Property PdfOutputPath As String
    Private _reportname As String
    Private _reportDefinitionPath As String
    Private Const _renderFormat As String = "PDF"


    Public Sub New(reportName As String, reportDefinitionPath As String, outputPath As String)
        _reportname = reportName
        _reportDefinitionPath = reportDefinitionPath
        PdfOutputPath = $"{outputPath}{reportName}.pdf"
    End Sub

    Public Sub GeneratePdf() Implements IReportGenerator.GeneratePdf

        'None Tube Row Fields
        Dim kittingStationMiscellaneousReportFields = New KittingStationReportMiscellaneousFields()
        PopulateFieldsWithFakeData(kittingStationMiscellaneousReportFields)
        Dim miscellaneousFieldsListWithSingleItem = New List(Of KittingStationReportMiscellaneousFields) From {kittingStationMiscellaneousReportFields}
        Dim nonTubeRowFields = New ReportDataSource("NonTubeRowFields", miscellaneousFieldsListWithSingleItem)

        'Tube Row Fields
        Dim tubes = GetFakeTubeList()
        Dim lengthRow = New KittingStationReportTubeInfoRow()
        Dim outerDiameter1Row = New KittingStationReportTubeInfoRow()
        Dim outerDiameter2Row = New KittingStationReportTubeInfoRow()
        Dim quantityCutRow = New KittingStationReportTubeInfoRow()

        PopulateTubeInfoRows(
            tubes,
            lengthRow,
            outerDiameter1Row,
            outerDiameter2Row,
            quantityCutRow)

        Dim lengthRowDataSource = CreateReportDataSource("TubeLengthRow", lengthRow)
        Dim outerDiameter1DataSource = CreateReportDataSource("TubeOuterDiameter1Row", outerDiameter1Row)
        Dim outerDiameter2DataSource = CreateReportDataSource("TubeOuterDiameter2Row", outerDiameter2Row)
        Dim tubeQuantityCutDataSource = CreateReportDataSource("TubeQuantityCutRow", quantityCutRow)


        Dim reportViewer = New ReportViewer()
        reportViewer.LocalReport.ReportPath = $"{_reportDefinitionPath}\Printing\{_reportname}.rdlc"
        reportViewer.LocalReport.DataSources.Add(nonTubeRowFields)
        reportViewer.LocalReport.DataSources.Add(lengthRowDataSource)
        reportViewer.LocalReport.DataSources.Add(outerDiameter1DataSource)
        reportViewer.LocalReport.DataSources.Add(outerDiameter2DataSource)
        reportViewer.LocalReport.DataSources.Add(tubeQuantityCutDataSource)


        Dim bytes = reportViewer.LocalReport.Render(format:=_renderFormat)

        Using fileStream As New FileStream(PdfOutputPath, FileMode.Create)
            fileStream.Write(bytes, 0, bytes.Length)
        End Using

    End Sub

    Private Sub PopulateFieldsWithFakeData(kittingStationReportFields As KittingStationReportMiscellaneousFields)
        kittingStationReportFields.User = "Bochia"
        kittingStationReportFields.MaterialNumber = "exampleMaterialNumber"
        kittingStationReportFields.ProductModelAndSize = "Synerygy II WH"
        kittingStationReportFields.BatchNumber = "GME"
        kittingStationReportFields.TubingMaterialNumber = "W"
        kittingStationReportFields.TubingBatchNumber = "S"
        kittingStationReportFields.KanbanNumber = "B"
        kittingStationReportFields.QuantityInCassette = "10"
    End Sub

    Public Function CreateReportDataSource(dataSetName As String, customDataSourceObject As ICustomDataSourceObject) As ReportDataSource
        Dim listBecauseDataSourceNeedsToBeOfTypeIEnumerable = New List(Of ICustomDataSourceObject) From {customDataSourceObject}
        Dim reportDataSource = New ReportDataSource(dataSetName, listBecauseDataSourceNeedsToBeOfTypeIEnumerable)

        Return reportDataSource
    End Function

    Private Function GetFakeTubeList() As List(Of Tube)
        Dim listOfTubes = New List(Of Tube)
        For index = 1 To 8
            Dim tube = New Tube()
            tube.Number = index.ToString()
            tube.Length = index.ToString()
            tube.OuterDiameter1 = index.ToString()
            tube.OuterDiameter2 = index.ToString()
            tube.QuantityCut = index.ToString()

            listOfTubes.Add(tube)
        Next

        Return listOfTubes
    End Function

    Public Sub PopulateTubeInfoRows(tubes As List(Of Tube),
            lengthRow As KittingStationReportTubeInfoRow,
            outerDiameter1Row As KittingStationReportTubeInfoRow,
            outerDiameter2Row As KittingStationReportTubeInfoRow,
            quantityCutRow As KittingStationReportTubeInfoRow)

        For Each tube As Tube In tubes
            Select Case tube.Number
                Case 1
                    lengthRow.Tube1Value = tube.Length
                    outerDiameter1Row.Tube1Value = tube.OuterDiameter1
                    outerDiameter2Row.Tube1Value = tube.OuterDiameter2
                    quantityCutRow.Tube1Value = tube.QuantityCut
                Case 2
                    lengthRow.Tube2Value = tube.Length
                    outerDiameter1Row.Tube2Value = tube.OuterDiameter1
                    outerDiameter2Row.Tube2Value = tube.OuterDiameter2
                    quantityCutRow.Tube2Value = tube.QuantityCut
                Case 3
                    lengthRow.Tube3Value = tube.Length
                    outerDiameter1Row.Tube3Value = tube.OuterDiameter1
                    outerDiameter2Row.Tube3Value = tube.OuterDiameter2
                    quantityCutRow.Tube3Value = tube.QuantityCut
                Case 4
                    lengthRow.Tube4Value = tube.Length
                    outerDiameter1Row.Tube4Value = tube.OuterDiameter1
                    outerDiameter2Row.Tube4Value = tube.OuterDiameter2
                    quantityCutRow.Tube4Value = tube.QuantityCut
                Case 5
                    lengthRow.Tube5Value = tube.Length
                    outerDiameter1Row.Tube5Value = tube.OuterDiameter1
                    outerDiameter2Row.Tube5Value = tube.OuterDiameter2
                    quantityCutRow.Tube5Value = tube.QuantityCut
                Case 6
                    lengthRow.Tube6Value = tube.Length
                    outerDiameter1Row.Tube6Value = tube.OuterDiameter1
                    outerDiameter2Row.Tube6Value = tube.OuterDiameter2
                    quantityCutRow.Tube6Value = tube.QuantityCut
                Case 7
                    lengthRow.Tube7Value = tube.Length
                    outerDiameter1Row.Tube7Value = tube.OuterDiameter1
                    outerDiameter2Row.Tube7Value = tube.OuterDiameter2
                    quantityCutRow.Tube7Value = tube.QuantityCut
                Case 8
                    lengthRow.Tube8Value = tube.Length
                    outerDiameter1Row.Tube8Value = tube.OuterDiameter1
                    outerDiameter2Row.Tube8Value = tube.OuterDiameter2
                    quantityCutRow.Tube8Value = tube.QuantityCut
            End Select
        Next

    End Sub


End Class
