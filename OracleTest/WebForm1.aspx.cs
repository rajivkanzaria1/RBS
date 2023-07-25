using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;

namespace RBS
{
    public partial class WebForm1 : System.Web.UI.Page
    {

       // private OracleConnection conn = new OracleConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            // string constr = "user id=IBSDEV;password=tiger;data source=oracle";
            
            //string constr = "Data Source=ORCL;User Id=IBSDev;Password=IBSDev";
            OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            try
                {
                    conn.Open();
                   // connect.Enabled = false;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    conn.Dispose();
                }
            }
        }
    }
