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

namespace RBS.Tech_Ref_Form
{
	public partial class Tech_Ref_Form : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		string wRegion;
		string Action;

		protected void Page_Load(object sender, System.EventArgs e)
		{

			if (Session["Region"].ToString() == "N") { wRegion = "N"; }
			else if (Session["Region"].ToString() == "S") { wRegion = "S"; }
			else if (Session["Region"].ToString() == "E") { wRegion = "E"; }
			else if (Session["Region"].ToString() == "W") { wRegion = "W"; }
			else if (Session["Region"].ToString() == "C") { wRegion = "C"; }

			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			if (Convert.ToString(Request.Params["TECH_ID"]) == null || Convert.ToString(Request.Params["TECH_ID"]) == "")
			{

				Action = "";
				lblTCode.Visible = false;

			}
			else
			{
				Action = Convert.ToString(Request.Params["ACTION"].Trim());
				lblTCode.Text = Convert.ToString(Request.Params["TECH_ID"].Trim());
				lblTCode.Visible = true;

			}

			if (!(IsPostBack))
			{
				string str2 = "select CO_CD, CO_NAME from T08_IE_CONTROLL_OFFICER where CO_STATUS is null and CO_REGION='" + Session["REGION"] + "' order by CO_NAME ";
				OracleDataAdapter da1 = new OracleDataAdapter(str2, conn1);
				OracleCommand myOracleCommand1 = new OracleCommand(str2, conn1);
				ListItem lst1;
				conn1.Open();
				da1.SelectCommand = myOracleCommand1;
				DataSet dsP1 = new DataSet();
				da1.Fill(dsP1, "Table");
				lst1 = new ListItem();
				for (int j = 0; j <= dsP1.Tables[0].Rows.Count - 1; j++)
				{
					lst1 = new ListItem();
					lst1.Text = dsP1.Tables[0].Rows[j]["CO_NAME"].ToString();
					lst1.Value = dsP1.Tables[0].Rows[j]["CO_CD"].ToString();
					lstCOType.Items.Add(lst1);
				}
				lstCOType.Items.Insert(0, "");
				conn1.Close();

				DataSet dsP2 = new DataSet();
				string str3 = "select IE_CD, IE_NAME from T09_IE where IE_STATUS is null and IE_REGION='" + Session["REGION"] + "' order by IE_NAME ";
				OracleDataAdapter da2 = new OracleDataAdapter(str3, conn1);
				OracleCommand myOracleCommand2 = new OracleCommand(str3, conn1);
				ListItem lst2;
				conn1.Open();
				da2.SelectCommand = myOracleCommand2;
				da2.Fill(dsP2, "Table");
				for (int i = 0; i <= dsP2.Tables[0].Rows.Count - 1; i++)
				{
					lst2 = new ListItem();
					lst2.Text = dsP2.Tables[0].Rows[i]["IE_NAME"].ToString();
					lst2.Value = dsP2.Tables[0].Rows[i]["IE_CD"].ToString();
					lstIEType.Items.Add(lst2);
				}
				lstIEType.Items.Insert(0, "");
				conn1.Close();
				if (Action == "E")
				{
					show();
					btnSave.Enabled = false;
					btnSave.Visible = false;
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

		void show()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

			string MySql = "Select  row_number() over (order by to_char(tr.tech_date, 'dd.mm.yyyy')) as sn,co.co_name cm_name,ie.ie_name ie_name,tr.tech_item_des item_des,tr.tech_spec_drg spec_drg,tr.tech_letter_no letter_no,to_char(tr.tech_date, 'dd/mm/yyyy') tech_date,tr.tech_ref_made ref_made,tr.tech_content tech_content,tr.tech_id TECH_ID,tr.tech_cm_cd tech_cm_id,tr.tech_ie_cd tech_ie_id  " +
				"from t66_tech_ref tr, t08_ie_controll_officer co, t09_ie ie where tr.tech_cm_cd= co.co_cd and tr.tech_ie_cd= ie.ie_cd " +
				"and tr.tech_id is not null and tr.region_cd='" + Session["Region"].ToString() + "' and tr.tech_id='" + lblTCode.Text + "' ";
			try
			{
				conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
				OracleCommand cmd = new OracleCommand(MySql, conn1);
				conn1.Open();
				OracleDataReader MyReader = cmd.ExecuteReader();
				while (MyReader.Read())
				{
					toDt.Text = MyReader["tech_date"].ToString();
					toDt.Enabled = false;
					Textletter.Text = MyReader["letter_no"].ToString();
					Textletter.Enabled = false;
					lstCOType.SelectedValue = MyReader["tech_cm_id"].ToString();
					lstCOType.Enabled = false;
					lstIEType.SelectedValue = MyReader["tech_ie_id"].ToString();
					lstIEType.Enabled = false;
					txtItem.Text = MyReader["item_des"].ToString();
					txtItem.Enabled = false;
					txtSpec.Text = MyReader["spec_drg"].ToString();
					txtSpec.Enabled = false;
					TextRef.Text = MyReader["ref_made"].ToString();
					TextRef.Enabled = false;
					TextTR.Text = MyReader["tech_content"].ToString();
					TextTR.Enabled = false;

				}
				string fpath1 = Server.MapPath("/RBS/TECH/" + lblTCode.Text.Trim() + ".PDF");
				if (File.Exists(fpath1) == false)
				{
					//Label12.Visible=true;
					File1.Visible = true;
					HyperLink1.Visible = false;

				}
				else
				{
					HyperLink1.NavigateUrl = "/RBS/TECH/" + lblTCode.Text.Trim() + ".PDF";
					HyperLink1.Visible = true;
					HyperLink1.Text = lblTCode.Text.Trim();
					File1.Visible = false;
				}
				string show_MyFile = lblTCode.Text + '_' + "R";
				string fpath2 = Server.MapPath("/RBS/TECH/" + show_MyFile + ".PDF");
				if (File.Exists(fpath2) == false)
				{
					//Label12.Visible=true;
					File2.Visible = true;
					Hyperlink2.Visible = false;
				}
				else
				{
					Hyperlink2.NavigateUrl = "/RBS/TECH/" + show_MyFile + ".PDF";
					Hyperlink2.Visible = true;
					Hyperlink2.Text = show_MyFile;
					File2.Visible = false;
				}

				if (File.Exists(fpath1) == false || File.Exists(fpath2) == false)
				{
					btnEdit.Enabled = true;
					btnEdit.Visible = true;
				}
				else
				{
					btnEdit.Enabled = false;
					btnEdit.Visible = false;
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


		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{

				conn1.Open();
				OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				string ss = Convert.ToString(cmd2.ExecuteScalar());
				conn1.Close();

				string Techcheckquery = "Select count(*) from T66_Tech_Ref where to_char(TECH_DATE, 'dd/mm/yyyy')= '" + toDt.Text + "' and REGION_CD='" + Session["Region"].ToString() + "' and TECH_CM_CD='" + lstCOType.SelectedValue + "' and TECH_IE_CD='" + lstIEType.SelectedValue + "' and TECH_LETTER_NO='" + Textletter.Text + "'";
				OracleCommand TechcheckCommand = new OracleCommand(Techcheckquery, conn1);
				conn1.Open();
				System.Data.DataSet ds = new DataSet();
				OracleDataAdapter adapter = new OracleDataAdapter(TechcheckCommand);
				adapter.Fill(ds);
				conn1.Close();
				if (Convert.ToInt64(ds.Tables[0].Rows[0][0]) > 0)
				{
					DisplayAlert("Selected Letter No.,CM,IE,DATE for this region already Exist!!!");
					return;
				}
				else
				{
					string Tech_No = generate_Tech_Ref_ID();
					string Techquery = "insert into T66_Tech_Ref(REGION_CD,TECH_CM_CD,TECH_IE_CD,TECH_ITEM_DES,TECH_SPEC_DRG,TECH_LETTER_NO,TECH_DATE,TECH_REF_MADE,TECH_CONTENT,USER_ID,DATETIME,TECH_ID) " +
						"VALUES('" + Session["Region"].ToString() + "','" + lstCOType.SelectedValue + "','" + lstIEType.SelectedValue + "','" + txtItem.Text + "','" + txtSpec.Text + "','" + Textletter.Text + "',to_date('" + toDt.Text + "','dd/mm/yyyy'),'" + TextRef.Text + "','" + TextTR.Text + "','" + Session["Uname"].ToString() + "',to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),'" + Tech_No + "')";
					OracleCommand ClientCommand = new OracleCommand();
					ClientCommand.CommandText = Techquery;
					ClientCommand.Connection = conn1;
					conn1.Open();
					ClientCommand.ExecuteNonQuery();
					conn1.Close();
					lblTCode.Text = Tech_No.ToString();
					lblTCode.Visible = false;
					upload_tech();
					upload_tech_R();
					DisplayAlert("Your Record is Saved!!!");
				}
				Reset();
				Show_Tech();
				Show_Tech_R();

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

		void upload_tech()
		{
			if (File1.PostedFile != null && File1.PostedFile.ContentLength > 0)
			{
				string fn = "", MyFile = "", fx = "";
				MyFile = lblTCode.Text;
				fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
				fx = System.IO.Path.GetExtension(File1.PostedFile.FileName).ToUpper().Substring(1);
				String SaveLocation = null;
				if (fx == "PDF")
				{
					SaveLocation = Server.MapPath("TECH/" + MyFile + ".PDF");
				}
				else
				{
					DisplayAlert("Kindly Upload PDF File only");
				}

				File1.PostedFile.SaveAs(SaveLocation);
				DisplayAlert("Technical Reference Uploaded!!!");

			}

		}

		void Show_Tech()
		{
			string MyFile_ex = lblTCode.Text;
			string fpath = Server.MapPath("/RBS/TECH/" + MyFile_ex + ".PDF");
			if (File.Exists(fpath) == false)
			{
				File1.Visible = true;
				HyperLink1.Visible = false;
			}
			else
			{
				HyperLink1.Visible = true;
				HyperLink1.Text = MyFile_ex;
				HyperLink1.NavigateUrl = "/RBS/TECH/" + MyFile_ex + ".PDF";
				File1.Visible = false;
			}

		}

		void upload_tech_R()
		{
			if (File2.PostedFile != null && File2.PostedFile.ContentLength > 0)
			{
				string fn = "", MyFile = "", fx = "";
				MyFile = lblTCode.Text + '_' + "R";
				fn = System.IO.Path.GetFileName(File2.PostedFile.FileName);
				fx = System.IO.Path.GetExtension(File2.PostedFile.FileName).ToUpper().Substring(1);
				String SaveLocation = null;
				if (fx == "PDF")
				{
					SaveLocation = Server.MapPath("TECH/" + MyFile + ".PDF");
				}
				else
				{
					DisplayAlert("Kindly Upload PDF File only");
				}

				File2.PostedFile.SaveAs(SaveLocation);
				DisplayAlert("Technical Reference Reply Uploaded!!!");

			}

		}

		void Show_Tech_R()
		{
			string MyFile_ex_r = lblTCode.Text + '_' + "R";
			string fpath = Server.MapPath("/RBS/TECH/" + MyFile_ex_r + ".PDF");
			if (File.Exists(fpath) == false)
			{
				File2.Visible = true;
				Hyperlink2.Visible = false;
			}
			else
			{
				Hyperlink2.Visible = true;
				Hyperlink2.Text = MyFile_ex_r;
				Hyperlink2.NavigateUrl = "/RBS/TECH/" + MyFile_ex_r + ".PDF";
				File2.Visible = false;
			}

		}

		private string generate_Tech_Ref_ID()
		{
			string Tech_ID = "";
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				OracleCommand cmd = new OracleCommand();
				cmd = new OracleCommand("GENERATE_TR_ID", conn1);
				cmd.CommandType = CommandType.StoredProcedure;
				conn1.Open();

				OracleParameter prm1 = new OracleParameter("IN_TECH_DT", OracleDbType.Char);
				prm1.Direction = ParameterDirection.Input;
				prm1.Value = Convert.ToString(toDt.Text.Replace("/", ""));
				cmd.Parameters.Add(prm1);

				OracleParameter prm2 = new OracleParameter("IN_REGION_CD", OracleDbType.Char);
				prm2.Direction = ParameterDirection.Input;
				prm2.Value = wRegion;
				cmd.Parameters.Add(prm2);

				OracleParameter prm3 = new OracleParameter("OUT_TECH_ID", OracleDbType.Char, 7);
				prm3.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(prm3);

				OracleParameter prm4 = new OracleParameter("OUT_ERR_CD", OracleDbType.Int32);
				prm4.Direction = ParameterDirection.Output;
				cmd.Parameters.Add(prm4);

				cmd.ExecuteNonQuery();

				if (Convert.ToInt16(cmd.Parameters["OUT_ERR_CD"].Value) == -1)
				{
					Tech_ID = "-1";
				}
				else
				{
					Tech_ID = Convert.ToString(cmd.Parameters["OUT_TECH_ID"].Value);
				}
				conn1.Close();
				return (Tech_ID);
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
				//conn1.Dispose();
			}
		}


		protected void btnEdit_Click(object sender, System.EventArgs e)
		{
			upload_tech();
			upload_tech_R();
			Show_Tech();
			Show_Tech_R();
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("MainForm.aspx");
		}
		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}
		void Reset()
		{
			try
			{
				toDt.Text = "";
				Textletter.Text = "";
				lstCOType.SelectedIndex = 0;
				lstIEType.SelectedIndex = 0;
				txtItem.Text = "";
				txtSpec.Text = "";
				TextRef.Text = "";
				TextTR.Text = "";
			}
			catch (Exception ex)
			{
				string str1;
				str1 = ex.Message;
				string str2 = str1.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str2));
			}

		}

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			search();
		}

		void search()
		{
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			DataSet dsP1 = new DataSet();
			string str1 = "Select  row_number() over (order by to_char(tr.tech_date, 'dd.mm.yyyy')) as sn,co.co_name cm_name,ie.ie_name ie_name,tr.tech_item_des item_des,tr.tech_spec_drg spec_drg,tr.tech_letter_no letter_no,to_char(tr.tech_date, 'dd/mm/yyyy') tech_date,tr.tech_ref_made ref_made,tr.tech_content tech_content,tr.tech_id TECH_ID  " +
				"from t66_tech_ref tr, t08_ie_controll_officer co, t09_ie ie where tr.tech_cm_cd= co.co_cd and tr.tech_ie_cd= ie.ie_cd " +
				"and tr.tech_id is not null and tr.region_cd='" + Session["Region"].ToString() + "' ";
			if (Textletter.Text.Trim() != "")
			{
				str1 = str1 + " and upper(tr.tech_letter_no) Like upper('" + Textletter.Text.Trim() + "%')";
				//grdCity.CurrentPageIndex=0;
			}
			if (toDt.Text.Trim() != "")
			{
				str1 = str1 + " and to_char(tr.tech_date, 'dd/mm/yyyy')='" + toDt.Text.Trim() + "'";
				//grdCity.CurrentPageIndex=0;
			}


			str1 = str1 + " order by sn";

			OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			conn1.Open();
			da.SelectCommand = myOracleCommand;
			dsP1.Clear();
			da.Fill(dsP1, "Table");
			if (dsP1.Tables[0].Rows.Count == 0)
			{
				grdTech.Visible = false;
				DisplayAlert("Technical Reference Not Found Or Old Rechnical Reference!!!");

			}
			else
			{

				try
				{
					//int aa=grdCity.CurrentPageIndex;
					grdTech.DataSource = dsP1;
					if (grdTech.CurrentPageIndex > (dsP1.Tables[0].Rows.Count / 15))
					{
						grdTech.CurrentPageIndex = 0;
					}
					grdTech.DataBind();
					grdTech.Visible = true;
				}
				catch (Exception ex)
				{
					string str;
					str = ex.Message;
					string str2 = str.Replace("\n", "");
					//DisplayAlert("Sorry, their is some error in search. so, plz try again!!!");
					Response.Redirect("Tech_Ref_Form.aspx");
				}
				finally
				{
					conn1.Close();
				}

			}
			conn1.Close();

		}
	}
}