<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calls_Upload.aspx.cs" Inherits="RBS.Calls_Upload.Calls_Upload" %>


<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Calls_Upload</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" encType="multipart/form-data" runat="server">
			<INPUT id="File1" style="WIDTH: 424px; HEIGHT: 22px" type="file" size="51" name="File1"
				runat="server">
			<br>
			<input id="Submit1" type="submit" value="Upload" runat="server" onserverclick="Submit1_ServerClick">
		</form>
	</body>
</HTML>
