using System;

namespace EntityLayer
{
    public class TBills
    {
        public int TrackingBillId { get; set; }
        public int PickupRequestId { get; set; }
        public DateTime create_date { get; set; }
        public string tracking_no { get; set; }
        public int status_id { get; set; }
        public int airport_id { get; set; }
        public DateTime status_date { get; set; }
        public int agent_id { get; set; }
        public int pieces { get; set; }
        public decimal actual_weight { get; set; }
        public decimal dim_weight { get; set; }
        public string notes { get; set; }
        public DateTime DateModified { get; set; }
        public int AccountCodeId { get; set; }
        public DateTime DateLastUpdated { get; set; }
        public string ProNumber { get; set; }
        public string ProNumberInterm { get; set; }
        public string ProNumberDelivery { get; set; }
        public string ProNumberOther { get; set; }
        public string GLSCarrierName { get; set; }
        public string GLSCarrierNameInterm { get; set; }
        public string GLSCarrierNameDelivery { get; set; }
        public string GLSCarrierNameOther { get; set; }
    }
}
