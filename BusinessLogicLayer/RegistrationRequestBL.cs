using DataAccessLayer;
using EntityLayer;
using System;
using System.Data;

namespace BusinessLogicLayer
{
    public class RegistrationRequestBL
    {
        public static Boolean InsertRegistrationRequest(RegistrationRequest objRegistrationRequest)
        {
            Boolean stat = false;
            try
            {
                ProcedureExecute proc = new ProcedureExecute("sp_tblRegistrationRequest");
                proc.AddVarcharPara("@Mode", 30, "insert");
                proc.AddNVarcharPara("@Name", 200, objRegistrationRequest.Name);
                proc.AddNVarcharPara("@ClientRefNum", 300, objRegistrationRequest.ClientRefNum);
                proc.AddNVarcharPara("@Phone", 200, objRegistrationRequest.Phone);
                proc.AddNVarcharPara("@EmailAddress", 300, objRegistrationRequest.EmailAddress);

                int i = proc.RunActionQuery();
                if (i > 0)
                {
                    stat = true;
                }
            }
            catch (Exception ex)
            {
            }
            return stat;
        }

        public static DataSet FetchAllRegistrationRequest(string strSearchKey, string strSearchCol)
        {
            DataSet dsRegistrationRequest;
            ProcedureExecute proc = new ProcedureExecute("sp_tblRegistrationRequest");
            proc.AddVarcharPara("@Mode", 30, "all");
            if (strSearchKey != "" && strSearchCol != "")
            {
                proc.AddNVarcharPara("@SearchText", 256, strSearchKey);
                proc.AddNVarcharPara("@SearchColumn", 16, strSearchCol);
            }
            dsRegistrationRequest = proc.GetDataSet();
            return dsRegistrationRequest;
        }

        public static Boolean DeleteRegistrationRequest(int _RegistrationRequestId)
        {
            Boolean stat = false;
            try
            {
                ProcedureExecute proc = new ProcedureExecute("sp_tblRegistrationRequest");
                proc.AddVarcharPara("@Mode", 30, "delete");
                proc.AddIntegerPara("@Id", _RegistrationRequestId);
                int i = proc.RunActionQuery();
                if (i < 0)
                {
                    stat = true;
                }
            }
            catch (Exception ex)
            {
            }
            return stat;
        }
    }
}
