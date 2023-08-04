using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.User_Edit
{
	public partial class User_Edit : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		DataSet dsP = new DataSet();
		string Ucode;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			OracleCommand cmd = new OracleCommand("Select nvl(ALLOW_UP_CHKSHT,'N') From T02_USERS Where USER_ID='" + Session["Uname"] + "'", conn1);
			lblDL.Text = Convert.ToString(cmd.ExecuteScalar());
			conn1.Close();
			//
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			if (Session["Uname"].ToString() == "")
			{
				Response.Redirect("Login_Form.aspx");
			}
			Ucode = Request.QueryString["USER_ID"].ToString();
			if (!(IsPostBack))
			{
				try
				{
					//					ListItem lst1 = new ListItem(); 
					//					lstRitesEmp.Items.Add(lst1); 
					//					lst1 = new ListItem(); 
					//					lst1.Text = "Yes"; 
					//					lst1.Value = "Y"; 
					//					lstRitesEmp.Items.Add(lst1); 
					//					lst1 = new ListItem(); 
					//					lst1.Text = "No"; 
					//					lst1.Value = "N"; 
					//					lstRitesEmp.Items.Add(lst1); 
					ListItem lst2 = new ListItem();
					lst2 = new ListItem();
					lst2.Text = "General User";
					lst2.Value = "4";
					lstRole.Items.Add(lst2);
					lst2 = new ListItem();
					lst2.Text = "Data Entry Operator";
					lst2.Value = "2";
					lstRole.Items.Add(lst2);
					lst2 = new ListItem();
					lst2.Text = "Inspection Engineer";
					lst2.Value = "3";
					lstRole.Items.Add(lst2);
					//					lst2 = new ListItem(); 
					//					lst2.Text = "Administrator"; 
					//					lst2.Value = "1"; 
					//					lstRole.Items.Add(lst2); 
					ListItem lst4 = new ListItem();
					lstStatus.Items.Add(lst4);

					lst4 = new ListItem();
					lst4.Text = "InActive";
					lst4.Value = "I";
					lstStatus.Items.Add(lst4);
					lst4 = new ListItem();
					lst4.Text = "Active";
					lst4.Value = "A";
					lstStatus.Items.Add(lst4);

					DataSet dsP = new DataSet();
					string str1 = "select * from T01_REGIONS";
					OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
					OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
					ListItem lst;
					conn1.Open();
					da.SelectCommand = myOracleCommand;
					da.Fill(dsP, "Table");
					for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
					{
						lst = new ListItem();
						lst.Text = dsP.Tables[0].Rows[i]["REGION"].ToString();
						lst.Value = dsP.Tables[0].Rows[i]["REGION_CODE"].ToString();
						lstRegion.Items.Add(lst);
					}
					conn1.Close();
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
				}
				//conn1.Close(); 

				if ((Ucode == ""))
				{
					Label3.Visible = true;
					Label7.Visible = true;
					//Label10.Visible =true;
					txtEmpNo.Visible = true;
					lstRegion.Visible = true;
					//Label9.Visible = true; 
					//lstStatus.Visible = true; 
					lstStatus.SelectedValue = "I";
					txtUID.Text = "";
					txtEmpNo.Text = "";
					txtUID.Text = "";
					txtUName.Text = "";
					lstRegion.SelectedValue = "N";
					//lstRitesEmp.SelectedValue = "N"; 
					lstRole.SelectedValue = "4";
					lstStatus.SelectedValue = "A";
				}
				else
				{
					int err_cd = 0;
					try
					{
						DataSet dsP1 = new DataSet();
						string str1 = "select USER_ID,USER_NAME,RITES_EMP,EMP_NO,REGION,PASSWORD,AUTH_LEVL,NVL(STATUS,'A') STATUS,ALLOW_PO,nvl(ALLOW_DN_CHKSHT,'N')ALLOW_DN_CHKSHT,CALL_MARKING,CALL_REMARKING from T02_USERS where USER_ID= '" + Ucode + "'";
						OracleDataAdapter da1 = new OracleDataAdapter(str1, conn1);
						OracleCommand myOracleCommand1 = new OracleCommand(str1, conn1);
						conn1.Open();
						da1.SelectCommand = myOracleCommand1;
						da1.Fill(dsP1, "Table");
						if (dsP1.Tables[0].Rows[0]["AUTH_LEVL"].ToString() == "1")
						{
							err_cd = 1;
							throw new System.Exception();
						}
						else
						{
							txtUID.Text = dsP1.Tables[0].Rows[0]["USER_ID"].ToString();
							txtUName.Text = dsP1.Tables[0].Rows[0]["USER_NAME"].ToString();
							//lstRitesEmp.SelectedValue = dsP1.Tables[0].Rows[0]["RITES_EMP"].ToString (); 
							lstStatus.SelectedValue = dsP1.Tables[0].Rows[0]["STATUS"].ToString();
							lstRole.SelectedValue = dsP1.Tables[0].Rows[0]["AUTH_LEVL"].ToString();

							//						if ((lstRitesEmp.SelectedValue) == "Y") 
							//						{ 
							//							Label3.Visible = true; 
							//							Label7.Visible = true; 
							//							txtEmpNo.Visible = true; 
							//							lstRegion.Visible = true; 
							//							//Label9.Visible = true; 
							//							//lstStatus.Visible = true; 
							txtEmpNo.Text = dsP1.Tables[0].Rows[0]["EMP_NO"].ToString();
							lstRegion.SelectedValue = dsP1.Tables[0].Rows[0]["REGION"].ToString();
							lstDL.SelectedValue = dsP1.Tables[0].Rows[0]["ALLOW_DN_CHKSHT"].ToString();
							if (lstRole.SelectedValue == "2")
							{
								if (dsP1.Tables[0].Rows[0]["ALLOW_PO"].ToString() == "N")
								{
									ddlAllowPO.SelectedValue = "N";
								}
								else
								{
									ddlAllowPO.SelectedValue = "Y";
								}
								lblPOEntry.Visible = true;
								ddlAllowPO.Visible = true;
							}
							else
							{
								lblPOEntry.Visible = false;
								ddlAllowPO.Visible = false;
							}
							ddlCallMarking_CM.SelectedValue = dsP1.Tables[0].Rows[0]["CALL_MARKING"].ToString();
							ddlCallRemarking_CM.SelectedValue = dsP1.Tables[0].Rows[0]["CALL_REMARKING"].ToString();
							//							
							//						} 
							//						else 
							//						{ 
							//							txtEmpNo.Visible = false; 
							//							lstRegion.Visible = false; 
							//							Label3.Visible = false; 
							//							Label7.Visible = false; 
							//							//Label9.Visible = false; 
							//							//lstStatus.Visible = false; 
							//						} 
							txtUID.Enabled = false;
							btnSave.Enabled = true;
						}
						conn1.Close();
					}
					catch (Exception ex)
					{
						if (err_cd == 1)
						{
							Response.Redirect("UnAuthorised_User_Message.aspx");
						}
						else
						{
							string str;
							str = ex.Message;
							string str1 = str.Replace("\n", "");
							Response.Redirect(("Error_Form.aspx?err=" + str1));
						}
					}
					finally
					{
						conn1.Close();
						conn1.Dispose();
					}
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

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				string Status;
				string allowpo = "", allowDL = null, allowCallMarking = null, allowCallRemarking = null, user_type = null;
				Status = lstStatus.SelectedItem.Value;
				if ((Status == "A"))
				{
					Status = "";
				}
				if (lstRole.SelectedValue == "2" && ddlAllowPO.SelectedValue == "N")
				{
					allowpo = "N";
				}

				if (lstDL.SelectedValue == "Y") { allowDL = "Y"; }
				if (ddlCallMarking_CM.SelectedValue == "Y") { allowCallMarking = "Y"; }
				if (ddlCallRemarking_CM.SelectedValue == "Y") { allowCallRemarking = "Y"; }
				if (ddlUser_Type.SelectedValue != "U")
				{

					user_type = ddlUser_Type.SelectedValue;
				}
				if (Ucode == "")
				{
					string myInsertQuery = "INSERT INTO T02_USERS values('" + txtUID.Text.Trim() + "', '" + txtUName.Text + "','Y', '" + txtEmpNo.Text + "','" + lstRegion.SelectedItem.Value.ToString() + "','" + txtUID.Text.Trim() + "', " + lstRole.SelectedItem.Value + ",'" + Status + "','" + allowpo + "',null,'" + allowDL + "','" + allowCallMarking + "','" + allowCallRemarking + "','" + user_type + "')";
					OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
					myInsertCommand.Connection = conn1;
					conn1.Open();
					myInsertCommand.ExecuteNonQuery();
					conn1.Close();
					btnSave.Enabled = false;
					DisplayAlert("Your Record is Saved");
					txtUID.Text = "";
					txtUName.Text = "";
					txtEmpNo.Text = "";
				}
				else
				{
					string myUpdateQuery = "Update T02_USERS set USER_NAME ='" + txtUName.Text + "', EMP_NO='" + txtEmpNo.Text + "', REGION ='" + lstRegion.SelectedItem.Value + "', PASSWORD ='" + txtUID.Text.Trim() + "', AUTH_LEVL= " + lstRole.SelectedItem.Value + ", STATUS='" + Status + "', ALLOW_PO='" + allowpo + "',ALLOW_DN_CHKSHT='" + allowDL + "',CALL_MARKING='" + allowCallMarking + "',CALL_REMARKING='" + allowCallRemarking + "', USER_TYPE='" + user_type + "' where USER_ID='" + Ucode + "'";
					OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
					myUpdateCommand.Connection = conn1;
					conn1.Open();
					myUpdateCommand.ExecuteNonQuery();
					conn1.Close();
					btnSave.Visible = true;
					DisplayAlert("Your Record is Updated");
				}
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				if (str1.Substring(0, 9).Equals("ORA-00001"))
				{ DisplayAlert("Duplicate User ID"); }
				else
				{ Response.Redirect(("Error_Form.aspx?err=" + str1)); }
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}
		}

		protected void lstRole_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lstRole.SelectedValue == "2")
			{
				lblPOEntry.Visible = true;
				ddlAllowPO.Visible = true;
			}
			else
			{
				lblPOEntry.Visible = false;
				ddlAllowPO.Visible = false;
			}
		}

	}
}