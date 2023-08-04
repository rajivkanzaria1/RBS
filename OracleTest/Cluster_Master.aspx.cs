using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Cluster_Master
{
	public partial class Cluster_Master : System.Web.UI.Page
	{
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected System.Web.UI.WebControls.DataGrid grdIECO;
		int code = 0;
		protected System.Web.UI.WebControls.Button Button2;
		public string Action;
		protected void Page_Load(object sender, System.EventArgs e)
		{


			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			//Delete.Attributes.Add("OnClick", "JavaScript:del();");


			//			if(Convert.ToString(Request.Params["CLUSTER_CODE"])== null || Convert.ToString(Request.Params["CLUSTER_CODE"])=="")
			//			{
			//				code=0;
			//				Action="";
			//			}
			//			else
			//			{
			//				code = Convert.ToInt32(Request.Params ["CLUSTER_CODE"].Trim());
			//
			//				showlist(code);
			//				//Action=Convert.ToString(Request.Params ["ACTION"].Trim());
			//			}
			//fillclustercode();
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				if (Session["Role"].ToString() == "Administrator")
				{

				}
				else
				{
					btnSave.Visible = false;
					btnUpdate.Visible = false;
					btnCancel.Visible = false;
					Button1.Visible = false;


				}

				fillclustercode();


				if (Action == "E")
				{
					//Delete.Visible=false;
					btnUpdate.Visible = true;
					btnSave.Visible = false;
				}
				else if (Action == "D")
				{

					//Delete.Visible=true;
					btnSave.Visible = false;
				}

				//fillclustercode();

				DataSet dsP = new DataSet();
				DataSet dsP1 = new DataSet();
				DataSet dsP2 = new DataSet();
				DataSet dsP3 = new DataSet();

				ListItem lst4 = new ListItem();
				lst4 = new ListItem();
				lst4.Text = "Northern Region";
				lst4.Value = "N";

				ddlregion.Items.Add(lst4);


				ListItem lst41 = new ListItem();
				lst41 = new ListItem();
				lst41.Text = "Southern Region";
				lst41.Value = "S";

				ddlregion.Items.Add(lst41);


				ListItem lst42 = new ListItem();
				lst42 = new ListItem();
				lst42.Text = "Eastern Region";
				lst42.Value = "E";

				ddlregion.Items.Add(lst42);


				ListItem lst43 = new ListItem();
				lst43 = new ListItem();
				lst43.Text = "Westrern Region";
				lst43.Value = "W";


				ddlregion.Items.Add(lst43);


				ListItem lst44 = new ListItem();
				lst44 = new ListItem();
				lst44.Text = "Central Region";
				lst44.Value = "C";

				ddlregion.Items.Add(lst44);

				ListItem lst45 = new ListItem();
				lst45 = new ListItem();
				lst45.Text = "QA Corporate";
				lst45.Value = "Q";

				ddlregion.Items.Add(lst45);

				if (Session["Region"] == null)
				{
				}
				else
				{
					string test = Session["Region"].ToString();
					//ddlregion.Items.Insert(0,test);
					ddlregion.SelectedValue = test;
					ddlregion.Enabled = false;
				}
				ddldepartment.Items.Insert(0, new ListItem("-Select Departmentlist item-", ""));
				ListItem lst5 = new ListItem();
				lst5 = new ListItem();
				lst5.Text = "Mechanical";
				lst5.Value = "M";
				//lst5.Selected=true;
				ddldepartment.Items.Add(lst5);
				lst5 = new ListItem();
				lst5.Text = "Electrical";
				lst5.Value = "E";
				ddldepartment.Items.Add(lst5);
				lst5 = new ListItem();
				lst5.Text = "Civil";
				lst5.Value = "C";
				ddldepartment.Items.Add(lst5);
				//				lst5 = new ListItem(); 
				//				lst5.Text = "Metallurgy"; 
				//				lst5.Value = "L"; 
				//				ddldepartment.Items.Add(lst5); 
				lst5 = new ListItem();
				lst5.Text = "Textiles";
				lst5.Value = "T";
				ddldepartment.Items.Add(lst5);
				lst5 = new ListItem();
				lst5.Text = "M & P";
				lst5.Value = "Z";
				ddldepartment.Items.Add(lst5);

				if (Convert.ToString(Request.Params["CLUSTER_CODE"]) == null || Convert.ToString(Request.Params["CLUSTER_CODE"]) == "")
				{
					code = 0;
					Action = "";
				}
				else
				{
					code = Convert.ToInt32(Request.Params["CLUSTER_CODE"].Trim());

					showlist(code);
					//Action=Convert.ToString(Request.Params ["ACTION"].Trim());
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

		void showlist(int code)
		{
			OracleConnection cone = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			DataSet dsP = new DataSet();
			string str1 = "select CLUSTER_CODE,Cluster_name,geographical_partition,department_name,region_code, hq_area from T99_cluster_master where CLUSTER_CODE=" + code + "";
			OracleDataAdapter da = new OracleDataAdapter(str1, cone);
			OracleCommand myOracleCommand = new OracleCommand(str1, cone);
			cone.Open();
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			cone.Close();
			if (dsP.Tables[0].Rows.Count == 0)
			{
				throw new System.Exception("No Record Found!!! For the given cluster Name.");
			}
			else
			{
				lblCom_DT.Text = dsP.Tables[0].Rows[0]["CLUSTER_CODE"].ToString();
				Label4.Text = dsP.Tables[0].Rows[0]["CLUSTER_NAME"].ToString();
				Textbox1.Text = dsP.Tables[0].Rows[0]["GEOGRAPHICAL_PARTITION"].ToString();
				ddldepartment.SelectedValue = dsP.Tables[0].Rows[0]["DEPARTMENT_NAME"].ToString();
				ddlregion.SelectedValue = dsP.Tables[0].Rows[0]["REGION_CODE"].ToString();
				txtHQArea.Text = dsP.Tables[0].Rows[0]["HQ_AREA"].ToString();

				btnSave.Visible = false;
				btnUpdate.Visible = true;
				//Delete.Visible=true;
				btnCancel.Visible = false;
			}
		}




		void fillclustercode()
		{
			OracleConnection cone = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			string Command = "select NVL(max(CLUSTER_CODE),0)+1 AS  ClusterCode from T99_CLUSTER_MASTER";
			OracleCommand Comm1 = new OracleCommand(Command, cone);
			cone.Open();
			OracleDataReader DR1 = Comm1.ExecuteReader();
			if (DR1.Read())
			{
				lblCom_DT.Text = DR1.GetValue(0).ToString();

			}
			else
			{
				lblCom_DT.Text = "1";
			}
			cone.Close();

		}
		void cancel()
		{
			Label4.Text = "";
			Textbox1.Text = "";
			ddldepartment.SelectedIndex = 0;
			//ddlregion.SelectedIndex=-1;
			txtHQArea.Text = "";
		}



		protected void CancelAll(object sender, System.EventArgs e)
		{
			fillclustercode();

			Label4.Text = "";
			Textbox1.Text = "";

			ddldepartment.SelectedIndex = 0;
			//			ddlregion.SelectedIndex=-1;

			btnSave.Visible = true;
			btnUpdate.Visible = false;

		}



		protected void Search(object sender, System.EventArgs e)
		{
			OracleConnection cone = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			try
			{
				if (Label4.Text == "" && Textbox1.Text == "" && ddldepartment.SelectedIndex == 0)
				{
					DisplayAlert("Please Enter First Few Letters of Cluster Name or geographical partition or department name!!!");
				}
				else
				{

					DataSet dsP = new DataSet();
					string str1 = "select CLUSTER_CODE,CLUSTER_NAME,GEOGRAPHICAL_PARTITION,DEPARTMENT_NAME,REGION_CODE, HQ_AREA from T99_cluster_master where  REGION_CODE='" + Session["Region"].ToString() + "'";


					if (Label4.Text.Trim() != "")
					{
						str1 = str1 + " and upper(CLUSTER_NAME) LIKE upper('" + Label4.Text.Trim() + "%')";
					}
					if (Textbox1.Text.Trim() != "")
					{
						str1 = str1 + " and upper(GEOGRAPHICAL_PARTITION) LIKE upper('" + Textbox1.Text.Trim() + "%')";
					}
					if (ddldepartment.SelectedItem.Value != "")
					{
						str1 = str1 + " and DEPARTMENT_NAME=('" + ddldepartment.SelectedItem.Value + "') ";
					}

					str1 = str1 + " order by CLUSTER_NAME";





					OracleDataAdapter da = new OracleDataAdapter(str1, cone);
					OracleCommand myOracleCommand = new OracleCommand(str1, cone);
					cone.Open();
					da.SelectCommand = myOracleCommand;
					da.Fill(dsP, "Table");
					cone.Close();
					for (int i = 0; i < dsP.Tables[0].Rows.Count; i++)
					{
						string dept = dsP.Tables[0].Rows[i]["DEPARTMENT_NAME"].ToString();
						if (dept == "M")
						{
							dept = "Mechanical";
						}
						else if (dept == "E")
						{
							dept = "Electrical";
						}
						else if (dept == "C")
						{
							dept = "Civil";
						}
						else if (dept == "Z")
						{
							dept = "M & P";
						}
						else
						{

							dept = "Textiles ";
						}
						dsP.Tables[0].Rows[i]["DEPARTMENT_NAME"] = dept;
					}



					if (dsP.Tables[0].Rows.Count == 0)
					{
						//throw new System.Exception("No Record Found!!! For the given cluster Name.");
						DisplayAlert("No Record Found!!! For the given cluster .");
					}
					else
					{
						grdBook.DataSource = dsP;
						grdBook.DataBind();
					}
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
				cone.Close();
			}
		}
		protected void Update_Click(object sender, System.EventArgs e)
		{
			string Code = lblCom_DT.Text;
			try
			{
				string myDeleteQuery = "UPDATE T99_CLUSTER_MASTER SET CLUSTER_NAME='" + Label4.Text + "', GEOGRAPHICAL_PARTITION= '" + Textbox1.Text + "',REGION_CODE='" + ddlregion.SelectedItem.Value + "',DEPARTMENT_NAME='" + ddldepartment.SelectedItem.Value + "', HQ_AREA='" + txtHQArea.Text + "' where CLUSTER_CODE=" + Code + "";
				OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
				myOracleCommand.Connection = conn;
				conn.Open();
				myOracleCommand.ExecuteNonQuery();
				DisplayAlert("Your Record has been Updated Successfully!!!");
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
			}
			cancel();
			//Response.Redirect("Cluster_Master.aspx");

		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		//		protected void Delete_Click(object sender, System.EventArgs e)
		//		{
		//			
		//			try 
		//			{
		//			    string Code=lblCom_DT.Text;
		//				string myDeleteQuery = "Delete T99_CLUSTER_MASTER where CLUSTER_CODE="+Code+"";
		//				OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
		//				myOracleCommand.Connection = conn;
		//				conn.Open();
		//				myOracleCommand.ExecuteNonQuery();
		//				DisplayAlert("Your Record has been Deleted Successfully!!!");
		//				cancel();
		//				
		//				
		//			}
		//			catch (Exception ex)
		//			{
		//				string str;
		//				str = ex.Message;
		//				string str1=str.Replace("\n","");
		//				Response.Redirect(("Error_Form.aspx?err=" + str1));
		//			}
		//			finally
		//			{
		//				conn.Close();
		//			}
		//			//Response.Redirect("Cluster_Master.aspx");
		//		}
		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			OracleConnection cone = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);


			try
			{

				cone.Open();
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", cone);
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				cone.Close();


				string CheckString = @"(SELECT COUNT(*) FROM T99_CLUSTER_MASTER WHERE CLUSTER_CODE ='" + lblCom_DT.Text + "' and  CLUSTER_NAME = '" + Label4.Text + "' and GEOGRAPHICAL_PARTITION='" + Textbox1.Text + "' AND REGION_CODE='" + ddlregion.SelectedItem.Value + "' AND DEPARTMENT_NAME= '" + ddldepartment.SelectedItem.Value + "')";

				string sval = Session["Uname"].ToString();

				OracleCommand cmd = new OracleCommand("INSERT INTO T99_CLUSTER_MASTER(CLUSTER_CODE,CLUSTER_NAME,GEOGRAPHICAL_PARTITION,REGION_CODE,DEPARTMENT_NAME,USER_ID,DATETIME,HQ_AREA)values('" + lblCom_DT.Text + "','" + Label4.Text + "','" + Textbox1.Text + "','" + ddlregion.SelectedItem.Value + "','" + ddldepartment.SelectedItem.Value + "','" + sval + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'), '" + txtHQArea.Text.Trim() + "')", cone);
				cmd.Connection.Open();


				OracleCommand commandCheck = new OracleCommand(CheckString, cone);
				int Count = Convert.ToInt32(commandCheck.ExecuteScalar());
				if (Count > 0)
				{
					DisplayAlert("This cluster is already entered!!!");
				}
				else
				{


					cmd.ExecuteNonQuery();
					//Update.Visible=true;
					btnSave.Visible = false;
					//Delete.Visible=true;
					// fillclustercode();
					//lblCom_DT.Visible=true;

					DisplayAlert("Your Record has been inserted Successfully!!!");
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
				conn.Close();
				conn.Dispose();
			}
		}

		protected void ddlregion_SelectedIndexChanged(object sender, System.EventArgs e)
		{

		}
		protected void PRINTCLICK(object sender, EventArgs e)
		{
			xyz.Visible = false;

			string sql = "select cluster_name,geographical_partition,decode(department_name,'M','Mechanical','E','Electrical','C','Civil','T','Textiles','Z','M P','') Department from t99_cluster_master where region_code='" + Session["Region"].ToString() + "' order by cluster_name";
			try
			{
				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='3'>");
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='6'>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>CLuster name</font></b></th>");
				Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>Geographical Area</font></b></th>");
				Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>Department Name</font></b></th>");
				Response.Write("</tr></font>");

				while (reader.Read())
				{
					Response.Write("<tr>");
					Response.Write("<td width='20%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["cluster_name"]); Response.Write("</td>");
					Response.Write("<td width='20%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["Geographical_partition"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["Department"]); Response.Write("</td>");
					Response.Write("</tr>");
				};

				Response.Write("</table>");
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
			}
		}



		protected void btnUpdate_Click(object sender, System.EventArgs e)
		{
			string Code = lblCom_DT.Text;
			try
			{
				string myDeleteQuery = "UPDATE T99_CLUSTER_MASTER SET CLUSTER_NAME='" + Label4.Text + "', GEOGRAPHICAL_PARTITION= '" + Textbox1.Text + "',REGION_CODE='" + ddlregion.SelectedItem.Value + "',DEPARTMENT_NAME='" + ddldepartment.SelectedItem.Value + "', HQ_AREA='" + txtHQArea.Text + "' where CLUSTER_CODE=" + Code + "";
				OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
				myOracleCommand.Connection = conn;
				conn.Open();
				myOracleCommand.ExecuteNonQuery();
				DisplayAlert("Your Record has been Updated Successfully!!!");
				conn.Close();
				cancel();
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
			}

		}


	}
}