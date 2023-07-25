using System;
using System.Text;
using System.Web.SessionState;
using System.Web.UI;
using Microsoft.CSharp;
using System.Net;

using System.IO;

namespace RBS
{
	/// <summary>
	/// Summary description for rbs.
	/// </summary>
	public class rbs
	{
		public rbs()
		{
			//
			// TODO: Add constructor logic here
			//
		
		}
		public static void SetFocus(Control control)
			{
				StringBuilder sb = new StringBuilder();
 
				sb.Append("\r\n<script language='JavaScript'>\r\n");
				sb.Append("<!--\r\n"); 
				sb.Append("function SetFocus()\r\n"); 
				sb.Append("{\r\n"); 
				sb.Append("\tdocument.");
 
				Control p = control.Parent;
				while (!(p is System.Web.UI.HtmlControls.HtmlForm)) p = p.Parent; 
 
				sb.Append(p.ClientID);
				sb.Append("['"); 
				sb.Append(control.UniqueID); 
				sb.Append("'].focus();\r\n"); 
				sb.Append("}\r\n"); 
				sb.Append("window.onload = SetFocus;\r\n"); 
				sb.Append("// -->\r\n"); 
				sb.Append("</script>");
				control.Page.RegisterClientScriptBlock("SetFocus", sb.ToString());
			}

		//public MemoryStream showrep(CrystalDecisions.CrystalReports.Engine.ReportDocument rpt)
		//{
		
		//	MemoryStream oStream = new MemoryStream();
		//	CrystalDecisions.Shared.DiskFileDestinationOptions DiskOpts = new CrystalDecisions.Shared.DiskFileDestinationOptions();
		//	rpt.SetDataSource("qa");
		//	rpt.SetDatabaseLogon("qa","qa");
		//	//rpt.DataDefinition.RecordSelectionFormula=formula;
		//	rpt.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.NoDestination;
		//	rpt.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
		//	oStream = (MemoryStream)rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
		//	return(oStream);
		//}

		//public MemoryStream showwordrep(CrystalDecisions.CrystalReports.Engine.ReportDocument rpt)
		//{
		//	MemoryStream oStream = new MemoryStream();
		//	CrystalDecisions.Shared.DiskFileDestinationOptions DiskOpts = new CrystalDecisions.Shared.DiskFileDestinationOptions();
		//	rpt.SetDataSource("qa");
		//	rpt.SetDatabaseLogon("qa","qa");
		//	rpt.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.NoDestination;
		//	rpt.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.WordForWindows;
		//	oStream = (MemoryStream)rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.WordForWindows);
		//	return(oStream);
		//}


		//public MemoryStream showpdfrep(CrystalDecisions.CrystalReports.Engine.ReportDocument rpt)
		//{
		//	MemoryStream oStream = new MemoryStream();
		//	CrystalDecisions.Shared.DiskFileDestinationOptions DiskOpts = new CrystalDecisions.Shared.DiskFileDestinationOptions();
		//	rpt.SetDataSource("qa");
		//	rpt.SetDatabaseLogon("qa","qa");
		//	rpt.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.NoDestination;
		//	//rpt.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;

		//	rpt.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
		//	oStream = (MemoryStream)rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
		//	return(oStream);
		//}
		//public MemoryStream showexcelrep(CrystalDecisions.CrystalReports.Engine.ReportDocument rpt)
		//{
		//	MemoryStream oStream = new MemoryStream();
		//	CrystalDecisions.Shared.DiskFileDestinationOptions DiskOpts = new CrystalDecisions.Shared.DiskFileDestinationOptions();
		//	rpt.SetDataSource("qa");
		//	rpt.SetDatabaseLogon("qa","qa");
		//	rpt.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.NoDestination;
		//	rpt.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.Excel;
		//	oStream = (MemoryStream)rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
		//	return(oStream);
		//}

		//public MemoryStream showrtfrep(CrystalDecisions.CrystalReports.Engine.ReportDocument rpt)
		//{
		//	MemoryStream oStream = new MemoryStream();
		//	CrystalDecisions.Shared.DiskFileDestinationOptions DiskOpts = new CrystalDecisions.Shared.DiskFileDestinationOptions();
		//	rpt.SetDataSource("qa");
		//	rpt.SetDatabaseLogon("qa","qa");
		//	rpt.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.NoDestination;
		//	rpt.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.RichText;
		//	oStream = (MemoryStream)rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.RichText);
		//	return(oStream);
		//}

	
		
     }
}


