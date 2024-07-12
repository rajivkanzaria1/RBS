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
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using Microsoft.CSharp;
using System.IO;
using RBS.Reports;
using System.Text;


namespace RBS.Reports
{
	/// <summary>
	/// Summary description for pfrmCalls.
	/// </summary>
	public class pfrmNCR : System.Web.UI.Page
	{
		OracleConnection conn = null ;
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
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.DropDownList lstCO;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.RadioButton rdbAllNCR;
		protected System.Web.UI.WebControls.RadioButton rdbOutsNCR;
		int ecode=0;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnPrint.Attributes.Add("OnClick", "JavaScript:validate();"); 
			
			conn= new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			if (!(IsPostBack))
			{
				if(Convert.ToString(Request.QueryString["rep"])=="I")
				{
					Label1.Text= "IE WISE NON CONFORMITIES REPORT";
					lblSIE.Text="Status of IE's";
					rdbAll.Text="All IE";
					rdbGIE.Text="For Given IE";
					lblIE.Text="Inspection Engineer";
					lstCO.Visible=false;
				}
				else if(Convert.ToString(Request.QueryString["rep"])=="C")
				{
					Label1.Text= "CONTROLLING MANAGER WISE NON CONFORMITIES REPORT";
					lblSIE.Text="Status of CM's";
					rdbAll.Text="All CM";
					rdbGIE.Text="For Given CM";
					lblIE.Text="Controlling Manager";
					lstIE.Visible=false;
				}
				

				


				try
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
					string str3 = "select IE_CD, IE_NAME from T09_IE where IE_STATUS is null and IE_REGION='"+Session["REGION"]+"' order by IE_NAME "; 
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

					DataSet dsP2 = new DataSet(); 
					string str2 = "select CO_CD, CO_NAME from T08_IE_CONTROLL_OFFICER where CO_STATUS is null and CO_REGION='"+Session["REGION"]+"' order by CO_NAME "; 
					OracleDataAdapter da2 = new OracleDataAdapter(str2, conn); 
					OracleCommand myOracleCommand2 = new OracleCommand(str2, conn); 
					ListItem lst1; 
					conn.Open(); 
					da2.SelectCommand = myOracleCommand2; 
					da2.Fill(dsP2, "Table"); 
					for (int i = 0; i <= dsP2.Tables[0].Rows.Count - 1; i++) 
					{ 
						lst1 = new ListItem(); 
						lst1.Text = dsP2.Tables[0].Rows[i]["CO_NAME"].ToString(); 
						lst1.Value = dsP2.Tables[0].Rows[i]["CO_CD"].ToString(); 
						lstCO.Items.Add(lst1); 
					} 
					conn.Close(); 
				}
				catch (Exception ex) 
				{ 
					string str; 
					str = ex.Message; 
					string str1=str.Replace("\n","");
					Response.Redirect(("Error_Form.aspx?err=" + str1));
				}
				finally
				{
					conn.Close(); 
					conn.Dispose();
				} 
				lstIE.Visible=false;
				lblIE.Visible=false;
				lstCO.Visible=false;
				radiochange();
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
			this.rdbAll.CheckedChanged += new System.EventHandler(this.rdbAll_CheckedChanged);
			this.rdbGIE.CheckedChanged += new System.EventHandler(this.rdbGIE_CheckedChanged);
			this.rdbForMonth.CheckedChanged += new System.EventHandler(this.rdbForMonth_CheckedChanged);
			this.ForGPer.CheckedChanged += new System.EventHandler(this.rdbForMonth_CheckedChanged);
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			
			Panel1.Visible=false;
			Panel2.Visible=true;
			if(rdbGIE.Checked==true)
			{
				repPIE_COwise();
			}
			else if(rdbAll.Checked==true)
			{
				repAllIE_COwise();
			}
			
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
		
