using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace RBS
{
    public partial class Login_Form1 : System.Web.UI.Page
    {
		//OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		protected System.Web.UI.WebControls.TextBox txtRole;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.Image Image3;
		protected System.Web.UI.WebControls.TextBox txtUname;
		protected System.Web.UI.WebControls.TextBox txtPwd;
		protected System.Web.UI.WebControls.Button btnChangePwd;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected Tittle.Controls.CustomDataGrid grdMessage;
		string reg, allow_po;

		//[System.Diagnostics.DebuggerStepThrough()] 

		//protected void Page_Init(object sender, System.EventArgs e) 
		//{ 
		//	InitializeComponent(); 
		//} 

		//#region Web Form Designer generated code
		//override protected void OnInit(EventArgs e)
		//{
		//	//
		//	// CODEGEN: This call is required by the ASP.NET Web Form Designer.
		//	//
		//	InitializeComponent();
		//	base.OnInit(e);
		//}

		///// <summary>
		///// Required method for Designer support - do not modify
		///// the contents of this method with the code editor.
		///// </summary>
		//private void InitializeComponent()
		//{    

		//}
		//#endregion
		protected void Page_Load(object sender, System.EventArgs e)
		{ 
		
			btnSubmit.Attributes.Add("OnClick", "JavaScript:validate();");


			//			try
			//			{
			//				OracleCommand cmd=new OracleCommand("Select to_char(add_months(sysdate,-1),'dd/mm/yyyy')DtFr,to_char(sysdate,'dd/mm/yyyy')DtTo from dual",conn);
			//				conn.Open();
			//				OracleDataReader reader = cmd.ExecuteReader();
			//				if (!(IsPostBack))
			//				{
			//					while(reader.Read())
			//					{
			//						HyperLinkNR.NavigateUrl="/RBS/Calls_Marked_Report.aspx?pDtFR="+Convert.ToString(reader["DtFr"])+"&pDtTo="+Convert.ToString(reader["DtTo"])+"&pRegion=N&pSortKey=V";
			//						HyperLinkER.NavigateUrl="/RBS/Calls_Marked_Report.aspx?pDtFR="+Convert.ToString(reader["DtFr"])+"&pDtTo="+Convert.ToString(reader["DtTo"])+"&pRegion=E&pSortKey=V";
			//						HyperLinkSR.NavigateUrl="/RBS/Calls_Marked_Report.aspx?pDtFR="+Convert.ToString(reader["DtFr"])+"&pDtTo="+Convert.ToString(reader["DtTo"])+"&pRegion=S&pSortKey=V";
			//						HyperLinkWR.NavigateUrl="/RBS/Calls_Marked_Report.aspx?pDtFR="+Convert.ToString(reader["DtFr"])+"&pDtTo="+Convert.ToString(reader["DtTo"])+"&pRegion=W&pSortKey=V";
			//					}
			//					reader.Close();
			//				}
			//				conn.Close();
			//				
			//			}
			//			catch (Exception ex) 
			//			{ 
			////				string str; 
			////				str = ex.Message; 
			////				DisplayAlert("ORACLE NOT AVAILABLE!!!");
			//				string str; 
			//				str = ex.Message; 
			//				string str1=str.Replace("\n","");
			//				Response.Redirect(("Error_Form.aspx?err=" + str1));
			//			}
			//			finally
			//			{
			//				conn.Close(); 
			//			} 


			fillgrid();

		}

		void fillgrid()
		{
			OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				DataSet dsP = new DataSet();
				conn.Open();
				string str1 = "select MESSAGE_ID,MESSAGE,USER_ID,to_char(DATETIME,'dd/mm/yyyy')DATETIME from T96_MESSAGES";
                OracleDataAdapter da = new OracleDataAdapter(str1, conn);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn);
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
                if (dsP.Tables[0].Rows.Count == 0)
                {
                    grdMessage.Visible = false;
                }
                else
                {
                    grdMessage.Visible = true;
                    grdMessage.DataSource = dsP;
                    grdMessage.DataBind();
                }
                conn.Close();
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
				conn.Dispose();
			}
		}

		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string str2 = "";
				OracleDataReader or1;
				string str1 = "select AUTH_LEVL,REGION,nvl(ALLOW_PO,' ') from T02_USERS where USER_ID='" + txtUname.Text + "' and PASSWORD= '" + txtPwd.Text + "' and STATUS is null";
				OracleCommand myOracleCommand = new OracleCommand(str1, conn);
				conn.Open();
				or1 = myOracleCommand.ExecuteReader();
				if (!or1.HasRows)
				{
					conn.Close();
					DisplayAlert("Invalid User Id / Password");
				}
				else
				{
					while (or1.Read())
					{
						str2 = or1.GetInt64(0).ToString();
						reg = or1.GetString(1);
						allow_po = or1.GetString(2);
					}
					conn.Close();
					Session["Uname"] = txtUname.Text;
					Session["Region"] = reg;
					Session["Role_CD"] = str2;
					Session["Authorise"] = allow_po;
					if (reg == "M")
					{
						if (Session["Role_CD"].ToString() == "1")
						{
							Session["Role"] = "Administrator";
						}
						else
						{
							Session["Role"] = "General User";
						}
						//						Response.Redirect("MainForm1.aspx"); 

						Response.Write("<script language=JavaScript>var oWin= window.open('Region_Selection_Form.aspx?Role=1','', 'fullscreen=yes, scrollbars=yes');");
						Response.Write("if (oWin==null || typeof(oWin)=='undefined') alert('System has been blocked by POP-UP BLOCKER!!!\\nPlease disable the POP-UP BLOCKER and try again or Please contact your system administrator.');</script>");
						Response.Write("<script language='Javascript'>window.opener='x';window.close();</script>");
					}
					else
					{
						if (str2 == "1")
						{
							Session["Role"] = "Administrator";
							//						Response.Redirect("MainForm.aspx?Role=1"); 

							Response.Write("<script language=JavaScript>var oWin= window.open('MainForm.aspx?Role=1','', 'fullscreen=yes, scrollbars=yes');");
							Response.Write("if (oWin==null || typeof(oWin)=='undefined') alert('System has been blocked by POP-UP BLOCKER!!!\\nPlease disable the POP-UP BLOCKER and try again or Please contact your system administrator.');</script>");
							Response.Write("<script language='Javascript'>window.opener='x';window.close();</script>");
						}
						else if (str2 == "2")
						{
							Session["Role"] = "Data Entry Operator";
							//Response.Redirect("MainForm2.aspx?Role=2"); 

							Response.Write("<script language=JavaScript>var oWin= window.open('MainForm.aspx?Role=1','', 'fullscreen=yes, scrollbars=yes');");
							Response.Write("if (oWin==null || typeof(oWin)=='undefined') alert('System has been blocked by POP-UP BLOCKER!!!\\nPlease disable the POP-UP BLOCKER and try again or Please contact your system administrator.');</script>");
							Response.Write("<script language='Javascript'>window.opener='x';window.close();</script>");
						}
						else if (str2 == "3")
						{
							Session["Role"] = "Insp. Engineer";
							//Response.Redirect("MainForm2.aspx?Role=3"); 

							Response.Write("<script language=JavaScript>var oWin= window.open('MainForm2.aspx?Role=1','', 'fullscreen=yes, scrollbars=yes');");
							Response.Write("if (oWin==null || typeof(oWin)=='undefined') alert('System has been blocked by POP-UP BLOCKER!!!\\nPlease disable the POP-UP BLOCKER and try again or Please contact your system administrator.');</script>");
							Response.Write("<script language='Javascript'>window.opener='x';window.close();</script>");
						}
						else if (str2 == "4")
						{
							Session["Role"] = "General User";
							//						Response.Redirect("MainForm1.aspx"); 

							Response.Write("<script language=JavaScript>var oWin= window.open('MainForm.aspx?Role=1','', 'fullscreen=yes, scrollbars=yes');");
							Response.Write("if (oWin==null || typeof(oWin)=='undefined') alert('System has been blocked by POP-UP BLOCKER!!!\\nPlease disable the POP-UP BLOCKER and try again or Please contact your system administrator.');</script>");
							Response.Write("<script language='Javascript'>window.opener='x';window.close();</script>");
						}
						else if (str2 == "5")
						{
							Session["Role"] = "NR Lab User";
							//						Response.Redirect("MainForm1.aspx"); 

							Response.Write("<script language=JavaScript>var oWin= window.open('Lab_Menu.aspx?Role=1','', 'fullscreen=yes, scrollbars=yes');");
							Response.Write("if (oWin==null || typeof(oWin)=='undefined') alert('System has been blocked by POP-UP BLOCKER!!!\\nPlease disable the POP-UP BLOCKER and try again or Please contact your system administrator.');</script>");
							Response.Write("<script language='Javascript'>window.opener='x';window.close();</script>");
						}
						else if (str2 == "6")
						{
							Session["Role"] = "WR Lab User";
							//						Response.Redirect("MainForm1.aspx"); 

							Response.Write("<script language=JavaScript>var oWin= window.open('Lab_Menu_WR.aspx?Role=1','', 'fullscreen=yes, scrollbars=yes');");
							Response.Write("if (oWin==null || typeof(oWin)=='undefined') alert('System has been blocked by POP-UP BLOCKER!!!\\nPlease disable the POP-UP BLOCKER and try again or Please contact your system administrator.');</script>");
							Response.Write("<script language='Javascript'>window.opener='x';window.close();</script>");
						}
						else if (str2 == "7")
						{
							Session["Role"] = "SR Lab User";
							//						Response.Redirect("MainForm1.aspx"); 

							Response.Write("<script language=JavaScript>var oWin= window.open('Lab_Menu_WR.aspx?Role=1','', 'fullscreen=yes, scrollbars=yes');");
							Response.Write("if (oWin==null || typeof(oWin)=='undefined') alert('System has been blocked by POP-UP BLOCKER!!!\\nPlease disable the POP-UP BLOCKER and try again or Please contact your system administrator.');</script>");
							Response.Write("<script language='Javascript'>window.opener='x';window.close();</script>");
						}
						else if (str2 == "8")
						{
							Session["Role"] = "ER Lab User";
							//						Response.Redirect("MainForm1.aspx"); 

							Response.Write("<script language=JavaScript>var oWin= window.open('Lab_Menu.aspx?Role=1','', 'fullscreen=yes, scrollbars=yes');");
							Response.Write("if (oWin==null || typeof(oWin)=='undefined') alert('System has been blocked by POP-UP BLOCKER!!!\\nPlease disable the POP-UP BLOCKER and try again or Please contact your system administrator.');</script>");
							Response.Write("<script language='Javascript'>window.opener='x';window.close();</script>");
						}
					}
				}
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				Response.Redirect(("Error_Form.aspx?err=" + str));
			}
			finally
			{
				conn.Close();
				conn.Dispose();
			}
		}

		protected void btnChangePwd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Change_Pwd_Form.aspx");
		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
	}
}




