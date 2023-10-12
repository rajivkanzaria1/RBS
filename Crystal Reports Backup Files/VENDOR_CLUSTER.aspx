<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VENDOR_CLUSTER.aspx.cs" Inherits="RBS.VENDOR_CLUSTER.VENDOR_CLUSTER" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>VENDER_CLUSTER</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript">

		function validate()
		{		
			if(document.Form12.Dropdownlist2.value=="")
			{
				alert("Vendor CODE CANNOT BE LEFT BLANK");
				event.returnValue=false;
			}
			else if(document.Form12.Dropdownlist1.value=="")		
			{
				alert("Department NAME CANNOT BE BLANK");
				event.returnValue=false;
			}
			else if(document.Form12.Dropdownlist3.value=="")		
			{
				alert("Cluster Code CANNOT BE BLANK");
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
		
		
		 function validate123()
        {
         if(document.getElementById("txtname").value=="")
               {
                 alert("Enter the Manufacturer Code or 1st few letters of Manufacturer Name then click on select Vendor Button");
                 event.returnValue=false;
               }
        }
        </script>
		</SCRIPT>
	</HEAD>
	<body>
		<INPUT id="Button12" onclick="history.go(-1)" type="button" value="Go Back" name="Button1">
		<div runat="server" id="xyz">
			<form id="Form12" method="post" runat="server">
				<TABLE style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px" id="Table1"
					border="0" cellSpacing="1" cellPadding="1" width="100%">
					<TR>
						<TD style="HEIGHT: 18px" align="center">
							<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
						</TD>
					<TR>
					</TR>
					</TR>
					<TR>
						<TD style="HEIGHT: 18px" align="center"><asp:label id="Label1" runat="server" Font-Names="Verdana" Font-Size="10pt" BackColor="White"
								Font-Bold="True" ForeColor="DarkBlue"> VENDOR Cluster FORM</asp:label></TD>
					</TR>
					<TR>
						<TD colSpan="4" align="center">
							<TABLE style="HEIGHT: 104px" id="Table2" border="1" cellSpacing="0" borderColor="#b0c4de"
								cellPadding="0" width="95%" bgColor="aliceblue">
								<TR>
									<TD style="WIDTH: 181px; HEIGHT: 34px" width="181"><asp:label id="Label10" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="100%">Name of Vendor/Manufacture Code<font color="red">*</font></asp:label></TD>
									<TD style="HEIGHT: 34px" width="30%" colSpan="3"><asp:textbox id="txtname" tabIndex="12" runat="server" Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue"
											Width="20%" Height="20px" MaxLength="50"></asp:textbox><asp:button id="Button1" tabIndex="13" onclick="btnclick" runat="server" Font-Names="Verdana"
											Font-Size="8pt" Font-Bold="True" ForeColor="DarkBlue" Width="30%" Height="19px" ToolTip="Enter the Manufacturer Code or 1st few letters of Manufacturer Name then click on select Vendor Button"
											Text="Select Place of Inspection"></asp:button><asp:dropdownlist id="ddlManufac" tabIndex="14" onkeypress="return keySort(ddlManufac);" runat="server"
											Font-Names="Verdana" Font-Size="8pt" ForeColor="DarkBlue" Width="120%" Height="25px" OnSelectedIndexChanged="ddlchanged" AutoPostBack="True" Visible="False"></asp:dropdownlist><asp:textbox id="txtplaceofinspection" tabIndex="12" runat="server" Font-Names="Verdana" Font-Size="8pt"
											ForeColor="DarkBlue" Width="50%" Height="20px" MaxLength="50" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 25.45%; HEIGHT: 27px" vAlign="top"><asp:label id="Label3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="128px">DEPARTMENT NAME:<font color="red">*</font></asp:label></TD>
									<TD style="WIDTH: 70%; HEIGHT: 27px" align="left"><asp:dropdownlist id="Dropdownlist1" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="OrangeRed" Width="300px" OnSelectedIndexChanged="departmentchanged" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 25.45%; HEIGHT: 27px" vAlign="top"><asp:label id="Label5" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="DarkBlue" Width="128px">CLUSTER NAME:<font color="red">*</font></asp:label></TD>
									<TD style="WIDTH: 70%; HEIGHT: 27px" align="left"><asp:dropdownlist id="Dropdownlist3" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
											ForeColor="OrangeRed" Width="850px"></asp:dropdownlist></TD>
								</TR>
								<TR>
								<TR>
								<TR>
									<TD style="WIDTH: 100%" colSpan="2"></TD>
								</TR>
							</TABLE>
							<asp:label id="Label4" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
								ForeColor="Crimson" Width="90%">Enter all the fields marked as * and then click on submit button to Submit Vendor Cluster Entry.</asp:label>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 23px" colSpan="4" align="center">
							<P>
								<asp:button id="btnSave" runat="server" Font-Names="Verdana" Font-Size="8pt" Font-Bold="True"
									ForeColor="DarkBlue" Text="Submit" onclick="btnSave_Click"></asp:button>
								<asp:button id="Update" onclick="Update_Click" runat="server" Font-Names="Verdana" Font-Size="8pt"
									Font-Bold="True" ForeColor="DarkBlue" Text="Update" Visible="False"></asp:button>
								<asp:button id="btnCancel" onclick="CancelAll" runat="server" Font-Names="Verdana" Font-Size="8pt"
									Font-Bold="True" ForeColor="DarkBlue" Text="New"></asp:button><asp:button id="Button2" onclick="Search" runat="server" Font-Names="Verdana" Font-Size="8pt"
									Font-Bold="True" ForeColor="DarkBlue" Text="Search"></asp:button>
								<asp:button id="PRINT" onclick="PRINTCLICK" runat="server" ForeColor="DarkBlue" Font-Bold="True"
									Font-Size="8pt" Font-Names="Verdana" Text="ShowList"></asp:button>
								<asp:button id="Button3" onclick="Delete_Click" runat="server" ForeColor="DarkBlue" Font-Bold="True"
									Font-Size="8pt" Font-Names="Verdana" Text="Delete"></asp:button>
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
								AutoGenerateColumns="False" BorderStyle="Groove" BorderColor="DarkBlue">
								<AlternatingItemStyle BackColor="#CCCCFF"></AlternatingItemStyle>
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
								<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center" ForeColor="DarkBlue"
									VerticalAlign="Middle" BackColor="InactiveCaptionText"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn>
										<ItemTemplate>
											<asp:HyperLink id=Hyperlink2 Runat="server" NavigateUrl='<%#"VENDOR_CLUSTER.aspx?VENDOR_CODE="+DataBinder.Eval(Container.DataItem,"VENDOR_CODE") + "&amp;DEPARTMENT_NAME="+DataBinder.Eval(Container.DataItem,"DEPARTMENT_NAME")%>'>Select</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="VEND_CD" HeaderText="VENDER CODE"></asp:BoundColumn>
									<asp:BoundColumn DataField="VENDOR" HeaderText="VENDER"></asp:BoundColumn>
									<asp:BoundColumn DataField="DEPARTMENT_NAME" HeaderText="DEPARTMENT NAME"></asp:BoundColumn>
									<asp:BoundColumn DataField="CLUSTER_NAME" HeaderText="CLUSTER NAME"></asp:BoundColumn>
								</Columns>
							</asp:datagrid></TD>
					</TR>
				</TABLE>
			</form>
		</div>
	</body>
</HTML>
