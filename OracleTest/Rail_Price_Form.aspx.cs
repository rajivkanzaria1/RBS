using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Rail_Price_Form
{
	public class Rail_Price_Form1 : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		protected System.Web.UI.WebControls.Label Label1;
		private DataSet dsP = new DataSet();
		public string Action;
		short id_srno = 0, rail_id = 0;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.HyperLink HyperLink2;
		protected Tittle.Controls.CustomDataGrid grdRail_Price_Details;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Button btnAddRail_desc;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnSave2;
		protected System.Web.UI.WebControls.TextBox toDt;
		protected System.Web.UI.WebControls.TextBox frmDt;
		protected System.Web.UI.WebControls.TextBox txtPacking_Charge;
		protected System.Web.UI.WebControls.TextBox txtRail_Price;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label lblFBankCD;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList lstRailDesc;
		protected System.Web.UI.WebControls.Panel Panel_1;
		protected System.Web.UI.WebControls.TextBox txtRailLength;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.TextBox txtRailDesc;


		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelete.Attributes.Add("OnClick", "JavaScript:del();");


			if (Convert.ToString(Request.Params["RAIL_ID"]) == null || Convert.ToString(Request.Params["RAIL_ID"]) == "")
			{
				Action = "";
			}
			else
			{
				if (Convert.ToString(Request.Params["ID_SRNO"]) == null || Convert.ToString(Request.Params["ID_SRNO"]) == "")
				{
					id_srno = 0;
				}
				else
				{

					id_srno = Convert.ToInt16(Request.Params["ID_SRNO"].Trim());
				}

				Action = Convert.ToString(Request.Params["ACTION"].Trim());
				rail_id = Convert.ToInt16(Request.Params["RAIL_ID"].Trim());

			}

			if (!IsPostBack)
			{
				fill_items();
				if (Action == "")
				{
					btnSave.Visible = true;
					Panel_1.Visible = false;
				}
				else if (Action == "M")
				{
					lstRailDesc.SelectedValue = rail_id.ToString();
					show();
					fillgrid();
					btnAddRail_desc.Visible = true;
					btnSave.Visible = false;
					Panel_1.Visible = true;
					if (id_srno != 0)
					{
						show1();
						btnDelete.Visible = true;

					}


				}
				//				if(Convert.ToString(Session["Role"])!="Administrator")
				//				{
				//					btnSave.Enabled=false;
				//					btnDelConfirm.Enabled=false;
				//					grdBank.Columns[0].Visible=false;
				//					grdBank.Columns[1].Visible=false;
				//				}
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
			this.lstRailDesc.SelectedIndexChanged += new System.EventHandler(this.lstRailDesc_SelectedIndexChanged_1);
			this.btnAddRail_desc.Click += new System.EventHandler(this.btnAddRail_desc_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnSave2.Click += new System.EventHandler(this.btnSave2_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public void fill_items()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				lstRailDesc.Items.Clear();
				OracleCommand cmd = new OracleCommand("select RAIL_ID,RAIL_DESC from T34_RAIL_PRICE ORDER BY RAIL_DESC", conn1);
				OracleDataReader dr;
				conn1.Open();
				dr = cmd.ExecuteReader();
				ListItem lst;
				while (dr.Read())
				{
					lst = new ListItem();
					lst.Text = Convert.ToString(dr["RAIL_DESC"]);
					lst.Value = Convert.ToString(dr["RAIL_ID"]);
					lstRailDesc.Items.Add(lst);
				}
				lstRailDesc.Items.Insert(0, "");
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
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH:MI:SS') from dual", conn1);
			string ss = Convert.ToString(cmd2.ExecuteScalar());
			try
			{
				if (lstRailDesc.SelectedItem.Text == "")
				{
					string str3 = "select NVL(max(RAIL_ID),0)+1 from T34_RAIL_PRICE";
					OracleCommand myInsertCommand = new OracleCommand();
					myInsertCommand.CommandText = str3;
					myInsertCommand.Connection = conn1;

					int bcode = Convert.ToInt32(myInsertCommand.ExecuteScalar());

					string myInsertQuery = "INSERT INTO T34_RAIL_PRICE values(" + bcode + ",'" + txtRailDesc.Text.Trim() + "'," + txtRailLength.Text.Trim() + ", '" + Session["Uname"].ToString() + "', to_date('" + ss + "','dd/mm/yyyy-HH:MI:SS'))";
					myInsertCommand.CommandText = myInsertQuery;
					myInsertCommand.Connection = conn1;
					myInsertCommand.ExecuteNonQuery();
					conn1.Close();
					Panel_1.Visible = true;
					fillgrid();
				}
				else
				{

					OracleCommand myUpdateCommand = new OracleCommand();
					string myUpdateQuery = "Update T34_RAIL_PRICE set RAIL_DESC ='" + txtRailDesc.Text.Trim() + "',RAIL_LENGTH_METER=" + txtRailLength.Text.Trim() + ", USER_ID='" + Session["Uname"].ToString() + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH:MI:SS') where RAIL_ID=" + lstRailDesc.SelectedValue;
					myUpdateCommand.CommandText = myUpdateQuery;
					myUpdateCommand.Connection = conn1;
					int count = myUpdateCommand.ExecuteNonQuery();
					if ((count == 0))
					{
						throw new System.Exception("No Record Found!!! Any Other User had Deleted Your Record While you were Modifying");
					}
					conn1.Close();
				}

				//				Response.Redirect("Rail_Price_Form.aspx");
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				DisplayAlert(str1);
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}


		}
		void show()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "select RAIL_ID,RAIL_DESC,RAIL_LENGTH_METER from T34_RAIL_PRICE where RAIL_ID=" + rail_id + "";
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
					txtRailDesc.Text = dsP.Tables[0].Rows[0]["RAIL_DESC"].ToString();
					txtRailLength.Text = dsP.Tables[0].Rows[0]["RAIL_LENGTH_METER"].ToString();
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
				conn1.Dispose();
			}

		}

		void show1()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "select RAIL_ID,ID_SRNO,RAIL_PRICE_PER_MT,PACKING_CHARGE,to_char(PRICE_DATE_FR,'dd/mm/yyyy')PRICE_DATE_FR,to_char(PRICE_DATE_TO,'dd/mm/yyyy')PRICE_DATE_TO from T35_RAIL_PRICE_DETAILS where RAIL_ID=" + rail_id + " and ID_SRNO=" + id_srno;
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
					Label5.Text = dsP.Tables[0].Rows[0]["ID_SRNO"].ToString();
					txtRail_Price.Text = dsP.Tables[0].Rows[0]["RAIL_PRICE_PER_MT"].ToString();
					txtPacking_Charge.Text = dsP.Tables[0].Rows[0]["PACKING_CHARGE"].ToString();
					frmDt.Text = dsP.Tables[0].Rows[0]["PRICE_DATE_FR"].ToString();
					toDt.Text = dsP.Tables[0].Rows[0]["PRICE_DATE_TO"].ToString();
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
				conn1.Dispose();
			}

		}


		private void btnDelConfirm_Click(object sender, System.EventArgs e)
		{
			try
			{

				//				string myDeleteQuery = "Delete T94_Bank where BANK_CD="+code+"";
				//				OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
				//				myOracleCommand.Connection = conn1;
				//				conn1.Open();
				//				myOracleCommand.ExecuteNonQuery();
				//				conn1.Close();

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
			Response.Redirect("Bank_Form.aspx");

		}


		void fillgrid()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{

				DataSet dsP1 = new DataSet();
				string str1 = "select RAIL_ID,ID_SRNO,RAIL_PRICE_PER_MT,PACKING_CHARGE,to_char(PRICE_DATE_FR,'dd/mm/yyyy')PRICE_DATE_FR,to_char(PRICE_DATE_TO,'dd/mm/yyyy') PRICE_DATE_TO from T35_RAIL_PRICE_DETAILS where RAIL_ID=" + lstRailDesc.SelectedValue + " order by ID_SRNO DESC";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				dsP1.Clear();
				da.Fill(dsP1, "Table");
				if (dsP1.Tables[0].Rows.Count == 0)
				{
					grdRail_Price_Details.Visible = false;

				}
				else
				{
					//int aa=grdCity.CurrentPageIndex;
					grdRail_Price_Details.DataSource = dsP1;
					grdRail_Price_Details.DataBind();
					grdRail_Price_Details.Visible = true;
					//					grdRail_Price_Details.Columns[0].Visible=false;

				}

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str2 = str.Replace("\n", "");

			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}

		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("MainForm.aspx");
		}



		private void lstRailDesc_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
			if (lstRailDesc.SelectedItem.Text != "")
			{
				rail_id = Convert.ToInt16(lstRailDesc.SelectedValue);
				show();
				fillgrid();
				Panel_1.Visible = true;

			}
			else
			{
				Panel_1.Visible = false;
				txtRailDesc.Text = "";
				txtRailLength.Text = "";
			}
		}

		private void btnAddRail_desc_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Rail_Price_Form.aspx");
		}

		private void btnSave2_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH:MI:SS') from dual", conn1);
			string ss = Convert.ToString(cmd2.ExecuteScalar());

			if (id_srno == 0)
			{
				try
				{

					string str3 = "select NVL(max(ID_SRNO),0)+1 from T35_RAIL_PRICE_DETAILS where RAIL_ID=" + lstRailDesc.SelectedValue;
					OracleCommand myInsertCommand = new OracleCommand();
					myInsertCommand.CommandText = str3;
					myInsertCommand.Connection = conn1;

					int bcode = Convert.ToInt32(myInsertCommand.ExecuteScalar());
					OracleTransaction myTrans = conn1.BeginTransaction();
					string myInsertQuery = "INSERT INTO T35_RAIL_PRICE_DETAILS(RAIL_ID,ID_SRNO,RAIL_PRICE_PER_MT,PACKING_CHARGE,PRICE_DATE_FR,PRICE_DATE_TO,USER_ID,DATETIME) values(" + lstRailDesc.SelectedValue + "," + bcode + "," + txtRail_Price.Text.Trim() + "," + txtPacking_Charge.Text.Trim() + ",to_date('" + frmDt.Text.Trim() + "','dd/mm/yyyy'),to_date('" + toDt.Text.Trim() + "','dd/mm/yyyy') ,'" + Session["Uname"].ToString() + "', to_date('" + ss + "','dd/mm/yyyy-HH:MI:SS'))";
					myInsertCommand.Transaction = myTrans;
					myInsertCommand.CommandText = myInsertQuery;
					myInsertCommand.Connection = conn1;
					myInsertCommand.ExecuteNonQuery();
					bcode = bcode - 1;
					DateTime dt = new DateTime(Convert.ToInt16(frmDt.Text.Substring(6, 4)), Convert.ToInt16(frmDt.Text.Substring(3, 2)), Convert.ToInt16(frmDt.Text.Substring(0, 2)));
					dt = dt.AddDays(-1);
					string dt1 = dt.ToString("dd/MM/yyyy");
					OracleCommand cmd4 = new OracleCommand("update T35_RAIL_PRICE_DETAILS set PRICE_DATE_TO=to_date('" + dt1 + "','dd/mm/yyyy') where RAIL_ID=" + lstRailDesc.SelectedValue + " and ID_SRNO=" + bcode, conn1);
					cmd4.Transaction = myTrans;
					cmd4.ExecuteNonQuery();
					myTrans.Commit();
					conn1.Close();
					Panel_1.Visible = true;
					fillgrid();
				}
				catch (Exception ex)
				{
					string str;
					str = ex.Message;
					string str1 = str.Replace("\n", "");
					DisplayAlert(str1);
				}
				finally
				{
					conn1.Close();
					conn1.Dispose();
				}
			}
			else
			{
				try
				{
					OracleCommand myUpdateCommand = new OracleCommand();
					string myUpdateQuery = "Update T35_RAIL_PRICE_DETAILS set RAIL_PRICE_PER_MT =" + txtRail_Price.Text.Trim() + ",PACKING_CHARGE=" + txtPacking_Charge.Text.Trim() + ",PRICE_DATE_FR=to_date('" + frmDt.Text.Trim() + "','dd/mm/yyyy'),PRICE_DATE_TO=to_date('" + toDt.Text.Trim() + "','dd/mm/yyyy'), USER_ID='" + Session["Uname"].ToString() + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH:MI:SS') where RAIL_ID=" + rail_id + " and ID_SRNO=" + id_srno;
					myUpdateCommand.CommandText = myUpdateQuery;
					myUpdateCommand.Connection = conn1;
					int count = myUpdateCommand.ExecuteNonQuery();
					if ((count == 0))
					{
						throw new System.Exception("No Record Found!!! Any Other User had Deleted Your Record While you were Modifying");
					}
					conn1.Close();
				}
				catch (Exception ex)
				{
					string str;
					str = ex.Message;
					string str1 = str.Replace("\n", "");
					DisplayAlert(str1);
				}
				finally
				{
					conn1.Close();
					conn1.Dispose();
				}
				Response.Redirect("Rail_Price_Form.aspx?RAIL_ID=" + rail_id + "&action=M");
			}

			//				Response.Redirect("Rail_Price_Form.aspx");


		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			try
			{
				OracleCommand myDeleteCommand = new OracleCommand();
				string myDeleteQuery = "delete from T35_RAIL_PRICE_DETAILS where RAIL_ID=" + rail_id + " and ID_SRNO=" + id_srno;
				myDeleteCommand.CommandText = myDeleteQuery;
				myDeleteCommand.Connection = conn1;
				conn1.Open();
				int count = myDeleteCommand.ExecuteNonQuery();
				if ((count == 0))
				{
					throw new System.Exception("No Record Found!!! Any Other User had Deleted Your Record While you were Modifying");
				}
				conn1.Close();
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				DisplayAlert(str1);
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}
			Response.Redirect("Rail_Price_Form.aspx?RAIL_ID=" + rail_id + "&action=M");
		}

		private void grdRail_Price_Details_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//								if(Convert.ToInt16(e.Item.Cells[0].Text)!=2)
			//								{
			//									e.Item.Cells[0].Visible=false;
			//								}
		}
	}
}