using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Collections;
using System.Configuration;
using Microsoft.Reporting.WebForms;


namespace Adhocs.Logic.ServiceHandler
{
    public class ReportExtentions
    {
        private const String IS_WORD = "WORDOPENXML";
        private const String IS_PDF = "PDF";
        private const String IS_EXCEL = "EXCELOPENXML";
        private const String IS_POWERPOINT = "PPTX";
        private const String IS_TIFF = "IMAGE";
        private const String IS_MHTML = "MHTML";
        private const String IS_CSV = "CSV";
        private const String IS_XML = "XML";
        private const String IS_DATA_FEED = "ATOM";

        /// <summary>
        /// Get internal rendering extension name by display name
        /// </summary>
        /// <param name="displayname">display name (as appear on the export report menu)</param>
        /// <returns>string</returns>
        public String GetInternalRenderingExtensionName(string displayname)
        {
            String name = "";
            switch (displayname.ToLower())
            {
                case "word":
                    name = IS_WORD;
                    break;
                case "excel":
                    name = IS_EXCEL;
                    break;
                case "power point":
                    name = IS_POWERPOINT;
                    break;
                case "tiff file":
                    name = IS_TIFF;
                    break;
                case "mhtml (web archive)":
                    name = IS_MHTML;
                    break;
                case "xml":
                    name = IS_XML;
                    break;
                case "data feed":
                    name = IS_DATA_FEED;
                    break;
                default:
                    throw new ArgumentException($"Invalid extension name provided {displayname}");
            }
            return name;
        }

        /// <summary>
        /// Get a array of all internal rendering extension names
        /// </summary>
        /// <returns>String[]</returns>
        public static String[] GetInternalRenderingExtensionName()
        {
            return new string[] { IS_WORD, IS_EXCEL, IS_POWERPOINT, IS_TIFF, IS_MHTML, IS_XML, IS_DATA_FEED };
        }

        /// <summary>
        /// Dissable specific or single report rendering extension
        /// </summary>
        /// <param name="rptViewerId">Report control Id</param>
        /// <param name="option">The internal or displayed extension name e.g CSV, Word, Power Point</param>
        public void DissableReportExportOptions(ReportViewer rptViewerId, string option)
        {
            RenderingExtension renderingExtendion = rptViewerId.ServerReport.ListRenderingExtensions().ToList<RenderingExtension>().Find(x => x.Name.Equals(option, StringComparison.OrdinalIgnoreCase));

            if (renderingExtendion != null)
            {
                FieldInfo info = renderingExtendion.GetType().GetField("m_isVisible", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                info.SetValue(renderingExtendion, false);
            }
        }

        /// <summary>
        /// Dissable specific or single report rendering extension
        /// </summary>
        /// <param name="rptViewerId">Report control Id</param>
        /// <param name="Options">An array of internal or displayed extension name e.g CSV, Word, Power Point</param>
        public void DissableReportExportOptions(ReportViewer rptViewerId, string[] Options)
        {
            foreach (var renderingOption in Options)
            {
                DissableReportExportOptions(rptViewerId, renderingOption);
            }
        }
    }
}