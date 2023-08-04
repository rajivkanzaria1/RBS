using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Call_Cancellation_Form
{
	public partial class Call_Cancellation_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		DataSet dsP = new DataSet();
		string CNO, DT, CSNO, Action;

		void show1()
		{
			DataSet dsP4 = new DataSet();
			string str5 = "select P.PO_NO, to_char(P.PO_DT,'dd/mm/yyyy')PO_DT,V.VEND_NAME from T13_PO_MASTER P,T05_VENDOR V where P.VEND_CD=V.VEND_CD and CASE_NO= '" + CNO + "'";
			conn1.Open();
			OracleDataAdapter da4 = new OracleDataAdapter(str5, conn1);
			OracleCommand myOracleCommand4 = new OracleCommand(str5, conn1);
			da4.SelectCommand = myOracleCommand4;
			da4.Fill(dsP4, "Table");
			if (dsP4.Tables[0].Rows.Count == 0)
			{
				lblPONo1.Visible = false;
				lblPODate1.Visible = false;
				lblVendor1.Visible = false;
				//lblIEng1.Visible=false;
			}
			else
			{
				lblPONo1.Visible = true;
				lblPODate1.Visible = true;
				lblVendor1.Visible = true;
				//lblIEng1.Visible=true;
				lblPONo1.Text = dsP4.Tables[0].Rows[0]["PO_NO"].ToString();
				lblPODate1.Text = dsP4.Tables[0].Rows[0]["PO_DT"].ToString();
				lblVendor1.Text = dsP4.Tables[0].Rows[0]["VEND_NAME"].ToString();
				//lblIEng1.Text=dsP4.Tables[0].Rows[0]["PO_DT"].ToString();
			}
			conn1.Close();
			string str4 = "select I.IE_SNAME from T17_CALL_REGISTER C,T09_IE I where C.IE_CD=I.IE_CD and C.CASE_NO= '" + CNO + "' and C.CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') AND C.CALL_SNO=" + CSNO;
			OracleCommand myCommand1 = new OracleCommand();
			myCommand1.CommandText = str4;
			myCommand1.Connection = conn1;
			conn1.Open();
			string CS = Convert.ToString(myCommand1.ExecuteScalar());
			conn1.Close();
			lblIEng1.Text = CS;
		}

		void show()
		{
			DataSet dsP1 = new DataSet();
			string str2 = "select T19.CASE_NO,to_char(T19.CALL_RECV_DT,'dd/mm/yyyy')CALL_RECV_DT,T19.CALL_SNO,T19.CANCEL_CD_1,T19.CANCEL_CD_2,T19.CANCEL_CD_3,T19.CANCEL_CD_4,T19.CANCEL_CD_5,T19.CANCEL_CD_6,T19.CANCEL_CD_7,T19.CANCEL_CD_8,T19.CANCEL_CD_9,T19.CANCEL_CD_10,T19.CANCEL_CD_11,T19.CANCEL_DESC,to_char(T19.CANCEL_DATE,'dd/mm/yyyy')CANCEL_DATE,NVL(T19.DOCS_SUBMITTED,'')DOCS_SUBMITTED, NVL(T17.CALL_CANCEL_STATUS,'') CALL_CANCEL_STATUS from T19_CALL_CANCEL T19,T17_CALL_REGISTER T17 where T19.CASE_NO=T17.CASE_NO and T19.CALL_SNO=T17.CALL_SNO and T19.CALL_RECV_DT=T17.CALL_RECV_DT and T19.CASE_NO= '" + CNO + "' and T19.CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') AND T19.CALL_SNO=" + CSNO;
			conn1.Open();
			OracleDataAdapter da1 = new OracleDataAdapter(str2, conn1);
			OracleCommand myOracleCommand1 = new OracleCommand(str2, conn1);
			da1.SelectCommand = myOracleCommand1;
			da1.Fill(dsP1, "Table");
			conn1.Close();
			if (dsP1.Tables[0].Rows.Count == 0)
			{
				DisplayAlert("No Record Found For the Given CASE_NO, CALL_RECV_DT and CALL_SNO");

			}
			else
			{
				txtCdesc.Text = dsP1.Tables[0].Rows[0]["CANCEL_DESC"].ToString();
				txtCCancelDT.Text = dsP1.Tables[0].Rows[0]["CANCEL_DATE"].ToString();
				lblCCancelDT.Text = dsP1.Tables[0].Rows[0]["CANCEL_DATE"].ToString();
				lstDocRec.SelectedValue = dsP1.Tables[0].Rows[0]["DOCS_SUBMITTED"].ToString();
				//				string str4 = "select I.IE_SNAME from T17_CALL_REGISTER C,T09_IE I where C.IE_CD=I.IE_CD and C.CASE_NO= '" + CNO + "' and C.CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy') AND C.CALL_SNO="+CSNO;  
				//				OracleCommand myCommand1 = new OracleCommand();
				//				myCommand1.CommandText = str4;
				//				myCommand1.Connection = conn1;
				//				conn1.Open();
				//				string CS = Convert.ToString(myCommand1.ExecuteScalar());
				//				conn1.Close();
				txtCaseNo.Text = CNO;
				txtDtOfReciept.Text = DT;
				lblCSNO.Text = CSNO;
				lstCallCancelStatus.SelectedValue = dsP1.Tables[0].Rows[0]["CALL_CANCEL_STATUS"].ToString();
				//lblIEng1.Text=CS;

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
			show1();
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
		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			//CCd=Convert.ToInt32(Request.Params["CCD"]);
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
				Action = Convert.ToString(Request.Params["Action"].Trim());

			}
			if (!(IsPostBack))
			{
				ListItem lst1 = new ListItem();
				lst1 = new ListItem();
				lst1.Text = "Yes";
				lst1.Value = "Y";
				lstDocRec.Items.Add(lst1);
				lst1 = new ListItem();
				lst1.Text = "No";
				lst1.Value = "";
				lstDocRec.Items.Add(lst1);

				try
				{
					if (Action == "A")
					{
						show1();
						btnDelete.Visible = false;
						txtCaseNo.Text = CNO;
						txtDtOfReciept.Text = DT;
						lblCSNO.Text = CSNO;
						lstDocRec.SelectedValue = "";
						txtCCancelDT.Visible = true;
						lblCCancelDT.Visible = false;
						//fillgrid();
					}
					else if (Action == "M")
					{

						show();
						btnDelete.Visible = true;
						txtCCancelDT.Visible = false;
						lblCCancelDT.Visible = true;
						//fillgrid();
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
				if (Session["Role"].ToString() == "General User")
				{
					btnSave.Enabled = false;
					btnDelete.Enabled = false;
				}
			}
		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
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

		//		public void fillgrid()
		//		{
		//			OracleDataAdapter dadpt;
		//			dadpt = new OracleDataAdapter("Select CASE_NO,to_char(CALL_RECV_DT,'dd/mm/yyyy')CALL_RECV_DT,CALL_SNO,CANCEL_DESC FROM T19_CALL_CANCEL where substr(CASE_NO,1,1)='"+Session["Region"]+"'",conn1); 
		//			conn1.Open();
		//			DataSet ds=new DataSet();
		//			dadpt.Fill(ds,"Table");
		//			dgCallCancellation.DataSource=ds;
		//			dgCallCancellation.DataBind();
		//			conn1.Close();
		//		}


		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
			string wCDT = Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();


			try
			{
				conn1.Open();
				OracleCommand myCommand = new OracleCommand("select CASE_NO from T20_IC where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') AND CALL_SNO=" + CSNO, conn1);
				string CCd = Convert.ToString(myCommand.ExecuteScalar());
				conn1.Close();
				if (CCd == "")
				{
					int[] chk1 = reasons();

					if (Action == "A")
					{

						string myInsertQuery = "INSERT INTO T19_CALL_CANCEL values('" + txtCaseNo.Text + "', to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy'), " + CSNO + "," + chk1[0] + "," + chk1[1] + "," + chk1[2] + "," + chk1[3] + "," + chk1[4] + "," + chk1[5] + "," + chk1[6] + "," + chk1[7] + "," + chk1[8] + "," + chk1[9] + "," + chk1[10] + ", '" + txtCdesc.Text + "',to_date('" + txtCCancelDT.Text + "','dd/mm/yyyy'),'" + Session["Uname"] + "',to_date('" + wCDT + "','dd/mm/yyyy-HH24:MI:SS'),'" + lstDocRec.SelectedValue + "')";
						OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
						myInsertCommand.Connection = conn1;
						conn1.Open();
						myInsertCommand.ExecuteNonQuery();
						conn1.Close();
						btnDelete.Visible = true;
						DisplayAlert("Your Record is Saved!!!");

					}
					else if (Action == "M")
					{
						string myUpdateQuery = "Update T19_CALL_CANCEL set CANCEL_CD_1=" + chk1[0] + ",CANCEL_CD_2=" + chk1[1] + ",CANCEL_CD_3=" + chk1[2] + ",CANCEL_CD_4=" + chk1[3] + ",CANCEL_CD_5=" + chk1[4] + ",CANCEL_CD_6=" + chk1[5] + ",CANCEL_CD_7=" + chk1[6] + ",CANCEL_CD_8=" + chk1[7] + ",CANCEL_CD_9=" + chk1[8] + ",CANCEL_CD_10=" + chk1[9] + ",CANCEL_CD_11=" + chk1[10] + ",CANCEL_DESC ='" + txtCdesc.Text + "',USER_ID='" + Session["Uname"] + "',DATETIME=to_date('" + wCDT + "','dd/mm/yyyy-HH24:MI:SS'),DOCS_SUBMITTED='" + lstDocRec.SelectedValue + "' where CASE_NO='" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CALL_SNO=" + lblCSNO.Text;
						OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
						myUpdateCommand.Connection = conn1;
						conn1.Open();
						myUpdateCommand.ExecuteNonQuery();
						conn1.Close();
						btnDelete.Visible = true;
						conn1.Close();
						DisplayAlert("Your Record is Modified!!!");
					}

					string myUpdateQuery1 = "Update T17_CALL_REGISTER set CALL_STATUS='C', CALL_CANCEL_STATUS='" + lstCallCancelStatus.SelectedValue + "' where CASE_NO='" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CALL_SNO=" + lblCSNO.Text;
					OracleCommand myUpdateCommand1 = new OracleCommand(myUpdateQuery1);
					myUpdateCommand1.Connection = conn1;
					conn1.Open();
					myUpdateCommand1.ExecuteNonQuery();
					conn1.Close();
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
				conn1.Close();
			}
		}


		//		private void grdCDetails_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		//		{
		//			if(e.Item.ItemType!=ListItemType.Header && e.Item.ItemType!=ListItemType.Footer)
		//			{
		//				LinkButton btn=(LinkButton)e.Item.Cells[0].Controls[0];
		//				btn.Attributes.Add("onclick","return confirm('Are you sure to delete?')");
		//			}
		//		}

		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				string myDeleteQuery = "Delete T19_CALL_CANCEL where CASE_NO= '" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') AND CALL_SNO=" + lblCSNO.Text;
				OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
				myOracleCommand.Connection = conn1;
				conn1.Open();
				myOracleCommand.ExecuteNonQuery();
				conn1.Close();
				txtCdesc.Text = "";
				DisplayAlert("Your Record Has Been Deleted!!!");
				string myUpdateQuery1 = "Update T17_CALL_REGISTER set CALL_STATUS='M' where CASE_NO='" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CALL_SNO=" + lblCSNO.Text;
				OracleCommand myUpdateCommand1 = new OracleCommand(myUpdateQuery1);
				myUpdateCommand1.Connection = conn1;
				conn1.Open();
				myUpdateCommand1.ExecuteNonQuery();
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
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Call_Register_Edit.aspx");
		}

		private void lstCan_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//txtCdesc.Text=lstCan.SelectedItem.Text;
		}
	}
}