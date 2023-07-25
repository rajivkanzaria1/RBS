using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Vendor
{
    public partial class Vendor_Call_Register_Form : System.Web.UI.Page
    {
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		DataSet dsP = new DataSet();
		protected System.Web.UI.WebControls.Label Label1;
		public string CNO, DT, Action, CSNO, cstatus, wFOS;
		int CD = 0;
		string ss, status;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected Tittle.Controls.CustomDataGrid grdCDetails_1;
		protected Tittle.Controls.CustomDataGrid grdCDetails;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtCaseNo;
		protected System.Web.UI.WebControls.Label Label27;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label28;
		protected System.Web.UI.WebControls.TextBox txtDtOfReciept;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label29;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.Label Label25;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label txtCallStatus;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label31;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtDtMark;
		protected System.Web.UI.WebControls.Label Label23;
		protected System.Web.UI.WebControls.TextBox txtDtOfCan;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.TextBox txtCInstallNo;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.TextBox txtExpOfIns;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.TextBox txtCallNO;
		protected System.Web.UI.WebControls.Label Label37;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtCallDt;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.DropDownList lstIE;
		protected System.Web.UI.WebControls.Label lblIE;
		protected System.Web.UI.WebControls.Label Label30;
		protected System.Web.UI.WebControls.DropDownList lstCallRStatus;
		protected System.Web.UI.WebControls.Label Label32;
		protected System.Web.UI.WebControls.TextBox txtRemarks;
		protected System.Web.UI.WebControls.Label Label26;
		protected System.Web.UI.WebControls.CheckBox chkManuf;
		protected System.Web.UI.WebControls.Label lblCUpdateStatus;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.TextBox txtMName;
		protected System.Web.UI.WebControls.Button btnFCList;
		protected System.Web.UI.WebControls.DropDownList ddlManufac;
		protected System.Web.UI.WebControls.Label Label24;
		protected System.Web.UI.WebControls.TextBox txtMPOI;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox txtMConPer;
		protected System.Web.UI.WebControls.Label Label33;
		protected System.Web.UI.WebControls.TextBox txtMEmail;
		protected System.Web.UI.WebControls.Label label20;
		protected System.Web.UI.WebControls.TextBox txtMPNo;
		protected System.Web.UI.WebControls.Button btnUManuf;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD1;
		protected System.Web.UI.WebControls.Label Label36;
		protected System.Web.UI.WebControls.Label Label38;
		protected System.Web.UI.WebControls.Label Label39;
		protected System.Web.UI.WebControls.Label Label40;
		protected System.Web.UI.WebControls.TextBox txtVendAppTo;
		protected System.Web.UI.WebControls.Label Label41;
		protected System.Web.UI.WebControls.Label Label42;
		protected System.Web.UI.WebControls.TextBox txtVendAppFrom;
		protected System.Web.UI.WebControls.RadioButton rdbIYes;
		protected System.Web.UI.WebControls.RadioButton rdbINo;
		protected System.Web.UI.WebControls.RadioButton rdbVNo;
		protected System.Web.UI.WebControls.RadioButton rdbVYes;
		protected System.Web.UI.WebControls.Label Label43;
		protected System.Web.UI.WebControls.RadioButton rdbSNo;
		protected System.Web.UI.WebControls.RadioButton rdbSYes;
		protected System.Web.UI.WebControls.Label Label44;
		protected System.Web.UI.WebControls.Label Label45;
		protected System.Web.UI.WebControls.TextBox txtLotDP1;
		protected System.Web.UI.WebControls.Label Label46;
		protected System.Web.UI.WebControls.TextBox txtLotDP2;
		protected System.Web.UI.WebControls.CheckBox CheckBox1;
		protected System.Web.UI.WebControls.Label Label47;
		protected System.Web.UI.WebControls.Button btnUpload;
		protected System.Web.UI.WebControls.Label Label48;
		protected System.Web.UI.HtmlControls.HtmlInputFile File1;
		protected System.Web.UI.WebControls.Label Label49;
		protected System.Web.UI.WebControls.Label lblRly;
		protected System.Web.UI.WebControls.Label lblL5noPo;
		protected System.Web.UI.WebControls.Label Label50;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist1;
		protected System.Web.UI.WebControls.Label Label51;
		protected System.Web.UI.WebControls.RadioButton rdbFinal;
		protected System.Web.UI.WebControls.RadioButton rdbStage;
		protected System.Web.UI.WebControls.Label Label52;
		protected System.Web.UI.WebControls.Label lblRLY_NONRly;
		protected System.Web.UI.WebControls.Label Label35;
		protected System.Web.UI.WebControls.TextBox txtBPO;
		protected System.Web.UI.WebControls.Label Label53;
		protected System.Web.UI.WebControls.TextBox txtGSTINNo;
		protected System.Web.UI.WebControls.CheckBox chkNewVendor;
		protected System.Web.UI.WebControls.DropDownList ddlIRFC;
		protected System.Web.UI.WebControls.Label lblIRFC;
		protected System.Web.UI.WebControls.Label lblCluster_Cd;
		protected System.Web.UI.WebControls.Label lblClusterIE_CD;
		int ecode = 0;
		//Added Kamta 14-09-2020//

		//END//
		void show1()
		{
			DataSet dsP4 = new DataSet();
			string str5 = "select (C.CONSIGNEE_CD||'-'||trim(C.CONSIGNEE_DESIG)||'/'||trim(C.CONSIGNEE_DEPT)||'/'||trim(C.CONSIGNEE_FIRM)) PURCHASER_CD, V.VEND_NAME VEND_CD, P.PO_NO, to_char(P.PO_DT,'dd/mm/yyyy') PO_DT,substr(P.RLY_CD,1,7)RLY, P.L5NO_PO, P.RLY_NONRLY from T13_PO_MASTER P,T06_CONSIGNEE C,T05_VENDOR V where P.PURCHASER_CD=C.CONSIGNEE_CD(+) and P.VEND_CD=V.VEND_CD and CASE_NO= '" + CNO + "' ";
			OracleDataAdapter da4 = new OracleDataAdapter(str5, conn1);
			OracleCommand myOracleCommand4 = new OracleCommand(str5, conn1);
			conn1.Open();
			da4.SelectCommand = myOracleCommand4;
			da4.Fill(dsP4, "Table");
			if (dsP4.Tables[0].Rows.Count == 0)
			{
				Label19.Visible = false;
				Label21.Visible = false;
				Label25.Visible = false;
				Label22.Visible = false;
			}
			else
			{
				Label19.Visible = true;
				Label21.Visible = true;
				Label25.Visible = true;
				Label22.Visible = true;
				Label19.Text = dsP4.Tables[0].Rows[0]["PURCHASER_CD"].ToString();
				Label21.Text = dsP4.Tables[0].Rows[0]["VEND_CD"].ToString();
				Label25.Text = dsP4.Tables[0].Rows[0]["PO_NO"].ToString();
				Label22.Text = dsP4.Tables[0].Rows[0]["PO_DT"].ToString();
				lblL5noPo.Text = dsP4.Tables[0].Rows[0]["L5NO_PO"].ToString();
				lblRly.Text = dsP4.Tables[0].Rows[0]["RLY"].ToString();
				lblRLY_NONRly.Text = dsP4.Tables[0].Rows[0]["RLY_NONRLY"].ToString();
			}
			//			txtPurchaser.Enabled=false;
			//			txtVendor.Enabled=false;
			//			txtPONO.Enabled =false;
			//			txtPODT.Enabled =false;
			conn1.Close();
			//conn1.Dispose();



		}
		//Added Kamta 14-09-2020//
		//		string PO_CODE_ICF(string PONO)
		//		{
		//			string PO_Code; 
		//			PO_Code=PONO.Substring(0,2);
		//			return (PO_Code);
		//		}
		//End//

		void fill_poi(int pCode)
		{

			try
			{


				string str2 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(VEND_CD)=" + pCode + " and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
				fill_manufacturer(str2);
				ddlManufac.Visible = true;
				txtMName.Text = pCode.ToString();
				//						OracleCommand cmd=new OracleCommand("select VEND_ADD1,VEND_CONTACT_PER_1,VEND_CONTACT_TEL_1,VEND_EMAIL from T05_VENDOR where VEND_CD='" +ddlManufac.SelectedValue + "'",conn1);
				//						conn1.Open();
				//						OracleDataReader reader = cmd.ExecuteReader();
				//						while(reader.Read())
				//						{
				//							txtMPOI.Text=Convert.ToString(reader["VEND_ADD1"]);
				//							txtMConPer.Text=Convert.ToString(reader["VEND_CONTACT_PER_1"]);
				//							txtMPNo.Text=Convert.ToString(reader["VEND_CONTACT_TEL_1"]);
				//							txtMEmail.Text=Convert.ToString(reader["VEND_EMAIL"]);
				//						}
				//						conn1.Close();
				manufac_details();
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
				//conn1.Dispose();
			}






		}

		//		int  FindIeCODE()
		//		{
		//			int IE_code=0;
		//			int Altie=0;
		//			int strval=0;
		//			int Clustercode;
		//			string vcode=ddlManufac.SelectedItem.Value;
		//			System.Data.OracleClient.OracleConnection cone = new System.Data.OracleClient.OracleConnection((ConfigurationSettings.AppSettings["ConnectionString"])) ;
		//            string Command="select distinct(b.Cluster_code) from T100_vender_cluster a inner join t99_cluster_master b  on a.cluster_code=b.cluster_code where a.vendor_code="+vcode+"  and a.DEPARTMENT_NAME='"+Dropdownlist1.SelectedItem.Value+"' and b.region_code='"+CNO.Substring(0,1).ToString()+"'";
		//			OracleCommand Comm1 = new OracleCommand(Command, cone);
		//			cone.Open();
		//			DataSet ds=new DataSet();
		//			OracleDataAdapter da=new OracleDataAdapter(Comm1);
		//			da.Fill(ds);
		//			cone.Close();
		//			if(ds.Tables[0].Rows.Count>0)
		//			{
		//				Clustercode= Convert.ToInt32(ds.Tables[0].Rows[0]["Cluster_code"]);
		//				if(Clustercode==0)
		//				{
		//					strval= 0;	
		//				}
		//				else
		//				{
		//					string Command1 ="select Ie_code from T101_ie_cluster where cluster_code="+Clustercode+" and DEPARTMENT_CODE='"+Dropdownlist1.SelectedItem.Value+"'";
		//					//string Command1="select distinct(a.Ie_code) from T101_ie_cluster a,t99_cluster_master b where a.cluster_code="+Clustercode+" and a.DEPARTMENT_CODE='"+Dropdownlist1.SelectedItem.Value+"' and b.region_code='"+CNO.Substring(0,1).ToString()+"'";
		//					OracleCommand Comm12 = new OracleCommand(Command1, cone);
		//					DataSet ds12=new DataSet();
		//					OracleDataAdapter da1=new OracleDataAdapter(Comm12);
		//					da1.Fill(ds12);
		//					cone.Close();
		//					if(ds12.Tables[0].Rows.Count>0)
		//					{
		//						int ieCode= Convert.ToInt32(ds12.Tables[0].Rows[0]["Ie_code"]);
		//						//					string Command1234 ="select distinct( ie_cd) from t47_ie_work_plan where Ie_cd='"+ieCode+"'  and VISIT_DT =to_date('" + Label28.Text + "','dd/mm/yyyy')";
		//						//					OracleCommand Comm1234 = new OracleCommand(Command1234, cone);
		//						//					cone.Open();
		//						//					DataSet ds1234=new DataSet();
		//						//					OracleDataAdapter da1234=new OracleDataAdapter(Comm1234);
		//						//					da1234.Fill(ds1234);
		//						//					cone.Close();
		//                  
		//						//					if(ds1234.Tables[0].Rows.Count>0)
		//						//					{
		//						//						int IE_Avlability=Convert.ToInt32(ds1234.Tables[0].Rows[0]["IE_CD"]);
		//						//                    
		//						//						if(IE_Avlability !=0)
		//						//						{
		//												
		//						//string Command12345 ="select count(1)call_status  from t17_call_register where call_status in('M','S') and  ie_cd='"+ieCode+"' and call_recv_dt>'01-JAN-2017'";
		//						string Command12345="SELECT count(a.call_status)call_status FROM t17_call_register a inner join T09_IE b on a.ie_cd =b.ie_cd where a.call_status in('M','S') and  a.ie_cd='"+ieCode+"' and a.call_recv_dt>'01-JAN-2017'";
		//						//and b.IE_CALL_MARKING='Y'";
		//						
		//						
		//						//string Command12345="SELECT count(a.call_status)call_status FROM t17_call_register a inner join T09_IE b on a.ie_cd =b.ie_cd where a.call_status in('M','S') and  a.ie_cd='"+ieCode+"' and a.call_recv_dt>'01-JAN-2017' and b.IE_CALL_MARKING='Y'";
		//						OracleCommand Comm12345 = new OracleCommand(Command12345, cone);
		//						cone.Open();
		//						DataSet ds12345=new DataSet();
		//						OracleDataAdapter da12345=new OracleDataAdapter(Comm12345);
		//						da12345.Fill(ds12345);
		//						cone.Close();
		//                         	
		//						if(ds12345.Tables[0].Rows.Count>0)
		//						{
		//							int countcalls=Convert.ToInt32(ds12345.Tables[0].Rows[0]["call_status"]);
		//	
		//							string Command1234544="SELECT IE_CALL_MARKING  FROM T09_IE  where IE_CD='"+ieCode+"'";
		//							OracleCommand Comm1234544 = new OracleCommand(Command1234544, cone);
		//							cone.Open();
		//							DataSet ds1234544=new DataSet();
		//							OracleDataAdapter da1234544=new OracleDataAdapter(Comm1234544);
		//							da1234544.Fill(ds1234544);
		//							cone.Close();
		//						    string callmarking=ds1234544.Tables[0].Rows[0]["IE_CALL_MARKING"].ToString();
		//		
		//							if(callmarking=="") 
		//							{
		//								strval= 0;	
		//							}
		//						    else if( callmarking=="N")
		//							 {
		//								 strval= 0;	
		//							 }
		//							 else
		//							 {
		//								 //string Command123456 ="select M.Maximum_call,M.region_code,I.Ie_cd from t102_ie_maximum_call_limit M  inner join t17_call_register I on M.region_code=I.region_code  where ie_cd='"+IE_Avlability+"'";
		//								 string Command123456="select MAXIMUM_CALL from T102_IE_mAXIMUM_CALL_LIMIT where region_code='"+CNO.Substring(0,1).ToString()+"'";
		//								 OracleCommand Comm123456 = new OracleCommand(Command123456, cone);
		//								 cone.Open();
		//								 DataSet ds123456=new DataSet();
		//								 OracleDataAdapter da123456=new OracleDataAdapter(Comm123456);
		//								 da123456.Fill(ds123456);
		//								 cone.Close();	
		//								 if(ds123456.Tables[0].Rows.Count>0)
		//								 {
		//									 int Maximumcalls=Convert.ToInt32(ds123456.Tables[0].Rows[0]["MAXIMUM_CALL"]);
		//
		//									 if(countcalls<Maximumcalls)
		//									 {
		//										 strval= ieCode;			
		//									 }
		//									 else
		//									 {
		//										 string query1 ="select Alt_ie as ALT_IE from t09_ie  where ie_cd='"+ ieCode+"'";
		//										 OracleCommand Cmd1 = new OracleCommand(query1, cone);
		//										 cone.Open();
		//										 DataSet dast=new DataSet();
		//										 OracleDataAdapter oda=new OracleDataAdapter(Cmd1);
		//										 oda.Fill(dast);
		//										 cone.Close();
		//										 if(dast.Tables[0].Rows.Count>0)
		//										 {
		//											 if(dast.Tables[0].Rows[0]["ALT_IE"].ToString()=="")
		//											 {
		//												 strval=0;
		//											 }
		//											 else
		//											 {
		//												 int  Alt_ieCode=Convert.ToInt32(dast.Tables[0].Rows[0]["ALT_IE"]);
		//									
		//												 //									string Command12348 ="select distinct(ie_cd) from t47_ie_work_plan where IE_CD='"+Alt_ieCode+"' and  VISIT_DT =to_date('" + Label28.Text + "','dd/mm/yyyy')";
		//												 //									OracleCommand Comm12348 = new OracleCommand(Command12348, cone);
		//												 //									cone.Open();
		//												 //									DataSet ds12348=new DataSet();
		//												 //									OracleDataAdapter da12348=new OracleDataAdapter(Comm12348);
		//												 //									da12348.Fill(ds12348);
		//												 //									cone.Close();
		//												 //									if(ds12348.Tables[0].Rows.Count>0)
		//												 //									{
		//												 //										int Alt_IE_Avlability=Convert.ToInt32(ds12348.Tables[0].Rows[0]["IE_CD"]);
		//												 //										if(Alt_IE_Avlability !=0)
		//												 //										{
		//												 //string Command1234578 ="select count(1)call_status  from t17_call_register where call_status in('M','S') and  ie_cd='"+Alt_ieCode+"'  and call_recv_dt>'01-JAN-2017'";
		//												 string Command1234578="SELECT count(a.call_status)call_status FROM t17_call_register a,T09_IE b where a.ie_cd =b.ie_cd and a.call_status in('M','S') and  a.ie_cd='"+ieCode+"' and a.call_recv_dt>'01-JAN-2017' and b.IE_CALL_MARKING='Y'";
		//												 OracleCommand Comm1234578 = new OracleCommand(Command1234578, cone);
		//												 cone.Open();
		//												 DataSet ds1234578=new DataSet();
		//												 OracleDataAdapter da1234578=new OracleDataAdapter(Comm1234578);
		//												 da1234578.Fill(ds1234578);
		//												 cone.Close();
		//												 if(ds1234578.Tables[0].Rows.Count>0)
		//												 {
		//													 int countcalls123=Convert.ToInt32(ds12345.Tables[0].Rows[0]["call_status"]);
		//													 if(countcalls123==0)
		//													 {
		//														 strval= 0;	
		//													 }
		//													 else
		//													 {
		//														 //string Command12345623 ="select M.Maximum_call,M.region_code,I.Ie_cd,A.alt_ie from t102_ie_maximum_call_limit M  inner join t17_call_register I on M.region_code=I.region_code  inner join T09_IE A on A.IE_REGION=I.REGION_CODE where I.ie_cd='"+Alt_IE_Avlability+"'";
		//														 string Command12345623="select MAXIMUM_CALL from T102_IE_mAXIMUM_CALL_LIMIT where  region_code='"+CNO.Substring(0,1).ToString()+"'";
		//														 OracleCommand Comm12345623 = new OracleCommand(Command12345623, cone);
		//														 cone.Open();
		//														 DataSet ds12345623=new DataSet();
		//														 OracleDataAdapter da12345623=new OracleDataAdapter(Comm12345623);
		//														 da123456.Fill(ds12345623);
		//														 cone.Close();
		//														 if(ds12345623.Tables[0].Rows.Count>0)
		//														 {
		//															 int Maximumcalls1=Convert.ToInt32(ds12345623.Tables[0].Rows[0]["Maximum_call"]);
		//															 //Altie=Convert.ToInt32(ds12345623.Tables[0].Rows[0]["alt_ie"]);
		//															 if(countcalls123<Maximumcalls1)
		//															 {
		//																 strval= Alt_ieCode;
		//															 }
		//														 }
		//													 }
		//												 }
		//											 }
		//											 //}
		//											
		//											 //}
		//										 }
		//										
		//									 }
		//
		//									 return strval;//iecode found here
		//
		//
		//								 }
		//							 }
		//						}
		//					}
		//					else
		//					{
		//						//                            int altiecode=AlTAvebleCOde(ieCode);//altie found here
		//						//							strval=altiecode;
		//							
		//
		//						//						}
		//						//					}
		//					}
		//				}
		//				
		//			}
		//			return strval;
		//		}

		//		int  FindIeCODE()
		//		{
		//			int strval=0;
		//			int Clustercode;
		//			int vcode=0;
		//			vcode=Convert.ToInt32(ddlManufac.SelectedItem.Value);
		//			System.Data.OracleClient.OracleConnection cone = new System.Data.OracleClient.OracleConnection((ConfigurationSettings.AppSettings["ConnectionString"])) ;
		//			string Command="select distinct(b.Cluster_code) from T100_vender_cluster a inner join t99_cluster_master b  on a.cluster_code=b.cluster_code where a.vendor_code="+vcode+"  and a.DEPARTMENT_NAME='"+Dropdownlist1.SelectedItem.Value+"' and b.region_code='"+CNO.Substring(0,1).ToString()+"'";
		//			OracleCommand Comm1 = new OracleCommand(Command, cone);
		//			cone.Open();
		//			DataSet ds=new DataSet();
		//			OracleDataAdapter da=new OracleDataAdapter(Comm1);
		//			da.Fill(ds);
		//			cone.Close();
		//			if(ds.Tables[0].Rows.Count>0)
		//			{
		//				Clustercode= Convert.ToInt32(ds.Tables[0].Rows[0]["Cluster_code"]);
		//				if(Clustercode==0)
		//				{
		//					strval= 0;	
		//				}
		//				else
		//				{
		//					string Command1 ="select Ie_code from T101_ie_cluster where cluster_code="+Clustercode+" and DEPARTMENT_CODE='"+Dropdownlist1.SelectedItem.Value+"'";
		//					OracleCommand Comm12 = new OracleCommand(Command1, cone);
		//					DataSet ds12=new DataSet();
		//					OracleDataAdapter da1=new OracleDataAdapter(Comm12);
		//					da1.Fill(ds12);
		//					cone.Close();
		//					if(ds12.Tables[0].Rows.Count>0)
		//					{
		//						int ieCode= Convert.ToInt32(ds12.Tables[0].Rows[0]["Ie_code"]);
		//						string Command12345="SELECT count(a.call_status)call_status FROM t17_call_register a inner join T09_IE b on a.ie_cd =b.ie_cd where a.call_status in('M','S') and  a.ie_cd='"+ieCode+"' and a.call_recv_dt>'01-JAN-2017'";
		//						OracleCommand Comm12345 = new OracleCommand(Command12345, cone);
		//						cone.Open();
		//						DataSet ds12345=new DataSet();
		//						OracleDataAdapter da12345=new OracleDataAdapter(Comm12345);
		//						da12345.Fill(ds12345);
		//						cone.Close();
		//						//develpoed by 13th may 2018 by swadhin sahoo-developer	
		//						if(ds12345.Tables[0].Rows.Count>0)
		//						{
		//							int countcalls=Convert.ToInt32(ds12345.Tables[0].Rows[0]["call_status"]);
		//							string Command1234544="SELECT IE_CALL_MARKING  FROM T09_IE  where IE_CD='"+ieCode+"'";
		//							OracleCommand Comm1234544 = new OracleCommand(Command1234544, cone);
		//							cone.Open();
		//							DataSet ds1234544=new DataSet();
		//							OracleDataAdapter da1234544=new OracleDataAdapter(Comm1234544);
		//							da1234544.Fill(ds1234544);
		//							cone.Close();
		//							string callmarking=ds1234544.Tables[0].Rows[0]["IE_CALL_MARKING"].ToString();
		//		
		//							if(callmarking=="") 
		//							{
		//								strval= 0;	
		//							}
		//							if( callmarking=="N")
		//							{
		//								//strval= 0;	
		//							}
		//							string Command123456="select MAXIMUM_CALL from T102_IE_mAXIMUM_CALL_LIMIT where region_code='"+CNO.Substring(0,1).ToString()+"'";
		//							OracleCommand Comm123456 = new OracleCommand(Command123456, cone);
		//							cone.Open();
		//							DataSet ds123456=new DataSet();
		//							OracleDataAdapter da123456=new OracleDataAdapter(Comm123456);
		//							da123456.Fill(ds123456);
		//							cone.Close();	
		//							if(ds123456.Tables[0].Rows.Count>0)
		//							{
		//								int Maximumcalls=Convert.ToInt32(ds123456.Tables[0].Rows[0]["MAXIMUM_CALL"]);
		//                     
		//								if(countcalls<Maximumcalls && callmarking=="Y")
		//								{
		//									strval= ieCode;			
		//								}
		//								else
		//								{
		//									string query1 ="select Alt_ie as ALT_IE from t09_ie  where ie_cd='"+ ieCode+"'";
		//									OracleCommand Cmd1 = new OracleCommand(query1, cone);
		//									cone.Open();
		//									DataSet dast=new DataSet();
		//									OracleDataAdapter oda=new OracleDataAdapter(Cmd1);
		//									oda.Fill(dast);
		//									cone.Close();
		//									if(dast.Tables[0].Rows.Count>0)
		//									{
		//										int  Alt_ieCode=Convert.ToInt32(dast.Tables[0].Rows[0]["ALT_IE"]);
		//										string Command1234578="SELECT count(a.call_status)call_status FROM t17_call_register a,T09_IE b where a.ie_cd =b.ie_cd and a.call_status in('M','S') and  a.ie_cd='"+Alt_ieCode+"' and a.call_recv_dt>'01-JAN-2017'";
		//										OracleCommand Comm1234578 = new OracleCommand(Command1234578, cone);
		//										cone.Open();
		//										DataSet ds1234578=new DataSet();
		//										OracleDataAdapter da1234578=new OracleDataAdapter(Comm1234578);
		//										da1234578.Fill(ds1234578);
		//										cone.Close();
		//										if(ds1234578.Tables[0].Rows.Count>0)
		//										{
		//											int countcalls123=Convert.ToInt32(ds1234578.Tables[0].Rows[0]["call_status"]);
		//
		//											string Command12345441="SELECT IE_CALL_MARKING  FROM T09_IE  where IE_CD='"+Alt_ieCode+"'";
		//											OracleCommand Comm12345441 = new OracleCommand(Command12345441, cone);
		//											cone.Open();
		//											DataSet ds12345441=new DataSet();
		//											OracleDataAdapter da12345441=new OracleDataAdapter(Comm12345441);
		//											da12345441.Fill(ds12345441);
		//											cone.Close();
		//											if(Convert.ToInt32(countcalls123)==0)
		//											{
		//												strval= 0;	
		//											}
		//											else
		//											{
		//											
		//												string callmarkings=ds12345441.Tables[0].Rows[0]["IE_CALL_MARKING"].ToString();
		//		
		//												if(callmarkings=="") 
		//												{
		//													strval= 0;	
		//												}
		//												if( callmarkings=="N")
		//												{
		//													//strval= 0;	
		//												}
		//												string Command12345623="select MAXIMUM_CALL from T102_IE_mAXIMUM_CALL_LIMIT where  region_code='"+CNO.Substring(0,1).ToString()+"'";
		//												OracleCommand Comm12345623 = new OracleCommand(Command12345623, cone);
		//												cone.Open();
		//												DataSet ds12345623=new DataSet();
		//												OracleDataAdapter da12345623=new OracleDataAdapter(Comm12345623);
		//												da123456.Fill(ds12345623);
		//												cone.Close();
		//												if(ds12345623.Tables[0].Rows.Count>0)
		//												{
		//													int Maximumcalls1=Convert.ToInt32(ds12345623.Tables[0].Rows[0]["Maximum_call"]);
		//													if(countcalls123<Maximumcalls1 && callmarkings=="Y" )
		//													{
		//														strval= Alt_ieCode;
		//													}
		//													else
		//													{
		//														strval= 0;	
		//													}
		//												}
		//											
		//													
		//											}
		//											return strval;
		//										}
		//									}
		//										
		//								}
		//
		//								return strval;
		//
		//
		//							}
		//							
		//							//}
		//						}
		//
		//					}
		//					else
		//					{
		//						
		//					}
		//				}
		//				
		//			}
		//			return strval;
		//		}


		int FindIeCODE()
		{
			string department1 = string.Empty;
			int strval = 0;
			int Clustercode;
			int vcode = 0;
			string region = CNO.Substring(0, 1).ToString();
			if (region == "N")
			{
				department1 = Dropdownlist1.SelectedItem.Value;
				if (department1 == "M")
				{
					department1 = "M";
				}
				else if (department1 == "E")
				{
					department1 = "E";
				}
				else
					department1 = "M";
			}
			else
			{
				department1 = Dropdownlist1.SelectedItem.Value;
			}
			vcode = Convert.ToInt32(ddlManufac.SelectedItem.Value);
			OracleConnection cone = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			//System.Data.OracleClient.OracleConnection cone = new System.Data.OracleClient.OracleConnection((ConfigurationSettings.AppSettings["ConnectionString"]));
			string Command = "select distinct(b.Cluster_code) from T100_vender_cluster a inner join t99_cluster_master b  on a.cluster_code=b.cluster_code where a.vendor_code=" + vcode + "  and a.DEPARTMENT_NAME='" + department1.ToString() + "' and b.region_code='" + CNO.Substring(0, 1).ToString() + "'";
			OracleCommand Comm1 = new OracleCommand(Command, cone);
			cone.Open();
			DataSet ds = new DataSet();
			OracleDataAdapter da = new OracleDataAdapter(Comm1);
			da.Fill(ds);
			cone.Close();
			if (ds.Tables[0].Rows.Count > 0)
			{
				Clustercode = Convert.ToInt32(ds.Tables[0].Rows[0]["Cluster_code"]);
				if (Clustercode == 0)
				{
					strval = 0;
				}
				else
				{
					lblCluster_Cd.Text = Convert.ToString(Clustercode);
					string Command1 = "select Ie_code from T101_ie_cluster where cluster_code=" + Clustercode + " and DEPARTMENT_CODE='" + department1.ToString() + "'";
					OracleCommand Comm12 = new OracleCommand(Command1, cone);
					DataSet ds12 = new DataSet();
					OracleDataAdapter da1 = new OracleDataAdapter(Comm12);
					da1.Fill(ds12);
					cone.Close();
					if (ds12.Tables[0].Rows.Count > 0)
					{
						int ieCode = Convert.ToInt32(ds12.Tables[0].Rows[0]["Ie_code"]);
						lblClusterIE_CD.Text = ieCode.ToString();
						string Command12345 = "SELECT count(a.call_status)call_status FROM t17_call_register a inner join T09_IE b on a.ie_cd =b.ie_cd where a.call_status in('M','S') and  a.ie_cd='" + ieCode + "' and a.call_recv_dt>'01-JAN-2017'";
						OracleCommand Comm12345 = new OracleCommand(Command12345, cone);
						cone.Open();
						DataSet ds12345 = new DataSet();
						OracleDataAdapter da12345 = new OracleDataAdapter(Comm12345);
						da12345.Fill(ds12345);
						cone.Close();
						//develpoed by 13th may 2018 by swadhin sahoo-developer	
						if (ds12345.Tables[0].Rows.Count > 0)
						{
							int countcalls = Convert.ToInt32(ds12345.Tables[0].Rows[0]["call_status"]);
							string Command1234544 = "SELECT IE_CALL_MARKING  FROM T09_IE  where IE_CD='" + ieCode + "'";
							OracleCommand Comm1234544 = new OracleCommand(Command1234544, cone);
							cone.Open();
							DataSet ds1234544 = new DataSet();
							OracleDataAdapter da1234544 = new OracleDataAdapter(Comm1234544);
							da1234544.Fill(ds1234544);
							cone.Close();


							if (Convert.ToInt32(ieCode) == 0)
							{
								strval = 0;
							}
							else
							{
								string callmarking = ds1234544.Tables[0].Rows[0]["IE_CALL_MARKING"].ToString();

								if (callmarking == "")
								{
									strval = 0;
								}
								if (callmarking == "N")
								{

								}
								string Command123456 = "select MAXIMUM_CALL from T102_IE_mAXIMUM_CALL_LIMIT where region_code='" + CNO.Substring(0, 1).ToString() + "'";
								OracleCommand Comm123456 = new OracleCommand(Command123456, cone);
								cone.Open();
								DataSet ds123456 = new DataSet();
								OracleDataAdapter da123456 = new OracleDataAdapter(Comm123456);
								da123456.Fill(ds123456);
								cone.Close();
								if (ds123456.Tables[0].Rows.Count > 0)
								{
									int Maximumcalls = Convert.ToInt32(ds123456.Tables[0].Rows[0]["MAXIMUM_CALL"]);

									if (countcalls < Maximumcalls && callmarking == "Y")
									{
										strval = ieCode;
									}
									else
									{
										string query1 = "select Alt_ie as ALT_IE from t09_ie  where ie_cd='" + ieCode + "'";
										OracleCommand Cmd1 = new OracleCommand(query1, cone);
										cone.Open();
										DataSet dast = new DataSet();
										OracleDataAdapter oda = new OracleDataAdapter(Cmd1);
										oda.Fill(dast);
										cone.Close();
										if (dast.Tables[0].Rows.Count > 0)
										{
											int Alt_ieCode = Convert.ToInt32(dast.Tables[0].Rows[0]["ALT_IE"]);
											string Command1234578 = "SELECT count(a.call_status)call_status FROM t17_call_register a,T09_IE b where a.ie_cd =b.ie_cd and a.call_status in('M','S') and  a.ie_cd='" + Alt_ieCode + "' and a.call_recv_dt>'01-JAN-2017'";
											OracleCommand Comm1234578 = new OracleCommand(Command1234578, cone);
											cone.Open();
											DataSet ds1234578 = new DataSet();
											OracleDataAdapter da1234578 = new OracleDataAdapter(Comm1234578);
											da1234578.Fill(ds1234578);
											cone.Close();
											if (ds1234578.Tables[0].Rows.Count > 0)
											{
												int countcalls123 = Convert.ToInt32(ds1234578.Tables[0].Rows[0]["call_status"]);

												string Command12345441 = "SELECT IE_CALL_MARKING  FROM T09_IE  where IE_CD='" + Alt_ieCode + "'";
												OracleCommand Comm12345441 = new OracleCommand(Command12345441, cone);
												cone.Open();
												DataSet ds12345441 = new DataSet();
												OracleDataAdapter da12345441 = new OracleDataAdapter(Comm12345441);
												da12345441.Fill(ds12345441);
												cone.Close();
												if (Convert.ToInt32(Alt_ieCode) == 0)
												{
													strval = 0;
												}
												else
												{

													string callmarkings = ds12345441.Tables[0].Rows[0]["IE_CALL_MARKING"].ToString();

													if (callmarkings == "")
													{
														strval = 0;
													}
													if (callmarkings == "N")
													{

													}
													string Command12345623 = "select MAXIMUM_CALL from T102_IE_mAXIMUM_CALL_LIMIT where  region_code='" + CNO.Substring(0, 1).ToString() + "'";
													OracleCommand Comm12345623 = new OracleCommand(Command12345623, cone);
													cone.Open();
													DataSet ds12345623 = new DataSet();
													OracleDataAdapter da12345623 = new OracleDataAdapter(Comm12345623);
													da123456.Fill(ds12345623);
													cone.Close();
													if (ds12345623.Tables[0].Rows.Count > 0)
													{
														int Maximumcalls1 = Convert.ToInt32(ds12345623.Tables[0].Rows[0]["Maximum_call"]);
														if (countcalls123 < Maximumcalls1 && callmarkings == "Y")
														{
															strval = Alt_ieCode;
														}
														else
														{
															string query12 = "select  ALT_IE_TWO from t09_ie  where ie_cd='" + ieCode + "'";
															OracleCommand Cmd12 = new OracleCommand(query12, cone);
															cone.Open();
															DataSet dast1 = new DataSet();
															OracleDataAdapter oda1 = new OracleDataAdapter(Cmd12);
															oda1.Fill(dast1);
															cone.Close();
															if (dast1.Tables[0].Rows[0]["ALT_IE_TWO"].ToString() == string.Empty)
															{
																strval = 0;
															}
															else
															{

																int Alt_ieCode_TWO = Convert.ToInt32(dast1.Tables[0].Rows[0]["ALT_IE_TWO"]);
																string Command12345789 = "SELECT count(a.call_status)call_status FROM t17_call_register a,T09_IE b where a.ie_cd =b.ie_cd and a.call_status in('M','S') and  a.ie_cd='" + Alt_ieCode_TWO + "' and a.call_recv_dt>'01-JAN-2017'";
																OracleCommand Comm12345789 = new OracleCommand(Command12345789, cone);
																cone.Open();
																DataSet ds12345789 = new DataSet();
																OracleDataAdapter da12345789 = new OracleDataAdapter(Comm12345789);
																da1234578.Fill(ds12345789);
																cone.Close();
																if (ds12345789.Tables[0].Rows.Count > 0)
																{
																	int countcalls1234 = Convert.ToInt32(ds12345789.Tables[0].Rows[0]["call_status"]);
																	string Command123454412 = "SELECT IE_CALL_MARKING  FROM T09_IE  where IE_CD='" + Alt_ieCode_TWO + "'";
																	OracleCommand Comm123454412 = new OracleCommand(Command123454412, cone);
																	cone.Open();
																	DataSet ds123454412 = new DataSet();
																	OracleDataAdapter da123454412 = new OracleDataAdapter(Comm123454412);
																	da123454412.Fill(ds123454412);
																	cone.Close();
																	if (Convert.ToInt32(Alt_ieCode_TWO) == 0)
																	{
																		strval = 0;
																	}
																	else
																	{
																		string callmarkings1 = ds123454412.Tables[0].Rows[0]["IE_CALL_MARKING"].ToString();

																		if (callmarkings1 == "")
																		{
																			strval = 0;
																		}
																		if (callmarkings1 == "N")
																		{

																		}
																		string Command123456231 = "select MAXIMUM_CALL from T102_IE_mAXIMUM_CALL_LIMIT where  region_code='" + CNO.Substring(0, 1).ToString() + "'";
																		OracleCommand Comm123456231 = new OracleCommand(Command123456231, cone);
																		cone.Open();
																		DataSet ds123456231 = new DataSet();
																		OracleDataAdapter da123456231 = new OracleDataAdapter(Comm123456231);
																		da123456231.Fill(ds123456231);
																		cone.Close();
																		if (ds123456231.Tables[0].Rows.Count > 0)
																		{
																			int Maximumcalls12 = Convert.ToInt32(ds123456231.Tables[0].Rows[0]["Maximum_call"]);
																			if (countcalls1234 < Maximumcalls12 && callmarkings1 == "Y")
																			{
																				strval = Alt_ieCode_TWO;
																			}
																			else
																			{
																				string query123 = "select ALT_IE_THREE from t09_ie  where ie_cd='" + ieCode + "'";
																				OracleCommand Cmd121 = new OracleCommand(query123, cone);
																				cone.Open();
																				DataSet dst = new DataSet();
																				OracleDataAdapter oda21 = new OracleDataAdapter(Cmd121);
																				oda21.Fill(dst);
																				cone.Close();

																				if (dst.Tables[0].Rows[0]["ALT_IE_THREE"].ToString() == string.Empty)
																				{
																					strval = 0;
																				}
																				else
																				{

																					int Alt_ieCode_THREE = Convert.ToInt32(dst.Tables[0].Rows[0]["ALT_IE_THREE"]);
																					string Command12345788 = "SELECT count(a.call_status)call_status FROM t17_call_register a,T09_IE b where a.ie_cd =b.ie_cd and a.call_status in('M','S') and  a.ie_cd='" + Alt_ieCode_THREE + "' and a.call_recv_dt>'01-JAN-2017'";
																					OracleCommand Comm12345788 = new OracleCommand(Command12345788, cone);
																					cone.Open();
																					DataSet ds12345788 = new DataSet();
																					OracleDataAdapter da12345788 = new OracleDataAdapter(Comm12345788);
																					da12345788.Fill(ds12345788);
																					cone.Close();
																					if (ds12345788.Tables[0].Rows.Count > 0)
																					{
																						int countcalls1233 = Convert.ToInt32(ds12345788.Tables[0].Rows[0]["call_status"]);

																						string Command123454411 = "SELECT IE_CALL_MARKING  FROM T09_IE  where IE_CD='" + Alt_ieCode_THREE + "'";
																						OracleCommand Comm123454411 = new OracleCommand(Command123454411, cone);
																						cone.Open();
																						DataSet ds123454411 = new DataSet();
																						OracleDataAdapter da123454411 = new OracleDataAdapter(Comm123454411);
																						da123454411.Fill(ds123454411);
																						cone.Close();
																						if (Convert.ToInt32(Alt_ieCode_THREE) == 0)
																						{
																							strval = 0;
																						}
																						else
																						{

																							string callmarkings123 = ds123454411.Tables[0].Rows[0]["IE_CALL_MARKING"].ToString();

																							if (callmarkings123 == "")
																							{
																								strval = 0;
																							}
																							if (callmarkings123 == "N")
																							{

																							}
																							string Command123456235 = "select MAXIMUM_CALL from T102_IE_mAXIMUM_CALL_LIMIT where  region_code='" + CNO.Substring(0, 1).ToString() + "'";
																							OracleCommand Comm123456233 = new OracleCommand(Command123456235, cone);
																							cone.Open();
																							DataSet ds1234562334 = new DataSet();
																							OracleDataAdapter da1234562345 = new OracleDataAdapter(Comm123456233);
																							da1234562345.Fill(ds1234562334);
																							cone.Close();
																							if (ds1234562334.Tables[0].Rows.Count > 0)
																							{
																								int Maximumcalls131 = Convert.ToInt32(ds1234562334.Tables[0].Rows[0]["Maximum_call"]);
																								if (countcalls1233 < Maximumcalls131 && callmarkings123 == "Y")
																								{
																									strval = Alt_ieCode_THREE;
																								}
																								else
																								{
																									strval = 0;

																								}
																							}


																						}
																						return strval;
																					}


																				}
																				return strval;
																			}
																			return strval;
																		}

																	}

																	return strval;

																}


															}

														}
														return strval;

													}

												}
												return strval;
											}
										}
									}
									return strval;
								}
							}
						}
						return strval;
					}
				}
			}
			return strval;
		}



		void show()
		{
			try
			{
				//				string str1="SELECT 'Marked' Status,T18.ITEM_SRNO_PO ITEM_SRNO_PO,T18.ITEM_DESC_PO ITEM_DESC_PO ,T18.QTY_ORDERED,T18.CUM_QTY_PREV_OFFERED,T18.CUM_QTY_PREV_PASSED,T18.QTY_TO_INSP,T18.QTY_PASSED,T18.QTY_REJECTED,T18.QTY_DUE, (T06.CONSIGNEE_CD||'-'||nvl2(trim(T06.CONSIGNEE_DESIG),trim(T06.CONSIGNEE_DESIG)||'/','')||nvl2(trim(T06.CONSIGNEE_DEPT),trim(T06.CONSIGNEE_DEPT)||'/','')||nvl2(trim(T06.CONSIGNEE_FIRM),trim(T06.CONSIGNEE_FIRM)||'/','')||NVL2(trim(T06.CONSIGNEE_ADD1),trim(T06.CONSIGNEE_ADD1)||'/','')||NVL2(trim(T03.LOCATION),trim(T03.LOCATION)||' : '||trim(T03.CITY),trim(T03.CITY))) CONSIGNEE  FROM T18_CALL_DETAILS T18,T06_CONSIGNEE T06, T03_CITY T03  where T18.CONSIGNEE_CD=T06.CONSIGNEE_CD and T06.CONSIGNEE_CITY=T03.CITY_CD and T18.CASE_NO='"+ CNO +"' AND T18.CALL_RECV_DT=to_date('"+DT+"','dd/mm/yyyy') AND CALL_SNO="+Label29.Text;
				//					str1=str1 + " union SELECT 'Available' Status,T15.ITEM_SRNO ITEM_SRNO_PO,T15.ITEM_DESC ITEM_DESC_PO,T15.QTY QTY_ORDERED,(0) CUM_QTY_PREV_OFFERED,(0) CUM_QTY_PREV_PASSED, (0) QTY_TO_INSP,(0) QTY_PASSED,(0) QTY_REJECTED,(0) QTY_DUE,(T06.CONSIGNEE_CD||'-'||nvl2(trim(T06.CONSIGNEE_DESIG),trim(T06.CONSIGNEE_DESIG)||'/','')||nvl2(trim(T06.CONSIGNEE_DEPT),trim(T06.CONSIGNEE_DEPT)||'/','')||nvl2(trim(T06.CONSIGNEE_FIRM),trim(T06.CONSIGNEE_FIRM)||'/','')||NVL2(trim(T06.CONSIGNEE_ADD1),trim(T06.CONSIGNEE_ADD1)||'/','')||NVL2(trim(T03.LOCATION),trim(T03.LOCATION)||' : '||trim(T03.CITY),trim(T03.CITY))) CONSIGNEE FROM T15_PO_DETAIL T15,T06_CONSIGNEE T06,T03_CITY T03 where T15.CONSIGNEE_CD=T06.CONSIGNEE_CD and T06.CONSIGNEE_CITY=T03.CITY_CD and T15.CASE_NO='"+CNO+"'"; 
				//					str1=str1+ " and T15.ITEM_SRNO not in (select ITEM_SRNO_PO from T18_CALL_DETAILS  where CASE_NO='"+CNO+"' and CALL_RECV_DT=to_date('"+DT+"','dd/mm/yyyy') AND CALL_SNO="+Label29.Text+") order by Status DESC, ITEM_SRNO_PO";
				string str1 = "SELECT T15.ITEM_SRNO ITEM_SRNO_PO,T15.ITEM_DESC ITEM_DESC_PO,T15.QTY QTY_ORDERED,(0) CUM_QTY_PREV_OFFERED,(0) CUM_QTY_PREV_PASSED, (0) QTY_TO_INSP,(0) QTY_PASSED,(0) QTY_REJECTED,(0) QTY_DUE,(T06.CONSIGNEE_CD||'-'||nvl2(trim(T06.CONSIGNEE_DESIG),trim(T06.CONSIGNEE_DESIG)||'/','')||nvl2(trim(T06.CONSIGNEE_DEPT),trim(T06.CONSIGNEE_DEPT)||'/','')||nvl2(trim(T06.CONSIGNEE_FIRM),trim(T06.CONSIGNEE_FIRM)||'/','')||NVL2(trim(T06.CONSIGNEE_ADD1),trim(T06.CONSIGNEE_ADD1)||'/','')||NVL2(trim(T03.LOCATION),trim(T03.LOCATION)||' : '||trim(T03.CITY),trim(T03.CITY))) CONSIGNEE, NVL(to_char(EXT_DELV_DT,'dd/mm/yyyy'),'01-JAN-01')DELV_DATE, (B.BPO_CD||'-'||B.BPO_NAME||'/'||B.BPO_RLY||'/'||NVL2(B.BPO_ADD,B.BPO_ADD||'/','')||NVL2(C.LOCATION,C.CITY||'/'||C.LOCATION,C.CITY)) BPO FROM T15_PO_DETAIL T15,T06_CONSIGNEE T06,T03_CITY T03,T14_PO_BPO T14, T12_BILL_PAYING_OFFICER B, T03_CITY C where T15.CONSIGNEE_CD=T06.CONSIGNEE_CD and T06.CONSIGNEE_CITY=T03.CITY_CD AND T15.CASE_NO=T14.CASE_NO AND T15.CONSIGNEE_CD=T14.CONSIGNEE_CD AND T14.BPO_CD=B.BPO_CD(+) AND B.BPO_CITY_CD=C.CITY_CD(+) and T15.CASE_NO='" + CNO + "' ORDER BY T15.ITEM_SRNO";
				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdCDetails_1.Visible = false;
					Label24.Visible = false;
				}
				else
				{
					grdCDetails.Visible = false;
					grdCDetails_1.Visible = true;
					Label24.Visible = true;
					grdCDetails_1.DataSource = dsP;
					grdCDetails_1.DataBind();
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
				//conn1.Dispose();
			}


		}


		void show_items()
		{
			try
			{
				string str1 = "SELECT 'Marked' Status,T18.ITEM_SRNO_PO ITEM_SRNO_PO,T18.ITEM_DESC_PO ITEM_DESC_PO ,T18.QTY_ORDERED,T18.CUM_QTY_PREV_OFFERED,T18.CUM_QTY_PREV_PASSED,T18.QTY_TO_INSP,T18.QTY_PASSED,T18.QTY_REJECTED,T18.QTY_DUE, (T06.CONSIGNEE_CD||'-'||nvl2(trim(T06.CONSIGNEE_DESIG),trim(T06.CONSIGNEE_DESIG)||'/','')||nvl2(trim(T06.CONSIGNEE_DEPT),trim(T06.CONSIGNEE_DEPT)||'/','')||nvl2(trim(T06.CONSIGNEE_FIRM),trim(T06.CONSIGNEE_FIRM)||'/','')||NVL2(trim(T06.CONSIGNEE_ADD1),trim(T06.CONSIGNEE_ADD1)||'/','')||NVL2(trim(T03.LOCATION),trim(T03.LOCATION)||' : '||trim(T03.CITY),trim(T03.CITY))) CONSIGNEE, NULL DELV_DATE  FROM T18_CALL_DETAILS T18,T06_CONSIGNEE T06, T03_CITY T03  where T18.CONSIGNEE_CD=T06.CONSIGNEE_CD and T06.CONSIGNEE_CITY=T03.CITY_CD and T18.CASE_NO='" + CNO + "' AND T18.CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') AND CALL_SNO=" + Label29.Text;
				str1 = str1 + " union SELECT 'Available' Status,T15.ITEM_SRNO ITEM_SRNO_PO,T15.ITEM_DESC ITEM_DESC_PO,T15.QTY QTY_ORDERED,(0) CUM_QTY_PREV_OFFERED,(0) CUM_QTY_PREV_PASSED, (0) QTY_TO_INSP,(0) QTY_PASSED,(0) QTY_REJECTED,(0) QTY_DUE,(T06.CONSIGNEE_CD||'-'||nvl2(trim(T06.CONSIGNEE_DESIG),trim(T06.CONSIGNEE_DESIG)||'/','')||nvl2(trim(T06.CONSIGNEE_DEPT),trim(T06.CONSIGNEE_DEPT)||'/','')||nvl2(trim(T06.CONSIGNEE_FIRM),trim(T06.CONSIGNEE_FIRM)||'/','')||NVL2(trim(T06.CONSIGNEE_ADD1),trim(T06.CONSIGNEE_ADD1)||'/','')||NVL2(trim(T03.LOCATION),trim(T03.LOCATION)||' : '||trim(T03.CITY),trim(T03.CITY))) CONSIGNEE, NVL(to_char(T15.EXT_DELV_DT,'dd/mm/yyyy'),'01-JAN-01') DELV_DATE FROM T15_PO_DETAIL T15,T06_CONSIGNEE T06,T03_CITY T03 where T15.CONSIGNEE_CD=T06.CONSIGNEE_CD and T06.CONSIGNEE_CITY=T03.CITY_CD and T15.CASE_NO='" + CNO + "'";
				str1 = str1 + " and T15.ITEM_SRNO not in (select ITEM_SRNO_PO from T18_CALL_DETAILS  where CASE_NO='" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') AND CALL_SNO=" + Label29.Text + ") order by Status DESC, ITEM_SRNO_PO";

				OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
				OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand;
				da.Fill(dsP, "Table");
				if (dsP.Tables[0].Rows.Count == 0)
				{
					grdCDetails.Visible = false;
					Label24.Visible = false;
				}
				else
				{
					grdCDetails_1.Visible = false;
					grdCDetails.Visible = true;
					Label24.Visible = true;
					grdCDetails.DataSource = dsP;
					grdCDetails.DataBind();
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
				//conn1.Dispose();
			}


		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
			btnDelete.Attributes.Add("OnClick", "JavaScript:del();");
			btnFCList.Attributes.Add("OnClick", "JavaScript:validate1();");



			if (Convert.ToString(Request.Params["Case_No"]) == null || Convert.ToString(Request.Params["DT_RECIEPT"]) == null)
			{
				CNO = "";
				DT = "";

			}
			else
			{
				CNO = Convert.ToString(Request.Params["Case_No"].Trim());
				DT = Convert.ToString(Request.Params["DT_RECIEPT"].Trim());
				Action = Convert.ToString(Request.Params["Action"]);
				wFOS = Convert.ToString(Request.Params["FOS"]);

				if (wFOS == "F")
				{
					rdbFinal.Checked = true;
				}
				else if (wFOS == "S")
				{
					rdbStage.Checked = true;
				}
				if (DT == "")
				{
					Response.Redirect("Error_Form.aspx?err=No Call is Registered On this Case. Kindly enter the Case No & Click on [New Call] Button!!!");
				}
				//				CSNO=Convert.ToString(Request.Params ["CALL_SNO"].Trim());

			}

			if (!(IsPostBack))
			{

				try
				{
					Dropdownlist1.Items.Insert(0, new ListItem("-Select Departmentlist item-", ""));
					ListItem lst5 = new ListItem();
					lst5 = new ListItem();
					lst5.Text = "Mechanical";
					lst5.Value = "M";
					//lst5.Selected=true;
					Dropdownlist1.Items.Add(lst5);
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
					//				lst5 = new ListItem(); 
					//				lst5.Text = "Power Engineering"; 

					//				lst5.Value = "P"; 
					//				Dropdownlist1.Items.Add(lst5);
					lst5 = new ListItem();
					lst5.Text = "M & P";
					lst5.Value = "Z";
					Dropdownlist1.Items.Add(lst5);
					if (Action == "A")
					{

						DataSet dsP2 = new DataSet();
						string str2 = "select to_char(C.CALL_MARK_DT,'dd/mm/yyyy') CALL_MARK_DT,C.CALL_SNO,NVL(I.IE_NAME,'NIL')IE_NAME from T17_CALL_REGISTER C, T09_IE I where C.IE_CD=I.IE_CD(+) and CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy')";
						OracleDataAdapter da2 = new OracleDataAdapter(str2, conn1);
						OracleCommand myCommand1 = new OracleCommand(str2, conn1);
						da2.SelectCommand = myCommand1;
						da2.Fill(dsP2, "Table");
						conn1.Close();
						if (dsP2.Tables[0].Rows.Count != 0)
						{
							//throw new System.Exception("The Record is Already Present for the Given Case No and Call Date and It is issued to IE="+dsP2.Tables[0].Rows[0]["IE_NAME"].ToString()+" vide Call Serial No.="+dsP2.Tables[0].Rows[0]["CALL_SNO"].ToString()+"and Call Mark Date="+dsP2.Tables[0].Rows[0]["CALL_MARK_DT"].ToString());
							string msg = "The Call Already Present for the Given Case No and Call Date -: \\n";
							for (int i = 0; i <= dsP2.Tables[0].Rows.Count - 1; i++)
							{
								msg = msg + (i + 1) + ") Marked To: " + dsP2.Tables[0].Rows[i]["IE_NAME"].ToString() + " vide Call Serial No.=" + dsP2.Tables[0].Rows[i]["CALL_SNO"].ToString() + " and Call Date=" + dsP2.Tables[0].Rows[i]["CALL_MARK_DT"].ToString() + ". \\n";
							}

							DisplayAlert1(msg);
							show1();
						}
						else
						{

							show1();
						}

						conn1.Open();
						OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH:MI:SS') from dual", conn1);
						string ss = Convert.ToString(cmd2.ExecuteScalar());
						conn1.Close();
						txtDtMark.Text = DT;
						txtExpOfIns.Text = DT;
						txtDtOfCan.Text = DT;
						txtDtMark.Enabled = false;
						txtDtOfCan.Enabled = false;
						fill_Region(CNO.Substring(0, 1).ToString());
						txtCallStatus.Text = "Marked";
						show();
						conn1.Open();
						OracleCommand cmd3 = new OracleCommand("Select RLY_NONRLY, to_char(RECV_DT,'YYYYMMDD')RECV_DATE, NVL(POI_CD,0) POI_CODE, NVL(VEND_CD,0) VEND_CODE, PO_OR_LETTER  from T13_PO_MASTER WHERE CASE_NO= '" + CNO + "'", conn1);
						//string rly=Convert.ToString(cmd3.ExecuteScalar());
						OracleDataReader reader3 = cmd3.ExecuteReader();
						string rly = "";
						string recv_date = "";
						int poi_cd = 0;
						int vend_cd = 0;
						string po_or_offer = "";
						while (reader3.Read())
						{

							rly = reader3["RLY_NONRLY"].ToString();
							recv_date = reader3["RECV_DATE"].ToString();
							poi_cd = Convert.ToInt32(reader3["POI_CODE"].ToString());
							vend_cd = Convert.ToInt32(reader3["VEND_CODE"].ToString());
							po_or_offer = reader3["PO_OR_LETTER"].ToString();
						}
						conn1.Close();

						if (rly == "R")
						{
							lblIRFC.Visible = true;
							ddlIRFC.Visible = true;
						}
						else
						{
							lblIRFC.Visible = false;
							ddlIRFC.Visible = false;
						}

						if (poi_cd != 0)
						{
							fill_poi(poi_cd);
							if (rly == "R" && po_or_offer == "P")
							{
								chkManuf.Enabled = false;
								btnFCList.Visible = false;
								ddlManufac.Enabled = true;
								txtMPOI.Enabled = false;
								txtMName.Enabled = false;
							}
							else
							{
								chkManuf.Enabled = true;
								btnFCList.Visible = true;
								ddlManufac.Enabled = true;
								txtMPOI.Enabled = true;
								txtMName.Enabled = true;
							}
						}
						else if (poi_cd == 0)
						{
							if (rly == "R" && Convert.ToInt32(recv_date) >= 20170111 && po_or_offer == "P")
							{
								fill_poi(vend_cd);
								chkManuf.Enabled = false;
								btnFCList.Visible = false;
								ddlManufac.Enabled = true;
								txtMPOI.Enabled = false;
								txtMName.Enabled = false;

							}
							else
							{
								chkManuf.Enabled = true;
								btnFCList.Visible = true;
								ddlManufac.Enabled = true;
								txtMPOI.Enabled = true;
								txtMName.Enabled = true;
							}


						}
					}

					txtCaseNo.Text = CNO;
					txtCaseNo.Visible = false;
					txtCaseNo.Enabled = false;
					Label27.Text = CNO;
					Label27.Visible = true;
					txtDtOfReciept.Text = DT;
					//txtDtOfReciept.Visible=false;
					//txtDtOfReciept.Enabled =false;
					Label28.Text = DT;
					Label28.Visible = true;
					//lstCallStatus.SelectedValue ="M";
					//lstCallStatus.Enabled =false;

					//txtCallSno.Enabled =false;
					Label29.Visible = false;
					//txtCallSno.Visible=false;

					DataSet dsP1 = new DataSet();
					string str3 = "select IE_CD, IE_NAME from T09_IE where IE_STATUS is null and IE_REGION='" + CNO.Substring(0, 1) + "' order by IE_NAME ";
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
						lstIE.Items.Add(lst3);
					}
					conn1.Close();
					lstIE.Items.Insert(0, "");



					ListItem lst = new ListItem();
					lst = new ListItem();
					lst.Text = "1st  Re-Mark";
					lst.Value = "1";
					lstCallRStatus.Items.Add(lst);
					lst = new ListItem();
					lst.Text = "2nd  Re-Mark";
					lst.Value = "2";
					lstCallRStatus.Items.Add(lst);
					lst = new ListItem();
					lst.Text = "3rd  Re-Mark";
					lst.Value = "3";
					lstCallRStatus.Items.Add(lst);
					lst = new ListItem();
					lst.Text = "4th  Re-Mark";
					lst.Value = "4";
					lstCallRStatus.Items.Add(lst);
					lst = new ListItem();
					lst.Text = "5th  Re-Mark";
					lst.Value = "5";
					lstCallRStatus.Items.Add(lst);
					lst = new ListItem();
					lst.Text = "6th  Re-Mark";
					lst.Value = "6";
					lstCallRStatus.Items.Add(lst);
					lst = new ListItem();
					lst.Text = "7th  Re-Mark";
					lst.Value = "7";
					lstCallRStatus.Items.Add(lst);
					lst = new ListItem();
					lst.Text = "8th  Re-Mark";
					lst.Value = "8";
					lstCallRStatus.Items.Add(lst);
					lst = new ListItem();
					lst.Text = "9th  Re-Mark";
					lst.Value = "9";
					lstCallRStatus.Items.Add(lst);
					lstCallRStatus.Items.Insert(0, "");
					item_rdso();
					vendor_rdso();
					stag_dp();
					File1.Visible = false;

					//					
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
					//conn1.Dispose();
				}

				if (Action == "M" || Action == "D")
				{


					try
					{
						CSNO = Convert.ToString(Request.Params["CALL_SNO"].Trim());
						show1();
						DataSet dsP1 = new DataSet();
						string str1 = "select CASE_NO,to_char(CALL_RECV_DT,'dd/mm/yyyy')CALL_RECV_DT,CALL_LETTER_NO,to_char(CALL_LETTER_DT,'dd/mm/yyyy')CALL_LETTER_DT,to_char(CALL_MARK_DT,'dd/mm/yyyy')CALL_MARK_DT,CALL_SNO,IE_CD,to_char(DT_INSP_DESIRE,'dd/mm/yyyy') DT_INSP_DESIRE,decode(CALL_STATUS,'M','Marked','C','Cancelled','A','Accepted','R','Rejected','U','Under Lab Testing','S','Still Under Inspection','G','Stage Inspection')||decode(CALL_CANCEL_STATUS,'N',' (Non Chargeable)','C',' (Chargeable)','') CALL_STATUS,to_char(CALL_STATUS_DT,'dd/mm/yyyy')CALL_STATUS_DT,CALL_REMARK_STATUS,CALL_INSTALL_NO,REGION_CODE,MFG_CD,MFG_PLACE,NVL(UPDATE_ALLOWED,'Y')UPDATE_ALLOWED,REMARKS,FINAL_OR_STAGE,BPO,RECIPIENT_GSTIN_NO from T17_CALL_REGISTER where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') and CALL_SNO=" + CSNO;
						OracleDataAdapter da1 = new OracleDataAdapter(str1, conn1);
						OracleCommand myOracleCommand1 = new OracleCommand(str1, conn1);
						conn1.Open();
						da1.SelectCommand = myOracleCommand1;
						da1.Fill(dsP1, "Table");
						conn1.Close();
						if (dsP1.Tables[0].Rows.Count == 0)
						{
							throw new System.Exception("Record not found for the given Case No. and Call Recieve Date. !!! ");
							//DisplayAlert("Record not found for the given Case No. and Call Recieve Date. !!! ");
						}
						else
						{

							txtCaseNo.Text = dsP1.Tables[0].Rows[0]["CASE_NO"].ToString();
							txtCaseNo.Visible = false;
							Label27.Text = dsP1.Tables[0].Rows[0]["CASE_NO"].ToString();
							txtDtOfReciept.Text = dsP1.Tables[0].Rows[0]["CALL_RECV_DT"].ToString();
							//txtDtOfReciept.Visible=false;
							Label28.Text = dsP1.Tables[0].Rows[0]["CALL_RECV_DT"].ToString();
							txtCallNO.Text = dsP1.Tables[0].Rows[0]["CALL_LETTER_NO"].ToString();
							txtCallDt.Text = dsP1.Tables[0].Rows[0]["CALL_LETTER_DT"].ToString();
							txtDtMark.Text = dsP1.Tables[0].Rows[0]["CALL_MARK_DT"].ToString();
							//txtCallSno.Text=dsP1.Tables[0].Rows[0]["CALL_SNO"].ToString (); 
							Label29.Visible = true;
							Label29.Text = dsP1.Tables[0].Rows[0]["CALL_SNO"].ToString();
							try
							{
								lstIE.SelectedValue = dsP1.Tables[0].Rows[0]["IE_CD"].ToString();
								if (lstIE.SelectedValue != "")
								{
									IE_NAME(lstIE.SelectedValue);
								}

							}
							catch (Exception ex)
							{
								string str;
								str = ex.Message;
								string str2 = str.Substring(0, 56);
								if (str2.CompareTo("Specified argument was out of the range of valid values.") == 0)
								{
									IE_NAME(dsP1.Tables[0].Rows[0]["IE_CD"].ToString());
								}

							}
							txtExpOfIns.Text = dsP1.Tables[0].Rows[0]["DT_INSP_DESIRE"].ToString();
							//lstCallStatus.SelectedValue = dsP1.Tables[0].Rows[0]["CALL_STATUS"].ToString (); 
							txtCallStatus.Text = dsP1.Tables[0].Rows[0]["CALL_STATUS"].ToString();
							txtDtOfCan.Text = dsP1.Tables[0].Rows[0]["CALL_STATUS_DT"].ToString();
							lstCallRStatus.SelectedValue = dsP1.Tables[0].Rows[0]["CALL_REMARK_STATUS"].ToString();
							txtCInstallNo.Text = dsP1.Tables[0].Rows[0]["CALL_INSTALL_NO"].ToString();
							txtRemarks.Text = dsP1.Tables[0].Rows[0]["REMARKS"].ToString();
							txtMPOI.Text = dsP1.Tables[0].Rows[0]["MFG_PLACE"].ToString();
							lblCUpdateStatus.Text = dsP1.Tables[0].Rows[0]["UPDATE_ALLOWED"].ToString();
							txtBPO.Text = dsP1.Tables[0].Rows[0]["BPO"].ToString();
							txtGSTINNo.Text = dsP1.Tables[0].Rows[0]["RECIPIENT_GSTIN_NO"].ToString();
							fill_Region(dsP1.Tables[0].Rows[0]["REGION_CODE"].ToString());
							if (dsP1.Tables[0].Rows[0]["FINAL_OR_STAGE"].ToString() == "S")
							{
								rdbStage.Checked = true;
							}
							else
							{
								rdbFinal.Checked = true;
							}

							rdbStage.Enabled = false;
							rdbFinal.Enabled = false;
							if (dsP1.Tables[0].Rows[0]["MFG_CD"].ToString() != "")
							{
								string str2 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(VEND_CD)=" + dsP1.Tables[0].Rows[0]["MFG_CD"].ToString() + " and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
								fill_manufacturer(str2);

								//fill_manufacturer(dsP1.Tables[0].Rows[0]["MFG_CD"].ToString ());
								ddlManufac.Visible = true;
								txtMName.Text = dsP1.Tables[0].Rows[0]["MFG_CD"].ToString();
								OracleCommand cmd = new OracleCommand("select VEND_ADD1,VEND_CONTACT_PER_1,VEND_CONTACT_TEL_1,VEND_EMAIL from T05_VENDOR where VEND_CD='" + ddlManufac.SelectedValue + "'", conn1);
								conn1.Open();
								OracleDataReader reader = cmd.ExecuteReader();
								while (reader.Read())
								{
									//txtMPOI.Text=Convert.ToString(reader["VEND_ADD1"]);
									txtMConPer.Text = Convert.ToString(reader["VEND_CONTACT_PER_1"]);
									txtMPNo.Text = Convert.ToString(reader["VEND_CONTACT_TEL_1"]);
									txtMEmail.Text = Convert.ToString(reader["VEND_EMAIL"]);
								}
								conn1.Close();

							}
							txtDtMark.Enabled = false;
							txtDtOfCan.Enabled = false;
						}
						if (Action == "M")
						{
							//if(txtCallStatus.Text=="Accepted" || txtCallStatus.Text=="Rejected" ||txtCallStatus.Text=="Cancelled")
							if (lblCUpdateStatus.Text == "N")
							{
								btnSave.Enabled = false;
								btnDelete.Enabled = false;
								status = "N";
							}
							else
							{
								btnSave.Enabled = true;
								btnSave.Visible = true;
								//																btnDelete.Enabled=true;
								//																btnDelete.Visible=true;
								status = "M";
							}
							//							btnDelete.Visible =false;
							//							btnCDetails.Visible =true;

							//							if(Session["Role_CD"].ToString()=="4")
							//							{
							//								btnSave.Visible=false;
							//								btnDelete.Visible=false;
							//								btnFCList.Visible=false;
							//								btnUManuf.Visible=false;
							//								
							//							}
							CheckBox1.Checked = true;
						}
						//						else if(Action=="D")
						//						{
						//							//if(txtCallStatus.Text=="Accepted" || txtCallStatus.Text=="Rejected" ||txtCallStatus.Text=="Cancelled")
						//							if(lblCUpdateStatus.Text=="N")
						//							{
						//								btnDelete.Enabled=false;
						//								btnSave.Enabled=false;
						//								status="N";
						//							}
						//							else
						//							{
						//								btnDelete.Enabled=true;
						//								btnDelete.Visible=true;
						//								status="M";
						//								
						//							}
						//							btnSave.Visible =false;
						////							btnCDetails.Visible =true;
						//						}
						txtCaseNo.Enabled = false;
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
						//conn1.Dispose();
					}
					show_items();
					btnPrint.Visible = true;


					//					conn1.Open();
					//					OracleCommand cmd22 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual",conn1);
					//					string sd=Convert.ToString(cmd22.ExecuteScalar());
					//					conn1.Close();
					//
					//					System.DateTime w_dt1 = new System.DateTime(Convert.ToInt32(sd.Substring(6,4)),Convert.ToInt32(sd.Substring(3,2)),Convert.ToInt32(sd.Substring(0,2)));
					//					System.DateTime w_dt2 = new System.DateTime(Convert.ToInt32(Label28.Text.Substring(6,4)),Convert.ToInt32(Label28.Text.Substring(3,2)),Convert.ToInt32(Label28.Text.Substring(0,2)));
					//					TimeSpan ts = w_dt1 - w_dt2;
					//					int differenceInDays = ts.Days;
					//
					//					if(lblIE.Text!="" || differenceInDays>0) 
					//					{
					btnSave.Enabled = false;
					grdCDetails.Columns[0].Visible = false;
					grdCDetails.Columns[1].Visible = false;
					//					}
				}
				else
					btnDelete.Visible = false;
			}

		}
		void IE_NAME(string ie_cd)
		{
			lstIE.Visible = false;
			string query1 = "Select IE_NAME,IE_STATUS from T09_IE where IE_CD=" + ie_cd;
			conn1.Open();
			OracleCommand Command1 = new OracleCommand(query1, conn1);
			OracleDataReader reader1 = Command1.ExecuteReader();
			lblIE.Visible = true;
			while (reader1.Read())
			{
				lblIE.Text = reader1["IE_NAME"].ToString();

				if (reader1["IE_STATUS"].ToString() == "L")
				{
					lblIE.Text = lblIE.Text + "(Status:Left)";
				}
				else if (reader1["IE_STATUS"].ToString() == "R")
				{
					lblIE.Text = lblIE.Text + "(Status:Retired)";
				}

			}
			conn1.Close();
			reader1.Close();
			if (lblIE.Text != "")
			{
				Label7.Visible = true;
			}
		}

		public void grdCDetails_Edit(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			btnSave.Visible = false;
			grdCDetails.EditItemIndex = e.Item.ItemIndex;
			show_items();

		}

		public void grdCDetails_Cancel(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			btnSave.Visible = true;
			grdCDetails.EditItemIndex = -1;
			show_items();
		}
		public void grdCDetails_Update(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			decimal isrno = Convert.ToDecimal(e.Item.Cells[2].Text);
			decimal qoff = 0;
			if ((e.Item.FindControl("txtQTYOFFNOW") as TextBox).Text.Trim() != "")
			{
				qoff = Convert.ToDecimal((e.Item.FindControl("txtQTYOFFNOW") as TextBox).Text.Trim());

			}
			if (qoff > 0)
			{
				conn1.Open();
				OracleCommand cmd1 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
				string ss = Convert.ToString(cmd1.ExecuteScalar());

				OracleCommand cmd2 = new OracleCommand("Select NVL(CASE_NO,'X') from T18_CALL_DETAILS where CASE_NO='" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + Label28.Text + "','dd/mm/yyyy') and CALL_SNO=" + Label29.Text.Trim() + " AND ITEM_SRNO_PO=" + isrno, conn1);
				string itemstatus = Convert.ToString(cmd2.ExecuteScalar());
				conn1.Close();
				if (itemstatus == "")
				{

					string str = "Select CONSIGNEE_CD from T15_PO_DETAIL WHERE CASE_NO='" + txtCaseNo.Text + "' AND ITEM_SRNO=" + isrno;
					OracleCommand cmd = new OracleCommand(str, conn1);
					conn1.Open();
					long ccd = Convert.ToInt64(cmd.ExecuteScalar());
					//string myInsertQuery = "INSERT INTO T18_CALL_DETAILS values('" + txtCaseNo.Text + "', to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy')," + txtSerialNo.Text + ", '" + txtIDesc.Text  + "'," + txtQOrd.Text + "," + txtCQty.Text + "," + txtQPrePassed.Text + "," + txtQuanInsp.Text + ","+txtQPass.Text +","+txtQRej.Text +","+ txtQtyDue.Text +",'"+Session["Uname"]+"', to_date('" +ss+ "','dd/mm/yyyy-HH24:MI:SS'))"; 
					string myInsertQuery = "INSERT INTO T18_CALL_DETAILS values('" + txtCaseNo.Text + "', to_date('" + Label28.Text + "','dd/mm/yyyy')," + Label29.Text + "," + isrno + ", upper('" + Convert.ToString(e.Item.Cells[4].Text) + "')," + ccd + "," + Convert.ToDecimal(e.Item.Cells[6].Text) + "," + Convert.ToDecimal(e.Item.Cells[7].Text) + "," + Convert.ToDecimal(e.Item.Cells[8].Text) + "," + qoff + ",'" + null + "','" + null + "','" + null + "','" + Session["VEND_CD"] + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
					OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
					myInsertCommand.Connection = conn1;
					myInsertCommand.ExecuteNonQuery();
					conn1.Close();

				}
				else
				{
					string myUpdateQuery = "Update T18_CALL_DETAILS set QTY_TO_INSP=" + qoff + " where CASE_NO= '" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + Label28.Text + "','dd/mm/yyyy') and CALL_SNO=" + Label29.Text.Trim() + " and ITEM_SRNO_PO=" + isrno;
					OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
					myUpdateCommand.Connection = conn1;
					conn1.Open();
					myUpdateCommand.ExecuteNonQuery();
					conn1.Close();
				}
				grdCDetails.EditItemIndex = -1;
				show_items();
				btnSave.Visible = true;
				btnPrint.Visible = true;
			}
			else
			{
				DisplayAlert("Quantity Offered Now Should be Greater then 0 !!!");
			}
		}
		public void fill_Region(string reg)
		{
			try
			{
				if (reg == "N")
				{
					Label31.Text = "Northern";
				}
				else if (reg == "S")
				{
					Label31.Text = "Southern";
				}
				else if (reg == "E")
				{
					Label31.Text = "Eastern";
				}
				else if (reg == "W")
				{
					Label31.Text = "Western";
				}
				else if (reg == "C")
				{
					Label31.Text = "Central";
				}

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
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
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.rdbIYes.CheckedChanged += new System.EventHandler(this.rdbIYes_CheckedChanged);
			this.rdbINo.CheckedChanged += new System.EventHandler(this.rdbIYes_CheckedChanged);
			this.rdbVYes.CheckedChanged += new System.EventHandler(this.rdbVYes_CheckedChanged);
			this.rdbVNo.CheckedChanged += new System.EventHandler(this.rdbVYes_CheckedChanged);
			this.rdbSYes.CheckedChanged += new System.EventHandler(this.rdbSYes_CheckedChanged);
			this.rdbSNo.CheckedChanged += new System.EventHandler(this.rdbSYes_CheckedChanged);
			this.chkManuf.CheckedChanged += new System.EventHandler(this.chkManuf_CheckedChanged);
			this.btnFCList.Click += new System.EventHandler(this.btnFCList_Click);
			this.ddlManufac.SelectedIndexChanged += new System.EventHandler(this.ddlManufac_SelectedIndexChanged);
			this.btnUManuf.Click += new System.EventHandler(this.btnUManuf_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			//				int e_status=0;
			//				try 
			//				{
			//					//if(lstCallRStatus.SelectedValue=="")
			//					if(ddlManufac.Visible==false)
			//					{
			//						DisplayAlert("Plz select Manufacturer first and then save it");
			//					}
			//					else
			//					{
			//						conn1.Open();
			//						OracleCommand cmd2 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual",conn1);
			//						ss=Convert.ToString(cmd2.ExecuteScalar());
			//						conn1.Close();
			//						if (Action == "A") 
			//						{ 
			//                            conn1.Open();
			//
			////							OracleCommand cmdCL =new OracleCommand("Select NVL(count(*),0) COUNT from T17_CALL_REGISTER where CASE_NO= '" + Label27.Text.Trim() + "' and CALL_LETTER_NO=trim(upper('"+txtCallNO.Text+"')) and REGION_CODE='"+CNO.Substring(0,1)+"'",conn1);
			//							OracleCommand cmdCL =new OracleCommand("Select NVL(count(*),0) COUNT from T17_CALL_REGISTER where CASE_NO= '" + Label27.Text.Trim() + "' and CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy') and REGION_CODE='"+CNO.Substring(0,1)+"'",conn1);
			//							int CL=Convert.ToInt32(cmdCL.ExecuteScalar());
			//							conn1.Close();
			//							if(CL==0)
			//							{
			//								conn1.Open();
			//								System.Data.OracleClient.OracleTransaction myTrans = conn1.BeginTransaction();
			//								try
			//								{
			//									string str3 = "select NVL(max(CALL_SNO),0)CALL_SNO from T17_CALL_REGISTER where CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy') and REGION_CODE='"+CNO.Substring(0,1)+"'"; 
			//									OracleCommand myCommand = new OracleCommand();
			//									myCommand.CommandText = str3;
			//									myCommand.Transaction=myTrans;
			//									myCommand.Connection = conn1;
			//									CD = Convert.ToInt32(myCommand.ExecuteScalar());
			//									CD = (CD + 1);
			//
			//									//							if(txtCInstallNo.Text=="")
			//									//							{
			//									//								txtCInstallNo.Text="null";
			//									//							}
			//									string myInsertQuery = "INSERT INTO T17_CALL_REGISTER(CASE_NO, CALL_RECV_DT, CALL_SNO, CALL_LETTER_NO, CALL_LETTER_DT,CALL_MARK_DT, IE_CD, DT_INSP_DESIRE, CALL_STATUS, CALL_STATUS_DT, CALL_REMARK_STATUS,CALL_INSTALL_NO, REGION_CODE, MFG_CD, USER_ID, DATETIME,MFG_PLACE,REMARKS) values('" + txtCaseNo.Text.Trim() + "', to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy')," + CD + ",trim(upper('"+txtCallNO.Text+"')),to_date('" + txtCallDt.Text + "','dd/mm/yyyy'),to_date('" + txtDtMark.Text + "','dd/mm/yyyy'), null,to_date('" + txtExpOfIns.Text + "','dd/mm/yyyy') ,'M',to_date('" + txtDtOfCan.Text + "','dd/mm/yyyy'),'"+lstCallRStatus.SelectedValue+"','" + txtCInstallNo.Text + "',upper('" + txtCaseNo.Text.Substring(0,1) + "'),'" + ddlManufac.SelectedValue + "','"+Session["VEND_CD"]+"', to_date('" +ss+ "','dd/mm/yyyy-HH24:MI:SS'),'"+txtMPOI.Text+"','"+txtRemarks.Text+"')"; 
			//									OracleCommand myInsertCommand = new OracleCommand(myInsertQuery); 
			//									myInsertCommand.Transaction=myTrans;
			//									myInsertCommand.Connection = conn1; 
			//									myInsertCommand.ExecuteNonQuery(); 
			//									myTrans.Commit();
			//									e_status=1;
			//									conn1.Close(); 
			//									DisplayAlert("Your Record Has Been Saved!!!");
			//									Label29.Text=CD.ToString();
			//									Label29.Visible=true;
			//									btnSave.Visible=false;
			//								}
			//								catch (Exception ex)
			//								{
			//									string str; 
			//									str = ex.Message; 
			//									myTrans.Rollback();
			//									e_status=0;
			//									DisplayAlert("Your Record Has Not Been Saved, So Try Again!!!");
			//								}
			//								finally
			//								{
			//									conn1.Close(); 
			//								}
			//								//txtCallSno.Visible=false;
			//								if(e_status==1)
			//								{
			//									show();
			//								}
			//								//btnSave.Enabled=false;
			//						
			//								//						string popupScript = "<script language='javascript'>" + "window.open('PopUp.aspx?str=Your Record Has Been Saved and Your Call Serial No is" + CD + "' , 'CustomPopUp', " + "'width=330, height=120, menubar=no, resizable=no')" + "</script>";
			//								//						Page.RegisterStartupScript("PopupScript", popupScript);
			//							}
			//							else
			//							{
			//								DisplayAlert("The Call for this Case No. is already in the given Call Date, Soo You cannot register the 2nd Call of this Case in same Call Date");
			//							}
			//						} 
			//						else if(Action=="M")
			//						{ 
			//							string Ucode=txtCaseNo.Text;
			////							if(txtCInstallNo.Text=="")
			////							{
			////								txtCInstallNo.Text="null";
			////							}
			//							string myUpdateQuery = "Update T17_CALL_REGISTER set CALL_LETTER_NO= trim(upper('"+txtCallNO.Text+"')),CALL_LETTER_DT=to_date('" + txtCallDt.Text + "','dd/mm/yyyy'),CALL_MARK_DT= to_date('" + txtDtMark.Text + "','dd/mm/yyyy'),CALL_SNO=" + Label29.Text + ",DT_INSP_DESIRE=to_date('" + txtExpOfIns.Text + "','dd/mm/yyyy'),CALL_STATUS_DT=to_date('" + txtDtOfCan.Text + "','dd/mm/yyyy'),CALL_REMARK_STATUS='"+lstCallRStatus.SelectedValue+"',CALL_INSTALL_NO='"+txtCInstallNo.Text+"',REMARKS='"+txtRemarks.Text+"',MFG_CD='" + ddlManufac.SelectedValue  + "',MFG_PLACE='"+txtMPOI.Text+"',USER_ID='"+Session["VEND_CD"] +"', DATETIME=to_date('" +ss+ "','dd/mm/yyyy-HH24:MI:SS') where (CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy') and CALL_SNO="+Label29.Text+")"; 
			//							OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery); 
			//							myUpdateCommand.Connection = conn1; 
			//							conn1.Open(); 
			//							myUpdateCommand.ExecuteNonQuery(); 
			//							CD=Convert.ToInt32(Label29.Text);
			//							conn1.Close(); 
			//							e_status=1;
			//							DisplayAlert("Your Record Has Been Saved!!!");
			//							
			//						
			//						}
			////						btnCDetails.Visible =true;
			//						//if(txtCallStatus.Text=="Accepted" || txtCallStatus.Text=="Rejected" ||txtCallStatus.Text=="Cancelled")
			//						if(lblCUpdateStatus.Text=="N")
			//						{
			//							btnSave.Enabled=false;
			//							btnDelete.Enabled=false;
			//						
			//						}
			//						else
			//						{
			//							btnSave.Enabled=true;
			//						}
			//					}
			////					send_IE_Email();
			//					if(e_status==1)
			//					{
			//						send_Vendor_Email();
			//					}
			//				} 
			//				catch (OracleException ex) 
			//				{ 
			//					string str; 
			//					str = ex.Message; 
			//					if(ex.Code==00001)
			//					{
			//					DisplayAlert("This Call is already registered. so go back and use modify to update it");
			//					}
			//					else
			//					{
			//						string str1=str.Replace("\n","");
			//						Response.Redirect(("Error_Form.aspx?err=" + str1));
			//					}
			//				}
			//				finally
			//				{
			//					conn1.Close(); 
			//				} 
			//				//Response.Redirect("Call_Register_Edit.aspx");

			//			conn1.Open();
			//			OracleCommand cmd =new OracleCommand("SELECT to_char(sysdate,'YYYYMMDD') CDATE, to_char(sysdate,'D') CDAY, to_char(sysdate,'HH24MI')CTYM FROM dual",conn1);
			//			string ss1="";
			//			int W_Cday=0;
			//			int W_cTym=0;
			//			OracleDataReader reader = cmd.ExecuteReader();
			//			while (reader.Read())
			//			{
			//				ss1=reader["CDATE"].ToString();
			//				W_Cday=Convert.ToInt16(reader["CDAY"].ToString());
			//				W_cTym=Convert.ToInt16(reader["CTYM"].ToString());
			//					
			//			}
			//			conn1.Close();
			//
			//			System.DateTime w_dt1 = new System.DateTime(Convert.ToInt32(ss1.Substring(6,4)),Convert.ToInt32(ss1.Substring(3,2)),Convert.ToInt32(ss1.Substring(0,2)));
			//			System.DateTime w_dt2 = new System.DateTime(Convert.ToInt32(Label28.Text.Trim().Substring(6,4)),Convert.ToInt32(Label28.Text.Trim().Substring(3,2)),Convert.ToInt32(Label28.Text.Trim().Substring(0,2)));
			//			TimeSpan ts = w_dt1 - w_dt2;
			//			int differenceInDays = ts.Days;
			//			
			//			if((differenceInDays==0 && W_cTym<1500) || (differenceInDays>0))
			//			{
			int w_no_of_days = check_desire_dt2();
			if (w_no_of_days == 1)
			{
				DisplayAlert("Expected Date of Inspection cannot be more then 5 days from Call Registration Date!!!");
			}
			else if (lblRLY_NONRly.Text == "R" && ddlIRFC.SelectedValue == "")
			{
				DisplayAlert("Select The project is IRFC Funded [Yes/No] !!!");
			}
			else
			{
				save_call();
			}
			//			}
			//			else
			//			{
			//				DisplayAlert("The Time Exceeds 1500 HRS, So the Call Registration Date has changed, Kindly go to Mainmenu=> Call For Inspection Form again and fill the details of Call again to register the call in next day.");	
			//			}

			//			DisplayAlert("Your Call is Registered, Acknowledgement mail is sent on your registered email-id!!!");
		}

		//		void call_marking()
		//		{
		//			try	
		//			{
		//				conn1.Close();
		//				OracleCommand cmd =new OracleCommand("SELECT COUNT(DISTINCT IE_CD) FROM T60_IE_POI_MAPPING where POI_CD="+ddlManufac.SelectedValue,conn1);
		//				conn1.Open();
		//				int no_of_ie=Convert.ToInt16(cmd.ExecuteScalar());
		//				if(no_of_ie==1)
		//				{
		//					string myUpdateQuery="UPDATE T17_CALL_REGISTER SET IE_CD=(SELECT DISTINCT IE_CD FROM T60_IE_POI_MAPPING where POI_CD="+ddlManufac.SelectedValue+") WHERE CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy') and CALL_SNO="+Label29.Text+")";
		//					OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery); 
		//					myUpdateCommand.Connection = conn1; 
		//					myUpdateCommand.ExecuteNonQuery(); 
		//				}
		//				else if(no_of_ie>1)
		//				{
		//					OracleCommand cmd1 =new OracleCommand("SELECT count(UNIQUE IE_CD) FROM T17_CALL_REGISTER WHERE MFG_CD='"+ddlManufac.SelectedValue+"' AND CALL_RECV_DT=(SELECT MAX(CALL_RECV_DT) FROM T17_CALL_REGISTER WHERE MFG_CD='"+ddlManufac.SelectedValue+"')",conn1);
		//					int no_of_ie2=Convert.ToInt16(cmd.ExecuteScalar());
		//					if(no_of_ie2==1)
		//					{
		//						string myUpdateQuery2="UPDATE T17_CALL_REGISTER SET IE_CD=(SELECT UNIQUE IE_CD FROM T17_CALL_REGISTER WHERE MFG_CD='"+ddlManufac.SelectedValue+"' AND CALL_RECV_DT=(SELECT MAX(CALL_RECV_DT) FROM T17_CALL_REGISTER WHERE MFG_CD='"+ddlManufac.SelectedValue+"')) WHERE CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy') and CALL_SNO="+Label29.Text+")";
		//						OracleCommand myUpdateCommand2 = new OracleCommand(myUpdateQuery2); 
		//						myUpdateCommand2.Connection = conn1; 
		//						myUpdateCommand2.ExecuteNonQuery();
		//					}
		//				}
		//				conn1.Close();
		//			
		//			}
		//			catch (Exception ex)
		//			{
		//				string str; 
		//				str = ex.Message; 
		//				//myTrans.Rollback();
		//			}
		//			finally
		//			{
		//				conn1.Close(); 
		//			}
		//		}
		void send_IE_sms(int ie_cd)
		{
			string sender = "";
			string wIEMobile = "", wIEName = "", wVendor = "", wCOMobile = "", wVendMobile = "", wIEMobile_for_SMS = "";
			OracleCommand cmd = new OracleCommand();
			if (txtCaseNo.Text.Substring(0, 1) == "N") { sender = "NR"; }
			else if (txtCaseNo.Text.Substring(0, 1) == "W") { sender = "WR"; }
			else if (txtCaseNo.Text.Substring(0, 1) == "E") { sender = "ER"; }
			else if (txtCaseNo.Text.Substring(0, 1) == "S") { sender = "SR"; }
			else if (txtCaseNo.Text.Substring(0, 1) == "C") { sender = "CR"; }
			else { sender = "RITES"; }
			//
			OracleConnection conn1 ;
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			conn1.Open();
			cmd.CommandText = "Select trim(SUBSTR(t09.IE_NAME,1,20)) IE_NAME,trim(substr(t09.IE_PHONE_NO,1,10)) IE_PHONE_NO, trim(substr(t08.CO_PHONE_NO,1,10)) CO_PHONE_NO from T09_IE t09,T08_IE_CONTROLL_OFFICER t08 where t08.CO_CD(+)=t09.IE_CO_CD and t09.IE_CD=" + ie_cd;
			cmd.Connection = conn1;
			OracleDataReader reader1 = cmd.ExecuteReader();
			while (reader1.Read())
			{
				wIEName = reader1["IE_NAME"].ToString();
				wIEMobile = reader1["IE_PHONE_NO"].ToString();
				wIEMobile_for_SMS = reader1["IE_PHONE_NO"].ToString();
				wCOMobile = reader1["CO_PHONE_NO"].ToString();
			}
			cmd.Dispose();
			//
			//cmd.CommandText="select substr(V.VEND_NAME,1,30)||','||substr(C.CITY,1,12) VEND_NAME,trim(substr(VEND_CONTACT_TEL_1,1,10)) VEND_TEL from T05_VENDOR V, T03_CITY C where VEND_CD="+txtMName.Text+" and V.VEND_CITY_CD=C.CITY_CD"; 
			cmd.CommandText = "select replace(substr(V.VEND_NAME,1,30),'&','AND') VEND_NAME,trim(substr(VEND_CONTACT_TEL_1,1,10)) VEND_TEL from T05_VENDOR V, T03_CITY C where VEND_CD=" + txtMName.Text + " and V.VEND_CITY_CD=C.CITY_CD";
			cmd.Connection = conn1;
			OracleDataReader reader2 = cmd.ExecuteReader();
			while (reader2.Read())
			{
				wVendor = reader2["VEND_NAME"].ToString();
				wVendMobile = reader2["VEND_TEL"].ToString();
			}
			cmd.Dispose();
			//
			if (wCOMobile != "") { wIEMobile = wIEMobile + "," + wCOMobile; }
			if (wVendMobile != "") { wIEMobile = wIEMobile + "," + wVendMobile; }
			//
			string message = "RITES LTD - QA Call Marked, IE-" + wIEName + ",Contact No.:" + wIEMobile_for_SMS + ",RLY-" + lblRly.Text + ",PO-" + lblL5noPo.Text + ",DT- " + Label22.Text + ", Firm Name-" + wVendor + ", Call Sno - " + Label29.Text + ",DT- " + Label28.Text + "- RITES/" + sender;
			//
			WebClient client = new WebClient();
			//string baseurl = "http://bulksms.mysmsmantra.com:8080/WebSMS/SMSAPI.jsp?username=ritesinsp&password=754347474&sendername=RITESQ&mobileno="+wIEMobile+"&message="+message;
			//string baseurl = "http://sandeshlive.in/API/WebSMS/Http/v1.0a/index.php?username=1ritesltd&password=R1te3@lxt&sender=RITESQ&to="+wIEMobile+"&message="+message+"&reqid=1&format={json|text}&route_id=23";
			//string baseurl = "http://103.247.98.91/API/SendMsg.aspx?uname=20181896&pass=9eBWwFz9&send=RITESQ&dest="+wIEMobile+"&msg="+message+"&priority=1";
			//string baseurl = "http://sandeshlive.in/API/WebSMS/Http/v1.0a/index.php?username=2ritesltd&password=Ag@14rtd&sender=RITESQ&to="+wIEMobile+"&message="+message+"&reqid=1&format={json|text}&route_id=23";
			//string baseurl = "https://apps.sandeshlive.com/API/WebSMS/Http/v1.0a/index.php?userid=532&password=Aa4cHZ5QFfKJEVzI&sender=RITESQ&to="+wIEMobile+"&message="+message+"&reqid=1&format={json|text}&route_id=3";
			//string baseurl = "http://nimbusit.co.in/api/swsendSingle.asp?username=t1RitesLtd&password=104848267&sender=RITESQ&sendto="+wIEMobile+"&message="+message+"&entityID=1501484780000011007";
			//string baseurl = "http://nimbusit.co.in/api/swsend.asp?username=t1RitesLtd&password=104848267&sender=RITESQ&sendto="+wIEMobile+"&message="+message;

			//string baseurl = "http://nimbusit.co.in/api/swsend.asp?username=t1RitesLtd&password=104848267&sender=RITESI&sendto="+wIEMobile+"&entityID=1501628520000011823&templateID=1707161588918541674&message="+message;

			string baseurl = "http://apin.onex-aura.com/api/sms?key=QtPr681q&to=" + wIEMobile + "&from=RITESI&body=" + message + "&entityid=1501628520000011823&templateid=1707161588918541674";
			Stream data = client.OpenRead(baseurl);
			StreamReader smsreader = new StreamReader(data);
			string s = smsreader.ReadToEnd();
			data.Close();
			smsreader.Close();
		}
		void send_Vendor_Email(int ie_cd)
		{
			
			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{

				string Case_Region = txtCaseNo.Text.Substring(0, 1);
				string wRegion = "";
				string sender = "";
				if (Case_Region == "N") { wRegion = "NORTHERN REGION <BR>12th FLOOR,CORE-II,SCOPE MINAR,LAXMI NAGAR, DELHI - 110092 <BR>Phone : +918800018691-95 <BR>Fax : 011-22024665"; sender = "nrinspn@rites.com"; }
				else if (Case_Region == "S") { wRegion = "SOUTHERN REGION <BR>CTS BUILDING - 2ND FLOOR, BSNL COMPLEX, NO. 16, GREAMS ROAD,  CHENNAI - 600 006 <BR>Phone : 044-28292807/044- 28292817 <BR>Fax : 044-28290359"; sender = "srinspn@rites.com"; }
				else if (Case_Region == "E") { wRegion = "EASTERN REGION <BR>CENTRAL STATION BUILDING(METRO), 56, C.R. AVENUE,3rd FLOOR,KOLKATA-700 012  <BR>Fax : 033-22348704"; sender = "erinspn@rites.com"; }
				else if (Case_Region == "W") { wRegion = "WESTERN REGION <BR>5TH FLOOR, REGENT CHAMBER, ABOVE STATUS RESTAURANT,NARIMAN POINT,MUMBAI-400021 <BR>Phone : 022-68943400/68943445 <BR>"; sender = "wrinspn@rites.com"; }
				else if (Case_Region == "C") { wRegion = "Central Region"; }

				OracleCommand cmd_vend = new OracleCommand("Select T13.VEND_CD,T05.VEND_NAME,NVL2(T05.VEND_ADD2,T05.VEND_ADD1||'/'||T05.VEND_ADD2,T05.VEND_ADD1)||'/'||T03.CITY VEND_ADDRESS, T05.VEND_EMAIL from T13_PO_MASTER T13,T05_VENDOR T05, T03_CITY T03 where T13.VEND_CD=T05.VEND_CD and T05.VEND_CITY_CD=T03.CITY_CD and CASE_NO='" + txtCaseNo.Text.Trim() + "'", conn1);
				conn1.Open();
				OracleDataReader reader = cmd_vend.ExecuteReader();
				string vend_cd = "", vend_add = "", vend_email = "";
				while (reader.Read())
				{
					vend_cd = Convert.ToString(reader["VEND_CD"]);
					vend_add = Convert.ToString(reader["VEND_ADDRESS"]);
					vend_email = Convert.ToString(reader["VEND_EMAIL"]);

				}
				conn1.Close();

				OracleCommand cmd = new OracleCommand("Select T05.VEND_EMAIL,T17.MFG_CD,to_char(T17.DT_INSP_DESIRE,'dd/mm/yyyy')DESIRE_DT from T05_VENDOR T05,T17_CALL_REGISTER T17 where T05.VEND_CD=T17.MFG_CD and CASE_NO='" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CALL_SNO=" + Label29.Text, conn1);
				conn1.Open();
				string manu_mail = "";
				string mfg_cd = "";
				string desire_dt = "";
				OracleDataReader reader1 = cmd.ExecuteReader();
				while (reader1.Read())
				{
					manu_mail = Convert.ToString(reader1["VEND_EMAIL"]);
					mfg_cd = Convert.ToString(reader1["MFG_CD"]);
					desire_dt = Convert.ToString(reader1["DESIRE_DT"]);
				}

				conn1.Close();
				//				OracleCommand cmd1 =new OracleCommand("Select IE_PHONE_NO from T09_IE where IE_CD="+lstIE.SelectedValue,conn1);
				//				conn1.Open();
				//				string ie_phone=Convert.ToString(cmd1.ExecuteScalar());
				//				conn1.Close();

				OracleCommand cmd1 = new OracleCommand("SELECT IE_PHONE_NO, CO_NAME, CO_PHONE_NO, IE_NAME, IE_EMAIL FROM T09_IE T09, T08_IE_CONTROLL_OFFICER T08 WHERE T09.IE_CO_CD=T08.CO_CD AND IE_CD=" + ie_cd, conn1);
				conn1.Open();
				OracleDataReader reader2 = cmd1.ExecuteReader();
				string ie_phone = "", co_name = "", co_mobile = "", ie_name = "", ie_email = "";
				while (reader2.Read())
				{
					ie_phone = Convert.ToString(reader2["IE_PHONE_NO"]);
					co_name = Convert.ToString(reader2["CO_NAME"]);
					co_mobile = Convert.ToString(reader2["CO_PHONE_NO"]);
					ie_name = Convert.ToString(reader2["IE_NAME"]);
					ie_email = Convert.ToString(reader2["IE_EMAIL"]);

				}
				conn1.Close();
				//				NO OF DAYS TO ATTEND THE CALL

				OracleCommand cmd11 = new OracleCommand("SELECT TO_CHAR(DT_INSP_DESIRE + (SELECT ROUND(COUNT(*)/1.5) DAYS FROM T17_CALL_REGISTER WHERE (CALL_RECV_DT>'01-APR-2017') AND CALL_STATUS IN ('M','S') AND IE_CD=" + ie_cd + "),'DD/MM/YYYY') INSP_DATE FROM T17_CALL_REGISTER WHERE CASE_NO='" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') and CALL_SNO=" + Label29.Text, conn1);
				conn1.Open();
				string dateto_attend = Convert.ToString(cmd11.ExecuteScalar());

				string updateQuery = "Update T17_CALL_REGISTER set EXP_INSP_DT=TO_DATE('" + dateto_attend + "','dd/mm/yyyy') where CASE_NO='" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + Label29.Text;
				OracleCommand myUpdateCommand = new OracleCommand(updateQuery, conn1);
				myUpdateCommand.ExecuteNonQuery();

				OracleCommand cmd21 = new OracleCommand("SELECT NVL(max(TIME_FOR_INSP),0) DAYS_TO_IC, T61.ITEM_CD FROM T18_CALL_DETAILS T18, T15_PO_DETAIL T15, T61_ITEM_MASTER T61 WHERE T18.CASE_NO=T15.CASE_NO AND T18.ITEM_SRNO_PO=T15.ITEM_SRNO AND T15.ITEM_CD=T61.ITEM_CD AND T15.CASE_NO='" + txtCaseNo.Text.Trim() + "' GROUP BY T61.ITEM_CD", conn1);
				OracleDataReader reader21 = cmd21.ExecuteReader();
				int days_to_ic = 0;
				string item_cd = "";
				while (reader21.Read())
				{
					days_to_ic = Convert.ToInt32(reader21["DAYS_TO_IC"]);
					item_cd = Convert.ToString(reader21["ITEM_CD"]);
				}

				conn1.Close();


				string call_letter_dt = "";
				if (txtCallDt.Text.Trim() == "")
				{
					call_letter_dt = "NIL";
				}
				else
				{
					call_letter_dt = txtCallDt.Text;
				}
				string mail_body = "Dear Sir/Madam,<br><br> In Reference to your Call Letter dated:  " + call_letter_dt + " for inspection of material against PO No. - " + Label25.Text + " & date - " + Label22.Text + ", Call has been registered vide Case No -  " + txtCaseNo.Text + ", on date: " + txtDtOfReciept.Text + ", at SNo. " + Label29.Text + ".<br> ";
				if (txtDtOfReciept.Text.Trim() != desire_dt.Trim())
				{
					mail_body = mail_body + "The Desired Inspection Date of this call shall be on or after: " + desire_dt.Trim() + ".<br>";
				}
				//				mail_body=mail_body+ "The inspection call has been assigned to Inspecting Engineer Sh. " + ie_name+", Contact No. "+ie_phone +". Based on the current workload with the IE, Inspection is likely to be attended on or before "+dateto_attend+" or next working day (In case the above date happens to be a holiday). Dates are subject to last minute changes due to  exigencies of work and overriding Client priorities. \n Name of Controlling Manager of concerned IE Sh.: "+ co_name +", Contact No."+co_mobile+". \nOffered Material as per registration should be readily available on the indicated date along with all related documents and internal test reports. \nFor Inspection related information please visit : http://ritesinsp.com. \n For any correspondence in future, please quote Case No. only. \n\n Thanks for using RITES Inspection Services. \n\n"+ wRegion +"." ;
				if (days_to_ic == 0)
				{
					mail_body = mail_body + "The inspection call has been assigned to Inspecting Engineer Sh. " + ie_name + ", Contact No. " + ie_phone + ", Email ID: " + ie_email + ". Based on the current workload with the IE, Inspection is likely to be attended on or before " + dateto_attend + " or next working day (In case the above date happens to be a holiday). Dates are subject to last minute changes due to  exigencies of work and overriding Client priorities. <br> Name of Controlling Manager of concerned IE Sh.: " + co_name + ", Contact No." + co_mobile + ". <br>Offered Material as per registration should be readily available on the indicated date along with all related documents and internal test reports.<br><a href='http://rites.ritesinsp.com/RBS/Guidelines for Vendors.pdf'>Guidelines for Vendors</a>.<br>For Inspection related information please visit : http://ritesinsp.com. <br> For any correspondence in future, please quote Case No. only.<br><br> Thanks for using RITES Inspection Services. <br><br>" + wRegion + ".";
				}
				else if (days_to_ic > 0)
				{
					System.DateTime w_dt1 = new System.DateTime(Convert.ToInt32(dateto_attend.Substring(6, 4)), Convert.ToInt32(dateto_attend.Substring(3, 2)), Convert.ToInt32(dateto_attend.Substring(0, 2)));
					System.DateTime w_dt2 = w_dt1.AddDays(days_to_ic);
					string date_to_ic = w_dt2.ToString("dd/MM/yyyy");
					mail_body = mail_body + "The inspection call has been assigned to Inspecting Engineer Sh. " + ie_name + ", Contact No. " + ie_phone + ", Email ID: " + ie_email + ". Based on the current workload with the IE, Inspection is likely to be attended on or before " + dateto_attend + " or next working day (In case the above date happens to be a holiday) and Inspection certificate is likely to issued by " + date_to_ic + ". Dates are subject to last minute changes due to  exigencies of work and overriding Client priorities. <br> Name of Controlling Manager of concerned IE Sh.: " + co_name + ", Contact No." + co_mobile + ". <br>Offered Material as per registration should be readily available on the indicated date along with all related documents and internal test reports. Inspection is proposed to be conducted as per inspection plan: <a href='http://rites.ritesinsp.com/RBS/MASTER_ITEMS_CHECKSHEETS/" + item_cd + ".RAR'>Inspection Plan</a>.<br><a href='http://rites.ritesinsp.com/RBS/Guidelines for Vendors.pdf'>Guidelines for Vendors</a>.<br>For Inspection related information please visit : http://ritesinsp.com. <br> For any correspondence in future, please quote Case No. only. <br><br> Thanks for using RITES Inspection Services. <br> NATIONAL INSPECTION HELP LINE NUMBER : 1800 425 7000 (TOLL FREE).<br><br>" + wRegion + ".";
				}

				mail_body = mail_body + "<br><br> THIS IS AN AUTO GENERATED EMAIL. PLEASE DO NOT REPLY. USE EMAIL GIVEN IN THE REGION ADDRESS.";
				if (Case_Region == "N")
				{
					sender = "nrinspn@rites.com";
				}
				else if (Case_Region == "W")
				{
					sender = "wrinspn@rites.com";
				}
				else if (Case_Region == "E")
				{
					sender = "erinspn@rites.com";
				}
				else if (Case_Region == "S")
				{
					sender = "srinspn@rites.com";
				}
				else if (Case_Region == "C")
				{
					sender = "crinspn@rites.com";
				}


				if (vend_cd == mfg_cd && manu_mail != "")
				{
					MailMessage mail = new MailMessage();
					mail.To = manu_mail;
					mail.Bcc = "nrinspn@gmail.com";
					//mail.From = sender;
					mail.From = "nrinspn@gmail.com";
					mail.Subject = "Your Call for Inspection By RITES";
					mail.BodyFormat = MailFormat.Html;
					mail.Body = mail_body;
					mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
																												//					SmtpMail.SmtpServer= "127.0.0.1";  //your real server goes here
					SmtpMail.SmtpServer = "10.60.50.81";  //your real server goes here
					mail.Priority = MailPriority.High;
					SmtpMail.Send(mail);
				}
				else if (vend_cd != mfg_cd && vend_email != "" && manu_mail != "")
				{

					MailMessage mail = new MailMessage();
					mail.To = vend_email + ";" + manu_mail;
					mail.Bcc = "nrinspn@gmail.com";
					//mail.From = sender;
					mail.From = "nrinspn@gmail.com";
					mail.Subject = "Your Call for Inspection By RITES";
					mail.BodyFormat = MailFormat.Html;
					mail.Body = mail_body;
					mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
																												//						SmtpMail.SmtpServer= "127.0.0.1";  //your real server goes here
					SmtpMail.SmtpServer = "10.60.50.81";  //your real server goes here
					mail.Priority = MailPriority.High;
					SmtpMail.Send(mail);

				}
				else if (vend_cd != mfg_cd && (vend_email == "" || manu_mail == ""))
				{

					MailMessage mail = new MailMessage();
					if (vend_email == "")
					{
						mail.To = manu_mail;
					}
					else if (manu_mail == "")
					{
						mail.To = vend_email;
					}
					mail.Bcc = "nrinspn@gmail.com";
					//mail.From = sender;
					mail.From = "nrinspn@gmail.com";
					mail.Subject = "Your Call for Inspection By RITES";
					mail.BodyFormat = MailFormat.Html;
					mail.Body = mail_body;
					mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
																												//					SmtpMail.SmtpServer= "127.0.0.1";  //your real server goes here
					SmtpMail.SmtpServer = "10.60.50.81";  //your real server goes here
					mail.Priority = MailPriority.High;
					SmtpMail.Send(mail);

				}

				OracleCommand cmd2 = new OracleCommand("Select CO_EMAIL from T08_IE_CONTROLL_OFFICER T08, T09_IE T09 where T09.IE_CO_CD=T08.CO_CD and IE_CD=" + ie_cd, conn1);
				conn1.Open();
				string controlling_email = Convert.ToString(cmd2.ExecuteScalar());
				conn1.Close();

				OracleCommand cmd_manu = new OracleCommand("Select T05.VEND_NAME,T03.CITY VEND_ADDRESS from T17_CALL_REGISTER T17,T05_VENDOR T05, T03_CITY T03 where T17.MFG_CD=T05.VEND_CD and T05.VEND_CITY_CD=T03.CITY_CD and CASE_NO='" + txtCaseNo.Text.Trim() + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + Label29.Text, conn1);
				conn1.Open();
				OracleDataReader readerm = cmd_manu.ExecuteReader();
				string manu_name = "", manu_add = "";
				while (readerm.Read())
				{
					manu_name = Convert.ToString(readerm["VEND_NAME"]);
					manu_add = Convert.ToString(readerm["VEND_ADDRESS"]);
				}
				conn1.Close();

				if (controlling_email != "")
				{
                    System.Web.Mail.MailMessage mail2 = new System.Web.Mail.MailMessage();
					mail2.To = controlling_email;
					mail2.Bcc = "nrinspn@gmail.com";
					if (ie_email != "")
					{
						mail2.Cc = ie_email;
					}
					//mail2.Bcc = "nrinspn@gmail.com";
					//mail2.From=sender;
					mail2.From = "nrinspn@gmail.com";
					mail2.Subject = "Your Call (" + manu_name + " - " + manu_add + ") for Inspection By RITES";
					mail2.BodyFormat = MailFormat.Html;
					mail2.Body = mail_body;
					mail2.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");   //basic authentication
																												//					SmtpMail.SmtpServer= "127.0.0.1";  //your real server goes here
					SmtpMail.SmtpServer = "10.60.50.81";  //your real server goes here
					mail2.Priority = System.Web.Mail.MailPriority.High;
					SmtpMail.Send(mail2);
				}

			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				//				Response.Write(ex);
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}


		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			//			OracleCommand cmdcall=new OracleCommand("select nvl(count(CASE_NO),0) from T20_IC where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy') AND CALL_SNO="+Label29.Text,conn1);
			//			conn1.Open();
			//			int delstatus=Convert.ToInt16(cmdcall.ExecuteScalar());
			//			conn1.Close();
			conn1.Open();
			OracleTransaction myTrans = conn1.BeginTransaction();

			try
			{


				//				if(delstatus==0)
				//				{
				//				string myDeleteQuery4 = "Delete T21_IC_DATES where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy')"; 
				//				OracleCommand myOracleCommand4 = new OracleCommand(myDeleteQuery4); 
				//				myOracleCommand4.Transaction=myTrans;
				//				myOracleCommand4.Connection = conn1; 
				//				myOracleCommand4.ExecuteNonQuery(); 

				//					string myDeleteQuery3 = "Delete T20_IC where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy')"; 
				//					OracleCommand myOracleCommand3 = new OracleCommand(myDeleteQuery3); 
				//					myOracleCommand3.Transaction=myTrans;
				//					myOracleCommand3.Connection = conn1; 
				//					myOracleCommand3.ExecuteNonQuery(); 
				//							
				//					string myDeleteQuery2 = "Delete T19_CALL_CANCEL where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy') AND CALL_SNO="+Label29.Text; 
				//					OracleCommand myOracleCommand2 = new OracleCommand(myDeleteQuery2); 
				//					myOracleCommand2.Transaction=myTrans;
				//					myOracleCommand2.Connection = conn1; 
				//					myOracleCommand2.ExecuteNonQuery(); 
				//				
				//
				//					string myDeleteQuery1 = "Delete T18_CALL_DETAILS where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('"+ DT +"','dd/mm/yyyy') AND CALL_SNO="+Label29.Text; 
				//					OracleCommand myOracleCommand1 = new OracleCommand(myDeleteQuery1); 
				//					myOracleCommand1.Transaction=myTrans;
				//					myOracleCommand1.Connection = conn1; 
				//					myOracleCommand1.ExecuteNonQuery(); 

				string myDeleteQuery = "Delete T17_CALL_REGISTER where CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') AND CALL_SNO=" + Label29.Text;
				OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
				myOracleCommand.Transaction = myTrans;
				myOracleCommand.Connection = conn1;
				myOracleCommand.ExecuteNonQuery();

				myTrans.Commit();

				conn1.Close();
				DisplayAlert("Your Record Has Been Deleted!!!");
				//				}
				//				else
				//				{
				//					DisplayAlert("This Call cannot be deleted. because IC is present for this call!!!");
				//				}

				//string popupScript = "<script language='javascript'>" + "window.open('PopUp.aspx?str=Your Record Has Been Deleted!!!', 'CustomPopUp', " + "'width=330, height=100, menubar=no, resizable=no')" + "</script>";
				//Page.RegisterStartupScript("PopupScript", popupScript);


			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				myTrans.Rollback();
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Vendor_Call_Register_Edit.aspx");
		}

		private void DisplayAlert(string msg)
		{
			Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
		}

		private void DisplayAlert1(string msg)
		{
			msg = msg + " Do You Still Want to Register This Call?";
			Response.Write("<script language=JavaScript> var d=confirm('" + msg + "'); if(d==false) location.href='/RBS/Vendor/Vendor_Call_Register_Edit.aspx';</script>");
		}


		private void btnCDetails_Click(object sender, System.EventArgs e)
		{
			string code = txtCaseNo.Text;
			string dt = txtDtOfReciept.Text;
			string cs = Label29.Text;
			if (btnSave.Enabled == true || btnDelete.Enabled == true)
			{
				status = "M";
			}
			else
			{
				status = "N";
			}
			Response.Redirect("Vendor_Call_Details_Form.aspx?Case_No=" + code + "&DT_RECIEPT=" + dt + "&CALL_SNO=" + cs + "&cstatus=" + status);
		}

		int fill_manufacturer(string str1)
		{
			ddlManufac.Items.Clear();
			DataSet dsP = new DataSet();
			//string str1 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME,VEND_ADD1,VEND_CONTACT_PER_1,VEND_CONTACT_TEL_1 from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and (trim(upper(VEND_CD))=upper('"+vend.Trim()+"') or trim(upper(VEND_NAME)) LIKE upper('"+vend.Trim()+"%')) and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME"; 
			OracleDataAdapter da = new OracleDataAdapter(str1, conn1);
			OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
			ListItem lst;
			da.SelectCommand = myOracleCommand;
			da.Fill(dsP, "Table");
			if (dsP.Tables[0].Rows.Count == 0)
			{
				ecode = 1;
				return (ecode);
				//DisplayAlert("Invalid Search Data");
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
				//rbs.SetFocus(ddlManufac);
				ecode = 2;
				return (ecode);

			}

		}

		private void btnFCList_Click(object sender, System.EventArgs e)
		{
			ddlManufac.Visible = true;
			ddlManufac.Enabled = true;
			try
			{
				if (Convert.ToInt32(txtMName.Text) >= 1 && Convert.ToInt32(txtMName.Text) <= 999999)
				{

					string str1 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(VEND_CD)=" + txtMName.Text.Trim() + " and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
					int a = fill_manufacturer(str1);
					if (a == 1)
					{
						ddlManufac.Visible = false;
						txtMPOI.Text = "";
						txtMConPer.Text = "";
						txtMPNo.Text = "";
						txtMEmail.Text = "";
						btnUManuf.Enabled = false;
						DisplayAlert("No Manufacturer Found!!!");
						rbs.SetFocus(txtMPOI);
					}
					else if (a == 2)
					{
						txtMName.Text = ddlManufac.SelectedValue;
						manufac_details();
						rbs.SetFocus(ddlManufac);

					}
				}
				else
				{
					DisplayAlert("Invalid Manufacturer Code!!!");
					ddlManufac.Items.Clear();
					ddlManufac.Visible = false;
					txtMPOI.Text = "";
					txtMConPer.Text = "";
					txtMEmail.Text = "";
					txtMPNo.Text = "";
					btnUManuf.Enabled = false;


				}



			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = "Input string was not in a correct format.";
				if (str.Equals(str1))
				{
					string str2 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(upper(VEND_NAME)) LIKE upper('" + txtMName.Text.Trim() + "%') and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
					int a = fill_manufacturer(str2);
					if (a == 1)
					{
						ddlManufac.Visible = false;
						txtMPOI.Text = "";
						txtMConPer.Text = "";
						txtMPNo.Text = "";
						txtMEmail.Text = "";
						btnUManuf.Enabled = false;
						DisplayAlert("No Manufacturer Found!!!");
						rbs.SetFocus(txtMPOI);
					}
					else if (a == 2)
					{
						txtMName.Text = ddlManufac.SelectedValue;
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
				conn1.Close();
				conn1.Dispose();
			}
		}

		private void ddlManufac_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtMName.Text = ddlManufac.SelectedValue;
			manufac_details();
			txtMPOI.Enabled = false;
			rbs.SetFocus(txtMConPer);
		}


		void manufac_details()
		{

			OracleCommand cmd = new OracleCommand("select VEND_ADD1,VEND_CONTACT_PER_1,VEND_CONTACT_TEL_1,VEND_STATUS,to_char(VEND_STATUS_DT_FR,'dd/mm/yyyy')VEND_STATUS_FR,to_char(VEND_STATUS_DT_TO,'dd/mm/yyyy')VEND_STATUS_TO,VEND_EMAIL from T05_VENDOR where VEND_CD=" + ddlManufac.SelectedValue, conn1);
			conn1.Open();
			OracleDataReader reader = cmd.ExecuteReader();
			if (reader.HasRows == true)
			{
				while (reader.Read())
				{
					if (Convert.ToString(reader["VEND_STATUS"]) == "B")
					{
						DisplayAlert("Due to some unavoidable reasons, registration of your call is restricted till further notice against your ID From: " + Convert.ToString(reader["VEND_STATUS_FR"]) + ". Please contact concerned Regional office for details");
						txtMName.Text = "";
						ddlManufac.Visible = false;
						txtMPOI.Text = "";
						txtMConPer.Text = "";
						txtMPNo.Text = "";
						txtMEmail.Text = "";
						btnUManuf.Enabled = false;
					}
					else
					{
						txtMPOI.Text = Convert.ToString(reader["VEND_ADD1"]);
						txtMConPer.Text = Convert.ToString(reader["VEND_CONTACT_PER_1"]);
						txtMPNo.Text = Convert.ToString(reader["VEND_CONTACT_TEL_1"]);
						txtMEmail.Text = Convert.ToString(reader["VEND_EMAIL"]);
						btnUManuf.Enabled = true;
						txtMPOI.Enabled = false;
					}

				}
			}
			else
			{
				txtMPOI.Text = "";
				txtMConPer.Text = "";
				txtMPNo.Text = "";
				txtMEmail.Text = "";
				btnUManuf.Enabled = false;
			}
			conn1.Close();
			//conn1.Dispose();
		}

		private void btnUManuf_Click(object sender, System.EventArgs e)
		{
			OracleCommand cmd = new OracleCommand("update T05_VENDOR set VEND_CONTACT_PER_1='" + txtMConPer.Text + "',VEND_CONTACT_TEL_1='" + txtMPNo.Text + "',VEND_EMAIL='" + txtMEmail.Text.Trim() + "' where VEND_CD=" + txtMName.Text, conn1);
			conn1.Open();
			cmd.ExecuteNonQuery();
			DisplayAlert("This Manufacturer details has been updated!!!");
			conn1.Close();
			conn1.Dispose();
		}

		private void chkManuf_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chkManuf.Checked == true)
			{
				try
				{
					OracleCommand cmd = new OracleCommand("select T13.VEND_CD from T13_PO_MASTER T13, T05_VENDOR T05 where T13.VEND_CD=T05.VEND_CD and CASE_NO='" + Label27.Text.Trim() + "'", conn1);
					conn1.Open();
					int vcode = Convert.ToInt32(cmd.ExecuteScalar());
					conn1.Close();

					if (Convert.ToInt32(vcode) >= 1 && Convert.ToInt32(vcode) <= 999999)
					{

						string str1 = "select VEND_CD,(trim(V.VEND_NAME)||'/'||trim(V.VEND_ADD1)||'/'||NVL2(C.LOCATION,C.LOCATION||' / '||C.CITY,C.CITY)) VEND_NAME from T05_VENDOR V, T03_CITY C where VEND_NAME is not null and trim(VEND_CD)=" + vcode + " and V.VEND_CITY_CD=C.CITY_CD ORDER BY VEND_NAME";
						int a = fill_manufacturer(str1);
						if (a == 1)
						{
							ddlManufac.Visible = false;
							txtMPOI.Text = "";
							txtMConPer.Text = "";
							txtMPNo.Text = "";
							txtMEmail.Text = "";
							btnUManuf.Enabled = false;
							DisplayAlert("No Manufacturer Found!!!");
							rbs.SetFocus(txtMPOI);
						}
						else if (a == 2)
						{
							txtMName.Text = ddlManufac.SelectedValue;
							manufac_details();
							rbs.SetFocus(ddlManufac);
							txtMPOI.Enabled = false;
						}
					}
					else
					{
						DisplayAlert("Invalid Manufacturer Code!!!");
						ddlManufac.Items.Clear();
						ddlManufac.Visible = false;
						txtMPOI.Text = "";
						txtMConPer.Text = "";
						txtMPNo.Text = "";
						txtMEmail.Text = "";
						btnUManuf.Enabled = false;


					}
					txtMName.Enabled = false;
					ddlManufac.Enabled = false;
					btnFCList.Visible = false;



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
			else
			{
				btnFCList.Visible = true;
				txtMName.Enabled = true;
				txtMName.Text = "";
				ddlManufac.Items.Clear();
				ddlManufac.Visible = false;
				txtMPOI.Text = "";
				txtMConPer.Text = "";
				txtMPNo.Text = "";
				txtMEmail.Text = "";
				btnUManuf.Enabled = false;

			}
		}

		private void grdCDetails_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				if (Convert.ToString(e.Item.Cells[3].Text) != "Available")
				{
					decimal isrno = Convert.ToDecimal(e.Item.Cells[2].Text);
					string myDeleteQuery = "Delete T18_CALL_DETAILS where CASE_NO= '" + txtCaseNo.Text + "' and CALL_RECV_DT=to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy') AND CALL_SNO=" + Label29.Text + " and ITEM_SRNO_PO=" + isrno;
					OracleCommand myOracleCommand = new OracleCommand(myDeleteQuery);
					myOracleCommand.Connection = conn1;
					conn1.Open();
					myOracleCommand.ExecuteNonQuery();
					conn1.Close();
					DisplayAlert("Your Item is UnMarked!!!");
				}
				else
				{
					DisplayAlert("Your Item is Already Available!!!");

				}

			}

			catch (Exception ex)
			{
				string str;
				str = ex.Message;
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}
			show();
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			string popupScript = "<script language='javascript'>" + "window.open('../Print_Call_letter.aspx?CASE_NO=" + Label27.Text + "&CALL_DT=" + Label28.Text + "&CALL_SNO=" + Label29.Text + "','CustomPopUp','fullscreen=no, scrollbars=yes' ," + "'width=700, height=800, menubar=no, resizable=no,alwaysRaised=true')" + "</script>";
			Page.RegisterStartupScript("PopupScript", popupScript);
			//			Response.Write("<script language=JavaScript>var oWin= window.open('../Print_Call_letter.aspx?CASE_NO="+Label27.Text+"&CALL_DT="+Label28.Text+"&CALL_SNO="+Label29.Text+"','', 'fullscreen=no, scrollbars=yes');");
			//			Response.Write("if (oWin==null || typeof(oWin)=='undefined') alert('System has been blocked by POP-UP BLOCKER!!!\\nPlease disable the POP-UP BLOCKER and try again or Please contact your system administrator.');</script>");
			//			Response.Write("<script language='Javascript'>window.opener='x';window.close();</script>");
			//						Response.Redirect("../Print_Call_letter.aspx?CASE_NO="+Label27.Text+"&CALL_DT="+Label28.Text+"&CALL_SNO="+Label29.Text);
		}
		int check_desire_dt(string ext_delv_dt)
		{
			//			conn1.Open();
			//			OracleCommand cmd22 =new OracleCommand("Select NVL(to_char(max(EXT_DELV_DT),'dd/mm/yyyy'),'01-JAN-01') EXT_DELV_DT from T15_PO_DETAIL where CASE_NO='"+CNO+"'",conn1);
			//			OracleDataReader or2 = cmd22.ExecuteReader();
			//			string ext_delv_dt="";
			//			while (or2.Read())
			//			{
			//				
			//				ext_delv_dt=or2["EXT_DELV_DT"].ToString();
			//			}
			//			conn1.Close();
			if (ext_delv_dt == "01-JAN-01")
			{
				return (2);
			}
			else
			{
				System.DateTime w_dt1 = new System.DateTime(Convert.ToInt32(ext_delv_dt.Substring(6, 4)), Convert.ToInt32(ext_delv_dt.Substring(3, 2)), Convert.ToInt32(ext_delv_dt.Substring(0, 2)));
				System.DateTime w_dt2 = new System.DateTime(Convert.ToInt32(txtExpOfIns.Text.Substring(6, 4)), Convert.ToInt32(txtExpOfIns.Text.Substring(3, 2)), Convert.ToInt32(txtExpOfIns.Text.Substring(0, 2)));
				TimeSpan ts = w_dt1 - w_dt2;
				int differenceInDays = ts.Days;
				if (differenceInDays < 5)
				{
					return (1);
				}
				else
				{
					return (0);
				}
			}

		}

		int check_desire_dt2()
		{

			System.DateTime w_dt1 = new System.DateTime(Convert.ToInt32(Label28.Text.Substring(6, 4)), Convert.ToInt32(Label28.Text.Substring(3, 2)), Convert.ToInt32(Label28.Text.Substring(0, 2)));
			System.DateTime w_dt2 = new System.DateTime(Convert.ToInt32(txtExpOfIns.Text.Substring(6, 4)), Convert.ToInt32(txtExpOfIns.Text.Substring(3, 2)), Convert.ToInt32(txtExpOfIns.Text.Substring(0, 2)));
			TimeSpan ts = w_dt2 - w_dt1;
			int differenceInDays = ts.Days;
			if (differenceInDays > 5)
			{
				return (1);
			}
			else
			{
				return (0);
			}

		}
		public void save_call()
		{
			int callval = 0;
			int e_status = 0;
			string IE_name = null;
			int ie_officer_code = 0;
			string automaticCallMarked = null;
			//string ICF_CODE;
			//int con_check=0;
			//ICF_CODE=PO_CODE_ICF(Label25.Text.Trim());
			try
			{

				if (ddlManufac.Visible == false)
				{
					DisplayAlert("Plz select Manufacturer first and then save it");
				}
				else if (rdbIYes.Checked == true && rdbVYes.Checked == true && (txtVendAppFrom.Text.Trim() == "" || txtVendAppFrom.Text.Trim() == ""))
				{
					DisplayAlert("Plz Enter Vendor Approval [From] & [To] Date");
				}
				else if (rdbSYes.Checked == true && (txtLotDP1.Text.Trim() == "" && txtLotDP1.Text.Trim() == ""))
				{
					DisplayAlert("Plz Enter Lot Size & DP");
				}
				else if (CheckBox1.Checked == false)
				{
					DisplayAlert("Kindly [Select or Check] the declaration before you click on Register Call button.");
				}
				else if (Dropdownlist1.SelectedIndex == 0)
				{
					DisplayAlert("Please Select item to be inspected viz. Mechanical, Electrical, Civil etc.");
				}
				else
				{
					conn1.Open();
					OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn1);
					ss = Convert.ToString(cmd2.ExecuteScalar());
					conn1.Close();
					if (Action == "A")
					{
						conn1.Open();

						OracleCommand cmdCL = new OracleCommand("Select NVL(count(*),0) COUNT from T17_CALL_REGISTER where CASE_NO= '" + Label27.Text.Trim() + "' and CALL_LETTER_NO=trim(upper('" + txtCallNO.Text + "')) and REGION_CODE='" + CNO.Substring(0, 1) + "'", conn1);
						int CL = Convert.ToInt32(cmdCL.ExecuteScalar());
						conn1.Close();

						if (CL == 0)
						{
							conn1.Open();
							OracleTransaction myTrans = null;
							try
							{

								string str3 = "select NVL(max(CALL_SNO),0)CALL_SNO from T17_CALL_REGISTER where CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') and REGION_CODE='" + CNO.Substring(0, 1) + "'";
								OracleCommand myCommand = new OracleCommand();
								myCommand.CommandText = str3;
								//myCommand.Transaction=myTrans;
								myCommand.Connection = conn1;
								CD = Convert.ToInt32(myCommand.ExecuteScalar());
								CD = (CD + 1);

								//							if(txtCInstallNo.Text=="")
								//							{
								//								txtCInstallNo.Text="null";
								//							}
								string w_item_rdso = "";
								string w_vend_rdso = "";
								string w_stag = "";
								string w_stage_or_final = "";

								if (rdbIYes.Checked == true)
								{
									w_item_rdso = "Y";
									if (rdbVYes.Checked == true)
									{
										w_vend_rdso = "Y";
									}
									else if (rdbVNo.Checked == true)
									{
										w_vend_rdso = "N";
									}
								}
								else if (rdbINo.Checked == true)
								{
									w_item_rdso = "N";
									w_vend_rdso = "";
								}




								if (rdbSYes.Checked == true)
								{
									w_stag = "Y";
								}
								else
								{
									w_stag = "N";
								}

								if (wFOS == "S")
								{
									w_stage_or_final = "S";
								}
								else
								{
									w_stage_or_final = "F";
								}

								string w_New_Vendor = "";
								if (chkNewVendor.Checked == true)
								{
									w_New_Vendor = "Y";
								}

								callval = FindIeCODE();
								//int callval=0;


								conn1.Close();
								// find Ie/Alt_ie name here.....developer--swadhin sahoo
								if (callval == 0)
								{
									//DisplayAlert("Master data not entered.So please enter master data cluster/vender/ie");
								}
								else
								{
									string Command131 = "select IE_NAME,IE_CO_CD from T09_ie where IE_CD=" + callval + "";
									OracleCommand Comm131 = new OracleCommand(Command131, conn1);
									OracleDataAdapter da = new OracleDataAdapter(Comm131);
									DataSet ds = new DataSet();
									//conn1.Close();
									conn1.Open();
									da.Fill(ds);
									String Isname = ds.Tables[0].Rows[0]["IE_NAME"].ToString();
									int ieofficercode = Convert.ToInt32(ds.Tables[0].Rows[0]["IE_CO_CD"]);
									IE_name = Isname;
									ie_officer_code = ieofficercode;
									conn1.Close();
									automaticCallMarked = "Y";



								}
								conn1.Open();
								string w_irfc_funded = "";
								if (lblRLY_NONRly.Text == "R")
								{
									w_irfc_funded = ddlIRFC.SelectedValue.ToString();
								}
								else
								{
									w_irfc_funded = "N";
								}

								myTrans = conn1.BeginTransaction();
								if (callval == 0)
								{
									string myInsertQuery = "INSERT INTO T17_CALL_REGISTER(CASE_NO, CALL_RECV_DT, CALL_SNO, CALL_LETTER_NO, CALL_LETTER_DT,CALL_MARK_DT, DEPARTMENT_CODE,DT_INSP_DESIRE, CALL_STATUS, CALL_STATUS_DT, CALL_REMARK_STATUS,CALL_INSTALL_NO, REGION_CODE, MFG_CD, USER_ID, DATETIME,MFG_PLACE,REMARKS,ONLINE_CALL,ITEM_RDSO,VEND_RDSO,VEND_APPROVAL_FR,VEND_APPROVAL_TO,STAGGERED_DP,LOT_DP_1,LOT_DP_2,FINAL_OR_STAGE,BPO,RECIPIENT_GSTIN_NO,NEW_VENDOR,IRFC_FUNDED) values('" + txtCaseNo.Text.Trim() + "', to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy')," + CD + ",trim(upper('" + txtCallNO.Text + "')),to_date('" + txtCallDt.Text + "','dd/mm/yyyy'),to_date('" + txtDtMark.Text + "','dd/mm/yyyy'),'" + Dropdownlist1.SelectedItem.Value + "',to_date('" + txtExpOfIns.Text + "','dd/mm/yyyy') ,'M',to_date('" + txtDtOfCan.Text + "','dd/mm/yyyy'),'" + lstCallRStatus.SelectedValue + "','" + txtCInstallNo.Text + "',upper('" + txtCaseNo.Text.Substring(0, 1) + "'),'" + ddlManufac.SelectedValue + "','" + Session["VEND_CD"] + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),'" + txtMPOI.Text + "','" + txtRemarks.Text + "','Y','" + w_item_rdso + "','" + w_vend_rdso + "',to_date('" + txtVendAppFrom.Text.Trim() + "','dd/mm/yyyy-HH24:MI:SS'),to_date('" + txtVendAppTo.Text.Trim() + "','dd/mm/yyyy-HH24:MI:SS'),'" + w_stag + "','" + txtLotDP1.Text.Trim() + "','" + txtLotDP2.Text.Trim() + "','" + w_stage_or_final + "', '" + txtBPO.Text.Trim() + "','" + txtGSTINNo.Text.Trim() + "','" + w_New_Vendor + "','" + w_irfc_funded + "')";
									OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
									myInsertCommand.Transaction = myTrans;
									myInsertCommand.Connection = conn1;
									myInsertCommand.ExecuteNonQuery();
								}
								else
								{
									string myInsertQuery = "INSERT INTO T17_CALL_REGISTER(CASE_NO, CALL_RECV_DT, CALL_SNO, CALL_LETTER_NO, CALL_LETTER_DT,CALL_MARK_DT, IE_CD,CO_CD,AUTOMATIC_CALL,DEPARTMENT_CODE,DT_INSP_DESIRE, CALL_STATUS, CALL_STATUS_DT, CALL_REMARK_STATUS,CALL_INSTALL_NO, REGION_CODE, MFG_CD, USER_ID, DATETIME,MFG_PLACE,REMARKS,ONLINE_CALL,ITEM_RDSO,VEND_RDSO,VEND_APPROVAL_FR,VEND_APPROVAL_TO,STAGGERED_DP,LOT_DP_1,LOT_DP_2,FINAL_OR_STAGE,BPO,RECIPIENT_GSTIN_NO,NEW_VENDOR,IRFC_FUNDED,CLUSTER_CODE) values('" + txtCaseNo.Text.Trim() + "', to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy')," + CD + ",trim(upper('" + txtCallNO.Text + "')),to_date('" + txtCallDt.Text + "','dd/mm/yyyy'),to_date('" + txtDtMark.Text + "','dd/mm/yyyy')," + callval + "," + ie_officer_code + ",'" + automaticCallMarked + "','" + Dropdownlist1.SelectedItem.Value + "',to_date('" + txtExpOfIns.Text + "','dd/mm/yyyy') ,'M',to_date('" + txtDtOfCan.Text + "','dd/mm/yyyy'),'" + lstCallRStatus.SelectedValue + "','" + txtCInstallNo.Text + "',upper('" + txtCaseNo.Text.Substring(0, 1) + "'),'" + ddlManufac.SelectedValue + "','" + Session["VEND_CD"] + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),'" + txtMPOI.Text + "','" + txtRemarks.Text + "','Y','" + w_item_rdso + "','" + w_vend_rdso + "',to_date('" + txtVendAppFrom.Text.Trim() + "','dd/mm/yyyy-HH24:MI:SS'),to_date('" + txtVendAppTo.Text.Trim() + "','dd/mm/yyyy-HH24:MI:SS'),'" + w_stag + "','" + txtLotDP1.Text.Trim() + "','" + txtLotDP2.Text.Trim() + "','" + w_stage_or_final + "','" + txtBPO.Text.Trim() + "','" + txtGSTINNo.Text.Trim() + "','" + w_New_Vendor + "','" + w_irfc_funded + "'," + lblCluster_Cd.Text.ToString() + ")";
									OracleCommand myInsertCommand = new OracleCommand(myInsertQuery);
									myInsertCommand.Transaction = myTrans;
									myInsertCommand.Connection = conn1;
									//conn1.Open();
									myInsertCommand.ExecuteNonQuery();

								}

								//								string myInsertQuery = "INSERT INTO T17_CALL_REGISTER(CASE_NO, CALL_RECV_DT, CALL_SNO, CALL_LETTER_NO, CALL_LETTER_DT,CALL_MARK_DT, IE_CD, DT_INSP_DESIRE, CALL_STATUS, CALL_STATUS_DT, CALL_REMARK_STATUS,CALL_INSTALL_NO, REGION_CODE, MFG_CD, USER_ID, DATETIME,MFG_PLACE,REMARKS,ONLINE_CALL,ITEM_RDSO,VEND_RDSO,VEND_APPROVAL_FR,VEND_APPROVAL_TO,STAGGERED_DP,LOT_DP_1,LOT_DP_2) values('" + txtCaseNo.Text.Trim() + "', to_date('" + txtDtOfReciept.Text.Trim() + "','dd/mm/yyyy')," + CD + ",trim(upper('"+txtCallNO.Text+"')),to_date('" + txtCallDt.Text + "','dd/mm/yyyy'),to_date('" + txtDtMark.Text + "','dd/mm/yyyy'), null,to_date('" + txtExpOfIns.Text + "','dd/mm/yyyy') ,'M',to_date('" + txtDtOfCan.Text + "','dd/mm/yyyy'),'"+lstCallRStatus.SelectedValue+"','" + txtCInstallNo.Text + "',upper('" + txtCaseNo.Text.Substring(0,1) + "'),'" + ddlManufac.SelectedValue + "','"+Session["VEND_CD"]+"', to_date('" +ss+ "','dd/mm/yyyy-HH24:MI:SS'),'"+txtMPOI.Text+"','"+txtRemarks.Text+"','Y','"+w_item_rdso+"','"+w_vend_rdso+"',to_date('" +txtVendAppFrom.Text.Trim()+ "','dd/mm/yyyy-HH24:MI:SS'),to_date('" +txtVendAppTo.Text.Trim()+ "','dd/mm/yyyy-HH24:MI:SS'),'"+w_stag+"','"+txtLotDP1.Text.Trim()+"','"+txtLotDP2.Text.Trim()+"')"; 
								//								OracleCommand myInsertCommand = new OracleCommand(myInsertQuery); 
								//								myInsertCommand.Transaction=myTrans;
								//								myInsertCommand.Connection = conn1; 
								//								myInsertCommand.ExecuteNonQuery(); 


								Label29.Text = CD.ToString();

								decimal wMat_value = 0;
								string ext_delv_dt = "";
								int desire_dt = 0;

								foreach (DataGridItem di in grdCDetails_1.Items)
								{
									// Make sure this is an item and not the header or footer.

									decimal qty_off_now = 0;
									int err = 0;
									int srno = 0;
									if (di.ItemType == ListItemType.Item || di.ItemType == ListItemType.AlternatingItem)
									{

										qty_off_now = Convert.ToDecimal(((TextBox)di.FindControl("txtQTYOFFNOW_1")).Text);
										srno = Convert.ToInt16(di.Cells[0].Text);
										//					OracleCommand cmd =new OracleCommand("Select NVL(sum(NVL(D.QTY_PASSED,0)),0) from T17_CALL_REGISTER R,T18_CALL_DETAILS D where R.CASE_NO=D.CASE_NO and R.CALL_RECV_DT=D.CALL_RECV_DT and R.CALL_SNO=D.CALL_SNO and R.CASE_NO= '" + txtCaseNo.Text + "' AND D.ITEM_SRNO_PO=" + srno + " and R.CALL_STATUS not in('R','C') AND (D.ROWID!=(Select ROWID from T18_CALL_DETAILS g where g.CASE_NO='"+txtCaseNo.Text+"' and g.CALL_RECV_DT=to_date('"+txtDtOfReciept.Text+"','dd/mm/yyyy') and g.CALL_SNO="+lblCSNO.Text+" AND g.ITEM_SRNO_PO="+srno+"))",conn1);
										//					conn1.Open();
										//					decimal tpqty= Convert.ToDecimal(cmd.ExecuteScalar());
										//					conn1.Close();
										//					tpqty=tpqty+qty_pass;

										if (qty_off_now > 0)
										{
											err = 1;

										}

										if (err == 1)
										{
											string str = "Select CONSIGNEE_CD,QTY,VALUE, NVL(to_char(EXT_DELV_DT,'dd/mm/yyyy'),'01-JAN-01') EXT_DELV_DATE from T15_PO_DETAIL WHERE CASE_NO='" + txtCaseNo.Text + "' AND ITEM_SRNO=" + srno;
											OracleCommand cmd = new OracleCommand(str, conn1);
											cmd.Transaction = myTrans;
											OracleDataReader reader = cmd.ExecuteReader();
											long ccd = 0;
											while (reader.Read())
											{
												ccd = Convert.ToInt64(reader["CONSIGNEE_CD"]);
												wMat_value = wMat_value + (Convert.ToDecimal(reader["VALUE"]) / Convert.ToDecimal(reader["QTY"])) * qty_off_now;
												ext_delv_dt = Convert.ToString(reader["EXT_DELV_DATE"]);
											}

											//											if(ccd==3064 || ccd==159 || ccd==39 || ccd==7470)
											//											{
											//												con_check=1;
											//											}
											//											if(lblRly.Text=="ICF" && ICF_CODE!="03")
											//											{
											//												con_check=1;
											//											
											//											}
											//string myInsertQuery = "INSERT INTO T18_CALL_DETAILS values('" + txtCaseNo.Text + "', to_date('" + txtDtOfReciept.Text + "','dd/mm/yyyy')," + txtSerialNo.Text + ", '" + txtIDesc.Text  + "'," + txtQOrd.Text + "," + txtCQty.Text + "," + txtQPrePassed.Text + "," + txtQuanInsp.Text + ","+txtQPass.Text +","+txtQRej.Text +","+ txtQtyDue.Text +",'"+Session["Uname"]+"', to_date('" +ss+ "','dd/mm/yyyy-HH24:MI:SS'))"; 
											string myInsertQuery1 = "INSERT INTO T18_CALL_DETAILS values('" + txtCaseNo.Text + "', to_date('" + Label28.Text + "','dd/mm/yyyy')," + Label29.Text + "," + srno + ", upper('" + Convert.ToString(di.Cells[1].Text) + "')," + ccd + "," + Convert.ToDecimal(di.Cells[3].Text) + "," + Convert.ToDecimal(di.Cells[4].Text) + "," + Convert.ToDecimal(di.Cells[5].Text) + "," + qty_off_now + ",'" + null + "','" + null + "','" + null + "','" + Session["VEND_CD"] + "', to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'))";
											OracleCommand myInsertCommand1 = new OracleCommand(myInsertQuery1);
											myInsertCommand1.Transaction = myTrans;
											myInsertCommand1.Connection = conn1;
											myInsertCommand1.ExecuteNonQuery();

											if (desire_dt == 0)
											{
												desire_dt = check_desire_dt(ext_delv_dt);
											}

										}
										//										else 
										//										{
										//											DisplayAlert("Enter Quantity Offered Now For Inspection of atleast one Item to register the call.");
										//										}


									}

								}

								//if(wMat_value>150000 && desire_dt==0)  //As desired by GM/QA on 02-11-2018

								//if(desire_dt==0)

								//if((lblRLY_NONRly.Text=="R" && wMat_value>150000 && desire_dt==0) || (lblRLY_NONRly.Text!="R" && wMat_value>1000 && desire_dt==0))			  //As desired by GGM/I/NR on 12-11-2018
								//	if((lblRLY_NONRly.Text=="R" && wMat_value>1000 && desire_dt==0 && con_check==0)	 ||	(lblRLY_NONRly.Text!="R" && wMat_value>1000 && desire_dt==0 && txtBPO.Text.Trim()!="" && txtGSTINNo.Text.Trim()!="" && con_check==0))	  //As desired by ED/QA on 14-11-2018
								if ((lblRLY_NONRly.Text == "R" && wMat_value > 1000 && desire_dt == 0) || (lblRLY_NONRly.Text != "R" && wMat_value > 1000 && desire_dt == 0 && txtBPO.Text.Trim() != "" && txtGSTINNo.Text.Trim() != ""))
								{
									myTrans.Commit();
									conn1.Close();
									show_items();
									//send_Vendor_Email();
									btnSave.Enabled = false;
									grdCDetails.Columns[0].Visible = false;
									grdCDetails.Columns[1].Visible = false;
									Label48.Visible = true;
									File1.Visible = true;
									btnUpload.Visible = true;
									Label29.Visible = true;

									if (wMat_value < 5000000)
									{
										conn1.Open();
										OracleCommand cmd_cont_altie_cd = new OracleCommand("select NVL(CONT_ALT_IE,0) from T09_IE where IE_CD=" + lblClusterIE_CD.Text, conn1);
										int cont_alt_iecode = Convert.ToInt32(cmd_cont_altie_cd.ExecuteScalar());
										OracleCommand cmd_reg_max_limit = new OracleCommand("select MAXIMUM_CALL from T102_IE_mAXIMUM_CALL_LIMIT where region_code='" + CNO.Substring(0, 1).ToString() + "'", conn1);
										int reg_max_limit = Convert.ToInt32(cmd_reg_max_limit.ExecuteScalar());
										OracleCommand cmd_ie_pend_calls = new OracleCommand("SELECT count(a.call_status)call_status FROM t17_call_register a inner join T09_IE b on a.ie_cd =b.ie_cd where a.call_status in('M','S') and  a.ie_cd='" + cont_alt_iecode + "' and a.call_recv_dt>'01-APR-2022'", conn1);
										int ie_pend_calls = Convert.ToInt32(cmd_ie_pend_calls.ExecuteScalar());
										OracleCommand cmd_ie_call_marking = new OracleCommand("SELECT IE_CALL_MARKING  FROM T09_IE  where IE_CD='" + cont_alt_iecode + "'", conn1);
										string ie_call_marking = Convert.ToString(cmd_ie_call_marking.ExecuteScalar());
										conn1.Close();

										if (cont_alt_iecode != 0 && ie_pend_calls < reg_max_limit && ie_call_marking == "Y")
										{
											string cont_altie_name = "select IE_NAME, IE_CO_CD from T09_IE where IE_CD=" + cont_alt_iecode;
											OracleCommand cmd_cont_altie_name = new OracleCommand(cont_altie_name, conn1);
											OracleDataAdapter da_cont = new OracleDataAdapter(cmd_cont_altie_name);
											DataSet ds_cont = new DataSet();
											//conn1.Close();
											conn1.Open();
											da_cont.Fill(ds_cont);
											IE_name = ds_cont.Tables[0].Rows[0]["IE_NAME"].ToString();
											int cont_ieofficercode = Convert.ToInt32(ds_cont.Tables[0].Rows[0]["IE_CO_CD"]);



											//											OracleCommand cmd_cont_altie_name=new OracleCommand("select IE_NAME from T09_IE where IE_CD=" +cont_alt_iecode,conn1);
											//											conn1.Open();
											//											string cont_alt_iename=Convert.ToString(cmd_cont_altie_name.ExecuteScalar());
											//											IE_name=cont_alt_iename;

											string myUpdateQuery = "Update T17_CALL_REGISTER set IE_CD=" + cont_alt_iecode + ", CO_CD=" + cont_ieofficercode + " where (CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') and CALL_SNO=" + Label29.Text + ")";
											OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
											myUpdateCommand.Connection = conn1;
											myUpdateCommand.ExecuteNonQuery();

											conn1.Close();
											callval = cont_alt_iecode;
										}

									}


									if (callval == 0)
									{
										DisplayAlert("Your Call is Registered, Acknowledgement mail is sent on your registered email-id!!!");
									}
									else
									{
										DisplayAlert("Your Call is Registered, Acknowledgement mail is sent on your registered email-id!!!.Call Marked To:" + IE_name);
									}
									//DisplayAlert("Your Call is Registered, Acknowledgement mail is sent on your registered email-id!!!");
									e_status = 1;

								}
								else
								{
									myTrans.Rollback();
									conn1.Close();
									e_status = 0;
									//									if(lblRLY_NONRly.Text=="R" && wMat_value<150000)
									//									{
									//										DisplayAlert("Sorry, Your Call is not registered as offered material value is less than Rs 1.5 Lakhs!!!");
									//									}
									//									else 
									if (lblRLY_NONRly.Text != "R" && txtBPO.Text.Trim() == "" && txtGSTINNo.Text.Trim() == "")
									{
										DisplayAlert("Mention the Name, Address and GST No of the party in whose favour invoice is to be raised. It is mandatory in Case of Non Railways Calls!!!");
									}
									else if (wMat_value < 1000)
									{
										DisplayAlert("Sorry, Your Call is not registered as offered material value is less than Rs 1 Thousand!!!");
									}
									else if (desire_dt > 0)
									{
										DisplayAlert("Sorry, Your Call is not registered as Delivery Period is not mentioned or Desire Date should be atleast five(5) days before the expiry of the delivery period!!!");
									}
									//									else if (con_check>0)
									//									{
									//										DisplayAlert("As advised by ICF PCMM letter No. PCMM/ND/NOTES/20 Dated 12/09/2020, Stoppage of inspection of materials for supply to ICF other then for the purchase orders statring with first two digits as 03. So, Your Call is not registered !!!");
									//									}
								}
							}
							catch (Exception ex)
							{
								string str;
								str = ex.Message;
								myTrans.Rollback();
								e_status = 0;
								DisplayAlert("Your Record Has Not Been Saved, So Try Again!!!");
							}
							finally
							{
								conn1.Close();
								conn1.Dispose();
							}

							//							show();
							//btnSave.Enabled=false;

							//						string popupScript = "<script language='javascript'>" + "window.open('PopUp.aspx?str=Your Record Has Been Saved and Your Call Serial No is" + CD + "' , 'CustomPopUp', " + "'width=330, height=120, menubar=no, resizable=no')" + "</script>";
							//						Page.RegisterStartupScript("PopupScript", popupScript);
						}
						else
						{
							DisplayAlert("The Call Letter No. is already present for this Case No.");
						}

					}
					else if (Action == "M")
					{
						string Ucode = txtCaseNo.Text;
						//							if(txtCInstallNo.Text=="")
						//							{
						//								txtCInstallNo.Text="null";
						//							}
						string myUpdateQuery = "Update T17_CALL_REGISTER set CALL_LETTER_NO= trim(upper('" + txtCallNO.Text + "')),CALL_LETTER_DT=to_date('" + txtCallDt.Text + "','dd/mm/yyyy'),CALL_MARK_DT= to_date('" + txtDtMark.Text + "','dd/mm/yyyy'),CALL_SNO=" + Label29.Text + ",DT_INSP_DESIRE=to_date('" + txtExpOfIns.Text + "','dd/mm/yyyy'),CALL_STATUS_DT=to_date('" + txtDtOfCan.Text + "','dd/mm/yyyy'),CALL_REMARK_STATUS='" + lstCallRStatus.SelectedValue + "',CALL_INSTALL_NO='" + txtCInstallNo.Text + "',REMARKS='" + txtRemarks.Text + "',MFG_CD='" + ddlManufac.SelectedValue + "',MFG_PLACE='" + txtMPOI.Text + "',USER_ID='" + Session["VEND_CD"] + "', DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where (CASE_NO= '" + CNO + "' and CALL_RECV_DT=to_date('" + DT + "','dd/mm/yyyy') and CALL_SNO=" + Label29.Text + ")";
						OracleCommand myUpdateCommand = new OracleCommand(myUpdateQuery);
						myUpdateCommand.Connection = conn1;
						conn1.Open();
						myUpdateCommand.ExecuteNonQuery();
						CD = Convert.ToInt32(Label29.Text);
						conn1.Close();
						DisplayAlert("Your Record Has Been Saved!!!");

					}
					//						btnCDetails.Visible =true;
					//if(txtCallStatus.Text=="Accepted" || txtCallStatus.Text=="Rejected" ||txtCallStatus.Text=="Cancelled")
					if (lblCUpdateStatus.Text == "N")
					{
						//						btnSave.Enabled=false;
						//						btnDelete.Enabled=false;

					}
					else
					{
						//						btnSave.Enabled=true;
					}
				}

				if (e_status == 1 && callval != 0)
				{


					send_IE_sms(callval);
					send_Vendor_Email(callval);

				}
			}
			catch (OracleException ex)
			{
				string str;
				str = ex.Message;
				if (ex.ErrorCode == 00001)
				{
					DisplayAlert("This Call is already registered. so go back and use modify to update it");
				}
				else
				{
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
		private void btnRegCall_Click(object sender, System.EventArgs e)
		{

		}

		private void rdbIYes_CheckedChanged(object sender, System.EventArgs e)
		{
			item_rdso();
		}
		void item_rdso()
		{
			if (rdbINo.Checked == true)
			{
				rdbVNo.Visible = false;
				rdbVYes.Visible = false;
				Label40.Visible = false;
				txtVendAppFrom.Visible = false;
				txtVendAppTo.Visible = false;
				Label41.Visible = false;
				Label42.Visible = false;
			}
			else if (rdbIYes.Checked == true)
			{
				rdbVNo.Visible = true;
				rdbVYes.Visible = true;
				Label40.Visible = true;
				txtVendAppFrom.Visible = true;
				txtVendAppTo.Visible = true;
				Label41.Visible = true;
				Label42.Visible = true;
			}
		}
		private void rdbVYes_CheckedChanged(object sender, System.EventArgs e)
		{
			vendor_rdso();
		}
		void vendor_rdso()
		{
			if (rdbVNo.Checked == true)
			{

				txtVendAppFrom.Visible = false;
				txtVendAppTo.Visible = false;
				Label41.Visible = false;
				Label42.Visible = false;
			}
			else if (rdbVYes.Checked == true)
			{

				txtVendAppFrom.Visible = true;
				txtVendAppTo.Visible = true;
				Label41.Visible = true;
				Label42.Visible = true;
			}
		}
		//		private void CheckBox1_CheckedChanged(object sender, System.EventArgs e)
		//		{
		//			if(CheckBox1.Checked==true)
		//			{
		//				btnSave.Visible=true;
		//			}
		//			else
		//			{
		//				btnSave.Visible=false;
		//			}
		//		}

		private void rdbSYes_CheckedChanged(object sender, System.EventArgs e)
		{
			stag_dp();
		}

		void stag_dp()
		{
			if (rdbSYes.Checked == true)
			{
				Label44.Visible = true;
				Label45.Visible = true;
				Label46.Visible = true;
				txtLotDP1.Visible = true;
				txtLotDP2.Visible = true;
			}
			else
			{
				Label44.Visible = false;
				Label45.Visible = false;
				Label46.Visible = false;
				txtLotDP1.Visible = false;
				txtLotDP2.Visible = false;

			}

		}

		private void btnUpload_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (File1.PostedFile != null && File1.PostedFile.ContentLength > 0)
				{
					String fn = "", fx = "";
					fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
					fx = System.IO.Path.GetExtension(File1.PostedFile.FileName).ToUpper();
					if (fx == ".PDF")
					{
						string myYear1, myMonth1, myDay1;
						myYear1 = Label28.Text.Substring(6, 4);
						myMonth1 = Label28.Text.Substring(3, 2);
						myDay1 = Label28.Text.Substring(0, 2);
						string calldt = myYear1 + myMonth1 + myDay1;
						String SaveLocation = null;
						SaveLocation = Server.MapPath("CALLS_DOCUMENTS/" + Label27.Text + "-" + calldt + "-" + Label29.Text.Trim() + ".pdf");

						//SaveLocation = Server.MapPath("PO/" + fn);
						//SaveLocation = "//172.16.7.76/madan/"+fn;
						File1.PostedFile.SaveAs(SaveLocation);
						DisplayAlert("The file has been uploaded.");
					}
					else
					{ DisplayAlert("Only pdf files are accepted."); }
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





	}
}