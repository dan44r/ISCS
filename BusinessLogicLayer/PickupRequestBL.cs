using DataAccessLayer;
using EntityLayer;
using System;
using System.Data;

namespace BusinessLogicLayer
{
    public class PickupRequestBL
    {
        public static Boolean AddPickupRequest(PickupRequestEL objEL)
        {
            Boolean stat = false;
            ProcedureExecute proc = new ProcedureExecute("sp_AdminUpdatePickupRequest");
            proc.AddVarcharPara("@Mode", 10, "add");
            proc.AddIntegerPara("@PickupRequestType", objEL.PickupRequestType);
            proc.AddIntegerPara("@PickupRequestTypeWarehouse", objEL.PickupRequestTypeWarehouse);
            proc.AddIntegerPara("@UserId", objEL.UserId);
            proc.AddVarcharPara("@ShipFromCompany", 100, objEL.ShipFromCompany);
            proc.AddVarcharPara("@ShipFromRefNumber", 20, objEL.ShipFromRefNumber);
            proc.AddVarcharPara("@ShipFromAddress", 100, objEL.ShipFromAddress);
            proc.AddVarcharPara("@ShipFromCity", 50, objEL.ShipFromCity);
            proc.AddVarcharPara("@ShipFromStatePick", 20, objEL.ShipFromState);
            proc.AddVarcharPara("@ShipFromCountryPick", 50, objEL.ShipFromCountry);
            proc.AddVarcharPara("@ShipFromPostalCode", 10, objEL.ShipFromPostalCode);
            proc.AddVarcharPara("@ShipFromContact", 50, objEL.ShipFromContact);
            proc.AddVarcharPara("@ShipFromPhone", 20, objEL.ShipFromPhone);
            proc.AddVarcharPara("@ShipFromFax", 20, objEL.ShipFromFax);
            proc.AddVarcharPara("@ShipFromEmail", 100, objEL.ShipFromEmail);
            proc.AddDateTimePara("@ShipFromDate", objEL.ShipFromDate);
            proc.AddVarcharPara("@ShipFromTimeReady", 20, objEL.ShipFromTimeReady);
            proc.AddVarcharPara("@ShipFromTimeNLT", 20, objEL.ShipFromTimeNLT);
            proc.AddIntegerPara("@ShipToLocationId", objEL.ShipToLocationId);
            proc.AddVarcharPara("@ShipToCompany", 100, objEL.ShipToCompany);
            proc.AddDateTimePara("@ShipToDate", objEL.ShipToDate);
            proc.AddVarcharPara("@ShipToAddress", 100, objEL.ShipToAddress);
            proc.AddVarcharPara("@ShipToCity", 50, objEL.ShipToCity);
            proc.AddVarcharPara("@ShipToStateDeli", 25, objEL.ShipToState);
            proc.AddVarcharPara("@ShipToCountryDeli", 50, objEL.ShipToCountry);
            proc.AddVarcharPara("@ShipToPostalCode", 10, objEL.ShipToPostalCode);
            proc.AddVarcharPara("@ShipToContact", 50, objEL.ShipToContact);
            proc.AddVarcharPara("@ShipToPhone", 20, objEL.ShipToPhone);
            proc.AddVarcharPara("@ShipToFax", 20, objEL.ShipToFax);
            proc.AddVarcharPara("@ShipToNotifyName", 50, objEL.ShipToNotifyName);
            proc.AddVarcharPara("@ShipToNotifyPhone", 20, objEL.ShipToNotifyPhone);
            proc.AddVarcharPara("@ShipToConsigneeRefNumber", 20, objEL.ShipToConsigneeRefNumber);
            proc.AddVarcharPara("@ExportEIN", 20, objEL.ExportEIN);
            proc.AddIntegerPara("@ExportPartiesToTransaction", objEL.ExportPartyTrans);
            proc.AddVarcharPara("@ExportLicence", 20, objEL.ExportLicence);
            proc.AddVarcharPara("@ExportECCN", 20, objEL.ExportECCN);
            proc.AddVarcharPara("@ExportIntermediateConsignee", 255, objEL.ExportIntermediateConsignee);
            proc.AddVarcharPara("@ExportAddress", 255, objEL.ExportAddress);
            proc.AddVarcharPara("@ExportCity", 50, objEL.ExportCity);
            proc.AddVarcharPara("@ExportIntermediateContact", 50, objEL.ExportIntermediateContact);
            proc.AddVarcharPara("@ExportPostalCode", 10, objEL.ExportPostalCode);
            proc.AddVarcharPara("@ExportIntermediatePhone", 20, objEL.ExportIntermediatePhone);
            proc.AddVarcharPara("@ExportCountryName", 100, objEL.ExportCountry);
            proc.AddDecimalPara("@Margin", 4, 18, objEL.Margin);
            proc.AddIntegerPara("@SkeletonRecord", objEL.SkeletonRecord);
            proc.AddVarcharPara("@StatusCode", 20, objEL.StatusCode);
            proc.AddIntegerPara("@NewRequestid", 0, QueryParameterDirection.Output);

            int i = proc.RunActionQuery();
            objEL.PickupRequestId = Convert.ToInt32(proc.GetParaValue("@NewRequestid"));
            if (i > 0)
            {
                stat = true;
            }
            return stat;
        }

