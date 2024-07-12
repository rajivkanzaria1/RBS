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
using System.Data.OracleClient; 
using System.Configuration;
using Microsoft.CSharp;
using System.IO;
using RBS.Reports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Text;


namespace RBS.Reports
{
	/// <summary>
	/// Summary description for pfrmCalls.
	/// </summary>
	public class pfrmAdvanceOutstanding : System.Web.UI.Page
	{
		System.Data.OracleClient.OracleConnection conn = new System.Data.OracleClient.OracleConnection((ConfigurationSettings.AppSettings["ConnectionString"])) ;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList toMonth;
		protected System.Web.UI.WebControls.DropDownList Year;
		protected System.Web.UI.WebControls.TextBox frmDt;
		protected System.Web.UI.WebControls.TextBox toDt;
		protected System.Web.UI.WebControls.RadioButton rdbForMonth;
		protected System.Web.UI.WebControls.RadioButton ForGPer;
		protected System.Web.UI.WebControls.Button btnBack;
		protected System.Web.UI.WebControls.Panel Panel2;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.Button btnPrintP;
		protected System.Web.UI.WebControls.RadioButton rdbAll;
		protected System.Web.UI.WebControls.RadioButton rdbGIE;
		protected System.Web.UI.WebControls.DropDownList lstIE;
		protected System.Web.UI.WebControls.Label lblSIE;
		protected System.Web.UI.WebControls.Label lblIE;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.RadioButton rdbSummary;
		protected System.Web.UI.WebControls.RadioButton rdbDetail;
		int ecode=0;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSubmit.Attributes.Add("OnClick", "JavaScript:validate();"); 
			

