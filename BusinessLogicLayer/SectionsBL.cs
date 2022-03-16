using System;
using System.Data;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class SectionsBL
    {
        public static DataTable GetSectionById(int _SectionId)
        {
            DataTable dtSection = new DataTable();
            try
            {
                ProcedureExecute proc = new ProcedureExecute("sp_tblSections");
                proc.AddVarcharPara("@Mode", 30, "selectbyid");
                proc.AddIntegerPara("@Id", _SectionId);
                dtSection = proc.GetTable();
            }
            catch (Exception ex)
            { }
            return dtSection;
        }

        public static DataTable GetSectionByParentId(int _ParentId)
        {
            DataTable dtChildSection = new DataTable();
            try
            {
                ProcedureExecute proc = new ProcedureExecute("sp_tblSections");
                proc.AddVarcharPara("@Mode", 30, "selectbyParentid");
                proc.AddIntegerPara("@ParentId", _ParentId);
                dtChildSection = proc.GetTable();
            }
            catch (Exception ex)
            { }
            return dtChildSection;
        }

        public static DataTable FetchAllSectionsOmitParent()
        {
            DataTable dtSection;
            ProcedureExecute proc = new ProcedureExecute("sp_tblSections");
            proc.AddVarcharPara("@Mode", 30, "all");
            dtSection = proc.GetTable();
            return dtSection;
        }
    }
}
