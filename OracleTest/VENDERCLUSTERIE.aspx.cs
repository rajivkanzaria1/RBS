using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.VENDERCLUSTERIE
{
	public partial class VENDERCLUSTERIE : System.Web.UI.Page
	{


		protected void Page_Load(object sender, System.EventArgs e)
		{

			if (!(IsPostBack))
			{
				Year.Visible = false;
				//bindddl();
			}

			// Put user code to initialize the page here
		}
		void bindddl()
		{




			ListItem lst5 = new ListItem();
			lst5 = new ListItem();
			lst5.Text = "Mechanical";
			lst5.Value = "M";

			Year.Items.Add(lst5);
			Year.Items.Insert(0, new ListItem("-Select Departmentlist item-", ""));

			lst5 = new ListItem();
			lst5.Text = "Electrical";
			lst5.Value = "E";
			Year.Items.Add(lst5);
			lst5 = new ListItem();
			lst5.Text = "Civil";
			lst5.Value = "C";
			Year.Items.Add(lst5);
			//				lst5 = new ListItem(); 
			//				lst5.Text = "Metallurgy"; 
			//				lst5.Value = "L"; 
			//				Dropdownlist1.Items.Add(lst5); 
			lst5 = new ListItem();
			lst5.Text = "Textiles";
			lst5.Value = "T";
			Year.Items.Add(lst5);
			lst5 = new ListItem();
			lst5.Text = "M & P";
			lst5.Value = "Z";
			Year.Items.Add(lst5);
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

		}
		#endregion

		protected void departmentchanged(object sender, System.EventArgs e)
		{
			OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			string deptname = Year.SelectedItem.Value;
			// xyz.Visible=false;
			xyz.Visible = false;

			try
			{

				//decode(v.department_name,'M','Mechanical','E','Electrical','C','Civil','T','Textiles','Z','M P','') Department
				//string sql="select v.department_name,c.Cluster_name,c.geographical_partition,x.vend_cd,x.vend_name,x.vend_add1,l.city,y.ie_name from t100_vender_cluster v inner join T101_ie_cluster i on v.cluster_code=i.cluster_code  inner join T05_vendor x on x.vend_cd=v.vendor_code inner join t09_ie y on y.ie_cd=i.ie_code inner join t99_cluster_master c on c.cluster_code=v.cluster_code inner join t03_city l on l.city_cd=x.vend_city_cd where  c.REGION_CODE='"+Session["Region"].ToString()+"' and  v.department_name='"+deptname+"' order by c.Cluster_name";
				//string sql="select v.department_name,c.Cluster_name,c.geographical_partition,x.vend_cd,x.vend_name,x.vend_add1,l.city,y.ie_name from t100_vender_cluster v inner join t99_cluster_master c  on c.cluster_code=v.cluster_code  left outer join t101_ie_cluster x on x.cluster_code=c.cluster_code left outer join t09_ie y on y.ie_cd=x.ie_code left outer join t05_vendor x on x.vend_cd=v.vendor_code inner join t03_city l on l.city_cd=x.vend_city_cd where c.REGION_CODE='"+Session["Region"].ToString()+"' and  v.department_name='"+deptname+"'and y.ie_name is not null  order by c.Cluster_name";
				string sql = "select decode(v.department_name,'M','Mechanical','E','Electrical','C','Civil','T','Textiles','Z','M P','') Department,c.Cluster_name,c.geographical_partition,x.vend_cd,x.vend_name,x.vend_add1,l.city,y.ie_name from t100_vender_cluster v inner join t99_cluster_master c  on c.cluster_code=v.cluster_code left outer join t101_ie_cluster x on x.cluster_code=c.cluster_code left outer join t09_ie y on y.ie_cd=x.ie_code left outer join t05_vendor x on x.vend_cd=v.vendor_code inner join t03_city l on l.city_cd=x.vend_city_cd where c.REGION_CODE='" + Session["Region"].ToString() + "' and  v.department_name='" + deptname + "'  order by c.Cluster_name";

				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='3'>");
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='6'>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>DEPARTMENT NAME</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>CLUSTER NAME</font></b></th>");
				Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>GEOGRAPHICAL PARTITION</font></b></th>");
				Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>VENDOR CODE</font></b></th>");
				Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>VENDOR NAME</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>ADDRESS</font></b></th>");
				Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>CITY</font></b></th>");
				Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>IE NAME</font></b></th>");

				Response.Write("</tr></font>");

				while (reader.Read())
				{
					Response.Write("<tr>");
					Response.Write("<td width='20%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["Department"]); Response.Write("</td>");
					Response.Write("<td width='20%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CLUSTER_NAME"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["GEOGRAPHICAL_PARTITION"]); Response.Write("</td>");
					Response.Write("<td width='20%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["VEND_CD"]); Response.Write("</td>");
					Response.Write("<td width='20%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["VEND_NAME"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["VEND_ADD1"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CITY"]); Response.Write("</td>");
					Response.Write("<td width='20%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
					Response.Write("</tr>");
				};

				Response.Write("</table>");
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}
			finally
			{
				conn.Close();
			}


		}


		protected void radiochanged123(object sender, System.EventArgs e)
		{
			Year.Visible = true;
			bindddl();
		}


		protected void radiochanged(object sender, System.EventArgs e)

		{
			xyz.Visible = false;
			//xyz.Visible=false;
			OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
			try
			{
				//string sql="select v.department_name,c.Cluster_name,c.geographical_partition,x.vend_cd,x.vend_name,x.vend_add1,l.city,y.ie_name from t100_vender_cluster v inner join T101_ie_cluster i on v.cluster_code=i.cluster_code  inner join T05_vendor x on x.vend_cd=v.vendor_code inner join t09_ie y on y.ie_cd=i.ie_code inner join t99_cluster_master c on c.cluster_code=v.cluster_code inner join t03_city l on l.city_cd=x.vend_city_cd where  c.REGION_CODE='"+Session["Region"].ToString()+"' order by c.Cluster_name";
				//string sql="select v.department_name,c.Cluster_name,c.geographical_partition,x.vend_cd,x.vend_name,x.vend_add1,l.city,y.ie_name from t100_vender_cluster v inner join t99_cluster_master c  on c.cluster_code=v.cluster_code  left outer join t101_ie_cluster x on x.cluster_code=c.cluster_code left outer join t09_ie y on y.ie_cd=x.ie_code left outer join t05_vendor x on x.vend_cd=v.vendor_code inner join t03_city l on l.city_cd=x.vend_city_cd where c.REGION_CODE='"+Session["Region"].ToString()+"' and y.ie_name is not null  order by c.Cluster_name";
				string sql = "select decode(v.department_name,'M','Mechanical','E','Electrical','C','Civil','T','Textiles','Z','M P','') Department,c.Cluster_name,c.geographical_partition,x.vend_cd,x.vend_name,x.vend_add1,l.city,y.ie_name from t100_vender_cluster v inner join t99_cluster_master c  on c.cluster_code=v.cluster_code left outer join t101_ie_cluster x on x.cluster_code=c.cluster_code left outer join t09_ie y on y.ie_cd=x.ie_code left outer join t05_vendor x on x.vend_cd=v.vendor_code inner join t03_city l on l.city_cd=x.vend_city_cd where c.REGION_CODE='" + Session["Region"].ToString() + "' order by c.Cluster_name";

				OracleCommand cmd = new OracleCommand(sql, conn);
				conn.Open();
				OracleDataReader reader = cmd.ExecuteReader();
				Response.Write("<br><table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse;' bordercolor='#111111' width='100%'>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='3'>");
				Response.Write("</td>"); Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<td width='100%' colspan='6'>");
				Response.Write("</td>");
				Response.Write("</tr>");
				Response.Write("<tr>");
				Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>DEPARTMENT NAME</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>CLUSTER NAME</font></b></th>");
				Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>GEOGRAPHICAL PARTITION</font></b></th>");
				Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>VENDOR CODE</font></b></th>");
				Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>VENDOR NAME</font></b></th>");
				Response.Write("<th width='15%' valign='top'><b><font size='1' face='Verdana'>ADDRESS</font></b></th>");
				Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>CITY</font></b></th>");
				Response.Write("<th width='20%' valign='top'><b><font size='1' face='Verdana'>IE NAME</font></b></th>");

				Response.Write("</tr></font>");

				while (reader.Read())
				{
					Response.Write("<tr>");
					Response.Write("<td width='20%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["Department"]); Response.Write("</td>");
					Response.Write("<td width='20%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CLUSTER_NAME"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["GEOGRAPHICAL_PARTITION"]); Response.Write("</td>");
					Response.Write("<td width='20%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["VEND_CD"]); Response.Write("</td>");
					Response.Write("<td width='20%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["VEND_NAME"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["VEND_ADD1"]); Response.Write("</td>");
					Response.Write("<td width='15%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["CITY"]); Response.Write("</td>");
					Response.Write("<td width='20%' valign='top' align='center'> <font size='1' face='Verdana'>"); Response.Write(reader["IE_NAME"]); Response.Write("</td>");
					Response.Write("</tr>");
				};

				Response.Write("</table>");
			}
			catch (Exception ex)
			{
				string str;
				str = ex.Message;
				string str1 = str.Replace("\n", "");
				Response.Redirect(("Error_Form.aspx?err=" + str1));
			}
			finally
			{
				conn.Close();
			}




		}




	}
}