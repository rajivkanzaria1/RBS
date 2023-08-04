using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Incoming_Dak_Edit
{
	public partial class Incoming_Dak_Edit : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Button btnMod;
		protected System.Web.UI.WebControls.Button btnShow;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtLetterID;
		protected System.Web.UI.WebControls.TextBox txtRecDT;
		protected System.Web.UI.WebControls.TextBox txtLetterNo;
		protected Tittle.Controls.CustomDataGrid grdDak;
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);


		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnShow.Attributes.Add("OnClick", "JavaScript:validate();");
			btnMod.Attributes.Add("OnClick", "JavaScript:validate1();");

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
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnShow_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string str1 = "select T55.LETTER_ID,to_char(LETTER_RECV_DT,'dd/mm/yyyy') REC_DATE,LETTER_NO from T55_DAK_INCOMING_MASTER T55 where substr(T55.LETTER_ID,1,1)='" + Session["Region"] + "' ";

				if (txtLetterID.Text.Trim() != "")
				{
					str1 = str1 + " AND T55.LETTER_ID = '" + txtLetterID.Text.Trim() + "'";
				}
				if (txtRecDT.Text.Trim() != "")
				{
					str1 = str1 + " AND LETTER_RECV_DT=to_date('" + txtRecDT.Text + "','dd/mm/yyyy')";
				}
				if (txtLetterNo.Text.Trim() != "")
				{
					str1 = str1 + " AND LETTER_NO='" + txtLetterNo.Text + "' ";
				}

				str1 = str1 + " order by T55.LETTER_RECV_DT";
				DataSet dsP = new DataSet();
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");

				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdDak.Visible = false;
					Label4.Visible = true;

				}
				else
				{
					grdDak.DataSource = dsP;
					grdDak.DataBind();
					grdDak.Visible = true;


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

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Vigilance_Cases_Form.aspx?Action=A");
		}
	}
}