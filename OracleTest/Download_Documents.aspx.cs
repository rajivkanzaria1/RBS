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

namespace RBS.Download_Documents
{
	public partial class Download_Documents : System.Web.UI.Page
	{
		OracleConnection Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);


		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (Convert.ToString(Request.Params["allowDL"]) == "Y" && Session["Uname"].ToString() != "")
			{
				if (!(IsPostBack))
				{
					Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
					Conn.Open();
					OracleCommand cmd = new OracleCommand("Select nvl(ALLOW_DN_CHKSHT,'N') From T02_USERS Where USER_ID='" + Session["Uname"] + "'", Conn);
					string wAns = Convert.ToString(cmd.ExecuteScalar());
					Conn.Close();
					Conn.Dispose();
					if (wAns == "Y")
					{
						fill_DocType();
						if (Convert.ToString(Request.Params["Action"]) == "CI")
						{
							lstDocType.SelectedValue = "R";
							lstDocType.Enabled = false;
							doctype_change();
							lstDocSubType.SelectedValue = "C";
							lstDocSubType.Enabled = false;
							search();
						}
					}
					else
					{
						Response.Redirect("Error_Form.aspx?err=You Are Not Allowed To Perform This Action.");
					}
				}
			}
			else if (Session["IE_NAME"].ToString() != "")
			{
				if (!(IsPostBack))
				{
					fill_DocType();
					if (Convert.ToString(Request.Params["Action"]) == "CI")
					{
						lstDocType.SelectedValue = "R";
						lstDocType.Enabled = false;
						doctype_change();
						lstDocSubType.SelectedValue = "C";
						lstDocSubType.Enabled = false;
						search();
					}
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
			this.DgCK.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DgCK_ItemDataBound);

		}
		#endregion

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			search();
		}
		public void search()
		{
			string MyStr = "";
			if (lstDocType.SelectedValue != "")
			{

				if (lstDocType.SelectedValue == "I")
				{
					MyStr = "DOC_TYPE='" + lstDocType.SelectedValue + "' and REGION='" + lstRegionCd.SelectedValue + "'";
				}
				else
				{
					MyStr = "DOC_TYPE='" + lstDocType.SelectedValue + "'";
				}
				lblGridHeader.Text = lstDocType.SelectedItem.Text;
				if (lblDocSubType.Text.Trim() != "*")
				{
					MyStr = MyStr + " and DOC_SUB_TYPE='" + lstDocSubType.SelectedValue + "'";
					lblGridHeader.Text = lblGridHeader.Text + " -- " + lstDocSubType.SelectedItem.Text;
				}
			}
			if (txtDocName.Text.Trim() != "")
			{
				if (MyStr == "")
				{
					MyStr = "upper(DOCUMENT_NAME) like upper('%" + txtDocName.Text + "%')";
					lblGridHeader.Text = lblGridHeader.Text + " List of Documents With Specific Name";
				}
				else
				{
					MyStr = MyStr + " and upper(DOCUMENT_NAME) like upper('%" + txtDocName.Text + "%')";
					lblGridHeader.Text = lblGridHeader.Text + " -- List of Documents With Specific Name";
				}
			}
			if (MyStr == "")
			{
				DgCK.Visible = false;
				lblGridHeader.Text = "";
				DisplayAlert("Nothing to Search!!");
			}
			else
			{
				Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				OracleDataAdapter da = null;
				try
				{
					string str = "select (trim(FILE_ID)||'.'||FILE_EXT) FILE_NAME,DOCUMENT_NAME,DOCUMENT_NO,to_char(ISSUE_DT,'dd/mm/yyyy')ISSUE_DATE,('Documents/'||trim(FILE_ID)||'.'||FILE_EXT) FILE_LOCATION from T76_DOCUMENT_CATALOG where " + MyStr + " order by ISSUE_DT DESC, DOCUMENT_NAME";
					da = new OracleDataAdapter(str, Conn);
					DataSet dsP = new DataSet();
					OracleCommand myOracleCommand = new OracleCommand(str, Conn);
					Conn.Open();
					da.SelectCommand = myOracleCommand;
					da.Fill(dsP, "Table");
					if (dsP.Tables[0].Rows.Count == 0)
					{
						DgCK.Visible = false;
						lblGridHeader.Text = "";
						DisplayAlert("No Data Found !!");
					}
					else
					{
						DgCK.DataSource = dsP;
						DgCK.DataBind();
						DgCK.Visible = true;
					}
				}
				catch (Exception ex)
				{
					string str;
					str = ex.Message;
					str = str.Replace("\n", "");
					Response.Redirect(("Error_Form.aspx?err=" + str));
				}
				finally
				{
					Conn.Close();
					Conn.Dispose();
				}
			}
		}
		private void DgCK_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			string fpath = Server.MapPath("/RBS/");
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				fpath = fpath + Convert.ToString(e.Item.Cells[4].Text);
				if (File.Exists(fpath) == false)
				{
					e.Item.Cells[4].Text = "<Font Face=Verdana Color=RED>No Document Available!!!</Font>";
				}
				else
				{
					e.Item.Cells[4].Text = "<a href=" + Convert.ToString(e.Item.Cells[4].Text) + ">Download Document</a>";
				}
			}
		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		private void fill_DocType()
		{
			Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			lstDocType.Items.Clear();
			DataSet ds = new DataSet();
			OracleCommand cmd = new OracleCommand("Select DOC_TYPE,DOC_TYPE_DESC from T74_DOCUMENT_TYPES", Conn);
			OracleDataAdapter da = new OracleDataAdapter(cmd);
			ListItem lst;
			//
			lst = new ListItem();
			lst.Value = null;
			lst.Text = null;
			lstDocType.Items.Add(lst);
			//
			da.SelectCommand = cmd;
			da.Fill(ds, "Table");
			for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
			{
				lst = new ListItem();
				lst.Value = ds.Tables[0].Rows[i]["DOC_TYPE"].ToString();
				lst.Text = ds.Tables[0].Rows[i]["DOC_TYPE_DESC"].ToString();
				lstDocType.Items.Add(lst);
			}
			Conn.Close();
			Conn.Dispose();
		}
		public void doctype_change()
		{
			if (lstDocType.SelectedValue == "X")
			{
				Response.Write("<script language=JavaScript>var oWin= window.open('http://www.rdso.indianrailways.gov.in/view_section.jsp?lang=0&id=0,2,459,523,551','', 'resizable=yes,scrollbars=yes');");
				Response.Write("if (oWin==null || typeof(oWin)=='undefined') alert('System has been blocked by POP-UP BLOCKER!!!\\nPlease disable the POP-UP BLOCKER and try again or Please contact your system administrator.');</script>");
				Response.Write("<script language='Javascript'>window.opener='x';window.close();</script>");
			}
			else
			{

				DgCK.Visible = false;
				lblGridHeader.Text = "";
				txtDocSubType.Text = lstDocType.SelectedItem.Text;
				Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				lstDocSubType.Items.Clear();
				DataSet ds = new DataSet();
				OracleCommand cmd = new OracleCommand("Select DOC_SUB_TYPE,DOC_SUB_TYPE_DESC from T75_DOC_SUB_TYPES where DOC_TYPE='" + lstDocType.SelectedValue + "' ORDER BY DOC_SUB_TYPE_DESC desc", Conn);
				OracleDataAdapter da = new OracleDataAdapter(cmd);
				ListItem lst;
				da.SelectCommand = cmd;
				da.Fill(ds, "Table");
				if (ds.Tables[0].Rows.Count > 0)
				{
					lstDocSubType.Visible = true;
					txtDocSubType.Visible = true;
					lblDocSubType.Text = "";
					for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
					{
						lst = new ListItem();
						lst.Value = ds.Tables[0].Rows[i]["DOC_SUB_TYPE"].ToString();
						lst.Text = ds.Tables[0].Rows[i]["DOC_SUB_TYPE_DESC"].ToString();
						lstDocSubType.Items.Add(lst);
					}
				}
				else
				{
					lstDocSubType.Visible = false;
					txtDocSubType.Visible = false;
					lblDocSubType.Text = "*";
				}
				Conn.Close();
				Conn.Dispose();

				if (lstDocType.SelectedValue == "I")
				{
					lblRegion.Visible = true;
					lstRegionCd.Visible = true;
					lstRegionCd.SelectedValue = Session["Region"].ToString();
				}
				else
				{
					lblRegion.Visible = false;
					lstRegionCd.Visible = false;
				}
			}
		}
		protected void lstDocType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			doctype_change();
		}
	}
}