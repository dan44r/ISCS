using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusinessLogicLayer
{
    public class GridViewExportUtil
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="gv"></param>
        private void ExportGridView(GridView grv)
        {

            string attachment = "attachment; filename=FactoryVisitManagement_" + DateTime.Now.ToString("dd_MMM_yymmss") + ".xls";

            HttpContext.Current.Response.ClearContent();

            HttpContext.Current.Response.AddHeader("content-disposition", attachment);

            HttpContext.Current.Response.ContentType = "application/ms-excel";

            StringWriter sw = new StringWriter();

            HtmlTextWriter htw = new HtmlTextWriter(sw);


            grv.RenderControl(htw);

            HttpContext.Current.Response.Write(sw.ToString());

            HttpContext.Current.Response.End();

        }

        private void PrepareGridViewForExport(Control gv)
        {

            LinkButton lb = new LinkButton();

            Literal l = new Literal();

            string name = String.Empty;

            for (int i = 0; i < gv.Controls.Count; i++)
            {

                if (gv.Controls[i].GetType() == typeof(LinkButton))
                {

                    l.Text = (gv.Controls[i] as LinkButton).Text;

                    gv.Controls.Remove(gv.Controls[i]);

                    gv.Controls.AddAt(i, l);

                }

                else if (gv.Controls[i].GetType() == typeof(DropDownList))
                {

                    l.Text = (gv.Controls[i] as DropDownList).SelectedItem.Text;

                    gv.Controls.Remove(gv.Controls[i]);

                    gv.Controls.AddAt(i, l);

                }

                else if (gv.Controls[i].GetType() == typeof(CheckBox))
                {

                    l.Text = (gv.Controls[i] as CheckBox).Checked ? "True" : "False";

                    gv.Controls.Remove(gv.Controls[i]);

                    gv.Controls.AddAt(i, l);

                }

                if (gv.Controls[i].HasControls())
                {

                    PrepareGridViewForExport(gv.Controls[i]);

                }

            }

        }
        public static void Export(string fileName, GridView gv, int status)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader(
                "content-disposition", string.Format("attachment; filename={0}", fileName));
            // HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.ContentType = "application/vnd.xls";

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    //  Create a form to contain the grid
                    Table table = new Table();
                    if (status == 1)
                    {
                        table.GridLines = gv.GridLines;
                    }
                    //add the header row to the table
                    if (gv.HeaderRow != null)
                    {
                        GridViewExportUtil.PrepareControlForExport(gv.HeaderRow);
                        table.Rows.Add(gv.HeaderRow);
                    }


                    //  add each of the data rows to the table
                    foreach (GridViewRow row in gv.Rows)
                    {
                        gv.AutoGenerateEditButton = false;
                        GridViewExportUtil.PrepareControlForExport(row);
                        table.Rows.Add(row);
                    }

                    //  add the footer row to the table
                    if (gv.FooterRow != null)
                    {
                        GridViewExportUtil.PrepareControlForExport(gv.FooterRow);
                        table.Rows.Add(gv.FooterRow);
                    }

                    //  render the table into the htmlwriter
                    table.RenderControl(htw);

                    //  render the htmlwriter into the response
                    HttpContext.Current.Response.Write(sw.ToString());
                    HttpContext.Current.Response.End();
                }
            }
        }
        public static void PrepareForDownlaod(string fileName, DataTable DT)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader(
                "content-disposition", string.Format("attachment; filename={0}", fileName));
            HttpContext.Current.Response.ContentType = "application/ms-excel";

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    //  Create a form to contain the grid
                    Table table = new Table();

                    table.GridLines = GridLines.Both;

                    int rows = 1;
                    int cols = DT.Rows.Count;

                    for (int j = 0; j < rows; j++)
                    {
                        TableRow r = new TableRow();
                        for (int i = 0; i < cols; i++)
                        {
                            TableCell c = new TableCell();
                            c.Controls.Add(new LiteralControl(DT.Rows[i]["DB_Column_Name"].ToString()));
                            r.Cells.Add(c);
                        }
                        table.Rows.Add(r);
                    }
                    //  render the table into the htmlwriter
                    table.RenderControl(htw);

                    //  render the htmlwriter into the response
                    HttpContext.Current.Response.Write(sw.ToString());
                    HttpContext.Current.Response.End();
                }
            }
        }
        /// <summary>
        /// Replace any of the contained controls with literals

        public static void ExportErorlist(string fileName, GridView gv, int status)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader(
                "content-disposition", string.Format("attachment; filename={0}", fileName));
            HttpContext.Current.Response.ContentType = "application/ms-excel";

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    //  Create a form to contain the grid
                    Table table = new Table();
                    if (status == 1)
                    {
                        table.GridLines = gv.GridLines;
                    }
                    //add the header row to the table
                    if (gv.HeaderRow != null)
                    {
                        // TableCell cell = gv.HeaderRow.Cells[0];
                        // gv.HeaderRow.Cells.Remove(cell);

                        // TableCell cell1 = gv.HeaderRow.Cells[0];


                        GridViewExportUtil.PrepareControlForExport(gv.HeaderRow);
                        table.Rows.Add(gv.HeaderRow);
                    }


                    //  add each of the data rows to the table
                    foreach (GridViewRow row in gv.Rows)
                    {
                        //TableCell cell = row.Cells[0];
                        //row.Cells.Remove(cell);

                        //TableCell cell1 = row.Cells[0];
                        //row.Cells.Remove(cell1);

                        gv.AutoGenerateEditButton = false;
                        GridViewExportUtil.PrepareControlForExport(row);
                        table.Rows.Add(row);
                    }

                    //  add the footer row to the table
                    if (gv.FooterRow != null)
                    {
                        GridViewExportUtil.PrepareControlForExport(gv.FooterRow);
                        table.Rows.Add(gv.FooterRow);
                    }

                    //  render the table into the htmlwriter
                    table.RenderControl(htw);

                    //  render the htmlwriter into the response
                    HttpContext.Current.Response.Write(sw.ToString());
                    HttpContext.Current.Response.End();
                }
            }
        }

        /// </summary>
        /// <param name="control"></param>
        private static void PrepareControlForExport(Control control)
        {
            for (int i = 0; i < control.Controls.Count; i++)
            {
                Control current = control.Controls[i];
                if (current is LinkButton)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
                }
                else if (current is ImageButton)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
                }
                else if (current is HyperLink)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
                }
                else if (current is DropDownList)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
                }
                else if (current is CheckBox)
                {
                    control.Controls.Remove(current);
                    control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
                }

                if (current.HasControls())
                {
                    GridViewExportUtil.PrepareControlForExport(current);
                }
            }
        }
    }
}
