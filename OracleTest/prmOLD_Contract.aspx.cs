using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.prmOLD_Contract
{
	public partial class prmOLD_Contract : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		DataSet dsP = new DataSet();
		protected System.Web.UI.WebControls.Button btnPrint;

		protected void Page_Load(object sender, System.EventArgs e)
		{
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
				for (int i = 0; i <= dsP2.Tables[0].Rows.Count - 1; i++)
				{
					lst6 = new ListItem();
					lst6.Text = dsP2.Tables[0].Rows[i]["REGION"].ToString();
					lst6.Value = dsP2.Tables[0].Rows[i]["REGION_CODE"].ToString();
					lstBPORegion.Items.Add(lst6);
				}
				lstBPORegion.Items.Insert(0, "");
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

		}
		#endregion

		string dateconcat(string dt)
		{
			string myYear, myMonth, myDay;
			myYear = dt.Substring(6, 4);
			myMonth = dt.Substring(3, 2);
			myDay = dt.Substring(0, 2);
			string dt_out = myYear + myMonth + myDay;
			return (dt_out);
		}

		protected void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("/RBS/MainForm.aspx");
		}

		void Contract_all()
		{
			int ctr = 60;
			int wSno = 0;
			string first_page = "Y";
			string wDtFr;
			string wDtTo;


			try
			{
				conn1.Open();
				string sql = "select CONTRACT_ID,CLIENT_NAME,CONTRACT_NO,to_char(CONT_PER_FROM,'dd/mm/yyyy')PER_FROM,to_char(CONT_PER_TO,'dd/mm/yyyy')PER_TO,CONTRACT_FEE_NUM,CO_NAME,CONTRACT_SPECIAL_CONDN,CONTRACT_PANALTY,CONT_INSP_FEE,SCOPE_OF_WORK, DECODE(REGION_CODE,'N','NORTHERN','S','SOUTHERN','W','WESTERN','E','EASTERN','C','CENTRAL','Q','CO QA') REGION from T57_ONGOING_CONTRACTS T57, T08_IE_CONTROLL_OFFICER T08 where T57.CONTRACT_CM=T08.CO_CD ";
				//if(txtFdate.Text.Trim()!="" && txtTdate.Text.Trim()!="")
				//{
				//sql =sql + " and to_char(t57.cont_per_from,'yyyyMMdd')>='"+wDtFr+"' and to_char(t57.cont_per_from,'yyyyMMdd')<='"+wDtTo+"'"; 
				//}
				if (txtFdate.Text.Trim() != "" && txtTdate.Text.Trim() != "")
				{
					wDtFr = dateconcat(txtFdate.Text);
					wDtTo = dateconcat(txtTdate.Text);
					sql = sql + " and ((to_char(CONT_PER_FROM,'yyyyMMdd')>='" + wDtFr + "' And to_char(CONT_PER_FROM,'yyyyMMdd')<='" + wDtTo + "') OR (to_char(CONT_PER_TO,'yyyyMMdd')>='" + wDtFr + "'  And to_char(CONT_PER_TO,'yyyyMMdd')<='" + wDtTo + "'))";
				}
				if (lstBPORegion.SelectedItem.Text.Trim() != "")
				{
					sql = sql + " and REGION_CODE='" + lstBPORegion.SelectedValue + "' ";
				}
				if (txtClient.Text.Trim() != "")
				{
					sql = sql + " and (upper(CLIENT_NAME) LIKE upper('%" + txtClient.Text.Trim() + "%')) ";
				}
				sql = sql + " order by CONT_PER_FROM,CLIENT_NAME,CONTRACT_NO";
				OracleCommand cmd = new OracleCommand(sql, conn1);
				OracleDataReader reader = cmd.ExecuteReader();
				//string wBILL_NO="";

				while (reader.Read())
				{
					if (ctr > 59)
					{
						Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='13'>");
						if (first_page == "N")
						{ Response.Write("<p style = page-break-before:always></p>"); }
						else
						{ first_page = "N"; }
						Response.Write("</td>"); Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='13'>");
						//Response.Write("<H5 align='center'><font face='Verdana'>"+wRegion+"</font><br></p>");
						Response.Write("<H5 align='center'><font face='Verdana'><B>CONTRACTS</B></font><br></p>");
						Response.Write("</td>");
						Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<th width='5%' valign='top'><b><font size='1' face='Verdana'>S.No.</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Client</font></b></th>");
						Response.Write("<th width='10%' valign='top'><b><font size='1' face='Verdana'>Contract No.</font></b></th>");
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
						ctr = 6;
					};


					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='5%' valign='top' align='center'> <font size='1' face='Verdana'>" + wSno + "</td>");
					Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["CLIENT_NAME"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CONTRACT_NO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["SCOPE_OF_WORK"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["PER_FROM"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["PER_TO"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CONT_INSP_FEE"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'>"); Response.Write(reader["CONTRACT_FEE_NUM"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CO_NAME"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["REGION"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CONTRACT_SPECIAL_CONDN"]); Response.Write("</td>");
					Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CONTRACT_PANALTY"]); Response.Write("</td>");
					string fpath = Server.MapPath("/RBS/CONTRACTS/" + reader["CONTRACT_ID"].ToString() + ".PDF");
					if (File.Exists(fpath) == true)
					{
						//Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>");Response.Write(reader["CONTRACT_PANALTY"]);Response.Write("</td>");
						Response.Write("<td width='10%' valign='top' align='center'><a href='/RBS/CONTRACTS/" + reader["CONTRACT_ID"].ToString() + ".PDF' Font-Names='Verdana' Font-Size='8pt'><font size='1' face='Verdana'>" + reader["CONTRACT_NO"].ToString() + "</font></a>"); Response.Write("</td>");

					}
					else
					{
						Response.Write("<td width='10%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(""); Response.Write("</td>");
					}

					Response.Write("</tr>");
					ctr = ctr + 1;


				};
				//				Response.Write("<tr>");
				//				Response.Write("<td width='10%' valign='top' align='right' colspan=5> <font size='1' face='Verdana'><B>");Response.Write("Total: ");Response.Write("</B></td>");
				//				Response.Write("<td width='10%' valign='top' align='right'> <font size='1' face='Verdana'><B>");Response.Write(w_total_retention);Response.Write("</B></td>");
				//				Response.Write("<td width='10%' valign='top' align='right' colspan=2> <font size='1' face='Verdana'><B>");Response.Write("");Response.Write("</B></td>");
				//				Response.Write("</tr>");
				Response.Write("</table>");

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


		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			Contract_all();
			Panel_2.Visible = false;
			Panel_1.Visible = true;

		}
	}
}