        public static Boolean UpdatePickupRequest(PickupRequestEL objEL)
        {
            Boolean stat = false;
            ProcedureExecute proc = new ProcedureExecute("sp_AdminUpdatePickupRequest");
            proc.AddVarcharPara("@Mode", 10, "update");
            proc.AddIntegerPara("@PickupRequestId", objEL.PickupRequestId);
            proc.AddIntegerPara("@PickupRequestType", objEL.PickupRequestType);
            proc.AddIntegerPara("@PickupRequestTypeWarehouse", objEL.PickupRequestTypeWarehouse);
            proc.AddIntegerPara("@UserId", objEL.UserId);
            proc.AddVarcharPara("@ShipFromCompany", 100, objEL.ShipFromCompany);
            proc.AddVarcharPara("@ShipFromRefNumber", 20, objEL.ShipFromRefNumber);
            proc.AddVarcharPara("@ShipFromAddress", 100, objEL.ShipFromAddress);
            proc.AddVarcharPara("@ShipFromCity", 50, objEL.ShipFromCity);
            proc.AddVarcharPara("@ShipFromStatePick", 20, objEL.ShipFromState);
            proc.AddVarcharPara("@ShipFromCountryPick", 50, objEL.ShipFromCountry);
            proc.AddVarcharPara("@ShipFromPostalCode", 10, objEL.ShipFromPostalCode);
            proc.AddVarcharPara("@ShipFromContact", 50, objEL.ShipFromContact);
            proc.AddVarcharPara("@ShipFromPhone", 20, objEL.ShipFromPhone);
            proc.AddVarcharPara("@ShipFromFax", 20, objEL.ShipFromFax);
            proc.AddVarcharPara("@ShipFromEmail", 100, objEL.ShipFromEmail);
            proc.AddDateTimePara("@ShipFromDate", objEL.ShipFromDate);
            proc.AddVarcharPara("@ShipFromTimeReady", 20, objEL.ShipFromTimeReady);
            proc.AddVarcharPara("@ShipFromTimeNLT", 20, objEL.ShipFromTimeNLT);
            proc.AddIntegerPara("@ShipToLocationId", objEL.ShipToLocationId);
            proc.AddVarcharPara("@ShipToCompany", 100, objEL.ShipToCompany);
            proc.AddDateTimePara("@ShipToDate", objEL.ShipToDate);
            proc.AddVarcharPara("@ShipToAddress", 100, objEL.ShipToAddress);
            proc.AddVarcharPara("@ShipToCity", 50, objEL.ShipToCity);
            proc.AddVarcharPara("@ShipToStateDeli", 25, objEL.ShipToState);
            proc.AddVarcharPara("@ShipToCountryDeli", 50, objEL.ShipToCountry);
            proc.AddVarcharPara("@ShipToPostalCode", 10, objEL.ShipToPostalCode);
            proc.AddVarcharPara("@ShipToContact", 50, objEL.ShipToContact);
            proc.AddVarcharPara("@ShipToPhone", 20, objEL.ShipToPhone);
            proc.AddVarcharPara("@ShipToFax", 20, objEL.ShipToFax);
            proc.AddVarcharPara("@ShipToNotifyName", 50, objEL.ShipToNotifyName);
            proc.AddVarcharPara("@ShipToNotifyPhone", 20, objEL.ShipToNotifyPhone);
            proc.AddVarcharPara("@ShipToConsigneeRefNumber", 20, objEL.ShipToConsigneeRefNumber);
            proc.AddVarcharPara("@WeightType", 256, objEL.WeightType);
            proc.AddIntegerPara("@TransMode", objEL.TransMode);
            proc.AddVarcharPara("@TransModeName", 256, objEL.TransModeName);
            proc.AddVarcharPara("@TransModeService1", 20, objEL.TransModeService1);
            proc.AddVarcharPara("@TransModeService2", 20, objEL.TransModeService2);
            proc.AddVarcharPara("@SpecialServiceCodes", 100, objEL.SpecialServiceCodes);
            proc.AddVarcharPara("@ExportEIN", 20, objEL.ExportEIN);
            proc.AddIntegerPara("@ExportPartiesToTransaction", objEL.ExportPartyTrans);
            proc.AddVarcharPara("@ExportLicence", 20, objEL.ExportLicence);
            proc.AddVarcharPara("@ExportECCN", 20, objEL.ExportECCN);
            proc.AddVarcharPara("@ExportIntermediateConsignee", 255, objEL.ExportIntermediateConsignee);
            proc.AddVarcharPara("@ExportAddress", 255, objEL.ExportAddress);
            proc.AddVarcharPara("@ExportCity", 50, objEL.ExportCity);
            proc.AddVarcharPara("@ExportIntermediateContact", 50, objEL.ExportIntermediateContact);
            proc.AddVarcharPara("@ExportPostalCode", 10, objEL.ExportPostalCode);
            proc.AddVarcharPara("@ExportLoadingPort", 50, objEL.ExportLoadingPort);
            proc.AddVarcharPara("@ExportIntermediatePhone", 20, objEL.ExportIntermediatePhone);
            proc.AddVarcharPara("@ExportCountryName", 100, objEL.ExportCountry);
            proc.AddVarcharPara("@ExportUnloadingPort", 50, objEL.ExportUnloadingPort);
            proc.AddIntegerPara("@ExportContanerized", objEL.ExportContanerized);
            proc.AddVarcharPara("@ExportAlternative", 20, objEL.ExportAlternative);
            proc.AddVarcharPara("@ExportAlternativeDeliverTo", 255, objEL.ExportAlternativeDeliverTo);
            proc.AddVarcharPara("@SpecialInstructions", 1000, objEL.SpecialInstructions);
            proc.AddVarcharPara("@GLSPaymentMethod", 20, objEL.GLSPaymentMethod);
            proc.AddVarcharPara("@GLSCertifiedCheck", 3, objEL.GLSCertifiedCheck);
            proc.AddVarcharPara("@GLSBillCompany", 100, objEL.GLSBillCompany);
            proc.AddVarcharPara("@GLSBillAddress", 100, objEL.GLSBillAddress);
            proc.AddVarcharPara("@GLSBillCity", 100, objEL.GLSBillCity);
            proc.AddVarcharPara("@GLSBillPostalCode", 10, objEL.GLSBillPostalCode);
            proc.AddVarcharPara("@BillToStateName", 20, objEL.BillToStateName);
            proc.AddVarcharPara("@BillToCountryName", 20, objEL.BillToCountryName);
            proc.AddVarcharPara("@GLSCarrierName", 50, objEL.GLSCarrierName);
            proc.AddDecimalPara("@GLSCubicWeight", 2, 14, objEL.GLSCubicWeight);
            proc.AddIntegerPara("@GLSInsured", objEL.GLSInsured);
            proc.AddNTextPara("@GLSNotes", objEL.GLSNotes);
            proc.AddDecimalPara("@GLSShippedWeight", 2, 14, objEL.GLSShippedWeight);
            proc.AddIntegerPara("@GLSAccountId", objEL.GLSAccountId);
            proc.AddVarcharPara("@GLSTrackingNumber", 9, objEL.GLSTrackingNumber);
            proc.AddDecimalPara("@GLSBuyRateTransportCharge", 2, 14, objEL.GLSBuyRateTransportCharge);
            proc.AddDecimalPara("@GLSBuyRateAccessorialCharge", 2, 14, objEL.GLSBuyRateAccessorialCharge);
            proc.AddDecimalPara("@GLSBuyRateFuelCharge", 2, 14, objEL.GLSBuyRateFuelCharge);
            proc.AddDecimalPara("@GLSBuyRateInsuraceCharge", 2, 14, objEL.GLSBuyRateInsuraceCharge);
            proc.AddDecimalPara("@GLSBuyRateCodFee", 2, 14, objEL.GLSBuyRateCodFee);
            proc.AddDecimalPara("@GLSTotalBuyRate", 2, 14, objEL.GLSTotalBuyRate);
            proc.AddDecimalPara("@GLSSellRateTransportCharge", 2, 14, objEL.GLSSellRateTransportCharge);
            proc.AddDecimalPara("@GLSSellRateAccessorialCharge", 2, 14, objEL.GLSSellRateAccessorialCharge);
            proc.AddDecimalPara("@GLSSellRateFuelCharge", 2, 14, objEL.GLSSellRateFuelCharge);
            proc.AddDecimalPara("@GLSSellRateInsuraceCharge", 2, 14, objEL.GLSSellRateInsuraceCharge);
            proc.AddDecimalPara("@GLSSellRateCodFee", 2, 14, objEL.GLSSellRateCodFee);
            proc.AddDecimalPara("@GLSTotalSellRate", 2, 14, objEL.GLSTotalSellRate);
            proc.AddIntegerPara("@GLSKnownShipper", objEL.GLSKnownShipper);
            proc.AddVarcharPara("@GLSCarrierNameInterm", 50, objEL.GLSCarrierNameInterm);
            proc.AddVarcharPara("@GLSCarrierNameDelivery", 50, objEL.GLSCarrierNameDelivery);
            proc.AddVarcharPara("@GLSCarrierNameOther", 50, objEL.GLSCarrierNameOther);
            proc.AddDecimalPara("@GLSBuyRateTransportChargeInterm", 2, 14, objEL.GLSBuyRateTransportChargeInterm);
            proc.AddDecimalPara("@GLSBuyRateTransportChargeDelivery", 2, 14, objEL.GLSBuyRateTransportChargeDelivery);
            proc.AddDecimalPara("@GLSBuyRateTransportChargeOther", 2, 14, objEL.GLSBuyRateTransportChargeOther);
            proc.AddDecimalPara("@GLSBuyRateAccessorialChargeInterm", 2, 14, objEL.GLSBuyRateAccessorialChargeInterm);
            proc.AddDecimalPara("@GLSBuyRateAccessorialChargeDelivery", 2, 14, objEL.GLSBuyRateAccessorialChargeDelivery);
            proc.AddDecimalPara("@GLSBuyRateAccessorialChargeOther", 2, 14, objEL.GLSBuyRateAccessorialChargeOther);
            proc.AddDecimalPara("@GLSBuyRateFuelChargeInterm", 2, 14, objEL.GLSBuyRateFuelChargeInterm);
            proc.AddDecimalPara("@GLSBuyRateFuelChargeDelivery", 2, 14, objEL.GLSBuyRateFuelChargeDelivery);
            proc.AddDecimalPara("@GLSBuyRateFuelChargeOther", 2, 14, objEL.GLSBuyRateFuelChargeOther);
            proc.AddIntegerPara("@InsuranceRequired", objEL.Insured);
            proc.AddDecimalPara("@InsuredValue", 2, 14, objEL.InsuredValue);
            proc.AddVarcharPara("@ShippersInstructions", 500, objEL.ShippersInstructions);
            proc.AddVarcharPara("@DocumentsEnclosed", 500, objEL.DocumentsEnclosed);
            proc.AddDecimalPara("@GLSBuyRateBrokerage", 2, 14, objEL.GLSBuyRateBrokerage);
            proc.AddDecimalPara("@GLSSellRateBrokerage", 2, 14, objEL.GLSSellRateBrokerage);
            proc.AddDecimalPara("@GLSBuyRateDuty", 2, 14, objEL.GLSBuyRateDuty);
            proc.AddDecimalPara("@GLSSellRateDuty", 2, 14, objEL.GLSSellRateDuty);
            proc.AddDecimalPara("@Margin", 4, 18, objEL.Margin);
            proc.AddIntegerPara("@SkeletonRecord", objEL.SkeletonRecord);
            proc.AddVarcharPara("@StatusCode", 20, objEL.StatusCode);

            int i = proc.RunActionQuery();
            if (i > 0)
            {
                stat = true;
            }
            return stat;
        }