			if (!(IsPostBack))
			{
				



				string str="select to_char(sysdate,'yyyy') from dual";
				OracleCommand cmd = new OracleCommand(str, conn); 
				conn.Open();
				int yr=Convert.ToInt32(cmd.ExecuteScalar());
				conn.Close();
				ListItem lst2 = new ListItem(); 
				for(int i=yr;i>=2008;i--)
				{
					lst2 = new ListItem(); 
					lst2.Text = i.ToString(); 
					lst2.Value = i.ToString(); 
					Year.Items.Add(lst2);
				}
				
				DataSet dsP1 = new DataSet(); 
				string str3 = "select IE_CD, IE_NAME from T09_IE where IE_REGION='"+Session["REGION"]+"' order by IE_NAME "; 
				OracleDataAdapter da = new OracleDataAdapter(str3, conn); 
				OracleCommand myOracleCommand = new OracleCommand(str3, conn); 
				ListItem lst3; 
				conn.Open(); 
				da.SelectCommand = myOracleCommand; 
				da.Fill(dsP1, "Table"); 
				for (int i = 0; i <= dsP1.Tables[0].Rows.Count - 1; i++) 
				{ 
					lst3 = new ListItem(); 
					lst3.Text = dsP1.Tables[0].Rows[i]["IE_NAME"].ToString(); 
					lst3.Value = dsP1.Tables[0].Rows[i]["IE_CD"].ToString(); 
					lstIE.Items.Add(lst3); 
				} 
				conn.Close(); 
				lstIE.Visible=false;
				lblIE.Visible=false;
				radiochange();
			

			}
			
			
		}
		void controlsVorN()
		{
			if(Convert.ToString(Request.QueryString["rep"])=="I" || Convert.ToString(Request.QueryString["rep"])=="V" || Convert.ToString(Request.QueryString["rep"])=="IV")
			{
				if(Convert.ToString(Request.QueryString["rep"])=="I" || Convert.ToString(Request.QueryString["rep"])=="IV")
				{
					lblSIE.Visible=true;
					lblIE.Visible=true;
					rdbAll.Visible=true;
					rdbGIE.Visible=true;
					lstIE.Visible=true;
					lblIE.Visible=true;
					
				}
				else if(Convert.ToString(Request.QueryString["rep"])=="V")
				{
					lblSIE.Visible=true;
					lblIE.Visible=true;
					rdbAll.Visible=true;
					rdbGIE.Visible=true;
					lstIE.Visible=false;
					lblIE.Visible=true;
					
				}
			}
			else
			{
				lblSIE.Visible=false;
				lblIE.Visible=false;
				rdbAll.Visible=false;
				rdbGIE.Visible=false;
				lstIE.Visible=false;
				lblIE.Visible=false;
				
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
			this.btnPrintP.Click += new System.EventHandler(this.btnPrintP_Click);
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			this.rdbAll.CheckedChanged += new System.EventHandler(this.rdbAll_CheckedChanged);
			this.rdbGIE.CheckedChanged += new System.EventHandler(this.rdbGIE_CheckedChanged);
			this.rdbForMonth.CheckedChanged += new System.EventHandler(this.rdbForMonth_CheckedChanged);
			this.ForGPer.CheckedChanged += new System.EventHandler(this.rdbForMonth_CheckedChanged);
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			
			
		}
		string dateconcat(string dt)
		{
			string myYear,myMonth,myDay; 
			myYear=dt.Substring(6,4);
			myMonth=dt.Substring(3,2);
			myDay=dt.Substring(0,2);
			string dt_out=myYear+myMonth+myDay;
			return (dt_out);
		}

		void radiochange()
		{
			if(rdbForMonth.Checked==true)
			{
				toMonth.Visible=true;
				Year.Visible=true;
				Label2.Text="Month";
				Label3.Text="Year";
				frmDt.Visible=false;
				toDt.Visible=false;
			}
			else
			{
				toMonth.Visible=false;
				Year.Visible=false;
				Label2.Text="Date From";
				Label3.Text="Date To";
				frmDt.Visible=true;
				toDt.Visible=true;
			}
		}
		private void rdbForMonth_CheckedChanged(object sender, System.EventArgs e)
		{
			radiochange();
		}
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			Panel2.Visible=true;
			Panel1.Visible=false;
			if(rdbDetail.Checked==true)
			{
				repadvoutdetail();
			}
			else if(rdbSummary.Checked==true) 
			{
				repadvoutsummary();
			}
		}
		void repadvoutsummary()
		{
			string wHdr_YrMth;
			string wYrMth;
			string wDtFr;
			string wDtTo;
			string wRegion="";

			
			conn.Open();
			OracleCommand cmd2 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual",conn);
			string ss=Convert.ToString(cmd2.ExecuteScalar());
			conn.Close();

			//string sql="select T09.IE_NAME,count(*)NO_OF_BILLS,sum(BILL_AMOUNT)TOT_BILL_AMOUNT,sum(NVL(BILL_AMT_CLEARED,0))TOT_BILL_AMT_CLEARED,sum(NVL(BILL_AMOUNT,0)-nvl(BILL_AMT_CLEARED,0)) TOT_OUTSTANDING from V22_BILL V22, T09_IE T09 where V22.IE_CD=T09.IE_CD and substr(BILL_NO,5,2)='03' and substr(BILL_NO,1,1)='"+Session["Region"]+"' and NVL(BILL_AMOUNT,0)-nvl(BILL_AMT_CLEARED,0) >10 ";
			string sql="select T09.IE_NAME,count(*)NO_OF_BILLS,sum(BILL_AMOUNT)TOT_BILL_AMOUNT,sum(NVL(BILL_AMT_CLEARED,0))TOT_BILL_AMT_CLEARED,sum(NVL(BILL_AMOUNT,0)-nvl(BILL_AMT_CLEARED,0)) TOT_OUTSTANDING from V22_BILL V22, T09_IE T09 where V22.IE_CD=T09.IE_CD and ADV_BILL='A' and substr(BILL_NO,1,1)='"+Session["Region"]+"' and NVL(BILL_AMOUNT,0)-nvl(BILL_AMT_CLEARED,0) >10 ";
			
			if(rdbForMonth.Checked==true)
			{
				wHdr_YrMth=toMonth.SelectedItem.Text+", "+Year.SelectedValue;
				wYrMth=Year.SelectedValue+toMonth.SelectedValue;
				sql=sql+" And to_char(V22.BILL_DT,'yyyyMM')='"+wYrMth+"'";
			}
			else
			{
				wHdr_YrMth=frmDt.Text+" to "+toDt.Text;
				wDtFr=dateconcat(frmDt.Text);
				wDtTo=dateconcat(toDt.Text);
				sql=sql+" And to_char(V22.BILL_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(V22.BILL_DT,'yyyyMMdd')<='"+wDtTo+"'";
			}
			
			if(rdbGIE.Checked==true)
			{
				sql=sql+" And V22.IE_CD='"+lstIE.SelectedValue+"'";
			}
			sql=sql+" group by T09.IE_NAME order by IE_NAME";
			if (Session["Region"].ToString()=="N")  {wRegion="Northern Region, RITES Ltd.";}
			else if (Session["Region"].ToString()=="S") {wRegion="Southern Region, RITES Ltd.";}
			else if (Session["Region"].ToString()=="E") {wRegion="Eastern Region, RITES Ltd.";}
			else if (Session["Region"].ToString()=="W") {wRegion="Western Region, RITES Ltd.";}
			else if (Session["Region"].ToString()=="C") {wRegion="Central Region, RITES Ltd.";}

			int ctr =60;
			int wSno=0;
			int wNOB=0;
			long wBAMT=0;
			long wCAMT=0;
			long wOAMT=0;
			try
			{
				OracleCommand cmd=new OracleCommand(sql,conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='6'>");
				Response.Write("<H6 align='center'><font face='Verdana'>"+wRegion+"</font><br></p>");
				Response.Write("<H6 align='right'><font face='Verdana'>Run Date: "+ss+"</font></p>");
				Response.Write("<H6 align='center'><font face='Verdana'>Summary of Advance Outstanding during "+wHdr_YrMth+"</font><br></p>");
				Response.Write("</td>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top' align='Center'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='35%' valign='top' align='Center'><b><font size='1' face='Verdana'>IE</font></b></th>");
				Response.Write("<th width='15%' valign='top' align='Center'><b><font size='1' face='Verdana'>No. Of Outstanding Bills</font></b></th>");
				Response.Write("<th width='15%' valign='top' align='Center'><b><font size='1' face='Verdana'>Total Bill Amt</font></b></th>");
				Response.Write("<th width='15%' valign='top' align='Center'><b><font size='1' face='Verdana'>Total Bill Amt Cleared</font></b></th>");
				Response.Write("<th width='15%' valign='top' align='Center'><b><font size='1' face='Verdana'>Total Outstanding</font></b></th>");
				Response.Write("</tr></font>");
				while (reader.Read())
				{
								
					wSno = wSno+1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"+wSno+"</td>");
					Response.Write("<td width='35%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["IE_NAME"]);Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='Right'> <font size='1' face='Verdana'>");Response.Write(reader["NO_OF_BILLS"]);Response.Write("</td>");
					wNOB=wNOB+Convert.ToInt32(reader["NO_OF_BILLS"]);
					Response.Write("<td width='15%' valign='top' align='Right'> <font size='1' face='Verdana'>");Response.Write(reader["TOT_BILL_AMOUNT"]);Response.Write("</td>");
					wBAMT=wBAMT+Convert.ToInt64(reader["TOT_BILL_AMOUNT"]);
					Response.Write("<td width='15%' valign='top' align='Right'> <font size='1' face='Verdana'>");Response.Write(reader["TOT_BILL_AMT_CLEARED"]);Response.Write("</td>");
					wCAMT=wCAMT+Convert.ToInt64(reader["TOT_BILL_AMT_CLEARED"]);
					Response.Write("<td width='15%' valign='top' align='Right'> <font size='1' face='Verdana'>");Response.Write(reader["TOT_OUTSTANDING"]);Response.Write("</td>");
					wOAMT=wOAMT+Convert.ToInt64(reader["TOT_OUTSTANDING"]);
					Response.Write("</tr>");
					ctr=ctr+1;
				};
		
				Response.Write("<tr>");
				Response.Write("<td>&nbsp</td>");
				Response.Write("<td width='35%' valign='top' align='Right'> <font size='1' face='Verdana'><b>Total:&nbsp&nbsp&nbsp</b></td>");
				Response.Write("<td width='15%' valign='top' align='Right'> <font size='1' face='Verdana'><b>"+wNOB+"</b></td>");
				Response.Write("<td width='15%' valign='top' align='Right'> <font size='1' face='Verdana'><b>"+wBAMT+"</b></td>");
				Response.Write("<td width='15%' valign='top' align='Right'> <font size='1' face='Verdana'><b>"+wCAMT+"</b></td>");
				Response.Write("<td width='15%' valign='top' align='Right'> <font size='1' face='Verdana'><b>"+wOAMT+"</b></td>");
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
				conn.Close();
			}
		
		}

		void repadvoutdetail()
		{
			string wHdr_YrMth;
			string wYrMth;
			string wDtFr;
			string wDtTo;
			string wRegion="";

			
			conn.Open();
			OracleCommand cmd2 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual",conn);
			string ss=Convert.ToString(cmd2.ExecuteScalar());
			conn.Close();

			//string sql="select CASE_NO,VEND_NAME,T09.IE_NAME,BK_NO,SET_NO,BILL_NO, to_char(BILL_DT,'dd/mm/yyyy')BILL_DATE,NVL(BILL_AMOUNT,0)BILL_AMOUNT,NVL(BILL_AMT_CLEARED,0)BILL_AMT_CLEARED,NVL(BILL_AMOUNT,0)-nvl(BILL_AMT_CLEARED,0) OUTSTANDING from V22_BILL V22, T09_IE T09 where V22.IE_CD=T09.IE_CD and substr(BILL_NO,6,5)>='30000' and substr(BILL_NO,1,1)='"+Session["Region"]+"' and NVL(BILL_AMOUNT,0)-nvl(BILL_AMT_CLEARED,0) >10 ";
			string sql="select CASE_NO,VEND_NAME,T09.IE_NAME,BK_NO,SET_NO,BILL_NO, to_char(BILL_DT,'dd/mm/yyyy')BILL_DATE,NVL(BILL_AMOUNT,0)BILL_AMOUNT,NVL(BILL_AMT_CLEARED,0)BILL_AMT_CLEARED,NVL(BILL_AMOUNT,0)-nvl(BILL_AMT_CLEARED,0) OUTSTANDING from V22_BILL V22, T09_IE T09 where V22.IE_CD=T09.IE_CD and ADV_BILL='A' and substr(BILL_NO,1,1)='"+Session["Region"]+"' and NVL(BILL_AMOUNT,0)-nvl(BILL_AMT_CLEARED,0) >10 ";
			
			if(rdbForMonth.Checked==true)
			{
				wHdr_YrMth=toMonth.SelectedItem.Text+", "+Year.SelectedValue;
				wYrMth=Year.SelectedValue+toMonth.SelectedValue;
				sql=sql+" And to_char(V22.BILL_DT,'yyyyMM')='"+wYrMth+"'";
			}
			else
			{
				wHdr_YrMth=frmDt.Text+" to "+toDt.Text;
				wDtFr=dateconcat(frmDt.Text);
				wDtTo=dateconcat(toDt.Text);
				sql=sql+" And to_char(V22.BILL_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(V22.BILL_DT,'yyyyMMdd')<='"+wDtTo+"'";
			}
			
			if(rdbGIE.Checked==true)
			{
				sql=sql+" And V22.IE_CD='"+lstIE.SelectedValue+"'";
			}
			sql=sql+" order by IE_NAME, V22.BILL_DT";
			if (Session["Region"].ToString()=="N")  {wRegion="Northern Region, RITES Ltd.";}
			else if (Session["Region"].ToString()=="S") {wRegion="Southern Region, RITES Ltd.";}
			else if (Session["Region"].ToString()=="E") {wRegion="Eastern Region, RITES Ltd.";}
			else if (Session["Region"].ToString()=="W") {wRegion="Western Region, RITES Ltd.";}
			else if (Session["Region"].ToString()=="C") {wRegion="Central Region, RITES Ltd.";}

			int ctr =60;
			int wSno=0;

			int wBAMT=0;
			int wCAMT=0;
			int wOAMT=0;
			try
			{
				OracleCommand cmd=new OracleCommand(sql,conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='11'>");
				Response.Write("<H6 align='center'><font face='Verdana'>"+wRegion+"</font><br></p>");
				Response.Write("<H6 align='right'><font face='Verdana'>Run Date: "+ss+"</font></p>");
				Response.Write("<H6 align='center'><font face='Verdana'>Details Of Advance Outstanding during "+wHdr_YrMth+"</font><br></p>");
				Response.Write("</td>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top' align='Right'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='Left'><b><font size='1' face='Verdana'>Case No.</font></b></th>");
				Response.Write("<th width='15%' valign='top' align='Left'><b><font size='1' face='Verdana'>Vendor</font></b></th>");						
				Response.Write("<th width='13%' valign='top' align='Left'><b><font size='1' face='Verdana'>IE</font></b></th>");
				Response.Write("<th width='8%' valign='top' align='Left'><b><font size='1' face='Verdana'>BK NO.</font></b></th>");
				Response.Write("<th width='7%' valign='top' align='Left'><b><font size='1' face='Verdana'>Set No.</font></b></th>");
				Response.Write("<th width='12%' valign='top' align='Left'><b><font size='1' face='Verdana'>Bill No.</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='Left'><b><font size='1' face='Verdana'>Bill Dt</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='Right'><b><font size='1' face='Verdana'>Bill Amt</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='Right'><b><font size='1' face='Verdana'>Bill Amt Cleared</font></b></th>");
				Response.Write("<th width='10%' valign='top' align='Right'><b><font size='1' face='Verdana'>Outstanding</font></b></th>");
				Response.Write("</tr></font>");
				while (reader.Read())
				{
								
					wSno = wSno+1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='Right'> <font size='1' face='Verdana'>"+wSno+"</td>");
					Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>");Response.Write(reader["CASE_NO"]);Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='Left'> <font size='1' face='Verdana'>");Response.Write(reader["VEND_NAME"]);Response.Write("</td>");
					Response.Write("<td width='13%' valign='top' align='Left'> <font size='1' face='Verdana'>");Response.Write(reader["IE_NAME"]);Response.Write("</td>");
					Response.Write("<td width='8%' valign='top' align='Left'> <font size='1' face='Verdana'>");Response.Write(reader["BK_NO"]);Response.Write("</td>");
					Response.Write("<td width='7%' valign='top' align='Left'> <font size='1' face='Verdana'>");Response.Write(reader["SET_NO"]);Response.Write("</td>");
					Response.Write("<td width='12%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["BILL_NO"]);Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>");Response.Write(reader["BILL_DATE"]);Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='Right'> <font size='1' face='Verdana'>");Response.Write(reader["BILL_AMOUNT"]);Response.Write("</td>");
					wBAMT=wBAMT+Convert.ToInt32(reader["BILL_AMOUNT"]);
					Response.Write("<td width='10%' valign='top' align='Right'> <font size='1' face='Verdana'>");Response.Write(reader["BILL_AMT_CLEARED"]);Response.Write("</td>");
					wCAMT=wCAMT+Convert.ToInt32(reader["BILL_AMT_CLEARED"]);
					Response.Write("<td width='10%' valign='top' align='Right'> <font size='1' face='Verdana'>");Response.Write(reader["OUTSTANDING"]);Response.Write("</td>");
					wOAMT=wOAMT+Convert.ToInt32(reader["OUTSTANDING"]);
					Response.Write("</tr>");
					ctr=ctr+1;
				};
				
				Response.Write("<tr>");
				Response.Write("<td colspan='7'>&nbsp</td>");
				Response.Write("<td width='10%' valign='top' align='Right'> <font size='1' face='Verdana'><b>Total:&nbsp&nbsp&nbsp</b></td>");
				Response.Write("<td width='10%' valign='top' align='Right'> <font size='1' face='Verdana'><b>"+wBAMT+"</b></td>");
				Response.Write("<td width='10%' valign='top' align='Right'> <font size='1' face='Verdana'><b>"+wCAMT+"</b></td>");
				Response.Write("<td width='10%' valign='top' align='Right'> <font size='1' face='Verdana'><b>"+wOAMT+"</b></td>");
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
				conn.Close();
			}
		
		}
		private void btnPrintP_Click(object sender, System.EventArgs e)
		{
			Panel1.Visible=false;
			Panel2.Visible=false;
			if(rdbDetail.Checked==true)
			{
				repadvoutdetail();
			}
			else if(rdbSummary.Checked==true) 
			{
				repadvoutsummary();
			}
			Response.Write("<script language=JavaScript>window.print();</script>");
		}

		private void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("/RBS/MainForm.aspx");
		}

		private void rdbAll_CheckedChanged(object sender, System.EventArgs e)
		{
			lstIE.Visible=false;
			lblIE.Visible=false;
			
		}

		private void rdbGIE_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rdbGIE.Checked==true)
			{
				lstIE.Visible=true;
				lblIE.Visible=true;
			}
			else
			{
				lstIE.Visible=false;
				lblIE.Visible=false;
			}
		
		}
		

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

				

		
		
	}
}
