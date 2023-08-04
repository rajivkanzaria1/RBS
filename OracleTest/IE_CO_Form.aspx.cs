using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.IE_CO_Form
{
	public partial class IE_CO_Form : System.Web.UI.Page
	{

		int code = new int();
		string Action;
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelConfirm.Attributes.Add("OnClick", "JavaScript:del();");

			if (Convert.ToString(Request.Params["CO_CD"]) == null || Convert.ToString(Request.Params["CO_CD"]) == "")
			{
				code = 0;
				Action = "";
			}
			else
			{
				code = Convert.ToInt32(Request.Params["CO_CD"].Trim());
				Action = Convert.ToString(Request.Params["ACTION"].Trim());
			}
			if (!(IsPostBack))
			{
				ListItem lst3 = new ListItem();
				lst3.Text = "Working";
				lst3.Value = "W";
				lstStatus.Items.Add(lst3);
				lst3 = new ListItem();
				lst3.Text = "Retired";
				lst3.Value = "R";
				lstStatus.Items.Add(lst3);
				lst3 = new ListItem();
				lst3.Text = "Transferred";
				lst3.Value = "T";
				lstStatus.Items.Add(lst3);
				lst3 = new ListItem();
				lst3.Text = "Left/Repatriated";
				lst3.Value = "L";
				lstStatus.Items.Add(lst3);

				try
				{
					DataSet dsP = new DataSet();
					string str1 = "select * from T07_RITES_DESIG ";
					OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
					OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
					//ListItem lst; 
					conn1.Open();
					da.SelectCommand = myOracleCommand;
					da.Fill(dsP, "Table");
					lstDesig.DataValueField = "R_DESIG_CD";
					lstDesig.DataTextField = "R_DESIGNATION";
					lstDesig.DataSource = dsP;
					lstDesig.DataBind();
					//					for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++) 
					//					{ 
					//						lst = new ListItem(); 
					//						lst.Text = dsP.Tables[0].Rows[i]["DESIG_SMALL"].ToString(); 
					//						lst.Value = dsP.Tables[0].Rows[i]["DESIG_CD"].ToString(); 
					//						lstDesig.Items.Add(lst); 
					//					} 
					conn1.Close();

					if (Action == "D")
					{
						show();

						btnSave.Visible = false;
						btnDelConfirm.Visible = true;
					}
					else if (Action == "E")
					{
						show();


						btnSave.Enabled = true;


					}
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
				//lstDesig.SelectedValue = "1"; 
				if (Convert.ToString(Session["Role"]) != "Administrator")
				{
					btnSave.Enabled = false;
					btnDelConfirm.Enabled = false;
					grdIECO.Columns[0].Visible = false;
					grdIECO.Columns[1].Visible = false;
				}
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

		private void btnShow_Click(object sender, System.EventArgs e)
		{
			fillgrid();
		}

		void fillgrid()
		{
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "select C.CO_CD, C.CO_NAME, D.R_DESIGNATION CO_DESIG,C.CO_PHONE_NO,C.CO_EMAIL,C.CO_TYPE CO_TYPE from T08_IE_CONTROLL_OFFICER C, T07_RITES_DESIG D where C.CO_DESIG=D.R_DESIG_CD(+) and C.CO_REGION='" + Session["Region"].ToString() + "' Order by C.CO_CD";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdIECO.Visible = false;
				}
				else
				{
					grdIECO.Visible = true;
					grdIECO.DataSource = dsP;
					grdIECO.DataBind();
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

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			int CD;
			conn1.Open();
			try
			{
				string status = "";
				if ((lstStatus.SelectedValue != "W"))
				{
					status = lstStatus.SelectedValue;
				}
				if ((code == 0))
				{
					string str3 = "select NVL(max(CO_CD),0) from T08_IE_CONTROLL_OFFICER ";
					OracleCommand myInsertCommand = new OracleCommand();
					myInsertCommand.CommandText = str3;
					myInsertCommand.Connection = conn1;
					CD = Convert.ToInt32(myInsertCommand.ExecuteScalar());
					code = CD + 1;
					string myInsertQuery = "INSERT INTO T08_IE_CONTROLL_OFFICER(CO_CD,CO_NAME,CO_DESIG,CO_REGION,CO_PHONE_NO,CO_EMAIL,CO_STATUS,CO_STATUS_DT,CO_TYPE) values(" + code + ", '" + txtCOName.Text + "', " + lstDesig.SelectedItem.Value + ",'" + Session["Region"].ToString() + "','" + txtCOPH_NO.Text.Trim() + "','" + txtCOEmail.Text.Trim() + "','" + status + "', to_date('" + txtStatusDT.Text + "','dd/mm/yyyy'),'" + DL_TYPE.SelectedItem.Value + "')";
					myInsertCommand.CommandText = myInsertQuery;
					myInsertCommand.Connection = conn1;
					myInsertCommand.ExecuteNonQuery();
					conn1.Close();

				}
				else
				{
					OracleCommand myUpdateCommand = new OracleCommand();
					string myUpdateQuery = "Update T08_IE_CONTROLL_OFFICER set CO_NAME ='" + txtCOName.Text + "', CO_DESIG = " + lstDesig.SelectedItem.Value + ", CO_PHONE_NO='" + txtCOPH_NO.Text.Trim() + "', CO_EMAIL='" + txtCOEmail.Text.Trim() + "',CO_STATUS='" + status + "',CO_STATUS_DT=to_date('" + txtStatusDT.Text + "','dd/mm/yyyy'),CO_TYPE='" + DL_TYPE.SelectedItem.Value + "' where CO_CD=" + code;
					myUpdateCommand.CommandText = myUpdateQuery;
					myUpdateCommand.Connection = conn1;
					myUpdateCommand.ExecuteNonQuery();
					int count = myUpdateCommand.ExecuteNonQuery();
					if ((count == 0))
					{
						throw new System.Exception("No Record Found!!! Any Other User had Deleted Your Record While you were Modifying");
					}
					conn1.Close();
				}

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
			Response.Redirect("IE_CO_Form.aspx");
		}

		void show()
		{
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "select CO_NAME,CO_DESIG,CO_PHONE_NO,CO_EMAIL,NVL(CO_STATUS,'W') CO_STATUS,TO_CHAR(CO_STATUS_DT,'dd/mm/yyyy')CO_STATUS_DT,CO_TYPE from T08_IE_CONTROLL_OFFICER where CO_CD=" + code;
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					throw new System.Exception("No Record Found!!! For The Given Code.");
				}
				else
				{
					txtCOName.Text = dsP.Tables[0].Rows[0]["CO_NAME"].ToString();
					lstDesig.SelectedValue = dsP.Tables[0].Rows[0]["CO_DESIG"].ToString();
					txtCOPH_NO.Text = dsP.Tables[0].Rows[0]["CO_PHONE_NO"].ToString();
					txtCOEmail.Text = dsP.Tables[0].Rows[0]["CO_EMAIL"].ToString();
					lstStatus.SelectedValue = dsP.Tables[0].Rows[0]["CO_STATUS"].ToString();
					txtStatusDT.Text = dsP.Tables[0].Rows[0]["CO_STATUS_DT"].ToString();
					DL_TYPE.SelectedValue = dsP.Tables[0].Rows[0]["CO_TYPE"].ToString();
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

		protected void btnDelConfirm_Click(object sender, System.EventArgs e)
		{
			try
			{

				string myDeleteQuery = "Delete From T08_IE_CONTROLL_OFFICER where CO_CD=" + code;
				OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
				myOracleCommand.Connection = conn1;
				conn1.Open();
				myOracleCommand.ExecuteNonQuery();
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
			Response.Redirect("IE_CO_Form.aspx");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("IE_CO_Form.aspx");
		}

		protected void grdIECO_PreRender(object sender, System.EventArgs e)
		{
			fillgrid();
		}
	}
}