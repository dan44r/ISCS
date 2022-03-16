using System;
using System.Data;
using DataAccessLayer;
using EntityLayer;

namespace BusinessLogicLayer
{
    public class UserTypeSectionsXrefBL
    {
        public static DataTable GetSectionIdByUserTypeId(int _UserTypeId)
        {
            DataTable dtUserTypeSectionXref = new DataTable();
            try
            {
                ProcedureExecute proc = new ProcedureExecute("sp_tblUserTypeSectionsXref");
                proc.AddVarcharPara("@Mode", 30, "selectbyUserTypeid");
                proc.AddIntegerPara("@UserTypeId", _UserTypeId);
                dtUserTypeSectionXref = proc.GetTable();
            }
            catch (Exception ex)
            { }
            return dtUserTypeSectionXref;
        }

        public static Boolean InsertUserTypeSectionXref(UserTypeSectionsXref objUserTypeSectionsXref)
        {
            Boolean stat = false;
            try
            {
                ProcedureExecute proc = new ProcedureExecute("sp_tblUserTypeSectionsXref");
                proc.AddVarcharPara("@Mode", 30, "insert");
                proc.AddIntegerPara("@UserTypeId", objUserTypeSectionsXref.UserTypeId);
                proc.AddIntegerPara("@SectionId", objUserTypeSectionsXref.SectionId);                

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

        public static Boolean DeleteUserTypeSectionXref(int _userTypeId)
        {
            Boolean stat = false;
            try
            {
                ProcedureExecute proc = new ProcedureExecute("sp_tblUserTypeSectionsXref");
                proc.AddVarcharPara("@Mode", 30, "delete");
                proc.AddIntegerPara("@UserTypeId", _userTypeId);
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

        public static Boolean CheckSectionId(int _sectionid, int _usertypeid)
        {
            Boolean stat = false;
            DataTable dtUserTypeSectionXref = new DataTable();
            try
            {
                ProcedureExecute proc = new ProcedureExecute("sp_tblUserTypeSectionsXref");
                proc.AddVarcharPara("@Mode", 30, "checksectionid");
                proc.AddIntegerPara("@SectionId", _sectionid);
                proc.AddIntegerPara("@UserTypeId", _usertypeid);
                dtUserTypeSectionXref = proc.GetTable();                
                if (dtUserTypeSectionXref.Rows.Count > 0)
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
