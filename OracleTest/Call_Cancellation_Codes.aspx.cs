using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Call_Cancellation_Codes
{
	public partial class Call_Cancellation_Codes : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		DataSet dsP = new DataSet();
		string CNO;

		void show()
		{
			try
			{
				string str1 = "select CANCEL_CD,CANCEL_DESC from T11_CALL_CANCEL_CODES";
				//string str1 = "select CASE_NO, TO_CHAR(CALL_RECV_DT,'dd/mm/yy') CALL_RECV_DT,ITEM_SRNO_PO,ITEM_DESC_PO,QTY_INSP from T18_CALL_DETAILS where CASE_NO= '" + CNO + "' and CALL_RECV_DT='"+ DT +"'"; 
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdCCDetails.Visible = false;
				}
				else
				{
					grdCCDetails.Visible = true;
					grdCCDetails.DataSource = dsP;
					grdCCDetails.DataBind();
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


		}



		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelete.Attributes.Add("OnClick", "JavaScript:del();");
			if (Convert.ToString(Request.QueryString["CANCEL_CD"]) == null)
			{
				CNO = "";

			}
			else
			{
				CNO = Convert.ToString(Request.QueryString["CANCEL_CD"].Trim());

			}
			if (!(IsPostBack))
			{
				if (CNO != "")
				{

					DataSet dsP2 = new DataSet();
					string str3 = "select CANCEL_CD, CANCEL_DESC from T11_CALL_CANCEL_CODES where CANCEL_CD=" + CNO + " ";
					OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
					OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
					conn1.Open();
					da.SelectCommand = myOracleCommand;
					da.Fill(dsP2, "Table");
					txtCCode.Text = dsP2.Tables[0].Rows[0]["CANCEL_CD"].ToString();
					txtCCode.Enabled = false;
					txtCdesc.Text = dsP2.Tables[0].Rows[0]["CANCEL_DESC"].ToString();
					conn1.Close();
					btnAdd.Visible = false;
				}
				else
				{
					btnAdd.Visible = true;
				}

				show();

				//				grdCDetails.DataSource=this.show();
				//				grdCDetails.DataBinding();

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
			this.grdCCDetails.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grdCDetails_ItemDataBound);

		}
		#endregion



		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (txtCCode.Visible == false)
				{
					string str3 = "select NVL(max(CANCEL_CD),0) from T11_CALL_CANCEL_CODES";
					OracleCommand myCommand = new OracleCommand();
					myCommand.CommandText = str3;
					myCommand.Connection = conn1;
					conn1.Open();
					int CD = Convert.ToInt32(myCommand.ExecuteScalar());
					CD = CD + 1;
					string myInsertQuery = "INSERT INTO T11_CALL_CANCEL_CODES values(" + CD + ",'" + txtCdesc.Text + "')";
					OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
					myInsertCommand.Connection = conn1;
					myInsertCommand.ExecuteNonQuery();
					conn1.Close();
				}
				else
				{
					string myUpdateQuery = "Update T11_CALL_CANCEL_CODES set CANCEL_DESC ='" + txtCdesc.Text + "' where CANCEL_CD=" + CNO;
					OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
					myUpdateCommand.Connection = conn1;
					conn1.Open();
					myUpdateCommand.ExecuteNonQuery();
					conn1.Close();
				}


				show();
				txtCCode.Visible = true;
				Label10.Visible = true;
				txtCdesc.Enabled = true;
				txtCCode.Text = "";
				txtCdesc.Text = "";
				btnAdd.Visible = true;
				DisplayAlert("Your Record Has Been Updated!!!");
				//				grdCDetails.DataSource=this.show();
				//				grdCDetails.DataBinding();
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

		private void grdCDetails_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//			if(e.Item.ItemType!=ListItemType.Header && e.Item.ItemType!=ListItemType.Footer)
			//			{
			//				LinkButton btn=(LinkButton)e.Item.Cells[0].Controls[0];
			//				btn.Attributes.Add("onclick","return confirm('Are you sure to delete  ?')");
			//			}
		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{

				{
					String myDeleteQuery = "Delete T11_CALL_CANCEL_CODES where CANCEL_CD= " + txtCCode.Text;
					OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
					myOracleCommand.Connection = conn1;
					conn1.Open();
					myOracleCommand.ExecuteNonQuery();
					conn1.Close();
					//txtSerialNo.Text="";
					//txtItemDesc.Text="";
					//txtQuanInsp.Text="";
					//txtCaseNo.Text="";
					//txtDtOfReciept.Text="";
					txtCCode.Text = "";
					txtCdesc.Text = "";
					show();
				}
				//string popupScript = "<script language='javascript'>" + "window.open('PopUp.aspx?str=Your Record Has Been Deleted!!!', 'CustomPopUp', " + "'width=330, height=120, menubar=no, resizable=no')" + "</script>";
				//Page.RegisterStartupScript("PopupScript", popupScript);
				DisplayAlert("Your Record Has Been Deleted!!!");
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
			}
			finally
			{
				conn1.Close();
			}
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("MainForm.aspx");
		}


		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			txtCCode.Visible = false;
			Label10.Visible = false;
			btnAdd.Visible = false;
		}

		protected void txtCdesc_TextChanged(object sender, System.EventArgs e)
		{

		}



	}
}