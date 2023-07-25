<%@ Page Language="c#" Inherits="RBS.MainForm" CodeFile="MainForm.aspx.cs" %>
<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>Menu Selection Screen</title>
		<script type='text/javascript'>
	var NoOffFirstLineMenus=5;			// Number of first level items
	var LowBgColor='#dce4f6';			// Background color when mouse is not over
	var LowSubBgColor='#dce4f6';			// Background color when mouse is not over on subs
	var HighBgColor='#87cefa';			// Background color when mouse is over
	var HighSubBgColor='#87cefa';			// Background color when mouse is over on subs
	var FontLowColor='#00008b';			// Font color when mouse is not over
	var FontSubLowColor='#00008b';			// Font color subs when mouse is not over
	var FontHighColor='#00008b';			// Font color when mouse is over
	var FontSubHighColor='#00008b';			// Font color subs when mouse is over
	var BorderColor='#00008b';			// Border color
	var BorderSubColor='#63639C';			// Border color for subs
	var BorderWidth=2;				// Border width
	var BorderBtwnElmnts=1;			// Border between elements 1 or 0
	var FontFamily="verdana"	// Font family menu items
	var FontSize=8;				// Font size menu items
	var FontBold=0;				// Bold menu items 1 or 0
	var FontItalic=0;				// Italic menu items 1 or 0
	var MenuTextCentered='left';			// Item text position 'left', 'center' or 'right'
	var MenuCentered='center';			// Menu horizontal position 'left', 'center' or 'right'
	var MenuVerticalCentered='top';		// Menu vertical position 'top', 'middle','bottom' or static
	var ChildOverlap=.2;				// horizontal overlap child/ parent
	var ChildVerticalOverlap=.8;			// vertical overlap child/ parent
	var StartTop=130;				// Menu offset x coordinate
	var StartLeft=1;				// Menu offset y coordinate
	var VerCorrect=0;				// Multiple frames y correction
	var HorCorrect=0;				// Multiple frames x correction
	var LeftPaddng=0;				// Left padding
	var TopPaddng=0;				// Top padding
	var FirstLineHorizontal=1;			// SET TO 1 FOR HORIZONTAL MENU, 0 FOR VERTICAL
	var MenuFramesVertical=1;			// Frames in cols or rows 1 or 0
	var DissapearDelay=1000;			// delay before menu folds in
	var TakeOverBgColor=1;			// Menu frame takes over background color subitem frame
	var FirstLineFrame='navig';			// Frame where first level appears
	var SecLineFrame='space';			// Frame where sub levels appear
	var DocTargetFrame='space';			// Frame where target documents appear
	var TargetLoc='';				// span id for relative positioning
	var HideTop=0;				// Hide first level when loading new document 1 or 0
	var MenuWrap=1;				// enables/ disables menu wrap 1 or 0
	var RightToLeft=0;				// enables/ disables right to left unfold 1 or 0
	var UnfoldsOnClick=0;			// Level 1 unfolds onclick/ onmouseover
	var WebMasterCheck=0;			// menu tree checking on or off 1 or 0
	var ShowArrow=1;				// Uses arrow gifs when 1
	var KeepHilite=1;				// Keep selected path highligthed
	var Arrws=['tri.gif',5,10,'tridown.gif',10,5,'trileft.gif',5,10];	// Arrow source, width and height

function BeforeStart(){return}
function AfterBuild(){return}
function BeforeFirstOpen(){return}
function AfterCloseAll(){return}
//****************** Menu **********************************************
  Menu1=new Array("ADMINISTRATION","","",13,20,150);
	 Menu1_1=new Array("User Administration","User_Administration.aspx","",0,20,250);
     Menu1_2=new Array("General Messages","Messages_Form.aspx","",0,20,250);
     Menu1_3=new Array("Allow/Disallow Old Bill Date","Allow_Old_Bill_Date_Form.aspx","",0,20,250);
     Menu1_4=new Array("Master Tables Status","Reports/rptMasterTableStatus.aspx","",0,20,250);
     Menu1_5=new Array("Instructions for Inspection Engineer","IE_Instructions_Admin.aspx","",0,20,250);
     Menu1_6=new Array("Purchase Orders Submitted by Vendors Awaiting Allocation of Case No.","DEO_Vendor_PurchesOrder1_Form.aspx","",0,30,250);
     Menu1_7=new Array("Upload Documents","Upload_Documents.aspx","",0,20,250);
     Menu1_8=new Array("Download Documents","Download_Documents.aspx?allowDL=Y","",0,20,250);
     Menu1_9=new Array("Download Corporate Instructions","Download_Documents.aspx?allowDL=Y&Action=CI","",0,20,250);
     Menu1_10=new Array("CRIS Purchase Orders Submitted Awaiting Allocation of Case No.","DEO_CRIS_PurchesOrder1_Form.aspx","",0,30,250);
     Menu1_11=new Array("MA Issued against CRIS Purchase Orders Registered In RITES.","DEO_CRIS_PurchesOrder_MA_Form.aspx","",0,30,250);
     Menu1_12=new Array("Approval For MA","MA_VENDOR_LIST.aspx","",0,30,250);
     Menu1_13=new Array("MA Issued against CRIS Purchase Orders Not Registered In RITES.(Under Testing)","DEO_CRIS_PurchesOrder_MA_Form_WCaseNo.aspx","",0,30,250);
