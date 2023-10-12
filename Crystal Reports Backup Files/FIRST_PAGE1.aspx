<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FIRST_PAGE1.aspx.cs" Inherits="RBS.FIRST_PAGE1.FIRST_PAGE1" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>FIRST_PAGE1</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<p>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:Label ID="Label1" runat="server" BackColor="#33CCFF" BorderColor="Blue" BorderStyle="Outset"
					BorderWidth="3px" ForeColor="#000099" Height="20px" Text="CONTROL PERSON" Width="145px"></asp:Label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:DropDownList ID="DropDownList1" runat="server" BackColor="#FFFFCC" Height="19px" Width="141px"></asp:DropDownList>
			</p>
			<p>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:Label ID="Label2" runat="server" BackColor="#33CCFF" BorderColor="#0000CC" BorderStyle="Outset"
					BorderWidth="3px" ForeColor="#000099" Height="20px" Text="   CLIENT" Width="145px"></asp:Label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" BackColor="#FFFFCC" Width="140px" onselectedindexchanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
			</p>
			<p>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:Label ID="Label3" runat="server" BackColor="#33CCFF" BorderColor="#000099" BorderStyle="Outset"
					BorderWidth="3px" ForeColor="#000099" Height="20px" Text="CLIENT TYPE" Width="145px"></asp:Label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" BackColor="#FFFFCC" Width="140px"></asp:DropDownList>
			</p>
			<p style="MARGIN-LEFT: 40px">
				&nbsp;</p>
			<p style="MARGIN-LEFT: 160px">
				<asp:Label ID="Label4" runat="server" BackColor="#33CCFF" BorderColor="#0000CC" BorderStyle="Outset"
					BorderWidth="3px" ForeColor="#000099" Height="20px" Text="FROM" Width="50px"></asp:Label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:TextBox ID="TextBox1" runat="server" BackColor="#FFFFCC" Columns="10" ForeColor="#00CC66"
					Height="25px"></asp:TextBox>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:Label ID="Label5" runat="server" BackColor="#33CCFF" BorderColor="#0000CC" BorderStyle="Outset"
					BorderWidth="3px" ForeColor="#000099" Height="25px" Text="TO" Width="20px"></asp:Label>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:TextBox ID="TextBox2" runat="server" BackColor="#FFFFCC" Columns="10" ForeColor="#00CC66"
					Height="25px"></asp:TextBox>
			</p>
			<p style="MARGIN-LEFT: 160px">
				&nbsp;</p>
			<p style="MARGIN-LEFT: 240px">
				<asp:Button ID="Button1" runat="server" BackColor="#3399FF" BorderColor="#0000CC" BorderStyle="Groove"
					Font-Bold="True" Text="SAVE" onclick="Button1_Click" />
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:Button ID="Button2" runat="server" BackColor="#3399FF" BorderColor="#0000CC" BorderStyle="Solid"
					Font-Bold="True" Height="25px" Text="CANCEL"/>
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:Button ID="Button3" runat="server" BackColor="#3399FF" BorderColor="#0000CC" BorderStyle="Outset"
					Font-Bold="True" ForeColor="#000099" Text="SEARCH" Width="73px" onclick="Button3_Click" />
			</p>
			<p style="MARGIN-LEFT: 240px">
				&nbsp;</p>
			<p style="MARGIN-LEFT: 240px">
				<asp:DataGrid id="GD1" runat="server" AutoGenerateColumns="False">
					<Columns>
						<asp:TemplateColumn FooterText="Edit">
							<ItemTemplate>
								<asp:HyperLink id="HyperLink2" NavigateUrl='<%#"FIRST_PAGE.aspx?CITY_CD=" + DataBinder.Eval(Container.DataItem,"CITY_CD") + "&amp;ACTION=E"%>' runat="server">Edit</asp:HyperLink>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="C_NO" HeaderText="C_NO"></asp:BoundColumn>
						<asp:BoundColumn DataField="C_NAME" HeaderText="C_NAME"></asp:BoundColumn>
						<asp:BoundColumn DataField="C_EMAIL" HeaderText="C_EMAIL"></asp:BoundColumn>
						<asp:BoundColumn DataField="BPO_TYPE" HeaderText="BPO_TYPE"></asp:BoundColumn>
						<asp:BoundColumn DataField="BPO_RLY" HeaderText="BPO_RLY"></asp:BoundColumn>
					</Columns>
				</asp:DataGrid>
			</p>
		</form>
	</body>
</HTML>

