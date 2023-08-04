using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.IE_MAXIMUMCALLLIMIT
{
	public partial class IE_MAXIMUMCALLLIMIT : System.Web.UI.Page
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");

			if (!Page.IsPostBack)
			{

				if (Session["Role"].ToString() == "Administrator")
				{

				}
				else
				{
					Update.Visible = false;





				}

				BINDGRID();

				ListItem lst4 = new ListItem();
				lst4 = new ListItem();
				lst4.Text = "Northern Region";
				lst4.Value = "N";

				Dropdownlist1.Items.Add(lst4);


				ListItem lst41 = new ListItem();
				lst41 = new ListItem();
				lst41.Text = "Southern Region";
				lst41.Value = "S";

				Dropdownlist1.Items.Add(lst41);


				ListItem lst42 = new ListItem();
				lst42 = new ListItem();
				lst42.Text = "Eastern Region";
				lst42.Value = "E";

				Dropdownlist1.Items.Add(lst42);


				ListItem lst43 = new ListItem();
				lst43 = new ListItem();
				lst43.Text = "Westrern Region";
				lst43.Value = "W";


				Dropdownlist1.Items.Add(lst43);


				ListItem lst44 = new ListItem();
				lst44 = new ListItem();
				lst44.Text = "Central Region";
				lst44.Value = "C";


				Dropdownlist1.Items.Add(lst44);
				if (Session["Region"] == null)
				{
				}
				else
				{
					string test = Session["Region"].ToString();
					//ddlregion.Items.Insert(0,test);
					Dropdownlist1.SelectedValue = test;
					Dropdownlist1.Enabled = false;
				}

			}
			// Put user code to initialize the page here
		}


		void BINDGRID()

		{
			//DataSet dsP=new DataSet();
			OracleConnection cone = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			OracleCommand cmd = new OracleCommand("select decode(REGION_CODE,'N','Northern','E','Easteren','S','Southeren','W','Westeren','C','Central','') region_code,MAXIMUM_CALL from T102_IE_mAXIMUM_CALL_LIMIT where  REGION_CODE='" + Session["Region"].ToString() + "'", cone);
			OracleDataAdapter dt = new OracleDataAdapter(cmd);
			cone.Open();
			DataSet ds1 = new DataSet();
			dt.Fill(ds1);
			cone.Close();
			grdBook.DataSource = ds1;
			grdBook.DataBind();

		}
		protected void Update_Click(object sender, System.EventArgs e)
		{
			OracleConnection cone = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			string Code = Dropdownlist1.SelectedItem.Value;
			try
			{
				string myDeleteQuery = "UPDATE T102_IE_mAXIMUM_CALL_LIMIT SET MAXIMUM_CALL=" + TextBox1.Text + " where REGION_CODE = '" + Code + "'";
				OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
				myOracleCommand.Connection = cone;
				cone.Open();
				myOracleCommand.ExecuteNonQuery();
				DisplayAlert("Your Record has been Updated Successfully!!!");
				cone.Close();
				BINDGRID();

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
				cone.Close();
			}
			//Response.Redirect("IE_CLUSTER.aspx");

		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			OracleConnection cone = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{


				cone.Open();
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", cone);
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				string CheckString = @"(SELECT COUNT(*) FROM T102_IE_mAXIMUM_CALL_LIMIT WHERE REGION_CODE ='" + Dropdownlist1.SelectedItem.Value + "' or  MAXIMUM_CALL = " + TextBox1.Text + ")";
				OracleCommand commandCheck = new OracleCommand(CheckString, cone);
				int Count = Convert.ToInt32(commandCheck.ExecuteScalar());
				if (Count > 0)
				{
					DisplayAlert("The maximum call alredy exist for this region.SO Please Click Update Button to Update Maximum CALL LIMIT!!!");
				}
				else
				{
					string sval = Session["Uname"].ToString();
					OracleCommand cmd = new OracleCommand("INSERT INTO T102_IE_mAXIMUM_CALL_LIMIT(REGION_CODE,MAXIMUM_CALL,USER_ID,DATETIME)values('" + Dropdownlist1.SelectedItem.Value + "'," + TextBox1.Text + ",'" + Session["Uname"].ToString() + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))", cone);
					//cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					DisplayAlert("Your Record has been inserted Successfully!!!");
					btnSave.Visible = true;
					//Update.Visible=true;
					BINDGRID();


				}
				cone.Close();
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
	}
}