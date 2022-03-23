using System;

namespace EntityLayer
{
    public class WarehouseShipmentItems
    {
        public int InventoryId { get; set; }
        public int SkidId_WI { get; set; }
        public string GLSTrackingNumber_WI { get; set; }
        public int PickupRequestId_WI { get; set; }
        public int PackageQuantity_WI { get; set; }
        public string PartNumber_WI { get; set; }
        public string PurchaseOrderNumber_WI { get; set; }
        public string LotNumber_WI { get; set; }
        public string Description_WI { get; set; }
        public string ContainerName_WI { get; set; }
        public string PackageType_WI { get; set; }
        public int Weight_WI { get; set; }
        public decimal Weight_Individual { get; set; }
        public decimal DeclaredValue_WI { get; set; }
        public string Export_MFG_WI { get; set; }
        public string ExportScheduleB_WI { get; set; }
        public int HazMat_WI { get; set; }
        public int OnHandQuantity { get; set; }
        public int PendingPickQuantity { get; set; }
        public int WarehouseLocationId { get; set; }
        public int GLSAccountId { get; set; }
        public int AdminUserId { get; set; }
        public DateTime DateAdded_WI { get; set; }
        public DateTime DateModified_WI { get; set; }
        public int PickupRequestType { get; set; }
        public int QtyAdded { get; set; }
        public int PickupRequestId { get; set; }
        public int SkidId_SI { get; set; }
    }
}
