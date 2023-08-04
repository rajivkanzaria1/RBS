using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.IC_BookSet_Search_Form1
{
	public partial class IC_BookSet_Search_Form1 : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		string BkNo;
		int SetNoFr;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnModifyIC.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDeleteIC.Attributes.Add("OnClick", "JavaScript:validate();");
			btnSearchIC.Attributes.Add("OnClick", "JavaScript:search();");

			if (!IsPostBack)
			{
				fill_IEwhomeIssued();
				if (Convert.ToString(Request.QueryString["BK_NO"]) == "" && Convert.ToString(Request.QueryString["SET_NO_FR"]) == "")
				{
					txtBKNo.Text = "";
					txtSetNo.Text = "";
				}
				else
				{
					txtBKNo.Text = Convert.ToString(Request.QueryString["BK_NO"]);
					txtSetNo.Text = Convert.ToString(Request.QueryString["SET_NO_FR"]);
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

		}
		#endregion

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("IC_Bookset_Form.aspx?Action=A");
		}
		public void fill_IEwhomeIssued()
		{
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
			}
		}
		public string match()
		{
			string count = "";
			BkNo = (txtBKNo.Text.Trim());
			SetNoFr = Convert.ToInt32(txtSetNo.Text.Trim());
			try
			{
				OracleCommand cmd = new OracleCommand("Select T09.IE_REGION FROM T10_IC_BOOKSET T10,T09_IE T09 WHERE T10.ISSUE_TO_IECD=T09.IE_CD and trim(T10.BK_NO) = '" + BkNo + "' AND trim(T10.SET_NO_FR) = " + SetNoFr + " and T09.IE_REGION='" + Session["Region"].ToString() + "'", conn1);
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
			}
			return count;
		}
		protected void btnModifyIC_Click(object sender, System.EventArgs e)
		{
			string i = match();
			if (i == "2")
			{
				Response.Redirect("IC_Bookset_Form.aspx?Action=M&BK_NO='" + BkNo + "'&SET_NO_FR=" + SetNoFr + "");
			}
			else if (i == "0")
			{
				DisplayAlert("No Record Found of Enterad Book No. and Set No.For!!!");
			}
			else
			{
				DisplayAlert("You Are Not Authorised to Update/Delete The Book and Set data Issued to Other Regions!!!");
			}
		}

		protected void btnDeleteIC_Click(object sender, System.EventArgs e)
		{
			string i = match();
			if (i == "2")
			{
				Response.Redirect("IC_Bookset_Form.aspx?Action=D&BK_NO='" + BkNo + "'&SET_NO_FR=" + SetNoFr + "");
			}
			else if (i == "0")
			{
				DisplayAlert("No Record Found of Enterad Book No. and Set No.For!!!");
			}
			else
			{
				DisplayAlert("You Are Not Authorised to Update/Delete The Book and Set data Issued to Other Regions!!!");
			}
		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		protected void btnSearchIC_Click(object sender, System.EventArgs e)
		{
			try
			{
				string str1 = "select b.BK_NO,b.SET_NO_FR,b.SET_NO_TO,to_char(ISSUE_DT,'dd/mm/yyyy') ISSUE_DT,i.IE_NAME ISSUE_TO_IECD,decode(i.IE_REGION,'N','Northern','W','Western','E','Eastern','S','South','C','Central')BK_ISSUED_TO_REGION,b.BK_SUBMITTED,to_char(BK_SUBMIT_DT,'dd/mm/yyyy') BK_SUBMIT_DT from T10_IC_BOOKSET b,T09_IE i where b.ISSUE_TO_IECD=i.IE_CD ";

				if (txtBKNo.Text.Trim() != "")
				{
					str1 = str1 + " and upper(trim(BK_NO)) LIKE upper('" + txtBKNo.Text.Trim() + "')";
				}

				if (txtSetNo.Text.Trim() != "")
				{
					str1 = str1 + " and (trim(SET_NO_FR))=(" + txtSetNo.Text.Trim() + ")";
				}
				if (ddlIE.SelectedItem.Text != "")
				{
					str1 = str1 + " and (trim(IE_CD))=(trim(" + ddlIE.SelectedValue + "))";
				}
				str1 = str1 + "and REGION='" + Session["Region"].ToString() + "' ORDER BY BK_NO ,SET_NO_FR";

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
					DisplayAlert("Book No. Not Registered!!!");
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
	}
}