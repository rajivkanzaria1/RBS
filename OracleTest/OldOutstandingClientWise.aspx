<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OldOutstandingClientWise.aspx.cs" Inherits="RBS.OldOutstandingClientWise.OldOutstandingClientWise" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>

<%@ Register TagPrefix="Tittle" Namespace="Tittle.Controls" Assembly="Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>OldOutstandingClientWise</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="date.js"></script>
		<script language="javascript" type="text/javascript">
		
		function validate()
		{
		
		if(document.Form1.lstClientType.value=="" || document.Form1.lstBPO_Rly.value=="" || document.Form1.txtOutstanding.value=="")
		{
		 alert("SELECT BPO TYPE THEN SELECT CLIENT AND THEN ENTER THE OUTSTANDING AMOUNT");
		 event.returnValue=false;
		 }
		 else if(document.Form1.txtOutstanding.value!="" && IsNumeric(document.Form1.txtOutstanding.value) == false)
		{
		 alert("OUTSTANDING AMOUNT CANTAINS INVALID CHARATERS!!!");
		 event.returnValue=false;
		 }
		 else
		 return;
		}
				
		
        </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
				cellPadding="0" width="100%" bgColor="#f0f8ff" border="1">
				<TR>
					<TD align="center" colSpan="3"><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 41px" align="center" colSpan="3"><asp:label id="Label1" runat="server" Font-Bold="True" BackColor="AliceBlue" ForeColor="DarkBlue"
							Font-Size="12pt" Font-Names="Verdana" Width="274px">OLD SYSTEM OUTSTANDING</asp:label></TD>
				</TR>
				<TR bgColor="lightsteelblue">
					<TD style="WIDTH: 20%; HEIGHT: 24px">
						<P><FONT face="Verdana" size="2"><STRONG style="COLOR: darkblue">Select Client</STRONG></FONT></P>
					</TD>
					<TD style="WIDTH: 20%"><FONT face="Verdana" size="2"><asp:dropdownlist id="lstClientType" tabIndex="1" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
								Font-Names="Verdana" Width="90%" AutoPostBack="True" onselectedindexchanged="lstClientType_SelectedIndexChanged"></asp:dropdownlist></FONT></TD>
					<TD style="WIDTH: 60%; HEIGHT: 24px"><asp:dropdownlist id="lstBPO_Rly" tabIndex="2" runat="server" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana" Width="98%" AutoPostBack="True" onselectedindexchanged="lstBPO_Rly_SelectedIndexChanged"></asp:dropdownlist></TD>
				</TR>
				<TR bgColor="lightsteelblue">
					<TD style="WIDTH: 20%; HEIGHT: 24px" colSpan="3"><asp:dropdownlist id="ddlBPOCode" tabIndex="3" runat="server" ForeColor="DarkBlue" Font-Size="7pt"
							Font-Names="Verdana" Width="100%" Height="25px"></asp:dropdownlist></TD>
				</TR>
				<TR bgColor="lightsteelblue">
					<TD style="WIDTH: 20%; HEIGHT: 24px">
						<P><FONT face="Verdana" size="2"><STRONG style="COLOR: darkblue">Old System BPO Ref No.</STRONG></FONT></P>
					</TD>
					<TD style="WIDTH: 20%" colSpan="2"><asp:textbox id="txtOLDBPOREF" style="TEXT-ALIGN: center" tabIndex="4" runat="server" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Width="25%" Height="20px" MaxLength="15"></asp:textbox></TD>
				</TR>
				<TR bgColor="lightsteelblue">
					<TD style="WIDTH: 20%; HEIGHT: 24px">
						<P><FONT face="Verdana" size="2"><STRONG style="COLOR: darkblue">Outstanding Amount</STRONG></FONT></P>
					</TD>
					<TD style="WIDTH: 20%" colSpan="2"><FONT face="Verdana" size="2"><asp:textbox id="txtOutstanding" style="TEXT-ALIGN: center" tabIndex="5" runat="server" ForeColor="DarkBlue"
								Font-Size="8pt" Font-Names="Verdana" Width="25%" Height="20px" MaxLength="16"></asp:textbox></FONT></TD>
				</TR>
				<TR bgColor="lightsteelblue">
					<TD style="WIDTH: 20%; HEIGHT: 24px" colSpan="3" align="center"><asp:button id="btnSave" tabIndex="6" runat="server" Font-Bold="True" ForeColor="DarkBlue" Text="Save" onclick="btnSave_Click"></asp:button>
						<asp:button id="btnDelete" tabIndex="7" runat="server" Font-Bold="True" ForeColor="DarkBlue"
							Text="Delete" onclick="btnDelete_Click"></asp:button>
						<asp:button id="btnCancel" tabIndex="8" runat="server" Font-Bold="True" ForeColor="DarkBlue"
							Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 20%; HEIGHT: 2px" align="center" colSpan="3">&nbsp;&nbsp;&nbsp;&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 20%; HEIGHT: 24px" colSpan="3">
						<DIV><TITTLE:CUSTOMDATAGRID id="grdOutstanding" runat="server" Width="100%" Height="8px" OnEditCommand="grdOutstanding_Edit"
								OnUpdateCommand="grdOutstanding_Update" OnCancelCommand="grdOutstanding_Cancel" BorderColor="DarkBlue"
								AutoGenerateColumns="False" PageSize="15" FreezeRows="0" CellPadding="2" UseAccessibleHeader="True"
								CssClass="Grid" AddEmptyHeaders="0" BorderWidth="1px" FreezeColumns="0" FreezeHeader="True" GridHeight="150px"
								GridWidth="100%">
								<PagerStyle HorizontalAlign="Center" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
								<AlternatingItemStyle Font-Size="8pt" Font-Names="Verdana" CssClass="GridAlternate" BackColor="#CCCCFF"></AlternatingItemStyle>
								<EditItemStyle Height="10%"></EditItemStyle>
								<FooterStyle CssClass="GridHeader"></FooterStyle>
								<ItemStyle Font-Size="8pt" Font-Names="Verdana" Height="20px" CssClass="GridNormal"></ItemStyle>
								<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" Height="15%" ForeColor="DarkBlue"
									CssClass="GridHeader" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit">
										<HeaderStyle Width="5%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:EditCommandColumn>
									<asp:BoundColumn DataField="BPO_CD" ReadOnly="True" HeaderText="BPO CD"></asp:BoundColumn>
									<asp:BoundColumn DataField="BPO" ReadOnly="True" HeaderText="BPO"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Old System BPO">
										<ItemTemplate>
											<asp:Label id=Label39 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.OLD_SYSTEM_BPO") %>'>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:TextBox id=txtODLSYSBPO runat="server" BackColor="#FFC080" ForeColor="#0000C0" Width="75px" MaxLength="12" Text='<%# DataBinder.Eval(Container, "DataItem.OLD_SYSTEM_BPO") %>' BorderStyle="Inset">
											</asp:TextBox>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Outstanding">
										<ItemTemplate>
											<asp:Label id=Label2 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.OUTSTANDING_AMT") %>'>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:TextBox id=txtOUTAMT runat="server" BackColor="#FFC080" ForeColor="#0000C0" Width="75px" MaxLength="12" Text='<%# DataBinder.Eval(Container, "DataItem.OUTSTANDING_AMT") %>' BorderStyle="Inset">
											</asp:TextBox>
										</EditItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</TITTLE:CUSTOMDATAGRID></DIV>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
