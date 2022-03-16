using System;
using System.Data;
using DataAccessLayer;


namespace BusinessLogicLayer
{
    public class CarriersBL
    {
        public static DataSet FetchAllCarriers()
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_tblCarriers");
            proc.AddVarcharPara("@Mode", 30, "all");
            ds = proc.GetDataSet();
            return ds;
        }

        public static DataSet FetchAllCarriers(string strSearchKey, string strSearchCol)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_tblCarriers");
            proc.AddVarcharPara("@Mode", 30, "allwithcols");
            if (strSearchKey != "")
            {
                proc.AddNVarcharPara("@SearchText", 64, strSearchKey);
                proc.AddNVarcharPara("@SearchColumn", 16, strSearchCol);
            }
            ds = proc.GetDataSet();
            return ds;
        }

        public static DataSet FetchAllCarriersforpopup(int strUserCode, int strUserId)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_tblCarriers");
            proc.AddVarcharPara("@Mode", 30, "forcarrpop");
            proc.AddIntegerPara("@UserCode", strUserCode);
            proc.AddIntegerPara("@UserID", strUserId);
            
            ds = proc.GetDataSet();
            return ds;
        }

        public static Boolean DeleteCarriers(int Id)
        {
            Boolean stat = false;
            ProcedureExecute proc = new ProcedureExecute("sp_tblCarriers");
            proc.AddVarcharPara("@Mode", 30, "delete");
            proc.AddIntegerPara("@Id", Id);
            int i = proc.RunActionQuery();
            if (i > 0)
            {
                stat = true;
            }
            return stat;
        }

        public static DataTable GetCarrierByCarrierId(int Id)
        {
            DataTable ds = null;
            ProcedureExecute proc = new ProcedureExecute("sp_tblCarriers");
            proc.AddVarcharPara("@Mode", 30, "byid");
            proc.AddIntegerPara("@Id", Id);
            ds = proc.GetTable();
            return ds;
        }

        public static Boolean InsertCarrier(EntityLayer.Carriers objEl)
        {
            Boolean stat = false;
            int i = 0;
            ProcedureExecute proc = new ProcedureExecute("sp_tblCarriers");
            proc.AddVarcharPara("@Mode", 30, "add");
            proc.AddIntegerPara("@UserId", objEl.UserId);
            proc.AddNVarcharPara("@CarrierName", 100, objEl.CarrierName);
            proc.AddNVarcharPara("@Address", 300, objEl.Address);
            proc.AddNVarcharPara("@City", 100, objEl.City);
            proc.AddIntegerPara("@StateId", objEl.StateId);
            proc.AddNVarcharPara("@PostalCode", 50, objEl.PostalCode);
            proc.AddNVarcharPara("@ContactName", 100, objEl.ContactName);
            proc.AddNVarcharPara("@ContactPhone", 100, objEl.ContactPhone);
            proc.AddNVarcharPara("@ContactFax", 100, objEl.ContactFax);
            proc.AddNVarcharPara("@ContactEmail", 100, objEl.ContactEmail);            
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

        public static Boolean UpdateCarrier(EntityLayer.Carriers objEl)
        {
            Boolean stat = false;
            int i = 0;
            ProcedureExecute proc = new ProcedureExecute("sp_tblCarriers");
            proc.AddVarcharPara("@Mode", 30, "edit");
            proc.AddIntegerPara("@Id", objEl.Id);
            proc.AddIntegerPara("@UserId", objEl.UserId);
            proc.AddNVarcharPara("@CarrierName", 100, objEl.CarrierName);
            proc.AddNVarcharPara("@Address", 300, objEl.Address);
            proc.AddNVarcharPara("@City", 100, objEl.City);
            proc.AddIntegerPara("@StateId", objEl.StateId);
            proc.AddNVarcharPara("@PostalCode", 50, objEl.PostalCode);
            proc.AddNVarcharPara("@ContactName", 100, objEl.ContactName);
            proc.AddNVarcharPara("@ContactPhone", 100, objEl.ContactPhone);
            proc.AddNVarcharPara("@ContactFax", 100, objEl.ContactFax);
            proc.AddNVarcharPara("@ContactEmail", 100, objEl.ContactEmail); 
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

        public static Boolean SaveCarrier(Int32 Userid, string CarrierName, string CarrierNameInterm, string CarrierNameDelivery, string CarrierNameOther)
        {
            Boolean stat = false;
            int i = 0;
            try
            {
                ProcedureExecute proc = new ProcedureExecute("sp_AdminSaveCarrierInfo");
                proc.AddIntegerPara("@UserId", Userid);
                proc.AddNVarcharPara("@CarrierName", 50, CarrierName);
                proc.AddNVarcharPara("@CarrierNameInterm", 50, CarrierNameInterm);
                proc.AddNVarcharPara("@CarrierNameDelivery", 50, CarrierNameDelivery);
                proc.AddNVarcharPara("@CarrierNameOther", 50, CarrierNameOther);
            }
            catch (Exception ex)
            { }

            if (i > 0)
            {
                stat = true;
            }
            return stat;
        }
    }
}
