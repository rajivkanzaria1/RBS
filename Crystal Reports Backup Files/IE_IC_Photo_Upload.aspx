<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IE_IC_Photo_Upload.aspx.cs" Inherits="RBS.IE_IC_Photo_Upload.IE_IC_Photo_Upload" %>

<%@ Register TagPrefix="uc1" TagName="WebUserControl1" Src="WebUserControl1.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>IE_IC_Photo_Upload</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		function validate()
		{
			if(document.Form1.txtSetNo.value=="" || document.Form1.txtBKNO.value=="")
			{
				alert("Enter Both the Fields Bk No & Set No!!!");
				event.returnValue=false;
			}
			else if(document.Form1.File1.value=="" || document.Form1.File2.value=="" || document.Form1.File3.value=="" || document.Form1.File4.value=="" || document.Form1.File5.value=="")
			{
				alert("Select Atleast 5 Images!!!");
				event.returnValue=false;
			}
			else
			
			return;
		}
		
		
			
		function makeUppercase(value1)
		 {
			var bkno=value1;
			var d=bkno.value.toUpperCase();
			bkno.value=d;
			
		 }
		 
		
		 
		function change(value1)
		{
			var sno=value1;
			var d=sno.value;
			var dlength=d.length; 
			if(dlength == 1 )
			{
				d="00" + d;
				sno.value=d;
				event.returnValue=false;
			}
			else if(dlength==2)
			{
				d="0" + d;
				sno.value=d;
				event.returnValue=false;
			}
			return false;	
		}
        </script>