//     Menu1_2=new Array("Messages Form","Mobile.aspx","",0,20,250);
  Menu2=new Array("DIRECTORIES","","",20,20,150);
     Menu2_1=new Array("Unit Of Measurements","UOM_Form.aspx","",0,20,250);
     Menu2_2=new Array("Rites Designation Master","Designation_Form.aspx","",0,20,250);
     Menu2_3=new Array("Railways Directory","Railways_Form.aspx","",0,20,250);
     Menu2_4=new Array("Railway Designation Master","Rly_Designation_Form.aspx","",0,20,250);
     Menu2_5=new Array("City Master","City_Form.aspx","",0,20,250);
     Menu2_6=new Array("Controlling Officers Of Inspecting Engineers","IE_CO_Form.aspx","",0,20,250);
     Menu2_7=new Array("Inspection Engineers","IE_Search_Form.aspx","",0,20,250);
     Menu2_8=new Array("I C Bookset","IC_Bookset_Search_Form1.aspx","",0,20,250);
     Menu2_9=new Array("Vendor/Manufacturer Master","Vendor_Search_Form.aspx","",0,20,250);
     Menu2_10=new Array("Consignee/Purchaser Master","Consignee_Search_Form.aspx","",0,20,250);
     Menu2_11=new Array("Bill Paying Officer","BPO_List.aspx","",0,20,250);
     Menu2_12=new Array("Bank Master","Bank_Form.aspx","",0,20,250);   
     Menu2_13=new Array("Account Codes Directory","Account_Codes_Form.aspx","",0,20,250);   
     Menu2_14=new Array("Issue of Hologram to IE","Hologram_Search_Form.aspx","",0,20,250); 
     Menu2_15=new Array("Cluster Master","Cluster_Master.aspx","",0,20,250); 
     Menu2_16=new Array("Vendor Cluster","Vendor_cluster.aspx","",0,20,250); 
     Menu2_17=new Array("IE Cluster","IE_cluster.aspx","",0,20,250); 
     Menu2_18=new Array("IE Maximum Call Limit Form","IE_MAXIMUMCALLLIMIT.aspx","",0,20,250); 
     Menu2_19=new Array("Master Items List Form","Master_Items_Form.aspx","",0,20,250); 
     Menu2_20=new Array("Master Items PL Form","Master_Items_PL_Form.aspx","",0,20,250);
    
  Menu3=new Array("TRANSACTIONS","","",12,20,200);
	Menu3_1=new Array("Inspection & Billing","","",16,20,250);
		Menu3_1_1=new Array("Purchase Order Form","PurchesOrder1_Form.aspx","",0,20,270);
		Menu3_1_2=new Array("Call Registration/Cancellation","Call_Register_Edit.aspx","",0,20,250); 
		Menu3_1_3=new Array("Unregistered Calls","Unregistered_Calls.aspx","",0,20,250);
		Menu3_1_4=new Array("Inspection Certificate","Inspection_Certificate_Edit_Form.aspx","",0,20,250);    
		Menu3_1_5=new Array("View Inspection Bill / Payments Received against the Bill","Inspection_Fee_Bill_Edit.aspx","",0,30,250);    
		Menu3_1_6=new Array("Print Bills","Bill_Report.aspx","",0,20,250);
		Menu3_1_7=new Array("IC Cancellation","IC_Cancel_Form.aspx","",0,20,250); 
		Menu3_1_8=new Array("Search","Search_Form.aspx","",0,20,250);  
		Menu3_1_9=new Array("Change Bill Status for Re-printing","Update_Bill_Status.aspx","",0,20,250);
		Menu3_1_10=new Array("Old System Outstanding","OldOutstandingClientWise.aspx","",0,20,250); 
		Menu3_1_11=new Array("Receipt of Bookset in Inspection Office","IC_Receipt.aspx","",0,20,250); 
		Menu3_1_12=new Array("Hologram Accountal","Hologram_Accountal_Search_Form.aspx","",0,20,250); 
		Menu3_1_13=new Array("Call Marked (Online)","Vendor_Calls_Marked_Form.aspx","",0,20,250); 
		Menu3_1_14=new Array("Online Consignee Rejections","Online_complaints_Approval_Form.aspx","",0,20,250); 
		Menu3_1_15=new Array("Call Return Form","Call_Return_Form.aspx","",0,20,250); 
		Menu3_1_16=new Array("CMWise IC Issued by IE But Not Recieved In Office","Reports/pfrmFromToDate.aspx?Action=CMWISEICNI","",0,20,250);
			
	Menu3_2=new Array("Finance","","",17,20,250);    
        Menu3_2_1=new Array("Reciept Voucher","","",2,20,250);  
			Menu3_2_1_1=new Array("Add Reciept Voucher","RV_Entry.aspx?Action=A","",0,20,250);  
			Menu3_2_1_2=new Array("Edit Reciept Voucher","RV_Entry.aspx?Action=M","",0,20,250);  
		Menu3_2_2=new Array("Filling of Missing BPO in Cheque/DD Receipts","CaseNoBPOforAdvancedCheque.aspx","",0,35,250); 
		Menu3_2_3=new Array("Cheque Posting","Check_Posting_Form.aspx","",0,20,250); 
		Menu3_2_4=new Array("TDS Entry","TDS.aspx","",0,20,250);  
		Menu3_2_5=new Array("EFT Entry","","",2,20,250);  
			Menu3_2_5_1=new Array("Add EFT Voucher","RV_Entry.aspx?Action=A&VOUCHER_TYPE=E","",0,20,250);  
			Menu3_2_5_2=new Array("Edit EFT Voucher","RV_Entry.aspx?Action=M&VOUCHER_TYPE=E","",0,20,250);   
		Menu3_2_6=new Array("Search Payments","Search_Payments.aspx","",0,20,250); 
		Menu3_2_7=new Array("Inter Unit Transfers","InterUnit_Transfer.aspx","",0,20,250); 
		Menu3_2_8=new Array("Inter Unit Receipts","","",2,20,250);  
			Menu3_2_8_1=new Array("New Voucher","InterUnit_Reciept.aspx?Action=A","",0,20,250);  
			Menu3_2_8_2=new Array("Edit Voucher","InterUnit_Reciept.aspx?Action=M","",0,20,250);  
		Menu3_2_9=new Array("Replace Cheque","Replace_Cheques_Form.aspx","",0,20,250); 
		Menu3_2_10=new Array("IE Claim Form","IE_Claim_Search.aspx","",0,20,250); 
		Menu3_2_11=new Array("SAP Billing Entry","SAP_Billing_Entry_Form.aspx","",0,20,250); 
		Menu3_2_12=new Array("SAP Realisation Entry Voucher Wise","SAP_Realisation_Entry_Form.aspx","",0,20,250); 
		Menu3_2_13=new Array("Railway Online Payment Posting Form","Rly_Online_Check_Posting_Form.aspx","",0,20,250); 
		Menu3_2_14=new Array("Update SAP Document ID in Credit Note","Credit_Doc_upd.aspx","",0,20,250);
		Menu3_2_15=new Array("Lab Sample Payment Approval Form","Lab_Pyament_List.aspx","",0,20,250);
		Menu3_2_16=new Array("Lab Sample Payment Approval Report","Reports/Rpt_lab_sample_info.aspx","",0,20,250); 
		Menu3_2_17=new Array("Update SAP Document ID in Lab Credit Note","Credit_Doc_Upd_Lab.aspx","",0,30,250); 
	 Menu3_3=new Array("Central Region Billing Information","CR_Bill_Search_Form.aspx","",0,20,250); 
	 Menu3_4=new Array("Consignee Complaints","Complaint_Case_Detail_Search.aspx","",0,20,250); 
	 Menu3_5=new Array("NCR Register","","",2,20,250); 
		 Menu3_5_1=new Array("Add NCR","IE_NC_Edit_Form.aspx?Action=A","",0,20,250);  
		 Menu3_5_2=new Array("Edit NCR","IE_NC_Edit_Form.aspx?Action=M","",0,20,250);  
	 Menu3_6=new Array("Vigilance Case Monitoring System -> Under Testing","Vigilance_Cases_Edit.aspx","",0,30,250);
	 Menu3_7=new Array("IE Training Master -> Under Testing","Training_Form.aspx","",0,30,250);
	 //Menu3_8=new Array("Ongoing Non Railway Contracts -> Under Testing","Ongoing_Contracts_Edit.aspx","",0,30,250);
	 Menu3_8=new Array("Super Surprise Check","Super_Surpirse_Form.aspx","",0,30,250);
	 //Menu3_9=new Array("Offers/Contracts Entry Form -> Under Testing","Contracts_Form.aspx","",0,30,250);
	 Menu3_9=new Array("CM Wise Call Cancellation Approval Form","CMIEWiseCancellationAcceptance_Form.aspx","",0,20,250); 
	 Menu3_10=new Array("PCDO Entry Form","","",14,20,250);
	     Menu3_10_1=new Array("Offers/Contracts Entry Form -> Under Testing","Contracts_Form.aspx","",0,30,250); 
	     Menu3_10_2=new Array("Clients Contact","Clients_Contact.aspx?ACTION=C","",0,20,250);
         Menu3_10_3=new Array("Lab Billing","Lab_Billing_Form.aspx","",0,20,250);
         Menu3_10_4=new Array("Expenditure","Expenditure_Form.aspx","",0,20,250);
         Menu3_10_5=new Array("Technical Reference","Tech_Ref_Form.aspx","",0,20,250); 
         Menu3_10_6=new Array("Highlights","Highlights_Form.aspx","",0,20,250);
         Menu3_10_7=new Array("BD Efforts","Clients_Contact.aspx?ACTION=B","",0,20,250);
         Menu3_10_8=new Array("Central Quality of Inspection-I","Central_QOI_Form.aspx","",0,20,250);
         Menu3_10_9=new Array("Central Quality of Inspection-II","Central_QOII.aspx","",0,20,250);
         Menu3_10_10=new Array("Central Rejection Status","Cr_rejection.aspx","",0,20,250);
         Menu3_10_11=new Array("Bill and Operating Ratio Target","BE_Target_Form.aspx","",0,20,250);
         Menu3_10_12=new Array("Last Year Current Month Outstanding","Outstanding_LY_Form.aspx","",0,20,250);
         Menu3_10_13=new Array("Billing Adjustments Form","Billing_Adjustment_Form.aspx","",0,20,250);
         Menu3_10_14=new Array("DFO Visit","Clients_Contact.aspx?ACTION=D","",0,20,250);
