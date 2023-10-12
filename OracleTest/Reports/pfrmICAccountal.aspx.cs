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

namespace RBS.Reports
{
    public partial class pfrmICAccountal : System.Web.UI.Page
	{
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);		
		int wError;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSubmit.Attributes.Add("OnClick", "JavaScript:validate();");
			txtRegion.Text = Convert.ToString(Session["REGION"]);
			if (txtRegion.Text == "N")
			{ rdbCancelYes.Checked = true; }
			else
			{ rdbCancelNo.Checked = true; }
			//
			if (!(IsPostBack))
			{
				DataSet dsP1 = new DataSet();
				string str3 = "select IE_CD, IE_NAME from T09_IE where IE_REGION='" + Session["REGION"] + "' order by IE_NAME ";
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
				lstIE.Visible = false;
				lblIE.Visible = false;
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
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			this.rdbAll.CheckedChanged += new System.EventHandler(this.rdbAll_CheckedChanged);
			this.rdbGIE.CheckedChanged += new System.EventHandler(this.rdbGIE_CheckedChanged);
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{

			if (Convert.ToString(Request.Params["ACTION"].Trim()) == "MISSING")
			{
				find_missing_IC();
				if (wError == -1)
				{ DisplayAlert("Unable to generate the report."); }
				else
					generate_report();
			}
			else if (Convert.ToString(Request.Params["ACTION"].Trim()) == "ICSTATUS")
			{
				ic_status();
			}

		}
		void ic_status()
		{
			conn.Open();
			OracleCommand cmd = new OracleCommand("Delete from TEMP10_IC", conn);
			cmd.ExecuteNonQuery();

			int wSet = 0;
			DataSet dsP = new DataSet();
			string str3 = "SELECT BK_NO,TO_NUMBER(SET_NO_FR) SET_NO_FR,TO_NUMBER(SET_NO_TO)SET_NO_TO,ISSUE_TO_IECD,REGION FROM T10_IC_BOOKSET WHERE REGION='" + Session["Region"].ToString() + "' AND BK_SUBMITTED='N' AND (ISSUE_DT BETWEEN TO_DATE('" + txtDtFr.Text + "','DD/MM/YYYY') AND TO_DATE('" + txtDtTo.Text + "','DD/MM/YYYY'))";
			if (rdbGIE.Checked == true)
			{
				str3 = str3 + " and ISSUE_TO_IECD=" + lstIE.SelectedValue;
			}
			OracleDataAdapter da = new OracleDataAdapter(str3, conn);
			OracleCommand myOracleCommand = new OracleCommand(str3, conn);

			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
			{
				wSet = Convert.ToInt32(dsP.Tables[0].Rows[i]["SET_NO_FR"].ToString());
				while (wSet <= Convert.ToInt32(dsP.Tables[0].Rows[i]["SET_NO_TO"].ToString()))
				{
					OracleCommand cmd1 = new OracleCommand("select NVL2(BILL_NO,'BILL NO: '||BILL_NO,'IC NO:'||IC_NO) from T20_IC where BK_NO='" + dsP.Tables[0].Rows[i]["BK_NO"].ToString() + "' and SET_NO=" + wSet + " and IE_CD=" + dsP.Tables[0].Rows[i]["ISSUE_TO_IECD"].ToString(), conn);
					string icstatus = Convert.ToString(cmd1.ExecuteScalar());
					if (icstatus == "")
					{
						OracleCommand cmd11 = new OracleCommand("select STATUS_DT from T16_IC_CANCEL where BK_NO='" + dsP.Tables[0].Rows[i]["BK_NO"].ToString() + "' and SET_NO=" + wSet + " and ISSUE_TO_IECD=" + dsP.Tables[0].Rows[i]["ISSUE_TO_IECD"].ToString(), conn);
						string icstatus1 = Convert.ToString(cmd11.ExecuteScalar());
						if (icstatus1 == "")
						{
							OracleCommand cmd2 = new OracleCommand("INSERT INTO TEMP10_IC ( REGION, IE_CD, BK_NO, SET_NO , MISSING_SETS)	VALUES('" + Session["Region"].ToString() + "','" + dsP.Tables[0].Rows[i]["ISSUE_TO_IECD"].ToString() + "','" + dsP.Tables[0].Rows[i]["BK_NO"].ToString() + "','" + wSet + "','IC MISSING')", conn);
							cmd2.ExecuteNonQuery();
						}
						else
						{
							OracleCommand cmd2 = new OracleCommand("INSERT INTO TEMP10_IC ( REGION, IE_CD, BK_NO, SET_NO , MISSING_SETS)	VALUES('" + Session["Region"].ToString() + "','" + dsP.Tables[0].Rows[i]["ISSUE_TO_IECD"].ToString() + "','" + dsP.Tables[0].Rows[i]["BK_NO"].ToString() + "','" + wSet + "','IC CANCELLED')", conn);
							cmd2.ExecuteNonQuery();
						}
					}
					else
					{
						OracleCommand cmd2 = new OracleCommand("INSERT INTO TEMP10_IC ( REGION, IE_CD, BK_NO, SET_NO , MISSING_SETS) VALUES('" + Session["Region"].ToString() + "','" + dsP.Tables[0].Rows[i]["ISSUE_TO_IECD"].ToString() + "','" + dsP.Tables[0].Rows[i]["BK_NO"].ToString() + "','" + wSet + "','" + icstatus + "')", conn);
						cmd2.ExecuteNonQuery();
					}
					wSet = wSet + 1;

				}
			}
			conn.Close();
			Panel_1.Visible = true;
			Panel_2.Visible = false;
			disic_status();
			//			if(Convert.ToString(Request.Params ["ACTION"].Trim())=="Missing")
			//			{
			//				missing_ic();
			//			}
			//			else
			//			{
			//				disic_status();
			//			}
		}
		private void find_missing_IC()
		{
			conn.Open();
			OracleCommand cmd = null;
			try
			{
				cmd = new OracleCommand("IC_ACCOUNTAL", conn);
				cmd.CommandType = CommandType.StoredProcedure;
				//
				OracleParameter prm1 = new OracleParameter("IN_REGION", System.Data.OracleClient.OracleType.Char);
				prm1.Direction = ParameterDirection.Input;
				prm1.Value = Session["REGION"];
				cmd.Parameters.Add(prm1);
				//
				OracleParameter prm2 = new OracleParameter("IN_DATE_FR", System.Data.OracleClient.OracleType.Char);
				prm2.Direction = ParameterDirection.Input;
				prm2.Value = txtDtFr.Text;
				cmd.Parameters.Add(prm2);
				//
				OracleParameter prm3 = new OracleParameter("IN_DATE_TO", System.Data.OracleClient.OracleType.Char);
				prm3.Direction = ParameterDirection.Input;
				prm3.Value = txtDtTo.Text;
				cmd.Parameters.Add(prm3);
				//
				OracleParameter prm4 = new OracleParameter("IN_YES_NO", System.Data.OracleClient.OracleType.Char);
				prm4.Direction = ParameterDirection.Input;
				prm4.Value = lstYESNO.SelectedValue;
				cmd.Parameters.Add(prm4);
				//
				OracleParameter prm5 = new OracleParameter("IN_IE_CD", System.Data.OracleClient.OracleType.Char);
				prm5.Direction = ParameterDirection.Input;
				if (rdbGIE.Checked == true)
				{ prm5.Value = lstIE.SelectedValue; }
				else
				{ prm5.Value = "X"; }
				cmd.Parameters.Add(prm5);
				//
				OracleParameter prm6 = new OracleParameter("IN_CANCEL_LOST", System.Data.OracleClient.OracleType.Char);
				prm6.Direction = ParameterDirection.Input;
				if (rdbCancelYes.Checked == true)
					prm6.Value = "Y";
				else
					prm6.Value = "N";
				cmd.Parameters.Add(prm6);
				//
				OracleParameter prm7 = new OracleParameter("OUT_ERR_CD", System.Data.OracleClient.OracleType.Number);
				prm7.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(prm7);
				//
				cmd.ExecuteNonQuery();
				conn.Close();
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
				conn.Close();
			}
			//wError=Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value);
		}

		private void generate_report()
		{
			//rbs my_rbs = new rbs();
			//CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = null;
			//if (Convert.ToString(Session["Region"]) == "N")
			//{ rpt = new nr_rptICAccountal(); }
			//else
			//{ rpt = new rptICAccountal(); };
			//rpt.RecordSelectionFormula = "{T10_IC_BOOKSET.REGION}='" + Session["Region"] + "'";
			//rpt.SetParameterValue(0, Session["Region"]);
			//rpt.SetParameterValue(1, txtDtFr.Text);
			//rpt.SetParameterValue(2, txtDtTo.Text);
			//MemoryStream oStream = my_rbs.showwordrep(rpt);
			//Response.Clear();
			//Response.Buffer = true;
			//Response.ContentType = "application/doc";
			//try
			//{
			//	Response.BinaryWrite(oStream.ToArray());
			//	Response.End();
			//}
			//catch (Exception err)
			//{
			//	Response.Write("< BR >");
			//	Response.Write(err.Message.ToString());
			//}
		}

		void disic_status()
		{

			//string wYrMth=lstYear.SelectedValue+lstMonths.SelectedValue;
			string wRegion = "";

			if (Session["Region"].ToString() == "N") { wRegion = "Northern Region"; }
			else if (Session["Region"].ToString() == "S") { wRegion = "Southern Region"; }
			else if (Session["Region"].ToString() == "E") { wRegion = "Eastern Region"; }
			else if (Session["Region"].ToString() == "W") { wRegion = "Western Region"; }
			else if (Session["Region"].ToString() == "C") { wRegion = "Central Region"; }

			string sql = "SELECT T09.IE_NAME,T10.BK_NO,T10.SET_NO,(T10.MISSING_SETS) STATUS from TEMP10_IC T10,T09_IE T09 where T10.IE_CD=T09.IE_CD order by IE_NAME, BK_NO,SET_NO";
			int ctr = 60;
			int wSno = 0;
			string first_page = "Y";

			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					if (ctr > 59)
					{
						Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='4'>");
						if (first_page == "N")
						{ Response.Write("<p style = page-break-before:always></p>"); }
						else
						{ first_page = "N"; }
						Response.Write("</td>"); Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='4'>");
						Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
						Response.Write("<H5 align='center'><font face='Verdana'>IC ACCOUNTAL for the Period " + txtDtFr.Text + " To " + txtDtTo.Text + "</font><br></p>");
						Response.Write("</td>");
						Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<th width='30%' valign='top'><b><font size='1' face='Verdana'>IE</font></b></th>");
						Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Book No.</font></b></th>");
						Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Set No.</font></b></th>");
						Response.Write("<th width='40%' valign='top'><b><font size='1' face='Verdana'>Status</font></b></th>");
						Response.Write("</tr></font>");
						ctr = 6;
					};
					wSno = wSno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='30%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["BK_NO"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["SET_NO"]); Response.Write("</td>");
					Response.Write("<td width='40%' valign='top' align='Left'> <font size='1' face='Verdana'>"); Response.Write(reader["STATUS"]); Response.Write("</td>");
					Response.Write("</tr>");
					ctr = ctr + 1;

				};

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
				conn.Close();
			}

		}

		void missing_ic()
		{

			//string wYrMth=lstYear.SelectedValue+lstMonths.SelectedValue;
			string wRegion = "";

			if (Session["Region"].ToString() == "N") { wRegion = "Northern Region"; }
			else if (Session["Region"].ToString() == "S") { wRegion = "Southern Region"; }
			else if (Session["Region"].ToString() == "E") { wRegion = "Eastern Region"; }
			else if (Session["Region"].ToString() == "W") { wRegion = "Western Region"; }
			else if (Session["Region"].ToString() == "C") { wRegion = "Central Region"; }

			//string sql="SELECT T09.IE_NAME,T10.BK_NO,T10.SET_NO,T10.STATUS from TEMP10_IC_A T10,T09_IE T09 where T10.IE_CD=T09.IE_CD and T10.STATUS='IC MISSING' order by BK_NO,SET_NO";
			string sql = "SELECT T09.IE_NAME,T10.BK_NO,T10.SET_NO,T10.STATUS from TEMP10_IC_A T10,T09_IE T09 where T10.IE_CD=T09.IE_CD order by BK_NO,SET_NO";
			int ctr = 60;
			int wSno = 0;
			string first_page = "Y";
			string SETNO = "";
			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataAdapter da = new OracleDataAdapter(sql, conn);
				DataSet dsP = new DataSet();
				da.SelectCommand = cmd;
				da.Fill(dsP, "Table");
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					if (ctr > 59)
					{
						Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='4'>");
						if (first_page == "N")
						{ Response.Write("<p style = page-break-before:always></p>"); }
						else
						{ first_page = "N"; }
						Response.Write("</td>"); Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<td width='100%' colspan='4'>");
						Response.Write("<H5 align='center'><font face='Verdana'>" + wRegion + "</font><br></p>");
						Response.Write("<H5 align='center'><font face='Verdana'>MISSING IC's for the Period " + txtDtFr.Text + " To " + txtDtTo.Text + "</font><br></p>");
						Response.Write("</td>");
						Response.Write("</tr>");
						Response.Write("<tr>");
						Response.Write("<th width='30%' valign='top'><b><font size='1' face='Verdana'>IE</font></b></th>");
						Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Book No.</font></b></th>");
						Response.Write("<th width='40%' valign='top'><b><font size='1' face='Verdana'>Set No.</font></b></th>");
						Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>Status</font></b></th>");

						Response.Write("</tr></font>");
						ctr = 6;
					}
					wSno = wSno + 1;
					if (SETNO == "")
					{
						SETNO = dsP.Tables[0].Rows[i]["SET_NO"].ToString();
					}
					else
					{
						SETNO = SETNO + " , " + dsP.Tables[0].Rows[i]["SET_NO"].ToString();
					}
					if (dsP.Tables[0].Rows[i]["STATUS"].ToString().Equals("IC MISSING") == true)
					{
						if (wSno > 1 && i < dsP.Tables[0].Rows.Count - 2 && (dsP.Tables[0].Rows[i]["IE_NAME"].ToString().Equals(dsP.Tables[0].Rows[i + 1]["IE_NAME"].ToString()) == true && dsP.Tables[0].Rows[i]["BK_NO"].ToString().Equals(dsP.Tables[0].Rows[i + 1]["BK_NO"].ToString()) == true))
						{

						}
						else
						{
							if (wSno == 1 || i == dsP.Tables[0].Rows.Count - 2)
							{

							}
							else
							{
								Response.Write("<tr>");
								Response.Write("<td width='30%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["IE_NAME"].ToString()); Response.Write("</td>");
								Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["BK_NO"].ToString()); Response.Write("</td>");
								Response.Write("<td width='40%' valign='top' align='center'> <font size='1' face='Verdana'>");
								Response.Write(SETNO);
								Response.Write("</td>");
								Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["STATUS"].ToString()); Response.Write("</td>");
								Response.Write("</tr>");
								ctr = ctr + 1;
								SETNO = "";
							}
						}
					}
					else
					{
						Response.Write("<tr>");
						Response.Write("<td width='30%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["IE_NAME"].ToString()); Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["BK_NO"].ToString()); Response.Write("</td>");
						Response.Write("<td width='40%' valign='top' align='center'> <font size='1' face='Verdana'>");
						Response.Write(dsP.Tables[0].Rows[i]["SET_NO"].ToString());
						Response.Write("</td>");
						Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(dsP.Tables[0].Rows[i]["STATUS"].ToString()); Response.Write("</td>");
						Response.Write("</tr>");
					}
				}
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
				conn.Close();
			}

		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		private void rdbAll_CheckedChanged(object sender, System.EventArgs e)
		{
			lstIE.Visible = false;
			lblIE.Visible = false;
		}

		private void rdbGIE_CheckedChanged(object sender, System.EventArgs e)
		{
			lstIE.Visible = true;
			lblIE.Visible = true;
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			Panel_1.Visible = true;
			Panel_2.Visible = false;
			disic_status();
		}

		private void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("/RBS/MainForm.aspx");
		}

	}
}
