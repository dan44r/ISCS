using System;

namespace EntityLayer
{
    public class ShipmentItemsEL
    {
        public int ShipmentItemId { get; set; }
        public int SkidId_SI { get; set; }
        public int PickupRequestId_SI { get; set; }
        public int PackageQuantity_SI { get; set; }
        public string PartNumber_SI { get; set; }
        public string PurchaseOrderNumber_SI { get; set; }
        public string LotNumber_SI { get; set; }
        public string Description_SI { get; set; }
        public string ContainerName_SI { get; set; }
        public string PackageType_SI { get; set; }
        public int Weight_SI { get; set; }
        public decimal DeclaredValue_SI { get; set; }
        public string Export_MFG_SI { get; set; }
        public string ExportScheduleB_SI { get; set; }
        public DateTime DateAdded_SI { get; set; }
        public DateTime DateModified_SI { get; set; }
        public int SkidId_WI { get; set; }
        public string GLSTrackingNumber_WI { get; set; }
    }
}
