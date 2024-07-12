using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.IO;
using RBS.Reports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Oracle.ManagedDataAccess.Client;

namespace RBS.Reports
{
	/// <summary>
	/// Summary description for rptOutstanding.
	/// </summary>
	public class rptOutstanding : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.Panel Panel_1;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.Panel Panel_2;
		OracleConnection conn1= new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		string wRegion,wP_DtFr,wP_DtTo,wC_DtFr,wYr;
		protected System.Web.UI.WebControls.Label lbl_01;
		protected System.Web.UI.WebControls.Label lbl_02;
		protected System.Web.UI.WebControls.DropDownList lstRegionCd;
		protected System.Web.UI.WebControls.RadioButton btnClient;
		protected System.Web.UI.WebControls.RadioButton btnBPO;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.CheckBox chkOutSum;
		protected System.Web.UI.WebControls.RadioButton rdbFourRegions;
		protected System.Web.UI.WebControls.RadioButton rdbAllRegion;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.RadioButton RdbIE;
		protected System.Web.UI.WebControls.RadioButton RdbCM;
		protected System.Web.UI.WebControls.RadioButton Rdb_Cl;
		protected System.Web.UI.WebControls.TextBox frmDt;
		protected System.Web.UI.WebControls.TextBox toDt;
		protected System.Web.UI.WebControls.RadioButton Rdb_SO;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSubmit.Attributes.Add("OnClick","JavaScript:validate();");

			if (!(IsPostBack))
			{
				btnPrint.Visible=true;
				btnCancel.Visible=true;
				lstRegionCd.SelectedValue=Session["Region"].ToString();
//				lstRegionCd.Items.Remove(lstRegionCd.SelectedItem);
				if(Convert.ToString(Request.Params["action"].Trim())=="S")
				{
					lbl_01.Text="Outstanding Statement as on ----->";
					if (Session["Region"].ToString()=="N") {lbl_02.Text="Outstanding of Northern Region on Other Regions ";}
					else if (Session["Region"].ToString()=="E") {lbl_02.Text="Outstanding of Eastern Region on Other Regions ";}
					else if (Session["Region"].ToString()=="W") {lbl_02.Text="Outstanding of Western Region on Other Regions ";}
					else if (Session["Region"].ToString()=="S") {lbl_02.Text="Outstanding of Southern Region on Other Regions ";}
					else {lbl_02.Text="Outstanding of Bhilai Region on Other Regions ";}
					Label1.Text="CLIENT WISE OUTSTANDING OF ONE REGION OVER OTHER";
				}
				else if(Convert.ToString(Request.Params["action"].Trim())=="F")
				{
					Label1.Text="CLIENT WISE OUTSTANDING";
				}
				else if (Convert.ToString(Request.Params["action"].Trim())=="P")
				{
					Label1.Text="PERIODIC BREAKUP OF CLIENT WISE OUTSTANDING";
				}
				else if (Convert.ToString(Request.Params["action"].Trim())=="A")
				{
					Label1.Text="AGE WISE BREAKUP OF CLIENT WISE OUTSTANDING STATEMENT FOR 2008-09 AUDIT";
				}
				else if (Convert.ToString(Request.Params["action"].Trim())=="R")
				{
					Label1.Text="REGION WISE COMPARISON OF OUTSTANDING";
				}
				else if (Convert.ToString(Request.Params["action"].Trim())=="X")
				{
					Label1.Text="OUTSTANDING OF ONE REGION OVER OTHER";
					//lstRegionCd.Items.Insert('A',"ALL");		
					ListItem lst = new ListItem();
					lst = new ListItem(); 
					lst.Text = "ALL REGIONS"; 
					lst.Value = "A"; 
					lstRegionCd.Items.Add(lst);
				}
			}
		}
		private void btnSubmit_Click(object sender, System.EventArgs e)
			{
				Panel_2.Visible=false;
				Panel_1.Visible=true;
				wRegion="";
				wYr="";
				if (Session["Region"].ToString()=="N")  {wRegion="NORTHERN REGION";}
				else if (Session["Region"].ToString()=="S") {wRegion="SOUTHERN REGION";}
				else if (Session["Region"].ToString()=="E") {wRegion="EASTERN REGION";}
				else if (Session["Region"].ToString()=="W") {wRegion="WESTERN REGION";}
				else if (Session["Region"].ToString()=="C") {wRegion="CENTRAL REGION";}
//--------------Find the Previous Financial Year date Range and Current Start Date----//
				wP_DtFr="01/04/2008";
				if (Convert.ToInt16(txtDate.Text.Substring(3,2)) > 3)	
					{wYr=txtDate.Text.Substring(6,4);}
				else
					{wYr=Convert.ToString(Convert.ToInt16(txtDate.Text.Substring(6,4))-1);}
				wP_DtTo="31/03/"+wYr;
				wC_DtFr="01/04/"+wYr;
//----------------------- xxxxxxxxxxx -----------------------------------------------//
				if(Convert.ToString(Request.Params["action"].Trim())=="F")
				{
					if(RdbIE.Checked==true)
					{
						Client_Wise_Outstanding();
					}
					else
					{
						Client_Wise_Outstanding_sortout();
					}
				}
				else if (Convert.ToString(Request.Params["action"].Trim())=="P")
				{
					Periodic_Outstanding_Client_Wise();
				}
				else if (Convert.ToString(Request.Params["action"].Trim())=="A")
				{
					Audit_Periodic_OS_Client_Wise();
				}
				else if (Convert.ToString(Request.Params["action"].Trim())=="R")
				{
					if(Rdb_Cl.Checked==true)
					{
						Region_Wise_Comparision_of_Outstanding();
					}
					else
					{
						Region_Wise_Comparision_of_Outstanding_sortout();
					}
					
				}
				else if (Convert.ToString(Request.Params["action"].Trim())=="X")
				{
					OtherRegion_Outstanding();
				}
				else if(Convert.ToString(Request.Params["action"].Trim())=="FNR")
				{
					rly_outs_chased_by_nr();
				}
				else if(Convert.ToString(Request.Params["action"].Trim())=="REF")
				{
					re_oustanding_au_wise();
				}
				else
				{
					if (btnClient.Checked==true){Client_Wise_OtherRegion_Outstanding();}
					else {BPO_Wise_OtherRegion_Outstanding();}
				}
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
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnBack_Click);
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		//===========RE OUTSTANDING AU WISE============
		void re_oustanding_au_wise()
		{
			conn1.Open();					
			OracleCommand cmd2 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual",conn1);
			string ss=Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();
			string str6="Select AU,C_R,Round(sum(OUTSTANDING_ER),0)OUTSTANDING_ER,sum(OUT_BILL_COUNT_ER) OUT_BILL_COUNT_ER,"+
				"Round(sum(OUTSTANDING_NR),0)OUTSTANDING_NR,sum(OUT_BILL_COUNT_NR) OUT_BILL_COUNT_NR,"+
				"Round(sum(OUTSTANDING_SR),0)OUTSTANDING_SR,sum(OUT_BILL_COUNT_SR) OUT_BILL_COUNT_SR,"+
				"Round(sum(OUTSTANDING_WR),0)OUTSTANDING_WR,sum(OUT_BILL_COUNT_WR) OUT_BILL_COUNT_WR,"+
				"Round(sum(OUTSTANDING),0)OUTSTANDING,Round(sum(TOT_SUSPENSE),0)TOT_SUSPENSE,"+
				"Round(sum(ACTUAL_SUSPENSE),0)ACTUAL_SUSPENSE,sum(OUT_BILL_COUNT) OUT_BILL_COUNT From "+ 
				"(Select V22.AU||'-'||AUDESC AU,DECODE(BPO_REGION,'N','NR','E','ER','W','WR','S','SR','BLANK') C_R,"+
				"nvl(AMOUNT_OUTSTANDING,0) OUTSTANDING_ER,1 OUT_BILL_COUNT_ER,"+
				"0 OUTSTANDING_NR,0 OUT_BILL_COUNT_NR,0 OUTSTANDING_SR,0 OUT_BILL_COUNT_SR,"+
				"0 OUTSTANDING_WR,0 OUT_BILL_COUNT_WR,0 OUTSTANDING,"+
				"0 TOT_SUSPENSE,0 ACTUAL_SUSPENSE,0 OUT_BILL_COUNT From V22B_OUTSTANDING_BILLS V22, AU_CRIS A Where V22.AU=A.AU AND (AMOUNT_OUTSTANDING > 0) and BILL_DT  <= to_date('"+txtDate.Text+"','dd/mm/yyyy') and BPO_RLY IN ('RE') AND BPO_TYPE='R' AND Substr(bill_no,1,1)='E' "+
				"UNION ALL "+
				"Select V22.AU||'-'||AUDESC AU,"+
				"DECODE(BPO_REGION,'N','NR','E','ER','W','WR','S','SR','BLANK') C_R,"+
				"0 OUTSTANDING_ER,0 OUT_BILL_COUNT_ER,"+
				"nvl(AMOUNT_OUTSTANDING,0) OUTSTANDING_NR,1 OUT_BILL_COUNT_NR,0 OUTSTANDING_SR,0 OUT_BILL_COUNT_SR,"+
				"0 OUTSTANDING_WR,0 OUT_BILL_COUNT_WR,0 OUTSTANDING,"+
				"0 TOT_SUSPENSE,0 ACTUAL_SUSPENSE,0 OUT_BILL_COUNT From V22B_OUTSTANDING_BILLS V22, AU_CRIS A Where V22.AU=A.AU AND (AMOUNT_OUTSTANDING >0) and BILL_DT  <= to_date('"+txtDate.Text+"','dd/mm/yyyy') and BPO_RLY IN ('RE','CORE') AND BPO_TYPE='R' AND Substr(bill_no,1,1)='N' "+
				"UNION ALL "+
				"Select V22.AU||'-'||AUDESC AU,"+
				"DECODE(BPO_REGION,'N','NR','E','ER','W','WR','S','SR','BLANK') C_R,"+
				"0 OUTSTANDING_ER,0 OUT_BILL_COUNT_ER,"+
				"0 OUTSTANDING_NR,0 OUT_BILL_COUNT_NR,nvl(AMOUNT_OUTSTANDING,0) OUTSTANDING_SR,1 OUT_BILL_COUNT_SR,"+
				"0 OUTSTANDING_WR,0 OUT_BILL_COUNT_WR,0 OUTSTANDING,"+
				"0 TOT_SUSPENSE,0 ACTUAL_SUSPENSE,0 OUT_BILL_COUNT From V22B_OUTSTANDING_BILLS V22, AU_CRIS A Where V22.AU=A.AU AND (AMOUNT_OUTSTANDING > 0) and BILL_DT  <= to_date('"+txtDate.Text+"','dd/mm/yyyy') and BPO_RLY IN ('RE','CORE') AND BPO_TYPE='R' AND Substr(bill_no,1,1)='S' "+
				"UNION ALL "+
				"Select V22.AU||'-'||AUDESC AU,"+
				"DECODE(BPO_REGION,'N','NR','E','ER','W','WR','S','SR','BLANK') C_R,"+
				"0 OUTSTANDING_ER,0 OUT_BILL_COUNT_ER,"+
				"0 OUTSTANDING_NR,0 OUT_BILL_COUNT_NR,0 OUTSTANDING_SR,0 OUT_BILL_COUNT_SR,"+
				"nvl(AMOUNT_OUTSTANDING,0) OUTSTANDING_WR,1 OUT_BILL_COUNT_WR,0 OUTSTANDING,"+
				"0 TOT_SUSPENSE,0 ACTUAL_SUSPENSE,0 OUT_BILL_COUNT From V22B_OUTSTANDING_BILLS V22, AU_CRIS A Where V22.AU=A.AU AND (AMOUNT_OUTSTANDING > 0) and BILL_DT  <= to_date('"+txtDate.Text+"','dd/mm/yyyy') and BPO_RLY IN ('RE','CORE') AND BPO_TYPE='R' AND Substr(bill_no,1,1)='W' "+
				"UNION ALL "+
				"Select V22.AU||'-'||AUDESC AU,"+
				"DECODE(BPO_REGION,'N','NR','E','ER','W','WR','S','SR','BLANK') C_R,"+
				"0 OUTSTANDING_ER,0 OUT_BILL_COUNT_ER,"+
				"0 OUTSTANDING_NR,0 OUT_BILL_COUNT_NR,0 OUTSTANDING_SR,0 OUT_BILL_COUNT_SR,"+
				"0 OUTSTANDING_WR,0 OUT_BILL_COUNT_WR,nvl(AMOUNT_OUTSTANDING,0) OUTSTANDING,"+
				"0 TOT_SUSPENSE,0 ACTUAL_SUSPENSE,1 OUT_BILL_COUNT From V22B_OUTSTANDING_BILLS V22, AU_CRIS A Where V22.AU=A.AU AND (AMOUNT_OUTSTANDING > 0) and BILL_DT  <= to_date('"+txtDate.Text+"','dd/mm/yyyy') and BPO_RLY IN ('RE','CORE') AND BPO_TYPE='R' "+
				"Union All "+
				"Select T12.AU||'-'||AUDESC AU,"+
				"DECODE(T12.BPO_REGION,'N','NR','E','ER','W','WR','S','SR','BLANK') C_R,"+
				"0 OUTSTANDING_ER,0 OUT_BILL_COUNT_ER,"+
				"0 OUTSTANDING_NR,0 OUT_BILL_COUNT_NR,0 OUTSTANDING_SR,0 OUT_BILL_COUNT_SR,"+
				"0 OUTSTANDING_WR,0 OUT_BILL_COUNT_WR,0 OUTSTANDING,nvl(T25.SUSPENSE_AMT,0) TOT_SUSPENSE,0 ACTUAL_SUSPENSE,0 OUT_BILL_COUNT From T25_RV_DETAILS T25,T12_BILL_PAYING_OFFICER T12, AU_CRIS A Where T12.AU=A.AU AND (T25.ACC_CD not in (2709,2210,2212)) and  T12.BPO_RLY IN ('RE','CORE') AND T12.BPO_TYPE='R' and nvl(T25.BPO_CD,'00000')=T12.BPO_CD and nvl(T25.SUSPENSE_AMT,0) <> 0 "+
				"Union All "+ 
				"Select T12.AU||'-'||AUDESC AU,"+
				"DECODE(T12.BPO_REGION,'N','NR','E','ER','W','WR','S','SR','BLANK') C_R,"+
				"0 OUTSTANDING_ER,0 OUT_BILL_COUNT_ER,"+
				"0 OUTSTANDING_NR,0 OUT_BILL_COUNT_NR,0 OUTSTANDING_SR,0 OUT_BILL_COUNT_SR,"+
				"0 OUTSTANDING_WR,0 OUT_BILL_COUNT_WR,0 OUTSTANDING,0 TOT_SUSPENSE,nvl(T25.SUSPENSE_AMT,0) ACTUAL_SUSPENSE,0 OUT_BILL_COUNT From T24_RV T24,T25_RV_DETAILS T25,T12_BILL_PAYING_OFFICER T12, AU_CRIS A Where T12.AU=A.AU AND (T25.ACC_CD not in (2709,2210,2212)) and T12.BPO_RLY IN ('RE','CORE') AND T12.BPO_TYPE='R' and nvl(T25.BPO_CD,'00000')=T12.BPO_CD and nvl(T25.SUSPENSE_AMT,0) <> 0 and T24.VCHR_NO=T25.VCHR_NO and ((T25.CHQ_DT <= to_date('"+txtDate.Text+"','dd/mm/yyyy')) and (nvl(T24.VCHR_DT,'01-Jan-01')<=to_date('"+txtDate.Text+"','dd/mm/yyyy')+7)) "+
				") Group By AU,C_R order by C_R";

			OracleCommand cmd6 = new OracleCommand(str6, conn1);
			conn1.Open();
			OracleDataReader reader6=cmd6.ExecuteReader();
			double t_gt1=0,t_gt2=0,t_gt3=0,t_gt4=0,t_gt5=0,t_gt6=0,t_gt7=0,t_gt8=0,t_gt9=0,t_gt10=0,t_gt11=0,t_gt12=0;
			double t_sgt1=0,t_sgt2=0,t_sgt3=0,t_sgt4=0,t_sgt5=0,t_sgt6=0,t_sgt7=0,t_sgt8=0,t_sgt9=0,t_sgt10=0,t_sgt11=0,t_sgt12=0;
			string wBPO_Type="";


			Response.Write("<html><body>");
			Response.Write("<br><br><p align=Center><font size='2' face='Verdana'><b><u>RE Outstanding Statement AU Wise as on : "+ss+"</u></b></font></p></br><br>");
			Response.Write("<p align=Left><font size='2' face='Verdana'><b></b></font></p>");
			Response.Write("<table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='90%'>");
			Response.Write("</tr></font>");
			Response.Write("<tr>");
			Response.Write("<th width='5%' valign='top' align='center' rowspan='2'><b><font size='2' face='Verdana'>AU</font></b></th>");
			Response.Write("<th width='5%' valign='top' align='center' rowspan='2'><b><font size='2' face='Verdana'>Chased by Region</font></b></th>");
			Response.Write("<th width='15%' valign='top' align='center' colspan='2'><b><font size='2' face='Verdana'>Eastern Region</font></b></th>");
			Response.Write("<th width='15%' valign='top' align='center' colspan='2'><b><font size='2' face='Verdana'>Northern Region</font></b></th>");
			Response.Write("<th width='15%' valign='top' align='center' colspan='2'><b><font size='2' face='Verdana'>Southern Region</font></b></th>");
			Response.Write("<th width='15%' valign='top' align='center' colspan='2'><b><font size='2' face='Verdana'>Western Region</font></b></th>");
			Response.Write("<th width='15%' valign='top' align='center' colspan='2'><b><font size='2' face='Verdana'>Total for all Regions</font></b></th>");
			Response.Write("<th width='15%' valign='top' align='center' colspan='2'><b><font size='2' face='Verdana'>Suspense</font></b></th>");
			Response.Write("</tr></font>");
			Response.Write("<tr>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>Outstanding of "+txtDate.Text+" as on "+ss+"</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>No. of bills Outstanding</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>Outstanding of "+txtDate.Text+" as on "+ss+"</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>No. of bills Outstanding</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>Outstanding of "+txtDate.Text+" as on "+ss+"</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>No. of bills Outstanding</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>Outstanding of "+txtDate.Text+" as on "+ss+"</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>No. of bills Outstanding</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>Outstanding of "+txtDate.Text+" as on "+ss+"</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>No. of bills Outstanding</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>Suspense of "+txtDate.Text+" as it stands today</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>Total Suspense as on Today</font></b></td>");
			Response.Write("</tr></font>");

			while(reader6.Read())
			{
				if (reader6["C_R"].ToString() != wBPO_Type)
				{
					if (wBPO_Type.ToString() !="")
					{
						Response.Write("<tr bgColor='#ccccff'>");
						Response.Write("<td width='5%' valign='top' align='center'><b><font size='2' face='Verdana'></font></b></td>");
						Response.Write("<td width='5%' valign='top' align='center'><b><font size='2' face='Verdana'>Sub Total</font></b></td>");
						Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_sgt1+"</font></b></td>");
						Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_sgt2+"</font></b></td>");
						Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_sgt3+"</font></b></td>");
						Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_sgt4+"</font></b></td>");
						Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_sgt5+"</font></b></td>");
						Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_sgt6+"</font></b></td>");
						Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_sgt7+"</font></b></td>");
						Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_sgt8+"</font></b></td>");
						Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_sgt9+"</font></b></td>");
						Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_sgt10+"</font></b></td>");
						Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_sgt11+"</font></b></td>");
						Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_sgt12+"</font></b></td>");
						Response.Write("</tr>");
						t_gt1=t_gt1+t_sgt1;
						t_gt2=t_gt2+t_sgt2;
						t_gt3=t_gt3+t_sgt3;
						t_gt4=t_gt4+t_sgt4;
						t_gt5=t_gt5+t_sgt5;
						t_gt6=t_gt6+t_sgt6;
						t_gt7=t_gt7+t_sgt7;
						t_gt8=t_gt8+t_sgt8;
						t_gt9=t_gt9+t_sgt9;
						t_gt10=t_gt10+t_sgt10;
						t_gt11=t_gt11+t_sgt11;
						t_gt12=t_gt12+t_sgt12;
						t_sgt1=0;t_sgt2=0;t_sgt3=0;t_sgt4=0;t_sgt5=0;t_sgt6=0;t_sgt7=0;t_sgt8=0;t_sgt9=0;t_sgt10=0;t_sgt11=0;t_sgt12=0;					
					}
				
					wBPO_Type=reader6["C_R"].ToString();
				}
				
				Response.Write("<tr>");
				Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+reader6["AU"]+"</font></b></td>");
				Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+reader6["C_R"]+"</font></b></td>");
				Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+reader6["OUTSTANDING_ER"]+"</font></b></td>");
				Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+reader6["OUT_BILL_COUNT_ER"]+"</font></b></td>");
				Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+reader6["OUTSTANDING_NR"]+"</font></b></td>");
				Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+reader6["OUT_BILL_COUNT_NR"]+"</font></b></td>");
				Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+reader6["OUTSTANDING_SR"]+"</font></b></td>");
				Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+reader6["OUT_BILL_COUNT_SR"]+"</font></b></td>");
				Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+reader6["OUTSTANDING_WR"]+"</font></b></td>");
				Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+reader6["OUT_BILL_COUNT_WR"]+"</font></b></td>");
				Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+reader6["OUTSTANDING"]+"</font></b></td>");
				Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+reader6["OUT_BILL_COUNT"]+"</font></b></td>");
				Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+reader6["ACTUAL_SUSPENSE"]+"</font></b></td>");
				Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+reader6["TOT_SUSPENSE"]+"</font></b></td>");
				Response.Write("</tr></font>");
				t_sgt1=t_sgt1+Convert.ToDouble(reader6["OUTSTANDING_ER"]);
				t_sgt2=t_sgt2+Convert.ToDouble(reader6["OUT_BILL_COUNT_ER"]);
				t_sgt3=t_sgt3+Convert.ToDouble(reader6["OUTSTANDING_NR"]);
				t_sgt4=t_sgt4+Convert.ToDouble(reader6["OUT_BILL_COUNT_NR"]);
				t_sgt5=t_sgt5+Convert.ToDouble(reader6["OUTSTANDING_SR"]);
				t_sgt6=t_sgt6+Convert.ToDouble(reader6["OUT_BILL_COUNT_SR"]);
				t_sgt7=t_sgt7+Convert.ToDouble(reader6["OUTSTANDING_WR"]);
				t_sgt8=t_sgt8+Convert.ToDouble(reader6["OUT_BILL_COUNT_WR"]);
				t_sgt9=t_sgt9+Convert.ToDouble(reader6["OUTSTANDING"]);
				t_sgt10=t_sgt10+Convert.ToDouble(reader6["OUT_BILL_COUNT"]);
				t_sgt11=t_sgt11+Convert.ToDouble(reader6["ACTUAL_SUSPENSE"]);
				t_sgt12=t_sgt12+Convert.ToDouble(reader6["TOT_SUSPENSE"]);
				
			};
			
			Response.Write("<tr bgColor='#ccccff'>");
			Response.Write("<td width='5%' valign='top' align='center'><b><font size='2' face='Verdana'></font></b></td>");
			Response.Write("<td width='5%' valign='top' align='center'><b><font size='2' face='Verdana'>Sub Total</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_sgt1+"</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_sgt2+"</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_sgt3+"</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_sgt4+"</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_sgt5+"</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_sgt6+"</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_sgt7+"</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_sgt8+"</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_sgt9+"</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_sgt10+"</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_sgt11+"</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_sgt12+"</font></b></td>");
			Response.Write("</tr>");
			t_gt1=t_gt1+t_sgt1;
			t_gt2=t_gt2+t_sgt2;
			t_gt3=t_gt3+t_sgt3;
			t_gt4=t_gt4+t_sgt4;
			t_gt5=t_gt5+t_sgt5;
			t_gt6=t_gt6+t_sgt6;
			t_gt7=t_gt7+t_sgt7;
			t_gt8=t_gt8+t_sgt8;
			t_gt9=t_gt9+t_sgt9;
			t_gt10=t_gt10+t_sgt10;
			t_gt11=t_gt11+t_sgt11;
			t_gt12=t_gt12+t_sgt12;
			Response.Write("<tr bgColor='#ccccff'>");
			Response.Write("<td width='5%' valign='top' align='center'><b><font size='2' face='Verdana'></font></b></td>");
			Response.Write("<td width='5%' valign='top' align='center'><b><font size='2' face='Verdana'>Grand Total</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_gt1+"</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_gt2+"</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_gt3+"</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_gt4+"</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_gt5+"</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_gt6+"</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_gt7+"</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_gt8+"</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_gt9+"</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_gt10+"</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_gt11+"</font></b></td>");
			Response.Write("<td width='7.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_gt12+"</font></b></td>");
			Response.Write("</tr>");
			conn1.Close();
			Response.Write("</table>");
		}

		//===========RLY OUTSTANDING CHASED BY NR=======
		void rly_outs_chased_by_nr()
		{
			conn1.Open();					
			OracleCommand cmd2 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual",conn1);
			string ss=Convert.ToString(cmd2.ExecuteScalar());

			OracleCommand cmd1 =new OracleCommand("Select to_char(sysdate-364,'dd/mm/yyyy') from dual",conn1);
			string ss1=Convert.ToString(cmd1.ExecuteScalar());
			conn1.Close();
			int ctr =60;
			string first_page="Y";  
			string str6="Select decode(BPO_TYPE,'R','1Railway','U','2PSU','P','3Private','F','4Foreign Railway','S','5State Government','6Un-Accounted')BPO_TYPE,BPO_RLY,BPO_ORGN,AU,LO_NAME LO,Round(sum(OUTSTANDING),0)OUTSTANDING,Round(sum(TOT_SUSPENSE),0)TOT_SUSPENSE,Round(sum(ACTUAL_SUSPENSE),0)ACTUAL_SUSPENSE,sum(OUT_BILL_COUNT) OUT_BILL_COUNT, SUM(TOTAL_AMT_PASSED) TOTAL_AMT_PASSED, SUM(bill_amt) bill_amt From "+
				"("+
				"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,AU, LO_NAME,nvl(AMOUNT_OUTSTANDING,0) OUTSTANDING,0 TOT_SUSPENSE,0 ACTUAL_SUSPENSE,1 OUT_BILL_COUNT, 0 TOTAL_AMT_PASSED,0 bill_amt From V22B_OUTSTANDING_BILLS V22,T106_LO_ORGN T106, T105_LO_LOGIN T105 Where V22.BPO_TYPE=T106.ORGN_TYPE(+) AND V22.BPO_RLY=T106.ORGN_CHASED(+) AND T106.MOBILE=T105.MOBILE(+) and (SYSDATE BETWEEN LO_PER_FR AND LO_PER_TO) AND (AMOUNT_OUTSTANDING > 0 OR BILL_AMOUNT<0) and BILL_DT  <= to_date('"+txtDate.Text+"','dd/mm/yyyy') and BPO_TYPE='R' and (BPO_RLY IN ('NR','MCF','RCF','RCFR','COFMOW','NCR','NWR','DMW','DLW','NER') ) "+
				"Union All "+
				"Select T12.BPO_TYPE BPO_TYPE,nvl(T25.BPO_CD,'00000') BPO_CD,T12.BPO_RLY BPO_RLY,T12.BPO_ORGN BPO_ORGN,AU, LO_NAME,0 OUTSTANDING,nvl(T25.SUSPENSE_AMT,0) TOT_SUSPENSE,0 ACTUAL_SUSPENSE,0 OUT_BILL_COUNT, 0 TOTAL_AMT_PASSED,0 bill_amt From T25_RV_DETAILS T25,T12_BILL_PAYING_OFFICER T12,T106_LO_ORGN T106, T105_LO_LOGIN T105 Where T12.BPO_TYPE=T106.ORGN_TYPE(+) AND T12.BPO_RLY=T106.ORGN_CHASED(+) AND T106.MOBILE=T105.MOBILE(+) and (SYSDATE BETWEEN LO_PER_FR AND LO_PER_TO) AND (T25.ACC_CD not in (2709,2210,2212)) and T12.BPO_TYPE='R' and  (T12.BPO_RLY IN ('NR','MCF','RCF','RCFR','COFMOW','NCR','NWR','DMW','DLW','NER') ) and nvl(T25.BPO_CD,'00000')=T12.BPO_CD and nvl(T25.SUSPENSE_AMT,0) <> 0 "+
				"Union All "+
				"Select T12.BPO_TYPE BPO_TYPE,nvl(T25.BPO_CD,'00000') BPO_CD,T12.BPO_RLY BPO_RLY,T12.BPO_ORGN BPO_ORGN,AU, LO_NAME,0 OUTSTANDING,0 TOT_SUSPENSE,nvl(T25.SUSPENSE_AMT,0) ACTUAL_SUSPENSE,0 OUT_BILL_COUNT, 0 TOTAL_AMT_PASSED,0 bill_amt From T24_RV T24,T25_RV_DETAILS T25,T12_BILL_PAYING_OFFICER T12,T106_LO_ORGN T106, T105_LO_LOGIN T105 Where T12.BPO_TYPE=T106.ORGN_TYPE(+) AND T12.BPO_RLY=T106.ORGN_CHASED(+) AND T106.MOBILE=T105.MOBILE(+) and (SYSDATE BETWEEN LO_PER_FR AND LO_PER_TO) AND (T25.ACC_CD not in (2709,2210,2212)) and T12.BPO_TYPE='R' and (T12.BPO_RLY IN ('NR','MCF','RCF','RCFR','COFMOW','NCR','NWR','DMW','DLW','NER') ) and nvl(T25.BPO_CD,'00000')=T12.BPO_CD and nvl(T25.SUSPENSE_AMT,0) <> 0 and T24.VCHR_NO=T25.VCHR_NO and ((T25.CHQ_DT <= to_date('"+txtDate.Text+"','dd/mm/yyyy')) and (nvl(T24.VCHR_DT,'01-Jan-01')<=to_date('"+txtDate.Text+"','dd/mm/yyyy')+7)) "+
				"Union All "+
				"select B.BPO_TYPE,B.BPO_CD,B.BPO_RLY,B.BPO_ORGN,B.AU,LO_NAME,0 OUTSTANDING, 0 TOT_SUSPENSE,0 ACTUAL_SUSPENSE,0 OUT_BILL_COUNT, SUM(PASSED_AMT) TOTAL_AMT_PASSED,0 bill_amt from RITES_BILL_DTLS B, AU_CRIS A,T106_LO_ORGN T106, T105_LO_LOGIN T105 where B.BPO_TYPE=T106.ORGN_TYPE(+) AND B.BPO_RLY=T106.ORGN_CHASED(+) AND T106.MOBILE=T105.MOBILE(+) AND B.AU=A.AU(+) AND PAYMENT_DT BETWEEN to_date('"+frmDt.Text.Trim()+"','dd/mm/yyyy') AND to_date('"+toDt.Text.Trim()+"','dd/mm/yyyy') and CO6_STATUS='A' AND PASSED_AMT>0 AND B.BPO_TYPE='R' AND (B.BPO_RLY IN ('NR','MCF','RCF','RCFR','COFMOW','NCR','NWR','DMW','DLW','NER') )  GROUP BY B.BPO_TYPE,B.BPO_CD,B.BPO_RLY,B.BPO_ORGN,B.AU,LO_NAME "+
				"Union All "+
				"select B.BPO_TYPE,B.BPO_CD,B.BPO_RLY,B.BPO_ORGN,B.AU,LO_NAME,0 OUTSTANDING, 0 TOT_SUSPENSE,0 ACTUAL_SUSPENSE,0 OUT_BILL_COUNT, 0 TOTAL_AMT_PASSED,sum(INSP_FEE) bill_amt From V22_BILL B, AU_CRIS A,T106_LO_ORGN T106, T105_LO_LOGIN T105 where B.BPO_TYPE=T106.ORGN_TYPE(+) AND B.BPO_RLY=T106.ORGN_CHASED(+) AND T106.MOBILE=T105.MOBILE(+) AND B.AU=A.AU(+) AND bill_dt BETWEEN to_date('"+ss1+"','dd/mm/yyyy') AND to_date('"+ss+"','dd/mm/yyyy') AND B.BPO_TYPE='R' AND (B.BPO_RLY IN ('NR','MCF','RCF','RCFR','COFMOW','NCR','NWR','DMW','DLW','NER')) GROUP BY B.BPO_TYPE,B.BPO_CD,B.BPO_RLY,B.BPO_ORGN,B.AU,LO_NAME "+
				") Group By BPO_TYPE,BPO_RLY,BPO_ORGN,AU, LO_NAME Order By BPO_TYPE,BPO_RLY";

			OracleCommand cmd6 = new OracleCommand(str6, conn1);
			conn1.Open();
			OracleDataReader reader6=cmd6.ExecuteReader();
			double t1=0,t2=0,t3=0,t5=0,t6=0,t7=0;
			double gt1=0,gt2=0,gt3=0,gt5=0,gt6=0,gt7=0,gt8=0;
			int t4=0,gt4=0;
			string wBPO_Type="";
			while(reader6.Read())
			{	
				if (ctr >50) 
				{										
					Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
					Response.Write("<tr>");
					Response.Write("<td width='100%' colspan='10'>");
					if (first_page=="N") 
					{Response.Write("<p style = page-break-before:always></p>");}				
					else
					{first_page="N";}
					Response.Write("<H5 align='center'><font face='Verdana'>"+wRegion+" </font></p>");
					Response.Write("<H5 align='center'><font face='Verdana'>Railway Wise Outstanding Chased By NR Statement as on : "+txtDate.Text+" </font></p>");
					Response.Write("</td>");
					Response.Write("</tr>");
					Response.Write("<tr>");
					Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>Abbreviated Name of Railway/Client</font></b></th>");
					Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>Railway/Client</font></b></th>");
					Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>LO Name</font></b></th>");
					Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Realization for the period: "+frmDt.Text.Trim()+" To "+toDt.Text.Trim()+" </font></b></th>");
					Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Outstanding as on "+txtDate.Text+" and Cleared Till Date</font></b></th>");
					Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>No. of Outstanding Bills </font></b></th>");
					Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Suspence of  "+txtDate.Text+" as it stands today</font></b></th>");
					Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Total Suspense as on Today</font></b></th>");
					Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Billing(Without Tax)</font></b></th>");
					Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>No of Days Outstanding</font></b></th>");
					
					Response.Write("</tr></font>");
					ctr =5;
				};
				if (reader6["BPO_RLY"].ToString() != wBPO_Type)
				{
					if (wBPO_Type.ToString() !="")
					{
						Response.Write("<tr bgColor='#d4d0c8'>");
						Response.Write("<td width='40%' valign='top' align='right' colspan=3><b><font size='1' face='Verdana'>Total For "+wBPO_Type.ToString()+" :</font></b></td>");
						Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t6+"</font></b></td>");
						Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t2+"</font></b></td>");
						Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t4+"</font></b></td>");
						Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t5+"</font></b></td>");
						Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t3+"</font></b></td>");
						Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t7+"</font></b></td>");						
						gt6=gt6+t6;
						gt2=gt2+t2;
						gt3=gt3+t3;
						gt4=gt4+t4;
						gt5=gt5+t5;
						gt7=gt7+t7;
						if(gt7 > 0)
						{
							gt8=Math.Round((((t2-t3)/t7)*365),2);
						}
						else
						{
							gt8=0;
						}
						Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt8+"</font></b></td>");						
						Response.Write("</tr>");
												
						t1=0;t2=0;t3=0;t4=0;t5=0;t6=0;t7=0;
						
						ctr=ctr+1;
					}
					wBPO_Type=reader6["BPO_RLY"].ToString();
					if (reader6["BPO_RLY"].ToString()=="6Un-Accounted")
					{
						Response.Write("<tr>");
						Response.Write("<td valign='top' align='center' colspan=10 bgcolor=#ccccff> <font size='2' face='Verdana'><a href='rptUnAccounted_Suspense.aspx'><b>"+wBPO_Type.ToString()+"</b></a></td>");
						Response.Write("</tr>");
					}
					else
					{
						Response.Write("<tr>");
						Response.Write("<td valign='top' align='center' colspan=10 bgcolor=#ccccff> <font size='2' face='Verdana'><b>"+wBPO_Type.ToString()+"</b></td>");
						Response.Write("</tr>");
					}
					ctr=ctr+1;
				}
				Response.Write("<tr>");
				Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["BPO_RLY"]+'-'+reader6["AU"]+"</font></b></td>");
				Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["BPO_ORGN"]+"</font></b></td>");
				Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["LO"]+"</font></b></td>");
				Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["TOTAL_AMT_PASSED"]+"</font></b></td>");
				Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["OUTSTANDING"]+"</font></b></td>");
				Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["OUT_BILL_COUNT"]+"</font></b></td>");
				if(Convert.ToInt32(reader6["ACTUAL_SUSPENSE"])>0)
				{
					Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'><a href='rptSuspense_Details.aspx?BPO_TYPE="+reader6["BPO_RLY"]+"&CUT_OFF_DT="+txtDate.Text+"&WREGION=A'><b>"+reader6["ACTUAL_SUSPENSE"]+"</font></b></a></td>");
				}
				else
				{
					Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'><b>"+reader6["ACTUAL_SUSPENSE"]+"</font></b></td>");
				}
				if(Convert.ToInt32(reader6["TOT_SUSPENSE"])>0)
				{
					Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'><a href='rptSuspense_Details.aspx?BPO_TYPE="+reader6["BPO_RLY"]+"&CUT_OFF_DT=&WREGION=A'><b>"+reader6["TOT_SUSPENSE"]+"</font></b></a></td>");
				}
				else
				{
					Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'><b>"+reader6["TOT_SUSPENSE"]+"</font></b></td>");
				}
				Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["bill_amt"]+"</font></b></td>");
				Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'></font></b></td>");
				t6=t6+Convert.ToDouble(reader6["TOTAL_AMT_PASSED"]);
				t2=t2+Convert.ToDouble(reader6["OUTSTANDING"]);
				t3=t3+Convert.ToDouble(reader6["TOT_SUSPENSE"]);
				t4=t4+Convert.ToInt16(reader6["OUT_BILL_COUNT"]);
				t5=t5+Convert.ToDouble(reader6["ACTUAL_SUSPENSE"]);
				t7=t7+Convert.ToDouble(reader6["bill_amt"]);
				Response.Write("</tr>");
				ctr=ctr+1;
			};
			Response.Write("<tr bgColor='#d4d0c8'>");
			Response.Write("<td width='40%' valign='top' align='right' colspan=3><b><font size='1' face='Verdana'>Total For "+wBPO_Type.ToString()+" :</font></b></td>");
			Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t6+"</font></b></td>");
			Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t2+"</font></b></td>");
			Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t4+"</font></b></td>");
			Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t5+"</font></b></td>");
			Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t3+"</font></b></td>");
			Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t7+"</font></b></td>");
			Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'></font></b></td>");
			Response.Write("</tr>");
			gt6=gt6+t6;
			gt2=gt2+t2;
			gt3=gt3+t3;
			gt4=gt4+t4;
			gt5=gt5+t5;
			gt7=gt7+t7;
			//gt8=gt8;
			Response.Write("<tr bgColor='#ccccff'>");
			Response.Write("<td width='40%' valign='top' align='right' colspan=3><b><font size='1' face='Verdana'>Grand Totals :</font></b></td>");
			Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt6+"</font></b></td>");
			Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt2+"</font></b></td>");
			Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt4+"</font></b></td>");
			Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt5+"</font></b></td>");
			Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt3+"</font></b></td>");
			Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt7+"</font></b></td>");
			Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'></font></b></td>");
			Response.Write("</tr>");
			conn1.Close();
			Response.Write("</table>");
		
		}