</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px; HEIGHT: 123px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 45px" align="center" colSpan="4">
						<P><uc1:webusercontrol1 id="WebUserControl11" runat="server"></uc1:webusercontrol1></P>
					</TD>
				</TR>
				<tr>
					<td align="center" colSpan="4"><asp:label id="Label1" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="10pt"
							Font-Names="Verdana" BackColor="White" Width="177px">IE IC PHOTO UPLOAD</asp:label></td>
				</tr>
				<tr bgColor="#ccccff">
					<TD style="WIDTH: 10.85%; HEIGHT: 23px"><asp:label id="Label12" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana">Case No</asp:label></TD>
					<TD style="WIDTH: 35.02%; HEIGHT: 23px"><asp:label id="txtCaseNo" runat="server" Font-Bold="True" ForeColor="OrangeRed" Font-Size="8pt"
							Font-Names="Verdana">Case No </asp:label></TD>
					<TD style="WIDTH: 14.16%; HEIGHT: 23px"><asp:label id="Label16" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
							Font-Names="Verdana"> Call Date - SNo. </asp:label></TD>
					<TD style="WIDTH: 12%; HEIGHT: 23px"><asp:label id="txtDtOfReciept" runat="server" Font-Bold="True" ForeColor="OrangeRed" Font-Size="8pt"
							Font-Names="Verdana">C Date </asp:label>&nbsp;-
						<asp:label id="lblCSNO" runat="server" Font-Bold="True" ForeColor="OrangeRed" Font-Size="8pt"
							Font-Names="Verdana">C SNO</asp:label></TD>
				</tr>
				<TR>
					<TD style="WIDTH: 10.85%; HEIGHT: 23px" align="center" colSpan="4"><asp:radiobutton id="rdbSingleIC" runat="server" Font-Bold="True" ForeColor="darkblue" Font-Size="X-Small"
							Font-Names="Verdana" Width="299px" Checked="True" AutoPostBack="True" GroupName="g1" Text="Single IC OR IC's With Different Photos" tabIndex="1" oncheckedchanged="rdbNonInspWork_CheckedChanged"></asp:radiobutton>
						<P></P>
						<P><asp:radiobutton id="rdbMultipleIC" runat="server" Font-Bold="True" ForeColor="darkblue" Font-Size="X-Small"
								Font-Names="Verdana" AutoPostBack="True" GroupName="g1" Text="Multiple IC's With Same Photos"
								tabIndex="2" oncheckedchanged="rdbNonInspWork_CheckedChanged"></asp:radiobutton></P>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="4">
						<TABLE id="Table3" style="HEIGHT: 50px" borderColor="#b0c4de" cellSpacing="0" cellPadding="0"
							width="80%" bgColor="aliceblue" border="1">
							<TR>
								<TD style="WIDTH: 47.53%; HEIGHT: 31px" align="center" colSpan="2">
									<TABLE id="Table4" style="HEIGHT: 50px" borderColor="#b0c4de" cellSpacing="0" cellPadding="0"
										width="50%" bgColor="aliceblue" border="1">
										<TBODY>
											<tr>
												<td style="WIDTH: 25%"><asp:label id="lblBKNO" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
														Font-Names="Verdana" Width="100px">BK No.</asp:label></td>
												<td style="WIDTH: 25%"><asp:textbox id="txtBKNO" onblur="makeUppercase(txtBKNO);" tabIndex="3" runat="server" ForeColor="DarkBlue"
														Font-Size="8pt" Font-Names="Verdana" Width="48px" MaxLength="4" Height="20px"></asp:textbox></td>
												<td style="HEIGHT: 25%"><asp:label id="lblSetNo" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
														Font-Names="Verdana" Width="100px">Set No.</asp:label></td>
												<td style="HEIGHT: 25%"><asp:textbox id="txtSetNo" onblur="change(txtSetNo);" tabIndex="4" runat="server" ForeColor="DarkBlue"
														Font-Size="8pt" Font-Names="Verdana" Width="48px" MaxLength="3" Height="20px"></asp:textbox>
												</td>
											</tr>
											<tr>
												<td style="WIDTH: 25%"><asp:label id="lblBKNO1" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
														Font-Names="Verdana" Width="100px">BK No.</asp:label></td>
												<td style="WIDTH: 25%"><asp:textbox id="txtBKNO1" onblur="makeUppercase(txtBKNO1);" tabIndex="5" runat="server" ForeColor="DarkBlue"
														Font-Size="8pt" Font-Names="Verdana" Width="48px" MaxLength="4" Height="20px"></asp:textbox></td>
												<td style="WIDTH: 25%"><asp:label id="lblSetNo1" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
														Font-Names="Verdana" Width="100px">Set No.</asp:label></td>
												<td style="WIDTH: 25%"><asp:textbox id="txtSetNo1" onblur="change(txtSetNo1);" tabIndex="6" runat="server" ForeColor="DarkBlue"
														Font-Size="8pt" Font-Names="Verdana" Width="48px" MaxLength="3" Height="20px"></asp:textbox></td>
											</tr>
											<tr>
												<td style="WIDTH: 25%"><asp:label id="lblBKNO2" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
														Font-Names="Verdana" Width="100px">BK No.</asp:label></td>
												<td style="WIDTH: 25%"><asp:textbox id="txtBKNO2" onblur="makeUppercase(txtBKNO2);" tabIndex="7" runat="server" ForeColor="DarkBlue"
														Font-Size="8pt" Font-Names="Verdana" Width="48px" MaxLength="4" Height="20px"></asp:textbox></td>
												<td style="WIDTH: 25%"><asp:label id="lblSetNo2" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
														Font-Names="Verdana" Width="100px">Set No.</asp:label></td>
												<td style="WIDTH: 25%"><asp:textbox id="txtSetNo2" onblur="change(txtSetNo2);" tabIndex="8" runat="server" ForeColor="DarkBlue"
														Font-Size="8pt" Font-Names="Verdana" Width="48px" MaxLength="3" Height="20px"></asp:textbox></td>
											<tr>
												<td style="WIDTH: 25%"><asp:label id="lblBKNO3" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
														Font-Names="Verdana" Width="100px">BK No.</asp:label></td>
												<td style="WIDTH: 25%"><asp:textbox id="txtBKNO3" onblur="makeUppercase(txtBKNO3);" tabIndex="9" runat="server" ForeColor="DarkBlue"
														Font-Size="8pt" Font-Names="Verdana" Width="48px" MaxLength="4" Height="20px"></asp:textbox></td>
												<td style="WIDTH: 25%">
													<asp:label id="lblSetNo3" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
														Font-Names="Verdana" Width="100px">Set No.</asp:label></td>
												<td style="WIDTH: 25%"><asp:textbox id="txtSetNo3" onblur="change(txtSetNo3);" tabIndex="10" runat="server" ForeColor="DarkBlue"
														Font-Size="8pt" Font-Names="Verdana" Width="48px" MaxLength="3" Height="20px"></asp:textbox></td>
											</tr>
											<tr>
												<td style="WIDTH: 25%"><asp:label id="lblBKNO4" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
														Font-Names="Verdana" Width="100px">BK No.</asp:label></td>
												<td style="WIDTH: 25%"><asp:textbox id="txtBKNO4" onblur="makeUppercase(txtBKNO4);" tabIndex="11" runat="server" ForeColor="DarkBlue"
														Font-Size="8pt" Font-Names="Verdana" Width="48px" MaxLength="4" Height="20px"></asp:textbox></td>
												<td style="WIDTH: 25%"><asp:label id="lblSetNo4" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
														Font-Names="Verdana" Width="100px">Set No.</asp:label></td>
												<td style="WIDTH: 25%"><asp:textbox id="txtSetNo4" onblur="change(txtSetNo4);" tabIndex="12" runat="server" ForeColor="DarkBlue"
														Font-Size="8pt" Font-Names="Verdana" Width="48px" MaxLength="3" Height="20px"></asp:textbox></td>
											</tr>
										</TBODY>
									</TABLE>
								</TD>
							<TR>
								<TD style="WIDTH: 50%; HEIGHT: 31px" align="center" colSpan="2">
									<P><asp:label id="Label3" runat="server" Font-Bold="True" ForeColor="DarkBlue" Font-Size="8pt"
											Font-Names="Verdana">Browse the Images to Upload</asp:label><asp:label id="Label4" runat="server" Font-Bold="True" ForeColor="Crimson" Font-Size="8pt"
											Font-Names="Verdana" Width="184px">(Select Atleast 5 Images)</asp:label></P>
								</TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.72%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Image&nbsp;1&nbsp;</TD>
								<TD style="WIDTH: 50%; HEIGHT: 35px">
									<P><INPUT id="File1" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
											tabIndex="0" type="file" size="51" name="File1" runat="server">
									</P>
								</TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.72%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Image 
									2</TD>
								<TD style="WIDTH: 50%; HEIGHT: 35px">
									<P><INPUT id="File2" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
											tabIndex="0" type="file" size="51" name="File1" runat="server">
									</P>
								</TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.72%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Image&nbsp;3&nbsp;</TD>
								<TD style="WIDTH: 50%; HEIGHT: 35px">
									<P><INPUT id="File3" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
											tabIndex="0" type="file" size="51" name="File1" runat="server">
									</P>
								</TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.72%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Image 
									4</TD>
								<TD style="WIDTH: 50%; HEIGHT: 35px">
									<P><INPUT id="File4" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
											tabIndex="0" type="file" size="51" name="File1" runat="server">
									</P>
								</TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.81%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Image 
									5</TD>
								<TD style="WIDTH: 50%; HEIGHT: 35px">
									<P><INPUT id="File5" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
											tabIndex="0" type="file" size="51" name="File1" runat="server">
									</P>
								</TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.81%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Image 
									6</TD>
								<TD style="WIDTH: 50%; HEIGHT: 35px">
									<P><INPUT id="File6" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
											tabIndex="0" type="file" size="51" name="File1" runat="server">
									</P>
								</TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.81%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Image 
									7</TD>
								<TD style="WIDTH: 50%; HEIGHT: 35px">
									<P><INPUT id="File7" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
											tabIndex="0" type="file" size="51" name="File1" runat="server">
									</P>
								</TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.81%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Image&nbsp;8&nbsp;</TD>
								<TD style="WIDTH: 50%; HEIGHT: 35px">
									<P><INPUT id="File8" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
											tabIndex="0" type="file" size="51" name="File1" runat="server">
									</P>
								</TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.81%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Image&nbsp;9&nbsp;</TD>
								<TD style="WIDTH: 50%; HEIGHT: 35px">
									<P><INPUT id="File9" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
											tabIndex="0" type="file" size="51" name="File1" runat="server"></P>
								</TD>
							</TR>
							<TR>
								<TD style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 6.81%; COLOR: darkblue; FONT-FAMILY: Verdana; HEIGHT: 12px">Image 
									10&nbsp;</TD>
								<TD style="WIDTH: 50%; HEIGHT: 35px">
									<P><INPUT id="File10" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; WIDTH: 90%; COLOR: navy; FONT-FAMILY: Verdana; HEIGHT: 25px"
											tabIndex="0" type="file" size="51" name="File1" runat="server"></P>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="4"><asp:button id="btnSave" tabIndex="23" runat="server" Font-Bold="True" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Width="67px" Text="Save" onclick="btnSave_Click"></asp:button><asp:button id="btnCancel" tabIndex="24" runat="server" Font-Bold="True" ForeColor="DarkBlue"
							Font-Size="8pt" Font-Names="Verdana" Width="67px" Text="Cancel" onclick="btnCancel_Click"></asp:button></TD>
				</TR>
			</TABLE>
		</form></TR></TBODY></TABLE>
	</body>
</HTML>