        public static DataSet FetchAllPickupRequest(int PickupRequestId)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_AdminUpdatePickupRequest");
            proc.AddVarcharPara("@Mode", 10, "all");
            proc.AddIntegerPara("@PickupRequestId", PickupRequestId);
            ds = proc.GetDataSet();
            return ds;
        }
        public static DataSet FetchAllPickupRequest(string strPending)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_AdminUpdatePickupRequest");
            proc.AddVarcharPara("@Mode", 10, "all");
            proc.AddVarcharPara("@StatusCode", 20, strPending);
            ds = proc.GetDataSet();
            return ds;
        }

        public static int DeletePickupRequest(int PickupRequestId)
        {
            ProcedureExecute proc = new ProcedureExecute("sp_AdminUpdatePickupRequest");
            proc.AddVarcharPara("@Mode", 10, "delete");
            proc.AddIntegerPara("@PickupRequestId", PickupRequestId);
            int i = proc.RunActionQuery();
            return i;
        }

        public static DataTable FetchAirwayBill(int PickupRequestId)
        {
            DataTable dt;
            ProcedureExecute proc = new ProcedureExecute("spAdminSelectAirwayBill");
            proc.AddIntegerPara("@PickupRequestId", PickupRequestId);
            dt = proc.GetTable();
            return dt;
        }

        public static DataTable FetchBillofLading(int PickupRequestId)
        {
            DataTable dt = null;
            try
            {
                ProcedureExecute proc = new ProcedureExecute("spAdminSelectBillOfLading");
                proc.AddIntegerPara("@PickupRequestId", PickupRequestId);
                dt = proc.GetTable();
            }
            catch (Exception ex)
            {
            }
            return dt;
        }

        public static DataTable FetchShipmentItems(int PickupRequestId)
        {
            DataTable dt;
            ProcedureExecute proc = new ProcedureExecute("spAdminSelectShipmentItemsForBOL");
            proc.AddIntegerPara("@PickupRequestId", PickupRequestId);
            dt = proc.GetTable();
            return dt;
        }

        public static DataTable FetchSkidItems(int PickupRequestId)
        {
            DataTable dt;
            ProcedureExecute proc = new ProcedureExecute("spAdminSelectSkidsForBOL");
            proc.AddIntegerPara("@PickupRequestId", PickupRequestId);
            proc.AddIntegerPara("@PickupRequestType", 1);
            dt = proc.GetTable();
            return dt;
        }

        public static DataSet FetchSinglePickupRequest(int PickupRequestId)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_AdminSelectPickupRequest");
            proc.AddIntegerPara("@PickupRequestId", PickupRequestId);
            ds = proc.GetDataSet();
            return ds;
        }
        public static DataTable FetchSED_SLI(int PickupRequestId)
        {
            DataTable dt = null;
            try
            {
                ProcedureExecute proc = new ProcedureExecute("spAdminSelectSED_SLI");
                proc.AddIntegerPara("@PickupRequestId", PickupRequestId);
                dt = proc.GetTable();
            }
            catch (Exception ex)
            {
            }
            return dt;
        }

        public static Boolean LockPickupRequest(int iPickupRequestID, int iUserID, bool istat)
        {
            Boolean stat = false;
            ProcedureExecute proc = new ProcedureExecute("sp_AdminUpdatePickupRequest");
            if (istat)
            { proc.AddVarcharPara("@Mode", 10, "lock"); }
            if (!istat)
            { proc.AddVarcharPara("@Mode", 10, "unlock"); }
            proc.AddIntegerPara("@PickupRequestId", iPickupRequestID);
            proc.AddIntegerPara("@UserId", iUserID);
            int i = proc.RunActionQuery();
            if (i > 0)
            {
                stat = true;
            }
            return stat;
        }

        public static DataSet FetchActiveShipmentReport(int AccountCodeId)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("spActiveShipmentReport");
            proc.AddIntegerPara("@AccountCodeId", AccountCodeId);
            ds = proc.GetDataSet();
            return ds;
        }

        public static DataSet FetchCostSummaryByOrderNoReport(string OrderNo, int AccountCodeId)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("spCostSummaryByOrderNoReport");
            proc.AddVarcharPara("@OrderNo", 500, OrderNo);
            proc.AddIntegerPara("@AccountCodeId", AccountCodeId);
            ds = proc.GetDataSet();
            return ds;
        }

        public static int UnlockPickupRequest()
        {
            ProcedureExecute proc = new ProcedureExecute("spUnlockPickupRequest");
            int i = proc.RunActionQuery();
            return i;
        }

        public static int WarehouseRollbackShippedItems()
        {
            ProcedureExecute proc = new ProcedureExecute("spWarehouseRollbackShippedItems");
            int i = proc.RunActionQuery();
            return i;
        }
    }
}
