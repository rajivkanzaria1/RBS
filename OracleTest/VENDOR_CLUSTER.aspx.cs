using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.VENDOR_CLUSTER
{
	public partial class VENDOR_CLUSTER : System.Web.UI.Page
	{
		OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		protected System.Web.UI.WebControls.Button Delete;
		int code = 0;
		String deptname = "";
		protected System.Web.UI.WebControls.Button btnnameclick;
		public string Action;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			Button3.Attributes.Add("OnClick", "JavaScript:del();");
			Button1.Attributes.Add("OnClick", "JavaScript:validate123();");




			if (!Page.IsPostBack)
			{
				Button3.Visible = false;
				if (Session["Role"].ToString() == "Administrator")
				{

				}
				else
				{
					btnSave.Visible = false;
					Update.Visible = false;
					btnCancel.Visible = false;
					Button2.Visible = false;

				}

				Dropdownlist3.Items.Insert(0, new ListItem("-Select ClusterList item-", ""));

				if (Action == "E")
				{
					//show();
					//Delete.Visible=false;
					Update.Visible = true;
					btnSave.Visible = false;
				}
				else if (Action == "D")
				{
					//show();
					//Delete.Visible=true;
					btnSave.Visible = false;
				}

				// fillgrid();
				ListItem lst5 = new ListItem();
				lst5 = new ListItem();
				lst5.Text = "Mechanical";
				lst5.Value = "M";

				Dropdownlist1.Items.Add(lst5);
				Dropdownlist1.Items.Insert(0, new ListItem("-Select Departmentlist item-", ""));

				lst5 = new ListItem();
				lst5.Text = "Electrical";
				lst5.Value = "E";
				Dropdownlist1.Items.Add(lst5);
				lst5 = new ListItem();
				lst5.Text = "Civil";
				lst5.Value = "C";
				Dropdownlist1.Items.Add(lst5);
				//				lst5 = new ListItem(); 
				//				lst5.Text = "Metallurgy"; 
				//				lst5.Value = "L"; 
				//				Dropdownlist1.Items.Add(lst5); 
				lst5 = new ListItem();
				lst5.Text = "Textiles";
				lst5.Value = "T";
				Dropdownlist1.Items.Add(lst5);
				lst5 = new ListItem();
				lst5.Text = "M & P";
				lst5.Value = "Z";
				Dropdownlist1.Items.Add(lst5);
				if (Convert.ToString(Request.Params["VENDOR_CODE"]) == null || Request.Params["VENDOR_CODE"] == "")
				{
					code = 0;
					Action = "";
				}

				if (Convert.ToString(Request.Params["DEPARTMENT_NAME"]) == null || Convert.ToString(Request.Params["DEPARTMENT_NAME"]) == "")
				{
					code = 0;
					Action = "";
				}

				else
				{
					code = Convert.ToInt32(Request.Params["VENDOR_CODE"].Trim());
					deptname = Request.Params["DEPARTMENT_NAME"].ToString();

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
					//					else if(deptname=="M & P")
					//					{
					//						deptname="Z";
					//					}
					//					else
					//					{
					//						
					//						deptname="T";
					//					}

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


				// Put user code to initialize the page here
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

		public void btnSave_Click(Object Sender, System.EventArgs e)
		{
			try
			{
				if (txtname.Text == "")
				{
					DisplayAlert("PLease Enter vendor Code!!!");
				}
				else if (Dropdownlist1.SelectedIndex == 0)
				{
					DisplayAlert("PLease Select department list item!!!");

				}
				else if (Dropdownlist3.SelectedIndex == 0)
				{
					DisplayAlert("PLease Select Cluster list item!!!");
				}
				else
				{


					OracleConnection cone = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
					cone.Open();
					OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", cone);
					string ss = Convert.ToString(cmd2.ExecuteScalar());
					cone.Close();

					string CheckString = @"(SELECT COUNT(*) FROM T100_VENDER_CLUSTER WHERE VENDOR_CODE = '" + ddlManufac.SelectedItem.Value + "' and  DEPARTMENT_NAME = '" + Dropdownlist1.SelectedItem.Value + "' and CLUSTER_CODE='" + Dropdownlist3.SelectedItem.Value + "')";

					string sval = Session["Uname"].ToString();

					OracleCommand cmd = new OracleCommand("INSERT INTO T100_VENDER_CLUSTER(VENDOR_CODE,DEPARTMENT_NAME,CLUSTER_CODE,USER_ID,DATETIME)values('" + ddlManufac.SelectedItem.Value + "','" + Dropdownlist1.SelectedItem.Value + "','" + Dropdownlist3.SelectedItem.Value + "','" + sval + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))", cone);
					cmd.Connection.Open();
					OracleCommand commandCheck = new OracleCommand(CheckString, cone);
					int Count = Convert.ToInt32(commandCheck.ExecuteScalar());

					if (Count > 0)
					{
						DisplayAlert("Cluster for this vender and department is already entered!!!");
					}
					else
					{
						cmd.ExecuteNonQuery();
						DisplayAlert("Your Record has been inserted Successfully!!!");
						//fillgrid();

						btnSave.Visible = false;
						Button3.Visible = true;
						//Update.Visible=true;
						//Delete.Visible=true;
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

			}
		}

		protected void Search(object sender, System.EventArgs e)
		{
			OracleConnection cone = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				if (txtname.Text == "" && Dropdownlist1.SelectedIndex == 0)
				{
					DisplayAlert("Please Enter VENDER CODE OR VENDER CODE AND DEPARTMENT NAME!!!");
				}
				else
				{

					DataSet dsP = new DataSet();
					//string str1="select a.VENDOR_CODE,a.DEPARTMENT_NAME, c.VENDOR,b.CLUSTER_NAME,a.CLUSTER_CODE from T100_VENDER_CLUSTER a,T99_CLUSTER_MASTER b,V05_VENDOR c where b.CLUSTER_CODE=a.CLUSTER_CODE and c.VEND_CD=a.VENDOR_CODE";
					string str1 = "select a.VENDOR_CODE,a.DEPARTMENT_NAME, c.VENDOR,c.VEND_CD,b.CLUSTER_NAME,a.CLUSTER_CODE from T100_VENDER_CLUSTER a,T99_CLUSTER_MASTER b,V05_VENDOR c where b.CLUSTER_CODE=a.CLUSTER_CODE and c.VEND_CD=a.VENDOR_CODE  and b.REGION_CODE='" + Session["Region"].ToString() + "'";
					if (txtname.Text.Trim() != "")
					{
						str1 = str1 + " and a.VENDOR_CODE =" + txtname.Text.Trim() + "";
					}
					//					else
					//					{
					//						str1 =str1 + " and VENDOR_CODE =''";
					//					}

					if (Dropdownlist1.SelectedItem.Value != "" && Dropdownlist1.SelectedIndex != 0)
					{
						str1 = str1 + " and a.DEPARTMENT_NAME ='" + Dropdownlist1.SelectedItem.Value + "' ";

					}
					if (Dropdownlist3.SelectedItem.Value != "" && Dropdownlist3.SelectedIndex != 0)
					{
						str1 = str1 + " and a.CLUSTER_CODE =" + Dropdownlist3.SelectedItem.Value + " ";

					}


					str1 = str1 + "order by a.VENDOR_CODE,b.CLUSTER_NAME ";


					OracleDataAdapter da = new OracleDataAdapter(str1, cone);
					OracleCommand myOracleCommand = new OracleCommand(str1, cone);
					cone.Open();
					da.SelectCommand = myOracleCommand;
					da.Fill(dsP);
					cone.Close();
					if (dsP.Tables[0].Rows.Count == 0)
					{
						//throw new System.Exception("No Record Found!!! For the given cluster Name.");
						DisplayAlert("No Record Found!!! For the given VENDER .");
						grdBook.DataSource = null;
						grdBook.DataBind();
					}
					else
					{


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


						String venderaddress = dsP.Tables[0].Rows[0]["VENDOR_CODE"].ToString();
						String vendorcode = string.Empty;



						using (OracleCommand cmd1 = new OracleCommand("Select  VENDOR,VEND_CD from V05_Vendor where VEND_CD=" + venderaddress + "", cone))
						{
							//											OracleCommand myOracleCommand12 = new OracleCommand(cmd1, cone); 
							//											OracleDataAdapter da12 = new OracleDataAdapter(cmd1, cone); 
							OracleDataAdapter dt = new OracleDataAdapter(cmd1);
							cone.Open();
							DataSet ds1 = new DataSet();
							dt.Fill(ds1);
							cone.Close();
							venderaddress = ds1.Tables[0].Rows[0]["VENDOR"].ToString();
							vendorcode = ds1.Tables[0].Rows[0]["VEND_CD"].ToString();


						}
						dsP.Tables[0].Rows[0]["VENDOR"] = venderaddress;
						dsP.Tables[0].Rows[0]["VEND_CD"] = vendorcode;

						//ds.Tables[0].Rows[0]["VENDOR_CODE"].ToString()=vnm;





						grdBook.DataSource = dsP;
						grdBook.DataBind();
					}
				}
			}

			//                    string VenderName=dsP.Tables[0].Rows[0]["VENDOR_CODE"].ToString();
			//					string str11="select VEND_NAME from t05_vendor where vend_cd="+VenderName+"";
			//					OracleCommand myOracleCommand1 = new OracleCommand(str11, cone); 
			//					OracleDataAdapter da1 = new OracleDataAdapter(str11, cone); 
			//					cone.Open();
			//					DataSet ds=new DataSet();
			//					da1.Fill(ds);
			//					cone.Close();
			//                    string vnm=ds.Tables[0].Rows[0]["VEND_NAME"].ToString();
			////dsP.Tables[0].Rows[0]["VENDOR_CODE"]=vnm;



			//
			//			        string  ClusterName=dsP.Tables[0].Rows[0]["CLUSTER_CODE"].ToString();
			//					string str111="select Cluster_name from t99_cluster_master where cluster_code="+ClusterName+"";
			//					OracleCommand myOracleCommand2 = new OracleCommand(str111, cone); 
			//					OracleDataAdapter da2 = new OracleDataAdapter(str111, cone); 
			//					cone.Open();
			//					DataSet ds1=new DataSet();
			//					da.Fill(ds1,"Table");
			//					cone.Close();
			//					String clusname=ds1.Tables[0].Rows[0]["Cluster_name"].ToString();
			//dsP.Tables[0].Rows[0]["CLUSTER_CODE"]=clusname;




			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
				//DisplayAlert("Please Select Vender code or vendor code and department name");


			}
			finally
			{
				cone.Close();
			}
		}

		void showlist(int code, String deptname)
		{
			OracleConnection cone = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			DataSet dsP = new DataSet();
			string str1 = "select VENDOR_CODE,DEPARTMENT_NAME,CLUSTER_CODE from T100_VENDER_CLUSTER where VENDOR_CODE=" + code + " and DEPARTMENT_NAME='" + deptname + "'";
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
				txtname.Text = dsP.Tables[0].Rows[0]["VENDOR_CODE"].ToString();
				Dropdownlist1.SelectedValue = dsP.Tables[0].Rows[0]["DEPARTMENT_NAME"].ToString();
				//int ClusterCode=Convert.ToInt32(dsP.Tables[0].Rows[0]["CLUSTER_CODE"]);



				using (OracleCommand cmd = new OracleCommand("Select CLUSTER_CODE,CLUSTER_NAME from t99_cluster_master where DEPARTMENT_NAME='" + Dropdownlist1.SelectedItem.Value + "'and region_code='" + Session["Region"].ToString() + "' order by CLUSTER_NAME", cone))
				{
					cone.Open();
					Dropdownlist3.DataSource = cmd.ExecuteReader();
					Dropdownlist3.DataValueField = "CLUSTER_CODE";
					Dropdownlist3.DataTextField = "CLUSTER_NAME";
					Dropdownlist3.DataBind();
					cone.Close();
				}
				String clustercode = dsP.Tables[0].Rows[0]["CLUSTER_CODE"].ToString();
				Dropdownlist3.SelectedValue = clustercode;

				//Dropdownlist3.SelectedValue = dsP.Tables[0].Rows[0]["CLUSTER_CODE"].ToString(); 



				//  Dropdownlist3.=clustername.ToString();
				btnSave.Visible = false;
				Update.Visible = true;
				Button3.Visible = true;
				btnCancel.Visible = false;
			}
		}


		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}


		public void Update_Click(Object Sender, System.EventArgs e)
		{
			try
			{
				OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				conn.Open();
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn);
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				conn.Close();
				string sval = Session["Uname"].ToString();

				string Code = txtname.Text;
				String DepartmentName = Dropdownlist1.SelectedItem.Value;
				string myDeleteQuery = "UPDATE T100_VENDER_CLUSTER SET CLUSTER_CODE='" + Dropdownlist3.SelectedItem.Value + "',USER_ID='" + sval + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where VENDOR_CODE=" + Code + " and DEPARTMENT_NAME= '" + Dropdownlist1.SelectedItem.Value + "'";
				conn.Open();
				OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
				myOracleCommand.Connection = conn;
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

		}


		protected void departmentchanged(Object Sender, System.EventArgs e)
		{
			string deptname = Dropdownlist1.SelectedItem.Value;
			OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			using (OracleCommand cmd = new OracleCommand("select Cluster_code,cluster_name ||'-'||geographical_partition AS NAME from T99_cluster_master where region_code='" + Session["Region"].ToString() + "' and Department_name='" + deptname + "' order by cluster_name asc", conn))
			{
				conn.Open();

				Dropdownlist3.Items.RemoveAt(0);
				Dropdownlist3.DataSource = cmd.ExecuteReader();
				Dropdownlist3.DataValueField = "CLUSTER_CODE";
				Dropdownlist3.DataTextField = "NAME";
				Dropdownlist3.DataBind();
				conn.Close();
				Dropdownlist3.Items.Insert(0, new ListItem("--Select Cluster Name--", "0"));
			}


		}
		public void Delete_Click(Object Sender, System.EventArgs e)

		{
			try
			{
				string Code = txtname.Text;
				String DepartmentName = Dropdownlist1.SelectedItem.Value;
				string myDeleteQuery = "Delete T100_VENDER_CLUSTER where  VENDOR_CODE=" + Code + " and DEPARTMENT_NAME='" + Dropdownlist1.SelectedItem.Value + "'";
				OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
				myOracleCommand.Connection = conn;
				conn.Open();
				myOracleCommand.ExecuteNonQuery();
				DisplayAlert("Your Record has been Deleted Successfully!!!");


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

		void manufac_details()
		{

			OracleCommand cmd = new OracleCommand("select VEND_ADD1,VEND_CONTACT_PER_1,VEND_CONTACT_TEL_1,VEND_STATUS,to_char(VEND_STATUS_DT_FR,'dd/mm/yyyy')VEND_STATUS_FR,to_char(VEND_STATUS_DT_TO,'dd/mm/yyyy')VEND_STATUS_TO,VEND_EMAIL from T05_VENDOR where VEND_CD=" + ddlManufac.SelectedValue, conn);
			conn.Open();
			OracleDataReader reader = cmd.ExecuteReader();
			if (reader.HasRows == true)
			{
				while (reader.Read())
				{
					if (Convert.ToString(reader["VEND_STATUS"]) == "B")
					{
						DisplayAlert("This Manufacturer is Blacklisted From:" + Convert.ToString(reader["VEND_STATUS_FR"]) + " TO: " + Convert.ToString(reader["VEND_STATUS_TO"]));
						txtname.Text = "";
						ddlManufac.Visible = false;

					}
					else
					{
						txtplaceofinspection.Text = Convert.ToString(reader["VEND_ADD1"]);
					}

				}
			}
			else
			{

			}
			conn.Close();
		}

		public void CancelAll(Object Sender, System.EventArgs e)

		{
			txtname.Text = "";
			ddlManufac.Items.Clear();
			Dropdownlist1.SelectedIndex = -1;
			Dropdownlist3.SelectedIndex = -1;
			txtplaceofinspection.Text = "";
			btnSave.Visible = true;
			Update.Visible = false;

		}

		protected void btnclick(Object Sender, System.EventArgs e)
		{
			ddlManufac.Visible = true;

			try
			{
				if (Convert.ToInt32(txtname.Text) >= 1 && Convert.ToInt32(txtname.Text) <= 999999)
				{

					string str1 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(VEND_CD)=" + txtname.Text.Trim() + " and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
					int a = fill_manufacturer(str1);
					if (a == 1)
					{
						ddlManufac.Visible = false;

						DisplayAlert("No Manufacturer Found!!!");

					}
					else if (a == 2)
					{
						txtname.Text = ddlManufac.SelectedValue;
						manufac_details();
						rbs.SetFocus(ddlManufac);
					}
				}
				else
				{
					DisplayAlert("Invalid Manufacturer Code!!!");
					ddlManufac.Items.Clear();
					ddlManufac.Visible = false;

				}
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = "Input string was not in a correct format.";
				if (str.Equals(str1))
				{
					string str2 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(upper(VEND_NAME)) LIKE upper('" + txtname.Text.Trim() + "%') and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
					int a = fill_manufacturer(str2);
					if (a == 1)
					{
						ddlManufac.Visible = false;

						DisplayAlert("No Manufacturer Found!!!");

					}
					else if (a == 2)
					{
						txtname.Text = ddlManufac.SelectedValue;
						manufac_details();
						rbs.SetFocus(ddlManufac);
					}
				}
				else
				{
					string str2 = str.Replace("\n", "");
					Response.Redirect("Error_Form.aspx?err=" + str2);
				}

			}
			finally
			{
				conn.Close();
			}
		}

		int fill_manufacturer(string str1)
		{
			int ecode = 0;
			ddlManufac.Items.Clear();
			DataSet dsP = new DataSet();
			OracleDataAdapter da = new OracleDataAdapter(str1, conn);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn);
			ListItem lst;
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			if (dsP.Tables[0].Rows.Count == 0)
			{
				ecode = 1;
				return (ecode);
			}
			else
			{
				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					lst = new ListItem();
					lst.Text = dsP.Tables[0].Rows[i]["VEND_NAME"].ToString();
					lst.Value = dsP.Tables[0].Rows[i]["VEND_CD"].ToString();
					ddlManufac.Items.Add(lst);
				}
				ddlManufac.Visible = true;
				ddlManufac.SelectedIndex = 0;
				ecode = 2;
				return (ecode);

			}

		}

		protected void ddlchanged(Object Sender, System.EventArgs e)
		{

			txtname.Text = ddlManufac.SelectedValue;
			manufac_details();

		}


		protected void PRINTCLICK(object sender, EventArgs e)
		{
			//abc.visisble=false;
			//xyz.Visisble=false;
			xyz.Visible = false;

			string sql = "select  c.VENDOR,b.CLUSTER_NAME,b.GEOGRAPHICAL_PARTITION,decode(a.department_name,'M','Mechanical','E','Electrical','C','Civil','T','Textiles','Z','M P','') Department from T100_VENDER_CLUSTER a,T99_CLUSTER_MASTER b,V05_VENDOR c where b.CLUSTER_CODE=a.CLUSTER_CODE and c.VEND_CD=a.VENDOR_CODE and b.region_code='" + Session["Region"].ToString() + "' order by c.VENDOR";
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
				Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>VENDOR NAME</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>DEPARTMENT NAME</font></b></th>");
				Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>CLUSTER NAME</font></b></th>");
				Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>GEOGRAPHICAL PARTITION</font></b></th>");
				Response.Write("</tr></font>");
				while (reader.Read())
				{
					Response.Write("<tr>");
					Response.Write("<td width='20%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["VENDOR"]); Response.Write("</td>");
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
	}
}