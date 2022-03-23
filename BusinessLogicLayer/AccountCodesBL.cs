using DataAccessLayer;
using System;
using System.Data;

namespace BusinessLogicLayer
{
    public class AccountCodesBL
    {
        public static DataSet FetchAllAccountCodes()
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_tblAccountCodes");
            proc.AddVarcharPara("@Mode", 30, "all");
            ds = proc.GetDataSet();
            return ds;
        }

        public static DataSet FetchAllAccountCodes(string strSearchKey, string strSearchCol)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_tblAccountCodes");
            proc.AddVarcharPara("@Mode", 30, "allwithcols");
            if (strSearchKey != "")
            {
                proc.AddNVarcharPara("@SearchText", 64, strSearchKey);
                proc.AddNVarcharPara("@SearchColumn", 16, strSearchCol);
            }
            ds = proc.GetDataSet();
            return ds;
        }

        public static int DeleteAccountCodes(int Id)
        {
            ProcedureExecute proc = new ProcedureExecute("sp_tblAccountCodes");
            proc.AddVarcharPara("@Mode", 30, "delete");
            proc.AddIntegerPara("@AccountId", Id);
            int i = proc.RunActionQuery();
            return i;
        }
        public static DataTable GetAccountCodeByAccountId(int Id)
        {
            DataTable ds = null;
            ProcedureExecute proc = new ProcedureExecute("sp_tblAccountCodes");
            proc.AddVarcharPara("@Mode", 30, "byid");
            proc.AddIntegerPara("@AccountId", Id);
            ds = proc.GetTable();
            return ds;
        }

        public static Boolean InsertAccountCode(EntityLayer.AccountCodes objEl)
        {
            Boolean stat = false;
            int i = 0;
            ProcedureExecute proc = new ProcedureExecute("sp_tblAccountCodes");
            proc.AddVarcharPara("@Mode", 30, "add");
            proc.AddNVarcharPara("@AccountCode", 3, objEl.AccountCode);
            proc.AddNVarcharPara("@AccountName", 100, objEl.AccountName);
            proc.AddDecimalPara("@Margin", 2, 6, objEl.Margin);
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


        public static Boolean UpdateAccountCode(EntityLayer.AccountCodes objEl)
        {
            Boolean stat = false;
            int i = 0;
            ProcedureExecute proc = new ProcedureExecute("sp_tblAccountCodes");
            proc.AddVarcharPara("@Mode", 30, "edit");
            proc.AddIntegerPara("@AccountId", objEl.AccountId);
            proc.AddNVarcharPara("@AccountCode", 3, objEl.AccountCode);
            proc.AddNVarcharPara("@AccountName", 100, objEl.AccountName);
            proc.AddDecimalPara("@Margin", 2, 6, objEl.Margin);
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
        public static DataSet FetchAllAccountCodesWithMargins()
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_AdminSelectPickupRequestAccountCodesFKeysWithMargins");
            ds = proc.GetDataSet();
            return ds;
        }
    }
}
