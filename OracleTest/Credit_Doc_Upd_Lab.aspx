<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Credit_Doc_Upd_Lab.aspx.cs" Inherits="RBS.Credit_Doc_Upd_Lab.Credit_Doc_Upd_Lab" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Credit_Doc_Upd_Lab</title>
<meta content="Microsoft Visual Studio .NET 7.1" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content=JavaScript name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
<script src="date.js"></script>

<script language=javascript>
		function validate1()
		{		
		if(trimAll(document.Form1.txtInvoiceno.value)=="")
		{
		 alert("Kindly select Invoice No");
		 event.returnValue=false;
		 }
		 else
		return;
		}
		function validate()
		{		
		if(trimAll(document.Form1.Text_doc.value)=="" || trimAll(document.Form1.txtInvoiceDt.value)=="")
		{
		 alert("Kindly Enter Document No. & Invoice Date");
		 event.returnValue=false;
		 }
		 else
		return;
		}
</script>
</HEAD>
<body>
<form id=Form1 method=post runat="server">
<TABLE id=Table1 
style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px" 
cellSpacing=1 cellPadding=1 width="100%" border=0>
  <TR>
    <TD style="HEIGHT: 17px" align=center height=17><uc1:webusercontrol1 id=WebUserControl11 runat="server"></uc1:webusercontrol1></TD></TR>
  <TR>
    <TD style="HEIGHT: 22px" align=center colSpan=5>
      <P><asp:label id=Label1 runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Bold="True" BackColor="White" ForeColor="DarkBlue" Width="80%">UPDATE SAP DOCUMENT ID IN LAB CREDIT NOTE</asp:label></P></TD></TR>
  <TR>
    <TD style="WIDTH: 100%" align=center>
      <TABLE id=Table2 style="WIDTH: 100%; HEIGHT: 70%" borderColor=#b0c4de 
      cellSpacing=1 cellPadding=1 border=1>
        <TBODY>
        <TR>
          <TD style="WIDTH: 50%; HEIGHT: 36px" align=right><asp:label id=Label2 runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" ForeColor="DarkBlue" Width="105px">Invoice No.</asp:label></TD>
          <TD style="WIDTH: 50%; HEIGHT: 36px"><asp:textbox id=txtInvoiceno tabIndex=3 runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="150px" Height="20px" MaxLength="14"></asp:textbox></TD></TR></TBODY></TABLE></TD>
  <TR>
    <TD style="HEIGHT: 21px" align=center><asp:button id=btnSearch tabIndex=13 runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" ForeColor="DarkBlue" Width="65px" Text="Search" onclick="btnSearch_Click"></asp:button></TD></TR>
  <TR>
    <TD style="HEIGHT: 15px">
      <P align=center><asp:label id=Label4 runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" ForeColor="OrangeRed" Width="384px" Visible="False">NO RECORD FOUND FOR THE GIVEN SEARCH CRITERIA!!!</asp:label></P></TD></TR>
  <TR>
    <TD id=Table_Details_Credit style="HEIGHT: 50px" align=center colSpan=5 
    runat="server" visible="False">
      <TABLE id=Table_Details_For_Credit style="WIDTH: 90%; HEIGHT: 32px" 
      borderColor=#b0c4de cellSpacing=1 cellPadding=1 bgColor=#f0f8ff border=1 
      >
        <TR>
          <TD style="WIDTH: 10%; HEIGHT: 19px" vAlign=top><asp:label id=Label7 runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" ForeColor="DarkBlue" Width="100%">Credit Invoice No</asp:label></TD>
          <TD style="WIDTH: 16%; HEIGHT: 19px" vAlign=top><asp:label id=Label8 runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" ForeColor="OrangeRed" Width="100%"></asp:label></TD>
          <TD style="WIDTH: 10%; HEIGHT: 19px" vAlign=top><asp:label id=Label18 runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" ForeColor="DarkBlue" Width="100%">Invoice Date.</asp:label></TD>
          <TD style="WIDTH: 20%; HEIGHT: 19px" vAlign=top><asp:label id=Label_in runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" ForeColor="OrangeRed" Width="100%"></asp:label></TD>
          <TD style="WIDTH: 10%; HEIGHT: 19px" vAlign=top><asp:label id=Label20 runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" ForeColor="DarkBlue" Width="100%">Case No.</asp:label></TD>
          <TD style="WIDTH: 20%; HEIGHT: 19px" vAlign=top><asp:label id=Label_id runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" ForeColor="OrangeRed" Width="100%"></asp:label></TD>
          <TD style="WIDTH: 10%; HEIGHT: 19px" vAlign=top><asp:label id=Label22 runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" ForeColor="DarkBlue" Width="100%">Bill Amt</asp:label></TD>
          <TD style="WIDTH: 28%; HEIGHT: 19px" vAlign=top><asp:label id=Label_im runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" ForeColor="OrangeRed" Width="100%"></asp:label></TD></TR></TABLE></TD></TR>
  <TR>
    <TD id=Table_doc style="WIDTH: 100%" align=center runat="server" 
     visible="False">
      <TABLE style="WIDTH: 100%; HEIGHT: 70%" borderColor=#b0c4de cellSpacing=1 
      cellPadding=1 border=1>
        <TBODY>
        <TR>
          <TD style="WIDTH: 50%; HEIGHT: 36px" align=right><asp:label id=Label3 runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" ForeColor="DarkBlue" Width="105px">Document No.</asp:label><asp:textbox id=Text_doc tabIndex=3 runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="150px" Height="20px" MaxLength="12"></asp:textbox></TD>
          <TD style="WIDTH: 50%; HEIGHT: 36px" 
            >&nbsp;&nbsp; 
<asp:label id=Label5 runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" ForeColor="DarkBlue" Width="105px">Invoice Date Entered in SAP</asp:label>
<asp:textbox id=txtInvoiceDt Onblur="check_date(txtInvoiceDt);" tabIndex=3 runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="150px" Height="20px" MaxLength="10"></asp:textbox></TD></TR></TBODY></TABLE></TD>
  <TR>
    <TD style="HEIGHT: 21px" align=center><asp:button id=Btn_upd tabIndex=13 runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True" ForeColor="DarkBlue" Width="65px" Text="Save" Visible="False" onclick="Btn_upd_Click"></asp:button></TD></TR></TABLE></TD></TR></TABLE></FORM>
	</body>
</HTML>
