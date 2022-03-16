using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace BusinessLogicLayer
{
    public class HTML2PDF
    {
        #region Convert HTML to PDF
        /// <summary>
        /// This Static Function Converts html string to pdf and save in a folder
        /// </summary>
        /// <param name="folderpath2Write"> Folder path to create vthe pdf</param>
        /// <param name="html">string of html to write in pdf</param>
        /// <param name="pdfName">Name of the pdf</param>
        /// <param name="password">Password if you want else send blank or null</param>
        /// <returns></returns>
        public static int ConvertHTML2PDF(string folderpath2Write, string html, string pdfName, string password)
        {
            int ret = 0;
            Document document = new Document();
            try
            {
                //PdfWriter.GetInstance(document, new FileStream(folderpath2Write+"\\"+pdfName+"_1.pdf", FileMode.Create));
                PdfWriter.GetInstance(document, new FileStream(folderpath2Write + "\\" + pdfName + ".pdf", FileMode.Create));
                String htmlText = html;
                List<IElement> htmlarraylist = HTMLWorker.ParseToList(new StringReader(htmlText), new StyleSheet());
                document.Open();
                foreach (object item in htmlarraylist)
                {
                    document.Add((IElement)item);
                }
                //var logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/Uploads/Logo/CurbSide-Logo123.gif"));
                //logo.SetAbsolutePosition(10,100);
                //document.Add(logo);

                document.Close();

                /////////////////// Start Password Protected Pdf//////

                //string sname = folderpath2Write + "\\" + pdfName + "_1.pdf";
                //string sname1 = new System.IO.FileInfo(folderpath2Write + "\\" + pdfName + "_1.pdf").DirectoryName + "//"+pdfName+".pdf";
                //PdfReader reader = new PdfReader(sname);
                //int n = reader.NumberOfPages;

                // document = new Document(reader.GetPageSizeWithRotation(1));
                //PdfWriter writer = PdfWriter.GetInstance(document, new System.IO.FileStream(sname1, System.IO.FileMode.Create));
                //writer.SetEncryption(PdfWriter.STRENGTH128BITS, password, null, PdfWriter.AllowPrinting);
                //document.Open();
                //PdfContentByte cb = writer.DirectContent;
                //PdfImportedPage page = default(PdfImportedPage);
                //int rotation = 0;
                //int i = 0;
                //// step 4: we add content 
                //while (i < n)
                //{
                //    i += 1;
                //    document.SetPageSize(reader.GetPageSizeWithRotation(i));
                //    document.NewPage();
                //    page = writer.GetImportedPage(reader, i);
                //    rotation = reader.GetPageRotation(i);
                //    if (rotation == 90 || rotation == 270)
                //    {
                //        cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(i).Height);
                //    }
                //    else
                //    {
                //        cb.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);

                //    }
                //}

                //document.Close();
                //writer.Close();
                //File.Delete(folderpath2Write + "\\" + pdfName + "_1.pdf");

                /////////////////// End Password Protected Pdf//////
                ret = 1;
            }
            catch (Exception exx)
            {
                HttpContext.Current.Response.Write("<br>____________________________________<br>");
                HttpContext.Current.Response.Write("<br>Error: " + exx + "<br>");
                HttpContext.Current.Response.Write("<br>StackTrace: " + exx.StackTrace + "<br>");
                HttpContext.Current.Response.Write("<br>strPDFDocument: " + pdfName.ToString() + "<br>");
                HttpContext.Current.Response.Write("<br>HTML: " + html.ToString() + "<br>");
                ret = 0;
            }
            finally
            {
                document.Close();

            }
            return ret;
        }
        #endregion
    }
}
