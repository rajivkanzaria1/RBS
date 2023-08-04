using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Change_IE_Pwd_Form
{
	public partial class Change_IE_Pwd_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);


		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSubmit.Attributes.Add("OnClick", "JavaScript:validate();");
			//btnSubmit.Attributes.Add("OnClick","JavaScript:del();");
			//			if (Page.Request.UrlReferrer==null) 
			//			{ 
			//				HyperLink3.Enabled = false; 
			//			} 
			//			else 
			//			{ 
			//				HyperLink3.Enabled = true; 
			//				HyperLink3.NavigateUrl = Request.UrlReferrer.AbsoluteUri; 
			//			} 
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

		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			string pwd;
			try
			{
				string str3 = "select IE_CD from T09_IE where (IE_EMP_NO='" + txtUID.Text + "' and IE_PWD='" + txtOPwd.Text + "')";
				OracleCommand mySelectCommand = new OracleCommand();
				conn1.Open();
				mySelectCommand.CommandText = str3;
				mySelectCommand.Connection = conn1;
				pwd = Convert.ToString(mySelectCommand.ExecuteScalar());
				if ((pwd == ""))
				{
					DisplayAlert("You Have Entered a Wrong UserID Or Password!!!");
				}
				else
				{

					string myUpdateQuery = "Update T09_IE set IE_PWD ='" + txtNPwd.Text + "' where IE_CD='" + pwd + "' and IE_EMP_NO='" + txtUID.Text + "'";
					OracleCommand myUpdateCommand = new OracleCommand();
					myUpdateCommand.CommandText = myUpdateQuery;
					myUpdateCommand.Connection = conn1;
					myUpdateCommand.ExecuteNonQuery();
					conn1.Close();

					//string popupScript = "<script language='javascript'>" + "window.open('PopUp.aspx?str=Your Password has been changed', 'CustomPopUp', " + "'width=330, height=100, menubar=no, resizable=no')" + "</script>";
					//Page.RegisterStartupScript("PopupScript", popupScript);
					DisplayAlert("Your Password has been changed");
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
			//			string str1 = "Your Password has been changed!!!"; 
			//			clrbs.myMsgBox(1, str1); 
			//			PlaceHolder1.Controls.Add(clrbs.newBox); 
			//			return; 
		}
	}
}