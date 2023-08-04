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

namespace RBS.Master_Items_Form
{
	public partial class Master_Items_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		string ITEM_CD = "";

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here


			if (!(IsPostBack))
			{


				lstDept.Items.Insert(0, new ListItem("-Select Item Descipline", ""));
				ListItem lst5 = new ListItem();
				lst5 = new ListItem();
				lst5.Text = "Mechanical";
				lst5.Value = "M";
				lstDept.Items.Add(lst5);
				lst5 = new ListItem();
				lst5.Text = "Electrical";
				lst5.Value = "E";
				lstDept.Items.Add(lst5);
				lst5 = new ListItem();
				lst5.Text = "Civil";
				lst5.Value = "C";
				lstDept.Items.Add(lst5);
				lst5 = new ListItem();
				lst5.Text = "Textiles";
				lst5.Value = "T";
				lstDept.Items.Add(lst5);
				lst5 = new ListItem();
				lst5.Text = "M & P";
				lst5.Value = "Z";
				lstDept.Items.Add(lst5);

				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				try
				{
					DataSet dsP1 = new DataSet();
					string str3 = "select CO_CD, CO_NAME from T08_IE_CONTROLL_OFFICER where CO_STATUS is null and CO_REGION='" + Session["REGION"] + "' order by CO_NAME ";
					OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
					OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
					ListItem lst3;
					conn1.Open();
					da.SelectCommand = myOracleCommand;
					da.Fill(dsP1, "Table");
					for (int i = 0; i <= dsP1.Tables[0].Rows.Count - 1; i++)
					{
						lst3 = new ListItem();
						lst3.Text = dsP1.Tables[0].Rows[i]["CO_NAME"].ToString();
						lst3.Value = dsP1.Tables[0].Rows[i]["CO_CD"].ToString();
						lstCO.Items.Add(lst3);
					}
					lstCO.Items.Insert(0, "");

					DataSet dsP2 = new DataSet();
					string str2 = "select IE_CD, IE_NAME from T09_IE where IE_STATUS is null and IE_REGION='" + Session["REGION"] + "' order by IE_NAME ";
					OracleDataAdapter da2 = new OracleDataAdapter(str2, conn1);
					OracleCommand myOracleCommand2 = new OracleCommand(str2, conn1);
					ListItem lst2;
					//conn1.Open(); 
					da2.SelectCommand = myOracleCommand2;
					da2.Fill(dsP2, "Table");
					for (int i = 0; i <= dsP2.Tables[0].Rows.Count - 1; i++)
					{
						lst2 = new ListItem();
						lst2.Text = dsP2.Tables[0].Rows[i]["IE_NAME"].ToString();
						lst2.Value = dsP2.Tables[0].Rows[i]["IE_CD"].ToString();
						lstIE.Items.Add(lst2);
					}
					lstIE.Items.Insert(0, "");
					conn1.Close();

				}
				catch (Exception ex)
				{
					string str;
					str = ex.Message;
					string str1 = str.Replace("\n", "");
					Response.Redirect("Error_Form.aspx?err=" + str1);
				}
				finally
				{
					conn1.Close();
					conn1.Dispose();
				}
				if (Convert.ToString(Request.Params["ITEM_CD"]) == null || Convert.ToString(Request.Params["ITEM_CD"]) == "")
				{

					ITEM_CD = "";
					btnSave.Visible = true;
					btnSaveU.Visible = false;
					txtSerialNo.Visible = false;
					Label10.Visible = false;
				}
				else
				{
					ITEM_CD = Convert.ToString(Request.Params["ITEM_CD"].Trim());
					show1();
					btnSave.Visible = false;
					btnSaveU.Visible = true;
				}

				if (Session["Uname"].ToString() == "" && Session["IE_CD"].ToString() != "")
				{
					btnSave.Enabled = false;
					btnSaveU.Enabled = false;
					grdBDetails.Columns[0].Visible = false;
					Panel_1.Visible = false;
					Panel_2.Visible = true;
				}


				fillgrid();
			}
		}

		void show1()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				DataSet dsP4 = new DataSet();
				string str5 = "select ITEM_CD, ITEM_DESC, DEPARTMENT, TIME_FOR_INSP, CHECKSHEET, IE, CM,  to_char(CREATION_REV_DT,'dd/mm/yyyy') CREA_REV_DT from T61_ITEM_MASTER WHERE ITEM_CD='" + ITEM_CD + "'";
				OracleDataAdapter da4 = new OracleDataAdapter(str5, conn1);
				OracleCommand myOracleCommand4 = new OracleCommand(str5, conn1);
				conn1.Open();
				da4.SelectCommand = myOracleCommand4;
				da4.Fill(dsP4, "Table");

				txtSerialNo.Text = dsP4.Tables[0].Rows[0]["ITEM_CD"].ToString();
				txtSerialNo.Visible = true;
				txtSerialNo.Enabled = false;
				Label10.Visible = true;
				txtIDesc.Text = dsP4.Tables[0].Rows[0]["ITEM_DESC"].ToString();
				lstDept.SelectedValue = dsP4.Tables[0].Rows[0]["DEPARTMENT"].ToString();
				//lstDept.Enabled=false;
				txtTimeforInsp.Text = dsP4.Tables[0].Rows[0]["TIME_FOR_INSP"].ToString();
				lstIE.SelectedValue = dsP4.Tables[0].Rows[0]["IE"].ToString();
				lstCO.SelectedValue = dsP4.Tables[0].Rows[0]["CM"].ToString();
				txtDt.Text = dsP4.Tables[0].Rows[0]["CREA_REV_DT"].ToString();
				//txtChksheet.Text=dsP4.Tables[0].Rows[0]["CHECKSHEET"].ToString();

				conn1.Close();
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect("Error_Form.aspx?err=" + str1);
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}




		}
		void fillgrid()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string str1 = "select ITEM_CD, ITEM_DESC, DECODE(DEPARTMENT,'M','MECHANICAL','C','CIVIL','E','ELECTRICAL','T','TEXTILES','Z','M&P') DEPT, TIME_FOR_INSP, 'MASTER_ITEMS_CHECKSHEETS/'||ITEM_CD||'.RAR' CHKSHT from T61_ITEM_MASTER";

				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				DataSet dsP = new DataSet();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdBDetails.Visible = false;
				}
				else
				{
					grdBDetails.Visible = true;
					grdBDetails.DataSource = dsP;
					grdBDetails.DataBind();
					conn1.Close();
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
			this.grdBDetails.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grdBDetails_ItemDataBound);

		}
		#endregion

		protected void btnSaveU_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{

				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				conn1.Open();
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				string myUpdateQuery = "Update T61_ITEM_MASTER  set ITEM_DESC= upper('" + txtIDesc.Text + "'),DEPARTMENT='" + lstDept.SelectedValue + "',TIME_FOR_INSP=" + txtTimeforInsp.Text + ", USER_ID='" + Session["Uname"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'), IE=" + lstIE.SelectedValue + ", CM=" + lstCO.SelectedValue + ", CREATION_REV_DT=to_date('" + txtDt.Text + "','dd/mm/yyyy') where ITEM_CD='" + txtSerialNo.Text + "'";
				OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
				myUpdateCommand.Connection = conn1;
				myUpdateCommand.ExecuteNonQuery();
				conn1.Close();
				upload_master_item_checksheet();

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
			fillgrid();
		}
		private string generate_ITEM_NO()
		{
			string wITEM_NO = "";
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{

				string wctr = Session["Region"].ToString();
				OracleCommand cmd2 = new OracleCommand("Select lpad(nvl(max(to_number(nvl(substr(ITEM_CD,2,6),0))),0)+1,6,'0') w_sno From T61_ITEM_MASTER where substr(ITEM_CD,1,1)='" + wctr + "'", conn1);
				conn1.Open();
				string nc_ser = Convert.ToString(cmd2.ExecuteScalar());
				wITEM_NO = wctr + nc_ser;
				conn1.Close();
				return (wITEM_NO);
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
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{

			string ITEM_NO = generate_ITEM_NO();
			if (ITEM_NO == "-1")
			{
				DisplayAlert("NC Details not available");
			}
			else
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				try
				{
					conn1.Open();

					OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
					string ss = Convert.ToString(cmd2.ExecuteScalar());
					conn1.Close();

					conn1.Open();


					string myInsertQuery = "INSERT INTO T61_ITEM_MASTER(ITEM_CD,ITEM_DESC,DEPARTMENT, TIME_FOR_INSP, CHECKSHEET, USER_ID, DATETIME,IE,CM,CREATION_REV_DT) values('" + ITEM_NO + "',upper('" + txtIDesc.Text.Trim() + "'),'" + lstDept.SelectedValue + "','" + txtTimeforInsp.Text + "', '" + ITEM_NO + "','" + Session["Uname"] + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS')," + lstIE.SelectedValue + "," + lstCO.SelectedValue + ",to_date('" + txtDt.Text + "','dd/mm/yyyy'))";
					OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
					myInsertCommand.Connection = conn1;
					myInsertCommand.ExecuteNonQuery();
					conn1.Close();
					upload_master_item_checksheet();
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
			Response.Redirect("Master_Items_Form.aspx");
		}
		private void upload_master_item_checksheet()
		{
			try
			{
				if (File1.PostedFile != null && File1.PostedFile.ContentLength > 0)
				{
					String fn = "", fx = "";
					fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
					fx = System.IO.Path.GetExtension(File1.PostedFile.FileName).ToUpper();
					if (fx == ".RAR")
					{
						String SaveLocation = null;
						SaveLocation = Server.MapPath("MASTER_ITEMS_CHECKSHEETS/" + txtSerialNo.Text + ".RAR");
						//SaveLocation = Server.MapPath("PO/" + fn);
						//SaveLocation = "//172.16.7.76/madan/"+fn;
						File1.PostedFile.SaveAs(SaveLocation);
						DisplayAlert("The file has been uploaded.");
					}
					else
					{ DisplayAlert("Only RAR files are accepted."); }
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
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Master_Items_Form.aspx");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("MainForm.aspx");
		}

		private void grdBDetails_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			string fpath = Server.MapPath("/RBS/");
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				fpath = fpath + Convert.ToString(e.Item.Cells[5].Text);
				if (File.Exists(fpath) == false)
				{
					e.Item.Cells[5].Text = "<Font Face=Verdana Color=RED>No Checksheet</Font>";
				}
				else
				{
					e.Item.Cells[5].Text = "<a href=" + Convert.ToString(e.Item.Cells[5].Text) + ">Download</a>";
				}
			}
		}
	}
}