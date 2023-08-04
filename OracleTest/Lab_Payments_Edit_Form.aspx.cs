using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Lab_Payments_Edit_Form
{
	public partial class Lab_Payments_Edit_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnShow.Attributes.Add("OnClick", "JavaScript:validate();");
			btnMod.Attributes.Add("OnClick", "JavaScript:validate1();");

			if (!(IsPostBack))
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				try
				{
					lstLab.Items.Clear();
					DataSet dsP2 = new DataSet();
					string str2 = "select LAB_ID,LAB_NAME||','||T03.CITY LAB_NAME from T65_LABORATORY_MASTER T65,T03_CITY T03 where T65.LAB_CITY=T03.CITY_CD order by LAB_NAME";
					OracleDataAdapter da2 = new OracleDataAdapter(str2, conn1);
					OracleCommand myOracleCommand2 = new OracleCommand(str2, conn1);
					ListItem lst2;
					conn1.Open();
					da2.SelectCommand = myOracleCommand2;
					da2.Fill(dsP2, "Table");
					for (int i = 0; i <= dsP2.Tables[0].Rows.Count - 1; i++)
					{
						lst2 = new ListItem();
						lst2.Text = dsP2.Tables[0].Rows[i]["LAB_NAME"].ToString();
						lst2.Value = dsP2.Tables[0].Rows[i]["LAB_ID"].ToString();
						lstLab.Items.Add(lst2);
					}
					conn1.Close();
					lstLab.Items.Insert(0, "");
					//					conn1.Open();
					//					OracleCommand cmd2 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual",conn1);
					//					lblRegDt.Text=Convert.ToString(cmd2.ExecuteScalar());
					//					conn1.Close();
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

		protected void btnShow_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string str1 = "select T56.PAYMENT_ID,to_char(T56.PAYMENT_DT,'dd/mm/yyyy') PAYMENT_DATE,LAB_NAME||','||T03.CITY LAB,AMOUNT from T56_LAB_PAYMENTS T56,T65_LABORATORY_MASTER T65, T03_CITY T03 where T56.LAB_ID=T65.LAB_ID and T65.LAB_CITY=T03.CITY_CD and substr(T56.PAYMENT_ID,1,1)='" + Session["Region"] + "' ";

				if (txtPaymentID.Text.Trim() != "")
				{
					str1 = str1 + " AND T56.PAYMENT_ID = '" + txtPaymentID.Text.Trim() + "'";
				}
				if (txtPaymentDT.Text.Trim() != "")
				{
					str1 = str1 + " AND PAYMENT_DT=to_date('" + txtPaymentDT.Text + "','dd/mm/yyyy')";
				}
				if (lstLab.SelectedValue != "")
				{
					str1 = str1 + " AND T56.LAB_ID=" + lstLab.SelectedValue;
				}

				str1 = str1 + " order by T56.PAYMENT_DT";
				DataSet dsP = new DataSet();
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");

				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdLAB.Visible = false;
					Label4.Visible = true;

				}
				else
				{
					grdLAB.DataSource = dsP;
					grdLAB.DataBind();
					grdLAB.Visible = true;


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

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Lab_Payments_Form.aspx");
		}

		protected void btnMod_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Lab_Payments_Form.aspx?PAYMENT_ID=" + txtPaymentID.Text.Trim());
		}
	}
}