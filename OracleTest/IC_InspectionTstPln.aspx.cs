using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.IC_InspectionTstPln
{
    public partial class IC_InspectionTstPln : System.Web.UI.Page
    {

        OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

        protected void Page_Load(object sender, System.EventArgs e)
        {
            //if (!IsPostBack)
            //{
            string sQuery = "select *from  T15_PO_DETAIL T15 inner join T13_PO_MASTER T13 on T13.case_No=T15.Case_No inner join T17_CALL_REGISTER T17 on T13.CASE_NO=T17.CASE_NO where T17.CASE_NO='" + Request.Params["CASE_NO"].ToString() + "'";
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = sQuery;
                cmd.Connection = conn;
                conn.Open();
                OracleDataReader readerB = cmd.ExecuteReader();
                bool isUsed = false;
                while (readerB.Read() && isUsed == false)
                {
                    string sItemCD = Convert.ToString(readerB["item_cd"]);
                    switch (Convert.ToString(readerB["item_cd"]))
                    {
                        /*case "W000054":
                            litData.Text = "FISH PLATE BARS";
                            phUserInfoBox.Controls.Add(LoadControl("ProductPage/UCFishPlateBars.ascx"));   // DONE
                            isUsed = true;
                        break;
                       */

                        case "N000015":
                            litData.Text = "WELDING CABLES";
                            phUserInfoBox.Controls.Add(LoadControl("ProductPage/UCWeldingcables.ascx"));   // DONE
                            isUsed = true;
                            break;
                        case "N000475":
                            litData.Text = "VERTICAL DAMPER (CAPACITY:200KG<br />FOR AIR SPRING SUSPENSION)";
                            phUserInfoBox.Controls.Add(LoadControl("ProductPage/UCVerticalDamper.ascx"));   // Done
                            isUsed = true;
                            break;
                        case "N000007":
                            litData.Text = "CENTERING DISC<br/>(Drg No. 1268840 )";
                            phUserInfoBox.Controls.Add(LoadControl("ProductPage/UCCenteringdiskdrg1268840 .ascx"));   // DONE
                            isUsed = true;
                            break;
                        case "E000039":
                            litData.Text = "COMPACT FLOURECENT LIGHT";
                            phUserInfoBox.Controls.Add(LoadControl("ProductPage/UCCompactFluorecent.ascx"));   // DONE
                            isUsed = true;
                            break;
                        case "W000020":
                            litData.Text = "SGCI INSERTS<br/>T-381 Alt 9";
                            phUserInfoBox.Controls.Add(LoadControl("ProductPage/UCSgicInserts.ascx"));   // DONE
                            isUsed = true;
                            break;
                        case "N000044":
                            litData.Text = "XLPE INSULATED PVC SHEATHED CABLES UPTO AND INCLUDING 11100 V (FOR CATEGORY 01/C1/C2)";
                            phUserInfoBox.Controls.Add(LoadControl("ProductPage/UCXlpeInsulatedpvc.ascx"));   // DONE
                            isUsed = true;
                            break;
                        case "N000040":
                            litData.Text = "FIRE RETARDANT CURTAIN FABRIC";
                            phUserInfoBox.Controls.Add(LoadControl("ProductPage/UCFireretardantfbric.ascx"));   // DONE
                            isUsed = true;
                            break;
                        case "W000054":
                            litData.Text = "BULL GEAR FOR WAG-9 LOCO 107 TEETH";
                            phUserInfoBox.Controls.Add(LoadControl("ProductPage/UCBullGearforWag9.ascx"));   // DONE
                            isUsed = true;
                            break;
                        case "N000038"://"N000038":
                            litData.Text = "FISH PLATE BARS";
                            phUserInfoBox.Controls.Add(LoadControl("ProductPage/UCFishPlateBars.ascx"));   // DONE
                            isUsed = true;
                            break;
                        case "E000087":
                            litData.Text = "LOW MAINTENANCE LEAD ACID BATTERIES FOR 110V";
                            phUserInfoBox.Controls.Add(LoadControl("ProductPage/UCLowMaintainanceLead.ascx"));   // DONE
                            isUsed = true;
                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                //					string str; 
                string str = ex.Message;
                string str1 = str.Replace("\n", "");
                Response.Redirect("Error_Form.aspx?err=" + str1);
            }
            finally
            {
                conn.Close();
            }
            //  litData.Text = "VERTICAL DAMPER (CAPACITY:200KG<br />FOR AIR SPRING SUSPENSION)";

            // phUserInfoBox.Controls.Add(LoadControl("ProductPage/UCVerticalDamper.ascx"));   // Done
            //phUserInfoBox.Controls.Add(LoadControl("ProductPage/UCBullGearforWag9.ascx"));
            // }
        }
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        ///		Required method for Designer support - do not modify
        ///		the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

        }
    }
}