		void repPIE_COwise()
		{
			string wHdr_YrMth;
			string wYrMth;
			string wDtFr;
			string wDtTo;
			string wRegion="";
			string wNC_NO="";
			conn= new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			conn.Open();
			OracleCommand cmd2 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual",conn);
			string ss=Convert.ToString(cmd2.ExecuteScalar());
			conn.Close();

			string sql="Select T41.NC_NO||' Dated: '||to_char(T41.NC_DT,'dd/mm/yyyy') NC_NO, CASE_NO||' ('||BK_NO||'-'||SET_NO||')' CASE_NO,ITEM_SRNO_PO||'-'||ITEM_DESC_PO ITEM,V05.VENDOR,T09.IE_NAME IE_NAME,T08.CO_NAME,NVL2(T42.NC_DESC_OTHERS,T42.NC_CD||'-'||T69.NC_DESC||'-'||T42.NC_DESC_OTHERS,T42.NC_CD||'-'||T69.NC_DESC) NC,T42.NC_CD_SNO,T42.IE_ACTION1,to_char(T42.IE_ACTION1_DT,'dd/mm/yyyy')IE_ACTION_DATE, CO_FINAL_REMARKS1, to_char(CO_FINAL_REMARKS1_DT,'dd/mm/yyyy') CO_REMARK_DATE from T41_NC_MASTER T41, T42_NC_DETAIL T42,T69_NC_CODES T69,T09_IE T09,T08_IE_CONTROLL_OFFICER T08, V05_VENDOR V05 "+
				"Where T41.NC_NO=T42.NC_NO and T42.NC_CD=T69.NC_CD and T41.IE_CD=T09.IE_CD and T41.VEND_CD=V05.VEND_CD and T41.CO_CD=T08.CO_CD ";
		
			
			if(rdbForMonth.Checked==true)
			{
				wHdr_YrMth=toMonth.SelectedItem.Text+", "+Year.SelectedValue;
				wYrMth=Year.SelectedValue+toMonth.SelectedValue;
				sql=sql+" And to_char(T41.NC_DT,'yyyyMM')='"+wYrMth+"' And T41.REGION_CODE='"+Session["Region"]+"'";
			}
			else
			{
				wHdr_YrMth=frmDt.Text+" to "+toDt.Text;
				wDtFr=dateconcat(frmDt.Text);
				wDtTo=dateconcat(toDt.Text);
				sql=sql+" And to_char(T41.NC_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T41.NC_DT,'yyyyMMdd')<='"+wDtTo+"' and T41.REGION_CODE='"+Session["Region"]+"'";
			}
			if(Convert.ToString(Request.QueryString["rep"])=="I")
			{
				sql=sql+" and T41.IE_CD="+lstIE.SelectedValue;
			}
			else if(Convert.ToString(Request.QueryString["rep"])=="C")
			{
				sql=sql+" and T41.CO_CD="+lstCO.SelectedValue;
			}
			if(rdbOutsNCR.Checked==true)
			{
				sql=sql+" and NVL(TRIM(IE_ACTION1),'X')='X'";
			}


			sql=sql+" order by T41.NC_DT,T41.NC_NO,T42.NC_CD_SNO,T42.NC_CD";
			if (Session["Region"].ToString()=="N")  {wRegion="Northern Region, RITES Ltd.";}
			else if (Session["Region"].ToString()=="S") {wRegion="Southern Region, RITES Ltd.";}
			else if (Session["Region"].ToString()=="E") {wRegion="Eastern Region, RITES Ltd.";}
			else if (Session["Region"].ToString()=="W") {wRegion="Western Region, RITES Ltd.";}
			else if (Session["Region"].ToString()=="C") {wRegion="Central Region, RITES Ltd.";}

			int ctr =60;
			int wSno=0;
//			int wNC_Codes_Sno=0;
			string first_page="Y";      
			
			try
			{
				OracleCommand cmd=new OracleCommand(sql,conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
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
						Response.Write("</td>");Response.Write("</tr>");		
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='12'>");
						Response.Write("<H6 align='center'><font face='Verdana'>"+wRegion+"</font><br></p>");
						Response.Write("<H6 align='right'><font face='Verdana'>Run Date: "+ss+"</font></p>");
						if(Convert.ToString(Request.QueryString["rep"])=="I")
						{
							Response.Write("<H6 align='center'><font face='Verdana'>IE: "+reader["IE_NAME"]+" NCR's Registered during "+wHdr_YrMth+"</font><br></p>");
						}
						else if(Convert.ToString(Request.QueryString["rep"])=="C")
						{
								Response.Write("<H6 align='center'><font face='Verdana'>CO: "+reader["CO_NAME"]+" NCR's Registered during "+wHdr_YrMth+"</font><br></p>");
						}
						Response.Write("</td>");
						
						Response.Write("<tr>");
						Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
//						if(Convert.ToString(Request.QueryString["rep"])=="I")
//						{
//							Response.Write("<th width='10%' valign='top' align='Left'><b><font size='1' face='Verdana'>IE</font></b></th>");
//						}
//						else if(Convert.ToString(Request.QueryString["rep"])=="C")
//						{
//								Response.Write("<th width='10%' valign='top' align='Left'><b><font size='1' face='Verdana'>CO</font></b></th>");
//						}
						Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Case No. (BK No-Set No.)</font></b></th>");
						Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>Vendor</font></b></th>");
						Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>NCR No.</font></b></th>");
						Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>ITEM</font></b></th>");
						Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>NCR CODES SNo.</font></b></th>");
						Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>NCR Desc</font></b></th>");
						Response.Write("<th width='10%' valign='top' align='center'><b><font size='1' face='Verdana'>IE Name</font></b></th>");
						Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>IE Remark</font></b></th>");
						Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>CM Remark</font></b></th>");
						Response.Write("</tr></font>");
						
						//wDept="";
						ctr =8;
					};
					if (wNC_NO==reader["NC_NO"].ToString()) 
					{
//						wNC_Codes_Sno=wNC_Codes_Sno+1;
						Response.Write("<tr>");
						Response.Write("<td width='5%' valign='top' align='left' colspan='5'> <font size='1' face='Verdana'>");Response.Write("");Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["NC_CD_SNO"]);Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["NC"]);Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["IE_NAME"]);Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["IE_ACTION1"]);Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["CO_FINAL_REMARKS1"]);Response.Write("</td>");
						Response.Write("</tr>");

					}
					else
					{
						wSno = wSno+1;
//						wNC_Codes_Sno=1;
						Response.Write("<tr>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"+wSno+"</td>");
//						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>");Response.Write(reader["NAME"]);Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>");Response.Write(reader["CASE_NO"]);Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["VENDOR"]);Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["NC_NO"]);Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["ITEM"]);Response.Write("</td>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["NC_CD_SNO"]);Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["NC"]);Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["IE_NAME"]);Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["IE_ACTION1"]);Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["CO_FINAL_REMARKS1"]);Response.Write("</td>");
						Response.Write("</tr>");
						wNC_NO=reader["NC_NO"].ToString();
						
						
						
					}
					
					ctr=ctr+1;
				};
				
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

		void repAllIE_COwise()
		{
			string wHdr_YrMth="";
			string wYrMth="";
			string wDtFr="";
			string wDtTo="";
			string wRegion="";
			conn= new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			int ncr_number=0;
			conn.Open();
			OracleCommand cmd2 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual",conn);
			string ss=Convert.ToString(cmd2.ExecuteScalar());
			conn.Close();
			string sql="";
//			string dt_cond="";
			if(rdbForMonth.Checked==true)
			{
				wHdr_YrMth=toMonth.SelectedItem.Text+", "+Year.SelectedValue;
				wYrMth=Year.SelectedValue+toMonth.SelectedValue;
				
			}
			else
			{
				wHdr_YrMth=frmDt.Text+" to "+toDt.Text;
				wDtFr=dateconcat(frmDt.Text);
				wDtTo=dateconcat(toDt.Text);
//				dt_cond=" And to_char(T41.NC_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T41.NC_DT,'yyyyMMdd')<='"+wDtTo+"' and T41.REGION_CODE='"+Session["Region"]+"'";
			}

			if(Convert.ToString(Request.QueryString["rep"])=="C")
			{
				if(rdbForMonth.Checked==true)
				{
					sql="select CO_NAME,sum(TOTAL_NO_CALLS) TOTAL_NO_CALLS,sum(TOTAL_NC) TOTAL_NC, sum(TOTAL_MINOR) TOTAL_MINOR,sum(TOTAL_MAJOR) TOTAL_MAJOR,sum(TOTAL_CRITICAL) TOTAL_CRITICAL, sum(NO_NC) NO_NC from (" +
						"select CO_NAME,count(*) TOTAL_NO_CALLS,0 TOTAL_NC,0 TOTAL_MINOR,0 TOTAL_MAJOR,0 TOTAL_CRITICAL,0 NO_NC from T17_CALL_REGISTER T17,T08_IE_CONTROLL_OFFICER T08 WHERE T17.CO_CD=T08.CO_CD  And to_char(T17.CALL_RECV_DT,'yyyyMM')='"+wYrMth+"' And substr(T17.CASE_NO,1,1)='"+Session["Region"]+"' group by CO_NAME UNION ALL "+
						"select CO_NAME,0 TOTAL_NO_CALLS,count(*) TOTAL_NC,0 TOTAL_MINOR,0 TOTAL_MAJOR,0 TOTAL_CRITICAL,0 NO_NC from T41_NC_MASTER T41,T08_IE_CONTROLL_OFFICER T08 WHERE T41.CO_CD=T08.CO_CD  And to_char(T41.NC_DT,'yyyyMM')='"+wYrMth+"' And T41.REGION_CODE='"+Session["Region"]+"' group by CO_NAME UNION ALL "+
						"select CO_NAME,0 TOTAL_NO_CALLS,0 TOTAL_NC,count(*) TOTAL_MINOR,0 TOTAL_MAJOR,0 TOTAL_CRITICAL,0 NO_NC from T42_NC_DETAIL T42, T41_NC_MASTER T41, T69_NC_CODES T69,T08_IE_CONTROLL_OFFICER T08 where T42.NC_NO=T41.NC_NO and T42.NC_CD=T69.NC_CD and T41.CO_CD=T08.CO_CD and T69.NC_CLASS='A'  And to_char(T41.NC_DT,'yyyyMM')='"+wYrMth+"' And T41.REGION_CODE='"+Session["Region"]+"' group by CO_NAME UNION ALL "+
						"select CO_NAME,0 TOTAL_NO_CALLS,0 TOTAL_NC,0 TOTAL_MINOR,count(*) TOTAL_MAJOR,0 TOTAL_CRITICAL,0 NO_NC from T42_NC_DETAIL T42, T41_NC_MASTER T41, T69_NC_CODES T69,T08_IE_CONTROLL_OFFICER T08 where T42.NC_NO=T41.NC_NO and T42.NC_CD=T69.NC_CD and T41.CO_CD=T08.CO_CD and T69.NC_CLASS='B'  And to_char(T41.NC_DT,'yyyyMM')='"+wYrMth+"' And T41.REGION_CODE='"+Session["Region"]+"' group by CO_NAME UNION ALL "+
						"select CO_NAME,0 TOTAL_NO_CALLS,0 TOTAL_NC,0 TOTAL_MINOR,0 TOTAL_MAJOR,count(*) TOTAL_CRITICAL,0 NO_NC from T42_NC_DETAIL T42, T41_NC_MASTER T41, T69_NC_CODES T69,T08_IE_CONTROLL_OFFICER T08 where T42.NC_NO=T41.NC_NO and T42.NC_CD=T69.NC_CD and T41.CO_CD=T08.CO_CD and T69.NC_CLASS='C'  And to_char(T41.NC_DT,'yyyyMM')='"+wYrMth+"' And T41.REGION_CODE='"+Session["Region"]+"' group by CO_NAME UNION ALL "+ 
						"select CO_NAME,0 TOTAL_NO_CALLS,0 TOTAL_NC,0 TOTAL_MINOR,0 TOTAL_MAJOR,0 TOTAL_CRITICAL,count(*) NO_NC from T42_NC_DETAIL T42, T41_NC_MASTER T41, T69_NC_CODES T69,T08_IE_CONTROLL_OFFICER T08 where T42.NC_NO=T41.NC_NO and T42.NC_CD=T69.NC_CD and T41.CO_CD=T08.CO_CD and T69.NC_CLASS='X'  And to_char(T41.NC_DT,'yyyyMM')='"+wYrMth+"' And T41.REGION_CODE='"+Session["Region"]+"' group by CO_NAME) group by CO_NAME order by CO_NAME";
				}
				else
				{
					sql="select CO_NAME,sum(TOTAL_NO_CALLS) TOTAL_NO_CALLS,sum(TOTAL_NC) TOTAL_NC, sum(TOTAL_MINOR) TOTAL_MINOR,sum(TOTAL_MAJOR) TOTAL_MAJOR,sum(TOTAL_CRITICAL) TOTAL_CRITICAL, sum(NO_NC) NO_NC  from (" +
						"select CO_NAME,count(*) TOTAL_NO_CALLS,0 TOTAL_NC,0 TOTAL_MINOR,0 TOTAL_MAJOR,0 TOTAL_CRITICAL,0 NO_NC from T17_CALL_REGISTER T17,T08_IE_CONTROLL_OFFICER T08 WHERE T17.CO_CD=T08.CO_CD   And to_char(T17.CALL_RECV_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T17.CALL_RECV_DT,'yyyyMMdd')<='"+wDtTo+"' And substr(T17.CASE_NO,1,1)='"+Session["Region"]+"' group by CO_NAME UNION ALL "+
						"select CO_NAME,0 TOTAL_NO_CALLS,count(*) TOTAL_NC,0 TOTAL_MINOR,0 TOTAL_MAJOR,0 TOTAL_CRITICAL,0 NO_NC from T41_NC_MASTER T41,T08_IE_CONTROLL_OFFICER T08 WHERE T41.CO_CD=T08.CO_CD   And to_char(T41.NC_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T41.NC_DT,'yyyyMMdd')<='"+wDtTo+"' and T41.REGION_CODE='"+Session["Region"]+"' group by CO_NAME UNION ALL "+
						"select CO_NAME,0 TOTAL_NO_CALLS,0 TOTAL_NC,count(*) TOTAL_MINOR,0 TOTAL_MAJOR,0 TOTAL_CRITICAL,0 NO_NC from T42_NC_DETAIL T42, T41_NC_MASTER T41, T69_NC_CODES T69,T08_IE_CONTROLL_OFFICER T08 where T42.NC_NO=T41.NC_NO and T42.NC_CD=T69.NC_CD and T41.CO_CD=T08.CO_CD and T69.NC_CLASS='A'  And to_char(T41.NC_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T41.NC_DT,'yyyyMMdd')<='"+wDtTo+"' and T41.REGION_CODE='"+Session["Region"]+"' group by CO_NAME UNION ALL "+
						"select CO_NAME,0 TOTAL_NO_CALLS,0 TOTAL_NC,0 TOTAL_MINOR,count(*) TOTAL_MAJOR,0 TOTAL_CRITICAL,0 NO_NC from T42_NC_DETAIL T42, T41_NC_MASTER T41, T69_NC_CODES T69,T08_IE_CONTROLL_OFFICER T08 where T42.NC_NO=T41.NC_NO and T42.NC_CD=T69.NC_CD and T41.CO_CD=T08.CO_CD and T69.NC_CLASS='B'  And to_char(T41.NC_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T41.NC_DT,'yyyyMMdd')<='"+wDtTo+"' and T41.REGION_CODE='"+Session["Region"]+"' group by CO_NAME UNION ALL "+
						"select CO_NAME,0 TOTAL_NO_CALLS,0 TOTAL_NC,0 TOTAL_MINOR,0 TOTAL_MAJOR,count(*) TOTAL_CRITICAL,0 NO_NC from T42_NC_DETAIL T42, T41_NC_MASTER T41, T69_NC_CODES T69,T08_IE_CONTROLL_OFFICER T08 where T42.NC_NO=T41.NC_NO and T42.NC_CD=T69.NC_CD and T41.CO_CD=T08.CO_CD and T69.NC_CLASS='C'  And to_char(T41.NC_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T41.NC_DT,'yyyyMMdd')<='"+wDtTo+"' and T41.REGION_CODE='"+Session["Region"]+"' group by CO_NAME UNION ALL "+
						"select CO_NAME,0 TOTAL_NO_CALLS,0 TOTAL_NC,0 TOTAL_MINOR,0 TOTAL_MAJOR,0 TOTAL_CRITICAL,count(*) NO_NC from T42_NC_DETAIL T42, T41_NC_MASTER T41, T69_NC_CODES T69,T08_IE_CONTROLL_OFFICER T08 where T42.NC_NO=T41.NC_NO and T42.NC_CD=T69.NC_CD and T41.CO_CD=T08.CO_CD and T69.NC_CLASS='X'  And to_char(T41.NC_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T41.NC_DT,'yyyyMMdd')<='"+wDtTo+"' and T41.REGION_CODE='"+Session["Region"]+"' group by CO_NAME) group by CO_NAME order by CO_NAME";
				
				}
			}
			else if(Convert.ToString(Request.QueryString["rep"])=="I")
			{
				if(rdbForMonth.Checked==true)
				{
					sql="select IE_NAME,sum(TOTAL_NO_CALLS)TOTAL_NO_CALLS,sum(TOTAL_NC) TOTAL_NC, sum(TOTAL_MINOR) TOTAL_MINOR,sum(TOTAL_MAJOR) TOTAL_MAJOR,sum(TOTAL_CRITICAL) TOTAL_CRITICAL, sum(NO_NC) NO_NC from (" +
						"select IE_NAME,count(*) TOTAL_NO_CALLS,0 TOTAL_NC,0 TOTAL_MINOR,0 TOTAL_MAJOR,0 TOTAL_CRITICAL,0 NO_NC from T17_CALL_REGISTER T17,T09_IE T09 WHERE T17.IE_CD=T09.IE_CD  And to_char(T17.CALL_RECV_DT,'yyyyMM')='"+wYrMth+"' And substr(T17.CASE_NO,1,1)='"+Session["Region"]+"' group by IE_NAME UNION ALL "+
						"select IE_NAME,0 TOTAL_NO_CALLS,count(*) TOTAL_NC,0 TOTAL_MINOR,0 TOTAL_MAJOR,0 TOTAL_CRITICAL,0 NO_NC from T41_NC_MASTER T41,T09_IE T09 WHERE T41.IE_CD=T09.IE_CD And to_char(T41.NC_DT,'yyyyMM')='"+wYrMth+"' And T41.REGION_CODE='"+Session["Region"]+"' group by IE_NAME UNION ALL "+
						"select IE_NAME,0 TOTAL_NO_CALLS,0 TOTAL_NC,count(*) TOTAL_MINOR,0 TOTAL_MAJOR,0 TOTAL_CRITICAL,0 NO_NC from T42_NC_DETAIL T42, T41_NC_MASTER T41, T69_NC_CODES T69,T09_IE T09 where T42.NC_NO=T41.NC_NO and T42.NC_CD=T69.NC_CD and T41.IE_CD=T09.IE_CD and T69.NC_CLASS='A' And to_char(T41.NC_DT,'yyyyMM')='"+wYrMth+"' And T41.REGION_CODE='"+Session["Region"]+"' group by IE_NAME UNION ALL "+
						"select IE_NAME,0 TOTAL_NO_CALLS,0 TOTAL_NC,0 TOTAL_MINOR,count(*) TOTAL_MAJOR,0 TOTAL_CRITICAL,0 NO_NC from T42_NC_DETAIL T42, T41_NC_MASTER T41, T69_NC_CODES T69,T09_IE T09 where T42.NC_NO=T41.NC_NO and T42.NC_CD=T69.NC_CD and T41.IE_CD=T09.IE_CD and T69.NC_CLASS='B' And to_char(T41.NC_DT,'yyyyMM')='"+wYrMth+"' And T41.REGION_CODE='"+Session["Region"]+"' group by IE_NAME UNION ALL "+
						"select IE_NAME,0 TOTAL_NO_CALLS,0 TOTAL_NC,0 TOTAL_MINOR,0 TOTAL_MAJOR,count(*) TOTAL_CRITICAL,0 NO_NC from T42_NC_DETAIL T42, T41_NC_MASTER T41, T69_NC_CODES T69,T09_IE T09 where T42.NC_NO=T41.NC_NO and T42.NC_CD=T69.NC_CD and T41.IE_CD=T09.IE_CD and T69.NC_CLASS='C' And to_char(T41.NC_DT,'yyyyMM')='"+wYrMth+"' And T41.REGION_CODE='"+Session["Region"]+"' group by IE_NAME UNION ALL "+
						"select IE_NAME,0 TOTAL_NO_CALLS,0 TOTAL_NC,0 TOTAL_MINOR,0 TOTAL_MAJOR,count(*) TOTAL_CRITICAL,count(*) NO_NC from T42_NC_DETAIL T42, T41_NC_MASTER T41, T69_NC_CODES T69,T09_IE T09 where T42.NC_NO=T41.NC_NO and T42.NC_CD=T69.NC_CD and T41.IE_CD=T09.IE_CD and T69.NC_CLASS='X' And to_char(T41.NC_DT,'yyyyMM')='"+wYrMth+"' And T41.REGION_CODE='"+Session["Region"]+"' group by IE_NAME ) group by IE_NAME order by IE_NAME";
				}
				else
				{
					sql="select IE_NAME,sum(TOTAL_NO_CALLS)TOTAL_NO_CALLS,sum(TOTAL_NC) TOTAL_NC, sum(TOTAL_MINOR) TOTAL_MINOR,sum(TOTAL_MAJOR) TOTAL_MAJOR,sum(TOTAL_CRITICAL) TOTAL_CRITICAL, sum(NO_NC) NO_NC from (" +
						"select IE_NAME,count(*) TOTAL_NO_CALLS,0 TOTAL_NC,0 TOTAL_MINOR,0 TOTAL_MAJOR,0 TOTAL_CRITICAL,0 NO_NC from T17_CALL_REGISTER T17,T09_IE T09 WHERE T17.IE_CD=T09.IE_CD  And to_char(T17.CALL_RECV_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T17.CALL_RECV_DT,'yyyyMMdd')<='"+wDtTo+"' And substr(T17.CASE_NO,1,1)='"+Session["Region"]+"' group by IE_NAME UNION ALL "+
						"select IE_NAME,0 TOTAL_NO_CALLS,count(*) TOTAL_NC,0 TOTAL_MINOR,0 TOTAL_MAJOR,0 TOTAL_CRITICAL,0 NO_NC from T41_NC_MASTER T41,T09_IE T09 WHERE T41.IE_CD=T09.IE_CD  And to_char(T41.NC_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T41.NC_DT,'yyyyMMdd')<='"+wDtTo+"' And T41.REGION_CODE='"+Session["Region"]+"' group by IE_NAME UNION ALL "+
						"select IE_NAME,0 TOTAL_NO_CALLS,0 TOTAL_NC,count(*) TOTAL_MINOR,0 TOTAL_MAJOR,0 TOTAL_CRITICAL,0 NO_NC from T42_NC_DETAIL T42, T41_NC_MASTER T41, T69_NC_CODES T69,T09_IE T09 where T42.NC_NO=T41.NC_NO and T42.NC_CD=T69.NC_CD and T41.IE_CD=T09.IE_CD and T69.NC_CLASS='A'  And to_char(T41.NC_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T41.NC_DT,'yyyyMMdd')<='"+wDtTo+"' And T41.REGION_CODE='"+Session["Region"]+"' group by IE_NAME UNION ALL "+
						"select IE_NAME,0 TOTAL_NO_CALLS,0 TOTAL_NC,0 TOTAL_MINOR,count(*) TOTAL_MAJOR,0 TOTAL_CRITICAL,0 NO_NC from T42_NC_DETAIL T42, T41_NC_MASTER T41, T69_NC_CODES T69,T09_IE T09 where T42.NC_NO=T41.NC_NO and T42.NC_CD=T69.NC_CD and T41.IE_CD=T09.IE_CD and T69.NC_CLASS='B'  And to_char(T41.NC_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T41.NC_DT,'yyyyMMdd')<='"+wDtTo+"' And T41.REGION_CODE='"+Session["Region"]+"' group by IE_NAME UNION ALL "+
						"select IE_NAME,0 TOTAL_NO_CALLS,0 TOTAL_NC,0 TOTAL_MINOR,0 TOTAL_MAJOR,count(*) TOTAL_CRITICAL,0 NO_NC from T42_NC_DETAIL T42, T41_NC_MASTER T41, T69_NC_CODES T69,T09_IE T09 where T42.NC_NO=T41.NC_NO and T42.NC_CD=T69.NC_CD and T41.IE_CD=T09.IE_CD and T69.NC_CLASS='C'  And to_char(T41.NC_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T41.NC_DT,'yyyyMMdd')<='"+wDtTo+"' And T41.REGION_CODE='"+Session["Region"]+"' group by IE_NAME UNION ALL "+
						"select IE_NAME,0 TOTAL_NO_CALLS,0 TOTAL_NC,0 TOTAL_MINOR,0 TOTAL_MAJOR,count(*) TOTAL_CRITICAL,count(*) NO_NC from T42_NC_DETAIL T42, T41_NC_MASTER T41, T69_NC_CODES T69,T09_IE T09 where T42.NC_NO=T41.NC_NO and T42.NC_CD=T69.NC_CD and T41.IE_CD=T09.IE_CD and T69.NC_CLASS='X'  And to_char(T41.NC_DT,'yyyyMMdd')>='"+wDtFr+"' And to_char(T41.NC_DT,'yyyyMMdd')<='"+wDtTo+"' And T41.REGION_CODE='"+Session["Region"]+"' group by IE_NAME) group by IE_NAME order by IE_NAME";
				
				}
			
			}
		
			if (Session["Region"].ToString()=="N")  {wRegion="Northern Region, RITES Ltd.";}
			else if (Session["Region"].ToString()=="S") {wRegion="Southern Region, RITES Ltd.";}
			else if (Session["Region"].ToString()=="E") {wRegion="Eastern Region, RITES Ltd.";}
			else if (Session["Region"].ToString()=="W") {wRegion="Western Region, RITES Ltd.";}
			else if (Session["Region"].ToString()=="C") {wRegion="Central Region, RITES Ltd.";}

			int ctr =60;
			int wSno=0;
			string first_page="Y";      
			
			try
			{
				OracleCommand cmd=new OracleCommand(sql,conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					ncr_number=0;
					if (ctr >50) 
					{
						Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='9'>");
						if (first_page=="N") 
						{Response.Write("<p style = page-break-before:always></p>");}				
						else
						{first_page="N";}
						Response.Write("</td>");Response.Write("</tr>");		
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='9'>");
						Response.Write("<H6 align='center'><font face='Verdana'>"+wRegion+"</font><br></p>");
						Response.Write("<H6 align='right'><font face='Verdana'>Run Date: "+ss+"</font></p>");
						if(Convert.ToString(Request.QueryString["rep"])=="I")
						{
							Response.Write("<H6 align='center'><font face='Verdana'>No. Of NCR's Registered during "+wHdr_YrMth+" (IE Wise)</font><br></p>");
						}
						else if(Convert.ToString(Request.QueryString["rep"])=="C")
						{
							Response.Write("<H6 align='center'><font face='Verdana'>No. Of NCR's Registered during "+wHdr_YrMth+"(CM Wise)</font><br></p>");
						}
						Response.Write("</td>");
						
						Response.Write("<tr>");
						Response.Write("<th width='5%' valign='top' align='center'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
						if(Convert.ToString(Request.QueryString["rep"])=="I")
						{
							Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>IE Name</font></b></th>");
						}
						else if(Convert.ToString(Request.QueryString["rep"])=="C")
						{
							Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>CM Name</font></b></th>");
						}
						Response.Write("<th width='15%' valign='top' align='center'><b><font size='1' face='Verdana'>Total No. OF Calls</font></b></th>");
						Response.Write("<th width='13%' valign='top' align='center'><b><font size='1' face='Verdana'>Total No. OF NCR</font></b></th>");
						Response.Write("<th width='13%' valign='top' align='center'><b><font size='1' face='Verdana'>Total No. OF NO NCR</font></b></th>");
						Response.Write("<th width='13%' valign='top' align='center'><b><font size='1' face='Verdana'>Total No. of Minor</font></b></th>");
						Response.Write("<th width='13%' valign='top' align='center'><b><font size='1' face='Verdana'>Total No. of Major</font></b></th>");
						Response.Write("<th width='13%' valign='top' align='center'><b><font size='1' face='Verdana'>Total No. of Critical</font></b></th>");
						Response.Write("<th width='13%' valign='top' align='center'><b><font size='1' face='Verdana'>Total NCR Marks</font></b></th>");
						Response.Write("</tr></font>");
						
						//wDept="";
						ctr =8;
					};
					
						wSno = wSno+1;
						
						Response.Write("<tr>");
						Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"+wSno+"</td>");
					if(Convert.ToString(Request.QueryString["rep"])=="I")
					{
						
						Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["IE_NAME"]);Response.Write("</td>");
					}
					else if(Convert.ToString(Request.QueryString["rep"])=="C")
					{
						Response.Write("<td width='15%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["CO_NAME"]);Response.Write("</td>");
					}
						Response.Write("<td width='15%' valign='top' align='right'> <font size='1' face='Verdana'>");Response.Write(reader["TOTAL_NO_CALLS"]);Response.Write("</td>");
						Response.Write("<td width='13%' valign='top' align='right'> <font size='1' face='Verdana'>");Response.Write(reader["TOTAL_NC"]);Response.Write("</td>");
						Response.Write("<td width='13%' valign='top' align='right'> <font size='1' face='Verdana'>");Response.Write(reader["NO_NC"]);Response.Write("</td>");
						Response.Write("<td width='13%' valign='top' align='right'> <font size='1' face='Verdana'>");Response.Write(reader["TOTAL_MINOR"]);Response.Write("</td>");
						ncr_number=ncr_number+Convert.ToInt16(reader["TOTAL_MINOR"]);
						Response.Write("<td width='13%' valign='top' align='right'> <font size='1' face='Verdana'>");Response.Write(reader["TOTAL_MAJOR"]);Response.Write("</td>");
						ncr_number=ncr_number+(2*Convert.ToInt16(reader["TOTAL_MAJOR"]));
						Response.Write("<td width='13%' valign='top' align='right'> <font size='1' face='Verdana'>");Response.Write(reader["TOTAL_CRITICAL"]);Response.Write("</td>");
						ncr_number=ncr_number+(4*Convert.ToInt16(reader["TOTAL_CRITICAL"]));
						Response.Write("<td width='13%' valign='top' align='right'> <font size='1' face='Verdana'>");Response.Write(ncr_number);Response.Write("</td>");
						Response.Write("</tr>");
						ctr=ctr+1;
				};
				
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
			if(rdbGIE.Checked==true)
			{
				repPIE_COwise();
			}
			else if(rdbAll.Checked==true)
			{
				repAllIE_COwise();
			}
			Response.Write("<script language=JavaScript>window.print();</script>");
		}

		
		private void rdbAll_CheckedChanged(object sender, System.EventArgs e)
		{
			
			lstIE.Visible=false;
			lblIE.Visible=false;
			lstCO.Visible=false;
			Label4.Visible=false;
			rdbAllNCR.Visible=false;
			rdbOutsNCR.Visible=false;
			
		}

		private void rdbGIE_CheckedChanged(object sender, System.EventArgs e)
		{
			if(Convert.ToString(Request.QueryString["rep"])=="I")
			{
				lstIE.Visible=true;
			}
			else if(Convert.ToString(Request.QueryString["rep"])=="C")
			{
				lstCO.Visible=true;
			}
				lblIE.Visible=true;
				Label4.Visible=true;
			rdbAllNCR.Visible=true;
			rdbOutsNCR.Visible=true;
				
			
		}
		

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		
		

		
		
	}
}
