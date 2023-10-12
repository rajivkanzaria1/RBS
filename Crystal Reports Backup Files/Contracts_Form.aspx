<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contracts_Form.aspx.cs" Inherits="RBS.Contracts_Form.Contracts_Form" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Contracts_Form</title>
<meta name=GENERATOR content="Microsoft Visual Studio .NET 7.1">
<meta name=CODE_LANGUAGE content=C#>
<meta name=vs_defaultClientScript content=JavaScript>
<meta name=vs_targetSchema content=http://schemas.microsoft.com/intellisense/ie5>
<script src="date.js"></script>

<script language=javascript>
		function validate()
		{
		
		if(document.Form1.txtClient.value=="")
		 {
		 alert("CLIENT NAME CANNOT BE LEFT BLANK");
		 event.returnValue=false;
		 }
		else if(document.Form1.txtConFee.value!="" && isNaN(parseInt(document.Form1.txtConFee))==false) 
		 {
		 alert("CONTRACT FEE CONTAINS INVALID CHARACTERS.");
		 event.returnValue=false;		
		 }
		else
		{
		document.Form1.btnSave.style.visibility = 'hidden';
		 alert("YOUR RECORD IS SAVED")
		}
		 return;
				 		 
		}
		
		function del()
		{
		var d=confirm("Click OK to Confirm Delete!!!");
		if(d==true)
		event.returnValue=true;
		else
		event.returnValue=false;
		}
		 
		 function del2()
		 {
		  if(document.Form1.txtCityCD.value=="")
		 {
		 alert("PLZ ENTER CITY CODE FIRST THEN CLICK ON MODIFY OR DELETE");
		 event.returnValue=false;
		 }
		 }
		
</script>
</HEAD>
<body>
<form id=Form1 method=post runat="server">
<TABLE 
style="Z-INDEX: 101; POSITION: absolute; HEIGHT: 123px; TOP: 8px; LEFT: 8px" 
id=Table1 border=0 cellSpacing=1 cellPadding=1 width="100%">
  <TBODY>
  <TR>
    <TD align=center><uc1:webusercontrol1 id=WebUserControl11 runat="server"></uc1:webusercontrol1></TD></TR>
  <TR>
    <TD align=center>
      <P><asp:label id=Label1 runat="server" Font-Bold="True" Width="272px" BackColor="White" ForeColor="DarkBlue" Font-Size="10pt" Font-Names="Verdana">OFFERS/CONTRACTS ENTRY FORM</asp:label></P></TD></TR>
  <TR>
    <TD>
      <P align=center>
      <TABLE style="HEIGHT: 72px" id=Table2 border=1 cellSpacing=0 
      borderColor=#b0c4de cellPadding=1 width="70%" bgColor=#f0f8ff 
      >
        <TR>
          <TD style="WIDTH: 9.5%; HEIGHT: 25px" colSpan=2 align=center 
          ><asp:label id=lblCCode runat="server" Font-Bold="True" Width="103px" ForeColor="OrangeRed" Font-Size="8pt" Font-Names="Verdana">Contract Code</asp:label></TD></TR>
        <TR align=center>
          <TD style="WIDTH: 9.5%; HEIGHT: 25px"><asp:label id=Label4 runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana">Name of Client</asp:label></TD>
          <TD style="WIDTH: 30.97%; HEIGHT: 25px" align=left 
          ><asp:textbox id=txtClient runat="server" Width="70%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"></asp:textbox></TD></TR>
        <TR>
          <TD style="WIDTH: 9.5%; HEIGHT: 25px" align=center 
          ><asp:label id=Label17 runat="server" Font-Bold="True" Width="96px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana">Offer Date</asp:label></TD>
          <TD style="WIDTH: 30.97%; HEIGHT: 25px" align=left 
          ><asp:textbox onblur=check_date(txtOfferDt); style="TEXT-ALIGN: center" id=txtOfferDt runat="server" Width="100px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="10"></asp:textbox></TD></TR>
        <TR>
          <TD style="WIDTH: 9.5%" align=center><STRONG 
            ><asp:label id=Label9 runat="server" Font-Bold="True" Width="225px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana">Expected Contract Fee</asp:label></STRONG></TD>
          <TD style="WIDTH: 30.97%" align=left><asp:textbox id=txtConFee runat="server" Width="70%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"></asp:textbox><asp:label id=Label16 runat="server" Font-Bold="True" Width="105px" ForeColor="OrangeRed" Font-Size="8pt" Font-Names="Verdana">* Numeric Only</asp:label></TD></TR>
        <TR>
          <TD style="WIDTH: 9.5%; HEIGHT: 25px" align=center 
          ><asp:label id=lblExpOR runat="server" Font-Bold="True" Width="96px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana">Expected OR</asp:label></TD>
          <TD style="WIDTH: 30.97%; HEIGHT: 25px" align=left 
          ><asp:textbox id=txtExpOR runat="server" Width="70%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"></asp:textbox></TD></TR>
        <TR align=center>
          <TD style="WIDTH: 9.5%"><asp:label id=Label14 runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana">Rate of Insp Fee</asp:label></TD>
          <TD style="WIDTH: 30.97%" align=left><asp:textbox id=txtInspFee runat="server" Width="70%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"></asp:textbox></TD></TR>
        <TR>
          <TD style="WIDTH: 9.5%; HEIGHT: 25px" align=center 
          ><asp:label id=Label21 runat="server" Font-Bold="True" Width="159px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana">Status Of Offer</asp:label></TD>
          <TD style="WIDTH: 30.97%; HEIGHT: 25px" align=left 
          ><asp:dropdownlist id=ddlOfferStatus runat="server" Width="200px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana">
												<asp:ListItem></asp:ListItem>
												<asp:ListItem Value="S">Offer Sent</asp:ListItem>
												<asp:ListItem Value="A">Offer Accepted</asp:ListItem>
												<asp:ListItem Value="B">BID Lost</asp:ListItem>
											</asp:dropdownlist></TD></TR>
        <TR>
          <TD style="WIDTH: 9.5%; HEIGHT: 25px" align=center 
          ><asp:label id=Label19 runat="server" Font-Bold="True" Width="159px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana">Contract/LOA Sign Date</asp:label></TD>
          <TD style="WIDTH: 30.97%; HEIGHT: 25px" align=left 
          ><asp:textbox onblur=check_date(txtOffSignDt); style="TEXT-ALIGN: center" id=txtOffSignDt runat="server" Width="100px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="10"></asp:textbox></TD></TR>
        <TR align=center>
          <TD style="WIDTH: 9.5%"><asp:label id=Label3 runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana">Contract No.</asp:label></TD>
          <TD style="WIDTH: 30.97%" align=left><asp:textbox id=txtConName runat="server" Width="70%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"></asp:textbox></TD></TR>
        <TR>
          <TD style="WIDTH: 9.5%" align=center><asp:label id=Label6 runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana">Contract Period</asp:label></TD>
          <TD style="WIDTH: 30.97%"><asp:label id=Label7 runat="server" Font-Bold="True" Width="2px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana">From</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
