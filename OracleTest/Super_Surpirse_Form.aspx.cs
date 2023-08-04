using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Super_Surpirse_Form
{
	public partial class Super_Surpirse_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		DataSet dsP = null;


		void show1()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			DataSet dsP = new DataSet();
			try
			{
				string str = "select V.VEND_NAME VEND_CD,M.VENDOR MFG,I.IE_NAME,C.IE_CD, P.PO_NO, to_char(P.PO_DT,'dd/mm/yyyy') PO_DT, C.CO_CD from T13_PO_MASTER P,T17_CALL_REGISTER C,T05_VENDOR V, T09_IE I, V05_VENDOR M where P.CASE_NO=C.CASE_NO and P.VEND_CD=V.VEND_CD AND C.IE_CD=I.IE_CD AND C.MFG_CD=M.VEND_CD and C.CASE_NO= '" + txtCaseNo.Text.Trim() + "' and C.CALL_RECV_DT=TO_DATE('" + txtCallDT.Text.Trim() + "','DD/MM/YYYY') AND C.CALL_SNO=" + txtCSNO.Text + " AND C.REGION_CODE='" + Session["Region"].ToString() + "'";
				OracleDataAdapter da = new OracleDataAdapter(str, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					DisplayAlert("Call With Given Case No, Call Dt & Sno does not exists!!!");
					Panel_2.Visible = false;
					Panel_1.Visible = true;
				}
				else
				{
					Panel_2.Visible = true;
					Panel_1.Visible = false;
					lblCaseNo.Text = txtCaseNo.Text;
					lblDtOfReciept.Text = txtCallDT.Text;
					lblCSNO.Text = txtCSNO.Text;
					lblIE.Text = dsP.Tables[0].Rows[0]["IE_NAME"].ToString();
					lblIECD.Text = dsP.Tables[0].Rows[0]["IE_CD"].ToString();
					lblVend.Text = dsP.Tables[0].Rows[0]["VEND_CD"].ToString();
					lblPONO.Text = dsP.Tables[0].Rows[0]["PO_NO"].ToString();
					lblPODT.Text = dsP.Tables[0].Rows[0]["PO_DT"].ToString();
					lblMfg.Text = dsP.Tables[0].Rows[0]["MFG"].ToString();
					lstCO.SelectedValue = dsP.Tables[0].Rows[0]["CO_CD"].ToString();
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
				conn1.Dispose();
			}
		}

		private void fill_lstPoItems()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			lstPoItems.Items.Clear();
			DataSet ds = new DataSet();
			try
			{
				string MySql = "Select t18.ITEM_SRNO_PO,t18.ITEM_DESC_PO From T18_CALL_DETAILS t18,T17_CALL_REGISTER t17 " +
					"Where t17.CASE_NO=t18.CASE_NO and t17.CALL_RECV_DT=t18.CALL_RECV_DT and t17.CALL_SNO=t18.CALL_SNO and " +
					"t17.CASE_NO='" + lblCaseNo.Text + "' and t17.CALL_RECV_DT=TO_DATE('" + lblDtOfReciept.Text + "','dd/mm/yyyy') and t17.CALL_SNO=" + lblCSNO.Text;
				OracleCommand cmd = new OracleCommand(MySql, conn1);
				OracleDataAdapter da = new OracleDataAdapter(cmd);
				ListItem lst;
				//
				lst = new ListItem();
				lst.Value = null;
				lst.Text = null;
				lstPoItems.Items.Add(lst);
				//
				da.SelectCommand = cmd;
				da.Fill(ds, "Table");
				for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
				{
					lst = new ListItem();
					lst.Value = ds.Tables[0].Rows[i]["ITEM_SRNO_PO"].ToString();
					lst.Text = ds.Tables[0].Rows[i]["ITEM_DESC_PO"].ToString();
					lstPoItems.Items.Add(lst);
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
				conn1.Dispose();
			}

		}


		private void fill_lstCO()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{

				lstCO.Items.Clear();
				DataSet ds = new DataSet();
				OracleCommand cmd = new OracleCommand("Select CO_CD,CO_NAME From T08_IE_CONTROLL_OFFICER Where CO_REGION='" + Session["Region"].ToString() + "' Order By CO_NAME", conn1);
				OracleDataAdapter da = new OracleDataAdapter(cmd);
				ListItem lst;
				da.SelectCommand = cmd;
				da.Fill(ds, "Table");
				//
				lst = new ListItem();
				lst.Value = "0";
				lst.Text = " ";
				lstCO.Items.Add(lst);
				//
				for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
				{
					lst = new ListItem();
					lst.Value = ds.Tables[0].Rows[i]["CO_CD"].ToString();
					lst.Text = ds.Tables[0].Rows[i]["CO_NAME"].ToString();
					lstCO.Items.Add(lst);
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
				conn1.Dispose();
			}

		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			OracleCommand MyCmd = new OracleCommand("select to_char(sysdate,'dd/mm/yyyy') from dual", conn1);
			string wDate = Convert.ToString(MyCmd.ExecuteScalar());



			if (!(IsPostBack))
			{
				Panel_1.Visible = true;
				Panel_2.Visible = false;
				Panel_3.Visible = false;
				//txtSupSurDT.Text=wDate;

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

		private string generate_super_surprise_id()
		{
			string wSuper_Surpirse_Id = "";
			try
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

				OracleCommand cmd = new OracleCommand("GENERATE_SUPER_SURPRISE_NO", conn1);
				cmd.CommandType = CommandType.StoredProcedure;
				conn1.Open();

				OracleParameter prm1 = new OracleParameter("IN_REGION_CD", OracleDbType.Char);
				prm1.Direction = ParameterDirection.Input;
				prm1.Value = Session["Region"].ToString();
				cmd.Parameters.Add(prm1);

				OracleParameter prm2 = new OracleParameter("IN_SUPER_SURPRISE_DT", OracleDbType.Char);
				prm2.Direction = ParameterDirection.Input;
				prm2.Value = Convert.ToString(txtSupSurDT.Text.Replace("/", ""));
				cmd.Parameters.Add(prm2);

				OracleParameter prm3 = new OracleParameter("OUT_SUPER_SURPRISE_NO", OracleDbType.Char, 7);
				prm3.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(prm3);

				OracleParameter prm4 = new OracleParameter("OUT_ERR_CD", OracleDbType.Int32);
				prm4.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(prm4);

				cmd.ExecuteNonQuery();

				if (Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value) == -1)
				{
					wSuper_Surpirse_Id = "-1";
				}
				else
				{
					wSuper_Surpirse_Id = Convert.ToString(cmd.Parameters["OUT_SUPER_SURPRISE_NO"].Value);
				}
				conn1.Close();
				return (wSuper_Surpirse_Id);
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
			if (lblSupSurNo.Text.Trim() == "" && txtSupSurDT.Text.Trim() != "")
			{

				string sup_sur_no = generate_super_surprise_id();
				if (sup_sur_no == "-1")
				{
					DisplayAlert("Registration Details not available");
				}
				else
				{
					try
					{
						conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
						conn1.Open();
						OracleCommand MyCmd = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
						string wDate = Convert.ToString(MyCmd.ExecuteScalar());
						string MySql = "";
						//string MyMsg="";
						//
						if (lblSupSurNo.Text == "")
						{
							lblSupSurNo.Text = sup_sur_no;
							MySql = "Insert into T44_SUPER_SURPRISE(SUPER_SURPRISE_NO,SUPER_SURPRISE_DT,CASE_NO,CALL_RECV_DT, CALL_SNO,IE_CD,CO_CD,ITEM_DESC," +
								"DISCREPANCY,OUTCOME,PRE_INT_REJ,NAME_SCOPE_ITEM,USER_ID,DATETIME,SBU_HEAD_REMARKS) " +
								"values " +
								"('" + lblSupSurNo.Text + "',to_date('" + txtSupSurDT.Text + "','dd/mm/yyyy'),'" + lblCaseNo.Text + "',to_date('" + txtCallDT.Text + "','dd/mm/yyyy-HH24:MI:SS')," + lblCSNO.Text + "," + lblIECD.Text + "," + lstCO.SelectedValue +
								",'" + lstPoItems.SelectedItem.Text + "','" + txtDiscrepancy.Text + "','" + txtOutcome.Text + "','" + txtRemarks.Text + "','" + ddlItemScope.SelectedValue + "','" + Session["Uname"] + "',to_date('" + wDate + "','dd/mm/yyyy-HH24:MI:SS'),'" + TextSBUremarks.Text + "')";

						}
						//					else
						//					{
						//						MySql="Update T40_CONSIGNEE_COMPLAINTS "+
						//							"Set IE_CO_CD="+lstCO.SelectedValue+",REJ_MEMO_NO='"+txtMemoNo.Text+"',REJ_MEMO_DT=to_date('"+txtMemoDt.Text+"','dd/mm/yyyy'),ITEM_SRNO_PO="+lblItemSrnoPo.Text+",ITEM_DESC='"+lblItemDesc.Text+"',"+
						//							"QTY_OFFERED="+txtQtyOffered.Text+",QTY_REJECTED="+txtQtyRej.Text+",UOM_CD="+lblUOM.Text+",RATE="+lblRate.Text+",REJECTION_VALUE="+txtValueRej.Text+","+
						//							"REJECTION_REASON='"+txtRejReason.Text+"',USER_ID='"+Session["Uname"]+"',DATETIME=to_date('" +wDate+"','dd/mm/yyyy-HH24:MI:SS') "+
						//							"Where COMPLAINT_ID='"+lblComplaintId.Text+"'";
						//						MyMsg="Record Updated";
						//					}
						//
						OracleCommand cmd = new OracleCommand(MySql, conn1);
						cmd.ExecuteNonQuery();
						DisplayAlert("Record Saved!!!");
						Panel_3.Visible = false;
						btnSave.Enabled = false;
						Label8.Visible = true;
						lblSupSurNo.Visible = true;

					}
					catch (Exception ex)
					{
						string str;
						str = ex.Message;
						string str1 = str.Replace("\n", "");

						if (str1.Substring(0, 9).Equals("ORA-00001"))
						{
							DisplayAlert("Super Surprise already exist for the given call!!!");
						}
						else
						{
							Response.Redirect(("Error_Form.aspx?err=" + str1));
						}
					}
					finally
					{
						conn1.Close();
						conn1.Dispose();
					}
				}
			}
			else
			{
				DisplayAlert("Kindly Enter Super Surprise Date.");
			}
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Panel_1.Visible = false;
			Panel_2.Visible = true;
			fill_lstCO();
			show1();
			fill_lstPoItems();
		}

		protected void btnUpload_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (File1.PostedFile != null && File1.PostedFile.ContentLength > 0)
				{
					String fn = "", fx = "";
					fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
					fx = System.IO.Path.GetExtension(File1.PostedFile.FileName).ToUpper();
					string MyFile = lblSupSurNo.Text;
					if (fx == ".PDF")
					{
						String SaveLocation = null;
						SaveLocation = Server.MapPath("SUPER_SURPRISE/" + MyFile + ".pdf");
						//SaveLocation = Server.MapPath("PO/" + fn);
						//SaveLocation = "//172.16.7.76/madan/"+fn;
						File1.PostedFile.SaveAs(SaveLocation);
						DisplayAlert("The file has been uploaded.");
					}
					else
					{ DisplayAlert("Only pdf files are accepted."); }
				}
				else
				{
					DisplayAlert("Please select a file to upload.");
				}
			}
			catch (FileNotFoundException fe)
			{ Response.Write("File not found" + fe); }
			catch (System.IO.DirectoryNotFoundException de)
			{ Response.Write("Directry not found" + de); }
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				Response.Write(ex);
			}
		}
	}
}