//	 Menu3_XX=new Array("Multi IC Bills","Multiple_Inspection_Certificate_Form.aspx","",0,20,250); 
	Menu3_11=new Array("Bills Finalisation Form","Bill_Finalisation_Form.aspx","",0,20,250); 
	Menu3_12=new Array("Call Remarking","","",2,20,250);
	       Menu3_12_1=new Array("Call Remarking Request","Call_Remark_Form.aspx","",0,20,250);
	       Menu3_12_2=new Array("Call Remarking Approval","Call_Remarking_List.aspx","",0,20,250);
  Menu4=new Array("REPORTS","","",13,20,150);
	Menu4_1=new Array("Calls","","",24,20,410);    
		Menu4_1_1=new Array("Calls Marked Period Wise","Calls_Marked.aspx","",0,20,310);    
		Menu4_1_2=new Array("Summary of IE Wise Calls Marked Monthly","Reports/rptCalls_NR.aspx","",0,20,200);
		Menu4_1_3=new Array("Daily IE Wise Calls","Reports/pfrmDailyIEWiseCall.aspx","",0,20,200);   
//		Menu4_1_4=new Array("Summary of IE Wise Calls","Query/qryIEWiseCall.aspx","",0,20,200);  
		Menu4_1_4=new Array("Calls Marked Vendor Wise","Reports/pfrmCalls.aspx?rep=V","",0,20,200);  
		Menu4_1_5=new Array("Calls Marked IE Wise","Reports/pfrmCalls.aspx?rep=I","",0,20,200); 
		Menu4_1_6=new Array("Calls Marked IE & Vendor Wise","Reports/pfrmCalls.aspx?rep=IV","",0,20,200);  
		Menu4_1_7=new Array("Summary of IE & Vendor Wise Calls","Reports/rptIEVendorWiseNoOfCalls.aspx?rep=C","",0,20,200);
		Menu4_1_8=new Array("Summary of Client Wise Calls","Reports/rptBillRaised.aspx?ACTION=CWCalls","",0,20,200);
		Menu4_1_9=new Array("Client Wise Call Details","Reports/pfrmCallDetailsClientWise.aspx?ACTION=CALLSCLIENTWISE","",0,20,200);
		Menu4_1_10=new Array("Summary of IE wise Call Status","Reports/pfrmFromToDate.aspx?action=CIE","",0,20,200);
		Menu4_1_11=new Array("Summary of IE Headquater/City wise Call Status","Reports/pfrmFromToDate.aspx?action=IECITYCALLS","",0,20,200);
		Menu4_1_12=new Array("IE & Vendor Wise Calls Cancelled","Reports/pfrmFromToDate.aspx?action=SUMCALLX","",0,20,200);
		Menu4_1_13=new Array("IE Wise Non-Railway Calls (as per ISO:17020 requirement)","Reports/pfrmISO17020.aspx","",0,30,200);
		Menu4_1_14=new Array("IE Wise Daily Summary of Calls ","Reports/rptCalls_NR.aspx?action=1","",0,20,200);  
		Menu4_1_15=new Array("Re-Marked Calls","Reports/pfrmFromToDate.aspx?ACTION=REMCALLS","",0,20,200);  
		Menu4_1_16=new Array("Statement of OverDue Calls","Reports/pfrmCalls.aspx?rep=O","",0,20,200);  
		Menu4_1_17=new Array("No. of Online & Manual Calls","Reports/pfrmFromToDate.aspx?action=NOOFCALLS","",0,20,200);  
		Menu4_1_18=new Array("Fire Retardant Vendors Call Details","Reports/pfrmFromToDate.aspx?action=FIRERETVENDCALL","",0,20,200);  
		Menu4_1_19=new Array("Textile Items Call Details","Reports/pfrmFromToDate.aspx?action=TEXTILEITEMS","",0,20,200);  
		Menu4_1_20=new Array("Call Cancellation Approval Report","Reports/pfrmFromToDate.aspx?action=CCAPP","",0,20,200);  
		Menu4_1_21=new Array("Specific PO Call Status","Calls_Marked_For_Specific_PO.aspx?ACTION=C","",0,20,250);	 
		Menu4_1_22=new Array("OHE Items Call Details","Reports/pfrmFromToDate.aspx?action=OHEITEMS","",0,20,200);	 
		Menu4_1_23=new Array("MOZ Project Purchase Orders","Reports/pfrmFromToDate.aspx?action=MOZPOS","",0,20,200);	 
		Menu4_1_24=new Array("MOZ Project Call Details","Reports/pfrmFromToDate.aspx?action=MOZCALLS","",0,20,200);	 
		Menu4_1_24=new Array("Jal Shakti Kashmir Calls","Reports/pfrmFromToDate.aspx?action=PHED","",0,20,200);	 
 	 Menu4_2=new Array("Inspection Status","","",8,20,150);
		Menu4_2_1=new Array("Inspection Status - RCF/JVVNL/Rly. Bd.","Reports/pfrmInsp_Status_RCF.aspx","",0,20,250);
		Menu4_2_2=new Array("IE Wise Inspection Status","Reports/rptInspStatusIEWise.aspx","",0,20,250);
		Menu4_2_3=new Array("IE Wise Inspections","Reports/rptIEVendorWiseNoOfCalls.aspx","",0,20,250);
		Menu4_2_4=new Array("Vendor Wise Inspection Status","Reports/pfrmVendorWiseBilling.aspx?ACTION=VENDINSP","",0,20,250);
		Menu4_2_5=new Array("Summary of Consignee Wise Inspections","Reports/rptHighValueBills.aspx?ACTION=C","",0,20,200);
		Menu4_2_6=new Array("Summary of Vendor Wise Inspections","Reports/rptHighValueBills.aspx?ACTION=V","",0,20,200);
		Menu4_2_7=new Array("Details of Purchaser Wise Inspections","Reports/rptHighValueBills.aspx?ACTION=P","",0,20,200);
		Menu4_2_8=new Array("Specific PO IC Status","Calls_Marked_For_Specific_PO.aspx?ACTION=I","",0,20,250);	 
    Menu4_3=new Array("Billing","","",18,20,150);
		Menu4_3_1=new Array("BPO Wise Billing Details","Reports/pfrmBPO_Bills.aspx","",0,20,270);
		Menu4_3_2=new Array("Client Wise Billing Summary","Reports/rptBillRaised.aspx?ACTION=CWBills","",0,20,250);
		Menu4_3_3=new Array("Inspection Billing & Delays","Reports/rptInspBillingDelay.aspx?ACTION=U","",0,20,250);   	
		Menu4_3_4=new Array("Sector Wise Billing Summary","Reports/rptBillRaised.aspx?ACTION=SWBills","",0,20,250);
		Menu4_3_5=new Array("Discipline Wise Inspection Fee Summary","Reports/pfrmFromToDate.aspx?ACTION=DWB","",0,20,250);
		Menu4_3_6=new Array("Client & Discipline Wise Billing Summary","Reports/rptBillRaised.aspx?ACTION=CDWB","",0,20,250);
		Menu4_3_7=new Array("Vendor Wise Billing Summary","Reports/pfrmVendorWiseBilling.aspx?ACTION=VENDBILL","",0,20,250);
		Menu4_3_8=new Array("Bill Register","Reports/repBillRegister.aspx","",0,20,200);  
		Menu4_3_9=new Array("Bills Raised against the Purchase Order for the Client","Reports/pfrmClient_And_BPO_Wise_Reports.aspx","",0,35,200);		
		Menu4_3_10=new Array("PO/Purchaser Client Wise Billing Summary","Reports/rptBillRaised.aspx?ACTION=POCWBills","",0,20,250);
		Menu4_3_11=new Array("ICF Billing Details for Payment","Reports/pfrmFromToDate.aspx?ACTION=ICFBILLDET","",0,20,250);
		Menu4_3_12=new Array("Create Digitally Signed Invoice for Rly Payment","CRIS_Bills_Gen_Reg_Wise.aspx","",0,30,250);
		Menu4_3_13=new Array("Download Document for Digital Invoices","Reports/pfrmRlyOnlineBills.aspx","",0,20,250);
		Menu4_3_14=new Array("Bills Not Submitted to CRIS","Reports/pfrmCrisPayementRec.aspx?ACTION=NSC","",0,20,250);
		Menu4_3_15=new Array("Returned Bills yet to be Submitted to CRIS (Under Testing)","Reports/pfrmCrisPayementRec.aspx?ACTION=RBNRS","",0,30,250);
		Menu4_3_16=new Array("Returned Bills BPO Change Report","Reports/pfrmFromToDate.aspx?ACTION=RETBILLSBPOCHANGE","",0,20,250);
		Menu4_3_17=new Array("Credit Note Invoices","Reports/pfrmFromToDate.aspx?ACTION=CREDITNOTE","",0,20,250);
		Menu4_3_18=new Array("Case Wise Billing","Query/qryUnInspectedQty.aspx?ACTION=CWS","",0,20,250);
	Menu4_4=new Array("Outstanding","","",12,20,150);
		Menu4_4_1=new Array("Bills Cleared Status (BPO Wise/PO Wise)","Reports/pfrmBPO_Wise_Bills.aspx?ACTION=BD","",0,20,300);
		Menu4_4_2=new Array("Client Wise Outstanding Statement","Reports/rptOutstanding.aspx?action=F","",0,20,300);	
		Menu4_4_3=new Array("BPO Wise Outstanding Bills & Suspense","","",5,20,300);
				Menu4_4_3_1=new Array("Outstanding Bills & Suspense - Detailed Report","Reports/pfrmBPO_Wise_Outstanding_Bills.aspx?ACTION=D","",0,20,400);
				Menu4_4_3_2=new Array("Outstanding Bills & Suspense - Detailed Letter Format for Clients","Reports/pfrmBPO_Wise_Outstanding_Bills.aspx?ACTION=L","",0,20,400);
				Menu4_4_3_3=new Array("Outstanding Bills & Suspense - Cover Letter Only","Reports/pfrmBPO_Wise_Outstanding_Bills.aspx?ACTION=C","",0,20,400);
				Menu4_4_3_4=new Array("Outstanding Bills & Suspense - Compact Report (For A4-Size paper)","Reports/pfrmBPO_Wise_Outstanding_Bills.aspx?ACTION=S","",0,20,400);
				Menu4_4_3_5=new Array("Outstanding Report (Excel)","Reports/pfrmBPO_Wise_Outstanding_Bills.aspx?ACTION=E","",0,20,400);	
		Menu4_4_4=new Array("Client Wise Outstanding of One Region Over Other","Reports/rptOutstanding.aspx?action=S","",0,20,300);	
		Menu4_4_5=new Array("Periodic Breakup of Client Wise Outstanding on Predefined Ages","Reports/rptOutstanding.aspx?action=P","",0,30,300);
		Menu4_4_6=new Array("Periodic Breakup of Client Wise Outstanding Based on Date Slots Choosen by User","Reports/rptPeriodicOutstanding.aspx","",0,30,300);	
		Menu4_4_7=new Array("Statement of Outstanding Bills of Specific Values","Reports/rptRemittances.aspx?action=O","",0,20,300);
		Menu4_4_8=new Array("Inspection Engineer wise Advance(Fees) Outstanding","Reports/pfrmAdvanceOutstanding.aspx","",0,30,300);
		Menu4_4_9=new Array("Client Wise Outstanding Statement For Service Tax Purpose","Reports/rptBillRaised.aspx?ACTION=CWOUTS","",0,30,300);
		Menu4_4_10=new Array("Short/Excess Payment & Reconciliation of Bills","Reports/rptShortorExcess.aspx","",0,30,300);
		Menu4_4_11=new Array("Rly Wise Outstanding Chased by NR","Reports/rptOutstanding.aspx?action=FNR","",0,20,200);
		Menu4_4_12=new Array("RE Outstanding AU Wise","Reports/rptOutstanding.aspx?action=REF","",0,20,200);
	Menu4_5=new Array("Receipts/Remitance/EFT/TDS/Service Tax/Write off/Retention Money","","",7,20,150);
		Menu4_5_1=new Array("Client Wise Un-Posted/Partly Posted Cheques","Reports/pfrmCustomerAdvance.aspx?ACTION=B","",0,20,270);
		Menu4_5_2=new Array("Remittance Reports","Reports/rptRemittances.aspx?action=R","",0,20,250);
		Menu4_5_3=new Array("Transfer & Receipts","","",4,20,250);
				Menu4_5_3_1=new Array("Amount Adjustments of Old System","Reports/pfrmFromToDate.aspx?ACTION=BATOS","",0,20,250);
				Menu4_5_3_2=new Array("Amount Transfered To Other Regions","Reports/pfrmFromToDate.aspx?ACTION=ATTR","",0,20,250);
				Menu4_5_3_3=new Array("Miscellaneous Adjustments","Reports/pfrmFromToDate.aspx?ACTION=MA","",0,20,250);
				Menu4_5_3_4=new Array("Amount Received From Other Regions","Reports/pfrmFromToDate.aspx?ACTION=ARFR","",0,20,250);
		Menu4_5_4=new Array("EFT Report","Reports/pfrmFromToDate.aspx?action=EFT","",0,20,250);
		Menu4_5_5=new Array("TDS deducted against the Bills","Reports/pfrmFromToDate.aspx?ACTION=TDS","",0,20,250);		
		//Menu4_5_6=new Array("Service Tax Report","Reports/pfrmFromToDate.aspx?ACTION=STAX","",0,20,250);	
		Menu4_5_6=new Array("Write off Details","Reports/pfrmFromToDate.aspx?ACTION=WOF","",0,20,250);	
		Menu4_5_7=new Array("Retention Money","Reports/pfrmFromToDate.aspx?ACTION=RET","",0,20,250);	
	Menu4_6=new Array("Management Reports(IE Performance/PCDO/Billing Analysis etc.)","","",32,20,150);		
			Menu4_6_1=new Array("IE Performance","Reports/pfrmFromToDate.aspx?action=IE_X","",0,20,300);
			Menu4_6_2=new Array("CLUSTER Performance-> Under Testing","Reports/pfrmFromToDate.aspx?action=CLUSTER_X","",0,20,300);
			Menu4_6_3=new Array("PCDO","","",2,20,200);
				Menu4_6_3_1=new Array("Major Traction Items","Reports/prmMthYR.aspx?action=Items","",0,20,200);
				Menu4_6_3_2=new Array("IE performance Summary","Reports/prmMthYR.aspx?action=IE_L","",0,20,200);
			Menu4_6_4=new Array("Billing Analysis","Reports/pfrmFromToDate.aspx?ACTION=BA","",0,20,200);
			Menu4_6_5=new Array("Client Wise Billing & Realisation against the Biils","Reports/rptBillRaised.aspx?ACTION=R","",0,20,300);
			Menu4_6_6=new Array("Client Wise Comparison of Inspection Fee","Reports/pfrmFeeComparision.aspx?ACTION=CL_COMP","",0,20,250);
			Menu4_6_7=new Array("Client Wise Inspection Fee,Material value and Calls","Reports/pfrmFeeComparision.aspx?ACTION=CL_COMP_MIC","",0,20,250);
			Menu4_6_8=new Array("Region Wise Billing Summary","Reports/rptBillRaised.aspx?ACTION=RWB","",0,20,250);
			Menu4_6_9=new Array("Region Wise Comparison of Outstanding and Suspense","Reports/rptOutstanding.aspx?action=R","",0,30,300);
			Menu4_6_10=new Array("Client & Region Wise Billing Summary","Reports/rptBillRaised.aspx?ACTION=CRWB","",0,20,300);
			Menu4_6_11=new Array("Summary Of Client wise Calls Attended Beyond 7 Days","Reports/pfrmReciepts.aspx?ACTION=CALLS","",0,30,200);
			Menu4_6_12=new Array("IC Submission Report","Reports/pfrmFromToDate.aspx?ACTION=ICSUBMIT","",0,20,200);
			Menu4_6_13=new Array("Pending IC's against Calls whose material has been Accepted or Rejected and Pending","Reports/pfrmFromToDate.aspx?ACTION=CALLSWITHOUTIC","",0,30,200);
			Menu4_6_14=new Array("Client Wise No Of PO's and their Value","Reports/pfrmFromToDate.aspx?ACTION=CWPOANDVALUE","",0,30,200);
			Menu4_6_15=new Array("IE Dairy","Reports/pfrmIEDairy.aspx?ACTION=E","",0,20,200)
			Menu4_6_16=new Array("Super Surprise","","",2,20,200);
				Menu4_6_16_1=new Array("Super Surprise Details","Reports/pfrmFromToDate.aspx?ACTION=SUPSUR","",0,20,200)
				Menu4_6_16_2=new Array("CO Wise Super Surprise Summary","Reports/pfrmFromToDate.aspx?ACTION=SUPSURPSUMM","",0,20,200)
			Menu4_6_17=new Array("Summary of IE wise Call Status Updated","Reports/pfrmFromToDate.aspx?action=CIEU","",0,20,200);
			Menu4_6_18=new Array("Online Consignee Rejections Report","Reports/pfrmOnlineConRejReport.aspx","",0,20,200);
			Menu4_6_19=new Array("Outstanding of One Region Over Other Regions","Reports/rptOutstanding.aspx?action=X","",0,20,300);	
			Menu4_6_20=new Array("Summary of IE Wise Calls Attended Within 2 & 5 Days","Reports/pfrmFromToDate.aspx?action=CALLSATTENDED2DAYS","",0,30,300);	
			Menu4_6_21=new Array("Cases of First Visit Date after Likely Inspection Date","Reports/pfrmFromToDate.aspx?ACTION=AFTEREXPDT","",0,20,200);	
			Menu4_6_22=new Array("Client wise Rejection IC's (All Regions)","Reports/pfrmCallDetailsClientWise.aspx?ACTION=CLIENTWISEREJ","",0,20,200);	
			Menu4_6_23=new Array("Summary of Cases where First Visit Date after Likely Inspection Date (Region Wise)","Reports/pfrmFromToDate.aspx?ACTION=SUMMARYAFTEREXPDT","",0,30,200);	
			Menu4_6_24=new Array("Format for Non Conformity Report (IE WISE)","Reports/rptNCRReport.aspx","",0,30,200);	
			Menu4_6_25=new Array("CM/IE wise Performance","Reports/pfrmIECMPerformance.aspx","",0,30,200);
			Menu4_6_26=new Array("Overdue/Pending Calls","Reports/prmOverdue_Pending.aspx","",0,30,200);
			Menu4_6_27=new Array("IBS and SAP Billing Comprision","Reports/prmMthYR.aspx?action=COMP_BILLING","",0,20,200);
			Menu4_6_28=new Array("IBS and SAP Realisation Comprision","Reports/prmMthYR.aspx?action=COMP_REALISATION","",0,20,200);	
			Menu4_6_29=new Array("CM and IE wise IC issued but not recieved","Reports/pfrmFromToDate.aspx?action=COUNTIC","",0,20,200);	
			Menu4_6_30=new Array("Tentative Inspection Fee Wise Pending Call","Reports/pfrmFromToDate.aspx?action=HIGHVALUE","",0,20,200);
			Menu4_6_31=new Array("Call Remarking","Reports/pfrmFromToDate.aspx?action=REMARKING","",0,20,200);		
			Menu4_6_32=new Array("Call Details Dashborad","Reports/Call_Details_Status.aspx","",0,20,200);									
			
	Menu4_7=new Array("Monthly Reports(Customer Ledger/IC Accountal/IC Status/Missing IC)","","",4,20,150);		
			Menu4_7_1=new Array("Customer Ledger","Reports/pfrmCustomerLedger.aspx","",0,20,150);   
			Menu4_7_2=new Array("IC Accountal","","",2,20,150);
				Menu4_7_2_1=new Array("Summary of Missing ICs","Reports/pfrmICAccountal.aspx?ACTION=MISSING","",0,20,150);
				Menu4_7_2_2=new Array("Status of All ICs","Reports/pfrmICAccountal.aspx?ACTION=ICSTATUS","",0,20,150);
			Menu4_7_3=new Array("Rejection ICs","Reports/pfrmFromToDate.aspx?ACTION=Rejection","",0,20,150);		
			Menu4_7_4=new Array("Re-Inspection ICs","Reports/pfrmFromToDate.aspx?ACTION=Reinspection","",0,20,150);		
	Menu4_8=new Array("Realisation/Payments","","",4,20,150);	
			Menu4_8_1=new Array("Client/BPO Wise Receipts","Reports/pfrmReciepts.aspx?ACTION=R","",0,20,250);
			Menu4_8_2=new Array("Client Wise Realisation For the Period","Reports/rptBillRaised.aspx?ACTION=CWR","",0,20,250);
			Menu4_8_3=new Array("Summary of Online Payments","Reports/pfrmFromToDate.aspx?action=ONLINENRPAYMENTS","",0,20,250);	
			Menu4_8_4=new Array("Summary of CRIS-RLY Payments","Reports/pfrmCrisPayementRec.aspx?ACTION=C","",0,20,250);	
	Menu4_9=new Array("Consignee Complaints Reports","","",4,20,200);
				Menu4_9_1=new Array("Consignee Complaints For The Period","Reports/pfrmCompliants.aspx?ACTION=U","",0,20,350);
				Menu4_9_2=new Array("Summary Of Consignee Complaints where JI Required","Reports/pfrmComplaintsJIRequiredReport.aspx?ACTION=","",0,20,350);
				Menu4_9_3=new Array("JI Topsheet","Reports/pfrmJI_Topsheet.aspx","",0,20,350);
				Menu4_9_4=new Array("Corporate Reports","","",5,20,350);
				    Menu4_9_4_1=new Array("Summarized Position Consignee Rejection (Region Wise)","Reports/CO_ComplaintJIRequired.aspx?ACTION=","",0,35,350);
					Menu4_9_4_2=new Array("Defect Code Wise Analysis of Complaints","Reports/pfrmFromToDate.aspx?ACTION=DCWACOMPS","",0,20,350);	
					Menu4_9_4_3=new Array("Classification/Defect Code Wise Statement OR Comulative Statement of Cases for the Month","Reports/pfrmCompliants.aspx?ACTION=CORP","",0,35,350);	
					Menu4_9_4_4=new Array("Top 'N' High Value Inspections","Reports/rptHighValueBills.aspx?ACTION=","",0,20,200);
					Menu4_9_4_5=new Array("Summarized Position Of Cases of Complaints where JI Required (IE/CM/Client/Consignee/Vendor Wise)","Reports/pfrmComplaintsJIRequiredReport.aspx?ACTION=","",0,35,350);
					
	Menu4_10=new Array("Queries","","",3,20,150);	
			Menu4_10_1=new Array("Purchase Orders of Specific Values","","",2,20,250);
				Menu4_10_1_1=new Array("Detailed Report - P O of Specific Values","Reports/pfrmPOValues.aspx?Action=D","",0,20,250);
				Menu4_10_1_2=new Array("Summary Report - P O of Specific Values","Reports/pfrmPOValues.aspx?Action=S","",0,20,250);
			Menu4_10_2=new Array("Item Wise Inspections","Reports/rptItemWiseInspectionDetails.aspx","",0,20,250);
			Menu4_10_3=new Array("Item Wise Inspections For Tender Queries","Reports/rptItemWiseInspectionDetails.aspx?ACTION=C","",0,20,250);
	Menu4_11=new Array("Master Item Checksheets Reports","","",4,20,150);
			Menu4_11_1=new Array("Rly Item details where Master Checksheets are not linked","Reports/pfrmFromToDate.aspx?ACTION=PLEXCEPT","",0,30,200);		
			Menu4_11_2=new Array("Rly Item details where Master Checksheets are linked","Reports/pfrmFromToDate.aspx?ACTION=PLLINKED","",0,30,200);	
			Menu4_11_3=new Array("Details of Items in Rly Calls where Master Checksheets are not linked","Reports/pfrmFromToDate.aspx?ACTION=CALLEXCEPT","",0,30,200);	
			Menu4_11_4=new Array("Details of PL's Linked with Master Checksheets","Reports/pfrmFromToDate.aspx?ACTION=PLLINKEDCHK","",0,30,200);	
	Menu4_12=new Array("PCDO","","",22,20,150);
	    Menu4_12_1=new Array("CO Highlights","Reports/prmMthYR.aspx?action=QI_CO","",0,20,200);
	    Menu4_12_2=new Array("Highlights","Reports/prmMthYR.aspx?action=QI_HIG","",0,20,200);	
	    Menu4_12_3=new Array("Annexure-I Financial(Billing)","Reports/prmMthYR.aspx?action=QI_FS","",0,30,200);
	    Menu4_12_4=new Array("Annexure-I Financial(Expenditure & Realization)","Reports/prmMthYR.aspx?action=QI_ER","",0,30,200);
	    Menu4_12_5=new Array("Annexure-I Financial(Outstanding)","Reports/prmMthYR.aspx?action=QI_FOS","",0,20,200);
	    Menu4_12_6=new Array("Annexure-II Business Development - EOI/Priced Offers Sent","Reports/prmMthYR.aspx?action=QI_OFFER_SENT","",0,40,200);	
		Menu4_12_7=new Array("Annexure-II Business Development - Contracts Secured","Reports/prmMthYR.aspx?action=QI_CON_SECU","",0,35,200);	
		Menu4_12_8=new Array("Annexure-II Business Development - BD Efforts","Reports/prmMthYR.aspx?action=QI_BD","",0,35,200);	
		Menu4_12_9=new Array("Annexure-II Business Development - Previous offers still under consideration","Reports/prmMthYR.aspx?action=QI_PRE_OFFER_SENT","",0,40,200);	
		Menu4_12_10=new Array("Annexure-III Progress of Check sheets","Reports/prmMthYR.aspx?action=QI_PCS","",0,30,200);
	    Menu4_12_11=new Array("Annexure-IV Complaints","Reports/prmMthYR.aspx?action=QI_COM","",0,20,200);
		Menu4_12_12=new Array("Annexure-V Quality of Inspection","Reports/prmMthYR.aspx?action=QI_Axur","",0,20,200);
		Menu4_12_13=new Array("Annexure-V Quality of Inspection(Central)","Reports/prmMthYR.aspx?action=QI_CentralInsp","",0,30,200);
		Menu4_12_14=new Array("Annexure-VI Improvement of Quality of Service","Reports/prmMthYR.aspx?action=QI_IQS","",0,30,200);
		Menu4_12_15=new Array("Annexure-VII Outstanding Railways ","Reports/prmMthYR.aspx?action=QI_OR","",0,30,200);
		Menu4_12_16=new Array("Annexure-VII Outstanding Non-Railways","Reports/prmMthYR.aspx?action=QI_ONR","",0,30,200);
		Menu4_12_17=new Array("Annexure-VII Top 5 Outstanding Railway & Non-Railways","Reports/prmMthYR.aspx?action=QI_TOP","",0,30,200);
		Menu4_12_18=new Array("Annexure-VIII Client Contact","Reports/prmMthYR.aspx?action=QI_CC","",0,20,200);
		Menu4_12_19=new Array("Annexure-VIII DFO Visit","Reports/prmMthYR.aspx?action=QI_DFO","",0,20,200);
		Menu4_12_20=new Array("Annexure-IX Training","Reports/prmMthYR.aspx?action=QI_TRA","",0,20,200);
		Menu4_12_21=new Array("Annexure-X Technical References","Reports/prmMthYR.aspx?action=QI_TRS","",0,20,200);
		Menu4_12_22=new Array("PCDO Summary","Reports/prmMthYR.aspx?action=PCDO_SUM","",0,20,200);
		
	Menu4_13=new Array("Other Reports","","",35,20,150);
			//	 Menu4_5=new Array("Inspection Details","Reports/pfrmBPO_Wise_Bills.aspx?Action=ID","",0,20,250);    
			Menu4_13_1=new Array("Book Sets Issued to IE","Reports/pfrmBookSet.aspx","",0,20,320);  
			Menu4_13_2=new Array("Controlling Officer Wise IE","Reports/rptIEAccToCO.aspx","",0,20,200);
			Menu4_13_3=new Array("Top 'N' High Value Inspections","Reports/rptHighValueBills.aspx?ACTION=","",0,20,200);
			Menu4_13_4=new Array("Details Of Customer Advance","Reports/pfrmCustomerAdvance.aspx?ACTION=A","",0,20,200);
			Menu4_13_5=new Array("Bill Details for Document management System","Reports/rptDocManagement.aspx","",0,20,200);
			Menu4_13_6=new Array("Case Wise Purchase Order Status","Query/qryUnInspectedQty.aspx?ACTION=UIQ","",0,20,200);
			Menu4_13_7=new Array("Client Wise Contract Review Statement","Reports/pfrmFromToDate.aspx?action=CR","",0,20,200);
			Menu4_13_8=new Array("Vendor Wise Available Advance And Pending Bills","Reports/pfrmCustomerAdvance.aspx?ACTION=PB","",0,20,200);
			Menu4_13_9=new Array("Vendor Wise Advance Received And Bills Posted","Reports/pfrmCustomerAdvance.aspx?ACTION=AB","",0,20,200);
			Menu4_13_10=new Array("Client Wise Bills & Their Call Letter Nos","Reports/pfrmCallDetailsClientWise.aspx?ACTION=CALLETTERNOSTATEMENT","",0,20,200);
			Menu4_13_11=new Array("Voucher Wise No. of CHQ's & Their Value","Reports/pfrmFromToDate.aspx?ACTION=VOUCHERDETAILS","",0,20,200);
			Menu4_13_12=new Array("Case History","Query/qryUnInspectedQty.aspx?ACTION=CH","",0,20,200);
			//Menu4_10_19=new Array("Photo Enclosed Report Thru IC","Reports/pfrmPhotoEnclosed.aspx?Action=I","",0,20,300);  
			Menu4_13_13=new Array("Photo Upload Report","Reports/pfrmPhotoEnclosed.aspx?Action=C","",0,20,300);  
			Menu4_13_14=new Array("Controlling Manager Wise Allocated IE's Calls Marked","Reports/pfrmCOIEWiseCalls.aspx","",0,20,300);  
			Menu4_13_15=new Array("NCR Report","","",2,20,300);  
				Menu4_13_15_1=new Array("NCR Report Controlling Wise","Reports/pfrmNCR.aspx?rep=C","",0,20,350);
				Menu4_13_15_2=new Array("NCR Report IE Wise","Reports/pfrmNCR.aspx?rep=I","",0,20,350);
			Menu4_13_16=new Array("Daily IE Work Plan Report","Reports/pfrmIEWorkPlan.aspx?ACTION=U","",0,20,300);  
			Menu4_13_17=new Array("Daily IE Work Plan Exception Report","Reports/pfrmIEWorkPlan.aspx?ACTION=E","",0,20,300);  
			Menu4_13_18=new Array("Download/View Photo Uploaded","IE_IC_Photo_Enclosed.aspx","",0,20,150); 
			Menu4_13_19=new Array("IE Claim Report","Reports/pfrmIEClaimReport.aspx","",0,20,250);
			Menu4_13_20=new Array("Details of Bills Not Scanned (NR)","Reports/pfrmFromToDate.aspx?ACTION=BSS","",0,20,250);
			Menu4_13_21=new Array("Summary of IE Wise Sealing Pattern Status","Reports/pfrmFromToDate.aspx?ACTION=STAMP","",0,20,250);
			Menu4_13_22=new Array("Call Return Report","Reports/pfrmFromToDate.aspx?ACTION=CLRETURN","",0,20,250);
			Menu4_13_23=new Array("IE Signature Report","Reports/pfrmIESignatureReport.aspx","",0,20,250);
			Menu4_13_24=new Array("IBS Daily Report","Reports/pfrmIBSDailyReport.aspx","",0,20,250);
			Menu4_13_25=new Array("IE Wise Training Details","Reports/pfrmTrainingDetails.aspx","",0,20,250);
			Menu4_13_26=new Array("IE Wise Training Details-Excel","Training_Excel.aspx","",0,20,250);
			Menu4_13_27=new Array("IBS Weekly Commulative Report","Reports/pfrmIBSWeeklyReport.aspx","",0,20,250);
			Menu4_13_28=new Array("Ongoing Contracts","Reports/pfrmOngoing_Contracts.aspx","",0,20,250);
			Menu4_13_29=new Array("Contracts","Reports/prmOLD_Contract_Rep.aspx","",0,20,250);
			Menu4_13_30=new Array("Cluster, Vendor & IE Mapping ","VENDERCLUSTERIE.aspx","",0,20,250);
			Menu4_13_31=new Array("IE'S Alternate IE Mapping ","IE_ALTIE_REPORT.aspx","",0,20,250);
			Menu4_13_32=new Array("Vendor's Performance Report ","Reports/pfrmVendorPerformance.aspx","",0,20,250);
			Menu4_13_33=new Array("Vendor's Feedback Report ","Reports/pfrmFeedback_Report.aspx?ACTION=VENDOR","",0,20,250);
			Menu4_13_34=new Array("Period Wise Report","","",2,20,300);
			       Menu4_13_34_1=new Array("Period Wise Progress of Checksheet","Reports/pfrmFromToDate.aspx?Action=CHECK","",0,20,250);
			       Menu4_13_34_2=new Array("Period Wise Technical References","Reports/pfrmFromToDate.aspx?Action=TECH","",0,20,250);
			Menu4_13_35=new Array("Summary of IEs DSC Getting Expired","Reports/rptCalls_NR.aspx?action=2","",0,20,200);  
		Menu5=new Array("QA MANUAL & PROCEDURES","Quality_Manual_Procedures.aspx","",0,20,170);	
		//	 Menu4_28=new Array("Controlling Officers Wise Call Status","Reports/pfrmCallsStatus.aspx","",0,20,250);
		//	 Menu4_36=new Array("Periodic Breakup of Client Wise Outstanding","Reports/rptPeriodicOutstanding.aspx","",0,20,250);
