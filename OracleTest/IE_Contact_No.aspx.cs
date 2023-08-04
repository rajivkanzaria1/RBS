using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.IE_Contact_No
{
	public partial class IE_Contact_No : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			string wRegion = Convert.ToString(Request.Params["ACTION"]);
			string wRegion_Desc = "";
			int wSno = 0;
			if (wRegion == "N") { wRegion_Desc = "Northern Region"; }
			else if (wRegion == "S") { wRegion_Desc = "Southern Region"; }
			else if (wRegion == "E") { wRegion_Desc = "Eastern Region"; }
			else if (wRegion == "W") { wRegion_Desc = "Western Region"; }
			else if (wRegion == "C") { wRegion_Desc = "Central Region"; }

			DataSet dsP1 = new DataSet();
			string str3 = "select IE_NAME,IE_PHONE_NO,IE_EMAIL, CO_NAME, CO_PHONE_NO,CO_EMAIL from T09_IE T09, T08_IE_CONTROLL_OFFICER T08 where T09.IE_CO_CD=T08.CO_CD and IE_STATUS is null and IE_REGION='" + wRegion + "' order by IE_NAME ";
			OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
			conn1.Open();
			OracleDataReader reader = myOracleCommand.ExecuteReader();
			Response.Write("<table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
			Response.Write("<tr>");
			Response.Write("<td width='100%' colspan='7'>");
			Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion_Desc + "</font><br></p>");
			Response.Write("<H5 align='center'><font face='Verdana'>INTERACTIVE AUTOMATIC CALL DESK HELPLINE NO. 1800 425 7000 (TOLL FREE)</font><br></p>");
			Response.Write("<H5 align='center'><font face='Verdana'>Inspection Engineers & Their Controllings Contact Information</font><br></p>");
			Response.Write("</td>");
			Response.Write("</tr>");
			Response.Write("<tr>");
			Response.Write("<th width='05%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
			Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>IE Name</font></b></th>");
			Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Mobile No.</font></b></th>");
			Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>IE Email</font></b></th>");
			Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>CO Name</font></b></th>");
			Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>CO Mobile No.</font></b></th>");
			Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>CO Email</font></b></th>");
			Response.Write("</tr></font>");
			while (reader.Read())
			{
				wSno = wSno + 1;
				Response.Write("<tr>");
				Response.Write("<td width='05%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
				Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
				Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_PHONE_NO"]); Response.Write("</td>");
				Response.Write("<td width='15%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_EMAIL"]); Response.Write("</td>");
				Response.Write("<td width='20%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CO_NAME"]); Response.Write("</td>");
				Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CO_PHONE_NO"]); Response.Write("</td>");
				Response.Write("<td width='15%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CO_EMAIL"]); Response.Write("</td>");
				Response.Write("</tr>");
			}
			conn1.Close();
			conn1.Dispose();
			if (wRegion == "N")
			{
				Response.Write("<tr>");
				Response.Write("<td width='20%' valign='top' align='center' colspan=7> <font size='1' face='Verdana'>"); Response.Write("SBU Head,GGM & GM Contact Information"); Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='20%' valign='top' align='center' colspan=7> <font size='1' face='Verdana'>"); Response.Write("1. Sh. S Sridhar (GM-I/SBU Head/NR)<BR><IMG height=20 src='/RBS/images/icon_tel.gif' width='20' align='absMiddle' border='0'>011-22402502<br><b><IMG height=20 src='/RBS/images/icon_mail.gif' width='20' align='absMiddle' border='0'><A href='mailto:sbu.ninsp@rites.com'>sbu.ninsp@rites.com</a>"); Response.Write("</b></td>");
				Response.Write("</tr>");
				//				Response.Write("<tr>");
				//				Response.Write("<td width='20%' valign='top' align='center' colspan=7> <font size='1' face='Verdana'>");Response.Write("2. Sh. KAMAL MOHAN (GM-I/NR)<BR><IMG height=20 src='http://www.rites.com/web/images/stories/icon_tel.gif' width='20' align='absMiddle' border='0'></b> 011-22402503 <br><b><IMG height=20 src='http://www.rites.com/web/images/stories/icon_mail.gif' width='20' align='absMiddle' border='0'><A href='mailto:kamal.rites@rites.com'>kamal.rites@rites.com</a>");Response.Write("</b></td>");
				//				Response.Write("</tr>");


			}
			else if (wRegion == "W")
			{
				Response.Write("<tr>");
				Response.Write("<td width='20%' valign='top' align='center' colspan=7> <font size='2' face='Verdana'><b><u>"); Response.Write("SBU Head,GGM & GM Contact Information"); Response.Write("</u></b></td>");
				Response.Write("</tr>");
				//				Response.Write("<tr>");
				//				Response.Write("<td width='20%' valign='top' align='center' colspan=7> <font size='1' face='Verdana'><b>");Response.Write("1. Sh. Pradeep Kumar (GM-I/SBU Head/WR)<BR><IMG height=20 src='http://www.rites.com/web/images/stories/icon_tel.gif' width='20' align='absMiddle' border='0'> 022-22016621<br><IMG height=20 src='http://www.rites.com/web/images/stories/icon_mail.gif' width='20' align='absMiddle' border='0'><A href='mailto:pradeepkumar@rites.com'>pradeepkumar@rites.com</a>");Response.Write("</b></td>");
				//				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='20%' valign='top' align='center' colspan=7> <font size='1' face='Verdana'><b>"); Response.Write("1. Sh. P V KOHADE (GM-I/SBU Head/WR)<BR><IMG height=20 src='/RBS/images/icon_mail.gif' width='20' align='absMiddle' border='0'><A href='mailto:sbu.winsp@rites.com'>sbu.winsp@rites.com</a>"); Response.Write("</b></td>");
				Response.Write("</tr>");
				//				Response.Write("<tr>");
				//				Response.Write("<td width='20%' valign='top' align='center' colspan=7> <font size='1' face='Verdana'><b>");Response.Write("2. Sh. Sanjay Tyagi (GM-I/M/WR)<BR><IMG height=20 src='http://www.rites.com/web/images/stories/icon_tel.gif' width='20' align='absMiddle' border='0'> 022-22017434 <br><IMG height=20 src='http://www.rites.com/web/images/stories/icon_mail.gif' width='20' align='absMiddle' border='0'><A href='mailto:sanjay@rites.com'>sandeepjain@rites.com</a>");Response.Write("</b></td>");
				//				Response.Write("</tr>");

			}
			else if (wRegion == "E")
			{
				Response.Write("<tr>");
				Response.Write("<td width='20%' valign='top' align='center' colspan=7> <font size='2' face='Verdana'><b><u>"); Response.Write("SBU Head,GGM & GM Contact Information"); Response.Write("</u></b></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='20%' valign='top' align='center' colspan=7> <font size='1' face='Verdana'><b>"); Response.Write("1. Sh. RAJESH RAHEJA (AGM-I/SBU Head/ER)<BR><IMG height=20 src='/RBS/images/icon_tel.gif' width='20' align='absMiddle' border='0'> 033-22348912<br><IMG height=20 src='/RBS/images/icon_mail.gif' width='20' align='absMiddle' border='0'><A href='mailto:sbu.einsp@rites.com'>sbu.einsp@rites.com</a>"); Response.Write("</b></td>");
				Response.Write("</tr>");

			}
			else if (wRegion == "S")
			{
				Response.Write("<tr>");
				Response.Write("<td width='20%' valign='top' align='center' colspan=7> <font size='2' face='Verdana'><b><u>"); Response.Write("SBU Head,GGM & GM Contact Information"); Response.Write("</u></b></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='20%' valign='top' align='center' colspan=7> <font size='1' face='Verdana'><b>"); Response.Write("1. Sh. K Gopal (GM-I/SBU Head/SR)<BR><IMG height=20 src='/RBS/images/icon_tel.gif' width='20' align='absMiddle' border='0'> 044-28292837<br><IMG height=20 src='/RBS/images/icon_mail.gif' width='20' align='absMiddle' border='0'><A href='mailto:sbu.sinsp@rites.com'>sbu.sinsp@rites.com</a>"); Response.Write("</b></td>");
				Response.Write("</tr>");

			}
			else if (wRegion == "C")
			{
				Response.Write("<tr>");
				Response.Write("<td width='20%' valign='top' align='center' colspan=7> <font size='2' face='Verdana'><b><u>"); Response.Write("SBU Head,GGM & GM Contact Information"); Response.Write("</u></b></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='20%' valign='top' align='center' colspan=7> <font size='1' face='Verdana'><b>"); Response.Write("1. Sh. H. S. NAYAK (GM-I/SBU Head/CR)<BR><IMG height=20 src='/RBS/images/icon_tel.gif' width='20' align='absMiddle' border='0'> 0788-2227304<br><IMG height=20 src='/RBS/images/icon_mail.gif' width='20' align='absMiddle' border='0'><A href='mailto:sbu.cinsp@rites.com'>sbu.cinsp@rites.com</a>"); Response.Write("</b></td>");
				Response.Write("</tr>");

			}
			Response.Write("<tr><td colspan=7 valign='top' align='center'><INPUT id='Button1' onclick='history.go(-1)' type='button' value='Go Back' name='Button1'></td></tr>");
			Response.Write("</table>");
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}
		#endregion
	}
}