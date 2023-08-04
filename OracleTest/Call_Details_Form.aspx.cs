using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Call_Details_Form
{
	public partial class Call_Details_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		DataSet dsP = new DataSet();
		public string CNO, DT, Action, cstatus, CSNO;
		string ss;
		public string status;

		void show()
		{
			try
			{
				string str1 = "SELECT 'Marked' Status,T18.ITEM_SRNO_PO ITEM_SRNO_PO,T18.ITEM_DESC_PO ITEM_DESC_PO ,T18.QTY_ORDERED,T18.CUM_QTY_PREV_OFFERED,T18.CUM_QTY_PREV_PASSED,T18.QTY_TO_INSP,T18.QTY_PASSED,T18.QTY_REJECTED,T18.QTY_DUE, (T06.CONSIGNEE_CD||'-'||nvl2(trim(T06.CONSIGNEE_DESIG),trim(T06.CONSIGNEE_DESIG)||'/','')||nvl2(trim(T06.CONSIGNEE_DEPT),trim(T06.CONSIGNEE_DEPT)||'/','')||nvl2(trim(T06.CONSIGNEE_FIRM),trim(T06.CONSIGNEE_FIRM)||'/','')||NVL2(trim(T06.CONSIGNEE_ADD1),trim(T06.CONSIGNEE_ADD1)||'/','')||NVL2(trim(T03.LOCATION),trim(T03.LOCATION)||' : '||trim(T03.CITY),trim(T03.CITY))) CONSIGNEE  FROM T18_CALL_DETAILS T18,T06_CONSIGNEE T06, T03_CITY T03  where T18.CONSIGNEE_CD=T06.CONSIGNEE_CD and T06.CONSIGNEE_CITY=T03.CITY_CD and T18.CASE_NO='" + CNO + "' AND T18.CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') AND CALL_SNO=" + CSNO;
				//str1=str1 + " union SELECT 'Available' Status,T15.ITEM_SRNO ITEM_SRNO_PO,T15.ITEM_DESC ITEM_DESC_PO,T15.QTY QTY_ORDERED,(null) CUM_QTY_PREV_OFFERED,(null) CUM_QTY_PREV_PASSED, (null) QTY_TO_INSP,(null) QTY_PASSED,(null) QTY_REJECTED,(null) QTY_DUE  FROM T15_PO_DETAIL T15  where T15.CASE_NO='"+CNO+"'"; 
				str1 = str1 + " union SELECT 'Available' Status,T15.ITEM_SRNO ITEM_SRNO_PO,T15.ITEM_DESC ITEM_DESC_PO,T15.QTY QTY_ORDERED,(0) CUM_QTY_PREV_OFFERED,(0) CUM_QTY_PREV_PASSED, (0) QTY_TO_INSP,(0) QTY_PASSED,(0) QTY_REJECTED,(0) QTY_DUE,(T06.CONSIGNEE_CD||'-'||nvl2(trim(T06.CONSIGNEE_DESIG),trim(T06.CONSIGNEE_DESIG)||'/','')||nvl2(trim(T06.CONSIGNEE_DEPT),trim(T06.CONSIGNEE_DEPT)||'/','')||nvl2(trim(T06.CONSIGNEE_FIRM),trim(T06.CONSIGNEE_FIRM)||'/','')||NVL2(trim(T06.CONSIGNEE_ADD1),trim(T06.CONSIGNEE_ADD1)||'/','')||NVL2(trim(T03.LOCATION),trim(T03.LOCATION)||' : '||trim(T03.CITY),trim(T03.CITY))) CONSIGNEE FROM T15_PO_DETAIL T15,T06_CONSIGNEE T06,T03_CITY T03 where T15.CONSIGNEE_CD=T06.CONSIGNEE_CD and T06.CONSIGNEE_CITY=T03.CITY_CD and T15.CASE_NO='" + CNO + "'";
				str1 = str1 + " and T15.ITEM_SRNO not in (select ITEM_SRNO_PO from T18_CALL_DETAILS  where CASE_NO='" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') AND CALL_SNO=" + CSNO + ") order by Status DESC, ITEM_SRNO_PO";
				//				string str1 = "select CASE_NO, to_char(CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT,ITEM_SRNO_PO,ITEM_DESC_PO,QTY_ORDERED,CUM_QTY_PREV_OFFERED,CUM_QTY_PREV_PASSED,QTY_TO_INSP,QTY_PASSED,QTY_REJECTED,QTY_DUE from T18_CALL_DETAILS where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy')"; 
				//string str1 = "select CASE_NO, TO_CHAR(CALL_RECV_DT,'dd/mm/yy') CALL_RECV_DT,ITEM_SRNO_PO,ITEM_DESC_PO,QTY_INSP from T18_CALL_DETAILS where CASE_NO= '" + CNO + "' and CALL_RECV_DT='"+ DT +"'"; 
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdCDetails.Visible = false;
					Label24.Visible = false;
				}
				else
				{
					grdCDetails.Visible = true;
					Label24.Visible = true;
					grdCDetails.DataSource = dsP;
					grdCDetails.DataBind();
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
			}


		}

		void show1()
		{
			try
			{
				//CSNO=Convert.ToString(Request.Params ["CALL_SNO"].Trim());
				DataSet dsP1 = new DataSet();
				//string str2 = "select ITEM_SRNO_PO,ITEM_DESC_PO,QTY_ORDERED,CUM_QTY_PREV_OFFERED,CUM_QTY_PREV_PASSED,QTY_TO_INSP,QTY_PASSED,QTY_REJECTED,QTY_DUE from T18_CALL_DETAILS where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy') and ITEM_SRNO_PO='" + Action + "'"; 
				string str2 = "select ITEM_SRNO_PO,ITEM_DESC_PO,QTY_ORDERED,CUM_QTY_PREV_OFFERED,CUM_QTY_PREV_PASSED,QTY_TO_INSP from T18_CALL_DETAILS where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') and CALL_SNO=" + CSNO + " and ITEM_SRNO_PO='" + Action + "'";
				OracleDataAdapter da1 = new OracleDataAdapter(str2, conn1);
				OracleCommand myOracleCommand1 = new OracleCommand(str2, conn1);
				conn1.Open();
				da1.SelectCommand = myOracleCommand1;
				da1.Fill(dsP1, "Table");
				txtSerialNo.Text = dsP1.Tables[0].Rows[0]["ITEM_SRNO_PO"].ToString();
				//lstIDesc.SelectedValue= dsP1.Tables[0].Rows[0]["ITEM_SRNO_PO"].ToString(); 
				txtIDesc.Text = dsP1.Tables[0].Rows[0]["ITEM_DESC_PO"].ToString();
				txtQOrd.Text = dsP1.Tables[0].Rows[0]["QTY_ORDERED"].ToString();
				txtCQty.Text = dsP1.Tables[0].Rows[0]["CUM_QTY_PREV_OFFERED"].ToString();
				txtQPrePassed.Text = dsP1.Tables[0].Rows[0]["CUM_QTY_PREV_PASSED"].ToString();
				txtQuanInsp.Text = dsP1.Tables[0].Rows[0]["QTY_TO_INSP"].ToString();
				txtSerialNo.Text = dsP1.Tables[0].Rows[0]["ITEM_SRNO_PO"].ToString();
				//txtQPass.Text=dsP1.Tables[0].Rows[0]["QTY_PASSED"].ToString();
				//txtQRej.Text=dsP1.Tables[0].Rows[0]["QTY_REJECTED"].ToString();
				//txtQtyDue.Text=dsP1.Tables[0].Rows[0]["QTY_DUE"].ToString();
				conn1.Close();
				if (cstatus.Equals("M"))
				{
					btnSave1.Visible = true;
					btnDelete.Visible = true;
				}
				else
				{
					btnSave1.Visible = false;
					btnDelete.Visible = false;
				}

				btnSave.Visible = false;

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

		void show2()
		{
			try
			{
				DataSet dsP2 = new DataSet();
				string str3 = "select ITEM_SRNO, ITEM_DESC,QTY from T15_PO_DETAIL WHERE CASE_NO='" + CNO + "' AND ITEM_SRNO=" + Action + " order by ITEM_SRNO ";
				OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP2, "Table");
				txtIDesc.Text = dsP2.Tables[0].Rows[0]["ITEM_DESC"].ToString();
				txtSerialNo.Text = dsP2.Tables[0].Rows[0]["ITEM_SRNO"].ToString();
				txtQOrd.Text = dsP2.Tables[0].Rows[0]["QTY"].ToString();
				conn1.Close();
				if (cstatus.Equals("M"))
				{
					btnSave.Visible = true;
				}
				else
				{
					btnSave.Visible = false;
				}
				btnSave1.Visible = false;
				btnDelete.Visible = false;
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
		void checkDP()
		{
			DataSet dsP2 = new DataSet();
			string str3 = "select  to_char(NVL(NVL2(EXT_DELV_DT,EXT_DELV_DT,DELV_DT),to_date('01/01/0001','dd/mm/yyyy')),'YYYYMMDD') from T15_PO_DETAIL WHERE CASE_NO='" + CNO + "' AND ITEM_SRNO=" + Action + " order by ITEM_SRNO ";
			//OracleDataAdapter da = new OracleDataAdapter(str3, conn1); 
			OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
			conn1.Open();
			//da.SelectCommand = myOracleCommand; 
			string dp = Convert.ToString(myOracleCommand.ExecuteScalar());
			//da.Fill(dsP2, "Table"); 
			conn1.Close();
			if (dp.Equals("00010101") != true)
			{
				string myYear, myMonth, myDay;
				myYear = DT.Substring(6, 4);
				myMonth = DT.Substring(3, 2);
				myDay = DT.Substring(0, 2);
				string call_dt = myYear + myMonth + myDay;

				if (dp.CompareTo(call_dt) < 0)
				{
					DisplayAlert1("The Delivery Period for the Item has been Expired!!!");
				}
			}

		}

		private void DisplayAlert1(string msg)
		{
			msg = msg + " Do You Still Want to Register This Call?";
			Response.Write("<script language=JavaScript> var d=confirm('" + msg + "'); if(d==false) location.href='/RBS/Call_Register_Edit.aspx';</script>");
		}

		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnSave1.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelete.Attributes.Add("OnClick", "JavaScript:del();");
			if (Convert.ToString(Request.Params["Case_No"].Trim()) == null || Convert.ToString(Request.Params["DT_RECIEPT"].Trim()) == null)
			{
				CNO = "";
				DT = "";


			}
			else
			{
				CNO = Convert.ToString(Request.Params["Case_No"].Trim());
				DT = Convert.ToString(Request.Params["DT_RECIEPT"].Trim());
				CSNO = Convert.ToString(Request.Params["CALL_SNO"].Trim());
				cstatus = Convert.ToString(Request.Params["cstatus"].Trim());
				if (Request.QueryString["Serial_No"] != null)
				{
					Action = Convert.ToString(Request.Params["Serial_No"].Trim());
					if (Convert.ToString(Request.Params["status"].Trim()).Equals("Marked"))
					{
						status = Convert.ToString(Request.Params["status"].Trim());

					}
					else if (Convert.ToString(Request.Params["status"].Trim()).Equals("Available"))
					{
						status = Convert.ToString(Request.Params["status"].Trim());
					}

				}
			}



			if (!(IsPostBack))
			{


				if (Convert.ToString(Request.Params["Case_No"].Trim()) == null || Convert.ToString(Request.Params["DT_RECIEPT"].Trim()) == null)
				{
					CNO = "";
					DT = "";


				}
				else
				{
					if (Request.QueryString["Serial_No"] == null)
					{
						show();
						btnSave1.Visible = false;
						btnSave.Visible = false;
						btnDelete.Visible = false;

					}
					else
					{

						if (Convert.ToString(Request.Params["status"].Trim()).Equals("Marked"))
						{

							checkDP();
							show1();

						}
						else if (Convert.ToString(Request.Params["status"].Trim()).Equals("Available"))
						{
							checkDP();
							show2();
						}
						show();
						rbs.SetFocus(txtCQty);
						if (Session["Role_CD"].ToString() == "4")
						{
							btnSave.Visible = false;
							btnSave1.Visible = false;
							btnDelete.Visible = false;


						}
					}

					conn1.Open();
					OracleCommand cmdIE = new OracleCommand("Select IE_SNAME from T09_IE T09, T17_CALL_REGISTER T17 where T17.IE_CD=T09.IE_CD and T17.CASE_NO= '" + CNO + "' and T17.CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') and T17.CALL_SNO=" + CSNO, conn1);
					lblIE.Text = Convert.ToString(cmdIE.ExecuteScalar());
					conn1.Close();

					string str3 = "select PO_NO,to_char(PO_DT,'dd/mm/yyyy') PO_DT from T13_PO_MASTER where CASE_NO= '" + CNO + "'";
					OracleCommand myOracleCommand3 = new OracleCommand(str3, conn1);
					conn1.Open();
					OracleDataReader reader = myOracleCommand3.ExecuteReader();
					while (reader.Read())
					{
						lblPONO.Text = reader["PO_NO"].ToString();
						lblPODT.Text = reader["PO_DT"].ToString();
					}
					reader.Close();
					conn1.Close();
				}
				//				DataSet dsP2 = new DataSet(); 
				//				string str3 = "select ITEM_SRNO, ITEM_DESC from T15_PO_DETAIL WHERE CASE_NO='"+CNO+"' order by ITEM_DESC "; 
				//				OracleDataAdapter da = new OracleDataAdapter(str3, conn1); 
				//				OracleCommand myOracleCommand = new OracleCommand(str3, conn1); 
				//				//ListItem lst; 
				//				conn1.Open(); 
				//				da.SelectCommand = myOracleCommand; 
				//				da.Fill(dsP2, "Table"); 
				//				for (int i = 0; i <= dsP2.Tables[0].Rows.Count - 1; i++) 
				//				{ 
				//					//lst = new ListItem(); 
				//					//lst.Text = dsP2.Tables[0].Rows[i]["ITEM_DESC"].ToString(); 
				//					//lst.Value = dsP2.Tables[0].Rows[i]["ITEM_SRNO"].ToString(); 
				//					//lstIDesc.Items.Add(lst); 
				//					OracleCommand cmd = new OracleCommand("Select ITEM_SRNO_PO from T18_CALL_DETAILS where CASE_NO='"+CNO+"' and CALL_RECV_DT=to_date('"+DT+"','dd/mm/yyyy') and ITEM_SRNO_PO="+dsP2.Tables[0].Rows[i]["ITEM_SRNO"].ToString()+"", conn1); 
				//					string ii=Convert.ToString(cmd.ExecuteScalar());
				//					if(ii=="")
				//					{
				//						this.lstItems.Items.Add(new ListItem(dsP2.Tables[0].Rows[i]["ITEM_DESC"].ToString(),dsP2.Tables[0].Rows[i]["ITEM_SRNO"].ToString()));
				//					}
				//					
				//				} 
				//				//lstIDesc.Items.Insert(0,"");
				//				lstItems.Enabled=true;
				//				conn1.Close(); 

				//				if(Action!=null)
				//				{
				////					if(DT==null||DT=="")
				////					{
				////						show2();
				////					}
				////					else
				////					{
				////						show1();
				////					}
				//					btnDelete.Visible =true;
				//					btnAdd.Visible=true;
				//					//lstItems.Enabled=false;
				//					btnSave1.Visible=true;
				//					btnSave.Visible=false;
				//					if(status=="M")
				//					{
				//						
				//						btnSave1.Enabled=true;
				//						btnDelete.Enabled=true;
				//						btnAdd.Enabled=true;
				//					}
				//					else
				//					{
				//						btnSave1.Enabled=false;
				//						btnDelete.Enabled=false;
				//						btnAdd.Enabled=false;
				//					}
				//					conn1.Close();
				//				}
				//				else
				//				{
				//					btnDelete.Visible =false;
				//					btnAdd.Visible=false;
				//					btnSave1.Visible=false;
				//					btnSave.Visible=true;
				//					if(status=="M")
				//					{
				//						
				//						btnSave.Enabled=true;
				//						//btnDelete.Enabled=true;
				//					}
				//					else
				//					{
				//						btnSave.Enabled=false;
				//						//btnDelete.Enabled=false;
				//					}
				//					
				//				}
				//				//show();
			}


			//txtCaseNo.Visible=false;
			//Label13.Text=CNO;
			//txtCaseNo.Enabled =false;

			//txtDtOfReciept.Visible=false;
			//Label14.Text=DT;
			//txtDtOfReciept.Enabled =false;

			//				grdCDetails.DataSource=this.show();
			//				grdCDetails.DataBinding();
			txtDtOfReciept.Text = DT;
			txtCaseNo.Text = CNO;
			lblCSNO.Text = CSNO;

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
			this.grdCDetails.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grdCDetails_ItemDataBound);

		}
		#endregion

		void check()
		{
			if (txtQOrd.Text == "")
			{
				txtQOrd.Text = "null";
			}
			if (txtCQty.Text == "")
			{
				txtCQty.Text = "null";
			}
			if (txtQPrePassed.Text == "")
			{
				txtQPrePassed.Text = "null";
			}
			if (txtQuanInsp.Text == "")
			{
				txtQuanInsp.Text = "null";
			}
			//			if (txtQPass.Text=="")
			//			{
			//				txtQPass.Text= "null";
			//			}
			//			if(txtQRej.Text=="")
			//			{
			//				txtQRej.Text= "null";
			//			}
			//			if(txtQtyDue.Text=="")
			//			{
			//				txtQtyDue.Text= "null";
			//			}

		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{

				string str3 = "select CASE_NO from T18_CALL_DETAILS where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') and CALL_SNO=" + CSNO + " and ITEM_SRNO_PO='" + txtSerialNo.Text + "'";
				OracleCommand myCommand = new OracleCommand();
				myCommand.CommandText = str3;
				myCommand.Connection = conn1;
				conn1.Open();
				string CD = Convert.ToString(myCommand.ExecuteScalar());
				check();
				if (CD == "" || CD == null)
				{
					int status = 0;
					//OracleCommand cmd3 =new OracleCommand("Select NVL(Sum(NVL(QTY_TO_INSP,0)),0) from T18_CALL_DETAILS where CASE_NO= '" + txtCaseNo.Text + "' and CALL_RECV_DT!=to_date('"+ txtDtOfReciept.Text +"','dd/mm/yyyy') AND ITEM_SRNO_PO='" + txtSerialNo.Text + "'",conn1);
					//OracleCommand cmd3 =new OracleCommand("Select NVL(Sum(NVL(QTY_TO_INSP,0)),0) from T18_CALL_DETAILS where CASE_NO= '" + txtCaseNo.Text + "' AND ITEM_SRNO_PO='" + txtSerialNo.Text + "'",conn1);
					OracleCommand cmd3 = new OracleCommand("Select NVL(sum(NVL(D.QTY_TO_INSP,0)),0) from T17_CALL_REGISTER R,T18_CALL_DETAILS D where R.CASE_NO=D.CASE_NO and R.CALL_RECV_DT=D.CALL_RECV_DT and R.CALL_SNO=D.CALL_SNO and R.CASE_NO= '" + CNO + "' AND D.ITEM_SRNO_PO='" + txtSerialNo.Text + "' and R.CALL_STATUS not in('R','C')", conn1);
					//conn1.Open();
					decimal reader = Convert.ToDecimal(cmd3.ExecuteScalar());
					if (reader > 0)
					{

						decimal qty = 0;
						qty = reader + Convert.ToDecimal(txtQuanInsp.Text);
						if (reader > Convert.ToDecimal(txtQOrd.Text))
						{
							status = 2;
						}
						else
						{
							if (qty > Convert.ToDecimal(txtQOrd.Text))
							{
								status = 1;
							}
						}

					}

					//							if(status!=2)
					//							{
					if (status == 1)
					{
						DisplayAlert("Their are Other Calls Present For this Case No. and Item. So,Total Qty Offered in all the Calls  is Exceeding Qty Ordered in PO for the Given Case No.!!!");
					}
					//							else
					//							{
					OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
					ss = Convert.ToString(cmd2.ExecuteScalar());

					string str = "Select CONSIGNEE_CD from T15_PO_DETAIL WHERE CASE_NO='" + txtCaseNo.Text + "' AND ITEM_SRNO=" + txtSerialNo.Text;
					OracleCommand cmd = new OracleCommand(str, conn1);
					long ccd = Convert.ToInt64(cmd.ExecuteScalar());
					//string myInsertQuery = "INSERT INTO T18_CALL_DETAILS values('" + txtCaseNo.Text + "', to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy')," + txtSerialNo.Text + ", '" + txtIDesc.Text  + "'," + txtQOrd.Text + "," + txtCQty.Text + "," + txtQPrePassed.Text + "," + txtQuanInsp.Text + ","+txtQPass.Text +","+txtQRej.Text +","+ txtQtyDue.Text +",'"+Session["Uname"]+"', to_date('" +ss+ "','dd/mm/yyyy-HH24:MI:SS'))"; 
					string myInsertQuery = "INSERT INTO T18_CALL_DETAILS values('" + txtCaseNo.Text + "', to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy')," + lblCSNO.Text + "," + txtSerialNo.Text + ", upper('" + txtIDesc.Text + "')," + ccd + "," + txtQOrd.Text + "," + txtCQty.Text + "," + txtQPrePassed.Text + "," + txtQuanInsp.Text + ",'" + null + "','" + null + "','" + null + "','" + Session["Uname"] + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
					OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
					myInsertCommand.Connection = conn1;
					myInsertCommand.ExecuteNonQuery();

					string myUpdateQuery1 = "Update T15_PO_DETAIL set ITEM_DESC =upper('" + txtIDesc.Text + "') where CASE_NO= '" + CNO + "' AND ITEM_SRNO=" + txtSerialNo.Text;
					OracleCommand myUpdateCommand1 = new OracleCommand(myUpdateQuery1);
					myUpdateCommand1.Connection = conn1;
					myUpdateCommand1.ExecuteNonQuery();

					conn1.Close();
					//this.lstItems.Items.Remove(new ListItem(txtIDesc.Text,txtSerialNo.Text));
					//DisplayAlert("Your Record has been Saved!!!");
					btnSave.Visible = false;
					btnSave1.Visible = true;
					//							}
					//							}
					//							else if(status==2)
					//							{
					//							DisplayAlert("Your Record cannot be saved because Total Qty Passed in the previous Calls  is already Exceeding Qty Ordered in PO for the Given Case No.!!!");
					//							}
				}

				else
				{
					DisplayAlert("Record Already Present For the Given Case No,Call Recv Date, Call SNo. and Item Serial No.");
				}

				Action = txtSerialNo.Text;

				//txtSerialNo.Text="";
				//txtItemDesc.Text="";
				//txtQuanInsp.Text="";
				//txtQPass.Text="";
				//txtQRej.Text="";
				//txtQOrd.Text="";
				//txtCQty.Text="";
				//txtQPrePassed.Text="";
				//txtQtyDue.Text="";



				//				grdCDetails.DataSource=this.show();
				//				grdCDetails.DataBinding();
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
			show();
		}

		private void grdCDetails_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{

			//			if(e.Item.ItemType!=ListItemType.Header && e.Item.ItemType!=ListItemType.Footer)
			//			{
			//				LinkButton btn=(LinkButton)e.Item.Cells[0].Controls[0];
			//				btn.Attributes.Add("onclick","return confirm('Are you sure to delete  ?')");
			//			}
		}

		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				string myDeleteQuery = "Delete T18_CALL_DETAILS where CASE_NO= '" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') AND CALL_SNO=" + lblCSNO.Text + " and ITEM_SRNO_PO='" + txtSerialNo.Text + "'";
				OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
				myOracleCommand.Connection = conn1;
				conn1.Open();
				myOracleCommand.ExecuteNonQuery();
				conn1.Close();
				//this.lstItems.Items.Add(new ListItem(txtIDesc.Text,txtSerialNo.Text));
				//show();
				txtSerialNo.Text = "";
				txtIDesc.Text = "";
				txtQuanInsp.Text = "";
				txtQOrd.Text = "";
				txtCQty.Text = "";
				txtQPrePassed.Text = "";
				DisplayAlert("Your Record has been Deleted!!!");
				btnDelete.Visible = false;
				btnSave1.Visible = false;
				//txtQtyDue.Text="";

			}

			catch (Exception ex)
			{
				string str;
				str = ex.Message;
			}
			finally
			{
				conn1.Close();
			}
			show();
			//string popupScript = "<script language='javascript'>" + "window.open('PopUp.aspx?str=Your Record Has Been Deleted!!!" + txtSerialNo.Text + "', 'CustomPopUp', " + "'width=330, height=120, menubar=no, resizable=no')" + "</script>";
			//Page.RegisterStartupScript("PopupScript", popupScript);


		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			//Response.Redirect("Call_Register_Edit.aspx");
			Response.Redirect("Call_Register_Form.aspx?Action=M&Case_No=" + txtCaseNo.Text.Trim() + "&DT_RECIEPT=" + txtDtOfReciept.Text.Trim() + "&CALL_SNO=" + lblCSNO.Text.Trim());
		}





		protected void btnSave1_Click(object sender, System.EventArgs e)
		{
			try
			{
				int status = 0;
				//OracleCommand cmd3 =new OracleCommand("Select NVL(sum(NVL(QTY_TO_INSP,0)),0) from T18_CALL_DETAILS where CASE_NO= '" + CNO + "' AND ITEM_SRNO_PO='" + txtSerialNo.Text + "'",conn1);
				OracleCommand cmd3 = new OracleCommand("Select NVL(sum(NVL(D.QTY_TO_INSP,0)),0) from T17_CALL_REGISTER R,T18_CALL_DETAILS D where R.CASE_NO=D.CASE_NO and R.CALL_RECV_DT=D.CALL_RECV_DT and R.CALL_SNO=D.CALL_SNO and R.CASE_NO= '" + CNO + "' AND D.ITEM_SRNO_PO='" + txtSerialNo.Text + "' and R.CALL_STATUS not in('R','C')", conn1);
				conn1.Open();
				decimal reader = Convert.ToDecimal(cmd3.ExecuteScalar());
				if (reader > 0)
				{
					decimal qty = 0;
					qty = reader + Convert.ToDecimal(txtQuanInsp.Text);
					if (reader > Convert.ToDecimal(txtQOrd.Text))
					{
						status = 2;
					}
					else
					{
						if (qty > Convert.ToDecimal(txtQOrd.Text))
						{
							status = 1;
						}
					}
				}

				//				if (status!=2)
				//				{
				if (status == 1)
				{
					DisplayAlert("Their are Other Calls Present For this Case No. and Item. So,Total Qty Offered in all the Calls  is Exceeding Qty Ordered in PO for the Given Case No.!!!");
				}
				//					else if(status==2)
				//					{
				//						DisplayAlert("Total Qty To Inspected in the previous Calls  is already Exceeding Qty Ordered in PO for the Given Case No.!!!");
				//					}
				//				else
				//				{
				check();

				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);

				ss = Convert.ToString(cmd2.ExecuteScalar());
				//string myUpdateQuery = "Update T18_CALL_DETAILS set ITEM_DESC_PO ='" + txtIDesc.Text + "', QTY_ORDERED="+ txtQOrd.Text +",CUM_QTY_PREV_OFFERED="+ txtCQty.Text +",CUM_QTY_PREV_PASSED="+ txtQPrePassed.Text +",QTY_TO_INSP =" + txtQuanInsp.Text + ",QTY_PASSED="+ txtQPass.Text +", QTY_REJECTED="+ txtQRej.Text +",QTY_DUE="+ txtQtyDue.Text +",USER_ID='"+Session["UName"] +"', DATETIME=to_date('" +ss+ "','dd/mm/yyyy-HH24:MI:SS') where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy') and ITEM_SRNO_PO='" + txtSerialNo.Text + "'"; 
				string myUpdateQuery = "Update T18_CALL_DETAILS set ITEM_DESC_PO =upper('" + txtIDesc.Text + "'), QTY_ORDERED=" + txtQOrd.Text + ",CUM_QTY_PREV_OFFERED=" + txtCQty.Text + ",CUM_QTY_PREV_PASSED=" + txtQPrePassed.Text + ",QTY_TO_INSP =" + txtQuanInsp.Text + ",USER_ID='" + Session["UName"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') and CALL_SNO=" + lblCSNO.Text + " and ITEM_SRNO_PO='" + txtSerialNo.Text + "'";
				OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
				myUpdateCommand.Connection = conn1;
				myUpdateCommand.ExecuteNonQuery();

				string myUpdateQuery1 = "Update T15_PO_DETAIL set ITEM_DESC =upper('" + txtIDesc.Text + "') where CASE_NO= '" + CNO + "' and ITEM_SRNO='" + txtSerialNo.Text + "'";
				OracleCommand myUpdateCommand1 = new OracleCommand(myUpdateQuery1);
				myUpdateCommand1.Connection = conn1;
				myUpdateCommand1.ExecuteNonQuery();

				//				}
				//				}


				//DisplayAlert("Your Record has been Updated!!!");
				conn1.Close();

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
			}
			finally
			{
				conn1.Close();
			}
			show();
		}

		//		private void lstItems_SelectedIndexChanged(object sender, System.EventArgs e)
		//		{
		//			DataSet dsP2 = new DataSet(); 
		//			string str3 = "select ITEM_SRNO, ITEM_DESC,QTY from T15_PO_DETAIL WHERE CASE_NO='"+CNO+"' AND ITEM_SRNO="+lstItems.SelectedValue+" order by ITEM_SRNO "; 
		//			OracleDataAdapter da = new OracleDataAdapter(str3, conn1); 
		//			OracleCommand myOracleCommand = new OracleCommand(str3, conn1); 
		//			conn1.Open(); 
		//			da.SelectCommand = myOracleCommand; 
		//			da.Fill(dsP2, "Table"); 
		//			txtIDesc.Text = dsP2.Tables[0].Rows[0]["ITEM_DESC"].ToString(); 
		//			txtSerialNo.Text = dsP2.Tables[0].Rows[0]["ITEM_SRNO"].ToString(); 
		//			txtQOrd.Text=dsP2.Tables[0].Rows[0]["QTY"].ToString(); 
		//			conn1.Close(); 
		//		}

		private void txtIDesc_TextChanged(object sender, System.EventArgs e)
		{

		}







	}
}