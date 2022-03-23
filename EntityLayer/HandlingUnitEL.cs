using System;

namespace EntityLayer
{
    public class HandlingUnitEL
    {
        public int SkidId { get; set; }
        public string GLSTrackingNumber { get; set; }
        public int PickupRequestId { get; set; }
        public string HandlingUnitType { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int HazMat { get; set; }

        public string Class { get; set; }
        public string NMFCCode { get; set; }
        public string CommodityDescription { get; set; }
        public string HazMatEmergencyPhone { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }

        public int Weight_SI { get; set; }
    }
}
