﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS
{
    public partial class IC_Cancel_Form : System.Web.UI.Page
    {
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		
		string BKNO, SNO, Action;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnSearch.Attributes.Add("OnClick", "JavaScript:validate2();");
			btnDelConfirm.Attributes.Add("OnClick", "JavaScript:validate1();");
			btnDelConfirm.Attributes.Add("OnClick", "JavaScript:del();");

			if (Request.Params["BK_NO"] == null && Request.Params["SET_NO"] == null)
			{
				BKNO = "";
				SNO = "";
				Action = "A";
			}
			else
			{
				BKNO = Request.Params["BK_NO"].ToString();
				SNO = Request.Params["SET_NO"].ToString();
				Action = "M";
			}


			if (!(IsPostBack))
			{
				fill_IEtoWhomeIssued();
				ListItem lst2 = new ListItem();
				lst2.Text = "Cancelled";
				lst2.Value = "C";
				lstICStatus.Items.Add(lst2);
				lst2 = new ListItem();
				lst2.Text = "Missing";
				lst2.Value = "M";
				lstICStatus.Items.Add(lst2);
				lst2 = new ListItem();
				lst2.Text = "Lost / Theft";
				lst2.Value = "L";
				lstICStatus.Items.Add(lst2);



				if (Action == "A")
				{
					//					fillgrid();
					btnDelConfirm.Visible = false;
					if (Session["Region"].ToString() == "N")
					{
						lblReg.Text = "Northern Region";
					}
					else if (Session["Region"].ToString() == "S")
					{
						lblReg.Text = "Southern Region";
					}
					else if (Session["Region"].ToString() == "E")
					{
						lblReg.Text = "Eastern Region";
					}
					else if (Session["Region"].ToString() == "W")
					{
						lblReg.Text = "Western Region";
					}
					else if (Session["Region"].ToString() == "C")
					{
						lblReg.Text = "Central Region";
					}
				}
				else if (Action == "M")
				{
					//					fillgrid();
					show();
					btnDelConfirm.Visible = true;
				}
			}
			if (Session["Role_CD"].ToString() == "4")
			{
				btnSave.Visible = false;
				btnDelConfirm.Visible = false;

			}

		}
		void searchic()
		{
			try
			{
				DataSet dsP = new DataSet();
				string str = "select IC.BK_NO,IC.SET_NO,IE.IE_NAME,decode(IC.IC_STATUS,'C','Cancelled','M','Missing','L','Lost')IC_STATUS,to_char(IC.STATUS_DT,'dd/mm/yyyy')STATUS_DT, decode(IC.REGION,'N','Northern','W','Western','E','Eastern','S','South','C','Central') REGION,IC.REMARKS from T16_IC_CANCEL IC, T09_IE IE where IC.ISSUE_TO_IECD=IE.IE_CD";
				if (txtBKNo.Text.Trim() != "")
				{
					str = str + " and Trim(BK_NO)=upper(trim('" + txtBKNo.Text.Trim() + "'))";
				}
				if (txtSetNO.Text.Trim() != "")
				{
					str = str + " and Trim(SET_NO)=upper(trim('" + txtSetNO.Text.Trim() + "'))";
				}
				if (lstIE.SelectedIndex != 0)
				{
					str = str + " and Trim(ISSUE_TO_IECD)=" + lstIE.SelectedValue;
				}
				str = str + " and REGION='" + Session["Region"] + "' order by BK_NO,SET_NO";
				OracleDataAdapter da = new OracleDataAdapter(str, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdICCancel.Visible = false;
					DisplayAlert("No Record Found!!!");
				}
				else
				{
					grdICCancel.Visible = true;
					grdICCancel.DataSource = dsP;
					grdICCancel.DataBind();
				}
				conn1.Close();
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect("Error_Form.aspx?err=" + str1);
			}
			finally
			{
				conn1.Close();
			}
		}
		void show()
		{
			try
			{
				DataSet dsP = new DataSet();
				//code = Convert.ToInt32(txtBankCD.Text);
				string str1 = ("select BK_NO,SET_NO,ISSUE_TO_IECD,IC_STATUS,to_char(STATUS_DT,'dd/mm/yyyy')STATUS_DT, decode(REGION,'N','Northern','W','Western','E','Eastern','S','South','C','Central') REGION,REMARKS from T16_IC_CANCEL where UPPER(TRIM(BK_NO))=upper(TRIM('" + BKNO + "')) and UPPER(TRIM(SET_NO))=upper(TRIM('" + SNO + "')) and REGION='" + Session["Region"] + "'");
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand1 = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand1;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					throw new System.Exception("No Record Found!!! For The Given Code");
				}
				else
				{
					txtBKNo.Text = dsP.Tables[0].Rows[0]["BK_NO"].ToString();
					txtSetNO.Text = dsP.Tables[0].Rows[0]["SET_NO"].ToString();
					lstIE.SelectedValue = dsP.Tables[0].Rows[0]["ISSUE_TO_IECD"].ToString();
					lstICStatus.SelectedValue = dsP.Tables[0].Rows[0]["IC_STATUS"].ToString();
					txtStatusDt.Text = dsP.Tables[0].Rows[0]["STATUS_DT"].ToString();
					txtRemarks.Text = dsP.Tables[0].Rows[0]["REMARKS"].ToString();
					lblReg.Text = dsP.Tables[0].Rows[0]["REGION"].ToString();

				}
				conn1.Close();


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
			}

		}

		void fillgrid()
		{
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "select IC.BK_NO,IC.SET_NO,IE.IE_NAME,decode(IC.IC_STATUS,'C','Cancelled','M','Missing','L','Lost')IC_STATUS,to_char(IC.STATUS_DT,'dd/mm/yyyy')STATUS_DT, decode(IC.REGION,'N','Northern','W','Western','E','Eastern','S','South','C','Central') REGION,REMARKS from T16_IC_CANCEL IC, T09_IE IE where IC.ISSUE_TO_IECD=IE.IE_CD and REGION='" + Session["Region"] + "' order by BK_NO,SET_NO";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdICCancel.Visible = false;
				}
				else
				{
					grdICCancel.Visible = true;
					grdICCancel.DataSource = dsP;
					grdICCancel.DataBind();
				}
				conn1.Close();
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect("Error_Form.aspx?err=" + str1);
			}
			finally
			{
				conn1.Close();
			}
		}

		int checkic()
		{
			conn1.Open();
			OracleCommand cmd1 = new OracleCommand("Select to_char(ISSUE_DT,'yyyymmdd') from T10_IC_BOOKSET where TRIM(BK_NO)=upper('" + txtBKNo.Text + "') and " + Convert.ToInt32(txtSetNO.Text) + " between (SET_NO_FR) and (SET_NO_TO) and ISSUE_TO_IECD=" + lstIE.SelectedValue, conn1);
			string bscheck = Convert.ToString(cmd1.ExecuteScalar());
			conn1.Close();
			string myYear = txtStatusDt.Text.Substring(6, 4);
			string myMonth = txtStatusDt.Text.Substring(3, 2);
			string myDay = txtStatusDt.Text.Substring(0, 2);
			string dt1 = myYear + myMonth + myDay;

			int i = bscheck.CompareTo(dt1);


			if (bscheck != "")
			{
				conn1.Open();
				if (i > 0)
				{
					return (3);
				}
				else
				{

					OracleCommand cmd = new OracleCommand("Select CASE_NO from T20_IC where TRIM(BK_NO)=upper('" + txtBKNo.Text.Trim() + "') and TRIM(SET_NO)=upper('" + txtSetNO.Text.Trim() + "') and substr(CASE_NO,1,1)='" + Session["Region"] + "'", conn1);
					string bscheck1 = Convert.ToString(cmd.ExecuteScalar());
					conn1.Close();
					if (bscheck1 == "" || bscheck1 == null)
					{
						return (1);
					}
					else
					{
						return (2);
					}
				}
			}
			else
			{
				return (0);
			}
		}
		public void fill_IEtoWhomeIssued()
		{
			try
			{
				lstIE.Items.Clear();
				OracleCommand cmd = new OracleCommand("select IE_CD,IE_NAME from T09_IE where IE_STATUS is null and IE_REGION ='" + Session["Region"].ToString() + "' ORDER BY IE_NAME", conn1);
				OracleDataReader dr;
				conn1.Open();
				dr = cmd.ExecuteReader();
				ListItem lst;
				while (dr.Read())
				{
					lst = new ListItem();
					lst.Text = Convert.ToString(dr["IE_NAME"]);
					lst.Value = Convert.ToString(dr["IE_CD"]);
					lstIE.Items.Add(lst);
				}
				lstIE.Items.Insert(0, "");
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
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		protected void btnSave_Click(object sender, System.EventArgs e)
		{

			if (Action == "A")
			{
				int bscheck = checkic();
				if (bscheck == 1)
				{
					try
					{
						string myInsertQuery = "INSERT INTO T16_IC_CANCEL(BK_NO,SET_NO,ISSUE_TO_IECD,IC_STATUS,STATUS_DT,REGION,REMARKS) values('" + txtBKNo.Text + "','" + txtSetNO.Text + "'," + lstIE.SelectedValue + ",'" + lstICStatus.SelectedValue + "', to_date('" + txtStatusDt.Text + "','dd/mm/yyyy'),'" + Session["Region"].ToString() + "','" + txtRemarks.Text.Trim() + "')";
						OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
						myInsertCommand.Connection = conn1;
						conn1.Open();
						myInsertCommand.ExecuteNonQuery();
						conn1.Close();
						DisplayAlert("Record Saved!!!");
						//						fillgrid();
					}
					catch (Exception ex)
					{
						string str;
						str = ex.Message;
						string str2 = str.Replace("\n", "");
						Response.Redirect("Error_Form.aspx?err=" + str2);
					}
					finally
					{
						conn1.Close();
					}

					//					Response.Redirect("IC_Cancel_Form.aspx");
					//					fillgrid();
				}
				else if (bscheck == 0)
				{
					DisplayAlert("Book No. and Set No. specified is not issued to the Selected Inspection Engineer!!!");
				}
				else if (bscheck == 2)
				{
					DisplayAlert("IC has already made for given Book and Set No., soo it can not be cancelled !!!");
				}
				else if (bscheck == 3)
				{
					DisplayAlert("IC Cancel Date Cannot be Less then Issue Date  !!!");
				}
			}
			else if (Action == "M")
			{
				int bscheck = checkic();
				if (bscheck == 1)
				{

					try
					{
						string myUpdateQuery = "UPDATE T16_IC_CANCEL set BK_NO=trim('" + txtBKNo.Text + "'),SET_NO=trim('" + txtSetNO.Text + "'),ISSUE_TO_IECD=" + lstIE.SelectedValue + ",IC_STATUS='" + lstICStatus.SelectedValue + "',STATUS_DT=to_date('" + txtStatusDt.Text + "','dd/mm/yyyy'),REMARKS='" + txtRemarks.Text.Trim() + "' where UPPER(TRIM(BK_NO))=upper(TRIM('" + BKNO + "')) and UPPER(TRIM(SET_NO))=upper(TRIM('" + SNO + "')) and REGION='" + Session["Region"] + "'";
						OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
						myUpdateCommand.Connection = conn1;
						conn1.Open();
						myUpdateCommand.ExecuteNonQuery();
						conn1.Close();

						//					fillgrid();
						//					DisplayAlert("Your Record is Modified!!!");
					}
					catch (Exception ex)
					{
						string str;
						str = ex.Message;
						string str2 = str.Replace("\n", "");
						Response.Redirect("Error_Form.aspx?err=" + str2);
					}
					finally
					{
						conn1.Close();
					}
					Response.Redirect("IC_Cancel_Form.aspx");
				}
				else if (bscheck == 0)
				{
					DisplayAlert("Book No. and Set No. specified is not issued to the Selected Inspection Engineer!!!");
				}
				else if (bscheck == 2)
				{
					DisplayAlert("IC has already made for given Book and Set No., soo it can not be cancelled !!!");
				}
				else if (bscheck == 3)
				{
					DisplayAlert("IC Cancel Date Cannot be Less then Issue Date  !!!");
				}
			}

		}

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			searchic();
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			if (Session["Role"].ToString() == "Administrator")
			{
				Response.Redirect("MainForm.aspx");
			}
			else
			{
				Response.Redirect("MainForm2.aspx");
			}
		}

		protected void btnDelConfirm_Click(object sender, System.EventArgs e)
		{
			try
			{
				string myUpdateQuery = "delete T16_IC_CANCEL where UPPER(TRIM(BK_NO))=upper(TRIM('" + BKNO + "')) and UPPER(TRIM(SET_NO))=upper(TRIM('" + SNO + "')) and REGION='" + Session["Region"] + "'";
				OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
				myUpdateCommand.Connection = conn1;
				conn1.Open();
				myUpdateCommand.ExecuteNonQuery();
				conn1.Close();
				//				fillgrid();
				DisplayAlert("Record Deleted!!!");
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
			}
		}

	}
}
