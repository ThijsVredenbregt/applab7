using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppLab_uploadForm
{
    public partial class Default : System.Web.UI.Page
    {
        private string[] validFileTypes;

        private struct UploadedFile
        {
            public string name { get; set; }
            public string extention { get; set; }
            public int size { get; set; }
            public string type { get; set; }
            public HttpPostedFile raw { get; set; }

            public UploadedFile(HttpPostedFile file): this()
            {
                name = Path.GetFileName(file.FileName);
                extention = Path.GetExtension(file.FileName);
                size = file.ContentLength;
                type = file.ContentType;
                raw = file;
            }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            validFileTypes = new string[] { "bmp", "gif", "png", "jpg", "jpeg", "doc", "xls" };
        }

        protected void upload_button_click(object sender, EventArgs e)
        {
            if (file_upload_control.HasFile)
            {
                try
                {
                    UploadedFile uf = new UploadedFile(file_upload_control.PostedFile);


                    foreach (PropertyInfo info in uf.GetType().GetProperties())
                    {
                        TableRow row = new TableRow();

                        TableCell[] cells = new TableCell[] {new TableCell(),new TableCell(),new TableCell()};
                        cells[0].Controls.Add(new LiteralControl(info.PropertyType.ToString()));
                        cells[1].Controls.Add(new LiteralControl(info.Name));
                        cells[2].Controls.Add(new LiteralControl(info.GetValue(uf).ToString()));
                        row.Cells.AddRange(cells);
                        
                        file_upload_details_table.Rows.Add(row);
                    }

                    status_label.Text = "Status: OK!";
                }
                catch (Exception ex)
                {
                    status_label.Text = "Status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
        }
    }
}