<asp:textbox onblur="check_date(frmDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');" style="TEXT-ALIGN: center" id=frmDt runat="server" Width="100px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="10"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
<asp:label id=Label8 runat="server" Font-Bold="True" Width="2px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana">To</asp:label>&nbsp;&nbsp;&nbsp;&nbsp; 
<asp:textbox onblur="check_date(toDt);compareDates(frmDt,toDt,'From Date Cannot Be Greater Then To Date');txtCopy();" style="TEXT-ALIGN: center" id=toDt runat="server" Width="100px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Height="20px" MaxLength="10"></asp:textbox></TD></TR>
        <TR align=center>
          <TD style="WIDTH: 9.5%"><asp:label id=Label15 runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana">Broad Scope of Work</asp:label></TD>
          <TD style="WIDTH: 30.97%" align=left><asp:textbox id=txtScopeofWork runat="server" Width="70%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"></asp:textbox></TD></TR>
        <TR>
          <TD style="WIDTH: 9.5%" align=center><asp:label id=Label10 runat="server" Font-Bold="True" Width="225px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana">CM</asp:label></TD>
          <TD style="WIDTH: 30.97%" align=left><asp:dropdownlist id=lstCO runat="server" Width="200px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"></asp:dropdownlist></TD></TR>
        <TR>
          <TD style="WIDTH: 9.5%" align=center><asp:label id=Label11 runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana">Special Condition of Contract</asp:label></TD>
          <TD style="WIDTH: 30.97%" align=left><asp:textbox id=txtConCond runat="server" Width="70%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"></asp:textbox></TD></TR>
        <TR>
          <TD style="WIDTH: 9.5%" align=center><asp:label id=Label12 runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana">Panalty (If Any)</asp:label></TD>
          <TD style="WIDTH: 30.97%" align=left><asp:textbox id=txtPanelty runat="server" Width="70%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana"></asp:textbox></TD></TR>
        <TR>
          <TD style="WIDTH: 9.5%" align=center><asp:label id=Label13 runat="server" Font-Bold="True" Width="100%" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana">Contract Documents (If Any)</asp:label></TD>
          <TD style="WIDTH: 30.97%" align=left><INPUT 
            style="WIDTH: 100%; FONT-FAMILY: Verdana; HEIGHT: 25px; COLOR: navy; FONT-SIZE: 8pt; FONT-WEIGHT: bold" 
            id=File1 tabIndex=0 size=51 type=file name=File1 runat="server" 
            ></TD></TR></TABLE>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
