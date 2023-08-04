<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cluster_Master.aspx.cs" Inherits="RBS.Cluster_Master.Cluster_Master" %>


<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Cluster_Master</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">

		function validate()
		{		
			if(document.Form1.lblCom_DT.value=="")
			{
				alert("Cluster CODE CANNOT BE LEFT BLANK");
				event.returnValue=false;
			}
			else if(document.Form1.Label4.value=="")		
			{
				alert("Cluster NAME CANNOT BE BLANK");
				event.returnValue=false;
			}
			else if(document.Form1.Textbox1.value=="")		
			{
				alert("Geographical Partition CANNOT BE BLANK");
				event.returnValue=false;
			}
		  else if(document.Form1.ddldepartment.value=="")		
			{
				alert("Department name CANNOT BE BLANK");
				event.returnValue=false;
			}
			
			return;
		}
		
		function clustername()
		{
		if(document.Form1.Label4.value=="")		
			{
				alert("Cluster NAME CANNOT BE BLANK");
				event.returnValue=false;
			}
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
	<body id="body1">
		<INPUT id="Button12" onclick="history.go(-1)" type="button" value="Go Back" name="Button1">
		<div id="xyz" runat="server">
			<form id="Form1" method="post" runat="server">
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
					cellSpacing="1" cellPadding="1" width="100%" border="0" runat="server">
					<TR>
						<TD style="HEIGHT: 18px" align="center">
							<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
						</TD>
					</TR>
					<tr>
						<td align="center">
							<P><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" BackColor="White"
									Font-Bold="True" ForeColor="DarkBlue">Cluster Master FORM</asp:label></P>
						</td>
					</tr>
					</TR>
					<TR>
						<TD style="HEIGHT: 18px" align="center" colSpan="4">
							<TABLE id="Table2" style="HEIGHT: 104px" borderColor="#b0c4de" cellSpacing="0" cellPadding="0"
								width="85%" bgColor="aliceblue" border="1">
								<TR>
									<TD style="WIDTH: 25.45%; HEIGHT: 27px" vAlign="top"><asp:label id="Label_Return_DT" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="200px"> CLUSTER CODE:<font color="red">*</font></asp:label></TD>
									<TD style="WIDTH: 70%; HEIGHT: 27px" align="left"><asp:textbox id="lblCom_DT" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="OrangeRed" Width="500px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 25.45%; HEIGHT: 27px" vAlign="top"><asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="200px"> CLUSTER NAME:<font color="red">*</font></asp:label></TD>
									<TD style="WIDTH: 70%; HEIGHT: 27px" align="left"><asp:textbox id="Label4" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="OrangeRed" Width="500px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 25.45%; HEIGHT: 27px" vAlign="top"><asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="200px">GEOGRAPHICAL AREA:<font color="red">*</font></asp:label></TD>
									<TD style="WIDTH: 70%; HEIGHT: 27px" align="left"><asp:textbox id="Textbox1" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="OrangeRed" Width="500px"></asp:textbox></TD>
								</TR>
								<TR>
								<TR>
									<TD style="WIDTH: 25.45%; HEIGHT: 27px" vAlign="top"><asp:label id="Label7" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="200px">DEPARTMENT NAME:<font color="red">*</font></asp:label></TD>
									<TD style="WIDTH: 70%; HEIGHT: 27px" align="left"><asp:dropdownlist id="ddldepartment" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="OrangeRed" Width="500px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 25.45%; HEIGHT: 27px" vAlign="top"><asp:label id="Label6" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="200px">REGION NAME:<font color="red">*</font></asp:label></TD>
									<TD style="WIDTH: 70%; HEIGHT: 27px" align="left"><asp:dropdownlist id="ddlregion" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="OrangeRed" Width="500px" onselectedindexchanged="ddlregion_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 25.45%; HEIGHT: 27px" vAlign="top"><asp:label id="Label8" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="200px">HQ AREA:<font color="red">*</font></asp:label></TD>
									<TD style="WIDTH: 70%; HEIGHT: 27px" align="left"><asp:textbox id="txtHQArea" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="OrangeRed" Width="500px"></asp:textbox></TD>
								</TR>
								<TR>
								<TR>
									<TD style="WIDTH: 100%" colSpan="2"></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="4"><asp:label id="Label2" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="Crimson" Width="90%">Enter all the fields marked as * and then click on submit button to Submit Cluster Master Entry.</asp:label></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 23px" align="center" colSpan="4">
							<P><asp:button id="btnSave" onclick="btnSave_Click" runat="server" Font-Names="Verdana" Font-Size="8pt"
									Font-Bold="True" ForeColor="DarkBlue" Text="Submit"></asp:button><asp:button id="btnUpdate" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
									ForeColor="DarkBlue" Text="Update" onclick="btnUpdate_Click"></asp:button><asp:button id="btnCancel" onclick="CancelAll" runat="server" Font-Names="Verdana" Font-Size="8pt"
									Font-Bold="True" ForeColor="DarkBlue" Text="New"></asp:button><asp:button id="Button1" onclick="Search" runat="server" Font-Names="Verdana" Font-Size="8pt"
									Font-Bold="True" ForeColor="DarkBlue" Text="Search"></asp:button><asp:button id="PRINT" onclick="PRINTCLICK" runat="server" Font-Names="Verdana" Font-Size="8pt"
									Font-Bold="True" ForeColor="DarkBlue" Text="ShowList"></asp:button></P>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="4"></TD>
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
									<asp:TemplateColumn>
										<ItemTemplate>
											<asp:HyperLink id=Hyperlink2 Runat="server" NavigateUrl='<%#"Cluster_Master.aspx?CLUSTER_CODE="+DataBinder.Eval(Container.DataItem,"CLUSTER_CODE") %>'>Select</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="CLUSTER_CODE" HeaderText="CLUSTER CODE"></asp:BoundColumn>
									<asp:BoundColumn DataField="CLUSTER_NAME" HeaderText="CLUSTER NAME"></asp:BoundColumn>
									<asp:BoundColumn DataField="GEOGRAPHICAL_PARTITION" HeaderText="GEOGRAPHICAL PARTITION"></asp:BoundColumn>
									<asp:BoundColumn DataField="DEPARTMENT_NAME" HeaderText="DEPARTMENT NAME"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="REGION_CODE" HeaderText="REGION CODE"></asp:BoundColumn>
									<asp:BoundColumn DataField="HQ_AREA" HeaderText="Headquater"></asp:BoundColumn>
								</Columns>
							</asp:datagrid></TD>
					</TR>
				</TABLE>
			</form>
		</div>
	</body>
</HTML>