//	Menu4_10=new Array("Outstanding Reports For Audit","","",2,20,150);
//			Menu4_10_1=new Array("Age Wise Breakup of Client Wise Outstanding Statement For 2008-09 Audit","Reports/rptOutstanding.aspx?action=A","",0,20,450);
//			Menu4_10_2=new Array("Un-Posted/Partly Posted Instruments upto 31-March-2009 (For 2008-09 Audit)","Query/rptAudit.aspx","",0,20,450);
//*********************** Ending of Menu ********************************
		function IsPopupBlocker()
		 {
			var oWin = window.open("","testpopupblocker","width=100,height=50,top=5000,left=5000");
			if (oWin==null || typeof(oWin)=="undefined")
			{
				return true;
			} else
			{
				oWin.close();
				return false;
			}
		 }

		</script>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </HEAD>
	<body text="navy">
		<script type='text/javascript'>

//HV Menu- by Ger Versluis (http://www.burmees.nl/)
//Submitted to Dynamic Drive (http://www.dynamicdrive.com)
//Visit http://www.dynamicdrive.com for this script and more

function Go(){return}

		</script>
		<script type='text/javascript' src='menu_com.js'></script>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 100%"
				cellSpacing="1" cellPadding="1" width="100%" border="0" align="center">
				<TR>
					<TD align="center" style="WIDTH: 100%;HEIGHT: 10%">
						<P>
							<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></P>
					</TD>
				</TR>
				<TR>
					<td align="center" valign="top" style="WIDTH: 100%;HEIGHT: 80%">
						<P><FONT style="FONT-WEIGHT: bold; LINE-HEIGHT: 8pt; TEXT-ALIGN: center" color="darkblue"
								size="3"></FONT>&nbsp;</P>
      <P><FONT style="FONT-WEIGHT: bold; LINE-HEIGHT: 8pt; TEXT-ALIGN: center" 
      color=darkblue size=3>MAIN MENU</FONT></P>
						<P>&nbsp;</P>
					</td>
				</TR>
				<TR>
					<td align="center" valign="top" style="WIDTH: 100%;HEIGHT: 10%">
						<P>
							<MARQUEE id="m1" dataFormatAs="html" style="FONT-WEIGHT: bold; FONT-SIZE: 10pt; FONT-FAMILY: Verdana; HEIGHT: 100%; TEXT-ALIGN: center"
								scrollDelay="125" width="90%">
								<P>
									<asp:label id="lblMessage" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
										ForeColor="DarkBlue" Width="100%" Height="100%" style="TEXT-ALIGN: left" BackColor="InactiveCaptionText"
										Visible="False"></asp:label></P>
							</MARQUEE>
						</P>
					</td>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
