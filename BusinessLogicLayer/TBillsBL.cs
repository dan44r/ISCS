using DataAccessLayer;
using EntityLayer;
using System;
using System.Data;

namespace BusinessLogicLayer
{
    public class TBillsBL
    {
        public static DataSet FetchAllBills(int _UserCode, int _UserId)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_tblTBills");
            proc.AddVarcharPara("@Mode", 50, "trackingbillsbyagentid");
            proc.AddIntegerPara("@UserCode", _UserCode);
            proc.AddIntegerPara("@agent_id", _UserId);
            ds = proc.GetDataSet();
            return ds;
        }

        public static DataSet FetchAllShipper()
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_tblTBills");
            proc.AddVarcharPara("@Mode", 50, "shipfromcompany");
            ds = proc.GetDataSet();
            return ds;
        }

        public static DataSet FetchAllConsignee()
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_tblTBills");
            proc.AddVarcharPara("@Mode", 50, "shiptocompany");
            ds = proc.GetDataSet();
            return ds;
        }

        public static DataSet FetchByTrackingBillId(int _trackingBillId)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_tblTBills");
            proc.AddVarcharPara("@Mode", 50, "shipmentitembytrackingbillid");
            proc.AddIntegerPara("@TrackingBillId", _trackingBillId);
            ds = proc.GetDataSet();
            return ds;
        }

        public static DataSet FetchByTrackingBillNo(string _trackingBillNo)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_tblTBills");
            proc.AddVarcharPara("@Mode", 50, "shipmentitembytrackingbillno");
            proc.AddNVarcharPara("@tracking_no", 20, _trackingBillNo);
            ds = proc.GetDataSet();
            return ds;
        }

        public static DataSet FetchShipmentByParameter(int _agentid, string _shipfromcompany, string _shiptocompany, DateTime _shipdate)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_tblTBills");
            proc.AddVarcharPara("@Mode", 50, "listshipment");
            proc.AddIntegerPara("@agent_id", _agentid);
            proc.AddNVarcharPara("@ShipFromCompany", 1024, _shipfromcompany);
            proc.AddNVarcharPara("@ShipToCompany", 1024, _shiptocompany);
            proc.AddDateTimePara("@TimeFrame", _shipdate);
            ds = proc.GetDataSet();
            return ds;
        }

        public static DataSet FetchShipmentByParameter(string tracking_no, int AccountCodeId, DateTime _shipdate)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_tblTBills");
            proc.AddVarcharPara("@Mode", 50, "listshipment");
            proc.AddVarcharPara("@tracking_no", 50, tracking_no);
            proc.AddIntegerPara("@AccountCodeId", AccountCodeId);
            proc.AddDateTimePara("@TimeFrame", _shipdate);
            ds = proc.GetDataSet();
            return ds;
        }

        public static Boolean UpdateTbills(TBills objEl)
        {
            Boolean stat = false;
            int i = 0;
            ProcedureExecute proc = new ProcedureExecute("sp_tblTBills");
            proc.AddVarcharPara("@Mode", 50, "updatetbills");
            proc.AddIntegerPara("@TrackingBillId", objEl.TrackingBillId);
            proc.AddVarcharPara("@Tracking_No", 20, objEl.tracking_no);
            proc.AddIntegerPara("@Status_Id", objEl.status_id);
            proc.AddDateTimePara("@Status_Date", objEl.status_date);
            proc.AddIntegerPara("@Airport_Id", objEl.airport_id);
            proc.AddIntegerPara("@Agent_Id", objEl.agent_id);
            proc.AddIntegerPara("@Pieces", objEl.pieces);
            proc.AddDecimalPara("@Actual_Weight", 2, 14, objEl.actual_weight);
            proc.AddDecimalPara("@Dim_Weight", 2, 14, objEl.dim_weight);
            proc.AddTextPara("@Notes", objEl.notes);
            proc.AddVarcharPara("@ProNumber", 50, objEl.ProNumber);
            proc.AddVarcharPara("@ProNumberInterm", 50, objEl.ProNumberInterm);
            proc.AddVarcharPara("@ProNumberDelivery", 50, objEl.ProNumberDelivery);
            proc.AddVarcharPara("@ProNumberOther", 50, objEl.ProNumberOther);

            try
            {
                i = proc.RunActionQuery();
            }
            catch (Exception ex)
            { }

            if (i > 0)
            {
                stat = true;
            }
            return stat;
        }

        public static Boolean DeleteTbills(int _trackingBillId)
        {
            Boolean stat = false;
            int i = 0;
            ProcedureExecute proc = new ProcedureExecute("sp_tblTBills");
            proc.AddVarcharPara("@Mode", 50, "deletebills");
            proc.AddIntegerPara("@TrackingBillId", _trackingBillId);
            try
            {
                i = proc.RunActionQuery();
            }
            catch (Exception ex)
            { }

            if (i > 0)
            {
                stat = true;
            }
            return stat;
        }

        public static Boolean AddNewTbills(TBills objEl)
        {
            Boolean stat = false;
            int i = 0;
            ProcedureExecute proc = new ProcedureExecute("sp_tblTBills");
            proc.AddVarcharPara("@Mode", 50, "addnewbill");
            proc.AddVarcharPara("@Tracking_No", 20, objEl.tracking_no);
            proc.AddIntegerPara("@PickupRequestId", objEl.PickupRequestId);
            proc.AddIntegerPara("@Pieces", objEl.pieces);
            proc.AddDecimalPara("@Actual_Weight", 2, 14, objEl.actual_weight);
            proc.AddDecimalPara("@Dim_Weight", 2, 14, objEl.dim_weight);
            proc.AddIntegerPara("@Agent_Id", objEl.agent_id);
            proc.AddIntegerPara("@Status_Id", objEl.status_id);
            proc.AddIntegerPara("@AccountCodeId", objEl.AccountCodeId);
            proc.AddVarcharPara("@GLSCarrierName", 50, objEl.GLSCarrierName);
            proc.AddVarcharPara("@GLSCarrierNameInterm", 50, objEl.GLSCarrierNameInterm);
            proc.AddVarcharPara("@GLSCarrierNameDelivery", 50, objEl.GLSCarrierNameDelivery);
            proc.AddVarcharPara("@GLSCarrierNameOther", 50, objEl.GLSCarrierNameOther);

            try
            {
                i = proc.RunActionQuery();
            }
            catch (Exception ex)
            { }

            if (i > 0)
            {
                stat = true;
            }
            return stat;
        }
        public static DataSet SelectTrackingBillByTackingNo(string strTrackingNo)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_AdminSelectTrackingBillUserByTrackingNo");
            proc.AddVarcharPara("@Tracking_No", 30, strTrackingNo);
            ds = proc.GetDataSet();
            return ds;
        }

        public static DataSet FetchShipmentByPO(string tracking_no, int AccountCodeId, DateTime _shipdate)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_tblTBills");
            proc.AddVarcharPara("@Mode", 50, "listshipmentByPO");
            proc.AddVarcharPara("@tracking_no", 50, tracking_no);
            proc.AddIntegerPara("@AccountCodeId", AccountCodeId);
            proc.AddDateTimePara("@TimeFrame", _shipdate);
            ds = proc.GetDataSet();
            return ds;
        }
    }
}
