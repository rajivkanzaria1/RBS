using Oracle.ManagedDataAccess.Client;
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
    public partial class Hologram_Search_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = null;
		protected System.Web.UI.WebControls.DataGrid grdBook;
		protected System.Web.UI.WebControls.Button btnSearchIC;
		protected System.Web.UI.WebControls.Button btnDeleteIC;
		protected System.Web.UI.WebControls.Button btnModifyIC;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlIE;
		protected System.Web.UI.WebControls.TextBox txtSetNoFR;
		protected System.Web.UI.WebControls.TextBox txtSetNoTo;
		string HGNoFR, HGNoTO;
		protected System.Web.UI.WebControls.Label lblReg2;
		protected System.Web.UI.WebControls.Label lblReg1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnModifyIC.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDeleteIC.Attributes.Add("OnClick", "JavaScript:validate();");
			btnSearchIC.Attributes.Add("OnClick", "JavaScript:search();");

			lblReg1.Text = Session["Region"].ToString();
			lblReg2.Text = Session["Region"].ToString();
			if (!IsPostBack)
			{
				fill_IEwhomeIssued();
				if ((Convert.ToString(Request.QueryString["HG_NO_FR"]) == "" && Convert.ToString(Request.QueryString["HG_NO_TO"]) == "") || (Convert.ToString(Request.QueryString["HG_NO_FR"]) == null && Convert.ToString(Request.QueryString["HG_NO_TO"]) == null))
				{
					txtSetNoFR.Text = "";
					txtSetNoTo.Text = "";
				}
				else
				{
					txtSetNoFR.Text = Convert.ToString(Request.QueryString["HG_NO_FR"].Substring(1, 7));
					txtSetNoTo.Text = Convert.ToString(Request.QueryString["HG_NO_TO"].ToString().Substring(1, 7));
				}
				if (Convert.ToString(Session["Role"]) != "Administrator")
				{
					btnAdd.Enabled = false;
					btnModifyIC.Enabled = false;
					btnDeleteIC.Enabled = false;
					grdBook.Columns[0].Visible = false;
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
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnModifyIC.Click += new System.EventHandler(this.btnModifyIC_Click);
			this.btnDeleteIC.Click += new System.EventHandler(this.btnDeleteIC_Click);
			this.btnSearchIC.Click += new System.EventHandler(this.btnSearchIC_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Hologram_Form.aspx");
		}
		public void fill_IEwhomeIssued()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				ddlIE.Items.Clear();
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
					ddlIE.Items.Add(lst);
				}
				ddlIE.Items.Insert(0, "");
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
		public string match()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			string count = "";
			HGNoFR = Convert.ToString(txtSetNoFR.Text.Trim());
			HGNoTO = Convert.ToString(txtSetNoTo.Text.Trim());
			try
			{
				OracleCommand cmd = new OracleCommand("Select T31.HG_REGION FROM T31_HOLOGRAM_ISSUED T31,T09_IE T09 WHERE T31.HG_IECD=T09.IE_CD and trim(T31.HG_NO_FR) = '" + HGNoFR + "' and trim(T31.HG_NO_TO)= '" + HGNoTO + "'  and T31.HG_REGION='" + Session["Region"].ToString() + "'", conn1);
				conn1.Open();
				count = Convert.ToString(cmd.ExecuteScalar());
				if (count == "\0")
				{
					count = "0";
				}
				if (count == Session["Region"].ToString())
				{
					count = "2";
				}
				else
				{
					count = "1";
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
				conn1.Dispose();
			}
			return count;
		}
		private void btnModifyIC_Click(object sender, System.EventArgs e)
		{
			string i = match();
			if (i == "2")
			{
				Response.Redirect("Hologram_Form.aspx?Action=M&HG_NO_FR=" + HGNoFR + "&HG_NO_TO=" + HGNoTO + "");
			}
			else if (i == "0")
			{
				DisplayAlert("No Record Found of Entered Hologram No From. and Hologram No.To!!!");
			}
			else
			{
				DisplayAlert("You Are Not Authorised to Update/Delete Hologram data Issued to Other Regions!!!");
			}
		}

		private void btnDeleteIC_Click(object sender, System.EventArgs e)
		{
			string i = match();
			if (i == "2")
			{
				Response.Redirect("Hologram_Form.aspx?Action=D&HG_NO_FR=" + HGNoFR + "&HG_NO_TO=" + HGNoTO + "");
			}
			else if (i == "0")
			{
				DisplayAlert("No Record Found of Entered Hologram No From. and Hologram No.To!!!");
			}
			else
			{
				DisplayAlert("You Are Not Authorised to Update/Delete The Hologram Issued to Other Regions!!!");
			}
		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		private void btnSearchIC_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string str1 = "select b.HG_REGION||b.HG_NO_FR HG_NO_FR,b.HG_REGION||b.HG_NO_TO HG_NO_TO,to_char(HG_ISSUE_DT,'dd/mm/yyyy') ISSUE_DT,i.IE_NAME HG_IECD,decode(i.IE_REGION,'N','Northern','W','Western','E','Eastern','S','South','C','Central')REGION from T31_HOLOGRAM_ISSUED b,T09_IE i where b.HG_IECD=i.IE_CD ";

				if (txtSetNoFR.Text.Trim() != "")
				{
					str1 = str1 + " and (trim(HG_NO_FR))=(" + txtSetNoFR.Text.Trim() + ")";
				}
				if (txtSetNoTo.Text.Trim() != "")
				{
					str1 = str1 + " and (trim(HG_NO_TO))=(" + txtSetNoTo.Text.Trim() + ")";
				}
				if (ddlIE.SelectedItem.Text != "")
				{
					str1 = str1 + " and (trim(HG_IECD))=(trim(" + ddlIE.SelectedValue + "))";
				}
				str1 = str1 + "and HG_REGION='" + Session["Region"].ToString() + "' ORDER BY HG_NO_FR";

				OracleCommand myOracleCommand1 = new OracleCommand(str1, conn1);
				conn1.Open();
				OracleDataReader dr;
				dr = myOracleCommand1.ExecuteReader(CommandBehavior.CloseConnection);

				if (dr.HasRows)
				{
					grdBook.DataSource = dr;
					grdBook.DataBind();
					grdBook.Visible = true;
					//grdBook.Columns[1].Visible=false;
				}
				else
				{
					grdBook.Visible = false;
					DisplayAlert("No Data Found!!!");
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
	}
}