using Adhocs.Logic.Infrastructure;
using Adhocs.Logic.Object;
using Adhocs.Logic.ServiceHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Adhocs.smartclient
{
    public partial class downloadrb : BasePage
    {
        public string _fileName;
        private string _buildnos;
        private TRTNBuilderUploadHandler _trtnBuilderUploader = new TRTNBuilderUploadHandler();
        public List<TRTNBuilderUploadObject> _rBuilderList = new List<TRTNBuilderUploadObject>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (base.Error.Count > 0)
                {
                    divAlert.Visible = true;
                    lblError.Text = base.Error[0];
                    return;
                }

                if(!Page.IsPostBack)
                {
                    //_rBuilderList = _trtnBuilderUploader.GetAll();
                    this.gridViewRb.DataSource = _trtnBuilderUploader.GetAll();
                    this.gridViewRb.DataBind();
                }
            }
            catch(Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
            }
        }

        protected void btnUpload_ServerClick(object sender, EventArgs e)
        {
            try
            {
                _fileName = this.customFile.PostedFile.FileName;
                if (string.IsNullOrWhiteSpace(_fileName))
                {
                    divAlert.Visible = true;
                    lblError.Text = "No file has been selected for upload yet";
                    return;
                }

                if (string.IsNullOrWhiteSpace(this.txtBuildNumber.Value))
                    _buildnos = null;
                else
                    if(this.txtBuildNumber.Value.Contains("v"))
                        _buildnos = this.txtBuildNumber.Value;
                    else
                        _buildnos = $"v {this.txtBuildNumber.Value}";

                //Check of the file has an extenssion of .zip
                var hasExt = Path.HasExtension(_fileName);
                if (hasExt)
                {
                    var extName = Path.GetExtension(_fileName);
                    if(extName.Equals(".zip") || extName.Equals(".rar"))
                    {
                        int rowsAffected = 0;
                        //Check if the return builder table contains data
                        var allAvailableRb = _trtnBuilderUploader.GetAll();
                        if(allAvailableRb == null || allAvailableRb.Count < 1)
                        {
                            //If available return builder is null, save else update
                            ///Save operation
                            rowsAffected = _trtnBuilderUploader.Save(new TRTNBuilderUploadObject()
                            {
                                file_name = _fileName,
                                upload_date = DateTime.Now,
                                build_number = _buildnos,
                                is_current = true,
                                uploaded_by = currentUser
                            });
                        }
                        else
                        {
                            //Update operation
                            rowsAffected = _trtnBuilderUploader.Update(new TRTNBuilderUploadObject()
                            {
                                file_name = _fileName,
                                upload_date = DateTime.Now,
                                build_number = _buildnos,
                                is_current = true,
                                uploaded_by = currentUser
                            });
                        }
                        
                        if (rowsAffected > 0)
                        {
                            this.divAlert.Visible = true;
                            divAlert.Attributes.Add("class", "alert alert-success alert-dismissible");
                            this.lblError.Text = "Return builder uploaded successfully";
                        }
                        else
                        {
                            this.divAlert.Visible = true;
                            this.lblError.Text = "Error occured while saving changes";
                        }
                    }
                    else
                    {
                        divAlert.Visible = true;
                        lblError.Text = "Selected file not supported. Supported files are (.zip & .rar)";
                    }
                }
            }
            catch(Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
            }
        }

        protected void btnAddBuild_ServerClick(object sender, EventArgs e)
        {
            _fileName = this.customFile.PostedFile.FileName ?? null;
            if (!string.IsNullOrWhiteSpace(_fileName))
            {
                divAlert.Visible = false;
                ClientScript.RegisterStartupScript(this.GetType(), "UpdatePasswordPolicy", "$('#exampleModalCenterX').modal('show')", true);
            }
            else
            {
                divAlert.Visible = true;
                lblError.Text = "No file has been selected for upload yet";
            }
        }

        protected void gridViewRb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Get the return builder filename
                var rbFileName = this.gridViewRb.SelectedRow.Cells[2].Text;
                //Get the return builder download path
                var rbPathInConfig = SharedConst.RETURN_BUILDER_DOWNLOAD_PATH;
                //combine the file name and path
                var realFileNameAndPath = rbPathInConfig + rbFileName;
                if (string.IsNullOrWhiteSpace(rbFileName) || string.IsNullOrWhiteSpace(Server.HtmlDecode(rbFileName)))
                {
                    divAlert.Visible = true;
                    lblError.Text = "No file available to download";
                }
                else
                {
                    Response.Clear();
                    Response.ContentType = "application/zip";
                    Response.AddHeader("Content-Disposition", $"attachment; filename={rbFileName}");
                    Response.TransmitFile(realFileNameAndPath);
                    var data = Response.OutputStream;
                    Response.End();
                    checked
                    {

                    }
                }
            }
            catch(Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
            }
        }

        protected void btnDownload_ServerClick(object sender, EventArgs e)
        {
            try
            {
                //Get the return builder filename
                var rbFileName = this.gridViewRb.Rows[0].Cells[2].Text;
                //Get the return builder download path
                var rbPathInConfig = SharedConst.RETURN_BUILDER_DOWNLOAD_PATH;
                //combine the file name and path
                var realFileNameAndPath = rbPathInConfig + rbFileName;
                if (string.IsNullOrWhiteSpace(rbFileName) || string.IsNullOrWhiteSpace(Server.HtmlDecode(rbFileName)))
                {
                    divAlert.Visible = true;
                    lblError.Text = "No file available to download";
                }
                else
                {
                    Response.Clear();
                    Response.ContentType = "application/zip";
                    Response.AddHeader("Content-Disposition", $"attachment; filename={rbFileName}");
                    Response.TransmitFile(realFileNameAndPath);
                    var data = Response.OutputStream;
                    Response.End();
                    checked
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                LogUtitlity.LogToText(ex.ToString());
            }
        }
    }
}