//===========Client Wise Outstanding============
		void Client_Wise_Outstanding()
		{
			conn1.Open();					
			OracleCommand cmd2 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy - HH:MI AM') from dual",conn1);
			string ss=Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();
			int ctr =60;
			string first_page="Y";  
			string str6;
			try
			{
			
				str6="Select decode(BPO_TYPE,'R','1Railway','U','2PSU','P','3Private','F','4Foreign Railway','S','5State Government','6Un-Accounted')BPO_TYPE,BPO_RLY,BPO_ORGN,sum(BILL_AMOUNT)BILL_AMOUNT,sum(OUTSTANDING)OUTSTANDING,sum(TOT_SUSPENSE)TOT_SUSPENSE,sum(ACTUAL_SUSPENSE)ACTUAL_SUSPENSE,sum(OUT_BILL_COUNT) OUT_BILL_COUNT From "+
					"("+
					"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,nvl(BILL_AMOUNT,0)BILL_AMOUNT,0 OUTSTANDING,0 TOT_SUSPENSE,0 ACTUAL_SUSPENSE,0 OUT_BILL_COUNT From V22B_OUTSTANDING_BILLS 	Where BILL_DT <= to_date('"+txtDate.Text+"','dd/mm/yyyy') and REGION_CODE='"+Session["Region"].ToString()+"' "+
					"Union All "+
					"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 BILL_AMOUNT,nvl(AMOUNT_OUTSTANDING,0) OUTSTANDING,0 TOT_SUSPENSE,0 ACTUAL_SUSPENSE,1 OUT_BILL_COUNT From V22B_OUTSTANDING_BILLS Where (AMOUNT_OUTSTANDING > 0 OR BILL_AMOUNT<0) and BILL_DT  <= to_date('"+txtDate.Text+"','dd/mm/yyyy') and REGION_CODE='"+Session["Region"].ToString()+"' "+
					"Union All "+
					"Select T12.BPO_TYPE BPO_TYPE,nvl(T25.BPO_CD,'00000') BPO_CD,T12.BPO_RLY BPO_RLY,T12.BPO_ORGN BPO_ORGN,0 BILL_AMOUNT,0 OUTSTANDING,nvl(T25.SUSPENSE_AMT,0) TOT_SUSPENSE,0 ACTUAL_SUSPENSE,0 OUT_BILL_COUNT From T25_RV_DETAILS T25,T12_BILL_PAYING_OFFICER T12 Where (T25.ACC_CD not in (2709,2210,2212)) and  substr(T25.VCHR_NO,1,1)='"+Session["Region"].ToString()+"' and nvl(T25.BPO_CD,'00000')=T12.BPO_CD and nvl(T25.SUSPENSE_AMT,0) <> 0"+
					"Union All "+
					"Select T12.BPO_TYPE BPO_TYPE,nvl(T25.BPO_CD,'00000') BPO_CD,T12.BPO_RLY BPO_RLY,T12.BPO_ORGN BPO_ORGN,0 BILL_AMOUNT,0 OUTSTANDING,0 TOT_SUSPENSE,nvl(T25.SUSPENSE_AMT,0) ACTUAL_SUSPENSE,0 OUT_BILL_COUNT From T24_RV T24,T25_RV_DETAILS T25,T12_BILL_PAYING_OFFICER T12 Where (T25.ACC_CD not in (2709,2210,2212)) and  substr(T25.VCHR_NO,1,1)='"+Session["Region"].ToString()+"' and nvl(T25.BPO_CD,'00000')=T12.BPO_CD and nvl(T25.SUSPENSE_AMT,0) <> 0 and T24.VCHR_NO=T25.VCHR_NO and ((T25.CHQ_DT <= to_date('"+txtDate.Text+"','dd/mm/yyyy')) and (nvl(T24.VCHR_DT,'01-Jan-01')<=to_date('"+txtDate.Text+"','dd/mm/yyyy')+7))"+
					") Group By BPO_TYPE,BPO_RLY,BPO_ORGN Order by BPO_TYPE,BPO_RLY ";

				OracleCommand cmd6 = new OracleCommand(str6, conn1);
				conn1.Open();
				//OracleDataReader reader6=cmd6.ExecuteReader();
				OracleDataAdapter da = new OracleDataAdapter(str6, conn1);
				DataSet dsP = new DataSet();
				da.SelectCommand = cmd6;
				da.Fill(dsP, "Table");
				conn1.Close();
				double t1=0,t2=0,t3=0,t5=0;
				double gt1=0,gt2=0,gt3=0,gt5=0;
				int t4=0,gt4=0;
				string wBPO_Type="";
				if(dsP.Tables[0].Rows.Count >0)
				{
					for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++) 
					{	
						if (ctr >50) 
						{										
							Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
							Response.Write("<tr>");
							Response.Write("<td width='100%' colspan='7'>");
							if (first_page=="N") 
							{Response.Write("<p style = page-break-before:always></p>");}				
							else
							{first_page="N";}
							Response.Write("<H5 align='center'><font face='Verdana'>"+wRegion+" </font></p>");
							Response.Write("<H5 align='center'><font face='Verdana'>Railway/Client Wise Outstanding Statement as on : "+txtDate.Text+" &nbsp&nbsp----&nbsp&nbspStatus as on : "+ss+"</font></p>");
							Response.Write("</td>");
							Response.Write("</tr>");
							Response.Write("<tr>");
							Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>Abbreviated Name of Railway/Client</font></b></th>");
							Response.Write("<th width='25%' valign='top' align='center'><b><font size='1' face='Verdana'>Railway/Client</font></b></th>");
							Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>Billing For The Period 01/04/2008 to "+txtDate.Text+"</font></b></th>");
							Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>Outstanding as on "+txtDate.Text+" and Cleared Till Date</font></b></th>");
							Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>No. of Outstanding Bills </font></b></th>");
							Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Suspence of  "+txtDate.Text+" as it stands today</font></b></th>");
							Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Total Suspense as on Today</font></b></th>");
							Response.Write("</tr></font>");
							ctr =5;
						};
						if (dsP.Tables[0].Rows[i]["BPO_Type"].ToString() != wBPO_Type)
						{
							if (wBPO_Type.ToString() !="")
							{
								Response.Write("<tr bgColor='#d4d0c8'>");
								Response.Write("<td width='40%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Total For "+wBPO_Type.Substring(1)+" :</font></b></td>");
								Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t1+"</font></b></td>");
								Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t2+"</font></b></td>");
								Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t4+"</font></b></td>");
								Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t5+"</font></b></td>");
								Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t3+"</font></b></td>");
								Response.Write("</tr>");
								gt1=gt1+t1;
								gt2=gt2+t2;
								gt3=gt3+t3;
								gt4=gt4+t4;
								gt5=gt5+t5;
								t1=0;t2=0;t3=0;t4=0;t5=0;
								ctr=ctr+1;
							}
							wBPO_Type=dsP.Tables[0].Rows[i]["BPO_Type"].ToString();
							if (dsP.Tables[0].Rows[i]["BPO_Type"].ToString()=="6Un-Accounted")
							{
								Response.Write("<tr>");
								Response.Write("<td valign='top' align='center' colspan=7 bgcolor=#ccccff> <font size='2' face='Verdana'><a href='rptUnAccounted_Suspense.aspx'><b>"+wBPO_Type.Substring(1)+"</b></a></td>");
								Response.Write("</tr>");
							}
							else
							{
								Response.Write("<tr>");
								Response.Write("<td valign='top' align='center' colspan=7 bgcolor=#ccccff> <font size='2' face='Verdana'><b>"+wBPO_Type.Substring(1)+"</b></td>");
								Response.Write("</tr>");
							}
							ctr=ctr+1;
						}
						Response.Write("<tr>");
			
				
						Response.Write("<td width='15%' valign='top' align='left'><b><font size='1' face='Verdana'>"+dsP.Tables[0].Rows[i]["BPO_RLY"].ToString()+"</font></b></td>");
						Response.Write("<td width='25%' valign='top' align='left'><b><font size='1' face='Verdana'>"+dsP.Tables[0].Rows[i]["BPO_ORGN"].ToString()+"</font></b></td>");
						Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+dsP.Tables[0].Rows[i]["BILL_AMOUNT"].ToString()+"</font></b></td>");
						Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+dsP.Tables[0].Rows[i]["OUTSTANDING"].ToString()+"</font></b></td>");
						Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+dsP.Tables[0].Rows[i]["OUT_BILL_COUNT"].ToString()+"</font></b></td>");
						if(Convert.ToDouble(dsP.Tables[0].Rows[i]["ACTUAL_SUSPENSE"].ToString())>0)
						{
							Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'><a href='rptSuspense_Details.aspx?BPO_TYPE="+dsP.Tables[0].Rows[i]["BPO_RLY"].ToString()+"&CUT_OFF_DT="+txtDate.Text+"'><b>"+dsP.Tables[0].Rows[i]["ACTUAL_SUSPENSE"].ToString()+"</font></b></a></td>");
						}
						else
						{
							Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'><b>"+dsP.Tables[0].Rows[i]["ACTUAL_SUSPENSE"].ToString()+"</font></b></td>");
						}
						if(Convert.ToDouble(dsP.Tables[0].Rows[i]["TOT_SUSPENSE"].ToString())>0)
						{
							Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'><a href='rptSuspense_Details.aspx?BPO_TYPE="+dsP.Tables[0].Rows[i]["BPO_RLY"].ToString()+"&CUT_OFF_DT='><b>"+dsP.Tables[0].Rows[i]["TOT_SUSPENSE"].ToString()+"</font></b></a></td>");
						}
						else
						{
							Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'><b>"+dsP.Tables[0].Rows[i]["TOT_SUSPENSE"].ToString()+"</font></b></td>");
						}

				
				
						t1=t1+Convert.ToDouble(dsP.Tables[0].Rows[i]["BILL_AMOUNT"].ToString());
						t2=t2+Convert.ToDouble(dsP.Tables[0].Rows[i]["OUTSTANDING"].ToString());
						t3=t3+Convert.ToDouble(dsP.Tables[0].Rows[i]["TOT_SUSPENSE"].ToString());
						t4=t4+Convert.ToInt16(dsP.Tables[0].Rows[i]["OUT_BILL_COUNT"].ToString());
						t5=t5+Convert.ToDouble(dsP.Tables[0].Rows[i]["ACTUAL_SUSPENSE"].ToString());
						Response.Write("</tr>");
						ctr=ctr+1;
					}
				};
				Response.Write("<tr bgColor='#d4d0c8'>");
				Response.Write("<td width='40%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Total For "+wBPO_Type.Substring(1)+" :</font></b></td>");
				Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t1+"</font></b></td>");
				Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t2+"</font></b></td>");
				Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t4+"</font></b></td>");
				Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t5+"</font></b></td>");
				Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t3+"</font></b></td>");
				Response.Write("</tr>");
				gt1=gt1+t1;
				gt2=gt2+t2;
				gt3=gt3+t3;
				gt4=gt4+t4;
				gt5=gt5+t5;
				Response.Write("<tr bgColor='#ccccff'>");
				Response.Write("<td width='40%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Grand Totals :</font></b></td>");
				Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt1+"</font></b></td>");
				Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt2+"</font></b></td>");
				Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt4+"</font></b></td>");
				Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt5+"</font></b></td>");
				Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt3+"</font></b></td>");
				Response.Write("</tr>");
				Response.Write("</table>");
			}
			catch(Exception ex)
			{
				string str;
				str = ex.Message;
				string str1=str.Replace("\n","");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}
			finally
			{
				conn1.Close();
			}
		}

		void Client_Wise_Outstanding_sortout()
		{
			conn1.Open();					
			OracleCommand cmd2 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy - HH:MI AM') from dual",conn1);
			string ss=Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();
			int ctr =60;
			//string first_page="Y";  
			string str6;
			
			
				str6="Select decode(BPO_TYPE,'R','1Railway','U','2PSU','P','3Private','F','4Foreign Railway','S','5State Government','6Un-Accounted')BPO_TYPE,BPO_RLY,BPO_ORGN,sum(BILL_AMOUNT)BILL_AMOUNT,sum(OUTSTANDING)OUTSTANDING,sum(TOT_SUSPENSE)TOT_SUSPENSE,sum(ACTUAL_SUSPENSE)ACTUAL_SUSPENSE,sum(OUT_BILL_COUNT) OUT_BILL_COUNT From "+
					"("+
					"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,nvl(BILL_AMOUNT,0)BILL_AMOUNT,0 OUTSTANDING,0 TOT_SUSPENSE,0 ACTUAL_SUSPENSE,0 OUT_BILL_COUNT From V22B_OUTSTANDING_BILLS 	Where BILL_DT <= to_date('"+txtDate.Text+"','dd/mm/yyyy') and REGION_CODE='"+Session["Region"].ToString()+"' "+
					"Union All "+
					"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 BILL_AMOUNT,nvl(AMOUNT_OUTSTANDING,0) OUTSTANDING,0 TOT_SUSPENSE,0 ACTUAL_SUSPENSE,1 OUT_BILL_COUNT From V22B_OUTSTANDING_BILLS Where (AMOUNT_OUTSTANDING > 0 OR BILL_AMOUNT<0) and BILL_DT  <= to_date('"+txtDate.Text+"','dd/mm/yyyy') and REGION_CODE='"+Session["Region"].ToString()+"' "+
					"Union All "+
					"Select T12.BPO_TYPE BPO_TYPE,nvl(T25.BPO_CD,'00000') BPO_CD,T12.BPO_RLY BPO_RLY,T12.BPO_ORGN BPO_ORGN,0 BILL_AMOUNT,0 OUTSTANDING,nvl(T25.SUSPENSE_AMT,0) TOT_SUSPENSE,0 ACTUAL_SUSPENSE,0 OUT_BILL_COUNT From T25_RV_DETAILS T25,T12_BILL_PAYING_OFFICER T12 Where (T25.ACC_CD not in (2709,2210,2212)) and  substr(T25.VCHR_NO,1,1)='"+Session["Region"].ToString()+"' and nvl(T25.BPO_CD,'00000')=T12.BPO_CD and nvl(T25.SUSPENSE_AMT,0) <> 0"+
					"Union All "+
					"Select T12.BPO_TYPE BPO_TYPE,nvl(T25.BPO_CD,'00000') BPO_CD,T12.BPO_RLY BPO_RLY,T12.BPO_ORGN BPO_ORGN,0 BILL_AMOUNT,0 OUTSTANDING,0 TOT_SUSPENSE,nvl(T25.SUSPENSE_AMT,0) ACTUAL_SUSPENSE,0 OUT_BILL_COUNT From T24_RV T24,T25_RV_DETAILS T25,T12_BILL_PAYING_OFFICER T12 Where (T25.ACC_CD not in (2709,2210,2212)) and  substr(T25.VCHR_NO,1,1)='"+Session["Region"].ToString()+"' and nvl(T25.BPO_CD,'00000')=T12.BPO_CD and nvl(T25.SUSPENSE_AMT,0) <> 0 and T24.VCHR_NO=T25.VCHR_NO and ((T25.CHQ_DT <= to_date('"+txtDate.Text+"','dd/mm/yyyy')) and (nvl(T24.VCHR_DT,'01-Jan-01')<=to_date('"+txtDate.Text+"','dd/mm/yyyy')+7))"+
					") Group By BPO_TYPE,BPO_RLY,BPO_ORGN Order by BPO_TYPE,OUTSTANDING desc,BPO_RLY";
			

			OracleCommand cmd6 = new OracleCommand(str6, conn1);
			conn1.Open();
			//OracleDataReader reader6=cmd6.ExecuteReader();
			OracleDataAdapter da = new OracleDataAdapter(str6, conn1);
			DataSet dsP = new DataSet();
			da.SelectCommand = cmd6;
			da.Fill(dsP, "Table");
			conn1.Close();
			double t1=0,t2=0,t3=0,t5=0;
			double gt1=0,gt2=0,gt3=0,gt5=0;
			int t4=0,gt4=0;
			string wBPO_Type="";

			Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
			Response.Write("<tr>");
			Response.Write("<td width='100%' colspan='7'>");
//			if (first_page=="N") 
//			{Response.Write("<p style = page-break-before:always></p>");}				
//			else
//			{first_page="N";}
			Response.Write("<H5 align='center'><font face='Verdana'>"+wRegion+" </font></p>");
			Response.Write("<H5 align='center'><font face='Verdana'>Railway/Client Wise Outstanding Statement as on : "+txtDate.Text+" </font></p>");
			Response.Write("<H5 align='center'><font face='Verdana'>(For the Client where outstanding is greater then zero Or Total suspense is greater then zero)&nbsp&nbsp----&nbsp&nbspStatus as on : "+ss+" </font></p>");
			Response.Write("</td>");
			Response.Write("</tr>");
			Response.Write("<tr>");
			Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>Abbreviated Name of Railway/Client</font></b></th>");
			Response.Write("<th width='25%' valign='top' align='center'><b><font size='1' face='Verdana'>Railway/Client</font></b></th>");
			Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>Billing For The Period 01/04/2008 to "+txtDate.Text+"</font></b></th>");
			Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>Outstanding as on "+txtDate.Text+" and Cleared Till Date</font></b></th>");
			Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>No. of Outstanding Bills </font></b></th>");
			Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Suspence of  "+txtDate.Text+" as it stands today</font></b></th>");
			Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Total Suspense as on Today</font></b></th>");
			Response.Write("</tr></font>");
			if(dsP.Tables[0].Rows.Count >0)
			{
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++) 
				{	
					if(Convert.ToDouble(dsP.Tables[0].Rows[i]["OUTSTANDING"].ToString())>0 || Convert.ToDouble(dsP.Tables[0].Rows[i]["TOT_SUSPENSE"].ToString())>0)
					{
						if (dsP.Tables[0].Rows[i]["BPO_TYPE"].ToString() != wBPO_Type)
						{
							if (wBPO_Type.ToString() !="")
							{
								Response.Write("<tr bgColor='#d4d0c8'>");
								Response.Write("<td width='40%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Total For "+wBPO_Type.Substring(1)+" :</font></b></td>");
								Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t1+"</font></b></td>");
								Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t2+"</font></b></td>");
								Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t4+"</font></b></td>");
								Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t5+"</font></b></td>");
								Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t3+"</font></b></td>");
								Response.Write("</tr>");
								gt1=gt1+t1;
								gt2=gt2+t2;
								gt3=gt3+t3;
								gt4=gt4+t4;
								gt5=gt5+t5;
								t1=0;t2=0;t3=0;t4=0;t5=0;
								ctr=ctr+1;
							}
							wBPO_Type=dsP.Tables[0].Rows[i]["BPO_TYPE"].ToString();
							if (dsP.Tables[0].Rows[i]["BPO_TYPE"].ToString()=="6Un-Accounted")
							{
								Response.Write("<tr>");
								Response.Write("<td valign='top' align='center' colspan=7 bgcolor=#ccccff> <font size='2' face='Verdana'><a href='rptUnAccounted_Suspense.aspx'><b>"+wBPO_Type.Substring(1)+"</b></a></td>");
								Response.Write("</tr>");
							}
							else
							{
								Response.Write("<tr>");
								Response.Write("<td valign='top' align='center' colspan=7 bgcolor=#ccccff> <font size='2' face='Verdana'><b>"+wBPO_Type.Substring(1)+"</b></td>");
								Response.Write("</tr>");
							}
							ctr=ctr+1;
						}
						Response.Write("<tr>");
				
						Response.Write("<td width='15%' valign='top' align='left'><b><font size='1' face='Verdana'>"+dsP.Tables[0].Rows[i]["BPO_RLY"].ToString()+"</font></b></td>");
						Response.Write("<td width='25%' valign='top' align='left'><b><font size='1' face='Verdana'>"+dsP.Tables[0].Rows[i]["BPO_ORGN"].ToString()+"</font></b></td>");
						Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+dsP.Tables[0].Rows[i]["BILL_AMOUNT"].ToString()+"</font></b></td>");
						Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+dsP.Tables[0].Rows[i]["OUTSTANDING"].ToString()+"</font></b></td>");
						Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+dsP.Tables[0].Rows[i]["OUT_BILL_COUNT"].ToString()+"</font></b></td>");
						if(Convert.ToDouble(dsP.Tables[0].Rows[i]["ACTUAL_SUSPENSE"].ToString())>0)
						{
							Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'><a href='rptSuspense_Details.aspx?BPO_TYPE="+dsP.Tables[0].Rows[i]["BPO_RLY"].ToString()+"&CUT_OFF_DT="+txtDate.Text+"'><b>"+dsP.Tables[0].Rows[i]["ACTUAL_SUSPENSE"].ToString()+"</font></b></a></td>");
						}
						else
						{
							Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'><b>"+dsP.Tables[0].Rows[i]["ACTUAL_SUSPENSE"].ToString()+"</font></b></td>");
						}
						if(Convert.ToDouble(dsP.Tables[0].Rows[i]["TOT_SUSPENSE"].ToString())>0)
						{
							Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'><a href='rptSuspense_Details.aspx?BPO_TYPE="+dsP.Tables[0].Rows[i]["BPO_RLY"].ToString()+"&CUT_OFF_DT='><b>"+dsP.Tables[0].Rows[i]["TOT_SUSPENSE"].ToString()+"</font></b></a></td>");
						}
						else
						{
							Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'><b>"+dsP.Tables[0].Rows[i]["TOT_SUSPENSE"].ToString()+"</font></b></td>");
						}
					}
				
					t1=t1+Convert.ToDouble(dsP.Tables[0].Rows[i]["BILL_AMOUNT"].ToString());
					t2=t2+Convert.ToDouble(dsP.Tables[0].Rows[i]["OUTSTANDING"].ToString());
					t3=t3+Convert.ToDouble(dsP.Tables[0].Rows[i]["TOT_SUSPENSE"].ToString());
					t4=t4+Convert.ToInt16(dsP.Tables[0].Rows[i]["OUT_BILL_COUNT"].ToString());
					t5=t5+Convert.ToDouble(dsP.Tables[0].Rows[i]["ACTUAL_SUSPENSE"].ToString());
					Response.Write("</tr>");
					ctr=ctr+1;
				}
			};
			Response.Write("<tr bgColor='#d4d0c8'>");
			Response.Write("<td width='40%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Total For "+wBPO_Type.Substring(1)+" :</font></b></td>");
			Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t1+"</font></b></td>");
			Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t2+"</font></b></td>");
			Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t4+"</font></b></td>");
			Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t5+"</font></b></td>");
			Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t3+"</font></b></td>");
			Response.Write("</tr>");
			gt1=gt1+t1;
			gt2=gt2+t2;
			gt3=gt3+t3;
			gt4=gt4+t4;
			gt5=gt5+t5;
			Response.Write("<tr bgColor='#ccccff'>");
			Response.Write("<td width='40%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Grand Totals :</font></b></td>");
			Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt1+"</font></b></td>");
			Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt2+"</font></b></td>");
			Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt4+"</font></b></td>");
			Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt5+"</font></b></td>");
			Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt3+"</font></b></td>");
			Response.Write("</tr>");
			conn1.Close();
			Response.Write("</table>");
		}


		//===========Periodical Breakup of Client Wise Outstanding============
		void Periodic_Outstanding_Client_Wise()
		{
			conn1.Open();					
			OracleCommand cmd2 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual",conn1);
			string wTodayDt=Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();
			int ctr =60;
			string first_page="Y"; 
			string str6=null;
			if(rdbFourRegions.Checked==false && rdbAllRegion.Checked==false)
			{
				str6="Select decode(BPO_TYPE,'R','1Railway','U','2PSU','P','3Private','F','4Foreign Railway','S','5State Government','6Un-Accounted')BPO_TYPE,BPO_RLY,BPO_ORGN,sum(OUT_0_6M)OUT_0_6M,sum(OUT_6_12M)OUT_6_12M,sum(OUT_12_24M)OUT_12_24M,sum(OUT_24_36M)OUT_24_36M,sum(OUT_36_48M)OUT_36_48M,sum(OUT_48_60M)OUT_48_60M,sum(OUT_GT_60M)OUT_GT_60M,sum(SUSPENSE)SUSPENSE, sum(ACTUAL_SUSPENSE) ACTUAL_SUSPENSE From "+
					"("+
					"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,nvl(AMOUNT_OUTSTANDING,0) OUT_0_6M,0 OUT_6_12M,0 OUT_12_24M,0 OUT_24_36M,0 OUT_36_48M,0 OUT_48_60M,0 OUT_GT_60M,0 SUSPENSE,0 ACTUAL_SUSPENSE From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and (BILL_DT between add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy')+1,-6) and to_date('"+txtDate.Text+"','dd/mm/yyyy')) and REGION_CODE='"+Session["Region"].ToString()+"' "+
					"Union All "+
					"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 OUT_0_6M,nvl(AMOUNT_OUTSTANDING,0) OUT_6_12M,0 OUT_12_24M,0 OUT_24_36M,0 OUT_36_48M,0 OUT_48_60M,0 OUT_GT_60M,0 SUSPENSE,0 ACTUAL_SUSPENSE From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and (BILL_DT between add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy')+1,-12) and add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy'),-6)) and REGION_CODE='"+Session["Region"].ToString()+"' "+
					"Union All "+
					"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 OUT_0_6M,0 OUT_6_12M,nvl(AMOUNT_OUTSTANDING,0) OUT_12_24M,0 OUT_24_36M,0 OUT_36_48M,0 OUT_48_60M,0 OUT_GT_60M,0 SUSPENSE,0 ACTUAL_SUSPENSE From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and (BILL_DT between add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy')+1,-24) and add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy'),-12)) and REGION_CODE='"+Session["Region"].ToString()+"' "+
					"Union All "+
					"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 OUT_0_6M,0 OUT_6_12M,0 OUT_12_24M,nvl(AMOUNT_OUTSTANDING,0) OUT_24_36M,0 OUT_36_48M,0 OUT_48_60M,0 OUT_GT_60M,0 SUSPENSE,0 ACTUAL_SUSPENSE From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and (BILL_DT between add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy')+1,-36) and add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy'),-24)) and REGION_CODE='"+Session["Region"].ToString()+"' "+
					"Union All "+
					"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 OUT_0_6M,0 OUT_6_12M,0 OUT_12_24M,0 OUT_24_36M,nvl(AMOUNT_OUTSTANDING,0) OUT_36_48M,0 OUT_48_60M,0 OUT_GT_60M,0 SUSPENSE,0 ACTUAL_SUSPENSE From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and (BILL_DT between add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy')+1,-48) and add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy'),-36)) and REGION_CODE='"+Session["Region"].ToString()+"' "+
					"Union All "+
					"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 OUT_0_6M,0 OUT_6_12M,0 OUT_12_24M,0 OUT_24_36M,0 OUT_36_48M,nvl(AMOUNT_OUTSTANDING,0) OUT_48_60M,0 OUT_GT_60M,0 SUSPENSE,0 ACTUAL_SUSPENSE From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and (BILL_DT between add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy')+1,-60) and add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy'),-48)) and REGION_CODE='"+Session["Region"].ToString()+"' "+
					"Union All "+
					"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 OUT_0_6M,0 OUT_6_12M,0 OUT_12_24M,0 OUT_24_36M,0 OUT_36_48M,0 OUT_48_60M,nvl(AMOUNT_OUTSTANDING,0) OUT_GT_60M,0 SUSPENSE,0 ACTUAL_SUSPENSE From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and (BILL_DT < add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy')+1,-60)) and REGION_CODE='"+Session["Region"].ToString()+"' "+
					"Union All "+
					"Select T12.BPO_TYPE BPO_TYPE,nvl(T25.BPO_CD,'00000') BPO_CD,T12.BPO_RLY BPO_RLY,T12.BPO_ORGN BPO_ORGN,0 OUT_0_6M,0 OUT_6_12M,0 OUT_12_24M,0 OUT_24_36M,0 OUT_36_48M,0 OUT_48_60M,0 OUT_GT_60M,nvl(T25.SUSPENSE_AMT,0) SUSPENSE,0 ACTUAL_SUSPENSE From T25_RV_DETAILS T25,T12_BILL_PAYING_OFFICER T12 Where (T25.ACC_CD not in (2709,2210,2212)) and  substr(T25.VCHR_NO,1,1)='"+Session["Region"].ToString()+"' and nvl(T25.BPO_CD,'00000')=T12.BPO_CD and nvl(T25.SUSPENSE_AMT,0) <>0"+
					"Union All "+
					"Select T12.BPO_TYPE BPO_TYPE,nvl(T25.BPO_CD,'00000') BPO_CD,T12.BPO_RLY BPO_RLY,T12.BPO_ORGN BPO_ORGN,0 OUT_0_6M,0 OUT_6_12M,0 OUT_12_24M,0 OUT_24_36M,0 OUT_36_48M,0 OUT_48_60M,0 OUT_GT_60M,0 SUSPENSE, nvl(T25.SUSPENSE_AMT,0) ACTUAL_SUSPENSE From T24_RV T24,T25_RV_DETAILS T25,T12_BILL_PAYING_OFFICER T12 Where (T25.ACC_CD not in (2709,2210,2212)) and  substr(T25.VCHR_NO,1,1)='"+Session["Region"].ToString()+"' and nvl(T25.BPO_CD,'00000')=T12.BPO_CD and nvl(T25.SUSPENSE_AMT,0) <> 0 and T24.VCHR_NO=T25.VCHR_NO and ((T25.CHQ_DT <= to_date('"+txtDate.Text+"','dd/mm/yyyy')) and (nvl(T24.VCHR_DT,'01-Jan-01')<=to_date('"+txtDate.Text+"','dd/mm/yyyy')+7))"+
					") Group By BPO_TYPE,BPO_RLY,BPO_ORGN Order By BPO_TYPE,BPO_RLY";
			}
			else if(rdbAllRegion.Checked==true)
			{
				str6="Select decode(BPO_TYPE,'R','1Railway','U','2PSU','P','3Private','F','4Foreign Railway','S','5State Government','6Un-Accounted')BPO_TYPE,BPO_RLY,BPO_ORGN,sum(OUT_0_6M)OUT_0_6M,sum(OUT_6_12M)OUT_6_12M,sum(OUT_12_24M)OUT_12_24M,sum(OUT_24_36M)OUT_24_36M,sum(OUT_36_48M)OUT_36_48M,sum(OUT_48_60M)OUT_48_60M,sum(OUT_GT_60M)OUT_GT_60M,sum(SUSPENSE)SUSPENSE, sum(ACTUAL_SUSPENSE) ACTUAL_SUSPENSE  From "+
					"("+
					"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,nvl(AMOUNT_OUTSTANDING,0) OUT_0_6M,0 OUT_6_12M,0 OUT_12_24M,0 OUT_24_36M,0 OUT_36_48M,0 OUT_48_60M,0 OUT_GT_60M,0 SUSPENSE,0 ACTUAL_SUSPENSE From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and (BILL_DT between add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy')+1,-6) and to_date('"+txtDate.Text+"','dd/mm/yyyy')) "+
					"Union All "+
					"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 OUT_0_6M,nvl(AMOUNT_OUTSTANDING,0) OUT_6_12M,0 OUT_12_24M,0 OUT_24_36M,0 OUT_36_48M,0 OUT_48_60M,0 OUT_GT_60M,0 SUSPENSE,0 ACTUAL_SUSPENSE From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and (BILL_DT between add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy')+1,-12) and add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy'),-6)) "+
					"Union All "+
					"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 OUT_0_6M,0 OUT_6_12M,nvl(AMOUNT_OUTSTANDING,0) OUT_12_24M,0 OUT_24_36M,0 OUT_36_48M,0 OUT_48_60M,0 OUT_GT_60M,0 SUSPENSE,0 ACTUAL_SUSPENSE From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and (BILL_DT between add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy')+1,-24) and add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy'),-12)) "+
					"Union All "+
					"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 OUT_0_6M,0 OUT_6_12M,0 OUT_12_24M,nvl(AMOUNT_OUTSTANDING,0) OUT_24_36M,0 OUT_36_48M,0 OUT_48_60M,0 OUT_GT_60M,0 SUSPENSE,0 ACTUAL_SUSPENSE From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and (BILL_DT between add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy')+1,-36) and add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy'),-24)) "+
					"Union All "+
					"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 OUT_0_6M,0 OUT_6_12M,0 OUT_12_24M,0 OUT_24_36M,nvl(AMOUNT_OUTSTANDING,0) OUT_36_48M,0 OUT_48_60M,0 OUT_GT_60M,0 SUSPENSE,0 ACTUAL_SUSPENSE From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and (BILL_DT between add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy')+1,-48) and add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy'),-36)) "+
					"Union All "+
					"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 OUT_0_6M,0 OUT_6_12M,0 OUT_12_24M,0 OUT_24_36M,0 OUT_36_48M,nvl(AMOUNT_OUTSTANDING,0) OUT_48_60M,0 OUT_GT_60M,0 SUSPENSE,0 ACTUAL_SUSPENSE From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and (BILL_DT between add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy')+1,-60) and add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy'),-48)) "+
					"Union All "+
					"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 OUT_0_6M,0 OUT_6_12M,0 OUT_12_24M,0 OUT_24_36M,0 OUT_36_48M,0 OUT_48_60M,nvl(AMOUNT_OUTSTANDING,0) OUT_GT_60M,0 SUSPENSE,0 ACTUAL_SUSPENSE From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and (BILL_DT < add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy')+1,-60)) "+
					"Union All "+
					"Select T12.BPO_TYPE BPO_TYPE,nvl(T25.BPO_CD,'00000') BPO_CD,T12.BPO_RLY BPO_RLY,T12.BPO_ORGN BPO_ORGN,0 OUT_0_6M,0 OUT_6_12M,0 OUT_12_24M,0 OUT_24_36M,0 OUT_36_48M,0 OUT_48_60M,0 OUT_GT_60M,nvl(T25.SUSPENSE_AMT,0) SUSPENSE,0 ACTUAL_SUSPENSE From T25_RV_DETAILS T25,T12_BILL_PAYING_OFFICER T12 Where (T25.ACC_CD not in (2709,2210,2212)) and nvl(T25.BPO_CD,'00000')=T12.BPO_CD and nvl(T25.SUSPENSE_AMT,0) <>0"+
					"Union All "+
					"Select T12.BPO_TYPE BPO_TYPE,nvl(T25.BPO_CD,'00000') BPO_CD,T12.BPO_RLY BPO_RLY,T12.BPO_ORGN BPO_ORGN,0 OUT_0_6M,0 OUT_6_12M,0 OUT_12_24M,0 OUT_24_36M,0 OUT_36_48M,0 OUT_48_60M,0 OUT_GT_60M,0 SUSPENSE, nvl(T25.SUSPENSE_AMT,0) ACTUAL_SUSPENSE From T24_RV T24,T25_RV_DETAILS T25,T12_BILL_PAYING_OFFICER T12 Where (T25.ACC_CD not in (2709,2210,2212)) and  substr(T25.VCHR_NO,1,1)='"+Session["Region"].ToString()+"' and nvl(T25.BPO_CD,'00000')=T12.BPO_CD and nvl(T25.SUSPENSE_AMT,0) <> 0 and T24.VCHR_NO=T25.VCHR_NO and ((T25.CHQ_DT <= to_date('"+txtDate.Text+"','dd/mm/yyyy')) and (nvl(T24.VCHR_DT,'01-Jan-01')<=to_date('"+txtDate.Text+"','dd/mm/yyyy')+7))"+
					") Group By BPO_TYPE,BPO_RLY,BPO_ORGN Order By BPO_TYPE,BPO_RLY";
			}
			else if(rdbFourRegions.Checked==true)
			{
				str6="Select decode(BPO_TYPE,'R','1Railway','U','2PSU','P','3Private','F','4Foreign Railway','S','5State Government','6Un-Accounted')BPO_TYPE,BPO_RLY,BPO_ORGN,sum(OUT_0_6M)OUT_0_6M,sum(OUT_6_12M)OUT_6_12M,sum(OUT_12_24M)OUT_12_24M,sum(OUT_24_36M)OUT_24_36M,sum(OUT_36_48M)OUT_36_48M,sum(OUT_48_60M)OUT_48_60M,sum(OUT_GT_60M)OUT_GT_60M,sum(SUSPENSE)SUSPENSE, sum(ACTUAL_SUSPENSE) ACTUAL_SUSPENSE  From "+
					"("+
					"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,nvl(AMOUNT_OUTSTANDING,0) OUT_0_6M,0 OUT_6_12M,0 OUT_12_24M,0 OUT_24_36M,0 OUT_36_48M,0 OUT_48_60M,0 OUT_GT_60M,0 SUSPENSE,0 ACTUAL_SUSPENSE From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and (BILL_DT between add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy')+1,-6) and to_date('"+txtDate.Text+"','dd/mm/yyyy')) and REGION_CODE IN ('N','W','E','S') "+
					"Union All "+
					"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 OUT_0_6M,nvl(AMOUNT_OUTSTANDING,0) OUT_6_12M,0 OUT_12_24M,0 OUT_24_36M,0 OUT_36_48M,0 OUT_48_60M,0 OUT_GT_60M,0 SUSPENSE,0 ACTUAL_SUSPENSE From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and (BILL_DT between add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy')+1,-12) and add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy'),-6)) and REGION_CODE IN ('N','W','E','S') "+
					"Union All "+
					"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 OUT_0_6M,0 OUT_6_12M,nvl(AMOUNT_OUTSTANDING,0) OUT_12_24M,0 OUT_24_36M,0 OUT_36_48M,0 OUT_48_60M,0 OUT_GT_60M,0 SUSPENSE,0 ACTUAL_SUSPENSE From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and (BILL_DT between add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy')+1,-24) and add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy'),-12)) and REGION_CODE IN ('N','W','E','S') "+
					"Union All "+
					"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 OUT_0_6M,0 OUT_6_12M,0 OUT_12_24M,nvl(AMOUNT_OUTSTANDING,0) OUT_24_36M,0 OUT_36_48M,0 OUT_48_60M,0 OUT_GT_60M,0 SUSPENSE,0 ACTUAL_SUSPENSE From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and (BILL_DT between add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy')+1,-36) and add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy'),-24)) and REGION_CODE IN ('N','W','E','S') "+
					"Union All "+
					"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 OUT_0_6M,0 OUT_6_12M,0 OUT_12_24M,0 OUT_24_36M,nvl(AMOUNT_OUTSTANDING,0) OUT_36_48M,0 OUT_48_60M,0 OUT_GT_60M,0 SUSPENSE,0 ACTUAL_SUSPENSE From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and (BILL_DT between add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy')+1,-48) and add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy'),-36)) and REGION_CODE IN ('N','W','E','S') "+
					"Union All "+
					"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 OUT_0_6M,0 OUT_6_12M,0 OUT_12_24M,0 OUT_24_36M,0 OUT_36_48M,nvl(AMOUNT_OUTSTANDING,0) OUT_48_60M,0 OUT_GT_60M,0 SUSPENSE,0 ACTUAL_SUSPENSE From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and (BILL_DT between add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy')+1,-60) and add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy'),-48)) and REGION_CODE IN ('N','W','E','S') "+
					"Union All "+
					"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 OUT_0_6M,0 OUT_6_12M,0 OUT_12_24M,0 OUT_24_36M,0 OUT_36_48M,0 OUT_48_60M,nvl(AMOUNT_OUTSTANDING,0) OUT_GT_60M,0 SUSPENSE,0 ACTUAL_SUSPENSE From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and (BILL_DT < add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy')+1,-60)) "+
					"Union All "+
					"Select T12.BPO_TYPE BPO_TYPE,nvl(T25.BPO_CD,'00000') BPO_CD,T12.BPO_RLY BPO_RLY,T12.BPO_ORGN BPO_ORGN,0 OUT_0_6M,0 OUT_6_12M,0 OUT_12_24M,0 OUT_24_36M,0 OUT_36_48M,0 OUT_48_60M,0 OUT_GT_60M,nvl(T25.SUSPENSE_AMT,0) SUSPENSE,0 ACTUAL_SUSPENSE From T25_RV_DETAILS T25,T12_BILL_PAYING_OFFICER T12 Where (T25.ACC_CD not in (2709,2210,2212)) and nvl(T25.BPO_CD,'00000')=T12.BPO_CD and nvl(T25.SUSPENSE_AMT,0) <>0"+
					"Union All "+
					"Select T12.BPO_TYPE BPO_TYPE,nvl(T25.BPO_CD,'00000') BPO_CD,T12.BPO_RLY BPO_RLY,T12.BPO_ORGN BPO_ORGN,0 OUT_0_6M,0 OUT_6_12M,0 OUT_12_24M,0 OUT_24_36M,0 OUT_36_48M,0 OUT_48_60M,0 OUT_GT_60M,0 SUSPENSE, nvl(T25.SUSPENSE_AMT,0) ACTUAL_SUSPENSE From T24_RV T24,T25_RV_DETAILS T25,T12_BILL_PAYING_OFFICER T12 Where (T25.ACC_CD not in (2709,2210,2212)) and  substr(T25.VCHR_NO,1,1)='"+Session["Region"].ToString()+"' and nvl(T25.BPO_CD,'00000')=T12.BPO_CD and nvl(T25.SUSPENSE_AMT,0) <> 0 and T24.VCHR_NO=T25.VCHR_NO and ((T25.CHQ_DT <= to_date('"+txtDate.Text+"','dd/mm/yyyy')) and (nvl(T24.VCHR_DT,'01-Jan-01')<=to_date('"+txtDate.Text+"','dd/mm/yyyy')+7))"+
					") Group By BPO_TYPE,BPO_RLY,BPO_ORGN Order By BPO_TYPE,BPO_RLY";
			}
			OracleCommand cmd6 = new OracleCommand(str6, conn1);
			conn1.Open();
			OracleDataReader reader6=cmd6.ExecuteReader();
			double t1=0,t2=0,t3=0,t4=0,t5=0,t6=0,t7=0,t8=0,t9=0,t10=0,r1=0;
			double gt1=0,gt2=0,gt3=0,gt4=0,gt5=0,gt6=0,gt7=0,gt8=0,gt9=0,gt10=0;
			string wBPO_Type="";
			while(reader6.Read())
			{	
				if (ctr >50) 
				{										
					Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
					Response.Write("<tr>");
					Response.Write("<td width='100%' colspan='12'>");
					if (first_page=="N") 
					{Response.Write("<p style = page-break-before:always></p>");}				
					else
					{first_page="N";}
					if(rdbAllRegion.Checked==false && rdbFourRegions.Checked==false)
					{
						Response.Write("<H5 align='center'><font face='Verdana'>"+wRegion+" </font></p>");
					}
					else if(rdbAllRegion.Checked==true)
					{
						Response.Write("<H5 align='center'><font face='Verdana'>All Five Regions (NR, SR, ER, WR & CR) </font></p>");
					}
					else if(rdbFourRegions.Checked==true)
					{
						Response.Write("<H5 align='center'><font face='Verdana'>Four Regions (NR, SR, ER & WR) </font></p>");
					}
					Response.Write("<H5 align='center'><font face='Verdana'>Railway/Client Wise Outstanding (Billing upto "+txtDate.Text+" and Cleared Till "+wTodayDt+")</font></p>");
					Response.Write("</td>");
					Response.Write("</tr>");
					Response.Write("<tr>");
					Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Abbreviated Name of Railway/Client</font></b></th>");
					Response.Write("<th width='18%' valign='top' align='center'><b><font size='1' face='Verdana'>Railway/Client</font></b></th>");
					Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>0-6 Months</font></b></th>");
					Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>6-12 Months</font></b></th>");
					Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>12-24 Months</font></b></th>");
					Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>24-36 Months</font></b></th>");
					Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>36-48 Months</font></b></th>");
					Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>48-60 Months</font></b></th>");
					Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'> > 60 Months</font></b></th>");
					Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Total Outstanding</font></b></th>");
					Response.Write("<th width='8%' valign='top' align='center'><b><font size='1' face='Verdana'>Suspense as on "+wTodayDt+"</font></b></th>");
					Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Suspence of  "+txtDate.Text+" as it stands today</font></b></th>");
					Response.Write("</tr></font>");
					ctr =5;
				};
				if (reader6["BPO_TYPE"].ToString() != wBPO_Type)
				{
					if (wBPO_Type.ToString() !="")
					{
						Response.Write("<tr bgColor='#d4d0c8'>");
						Response.Write("<td width='28%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Total For "+wBPO_Type.Substring(1)+" :</font></b></td>");
						Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t1+"</font></b></td>");
						Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t2+"</font></b></td>");
						Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t3+"</font></b></td>");
						Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t4+"</font></b></td>");
						Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t5+"</font></b></td>");
						Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t6+"</font></b></td>");
						Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t7+"</font></b></td>");
						Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t8+"</font></b></td>");
						Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t9+"</font></b></td>");
						Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t10+"</font></b></td>");
						Response.Write("</tr>");
						gt1=gt1+t1;
						gt2=gt2+t2;
						gt3=gt3+t3;
						gt4=gt4+t4;
						gt5=gt5+t5;
						gt6=gt6+t6;
						gt7=gt7+t7;
						gt8=gt8+t8;
						gt9=gt9+t9;
						gt10=gt10+t10;
						t1=0;t2=0;t3=0;t4=0;t5=0;t6=0;t7=0;t8=0;t9=0;t10=0;
						ctr=ctr+1;
					}
					wBPO_Type=reader6["BPO_TYPE"].ToString();
					Response.Write("<tr>");
					Response.Write("<td valign='top' align='center' colspan=12 bgcolor=#ccccff> <font size='2' face='Verdana'><b>"+wBPO_Type.Substring(1)+"</b></td>");
					Response.Write("</tr>");
					ctr=ctr+1;
				}
				r1=Convert.ToDouble(reader6["OUT_0_6M"])+Convert.ToDouble(reader6["OUT_6_12M"])+Convert.ToDouble(reader6["OUT_12_24M"])+Convert.ToDouble(reader6["OUT_24_36M"])+Convert.ToDouble(reader6["OUT_36_48M"])+Convert.ToDouble(reader6["OUT_48_60M"])+Convert.ToDouble(reader6["OUT_GT_60M"]);
				if (chkOutSum.Checked==false)
				{
					Response.Write("<tr>");
					Response.Write("<td width='10%' valign='top' align='left'><b><font size='1' face='Verdana'>"+reader6["BPO_RLY"]+"</font></b></td>");
					Response.Write("<td width='18%' valign='top' align='left'><b><font size='1' face='Verdana'>"+reader6["BPO_ORGN"]+"</font></b></td>");
					Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["OUT_0_6M"]+"</font></b></td>");
					Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["OUT_6_12M"]+"</font></b></td>");
					Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["OUT_12_24M"]+"</font></b></td>");
					Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["OUT_24_36M"]+"</font></b></td>");
					Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["OUT_36_48M"]+"</font></b></td>");
					Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["OUT_48_60M"]+"</font></b></td>");
					Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["OUT_GT_60M"]+"</font></b></td>");
					Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+r1+"</font></b></td>");
					Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["SUSPENSE"]+"</font></b></td>");
					Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["ACTUAL_SUSPENSE"]+"</font></b></td>");
					Response.Write("</tr>");
					ctr=ctr+1;
				}
				t1=t1+Convert.ToDouble(reader6["OUT_0_6M"]);
				t2=t2+Convert.ToDouble(reader6["OUT_6_12M"]);
				t3=t3+Convert.ToDouble(reader6["OUT_12_24M"]);
				t4=t4+Convert.ToDouble(reader6["OUT_24_36M"]);
				t5=t5+Convert.ToDouble(reader6["OUT_36_48M"]);
				t6=t6+Convert.ToDouble(reader6["OUT_48_60M"]);
				t7=t7+Convert.ToDouble(reader6["OUT_GT_60M"]);
				t8=t8+r1;
				t9=t9+Convert.ToDouble(reader6["SUSPENSE"]);
				t10=t10+Convert.ToDouble(reader6["ACTUAL_SUSPENSE"]);
			};
			Response.Write("<tr bgColor='#d4d0c8'>");
			Response.Write("<td width='28%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Total For "+wBPO_Type.Substring(1)+" :</font></b></td>");
			Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t1+"</font></b></td>");
			Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t2+"</font></b></td>");
			Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t3+"</font></b></td>");
			Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t4+"</font></b></td>");
			Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t5+"</font></b></td>");
			Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t6+"</font></b></td>");
			Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t7+"</font></b></td>");
			Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t8+"</font></b></td>");
			Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t9+"</font></b></td>");
			Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t10+"</font></b></td>");
			Response.Write("</tr>");
			gt1=gt1+t1;
			gt2=gt2+t2;
			gt3=gt3+t3;
			gt4=gt4+t4;
			gt5=gt5+t5;
			gt6=gt6+t6;
			gt7=gt7+t7;
			gt8=gt8+t8;
			gt9=gt9+t9;
			gt10=gt10+t10;
			Response.Write("<tr bgColor='#ccccff'>");
			Response.Write("<td width='28%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Grand Totals :</font></b></td>");
			Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt1+"</font></b></td>");
			Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt2+"</font></b></td>");
			Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt3+"</font></b></td>");
			Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt4+"</font></b></td>");
			Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt5+"</font></b></td>");
			Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt6+"</font></b></td>");
			Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt7+"</font></b></td>");
			Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt8+"</font></b></td>");
			Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt9+"</font></b></td>");
			Response.Write("<td width='8%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt10+"</font></b></td>");
			Response.Write("</tr>");
			conn1.Close();
			Response.Write("</table>");
		}
		//===========Comparision of Client Wise Outstanding============
