using System;
using System.Data;
using DataAccessLayer;

namespace BusinessLogicLayer
{
   public class InformationRequestBL
    {
       public static Boolean InsertInfoReqest(EntityLayer.InfoRequest objEl)
       {
           Boolean stat = false;
           try
           {
               ProcedureExecute proc = new ProcedureExecute("sp_InformationRequest");
                proc.AddVarcharPara("@Mode",10,"insert");
                proc.AddNVarcharPara("@ServiceType",128,objEl.ServiceType);
                proc.AddNVarcharPara("@Name",64,objEl.Name);
                proc.AddNVarcharPara("@Address",128,objEl.Address);
                proc.AddNVarcharPara("@City",32,objEl.City);
                proc.AddNVarcharPara("@State",32,objEl.State);
                proc.AddNVarcharPara("@Zip",16,objEl.Zip);
                proc.AddNVarcharPara("@Phone",32,objEl.Phone);
                proc.AddNVarcharPara("@Email", 64, objEl.Email);
                int i = proc.RunActionQuery();
                if (i > 0)
                {
                    stat = true;
                }
           }
           catch (Exception ex)
           { }
           return stat;
       }
       public static DataSet FetchAllInfoRequest(string strSearchKey, string strSearchCol)
       {
           DataSet ds;
           ProcedureExecute proc = new ProcedureExecute("sp_InformationRequest");
           proc.AddVarcharPara("@Mode", 10, "all");
           if (strSearchKey != "")
           {
               proc.AddNVarcharPara("@SearchText", 64, strSearchKey);
               proc.AddNVarcharPara("@SearchColumn", 16, strSearchCol);
           }
           ds = proc.GetDataSet();
           return ds;
       }
       
       public static DataSet FetchInfoRequestByID(int InfoRequestID)
       {
           DataSet ds;
           ProcedureExecute proc = new ProcedureExecute("sp_InformationRequest");
           proc.AddVarcharPara("@Mode", 10, "byID");
           proc.AddIntegerPara("@Id", InfoRequestID);
           ds = proc.GetDataSet();
           return ds;
       }
       
       public static Boolean DeleteInfoRequest(int Id)
       {
           Boolean stat = false;
           ProcedureExecute proc = new ProcedureExecute("sp_InformationRequest");
           proc.AddVarcharPara("@Mode", 10, "delete");
           proc.AddIntegerPara("@Id", Id);
           int i = proc.RunActionQuery();
           if (i > 0)
           {
               stat = true;
           }
           return stat;
       }
       public static Boolean SetRepliedInfoRequest(int Id)
       {
           Boolean stat = false;
           ProcedureExecute proc = new ProcedureExecute("sp_InformationRequest");
           proc.AddVarcharPara("@Mode", 10, "reply");
           proc.AddIntegerPara("@Id", Id);
           int i = proc.RunActionQuery();
           if (i > 0)
           {
               stat = true;
           }
           return stat;
       }
    }
}
