namespace EntityLayer
{
    public class QuickBookEL
    {
        public string VendorName { get; set; }
        public string IsActive { get; set; }
        public int CarrierID { get; set; }
        public double VendorTransportAmt1 { get; set; }
        public double VendorAccessorialAmt1 { get; set; }
        public double VendorFuelSurchargeAmt1 { get; set; }
        public double VendorTransportAmt2 { get; set; }
        public double VendorAccessorialAmt2 { get; set; }
        public double VendorFuelSurchargeAmt2 { get; set; }
        public double VendorTransportAmt3 { get; set; }
        public double VendorAccessorialAmt3 { get; set; }
        public double VendorFuelSurchargeAmt3 { get; set; }
        public double VendorTransportAmt4 { get; set; }
        public double VendorAccessorialAmt4 { get; set; }
        public double VendorFuelSurchargeAmt4 { get; set; }
        public double VendorInsuranceAmt { get; set; }
        public double VendorCODFeeAmt { get; set; }

        public double VendorBuyBrokerageAmt1 { get; set; }
        public double VendorBuyDutyAmt1 { get; set; }

        public string CustomerName { get; set; }
        public string CustomerCompanyName { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerAddr1 { get; set; }
        public string CustomerAddr2 { get; set; }
        public string CustomerAddr3 { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerState { get; set; }
        public string CustomerPostalCode { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAltPhone { get; set; }
        public string CustomerFax { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerContact { get; set; }

        public double CustomerTransportAmt { get; set; }
        public double CustomerAccessorialAmt { get; set; }
        public double CustomerFuelSurchargeAmt { get; set; }
        public double CustomerInsuranceAmt { get; set; }
        public double CustomerCODFeeAmt { get; set; }

        public double CustomerSellBrokerageAmt { get; set; }
        public double CustomerSellDutyAmt { get; set; }

        public string CustomerInvoiceDesc { get; set; }
        public double CustomerTotalAmt { get; set; }
        public int CustomerTotalQty { get; set; }

        public string CustomerInvoiceNo { get; set; }

    }
}
