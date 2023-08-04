<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CR_Bill_Search_Form.aspx.cs" Inherits="RBS.CR_Bill_Search_Form.CR_Bill_Search_Form" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>BILL FORM</title>
<meta content="Microsoft Visual Studio .NET 7.1" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content=JavaScript name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
<script src="date.js"></script>

<script language=javascript>		 
		function search()
		{
		 if(trimAll(document.Form1.txtBillNo.value)=="" && trimAll(document.Form1.txtBillDate.value)=="")
		 {
			alert("Please Enter Bill No / Bill Date");
			event.returnValue=false;
		 }
		 else
		 return;			 
		}
		function validate()
		{
		 if(trimAll(document.Form1.txtBillNo.value)=="" && trimAll(document.Form1.txtBillDate.value)=="")
		 {
			alert("Bill No or Bill Date must be entered");
			event.returnValue=false;
		 }
		 else
		 return;			 
		}	
		function txtCopy()
		{
			
			if(check_date(document.Form1.frmDt)==true && trimAll(document.Form1.toDt.value)=="")
			{
				document.Form1.toDt.value=document.Form1.frmDt.value;
			}
			
		}
		function validate1()
		{
			if(document.Form1.frmDt=="[object]" && trimAll(document.Form1.frmDt.value)=="")
			{
				alert("You Cannot Leave From Date Blank!!!");
				event.returnValue=false;
			}
		}
		
</script>
</HEAD>
<body>
<form id=Form1 method=post runat="server"><asp:panel 
id=Panel_1 style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server" Width="100%" Height="1px" Visible="False">
<asp:Button id=btnPrint runat="server" Text="Print" onclick="btnPrint_Click"></asp:Button>
<asp:Button id=btnBack runat="server" Text="Go Back" onclick="btnBack_Click"></asp:Button></asp:panel><asp:panel 
id=Panel_2 style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 8px" runat="server" Width="100%" Height="1px">
<TABLE id=Table3 
style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px" 
cellSpacing=1 cellPadding=1 width="100%" border=0>
  <TR>
    <TD align=center>
<uc1:webusercontrol1 id=WebUserControl11 runat="server"></uc1:webusercontrol1></TD></TR>
  <TR align=center>
    <TD><FONT color=#3300cc><FONT face=Arial color=#000099 
      size=2><STRONG><U>BILL FORM&nbsp;</U></STRONG></FONT></FONT></TD></TR>
  <TR>
    <TD style="HEIGHT: 108px">
      <P align=center>
      <TABLE id=Table2 style="HEIGHT: 52px" borderColor=#bfcbe3 cellSpacing=1 
      cellPadding=1 width="70%" bgColor=#f0f8ff border=1>
        <TR align=center>
          <TD style="WIDTH: 41.5%" align=center colSpan=2><STRONG><FONT 
            face=Verdana color=#000099 size=2>Bill No</FONT></STRONG></TD>
          <TD style="HEIGHT: 17px"><STRONG><FONT face=Verdana color=#000099 
            size=2>Bill Date</FONT></STRONG></TD></TR>
        <TR align=center>
          <TD align=center colSpan=2>
<asp:textbox id=txtBillNo tabIndex=1 runat="server" Font-Size="8pt" ForeColor="DarkBlue" Width="35%" MaxLength="30" BackColor="White"></asp:textbox></TD>
          <TD align=center colSpan=2>
<asp:textbox id=txtBillDate onblur=check_date(txtBillDate); tabIndex=1 runat="server" Font-Size="8pt" ForeColor="DarkBlue" Width="35%" MaxLength="10" BackColor="White"></asp:textbox></TD></TR></TABLE>
<asp:label id=Label1 runat="server" Font-Size="7.8pt" ForeColor="DarkMagenta" Width="511px" Font-Bold="True" Font-Names="Verdana"> To Search/Modify/Delete Bill -> Enter Bill No / Bill Date and click on [Search] button and then select the desired record.</asp:label>
<asp:label id=Label2 runat="server" Font-Size="7.8pt" ForeColor="DarkMagenta" Width="100%" Font-Bold="True" Font-Names="Verdana"> Click on [Add] button for new Bill</asp:label></P></TD></TR>
  <TR align=center>
    <TD>
