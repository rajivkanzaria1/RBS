using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Call_Status_Edit_Form_Admin
{
	public partial class Call_Status_Edit_Form_Admin : System.Web.UI.Page
	{
		string wIECD;
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);


		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			string CASE_NO, CALL_RECV_DT, CALL_SNO;
			CASE_NO = Request.Params["CASE_NO"].ToString();
			CALL_RECV_DT = Request.Params["CALL_RECV_DT"].ToString();
			CALL_SNO = Request.Params["CALL_SNO"].ToString();
			//	wIECD=Request.Params["IE_CD"].ToString();


			if (!(IsPostBack))
			{
				DataSet ds = new DataSet();
				string str = "select CALL_STATUS_CD,CALL_STATUS_DESC from T21_CALL_STATUS_CODES order by CALL_STATUS_DESC";
				OracleDataAdapter da = new OracleDataAdapter(str, conn);
				OracleCommand myOracleCommand = new OracleCommand(str, conn);
				conn.Open();
				da.SelectCommand = myOracleCommand;
				conn.Close();
				da.Fill(ds, "Table");
				lstCallStatus.DataValueField = "CALL_STATUS_CD";
				lstCallStatus.DataTextField = "CALL_STATUS_DESC";
				lstCallStatus.DataSource = ds;
				lstCallStatus.DataBind();
				lstCallStatus.SelectedValue = "M";

				//				ListItem lst11 = new ListItem(); 
				//				lst11 = new ListItem(); 
				//				lst11.Text = "Pending"; 
				//				lst11.Value = "M"; 
				//				lstCallStatus.Items.Add(lst11);
				//				lst11 = new ListItem(); 
				//				lst11.Text = "Accepted"; 
				//				lst11.Value = "A"; 
				//				lstCallStatus.Items.Add(lst11); 
				//				lst11 = new ListItem(); 
				//				lst11.Text = "Rejection"; 
				//				lst11.Value = "R"; 
				//				lstCallStatus.Items.Add(lst11);
				//				lst11 = new ListItem(); 
				//				lst11.Text = "Under Lab Testing"; 
				//				lst11.Value = "U"; 
				//				lstCallStatus.Items.Add(lst11);
				//				lst11 = new ListItem(); 
				//				lst11.Text = "Still Under Inspection"; 
				//				lst11.Value = "S"; 
				//				lstCallStatus.Items.Add(lst11); 
				//				lst11 = new ListItem(); 
				//				lst11.Text = "Stage Inspection"; 
				//				lst11.Value = "G"; 
				//				lstCallStatus.Items.Add(lst11); 
				//				lst11 = new ListItem(); 
				//				lst11.Text = "Withheld"; 
				//				lst11.Value = "W"; 
				//				lstCallStatus.Items.Add(lst11); 

				ListItem lst1 = new ListItem();
				lst1 = new ListItem();
				lst1.Text = "Yes";
				lst1.Value = "Y";
				lstCStatusUAllow.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "No";
				lst1.Value = "N";
				lstCStatusUAllow.Items.Add(lst1);


				string sql = "Select T051.VEND_NAME,(T06.CONSIGNEE_DESIG||' '||T06.CONSIGNEE_FIRM) CONSIGNEE," +
					"T18.ITEM_DESC_PO,to_char(T17.CALL_MARK_DT,'dd/mm/yyyy') CALL_MARK_DT,to_char(T17.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT," +
					"T09.IE_NAME,T09.IE_PHONE_NO,T13.PO_NO,to_char(T13.PO_DT,'dd/mm/yyyy')PO_DATE,T17.CASE_NO," +
					"decode(T17.CALL_STATUS,'M','Pending','A','Accepted','R','Rejection','C','Cancelled','U','Under Lab Testing','S','Still Under Inspection','G','Stage Inspection','W','Withheld')CALL_STATUS1,T17.CALL_STATUS,NVL(UPDATE_ALLOWED,'Y')UPDATE_ALLOWED,T052.VEND_CONTACT_PER_1 MFG_PERS,T052.VEND_CONTACT_TEL_1 MFG_PHONE,T17.CALL_SNO," +
					"(select count(*) from T18_CALL_DETAILS A WHERE A.CASE_NO=T18.CASE_NO AND A.CALL_RECV_DT=T18.CALL_RECV_DT) COUNT " +
					"From T05_VENDOR T051,T06_CONSIGNEE T06,T17_CALL_REGISTER T17,T18_CALL_DETAILS T18,T13_PO_MASTER T13,T09_IE T09,T05_VENDOR T052 " +
					"Where  T051.VEND_CD=T13.VEND_CD and  T06.CONSIGNEE_CD(+)=T13.PURCHASER_CD and  T13.CASE_NO=T17.CASE_NO and " +
					"T09.IE_CD =T17.IE_CD  and  T18.CASE_NO=T17.CASE_NO and T18.CALL_RECV_DT=T17.CALL_RECV_DT and T17.MFG_CD=T052.VEND_CD(+) and " +
					"(T17.CASE_NO='" + CASE_NO + "' and T17.CALL_RECV_DT=to_date('" + CALL_RECV_DT + "','dd/mm/yyyy') and T17.CALL_SNO='" + CALL_SNO + "') and " +
					"T18.ITEM_SRNO_PO=(Select min(B.ITEM_SRNO_PO) from T18_CALL_DETAILS B where B.CASE_NO=T18.CASE_NO AND B.CALL_RECV_DT=T18.CALL_RECV_DT) " +
					"Order by T051.VEND_NAME,CALL_MARK_DT";

				try
				{
					OracleCommand cmd = new OracleCommand();
					cmd.CommandText = sql;
					cmd.Connection = conn;
					conn.Open();
					OracleDataReader readerB = cmd.ExecuteReader();
					while (readerB.Read())
					{
						lblVend.Text = Convert.ToString(readerB["VEND_NAME"]);
						lblPurc.Text = Convert.ToString(readerB["CONSIGNEE"]);
						lblItem.Text = Convert.ToString(readerB["ITEM_DESC_PO"]);
						lblCallDT.Text = Convert.ToString(readerB["CALL_RECV_DT"]);
						lblIEName1.Text = Convert.ToString(readerB["IE_NAME"]);
						//lblIEName.Text=Convert.ToString(readerB["IE_NAME"]);
						lblIECON.Text = Convert.ToString(readerB["IE_PHONE_NO"]);
						lblPONO.Text = Convert.ToString(readerB["PO_NO"]);
						lblPODT.Text = Convert.ToString(readerB["PO_DATE"]);
						lblCSNO.Text = Convert.ToString(readerB["CASE_NO"]);
						lblCONPER.Text = Convert.ToString(readerB["MFG_PERS"]);
						lblCONPERTEL.Text = Convert.ToString(readerB["MFG_PHONE"]);
						lblSNO.Text = Convert.ToString(readerB["CALL_SNO"]);
						lblCallStatus.Text = Convert.ToString(readerB["CALL_STATUS1"]);
						if (Convert.ToString(readerB["CALL_STATUS"]) == "C")
						{
							throw new System.Exception("This Call is Cancelled, so use Call Cancellation!!!");
						}
						lstCallStatus.SelectedValue = Convert.ToString(readerB["CALL_STATUS"]);
						lstCStatusUAllow.SelectedValue = Convert.ToString(readerB["UPDATE_ALLOWED"]);
						//						if(Convert.ToString(readerB["CALL_STATUS"])=="C" || Convert.ToString(readerB["CALL_STATUS"])=="R"||Convert.ToString(readerB["CALL_STATUS"])=="A")
						//						{
						//							lstCallStatus.SelectedValue=Convert.ToString(readerB["CALL_STATUS"]);
						//							lstCallStatus.Enabled=false;
						//						}
						//						else
						//						{
						//							lstCallStatus.SelectedValue=Convert.ToString(readerB["CALL_STATUS"]);
						//							lstCallStatus.Enabled=true;
						//						}
					}
				}
				catch (Exception ex)
				{
					//					string str; 
					str = ex.Message;
					string str1 = str.Replace("\n", "");
					Response.Redirect("Error_Form.aspx?err=" + str1);

				}
				finally
				{
					conn.Close();
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
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Call_Register_Edit.aspx");
		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				string status = "";
				if (lstCStatusUAllow.SelectedValue == "Y")
				{
					status = "";
				}
				else
				{
					status = lstCStatusUAllow.SelectedValue;
				}
				string updateQuery = "Update T17_CALL_REGISTER set CALL_STATUS='" + lstCallStatus.SelectedValue + "',UPDATE_ALLOWED='" + status + "' where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + "";
				OracleCommand myUpdateCommand = myUpdateCommand = new OracleCommand(updateQuery, conn);
				conn.Open();
				myUpdateCommand.ExecuteNonQuery();
				conn.Close();

				if (lstCallStatus.SelectedValue == "M" || lstCallStatus.SelectedValue == "A")
				{
					conn.Open();
					OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn);
					string ss = Convert.ToString(cmd2.ExecuteScalar());


					string updateQuery1 = "Update IC_INTERMEDIATE set CONSGN_CALL_STATUS='" + lstCallStatus.SelectedValue + "',USER_ID='" + Session["Uname"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + "";
					OracleCommand myUpdateCommand1 = myUpdateCommand1 = new OracleCommand(updateQuery1, conn);
					myUpdateCommand1.ExecuteNonQuery();
					conn.Close();

				}
				DisplayAlert("Call Status and Call Update Status has Been Modified!!!");
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect("Error_Form.aspx?err=" + str1);
			}
			finally
			{
				conn.Close();
			}

			//			if(lstCallStatus.SelectedValue=="C" || lstCallStatus.SelectedValue=="R"||lstCallStatus.SelectedValue=="A")
			//			{
			//				lstCallStatus.Enabled=false;
			//			}
			//			else
			//			{
			//				lstCallStatus.Enabled=true;
			//			}
		}
	}
}