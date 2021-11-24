Public Class KittingStationReportMiscellaneousFields
    Implements ICustomDataSourceObject

    Public Property User As String
    Public Property MaterialNumber As String
    Public Property ProductModelAndSize As String
    Public Property BatchNumber As String
    Public Property TubingMaterialNumber As String
    Public Property TubingBatchNumber As String
    Public Property KanbanNumber As String
    Public Property QuantityInCassette As String
    Public Property IsSetupSizeRequired As String
    Public Property TubingIssuedCurrentBatch As String
    Public Property TotalQuantityCut As String
    Public Property BatchTargetSize As String
    Public Property BatchQuantity As String
    Public Property TubingIssuedNextBatch() As String = "0"
    Public Property BushingSizeValue() As String = "N/A"
    Public Property BushingSizeMin() As String = "N/A"
    Public Property BushingSizeMax() As String = "N/A"

End Class
