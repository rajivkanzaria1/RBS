<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IE_MAXIMUMCALLLIMIT.aspx.cs" Inherits="RBS.IE_MAXIMUMCALLLIMIT.IE_MAXIMUMCALLLIMIT" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>IE_MAXIMUMCALLLIMIT</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript">

		function validate()
		{		
			if(document.Form1.Dropdownlist1.value=="")
			{
				alert("REGION NAME CAN NOT BE BLANK!!!");
				event.returnValue=false;
			}
			else if(document.Form1.TextBox1.value=="")		
			{
				alert("IE MAXIMUM CALL LIMIT CAN NOT BLANK ");
				event.returnValue=false;
			}
			return;
		}
        </script>
</HEAD>
	<body>
		<INPUT id="Button12" onclick="history.go(-1)" type="button" value="Go Back" name="Button1">
		<div runat="server" id="xyz">
			<form id="Form1" method="post" runat="server">
				<TABLE style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px" id="Table1"
					border="0" cellSpacing="1" cellPadding="1" width="100%">
					<TR>
						<TD style="HEIGHT: 18px" align="center">
							<P>
								<uc1:WebUserControl1 id="WebUserControl11" runat="server"></uc1:WebUserControl1></P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 18px" colSpan="4" align="center">
							<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" BackColor="White"
									Font-Bold="True" ForeColor="DarkBlue"> IE MAXIMUM_CALL LIMIT FORM</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD colSpan="4" align="center">
							<TABLE style="HEIGHT: 104px" id="Table2" border="1" cellSpacing="0" borderColor="#b0c4de"
								cellPadding="0" width="95%" bgColor="aliceblue">
								<TR>
									<TD style="WIDTH: 25.45%; HEIGHT: 27px" vAlign="top"><asp:label id="Label4" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="128px">REGION NAME:<font color="red">*</font></asp:label></TD>
									<TD style="WIDTH: 70%; HEIGHT: 27px" align="left"><asp:dropdownlist id="Dropdownlist1" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="OrangeRed" Width="480px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 25.45%; HEIGHT: 27px" vAlign="top"><asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="200px">MAXIMUM CALL LIMIT:<font color="red">*</font></asp:label></TD>
									<TD style="WIDTH: 70%; HEIGHT: 27px" align="left"><asp:TextBox Runat="server" id="TextBox1" />
									</TD>
								<TR>
								<TR>
									<TD style="WIDTH: 100%" colSpan="2"></TD>
								</TR>
							</TABLE>
							<asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="Crimson" Width="90%">Enter all the fields marked as * and then click on submit button to submit IE MAXIMUMN CALL ENTRY.</asp:label></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 23px" colSpan="4" align="center">
							<P><asp:button id="btnSave" onclick="btnSave_Click" runat="server" Font-Names="Verdana" Font-Size="8pt"
									Font-Bold="True" ForeColor="DarkBlue" Text="Submit" Enabled="False"></asp:button>
								<asp:button id="Update" onclick="Update_Click" runat="server" Font-Names="Verdana" Font-Size="8pt"
									Font-Bold="True" ForeColor="DarkBlue" Text="Update"></asp:button>
							</P>
						</TD>
					</TR>
					<TR>
						<TD colSpan="4" align="center"></TD>
					</TR>
					<TR>
						<TD colSpan="4" align="center"></TD>
					</TR>
					<TR>
						<TD align="center"><asp:datagrid id="grdBook" runat="server" Font-Names="Verdana" Font-Size="8pt" Width="100%" Height="96px"
								BorderColor="DarkBlue" BorderStyle="Groove" AutoGenerateColumns="False">
								<AlternatingItemStyle BackColor="#CCCCFF"></AlternatingItemStyle>
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
								<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center" ForeColor="DarkBlue"
									VerticalAlign="Middle" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="REGION_CODE" HeaderText="REGION NAME"></asp:BoundColumn>
									<asp:BoundColumn DataField="MAXIMUM_CALL" HeaderText="MAXIMUM CALL LIMIT"></asp:BoundColumn>
								</Columns>
							</asp:datagrid></TD>
					</TR>
				</TABLE>
			</form>
		</div>
	</body>
</HTML>