//		void Region_Wise_Comparision_of_Outstanding()
//		{
//			conn1.Open();					
//			OracleCommand cmd2 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual",conn1);
//			string ss=Convert.ToString(cmd2.ExecuteScalar());
//			conn1.Close();
//			int ctr =70;
//			string first_page="Y";  
//			string str6="Select decode(BPO_TYPE,'R','1Railway','U','2PSU','P','3Private','F','4Foreign Railway','S','5State Government','6Un-Accounted')BPO_TYPE,BPO_RLY,BPO_ORGN,sum(NR_OUTSTANDING) NR_OUTSTANDING,sum(WR_OUTSTANDING) WR_OUTSTANDING,sum(ER_OUTSTANDING) ER_OUTSTANDING,sum(SR_OUTSTANDING) SR_OUTSTANDING From "+
//				"("+
//				"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,nvl(AMOUNT_OUTSTANDING,0) NR_OUTSTANDING,0 WR_OUTSTANDING,0 ER_OUTSTANDING,0 SR_OUTSTANDING From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and BILL_DT  <= to_date('"+txtDate.Text+"','dd/mm/yyyy') and REGION_CODE='N' "+
//				"Union All "+
//				"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 NR_OUTSTANDING,nvl(AMOUNT_OUTSTANDING,0) WR_OUTSTANDING,0 ER_OUTSTANDING,0 SR_OUTSTANDING From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and BILL_DT  <= to_date('"+txtDate.Text+"','dd/mm/yyyy') and REGION_CODE='W' "+
//				"Union All "+
//				"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 NR_OUTSTANDING,0 WR_OUTSTANDING,nvl(AMOUNT_OUTSTANDING,0) ER_OUTSTANDING,0 SR_OUTSTANDING From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and BILL_DT  <= to_date('"+txtDate.Text+"','dd/mm/yyyy') and REGION_CODE='E' "+
//				"Union All "+
//				"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 NR_OUTSTANDING,0 WR_OUTSTANDING,0 ER_OUTSTANDING,nvl(AMOUNT_OUTSTANDING,0) SR_OUTSTANDING From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and BILL_DT  <= to_date('"+txtDate.Text+"','dd/mm/yyyy') and REGION_CODE='S' "+
//				") Group By BPO_TYPE,BPO_RLY,BPO_ORGN Order By BPO_TYPE,BPO_RLY";
//			OracleCommand cmd6 = new OracleCommand(str6, conn1);
//			conn1.Open();
//			OracleDataReader reader6=cmd6.ExecuteReader();
//			double tNR=0,tWR=0,tER=0,tSR=0,tClient=0,tAllRegion=0;
//			double gtNR=0,gtWR=0,gtER=0,gtSR=0,gtAllRegion=0;
//			string wBPO_Type="";
//			while(reader6.Read())
//			{	
//				if (ctr >60) 
//				{										
//					Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
//					Response.Write("<tr bgcolor='#99cc99'>");
//					Response.Write("<td width='100%' colspan='7'>");
//					if (first_page=="N") 
//					{Response.Write("<p style = page-break-before:always></p>");}				
//					else
//					{first_page="N";}
//					Response.Write("<H5 align='center'><font face='Verdana'>Region & Client Wise Comparison of Outstanding (for the Billing Period 01/04/2008 to "+txtDate.Text+" and Cleared Till Date)</font></p>");
//					Response.Write("</td>");
//					Response.Write("</tr>");
//					Response.Write("<tr bgcolor='#faebd7'>");
//					Response.Write("<th width='15%' valign='top' align='center'><font size='1' face='Verdana'>Abbreviated Name of Railway/Client</font></th>");
//					Response.Write("<th width='30%' valign='top' align='center'><font size='1' face='Verdana'>Railway/Client</font></th>");
//					Response.Write("<th width='11%' valign='top' align='right'><font size='1' face='Verdana'> Northern Region</font></th>");
//					Response.Write("<th width='11%' valign='top' align='right'><font size='1' face='Verdana'>Western Region</font></th>");
//					Response.Write("<th width='11%' valign='top' align='right'><font size='1' face='Verdana'>Eastern Region</font></th>");
//					Response.Write("<th width='11%' valign='top' align='right'><font size='1' face='Verdana'>Southern Region</font></th>");
//					Response.Write("<th width='11%' valign='top' align='right'><font size='1' face='Verdana'>Total Outstanding</font></th>");
//					Response.Write("</tr></font>");
//					ctr =5;
//				};
//				if (reader6["BPO_TYPE"].ToString() != wBPO_Type)
//				{
//					if (wBPO_Type.ToString() !="")
//					{
//						Response.Write("<tr bgColor='#d4d0c8'>");
//						Response.Write("<td width='45%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Total For "+wBPO_Type.Substring(1)+" :</font></b></td>");
//						Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tNR+"</font></b></td>");
//						Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tWR+"</font></b></td>");
//						Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tER+"</font></b></td>");
//						Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tSR+"</font></b></td>");
//						Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tAllRegion+"</font></b></td>");
//						Response.Write("</tr>");
//						gtNR=gtNR+tNR;
//						gtWR=gtWR+tWR;
//						gtER=gtER+tER;
//						gtSR=gtSR+tSR;
//						gtAllRegion=gtAllRegion+tAllRegion;
//						tNR=0;tWR=0;tER=0;tSR=0;tAllRegion=0;
//						ctr=ctr+1;
//					}
//					wBPO_Type=reader6["BPO_TYPE"].ToString();
//					Response.Write("<tr>");
//					Response.Write("<td valign='top' align='center' colspan=7 bgcolor=#ccccff> <font size='2' face='Verdana'><b>"+wBPO_Type.Substring(1)+"</b></td>");
//					Response.Write("</tr>");
//					ctr=ctr+1;
//				}
//				Response.Write("<tr>");
//				Response.Write("<td width='15%' valign='top' align='left'><b><font size='1' face='Verdana'>"+reader6["BPO_RLY"]+"</font></b></td>");
//				Response.Write("<td width='30%' valign='top' align='left'><b><font size='1' face='Verdana'>"+reader6["BPO_ORGN"]+"</font></b></td>");
//				Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["NR_OUTSTANDING"]+"</font></b></td>");
//				Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["WR_OUTSTANDING"]+"</font></b></td>");
//				Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["ER_OUTSTANDING"]+"</font></b></td>");
//				Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["SR_OUTSTANDING"]+"</font></b></td>");
//				tClient=Convert.ToDouble(reader6["NR_OUTSTANDING"])+Convert.ToDouble(reader6["WR_OUTSTANDING"])+Convert.ToDouble(reader6["ER_OUTSTANDING"])+Convert.ToDouble(reader6["SR_OUTSTANDING"]);
//				Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tClient+"</font></b></td>");
//				tNR=tNR+Convert.ToDouble(reader6["NR_OUTSTANDING"]);
//				tWR=tWR+Convert.ToDouble(reader6["WR_OUTSTANDING"]);
//				tER=tER+Convert.ToDouble(reader6["ER_OUTSTANDING"]);
//				tSR=tSR+Convert.ToDouble(reader6["SR_OUTSTANDING"]);
//				tAllRegion=tAllRegion+tClient;
//				Response.Write("</tr>");
//				ctr=ctr+1;
//			};
//			Response.Write("<tr bgColor='#d4d0c8'>");
//			Response.Write("<td width='45%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Total For "+wBPO_Type.Substring(1)+" :</font></b></td>");
//			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tNR+"</font></b></td>");
//			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tWR+"</font></b></td>");
//			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tER+"</font></b></td>");
//			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tSR+"</font></b></td>");
//			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tAllRegion+"</font></b></td>");
//			Response.Write("</tr>");
//			gtNR=gtNR+tNR;
//			gtWR=gtWR+tWR;
//			gtER=gtER+tER;
//			gtSR=gtSR+tSR;
//			gtAllRegion=gtAllRegion+tAllRegion;
//			Response.Write("<tr bgColor='#ccccff'>");
//			Response.Write("<td width='45%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Grand Totals :</font></b></td>");
//			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gtNR+"</font></b></td>");
//			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gtWR+"</font></b></td>");
//			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gtER+"</font></b></td>");
//			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gtSR+"</font></b></td>");
//			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gtAllRegion+"</font></b></td>");
//			Response.Write("</tr>");
//			conn1.Close();
//			Response.Write("</table>");
//		}
		void Region_Wise_Comparision_of_Outstanding()
		{
			conn1.Open();					
			OracleCommand cmd2 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy - HH:MI AM') from dual",conn1);
			string ss=Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();
			int ctr =70;
			string first_page="Y";  
			string str6="Select decode(BPO_TYPE,'R','1Railway','U','2PSU','P','3Private','F','4Foreign Railway','S','5State Government','6Un-Accounted')BPO_TYPE,BPO_RLY,BPO_ORGN,sum(NR_OUTSTANDING) NR_OUTSTANDING,sum(WR_OUTSTANDING) WR_OUTSTANDING,sum(ER_OUTSTANDING) ER_OUTSTANDING,sum(SR_OUTSTANDING) SR_OUTSTANDING,sum(CR_OUTSTANDING) CR_OUTSTANDING,SUM(TOT_SUSPENSE_NR) TOT_SUSPENSE_NR,SUM(TOT_SUSPENSE_WR) TOT_SUSPENSE_WR,SUM(TOT_SUSPENSE_ER) TOT_SUSPENSE_ER,SUM(TOT_SUSPENSE_SR) TOT_SUSPENSE_SR,SUM(TOT_SUSPENSE_CR) TOT_SUSPENSE_CR From "+
				"("+
				"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,nvl(AMOUNT_OUTSTANDING,0) NR_OUTSTANDING,0 WR_OUTSTANDING,0 ER_OUTSTANDING,0 SR_OUTSTANDING,0 CR_OUTSTANDING,0 TOT_SUSPENSE_NR,0 TOT_SUSPENSE_WR,0 TOT_SUSPENSE_ER,0 TOT_SUSPENSE_SR,0 TOT_SUSPENSE_CR  From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and BILL_DT  <= to_date('"+txtDate.Text+"','dd/mm/yyyy') and REGION_CODE='N' "+
				"Union All "+
				"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 NR_OUTSTANDING,nvl(AMOUNT_OUTSTANDING,0) WR_OUTSTANDING,0 ER_OUTSTANDING,0 SR_OUTSTANDING,0 CR_OUTSTANDING,0 TOT_SUSPENSE_NR,0 TOT_SUSPENSE_WR,0 TOT_SUSPENSE_ER,0 TOT_SUSPENSE_SR,0 TOT_SUSPENSE_CR  From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and BILL_DT  <= to_date('"+txtDate.Text+"','dd/mm/yyyy') and REGION_CODE='W' "+
				"Union All "+
				"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 NR_OUTSTANDING,0 WR_OUTSTANDING,nvl(AMOUNT_OUTSTANDING,0) ER_OUTSTANDING,0 SR_OUTSTANDING,0 CR_OUTSTANDING,0 TOT_SUSPENSE_NR,0 TOT_SUSPENSE_WR,0 TOT_SUSPENSE_ER,0 TOT_SUSPENSE_SR,0 TOT_SUSPENSE_CR  From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and BILL_DT  <= to_date('"+txtDate.Text+"','dd/mm/yyyy') and REGION_CODE='E' "+
				"Union All "+
				"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 NR_OUTSTANDING,0 WR_OUTSTANDING,0 ER_OUTSTANDING,nvl(AMOUNT_OUTSTANDING,0) SR_OUTSTANDING,0 CR_OUTSTANDING,0 TOT_SUSPENSE_NR,0 TOT_SUSPENSE_WR,0 TOT_SUSPENSE_ER,0 TOT_SUSPENSE_SR,0 TOT_SUSPENSE_CR  From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and BILL_DT  <= to_date('"+txtDate.Text+"','dd/mm/yyyy') and REGION_CODE='S' "+
				"Union All "+
				"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 NR_OUTSTANDING,0 WR_OUTSTANDING,0 ER_OUTSTANDING,0 SR_OUTSTANDING,nvl(AMOUNT_OUTSTANDING,0) CR_OUTSTANDING,0 TOT_SUSPENSE_NR,0 TOT_SUSPENSE_WR,0 TOT_SUSPENSE_ER,0 TOT_SUSPENSE_SR,0 TOT_SUSPENSE_CR  From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and BILL_DT  <= to_date('"+txtDate.Text+"','dd/mm/yyyy') and REGION_CODE='C' "+
				"Union All "+
				"Select T12.BPO_TYPE BPO_TYPE,nvl(T25.BPO_CD,'00000') BPO_CD,T12.BPO_RLY BPO_RLY,T12.BPO_ORGN BPO_ORGN,0 NR_OUTSTANDING,0 WR_OUTSTANDING,0 ER_OUTSTANDING,0 SR_OUTSTANDING,0 CR_OUTSTANDING,nvl(T25.SUSPENSE_AMT,0) TOT_SUSPENSE_NR,0 TOT_SUSPENSE_WR,0 TOT_SUSPENSE_ER,0 TOT_SUSPENSE_SR,0 TOT_SUSPENSE_CR From T25_RV_DETAILS T25,T12_BILL_PAYING_OFFICER T12 Where (T25.ACC_CD not in (2709,2210,2212)) and  substr(T25.VCHR_NO,1,1)='N' and nvl(T25.BPO_CD,'00000')=T12.BPO_CD and nvl(T25.SUSPENSE_AMT,0) <> 0 "+
				"Union All "+
				"Select T12.BPO_TYPE BPO_TYPE,nvl(T25.BPO_CD,'00000') BPO_CD,T12.BPO_RLY BPO_RLY,T12.BPO_ORGN BPO_ORGN,0 NR_OUTSTANDING,0 WR_OUTSTANDING,0 ER_OUTSTANDING,0 SR_OUTSTANDING,0 CR_OUTSTANDING,0 TOT_SUSPENSE_NR,nvl(T25.SUSPENSE_AMT,0) TOT_SUSPENSE_WR,0 TOT_SUSPENSE_ER,0 TOT_SUSPENSE_SR,0 TOT_SUSPENSE_CR From T25_RV_DETAILS T25,T12_BILL_PAYING_OFFICER T12 Where (T25.ACC_CD not in (2709,2210,2212)) and  substr(T25.VCHR_NO,1,1)='W' and nvl(T25.BPO_CD,'00000')=T12.BPO_CD and nvl(T25.SUSPENSE_AMT,0) <> 0 "+
				"Union All "+
				"Select T12.BPO_TYPE BPO_TYPE,nvl(T25.BPO_CD,'00000') BPO_CD,T12.BPO_RLY BPO_RLY,T12.BPO_ORGN BPO_ORGN,0 NR_OUTSTANDING,0 WR_OUTSTANDING,0 ER_OUTSTANDING,0 SR_OUTSTANDING,0 CR_OUTSTANDING,0 TOT_SUSPENSE_NR,0 TOT_SUSPENSE_WR,nvl(T25.SUSPENSE_AMT,0) TOT_SUSPENSE_ER,0 TOT_SUSPENSE_SR,0 TOT_SUSPENSE_CR From T25_RV_DETAILS T25,T12_BILL_PAYING_OFFICER T12 Where (T25.ACC_CD not in (2709,2210,2212)) and  substr(T25.VCHR_NO,1,1)='E' and nvl(T25.BPO_CD,'00000')=T12.BPO_CD and nvl(T25.SUSPENSE_AMT,0) <> 0 "+
				"Union All "+
				"Select T12.BPO_TYPE BPO_TYPE,nvl(T25.BPO_CD,'00000') BPO_CD,T12.BPO_RLY BPO_RLY,T12.BPO_ORGN BPO_ORGN,0 NR_OUTSTANDING,0 WR_OUTSTANDING,0 ER_OUTSTANDING,0 SR_OUTSTANDING,0 CR_OUTSTANDING,0 TOT_SUSPENSE_NR,0 TOT_SUSPENSE_WR,0 TOT_SUSPENSE_ER,nvl(T25.SUSPENSE_AMT,0) TOT_SUSPENSE_SR,0 TOT_SUSPENSE_CR From T25_RV_DETAILS T25,T12_BILL_PAYING_OFFICER T12 Where (T25.ACC_CD not in (2709,2210,2212)) and  substr(T25.VCHR_NO,1,1)='S' and nvl(T25.BPO_CD,'00000')=T12.BPO_CD and nvl(T25.SUSPENSE_AMT,0) <> 0 "+
				"Union All "+
				"Select T12.BPO_TYPE BPO_TYPE,nvl(T25.BPO_CD,'00000') BPO_CD,T12.BPO_RLY BPO_RLY,T12.BPO_ORGN BPO_ORGN,0 NR_OUTSTANDING,0 WR_OUTSTANDING,0 ER_OUTSTANDING,0 SR_OUTSTANDING,0 CR_OUTSTANDING,0 TOT_SUSPENSE_NR,0 TOT_SUSPENSE_WR,0 TOT_SUSPENSE_ER,0 TOT_SUSPENSE_SR,nvl(T25.SUSPENSE_AMT,0) TOT_SUSPENSE_CR From T25_RV_DETAILS T25,T12_BILL_PAYING_OFFICER T12 Where (T25.ACC_CD not in (2709,2210,2212)) and  substr(T25.VCHR_NO,1,1)='C' and nvl(T25.BPO_CD,'00000')=T12.BPO_CD and nvl(T25.SUSPENSE_AMT,0) <> 0 "+
				") Group By BPO_TYPE,BPO_RLY,BPO_ORGN Order By BPO_TYPE,BPO_RLY";
			OracleCommand cmd6 = new OracleCommand(str6, conn1);
			conn1.Open();
			//OracleDataReader reader6=cmd6.ExecuteReader();
			OracleDataAdapter da2 = new OracleDataAdapter(str6, conn1);
			DataSet dsP2 = new DataSet();
			da2.SelectCommand = cmd6;
			da2.Fill(dsP2, "Table");
			conn1.Close();
			double tNR=0,tWR=0,tER=0,tSR=0,tCR=0,tClient=0,tAllRegion=0,sNR=0,sWR=0,sER=0,sSR=0,sCR=0,sAllRegion=0,sClient=0;
			double gtNR=0,gtWR=0,gtER=0,gtSR=0,gtCR=0,gtAllRegion=0,gsNR=0,gsWR=0,gsER=0,gsSR=0,gsCR=0,gsAllRegion=0;
			string wBPO_Type="";
			if(dsP2.Tables[0].Rows.Count >0)
			{
				for (int i = 0; i <= dsP2.Tables[0].Rows.Count - 1; i++) 
				{
					if (ctr >60) 
					{										
						Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
						Response.Write("<tr bgcolor='#99cc99'>");
						Response.Write("<td width='100%' colspan='14'>");
						if (first_page=="N") 
						{Response.Write("<p style = page-break-before:always></p>");}				
						else
						{first_page="N";}
						Response.Write("<H5 align='center'><font face='Verdana'>Region & Client Wise Comparison of Outstanding (for the Billing Period 01/04/2008 to "+txtDate.Text+" and Cleared Till Date) & Suspense Till Date &nbsp&nbsp----&nbsp&nbspStatus as on : "+ss+"</font></p>");
						Response.Write("</td>");
						Response.Write("</tr>");
						Response.Write("<tr bgcolor='#faebd7'>");
						Response.Write("<th width='15%' valign='top' align='center'><font size='1' face='Verdana'>Abbreviated Name of Railway/Client</font></th>");
						Response.Write("<th width='15%' valign='top' align='center'><font size='1' face='Verdana'>Railway/Client</font></th>");
						Response.Write("<th width='7%' valign='top' align='right'><font size='1' face='Verdana'>NR Outstanding</font></th>");
						Response.Write("<th width='7%' valign='top' align='right'><font size='1' face='Verdana'>NR Suspense</font></th>");
						Response.Write("<th width='7%' valign='top' align='right'><font size='1' face='Verdana'>WR Outstanding</font></th>");
						Response.Write("<th width='7%' valign='top' align='right'><font size='1' face='Verdana'>WR Suspense</font></th>");
						Response.Write("<th width='7%' valign='top' align='right'><font size='1' face='Verdana'>ER Outstanding</font></th>");
						Response.Write("<th width='7%' valign='top' align='right'><font size='1' face='Verdana'>ER Suspense</font></th>");
						Response.Write("<th width='7%' valign='top' align='right'><font size='1' face='Verdana'>SR Outstanding</font></th>");
						Response.Write("<th width='7%' valign='top' align='right'><font size='1' face='Verdana'>SR Suspense</font></th>");
						Response.Write("<th width='7%' valign='top' align='right'><font size='1' face='Verdana'>CR Outstanding</font></th>");
						Response.Write("<th width='7%' valign='top' align='right'><font size='1' face='Verdana'>CR Suspense</font></th>");
						Response.Write("<th width='7%' valign='top' align='right'><font size='1' face='Verdana'>Total Outstanding</font></th>");
						Response.Write("<th width='7%' valign='top' align='right'><font size='1' face='Verdana'>Total Suspense</font></th>");
						Response.Write("</tr></font>");
						ctr =5;
					};
					if (dsP2.Tables[0].Rows[i]["BPO_Type"].ToString() != wBPO_Type)
					{
						if (wBPO_Type.ToString() !="")
						{
							Response.Write("<tr bgColor='#d4d0c8'>");
							Response.Write("<td width='45%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Total For "+wBPO_Type.Substring(1)+" :</font></b></td>");
							Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tNR+"</font></b></td>");
							Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+sNR+"</font></b></td>");
							Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tWR+"</font></b></td>");
							Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+sWR+"</font></b></td>");
							Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tER+"</font></b></td>");
							Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+sER+"</font></b></td>");
							Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tSR+"</font></b></td>");
							Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+sSR+"</font></b></td>");
							Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tCR+"</font></b></td>");
							Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+sCR+"</font></b></td>");
							Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tAllRegion+"</font></b></td>");
							Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+sAllRegion+"</font></b></td>");
							Response.Write("</tr>");
							gtNR=gtNR+tNR;
							gsNR=gsNR+sNR;
							gtWR=gtWR+tWR;
							gsWR=gsWR+sWR;
							gtER=gtER+tER;
							gsER=gsER+sER;
							gtSR=gtSR+tSR;
							gsSR=gsSR+sSR;
							gtCR=gtCR+tCR;
							gsCR=gsCR+sCR;
							gtAllRegion=gtAllRegion+tAllRegion;
							gsAllRegion=gsAllRegion+sAllRegion;
							tNR=0;tWR=0;tER=0;tSR=0;tCR=0;tAllRegion=0;sNR=0;sWR=0;sER=0;sSR=0;sCR=0;sAllRegion=0;
							ctr=ctr+1;
						}
						wBPO_Type=dsP2.Tables[0].Rows[i]["BPO_Type"].ToString();
						Response.Write("<tr>");
						Response.Write("<td valign='top' align='center' colspan=14 bgcolor=#ccccff> <font size='2' face='Verdana'><b>"+wBPO_Type.Substring(1)+"</b></td>");
						Response.Write("</tr>");
						ctr=ctr+1;
					}
					Response.Write("<tr>");
					Response.Write("<td width='15%' valign='top' align='left'><b><font size='1' face='Verdana'>"+dsP2.Tables[0].Rows[i]["BPO_RLY"].ToString()+"</font></b></td>");
					Response.Write("<td width='30%' valign='top' align='left'><b><font size='1' face='Verdana'>"+dsP2.Tables[0].Rows[i]["BPO_ORGN"].ToString()+"</font></b></td>");
					Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+dsP2.Tables[0].Rows[i]["NR_OUTSTANDING"].ToString()+"</font></b></td>");
					Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_NR"].ToString()+"</font></b></td>");
					Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+dsP2.Tables[0].Rows[i]["WR_OUTSTANDING"].ToString()+"</font></b></td>");
					Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_WR"].ToString()+"</font></b></td>");
					Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+dsP2.Tables[0].Rows[i]["ER_OUTSTANDING"].ToString()+"</font></b></td>");
					Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_ER"].ToString()+"</font></b></td>");
					Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+dsP2.Tables[0].Rows[i]["SR_OUTSTANDING"].ToString()+"</font></b></td>");
					Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_SR"].ToString()+"</font></b></td>");
					Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+dsP2.Tables[0].Rows[i]["CR_OUTSTANDING"].ToString()+"</font></b></td>");
					Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_CR"].ToString()+"</font></b></td>");
					tClient=Convert.ToDouble(dsP2.Tables[0].Rows[i]["NR_OUTSTANDING"].ToString())+Convert.ToDouble(dsP2.Tables[0].Rows[i]["WR_OUTSTANDING"].ToString())+Convert.ToDouble(dsP2.Tables[0].Rows[i]["ER_OUTSTANDING"].ToString())+Convert.ToDouble(dsP2.Tables[0].Rows[i]["SR_OUTSTANDING"].ToString())+Convert.ToDouble(dsP2.Tables[0].Rows[i]["CR_OUTSTANDING"].ToString());
					sClient=Convert.ToDouble(dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_NR"].ToString())+Convert.ToDouble(dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_WR"].ToString())+Convert.ToDouble(dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_ER"].ToString())+Convert.ToDouble(dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_SR"].ToString())+Convert.ToDouble(dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_CR"].ToString());
					Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tClient+"</font></b></td>");
					//Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+sClient+"</font></b></td>");
					Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'><a href='rptSuspense_Details.aspx?BPO_TYPE="+dsP2.Tables[0].Rows[i]["BPO_RLY"]+"&CUT_OFF_DT=&WREGION=A'><b>"+sClient+"</font></b></a></font></b></td>");
					
					tNR=tNR+Convert.ToDouble(dsP2.Tables[0].Rows[i]["NR_OUTSTANDING"].ToString());
					sNR=sNR+Convert.ToDouble(dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_NR"].ToString());
					tWR=tWR+Convert.ToDouble(dsP2.Tables[0].Rows[i]["WR_OUTSTANDING"].ToString());
					sWR=sWR+Convert.ToDouble(dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_WR"].ToString());
					tER=tER+Convert.ToDouble(dsP2.Tables[0].Rows[i]["ER_OUTSTANDING"].ToString());
					sER=sER+Convert.ToDouble(dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_ER"].ToString());
					tSR=tSR+Convert.ToDouble(dsP2.Tables[0].Rows[i]["SR_OUTSTANDING"].ToString());
					sSR=sSR+Convert.ToDouble(dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_SR"].ToString());
					tCR=tCR+Convert.ToDouble(dsP2.Tables[0].Rows[i]["CR_OUTSTANDING"].ToString());
					sCR=sCR+Convert.ToDouble(dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_CR"].ToString());
					tAllRegion=tAllRegion+tClient;
					sAllRegion=sAllRegion+sClient;
					Response.Write("</tr>");
					ctr=ctr+1;
				}
			};
			Response.Write("<tr bgColor='#d4d0c8'>");
			Response.Write("<td width='45%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Total For "+wBPO_Type.Substring(1)+" :</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tNR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+sNR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tWR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+sWR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tER+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+sER+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tSR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+sSR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tCR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+sCR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tAllRegion+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+sAllRegion+"</font></b></td>");
			Response.Write("</tr>");
			gtNR=gtNR+tNR;
			gtWR=gtWR+tWR;
			gtER=gtER+tER;
			gtSR=gtSR+tSR;
			gtCR=gtCR+tCR;
			gtAllRegion=gtAllRegion+tAllRegion;
			Response.Write("<tr bgColor='#ccccff'>");
			Response.Write("<td width='45%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Grand Totals :</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gtNR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gsNR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gtWR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gsWR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gtER+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gsER+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gtSR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gsSR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gtCR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gsCR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gtAllRegion+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gsAllRegion+"</font></b></td>");
			Response.Write("</tr>");
			conn1.Close();
			Response.Write("</table>");
		}

		void Region_Wise_Comparision_of_Outstanding_sortout()
		{
			conn1.Open();					
			OracleCommand cmd2 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy - HH:MI AM') from dual",conn1);
			string ss=Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();
			int ctr =70;
			//string first_page="Y";  
			string str6="Select decode(BPO_TYPE,'R','1Railway','U','2PSU','P','3Private','F','4Foreign Railway','S','5State Government','6Un-Accounted')BPO_TYPE,BPO_RLY,BPO_ORGN,sum(NR_OUTSTANDING) NR_OUTSTANDING,sum(WR_OUTSTANDING) WR_OUTSTANDING,sum(ER_OUTSTANDING) ER_OUTSTANDING,sum(SR_OUTSTANDING) SR_OUTSTANDING,sum(CR_OUTSTANDING) CR_OUTSTANDING,SUM(TOT_SUSPENSE_NR) TOT_SUSPENSE_NR,SUM(TOT_SUSPENSE_WR) TOT_SUSPENSE_WR,SUM(TOT_SUSPENSE_ER) TOT_SUSPENSE_ER,SUM(TOT_SUSPENSE_SR) TOT_SUSPENSE_SR,SUM(TOT_SUSPENSE_CR) TOT_SUSPENSE_CR,"+
				" (sum(NR_OUTSTANDING)+sum(WR_OUTSTANDING)+sum(SR_OUTSTANDING)+sum(ER_OUTSTANDING)+sum(CR_OUTSTANDING)) tot_all_out, (SUM(TOT_SUSPENSE_NR)+SUM(TOT_SUSPENSE_WR)+SUM(TOT_SUSPENSE_SR)+SUM(TOT_SUSPENSE_ER)+SUM(TOT_SUSPENSE_CR)) tot_all_sus From "+
				"("+
				"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,nvl(AMOUNT_OUTSTANDING,0) NR_OUTSTANDING,0 WR_OUTSTANDING,0 ER_OUTSTANDING,0 SR_OUTSTANDING,0 CR_OUTSTANDING,0 TOT_SUSPENSE_NR,0 TOT_SUSPENSE_WR,0 TOT_SUSPENSE_ER,0 TOT_SUSPENSE_SR,0 TOT_SUSPENSE_CR  From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and BILL_DT  <= to_date('"+txtDate.Text+"','dd/mm/yyyy') and REGION_CODE='N' "+
				"Union All "+
				"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 NR_OUTSTANDING,nvl(AMOUNT_OUTSTANDING,0) WR_OUTSTANDING,0 ER_OUTSTANDING,0 SR_OUTSTANDING,0 CR_OUTSTANDING,0 TOT_SUSPENSE_NR,0 TOT_SUSPENSE_WR,0 TOT_SUSPENSE_ER,0 TOT_SUSPENSE_SR,0 TOT_SUSPENSE_CR  From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and BILL_DT  <= to_date('"+txtDate.Text+"','dd/mm/yyyy') and REGION_CODE='W' "+
				"Union All "+
				"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 NR_OUTSTANDING,0 WR_OUTSTANDING,nvl(AMOUNT_OUTSTANDING,0) ER_OUTSTANDING,0 SR_OUTSTANDING,0 CR_OUTSTANDING,0 TOT_SUSPENSE_NR,0 TOT_SUSPENSE_WR,0 TOT_SUSPENSE_ER,0 TOT_SUSPENSE_SR,0 TOT_SUSPENSE_CR  From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and BILL_DT  <= to_date('"+txtDate.Text+"','dd/mm/yyyy') and REGION_CODE='E' "+
				"Union All "+
				"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 NR_OUTSTANDING,0 WR_OUTSTANDING,0 ER_OUTSTANDING,nvl(AMOUNT_OUTSTANDING,0) SR_OUTSTANDING,0 CR_OUTSTANDING,0 TOT_SUSPENSE_NR,0 TOT_SUSPENSE_WR,0 TOT_SUSPENSE_ER,0 TOT_SUSPENSE_SR,0 TOT_SUSPENSE_CR  From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and BILL_DT  <= to_date('"+txtDate.Text+"','dd/mm/yyyy') and REGION_CODE='S' "+
				"Union All "+
				"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 NR_OUTSTANDING,0 WR_OUTSTANDING,0 ER_OUTSTANDING,0 SR_OUTSTANDING,nvl(AMOUNT_OUTSTANDING,0) CR_OUTSTANDING,0 TOT_SUSPENSE_NR,0 TOT_SUSPENSE_WR,0 TOT_SUSPENSE_ER,0 TOT_SUSPENSE_SR,0 TOT_SUSPENSE_CR  From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and BILL_DT  <= to_date('"+txtDate.Text+"','dd/mm/yyyy') and REGION_CODE='C' "+
				"Union All "+
				"Select T12.BPO_TYPE BPO_TYPE,nvl(T25.BPO_CD,'00000') BPO_CD,T12.BPO_RLY BPO_RLY,T12.BPO_ORGN BPO_ORGN,0 NR_OUTSTANDING,0 WR_OUTSTANDING,0 ER_OUTSTANDING,0 SR_OUTSTANDING,0 CR_OUTSTANDING,nvl(T25.SUSPENSE_AMT,0) TOT_SUSPENSE_NR,0 TOT_SUSPENSE_WR,0 TOT_SUSPENSE_ER,0 TOT_SUSPENSE_SR,0 TOT_SUSPENSE_CR From T25_RV_DETAILS T25,T12_BILL_PAYING_OFFICER T12 Where (T25.ACC_CD not in (2709,2210,2212)) and  substr(T25.VCHR_NO,1,1)='N' and nvl(T25.BPO_CD,'00000')=T12.BPO_CD and nvl(T25.SUSPENSE_AMT,0) <> 0 "+
				"Union All "+
				"Select T12.BPO_TYPE BPO_TYPE,nvl(T25.BPO_CD,'00000') BPO_CD,T12.BPO_RLY BPO_RLY,T12.BPO_ORGN BPO_ORGN,0 NR_OUTSTANDING,0 WR_OUTSTANDING,0 ER_OUTSTANDING,0 SR_OUTSTANDING,0 CR_OUTSTANDING,0 TOT_SUSPENSE_NR,nvl(T25.SUSPENSE_AMT,0) TOT_SUSPENSE_WR,0 TOT_SUSPENSE_ER,0 TOT_SUSPENSE_SR,0 TOT_SUSPENSE_CR From T25_RV_DETAILS T25,T12_BILL_PAYING_OFFICER T12 Where (T25.ACC_CD not in (2709,2210,2212)) and  substr(T25.VCHR_NO,1,1)='W' and nvl(T25.BPO_CD,'00000')=T12.BPO_CD and nvl(T25.SUSPENSE_AMT,0) <> 0 "+
				"Union All "+
				"Select T12.BPO_TYPE BPO_TYPE,nvl(T25.BPO_CD,'00000') BPO_CD,T12.BPO_RLY BPO_RLY,T12.BPO_ORGN BPO_ORGN,0 NR_OUTSTANDING,0 WR_OUTSTANDING,0 ER_OUTSTANDING,0 SR_OUTSTANDING,0 CR_OUTSTANDING,0 TOT_SUSPENSE_NR,0 TOT_SUSPENSE_WR,nvl(T25.SUSPENSE_AMT,0) TOT_SUSPENSE_ER,0 TOT_SUSPENSE_SR,0 TOT_SUSPENSE_CR From T25_RV_DETAILS T25,T12_BILL_PAYING_OFFICER T12 Where (T25.ACC_CD not in (2709,2210,2212)) and  substr(T25.VCHR_NO,1,1)='E' and nvl(T25.BPO_CD,'00000')=T12.BPO_CD and nvl(T25.SUSPENSE_AMT,0) <> 0 "+
				"Union All "+
				"Select T12.BPO_TYPE BPO_TYPE,nvl(T25.BPO_CD,'00000') BPO_CD,T12.BPO_RLY BPO_RLY,T12.BPO_ORGN BPO_ORGN,0 NR_OUTSTANDING,0 WR_OUTSTANDING,0 ER_OUTSTANDING,0 SR_OUTSTANDING,0 CR_OUTSTANDING,0 TOT_SUSPENSE_NR,0 TOT_SUSPENSE_WR,0 TOT_SUSPENSE_ER,nvl(T25.SUSPENSE_AMT,0) TOT_SUSPENSE_SR,0 TOT_SUSPENSE_CR From T25_RV_DETAILS T25,T12_BILL_PAYING_OFFICER T12 Where (T25.ACC_CD not in (2709,2210,2212)) and  substr(T25.VCHR_NO,1,1)='S' and nvl(T25.BPO_CD,'00000')=T12.BPO_CD and nvl(T25.SUSPENSE_AMT,0) <> 0 "+
				"Union All "+
				"Select T12.BPO_TYPE BPO_TYPE,nvl(T25.BPO_CD,'00000') BPO_CD,T12.BPO_RLY BPO_RLY,T12.BPO_ORGN BPO_ORGN,0 NR_OUTSTANDING,0 WR_OUTSTANDING,0 ER_OUTSTANDING,0 SR_OUTSTANDING,0 CR_OUTSTANDING,0 TOT_SUSPENSE_NR,0 TOT_SUSPENSE_WR,0 TOT_SUSPENSE_ER,0 TOT_SUSPENSE_SR,nvl(T25.SUSPENSE_AMT,0) TOT_SUSPENSE_CR From T25_RV_DETAILS T25,T12_BILL_PAYING_OFFICER T12 Where (T25.ACC_CD not in (2709,2210,2212)) and  substr(T25.VCHR_NO,1,1)='C' and nvl(T25.BPO_CD,'00000')=T12.BPO_CD and nvl(T25.SUSPENSE_AMT,0) <> 0 "+
				") Group By BPO_TYPE,BPO_RLY,BPO_ORGN Order By BPO_TYPE,tot_all_out desc,BPO_RLY";
			OracleCommand cmd6 = new OracleCommand(str6, conn1);
			conn1.Open();
			//OracleDataReader reader6=cmd6.ExecuteReader();
			OracleDataAdapter da2 = new OracleDataAdapter(str6, conn1);
			DataSet dsP2 = new DataSet();
			da2.SelectCommand = cmd6;
			da2.Fill(dsP2, "Table");
			conn1.Close();
			double tNR=0,tWR=0,tER=0,tSR=0,tCR=0,tClient=0,tAllRegion=0,sNR=0,sWR=0,sER=0,sSR=0,sCR=0,sAllRegion=0,sClient=0;
			double gtNR=0,gtWR=0,gtER=0,gtSR=0,gtCR=0,gtAllRegion=0,gsNR=0,gsWR=0,gsER=0,gsSR=0,gsCR=0,gsAllRegion=0;
			string wBPO_Type="";
			Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
			Response.Write("<tr bgcolor='#99cc99'>");
			Response.Write("<td width='100%' colspan='14'>");
			//if (first_page=="N") 
			//{Response.Write("<p style = page-break-before:always></p>");}				
			//else
			//{first_page="N";}
			Response.Write("<H5 align='center'><font face='Verdana'>Region & Client Wise Comparison of Outstanding (for the Billing Period 01/04/2008 to "+txtDate.Text+" and Cleared Till Date) & Suspense Till Date</font></p>");
			Response.Write("<H5 align='center'><font face='Verdana'>(For the Client where Total Outstanding is greater then zero or Total Suspense is greater then zero)&nbsp&nbsp----&nbsp&nbspStatus as on : "+ss+"</font></p>");
			Response.Write("</td>");
			Response.Write("</tr>");
			Response.Write("<tr bgcolor='#faebd7'>");
			Response.Write("<th width='15%' valign='top' align='center'><font size='1' face='Verdana'>Abbreviated Name of Railway/Client</font></th>");
			Response.Write("<th width='15%' valign='top' align='center'><font size='1' face='Verdana'>Railway/Client</font></th>");
			Response.Write("<th width='7%' valign='top' align='right'><font size='1' face='Verdana'>NR Outstanding</font></th>");
			Response.Write("<th width='7%' valign='top' align='right'><font size='1' face='Verdana'>NR Suspense</font></th>");
			Response.Write("<th width='7%' valign='top' align='right'><font size='1' face='Verdana'>WR Outstanding</font></th>");
			Response.Write("<th width='7%' valign='top' align='right'><font size='1' face='Verdana'>WR Suspense</font></th>");
			Response.Write("<th width='7%' valign='top' align='right'><font size='1' face='Verdana'>ER Outstanding</font></th>");
			Response.Write("<th width='7%' valign='top' align='right'><font size='1' face='Verdana'>ER Suspense</font></th>");
			Response.Write("<th width='7%' valign='top' align='right'><font size='1' face='Verdana'>SR Outstanding</font></th>");
			Response.Write("<th width='7%' valign='top' align='right'><font size='1' face='Verdana'>SR Suspense</font></th>");
			Response.Write("<th width='7%' valign='top' align='right'><font size='1' face='Verdana'>CR Outstanding</font></th>");
			Response.Write("<th width='7%' valign='top' align='right'><font size='1' face='Verdana'>CR Suspense</font></th>");
			Response.Write("<th width='7%' valign='top' align='right'><font size='1' face='Verdana'>Total Outstanding</font></th>");
			Response.Write("<th width='7%' valign='top' align='right'><font size='1' face='Verdana'>Total Suspense</font></th>");
			Response.Write("</tr></font>");
			if(dsP2.Tables[0].Rows.Count >0)
			{
				for (int i = 0; i <= dsP2.Tables[0].Rows.Count - 1; i++) 
				{
					if(Convert.ToDouble(dsP2.Tables[0].Rows[i]["tot_all_out"].ToString())>0 || Convert.ToDouble(dsP2.Tables[0].Rows[i]["tot_all_sus"].ToString())>0)
					{
						if (dsP2.Tables[0].Rows[i]["BPO_Type"].ToString() != wBPO_Type)
						{
							if (wBPO_Type.ToString() !="")
							{
								Response.Write("<tr bgColor='#d4d0c8'>");
								Response.Write("<td width='45%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Total For "+wBPO_Type.Substring(1)+" :</font></b></td>");
								Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tNR+"</font></b></td>");
								Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+sNR+"</font></b></td>");
								Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tWR+"</font></b></td>");
								Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+sWR+"</font></b></td>");
								Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tER+"</font></b></td>");
								Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+sER+"</font></b></td>");
								Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tSR+"</font></b></td>");
								Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+sSR+"</font></b></td>");
								Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tCR+"</font></b></td>");
								Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+sCR+"</font></b></td>");
								Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tAllRegion+"</font></b></td>");
								Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+sAllRegion+"</font></b></td>");
								Response.Write("</tr>");
								gtNR=gtNR+tNR;
								gsNR=gsNR+sNR;
								gtWR=gtWR+tWR;
								gsWR=gsWR+sWR;
								gtER=gtER+tER;
								gsER=gsER+sER;
								gtSR=gtSR+tSR;
								gsSR=gsSR+sSR;
								gtCR=gtCR+tCR;
								gsCR=gsCR+sCR;
								gtAllRegion=gtAllRegion+tAllRegion;
								gsAllRegion=gsAllRegion+sAllRegion;
								tNR=0;tWR=0;tER=0;tSR=0;tCR=0;tAllRegion=0;sNR=0;sWR=0;sER=0;sSR=0;sCR=0;sAllRegion=0;
								ctr=ctr+1;
							}
							wBPO_Type=dsP2.Tables[0].Rows[i]["BPO_Type"].ToString();
							Response.Write("<tr>");
							Response.Write("<td valign='top' align='center' colspan=14 bgcolor=#ccccff> <font size='2' face='Verdana'><b>"+wBPO_Type.Substring(1)+"</b></td>");
							Response.Write("</tr>");
							ctr=ctr+1;
						}
					}
					Response.Write("<tr>");
					Response.Write("<td width='15%' valign='top' align='left'><b><font size='1' face='Verdana'>"+dsP2.Tables[0].Rows[i]["BPO_RLY"].ToString()+"</font></b></td>");
					Response.Write("<td width='30%' valign='top' align='left'><b><font size='1' face='Verdana'>"+dsP2.Tables[0].Rows[i]["BPO_ORGN"].ToString()+"</font></b></td>");
					Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+dsP2.Tables[0].Rows[i]["NR_OUTSTANDING"].ToString()+"</font></b></td>");
					Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_NR"].ToString()+"</font></b></td>");
					Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+dsP2.Tables[0].Rows[i]["WR_OUTSTANDING"].ToString()+"</font></b></td>");
					Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_WR"].ToString()+"</font></b></td>");
					Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+dsP2.Tables[0].Rows[i]["ER_OUTSTANDING"].ToString()+"</font></b></td>");
					Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_ER"].ToString()+"</font></b></td>");
					Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+dsP2.Tables[0].Rows[i]["SR_OUTSTANDING"].ToString()+"</font></b></td>");
					Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_SR"].ToString()+"</font></b></td>");
					Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+dsP2.Tables[0].Rows[i]["CR_OUTSTANDING"].ToString()+"</font></b></td>");
					Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_CR"].ToString()+"</font></b></td>");
					tClient=Convert.ToDouble(dsP2.Tables[0].Rows[i]["NR_OUTSTANDING"].ToString())+Convert.ToDouble(dsP2.Tables[0].Rows[i]["WR_OUTSTANDING"].ToString())+Convert.ToDouble(dsP2.Tables[0].Rows[i]["ER_OUTSTANDING"].ToString())+Convert.ToDouble(dsP2.Tables[0].Rows[i]["SR_OUTSTANDING"].ToString())+Convert.ToDouble(dsP2.Tables[0].Rows[i]["CR_OUTSTANDING"].ToString());
					sClient=Convert.ToDouble(dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_NR"].ToString())+Convert.ToDouble(dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_WR"].ToString())+Convert.ToDouble(dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_ER"].ToString())+Convert.ToDouble(dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_SR"].ToString())+Convert.ToDouble(dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_CR"].ToString());
					Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tClient+"</font></b></td>");
					//Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+sClient+"</font></b></td>");
					Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'><a href='rptSuspense_Details.aspx?BPO_TYPE="+dsP2.Tables[0].Rows[i]["BPO_RLY"]+"&CUT_OFF_DT=&WREGION=A'><b>"+sClient+"</font></b></a></font></b></td>");
					tNR=tNR+Convert.ToDouble(dsP2.Tables[0].Rows[i]["NR_OUTSTANDING"].ToString());
					sNR=sNR+Convert.ToDouble(dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_NR"].ToString());
					tWR=tWR+Convert.ToDouble(dsP2.Tables[0].Rows[i]["WR_OUTSTANDING"].ToString());
					sWR=sWR+Convert.ToDouble(dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_WR"].ToString());
					tER=tER+Convert.ToDouble(dsP2.Tables[0].Rows[i]["ER_OUTSTANDING"].ToString());
					sER=sER+Convert.ToDouble(dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_ER"].ToString());
					tSR=tSR+Convert.ToDouble(dsP2.Tables[0].Rows[i]["SR_OUTSTANDING"].ToString());
					sSR=sSR+Convert.ToDouble(dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_SR"].ToString());
					tCR=tCR+Convert.ToDouble(dsP2.Tables[0].Rows[i]["CR_OUTSTANDING"].ToString());
					sCR=sCR+Convert.ToDouble(dsP2.Tables[0].Rows[i]["TOT_SUSPENSE_CR"].ToString());
					tAllRegion=tAllRegion+tClient;
					sAllRegion=sAllRegion+sClient;
					Response.Write("</tr>");
					ctr=ctr+1;
				}
			};
			Response.Write("<tr bgColor='#d4d0c8'>");
			Response.Write("<td width='45%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Total For "+wBPO_Type.Substring(1)+" :</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tNR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+sNR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tWR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+sWR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tER+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+sER+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tSR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+sSR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tCR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+sCR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+tAllRegion+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+sAllRegion+"</font></b></td>");
			Response.Write("</tr>");
			gtNR=gtNR+tNR;
			gtWR=gtWR+tWR;
			gtER=gtER+tER;
			gtSR=gtSR+tSR;
			gtCR=gtCR+tCR;
			gtAllRegion=gtAllRegion+tAllRegion;
			Response.Write("<tr bgColor='#ccccff'>");
			Response.Write("<td width='45%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Grand Totals :</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gtNR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gsNR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gtWR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gsWR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gtER+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gsER+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gtSR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gsSR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gtCR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gsCR+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gtAllRegion+"</font></b></td>");
			Response.Write("<td width='11%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gsAllRegion+"</font></b></td>");
			Response.Write("</tr>");
			conn1.Close();
			Response.Write("</table>");
		}

		
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
		//===========For Prabir Only ============
//		void xxPeriodic_Outstanding_Client_Wise()
//		{
//			conn1.Open();					
//			OracleCommand cmd2 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual",conn1);
//			string ss=Convert.ToString(cmd2.ExecuteScalar());
//			conn1.Close();
//			int ctr =60;
//			string first_page="Y";  
//			string str6="Select decode(BPO_TYPE,'R','1Railway','U','2PSU','P','3Private','F','4Foreign Railway','S','5State Government','6Un-Accounted')BPO_TYPE,BPO_RLY,BPO_ORGN,sum(OUT_0_6M)OUT_0_6M,sum(OUT_6_12M)OUT_6_12M,sum(SUSPENSE)SUSPENSE From "+
//				"("+
//				"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,nvl(AMOUNT_OUTSTANDING,0) OUT_0_6M,0 OUT_6_12M,0 SUSPENSE From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and (BILL_DT between to_date('01/04/2008','dd/mm/yyyy') and to_date('30/09/2008','dd/mm/yyyy')) and REGION_CODE='"+Session["Region"].ToString()+"' "+
//				"Union All "+
//				"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 OUT_0_6M,nvl(AMOUNT_OUTSTANDING,0) OUT_6_12M,0 SUSPENSE From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and (BILL_DT between to_date('01/10/2008','dd/mm/yyyy') and to_date('31/12/2008','dd/mm/yyyy')) and REGION_CODE='"+Session["Region"].ToString()+"' "+
//				"Union All "+
//				"Select T12.BPO_TYPE BPO_TYPE,nvl(T25.BPO_CD,'00000') BPO_CD,T12.BPO_RLY BPO_RLY,T12.BPO_ORGN BPO_ORGN,0 OUT_0_6M,0 OUT_6_12M,nvl(T25.SUSPENSE_AMT,0) SUSPENSE From T25_RV_DETAILS T25,T12_BILL_PAYING_OFFICER T12 Where (T25.ACC_CD not in (2709,2210,2212)) and  substr(T25.VCHR_NO,1,1)='"+Session["Region"].ToString()+"' and nvl(T25.BPO_CD,'00000')=T12.BPO_CD"+
//				") Group By BPO_TYPE,BPO_RLY,BPO_ORGN Order By BPO_TYPE,BPO_RLY";
//			OracleCommand cmd6 = new OracleCommand(str6, conn1);
//			conn1.Open();
//			OracleDataReader reader6=cmd6.ExecuteReader();
//			double t1=0,t2=0,t3=0;
//			double gt1=0,gt2=0,gt3=0;
//			string wBPO_Type="";
//			while(reader6.Read())
//			{	
//				if (ctr >50) 
//				{										
//					Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
//					Response.Write("<tr>");
//					Response.Write("<td width='100%' colspan='5'>");
//					if (first_page=="N") 
//					{Response.Write("<p style = page-break-before:always></p>");}				
//					else
//					{first_page="N";}
//					Response.Write("<H5 align='center'><font face='Verdana'>"+wRegion+" </font></p>");
//					Response.Write("<H5 align='center'><font face='Verdana'>Railway/Client Wise Outstanding (Billing upto "+txtDate.Text+" and Cleared Till Date)</font></p>");
//					Response.Write("</td>");
//					Response.Write("</tr>");
//					Response.Write("<tr>");
//					Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>Abbreviated Name of Railway/Client</font></b></th>");
//					Response.Write("<th width='35%' valign='top' align='center'><b><font size='1' face='Verdana'>Railway/Client</font></b></th>");
//					Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>01-Apr-08 to 30-Sep-08</font></b></th>");
//					Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>01-Oct-08 to 31-Dec-08</font></b></th>");
//					Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>Suspense Till Date</font></b></th>");
//					Response.Write("</tr></font>");
//					ctr =5;
//				};
//				if (reader6["BPO_TYPE"].ToString() != wBPO_Type)
//				{
//					if (wBPO_Type.ToString() !="")
//					{
//						Response.Write("<tr bgColor='#d4d0c8'>");
//						Response.Write("<td width='60%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Total For "+wBPO_Type.Substring(1)+" :</font></b></td>");
//						Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t1+"</font></b></td>");
//						Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t2+"</font></b></td>");
//						Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t3+"</font></b></td>");
//						Response.Write("</tr>");
//						gt1=gt1+t1;
//						gt2=gt2+t2;
//						gt3=gt3+t3;
//						t1=0;t2=0;t3=0;
//						ctr=ctr+1;
//					}
//					wBPO_Type=reader6["BPO_TYPE"].ToString();
//					Response.Write("<tr>");
//					Response.Write("<td valign='top' align='center' colspan=5 bgcolor=#ccccff> <font size='2' face='Verdana'><b>"+wBPO_Type.Substring(1)+"</b></td>");
//					Response.Write("</tr>");
//					ctr=ctr+1;
//				}
//				Response.Write("<tr>");
//				Response.Write("<td width='20%' valign='top' align='left'><b><font size='1' face='Verdana'>"+reader6["BPO_RLY"]+"</font></b></td>");
//				Response.Write("<td width='35%' valign='top' align='left'><b><font size='1' face='Verdana'>"+reader6["BPO_ORGN"]+"</font></b></td>");
//				Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["OUT_0_6M"]+"</font></b></td>");
//				Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["OUT_6_12M"]+"</font></b></td>");
//				Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["SUSPENSE"]+"</font></b></td>");
//				t1=t1+Convert.ToDouble(reader6["OUT_0_6M"]);
//				t2=t2+Convert.ToDouble(reader6["OUT_6_12M"]);
//				t3=t3+Convert.ToDouble(reader6["SUSPENSE"]);
//				Response.Write("</tr>");
//				ctr=ctr+1;
//			};
//			Response.Write("<tr bgColor='#d4d0c8'>");
//			Response.Write("<td width='60%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Total For "+wBPO_Type.Substring(1)+" :</font></b></td>");
//			Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t1+"</font></b></td>");
//			Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t2+"</font></b></td>");
//			Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t3+"</font></b></td>");
//			Response.Write("</tr>");
//			gt1=gt1+t1;
//			gt2=gt2+t2;
//			gt3=gt3+t3;
//			Response.Write("<tr bgColor='#ccccff'>");
//			Response.Write("<td width='60%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Grand Totals :</font></b></td>");
//			Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt1+"</font></b></td>");
//			Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt2+"</font></b></td>");
//			Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt3+"</font></b></td>");
//			Response.Write("</tr>");
//			conn1.Close();
//			Response.Write("</table>");
//		}
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//===========Client Wise Outstanding of One Region over Other============
		void Client_Wise_OtherRegion_Outstanding()
		{
			conn1.Open();					
			OracleCommand cmd2 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual",conn1);
			string ss=Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();
			int ctr =60;
			string first_page="Y";  
			string str6="Select BPO_TYPE,BPO_RLY,BPO_ORGN,sum(P_OUTSTANDING)P_OUTSTANDING,sum(C_OUTSTANDING)C_OUTSTANDING,sum(P_OUTSTANDING+C_OUTSTANDING)TOT_OUTSTANDING From "+
				"(Select decode(BPO_TYPE,'R','1Railways','2Non-Railways')BPO_TYPE,BPO_RLY,BPO_CD,BPO_ORGN,nvl(AMOUNT_OUTSTANDING,0) P_OUTSTANDING,0 C_OUTSTANDING From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and BPO_REGION='"+lstRegionCd.SelectedValue+"' and BILL_DT  <= to_date('"+wP_DtTo+"','dd/mm/yyyy') and REGION_CODE='"+Session["Region"].ToString()+"'"+
				" union all "+
				"Select decode(BPO_TYPE,'R','1Railways','2Non-Railways')BPO_TYPE,BPO_RLY,BPO_CD,BPO_ORGN,0 P_OUTSTANDING,nvl(AMOUNT_OUTSTANDING,0) C_OUTSTANDING From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and BPO_REGION='"+lstRegionCd.SelectedValue+"' and (BILL_DT  between to_date('"+wC_DtFr+"','dd/mm/yyyy') and to_date('"+txtDate.Text+"','dd/mm/yyyy')) and REGION_CODE='"+Session["Region"].ToString()+"') "+
				"Group By BPO_TYPE,BPO_RLY,BPO_ORGN Order By BPO_TYPE,BPO_RLY";
			OracleCommand cmd6 = new OracleCommand(str6, conn1);
			conn1.Open();
			OracleDataReader reader6=cmd6.ExecuteReader();
			int sno=0;
			double t1=0,t2=0,t3=0,gt1=0,gt2=0,gt3=0;
			string wBPO_Type="";
			while(reader6.Read())
			{	
				if (ctr >50) 
				{										
					Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
					Response.Write("<tr>");
					Response.Write("<td width='100%' colspan='6'>");
					if (first_page=="N") 
					{Response.Write("<p style = page-break-before:always></p>");}				
					else
					{first_page="N";}
					Response.Write("<H5 align='center'><font face='Verdana'>Outstanding of "+wRegion+" as on : "+txtDate.Text+"  On "+lstRegionCd.SelectedItem+"</font></p>");
					Response.Write("</td>");
					Response.Write("</tr>");
					Response.Write("<tr>");
					Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
					Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>Abbreviated Name of Railway/Client</font></b></th>");
					Response.Write("<th width='45%' valign='top' align='center'><b><font size='1' face='Verdana'>Railway/Client</font></b></th>");
					if (wYr=="2008") 
						{Response.Write("<td width='10%'></td>");}
					else
						{Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>"+wP_DtFr+" to "+wP_DtTo+"</font></b></th>");}
					Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>"+wC_DtFr+" to "+txtDate.Text+"</font></b></th>");
					Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Total Outstanding (and cleared till date)</font></b></th>");
					Response.Write("</tr></font>");
					ctr =5;
				};
				if (reader6["BPO_TYPE"].ToString() != wBPO_Type)
				{
					if (wBPO_Type.ToString() !="")
					{
						Response.Write("<tr bgColor='#d4d0c8'>");
						Response.Write("<td width='70%' height='20px valign='top' align='center' colspan=3><b><font size='1' face='Verdana'>Total For "+wBPO_Type.Substring(1)+" :</font></b></td>");
						if (wYr=="2008") 
						{Response.Write("<td width='10%'></td>");}
						else
						{Response.Write("<td width='10%' height='20px valign='top' align='right'><b><font size='1' face='Verdana'>"+t1+"</font></b></td>");}
						Response.Write("<td width='10%' height='20px valign='top' align='right'><b><font size='1' face='Verdana'>"+t2+"</font></b></td>");
						Response.Write("<td width='10%' height='20px valign='top' align='right'><b><font size='1' face='Verdana'>"+t3+"</font></b></td>");
						Response.Write("</tr>");
						gt1=gt1+t1;
						gt2=gt2+t2;
						gt3=gt3+t3;
						t1=0;t2=0;t3=0;
						ctr=ctr+1;
						sno=0;
					}
					wBPO_Type=reader6["BPO_TYPE"].ToString();
					Response.Write("<tr>");
					Response.Write("<td valign='center' height='30px' align='center' colspan=6 bgcolor=#ccccff> <font size='2' face='Verdana'><b>"+wBPO_Type.Substring(1)+"</b></td>");
					Response.Write("</tr>");
					ctr=ctr+1;
				}
				Response.Write("<tr>");
				sno=sno+1;
				Response.Write("<td width='5%' valign='top' align='right'><b><font size='1' face='Verdana'>"+sno+"&nbsp&nbsp</font></b></td>");
				Response.Write("<td width='20%' valign='top' align='left'><b><font size='1' face='Verdana'>&nbsp&nbsp"+reader6["BPO_RLY"]+"</font></b></td>");
				Response.Write("<td width='45%' valign='top' align='left'><b><font size='1' face='Verdana'>"+reader6["BPO_ORGN"]+"</font></b></td>");
				if (wYr=="2008") 
					{Response.Write("<td width='10%'></td>");}
				else
					{Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["P_OUTSTANDING"]+"</font></b></td>");}
				Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["C_OUTSTANDING"]+"</font></b></td>");
				Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["TOT_OUTSTANDING"]+"</font></b></td>");
				t1=t1+Convert.ToDouble(reader6["P_OUTSTANDING"]);
				t2=t2+Convert.ToDouble(reader6["C_OUTSTANDING"]);
				t3=t3+Convert.ToDouble(reader6["TOT_OUTSTANDING"]);
				Response.Write("</tr>");
				ctr=ctr+1;
			};
			Response.Write("<tr bgColor='#d4d0c8'>");
			Response.Write("<td width='70%' valign='center' height='20px' align='center' colspan=3><b><font size='1' face='Verdana'>Total For "+wBPO_Type.Substring(1)+" :</font></b></td>");
			if (wYr=="2008") 
				{Response.Write("<td width='10%'></td>");}
			else
				{Response.Write("<td width='10%' valign='center' height='20px' align='right'><b><font size='1' face='Verdana'>"+t1+"</font></b></td>");}
			Response.Write("<td width='10%' valign='center' height='20px' align='right'><b><font size='1' face='Verdana'>"+t2+"</font></b></td>");
			Response.Write("<td width='10%' valign='center' height='20px' align='right'><b><font size='1' face='Verdana'>"+t3+"</font></b></td>");
			Response.Write("</tr>");
			gt1=gt1+t1;
			gt2=gt2+t2;
			gt3=gt3+t3;
			Response.Write("<tr bgColor='#ccccff'>");
			Response.Write("<td width='70%' height='30px valign='baseline' align='center' colspan=3><b><font size='1' face='Verdana'>Grand Totals :</font></b></td>");
			if (wYr=="2008") 
				{Response.Write("<td width='10%'></td>");}
			else
				{Response.Write("<td width='10%' height='30px valign='baseline' align='right'><b><font size='1' face='Verdana'>"+gt1+"</font></b></td>");}
			Response.Write("<td width='10%' height='30px valign='baseline' align='right'><b><font size='1' face='Verdana'>"+gt2+"</font></b></td>");
			Response.Write("<td width='10%' height='30px valign='baseline' align='right'><b><font size='1' face='Verdana'>"+gt3+"</font></b></td>");
			Response.Write("</tr>");
			conn1.Close();
			Response.Write("</table>");
		}
//========================================
//		void OtherRegion_Outstanding()
//		{
//			conn1.Open();					
//			OracleCommand cmd2 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual",conn1);
//			string ss=Convert.ToString(cmd2.ExecuteScalar());
//			conn1.Close();
//			int ctr =60;
//			string first_page="Y";  
//			string str6="";
//			if(lstRegionCd.SelectedValue=="A")
//			{
//				str6="Select DECODE(BPO_REGION,'N','NORTHERN','E','EASTERN','W','WESTERN','S','SOUTHERN','C','CENTRAL','OTHER') REGION, COUNT(*) NO_OF_BILLS , SUM(nvl(AMOUNT_OUTSTANDING,0)) P_OUTSTANDING From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and BILL_DT  <= to_date('"+wP_DtTo+"','dd/mm/yyyy') and REGION_CODE='"+Session["Region"].ToString()+"' group by BPO_REGION ORDER BY BPO_REGION";
//			}
//			else
//			{
//				
//				str6="Select DECODE(BPO_REGION,'N','NORTHERN','E','EASTERN','W','WESTERN','S','SOUTHERN','C','CENTRAL','OTHER') REGION, COUNT(*) NO_OF_BILLS , SUM(nvl(AMOUNT_OUTSTANDING,0)) P_OUTSTANDING From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and BPO_REGION='"+lstRegionCd.SelectedValue+"' and BILL_DT  <= to_date('"+wP_DtTo+"','dd/mm/yyyy') and REGION_CODE='"+Session["Region"].ToString()+"' group by BPO_REGION";
//			}
//				     
//			OracleCommand cmd6 = new OracleCommand(str6, conn1);
//			conn1.Open();
//			OracleDataReader reader6=cmd6.ExecuteReader();
//			int sno=0;
//			double t1=0,t2=0,t3=0,gt1=0,gt2=0,gt3=0;
//			string wBPO_Type="";
//			while(reader6.Read())
//			{	
//				if (ctr >50) 
//				{										
//					Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='70%'>");
//					Response.Write("<tr>");
//					Response.Write("<td width='100%' colspan='6'>");
//					if (first_page=="N") 
//					{Response.Write("<p style = page-break-before:always></p>");}				
//					else
//					{first_page="N";}
//					Response.Write("<H5 align='center'><font face='Verdana'>Outstanding of "+wRegion+" as on : "+txtDate.Text+"  On "+lstRegionCd.SelectedItem+"</font></p>");
//					Response.Write("</td>");
//					Response.Write("</tr>");
//					Response.Write("<tr>");
//					Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>Region</font></b></th>");
//					Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>No. Of Bills</font></b></th>");
//					Response.Write("<th width='45%' valign='top' align='center'><b><font size='1' face='Verdana'>Outstanding Amount</font></b></th>");
//					Response.Write("</tr></font>");
//					ctr =5;
//				};
//				
//					
//				Response.Write("<tr>");
//				sno=sno+1;
//				Response.Write("<td width='5%' valign='top' align='left'><b><font size='1' face='Verdana'>"+reader6["REGION"]+"</font></b></td>");
//				Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["NO_OF_BILLS"]+"</font></b></td>");
//				Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["P_OUTSTANDING"]+"</font></b></td>");
//				t1=t1+Convert.ToDouble(reader6["P_OUTSTANDING"]);
//				//				t3=t3+Convert.ToDouble(reader6["TOT_OUTSTANDING"]);
//				Response.Write("</tr>");
//				ctr=ctr+1;
//			};
//			
//			conn1.Close();
//			Response.Write("</table>");
//		}

		void OtherRegion_Outstanding()
		{
			conn1.Open();					
			OracleCommand cmd1 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual",conn1);
			string ss=Convert.ToString(cmd1.ExecuteScalar());
			conn1.Close();
			string first_page="Y";  
			string str6="";
			
			decimal tno=0,teo=0,two=0,tso=0,tco=0,too=0;
			int tnb=0,teb=0,twb=0,tsb=0,tcb=0,tob=0;
			Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
			Response.Write("<tr>");
			Response.Write("<td width='100%' colspan='13'>");
			if (first_page=="N") 
			{Response.Write("<p style = page-break-before:always></p>");}				
			else
			{first_page="N";}
			Response.Write("<H5 align='center'><font face='Verdana'>Outstanding of All Region as on : "+txtDate.Text+"  On Other Regions</font></p>");
			Response.Write("</td>");
			Response.Write("</tr>");
			Response.Write("<tr><th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'></font></b></th><th width='5%' valign='top' align='center' colspan=12><b><font size='2' face='Verdana'><u>Outstanding to be chased by the Region</U</font></b></th></tr>");
			Response.Write("<tr>");
			Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'></font></b></th>");
			Response.Write("<th width='5%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Northern</font></b></th>");
			Response.Write("<th width='5%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Eastern</font></b></th>");
			Response.Write("<th width='5%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Western</font></b></th>");
			Response.Write("<th width='5%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Southern</font></b></th>");
			Response.Write("<th width='5%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Central</font></b></th>");
			Response.Write("<th width='5%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Other</font></b></th>");
			Response.Write("</tr></font>");
			Response.Write("<tr>");
			Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'><U>Outstanding bills of the Region</U></font></b></th>");
			Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>No. Of Bills</font></b></th>");
			Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Outstanding Amount</font></b></th>");
			Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>No. Of Bills</font></b></th>");
			Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Outstanding Amount</font></b></th>");
			Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>No. Of Bills</font></b></th>");
			Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Outstanding Amount</font></b></th>");
			Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>No. Of Bills</font></b></th>");
			Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Outstanding Amount</font></b></th>");
			Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>No. Of Bills</font></b></th>");
			Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Outstanding Amount</font></b></th>");
			Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>No. Of Bills</font></b></th>");
			Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Outstanding Amount</font></b></th>");
			Response.Write("</tr></font>");
			
			OracleCommand cmd2;
			char[] region1 = new char[5]{'N','E','W','S','C'};
			char[] region2 = new char[6]{'N','E','W','S','C','O'};
			string wRegion="";
			for (int i = 0; i < 5; i++)
			{
				Response.Write("<tr>");
				if (region1[i].ToString()=="N")  {wRegion="Northern";}
				else if (region1[i].ToString()=="S") {wRegion="Southern";}
				else if (region1[i].ToString()=="E") {wRegion="Eastern";}
				else if (region1[i].ToString()=="W") {wRegion="Western";}
				else if (region1[i].ToString()=="C") {wRegion="Central";}
				Response.Write("<td width='5%' valign='top' align='CENTER'><b><font size='1' face='Verdana'><U>"+wRegion+"</U></font></b></td>");
				string val="";	
				int noofbils=0;
				decimal valofbills=0;
				for (int f = 0; f < 6; f++)
				{
					val="";
					noofbils=0;
					valofbills=0;
					if(region2[f]=='O')
					{	
						str6="Select COUNT(*)||'/'|| SUM(nvl(AMOUNT_OUTSTANDING,0))  From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and BPO_REGION is null and BILL_DT  <= to_date('"+txtDate.Text+"','dd/mm/yyyy') and REGION_CODE='"+region1[i].ToString()+"' group by BPO_REGION";
					}
					else
					{
						str6="Select COUNT(*)||'/'|| SUM(nvl(AMOUNT_OUTSTANDING,0)) From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and BPO_REGION='"+region2[f].ToString()+"' and BILL_DT  <= to_date('"+txtDate.Text+"','dd/mm/yyyy') and REGION_CODE='"+region1[i].ToString()+"' group by BPO_REGION";
					}
					cmd2 =new OracleCommand(str6,conn1);
					conn1.Open();
					val=Convert.ToString(cmd2.ExecuteScalar());
					if(val!="")
					{

						noofbils=Convert.ToInt32(val.Substring(0,val.IndexOf('/')));
						valofbills=Convert.ToDecimal(val.Substring(val.IndexOf('/')+1,val.Length-(val.IndexOf('/')+1)));
					}
					else
					{
						noofbils=0;
						valofbills=0;
					}
					conn1.Close();
					Response.Write("<td width='5%' valign='top' align='right'><font size='1' face='Verdana'>"+noofbils+"</font></td>");
					Response.Write("<td width='10%' valign='top' align='right'><font size='1' face='Verdana'>"+valofbills+"</font></td>");
					if(region2[f].ToString()=="N")
					{
						tnb=tnb+noofbils;
						tno=tno+valofbills;
					}
					else if(region2[f].ToString()=="S")
					{
						tsb=tsb+noofbils;
						tso=tso+valofbills;
					}
					else if(region2[f].ToString()=="W")
					{
						twb=twb+noofbils;
						two=two+valofbills;
					}
					else if(region2[f].ToString()=="E")
					{
						teb=teb+noofbils;
						teo=teo+valofbills;
					}
					else if(region2[f].ToString()=="C")
					{
						tcb=tcb+noofbils;
						tco=tco+valofbills;
					}
					else
					{
						tob=tob+noofbils;
						too=too+valofbills;
					}

				}
				
				Response.Write("</tr>");
			}
			

			conn1.Close();
			Response.Write("<tr>");
			Response.Write("<td width='5%' valign='top' align='center'><b><font size='1' face='Verdana'></font>Total: </b></th>");
			Response.Write("<td width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>"+tnb+"</font></b></th>");
			Response.Write("<td width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>"+tno+"</font></b></th>");
			Response.Write("<td width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>"+teb+"</font></b></th>");
			Response.Write("<td width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>"+teo+"</font></b></th>");
			Response.Write("<td width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>"+twb+"</font></b></th>");
			Response.Write("<td width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>"+two+"</font></b></th>");
			Response.Write("<td width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>"+tsb+"</font></b></th>");
			Response.Write("<td width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>"+tso+"</font></b></th>");
			Response.Write("<td width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>"+tcb+"</font></b></th>");
			Response.Write("<td width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>"+tco+"</font></b></th>");
			Response.Write("<td width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>"+tob+"</font></b></th>");
			Response.Write("<td width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>"+too+"</font></b></th>");
			Response.Write("</tr></font>");
			Response.Write("</table>");
		}



//==========================================

		//===========For Audit - Periodical Breakup of Client Wise Outstanding============
		void Audit_Periodic_OS_Client_Wise()
		{
			conn1.Open();					
			OracleCommand cmd2 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual",conn1);
			string ss=Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();
			int ctr =70;
			string first_page="Y";  
			string str6="Select decode(BPO_TYPE,'R','1Railway','U','2PSU','P','3Private','F','4Foreign Railway','S','5State Government','6Un-Accounted')BPO_TYPE,BPO_RLY,BPO_ORGN,sum(OUT_0_6M)OUT_0_6M,sum(OUT_6_12M)OUT_6_12M,sum(SUSPENSE)SUSPENSE From "+
				"("+
				"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,nvl(OUTSTANDING,0) OUT_0_6M,0 OUT_6_12M,0 SUSPENSE From TEMP22_BILL  Where OUTSTANDING  > 0 and (BILL_DT between add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy')+1,-6) and to_date('"+txtDate.Text+"','dd/mm/yyyy')) and REGION_CODE='"+Session["Region"].ToString()+"' "+
				"Union All "+
				"Select BPO_TYPE,BPO_CD,BPO_RLY,BPO_ORGN,0 OUT_0_6M,nvl(OUTSTANDING,0) OUT_6_12M,0 SUSPENSE From TEMP22_BILL Where OUTSTANDING > 0 and (BILL_DT between add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy')+1,-12) and add_months(to_date('"+txtDate.Text+"','dd/mm/yyyy'),-6)) and REGION_CODE='"+Session["Region"].ToString()+"' "+
				"Union All "+
				"Select T12.BPO_TYPE BPO_TYPE,nvl(T25.BPO_CD,'00000') BPO_CD,T12.BPO_RLY BPO_RLY,T12.BPO_ORGN BPO_ORGN,0 OUT_0_6M,0 OUT_6_12M,nvl(T25.SUSPENSE,0) SUSPENSE From TEMP25_RV_DETAILS T25,T12_BILL_PAYING_OFFICER T12 Where nvl(T25.BPO_CD,'00000')=T12.BPO_CD and nvl(T25.SUSPENSE,0) > 0 and T25.REGION_CODE='"+Session["Region"].ToString()+"'"+
				") Group By BPO_TYPE,BPO_RLY,BPO_ORGN Order By BPO_TYPE,BPO_RLY";
			OracleCommand cmd6 = new OracleCommand(str6, conn1);
			conn1.Open();
			OracleDataReader reader6=cmd6.ExecuteReader();
			double t1=0,t2=0,t3=0;
			double gt1=0,gt2=0,gt3=0;
			string wBPO_Type="";
			while(reader6.Read())
			{	
				if (ctr >66) 
				{										
					Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
					Response.Write("<tr>");
					Response.Write("<td width='100%' colspan='5'>");
					if (first_page=="N") 
					{Response.Write("<p style = page-break-before:always></p>");}				
					else
					{first_page="N";}
					Response.Write("<H5 align='center'><font face='Verdana'>"+wRegion+" </font></p>");
					Response.Write("<H5 align='center'><font face='Verdana'>Railway/Client Wise Outstanding (Billing upto "+txtDate.Text+" and Cleared Till "+txtDate.Text+")</font></p>");
					Response.Write("</td>");
					Response.Write("</tr>");
					Response.Write("<tr>");
					Response.Write("<th width='20%' valign='top' align='center'><b><font size='1' face='Verdana'>Abbreviated Name of Railway/Client</font></b></th>");
					Response.Write("<th width='35%' valign='top' align='center'><b><font size='1' face='Verdana'>Railway/Client</font></b></th>");
					Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>0-6 Months</font></b></th>");
					Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>6-12 Months</font></b></th>");
					Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>Suspense Till "+txtDate.Text+"</font></b></th>");
					Response.Write("</tr></font>");
					ctr =5;
				};
				if (reader6["BPO_TYPE"].ToString() != wBPO_Type)
				{
					if (wBPO_Type.ToString() !="")
					{
						Response.Write("<tr bgColor='#d4d0c8'>");
						Response.Write("<td width='60%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Total For "+wBPO_Type.Substring(1)+" :</font></b></td>");
						Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t1+"</font></b></td>");
						Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t2+"</font></b></td>");
						Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t3+"</font></b></td>");
						Response.Write("</tr>");
						gt1=gt1+t1;
						gt2=gt2+t2;
						gt3=gt3+t3;
						t1=0;t2=0;t3=0;
						ctr=ctr+1;
					}
					wBPO_Type=reader6["BPO_TYPE"].ToString();
					Response.Write("<tr>");
					Response.Write("<td valign='top' align='center' colspan=5 bgcolor=#ccccff> <font size='2' face='Verdana'><b>"+wBPO_Type.Substring(1)+"</b></td>");
					Response.Write("</tr>");
					ctr=ctr+1;
				}
				Response.Write("<tr>");
				Response.Write("<td width='20%' valign='top' align='left'><b><font size='1' face='Verdana'>"+reader6["BPO_RLY"]+"</font></b></td>");
				Response.Write("<td width='35%' valign='top' align='left'><b><font size='1' face='Verdana'>"+reader6["BPO_ORGN"]+"</font></b></td>");
				Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["OUT_0_6M"]+"</font></b></td>");
				Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["OUT_6_12M"]+"</font></b></td>");
				Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["SUSPENSE"]+"</font></b></td>");
				t1=t1+Convert.ToDouble(reader6["OUT_0_6M"]);
				t2=t2+Convert.ToDouble(reader6["OUT_6_12M"]);
				t3=t3+Convert.ToDouble(reader6["SUSPENSE"]);
				Response.Write("</tr>");
				ctr=ctr+1;
			};
			Response.Write("<tr bgColor='#d4d0c8'>");
			Response.Write("<td width='60%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Total For "+wBPO_Type.Substring(1)+" :</font></b></td>");
			Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t1+"</font></b></td>");
			Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t2+"</font></b></td>");
			Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+t3+"</font></b></td>");
			Response.Write("</tr>");
			gt1=gt1+t1;
			gt2=gt2+t2;
			gt3=gt3+t3;
			Response.Write("<tr bgColor='#ccccff'>");
			Response.Write("<td width='60%' valign='top' align='center' colspan=2><b><font size='1' face='Verdana'>Grand Totals :</font></b></td>");
			Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt1+"</font></b></td>");
			Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt2+"</font></b></td>");
			Response.Write("<td width='15%' valign='top' align='right'><b><font size='1' face='Verdana'>"+gt3+"</font></b></td>");
			Response.Write("</tr>");
			conn1.Close();
			Response.Write("</table>");
		}

