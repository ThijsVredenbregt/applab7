using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
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


                    string extention = Path.GetExtension(file_upload_control.PostedFile.FileName);


                    if (file_upload_control.PostedFile.ContentType == "image/jpeg")
                    {
                        if (file_upload_control.PostedFile.ContentLength < 102400)
                        {
                            string filename = Path.GetFileName(file_upload_control.FileName);
                            file_upload_control.PostedFile.SaveAs(Server.MapPath("~/") + filename);
                            upload_status_label.Text = "Upload status: File uploaded!";
                        }
                        else
                            upload_status_label.Text = "Upload status: The file has to be less than 100 kb!";
                    }
                    else
                        upload_status_label.Text = "Upload status: Only JPEG files are accepted!";
                }
                catch (Exception ex)
                {
                    upload_status_label.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
        }
    }
}