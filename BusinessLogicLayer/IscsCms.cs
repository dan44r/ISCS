using DataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogicLayer
{
    public class IscsCms
    {
        public static DataSet GetPages(string strSearchKey, string strSearchCol)
        {
            DataSet ds = new DataSet();
            try
            {
                ProcedureExecute proc = new ProcedureExecute("sp_PublicPages");
                proc.AddVarcharPara("@Mode", 8, "select");
                if (strSearchKey != "" && strSearchCol != "")
                {
                    proc.AddNVarcharPara("@SearchText", 256, strSearchKey);
                    proc.AddNVarcharPara("@SearchColumn", 16, strSearchCol);
                }
                ds = proc.GetDataSet();
            }
            catch (Exception ex)
            { }
            return ds;
        }
        public static bool AddPageContent(EntityLayer.PageCms objEl)
        {
            bool stat = false;
            try
            {
                ProcedureExecute proc = new ProcedureExecute("sp_PublicPages");
                proc.AddVarcharPara("@Mode", 8, "edit");
                proc.AddIntegerPara("@PageId", objEl.PageId);
                proc.AddNTextPara("@PageContent", objEl.PageContent);
                proc.AddNVarcharPara("@PageTitle", 64, objEl.PageTitle);
                proc.AddNVarcharPara("@MetaKey", 256, objEl.MetaKey);
                proc.AddNVarcharPara("@MetaDescription", 256, objEl.MetaDescription);
                int count = proc.RunActionQuery();
                if (count > 0)
                {
                    stat = true;
                }
            }
            catch (Exception ex)
            { }
            return stat;
        }

        public static EntityLayer.PageCms FetchSingleContent(int pageId)
        {
            EntityLayer.PageCms objEl = new EntityLayer.PageCms();
            SqlDataReader objReader;
            try
            {
                ProcedureExecute proc = new ProcedureExecute("sp_PublicPages");
                proc.AddVarcharPara("@Mode", 8, "single");
                proc.AddIntegerPara("@PageId", pageId);
                objReader = proc.GetReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        objEl.PageContent = objReader["PageContent"].ToString();
                        objEl.PageTitle = objReader["PageTitle"].ToString();
                        objEl.MetaKey = objReader["MetaKey"].ToString();
                        objEl.MetaDescription = objReader["MetaDescription"].ToString();
                        objEl.PageName = objReader["PageName"].ToString();
                    }
                }
            }
            catch (Exception ex)
            { }
            return objEl;
        }
    }
}