<asp:label id=Label2 runat="server" Font-Bold="True" Width="100%" ForeColor="DarkMagenta" Font-Size="8pt" Font-Names="Verdana">* To Add New Record Fill Values and Click on Save</asp:label><asp:label id=Label5 runat="server" Font-Bold="True" Width="100%" ForeColor="DarkMagenta" Font-Size="8pt" Font-Names="Verdana">* To Search a Contract Enter First Few Characters Of Client OR Contract No. and Click on Search.</asp:label></P></TD></TR>
  <TR>
    <TD style="HEIGHT: 22px" align=center><asp:button id=btnSave runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id=btnAdd runat="server" Font-Bold="True" Width="77px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Text="Add New" onclick="btnAdd_Click"></asp:button><asp:button id=btnDelConfirm runat="server" Font-Bold="True" Width="75px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Text="Delete!!!" Visible="False" onclick="btnDelConfirm_Click"></asp:button><asp:button id=btnSearch runat="server" Font-Bold="True" Width="65px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Text="Search" onclick="btnSearch_Click"></asp:button><asp:button id=btnCancel tabIndex=10 runat="server" Font-Bold="True" Width="75px" ForeColor="DarkBlue" Font-Size="8pt" Font-Names="Verdana" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD></TR>
  <TR>
    <TD align=center><TITTLE:CUSTOMDATAGRID id=grdCity runat="server" Width="100%" Height="8px" GridWidth="100%" GridHeight="220px" AutoGenerateColumns="False" FreezeHeader="True" FreezeColumns="0" BorderWidth="1px" BorderColor="DarkBlue" AddEmptyHeaders="0" CssClass="Grid" UseAccessibleHeader="True" CellPadding="2" FreezeRows="0" PageSize="15" HorizontalAlign="Left">
								<PagerStyle NextPageText="Next" PrevPageText="Prev" HorizontalAlign="Center" ForeColor="Blue"
									Mode="NumericPages"></PagerStyle>
								<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
								<EditItemStyle Height="10%"></EditItemStyle>
								<FooterStyle CssClass="GridHeader"></FooterStyle>
								<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
								<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Left" Height="15%"
									ForeColor="DarkBlue" CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn FooterText="Delete">
										<HeaderStyle Width="5%"></HeaderStyle>
										<ItemTemplate>
											<asp:HyperLink id="HyperLink1" NavigateUrl='<%#"Contracts_Form.aspx?CONTRACT_ID=" + DataBinder.Eval(Container.DataItem,"CONTRACT_ID") + "&amp;ACTION=D"%>' runat="server">Delete</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn FooterText="Edit">
										<HeaderStyle Width="5%"></HeaderStyle>
										<ItemTemplate>
											<asp:HyperLink id="HyperLink2" NavigateUrl='<%#"Contracts_Form.aspx?CONTRACT_ID=" + DataBinder.Eval(Container.DataItem,"CONTRACT_ID") + "&amp;ACTION=E"%>' runat="server">Edit</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="CONTRACT_ID" HeaderText="Contract Code">
										<HeaderStyle Width="5%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CLIENT_NAME" HeaderText="Client">
										<HeaderStyle Width="20%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CONTRACT_NO" HeaderText="Contract No.">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CONT_INSP_FEE" HeaderText="Rate of Insp Fee"></asp:BoundColumn>
									<asp:BoundColumn DataField="CONT_PER_FROM" HeaderText="Contract Period From">
										<HeaderStyle Width="10%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CONT_PER_TO" HeaderText="Contract Period To">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CO_NAME" HeaderText="Contract CM">
										<HeaderStyle Width="15%"></HeaderStyle>
										</asp:BoundColumn>
									<asp:BoundColumn DataField="CON_DOC" HeaderText="View Contract" ReadOnly="True">
									<HeaderStyle Width="15%"></HeaderStyle>
									</asp:BoundColumn>
								    
								</Columns>
							</TITTLE:CUSTOMDATAGRID></TD></TR></TBODY></TABLE></FORM>
<DIV></DIV></TD></TR></TBODY></TABLE></FORM>
	</body>
</HTML>
