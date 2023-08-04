using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Training_Form
{
	public partial class Training_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!(IsPostBack))
			{
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
				lst5.Text = "Metallurgy";
				lst5.Value = "L";
				lstDept.Items.Add(lst5);
				lst5 = new ListItem();
				lst5.Text = "Textiles";
				lst5.Value = "T";
				lstDept.Items.Add(lst5);
				lst5 = new ListItem();
				lst5.Text = "Power Engineering";
				lst5.Value = "P";
				lstDept.Items.Add(lst5);
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				try
				{
					DataSet dsP1 = new DataSet();
					string str3 = "select IE_CD, IE_NAME from T09_IE where IE_STATUS is null and IE_REGION='" + Session["REGION"] + "' order by IE_NAME ";
					OracleDataAdapter da = new OracleDataAdapter(str3, conn1);
					OracleCommand myOracleCommand = new OracleCommand(str3, conn1);
					ListItem lst3;
					conn1.Open();
					da.SelectCommand = myOracleCommand;
					da.Fill(dsP1, "Table");
					for (int i = 0; i <= dsP1.Tables[0].Rows.Count - 1; i++)
					{
						lst3 = new ListItem();
						lst3.Text = dsP1.Tables[0].Rows[i]["IE_NAME"].ToString();
						lst3.Value = dsP1.Tables[0].Rows[i]["IE_CD"].ToString();
						lstIEORCM.Items.Add(lst3);
					}
					conn1.Close();
					lstIEORCM.Items.Insert(0, "");
					lstCategory.Items.Insert(0, "");
					lstQual.Items.Insert(0, "");
					lstTType.Items.Insert(0, "");
					lstField.Items.Insert(0, "");
					lstDept.Items.Insert(0, "");


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

		//		private void rdbAllIE_CheckedChanged(object sender, System.EventArgs e)
		//		{
		//			conn1=new System.Data.OracleClient.OracleConnection((ConfigurationSettings.AppSettings["ConnectionString"])) ;
		//
		//			if(rdbIE.Checked==true)
		//			{
		//				try
		//				{
		//					DataSet dsP1 = new DataSet(); 
		//					string str3 = "select IE_CD, IE_NAME from T09_IE where IE_STATUS is null and IE_REGION='"+Session["REGION"]+"' order by IE_NAME "; 
		//					OracleDataAdapter da = new OracleDataAdapter(str3, conn1); 
		//					OracleCommand myOracleCommand = new OracleCommand(str3, conn1); 
		//					ListItem lst3; 
		//					conn1.Open(); 
		//					da.SelectCommand = myOracleCommand; 
		//					da.Fill(dsP1, "Table"); 
		//					for (int i = 0; i <= dsP1.Tables[0].Rows.Count - 1; i++) 
		//					{ 
		//						lst3 = new ListItem(); 
		//						lst3.Text = dsP1.Tables[0].Rows[i]["IE_NAME"].ToString(); 
		//						lst3.Value = dsP1.Tables[0].Rows[i]["IE_CD"].ToString(); 
		//						lstIEORCM.Items.Add(lst3); 
		//					} 
		//					conn1.Close(); 
		//					lstIEORCM.Items.Insert(0,"");
		//				}
		//				catch (Exception ex) 
		//				{ 
		//					string str; 
		//					str = ex.Message; 
		//					string str1=str.Replace("\n","");
		//					Response.Redirect("Error_Form.aspx?err="+str1); 
		//				}
		//				finally
		//				{
		//					conn1.Close(); 
		//					conn1.Dispose();
		//				} 
		//			
		//			}
		//			else if(rdbCM.Checked==true)
		//			{
		//				try
		//				{
		//				
		//					DataSet dsP1 = new DataSet(); 
		//					string str3 = "select CO_CD, CO_NAME from T08_IE_CONTROLL_OFFICER where CO_STATUS is null and CO_REGION='"+Session["REGION"]+"' order by CO_NAME "; 
		//					OracleDataAdapter da = new OracleDataAdapter(str3, conn1); 
		//					OracleCommand myOracleCommand = new OracleCommand(str3, conn1); 
		//					ListItem lst3; 
		//					conn1.Open(); 
		//					da.SelectCommand = myOracleCommand; 
		//					da.Fill(dsP1, "Table"); 
		//					for (int i = 0; i <= dsP1.Tables[0].Rows.Count - 1; i++) 
		//					{ 
		//						lst3 = new ListItem(); 
		//						lst3.Text = dsP1.Tables[0].Rows[i]["CO_NAME"].ToString(); 
		//						lst3.Value = dsP1.Tables[0].Rows[i]["CO_CD"].ToString(); 
		//						lstIEORCM.Items.Add(lst3); 
		//					} 
		//					conn1.Close();
		//				}
		//				catch (Exception ex) 
		//				{ 
		//					string str; 
		//					str = ex.Message; 
		//					string str1=str.Replace("\n","");
		//					Response.Redirect("Error_Form.aspx?err="+str1); 
		//				}
		//				finally
		//				{
		//					conn1.Close(); 
		//					conn1.Dispose();
		//				} 
		//			}
		//		}

		protected void lstIEORCM_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			try
			{
				string query = "Select NAME,TO_CHAR(DOJ,'DD/MM/YYYY') JOIN_DT, TO_CHAR(DOB,'DD/MM/YYYY') DOB,DESCIPLINE,EMP_NO,CATEGORY,CATEGORY_OTHER,QUALIFICATION,QUAL_OTHER,QUAL_INSTITUTE,REGION from TRAINEE_EMPLOYEE_MASTER where IE_CD=" + lstIEORCM.SelectedValue;
				DataSet dsP1 = new DataSet();
				OracleDataAdapter da = new OracleDataAdapter(query, conn1);
				OracleCommand myOracleCommand = new OracleCommand(query, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP1, "Table");
				conn1.Close();


				if (dsP1.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i <= dsP1.Tables[0].Rows.Count - 1; i++)

					{
						txtDOB.Text = dsP1.Tables[0].Rows[i]["DOB"].ToString();
						txtDOJ.Text = dsP1.Tables[0].Rows[i]["JOIN_DT"].ToString();
						lstDept.SelectedValue = dsP1.Tables[0].Rows[i]["DESCIPLINE"].ToString();
						txtEmpNo.Text = dsP1.Tables[0].Rows[i]["EMP_NO"].ToString();
						lstCategory.SelectedValue = dsP1.Tables[0].Rows[i]["CATEGORY"].ToString();
						txtCatOth.Text = dsP1.Tables[0].Rows[i]["CATEGORY_OTHER"].ToString();
						lstQual.SelectedValue = dsP1.Tables[0].Rows[i]["QUALIFICATION"].ToString();
						txtQualOther.Text = dsP1.Tables[0].Rows[i]["QUAL_OTHER"].ToString();
						txtInst.Text = dsP1.Tables[0].Rows[i]["QUAL_INSTITUTE"].ToString();
						btnSave.Visible = false;

					}
					conn1.Close();
				}
				else
				{
					string query1 = "Select IE_NAME,TO_CHAR(IE_JOIN_DT,'DD/MM/YYYY') JOIN_DT, TO_CHAR(IE_DOB,'DD/MM/YYYY') DOB,IE_DEPARTMENT,IE_EMP_NO from T09_IE where IE_CD=" + lstIEORCM.SelectedValue;
					conn1.Open();
					OracleCommand Command1 = new OracleCommand(query1, conn1);
					OracleDataReader reader1 = Command1.ExecuteReader();
					while (reader1.Read())
					{
						txtDOB.Text = reader1["DOB"].ToString();
						txtDOJ.Text = reader1["JOIN_DT"].ToString();
						lstDept.SelectedValue = reader1["IE_DEPARTMENT"].ToString();
						txtEmpNo.Text = reader1["IE_EMP_NO"].ToString();
						lstCategory.SelectedIndex = 0;
						txtCatOth.Text = "";
						lstQual.SelectedIndex = 0;
						txtQualOther.Text = "";
						txtInst.Text = "";
						btnSave.Visible = true;

					}
					conn1.Close();
				}
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

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			try
			{
				string myInsertQuery = "INSERT INTO TRAINEE_EMPLOYEE_MASTER (IE_CD,NAME,DOB,DOJ,EMP_NO,DESCIPLINE,CATEGORY,CATEGORY_OTHER,QUALIFICATION,QUAL_OTHER,QUAL_INSTITUTE,REGION)values(" + lstIEORCM.SelectedValue + ",'" + lstIEORCM.SelectedItem.Text + "',to_date('" + txtDOB.Text.Trim() + "','dd/mm/yyyy'),to_date('" + txtDOJ.Text + "','dd/mm/yyyy'),'" + txtEmpNo.Text.Trim() + "','" + lstDept.SelectedItem.Value + "','" + lstCategory.SelectedValue + "','" + txtCatOth.Text + "','" + lstQual.SelectedValue + "','" + txtQualOther.Text + "','" + txtInst.Text.Trim() + "','" + Session["REGION"].ToString() + "')";
				OracleCommand myInsertCommand = new OracleCommand();
				conn1.Open();
				myInsertCommand.CommandText = myInsertQuery;
				myInsertCommand.Connection = conn1;
				myInsertCommand.ExecuteNonQuery();
				conn1.Close();
				DisplayAlert("Your Record is Saved!!!");
				btnSave.Visible = false;
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

		protected void btnAddNew_Click(object sender, System.EventArgs e)
		{
			//Response.Redirect("Training_Form.aspx");
			lstIEORCM.SelectedIndex = 0;
			txtEmpNo.Text = "";
			txtDOB.Text = "";
			txtDOJ.Text = "";
			lstDept.SelectedIndex = 0;
			lstCategory.SelectedIndex = 0;
			txtCatOth.Text = "";
			lstQual.SelectedIndex = 0;
			txtQualOther.Text = "";
			txtInst.Text = "";
			btnSave.Visible = true;
		}

		protected void lstCategory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lstCategory.SelectedValue == "O")
			{
				txtCatOth.Visible = true;

			}
			else
			{
				txtCatOth.Visible = false;
			}
		}

		protected void lstQual_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lstQual.SelectedValue == "O")
			{
				txtQualOther.Visible = true;

			}
			else
			{
				txtQualOther.Visible = false;
			}
		}

		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			try
			{

				OracleCommand cmd1 = new OracleCommand("select NVL(count(*),0) from TRAINING_COURSE_MASTER WHERE TRAINING_TYPE='" + lstTType.SelectedValue + "' AND TRAINING_FIELD='" + lstField.SelectedValue + "' AND REGION='" + Session["REGION"] + "' ", conn1);
				conn1.Open();
				int course_count = Convert.ToInt16(cmd1.ExecuteScalar());
				conn1.Close();
				string tr_categ = "";
				if (rdbIn.Checked == true)
				{
					tr_categ = "I";
				}
				else
				{
					tr_categ = "O";
				}

				if (course_count == 0 || lstCourse.SelectedValue == "" || txtCourse.Text == "")
				{
					conn1.Open();
					OracleCommand cmd2 = new OracleCommand("Select lpad(nvl(max(to_number(nvl(substr(COURSE_ID,2,4),0))),0)+1,4,'0')  From TRAINING_COURSE_MASTER where substr(COURSE_ID,1,1)='" + Session["Region"].ToString() + "'", conn1);
					string course_id = Convert.ToString(cmd2.ExecuteScalar());
					course_id = Session["Region"].ToString() + course_id;
					string myInsertQuery = "INSERT INTO TRAINING_COURSE_MASTER (COURSE_ID,TRAINING_TYPE,TRAINING_FIELD,COURSE_NAME,COURSE_INSTITUTE,COURSE_DUR_FR,COURSE_DUR_TO,CERTIFICATE,FEES,VALIDITY,REGION,TRAINING_CATEGORY) values ('" + course_id + "','" + lstTType.SelectedValue + "','" + lstField.SelectedValue + "','" + txtCourse.Text + "','" + txtCInst.Text + "',to_date('" + txtFrom.Text.Trim() + "','dd/mm/yyyy'),to_date('" + txtTo.Text + "','dd/mm/yyyy'),'" + txtCert.Text.Trim() + "'," + txtFees.Text + ",'" + txtValidity.Text + "','" + Session["REGION"].ToString() + "','" + tr_categ + "')";
					OracleCommand myInsertCommand = new OracleCommand();
					myInsertCommand.CommandText = myInsertQuery;
					myInsertCommand.Connection = conn1;
					myInsertCommand.ExecuteNonQuery();
					conn1.Close();

					string myInsertQuery1 = "INSERT INTO TRAINING_DETAILS (IE_CD,COURSE_ID) values ('" + lstIEORCM.SelectedValue + "','" + course_id + "')";
					OracleCommand myInsertCommand1 = new OracleCommand();
					conn1.Open();
					myInsertCommand1.CommandText = myInsertQuery1;
					myInsertCommand1.Connection = conn1;
					myInsertCommand1.ExecuteNonQuery();
					conn1.Close();
				}
				else
				{
					string myInsertQuery1 = "INSERT INTO TRAINING_DETAILS (IE_CD,COURSE_ID) values ('" + lstIEORCM.SelectedValue + "','" + lstCourse.SelectedValue + "')";
					OracleCommand myInsertCommand1 = new OracleCommand();
					conn1.Open();
					myInsertCommand1.CommandText = myInsertQuery1;
					myInsertCommand1.Connection = conn1;
					myInsertCommand1.ExecuteNonQuery();
					conn1.Close();
				}
				DisplayAlert("Your Record is Saved!!!");
				btnSubmit.Visible = false;
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

		protected void btnAddNew1_Click(object sender, System.EventArgs e)
		{
			lstTType.SelectedIndex = 0;
			lstField.SelectedIndex = 0;
			lstCourse.SelectedIndex = 0;
			txtCourse.Text = "";
			txtCInst.Text = "";
			txtFrom.Text = "";
			txtTo.Text = "";
			txtCert.Text = "";
			txtFees.Text = "";
			txtValidity.Text = "";
			//lstCourse.Visible=false;
			btnSubmit.Visible = true;
		}

		protected void lstField_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			try
			{
				DataSet dsP = new DataSet();
				string str = "select COURSE_ID, COURSE_NAME||'('||to_char(COURSE_DUR_FR,'dd/mm/yyyy')||to_char(COURSE_DUR_TO,'dd/mm/yyyy')||')' COURSE from TRAINING_COURSE_MASTER WHERE TRAINING_TYPE='" + lstTType.SelectedValue + "' AND TRAINING_FIELD='" + lstField.SelectedValue + "' AND REGION='" + Session["REGION"] + "' order by COURSE_NAME||to_char(COURSE_DUR_FR,'dd/mm/yyyy')||to_char(COURSE_DUR_TO,'dd/mm/yyyy') ";
				OracleDataAdapter da = new OracleDataAdapter(str, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str, conn1);
				ListItem lst;
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count >= 0)
				{
					for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
					{
						lst = new ListItem();
						lst.Text = dsP.Tables[0].Rows[i]["COURSE"].ToString();
						lst.Value = dsP.Tables[0].Rows[i]["COURSE_ID"].ToString();
						lstCourse.Items.Add(lst);
					}
				}
				else
				{
					lstCourse.Visible = false;

				}
				conn1.Close();
				lstCourse.Items.Insert(0, "");
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

		protected void lstCourse_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string query = "Select COURSE_ID,TRAINING_TYPE,TRAINING_FIELD,COURSE_NAME,COURSE_INSTITUTE,to_char(COURSE_DUR_FR,'dd/mm/yyyy') COURSE_DUR_FR,to_char(COURSE_DUR_TO,'dd/mm/yyyy') COURSE_DUR_TO,CERTIFICATE,FEES,VALIDITY,REGION,TRAINING_CATEGORY from TRAINING_COURSE_MASTER where COURSE_ID='" + lstCourse.SelectedValue + "'";
				conn1.Open();
				OracleCommand Command = new OracleCommand(query, conn1);
				OracleDataReader reader = Command.ExecuteReader();
				while (reader.Read())
				{
					txtCourse.Text = reader["COURSE_NAME"].ToString();
					txtCInst.Text = reader["COURSE_INSTITUTE"].ToString();
					txtFrom.Text = reader["COURSE_DUR_FR"].ToString();
					txtTo.Text = reader["COURSE_DUR_TO"].ToString();
					txtCert.Text = reader["CERTIFICATE"].ToString();
					txtFees.Text = reader["FEES"].ToString();
					txtValidity.Text = reader["VALIDITY"].ToString();
					if (reader["TRAINING_CATEGORY"].ToString() == "I")
					{
						rdbIn.Checked = true;
					}
					else
					{
						rdbOut.Checked = true;
					}

				}
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

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}


	}
}