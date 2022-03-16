using System;
using System.Data;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class QBXmlFileBL
    {
        public static Boolean InsertQBXMLFile(string TrackingNo, string QBXmlFile, string QBCustomerAddXmlFile, string QBCustomerAmtAddXmlFile, string QBVendorAddXmlFile, string QBVendorAmtAddXmlFile)
        {
            Boolean stat = false;
            int i = 0;
            ProcedureExecute proc = new ProcedureExecute("prcQBXMLFile");
            proc.AddVarcharPara("@Mode", 100, "InsertQBXMLFile");
            proc.AddNVarcharPara("@TrackingNo", 50, TrackingNo);
            proc.AddNVarcharPara("@QBXmlFile", 200, QBXmlFile);
            proc.AddNVarcharPara("@QBCustomerAddXmlFile", 200, QBCustomerAddXmlFile);
            proc.AddNVarcharPara("@QBCustomerAmtAddXmlFile", 200, QBCustomerAmtAddXmlFile);
            proc.AddNVarcharPara("@QBVendorAddXmlFile", 200, QBVendorAddXmlFile);
            proc.AddNVarcharPara("@QBVendorAmtAddXmlFile", 200, QBVendorAmtAddXmlFile);
            
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

        public static Boolean UpdateQBXMLFile(string TrackingNo,string QBVendorAmtAddXmlFile)
        {
            Boolean stat = false;
            int i = 0;
            ProcedureExecute proc = new ProcedureExecute("prcQBXMLFile");
            proc.AddVarcharPara("@Mode", 100, "UpdateQBXMLFile");
            proc.AddNVarcharPara("@TrackingNo", 50, TrackingNo);            
            proc.AddNVarcharPara("@QBVendorAmtAddXmlFile", 200, QBVendorAmtAddXmlFile);

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

        public static DataTable QBXMLFileDetailsByTrackingNo(string TrackingNo)
        {
            DataTable ds = null;
            ProcedureExecute proc = new ProcedureExecute("prcQBXMLFile");
            proc.AddVarcharPara("@Mode", 100, "QBXMLFileDetailsByTrackingNo");
            proc.AddNVarcharPara("@TrackingNo", 50, TrackingNo);
            ds = proc.GetTable();
            return ds;
        }
    }
}
