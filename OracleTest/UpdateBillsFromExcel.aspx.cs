using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.UpdateBillsFromExcel
{
	public partial class UpdateBillsFromExcel : System.Web.UI.Page
	{
		OracleConnection Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		public DataTable GetDataFromExcel()
		{
			DataTable dt = new DataTable();
			try
			{
				//OleDbConnection oledbconn=new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/Bills Scanned.xls").ToString() + ";Extended Properties=Excel 8.0;");		
				OleDbConnection oledbconn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/QR_UPDATE7.xls").ToString() + ";Extended Properties=Excel 8.0;");
				string SheetName = "Sheet1";//here enter sheet name        
				oledbconn.Open();
				OleDbCommand cmdSelect = new OleDbCommand(@"SELECT * FROM [" + SheetName + "$]", oledbconn);
				OleDbDataAdapter oledbda = new OleDbDataAdapter();
				oledbda.SelectCommand = cmdSelect;
				oledbda.Fill(dt);
				oledbconn.Close();
				oledbda = null;
			}
			catch (Exception ex)
			{
				Response.Write(ex.Message);
			}
			return dt;
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
		protected void Button1_Click(object sender, System.EventArgs e)
		{
			Conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			Conn.Open();
			OracleTransaction myTrans = Conn.BeginTransaction();
			try
			{
				DataTable dt = GetDataFromExcel();
				StringBuilder SqlQuery = new StringBuilder();
				SqlQuery.Append("");
				int sno = 0;
				foreach (DataRow dr in dt.Rows)
				{
					//					SqlQuery.Append();
					sno = sno + 1;
					OracleCommand myInsertCommandM = new OracleCommand();
					//myInsertCommandM.CommandText="update T22_BILL set SCANNED_STATUS='Y' where BILL_NO='" + dr["BILL_NO"].ToString() + "'";
					//myInsertCommandM.CommandText="update T22_BILL set BILL_DT='31-JAN-2021' where INVOICE_NO='" + dr["INVOICE_NO"].ToString() + "'";
					//myInsertCommandM.CommandText="update T22_BILL set DIG_BILL_GEN_DT=TO_DATE('03/09/2020','DD/MM/YYYY') where BILL_NO='" + dr["BILL_NO"].ToString() + "'";
					//myInsertCommandM.CommandText="update T03_CITY set PIN_CODE='"+dr["PIN_CODE"].ToString()+"' where CITY_CD='" + dr["CITY_CD"].ToString() + "'";
					//myInsertCommandM.CommandText="DELETE FROM RITES_BILL_DTLS where BILL_NO='" + dr["BILL_NO"].ToString() + "'";
					//myInsertCommandM.CommandText="update T55_LAB_INVOICE set SENT_TO_SAP='X' where INVOICE_NO='" + dr["INVOICE_NO"].ToString() + "'";
					//myInsertCommandM.CommandText="update T55_LAB_INVOICE set ACK_NO='" + dr["ACK_NO"].ToString() + "', ACK_DT=TO_DATE('" + dr["ACK_DT"].ToString()+ "','DD/MM/YYYY-HH24:MI:SS') , IRN_NO='" + dr["IRN_NO"].ToString() + "', QR_CODE='" + dr["QR_CODE"].ToString() + "' where INVOICE_NO='" + dr["INVOICE_NO"].ToString() + "'";
					myInsertCommandM.CommandText = "update T22_BILL set ACK_NO='" + dr["ACK_NO"].ToString() + "', ACK_DT=TO_DATE('" + dr["ACK_DT"].ToString() + "','DD/MM/YYYY-HH24:MI:SS') , IRN_NO='" + dr["IRN_NO"].ToString() + "', QR_CODE='" + dr["QR_CODE"].ToString() + "' where INVOICE_NO='" + dr["INVOICE_NO"].ToString() + "'";
					myInsertCommandM.Transaction = myTrans;
					myInsertCommandM.Connection = Conn;
					myInsertCommandM.ExecuteNonQuery();
				}


				myTrans.Commit();
				DisplayAlert("Update Sucessfull " + sno);
				//DisplayAlert(sno);

			}
			catch (Exception ex)
			{
				myTrans.Rollback();
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}
			finally
			{
				Conn.Close();
				Conn.Dispose();
			}

		}

		//		public int UpdatedCommand(string strupdatequery)
		//		{	
		//			int intreturn = 0;    
		//			Conn= new System.Data.OracleClient.OracleConnection((ConfigurationSettings.AppSettings["ConnectionString"])) ;
		//			Conn.Open(); 
		//			System.Data.OracleClient.OracleTransaction myTrans=null;
		//			try    
		//			{		
		//				
		//				OracleCommand myInsertCommandM = new OracleCommand(); 
		//				myInsertCommandM.CommandText=strupdatequery;
		//				myTrans =Conn.BeginTransaction();
		//				myInsertCommandM.Transaction=myTrans;
		//				myInsertCommandM.Connection = Conn; 
		//				intreturn=myInsertCommandM.ExecuteNonQuery(); 
		//				myTrans.Commit();
		////				SqlConnection sqlconn=new SqlConnection("Connection String for Sql Server");		
		////				SqlTransaction transsql;        
		////				SqlCommand cmdupdatecommand = new  SqlCommand();        
		////				transsql = null;        
		////				if (sqlconn.State != ConnectionState.Closed)        
		////				{            
		////					sqlconn.Close();        
		////				}        
		////				sqlconn.Open();        
		////				transsql =sqlconn.BeginTransaction();        
		////				cmdupdatecommand.CommandTimeout = 0;        
		////				cmdupdatecommand.CommandText = strupdatequery;        
		////				cmdupdatecommand.Connection =sqlconn;        
		////				cmdupdatecommand.Transaction = transsql;        
		////				intreturn = cmdupdatecommand.ExecuteNonQuery();        
		////				transsql.Commit();        
		////				if (sqlconn.State != ConnectionState.Closed)        
		////				{            
		////					sqlconn.Close();        
		////				}            
		//			}   
		//			catch (OracleException ex)
		//			{
		//				Response.Write(ex.Message);        
		//				myTrans.Rollback();   
		//				intreturn= -3;    
		//			}    
		//			catch (System.Exception exp)    
		//			{        
		//				myTrans.Rollback();   
		//				Response.Write(exp.Message);        
		//				intreturn= -3;    
		//			}   
		//            finally    
		//			{        
		//				       
		//					Conn.Close();        
		//				    
		//			}	
		//			return intreturn;
		//		}


	}
}