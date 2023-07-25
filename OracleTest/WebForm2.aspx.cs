using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS
{
    public partial class WebForm2 : System.Web.UI.Page
    {
       //private readonly 
        protected void Page_Load(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection();
            //conn.ConnectionString = "Data Source=ORCL;User Id=IBSDev;Password=IBSDev";
            //try
            //{
            //    conn.Open();
            //    // connect.Enabled = false;
            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show(ex.Message.ToString());
            //}
            //finally
            //{
            //    conn.Dispose();
            //}
        }
    }
}