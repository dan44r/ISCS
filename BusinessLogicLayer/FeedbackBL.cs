using System;
using System.Data;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class FeedbackBL
    {
        public static Boolean InsertFeedback(EntityLayer.UserFeedback objEl)
        {
            Boolean stat = false;
            try
            {
                ProcedureExecute proc = new ProcedureExecute("sp_Feedback");               
                proc.AddVarcharPara("@Mode", 10, "insert");
                proc.AddNVarcharPara("@Name", 256, objEl.Name);
                proc.AddNVarcharPara("@Company", 256, objEl.Company);
                proc.AddNVarcharPara("@Email", 256, objEl.Email);
                proc.AddNVarcharPara("@Phone", 256, objEl.Phone);
                proc.AddNVarcharPara("@Fax", 256, objEl.Fax);
                proc.AddBooleanPara("@IsPriority",  objEl.IsPriority);
                proc.AddNVarcharPara("@CommentType", 256, objEl.CommentType);
                proc.AddNVarcharPara("@CommentOn", 256, objEl.CommentOn);
                proc.AddBooleanPara("@IsActive",  objEl.IsActive);
                proc.AddBooleanPara("@IsDeleted",  objEl.IsDeleted);
                proc.AddDateTimePara("@CommentDate",  objEl.CommentDate);
                proc.AddNTextPara("@Comment", objEl.Comment);
               int i= proc.RunActionQuery();
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
        public static DataSet FetchAllFeedback(string strSearchKey,string strSearchCol)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_Feedback");
            proc.AddVarcharPara("@Mode", 10, "all");
            if (strSearchKey != "")
            {
                proc.AddNVarcharPara("@SearchText", 64, strSearchKey);
                proc.AddNVarcharPara("@SearchColumn", 16, strSearchCol);
            }
            ds = proc.GetDataSet();
            return ds;
        }
        //Sourayan 17-12-2010
        public static DataSet FetchFeedbackByID(int FeedbackID)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_Feedback");
            proc.AddVarcharPara("@Mode", 10, "byID");            
            proc.AddIntegerPara("@Id", FeedbackID);           
            ds = proc.GetDataSet();
            return ds;
        }
        //Sourayan 17-12-2010
        public static Boolean DeleteFeedback(int Id)
        {
            Boolean stat = false;
            ProcedureExecute proc = new ProcedureExecute("sp_Feedback");
            proc.AddVarcharPara("@Mode", 10, "delete");
            proc.AddIntegerPara("@Id", Id);
            int i = proc.RunActionQuery();
            if (i > 0)
            {
                stat = true;
            }
            return stat;
        }
        public static Boolean SetActivation(EntityLayer.UserFeedback objEl)
        {
            Boolean stat = false;
            ProcedureExecute proc = new ProcedureExecute("sp_Feedback");
            proc.AddVarcharPara("@Mode", 10, "activate");
            proc.AddIntegerPara("@Id", objEl.Id);
            proc.AddBooleanPara("@IsActive", objEl.IsActive);
            int i = proc.RunActionQuery();
            if (i > 0)
            {
                stat = true;
            }
            return stat;
        }
    }
}
