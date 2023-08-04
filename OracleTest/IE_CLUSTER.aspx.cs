using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.IE_CLUSTER
{
	public partial class IE_CLUSTER : System.Web.UI.Page
	{
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		protected System.Web.UI.WebControls.TextBox txtMName;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.Button Delete;
		protected System.Web.UI.WebControls.TextBox Textbox2;
		protected System.Web.UI.WebControls.TextBox Textbox3;
		int code = 0;
		String deptname;
		protected System.Web.UI.WebControls.Button btnPrint;
		public string Action;

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
					btnSave.Visible = false;
					Update.Visible = false;
					btnCancel.Visible = false;
					Button1.Visible = false;
				}
				Dropdownlist1.Items.Insert(0, new ListItem("-Select ClusterList item-", ""));
				//				BindVendorCode();
				//				BindClustercode();
				FillIE();

				if (Action == "E")
				{
					show();
					//Delete.Visible=false;
					Update.Visible = true;
					btnSave.Visible = false;
				}
				else if (Action == "D")
				{
					show();
					//Delete.Visible=true;
					btnSave.Visible = false;
				}
				ListItem lst5 = new ListItem();
				lst5 = new ListItem();
				lst5.Text = "Mechanical";
				lst5.Value = "M";

				Dropdownlist2.Items.Add(lst5);
				Dropdownlist2.Items.Insert(0, new ListItem("-Select Departmentlist item-", ""));

				lst5 = new ListItem();
				lst5.Text = "Electrical";
				lst5.Value = "E";
				Dropdownlist2.Items.Add(lst5);
				lst5 = new ListItem();
				lst5.Text = "Civil";
				lst5.Value = "C";
				Dropdownlist2.Items.Add(lst5);
				//				lst5 = new ListItem(); 
				//				lst5.Text = "Metallurgy"; 
				//				lst5.Value = "L"; 
				//				Dropdownlist2.Items.Add(lst5); 
				lst5 = new ListItem();
				lst5.Text = "Textiles";
				lst5.Value = "T";
				Dropdownlist2.Items.Add(lst5);
				lst5 = new ListItem();
				lst5.Text = "M & P";
				lst5.Value = "Z";
				Dropdownlist2.Items.Add(lst5);


				// Put user code to initialize the page here


				if (Convert.ToString(Request.Params["CLUSTER_CODE"]) == null || Convert.ToString(Request.Params["CLUSTER_CODE"]) == "")
				{
					code = 0;
					Action = "";
				}
				if (Convert.ToString(Request.Params["DEPARTMENT_CODE"]) == null || Convert.ToString(Request.Params["DEPARTMENT_CODE"]) == "")
				{
					code = 0;
					Action = "";
				}


				else
				{
					code = Convert.ToInt32(Request.Params["CLUSTER_CODE"].Trim());
					deptname = Request.Params["DEPARTMENT_CODE"].ToString();

					if (deptname == "Mechanical")
					{
						deptname = "M";
					}
					else if (deptname == "Electrical")
					{
						deptname = "E";
					}
					else if (deptname == "Civil")
					{
						deptname = "C";
					}
					else if (deptname == "Textiles")
					{
						deptname = "T";
					}
					else
					{

						deptname = "Z";
					}


					showlist(code, deptname);
					//Action=Convert.ToString(Request.Params ["ACTION"].Trim());
				}
			}
		}


		void showlist(int code, String deptname)
		{
			OracleConnection cone = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			DataSet dsP = new DataSet();
			string str1 = "select IE_CODE,DEPARTMENT_CODE,CLUSTER_CODE from T101_IE_CLUSTER where CLUSTER_CODE=" + code + " and DEPARTMENT_CODE='" + deptname + "'";
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
				Dropdownlist12.SelectedValue = dsP.Tables[0].Rows[0]["IE_CODE"].ToString();
				Dropdownlist2.SelectedValue = dsP.Tables[0].Rows[0]["DEPARTMENT_CODE"].ToString();
				//Dropdownlist1.SelectedValue = dsP.Tables[0].Rows[0]["CLUSTER_CODE"].ToString(); 
				using (OracleCommand cmd = new OracleCommand("Select CLUSTER_CODE,cluster_name ||'-'||geographical_partition AS NAME from t99_cluster_master where DEPARTMENT_NAME='" + Dropdownlist2.SelectedItem.Value + "' and region_code='" + Session["Region"].ToString() + "' order by CLUSTER_NAME", cone))
				{
					cone.Open();
					Dropdownlist1.DataSource = cmd.ExecuteReader();
					Dropdownlist1.DataValueField = "CLUSTER_CODE";
					Dropdownlist1.DataTextField = "NAME";
					Dropdownlist1.DataBind();
					cone.Close();
				}
				Dropdownlist1.SelectedValue = dsP.Tables[0].Rows[0]["CLUSTER_CODE"].ToString();
				btnSave.Visible = false;
				Update.Visible = true;
				//Delete.Visible=true;
				btnCancel.Visible = false;
			}
		}



		void show()
		{


			try
			{
				DataSet dsP = new DataSet();
				string str1 = "select Ie_code,cluster_code,DEPARTMENT_CODE from t101_ie_cluster where IE_CODE='" + code + "'";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn);
				OracleCommand myOracleCommand1 = new OracleCommand(str1, conn);
				conn.Open();
				da.SelectCommand = myOracleCommand1;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					throw new System.Exception("No Record Found!!! For The Given Code");
				}
				else
				{
					Dropdownlist12.DataValueField = dsP.Tables[0].Rows[0]["Ie_code"].ToString();
					Dropdownlist1.DataValueField = dsP.Tables[0].Rows[0]["cluster_code"].ToString();
					Dropdownlist2.DataValueField = dsP.Tables[0].Rows[0]["DEPARTMENT_CODE"].ToString();


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
				//conn.Close();
			}
		}



		void FillIE()
		{
			//SELECT first_name || ' ' || last_namefrom AS 
			OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			using (OracleCommand cmd = new OracleCommand("select IE_CD,IE_NAME AS NAME from T09_IE where IE_REGION='" + Session["Region"].ToString() + "' and IE_STATUS IS NULL order by IE_NAME asc ", conn))
			{
				conn.Open();
				Dropdownlist12.DataSource = cmd.ExecuteReader();
				Dropdownlist12.DataValueField = "IE_CD";
				Dropdownlist12.DataTextField = "NAME";
				Dropdownlist12.DataBind();
				conn.Close();
				Dropdownlist12.Items.Insert(0, new ListItem("--Select IE Name--", "0"));

			}

		}


		protected void Search(object sender, System.EventArgs e)
		{
			OracleConnection cone = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				if (Dropdownlist2.SelectedIndex == 0 && Dropdownlist1.SelectedIndex == 0 && Dropdownlist12.SelectedIndex == 0)
				{
					DisplayAlert("PLEASE ENTER DEPARTMENT NAME  OR DEPARTMENT NAME AND CLUSTER NAME or IE Name!!!");
				}
				else
				{
					DataSet dsP = new DataSet();
					string str1 = "select a.IE_CODE,b.IE_NAME,a.DEPARTMENT_CODE,a.CLUSTER_CODE,c.CLUSTER_NAME from T101_IE_CLUSTER a ,T09_IE b,T99_CLUSTER_MASTER c where a.IE_CODE=b.IE_CD and c.CLUSTER_CODE=a.CLUSTER_CODE  and b.IE_REGION='" + Session["Region"].ToString() + "' ";
					if (Dropdownlist2.SelectedItem.Value != "")
					{
						str1 = str1 + " and a.DEPARTMENT_CODE ='" + Dropdownlist2.SelectedItem.Value + "'";

					}
					if (Dropdownlist1.SelectedItem.Value != "" && Dropdownlist1.SelectedIndex != 0)
					{
						str1 = str1 + " and a.CLUSTER_CODE =" + Dropdownlist1.SelectedItem.Value + "";
					}
					else
					{

						str1 = str1 + "";
					}
					if (Dropdownlist12.SelectedItem.Value != "" && Dropdownlist12.SelectedIndex != 0)
					{
						str1 = str1 + " and a.IE_CODE =" + Dropdownlist12.SelectedItem.Value + "";
					}


					str1 = str1 + " order by c.CLUSTER_NAME,b.IE_NAME";

					OracleDataAdapter da = new OracleDataAdapter(str1, cone);
					OracleCommand myOracleCommand = new OracleCommand(str1, cone);
					cone.Open();
					da.SelectCommand = myOracleCommand;
					da.Fill(dsP);
					cone.Close();
					if (dsP.Tables[0].Rows.Count == 0)
					{
						DisplayAlert("NO record Found!!!");
						grdBook.Visible = false;


						//throw new System.Exception("No Record Found!!! For the given cluster Name.");

					}
					else
					{
						for (int i = 0; i < dsP.Tables[0].Rows.Count; i++)
						{
							string dept = dsP.Tables[0].Rows[i]["DEPARTMENT_CODE"].ToString();
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
							dsP.Tables[0].Rows[i]["DEPARTMENT_CODE"] = dept;
						}

						//					using (OracleCommand cmd = new OracleCommand("select ie" ,cone))
						//					{
						//						cone.Open();
						//						Dropdownlist1.DataSource = cmd.ExecuteReader();
						//						Dropdownlist1.DataValueField = "CLUSTER_CODE";
						//						Dropdownlist1.DataTextField = "CLUSTER_NAME";	
						//						Dropdownlist1.DataBind();
						//						cone.Close();
						//					}
						//					Dropdownlist1.SelectedValue = dsP.Tables[0].Rows[0]["CLUSTER_CODE"].ToString(); 

						String venderaddress = dsP.Tables[0].Rows[0]["CLUSTER_CODE"].ToString();



						using (OracleCommand cmd1 = new OracleCommand("Select CLUSTER_CODE,CLUSTER_NAME from T99_CLUSTER_MASTER where CLUSTER_CODE=" + venderaddress + "", cone))
						{
							//											OracleCommand myOracleCommand12 = new OracleCommand(cmd1, cone); 
							//											OracleDataAdapter da12 = new OracleDataAdapter(cmd1, cone); 
							OracleDataAdapter dt = new OracleDataAdapter(cmd1);
							cone.Open();
							DataSet ds1 = new DataSet();
							dt.Fill(ds1);
							cone.Close();
							venderaddress = ds1.Tables[0].Rows[0]["CLUSTER_NAME"].ToString();
						}
						dsP.Tables[0].Rows[0]["CLUSTER_NAME"] = venderaddress;
						grdBook.Visible = true;
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

		protected void CancelAll(object sender, System.EventArgs e)
		{

			Dropdownlist12.SelectedIndex = 0;
			Dropdownlist1.SelectedIndex = -1;
			Dropdownlist2.SelectedIndex = 0;
			btnSave.Visible = true;
			Update.Visible = false;
		}
		protected void Update_Click(object sender, System.EventArgs e)
		{
			try
			{
				OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				conn.Open();
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn);
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				conn.Close();
				string sval = Session["Uname"].ToString();

				string Code = Dropdownlist1.SelectedItem.Value;
				string deptname = Dropdownlist2.SelectedItem.Value;
				string myDeleteQuery = "UPDATE t101_IE_CLUSTER SET IE_CODE='" + Dropdownlist12.SelectedItem.Value + "',USER_ID='" + sval + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where CLUSTER_CODE= " + Code + " and DEPARTMENT_CODE='" + deptname + "'";
				OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
				myOracleCommand.Connection = conn;
				conn.Open();
				myOracleCommand.ExecuteNonQuery();
				DisplayAlert("Your Record has been Updated Successfully!!!");
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
			//Response.Redirect("IE_CLUSTER.aspx");

		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		//		protected void Delete_Click(object sender, System.EventArgs e)
		//		{
		//		
		//			
		//			try 
		//			{
		//				string Code1=Dropdownlist1.SelectedItem.Value;
		//				string deptname=Dropdownlist2.SelectedItem.Value;
		//
		//								string myDeleteQuery = "Delete t101_IE_CLUSTER where CLUSTER_CODE="+Code1+" and DEPARTMENT_CODE='"+Dropdownlist2.SelectedItem.Value+"'";
		//								OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
		//								myOracleCommand.Connection = conn;
		//								conn.Open();
		//								myOracleCommand.ExecuteNonQuery();
		//								DisplayAlert("Your Record has been Deleted Successfully!!!");
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
		//		//	Response.Redirect("IE_CLUSTER.aspx");
		//		}


		//		protected void ienamechanged(object sender, System.EventArgs e)
		//		{
		//			string Code=Dropdownlist12.SelectedItem.Value;
		//
		//			System.Data.OracleClient.OracleConnection conn = new System.Data.OracleClient.OracleConnection((ConfigurationSettings.AppSettings["ConnectionString"])) ;
		//			using (OracleCommand cmd = new OracleCommand("select Cluster_Code,NVL2(Cluster_name,Cluster_name||' - '||Geographical_partition,geographical_partition) CITY,IE_DEPARTMENT From T99_cluster_master C  inner join T09_IE I on I.Ie_Department=C.DEPARTMENT_NAME where I.IE_REGION='"+Session["Region"].ToString()+"' and I.IE_CD='"+Code+"'",conn))
		//			{
		//				conn.Open();
		//				Dropdownlist1.DataSource = cmd.ExecuteReader();
		//				Dropdownlist1.DataValueField = "Cluster_Code";
		//				Dropdownlist1.DataTextField = "CITY";	
		//				Dropdownlist1.DataBind();
		//				conn.Close();
		//				Dropdownlist1.Items.Insert(0, new ListItem("--Select Cluster Name--", "0"));
		//			}
		//
		//			}



		protected void departmentchanged(Object Sender, System.EventArgs e)
		{
			string deptname = Dropdownlist2.SelectedItem.Value;
			OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			using (OracleCommand cmd = new OracleCommand("select Cluster_code, cluster_name ||'-'||geographical_partition AS NAME from T99_cluster_master where region_code='" + Session["Region"].ToString() + "' and Department_name='" + deptname + "' order by cluster_name asc", conn))
			{
				conn.Open();
				Dropdownlist1.Items.RemoveAt(0);
				Dropdownlist1.DataSource = cmd.ExecuteReader();
				Dropdownlist1.DataValueField = "CLUSTER_CODE";
				Dropdownlist1.DataTextField = "NAME";
				Dropdownlist1.DataBind();
				conn.Close();
				Dropdownlist1.Items.Insert(0, new ListItem("--Select Cluster Name--", "0"));
			}


		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (Dropdownlist1.SelectedIndex == 0)
				{
					DisplayAlert("Cluster Name can not be blank!!!");
				}
				else if (Dropdownlist12.SelectedIndex == 0)
				{
					DisplayAlert("IE Name can not be blank!!!");
				}
				else
				{
					OracleConnection cone = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
					cone.Open();
					OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", cone);
					string ss = Convert.ToString(cmd2.ExecuteScalar());
					cone.Close();

					string CheckString = @"(SELECT IE_CODE FROM t101_IE_CLUSTER  where  CLUSTER_CODE = '" + Dropdownlist1.SelectedItem.Value + "' and DEPARTMENT_CODE='" + Dropdownlist2.SelectedItem.Value + "')";
					OracleCommand commandCheck = new OracleCommand(CheckString, cone);
					cone.Open();
					System.Data.DataSet ds = new DataSet();
					OracleDataAdapter adapter = new OracleDataAdapter(commandCheck);
					adapter.Fill(ds);
					if (ds.Tables[0].Rows.Count != 0)
					{
						if (Convert.ToInt64(ds.Tables[0].Rows[0][0]) == 0)
						{
							string myUpdateQuery = "UPDATE t101_IE_CLUSTER SET IE_CODE='" + Dropdownlist12.SelectedItem.Value + "',USER_ID='" + Session["Uname"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where CLUSTER_CODE='" + Dropdownlist1.SelectedItem.Value + "' and DEPARTMENT_CODE='" + Dropdownlist2.SelectedItem.Value + "'";
							OracleCommand myOracleCommand = new OracleCommand(myUpdateQuery);
							myOracleCommand.Connection = conn;
							conn.Open();
							myOracleCommand.ExecuteNonQuery();
							DisplayAlert("Your Record has been Inserted Successfully!!!");
						}
						else
						{
							DisplayAlert("IE for this Department for this cluster is already entered!!!");
						}
					}
					else
					{
						string sval = Session["Uname"].ToString();
						OracleCommand cmd = new OracleCommand("INSERT INTO t101_IE_CLUSTER(IE_CODE,CLUSTER_CODE,DEPARTMENT_CODE,USER_ID,DATETIME)values('" + Dropdownlist12.SelectedItem.Value + "','" + Dropdownlist1.SelectedItem.Value + "','" + Dropdownlist2.SelectedItem.Value + "','" + Session["Uname"].ToString() + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))", cone);
						//cmd.Connection.Open();
						cmd.ExecuteNonQuery();
						DisplayAlert("Your Record has been inserted Successfully!!!");
						btnSave.Visible = false;
						//Update.Visible=true;

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
				conn.Close();
				conn.Dispose();
			}
		}

		protected void PRINTCLICK(object sender, EventArgs e)
		{
			//	Form1.Visible=false;
			xyz.Visible = false;
			string sql = "select b.IE_NAME,decode(a.DEPARTMENT_CODE,'M','Mechanical','E','Electrical','C','Civil','T','Textiles','Z','M P','') Department,c.CLUSTER_NAME,c.GEOGRAPHICAL_PARTITION from T101_IE_CLUSTER a ,T09_IE b,T99_CLUSTER_MASTER c where a.IE_CODE=b.IE_CD and c.CLUSTER_CODE=a.CLUSTER_CODE and b.IE_REGION='" + Session["Region"].ToString() + "' order by IE_NAME";
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
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>IE NAME</font></b></th>");
				Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>DEPARTMENT NAME</font></b></th>");
				Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>CLUSTER NAME</font></b></th>");
				Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>GEOGRAPHICAL PARTITION</font></b></th>");
				Response.Write("</tr></font>");

				while (reader.Read())
				{
					Response.Write("<tr>");
					Response.Write("<td width='20%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
					Response.Write("<td width='20%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["Department"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CLUSTER_NAME"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["GEOGRAPHICAL_PARTITION"]); Response.Write("</td>");
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

		protected void Button1_Click(object sender, System.EventArgs e)
		{

		}
	}
}