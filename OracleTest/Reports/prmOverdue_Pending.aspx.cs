using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using Microsoft.CSharp;
using System.IO;

namespace RBS.Reports
{
	/// <summary>
	/// Summary description for prmOverdue_Pending.
	/// </summary>
	public class prmOverdue_Pending : System.Web.UI.Page
	{
		OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{			
//				OracleCommand cmd=new OracleCommand("select to_char(sysdate,'DD/MM/YYYY - HH:MI AM') from dual",conn1);

				conn1.Open();
				OracleCommand cmd2 =new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual",conn1);
				string ss=Convert.ToString(cmd2.ExecuteScalar());
				conn1.Close();
				conn1.Open();
//				string curr_dt_time=Convert.ToString(cmd.ExecuteScalar());
				conn1.Close();
				Response.Write("<html><body>");
				Response.Write("<br><br><p align=Center><font size='2' face='Verdana'><b><u>Statement of Overdue/Pending Calls as on : "+ss+"</u></b></font></p></br><br>");
				Response.Write("<table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='90%'>");
				Response.Write("</tr></font>");
				Response.Write("<tr>");
				Response.Write("<th width='6%' valign='top' align='center' rowspan='3'><b><font size='2' face='Verdana'>Region</font></b></th>");
				Response.Write("<th width='42%' valign='top' align='center' colspan='4'><b><font size='2' face='Verdana'>No. of Overdue calls</font></b></th>");
				Response.Write("<th width='42%' valign='top' align='center' colspan='4'><b><font size='2' face='Verdana'>No. of calls pending for</font></b></th>");
				Response.Write("</tr></font>");
				Response.Write("<tr>");
				Response.Write("<th width='21%' valign='top' align='center' colspan='2'><b><font size='2' face='Verdana'>More than 7 days</font></b></th>");
				Response.Write("<th width='21%' valign='top' align='center' colspan='2'><b><font size='2' face='Verdana'>More than 5 days</font></b></th>");
				Response.Write("<th width='21%' valign='top' align='center' colspan='2'><b><font size='2' face='Verdana'>More than 7 days</font></b></th>");
				Response.Write("<th width='21%' valign='top' align='center' colspan='2'><b><font size='2' face='Verdana'>More than 5 days</font></b></th>");
				Response.Write("</tr></font>");
				Response.Write("<tr>");
				Response.Write("<td width='10.5%' valign='top' align='center'><b><font size='2' face='Verdana'>Inspection</font></b></td>");
				Response.Write("<td width='10.5%' valign='top' align='center'><b><font size='2' face='Verdana'>NSIC</font></b></td>");
				Response.Write("<td width='10.5%' valign='top' align='center'><b><font size='2' face='Verdana'>Inspection</font></b></td>");
				Response.Write("<td width='10.5%' valign='top' align='center'><b><font size='2' face='Verdana'>NSIC</font></b></td>");
				Response.Write("<td width='10.5%' valign='top' align='center'><b><font size='2' face='Verdana'>Inspection</font></b></td>");
				Response.Write("<td width='10.5%' valign='top' align='center'><b><font size='2' face='Verdana'>NSIC</font></b></td>");
				Response.Write("<td width='10.5%' valign='top' align='center'><b><font size='2' face='Verdana'>Inspection</font></b></td>");
				Response.Write("<td width='10.5%' valign='top' align='center'><b><font size='2' face='Verdana'>NSIC</font></b></td>");
				Response.Write("</tr></font>");

				string str="Select decode(region,'N','NR','E','ER','W','WR','S','SR','C','CR')region,"+
					"decode(region,'N','A','E','B','W','C','S','D','C','E')Serial_Code,"+
					"Sum(GRO_SEVEN_INSP)GRO_SEVEN_INSP,Sum(GRO_SEVEN_NSIC)GRO_SEVEN_NSIC,Sum(GRO_FIVE_INSP)GRO_FIVE_INSP,Sum(GRO_FIVE_NSIC)GRO_FIVE_NSIC,"+
					"Sum(GRP_SEVEN_INSP)GRP_SEVEN_INSP,Sum(GRP_SEVEN_NSIC)GRP_SEVEN_NSIC,Sum(GRP_FIVE_INSP)GRP_FIVE_INSP,Sum(GRP_FIVE_NSIC)GRP_FIVE_NSIC "+
					"FROM "+
					"(select T13.REGION_CODE region,T13.REGION_CODE Serial_Code,COUNT(*) GRO_SEVEN_INSP,0 GRO_SEVEN_NSIC,0 GRO_FIVE_INSP,0 GRO_FIVE_NSIC,0 GRP_SEVEN_INSP,0 GRP_SEVEN_NSIC,0 GRP_FIVE_INSP,0 GRP_FIVE_NSIC FROM T13_PO_MASTER T13, T17_CALL_REGISTER T17 "+
					"WHERE T13.CASE_NO=T17.CASE_NO AND CALL_STATUS IN ('U','S','W') AND T17.CALL_RECV_DT>'31-MAR-19' AND to_date('"+ss+"','dd/mm/yyyy')-DT_INSP_DESIRE>7 "+ 
					"AND T13.RLY_CD<>'NSIC' GROUP BY T13.REGION_CODE "+
					"UNION ALL "+
					"select T13.REGION_CODE region,T13.REGION_CODE Serial_Code,0 GRO_SEVEN_INSP,Count(*) GRO_SEVEN_NSIC,0 GRO_FIVE_INSP,0 "+ 
					"GRO_FIVE_NSIC,0 GRP_SEVEN_INSP,0 GRP_SEVEN_NSIC,0 GRP_FIVE_INSP,0 GRP_FIVE_NSIC FROM T13_PO_MASTER T13, T17_CALL_REGISTER T17 "+ 
					"WHERE T13.CASE_NO=T17.CASE_NO AND CALL_STATUS IN ('U','S','W') AND T17.CALL_RECV_DT>'31-MAR-19' AND to_date('"+ss+"','dd/mm/yyyy')-DT_INSP_DESIRE>7 "+
					"AND T13.RLY_CD='NSIC' GROUP BY T13.REGION_CODE "+
					"UNION ALL "+
					"select T13.REGION_CODE region,T13.REGION_CODE Serial_Code,0 GRO_SEVEN_INSP,0 GRO_SEVEN_NSIC,Count(*) GRO_FIVE_INSP,0 "+
					"GRO_FIVE_NSIC,0 GRP_SEVEN_INSP,0 GRP_SEVEN_NSIC,0 GRP_FIVE_INSP,0 GRP_FIVE_NSIC FROM T13_PO_MASTER T13, T17_CALL_REGISTER T17 "+
					"WHERE T13.CASE_NO=T17.CASE_NO AND CALL_STATUS IN ('U','S','W') AND T17.CALL_RECV_DT>'31-MAR-19' AND to_date('"+ss+"','dd/mm/yyyy')-DT_INSP_DESIRE>5 "+
					"AND T13.RLY_CD<>'NSIC' GROUP BY T13.REGION_CODE "+
					"UNION ALL "+
					"select T13.REGION_CODE region,T13.REGION_CODE Serial_Code,0 GRO_SEVEN_INSP,0 GRO_SEVEN_NSIC,0 GRO_FIVE_INSP,Count(*) "+
					"GRO_FIVE_NSIC,0 GRP_SEVEN_INSP,0 GRP_SEVEN_NSIC,0 GRP_FIVE_INSP,0 GRP_FIVE_NSIC FROM T13_PO_MASTER T13, T17_CALL_REGISTER T17 "+
					"WHERE T13.CASE_NO=T17.CASE_NO AND CALL_STATUS IN ('U','S','W') AND T17.CALL_RECV_DT>'31-MAR-19' AND to_date('"+ss+"','dd/mm/yyyy')-DT_INSP_DESIRE>5 "+
					"AND T13.RLY_CD='NSIC' GROUP BY T13.REGION_CODE "+
					"UNION ALL "+
					"select T13.REGION_CODE region,T13.REGION_CODE Serial_Code,0 GRO_SEVEN_INSP,0 GRO_SEVEN_NSIC,0 GRO_FIVE_INSP,0 "+
					"GRO_FIVE_NSIC,Count(*) GRP_SEVEN_INSP,0 GRP_SEVEN_NSIC,0 GRP_FIVE_INSP,0 GRP_FIVE_NSIC FROM T13_PO_MASTER "+
					"T13,T17_CALL_REGISTER T17 WHERE T13.CASE_NO=T17.CASE_NO AND CALL_STATUS='M' AND T17.CALL_RECV_DT>'31-MAR-19' AND "+
					"to_date('"+ss+"','dd/mm/yyyy')-DT_INSP_DESIRE>7 AND T13.RLY_CD<>'NSIC' GROUP BY T13.REGION_CODE "+
					"UNION ALL "+
					"select T13.REGION_CODE region,T13.REGION_CODE Serial_Code,0 GRO_SEVEN_INSP,0 GRO_SEVEN_NSIC,0 GRO_FIVE_INSP,0 GRO_FIVE_NSIC,0 "+
					"GRP_SEVEN_INSP,Count(*) GRP_SEVEN_NSIC,0 GRP_FIVE_INSP,0 GRP_FIVE_NSIC FROM T13_PO_MASTER T13, T17_CALL_REGISTER T17 WHERE "+
					"T13.CASE_NO=T17.CASE_NO AND CALL_STATUS='M' AND T17.CALL_RECV_DT>'31-MAR-19' AND to_date('"+ss+"','dd/mm/yyyy')-DT_INSP_DESIRE>7 AND "+
					"T13.RLY_CD='NSIC' GROUP BY T13.REGION_CODE "+
					"UNION ALL "+
					"select T13.REGION_CODE region,T13.REGION_CODE Serial_Code,0 GRO_SEVEN_INSP,0 GRO_SEVEN_NSIC,0 GRO_FIVE_INSP,0 GRO_FIVE_NSIC,0 "+
					"GRP_SEVEN_INSP,0 GRP_SEVEN_NSIC,Count(*) GRP_FIVE_INSP,0 GRP_FIVE_NSIC FROM T13_PO_MASTER T13, T17_CALL_REGISTER T17 WHERE "+ 
					"T13.CASE_NO=T17.CASE_NO AND CALL_STATUS='M' AND T17.CALL_RECV_DT>'31-MAR-19' AND to_date('"+ss+"','dd/mm/yyyy')-DT_INSP_DESIRE>5 AND "+
					"T13.RLY_CD<>'NSIC' GROUP BY T13.REGION_CODE "+
					"UNION ALL "+
					"select T13.REGION_CODE region,T13.REGION_CODE Serial_Code,0 GRO_SEVEN_INSP,0 GRO_SEVEN_NSIC,0 GRO_FIVE_INSP,0 GRO_FIVE_NSIC,0 "+
					"GRP_SEVEN_INSP,0 GRP_SEVEN_NSIC,0 GRP_FIVE_INSP,Count(*) GRP_FIVE_NSIC FROM T13_PO_MASTER T13, T17_CALL_REGISTER T17 WHERE "+
					"T13.CASE_NO=T17.CASE_NO AND CALL_STATUS='M' AND T17.CALL_RECV_DT>'31-MAR-19' AND to_date('"+ss+"','dd/mm/yyyy')-DT_INSP_DESIRE>5 AND "+
					"T13.RLY_CD='NSIC' GROUP BY T13.REGION_CODE) "+
					"GROUP by Region order by Serial_Code";

				OracleCommand cmdtra= new OracleCommand(str, conn1);
				conn1.Open();
				OracleDataReader drtra= cmdtra.ExecuteReader();
				int t_gt1=0,t_gt2=0,t_gt3=0,t_gt4=0,t_gt5=0,t_gt6=0,t_gt7=0,t_gt8=0;
				while(drtra.Read())
				{
					Response.Write("<tr>");
					Response.Write("<td width='7%' valign='top' align='center'><b><font size='2' face='Verdana'>"+drtra["region"]+"</font></b></td>");
					Response.Write("<td width='10.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+drtra["GRO_SEVEN_INSP"]+"</font></b></td>");
					Response.Write("<td width='10.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+drtra["GRO_SEVEN_NSIC"]+"</font></b></td>");
					Response.Write("<td width='10.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+drtra["GRO_FIVE_INSP"]+"</font></b></td>");
					Response.Write("<td width='10.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+drtra["GRO_FIVE_NSIC"]+"</font></b></td>");
					Response.Write("<td width='10.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+drtra["GRP_SEVEN_INSP"]+"</font></b></td>");
					Response.Write("<td width='10.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+drtra["GRP_SEVEN_NSIC"]+"</font></b></td>");
					Response.Write("<td width='10.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+drtra["GRP_FIVE_INSP"]+"</font></b></td>");
					Response.Write("<td width='10.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+drtra["GRP_FIVE_NSIC"]+"</font></b></td>");
					Response.Write("</tr></font>");
					t_gt1=t_gt1+Convert.ToInt32(drtra["GRO_SEVEN_INSP"]);
					t_gt2=t_gt2+Convert.ToInt32(drtra["GRO_SEVEN_NSIC"]);
					t_gt3=t_gt3+Convert.ToInt32(drtra["GRO_FIVE_INSP"]);
					t_gt4=t_gt4+Convert.ToInt32(drtra["GRO_FIVE_NSIC"]);
					t_gt5=t_gt5+Convert.ToInt32(drtra["GRP_SEVEN_INSP"]);
					t_gt6=t_gt6+Convert.ToInt32(drtra["GRP_SEVEN_NSIC"]);
					t_gt7=t_gt7+Convert.ToInt32(drtra["GRP_FIVE_INSP"]);
					t_gt8=t_gt8+Convert.ToInt32(drtra["GRP_FIVE_NSIC"]);

				}
				Response.Write("<tr>");
				Response.Write("<td width='7%' valign='top' align='center'><b><font size='2' face='Verdana'>Total</font></b></td>");
				Response.Write("<td width='10.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_gt1+"</font></b></td>");
				Response.Write("<td width='10.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_gt2+"</font></b></td>");
				Response.Write("<td width='10.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_gt3+"</font></b></td>");
				Response.Write("<td width='10.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_gt4+"</font></b></td>");
				Response.Write("<td width='10.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_gt5+"</font></b></td>");
				Response.Write("<td width='10.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_gt6+"</font></b></td>");
				Response.Write("<td width='10.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_gt7+"</font></b></td>");
				Response.Write("<td width='10.5%' valign='top' align='center'><b><font size='2' face='Verdana'>"+t_gt8+"</font></b></td>");
				Response.Write("</tr></font>");
				conn1.Close();
				Response.Write("</table>");
				Response.Write("</td>");
				Response.Write("</body></html>");
			}
			catch(Exception ex)
			{
				string str;
				str = ex.Message;
				string str1=str.Replace("\n","");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}
			finally
			{
				conn1.Close();
				conn1.Dispose();
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
