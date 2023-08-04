using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Hologram_Cancel_Form
{
	public partial class Hologram_Cancel_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		string HGNoFr, HGNoTo, Action;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnSearch.Attributes.Add("OnClick", "JavaScript:validate2();");
			btnDelConfirm.Attributes.Add("OnClick", "JavaScript:validate1();");
			btnDelConfirm.Attributes.Add("OnClick", "JavaScript:del();");

			if (Request.Params["HG_NO_FR"] == null && Request.Params["HG_NO_TO"] == null)
			{
				HGNoFr = "";
				HGNoTo = "";
				Action = "A";
			}
			else
			{
				HGNoFr = Request.Params["HG_NO_FR"].ToString();
				HGNoTo = Request.Params["HG_NO_TO"].ToString();
				Action = "M";
			}


			if (!(IsPostBack))
			{
				fill_IEtoWhomeIssued();
				ListItem lst2 = new ListItem();
				lst2.Text = "Cancelled";
				lst2.Value = "C";
				lstICStatus.Items.Add(lst2);
				lst2 = new ListItem();
				lst2.Text = "Distroyed";
				lst2.Value = "D";
				lstICStatus.Items.Add(lst2);
				lst2 = new ListItem();
				lst2.Text = "Missing";
				lst2.Value = "M";
				lstICStatus.Items.Add(lst2);
				lst2 = new ListItem();
				lst2.Text = "Lost / Theft";
				lst2.Value = "L";
				lstICStatus.Items.Add(lst2);



				if (Action == "A")
				{
					//					fillgrid();
					btnDelConfirm.Visible = false;
					if (Session["Region"].ToString() == "N")
					{
						lblReg.Text = "Northern Region";
					}
					else if (Session["Region"].ToString() == "S")
					{
						lblReg.Text = "Southern Region";
					}
					else if (Session["Region"].ToString() == "E")
					{
						lblReg.Text = "Eastern Region";
					}
					else if (Session["Region"].ToString() == "W")
					{
						lblReg.Text = "Western Region";
					}
					else if (Session["Region"].ToString() == "C")
					{
						lblReg.Text = "Central Region";
					}
				}
				else if (Action == "M")
				{
					//					fillgrid();
					show();
					btnDelConfirm.Visible = true;
				}
			}
			if (Session["Role_CD"].ToString() == "4")
			{
				btnSave.Visible = false;
				btnDelConfirm.Visible = false;

			}

		}
		void searchHG()
		{
			try
			{
				DataSet dsP = new DataSet();
				string str = "select HG.HG_NO_FR,HG.HG_NO_TO,IE.IE_NAME,decode(HG.HG_STATUS,'C','Cancelled','M','Missing','L','Lost')HG_STATUS,to_char(HG.HG_STATUS_DT,'dd/mm/yyyy')HG_STATUS_DT, decode(HG.HG_REGION,'N','Northern','W','Western','E','Eastern','S','South','C','Central') HG_REGION from T32_HOLOGRAM_CANCEL HG, T09_IE IE where HG.HG_IECD=IE.IE_CD";

				if (txtHGFrom.Text.Trim() != "")
				{
					str = str + " and Trim(HG_NO_FR)=upper(trim('" + txtHGFrom.Text.Trim() + "'))";
				}
				if (txtHGTo.Text.Trim() != "")
				{
					str = str + " and Trim(HG_NO_TO)=upper(trim('" + txtHGTo.Text.Trim() + "'))";
				}
				if (lstIE.SelectedIndex != 0)
				{
					str = str + " and Trim(HG_IECD)=" + lstIE.SelectedValue;
				}
				str = str + " and HG_REGION='" + Session["Region"] + "' order by IE_CD,HG.HG_NO_FR,HG.HG_NO_TO";
				OracleDataAdapter da = new OracleDataAdapter(str, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdICCancel.Visible = false;
					DisplayAlert("No Data Found!!!");
				}
				else
				{
					grdICCancel.Visible = true;
					grdICCancel.DataSource = dsP;
					grdICCancel.DataBind();
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
			}
		}
		void show()
		{
			try
			{
				DataSet dsP = new DataSet();
				//code = Convert.ToInt32(txtBankCD.Text);
				string str1 = ("select HG_NO_FR,HG_NO_TO,HG_IECD,HG_STATUS,to_char(HG_STATUS_DT,'dd/mm/yyyy')STATUS_DT, decode(HG_REGION,'N','Northern','W','Western','E','Eastern','S','South','C','Central') REGION from T32_HOLOGRAM_CANCEL where (TRIM(HG_NO_FR))=upper(TRIM('" + HGNoFr + "')) and (TRIM(HG_NO_TO))=upper(TRIM('" + HGNoTo + "')) and HG_REGION='" + Session["Region"] + "'");
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand1 = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand1;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					throw new System.Exception("No Record Found!!! For The Given Code");
				}
				else
				{
					txtHGFrom.Text = dsP.Tables[0].Rows[0]["HG_NO_FR"].ToString();
					txtHGTo.Text = dsP.Tables[0].Rows[0]["HG_NO_TO"].ToString();
					lstIE.SelectedValue = dsP.Tables[0].Rows[0]["HG_IECD"].ToString();
					lstICStatus.SelectedValue = dsP.Tables[0].Rows[0]["HG_STATUS"].ToString();
					txtStatusDt.Text = dsP.Tables[0].Rows[0]["STATUS_DT"].ToString();
					lblReg.Text = dsP.Tables[0].Rows[0]["REGION"].ToString();

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

		}

		void fillgrid()
		{
			try
			{
				DataSet dsP = new DataSet();
				string str1 = "select HG.HG_NO_FR,HG.HG_NO_FR,IE.IE_NAME,decode(HG.HG_STATUS,'C','Cancelled','M','Missing','L','Lost')HG_STATUS,to_char(HG.HG_STATUS_DT,'dd/mm/yyyy')HG_STATUS_DT, decode(HG.HG_REGION,'N','Northern','W','Western','E','Eastern','S','South','C','Central') HG_REGION from T32_HG_CANCEL HG, T09_IE IE where HG.HG_IECD=IE.IE_CD and HG_REGION='" + Session["Region"] + "' order by IE_CD,HG_NO_FR,HG_NO_TO";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdICCancel.Visible = false;
				}
				else
				{
					grdICCancel.Visible = true;
					grdICCancel.DataSource = dsP;
					grdICCancel.DataBind();
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
			}
		}

		int checkHG()
		{
			conn1.Open();
			OracleCommand cmd1 = new OracleCommand("Select to_char(HG_ISSUE_DT,'yyyymmdd') from T31_HOLOGRAM_ISSUED where (" + Convert.ToInt32(txtHGFrom.Text) + " between (HG_NO_FR) and (HG_NO_TO)) and (" + Convert.ToInt32(txtHGTo.Text) + " between (HG_NO_FR) and (HG_NO_TO)) and HG_IECD=" + lstIE.SelectedValue, conn1);
			string bscheck = Convert.ToString(cmd1.ExecuteScalar());
			conn1.Close();
			string myYear = txtStatusDt.Text.Substring(6, 4);
			string myMonth = txtStatusDt.Text.Substring(3, 2);
			string myDay = txtStatusDt.Text.Substring(0, 2);
			string dt1 = myYear + myMonth + myDay;

			int i = bscheck.CompareTo(dt1);


			if (bscheck != "" && i > 0)
			{
				//				conn1.Open();
				//				if(i>0)
				//				{
				return (3);
				//				}
				//				else
				//				{

				//					OracleCommand cmd =new OracleCommand("Select CASE_NO from T20_IC where TRIM(HG_NO_FR)=upper('"+txtHGFrom.Text.Trim()+"') and TRIM(HG_NO_TO)=upper('"+txtHGTo.Text.Trim()+"') and substr(CASE_NO,1,1)='"+Session["Region"]+"'",conn1);
				//					string bscheck1 =Convert.ToString(cmd.ExecuteScalar());
				//					conn1.Close();
				//					if (bscheck1=="" || bscheck1==null)
				//					{
				//						return(1);
				//					}
				//					else
				//					{
				//						return(2);
				//					}
			}
			//			}
			else if (bscheck == "")
			{
				return (0);
			}
			else
			{
				return (1);
			}
		}
		public void fill_IEtoWhomeIssued()
		{
			try
			{
				lstIE.Items.Clear();
				OracleCommand cmd = new OracleCommand("select IE_CD,IE_NAME from T09_IE where IE_STATUS is null and IE_REGION ='" + Session["Region"].ToString() + "' ORDER BY IE_NAME", conn1);
				OracleDataReader dr;
				conn1.Open();
				dr = cmd.ExecuteReader();
				ListItem lst;
				while (dr.Read())
				{
					lst = new ListItem();
					lst.Text = Convert.ToString(dr["IE_NAME"]);
					lst.Value = Convert.ToString(dr["IE_CD"]);
					lstIE.Items.Add(lst);
				}
				lstIE.Items.Insert(0, "");
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
			conn1.Open();
			OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
			string ss = Convert.ToString(cmd2.ExecuteScalar());
			conn1.Close();
			if (Action == "A")
			{
				int bscheck = checkHG();
				if (bscheck == 1)
				{
					try
					{
						string myInsertQuery = "INSERT INTO T32_HOLOGRAM_CANCEL(HG_REGION,HG_NO_FR,HG_NO_TO,HG_STATUS,HG_STATUS_DT,HG_IECD,USER_ID,DATETIME ) values('" + Session["Region"].ToString() + "','" + txtHGFrom.Text + "','" + txtHGTo.Text + "','" + lstICStatus.SelectedValue + "', to_date('" + txtStatusDt.Text + "','dd/mm/yyyy')," + lstIE.SelectedValue + ",'" + Session["Uname"].ToString() + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
						OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
						myInsertCommand.Connection = conn1;
						conn1.Open();
						myInsertCommand.ExecuteNonQuery();
						conn1.Close();
						DisplayAlert("Record Saved!!!");
						//						fillgrid();
					}
					catch (Exception ex)
					{
						string str;
						str = ex.Message;
						string str2 = str.Replace("\n", "");
						Response.Redirect("Error_Form.aspx?err=" + str2);
					}
					finally
					{
						conn1.Close();
					}

					//					Response.Redirect("IC_Cancel_Form.aspx");
					//					fillgrid();
				}
				else if (bscheck == 0)
				{
					DisplayAlert("Hologram No. From and Hologram No. To specified is not issued to the Selected Inspection Engineer!!!");
				}
				//				else if(bscheck==2)
				//				{
				//					DisplayAlert("IC has already made for given Book and Set No., soo it can not be cancelled !!!");
				//				}
				else if (bscheck == 3)
				{
					DisplayAlert("Hologram Cancel Date Cannot be Less then Hologram Issue Date  !!!");
				}
			}
			else if (Action == "M")
			{
				int bscheck = checkHG();
				if (bscheck == 1)
				{

					try
					{
						string myUpdateQuery = "UPDATE T32_HOLOGRAM_CANCEL  set HG_NO_FR=trim('" + txtHGFrom.Text + "'),HG_NO_TO=trim('" + txtHGTo.Text + "'),HG_IECD=" + lstIE.SelectedValue + ",HG_STATUS='" + lstICStatus.SelectedValue + "',HG_STATUS_DT=to_date('" + txtStatusDt.Text + "','dd/mm/yyyy'),USER_ID='" + Session["Uname"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where TRIM(HG_NO_FR)=TRIM('" + HGNoFr + "') and TRIM(HG_NO_TO)=TRIM('" + HGNoTo + "') and HG_REGION='" + Session["Region"] + "'";
						OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
						myUpdateCommand.Connection = conn1;
						conn1.Open();
						myUpdateCommand.ExecuteNonQuery();
						conn1.Close();

						//					fillgrid();
						//					DisplayAlert("Your Record is Modified!!!");
					}
					catch (Exception ex)
					{
						string str;
						str = ex.Message;
						string str2 = str.Replace("\n", "");
						Response.Redirect("Error_Form.aspx?err=" + str2);
					}
					finally
					{
						conn1.Close();
					}
					Response.Redirect("Hologram_Cancel_Form.aspx");
				}
				else if (bscheck == 0)
				{
					DisplayAlert("Hologram No. From and Hologram No. To specified is not issued to the Selected Inspection Engineer!!!");
				}
				//				else if(bscheck==2)
				//				{
				//					DisplayAlert("IC has already made for given Book and Set No., soo it can not be cancelled !!!");
				//				}
				else if (bscheck == 3)
				{
					DisplayAlert("Hologram Cancel Date Cannot be Less then Hologram Issue Date  !!!");
				}
			}

		}

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			searchHG();
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{

			Response.Redirect("MainForm.aspx");

		}

		protected void btnDelConfirm_Click(object sender, System.EventArgs e)
		{
			try
			{
				string myUpdateQuery = "delete T32_HOLOGRAM_CANCEL where TRIM(HG_NO_FR)=TRIM('" + HGNoFr + "') and TRIM(HG_NO_TO)=TRIM('" + HGNoTo + "') and HG_REGION='" + Session["Region"] + "'";
				OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
				myUpdateCommand.Connection = conn1;
				conn1.Open();
				myUpdateCommand.ExecuteNonQuery();
				conn1.Close();
				//				fillgrid();
				DisplayAlert("Record Deleted!!!");
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
		}

	}
}