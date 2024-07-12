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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Text;

namespace RBS.Reports
{
	/// <summary>
	/// Summary description for pfrmTrainingDetails.
	/// </summary>
	public class pfrmTrainingDetails : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.Panel Panel2;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblFrom;
		protected System.Web.UI.WebControls.Label lblTo;
		protected System.Web.UI.WebControls.Button btnView;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.RadioButton rdbCiv;
		protected System.Web.UI.WebControls.RadioButton rdbElec;
		protected System.Web.UI.WebControls.RadioButton rdbMech;
		protected System.Web.UI.WebControls.RadioButton rdbAllIE;
		protected System.Web.UI.WebControls.RadioButton rdbPIE;
		protected System.Web.UI.WebControls.DropDownList lstIE;
		protected System.Web.UI.WebControls.RadioButton rdbAll;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.RadioButton rdbRegular;
		protected System.Web.UI.WebControls.RadioButton rdbAllCat;
		protected System.Web.UI.WebControls.RadioButton rdbDepu;
		protected System.Web.UI.WebControls.RadioButton rdbAllTArea;
		protected System.Web.UI.WebControls.DropDownList lstField;
		protected System.Web.UI.WebControls.RadioButton rdbPArea;
		OracleConnection conn1 = null;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.rdbAllIE.CheckedChanged += new System.EventHandler(this.rdbAllIE_CheckedChanged);
			this.rdbPIE.CheckedChanged += new System.EventHandler(this.rdbAllIE_CheckedChanged);
			this.rdbAllTArea.CheckedChanged += new System.EventHandler(this.rdbPArea_CheckedChanged);
			this.rdbPArea.CheckedChanged += new System.EventHandler(this.rdbPArea_CheckedChanged);
			this.btnView.Click += new System.EventHandler(this.btnView_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void rdbAllIE_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rdbPIE.Checked==true)
			{
				conn1= new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				try
				{
				
					DataSet dsP1 = new DataSet(); 
					string str3 = "select IE_CD, IE_NAME from T09_IE where IE_REGION='"+Session["REGION"]+"' and IE_STATUS is NULL order by IE_NAME "; 
					OracleDataAdapter da = new OracleDataAdapter(str3, conn1); 
					OracleCommand myOracleCommand = new OracleCommand(str3, conn1); 
					ListItem lst3; 
					conn1.Open(); 
					da.SelectCommand = myOracleCommand; 
					da.Fill(dsP1, "Table"); 
					for (int i = 0; i <= dsP1.Tables[0].Rows.Count - 1; i++) 
					{ 
						lst3 = new ListItem(); 
						lst3.Text = dsP1.Tables[0].Rows[i]["IE_NAME"].ToString(); 
						lst3.Value = dsP1.Tables[0].Rows[i]["IE_CD"].ToString(); 
						lstIE.Items.Add(lst3); 
					} 
					conn1.Close(); 
					lstIE.Visible=true;
				}
				catch (Exception ex) 
				{ 
					string str; 
					str = ex.Message; 
					string str1=str.Replace("\n","");
					Response.Redirect("Error_Form.aspx?err="+str1); 
				}
				finally
				{
					conn1.Close(); 
					conn1.Dispose();
				}
			}
			else
			{
				lstIE.Visible=false;
			
			}
		}

		private void btnView_Click(object sender, System.EventArgs e)
		{
			
			Panel2.Visible=true;
			Panel1.Visible=false;
			training_details();
		}
		void training_details()
		{
			string wRegion="";

			if (Session["Region"].ToString()=="N")  {wRegion="Northern Region, RITES Ltd.";}
			else if (Session["Region"].ToString()=="S") {wRegion="Southern Region, RITES Ltd.";}
			else if (Session["Region"].ToString()=="E") {wRegion="Eastern Region, RITES Ltd.";}
			else if (Session["Region"].ToString()=="W") {wRegion="Western Region, RITES Ltd.";}
			else if (Session["Region"].ToString()=="C") {wRegion="Central Region, RITES Ltd.";}

			conn1= new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			conn1.Open();
			OracleCommand cmd2 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual",conn1);
			string ss=Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();
			
			string sql="Select NAME, EMP_NO, DECODE (CATEGORY,'R','Regular','D','Deputation','Other') CATEGORY, decode(QUALIFICATION,'D','Degree','P','Diploma','Others') QUAL, DECODE(TRAINING_TYPE,'I','Induction','O','Orientation','R','Refresh','T','Technical') T_TYPE,DECODE(TRAINING_FIELD,'W','Welding','N','NDT','M','Metrology','P','Plastic','T','Textile','A','Paint','R','Transformer','C','Cable','E','Energy','V','Pressure Vessal','I','Pipeline','B','Rubber','X','M&P','O','ISO','D','DRG','Y','Other') T_FEILD,COURSE_NAME,COURSE_INSTITUTE, TO_CHAR(COURSE_DUR_FR,'DD/MM/YYYY')C_DUR_FR, TO_CHAR(COURSE_DUR_TO,'DD/MM/YYYY')C_DUR_TO, CERTIFICATE, FEES, VALIDITY FROM TRAINEE_EMPLOYEE_MASTER TEM, T09_IE T09, TRAINING_COURSE_MASTER TCM, TRAINING_DETAILS TD WHERE T09.IE_CD=TEM.IE_CD AND TCM.COURSE_ID=TD.COURSE_ID AND TEM.IE_CD=TD.IE_CD AND TEM.REGION='"+Session["Region"].ToString()+"'" ;
				
			if(rdbMech.Checked==true)
			{
				sql=sql + " and T09.IE_DEPARTMENT='M'";
			}
			else if(rdbElec.Checked==true)
			{
				sql=sql + " and T09.IE_DEPARTMENT='E'";
			}
			else if(rdbCiv.Checked==true)
			{
				sql=sql + " and T09.IE_DEPARTMENT='C'";
			}

			if(rdbPIE.Checked==true)
			{
				sql=sql + " and T09.IE_CD="+lstIE.SelectedValue;
			}

			if(rdbRegular.Checked==true)
			{
				sql=sql + " and TEM.CATEGORY='R' ";
			}
			else if(rdbDepu.Checked==true)
			{
				sql=sql + " and TEM.CATEGORY='D' ";
			} 

			if(rdbPArea.Checked==true)
			{
				sql=sql + " and TCM.TRAINING_FIELD='"+lstField.SelectedValue+"' ";
			}

			sql=sql + " ORDER BY  T09.IE_NAME,COURSE_DUR_FR, TCM.TRAINING_TYPE, TCM.TRAINING_FIELD, COURSE_NAME";
			int wSno=0;
			string first_page="Y";      
			
			try
			{
				OracleCommand cmd=new OracleCommand(sql,conn1);
				conn1.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='18'>");
				if (first_page=="N") 
				{Response.Write("<p style = page-break-before:always></p>");}				
				else
				{first_page="N";}
				Response.Write("</td>");Response.Write("</tr>");		
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='18'>");
				Response.Write("<H5 align='center'><font face='Verdana'>"+wRegion+"</font><br></p>");
				Response.Write("<H5 align='center'><font face='Verdana'>SUMMARY OF IE WISE TRAINING DETAILS</font><br></p>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
				Response.Write("<th width='14%' valign='top'><b><font size='1' face='Verdana'>IE NAME.</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>EMP No.</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>CATEGORY</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>QUALIFICATION</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>TRAINING TYPE</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>TRAINING FEILD</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>COURSE NAME</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>COURSE INSTITUTE</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>COURSE DUR FR</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>COURSE DUR TO</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>CERTIFICATE</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>FEES</font></b></th>");
				Response.Write("<th width='6%' valign='top'><b><font size='1' face='Verdana'>VALIDITY</font></b></th>");
				Response.Write("</tr></font>");
				
				
				int i=0; 
				while (reader.Read())
				{
					
					wSno = wSno+1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>"+wSno+"</td>");
					Response.Write("<td width='14%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["NAME"]);Response.Write("</td>");
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>");Response.Write(reader["EMP_NO"]);Response.Write("</td>");
					Response.Write("<td width='6%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["CATEGORY"]);Response.Write("</td>");
					Response.Write("<td width='6%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["QUAL"]);Response.Write("</td>");
					Response.Write("<td width='6%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["T_TYPE"]);Response.Write("</td>");
					Response.Write("<td width='6%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["T_FEILD"]);Response.Write("</td>");
					Response.Write("<td width='6%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["COURSE_NAME"]);Response.Write("</td>");
					Response.Write("<td width='6%' valign='top' align='left'> <font size='1' face='Verdana'>");Response.Write(reader["COURSE_INSTITUTE"]);Response.Write("</td>");
					Response.Write("<td width='6%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["C_DUR_FR"]);Response.Write("</td>");
					Response.Write("<td width='6%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["C_DUR_TO"]);Response.Write("&nbsp&nbsp</td>");
					Response.Write("<td width='6%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["CERTIFICATE"]);Response.Write("</td>");
					Response.Write("<td width='6%' valign='top' align='right'> <font size='1' face='Verdana'>");Response.Write(reader["FEES"]);Response.Write("</td>");
					Response.Write("<td width='6%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["VALIDITY"]);Response.Write("</td>");
					Response.Write("</tr>");
					i++;
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
				conn1.Close();
				conn1.Dispose();
			}
		}
//		private void rdbPCourse_CheckedChanged(object sender, System.EventArgs e)
//		{
//			if(rdbPCourse.Checked==true)
//			{
//					txtCourse.Visible=true;
//			}
//			else
//			{
//					txtCourse.Visible=false;
//			}
//		}

		private void rdbPArea_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rdbAllTArea.Checked==true)
			{
				lstField.Visible=false;
			}
			else if(rdbPArea.Checked==true)
			{
				lstField.Visible=true;
			}
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			Panel1.Visible=false;
			Panel2.Visible=false;
			training_details();
			Response.Write("<script language=JavaScript>window.print();</script>");
		}
	}
}
