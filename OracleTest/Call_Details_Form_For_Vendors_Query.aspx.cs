using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Call_Details_Form_For_Vendors_Query
{
	public partial class Call_Details_Form_For_Vendors_Query : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		static string wDtFr;
		static string wDtTo;
		static string wRegion;
		static string wRgn_Name;
		string wVendor;
		string wSortKey;
		string wSortHdr;
		int wCallCtr;
		private string wColour;
		protected System.Web.UI.WebControls.TextBox txtPODT;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtPONO;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.DropDownList lstClientType;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList lstBPO_Rly;
		protected System.Web.UI.WebControls.Button Submit;
		protected System.Web.UI.WebControls.Panel Panel_1;
		protected System.Web.UI.WebControls.Label Label1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Submit.Attributes.Add("OnClick", "JavaScript:validate();");
			if (!(IsPostBack))
			{
				ListItem lst = new ListItem();
				lst.Text = "";
				lst.Value = "";
				lstClientType.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "Railways";
				lst.Value = "R";
				lstClientType.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "Private";
				lst.Value = "P";
				lstClientType.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "PSU";
				lst.Value = "U";
				lstClientType.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "State Govt.";
				lst.Value = "S";
				lstClientType.Items.Add(lst);
				lst = new ListItem();
				lst.Text = "Foreign Railways";
				lst.Value = "F";
				lstClientType.Items.Add(lst);
			}
			Panel_1.Visible = true;

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
			this.lstClientType.SelectedIndexChanged += new System.EventHandler(this.lstClientType_SelectedIndexChanged);
			this.Submit.Click += new System.EventHandler(this.Submit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lstClientType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fill_Rly();
		}

		public void fill_Rly()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			lstBPO_Rly.Items.Clear();
			DataSet dsP = new DataSet();
			string str = "";
			if (lstClientType.SelectedValue == "R")
			{
				str = "Select RLY_CD from T91_RAILWAYS Order by RLY_CD";
			}
			else
			{
				str = "Select distinct(upper(trim(BPO_RLY))) RLY_CD from T12_BILL_PAYING_OFFICER WHERE BPO_TYPE='" + lstClientType.SelectedValue + "' Order by RLY_CD";
			}
			try
			{
				OracleDataAdapter da = new OracleDataAdapter(str, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str, conn1);
				ListItem lst;
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				conn1.Close();
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					lst = new ListItem();
					lst.Text = dsP.Tables[0].Rows[i]["RLY_CD"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["RLY_CD"].ToString();
					lstBPO_Rly.Items.Add(lst);
				}

			}
			catch (Exception ex)
			{
				string str1;
				str1 = ex.Message;
				string str2 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str2));
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}
		}

		private void Submit_Click(object sender, System.EventArgs e)
		{
			Panel_1.Visible = false;
			call_details();
		}
		void call_details()
		{
			wCallCtr = 0;
			//			wDtFr=Request.Params["pDtFr"].ToString(); 
			//			wDtTo=Request.Params["pDtTo"].ToString(); 
			//			wRegion=Request.Params["pRegion"].ToString();
			//			wSortKey=Request.Params["pSortKey"].ToString();

			if (wRegion == "N")
			{ wRgn_Name = "NORTHERN REGION"; }
			else if (wRegion == "W")
			{ wRgn_Name = "WESTERN REGION"; }
			else if (wRegion == "E")
			{ wRgn_Name = "EASTERN REGION"; }
			else if (wRegion == "S")
			{ wRgn_Name = "SOUTHERN REGION"; }
			else if (wRegion == "C")
			{ wRgn_Name = "CENTRAL REGION"; }
			else
			{ wRgn_Name = "--x--"; }


			string sql = "Select trim(T051.VEND_NAME)||nvl2(trim(T03.CITY),','||trim(T03.CITY),'') VENDOR,trim(T052.VEND_NAME)||nvl2(trim(T032.CITY),','||trim(T032.CITY),'') MANUFACTURER,T051.VEND_CD VEND_CD,T052.VEND_CD MFG_CD," +
				"(T06.CONSIGNEE_DESIG||' '||T06.CONSIGNEE_FIRM) CONSIGNEE,T18.ITEM_DESC_PO,to_char(T17.CALL_MARK_DT,'dd/mm/yyyy') CALL_MARK_DT," +
				"T09.IE_NAME,T09.IE_PHONE_NO,T13.PO_NO,to_char(T13.PO_DT,'dd/mm/yyyy')PO_DATE,T17.CASE_NO,T17.REMARKS REMARK, " +
				"trim(T21.CALL_STATUS_DESC)||decode(T21.CALL_STATUS_CD,'A',nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')',''),'R',nvl2(T17.BK_NO,' (BookSet-'||T17.BK_NO||'/'||T17.SET_NO||')',''),'C',' on '||to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy'))||decode(T17.CALL_CANCEL_STATUS,'N',' (Non Chargeable)','C',' (Chargeable)','') CALL_STATUS,T21.CALL_STATUS_COLOR COLOUR," +
				"T052.VEND_CONTACT_PER_1 MFG_PERS,(T052.VEND_CONTACT_TEL_1) MFG_PHONE,T17.CALL_SNO," +
				"(select count(*) from T18_CALL_DETAILS A WHERE A.CASE_NO=T18.CASE_NO AND A.CALL_RECV_DT=T18.CALL_RECV_DT AND A.CALL_SNO=T18.CALL_SNO) COUNT, nvl2(T08.CO_PHONE_NO,trim(T08.CO_NAME)||' (Mob: '||CO_PHONE_NO||')',T08.CO_NAME)CO_NAME " +
				"From T05_VENDOR T051,T06_CONSIGNEE T06,T17_CALL_REGISTER T17,T18_CALL_DETAILS T18,T13_PO_MASTER T13,T09_IE T09,T05_VENDOR T052, T03_CITY T03, T03_CITY T032, T08_IE_CONTROLL_OFFICER T08,T21_CALL_STATUS_CODES T21 " +
				"Where  T051.VEND_CD=T13.VEND_CD and  T06.CONSIGNEE_CD(+)=T13.PURCHASER_CD and  T13.CASE_NO=T17.CASE_NO and T17.CALL_STATUS=T21.CALL_STATUS_CD and " +
				"T09.IE_CD =T17.IE_CD  and  T18.CASE_NO=T17.CASE_NO and T18.CALL_RECV_DT=T17.CALL_RECV_DT and T18.CALL_SNO=T17.CALL_SNO and T17.MFG_CD=T052.VEND_CD(+) and " +
				"(T13.L5NO_PO='" + txtPONO.Text.Trim() + "' and PO_DT=to_date('" + txtPODT.Text.Trim() + "','dd/mm/yyyy') and RLY_NONRLY='" + lstClientType.SelectedValue + "' and RLY_CD='" + lstBPO_Rly.SelectedValue + "') and " +
				"T18.ITEM_SRNO_PO=(Select min(B.ITEM_SRNO_PO) from T18_CALL_DETAILS B where B.CASE_NO=T18.CASE_NO AND B.CALL_RECV_DT=T18.CALL_RECV_DT AND B.CALL_SNO=T18.CALL_SNO) and  " +
				"T03.CITY_CD=T051.VEND_CITY_CD and T032.CITY_CD(+)=T052.VEND_CITY_CD and T08.CO_CD(+)=T09.IE_CO_CD ";

			//			if (wSortKey=="V") 
			//			{
			//					sql = sql+"Order by T051.VEND_NAME,T17.CALL_MARK_DT";
			//				wSortHdr="Report Sorted on Vendor Name";
			//			}
			//			else 
			//			{
			sql = sql + "Order by T17.CALL_MARK_DT,T051.VEND_NAME";
			wSortHdr = "Report Sorted on Call Date";
			//			}
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn1);
				conn1.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse' bordercolor='#111111' width='130%'>");
				Response.Write("<tr>"); Response.Write("<td width='100%' bgcolor='#FFFFCC' colspan='16'>");
				Response.Write("<p align='center'><font face='Verdana' color='#3333FF'><b>");
				Response.Write("<font size='4'>CALLS  STATUS </b></font><br>");
				Response.Write("<font size='2'>" + wSortHdr + "</font></p>");
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr bgcolor='#FFCCCC'>");
				Response.Write("<th width='4%' valign='top'><b><font size='1' face='Verdana'>SNO</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>VENDOR NAME</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>PURCHASER</font></b></th>");
				Response.Write("<th width='13%' valign='top'><b><font size='1' face='Verdana'>ITEM</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>CALL DATE</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>ENGINEER DEPUTED</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>ENGINEER CONTACT NO.</font></b></th>");
				Response.Write("<th width='8%' valign='top'><b><font size='1' face='Verdana'>PONO</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>PO DATE</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>CASE NO</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>STATUS</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>CONTACT PERSON</font></b></th>");
				Response.Write("<th width='7%' valign='top'><b><font size='1' face='Verdana'>CONTACT PERSON PHONE NO.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>CALL SERIAL NO.</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>CONTROLLING MANAGER</font></b></th>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>REMARKS</font></b></th></tr>");
				Response.Write("</tr></font>");
				while (reader.Read())
				{
					wCallCtr = wCallCtr + 1;
					wVendor = "";
					Response.Write("<tr>");
					Response.Write("<td width='4%' valign='top'> <font size='1' face='Verdana'>" + wCallCtr); Response.Write("</td>");
					if (Convert.ToInt32(reader["VEND_CD"]) == Convert.ToInt64(reader["MFG_CD"]))
					{ wVendor = Convert.ToString(reader["VENDOR"]); }
					else
					{ wVendor = Convert.ToString(reader["VENDOR"]) + " <font color='#FF00CC'>At<font color='#3333FF'> " + Convert.ToString(reader["MANUFACTURER"]); }
					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>" + wVendor); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["CONSIGNEE"]); Response.Write("</td>");
					if (Convert.ToInt16(reader["COUNT"]) > 1)
					{ Response.Write("<td width='13%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC_PO"] + "<font color='#FF00CC'> and more items as per call"); Response.Write("</td>"); }
					else
					{ Response.Write("<td width='13%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["ITEM_DESC_PO"]); Response.Write("</td>"); }
					Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_MARK_DT"]); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_PHONE_NO"]); Response.Write("</td>");
					Response.Write("<td width='8%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_NO"]); Response.Write("</td>");
					Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["PO_DATE"]); Response.Write("</td>");
					Response.Write("<td width='6%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["CASE_NO"]); Response.Write("</td>");
					wColour = "'" + Convert.ToString(reader["COLOUR"]) + "'";
					Response.Write("<td width='5%' valign='top'> <font size='1' face='Verdana' color=" + wColour + ">"); Response.Write(reader["CALL_STATUS"]); Response.Write("</font></td>");
					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["MFG_PERS"]); Response.Write("</td>");
					Response.Write("<td width='7%' valign='top'> <font size='1' face='Verdana'>"); Response.Write(reader["MFG_PHONE"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CALL_SNO"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["CO_NAME"]); Response.Write("</td>");
					Response.Write("<td width='5%' valign='top' align='left'> <font size='1' face='Verdana'>"); Response.Write(reader["REMARK"]); Response.Write("</td>");
					Response.Write("</tr>");
				};
				Response.Write("</table>");
				Response.Write("<p align='center'><font face='Verdana'><a href='javascript:history.go(-1);'>Go Back </a><font></p>");
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}

		}

	}
}