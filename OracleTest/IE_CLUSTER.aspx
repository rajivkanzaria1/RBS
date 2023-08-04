<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IE_CLUSTER.aspx.cs" Inherits="RBS.IE_CLUSTER.IE_CLUSTER" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>IE_CLUSTER</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript">

		function validate()
		{		
			if(document.Form1.Dropdownlist2.value=="")
			{
				alert("Department Name CANNOT BE LEFT BLANK");
				event.returnValue=false;
			}
			else if(document.Form1.Dropdownlist1.value=="")		
			{
				alert("CLUSTER Name CANNOT BE BLANK");
				event.returnValue=false;
			}
			else if(document.Form1.Dropdownlist12.value=="")		
			{
				alert("IE Name CANNOT BE BLANK");
				event.returnValue=false;
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
									Font-Bold="True" ForeColor="DarkBlue"> IE Cluster FORM</asp:label></P>
						</TD>
					</TR>
					<TR>
						<TD colSpan="4" align="center">
							<TABLE style="HEIGHT: 104px" id="Table2" border="1" cellSpacing="0" borderColor="#b0c4de"
								cellPadding="0" width="95%" bgColor="aliceblue">
								<TR>
									<TD style="WIDTH: 25.45%; HEIGHT: 27px" vAlign="top"><asp:label id="Label4" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="128px">Department Name:<font color="red">*</font></asp:label></TD>
									<TD style="WIDTH: 70%; HEIGHT: 27px" align="left"><asp:dropdownlist id="Dropdownlist2" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="OrangeRed" Width="480px" AutoPostBack="True" OnSelectedIndexChanged="departmentchanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 25.45%; HEIGHT: 27px" vAlign="top"><asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="128px"> CLUSTER NAME:<font color="red">*</font></asp:label></TD>
									<TD style="WIDTH: 70%; HEIGHT: 27px" align="left"><asp:dropdownlist id="Dropdownlist1" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="OrangeRed" Width="850px" AutoPostBack="True"></asp:dropdownlist></TD>
								<TR>
								<TR>
									<TD style="WIDTH: 25.45%; HEIGHT: 27px" vAlign="top"><asp:label id="Label_Return_DT" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="128px"> IE NAME:<font color="red">*</font></asp:label></TD>
									<TD style="WIDTH: 70%; HEIGHT: 27px" align="left"><asp:dropdownlist id="Dropdownlist12" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="OrangeRed" Width="480px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 100%" colSpan="2"></TD>
								</TR>
							</TABLE>
							<asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="Crimson" Width="90%">Enter all the fields marked as * and then click on submit button to Submit IE Cluster Entry.</asp:label>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 23px" colSpan="4" align="center">
							<P><asp:button id="btnSave" onclick="btnSave_Click" runat="server" Font-Names="Verdana" Font-Size="8pt"
									Font-Bold="True" ForeColor="DarkBlue" Text="Submit"></asp:button><asp:button id="Update" onclick="Update_Click" runat="server" Font-Names="Verdana" Font-Size="8pt"
									Font-Bold="True" ForeColor="DarkBlue" Text="Update" Visible="False"></asp:button>
								<asp:button id="btnCancel" onclick="CancelAll" runat="server" Font-Names="Verdana" Font-Size="8pt"
									Font-Bold="True" ForeColor="DarkBlue" Text="NEW"></asp:button>
								<asp:button id="Button1" onclick="Search" runat="server" ForeColor="DarkBlue" Font-Bold="True"
									Font-Size="8pt" Font-Names="Verdana" Text="Search"></asp:button>
								<asp:button id="PRINT" onclick="PRINTCLICK" runat="server" ForeColor="DarkBlue" Font-Bold="True"
									Font-Size="8pt" Font-Names="Verdana" Text="ShowList"></asp:button>
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
					</TR>
					<TR>
						<TD align="center"><asp:datagrid id="grdBook" runat="server" Font-Names="Verdana" Font-Size="8pt" Width="100%" Height="96px"
								BorderColor="DarkBlue" BorderStyle="Groove" AutoGenerateColumns="False">
								<AlternatingItemStyle BackColor="#CCCCFF"></AlternatingItemStyle>
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
								<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center" ForeColor="DarkBlue"
									VerticalAlign="Middle" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn>
										<ItemTemplate>
											<asp:HyperLink id=Hyperlink2 Runat="server" NavigateUrl='<%#"IE_CLUSTER.aspx?CLUSTER_CODE="+DataBinder.Eval(Container.DataItem,"CLUSTER_CODE")+ "&amp;DEPARTMENT_CODE="+DataBinder.Eval(Container.DataItem,"DEPARTMENT_CODE") %>'>Select</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="DEPARTMENT_CODE" HeaderText="DEPARTMENT NAME"></asp:BoundColumn>
									<asp:BoundColumn DataField="CLUSTER_NAME" HeaderText="CLUSTER NAME"></asp:BoundColumn>
									<asp:BoundColumn DataField="IE_NAME" HeaderText="IE NAME"></asp:BoundColumn>
								</Columns>
							</asp:datagrid></TD>
					</TR>
				</TABLE>
			</form>
		</div>
	</body>
</HTML>
