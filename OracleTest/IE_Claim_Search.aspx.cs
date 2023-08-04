using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.IE_Claim_Search
{
	public partial class IE_Claim_Search : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSearch.Attributes.Add("OnClick", "JavaScript:validate1();");
			btnSubmit.Attributes.Add("OnClick", "JavaScript:validate();");
			if (!(IsPostBack))
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

				try
				{
					DataSet dsP1 = new DataSet();
					string str3 = "select IE_CD, IE_NAME from T09_IE where  IE_STATUS is null and IE_REGION='" + Session["REGION"] + "' order by IE_NAME ";
					OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
					OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
					ListItem lst3;
					conn1.Open();
					da.SelectCommand = myOracleCommand;
					da.Fill(dsP1, "Table");
					for (int i = 0; i <= dsP1.Tables[0].Rows.Count - 1; i++)
					{
						lst3 = new ListItem();
						lst3.Text = dsP1.Tables[0].Rows[i]["IE_NAME"].ToString();
						lst3.Value = dsP1.Tables[0].Rows[i]["IE_CD"].ToString();
						lstIE.Items.Add(lst3);
					}
					conn1.Close();
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
					conn1.Dispose();
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
			Response.Redirect("IE_Claim_Form.aspx?Action=A");
		}

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			DataSet dsP = new DataSet();
			try
			{
				//string str1 = "select R.VCHR_NO,R.SNO,A.ACC_DESC,R.AMOUNT,(B.BPO_NAME||'/'||B.BPO_ADD||'/'||B.BPO_RLY)BPO_NAME,R.CHQ_NO,to_char(R.CHQ_DT,'dd/mm/yyyy')CHQ_DT,R.NARRATION,R.SAMPLE_NO,D.BANK_NAME from T25_RV_DETAILS R, T95_ACCOUNT_CODES A, T12_BILL_PAYING_OFFICER B,T94_BANK D where R.ACC_CD=A.ACC_CD(+) AND R.BPO_CD=B.BPO_CD(+) and R.BANK_CD=D.BANK_CD AND VCHR_NO= '" + VNO + "'";

				string str1 = "select CLAIM_NO, to_char(CLAIM_DT,'dd/mm/yyyy')CLAIM_DT,to_char(RECEIVE_DT,'dd/mm/yyyy')RECV_DT,T09.IE_NAME from T45_CLAIM_MASTER T45,T09_IE T09 where  T45.IE_CD=T09.IE_CD";
				if (txtCNO.Text != "")
				{

					str1 = str1 + " and T45.CLAIM_NO='" + txtCNO.Text.Trim() + "'";
				}

				if (txtCDT.Text != "")
				{

					str1 = str1 + " and CLAIM_DT=to_date('" + txtCDT.Text.Trim() + "','dd/mm/yyyy')";
				}

				if (lstIE.SelectedValue != "")
				{
					str1 = str1 + " and T45.IE_CD=" + lstIE.SelectedValue;
				}
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdVDt.Visible = false;
					DisplayAlert("No Record Found");
				}
				else
				{
					grdVDt.Visible = true;
					grdVDt.DataSource = dsP;
					grdVDt.DataBind();
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
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("IE_Claim_Form.aspx?CLAIM_NO=" + txtCNO.Text + "&Action=M");
		}
	}
}