using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.IE_Menu
{
	public partial class IE_Menu : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink HyperLink2;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);


		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn1.Open();
			OracleCommand cmd11 = new OracleCommand("Select to_char(sysdate,'mmdd') from dual", conn1);
			string sdate = Convert.ToString(cmd11.ExecuteScalar());
			string str3 = "select to_char(IE_DOB,'mmdd') from T09_IE where IE_CD='" + Session["IE_CD"] + "'";
			OracleCommand myOracleCommand3 = new OracleCommand(str3, conn1);

			string DOB = Convert.ToString(myOracleCommand3.ExecuteScalar());

			if (DOB == sdate)
			{
				lblMessage.Visible = true;
			}
			else
			{
				lblMessage.Visible = false;
			}
			conn1.Close();
			//			fillgrid();
			conn1.Dispose();

			//Response.Write("<MARQUEE dataFormatAs='html' style='FONT-SIZE: 10pt; WIDTH: 100%; FONT-FAMILY: Verdana; HEIGHT: 100%' scrollDelay='125' behavior='alternate' width='100%'>" + lblMessage.Text+"</MARQUEE>");

		}

		void fillgrid()
		{
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "select T17.CASE_NO, TO_CHAR(T17.CALL_RECV_DT,'DD/MM/YYYY') CALL_DT, T17.CALL_SNO, V05.VENDOR from T17_CALL_REGISTER T17, T13_PO_MASTER T13, T15_PO_DETAIL T15, T18_CALL_DETAILS T18, V05_VENDOR V05  where T17.CASE_NO=T13.CASE_NO AND T13.CASE_NO=T15.CASE_NO AND T18.ITEM_SRNO_PO=T15.ITEM_SRNO AND T17.CASE_NO=T18.CASE_NO AND T17.CALL_RECV_DT=T18.CALL_RECV_DT AND T17.CALL_SNO=T18.CALL_SNO AND T13.VEND_CD=V05.VEND_CD AND EXT_DELV_DT-SYSDATE<7 AND CALL_STATUS IN ('M','S','W') AND IE_CD='" + Session["IE_CD"] + "' GROUP BY T17.CASE_NO, TO_CHAR(T17.CALL_RECV_DT,'DD/MM/YYYY'), T17.CALL_SNO, V05.VENDOR ";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdDPCalls.Visible = false;
					Label4.Visible = false;
				}
				else
				{
					grdDPCalls.Visible = true;
					grdDPCalls.DataSource = dsP;
					grdDPCalls.DataBind();
					Label4.Visible = true;
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
	}
}