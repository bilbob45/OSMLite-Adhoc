using Microsoft.Reporting.WebForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Adhocs
{
    public partial class report_test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String defaultReportName = "std_reporting_institution_details";
            var qs = Request.QueryString["rn"] == null ? null : Request.QueryString["rn"].ToString();
            if (qs == null)
                ShowReport(defaultReportName);
            else
                ShowReport(qs);

            this.iframereport.Src = $@"http:80//olamidebbt/ReportServer?/CBN_STD_REPORTS?/{defaultReportName}&rs:Command=Render";
        }

        private String GetSsrsUrlFromConfig()
        {
            var ssrsURL = ConfigurationManager.AppSettings["SSRSURL"].ToString();
            return ssrsURL;
        }

        private String GetSsrsFolderFromConfig()
        {
            var ssrsURL = ConfigurationManager.AppSettings["ReportFolderPath"].ToString();
            return ssrsURL;
        }

        private void ShowReport(string reportname)
        {
            //try
            //{
            //    this.ReportViewer1.ProcessingMode = ProcessingMode.Remote;
            //    this.ReportViewer1.ServerReport.ReportServerUrl = new Uri(GetSsrsUrlFromConfig());
            //    this.ReportViewer1.ServerReport.ReportPath = GetSsrsFolderFromConfig() + reportname;
            //    this.ReportViewer1.ShowPrintButton = true;
            //    this.ReportViewer1.ShowZoomControl = true;

            //    ArrayList reportParamArray = new ArrayList();
            //    ReportParameterInfoCollection reportParamInfoCollection = this.ReportViewer1.ServerReport.GetParameters();
            //    if (reportParamInfoCollection.Count > 0)
            //    {
            //        foreach (ReportParameterInfo reportinfo in reportParamInfoCollection)
            //        {
            //            reportParamArray.Add(reportinfo.Name);
            //            reportParamArray.Add(reportinfo.Values);
            //        }
            //    }
            //    ReportParameter param = new ReportParameter()
            //    {
            //        Name = reportParamArray[0].ToString()
            //    };

            //    this.ReportViewer1.ServerReport.SetParameters(param);
            //    this.ReportViewer1.ServerReport.Refresh();
            //}
            //catch (ReportServerException rptEx)
            //{
            //    if (rptEx.Message.Contains("ItemNotFound"))
            //    {
            //        divAlert.Visible = true;
            //        lblErrorMsg.Text = $"The report <b>{ reportname }</b> is not found on the report server";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    divAlert.Visible = true;
            //    lblErrorMsg.Text = ex.ToString();
            //}
        }

        protected void ReportViewer1_ReportError(object sender, ReportErrorEventArgs e)
        {
            this.divAlert.Visible = true;
            lblErrorMsg.Text = e.Exception.ToString();
        }
    }
}