//===========BPO Wise Outstanding of One Region over Other============
		void BPO_Wise_OtherRegion_Outstanding()
		{
			conn1.Open();					
			OracleCommand cmd2 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual",conn1);
			string ss=Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();
			int ctr =60;
			string first_page="Y";  
			string str6="Select BPO_TYPE,BPO_RLY,BPO_CD,BPONAME,sum(P_OUTSTANDING)P_OUTSTANDING,sum(C_OUTSTANDING)C_OUTSTANDING,sum(P_OUTSTANDING+C_OUTSTANDING)TOT_OUTSTANDING From"+
				"(Select decode(BPO_TYPE,'R','1Railways','2Non-Railways')BPO_TYPE,BPO_RLY,BPO_CD,(trim(BPO_NAME)||nvl2(trim(BPO_ADD),','||trim(BPO_ADD),'')||nvl2(trim(BPO_CITY),','||trim(BPO_CITY),''))BPONAME,nvl(AMOUNT_OUTSTANDING,0) P_OUTSTANDING,0 C_OUTSTANDING From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and BPO_REGION='"+lstRegionCd.SelectedValue+"' and BILL_DT  <= to_date('"+wP_DtTo+"','dd/mm/yyyy') and REGION_CODE='"+Session["Region"].ToString()+"' "+
				"union all "+
				"Select decode(BPO_TYPE,'R','1Railways','2Non-Railways')BPO_TYPE,BPO_RLY,BPO_CD,(trim(BPO_NAME)||nvl2(trim(BPO_ADD),','||trim(BPO_ADD),'')||nvl2(trim(BPO_CITY),','||trim(BPO_CITY),''))BPONAME,0 P_OUTSTANDING,nvl(AMOUNT_OUTSTANDING,0) C_OUTSTANDING From V22B_OUTSTANDING_BILLS Where AMOUNT_OUTSTANDING > 0 and BPO_REGION='"+lstRegionCd.SelectedValue+"' and (BILL_DT  between to_date('"+wC_DtFr+"','dd/mm/yyyy') and to_date('"+txtDate.Text+"','dd/mm/yyyy')) and REGION_CODE='"+Session["Region"].ToString()+"') "+
				"Group By BPO_TYPE,BPO_RLY,BPO_CD,BPONAME";
			OracleCommand cmd6 = new OracleCommand(str6, conn1);
			conn1.Open();
			OracleDataReader reader6=cmd6.ExecuteReader();
			int sno=0;
			double t1=0,t2=0,t3=0,gt1=0,gt2=0,gt3=0;
			string wBPO_Type="";
			while(reader6.Read())
			{	
				if (ctr >50) 
				{										
					Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
					Response.Write("<tr>");
					Response.Write("<td width='100%' colspan='7'>");
					if (first_page=="N") 
						{Response.Write("<p style = page-break-before:always></p>");}				
					else
						{first_page="N";}
					Response.Write("<H5 align='center'><font face='Verdana'>Outstanding of "+wRegion+" as on : "+txtDate.Text+"  On "+lstRegionCd.SelectedItem+"</font></p>");
					Response.Write("</td>");
					Response.Write("</tr>");
					Response.Write("<tr>");
					Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
					Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Abbreviated Name of Railway/Client</font></b></th>");
					Response.Write("<th width='7%' valign='top' align='center'><b><font size='1' face='Verdana'>BPO Code</font></b></th>");
					Response.Write("<th width='48%' valign='top' align='center'><b><font size='1' face='Verdana'>BPO Name</font></b></th>");
					if (wYr=="2008") 
						{Response.Write("<td width='10%'></td>");}
					else
						{Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>"+wP_DtFr+" to "+wP_DtTo+"</font></b></th>");}
					Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>"+wC_DtFr+" to "+txtDate.Text+"</font></b></th>");
					Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Total Outstanding (and cleared till date)</font></b></th>");
					Response.Write("</tr></font>");
					ctr =5;
				};
				if (reader6["BPO_TYPE"].ToString() != wBPO_Type)
				{
					if (wBPO_Type.ToString() !="")
					{
						Response.Write("<tr bgColor='#d4d0c8'>");
						Response.Write("<td width='70%' height='20px valign='top' align='center' colspan=4><b><font size='1' face='Verdana'>Total For "+wBPO_Type.Substring(1)+" :</font></b></td>");
						if (wYr=="2008") 
							{Response.Write("<td width='10%'></td>");}
						else
							{Response.Write("<td width='10%' height='20px valign='top' align='right'><b><font size='1' face='Verdana'>"+t1+"</font></b></td>");}
						Response.Write("<td width='10%' height='20px valign='top' align='right'><b><font size='1' face='Verdana'>"+t2+"</font></b></td>");
						Response.Write("<td width='10%' height='20px valign='top' align='right'><b><font size='1' face='Verdana'>"+t3+"</font></b></td>");
						Response.Write("</tr>");
						gt1=gt1+t1;
						gt2=gt2+t2;
						gt3=gt3+t3;
						t1=0;t2=0;t3=0;
						ctr=ctr+1;
						sno=0;
					}
					wBPO_Type=reader6["BPO_TYPE"].ToString();
					Response.Write("<tr>");
					Response.Write("<td valign='center' height='30px' align='center' colspan=7 bgcolor=#ccccff> <font size='2' face='Verdana'><b>"+wBPO_Type.Substring(1)+"</b></td>");
					Response.Write("</tr>");
					ctr=ctr+1;
				}
				Response.Write("<tr>");
				sno=sno+1;
				Response.Write("<td width='5%' valign='top' align='right'><b><font size='1' face='Verdana'>"+sno+"&nbsp&nbsp</font></b></td>");
				Response.Write("<td width='10%' valign='top' align='left'><b><font size='1' face='Verdana'>&nbsp&nbsp"+reader6["BPO_RLY"]+"</font></b></td>");
				Response.Write("<td width='7%' valign='top' align='center'><b><font size='1' face='Verdana'>"+reader6["BPO_CD"]+"</font></b></td>");
				Response.Write("<td width='48%' valign='top' align='left'><b><font size='1' face='Verdana'>"+reader6["BPONAME"]+"</font></b></td>");
				if (wYr=="2008") 
					{Response.Write("<td width='10%'></td>");}
				else
					{Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["P_OUTSTANDING"]+"</font></b></td>");}
				Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["C_OUTSTANDING"]+"</font></b></td>");
				Response.Write("<td width='10%' valign='top' align='right'><b><font size='1' face='Verdana'>"+reader6["TOT_OUTSTANDING"]+"</font></b></td>");
				t1=t1+Convert.ToDouble(reader6["P_OUTSTANDING"]);
				t2=t2+Convert.ToDouble(reader6["C_OUTSTANDING"]);
				t3=t3+Convert.ToDouble(reader6["TOT_OUTSTANDING"]);
				Response.Write("</tr>");
				ctr=ctr+1;
			};
			Response.Write("<tr bgColor='#d4d0c8'>");
			Response.Write("<td width='70%' valign='center' height='20px' align='center' colspan=4><b><font size='1' face='Verdana'>Total For "+wBPO_Type.Substring(1)+" :</font></b></td>");
			if (wYr=="2008") 
				{Response.Write("<td width='10%'></td>");}
			else
				{Response.Write("<td width='10%' valign='center' height='20px' align='right'><b><font size='1' face='Verdana'>"+t1+"</font></b></td>");}
			Response.Write("<td width='10%' valign='center' height='20px' align='right'><b><font size='1' face='Verdana'>"+t2+"</font></b></td>");
			Response.Write("<td width='10%' valign='center' height='20px' align='right'><b><font size='1' face='Verdana'>"+t3+"</font></b></td>");
			Response.Write("</tr>");
			gt1=gt1+t1;
			gt2=gt2+t2;
			gt3=gt3+t3;			
			Response.Write("<tr bgColor='#ccccff'>");
			Response.Write("<td width='70%' height='30px valign='baseline' align='center' colspan=4><b><font size='1' face='Verdana'>Grand Totals :</font></b></td>");
			if (wYr=="2008") 
				{Response.Write("<td width='10%'></td>");}
			else
				{Response.Write("<td width='10%' height='30px valign='baseline' align='right'><b><font size='1' face='Verdana'>"+gt1+"</font></b></td>");}
			Response.Write("<td width='10%' height='30px valign='baseline' align='right'><b><font size='1' face='Verdana'>"+gt2+"</font></b></td>");
			Response.Write("<td width='10%' height='30px valign='baseline' align='right'><b><font size='1' face='Verdana'>"+gt3+"</font></b></td>");
			Response.Write("</tr>");
			conn1.Close();
			Response.Write("</table>");
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			Panel_1.Visible=false;
			Panel_2.Visible=false;
			wRegion="";
			if (Session["Region"].ToString()=="N")  {wRegion="Northern Region";}
			else if (Session["Region"].ToString()=="S") {wRegion="Southern Region";}
			else if (Session["Region"].ToString()=="E") {wRegion="Eastern Region";}
			else if (Session["Region"].ToString()=="W") {wRegion="Western Region";}
			else if (Session["Region"].ToString()=="C") {wRegion="Central Region";}
			
			wP_DtFr="01/04/2008";
			if (Convert.ToInt16(txtDate.Text.Substring(3,2)) > 3)	
			{wYr=txtDate.Text.Substring(6,4);}
			else
			{wYr=Convert.ToString(Convert.ToInt16(txtDate.Text.Substring(6,4))-1);}
			wP_DtTo="31/03/"+wYr;
			wC_DtFr="01/04/"+wYr;

			btnPrint.Visible=false;
			btnCancel.Visible=false;
			if(Convert.ToString(Request.Params["action"].Trim())=="F")
			{
				Client_Wise_Outstanding();
			}
			else if (Convert.ToString(Request.Params["action"].Trim())=="P")
			{
				Periodic_Outstanding_Client_Wise();
			}
			else if (Convert.ToString(Request.Params["action"].Trim())=="A")
			{
				Audit_Periodic_OS_Client_Wise();
			}
			else if (Convert.ToString(Request.Params["action"].Trim())=="R")
			{
				Region_Wise_Comparision_of_Outstanding();
			}
			else if (Convert.ToString(Request.Params["action"].Trim())=="X")
			{
				OtherRegion_Outstanding();
			}
			else if(Convert.ToString(Request.Params["action"].Trim())=="FNR")
			{
				rly_outs_chased_by_nr();
			}
			else if(Convert.ToString(Request.Params["action"].Trim())=="REF")
			{
				re_oustanding_au_wise();
			}
			else
			{
				if (btnClient.Checked==true){Client_Wise_OtherRegion_Outstanding();}
				else {BPO_Wise_OtherRegion_Outstanding();}
			}	
			Response.Write("<script language=JavaScript>window.print();</script>");
		}
		private void btnBack_Click(object sender, System.EventArgs e)
		{
			if(Convert.ToString(Request.Params["action"].Trim())=="F")
			{
				Response.Redirect("/RBS/Reports/rptOutstanding.aspx?action=F");
			}
			else if (Convert.ToString(Request.Params["action"].Trim())=="P")
			{
				Response.Redirect("/RBS/Reports/rptOutstanding.aspx?action=P");
			}
			else if (Convert.ToString(Request.Params["action"].Trim())=="A")
			{
				Response.Redirect("/RBS/Reports/rptOutstanding.aspx?action=A");
			}
			else if (Convert.ToString(Request.Params["action"].Trim())=="R")
			{
				Response.Redirect("/RBS/Reports/rptOutstanding.aspx?action=R");
			}
			else if (Convert.ToString(Request.Params["action"].Trim())=="X")
			{
				Response.Redirect("/RBS/Reports/rptOutstanding.aspx?action=X");
			}
			else if (Convert.ToString(Request.Params["action"].Trim())=="REF")
			{
				Response.Redirect("/RBS/Reports/rptOutstanding.aspx?action=REF");
			}
			else
			{
				Response.Redirect("/RBS/Reports/rptOutstanding.aspx?action=S");
			}
		}
	}
}
