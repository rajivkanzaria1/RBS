using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS
{
    public partial class WebUserControl2 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (Convert.ToString(((System.Web.HttpRequest)((Page.Request))).Path) == "/RBS/Error_Form.aspx")
			{
				lblUID.Text = "User: " + Session["Uname"];
				lblRole.Text = "Role: " + Session["Role"];
				if (Session["Region"].ToString() == "N")
				{
					lblRegion.Text = "Region: " + "Northern";
				}
				else if (Session["Region"].ToString() == "S")
				{
					lblRegion.Text = "Region: " + "Southern";
				}
				else if (Session["Region"].ToString() == "E")
				{
					lblRegion.Text = "Region: " + "Eastern";
				}
				else if (Session["Region"].ToString() == "W")
				{
					lblRegion.Text = "Region: " + "Western";
				}
				else if (Session["Region"].ToString() == "C")
				{
					lblRegion.Text = "Region: " + "Central";
				}
				else if (Session["Region"].ToString() == "Q")
				{
					lblRegion.Text = "Region: " + "CO QA Division";
				}
			}
			else if ((Convert.ToString(Session["Uname"]) == "" || Convert.ToString(Session["Role"]) == "") && Convert.ToString(Session["IE_CD"]) == "")
			{
				Response.Write("<script language=JavaScript>var oWin=window.open('/RBS/Session_Expired.aspx', '', " + "'width=350, height=125, menubar=no, resizable=no,alwaysRaised=true');");
				Response.Write("if (oWin==null || typeof(oWin)=='undefined') alert('System has been blocked by POP-UP BLOCKER!!!\\nPlease disable the POP-UP BLOCKER and try again or Please contact your system administrator.');</script>");
				Response.Write("<script language='Javascript'>window.opener='x';window.close();</script>");
			}
			else if (Convert.ToString(Session["Uname"]) != "")
			{

				lblUID.Text = "User: " + Session["Uname"];
				lblRole.Text = "Role: " + Session["Role"];
				if (Session["Region"].ToString() == "N")
				{
					lblRegion.Text = "Region: " + "Northern";
				}
				else if (Session["Region"].ToString() == "S")
				{
					lblRegion.Text = "Region: " + "Southern";
				}
				else if (Session["Region"].ToString() == "E")
				{
					lblRegion.Text = "Region: " + "Eastern";
				}
				else if (Session["Region"].ToString() == "W")
				{
					lblRegion.Text = "Region: " + "Western";
				}
				else if (Session["Region"].ToString() == "C")
				{
					lblRegion.Text = "Region: " + "Central";
				}
				else if (Session["Region"].ToString() == "Q")
				{
					lblRegion.Text = "Region: " + "CO QA Division";
				}

				if (Session["Role"].Equals("Administrator"))
				{
					HyperLink1.NavigateUrl = "MainForm.aspx";
					//Response.Redirect("MainForm.aspx?Role=1"); 
				}
				else if (Session["Role"].Equals("D E Operator"))
				{
					HyperLink1.NavigateUrl = "MainForm2.aspx";
					//Response.Redirect("MainForm.aspx?Role=2"); 
				}
				else if (Session["Role"].Equals("Insp. Engineer"))
				{
					HyperLink1.NavigateUrl = "MainForm2.aspx";
					//Response.Redirect("MainForm2.aspx?Role=3"); 
				}
				else if (Session["Role"].Equals("General User"))
				{
					HyperLink1.NavigateUrl = "MainForm.aspx";
					//Response.Redirect("MainForm.aspx?Role=4"); 
				}
				else if (Session["Role"].Equals("NR Lab User"))
				{
					HyperLink1.NavigateUrl = "Lab_Menu.aspx";
					//Response.Redirect("MainForm.aspx?Role=4"); 
				}
				else if (Session["Role"].Equals("WR Lab User"))
				{
					HyperLink1.NavigateUrl = "Lab_Menu_WR.aspx";
					//Response.Redirect("MainForm.aspx?Role=4"); 
				}
				else if (Session["Role"].Equals("SR Lab User"))
				{
					HyperLink1.NavigateUrl = "Lab_Menu_WR.aspx";
					//Response.Redirect("MainForm.aspx?Role=4"); 
				}
				else if (Session["Role"].Equals("ER Lab User"))
				{
					HyperLink1.NavigateUrl = "Lab_Menu.aspx";
					//Response.Redirect("MainForm.aspx?Role=4"); 
				}


			}
			else if (Convert.ToString(Session["IE_CD"]) != "")
			{
				lblUID.Text = "User: " + Session["IE_NAME"];
				lblRole.Visible = false;
				if (Session["Region"].ToString() == "N")
				{
					lblRegion.Text = "Region: " + "Northern";
				}
				else if (Session["Region"].ToString() == "S")
				{
					lblRegion.Text = "Region: " + "Southern";
				}
				else if (Session["Region"].ToString() == "E")
				{
					lblRegion.Text = "Region: " + "Eastern";
				}
				else if (Session["Region"].ToString() == "W")
				{
					lblRegion.Text = "Region: " + "Western";
				}
				else if (Session["Region"].ToString() == "C")
				{
					lblRegion.Text = "Region: " + "Central";
				}
				else if (Session["Region"].ToString() == "Q")
				{
					lblRegion.Text = "Region: " + "CO QA Division";
				}
				HyperLink1.NavigateUrl = "IE_Menu.aspx";

			}


		}
	}
}