<asp:button id=btnAdd tabIndex=4 runat="server" Font-Size="8pt" ForeColor="DarkBlue" Width="46px" Font-Bold="True" Font-Names="Verdana" Text="Add" onclick="btnAdd_Click"></asp:button>
<asp:button id=btnSearchIC tabIndex=7 runat="server" Font-Size="8pt" ForeColor="DarkBlue" Font-Bold="True" Font-Names="Verdana" Text="Search" onclick="btnSearchIC_Click"></asp:button></TD></TR>
  <TR>
    <TD align=center>
<asp:datagrid id=grdBook runat="server" Font-Size="8pt" Width="100%" Font-Names="Verdana" Height="96px" BorderColor="DarkBlue" BorderStyle="Groove" AutoGenerateColumns="False">
								<AlternatingItemStyle BackColor="#CCCCFF"></AlternatingItemStyle>
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
								<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center" ForeColor="DarkBlue"
									VerticalAlign="Middle" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn>
										<ItemTemplate>
											<asp:HyperLink id=Hyperlink2 NavigateUrl='<%#"CR_Bill_Form.aspx?BILL_NO="+DataBinder.Eval(Container.DataItem,"BILL_NO")%>' Runat="server">Select</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="BILL_NO" HeaderText="Bill No"></asp:BoundColumn>
									<asp:BoundColumn DataField="BILL_DT" HeaderText="Bill Date"></asp:BoundColumn>
									<asp:BoundColumn DataField="BILL_AMOUNT" HeaderText="Total Fee"></asp:BoundColumn>
									<asp:BoundColumn DataField="IC_NO" HeaderText="IC No."></asp:BoundColumn>
									<asp:BoundColumn DataField="IC_DT" HeaderText="IC Date"></asp:BoundColumn>
								</Columns>
							</asp:datagrid></TD></TR>
  <TR>
    <TD align=center>
      <TABLE borderColor=#bfcbe3 bgColor=#f0f8ff border=1>
        <TR bgColor=#f0f8ff>
          <TD style="WIDTH: 33.09%; HEIGHT: 35px" align=right><B><FONT 
            face=Verdana color=darkblue size=2>List Of Bills For The Period 
            --&gt;</FONT></B></TD>
          <TD style="WIDTH: 10.52%; HEIGHT: 35px" align=center><B><FONT 
            face=Verdana color=darkblue size=2>From</FONT></B></TD>
          <TD style="WIDTH: 13.97%; HEIGHT: 35px">
<asp:textbox id=frmDt onblur="check_date(frmDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');" style="TEXT-ALIGN: center" tabIndex=8 runat="server" Font-Size="8pt" ForeColor="DarkBlue" Width="100px" MaxLength="10" Font-Names="Verdana" Height="20px"></asp:textbox></TD>
          <TD style="WIDTH: 6.76%; HEIGHT: 35px" align=center><B><FONT 
            face=Verdana color=darkblue size=2>To</FONT></B></TD>
          <TD style="WIDTH: 30%; HEIGHT: 35px">
<asp:textbox id=toDt onblur="check_date(toDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');txtCopy();" style="TEXT-ALIGN: center" tabIndex=9 runat="server" Font-Size="8pt" ForeColor="DarkBlue" Width="100px" MaxLength="10" Font-Names="Verdana" Height="20px"></asp:textbox></TD></TR>
        <TR bgColor=#f0f8ff>
          <TD align=center colSpan=5>
<asp:button id=btnSubmit tabIndex=10 runat="server" ForeColor="DarkBlue" BackColor="#C0C0FF" Font-Bold="True" Text="Submit" onclick="btnSubmit_Click"></asp:button></TD></TR></TABLE></TD></TR></TABLE></asp:panel></FORM>
	</body>
</HTML>
