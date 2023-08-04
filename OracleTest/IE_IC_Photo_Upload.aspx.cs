using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.IE_IC_Photo_Upload
{
	public partial class IE_IC_Photo_Upload : System.Web.UI.Page
	{
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);


		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			if (Convert.ToString(Request.Params["CASE_NO"]) == null || Convert.ToString(Request.Params["CALL_RECV_DT"]) == null)
			{
				txtCaseNo.Text = "";
				txtDtOfReciept.Text = "";
				lblCSNO.Text = "";
			}
			else
			{
				txtCaseNo.Text = Convert.ToString(Request.Params["CASE_NO"].Trim());
				txtDtOfReciept.Text = Convert.ToString(Request.Params["CALL_RECV_DT"].Trim());
				lblCSNO.Text = Convert.ToString(Request.Params["CALL_SNO"].Trim());
			}

			set_visible();

			if (!IsPostBack) //check if the webpage is loaded for the first time.
			{
				ViewState["PreviousPage"] = Request.UrlReferrer;//Saves the Previous page url in ViewState
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


				string MySql = "Insert into T49_IC_PHOTO_ENCLOSED(CASE_NO,CALL_RECV_DT,CALL_SNO,BK_NO,SET_NO,USER_ID,DATETIME) " +
					"values " +
					"('" + txtCaseNo.Text.Trim() + "',to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy')," + lblCSNO.Text + ",'" + BK_NO + "','" + SET_NO + "','" + Session["IE_EMP_NO"].ToString() + "',to_date('" + ss + "','dd/mm/yyyy'))";

				OracleCommand cmd1 = new OracleCommand(MySql, conn);
				cmd1.Transaction = myTrans;
				cmd1.ExecuteNonQuery();
				string myUpdateQuery = "Update T49_IC_PHOTO_ENCLOSED set ";
				if (File1.PostedFile != null && File1.PostedFile.ContentLength > 0)
				{
					string fn = "", fx = "", MyFile = "";
					MyFile = txtCaseNo.Text.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "01";
					fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
					fx = System.IO.Path.GetExtension(File1.PostedFile.FileName).ToUpper().Substring(1);
					String SaveLocation = null;
					SaveLocation = Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx);
					File1.PostedFile.SaveAs(SaveLocation);
					myUpdateQuery = myUpdateQuery + " FILE_1='" + MyFile + "." + fx + "' ";
				}
				if (File2.PostedFile != null && File2.PostedFile.ContentLength > 0)
				{
					string fn = "", fx = "", MyFile = "";
					MyFile = txtCaseNo.Text.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "02";
					fn = System.IO.Path.GetFileName(File2.PostedFile.FileName);
					fx = System.IO.Path.GetExtension(File2.PostedFile.FileName).ToUpper().Substring(1);
					String SaveLocation = null;
					SaveLocation = Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx);
					File2.PostedFile.SaveAs(SaveLocation);
					myUpdateQuery = myUpdateQuery + " , FILE_2='" + MyFile + "." + fx + "' ";
				}
				if (File3.PostedFile != null && File3.PostedFile.ContentLength > 0)
				{
					string fn = "", fx = "", MyFile = "";
					MyFile = txtCaseNo.Text.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "03";
					fn = System.IO.Path.GetFileName(File3.PostedFile.FileName);
					fx = System.IO.Path.GetExtension(File3.PostedFile.FileName).ToUpper().Substring(1);
					String SaveLocation = null;
					SaveLocation = Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx);
					File3.PostedFile.SaveAs(SaveLocation);
					myUpdateQuery = myUpdateQuery + " , FILE_3='" + MyFile + "." + fx + "' ";
				}
				if (File4.PostedFile != null && File4.PostedFile.ContentLength > 0)
				{
					string fn = "", fx = "", MyFile = "";
					MyFile = txtCaseNo.Text.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "04";
					fn = System.IO.Path.GetFileName(File4.PostedFile.FileName);
					fx = System.IO.Path.GetExtension(File4.PostedFile.FileName).ToUpper().Substring(1);
					String SaveLocation = null;
					SaveLocation = Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx);
					File4.PostedFile.SaveAs(SaveLocation);
					myUpdateQuery = myUpdateQuery + " , FILE_4='" + MyFile + "." + fx + "' ";
				}
				if (File5.PostedFile != null && File5.PostedFile.ContentLength > 0)
				{
					string fn = "", fx = "", MyFile = "";
					MyFile = txtCaseNo.Text.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "05";
					fn = System.IO.Path.GetFileName(File5.PostedFile.FileName);
					fx = System.IO.Path.GetExtension(File5.PostedFile.FileName).ToUpper().Substring(1);
					String SaveLocation = null;
					SaveLocation = Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx);
					File5.PostedFile.SaveAs(SaveLocation);
					myUpdateQuery = myUpdateQuery + " , FILE_5='" + MyFile + "." + fx + "' ";
				}
				if (File6.PostedFile != null && File6.PostedFile.ContentLength > 0)
				{
					string fn = "", fx = "", MyFile = "";
					MyFile = txtCaseNo.Text.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "06";
					fn = System.IO.Path.GetFileName(File6.PostedFile.FileName);
					fx = System.IO.Path.GetExtension(File6.PostedFile.FileName).ToUpper().Substring(1);
					String SaveLocation = null;
					SaveLocation = Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx);
					File6.PostedFile.SaveAs(SaveLocation);
					myUpdateQuery = myUpdateQuery + " , FILE_6='" + MyFile + "." + fx + "' ";
				}
				if (File7.PostedFile != null && File7.PostedFile.ContentLength > 0)
				{
					string fn = "", fx = "", MyFile = "";
					MyFile = txtCaseNo.Text.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "07";
					fn = System.IO.Path.GetFileName(File7.PostedFile.FileName);
					fx = System.IO.Path.GetExtension(File7.PostedFile.FileName).ToUpper().Substring(1);
					String SaveLocation = null;
					SaveLocation = Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx);
					File7.PostedFile.SaveAs(SaveLocation);
					myUpdateQuery = myUpdateQuery + " , FILE_7='" + MyFile + "." + fx + "' ";
				}
				if (File8.PostedFile != null && File8.PostedFile.ContentLength > 0)
				{
					string fn = "", fx = "", MyFile = "";
					MyFile = txtCaseNo.Text.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "08";
					fn = System.IO.Path.GetFileName(File8.PostedFile.FileName);
					fx = System.IO.Path.GetExtension(File8.PostedFile.FileName).ToUpper().Substring(1);
					String SaveLocation = null;
					SaveLocation = Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx);
					File8.PostedFile.SaveAs(SaveLocation);
					myUpdateQuery = myUpdateQuery + " , FILE_8='" + MyFile + "." + fx + "' ";
				}
				if (File9.PostedFile != null && File9.PostedFile.ContentLength > 0)
				{
					string fn = "", fx = "", MyFile = "";
					MyFile = txtCaseNo.Text.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "09";
					fn = System.IO.Path.GetFileName(File9.PostedFile.FileName);
					fx = System.IO.Path.GetExtension(File9.PostedFile.FileName).ToUpper().Substring(1);
					String SaveLocation = null;
					SaveLocation = Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx);
					File9.PostedFile.SaveAs(SaveLocation);
					myUpdateQuery = myUpdateQuery + " , FILE_9='" + MyFile + "." + fx + "' ";
				}
				if (File10.PostedFile != null && File10.PostedFile.ContentLength > 0)
				{
					string fn = "", fx = "", MyFile = "";
					MyFile = txtCaseNo.Text.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "10";
					fn = System.IO.Path.GetFileName(File10.PostedFile.FileName);
					fx = System.IO.Path.GetExtension(File10.PostedFile.FileName).ToUpper().Substring(1);
					String SaveLocation = null;
					SaveLocation = Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx);
					File10.PostedFile.SaveAs(SaveLocation);
					myUpdateQuery = myUpdateQuery + " , FILE_10='" + MyFile + "." + fx + "' ";

				}
				myUpdateQuery = myUpdateQuery + " where CASE_NO='" + txtCaseNo.Text.Trim() + "' AND BK_NO='" + BK_NO + "' AND SET_NO='" + SET_NO + "'";
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
		protected void btnSave_Click(object sender, System.EventArgs e)
		{

			if (txtBKNO.Text.Trim() != "" && txtSetNo.Text.Trim() != "")
			{
				string bscheck = "";
				conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				conn.Open();
				OracleCommand cmd = new OracleCommand("Select ISSUE_TO_IECD from T10_IC_BOOKSET where TRIM(BK_NO)=upper('" + txtBKNO.Text + "') and " + Convert.ToInt32(txtSetNo.Text) + " between (SET_NO_FR) and (SET_NO_TO) and ISSUE_TO_IECD=" + Session["IE_CD"].ToString(), conn);
				bscheck = Convert.ToString(cmd.ExecuteScalar());
				conn.Close();
				conn.Dispose();
				if (bscheck != "")
				{
					if (File1.PostedFile != null && File1.PostedFile.ContentLength > 0)
					{
						photo_upload(txtBKNO.Text.Trim(), txtSetNo.Text.Trim());
					}
				}
				else if (txtBKNO.Text.Trim() != "" && txtSetNo.Text.Trim() != "" && bscheck == "")
				{
					DisplayAlert("Book No. and Set No. specified is not issued to You!!!");
				}
			}
			if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "")
			{
				string bscheck = "";
				conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				conn.Open();
				OracleCommand cmd = new OracleCommand("Select ISSUE_TO_IECD from T10_IC_BOOKSET where TRIM(BK_NO)=upper('" + txtBKNO1.Text + "') and " + Convert.ToInt32(txtSetNo1.Text) + " between (SET_NO_FR) and (SET_NO_TO) and ISSUE_TO_IECD=" + Session["IE_CD"].ToString(), conn);
				bscheck = Convert.ToString(cmd.ExecuteScalar());
				conn.Close();
				conn.Dispose();
				if (bscheck != "")
				{
					if (File1.PostedFile != null && File1.PostedFile.ContentLength > 0)
					{
						photo_upload(txtBKNO1.Text.Trim(), txtSetNo1.Text.Trim());
					}
				}
				else if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "" && bscheck == "")
				{
					DisplayAlert("Book No. and Set No. specified is not issued to You!!!");
				}
			}
			if (txtBKNO2.Text.Trim() != "" && txtSetNo2.Text.Trim() != "")
			{
				string bscheck = "";
				conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				conn.Open();
				OracleCommand cmd = new OracleCommand("Select ISSUE_TO_IECD from T10_IC_BOOKSET where TRIM(BK_NO)=upper('" + txtBKNO2.Text + "') and " + Convert.ToInt32(txtSetNo2.Text) + " between (SET_NO_FR) and (SET_NO_TO) and ISSUE_TO_IECD=" + Session["IE_CD"].ToString(), conn);
				bscheck = Convert.ToString(cmd.ExecuteScalar());
				conn.Close();
				conn.Dispose();
				if (bscheck != "")
				{
					if (File1.PostedFile != null && File1.PostedFile.ContentLength > 0)
					{
						photo_upload(txtBKNO2.Text.Trim(), txtSetNo2.Text.Trim());
					}
				}
				else if (txtBKNO2.Text.Trim() != "" && txtSetNo2.Text.Trim() != "" && bscheck == "")
				{
					DisplayAlert("Book No. and Set No. specified is not issued to You!!!");
				}
			}
			if (txtBKNO3.Text.Trim() != "" && txtSetNo3.Text.Trim() != "")
			{
				string bscheck = "";
				conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				conn.Open();
				OracleCommand cmd = new OracleCommand("Select ISSUE_TO_IECD from T10_IC_BOOKSET where TRIM(BK_NO)=upper('" + txtBKNO3.Text + "') and " + Convert.ToInt32(txtSetNo3.Text) + " between (SET_NO_FR) and (SET_NO_TO) and ISSUE_TO_IECD=" + Session["IE_CD"].ToString(), conn);
				bscheck = Convert.ToString(cmd.ExecuteScalar());
				conn.Close();
				conn.Dispose();
				if (bscheck != "")
				{
					if (File1.PostedFile != null && File1.PostedFile.ContentLength > 0)
					{
						photo_upload(txtBKNO3.Text.Trim(), txtSetNo3.Text.Trim());
					}
				}
				else if (txtBKNO3.Text.Trim() != "" && txtSetNo3.Text.Trim() != "" && bscheck == "")
				{
					DisplayAlert("Book No. and Set No. specified is not issued to You!!!");
				}
			}
			if (txtBKNO4.Text.Trim() != "" && txtSetNo4.Text.Trim() != "")
			{
				string bscheck = "";
				conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				conn.Open();
				OracleCommand cmd = new OracleCommand("Select ISSUE_TO_IECD from T10_IC_BOOKSET where TRIM(BK_NO)=upper('" + txtBKNO4.Text + "') and " + Convert.ToInt32(txtSetNo4.Text) + " between (SET_NO_FR) and (SET_NO_TO) and ISSUE_TO_IECD=" + Session["IE_CD"].ToString(), conn);
				bscheck = Convert.ToString(cmd.ExecuteScalar());
				conn.Close();
				conn.Dispose();
				if (bscheck != "")
				{
					if (File1.PostedFile != null && File1.PostedFile.ContentLength > 0)
					{
						photo_upload(txtBKNO4.Text.Trim(), txtSetNo4.Text.Trim());
					}
				}
				else if (txtBKNO4.Text.Trim() != "" && txtSetNo4.Text.Trim() != "" && bscheck == "")
				{
					DisplayAlert("Book No. and Set No. specified is not issued to You!!!");
				}
			}

			DisplayAlert("Upload done Successfully!!!");

		}
		void set_visible()
		{
			if (rdbSingleIC.Checked == true)
			{
				lblBKNO1.Visible = false;
				txtBKNO1.Visible = false;
				lblBKNO2.Visible = false;
				txtBKNO2.Visible = false;
				lblBKNO3.Visible = false;
				txtBKNO3.Visible = false;
				lblBKNO4.Visible = false;
				txtBKNO4.Visible = false;

				lblSetNo1.Visible = false;
				txtSetNo1.Visible = false;
				lblSetNo2.Visible = false;
				txtSetNo2.Visible = false;
				lblSetNo3.Visible = false;
				txtSetNo3.Visible = false;
				lblSetNo4.Visible = false;
				txtSetNo4.Visible = false;
			}
			else if (rdbMultipleIC.Checked == true)
			{
				lblBKNO1.Visible = true;
				txtBKNO1.Visible = true;
				lblBKNO2.Visible = true;
				txtBKNO2.Visible = true;
				lblBKNO3.Visible = true;
				txtBKNO3.Visible = true;
				lblBKNO4.Visible = true;
				txtBKNO4.Visible = true;

				lblSetNo1.Visible = true;
				txtSetNo1.Visible = true;
				lblSetNo2.Visible = true;
				txtSetNo2.Visible = true;
				lblSetNo3.Visible = true;
				txtSetNo3.Visible = true;
				lblSetNo4.Visible = true;
				txtSetNo4.Visible = true;

			}
		}
		protected void rdbNonInspWork_CheckedChanged(object sender, System.EventArgs e)
		{

		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			if (ViewState["PreviousPage"] != null)  //Check if the ViewState 
													//contains Previous page URL
			{
				Response.Redirect(ViewState["PreviousPage"].ToString());//Redirect to 
																		//Previous page by retrieving the PreviousPage Url from ViewState.
			}


		}
	}
}