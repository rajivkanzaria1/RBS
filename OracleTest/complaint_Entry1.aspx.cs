using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.complaint_Entry1
{
	public class complaint_Entry : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		protected System.Web.UI.WebControls.TextBox txtQtyOffer;
		protected System.Web.UI.WebControls.TextBox txtQtyRej;
		protected System.Web.UI.WebControls.DropDownList lstConsignee;
		protected System.Web.UI.WebControls.TextBox txtItemDesc;
		protected System.Web.UI.WebControls.TextBox txtRejReason;
		protected System.Web.UI.WebControls.TextBox txtBkNo;
		protected System.Web.UI.WebControls.TextBox txtSetNo;
		protected System.Web.UI.WebControls.TextBox txtCaseNo;
		protected System.Web.UI.WebControls.Label lblIE;
		protected System.Web.UI.WebControls.Label lblRegion;
		protected System.Web.UI.WebControls.TextBox txtValueRej;
		protected System.Web.UI.WebControls.DropDownList lstDefectCd;
		protected System.Web.UI.WebControls.DropDownList lstClassification;
		protected System.Web.UI.WebControls.TextBox txtComplaintDt;
		protected System.Web.UI.WebControls.TextBox txtStatus;
		protected System.Web.UI.WebControls.TextBox txtDt1stRef;
		protected System.Web.UI.WebControls.Label lblPoNo;
		protected System.Web.UI.WebControls.Label lblRly;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Label lblComplaintId;


		private void Page_Load(object sender, System.EventArgs e)
		{
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelete.Attributes.Add("OnClick", "JavaScript:del();");
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual", conn1);
			txtComplaintDt.Text = Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();


			if (!(IsPostBack))
			{
				DataSet dsP1 = new DataSet();
				string str1 = "select DEFECT_CD, DEFECT_DESC from T38_DEFECT_CODES";
				OracleDataAdapter da1 = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand1 = new OracleCommand(str1, conn1);
				ListItem lst1;
				conn1.Open();
				da1.SelectCommand = myOracleCommand1;
				da1.Fill(dsP1, "Table");
				for (int i = 0; i <= dsP1.Tables[0].Rows.Count - 1; i++)
				{
					lst1 = new ListItem();
					lst1.Text = dsP1.Tables[0].Rows[i]["DEFECT_DESC"].ToString();
					lst1.Value = dsP1.Tables[0].Rows[i]["DEFECT_CD"].ToString();
					lstDefectCd.Items.Add(lst1);
				}
				conn1.Close();

				DataSet dsP2 = new DataSet();
				string str2 = "select JI_STATUS_CD, JI_STATUS_DESC from T39_JI_STATUS_CODES";
				OracleDataAdapter da2 = new OracleDataAdapter(str2, conn1);
				OracleCommand myOracleCommand2 = new OracleCommand(str2, conn1);
				ListItem lst2;
				conn1.Open();
				da2.SelectCommand = myOracleCommand2;
				da2.Fill(dsP2, "Table");
				for (int i = 0; i <= dsP2.Tables[0].Rows.Count - 1; i++)
				{
					lst2 = new ListItem();
					lst2.Text = dsP2.Tables[0].Rows[i]["JI_STATUS_DESC"].ToString();
					lst2.Value = dsP2.Tables[0].Rows[i]["JI_STATUS_CD"].ToString();
					lstClassification.Items.Add(lst2);
				}
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
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			DisplayAlert("Hello");
		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

	}
}