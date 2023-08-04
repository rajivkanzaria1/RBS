using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Call_Status_Edit_Form
{
	public partial class Call_Status_Edit_Form : System.Web.UI.Page
	{
		string wIECD;
		//protected System.Web.UI.WebControls.HyperLink HyperLink2;
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);


		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnSaveCancellation.Attributes.Add("OnClick", "JavaScript:validate();");
			btnSaveCancellation.Attributes.Add("OnClick", "JavaScript:validate1();");
			string CASE_NO, CALL_RECV_DT, CALL_SNO;
			CASE_NO = Request.Params["CASE_NO"].ToString();
			CALL_RECV_DT = Request.Params["CALL_RECV_DT"].ToString();
			CALL_SNO = Request.Params["CALL_SNO"].ToString();
			//			ACTION=Request.Params["ACTION"].ToString();
			wIECD = Session["IE_CD"].ToString();
			HyperLink1.NavigateUrl = "/RBS/IE_IC_Photo_Upload.aspx?CASE_NO=" + CASE_NO + "&CALL_RECV_DT=" + CALL_RECV_DT + "&CALL_SNO=" + CALL_SNO;
			#region HML
			HprInspecttestPlan.NavigateUrl = "/RBS/IC_InspectionTstPln.aspx?CASE_NO=" + CASE_NO + "&CALL_RECV_DT=" + CALL_RECV_DT + "&CALL_SNO=" + CALL_SNO + "&IE_CD=" + wIECD + "&ACTIONAR=" + lstCallStatus.SelectedValue + "&ACTION=" + Request.Params["ACTION"].Trim() + "";
			HprInspecttestPlan.Visible = false;
			#endregion
			HyperLink2AR.NavigateUrl = "/RBS/IC_Intermediate.aspx?CASE_NO=" + CASE_NO + "&CALL_RECV_DT=" + CALL_RECV_DT + "&CALL_SNO=" + CALL_SNO + "&IE_CD=" + wIECD + "&ACTIONAR=" + lstCallStatus.SelectedValue + "&ACTION=" + Request.Params["ACTION"].Trim() + "' Font-Names='Verdana' Font-Size='8pt'";
			HyperLink2AR.Visible = false;
			if (!(IsPostBack))
			{
				DataSet ds = new DataSet();
				string str = "select CALL_STATUS_CD,CALL_STATUS_DESC from T21_CALL_STATUS_CODES where CALL_STATUS_CD<>'B' order by CALL_STATUS_DESC";
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
				//				-- xx--			
				//				ListItem lst1 = new ListItem(); 
				//				lst1 = new ListItem(); 
				//				lst1.Text = "Pending"; 
				//				lst1.Value = "M"; 
				//				lstCallStatus.Items.Add(lst1);
				//				lst1 = new ListItem(); 
				//				lst1.Text = "Accepted"; 
				//				lst1.Value = "A"; 
				//				lstCallStatus.Items.Add(lst1); 
				//				lst1 = new ListItem(); 
				//				lst1.Text = "Rejection"; 
				//				lst1.Value = "R"; 
				//				lstCallStatus.Items.Add(lst1); 
				//				lst1 = new ListItem(); 
				//				lst1.Text = "Cancelled"; 
				//				lst1.Value = "C"; 
				//				lstCallStatus.Items.Add(lst1); 
				//				lst1 = new ListItem(); 
				//				lst1.Text = "Under Lab Testing"; 
				//				lst1.Value = "U"; 
				//				lstCallStatus.Items.Add(lst1); 
				//				lst1 = new ListItem(); 
				//				lst1.Text = "Still Under Inspection"; 
				//				lst1.Value = "S"; 
				//				lstCallStatus.Items.Add(lst1);
				//				lst1 = new ListItem(); 
				//				lst1.Text = "Stage Inspection"; 
				//				lst1.Value = "G"; 
				//				lstCallStatus.Items.Add(lst1);
				//				lst1 = new ListItem(); 
				//				lst1.Text = "Withheld"; 
				//				lst1.Value = "W"; 
				//				lstCallStatus.Items.Add(lst1);
				//				-- xx--			
				string sql = "Select T051.VEND_NAME,(T06.CONSIGNEE_DESIG||' '||T06.CONSIGNEE_FIRM) CONSIGNEE," +
					"T18.ITEM_DESC_PO,to_char(T17.CALL_MARK_DT,'dd/mm/yyyy') CALL_MARK_DT,to_char(T17.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT,to_char(DT_INSP_DESIRE,'dd/mm/yyyy')DESIRE_DT," +
					"T09.IE_NAME,T09.IE_PHONE_NO,T13.PO_NO,to_char(T13.PO_DT,'dd/mm/yyyy')PO_DATE,T17.CASE_NO,to_char(T17.CALL_LETTER_DT,'dd/mm/yyyy') CALL_LETTER_DT," +
					"T17.CALL_LETTER_NO,T17.CALL_STATUS,to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy') CALL_STATUS_DT,T17.CALL_CANCEL_STATUS,T17.CALL_CANCEL_CHARGES,T17.BK_NO,T17.SET_NO,T17.REMARKS,T17.HOLOGRAM, T052.VEND_CONTACT_PER_1 MFG_PERS,T052.VEND_CONTACT_TEL_1 MFG_PHONE,T17.CALL_SNO," +
					"(select count(*) from T18_CALL_DETAILS A WHERE A.CASE_NO=T18.CASE_NO AND A.CALL_RECV_DT=T18.CALL_RECV_DT) COUNT " +
					"From T05_VENDOR T051,T06_CONSIGNEE T06,T17_CALL_REGISTER T17,T18_CALL_DETAILS T18,T13_PO_MASTER T13,T09_IE T09,T05_VENDOR T052 " +
					"Where  T051.VEND_CD=T13.VEND_CD and  T06.CONSIGNEE_CD(+)=T13.PURCHASER_CD and  T13.CASE_NO=T17.CASE_NO and " +
					"T09.IE_CD =T17.IE_CD  and  T18.CASE_NO=T17.CASE_NO and T18.CALL_RECV_DT=T17.CALL_RECV_DT AND T18.CALL_SNO=T17.CALL_SNO and T17.MFG_CD=T052.VEND_CD(+) and " +
					"(T17.CASE_NO='" + CASE_NO + "' and T17.CALL_RECV_DT=to_date('" + CALL_RECV_DT + "','dd/mm/yyyy') and T17.CALL_SNO='" + CALL_SNO + "') and " +
					"T18.ITEM_SRNO_PO=(Select min(B.ITEM_SRNO_PO) from T18_CALL_DETAILS B where B.CASE_NO=T18.CASE_NO AND B.CALL_RECV_DT=T18.CALL_RECV_DT AND B.CALL_SNO=T18.CALL_SNO) " +
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
						lblInpDesireDT.Text = Convert.ToString(readerB["DESIRE_DT"]);
						lblIEName1.Text = Convert.ToString(readerB["IE_NAME"]);
						//						lblIEName.Text=Convert.ToString(readerB["IE_NAME"]);
						lblIECON.Text = Convert.ToString(readerB["IE_PHONE_NO"]);
						lblPONO.Text = Convert.ToString(readerB["PO_NO"]);
						lblPODT.Text = Convert.ToString(readerB["PO_DATE"]);
						lblCSNO.Text = Convert.ToString(readerB["CASE_NO"]);
						lblCONPER.Text = Convert.ToString(readerB["MFG_PERS"]);
						lblCONPERTEL.Text = Convert.ToString(readerB["MFG_PHONE"]);
						lblSNO.Text = Convert.ToString(readerB["CALL_SNO"]);
						lstCallStatus.SelectedValue = Convert.ToString(readerB["CALL_STATUS"]);
						lblCallStatus.Text = Convert.ToString(readerB["CALL_STATUS"]);

						if (lstCallStatus.SelectedValue == "M" || lstCallStatus.SelectedValue == "U" || lstCallStatus.SelectedValue == "S")
						{
							txtRemarks.Text = "";
							lblRemarks.Text = Convert.ToString(readerB["REMARKS"]);
						}
						else
						{
							txtRemarks.Text = Convert.ToString(readerB["REMARKS"]);
							txtHologram.Text = Convert.ToString(readerB["HOLOGRAM"]);
						}
						if (Convert.ToString(readerB["CALL_STATUS"]) == "C")
						{
							lstCallCancelStatus.SelectedValue = Convert.ToString(readerB["CALL_CANCEL_STATUS"]);
							txtCanCharges.Text = Convert.ToString(readerB["CALL_CANCEL_CHARGES"]);
							Panel_1.Visible = true;
							HyperLink1.Visible = false;
							Label3.Visible = false;
							txtRemarks.Visible = false;
							Label32.Visible = false;
							Label4.Visible = false;
							Label5.Visible = false;
							txtHologram.Visible = false;
							Label6.Visible = false;
							Label9.Visible = false;
							Label15.Visible = false;
							File14.Visible = false;
							File1.Visible = false;
							File2.Visible = false;
							File3.Visible = false;
							Label7.Visible = false;
							Label10.Visible = false;
							btnSaveCancellation.Enabled = false;
							Label11.Visible = true;
							txtCanCharges.Visible = true;
							lstCallStatus.Enabled = false;

						}

						#region HML

						if (lstCallStatus.SelectedValue == "S")
						{
							HprInspecttestPlan.Visible = true;
						}
						#endregion
						//						else if(Convert.ToString(readerB["CALL_STATUS"])=="A" || Convert.ToString(readerB["CALL_STATUS"])=="R") {
						//							HyperLink2AR.Visible=true;
						//							lstCallStatus.SelectedValue=Convert.ToString(readerB["CALL_STATUS"]);
						//							//lstCallStatus.Enabled=false;
						//							btnSave.Enabled =false;
						//							btnSaveCancellation.Enabled=false;
						//						
						//							txtSTDT.Enabled=false;
						//							txtBKNO.Enabled=false;
						//							txtSetNo.Enabled=false;
						//							btnSave.Enabled=false;
						//							Panel_1.Visible=false;
						//							HyperLink1.Visible=false;
						//							Label3.Visible=false;
						//							txtHologram.Enabled=false;
						//							Label9.Visible=false;
						//							File1.Visible=false;
						//							File2.Visible=false;
						//							File3.Visible=false;
						//							Label7.Visible=false;
						//							Label10.Visible=false;
						//							txtRemarks.Visible=false;
						//							Label32.Visible=false;
						//							Label4.Visible=false;
						//							if(Convert.ToString(readerB["CALL_STATUS"])=="R")
						//							{
						//								txtRemarks.Visible=false;
						//								Label32.Visible=false;
						//								txtRemarks.Enabled=false;
						//								
						//							}
						//							btnViewIC.Visible=true;
						//						}
						else if (Convert.ToString(readerB["CALL_STATUS"]) == "A" || Convert.ToString(readerB["CALL_STATUS"]) == "R" || Convert.ToString(readerB["CALL_STATUS"]) == "B" || Convert.ToString(readerB["CALL_STATUS"]) == "T" || Convert.ToString(readerB["CALL_STATUS"]) == "G")
						{
							//
							HyperLink2AR.Visible = true;
							lstCallStatus.SelectedValue = Convert.ToString(readerB["CALL_STATUS"]);
							lstCallStatus.Enabled = false;
							btnSave.Enabled = false;
							btnSaveCancellation.Enabled = false;
							//lstCallStatus.Enabled=true;
							//
							//lstCallStatus.Enabled=false;
							txtSTDT.Enabled = false;
							txtBKNO.Enabled = false;
							txtSetNo.Enabled = false;
							btnSave.Enabled = false;
							Panel_1.Visible = false;
							HyperLink1.Visible = false;
							Label3.Visible = false;
							txtHologram.Enabled = false;
							Label9.Visible = false;
							File1.Visible = false;
							File2.Visible = false;
							File3.Visible = false;
							Label15.Visible = false;
							File14.Visible = false;
							Label7.Visible = false;
							Label10.Visible = false;
							txtRemarks.Visible = false;
							Label32.Visible = false;
							Label4.Visible = false;
							Label11.Visible = false;
							Label12.Visible = false;
							txtMatValue.Visible = false;
							txtCanCharges.Visible = false;
							lstCallCancelCharges.Visible = false;

							if (Convert.ToString(readerB["CALL_STATUS"]) == "R")
							{
								//								txtRemarks.Visible=true;
								//								Label32.Visible=true;
								txtRemarks.Visible = false;
								Label32.Visible = false;
								txtRemarks.Enabled = false;

							}
							//btnViewIC.Visible=true;


						}
						else
						{
							Panel_1.Visible = false;
							txtRemarks.Visible = false;
							Label32.Visible = false;
							Label4.Visible = false;
							Label4.Visible = false;
							Label5.Visible = false;
							txtHologram.Visible = false;
							Label6.Visible = false;
							Label9.Visible = false;
							File1.Visible = false;
							File2.Visible = false;
							File3.Visible = false;
							Label15.Visible = false;
							File14.Visible = false;
							Label7.Visible = false;
							Label10.Visible = false;
							Label11.Visible = false;
							Label12.Visible = false;
							txtMatValue.Visible = false;
							txtCanCharges.Visible = false;
							lstCallCancelCharges.Visible = false;

						}
						lblCLettDT.Text = Convert.ToString(readerB["CALL_LETTER_DT"]);
						lblCLettNo.Text = Convert.ToString(readerB["CALL_LETTER_NO"]);
						txtSTDT.Text = Convert.ToString(readerB["CALL_STATUS_DT"]);
						txtBKNO.Text = Convert.ToString(readerB["BK_NO"]);
						txtSetNo.Text = Convert.ToString(readerB["SET_NO"]);

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
					OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual", conn);
					txtSTDT.Text = Convert.ToString(cmd2.ExecuteScalar());
					conn.Close();
					if (lstCallStatus.SelectedValue == "C")
					{
						Panel_1.Visible = true;
						show();
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
					conn.Dispose();
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

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Calls_Marked_To_IE.aspx?ACTION=" + Request.Params["ACTION"].ToString());
		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		int[] reasons()
		{
			int[] chk = new int[11];
			int j = 0;
			//			CheckBox chk= new CheckBox();
			//			chk=(CheckBox)dgCategory.Items[i].FindControl("chkID");
			//			if(chk.Checked)
			//			{
			//				s=s+dgCategory.Items[i].Cells[2].Text+",";
			//			}
			for (int i = 0; i < 1; i++)
			{
				if (chk1.Checked == true)
				{
					chk[j] = Convert.ToInt32(chk1.Text.Substring(0, 2));
					j++;
				}
				if (chk2.Checked == true)
				{
					chk[j] = Convert.ToInt32(chk2.Text.Substring(0, 2));
					j++;
				}
				if (chk3.Checked == true)
				{
					chk[j] = Convert.ToInt32(chk3.Text.Substring(0, 2));
					j++;
				}
				if (chk4.Checked == true)
				{
					chk[j] = Convert.ToInt32(chk4.Text.Substring(0, 2));
					j++;
				}
				if (chk5.Checked == true)
				{
					chk[j] = Convert.ToInt32(chk5.Text.Substring(0, 2));
					j++;
				}
				if (chk6.Checked == true)
				{
					chk[j] = Convert.ToInt32(chk6.Text.Substring(0, 2));
					j++;
				}
				if (chk7.Checked == true)
				{
					chk[j] = Convert.ToInt32(chk7.Text.Substring(0, 2));
					j++;
				}
				if (chk8.Checked == true)
				{
					chk[j] = Convert.ToInt32(chk8.Text.Substring(0, 2));
					j++;
				}
				if (chk9.Checked == true)
				{
					chk[j] = Convert.ToInt32(chk9.Text.Substring(0, 2));
					j++;
				}
				if (chk10.Checked == true)
				{
					chk[j] = Convert.ToInt32(chk10.Text.Substring(0, 2));
					j++;
				}
				if (chk11.Checked == true)
				{
					chk[j] = Convert.ToInt32(chk11.Text.Substring(0, 2));
					j++;
				}
				if (chk12.Checked == true)
				{
					chk[j] = Convert.ToInt32(chk12.Text.Substring(0, 2));
					j++;
				}

			}
			return (chk);
		}
		string get_cancel_reasons()
		{
			string reason = "";
			if (chk1.Checked == true)
			{
				reason = reason + "=> " + chk1.Text.Substring(5, chk1.Text.Length - 5) + "<br>";
			}
			if (chk2.Checked == true)
			{
				reason = reason + "=> " + chk2.Text.Substring(5, chk2.Text.Length - 5) + "<br>";
			}
			if (chk3.Checked == true)
			{
				reason = reason + "=> " + chk3.Text.Substring(5, chk3.Text.Length - 5) + "<br>";
			}
			if (chk4.Checked == true)
			{
				reason = reason + "=> " + chk4.Text.Substring(5, chk4.Text.Length - 5) + "<br>";
			}
			if (chk5.Checked == true)
			{
				reason = reason + "=> " + chk5.Text.Substring(5, chk5.Text.Length - 5) + "<br>";
			}
			if (chk6.Checked == true)
			{
				reason = reason + "=> " + chk6.Text.Substring(5, chk6.Text.Length - 5) + "<br>";
			}
			if (chk7.Checked == true)
			{
				reason = reason + "=> " + chk7.Text.Substring(5, chk7.Text.Length - 5) + "<br>";
			}
			if (chk8.Checked == true)
			{
				reason = reason + "=> " + chk8.Text.Substring(5, chk8.Text.Length - 5) + "<br>";
			}
			if (chk9.Checked == true)
			{
				reason = reason + "=> " + chk9.Text.Substring(5, chk9.Text.Length - 5) + "<br>";
			}
			if (chk10.Checked == true)
			{
				reason = reason + "=> " + chk10.Text.Substring(5, chk10.Text.Length - 5) + "<br>";
			}
			if (chk11.Checked == true)
			{
				reason = reason + "=> " + chk11.Text.Substring(5, chk11.Text.Length - 5) + "<br>";
			}
			if (chk12.Checked == true)
			{
				reason = reason + "=> " + chk12.Text + "(" + txtCdesc.Text.Trim() + ")" + "<br>";
			}
			return (reason);
		}
		void show()
		{
			try
			{
				DataSet dsP1 = new DataSet();
				string str2 = "select T19.CANCEL_CD_1,T19.CANCEL_CD_2,T19.CANCEL_CD_3,T19.CANCEL_CD_4,T19.CANCEL_CD_5,T19.CANCEL_CD_6,T19.CANCEL_CD_7,T19.CANCEL_CD_8,T19.CANCEL_CD_9,T19.CANCEL_CD_10,T19.CANCEL_CD_11,T19.CANCEL_DESC,to_char(T19.CANCEL_DATE,'dd/mm/yyyy')CANCEL_DATE, NVL(T17.CALL_CANCEL_STATUS,'') CALL_CANCEL_STATUS from T19_CALL_CANCEL T19,T17_CALL_REGISTER T17 where T19.CASE_NO=T17.CASE_NO and T19.CALL_SNO=T17.CALL_SNO and T19.CALL_RECV_DT=T17.CALL_RECV_DT and T19.CASE_NO= '" + lblCSNO.Text + "' and T19.CALL_RECV_DT=to_date('" + lblCallDT.Text + "','dd/mm/yyyy') AND T19.CALL_SNO=" + lblSNO.Text;
				conn.Open();
				OracleDataAdapter da1 = new OracleDataAdapter(str2, conn);
				OracleCommand myOracleCommand1 = new OracleCommand(str2, conn);
				da1.SelectCommand = myOracleCommand1;
				da1.Fill(dsP1, "Table");
				conn.Close();
				if (dsP1.Tables[0].Rows.Count == 0)
				{
					DisplayAlert("No Record Found For the Given CASE_NO, CALL_RECV_DT and CALL_SNO");

				}
				else
				{
					txtCdesc.Text = dsP1.Tables[0].Rows[0]["CANCEL_DESC"].ToString();
					int[] a = new int[11];
					int j = 0;
					for (int i = 1; i <= 11; i++)
					{
						if (dsP1.Tables[0].Rows[0]["CANCEL_CD_" + i].ToString() != "0")
						{
							a[j] = Convert.ToInt32(dsP1.Tables[0].Rows[0]["CANCEL_CD_" + i].ToString());
							j++;
						}
					}
					chkcheckbox(a);

				}
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
				conn.Dispose();
			}
		}

		void chkcheckbox(int[] a)
		{
			for (int i = 0; i <= 10; i++)
			{
				if (a[i] == 1)
				{
					chk1.Checked = true;
				}
				if (a[i] == 2)
				{
					chk2.Checked = true;
				}
				if (a[i] == 3)
				{
					chk3.Checked = true;
				}
				if (a[i] == 4)
				{
					chk4.Checked = true;
				}
				if (a[i] == 5)
				{
					chk5.Checked = true;
				}
				if (a[i] == 6)
				{
					chk6.Checked = true;
				}
				if (a[i] == 7)
				{
					chk7.Checked = true;
				}
				if (a[i] == 8)
				{
					chk8.Checked = true;
				}
				if (a[i] == 9)
				{
					chk9.Checked = true;
				}
				if (a[i] == 10)
				{
					chk10.Checked = true;
				}
				if (a[i] == 11)
				{
					chk11.Checked = true;
				}
				if (a[i] == 12)
				{
					chk12.Checked = true;
				}
			}

		}


		void photo_upload(string BK_NO, string SET_NO)
		{

			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			OracleCommand cmd = new OracleCommand("select to_char(sysdate,'dd/mm/yyyy') from dual", conn);
			conn.Open();
			string ss = Convert.ToString(cmd.ExecuteScalar());
			conn.Close();
			conn.Open();
			OracleTransaction myTrans = conn.BeginTransaction();

			try
			{
				//				string MySql="";

				//				string MySql="UPDATE T49_IC_PHOTO_ENCLOSED SET IC_PHOTO='"+File1.Value+"' "+		
				//					"where "+
				//					"CASE_NO='"+txtCaseNo.Text.Trim()+"' and BK_NO='"+BK_NO+"' AND SET_NO='"+SET_NO+"'";

				//				OracleCommand cmd1 = new OracleCommand(MySql,conn);
				//				cmd1.Transaction=myTrans;
				//				cmd1.ExecuteNonQuery();
				string myUpdateQuery = "Update T49_IC_PHOTO_ENCLOSED set ";
				if (File1.PostedFile != null && File1.PostedFile.ContentLength > 0)
				{
					string fn = "", fx = "", MyFile = "";
					MyFile = lblCSNO.Text.Trim() + "-" + BK_NO + "-" + SET_NO;
					fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
					fx = System.IO.Path.GetExtension(File1.PostedFile.FileName).ToUpper().Substring(1);
					String SaveLocation = null;
					SaveLocation = Server.MapPath("BILL_IC/" + MyFile + "." + fx);
					File1.PostedFile.SaveAs(SaveLocation);
					myUpdateQuery = myUpdateQuery + " IC_PHOTO='" + MyFile + "." + fx + "' ";
				}

				if (File2.PostedFile != null && File2.PostedFile.ContentLength > 0)
				{
					string fn = "", fx = "", MyFile = "";
					MyFile = lblCSNO.Text.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "A1";
					fn = System.IO.Path.GetFileName(File2.PostedFile.FileName);
					fx = System.IO.Path.GetExtension(File2.PostedFile.FileName).ToUpper().Substring(1);
					String SaveLocation = null;
					SaveLocation = Server.MapPath("BILL_IC/" + MyFile + "." + fx);
					File2.PostedFile.SaveAs(SaveLocation);
					myUpdateQuery = myUpdateQuery + " , IC_PHOTO_A1='" + MyFile + "." + fx + "' ";
				}

				if (File3.PostedFile != null && File3.PostedFile.ContentLength > 0)
				{
					string fn = "", fx = "", MyFile = "";
					MyFile = lblCSNO.Text.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "A2";
					fn = System.IO.Path.GetFileName(File3.PostedFile.FileName);
					fx = System.IO.Path.GetExtension(File3.PostedFile.FileName).ToUpper().Substring(1);
					String SaveLocation = null;
					SaveLocation = Server.MapPath("BILL_IC/" + MyFile + "." + fx);
					File2.PostedFile.SaveAs(SaveLocation);
					myUpdateQuery = myUpdateQuery + " , IC_PHOTO_A2='" + MyFile + "." + fx + "' ";
				}

				myUpdateQuery = myUpdateQuery + " where CASE_NO='" + lblCSNO.Text.Trim() + "' AND BK_NO='" + BK_NO + "' AND SET_NO='" + SET_NO + "'";
				OracleCommand myInsertCommand1 = new OracleCommand(myUpdateQuery);
				myInsertCommand1.Transaction = myTrans;
				myInsertCommand1.Connection = conn;
				myInsertCommand1.ExecuteNonQuery();
				myTrans.Commit();
				conn.Close();


			}
			catch (FileNotFoundException fe)
			{ Response.Write("File not found" + fe); }
			catch (System.IO.DirectoryNotFoundException de)
			{ Response.Write("Directry not found" + de); }
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
				myTrans.Rollback();
				DisplayAlert("Upload is not Successfull, Plz Try Again!!!");
			}
			finally
			{
				conn.Close();
				conn.Dispose();

			}


		}

		void stage_ic_upload(string BK_NO, string SET_NO)
		{

			conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			OracleCommand cmd = new OracleCommand("select to_char(sysdate,'dd/mm/yyyy') from dual", conn);
			conn.Open();
			string ss = Convert.ToString(cmd.ExecuteScalar());
			conn.Close();
			conn.Open();
			OracleTransaction myTrans = conn.BeginTransaction();

			try
			{

				if (File1.PostedFile != null && File1.PostedFile.ContentLength > 0)
				{
					string fn = "", fx = "", MyFile = "";
					MyFile = lblCSNO.Text.Trim() + "-" + BK_NO + "-" + SET_NO;
					fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
					fx = System.IO.Path.GetExtension(File1.PostedFile.FileName).ToUpper().Substring(1);
					String SaveLocation = null;
					SaveLocation = Server.MapPath("BILL_IC/" + MyFile + "." + fx);
					File1.PostedFile.SaveAs(SaveLocation);

				}

				if (File2.PostedFile != null && File2.PostedFile.ContentLength > 0)
				{
					string fn = "", fx = "", MyFile = "";
					MyFile = lblCSNO.Text.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "A1";
					fn = System.IO.Path.GetFileName(File2.PostedFile.FileName);
					fx = System.IO.Path.GetExtension(File2.PostedFile.FileName).ToUpper().Substring(1);
					String SaveLocation = null;
					SaveLocation = Server.MapPath("BILL_IC/" + MyFile + "." + fx);
					File2.PostedFile.SaveAs(SaveLocation);

				}

				if (File3.PostedFile != null && File3.PostedFile.ContentLength > 0)
				{
					string fn = "", fx = "", MyFile = "";
					MyFile = lblCSNO.Text.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "A2";
					fn = System.IO.Path.GetFileName(File3.PostedFile.FileName);
					fx = System.IO.Path.GetExtension(File3.PostedFile.FileName).ToUpper().Substring(1);
					String SaveLocation = null;
					SaveLocation = Server.MapPath("BILL_IC/" + MyFile + "." + fx);
					File2.PostedFile.SaveAs(SaveLocation);

				}

				if (File14.PostedFile != null && File14.PostedFile.ContentLength > 0)
				{
					string fn = "", fx = "", MyFile = "";
					MyFile = lblCSNO.Text.Trim() + "-" + BK_NO + "-" + SET_NO;
					fn = System.IO.Path.GetFileName(File14.PostedFile.FileName);
					fx = System.IO.Path.GetExtension(File14.PostedFile.FileName).ToUpper().Substring(1);
					if (fx != "" && fx != "PDF")
					{
						throw new System.Exception("KINDLY UPLOAD DIGITALLY SIGNED PDF FILES ONLY");
					}
					String SaveLocation = null;
					SaveLocation = Server.MapPath("TESTPLAN/" + MyFile + "." + fx);
					File14.PostedFile.SaveAs(SaveLocation);

				}
				conn.Close();


			}
			catch (FileNotFoundException fe)
			{ Response.Write("File not found" + fe); }
			catch (System.IO.DirectoryNotFoundException de)
			{ Response.Write("Directry not found" + de); }
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
				myTrans.Rollback();
				DisplayAlert("Upload is not Successfull, Plz Try Again!!!");
			}
			finally
			{
				conn.Close();
				conn.Dispose();

			}


		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			string wFifoVoilateReason = "";
			//			if(txtFIFO.Visible==true && txtFIFO.Text.Trim()=="")
			//			{
			//				DisplayAlert("Kindly Enter the Reason For Voilating FIFO!!! ");
			//			}
			//			else
			//			{
			try
			{
				wFifoVoilateReason = txtFIFO.Text.Trim();
				string w_call_cancel_status = "";

				conn.Open();
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn);
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				conn.Close();

				if (lblCallStatus.Text == "C" && lstCallStatus.SelectedValue != "C")
				{
					string DQuery = "Delete T19_CALL_CANCEL where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + "";
					OracleCommand myDCommand = new OracleCommand(DQuery, conn);
					conn.Open();
					myDCommand.ExecuteNonQuery();
					conn.Close();
					w_call_cancel_status = "";

				}
				else if (lstCallStatus.SelectedValue == "C" && lstCallCancelStatus.SelectedValue == "C")
				{
					w_call_cancel_status = "C";

				}
				else if (lstCallStatus.SelectedValue == "C" && lstCallCancelStatus.SelectedValue == "N")
				{
					w_call_cancel_status = "N";

				}
				else
				{
					w_call_cancel_status = "";

				}

				if (lstCallStatus.SelectedValue == "A" || lstCallStatus.SelectedValue == "R")
				{
					string bscheck = "";
					//					w_call_cancel_status="";
					if (txtBKNO.Text.Trim() != "" && txtSetNo.Text.Trim() != "")
					{
						conn.Open();
						OracleCommand cmd = new OracleCommand("Select ISSUE_TO_IECD from T10_IC_BOOKSET where TRIM(BK_NO)=upper('" + txtBKNO.Text + "') and " + Convert.ToInt32(txtSetNo.Text) + " between (SET_NO_FR) and (SET_NO_TO) and ISSUE_TO_IECD=" + wIECD, conn);
						bscheck = Convert.ToString(cmd.ExecuteScalar());
						conn.Close();
					}
					if (txtBKNO.Text.Trim() != "" && txtSetNo.Text.Trim() != "" && bscheck != "" && txtHologram.Text.Trim() != "" && File1.Value != "")
					{
						string str = "select NVL(count(*),0) from T49_IC_PHOTO_ENCLOSED where CASE_NO='" + lblCSNO.Text.Trim() + "' and BK_NO='" + txtBKNO.Text + "' and SET_NO='" + txtSetNo.Text + "'";
						OracleCommand cmd1 = new OracleCommand(str, conn);
						conn.Open();
						int count = Convert.ToInt16(cmd1.ExecuteScalar());
						conn.Close();
						if (count > 0)
						{
							string updateQuery = "";
							conn.Open();
							OracleTransaction myTrans = conn.BeginTransaction();
							if (lstCallStatus.SelectedValue == "A")
							{
								updateQuery = "Update T17_CALL_REGISTER set CALL_STATUS='" + lstCallStatus.SelectedValue + "',CALL_STATUS_DT=to_date('" + txtSTDT.Text + "','dd/mm/yyyy'),CALL_CANCEL_STATUS=null,BK_NO='" + txtBKNO.Text + "',SET_NO='" + txtSetNo.Text + "',USER_ID='" + Session["IE_EMP_NO"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'), HOLOGRAM='" + txtHologram.Text.Trim() + "', FIFO_VOILATE_REASON='" + wFifoVoilateReason + "' where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + "";
							}
							else if (lstCallStatus.SelectedValue == "R")
							{
								if (lblRemarks.Text.Trim() != "")
								{
									updateQuery = "Update T17_CALL_REGISTER set CALL_STATUS='" + lstCallStatus.SelectedValue + "',CALL_STATUS_DT=to_date('" + txtSTDT.Text + "','dd/mm/yyyy'),CALL_CANCEL_STATUS=null,BK_NO='" + txtBKNO.Text + "',SET_NO='" + txtSetNo.Text + "',REMARKS='" + lblRemarks.Text.Trim() + "'||', '||'" + txtRemarks.Text.Trim() + "',USER_ID='" + Session["IE_EMP_NO"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'), HOLOGRAM='" + txtHologram.Text.Trim() + "', FIFO_VOILATE_REASON='" + wFifoVoilateReason + "' where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + "";
								}
								else
								{
									updateQuery = "Update T17_CALL_REGISTER set CALL_STATUS='" + lstCallStatus.SelectedValue + "',CALL_STATUS_DT=to_date('" + txtSTDT.Text + "','dd/mm/yyyy'),CALL_CANCEL_STATUS=null,BK_NO='" + txtBKNO.Text + "',SET_NO='" + txtSetNo.Text + "',REMARKS='" + txtRemarks.Text.Trim() + "',USER_ID='" + Session["IE_EMP_NO"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'), HOLOGRAM='" + txtHologram.Text.Trim() + "', FIFO_VOILATE_REASON='" + wFifoVoilateReason + "' where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + "";
								}
							}
							OracleCommand myUpdateCommand = new OracleCommand(updateQuery);
							myUpdateCommand.Transaction = myTrans;
							myUpdateCommand.Connection = conn;
							myUpdateCommand.ExecuteNonQuery();

							if (lstCallStatus.SelectedValue == "R")
							{
								string updateQuery1 = "Update T13_PO_MASTER set PENDING_CHARGES=NVL(PENDING_CHARGES,0)+1 where CASE_NO='" + lblCSNO.Text.Trim() + "'";
								OracleCommand myUpdateCommand1 = new OracleCommand(updateQuery1, conn);
								myUpdateCommand1.Transaction = myTrans;
								myUpdateCommand1.Connection = conn;
								myUpdateCommand1.ExecuteNonQuery();
							}
							myTrans.Commit();
							conn.Close();
							photo_upload(txtBKNO.Text.Trim(), txtSetNo.Text.Trim());
							DisplayAlert("Your Record is Saved!!!");
						}
						else
						{
							DisplayAlert("Photos against given Case No, Book No & Set No are not uploaded, So Upload Photos before changing the Call Status to [Aceepted OR Rejection]!!!");
						}
					}
					else if (txtBKNO.Text.Trim() != "" && txtSetNo.Text.Trim() != "" && bscheck == "")
					{
						DisplayAlert("Book No. and Set No. specified is not issued to You!!!");
					}
					else if (txtBKNO.Text.Trim() == "" || txtSetNo.Text.Trim() == "" || txtHologram.Text == "" || File1.Value == "")
					{

						DisplayAlert("Book No. , Set No., Holograms OR IC Photo cannot be left blank!!!");
						//						string updateQuery="Update T17_CALL_REGISTER set CALL_STATUS='"+lstCallStatus.SelectedValue+"',CALL_STATUS_DT=to_date('"+txtSTDT.Text+"','dd/mm/yyyy'),CALL_CANCEL_STATUS=null,BK_NO='"+txtBKNO.Text+"',SET_NO='"+txtSetNo.Text+"',USER_ID='"+Session["IE_EMP_NO"].ToString()+"',DATETIME=to_date('"+ss+"','dd/mm/yyyy-HH24:MI:SS') where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO="+lblSNO.Text+"";
						//						OracleCommand myUpdateCommand=new OracleCommand(updateQuery,conn);
						//						conn.Open();
						//						myUpdateCommand.ExecuteNonQuery();
						//						conn.Close(); 
					}
				}
				else if (lstCallStatus.SelectedValue == "G" || lstCallStatus.SelectedValue == "T")
				{
					string bscheck = "";
					if (txtBKNO.Text.Trim() != "" && txtSetNo.Text.Trim() != "")
					{
						conn.Open();
						OracleCommand cmd = new OracleCommand("Select ISSUE_TO_IECD from T10_IC_BOOKSET where TRIM(BK_NO)=upper('" + txtBKNO.Text + "') and " + Convert.ToInt32(txtSetNo.Text) + " between (SET_NO_FR) and (SET_NO_TO) and ISSUE_TO_IECD=" + wIECD, conn);
						bscheck = Convert.ToString(cmd.ExecuteScalar());
						conn.Close();
					}
					if (txtBKNO.Text.Trim() != "" && txtSetNo.Text.Trim() != "" && bscheck != "" && File1.Value != "")
					{

						string updateQuery = "";
						conn.Open();
						OracleTransaction myTrans = conn.BeginTransaction();
						updateQuery = "Update T17_CALL_REGISTER set CALL_STATUS='" + lstCallStatus.SelectedValue + "',CALL_STATUS_DT=to_date('" + txtSTDT.Text + "','dd/mm/yyyy'),CALL_CANCEL_STATUS=null,BK_NO='" + txtBKNO.Text + "',SET_NO='" + txtSetNo.Text + "',USER_ID='" + Session["IE_EMP_NO"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'), FIFO_VOILATE_REASON='" + wFifoVoilateReason + "' where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + "";
						OracleCommand myUpdateCommand = new OracleCommand(updateQuery);
						myUpdateCommand.Transaction = myTrans;
						myUpdateCommand.Connection = conn;
						myUpdateCommand.ExecuteNonQuery();
						myTrans.Commit();
						conn.Close();
						stage_ic_upload(txtBKNO.Text.Trim(), txtSetNo.Text.Trim());
						DisplayAlert("Your Record is Saved!!!");
						btnSave.Enabled = false;

					}
					else if (txtBKNO.Text.Trim() != "" && txtSetNo.Text.Trim() != "" && bscheck == "")
					{
						DisplayAlert("Book No. and Set No. specified is not issued to You!!!");
					}
					else if (txtBKNO.Text.Trim() == "" || txtSetNo.Text.Trim() == "" || File1.Value == "")
					{

						DisplayAlert("Book No. , Set No. OR Stage IC Photo cannot be left blank!!!");
						//						string updateQuery="Update T17_CALL_REGISTER set CALL_STATUS='"+lstCallStatus.SelectedValue+"',CALL_STATUS_DT=to_date('"+txtSTDT.Text+"','dd/mm/yyyy'),CALL_CANCEL_STATUS=null,BK_NO='"+txtBKNO.Text+"',SET_NO='"+txtSetNo.Text+"',USER_ID='"+Session["IE_EMP_NO"].ToString()+"',DATETIME=to_date('"+ss+"','dd/mm/yyyy-HH24:MI:SS') where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO="+lblSNO.Text+"";
						//						OracleCommand myUpdateCommand=new OracleCommand(updateQuery,conn);
						//						conn.Open();
						//						myUpdateCommand.ExecuteNonQuery();
						//						conn.Close(); 
					}
				}
				else
				{
					string updateQuery = "Update T17_CALL_REGISTER set CALL_STATUS='" + lstCallStatus.SelectedValue + "',CALL_STATUS_DT=to_date('" + txtSTDT.Text + "','dd/mm/yyyy'),CALL_CANCEL_STATUS='" + w_call_cancel_status + "',USER_ID='" + Session["IE_EMP_NO"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'), FIFO_VOILATE_REASON='" + wFifoVoilateReason + "' where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + "";
					OracleCommand myUpdateCommand = new OracleCommand(updateQuery, conn);
					conn.Open();
					myUpdateCommand.ExecuteNonQuery();
					conn.Close();
					DisplayAlert("Your Record is Saved!!!");
				}

				if (lstCallStatus.SelectedValue == "C")
				{
					Panel_1.Visible = true;
					Call_Cancellation_Entry();

				}
				//				else if(lstCallStatus.SelectedValue=="A" || lstCallStatus.SelectedValue=="R")
				//				{
				//					HyperLink1.Visible=true;
				//				}
				else
				{
					Panel_1.Visible = false;
				}

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
				conn.Dispose();
			}

			//			}
		}
		void Call_Cancellation_Entry()
		{
			if (lstCallCancelStatus.SelectedValue == "" || (lstCallCancelStatus.SelectedValue == "C" && lstCallCancelCharges.SelectedValue == ""))
			{
				DisplayAlert("Mention Call Chargeable/Call Non-Chargeable & Select One of the Given Call Cancellation Charges in Case the Call is Chargeable!!!");
			}
			else
			{
				conn.Open();
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn);
				string wCDT = Convert.ToString(cmd2.ExecuteScalar());
				conn.Close();

				try
				{
					string wFifoVoilateReason = "";
					if (txtFIFO.Visible == true)
					{
						wFifoVoilateReason = txtFIFO.Text.Trim();
					}
					conn.Open();
					OracleCommand myCommand = new OracleCommand("select CASE_NO from T20_IC where CASE_NO= '" + lblCSNO.Text + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text + "','dd/mm/yyyy') AND CALL_SNO=" + lblSNO.Text, conn);
					string CCd = Convert.ToString(myCommand.ExecuteScalar());
					conn.Close();

					conn.Open();
					OracleCommand myCommand11 = new OracleCommand("select CASE_NO from T19_CALL_CANCEL where CASE_NO= '" + lblCSNO.Text + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text + "','dd/mm/yyyy') AND CALL_SNO=" + lblSNO.Text, conn);
					string Action = Convert.ToString(myCommand11.ExecuteScalar());
					conn.Close();

					conn.Open();
					OracleCommand myCommand12 = new OracleCommand("select IE_EMP_NO from T09_IE where IE_CD= '" + Request.Params["IE_CD"].ToString() + "'", conn);
					string w_IE_EMPNO = Convert.ToString(myCommand12.ExecuteScalar());
					conn.Close();

					if (CCd == "")
					{
						int[] chk1 = reasons();
						conn.Open();
					OracleTransaction myTrans = conn.BeginTransaction();
						if (Action == "")
						{
							string myInsertQuery = "INSERT INTO T19_CALL_CANCEL values('" + lblCSNO.Text + "', to_date('" + lblCallDT.Text + "','dd/mm/yyyy'), " + lblSNO.Text + "," + chk1[0] + "," + chk1[1] + "," + chk1[2] + "," + chk1[3] + "," + chk1[4] + "," + chk1[5] + "," + chk1[6] + "," + chk1[7] + "," + chk1[8] + "," + chk1[9] + "," + chk1[10] + ", '" + txtCdesc.Text + "',to_date('" + txtSTDT.Text + "','dd/mm/yyyy'),'" + w_IE_EMPNO + "',to_date('" + wCDT + "','dd/mm/yyyy-HH24:MI:SS'),'')";
							OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
							myInsertCommand.Transaction = myTrans;
							myInsertCommand.Connection = conn;
							myInsertCommand.ExecuteNonQuery();

							string updateCallStatusQuery = "";
							if (lstCallCancelStatus.SelectedValue == "C")
							{

								updateCallStatusQuery = "Update T17_CALL_REGISTER set CALL_STATUS='C',CALL_STATUS_DT=to_date('" + txtSTDT.Text + "','dd/mm/yyyy'),CALL_CANCEL_STATUS='" + lstCallCancelStatus.SelectedValue + "',CALL_CANCEL_CHARGES=" + Convert.ToInt16(txtCanCharges.Text) + ", FIFO_VOILATE_REASON='" + wFifoVoilateReason + "' where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + "";
							}
							else
							{
								updateCallStatusQuery = "Update T17_CALL_REGISTER set CALL_STATUS='C',CALL_STATUS_DT=to_date('" + txtSTDT.Text + "','dd/mm/yyyy'),CALL_CANCEL_STATUS='" + lstCallCancelStatus.SelectedValue + "', FIFO_VOILATE_REASON='" + wFifoVoilateReason + "' where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + "";
							}
							OracleCommand myUpdateCallStatusCommand = new OracleCommand(updateCallStatusQuery, conn);
							myUpdateCallStatusCommand.Transaction = myTrans;
							myUpdateCallStatusCommand.Connection = conn;
							myUpdateCallStatusCommand.ExecuteNonQuery();

							string updateCallStatusQuery1 = "";
							if (lstCallCancelStatus.SelectedValue == "C")
							{

								updateCallStatusQuery1 = "Update T13_PO_MASTER set PENDING_CHARGES=NVL(PENDING_CHARGES,0)+1 where CASE_NO='" + lblCSNO.Text.Trim() + "'";
								OracleCommand myUpdateCallStatusCommand1 = new OracleCommand(updateCallStatusQuery1, conn);
								myUpdateCallStatusCommand1.Transaction = myTrans;
								myUpdateCallStatusCommand1.Connection = conn;
								myUpdateCallStatusCommand1.ExecuteNonQuery();
							}

							myTrans.Commit();
							conn.Close();
							DisplayAlert("Your Record is Saved!!!");

						}
						else if (Action != "")
						{
							string myUpdateQuery = "Update T19_CALL_CANCEL set CANCEL_DATE=to_date('" + txtSTDT.Text + "','dd/mm/yyyy'),CANCEL_CD_1=" + chk1[0] + ",CANCEL_CD_2=" + chk1[1] + ",CANCEL_CD_3=" + chk1[2] + ",CANCEL_CD_4=" + chk1[3] + ",CANCEL_CD_5=" + chk1[4] + ",CANCEL_CD_6=" + chk1[5] + ",CANCEL_CD_7=" + chk1[6] + ",CANCEL_CD_8=" + chk1[7] + ",CANCEL_CD_9=" + chk1[8] + ",CANCEL_CD_10=" + chk1[9] + ",CANCEL_CD_11=" + chk1[10] + ",CANCEL_DESC ='" + txtCdesc.Text + "',USER_ID='" + w_IE_EMPNO + "',DATETIME=to_date('" + wCDT + "','dd/mm/yyyy-HH24:MI:SS') where CASE_NO='" + lblCSNO.Text + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text;
							OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
							myUpdateCommand.Transaction = myTrans;
							myUpdateCommand.Connection = conn;
							myUpdateCommand.ExecuteNonQuery();
							string updateCallStatusQuery = "";
							if (lstCallCancelStatus.SelectedValue == "C")
							{
								updateCallStatusQuery = "Update T17_CALL_REGISTER set CALL_STATUS='C',CALL_STATUS_DT=to_date('" + txtSTDT.Text + "','dd/mm/yyyy'),CALL_CANCEL_STATUS='" + lstCallCancelStatus.SelectedValue + "',CALL_CANCEL_CHARGES=" + Convert.ToInt16(lstCallCancelCharges.SelectedValue) + ", FIFO_VOILATE_REASON='" + wFifoVoilateReason + "' where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + "";
							}
							else
							{
								updateCallStatusQuery = "Update T17_CALL_REGISTER set CALL_STATUS='C',CALL_STATUS_DT=to_date('" + txtSTDT.Text + "','dd/mm/yyyy'),CALL_CANCEL_STATUS='" + lstCallCancelStatus.SelectedValue + "', FIFO_VOILATE_REASON='" + wFifoVoilateReason + "' where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + "";
							}
							OracleCommand myUpdateCallStatusCommand = new OracleCommand(updateCallStatusQuery, conn);
							myUpdateCallStatusCommand.Transaction = myTrans;
							myUpdateCallStatusCommand.Connection = conn;
							myUpdateCallStatusCommand.ExecuteNonQuery();
							myTrans.Commit();
							conn.Close();
							DisplayAlert("Your Record is Modified!!!");
						}

					}
					else
					{
						DisplayAlert("The IC is Present For give CASE_NO, CALL_RECV_DT and CALL_SNO, So it can not be cancelled!!!");
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
					conn.Close();
					//conn.Dispose();

				}
				send_Vendor_Email();
			}
		}

		string dateconcat(string dt)
		{
			string myYear, myMonth, myDay;
			myYear = dt.Substring(6, 4);
			myMonth = dt.Substring(3, 2);
			myDay = dt.Substring(0, 2);
			string dt_out = myYear + myMonth + myDay;
			return (dt_out);
		}

		protected void btnSaveCancellation_Click(object sender, System.EventArgs e)
		{
			//			Call_Cancellation_Entry();
			//			if(txtFIFO.Visible==true && txtFIFO.Text.Trim()=="")
			//			{
			//				DisplayAlert("Kindly Enter the Reason For Voilating FIFO!!!");
			//			}
			//			else
			//			{
			if (File4.PostedFile != null && File4.PostedFile.ContentLength > 0)
			{
				string call_dt = dateconcat(lblCallDT.Text);
				String fn = "", fx = "";
				fn = System.IO.Path.GetFileName(File4.PostedFile.FileName);
				fx = System.IO.Path.GetExtension(File4.PostedFile.FileName).ToUpper();
				if (fx == ".PDF")
				{
					String SaveLocation = null;
					SaveLocation = Server.MapPath("CALL_CANCELLATION_DOCUMENTS/" + lblCSNO.Text + "-" + call_dt + "-" + lblSNO.Text + ".PDF");
					File4.PostedFile.SaveAs(SaveLocation);
					//DisplayAlert("The file has been uploaded.");

					//					conn.Open();
					//					string myUpdateQuery = "Update T19_CALL_CANCEL set DOCS_SUBMITTED='Y' where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO="+lblSNO.Text+"";
					//					OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery); 
					//					myUpdateCommand.Connection = conn; 
					//					myUpdateCommand.ExecuteNonQuery(); 
					//					conn.Close(); 

					Call_Cancellation_Entry();
				}
				else
				{
					DisplayAlert("Kindly select PDF file only!!!");
				}
			}
			else
			{
				DisplayAlert("Kindly select Call Cancellation Documents file and then click on Save Button !!!");
			}
			//			}
		}
		void send_Vendor_Email()
		{
			try
			{
				string wRegion = "";
				string wPCity = "";
				string sender = "";
				OracleCommand cmd_vend = new OracleCommand("Select T13.VEND_CD,T05.VEND_NAME,NVL2(T05.VEND_ADD2,T05.VEND_ADD1||'/'||T05.VEND_ADD2,T05.VEND_ADD1) VEND_ADDRESS,T03.CITY VEND_CITY, T05.VEND_EMAIL,T13.REGION_CODE,T13.RLY_CD from T13_PO_MASTER T13,T05_VENDOR T05, T03_CITY T03 where T13.VEND_CD=T05.VEND_CD and T05.VEND_CITY_CD=T03.CITY_CD and CASE_NO='" + lblCSNO.Text.Trim() + "'", conn);
				conn.Open();
				OracleDataReader reader = cmd_vend.ExecuteReader();
				string vend_cd = "", vend_name = "", vend_email = "", rly_cd = "", vend_city = "";
				while (reader.Read())
				{
					vend_cd = Convert.ToString(reader["VEND_CD"]);
					vend_name = Convert.ToString(reader["VEND_NAME"]);
					vend_city = Convert.ToString(reader["VEND_CITY"]);
					vend_email = Convert.ToString(reader["VEND_EMAIL"]);
					rly_cd = Convert.ToString(reader["RLY_CD"]);
					if (reader["REGION_CODE"].ToString() == "N") { wRegion = "NORTHERN REGION <br> 12th FLOOR,CORE-II,SCOPE MINAR,LAXMI NAGAR, DELHI - 110092<br> Phone : +918800018691-95 <br> Fax : 011-22024665"; sender = "nrinspn@rites.com"; wPCity = "New Delhi"; }
					else if (reader["REGION_CODE"].ToString() == "S") { wRegion = "SOUTHERN REGION <br> CTS BUILDING - 2ND FLOOR, BSNL COMPLEX, NO. 16, GREAMS ROAD,  CHENNAI - 600 006 <br> Phone : 044-28292807/044- 28292817 <br> Fax : 044-28290359"; sender = "srinspn@rites.com"; wPCity = "Chennai"; }
					else if (reader["REGION_CODE"].ToString() == "E") { wRegion = "EASTERN REGION <br> CENTRAL STATION BUILDING(METRO), 56, C.R. AVENUE,3rd FLOOR,KOLKATA-700 012  <br> Fax : 033-22348704"; sender = "erinspn@rites.com"; wPCity = "Kolkata"; }
					else if (reader["REGION_CODE"].ToString() == "W") { wRegion = "WESTERN REGION <BR>5TH FLOOR, REGENT CHAMBER, ABOVE STATUS RESTAURANT,NARIMAN POINT,MUMBAI-400021 <BR>Phone : 022-68943400/68943445 <BR>"; sender = "wrinspn@rites.com"; wPCity = "Mumbai"; }
					else if (reader["REGION_CODE"].ToString() == "C") { wRegion = "Central Region"; }
				}
				conn.Close();

				OracleCommand cmd = new OracleCommand("Select T05.VEND_NAME MFG_NAME,T03.CITY MFG_CITY,T05.VEND_EMAIL,T17.MFG_CD from T05_VENDOR T05,T17_CALL_REGISTER T17,T03_CITY T03 where T05.VEND_CD=T17.MFG_CD and T05.VEND_CITY_CD=T03.CITY_CD and CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text, conn);
				conn.Open();
				string manu_mail = "", mfg_cd = "", manu_name = "", manu_city = "", can_charges = "", can_status = "";
				OracleDataReader reader1 = cmd.ExecuteReader();
				while (reader1.Read())
				{
					manu_mail = Convert.ToString(reader1["VEND_EMAIL"]);
					mfg_cd = Convert.ToString(reader1["MFG_CD"]);
					manu_name = Convert.ToString(reader1["MFG_NAME"]);
					manu_city = Convert.ToString(reader1["MFG_CITY"]);

				}

				conn.Close();
				OracleCommand cmd1 = new OracleCommand("Select T09.IE_NAME,T09.IE_PHONE_NO,T09.IE_EMAIL,T08.CO_EMAIL  from T09_IE T09, T08_IE_CONTROLL_OFFICER T08 where T09.IE_CO_CD=T08.CO_CD and IE_CD=" + Request.Params["IE_CD"].ToString(), conn);
				conn.Open();
				string ie_phone = "", ie_name = "", ie_email = "", ie_co_email = "";
				OracleDataReader reader2 = cmd1.ExecuteReader();
				while (reader2.Read())
				{
					ie_phone = Convert.ToString(reader2["IE_PHONE_NO"]);
					ie_name = Convert.ToString(reader2["IE_NAME"]);
					ie_email = Convert.ToString(reader2["IE_EMAIL"]);
					ie_co_email = Convert.ToString(reader2["CO_EMAIL"]);
				}
				conn.Close();
				string can_reasons = "";
				if (lstCallStatus.SelectedValue == "C")
				{
					can_reasons = get_cancel_reasons();
				}
				string call_letter_dt = "";
				if (lblCLettDT.Text.Trim() == "")
				{
					call_letter_dt = "NIL";
				}
				else
				{
					call_letter_dt = lblCLettDT.Text.Trim();
				}
				string mail_body = "";
				if (lstCallCancelStatus.SelectedValue == "C")
				{
					mail_body = vend_name + ", " + vend_city + " / " + manu_name + ", " + manu_city + ",<br><br> Your Call Letter Dated:  " + call_letter_dt + " for inspection of material against Agency.-" + rly_cd + ", PO No. - " + lblPONO.Text + " & Date - " + lblPODT.Text + ", Case NO. -" + lblCSNO.Text + ", registered on date: " + lblCallDT.Text + ", at SNo. " + lblSNO.Text + ". is Cancelled (" + lstCallCancelStatus.SelectedItem.Text + ") on Date.-" + txtSTDT.Text + " by the concerned Inspection Engineer. - " + ie_name + " Contact No. " + ie_phone + ", Due to the following reasons.<br>" + can_reasons + "<br>";
					//						if(lstCallCancelCharges.SelectedValue=="0")
					//						{
					mail_body = mail_body + "You are requested to submit call cancellation charges for the amount of Rs. " + txtCanCharges.Text + "/- + GST, through NEFT/RTGS/Credit card/Debit card/Net banking. </b> in f/o RITES LTD, Payble at " + wPCity + " along with next call.<br><b><u>Please note that call letter without call cancellation charges will not be accepted.</u></b><br>";

					//						}
					//						else
					//						{
					//							mail_body=mail_body + "You are requested to submit call cancellation charges through NEFT/ RTGS/ Credit card/ Debit card/ Net banking for <b> Rs."+lstCallCancelCharges.SelectedValue+" + GST </b> in f/o RITES LTD, Payble at "+wPCity+" along with next call.<br><b><u>Please note that call letter without call cancellation charges will not be accepted.</u></b><br>";
					//						}


					mail_body = mail_body + "This is for your information and necessary corrective measures please. <br><br> Thanks for using RITES Inspection Services.<br> NATIONAL INSPECTION HELP LINE NUMBER : 1800 425 7000 (TOLL FREE). <br><br>" + wRegion + ".";
				}
				else
				{
					mail_body = vend_name + ", " + vend_city + " / " + manu_name + ", " + manu_city + ",<br><br> Your Call Letter Dated:  " + call_letter_dt + " for inspection of material against Agency.-" + rly_cd + ", PO No. - " + lblPONO.Text + " & Date - " + lblPODT.Text + ", Case NO. -" + lblCSNO.Text + ", registered on date: " + lblCallDT.Text + ", at SNo. " + lblSNO.Text + ". is Cancelled (" + lstCallCancelStatus.SelectedItem.Text + ") on Date.-" + txtSTDT.Text + " by the concerned Inspection Engineer. - " + ie_name + " Contact No. " + ie_phone + "<br>";
					mail_body = mail_body + "This is for your information and necessary corrective measures please.<br> NATIONAL INSPECTION HELP LINE NUMBER : 1800 425 7000 (TOLL FREE). <br><br> Thanks for using RITES Inspection Services. <br><br>" + wRegion + ".";
				}
				if (vend_cd == mfg_cd && manu_mail != "")
				{
					MailMessage mail = new MailMessage();
					mail.To = manu_mail;
					mail.Cc = ie_co_email + ";" + ie_email;
					if (Session["Region"].ToString() == "N")
					{
						mail.Bcc = "nrinspn@gmail.com" + ";" + "nrinspn.fin@rites.com";
					}
					else
					{
						mail.Bcc = "nrinspn@gmail.com";
					}
					mail.BodyFormat = MailFormat.Html;
					//mail.From = sender;
					mail.From = "nrinspn@gmail.com";
					mail.Subject = "Your Call for Inspection By RITES has Cancelled.";
					mail.Body = mail_body;
					mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
					SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
					mail.Priority = MailPriority.High;
					SmtpMail.Send(mail);
				}
				else if (vend_cd != mfg_cd && vend_email != "" && manu_mail != "")
				{


					MailMessage mail = new MailMessage();
					mail.To = vend_email + ";" + manu_mail;
					mail.Cc = ie_co_email + ";" + ie_email;
					if (Session["Region"].ToString() == "N")
					{
						mail.Bcc = "nrinspn@gmail.com" + ";" + "nrinspn.fin@rites.com";
					}
					else
					{
						mail.Bcc = "nrinspn@gmail.com";
					}
					mail.BodyFormat = MailFormat.Html;
					//mail.From = sender;
					mail.From = "nrinspn@gmail.com";
					mail.Subject = "Your Call for Inspection By RITES has Cancelled.";
					mail.Body = mail_body;
					mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
					SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
					mail.Priority = MailPriority.High;
					SmtpMail.Send(mail);




				}
				else if (vend_cd != mfg_cd && (vend_email != "" || manu_mail != ""))
				{
					MailMessage mail = new MailMessage();
					if (vend_email == "")
					{
						mail.To = manu_mail;
					}
					else if (manu_mail == "")
					{
						mail.To = vend_email;
					}

					mail.Cc = ie_co_email + ";" + ie_email;
					if (Session["Region"].ToString() == "N")
					{
						mail.Bcc = "nrinspn@gmail.com" + ";" + "nrinspn.fin@rites.com";
					}
					else
					{
						mail.Bcc = "nrinspn@gmail.com";
					}
					mail.BodyFormat = MailFormat.Html;
					//mail.From = sender;
					mail.From = "nrinspn@gmail.com";
					mail.Subject = "Your Call for Inspection By RITES has Cancelled.";
					mail.Body = mail_body;
					mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
					SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
					mail.Priority = MailPriority.High;
					SmtpMail.Send(mail);

				}

				if (vend_email == "" && manu_mail == "")
				{
					mail_body = mail_body + "\n As their is no email-id available for Vendor/Manufacturer, So the email cannot be send to Vendor/Manufacturer.";
					MailMessage mail1 = new MailMessage();
					mail1.To = ie_co_email + ";" + ie_email;
					if (Session["Region"].ToString() == "N")
					{
						mail1.Bcc = "nrinspn@gmail.com" + ";nrinspn.fin@rites.com";
					}
					else
					{
						mail1.Bcc = "nrinspn@gmail.com";
					}
					mail1.BodyFormat = MailFormat.Html;
					//					mail1.From=sender;
					mail1.From = "nrinspn@gmail.com";
					mail1.Subject = "Your Call for Inspection By RITES has Cancelled.";
					mail1.Body = mail_body;
					mail1.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");   //basic authentication
					SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
					mail1.Priority = MailPriority.High;
					SmtpMail.Send(mail1);


				}

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				//				Response.Write(ex);
			}
			finally
			{
				conn.Close();
				conn.Dispose();
			}


		}
		void cancel_charges()
		{
			try
			{
				conn.Open();
				OracleCommand myCommand11 = new OracleCommand("select RLY_NONRLY from T13_PO_MASTER where CASE_NO= '" + lblCSNO.Text.Trim() + "'", conn);
				string rly_nonrly = Convert.ToString(myCommand11.ExecuteScalar());
				if (rly_nonrly == "R")
				{

					string str1 = "SELECT round(SUM(VALUE),2) VALUE FROM (SELECT T18.CASE_NO,T18.CALL_RECV_DT, T18.CALL_SNO,(T15.VALUE/T15.QTY)*T18.QTY_TO_INSP VALUE FROM T18_CALL_DETAILS T18, T15_PO_DETAIL T15 WHERE T15.CASE_NO=T18.CASE_NO AND T15.ITEM_SRNO=T18.ITEM_SRNO_PO AND T18.CASE_NO='" + lblCSNO.Text.Trim() + "' AND CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + ") GROUP BY CASE_NO,CALL_RECV_DT,CALL_SNO";
					OracleCommand myCommand2 = new OracleCommand(str1, conn);
					double w_mat_value = Convert.ToDouble(myCommand2.ExecuteScalar());
					txtMatValue.Text = Convert.ToString(w_mat_value);
					txtCanCharges.Text = Convert.ToString(w_mat_value * 0.9 / 100);
					double w_cancharges = 0;
					Label12.Visible = true;
					txtMatValue.Visible = true;
					if (lstCallCancelCharges.SelectedValue == "B")
					{
						w_cancharges = Math.Round(Convert.ToDouble(txtCanCharges.Text) / 2);
						if (w_cancharges < 11000)
						{
							txtCanCharges.Text = Convert.ToString(w_cancharges);
						}
						else
						{
							txtCanCharges.Text = Convert.ToString(11000);
						}
					}
					else if (lstCallCancelCharges.SelectedValue == "A")
					{

						w_cancharges = Math.Round(Convert.ToDouble(txtCanCharges.Text));
						if (w_cancharges < 22000)
						{
							txtCanCharges.Text = Convert.ToString(w_cancharges);
						}
						else
						{
							txtCanCharges.Text = Convert.ToString(22000);
						}
					}
					//				else if (lstCallCancelCharges.SelectedValue=="X")
					//				{
					//					txtCanCharges.Text=Convert.ToString(500);
					//				}

				}
				else if (rly_nonrly != "R")
				{
					txtCanCharges.Text = lstCallCancelCharges.SelectedValue;
					Label12.Visible = false;
					txtMatValue.Visible = false;
				}
				conn.Close();
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
				conn.Dispose();
			}
		}
		protected void lstCallStatus_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lstCallStatus.SelectedValue == "C")
			{
				btnSaveCancellation.Enabled = true;
				Panel_1.Visible = true;
				lstCallCancelStatus.Visible = true;
				txtRemarks.Visible = false;
				Label32.Visible = false;
				Label4.Visible = false;
				Label4.Visible = false;
				Label5.Visible = false;
				txtHologram.Visible = false;
				Label6.Visible = false;
				Label9.Visible = false;
				Label15.Visible = false;
				File14.Visible = false;
				File1.Visible = false;
				File2.Visible = false;
				File3.Visible = false;
				Label7.Visible = false;
				Label10.Visible = false;
				conn.Open();
				OracleCommand myCommand1 = new OracleCommand("select RLY_NONRLY from T13_PO_MASTER where CASE_NO= '" + lblCSNO.Text.Trim() + "'", conn);
				string w_rly_nonrly = Convert.ToString(myCommand1.ExecuteScalar());
				lstCallCancelCharges.Items.Clear();
				if (w_rly_nonrly == "R")
				{
					//					ListItem lst2 = new ListItem(); 
					//					lst2.Text = "Before Visit of IE to Vendor's premises (Due to typographical mistakes in Call letter by Vendor)"; 
					//					lst2.Value = "X"; 
					//					lstCallCancelCharges.Items.Add(lst2);
					ListItem lst2 = new ListItem();
					lst2.Text = "Before Visit of IE to Vendor's premises (AS per Railway Board Order No. 99/RS(G)/709/4 Dated: 12-02/2016)";
					lst2.Value = "B";
					lstCallCancelCharges.Items.Add(lst2);
					lst2 = new ListItem();
					lst2.Text = "After Visit of IE to Vendor's Premises (As per Railway Board Order No. 99/RS(G)/709/4 Dated: 12-02/2016)";
					lst2.Value = "A";
					lstCallCancelCharges.Items.Add(lst2);
					lstCallCancelCharges.Items.Insert(0, "");
				}
				else
				{
					ListItem lst1 = new ListItem();
					lst1.Text = "Before Visit of IE to Vendor's premises";
					lst1.Value = "3000";
					lstCallCancelCharges.Items.Add(lst1);
					lst1 = new ListItem();
					lst1.Text = "After Visit of IE to Vendor Premises - Local";
					lst1.Value = "10000";
					lstCallCancelCharges.Items.Add(lst1);
					lst1 = new ListItem();
					lst1.Text = "After Visit of IE to Vendor Premises - Out Station";
					lst1.Value = "15000";
					lstCallCancelCharges.Items.Add(lst1);
					lstCallCancelCharges.Items.Insert(0, "");
					txtCanCharges.Text = Convert.ToString(lstCallCancelCharges.SelectedValue);
				}
				conn.Close();
				lstCallCancelCharges.Visible = true;

			}
			else if (lstCallStatus.SelectedValue == "R")
			{
				HyperLink2AR.Visible = true;
				HyperLink1.Visible = false;
				btnSave.Enabled = false;
				btnSaveCancellation.Enabled = false;
				Label11.Visible = false;
				Label12.Visible = false;
				txtMatValue.Visible = false;
				txtCanCharges.Visible = false;
				lstCallCancelCharges.Visible = false;
				Panel_1.Visible = false;
				txtbksetno.Visible = false;
				txtBKNO.Visible = false;
				txtSetNo.Visible = false;
				Label9.Visible = false;
				Label10.Visible = false;
				Label7.Visible = false;
				File1.Visible = false;
				File2.Visible = false;
				File3.Visible = false;
				Label15.Visible = false;
				File14.Visible = false;
				lstCallCancelStatus.Visible = false;
				//				txtRemarks.Visible=true;
				//				Label32.Visible=true;
				//				txtRemarks.Enabled=true;
				//				Label4.Visible=true;
				//				Label5.Visible=true;
				//				txtHologram.Visible=true;
				//				Label6.Visible=true;
				//				Label9.Visible=true;
				//				File1.Visible=true;
				//				File2.Visible=true;
				//				File3.Visible=true;
				//				Label7.Visible=true;
				//				Label10.Visible=true;
				//				btnViewIC.Visible=true;
			}
			else if (lstCallStatus.SelectedValue == "A")
			{
				HyperLink2AR.Visible = true;
				HyperLink1.Visible = false;
				btnSave.Enabled = false;
				btnSaveCancellation.Enabled = false;
				Label11.Visible = false;
				Label12.Visible = false;
				txtMatValue.Visible = false;
				txtCanCharges.Visible = false;
				lstCallCancelCharges.Visible = false;
				Panel_1.Visible = false;
				txtbksetno.Visible = false;
				txtBKNO.Visible = false;
				txtSetNo.Visible = false;
				Label9.Visible = false;
				Label10.Visible = false;
				Label7.Visible = false;
				File1.Visible = false;
				File2.Visible = false;
				File3.Visible = false;
				Label15.Visible = false;
				File14.Visible = false;
				lstCallCancelStatus.Visible = false;

				//				Label32.Visible=false;
				//				txtRemarks.Visible=false;
				//				Label4.Visible=false;
				//				Label5.Visible=true;
				//				txtHologram.Visible=true;
				//				Label6.Visible=true;
				//				Label9.Visible=true;
				//				File1.Visible=true;
				//				File2.Visible=true;
				//				File3.Visible=true;
				//				Label7.Visible=true;
				//				Label10.Visible=true;
				//				btnViewIC.Visible=true;
			}
			else if (lstCallStatus.SelectedValue == "G" || lstCallStatus.SelectedValue == "T")
			{
				txtbksetno.Visible = true;
				txtBKNO.Visible = true;
				txtSetNo.Visible = true;
				Label9.Visible = true;
				Label10.Visible = true;
				Label7.Visible = true;
				File1.Visible = true;
				File2.Visible = true;
				File3.Visible = true;
				Label15.Visible = true;
				File14.Visible = true;
				Panel_1.Visible = false;
				btnSave.Enabled = true;
			}
			else
			{
				#region HML
				if (lstCallStatus.SelectedValue == "S")
				{
					HprInspecttestPlan.Visible = true;
				}
				#endregion
				Panel_1.Visible = false;
				txtRemarks.Visible = false;
				Label32.Visible = false;
				txtRemarks.Enabled = false;
				Label4.Visible = false;
				Label5.Visible = false;
				txtHologram.Visible = false;
				Label6.Visible = false;
				Label9.Visible = false;
				File1.Visible = false;
				File2.Visible = false;
				File3.Visible = false;
				Label15.Visible = false;
				File14.Visible = false;
				Label7.Visible = false;
				Label10.Visible = false;
				Label11.Visible = false;
				Label12.Visible = false;
				txtMatValue.Visible = false;
				txtCanCharges.Visible = false;
				lstCallCancelCharges.Visible = false;
			}
			if (lstCallStatus.SelectedValue != "A" && lstCallStatus.SelectedValue != "R")
			{
				fifo_voilate_check();
			}
		}

		void fifo_voilate_check()
		{
			try
			{
				conn.Open();
				string str1 = "SELECT count(*) FROM T17_CALL_REGISTER T17 WHERE DT_INSP_DESIRE<to_date('" + lblInpDesireDT.Text.Trim() + "','dd/mm/yyyy') and CALL_STATUS='M' AND IE_CD='" + Session["IE_CD"] + "' AND REGION_CODE='" + Session["Region"] + "' AND CALL_RECV_DT>TO_DATE('01/04/2021','DD/MM/YYYY')";
				OracleCommand myCommand2 = new OracleCommand(str1, conn);
				int wFIFOVoilate = Convert.ToInt32(myCommand2.ExecuteScalar());
				conn.Close();
				if (wFIFOVoilate > 0)
				{
					DisplayAlert("You are Voilating the FIFO for attending Calls, kindly enter the reason for voilating FIFO!!!");
					lblFIFO.Visible = true;
					txtFIFO.Visible = true;
				}
				else
				{
					lblFIFO.Visible = false;
					txtFIFO.Visible = false;
				}
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				//				Response.Write(ex);
			}
			finally
			{
				conn.Close();
				conn.Dispose();
			}
		}
		protected void lstCallCancelCharges_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lstCallCancelStatus.SelectedValue == "C")
			{
				lstCallCancelCharges.Visible = true;
				Label11.Visible = true;
				Label12.Visible = true;
				txtMatValue.Visible = true;
				txtCanCharges.Visible = true;

				cancel_charges();
			}
			else
			{
				lstCallCancelCharges.Visible = false;
			}
		}

		protected void lstCallCancelStatus_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lstCallCancelStatus.SelectedValue == "C")
			{
				lstCallCancelCharges.Visible = true;
			}
			else
			{
				lstCallCancelCharges.Visible = false;
				txtbksetno.Visible = false;
				txtBKNO.Visible = false;
				txtSetNo.Visible = false;
				btnSave.Visible = false;
				Label11.Visible = false;
				Label12.Visible = false;
				txtMatValue.Visible = false;
				txtCanCharges.Visible = false;
			}
		}

		protected void btnViewIC_Click(object sender, System.EventArgs e)
		{
			//			conn.Open();
			//			OracleDataReader ord;
			//			string qry = "Delete from RPT_PRM_Inspection_Certificate Where Request_TS < CURRENT_TIMESTAMP - INTERVAL '1' MINUTE"; 
			//			OracleCommand myOracleCommand1 = new OracleCommand(qry, conn); 			 
			//			ord = myOracleCommand1.ExecuteReader();
			//			conn.Close();
			//			//updateQuery="Update T17_CALL_REGISTER set CALL_STATUS='"+lstCallStatus.SelectedValue+"',CALL_STATUS_DT=to_date('"+txtSTDT.Text+"','dd/mm/yyyy'),CALL_CANCEL_STATUS=null,BK_NO='"+txtBKNO.Text+"',SET_NO='"+txtSetNo.Text+"',USER_ID='"+Session["IE_EMP_NO"].ToString()+"',DATETIME=to_date('"+ss+"','dd/mm/yyyy-HH24:MI:SS'), HOLOGRAM='"+txtHologram.Text.Trim()+"' where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO="+lblSNO.Text+"";
			//			string caseNo = lblCSNO.Text.Trim();
			//			string callSNo = lblSNO.Text;
			//			string myYear,myMonth,myDay;
			//			myYear=lblCallDT.Text.Substring(6,4);
			//			myMonth=lblCallDT.Text.Substring(3,2);
			//			myDay=lblCallDT.Text.Substring(0,2);
			//			string recvDtRpt = myMonth+"/"+myDay+"/"+myYear;
			//			//string recvDtQry = "26-NOV-2010";
			//
			//			conn.Open();
			//			qry = "INSERT INTO RPT_PRM_Inspection_Certificate VALUES ('" + caseNo + "', to_date('" + recvDtRpt + "','mm/dd/yyyy'), " + callSNo + " , NULL, NULL , CURRENT_TIMESTAMP)";
			//			myOracleCommand1 = new OracleCommand(qry, conn); 			 
			//			ord = myOracleCommand1.ExecuteReader();
			//			conn.Close();
			//
			//			
			//			qry = "MERGE INTO RPT_PRM_Inspection_Certificate RP USING ";
			//			qry+= "( SELECT CASE_NO, CALL_SNO, CALL_RECV_DT, COUNT(*) as NUM_VISITS, LISTAGG(TO_CHAR(Visit_DT, 'DD.MM.YYYY'), ', ') within group (order by Visit_DT ) as VISIT_DATES ";
			//			qry+= "    FROM T47_IE_WORK_PLAN ";
			//			qry+= "   WHERE CASE_NO = '" + caseNo + "' and CALL_SNO = " + callSNo + " and CALL_RECV_DT = to_date('" + recvDtRpt + "','mm/dd/yyyy') ";
			//			qry+= "  GROUP BY CASE_NO, CALL_SNO, CALL_RECV_DT) WP ";
			//			qry+= "ON(RP.CASE_NO = WP.CASE_NO AND RP.CALL_SNO = WP.CALL_SNO AND RP.CALL_RECV_DT = WP.CALL_RECV_DT) ";
			//			qry+= "WHEN MATCHED THEN UPDATE SET ";
			//			qry+= "RP.NUM_VISITS = WP.NUM_VISITS, ";
			//			qry+= "RP.VISIT_DATES = WP.VISIT_DATES";
			//			conn.Open();
			//			myOracleCommand1 = new OracleCommand(qry, conn); 
			//				
			//			ord = myOracleCommand1.ExecuteReader();
			//			conn.Close();
			//			rbs my_rbs=new rbs();
			//			CrystalDecisions.CrystalReports.Engine.ReportDocument rpt=null;
			//			rpt= new Reports.InspectionCertificate();			
			//			//			rpt.RecordSelectionFormula ="ToText({V22_BILL.BILL_DT},'yyyyMMdd')>='"+wDtFr+"' and ToText({V22_BILL.BILL_DT},'yyyyMMdd')<='"+wDtTo+"' and {V22_BILL.REGION_CODE}='"+Session["Region"]+"' and ("+wFormula+")";
			//			//			rpt.SetParameterValue(0,Session["Region"]);
			//			//			rpt.SetParameterValue(1,txtDateFr.Text);
			//			//			rpt.SetParameterValue(2,txtDateTo.Text);
			//			rpt.SetParameterValue("caseno",caseNo);
			//			rpt.SetParameterValue(1,callSNo);
			//			rpt.SetParameterValue(2,recvDtRpt);
			//			rpt.SetParameterValue("pRegion",Session["Region"]);
			//			
			//			MemoryStream oStream=my_rbs.showwordrep(rpt);
			//			Response.Clear();
			//			Response.Buffer = true;
			//			Response.ContentType = "application/doc";
			//			try
			//			{				
			//				Response.BinaryWrite(oStream.ToArray());
			//				Response.End();
			//			}
			//			catch(Exception err)
			//			{
			//				Response.Write("< BR >");
			//				Response.Write(err.Message.ToString());
			//			}	
		}

		private void btnRecalcCanCharges_Click(object sender, System.EventArgs e)
		{
			cancel_charges();
		}


	}
}