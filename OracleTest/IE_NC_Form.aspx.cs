using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS
{
    public partial class IE_NC_Form : System.Web.UI.Page
    {
		OracleConnection conn1 = null;
		public string CNO, BNO, SNO, Action, NCNO;

		void show1()
		{

			conn1= new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		//	conn1 = new System.Data.OracleClient.OracleConnection((ConfigurationSettings.AppSettings["ConnectionString"]));
			try
			{
				DataSet dsP4 = new DataSet();
				string str5 = "select T06.CONSIGNEE_CD,(trim(T06.CONSIGNEE_DESIG)||'/'||trim(T06.CONSIGNEE_DEPT)||'/'||trim(T06.CONSIGNEE_FIRM)||'/'||T031.CITY) CONSIGNEE,T05.VEND_NAME||','||T03.CITY VENDOR, T13.VEND_CD,T13.PO_NO, to_char(T13.PO_DT,'dd/mm/yyyy') PO_DT, T20.BK_NO, T20.SET_NO, T20.CASE_NO, to_char(T20.CALL_RECV_DT,'dd/mm/yyyy')CALL_RECV_DT, T20.CALL_SNO, T20.IE_CD,T20.IC_NO, to_char(T20.IC_DT,'dd/mm/yyyy')IC_DATE,T09.IE_NAME from T13_PO_MASTER T13,T17_CALL_REGISTER T17,T20_IC T20,T05_VENDOR T05, T03_CITY T03, T06_CONSIGNEE T06,T03_CITY T031,T09_IE T09 where T20.CASE_NO=T13.CASE_NO and T20.CASE_NO=T17.CASE_NO AND T20.CALL_RECV_DT=T17.CALL_RECV_DT AND T20.CALL_SNO=T17.CALL_SNO AND T20.CONSIGNEE_CD=T06.CONSIGNEE_CD AND T06.CONSIGNEE_CITY=T031.CITY_CD AND T13.VEND_CD=T05.VEND_CD AND T05.VEND_CITY_CD=T03.CITY_CD and T13.CASE_NO=T17.CASE_NO AND T20.IE_CD=T09.IE_CD AND T20.CASE_NO= '" + CNO + "' AND T20.BK_NO='" + BNO + "' AND T20.SET_NO='" + SNO + "' ";
				OracleDataAdapter da4 = new OracleDataAdapter(str5, conn1);
				OracleCommand myOracleCommand4 = new OracleCommand(str5, conn1);
				conn1.Open();
				da4.SelectCommand = myOracleCommand4;
				da4.Fill(dsP4, "Table");
				if (dsP4.Tables[0].Rows.Count == 0)
				{
					lblBKNO.Visible = false;
					lblSETNO.Visible = false;
					lblIE.Visible = false;
					txtCaseNo.Visible = false;
					txtDtOfReciept.Visible = false;
					lblCSNO.Visible = false;
					lblVend.Visible = false;
					lblPONO.Visible = false;
					lblPODT.Visible = false;
					lblIECD.Visible = false;
					lblConsignee.Visible = false;
					lblCon_CD.Visible = false;
					lblIC_NO.Visible = false;
					lblIC_DT.Visible = false;
				}
				else
				{
					lblBKNO.Text = dsP4.Tables[0].Rows[0]["BK_NO"].ToString();
					lblSETNO.Text = dsP4.Tables[0].Rows[0]["SET_NO"].ToString();
					lblIE.Text = dsP4.Tables[0].Rows[0]["IE_NAME"].ToString();
					txtCaseNo.Text = dsP4.Tables[0].Rows[0]["CASE_NO"].ToString();
					txtDtOfReciept.Text = dsP4.Tables[0].Rows[0]["CALL_RECV_DT"].ToString();
					lblCSNO.Text = dsP4.Tables[0].Rows[0]["CALL_SNO"].ToString();
					lblVend.Text = dsP4.Tables[0].Rows[0]["VENDOR"].ToString();
					lblVEND_CD.Text = dsP4.Tables[0].Rows[0]["VEND_CD"].ToString();
					lblPONO.Text = dsP4.Tables[0].Rows[0]["PO_NO"].ToString();
					lblPODT.Text = dsP4.Tables[0].Rows[0]["PO_DT"].ToString();
					lblIECD.Text = dsP4.Tables[0].Rows[0]["IE_CD"].ToString();
					lblConsignee.Text = dsP4.Tables[0].Rows[0]["CONSIGNEE"].ToString();
					lblCon_CD.Text = dsP4.Tables[0].Rows[0]["CONSIGNEE_CD"].ToString();
					lblIC_NO.Text = dsP4.Tables[0].Rows[0]["IC_NO"].ToString();
					lblIC_DT.Text = dsP4.Tables[0].Rows[0]["IC_DATE"].ToString();
				}
				conn1.Close();
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
				conn1.Close();
				conn1.Dispose();
			}

			fill_items();


		}

		void show2()
		{

			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			//conn1 = new System.Data.OracleClient.OracleConnection((ConfigurationSettings.AppSettings["ConnectionString"]));
			try
			{
				DataSet dsP4 = new DataSet();
				string str5 = "select T41.NC_NO,to_char(T41.NC_DT,'dd/mm/yyyy') NC_DATE,T41.CONSIGNEE_CD,(trim(T06.CONSIGNEE_DESIG)||'/'||trim(T06.CONSIGNEE_DEPT)||'/'||trim(T06.CONSIGNEE_FIRM)||'/'||T031.CITY) CONSIGNEE,T05.VEND_NAME||','||T03.CITY VENDOR, T41.VEND_CD,T41.PO_NO, to_char(T41.PO_DT,'dd/mm/yyyy') PO_DT,T41.BK_NO, T41.SET_NO, T41.CASE_NO, to_char(T41.CALL_RECV_DT,'dd/mm/yyyy')CALL_RECV_DT, T41.CALL_SNO, T41.IE_CD,T41.IC_NO, to_char(T41.IC_DT,'dd/mm/yyyy')IC_DATE,T09.IE_NAME,T41.ITEM_DESC_PO, T41.ITEM_SRNO_PO, T41.QTY_PASSED from T41_NC_MASTER T41,T05_VENDOR T05, T03_CITY T03, T06_CONSIGNEE T06,T03_CITY T031,T09_IE T09 where T41.CONSIGNEE_CD=T06.CONSIGNEE_CD AND T06.CONSIGNEE_CITY=T031.CITY_CD AND T41.VEND_CD=T05.VEND_CD AND T05.VEND_CITY_CD=T03.CITY_CD and T41.IE_CD=T09.IE_CD AND T41.NC_NO= '" + NCNO + "' ";
				OracleDataAdapter da4 = new OracleDataAdapter(str5, conn1);
				OracleCommand myOracleCommand4 = new OracleCommand(str5, conn1);
				conn1.Open();
				da4.SelectCommand = myOracleCommand4;
				da4.Fill(dsP4, "Table");
				if (dsP4.Tables[0].Rows.Count == 0)
				{
					lblBKNO.Visible = false;
					lblSETNO.Visible = false;
					lblIE.Visible = false;
					txtCaseNo.Visible = false;
					txtDtOfReciept.Visible = false;
					lblCSNO.Visible = false;
					lblVend.Visible = false;
					lblPONO.Visible = false;
					lblPODT.Visible = false;
					lblIECD.Visible = false;
					lblConsignee.Visible = false;
					lblCon_CD.Visible = false;
					lblIC_NO.Visible = false;
					lblIC_DT.Visible = false;
				}
				else
				{
					lblBKNO.Text = dsP4.Tables[0].Rows[0]["BK_NO"].ToString();
					lblSETNO.Text = dsP4.Tables[0].Rows[0]["SET_NO"].ToString();
					lblIE.Text = dsP4.Tables[0].Rows[0]["IE_NAME"].ToString();
					txtCaseNo.Text = dsP4.Tables[0].Rows[0]["CASE_NO"].ToString();
					txtDtOfReciept.Text = dsP4.Tables[0].Rows[0]["CALL_RECV_DT"].ToString();
					lblCSNO.Text = dsP4.Tables[0].Rows[0]["CALL_SNO"].ToString();
					lblVend.Text = dsP4.Tables[0].Rows[0]["VENDOR"].ToString();
					lblVEND_CD.Text = dsP4.Tables[0].Rows[0]["VEND_CD"].ToString();
					lblPONO.Text = dsP4.Tables[0].Rows[0]["PO_NO"].ToString();
					lblPODT.Text = dsP4.Tables[0].Rows[0]["PO_DT"].ToString();
					lblIECD.Text = dsP4.Tables[0].Rows[0]["IE_CD"].ToString();
					lblConsignee.Text = dsP4.Tables[0].Rows[0]["CONSIGNEE"].ToString();
					lblCon_CD.Text = dsP4.Tables[0].Rows[0]["CONSIGNEE_CD"].ToString();
					lblIC_NO.Text = dsP4.Tables[0].Rows[0]["IC_NO"].ToString();
					lblIC_DT.Text = dsP4.Tables[0].Rows[0]["IC_DATE"].ToString();
					lblItem.Text = dsP4.Tables[0].Rows[0]["ITEM_DESC_PO"].ToString();
					lblItem_Srno.Text = dsP4.Tables[0].Rows[0]["ITEM_SRNO_PO"].ToString();
					lblQtyPass.Text = dsP4.Tables[0].Rows[0]["QTY_PASSED"].ToString();
					txtNCR_DT.Text = dsP4.Tables[0].Rows[0]["NC_DATE"].ToString();
					lblNC_NO.Text = dsP4.Tables[0].Rows[0]["NC_NO"].ToString();
				}
				conn1.Close();
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
				conn1.Close();
				conn1.Dispose();
			}

			fillgrid();


		}

		void fill_items()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				lstItems.Items.Clear();
				DataSet dsP = new DataSet();
				string str1;

				str1 = "Select ITEM_SRNO_PO,ITEM_DESC_PO from T18_CALL_DETAILS T18,T20_IC T20 where T20.CASE_NO=T18.CASE_NO and T20.CALL_RECV_DT=T18.CALL_RECV_DT and T20.CALL_SNO=T18.CALL_SNO and T20.CONSIGNEE_CD=T18.CONSIGNEE_CD and T20.CASE_NO='" + txtCaseNo.Text.Trim() + "' and BK_NO='" + lblBKNO.Text.Trim() + "' and SET_NO='" + lblSETNO.Text.Trim() + "'";

				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				ListItem lst;
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					throw new Exception("Their is no details Present for this Case No and Call Recieve Date in CALL DETAILS TABLE !!!");
				}
				else
				{
					for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
					{
						lst = new ListItem();
						lst.Text = dsP.Tables[0].Rows[i]["ITEM_DESC_PO"].ToString();
						lst.Value = dsP.Tables[0].Rows[i]["ITEM_SRNO_PO"].ToString();
						lstItems.Items.Add(lst);
					}

				}
				conn1.Close();
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
				conn1.Close();
				conn1.Dispose();
			}
			QTY_PASS();
		}

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnAddMoreNC.Attributes.Add("OnClick", "JavaScript:validate();");

			if (Convert.ToString(Request.Params["Action"]) == "A")
			{

				CNO = Convert.ToString(Request.Params["CASE_NO"].Trim());
				BNO = Convert.ToString(Request.Params["BK_NO"].Trim());
				SNO = Convert.ToString(Request.Params["SET_NO"].Trim());
				Action = Convert.ToString(Request.Params["Action"]);


			}
			else
			{
				Action = Request.Params["Action"].ToString();
				NCNO = Convert.ToString(Request.Params["NC_NO"].Trim());
			}
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			if (!(IsPostBack))
			{
				ListItem lst5 = new ListItem();
				lst5 = new ListItem();
				lst5.Text = "Minor";
				lst5.Value = "A";
				lstNCRClass.Items.Add(lst5);
				lst5 = new ListItem();
				lst5.Text = "Major";
				lst5.Value = "B";
				lstNCRClass.Items.Add(lst5);
				lst5 = new ListItem();
				lst5.Text = "Critical";
				lst5.Value = "C";
				lstNCRClass.Items.Add(lst5);

				conn1.Open();
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual", conn1);
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				conn1.Close();
				conn1.Dispose();


				if (Convert.ToString(Request.Params["Action"]) == "A")
				{
					show1();
					fill_NCR();
					txtNCR_DT.Text = ss;
					Label9.Visible = false;
					lblNC_NO.Visible = false;
					btnAddMoreNC.Visible = false;
					btnSaveCORemarks.Visible = false;
					btnSaveIEAction.Visible = false;
					rdbAddNCR.Visible = true;
					rdbNONCR.Visible = true;
				}
				else
				{
					show2();
					//					fillgrid();
					lblItemDesc.Visible = false;
					lstItems.Visible = false;
					fill_NCR();
					Label10.Visible = false;
					Label11.Visible = false;
					//btnSend.Visible=false;
					rdbAddNCR.Visible = false;
					rdbNONCR.Visible = false;
					if (Session["Uname"].ToString() != "")
					{
						if (ss == txtNCR_DT.Text.Trim())
						{
							lstNCRClass.Visible = true;
							lstNCR_Codes.Visible = true;
							btnSave.Visible = false;
							btnAddMoreNC.Visible = true;
							Label10.Visible = true;
							Label11.Visible = true;
							btnSend.Visible = true;
						}
						else
						{
							lstNCRClass.Visible = false;
							lstNCR_Codes.Visible = false;
							btnSave.Visible = false;
							btnAddMoreNC.Visible = false;
						}
						btnSaveIEAction.Visible = false;
						btnSaveCORemarks.Visible = true;
					}
					else if (Session["IE_CD"].ToString() != "")
					{
						lstNCRClass.Visible = false;
						lstNCR_Codes.Visible = false;
						btnSave.Visible = false;
						btnSaveIEAction.Visible = true;
						btnSaveCORemarks.Visible = false;
						btnAddMoreNC.Visible = false;
					}

					int nc_status = ncrornoncr();
					if (nc_status >= 1)
					{
						lstNCRClass.Visible = false;
						lstNCR_Codes.Visible = false;
						btnAddMoreNC.Visible = false;
						Label10.Visible = false;
						Label11.Visible = false;
						btnSave.Visible = false;
						btnSaveCORemarks.Visible = false;
						btnSaveIEAction.Visible = false;
						//btnSend.Visible=false;

					}

				}

				txtOtherDesc.Visible = false;
				Label14.Visible = false;
			}
		}

		int ncrornoncr()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("select NVL(count(*),0) from T42_NC_DETAIL where NC_NO='" + lblNC_NO.Text + "' and substr(NC_CD,1,1)='X'", conn1);
			int w_nc = Convert.ToInt32(cmd2.ExecuteScalar());
			conn1.Close();
			conn1.Dispose();
			return (w_nc);
		}
		void fill_NCR()
		{
			lstNCR_Codes.Items.Clear();
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				DataSet dsP1 = new DataSet();
				string str3 = "select NC_CD, NC_CD||'-'||NC_DESC NC_DESC from T69_NC_CODES where NC_CLASS='" + lstNCRClass.SelectedValue + "' order by  NC_CD";
				OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
				ListItem lst3;
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP1, "Table");
				for (int i = 0; i <= dsP1.Tables[0].Rows.Count - 1; i++)
				{
					lst3 = new ListItem();
					lst3.Text = dsP1.Tables[0].Rows[i]["NC_DESC"].ToString();
					lst3.Value = dsP1.Tables[0].Rows[i]["NC_CD"].ToString();
					lstNCR_Codes.Items.Add(lst3);
				}
				conn1.Close();
				lstNCR_Codes.Items.Insert(0, "");
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
				conn1.Close();
				conn1.Dispose();
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
			this.grdNCDetails.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grdNCDetails_ItemDataBound);

		}
		#endregion
		void fillgrid()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "SELECT T42.NC_CD,NVL2(T42.NC_DESC_OTHERS,T69.NC_DESC||'-'||T42.NC_DESC_OTHERS,T69.NC_DESC) NC_DESC,NC_CD_SNO,IE_ACTION1 IE_ACTION, to_char(IE_ACTION1_DT,'dd/mm/yyyy')IE_ACTION1_DT,CO_FINAL_REMARKS1 CO_FINAL_REMARKS ,to_char(CO_FINAL_REMARKS1_DT,'dd/mm/yyyy') CO_FINAL_REMARKS_DT from T69_NC_CODES T69,T41_NC_MASTER T41,T42_NC_DETAIL T42 where T41.NC_NO=T42.NC_NO and T42.NC_CD=T69.NC_CD and T41.NC_NO='" + NCNO + "' order by NC_CD_SNO ASC";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdNCDetails.Visible = false;

				}
				else
				{
					grdNCDetails.Visible = false;
					grdNCDetails.Visible = true;
					grdNCDetails.DataSource = dsP;
					grdNCDetails.DataBind();
					conn1.Close();


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
				conn1.Close();
			}


		}



		protected void lstNCRClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fill_NCR();
		}

		protected void lstPoItems_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			QTY_PASS();

		}

		void QTY_PASS()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				conn1.Open();
				OracleCommand cmd2 = new OracleCommand("Select NVL(QTY_PASSED,0)QTY_PASSED from T18_CALL_DETAILS where CASE_NO='" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblCSNO.Text + " and ITEM_SRNO_PO=" + lstItems.SelectedValue, conn1);
				lblQtyPass.Text = Convert.ToString(cmd2.ExecuteScalar());
				conn1.Close();
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
				conn1.Close();
				conn1.Dispose();
			}
		}
		private string generate_NC_NO()
		{
			string wNC_NO = "";
			try
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				//				string wctr=Session["Region"].ToString()+txtNCR_DT.Text.Substring(8,2);
				//				OracleCommand cmd2 =new OracleCommand("Select lpad(nvl(max(to_number(nvl(substr(NC_NO,5,4),0))),0)+1,4,'0') w_sno From T41_NC_MASTER where substr(NC_NO,1,3)='"+wctr+"'",conn1);
				//				conn1.Open();
				//				string nc_ser=Convert.ToString(cmd2.ExecuteScalar());
				//				wNC_NO=wctr+'-'+nc_ser;
				//				conn1.Close();
				//
				OracleCommand cmd = new OracleCommand("GENERATE_NC_NO", conn1);
				cmd.CommandType = CommandType.StoredProcedure;
				conn1.Open();

				OracleParameter prm1 = new OracleParameter("IN_REGION_CD", System.Data.OracleClient.OracleType.Char);
				prm1.Direction = ParameterDirection.Input;
				prm1.Value = Session["Region"].ToString();
				cmd.Parameters.Add(prm1);

				OracleParameter prm2 = new OracleParameter("IN_NC_DT", System.Data.OracleClient.OracleType.Char);
				prm2.Direction = ParameterDirection.Input;
				prm2.Value = Convert.ToString(txtNCR_DT.Text);
				cmd.Parameters.Add(prm2);

				OracleParameter prm3 = new OracleParameter("OUT_NC_NO", OracleDbType.Char, 8);
				prm3.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(prm3);

				OracleParameter prm4 = new OracleParameter("OUT_ERR_CD", OracleDbType.Int16, 1);
				prm4.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(prm4);

				cmd.ExecuteNonQuery();

				if (Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value) == -1)
				{
					wNC_NO = "-1";
				}
				else
				{
					wNC_NO = Convert.ToString(cmd.Parameters["OUT_NC_NO"].Value);
				}
				conn1.Close();
				return (wNC_NO);
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
				return ("-1");
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}
		}
		protected void btnSave_Click(object sender, System.EventArgs e)
		{


			if (Convert.ToString(Request.Params["Action"]) == "A")
			{
				string NC_NO = generate_NC_NO();
				if (NC_NO == "-1")
				{
					DisplayAlert("NC Details not available");
				}
				else
				{
					conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
					conn1.Open();

					OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
					string ss = Convert.ToString(cmd2.ExecuteScalar());
					//					OracleCommand cmdCO =new OracleCommand("Select IE_CO_CD from T09_IE where IE_CD="+lblIECD.Text.Trim(),conn1);
					OracleCommand cmdCO = new OracleCommand("Select CO_CD from T20_IC where CASE_NO='" + txtCaseNo.Text.Trim() + "' and BK_NO='" + lblBKNO.Text.Trim() + "' and SET_NO='" + lblSETNO.Text.Trim() + "'", conn1);
					int CO = Convert.ToInt32(cmdCO.ExecuteScalar());
					conn1.Close();

					conn1.Open();
					OracleTransaction myTrans = conn1.BeginTransaction();
					try
					{
						string myInsertQuery = "INSERT INTO T41_NC_MASTER(NC_NO,NC_DT,CASE_NO, CALL_RECV_DT, CALL_SNO, BK_NO, SET_NO,VEND_CD,CONSIGNEE_CD,ITEM_SRNO_PO,ITEM_DESC_PO, QTY_PASSED,PO_NO,PO_DT,IC_NO,IC_DT,IE_CD, CO_CD, REGION_CODE, USER_ID, DATETIME) values('" + NC_NO + "',to_date('" + txtNCR_DT.Text.Trim() + "','dd/mm/yyyy'),'" + txtCaseNo.Text.Trim() + "', to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy')," + lblCSNO.Text + ",'" + lblBKNO.Text + "','" + lblSETNO.Text + "'," + lblVEND_CD.Text.Trim() + "," + lblCon_CD.Text.Trim() + "," + lstItems.SelectedValue + ",'" + lstItems.SelectedItem.Text + "'," + lblQtyPass.Text.Trim() + ",'" + lblPONO.Text + "',to_date('" + lblPODT.Text + "','dd/mm/yyyy'),'" + lblIC_NO.Text.Trim() + "',to_date('" + lblIC_DT.Text + "','dd/mm/yyyy'), " + lblIECD.Text + "," + CO + ",'" + Session["Region"] + "','" + Session["Uname"] + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
						OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
						myInsertCommand.Transaction = myTrans;
						myInsertCommand.Connection = conn1;
						myInsertCommand.ExecuteNonQuery();
						string myInsertQuery1 = "";
						if (rdbNONCR.Checked == true)
						{
							myInsertQuery1 = "INSERT INTO T42_NC_DETAIL(NC_NO,NC_CD,NC_CD_SNO,NC_DESC_OTHERS,USER_ID,DATETIME) values('" + NC_NO + "','X01',1,'','" + Session["Uname"].ToString() + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
						}
						else if (rdbAddNCR.Checked == true)
						{
							myInsertQuery1 = "INSERT INTO T42_NC_DETAIL(NC_NO,NC_CD,NC_CD_SNO,NC_DESC_OTHERS,USER_ID,DATETIME) values('" + NC_NO + "','" + lstNCR_Codes.SelectedValue + "',1,'" + txtOtherDesc.Text.Trim() + "','" + Session["Uname"].ToString() + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
						}
						OracleCommand myInsertCommand1 = new OracleCommand(myInsertQuery1);
						myInsertCommand1.Transaction = myTrans;
						myInsertCommand1.Connection = conn1;
						myInsertCommand1.ExecuteNonQuery();
						myTrans.Commit();
						conn1.Close();
					}
					catch (Exception ex)
					{
						string str;
						str = ex.Message;
						myTrans.Rollback();
						string str1 = str.Replace("\n", "");
						Response.Redirect(("Error_Form.aspx?err=" + str1));
					}
					finally
					{
						conn1.Close();
						conn1.Dispose();
					}
					lblNC_NO.Text = NC_NO;
					Label9.Visible = true;
					lblNC_NO.Visible = true;
					btnAddMoreNC.Visible = true;
					btnSave.Visible = false;
					Response.Redirect("IE_NC_Form.aspx?Action=M&NC_NO=" + lblNC_NO.Text);
				}
			}

		}

		protected void btnSaveIEAction_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
			string ss = Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();
			conn1.Open();
			OracleTransaction myTrans = conn1.BeginTransaction();
			try
			{
				int err = 0;
				string wnc_cd = "";
				int wnc_cd_sno = 0;
				string w_reason = "";

				foreach (DataGridItem di in grdNCDetails.Items)
				{
					// Make sure this is an item and not the header or footer.
					if (di.ItemType == ListItemType.Item || di.ItemType == ListItemType.AlternatingItem)
					{

						w_reason = Convert.ToString(((TextBox)di.FindControl("txtIE_Remarks1")).Text);

						wnc_cd = Convert.ToString(di.Cells[1].Text.Trim());
						wnc_cd_sno = Convert.ToInt16(di.Cells[0].Text.Trim());
						if (w_reason == "")
						{
							err = 1;

						}
						string myInsertQuery1 = "";
						if (((TextBox)di.FindControl("txtIE_Remarks1")).Visible == true)
						{
							myInsertQuery1 = "update T42_NC_DETAIL set IE_ACTION1='" + w_reason + "',IE_ACTION1_DT=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),USER_ID='" + Session["IE_EMP_NO"] + "',DATETIME= to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where NC_NO='" + lblNC_NO.Text + "' and NC_CD='" + wnc_cd.Trim() + "' and NC_CD_SNO=" + wnc_cd_sno;
						}

						OracleCommand myInsertCommand1 = new OracleCommand(myInsertQuery1);
						myInsertCommand1.Transaction = myTrans;
						myInsertCommand1.Connection = conn1;
						myInsertCommand1.ExecuteNonQuery();



					}


				}
				if (err == 0)
				{
					myTrans.Commit();

				}
				else if (err == 1)
				{
					myTrans.Rollback();
					DisplayAlert("All Actions Shld be entered!!!");
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
			fillgrid();
			send_email();
		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		protected void btnSaveCORemarks_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
			string ss = Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();
			conn1.Open();
			OracleTransaction myTrans = conn1.BeginTransaction();
			try
			{
				int err = 0;
				string wnc_cd = "";
				int wnc_cd_sno = 0;
				string w_reason = "";

				foreach (DataGridItem di in grdNCDetails.Items)
				{
					// Make sure this is an item and not the header or footer.
					if (di.ItemType == ListItemType.Item || di.ItemType == ListItemType.AlternatingItem)
					{

						w_reason = Convert.ToString(((TextBox)di.FindControl("txtCO_Remarks1")).Text.Trim());
						wnc_cd = Convert.ToString(di.Cells[1].Text.Trim());
						wnc_cd_sno = Convert.ToInt16(di.Cells[0].Text.Trim());

						if (w_reason == "")
						{
							err = 1;

						}

						string myInsertQuery1 = "";
						if (((TextBox)di.FindControl("txtCO_Remarks1")).Visible == true)
						{
							myInsertQuery1 = "update T42_NC_DETAIL set CO_FINAL_REMARKS1='" + w_reason + "',CO_FINAL_REMARKS1_DT=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),USER_ID='" + Session["Uname"] + "',DATETIME= to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where NC_NO='" + lblNC_NO.Text + "' and NC_CD='" + wnc_cd.Trim() + "' and NC_CD_SNO=" + wnc_cd_sno;
						}

						OracleCommand myInsertCommand1 = new OracleCommand(myInsertQuery1);
						myInsertCommand1.Transaction = myTrans;
						myInsertCommand1.Connection = conn1;
						myInsertCommand1.ExecuteNonQuery();



					}


				}
				if (err == 0)
				{
					myTrans.Commit();

				}
				else if (err == 1)
				{
					myTrans.Rollback();
					DisplayAlert("All Actions Shld be entered!!!");
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
			fillgrid();
			send_email();
		}

		private void grdNCDetails_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			string i_reason = "";
			string c_remark = "";
			string w_nc_cd = "";

			foreach (DataGridItem di in grdNCDetails.Items)
			{
				// Make sure this is an item and not the header or footer.
				if (di.ItemType == ListItemType.Item || di.ItemType == ListItemType.AlternatingItem)
				{
					w_nc_cd = Convert.ToString(di.Cells[1].Text.Trim()).Substring(0, 1);
					if (w_nc_cd != "X")
					{
						i_reason = Convert.ToString(((TextBox)di.FindControl("txtIE_Remarks1")).Text);
						if (i_reason == "")
						{
							((TextBox)di.FindControl("txtIE_Remarks1")).Visible = true;
							((Label)di.FindControl("lblIE_Remarks1")).Visible = false;
						}
						else
						{
							((TextBox)di.FindControl("txtIE_Remarks1")).Visible = false;
							((Label)di.FindControl("lblIE_Remarks1")).Visible = true;
						}



						c_remark = Convert.ToString(((TextBox)di.FindControl("txtCO_Remarks1")).Text);
						if (c_remark == "")
						{
							((TextBox)di.FindControl("txtCO_Remarks1")).Visible = true;
							((Label)di.FindControl("lblCO_Remarks1")).Visible = false;
						}
						else
						{
							((TextBox)di.FindControl("txtCO_Remarks1")).Visible = false;
							((Label)di.FindControl("lblCO_Remarks1")).Visible = true;
						}

					}
					else
					{
						((TextBox)di.FindControl("txtCO_Remarks1")).Visible = false;
						((Label)di.FindControl("lblCO_Remarks1")).Visible = false;
						((TextBox)di.FindControl("txtIE_Remarks1")).Visible = false;
						((Label)di.FindControl("lblIE_Remarks1")).Visible = false;
						btnSaveIEAction.Visible = false;
						btnSaveCORemarks.Visible = false;

					}
				}
			}
		}

		protected void btnAddMoreNC_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				conn1.Open();
				OracleCommand cmd1 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				string ss = Convert.ToString(cmd1.ExecuteScalar());
				OracleCommand cmd2 = new OracleCommand("Select max(NC_CD_SNO)+1 from T42_NC_DETAIL where NC_NO='" + lblNC_NO.Text + "'", conn1);
				int nc_sno = Convert.ToInt16(cmd2.ExecuteScalar());
				string myInsertQuery1 = "INSERT INTO T42_NC_DETAIL(NC_NO,NC_CD,NC_CD_SNO,NC_DESC_OTHERS,USER_ID,DATETIME) values('" + lblNC_NO.Text + "','" + lstNCR_Codes.SelectedValue + "'," + nc_sno + ",'" + txtOtherDesc.Text.Trim() + "','" + Session["Uname"].ToString() + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
				OracleCommand myInsertCommand1 = new OracleCommand(myInsertQuery1);
				myInsertCommand1.Connection = conn1;
				myInsertCommand1.ExecuteNonQuery();
				conn1.Close();
				conn1.Dispose();
				txtOtherDesc.Text = "";
				//				lstNCRClass.SelectedIndex=0;
				//				lstNCR_Codes.SelectedIndex=0;
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
			fillgrid();

		}
		void send_email()
		{
			string wRegion = "";

			string rsender = "";
			if (Session["Region"].ToString() == "N") { wRegion = "NORTHERN REGION \n 12th FLOOR,CORE-II,SCOPE MINAR,LAXMI NAGAR, DELHI - 110092 \n Phone : +918800018691-95 \n Fax : 011-22024665"; rsender = "nrinspn@rites.com"; }
			else if (Session["Region"].ToString() == "S") { wRegion = "SOUTHERN REGION \n CTS BUILDING - 2ND FLOOR, BSNL COMPLEX, NO. 16, GREAMS ROAD,  CHENNAI - 600 006 \n Phone : 044-28292807/044- 28292817 \n Fax : 044-28290359"; rsender = "srinspn@rites.com"; }
			else if (Session["Region"].ToString() == "E") { wRegion = "EASTERN REGION \n CENTRAL STATION BUILDING(METRO), 56, C.R. AVENUE,3rd FLOOR,KOLKATA-700 012  \n Fax : 033-22348704"; rsender = "erinspn@rites.com"; }
			else if (Session["Region"].ToString() == "W") { wRegion = "WESTERN REGION \n 5TH FLOOR, REGENT CHAMBER, ABOVE STATUS RESTAURANT,NARIMAN POINT,MUMBAI-400021 \n Phone : 022-68943400/68943445"; rsender = "wrinspn@rites.com"; }
			else if (Session["Region"].ToString() == "C") { wRegion = "Central Region"; }
			DataSet dsP = new DataSet();
			string str3 = "select T41.IC_NO, to_char(T41.IC_DT,'dd/mm/yyyy') IC_DATE,T41.NC_NO,to_char(NC_DT,'dd/mm/yyyy')NC_DT,T41.CASE_NO,T41.BK_NO,T41.SET_NO,T41.PO_NO,to_char(T41.PO_DT,'dd/mm/yyyy') PO_DATE,T41.ITEM_SRNO_PO,T41.ITEM_DESC_PO,T41.IE_CD,T41.USER_ID, T42.NC_CD,T42.IE_ACTION1,CO_FINAL_REMARKS1, NVL2(T42.NC_DESC_OTHERS,T69.NC_DESC||'-'||T42.NC_DESC_OTHERS,T69.NC_DESC) NC_DESC, T69.NC_CLASS,T09.IE_NAME,T08.CO_NAME,T09.IE_EMAIL||';'|| T08.CO_EMAIL EMAIL from T41_NC_MASTER T41, T42_NC_DETAIL T42,T69_NC_CODES T69,T09_IE T09, T08_IE_CONTROLL_OFFICER T08 where T41.NC_NO=T42.NC_NO and T42.NC_CD=T69.NC_CD and T41.IE_CD=T09.IE_CD and T41.CO_CD=T08.CO_CD and T41.NC_NO='" + lblNC_NO.Text.Trim() + "'";
			OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
			OracleCommand myOracleCommand3 = new OracleCommand(str3, conn1);
			conn1.Open();
			da.SelectCommand = myOracleCommand3;
			da.Fill(dsP, "Table");
			string NC_REASONS = "";
			//			string IE_Remarks="";
			//			string CM_Remarks="";
			int j = 0;
			for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
			{
				if (dsP.Tables[0].Rows[i]["NC_CLASS"].ToString() == "C")
				{
					j = 1;
				}
				if (NC_REASONS == "")
				{
					NC_REASONS = NC_REASONS + "IC No. " + dsP.Tables[0].Rows[i]["IC_NO"].ToString() + ", Dated:" + dsP.Tables[0].Rows[i]["IC_DATE"].ToString() + "\n";
					NC_REASONS = NC_REASONS + "Case No. " + dsP.Tables[0].Rows[i]["CASE_NO"].ToString() + "\n";
					NC_REASONS = NC_REASONS + "Item: " + dsP.Tables[0].Rows[i]["ITEM_DESC_PO"].ToString() + "\n";
					NC_REASONS = NC_REASONS + "PO No. " + dsP.Tables[0].Rows[i]["PO_NO"].ToString() + ", Dated:" + dsP.Tables[0].Rows[i]["PO_DATE"].ToString() + "\n";
					NC_REASONS = NC_REASONS + "IE: " + dsP.Tables[0].Rows[i]["IE_NAME"].ToString() + "\n";
					NC_REASONS = NC_REASONS + "CM: " + dsP.Tables[0].Rows[i]["CO_NAME"].ToString() + "\n";
				}

				NC_REASONS = NC_REASONS + "NCR Code:" + dsP.Tables[0].Rows[i]["NC_CD"].ToString() + "-" + dsP.Tables[0].Rows[i]["NC_DESC"].ToString() + "\n";
				if (dsP.Tables[0].Rows[i]["IE_ACTION1"].ToString() != "")
				{
					NC_REASONS = NC_REASONS + "IE Corrective and Preventive Action:" + dsP.Tables[0].Rows[i]["IE_ACTION1"].ToString() + "\n";
				}
				if (dsP.Tables[0].Rows[i]["CO_FINAL_REMARKS1"].ToString() != "")
				{
					NC_REASONS = NC_REASONS + "Controlling Remarks:" + dsP.Tables[0].Rows[i]["CO_FINAL_REMARKS1"].ToString() + "\n";
				}
			}

			OracleCommand cmd2 = new OracleCommand("Select T09.IE_EMAIL||';'|| T08.CO_EMAIL from T09_IE T09, T08_IE_CONTROLL_OFFICER T08 where T09.IE_CO_CD=T08.CO_CD and IE_CD='" + dsP.Tables[0].Rows[0]["IE_CD"].ToString() + "'", conn1);
			string ss = Convert.ToString(cmd2.ExecuteScalar());

			MailMessage mail1 = new MailMessage();
			mail1.To = ss;
			if (j == 1 && Session["Region"].ToString() == "N")
			{
				mail1.Cc = "sbu.ninsp@rites.com";
			}
			//mail1.From=rsender;
			mail1.From = "nrinspn@gmail.com";
			mail1.Subject = "Non Conformities Register";
			mail1.Body = NC_REASONS + "\n" + wRegion;
			mail1.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");   //basic authentication
																										//SmtpMail.SmtpServer= "127.0.0.1";  //your real server goes here
			SmtpMail.SmtpServer = "10.60.50.81";  //your real server goes here
			mail1.Priority = MailPriority.High;
			SmtpMail.Send(mail1);

		}

		protected void btnSend_Click(object sender, System.EventArgs e)
		{
			send_email();
			//			string wRegion="";
			//
			//			string rsender="";
			//			if (Session["Region"].ToString()=="N")  {wRegion="NORTHERN REGION \n 12th FLOOR,CORE-II,SCOPE MINAR,LAXMI NAGAR, DELHI - 110092 \n Phone : +918800018691-95/011-22029110 \n Fax : 011-22024665";rsender="nrinspn@rites.com";}
			//			else if (Session["Region"].ToString()=="S") {wRegion="SOUTHERN REGION \n 758 ANNA SALAI [MOUNT CHAMBER], CHENNAI - 600 002 \n Phone : 044-28523364/044-28524128 \n Fax : 044-28525408";rsender="srinspn@rites.com";}
			//			else if (Session["Region"].ToString()=="E") {wRegion="EASTERN REGION \n CENTRAL STATION BUILDING(METRO), 56, C.R. AVENUE,3rd FLOOR,KOLKATA-700 012  \n Fax : 033-22348704";rsender="erinspn@rites.com";}
			//			else if (Session["Region"].ToString()=="W") {wRegion="WESTERN REGION \n CHURCHGATE STATION BLDG., 2nd FLOOR, M.K ROAD,MUMBAI-400 020 \n Phone : 022-22012523/022-22015573 \n Fax : 022-22081455/022-22016220";rsender="wrinspn@rites.com";}
			//			else if (Session["Region"].ToString()=="C") {wRegion="Central Region";}
			//			DataSet dsP = new DataSet();
			//			string str3="select T41.NC_NO,to_char(NC_DT,'dd/mm/yyyy')NC_DT,T41.CASE_NO,T41.BK_NO,T41.SET_NO,T41.ITEM_SRNO_PO,T41.ITEM_DESC_PO,T41.IE_CD,T41.USER_ID, T42.NC_CD, T69.NC_DESC, T69.NC_CLASS from T41_NC_MASTER T41, T42_NC_DETAIL T42,T69_NC_CODES T69 where T41.NC_NO=T42.NC_NO and T42.NC_CD=T69.NC_CD and T41.NC_NO='"+lblNC_NO.Text.Trim()+"'";
			//			OracleDataAdapter da = new OracleDataAdapter(str3, conn1); 
			//			OracleCommand myOracleCommand3 = new OracleCommand(str3, conn1); 
			//			conn1.Open(); 
			//			da.SelectCommand = myOracleCommand3; 
			//			da.Fill(dsP, "Table"); 
			//			string NC_REASONS="";
			//			int j=0;
			//			for (int i = 0; i <= dsP.Tables [0].Rows.Count - 1; i++) 
			//			{
			//				if(dsP.Tables[0].Rows[i]["NC_CLASS"].ToString()=="C")
			//				{
			//					j=1;
			//				}
			//				NC_REASONS=NC_REASONS+dsP.Tables[0].Rows[i]["NC_CD"].ToString()+"-"+dsP.Tables[0].Rows[i]["NC_DESC"].ToString()+"<BR>";
			//			}
			//
			//			OracleCommand cmd2 =new OracleCommand("Select T09.IE_EMAIL||';'|| T08.CO_EMAIL from T09_IE T09, T08_IE_CONTROLL_OFFICER T08 where T09.IE_CO_CD=T08.CO_CD and IE_CD='"+dsP.Tables[0].Rows[0]["IE_CD"].ToString()+"'",conn1);
			//			string ss=Convert.ToString(cmd2.ExecuteScalar());
			//						
			//			MailMessage mail1 = new MailMessage();
			//			mail1.To = ss;
			//			if(j==1 && Session["Region"].ToString()=="N")
			//			{
			//				mail1.Cc="mukeshrathore@rites.com";
			//			}
			//			mail1.From=rsender;
			//			mail1.Subject ="Non Conformities Register";
			//			mail1.Body = NC_REASONS+"<br>"+wRegion;
			//			mail1.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");	//basic authentication
			//			SmtpMail.SmtpServer= "127.0.0.1";  //your real server goes here
			//			mail1.Priority = MailPriority.High;
			//			SmtpMail.Send(mail1);



		}
		void showOther()
		{
			if (lstNCR_Codes.SelectedItem.Text.Substring(1, 2) == "99")
			{
				txtOtherDesc.Visible = true;
				Label14.Visible = true;
			}
			else
			{
				txtOtherDesc.Visible = false;
				Label14.Visible = false;
			}
		}
		protected void lstNCR_Codes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			showOther();
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("MainForm.aspx");
		}

		protected void rdbAddNCR_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdbNONCR.Checked == true)
			{
				lstNCRClass.Visible = false;
				lstNCR_Codes.Visible = false;
				btnAddMoreNC.Visible = false;
				Label10.Visible = false;
				Label11.Visible = false;
				btnSend.Visible = false;
			}
			else
			{
				lstNCRClass.Visible = true;
				lstNCR_Codes.Visible = true;
				btnAddMoreNC.Visible = true;
				Label10.Visible = true;
				Label11.Visible = true;
				btnSend.Visible = true;
			}
		}
	}
}
