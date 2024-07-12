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

namespace RBS.Reports
{
	/// <summary>
	/// Summary description for pfrmOngoing_Contracts.
	/// </summary>
	/// 


	public class pfrmOngoing_Contracts : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnBack;
		protected System.Web.UI.WebControls.Panel Panel_1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList lstBPORegion;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.Panel Panel_2;
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		protected System.Web.UI.WebControls.RadioButton rdb_New;
		protected System.Web.UI.WebControls.RadioButton rdb_Exist;
		protected System.Web.UI.HtmlControls.HtmlTable Table_Sample_Registration;
		protected System.Web.UI.HtmlControls.HtmlTable Table_Region;
		string wRegion;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.DropDownList ddlOfferStatus;
		protected System.Web.UI.HtmlControls.HtmlTable Table_Status;
		int Re_code;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (Session["Region"].ToString()=="N")  {wRegion="Northern Region";}
			else if (Session["Region"].ToString()=="S") {wRegion="Southern Region";}
			else if (Session["Region"].ToString()=="E") {wRegion="Eastern Region";}
			else if (Session["Region"].ToString()=="W") {wRegion="Western Region";}
			else if (Session["Region"].ToString()=="C") {wRegion="Central Region";}
			
			btnSubmit.Attributes.Add("OnClick", "JavaScript:validate1();"); 
			if (!(IsPostBack))
			{
				DataSet dsP2 = new DataSet(); 
				string str2 = "select * from T01_REGIONS"; 
				OracleDataAdapter da1 = new OracleDataAdapter(str2, conn1); 
				OracleCommand myOracleCommand1 = new OracleCommand(str2, conn1); 
				ListItem lst6; 
				conn1.Open(); 
				da1.SelectCommand = myOracleCommand1; 
				da1.Fill(dsP2, "Table"); 
				for (int i = 0; i <= dsP2.Tables [0].Rows.Count - 1; i++) 
				{ 
					lst6 = new ListItem(); 
					lst6.Text = dsP2.Tables[0].Rows[i]["REGION"].ToString ();
					lst6.Value = dsP2.Tables[0].Rows[i]["REGION_CODE"].ToString (); 
					lstBPORegion.Items.Add(lst6); 
				} 
				conn1.Close();
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
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			this.rdb_New.CheckedChanged += new System.EventHandler(this.rdb_New_CheckedChanged);
			this.rdb_Exist.CheckedChanged += new System.EventHandler(this.rdb_New_CheckedChanged);
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			int ctr =60;
			int wSno=0;
			string first_page="Y";   
   
			Panel_2.Visible=false;
			Panel_1.Visible=true;
			
			try
			{
				conn1.Open();
				OracleCommand cmd2 =new OracleCommand("Select to_char(sysdate,'yyyymmdd') from dual",conn1);
				string ss=Convert.ToString(cmd2.ExecuteScalar());
				string sql="";
				string Status="";
				
					if(rdb_New.Checked==true)
					{
						if(ddlOfferStatus.SelectedValue=="E")
						{
							sql="select CONTRACT_ID,CLIENT_NAME,CONTRACT_NO,to_char(OFFER_DT,'dd/mm/yyyy')OFFER_DTE,to_char(CONT_PER_FROM,'dd/mm/yyyy')PER_FROM,to_char(CONT_PER_TO,'dd/mm/yyyy')PER_TO,CONTRACT_FEE_NUM,CO_NAME,CONTRACT_SPECIAL_CONDN, CONTRACT_PANALTY,CONT_INSP_FEE,SCOPE_OF_WORK, DECODE(REGION_CODE,'N','NORTHERN','S','SOUTHERN','W','WESTERN','E','EASTERN','C','CENTRAL') REGION from T57_ONGOING_CONTRACTS T57, T08_IE_CONTROLL_OFFICER T08 where T57.CONTRACT_CM=T08.CO_CD and (to_char(CONT_PER_TO,'yyyyMMdd')>='"+ss+"' And to_char(CONT_PER_FROM,'yyyyMMdd')<='"+ss+"') and t57.region_code='"+lstBPORegion.SelectedValue+"' and t57.status!='B' order by CONT_PER_FROM,CLIENT_NAME,CONTRACT_NO";
							wRegion=lstBPORegion.SelectedItem.Text;
							Label1.Text="ONGOING CONTRACTS"; 
						}
						else
						{
                           sql="select CONTRACT_ID,CLIENT_NAME,CONTRACT_NO,to_char(OFFER_DT,'dd/mm/yyyy')OFFER_DTE,to_char(CONT_PER_FROM,'dd/mm/yyyy')PER_FROM,to_char(CONT_PER_TO,'dd/mm/yyyy')PER_TO,CONTRACT_FEE_NUM,CO_NAME,CONTRACT_SPECIAL_CONDN, CONTRACT_PANALTY,CONT_INSP_FEE,SCOPE_OF_WORK, DECODE(REGION_CODE,'N','NORTHERN','S','SOUTHERN','W','WESTERN','E','EASTERN','C','CENTRAL') REGION from T57_ONGOING_CONTRACTS T57, T08_IE_CONTROLL_OFFICER T08 where T57.CONTRACT_CM=T08.CO_CD and t57.region_code='"+lstBPORegion.SelectedValue+"' and t57.status='B' order by CONT_PER_FROM,CLIENT_NAME,CONTRACT_NO";
						   wRegion=lstBPORegion.SelectedItem.Text;
						   Label1.Text="BID LOST"; 
						}
					}
					else
					{			
						if(ddlOfferStatus.SelectedValue=="E")
						{
							sql="select CONTRACT_ID,CLIENT_NAME,CONTRACT_NO,to_char(OFFER_DT,'dd/mm/yyyy')OFFER_DTE,to_char(CONT_PER_FROM,'dd/mm/yyyy')PER_FROM,to_char(CONT_PER_TO,'dd/mm/yyyy')PER_TO,CONTRACT_FEE_NUM,CO_NAME,CONTRACT_SPECIAL_CONDN, CONTRACT_PANALTY,CONT_INSP_FEE,SCOPE_OF_WORK, DECODE(REGION_CODE,'N','NORTHERN','S','SOUTHERN','W','WESTERN','E','EASTERN','C','CENTRAL') REGION from T57_ONGOING_CONTRACTS T57, T08_IE_CONTROLL_OFFICER T08 where T57.CONTRACT_CM=T08.CO_CD and (to_char(CONT_PER_TO,'yyyyMMdd')>='"+ss+"' And to_char(CONT_PER_FROM,'yyyyMMdd')<='"+ss+"') and t57.status!='B' order by CONT_PER_FROM,CLIENT_NAME,CONTRACT_NO";
							wRegion="ALL REGIONS";
							Label1.Text="ONGOING CONTRACTS"; 
						}
						else
						{
							sql="select CONTRACT_ID,CLIENT_NAME,CONTRACT_NO,to_char(OFFER_DT,'dd/mm/yyyy')OFFER_DTE,to_char(CONT_PER_FROM,'dd/mm/yyyy')PER_FROM,to_char(CONT_PER_TO,'dd/mm/yyyy')PER_TO,CONTRACT_FEE_NUM,CO_NAME,CONTRACT_SPECIAL_CONDN, CONTRACT_PANALTY,CONT_INSP_FEE,SCOPE_OF_WORK, DECODE(REGION_CODE,'N','NORTHERN','S','SOUTHERN','W','WESTERN','E','EASTERN','C','CENTRAL') REGION from T57_ONGOING_CONTRACTS T57, T08_IE_CONTROLL_OFFICER T08 where T57.CONTRACT_CM=T08.CO_CD and t57.status='B' order by CONT_PER_FROM,CLIENT_NAME,CONTRACT_NO";
							wRegion="ALL REGIONS";
							Label1.Text="BID LOST"; 
						}
					}
//				}
//				else
//				{
//						if(rdb_New.Checked==true)
//				 {
//					 sql="select CONTRACT_ID,CLIENT_NAME,CONTRACT_NO,to_char(CONT_PER_FROM,'dd/mm/yyyy')PER_FROM,to_char(CONT_PER_TO,'dd/mm/yyyy')PER_TO,CONTRACT_FEE_NUM,CO_NAME,CONTRACT_SPECIAL_CONDN, CONTRACT_PANALTY,CONT_INSP_FEE,SCOPE_OF_WORK, DECODE(REGION_CODE,'N','NORTHERN','S','SOUTHERN','W','WESTERN','E','EASTERN','C','CENTRAL') REGION from T57_ONGOING_CONTRACTS T57, T08_IE_CONTROLL_OFFICER T08 where T57.CONTRACT_CM=T08.CO_CD and (to_char(CONT_PER_TO,'yyyyMMdd')>='"+ss+"' And to_char(CONT_PER_FROM,'yyyyMMdd')<='"+ss+"') and t57.region_code='"+lstBPORegion.SelectedValue+"' and t57.status='"+ddlOfferStatus.SelectedValue+"' order by CONT_PER_FROM,CLIENT_NAME,CONTRACT_NO";
//					 wRegion=lstBPORegion.SelectedItem.Text;
//				 }
//				 else
//				 {
//					 sql="select CONTRACT_ID,CLIENT_NAME,CONTRACT_NO,to_char(CONT_PER_FROM,'dd/mm/yyyy')PER_FROM,to_char(CONT_PER_TO,'dd/mm/yyyy')PER_TO,CONTRACT_FEE_NUM,CO_NAME,CONTRACT_SPECIAL_CONDN, CONTRACT_PANALTY,CONT_INSP_FEE,SCOPE_OF_WORK, DECODE(REGION_CODE,'N','NORTHERN','S','SOUTHERN','W','WESTERN','E','EASTERN','C','CENTRAL') REGION from T57_ONGOING_CONTRACTS T57, T08_IE_CONTROLL_OFFICER T08 where T57.CONTRACT_CM=T08.CO_CD and (to_char(CONT_PER_TO,'yyyyMMdd')>='"+ss+"' And to_char(CONT_PER_FROM,'yyyyMMdd')<='"+ss+"')  and t57.status='"+ddlOfferStatus.SelectedValue+"' order by CONT_PER_FROM,CLIENT_NAME,CONTRACT_NO";
//					 wRegion="ALL REGIONS";
//				 }
//
//				}
				

				OracleCommand cmd=new OracleCommand(sql,conn1);
				OracleDataReader reader = cmd.ExecuteReader();
				string wBILL_NO="";
				while (reader.Read())
				{
					if (ctr >59) 
					{
						Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='13'>");
						if (first_page=="N") 
						{Response.Write("<p style = page-break-before:always></p>");}				
						else
						{first_page="N";}
						Response.Write("</td>");Response.Write("</tr>");		
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='13'>");
						Response.Write("<H5 align='center'><font face='Verdana'>"+wRegion+"</font><br></p>");
						Response.Write("<H5 align='center'><font face='Verdana'><B>"+Label1.Text+"</B></font><br></p>");
						Response.Write("</td>");
						Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
						Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Contract Id</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Client</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Contract No.</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Offer Date</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Scope of Work</font></b></th>");
						Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Period From</font></b></th>");
						Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>Period To</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Rate of Insp Fee</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Contract Fee</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>CM Name</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Region</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Cont Special Condns</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Contract Penalty</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>File Uploaded(If Any)</font></b></th>");
						Response.Write("</tr></font>");
						ctr =6;
					};
					
					
					wSno = wSno+1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"+wSno+"</td>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"+reader["CONTRACT_ID"]+"</td>");
					Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>");Response.Write(reader["CLIENT_NAME"]);Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["CONTRACT_NO"]);Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["OFFER_DTE"]);Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>");Response.Write(reader["SCOPE_OF_WORK"]);Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["PER_FROM"]);Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["PER_TO"]);Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["CONT_INSP_FEE"]);Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>");Response.Write(reader["CONTRACT_FEE_NUM"]);Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["CO_NAME"]);Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["REGION"]);Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["CONTRACT_SPECIAL_CONDN"]);Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["CONTRACT_PANALTY"]);Response.Write("</td>");
					string fpath=Server.MapPath("/RBS/CONTRACTS/"+reader["CONTRACT_ID"].ToString()+".PDF");
					if (File.Exists(fpath)==true) 
					{
						//Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["CONTRACT_PANALTY"]);Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/CONTRACTS/"+reader["CONTRACT_ID"].ToString()+".PDF' Font-Names='Verdana' Font-Size='8pt'><font size='1' face='Verdana'>"+reader["CONTRACT_NO"].ToString()+"</font></a>");Response.Write("</td>");

					}
					else
					{
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write("");Response.Write("</td>");
					}

					Response.Write("</tr>");
					ctr=ctr+1;
						
					
				};
				//				Response.Write("<tr>");
				//				Response.Write("<td width='10%' valign='top' align='right' colspan=5> <font size='1' face='Verdana'><B>");Response.Write("Total: ");Response.Write("</B></td>");
				//				Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'><B>");Response.Write(w_total_retention);Response.Write("</B></td>");
				//				Response.Write("<td width='10%' valign='top' align='right' colspan=2> <font size='1' face='Verdana'><B>");Response.Write("");Response.Write("</B></td>");
				//				Response.Write("</tr>");
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
				conn1.Dispose();
			}
		
		}

		private void rdb_New_CheckedChanged(object sender, System.EventArgs e)
		{
		   radiochange();
		}

		void radiochange()
		{
			if(rdb_New.Checked==true)
			{
				Table_Region.Visible=true;
				Re_code=1;
			}
			else
			{
				Table_Region.Visible=false;
				Re_code=0;
			}
		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		private void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("/RBS/MainForm.aspx");
		}
	}
}
