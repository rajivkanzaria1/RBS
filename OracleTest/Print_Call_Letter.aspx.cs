using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Print_Call_Letter
{
	public partial class Print_Call_Letter : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

		string CNO, CDT;
		int CSNO;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (Request.Params["CASE_NO"] != null || Request.Params["CASE_NO"] != "")
			{
				CNO = Convert.ToString(Request.Params["CASE_NO"].Trim());
				CDT = Convert.ToString(Request.Params["CALL_DT"].Trim());
				CSNO = Convert.ToInt16(Request.Params["CALL_SNO"].Trim());
			}


			conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				DataSet dsP = new DataSet();
				string str3 = "select P.PO_NO,to_char(P.PO_DT,'dd/mm/yyyy') PO_DT, trim(M.VEND_NAME)MFG_NAME,trim(M.VEND_ADD1)||'/'||NVL2(CM.LOCATION,CM.LOCATION||' / '||CM.CITY,CM.CITY) MFG_ADD,(P.PURCHASER_CD||'-'||PU.CONSIGNEE)PURCHASER,(T18.CONSIGNEE_CD||'-'||CN.CONSIGNEE)CONSIGNEE,T17.CASE_NO, to_char(T17.CALL_RECV_DT,'dd/mm/yyyy')CALL_RECV_DATE, T17.CALL_SNO,T17.CALL_LETTER_NO, to_char(T17.CALL_LETTER_DT,'dd/mm/yyyy')CALL_LETTER_DT,T17.CALL_INSTALL_NO,nvl(T17.ONLINE_CALL,'X') ONLINE_CALL,nvl(T17.FINAL_OR_STAGE,'X') FINAL_OR_STAGE,T17.REMARKS,DECODE(T17.ITEM_RDSO,'Y','Yes','N','No','') ITEM_RDSO,DECODE(T17.VEND_RDSO,'Y','Yes','N','No','') VEND_RDSO,to_char(T17.VEND_APPROVAL_FR,'dd/mm/yyyy')VEND_APP_FR,to_char(T17.VEND_APPROVAL_TO,'dd/mm/yyyy')VEND_APP_TO,decode(STAGGERED_DP,'Y','YES','N','NO','N.A')STAG_DP,LOT_DP_1,LOT_DP_2, T09.IE_NAME, T18.ITEM_DESC_PO,T18.QTY_ORDERED,T18.QTY_TO_INSP,NVL(T18.CUM_QTY_PREV_OFFERED,'0')CUM_QTY_PREV_OFFERED,NVL(T18.CUM_QTY_PREV_PASSED,'0')CUM_QTY_PREV_PASSED, M.VEND_CONTACT_PER_1, M.VEND_CONTACT_TEL_1,M.VEND_EMAIL,V12.BPO, to_char(T15.EXT_DELV_DT,'dd/mm/yyyy') DELV_DT, T15.ITEM_CD,IRFC_FUNDED  from T05_VENDOR M, T03_CITY CM,T13_PO_MASTER P,T17_CALL_REGISTER T17,T18_CALL_DETAILS T18, V06_CONSIGNEE CN,V06_CONSIGNEE PU, V12_BILL_PAYING_OFFICER V12, T14_PO_BPO T14, T15_PO_DETAIL T15,T09_IE T09  where P.CASE_NO=T17.CASE_NO and T17.MFG_CD=M.VEND_CD and M.VEND_CITY_CD=CM.CITY_CD and P.PURCHASER_CD=PU.CONSIGNEE_CD and T18.CONSIGNEE_CD=CN.CONSIGNEE_CD and P.CASE_NO=T14.CASE_NO and T14.BPO_CD=V12.BPO_CD and T14.CONSIGNEE_CD=T18.CONSIGNEE_CD and P.CASE_NO=T15.CASE_NO and T15.CASE_NO=T18.CASE_NO and T15.ITEM_SRNO=T18.ITEM_SRNO_PO and T15.CONSIGNEE_CD=T18.CONSIGNEE_CD and T14.CONSIGNEE_CD=T15.CONSIGNEE_CD and T18.CASE_NO=T17.CASE_NO and T18.CALL_RECV_DT=T17.CALL_RECV_DT and T18.CALL_SNO=T17.CALL_SNO and T17.IE_CD=T09.IE_CD(+) and T17.CASE_NO= '" + CNO + "' and T17.CALL_RECV_DT=to_date('" + CDT + "','dd/mm/yyyy') and T17.CALL_SNO=" + CSNO;
				OracleDataAdapter da = new OracleDataAdapter(str3, conn1);

				//				string str3 = "select P.PO_NO,to_char(P.PO_DT,'dd/mm/yyyy') PO_DT, trim(M.VEND_NAME)MFG_NAME,trim(M.VEND_ADD1)||'/'||NVL2(CM.LOCATION,CM.LOCATION||' / '||CM.CITY,CM.CITY) MFG_ADD,(P.PURCHASER_CD||'-'||PU.CONSIGNEE)PURCHASER,(T18.CONSIGNEE_CD||'-'||CN.CONSIGNEE)CONSIGNEE,T17.CASE_NO, to_char(T17.CALL_RECV_DT,'dd/mm/yyyy')CALL_RECV_DATE, T17.CALL_SNO,T17.CALL_LETTER_NO, to_char(T17.CALL_LETTER_DT,'dd/mm/yyyy')CALL_LETTER_DT,T17.CALL_INSTALL_NO, T18.ITEM_DESC_PO,T18.QTY_ORDERED,T18.QTY_TO_INSP,NVL(T18.CUM_QTY_PREV_OFFERED,'0')CUM_QTY_PREV_OFFERED,NVL(T18.CUM_QTY_PREV_PASSED,'0')CUM_QTY_PREV_PASSED, M.VEND_CONTACT_PER_1, M.VEND_CONTACT_TEL_1,M.VEND_EMAIL,V12.BPO, to_char(T15.DELV_DT,'dd/mm/yyyy') DELV_DT  from T05_VENDOR M, T03_CITY CM,T13_PO_MASTER P,T17_CALL_REGISTER T17,T18_CALL_DETAILS T18, V06_CONSIGNEE CN,V06_CONSIGNEE PU, V12_BILL_PAYING_OFFICER V12, T14_PO_BPO T14, T15_PO_DETAIL T15  where T17.CASE_NO=P.CASE_NO and T17.MFG_CD=M.VEND_CD and M.VEND_CITY_CD=CM.CITY_CD and P.PURCHASER_CD=PU.CONSIGNEE_CD and T18.CONSIGNEE_CD=CN.CONSIGNEE_CD and T17.CASE_NO=T18.CASE_NO and T17.CALL_RECV_DT=T18.CALL_RECV_DT and T17.CALL_SNO=T18.CALL_SNO and P.CASE_NO=T14.CASE_NO and T14.BPO_CD=V12.BPO_CD and T14.CONSIGNEE_CD=T18.CONSIGNEE_CD and P.CASE_NO=T15.CASE_NO and T15.CASE_NO=T18.CASE_NO and T15.CONSIGNEE_CD=T18.CONSIGNEE_CD and T17.CASE_NO= '" + CNO + "' and T17.CALL_RECV_DT=to_date('"+ CDT +"','dd/mm/yyyy') and T17.CALL_SNO="+CSNO; 
				OracleCommand myOracleCommand3 = new OracleCommand(str3, conn1);
				conn1.Open();
				da.SelectCommand = myOracleCommand3;
				da.Fill(dsP, "Table");
				conn1.Close();

				DataSet dsP1 = new DataSet();
				string str4 = "Select T13.VEND_CD,T05.VEND_NAME,NVL2(T05.VEND_ADD2,T05.VEND_ADD1||'/'||T05.VEND_ADD2,T05.VEND_ADD1)||'/'||T03.CITY VEND_ADDRESS, T05.VEND_EMAIL, T05.VEND_CONTACT_PER_1, T05.VEND_CONTACT_TEL_1,DECODE(T13.PO_SOURCE,'V','VENDOR','M','MANUAL','C','IREPS','OTHER') SOURCE from T13_PO_MASTER T13,T05_VENDOR T05, T03_CITY T03 where T13.VEND_CD=T05.VEND_CD and T05.VEND_CITY_CD=T03.CITY_CD and CASE_NO='" + CNO + "'";
				OracleDataAdapter da1 = new OracleDataAdapter(str4, conn1);
				OracleCommand myOracleCommand4 = new OracleCommand(str4, conn1);
				conn1.Open();
				da1.SelectCommand = myOracleCommand4;
				da1.Fill(dsP1, "Table");
				conn1.Close();


				//				if(dsP.Tables[0].Rows.Count ==1)
				//				{
				//					Response.Write("<HTML>");
				//					Response.Write("<body>");
				//					Response.Write("<Table width='90%' align='center' style='Z-INDEX: 101; LEFT: 8px; WIDTH: 90%; POSITION: absolute; TOP: 8px;' height='100' border='0'>");
				//					Response.Write("<tr>");
				//					if(dsP.Tables[0].Rows[0]["ONLINE_CALL"].ToString()=="Y")
				//					{
				//						Response.Write("<td colspan=2 align='center'><Font Face='Verdana' size='2'><span style='font-size: 14'><B>ONLINE INSPECTION CALL</B></Font></td>");
				//
				//					}
				//					else
				//					{
				//						Response.Write("<td colspan=2 align='center'><Font Face='Verdana' size='2'><span style='font-size: 14'><B>INSPECTION CALL</B></Font></td>");
				//					}
				//					
				//					
				//					Response.Write("</tr>");
				//					
				//					if(dsP.Tables[0].Rows[0]["FINAL_OR_STAGE"].ToString()=="S")
				//					{
				//						Response.Write("<tr>");
				//						Response.Write("<td colspan=2 align='center'><Font Face='Verdana' size='2'><span style='font-size: 14'><B>STAGE CALL</B></Font></td>");
				//						Response.Write("</tr>");
				//					}
				//					
				//					Response.Write("<tr>");
				//					Response.Write("<td colspan=2><Font Face='Verdana' size='1'><span style='font-size: 12'><B>From.</B><br>"+dsP1.Tables[0].Rows[0]["VEND_NAME"].ToString()+"<br>"+dsP1.Tables[0].Rows[0]["VEND_ADDRESS"].ToString()+"</Font></td>");
				//					Response.Write("</tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td colspan=2><Font Face='Verdana' size='1'><span style='font-size: 12'><B>Ref No.</B>"+dsP.Tables[0].Rows[0]["CALL_LETTER_NO"].ToString()+"</Font></td>");
				//					Response.Write("</tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td align=left width='50%'><Font Face='Verdana' size='1'><span style='font-size: 12'><B>Date: </B>"+dsP.Tables[0].Rows[0]["CALL_LETTER_DT"].ToString()+"</Font></td>");
				//					if(dsP.Tables[0].Rows[0]["IE_NAME"].ToString()!="")
				//					{
				//						Response.Write("<td align=right width='50%'><Font Face='Verdana' size='1'><span style='font-size: 12'><B>Call Marked to: </B>"+dsP.Tables[0].Rows[0]["IE_NAME"].ToString()+"</Font></td>");
				//					}
				//					Response.Write("</tr>");
				//					Response.Write("<tr><td colspan=2></td></tr>");
				//					Response.Write("<tr>");
				//					if(CNO.Substring(0,1).ToString()=="N")
				//					{
				//						Response.Write("<td align=left width='50%'><Font Face='Verdana' size='1'><span style='font-size: 12'><p> To <BR><BR> Group General Manager (Inspection) <br> RITES LTD.,<br> Northern Region <br> 12th Floor, Core-II, <br> Scope Minar, Laxmi Nagar, <br> Delhi-110092</Font></td>");
				//					}
				//					else if(CNO.Substring(0,1).ToString()=="E")
				//					{
				//						Response.Write("<td align=left width='50%'><Font Face='Verdana' size='1'><span style='font-size: 12'><p> To <BR><BR> Group General Manager (Inspection) <br> RITES LTD.,<br> Eastern Region <br> CENTRAL STATION BUILDING(METRO), 56, C.R. AVENUE, 3rd FLOOR, <br> KOLKATA-700 012</Font></td>");
				//					}
				//					else if(CNO.Substring(0,1).ToString()=="W")
				//					{
				//						Response.Write("<td align=left width='50%'><Font Face='Verdana' size='1'><span style='font-size: 12'><p> To <BR><BR> Group General Manager (Inspection) <br> RITES LTD.,<br> Western Region <br> CHURCHGATE STATION BLDG., 2nd FLOOR, M.K ROAD, <br> MUMBAI-400 020 </Font></td>");
				//					}
				//					else if(CNO.Substring(0,1).ToString()=="S")
				//					{
				//						Response.Write("<td align=left width='50%'><Font Face='Verdana' size='1'><span style='font-size: 12'><p> To <BR><BR> Group General Manager (Inspection) <br> RITES LTD.,<br> Southern Region <br> CTS BUILDING - 2ND FLOOR, BSNL COMPLEX, NO. 16, GREAMS ROAD, <br> CHENNAI - 600 006</Font></td>");
				//					}
				//					else if(CNO.Substring(0,1).ToString()=="C")
				//					{
				//						Response.Write("<td align=left width='50%'><Font Face='Verdana' size='1'><span style='font-size: 12'><p> To <BR><BR> Group General Manager (Inspection) <br> RITES LTD.,<br> Central Region <br> 50, EXPANSION BUIDING,BHILAI STEEL PLANT AREA <br> BHILAI -490001 </Font></td>");
				//					}
				//					else if(CNO.Substring(0,1).ToString()=="Q")
				//					{
				//						Response.Write("<td align=left width='50%'><Font Face='Verdana' size='1'><span style='font-size: 12'><p> To <BR><BR> Group General Manager (Inspection) <br> RITES LTD.,<br> CO QA Division <br> RITES BHAWAN, 1, SECTOR-29, GURGAON <br> HARYANA -122001</Font></td>");
				//					}
				//					Response.Write("<td align=right width='50%'><Font Face='Verdana' size='1'><span style='font-size: 12'><B> CALL DATED:</B>"+dsP.Tables[0].Rows[0]["CALL_RECV_DATE"].ToString()+" <B> CALL SNO. </B>"+dsP.Tables[0].Rows[0]["CALL_SNO"].ToString()+"<br><B>CASE NO. </B>"+dsP.Tables[0].Rows[0]["CASE_NO"].ToString()+"</Font></td>");
				//					Response.Write("</tr>");
				//					Response.Write("<tr><td colspan=2></td></tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td colspan=2 align=left><Font Face='Verdana' size='1'><span style='font-size: 12'><br>Dear Sir,<br></Font></td>");
				//					Response.Write("</tr>");
				//					Response.Write("<tr><td colspan=2></td></tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td colspan=2 align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>Please arrange to inspect following goods lying ready with us. It is certified that the stores offered have been inspected by us and found to conform to the governing specifications.<br></Font></td>");
				//					Response.Write("</tr>");
				//					Response.Write("<tr><td colspan=2></td></tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>1. Purchase Order No. and Date</Font></td>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>"+dsP.Tables[0].Rows[0]["PO_NO"].ToString()+" Dated:"+dsP.Tables[0].Rows[0]["PO_DT"].ToString()+"</Font></td>");
				//					Response.Write("</tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>2. Purchaser</Font></td>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>"+dsP.Tables[0].Rows[0]["PURCHASER"].ToString()+"</Font></td>");
				//					Response.Write("</tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>3. Consignee</Font></td>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>"+dsP.Tables[0].Rows[0]["CONSIGNEE"].ToString()+"</Font></td>");
				//					Response.Write("</tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>4. Manufacturer's Name</Font></td>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>"+dsP.Tables[0].Rows[0]["MFG_NAME"].ToString()+"</Font></td>");
				//					Response.Write("</tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>5. Place of Inspection with address</Font></td>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>"+dsP.Tables[0].Rows[0]["MFG_ADD"].ToString()+"</Font></td>");
				//					Response.Write("</tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>6. Person to be contacted, Phone No. with E-mail id</Font></td>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>"+dsP.Tables[0].Rows[0]["VEND_CONTACT_PER_1"].ToString()+","+dsP.Tables[0].Rows[0]["VEND_CONTACT_TEL_1"].ToString()+","+dsP.Tables[0].Rows[0]["VEND_EMAIL"].ToString()+"</Font></td>");
				//					Response.Write("</tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>7. Description of Stores</Font></td>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>"+dsP.Tables[0].Rows[0]["ITEM_DESC_PO"].ToString()+"</Font></td>");
				//
				//					Response.Write("</tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>8. State whether the items is on RDSO Vendor Directory</Font></td>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>"+dsP.Tables[0].Rows[0]["ITEM_RDSO"].ToString()+"</Font></td>");
				//					Response.Write("</tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>9. If Yes, whether the vendor is RDSO Aprroved. Indicate validity of approval</Font></td>");
				//					if(dsP.Tables[0].Rows[0]["VEND_RDSO"].ToString()=="Yes")
				//					{
				//						Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>"+dsP.Tables[0].Rows[0]["VEND_RDSO"].ToString()+", From: "+dsP.Tables[0].Rows[0]["VEND_APP_FR"].ToString()+" TO: "+dsP.Tables[0].Rows[0]["VEND_APP_TO"].ToString()+"</Font></td>");
				//					}
				//					else
				//					{
				//						Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>"+dsP.Tables[0].Rows[0]["VEND_RDSO"].ToString()+"</Font></td>");
				//					}
				//					Response.Write("</tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>10. Quantity on Order</Font></td>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>"+dsP.Tables[0].Rows[0]["QTY_ORDERED"].ToString()+"</Font></td>");
				//					Response.Write("</tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>11. Quantity Now Offered</Font></td>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>"+dsP.Tables[0].Rows[0]["QTY_TO_INSP"].ToString()+"</Font></td>");
				//					Response.Write("</tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>12. Installmant Number</Font></td>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>"+dsP.Tables[0].Rows[0]["CALL_INSTALL_NO"].ToString()+"</Font></td>");
				//					Response.Write("</tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>13. Quantity already inspected and passed</Font></td>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>"+dsP.Tables[0].Rows[0]["CUM_QTY_PREV_OFFERED"].ToString()+" and "+dsP.Tables[0].Rows[0]["CUM_QTY_PREV_PASSED"].ToString()+"</Font></td>");
				//					Response.Write("</tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>14. Delivery period as per P.O./Amendment</Font></td>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>"+dsP.Tables[0].Rows[0]["DELV_DT"].ToString()+"</Font></td>");
				//					Response.Write("</tr>");
				//
				//					Response.Write("<tr>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; a. Does PO specified staggered DP: </Font></td>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>"+dsP.Tables[0].Rows[0]["STAG_DP"].ToString()+"</Font></td>");
				//					Response.Write("</tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; b. If yes, details of lot size and staggered DP</Font></td>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>1. Lot Size & DP: "+dsP.Tables[0].Rows[0]["LOT_DP_1"].ToString()+"</Font></td>");
				//					Response.Write("</tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'></Font></td>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>2. Lot Size & DP2: "+dsP.Tables[0].Rows[0]["LOT_DP_2"].ToString()+"</Font></td>");
				//					Response.Write("</tr>");
				//					
				//					Response.Write("<tr>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>15. Bill Paying authority</Font></td>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>"+dsP.Tables[0].Rows[0]["BPO"].ToString()+"</Font></td>");
				//					Response.Write("</tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>16. Inspection Fee Payment details for cases</Font></td>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'></Font></td>");
				//					Response.Write("</tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>    Where advance inspection fee is to be paid</Font></td>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'></Font></td>");
				//					Response.Write("</tr>");
				//					Response.Write("<tr><td colspan=2></td></tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td colspan=2 align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>I hereby declare that all details given by me are correct to the best of my knowledge and in case any information is found to be incorrect I understand that call is liable to be cancelled with full Call Cancellation charges by RITES</Font></td>");
				//					Response.Write("</tr>");
				//					Response.Write("<tr><td colspan=2></td></tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td colspan=2 align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>Thanking you,<br></Font></td>");
				//					Response.Write("</tr>");
				//					Response.Write("<tr><td colspan=2></td></tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td colspan=2 align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>Yours Faithfully,<br></Font></td>");
				//					Response.Write("</tr>");
				//					Response.Write("<tr><td colspan=2></td></tr>");
				//					Response.Write("<tr><td colspan=2></td></tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>Name<br></Font></td>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>"+dsP1.Tables[0].Rows[0]["VEND_CONTACT_PER_1"].ToString()+"</Font></td>");
				//					Response.Write("</tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>Mobile<br></Font></td>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>"+dsP1.Tables[0].Rows[0]["VEND_CONTACT_TEL_1"].ToString()+"</Font></td>");
				//					Response.Write("</tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>Vend Email<br></Font></td>");
				//					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>"+dsP1.Tables[0].Rows[0]["VEND_EMAIL"].ToString()+"</Font></td>");
				//					Response.Write("</tr>");
				//					Response.Write("<tr><td colspan=2></td></tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td colspan=2 align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>Designation<br></Font></td>");
				//					Response.Write("</tr>");
				//					Response.Write("<tr><td colspan=2>  </td></tr>");
				//					Response.Write("<tr>");
				//					Response.Write("<td colspan=2 align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>Authorised Signatory</Font></td>");
				//					Response.Write("</tr>");
				//					if(dsP.Tables[0].Rows[0]["REMARKS"].ToString()!="")
				//					{
				//						Response.Write("<tr>");
				//						Response.Write("<td colspan=2 align=left><Font Face='Verdana' size='1'><span style='font-size: 12'><B>REMARKS: "+dsP.Tables[0].Rows[0]["REMARKS"].ToString()+"</b></Font></td>");
				//						Response.Write("</tr>");
				//					}
				//					Response.Write("</Table>");
				//					Response.Write("</body>");
				//					Response.Write("</HTML>");
				//				}
				//				else if(dsP.Tables[0].Rows.Count >1)
				//				{

				Response.Write("<HTML>");
				Response.Write("<body>");
				Response.Write("<Table width='90%' align='center' style='Z-INDEX: 101; LEFT: 8px; WIDTH: 90%; POSITION: absolute; TOP: 8px;' height='100' border='0'>");
				Response.Write("<tr>");
				if (dsP.Tables[0].Rows[0]["ONLINE_CALL"].ToString() == "Y")
				{
					Response.Write("<td colspan=2 align='center'><Font Face='Verdana' size='2'><span style='font-size: 14'><B>ONLINE INSPECTION CALL</B></Font></td>");
				}
				else
				{
					Response.Write("<td colspan=2 align='center'><Font Face='Verdana' size='2'><span style='font-size: 14'><B>INSPECTION CALL</B></Font></td>");
				}
				Response.Write("</tr>");

				if (dsP.Tables[0].Rows[0]["FINAL_OR_STAGE"].ToString() == "S")
				{
					Response.Write("<tr>");
					Response.Write("<td colspan=2 align='center'><Font Face='Verdana' size='2'><span style='font-size: 14'><B>STAGE CALL</B></Font></td>");
					Response.Write("</tr>");
				}
				Response.Write("<tr>");
				Response.Write("<td colspan=2><Font Face='Verdana' size='1'><span style='font-size: 12'><B>From.</B><br>" + dsP1.Tables[0].Rows[0]["VEND_NAME"].ToString() + "<br>" + dsP1.Tables[0].Rows[0]["VEND_ADDRESS"].ToString() + "</Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td colspan=2><Font Face='Verdana' size='1'><span style='font-size: 12'><B>Ref No.</B>" + dsP.Tables[0].Rows[0]["CALL_LETTER_NO"].ToString() + "</Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td align=left width='50%'><Font Face='Verdana' size='1'><span style='font-size: 12'><B>Date: </B>" + dsP.Tables[0].Rows[0]["CALL_LETTER_DT"].ToString() + "</Font></td>");
				if (dsP.Tables[0].Rows[0]["IE_NAME"].ToString() != "")
				{
					Response.Write("<td align=right width='50%'><Font Face='Verdana' size='1'><span style='font-size: 12'><B>Call Marked to: </B>" + dsP.Tables[0].Rows[0]["IE_NAME"].ToString() + "</Font></td>");
				}
				Response.Write("</tr>");
				Response.Write("<tr><td colspan=2></td></tr>");
				Response.Write("<tr>");
				//Response.Write("<td align=left width='50%'><Font Face='Verdana' size='1'><span style='font-size: 12'><p> To <BR><BR> Group Genral Manager (Inspection) <br> RITES LTD.,<br> Northern Region <br> 12th Floor, Core-II, <br> Scope Minar, Laxmi Nagar, <br> Delhi-110092</Font></td>");
				if (CNO.Substring(0, 1).ToString() == "N")
				{
					Response.Write("<td align=left width='50%'><Font Face='Verdana' size='1'><span style='font-size: 12'><p> To <BR><BR> Group General Manager (Inspection) <br> RITES LTD.,<br> Northern Region <br> 12th Floor, Core-II, <br> Scope Minar, Laxmi Nagar, <br> Delhi-110092</Font></td>");
				}
				else if (CNO.Substring(0, 1).ToString() == "E")
				{
					Response.Write("<td align=left width='50%'><Font Face='Verdana' size='1'><span style='font-size: 12'><p> To <BR><BR> Group General Manager (Inspection) <br> RITES LTD.,<br> Eastern Region <br> CENTRAL STATION BUILDING(METRO), 56, C.R. AVENUE, 3rd FLOOR, <br> KOLKATA-700 012</Font></td>");
				}
				else if (CNO.Substring(0, 1).ToString() == "W")
				{
					Response.Write("<td align=left width='50%'><Font Face='Verdana' size='1'><span style='font-size: 12'><p> To <BR><BR> Group General Manager (Inspection) <br> RITES LTD.,<br> Western Region <br> 5TH FLOOR, REGENT CHAMBER, ABOVE STATUS RESTAURANT, NARIMAN POINT, MUMBAI-400021 </Font></td>");
				}
				else if (CNO.Substring(0, 1).ToString() == "S")
				{
					Response.Write("<td align=left width='50%'><Font Face='Verdana' size='1'><span style='font-size: 12'><p> To <BR><BR> Group General Manager (Inspection) <br> RITES LTD.,<br> Southern Region <br> CTS BUILDING - 2ND FLOOR, BSNL COMPLEX, NO. 16, GREAMS ROAD, <br> CHENNAI - 600 006</Font></td>");
				}
				else if (CNO.Substring(0, 1).ToString() == "C")
				{
					Response.Write("<td align=left width='50%'><Font Face='Verdana' size='1'><span style='font-size: 12'><p> To <BR><BR> Group General Manager (Inspection) <br> RITES LTD.,<br> Central Region <br> 50, EXPANSION BUIDING,BHILAI STEEL PLANT AREA <br> BHILAI -490001 </Font></td>");
				}
				else if (CNO.Substring(0, 1).ToString() == "Q")
				{
					Response.Write("<td align=left width='50%'><Font Face='Verdana' size='1'><span style='font-size: 12'><p> To <BR><BR> Group General Manager (Inspection) <br> RITES LTD.,<br> CO QA Division <br> RITES BHAWAN, 1, SECTOR-29, GURGAON <br> HARYANA -122001</Font></td>");
				}
				Response.Write("<td align=right width='50%'><Font Face='Verdana' size='1'><span style='font-size: 12'><B> CALL DATED:</B>" + dsP.Tables[0].Rows[0]["CALL_RECV_DATE"].ToString() + " <B> CALL SNO. </B>" + dsP.Tables[0].Rows[0]["CALL_SNO"].ToString() + "<br><B>CASE NO. </B>" + dsP.Tables[0].Rows[0]["CASE_NO"].ToString() + "(PO SOURCE:" + dsP1.Tables[0].Rows[0]["SOURCE"].ToString() + ")</Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr><td colspan=2></td></tr>");
				Response.Write("<tr>");
				Response.Write("<td colspan=2 align=left><Font Face='Verdana' size='1'><span style='font-size: 12'><br>Dear Sir,<br></Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr><td colspan=2></td></tr>");
				Response.Write("<tr>");
				Response.Write("<td colspan=2 align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>Please arrange to inspect following goods lying ready with us. It is certified that the stores offered have been inspected by us and found to conform to the governing specifications.<br></Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr><td colspan=2></td></tr>");
				Response.Write("<tr>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>1. Purchase Order No. and Date</Font></td>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>" + dsP.Tables[0].Rows[0]["PO_NO"].ToString() + " Dated:" + dsP.Tables[0].Rows[0]["PO_DT"].ToString() + "</Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>2. Purchaser</Font></td>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>" + dsP.Tables[0].Rows[0]["PURCHASER"].ToString() + "</Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>3. Consignee</Font></td>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>As Per Annexure-1</Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>4. Manufacturer's Name</Font></td>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>" + dsP.Tables[0].Rows[0]["MFG_NAME"].ToString() + "</Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>5. Place of Inspection with address</Font></td>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>" + dsP.Tables[0].Rows[0]["MFG_ADD"].ToString() + "</Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>6. Person to be contacted, Phone No. with E-mail id</Font></td>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>" + dsP.Tables[0].Rows[0]["VEND_CONTACT_PER_1"].ToString() + "," + dsP.Tables[0].Rows[0]["VEND_CONTACT_TEL_1"].ToString() + "," + dsP.Tables[0].Rows[0]["VEND_EMAIL"].ToString() + "</Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>7. Description of Stores</Font></td>");

				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>As Per Annexure-1</Font></td>");

				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>8. State whether the items is on RDSO Vendor Directory</Font></td>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>" + dsP.Tables[0].Rows[0]["ITEM_RDSO"].ToString() + "</Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>9. If Yes, whether the vendor is RDSO Aprroved. Indicate validity of approval</Font></td>");
				if (dsP.Tables[0].Rows[0]["VEND_RDSO"].ToString() == "Yes")
				{
					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>" + dsP.Tables[0].Rows[0]["VEND_RDSO"].ToString() + ", From: " + dsP.Tables[0].Rows[0]["VEND_APP_FR"].ToString() + " TO: " + dsP.Tables[0].Rows[0]["VEND_APP_TO"].ToString() + "</Font></td>");
				}
				else
				{
					Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>" + dsP.Tables[0].Rows[0]["VEND_RDSO"].ToString() + "</Font></td>");
				}
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>10. Quantity on Order</Font></td>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>As Per Annexure-1</Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>11. Quantity Now Offered</Font></td>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>As Per Annexure-1</Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>12. Installmant Number</Font></td>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>" + dsP.Tables[0].Rows[0]["CALL_INSTALL_NO"].ToString() + "</Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>13. Quantity already inspected and passed</Font></td>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>As Per Annexure-1</Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>14. Delivery period as per P.O./Amendment</Font></td>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>As Per Annexure-1</Font></td>");
				Response.Write("</tr>");

				Response.Write("<tr>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; a. Does PO specified staggered DP: </Font></td>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>" + dsP.Tables[0].Rows[0]["STAG_DP"].ToString() + "</Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; b. If yes, details of lot size and staggered DP</Font></td>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>1. Lot Size & DP: " + dsP.Tables[0].Rows[0]["LOT_DP_1"].ToString() + "</Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'></Font></td>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>2. Lot Size & DP2: " + dsP.Tables[0].Rows[0]["LOT_DP_2"].ToString() + "</Font></td>");
				Response.Write("</tr>");

				Response.Write("<tr>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>15. Bill Paying authority</Font></td>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>As Per Annexure-1</Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>16. IRFC Funded Project</Font></td>");
				string w_irfc = "";
				if (dsP.Tables[0].Rows[0]["IRFC_FUNDED"].ToString() == "Y")
				{
					w_irfc = "Yes";
				}
				else
				{
					w_irfc = "No";
				}
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>" + w_irfc + "</Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>17. Inspection Fee Payment details for cases</Font></td>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'></Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>    Where advance inspection fee is to be paid</Font></td>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'></Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr><td colspan=2></td></tr>");
				Response.Write("<tr>");
				//Response.Write("<td colspan=2 align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>I hereby declare that all details given by me above are correct to the best of my knowledge and in case any information is found to be incorrect. I understand that call is liable to be cancelled with full Call Cancellation charges by RITES. Besides, I am fully aware that any amendment to PO/LOA is to be uploaded on IBS (path shown below), as and when, i recieve it from the purchaser and it will be my responsibility that all the MAs recieved till the date of inspection are uploaded on IBS and will provide all of these MAs to the Inspecting Engineer during inspection, if any additional MA is recieved during inspection up to the issue of IC, the same will also be provided to Inspecting Engineer immediately.<br>Vendor Login=>Add MA=>Enter Case No.=>Add New MA=>Fill the MA Details=>Upload Original MA Copy=>Save MA</Font></td>");
				Response.Write("<td colspan=2 align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>I hereby accept all the <a href='javascript: void(0)' onclick=javascript:window.open('TermsandConditions.aspx','CustomPopUp','fullscreen=no,scrollbars=yes','width=700,height=800,menubar=no,resizable=no,alwaysRaised=true');return false; Font-Names='Verdana' Font-Size='8pt'>Terms and Conditions</a>. </Font></td>");

				Response.Write("</tr>");
				Response.Write("<tr><td colspan=2></td></tr>");
				Response.Write("<tr>");
				Response.Write("<td colspan=2 align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>Thanking you,<br></Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr><td colspan=2></td></tr>");
				Response.Write("<tr>");
				Response.Write("<td colspan=2 align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>Yours Faithfully,</Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr><td colspan=2></td></tr>");
				Response.Write("<tr><td colspan=2></td></tr>");
				Response.Write("<tr>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>Name<br></Font></td>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>" + dsP1.Tables[0].Rows[0]["VEND_CONTACT_PER_1"].ToString() + "</Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>Mobile<br></Font></td>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>" + dsP1.Tables[0].Rows[0]["VEND_CONTACT_TEL_1"].ToString() + "</Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>Vend Email<br></Font></td>");
				Response.Write("<td align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>" + dsP1.Tables[0].Rows[0]["VEND_EMAIL"].ToString() + "</Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr><td colspan=2></td></tr>");
				Response.Write("<tr>");
				Response.Write("<td colspan=2 align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>Designation</Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr><td colspan=2>  </td></tr>");
				Response.Write("<tr>");
				Response.Write("<td colspan=2 align=left><Font Face='Verdana' size='1'><span style='font-size: 12'>Authorised Signatory</Font></td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='2'>");
				int wsno = 0;
				Response.Write("<Table width='100%' align='center' border='1' bordercolor='#111111'>");
				Response.Write("<tr>");
				Response.Write("<td colspan=9 align='center'><Font Face='Verdana' size='2'><span style='font-size: 14'><B>Annexure-1 (INSPECTION CALL ITEM DETAILS)</B></Font></td>");
				Response.Write("</tr>");
				//						Response.Write("<tr>");
				//						Response.Write("<td colspan=8 align='center'><Font Face='Verdana' size='1'><span style='font-size: 14'><B>Case No. "+CNO+" Call Dated. "+CDT+" Sno. "+CSNO+"</B></Font></td>");
				//						Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='10%' valign='top' align='center'><font size='1' face='Verdana'>Sno.</Font></th>");
				Response.Write("<th width='15%' valign='top' align='center'><font size='1' face='Verdana'>Consignee</Font></th>");
				Response.Write("<th width='35%' valign='top' align='center'><font size='1' face='Verdana'>Description of Stores</Font></th>");
				Response.Write("<th width='5%' valign='top' align='center'><font size='1' face='Verdana'>Quantity on Order</Font></th>");
				Response.Write("<th width='5%' valign='top' align='center'><font size='1' face='Verdana'>Quantity Now Offered</Font></th>");
				Response.Write("<th width='5%' valign='top' align='center'><font size='1' face='Verdana'>Quantity already inspected and passed</Font></th>");
				Response.Write("<th width='5%' valign='top' align='center'><font size='1' face='Verdana'>Delivery period as per P.O./Amendment</Font></th>");
				Response.Write("<th width='15%' valign='top' align='center'><font size='1' face='Verdana'>Bill Paying authority</Font></th>");
				Response.Write("<th width='5%' valign='top' align='center'><font size='1' face='Verdana'>Master Item Checksheet</Font></th>");
				Response.Write("</tr>");

				for (int i = 0; i <= dsP.Tables[0].Rows.Count - 1; i++)
				{
					wsno = wsno + 1;
					Response.Write("<tr>");
					Response.Write("<td width='10%' valign='top' align='Center'><font size='1' face='Verdana'>" + wsno + "</font></b></td>");
					Response.Write("<td width='15%' valign='top' align='Left'><font size='1' face='Verdana'>" + dsP.Tables[0].Rows[i]["CONSIGNEE"].ToString() + "</font></td>");
					Response.Write("<td width='35%' valign='top' align='Left'><font size='1' face='Verdana'>" + dsP.Tables[0].Rows[i]["ITEM_DESC_PO"].ToString() + "</font></td>");
					Response.Write("<td width='5%' valign='top' align='Left'><font size='1' face='Verdana'>" + dsP.Tables[0].Rows[i]["QTY_ORDERED"].ToString() + "</font></td>");
					Response.Write("<td width='5%' valign='top' align='left'><font size='1' face='Verdana'>" + dsP.Tables[0].Rows[i]["QTY_TO_INSP"].ToString() + "</font></td>");
					Response.Write("<td width='5%' valign='top' align='left'><font size='1' face='Verdana'>" + dsP.Tables[0].Rows[i]["CUM_QTY_PREV_OFFERED"].ToString() + " & " + dsP.Tables[0].Rows[i]["CUM_QTY_PREV_PASSED"].ToString() + "</font></td>");
					Response.Write("<td width='5%' valign='top' align='left'><font size='1' face='Verdana'>" + dsP.Tables[0].Rows[i]["DELV_DT"].ToString() + "</font></td>");
					Response.Write("<td width='15%' valign='top' align='Left'><font size='1' face='Verdana'>" + dsP.Tables[0].Rows[i]["BPO"].ToString() + "</font></td>");
					Response.Write("<td width='5%' valign='top' align='Left'><font size='1' face='Verdana'><a href='http://rites.ritesinsp.com/RBS/MASTER_ITEMS_CHECKSHEETS/" + dsP.Tables[0].Rows[i]["ITEM_CD"].ToString() + ".RAR'>" + dsP.Tables[0].Rows[i]["ITEM_CD"].ToString() + "</font></td>");
					Response.Write("</tr>");

				}

				Response.Write("</Table>");
				Response.Write("</td></tr>");
				if (dsP.Tables[0].Rows[0]["REMARKS"].ToString() != "")
				{
					Response.Write("<tr>");
					Response.Write("<td colspan=2 align=left><Font Face='Verdana' size='1'><span style='font-size: 12'><B>REMARKS: " + dsP.Tables[0].Rows[0]["REMARKS"].ToString() + "</b></Font></td>");
					Response.Write("</tr>");
				}
				Response.Write("</Table>");
				Response.Write("</body>");
				Response.Write("</HTML>");
				//				}

				conn1.Close();
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				//string str1=str.Replace("\n","");
				Response.Write("Error!!" + str);
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

		}
		#endregion

		protected void btnPrint_Click(object sender, System.EventArgs e)
		{
			btnPrint.Visible = false;

			Response.Write("<script language=JavaScript>window.print();</script>");
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("MainForm.aspx");
		}
	}
}