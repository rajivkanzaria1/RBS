using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS
{
    public partial class IC_Intermediate : System.Web.UI.Page
    {
        
        protected System.Web.UI.WebControls.DropDownList lstCallStatus;
       
        string wIECD;
        protected System.Web.UI.WebControls.Label lblCallStatus;
        
        protected System.Web.UI.WebControls.DropDownList lstCallCancelStatus;
        //protected System.Web.UI.WebControls.TextBox txtSetNo;
        //protected System.Web.UI.WebControls.TextBox txtBKNO;
        
        protected System.Web.UI.WebControls.TextBox txtbksetno;
        protected System.Web.UI.WebControls.Label Label8;
        protected System.Web.UI.WebControls.CheckBox chk1;
        protected System.Web.UI.WebControls.CheckBox chk2;
        protected System.Web.UI.WebControls.CheckBox chk3;
        protected System.Web.UI.WebControls.CheckBox chk4;
        protected System.Web.UI.WebControls.CheckBox chk5;
        protected System.Web.UI.WebControls.CheckBox chk6;
        protected System.Web.UI.WebControls.CheckBox chk7;
        protected System.Web.UI.WebControls.CheckBox chk8;
        protected System.Web.UI.WebControls.CheckBox chk9;
        protected System.Web.UI.WebControls.CheckBox chk10;
        protected System.Web.UI.WebControls.CheckBox chk11;
        protected System.Web.UI.WebControls.CheckBox chk12;
        
        protected System.Web.UI.WebControls.TextBox txtCdesc;
        protected System.Web.UI.WebControls.Panel Panel_1;
        protected System.Web.UI.WebControls.Button btnSaveCancellation;
        protected System.Web.UI.WebControls.Label Label14;
        
        protected System.Web.UI.WebControls.DropDownList lstCallCancelCharges;
        protected System.Web.UI.WebControls.HyperLink HyperLink1;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label32;
        protected System.Web.UI.WebControls.TextBox txtRemarks;
        protected System.Web.UI.WebControls.Label lblRemarks;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label Label6;
        
        
        protected System.Web.UI.WebControls.TextBox txtHologram;
        
        

        //
        

        protected System.Web.UI.WebControls.Label txtCaseNo;
        protected System.Web.UI.WebControls.Label txtDtOfReciept;
               

        OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        string CASE_NO, CALL_RECV_DT, ACTIONAR, CALL_SNO;        
        protected System.Web.UI.WebControls.Label Label11;
        //
        private void SetAccepted()
        {
            btnSaveFiles.Enabled = false;
            txtBKNO1.Enabled = false;
            txtSetNo1.Enabled = false;
            File4.Disabled = true;
            File5.Disabled = true;
            File6.Disabled = true;
            File7.Disabled = true;
            File8.Disabled = true;
            File9.Disabled = true;
            File10.Disabled = true;
            File11.Disabled = true;
            File12.Disabled = true;
            File13.Disabled = true;
        }


        //
        private void FillFileNames(bool def)
        {

            def = false;

            conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

            DataSet ds = new DataSet();
            //string str = "SELECT * FROM IC_INTERMEDIATE WHERE CASE_NO='" + CASE_NO.Trim() + "' AND CALL_RECV_DT= TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CALL_SNO='" + CALL_SNO + "' AND CONSIGNEE_CD ='" + ddlCondignee.SelectedValue + "'";
            string str = "SELECT * FROM IC_INTERMEDIATE WHERE CASE_NO='" + CASE_NO.Trim() + "' AND CALL_RECV_DT= TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CALL_SNO='" + CALL_SNO + "' ORDER BY DATETIME DESC";
            OracleDataAdapter da = new OracleDataAdapter(str, conn);
            OracleCommand myOracleCommand = new OracleCommand(str, conn);
            conn.Open();
            da.SelectCommand = myOracleCommand;
            conn.Close();
            da.Fill(ds, "Table");


            bool oneonly = false;
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow itemDR in ds.Tables[0].Rows)
                    {

                        if (Convert.ToString(ddlCondignee.SelectedValue) == Convert.ToString(itemDR["CONSIGNEE_CD"]))
                        {
                            txtBKNO1.Text = Convert.ToString(itemDR["BK_NO"]);
                            txtSetNo1.Text = Convert.ToString(itemDR["SET_NO"]).PadLeft(3, '0');
                            setControls(itemDR, def);
                            oneonly = true;
                            btnViewIC.Visible = true;
                            btnViewIC.Enabled = true;

                            if (Convert.ToString(itemDR["CONSGN_CALL_STATUS"]) == "A") SetAccepted();

                            break;
                        }

                        if (!oneonly)
                        { setControls(itemDR, def); oneonly = true; }
                    }
                }
            }
        }

        private void setControls(DataRow itemDR, bool def)
        {

            if (Convert.ToString(itemDR["FILE_1"]) != "" || def)
            {
                //if (!isPostBack)
                //{
                LblFile4.Visible = true;
                CkBFile4.Visible = true;
                CkBFile4.Checked = true;
                File4.Disabled = true;
                File4.Style.Add("width", "50%");
                LblFile4.Text = Convert.ToString(itemDR["FILE_1"]);
                //}

            }
            else
            {
                LblFile4.Visible = false;
                CkBFile4.Visible = false;
                CkBFile4.Checked = false;
                File4.Disabled = false;
                File4.Style.Add("width", "100%");
            }
            if (Convert.ToString(itemDR["FILE_2"]) != "" || def)
            {
                LblFile5.Visible = true;
                CkBFile5.Visible = true;

                CkBFile5.Checked = true;
                File5.Disabled = true;
                File5.Style.Add("width", "50%");
                LblFile5.Text = Convert.ToString(itemDR["FILE_2"]);
            }
            else
            {
                LblFile5.Visible = false;
                CkBFile5.Visible = false;

                CkBFile5.Checked = false;
                File5.Disabled = false;
                File5.Style.Add("width", "100%");
            }

            if (Convert.ToString(itemDR["FILE_3"]) != "" || def)
            {
                LblFile6.Visible = true;
                CkBFile6.Visible = true;

                CkBFile6.Checked = true;
                File6.Disabled = true;
                File6.Style.Add("width", "50%");
                LblFile6.Text = Convert.ToString(itemDR["FILE_3"]);
            }
            else
            {
                LblFile6.Visible = false;
                CkBFile6.Visible = false;

                CkBFile6.Checked = false;
                File6.Disabled = false;
                File6.Style.Add("width", "100%");
            }
            if (Convert.ToString(itemDR["FILE_4"]) != "" || def)
            {
                LblFile7.Visible = true;
                CkBFile7.Visible = true;

                CkBFile7.Checked = true;
                File7.Disabled = true;
                File7.Style.Add("width", "50%");
                LblFile7.Text = Convert.ToString(itemDR["FILE_4"]);
            }
            else
            {
                LblFile7.Visible = false;
                CkBFile7.Visible = false;

                CkBFile7.Checked = false;
                File7.Disabled = false;
                File7.Style.Add("width", "100%");
            }
            if (Convert.ToString(itemDR["FILE_5"]) != "" || def)
            {
                LblFile8.Visible = true;
                CkBFile8.Visible = true;
                CkBFile8.Checked = true;
                File8.Disabled = true;
                File8.Style.Add("width", "50%");
                LblFile8.Text = Convert.ToString(itemDR["FILE_5"]);
            }
            else
            {
                LblFile8.Visible = false;
                CkBFile8.Visible = false;
                CkBFile8.Checked = false;
                File8.Disabled = false;
                File8.Style.Add("width", "100%");
            }
            if (Convert.ToString(itemDR["FILE_6"]) != "" || def)
            {
                LblFile9.Visible = true;
                CkBFile9.Visible = true;

                CkBFile9.Checked = true;
                File9.Disabled = true;
                File9.Style.Add("width", "50%");
                LblFile9.Text = Convert.ToString(itemDR["FILE_6"]);
            }
            else
            {
                LblFile9.Visible = false;
                CkBFile9.Visible = false;

                CkBFile9.Checked = false;
                File9.Disabled = false;
                File9.Style.Add("width", "100%");
            }
            if (Convert.ToString(itemDR["FILE_7"]) != "" || def)
            {
                LblFile10.Visible = true;
                CkBFile10.Visible = true;
                CkBFile10.Checked = true;
                File10.Disabled = true;
                File10.Style.Add("width", "50%");
                LblFile10.Text = Convert.ToString(itemDR["FILE_7"]);
            }
            else
            {
                LblFile10.Visible = false;
                CkBFile10.Visible = false;
                CkBFile10.Checked = false;
                File10.Disabled = false;
                File10.Style.Add("width", "100%");
            }
            if (Convert.ToString(itemDR["FILE_8"]) != "" || def)
            {
                LblFile11.Visible = true;
                CkBFile11.Visible = true;
                CkBFile11.Checked = true;
                File11.Disabled = true;
                File11.Style.Add("width", "50%");
                LblFile11.Text = Convert.ToString(itemDR["FILE_8"]);
            }
            else
            {
                LblFile11.Visible = false;
                CkBFile11.Visible = false;
                CkBFile11.Checked = false;
                File11.Disabled = false;
                File11.Style.Add("width", "100%");
            }
            if (Convert.ToString(itemDR["FILE_9"]) != "" || def)
            {
                LblFile12.Visible = true;
                CkBFile12.Visible = true;
                CkBFile12.Checked = true;
                File12.Disabled = true;
                File12.Style.Add("width", "50%");
                LblFile12.Text = Convert.ToString(itemDR["FILE_9"]);
            }
            else
            {
                LblFile12.Visible = false;
                CkBFile12.Visible = false;
                CkBFile12.Checked = false;
                File12.Disabled = false;
                File12.Style.Add("width", "100%");
            }
            if (Convert.ToString(itemDR["FILE_10"]) != "" || def)
            {
                LblFile13.Visible = true;
                CkBFile13.Visible = true;
                CkBFile13.Checked = true;
                File13.Disabled = true;
                File13.Style.Add("width", "50%");
                LblFile13.Text = Convert.ToString(itemDR["FILE_10"]);
            }
            else
            {
                LblFile13.Visible = false;
                CkBFile13.Visible = false;
                CkBFile13.Checked = false;
                File13.Disabled = false;
                File13.Style.Add("width", "100%");
            }
        }
        //

        //protected System.Web.UI.WebControls.HyperLink HyperLink2;
        //System.Data.OracleClient.OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        void display_rejection_type()
        {

            conn.Open();
            OracleCommand myCommand1 = new OracleCommand("select RLY_NONRLY from T13_PO_MASTER where CASE_NO= '" + lblCSNO.Text.Trim() + "'", conn);
            string w_rly_nonrly = Convert.ToString(myCommand1.ExecuteScalar());
            conn.Close(); ;
            if (w_rly_nonrly != "R")
            {
                lstRejectionType.Visible = true;
                Label18.Visible = true;
                lstRejectionType.Items.Clear();
                ListItem lst1 = new ListItem();
                lst1 = new ListItem();
                lst1.Text = "Local (10,000/- Per Manday)";
                lst1.Value = "L";
                lstRejectionType.Items.Add(lst1);
                lst1 = new ListItem();
                lst1.Text = "Out Station (15,000/- Per Manday)";
                lst1.Value = "O";
                lstRejectionType.Items.Add(lst1);
                lstRejectionType.Items.Insert(0, "");
                DisplayAlert("Kindly Select Local/Outstation From Rejection Type!!!");
                //				txtCanCharges.Text=Convert.ToString(lstCallCancelCharges.SelectedValue);
            }
            else
            {
                lstRejectionType.Visible = false;
                Label18.Visible = false;
                rejection_charges();
            }
            conn.Close();

        }

        void rejection_charges()
        {
            try
            {
                conn.Open();
                OracleCommand myCommand11 = new OracleCommand("select RLY_NONRLY from T13_PO_MASTER where CASE_NO= '" + lblCSNO.Text.Trim() + "'", conn);
                string rly_nonrly = Convert.ToString(myCommand11.ExecuteScalar());
                string str1 = "SELECT round(SUM(VALUE),2) VALUE FROM (SELECT T18.CASE_NO,T18.CALL_RECV_DT, T18.CALL_SNO,(T15.VALUE/T15.QTY)*T18.QTY_TO_INSP VALUE FROM T18_CALL_DETAILS T18, T15_PO_DETAIL T15 WHERE T15.CASE_NO=T18.CASE_NO AND T15.ITEM_SRNO=T18.ITEM_SRNO_PO AND T18.CASE_NO='" + lblCSNO.Text.Trim() + "' AND CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + ") GROUP BY CASE_NO,CALL_RECV_DT,CALL_SNO";
                OracleCommand myCommand2 = new OracleCommand(str1, conn);
                double w_mat_value = Convert.ToDouble(myCommand2.ExecuteScalar());
                conn.Close();
                txtMatValue.Text = Convert.ToString(w_mat_value);
                double w_cancharges = 0;
                Label12.Visible = true;
                txtMatValue.Visible = true;
                if (rly_nonrly == "R")
                {
                    txtRejCharges.Text = Convert.ToString(w_mat_value * 0.9 / 100);

                    w_cancharges = Math.Round(Convert.ToDouble(txtRejCharges.Text), 2);
                    if (w_cancharges < 5000)
                    {
                        txtRejCharges.Text = "5000";
                    }


                }
                else if (rly_nonrly != "R")
                {
                    txtRejCharges.Text = Convert.ToString(w_mat_value * 1 / 100);
                    w_cancharges = Math.Round(Convert.ToDouble(txtRejCharges.Text), 2);
                    conn.Open();
                    OracleCommand myCommandV = new OracleCommand("select COUNT(*) FROM T47_IE_WORK_PLAN where CASE_NO= '" + lblCSNO.Text.Trim() + "' AND CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text, conn);
                    int no_of_visits = Convert.ToInt32(myCommandV.ExecuteScalar());
                    conn.Close();
                    double w_rejcharges = 0;
                    if (lstRejectionType.SelectedValue == "L")
                    {
                        w_rejcharges = no_of_visits * 10000;
                        if (w_rejcharges > w_cancharges)
                        {
                            txtRejCharges.Text = Convert.ToString(w_rejcharges);
                        }
                    }
                    if (lstRejectionType.SelectedValue == "O")
                    {
                        w_rejcharges = no_of_visits * 15000;
                        if (w_rejcharges > w_cancharges)
                        {
                            txtRejCharges.Text = Convert.ToString(w_rejcharges);
                        }
                    }

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message;
                string str1 = str.Replace("\n", "");
                Response.Redirect("Error_Form.aspx?err=" + str1);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            //txtRejCharges.Enabled=false;
        }
        private void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here



            lstCallStatus_SelectedIndexChanged();

            btnSaveFiles.Attributes.Add("OnClick", "JavaScript:validateFiles();");
            if (Convert.ToString(Request.Params["CASE_NO"]) == null || Convert.ToString(Request.Params["CALL_RECV_DT"]) == null)
            {
                //txtCaseNo.Text = "";
                //txtDtOfReciept.Text = "";
                //lblCSNO.Text = "";
                CASE_NO = "";
                CALL_RECV_DT = "";
                CALL_SNO = "";
                ACTIONAR = "";
            }
            else
            {
                //txtCaseNo.Text = Convert.ToString(Request.Params["CASE_NO"].Trim());
                //txtDtOfReciept.Text = Convert.ToString(Request.Params["CALL_RECV_DT"].Trim());
                //lblCSNO.Text = Convert.ToString(Request.Params["CALL_SNO"].Trim());

                CASE_NO = Convert.ToString(Request.Params["CASE_NO"].Trim());
                CALL_RECV_DT = Convert.ToString(Request.Params["CALL_RECV_DT"].Trim());
                CALL_SNO = Convert.ToString(Request.Params["CALL_SNO"].Trim());
                ACTIONAR = Request.Params["ACTIONAR"].ToString();
            }
            //set_visible();
            //
            //
            // Put user code to initialize the page here
            //btnSave.Attributes.Add("OnClick", "JavaScript:validate();");
            //btnSaveCancellation.Attributes.Add("OnClick", "JavaScript:validate();");
            //btnSaveCancellation.Attributes.Add("OnClick", "JavaScript:validate1();");
            //string CASE_NO,CALL_RECV_DT,CALL_SNO;
            CASE_NO = Request.Params["CASE_NO"].ToString();
            CALL_RECV_DT = Request.Params["CALL_RECV_DT"].ToString();
            CALL_SNO = Request.Params["CALL_SNO"].ToString();
            //			ACTION=Request.Params["ACTION"].ToString();
            ACTIONAR = Request.Params["ACTIONAR"].ToString();

            if (ACTIONAR == "R")
            {
                btnSave.Text = "Rejected!";
                lblRejCharges.Visible = true;
                txtRejCharges.Visible = true;
                txtRejCharges.Enabled = true;

            }




            wIECD = Session["IE_CD"].ToString();
            //HyperLink1.NavigateUrl="/RBS/IE_IC_Photo_Upload.aspx?CASE_NO="+CASE_NO+"&CALL_RECV_DT="+CALL_RECV_DT+"&CALL_SNO="+CALL_SNO;
            string str = "";
            if (!(IsPostBack))
            {
                //DataSet ds = new DataSet();
                //string str = "select CALL_STATUS_CD,CALL_STATUS_DESC from T21_CALL_STATUS_CODES where CALL_STATUS_CD<>'B' order by CALL_STATUS_DESC";
                //OracleDataAdapter da = new OracleDataAdapter(str, conn);
                //OracleCommand myOracleCommand = new OracleCommand(str, conn);
                //conn.Open();
                //da.SelectCommand = myOracleCommand;
                //conn.Close();
                //da.Fill(ds, "Table");
                //lstCallStatus.DataValueField = "CALL_STATUS_CD";
                //lstCallStatus.DataTextField = "CALL_STATUS_DESC";
                //lstCallStatus.DataSource = ds;
                //lstCallStatus.DataBind();
                //lstCallStatus.SelectedValue = "M";

                //

                DataSet ds = new DataSet();
                str = "select 0 as consignee_cd,'Select Consignee' as consignee_firm from dual union select distinct csn.consignee_cd,CSN.consignee_cd ||'-'|| csn.consignee consignee_firm   from t18_call_details CDT inner join V06_CONSIGNEE CSN ";
                str += " on cdt.consignee_cd = csn.consignee_cd where case_no = '" + CASE_NO + "' and call_recv_dt = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') and call_sno = '" + CALL_SNO + "' ";
                OracleDataAdapter da = new OracleDataAdapter(str, conn);
                OracleCommand myOracleCommand = new OracleCommand(str, conn);
                conn.Open();
                da.SelectCommand = myOracleCommand;
                conn.Close();
                da.Fill(ds, "Table");
                ddlCondignee.DataValueField = "consignee_cd";
                ddlCondignee.DataTextField = "consignee_firm";
                ddlCondignee.DataSource = ds;
                ddlCondignee.DataBind();
                //ddlCondignee.SelectedValue = "M";
                FillFileNames(false);

                txtBKNO1.Text = "";
                txtSetNo1.Text = "";

                //


                //				-- xx--			
                //				ListItem lst1 = new ListItem(); 
                //				lst1 = new ListItem(); 
                //				lst1.Text = "Pending"; 
                //				lst1.Value = "M"; 
                //				lstCallStatus.Items.Add(lst1);
                //				lst1 = new ListItem(); 
                //				lst1.Text = "Accepted"; 
                //				lst1.Value = "A"; 
                //				lstCallStatus.Items.Add(lst1); 
                //				lst1 = new ListItem(); 
                //				lst1.Text = "Rejection"; 
                //				lst1.Value = "R"; 
                //				lstCallStatus.Items.Add(lst1); 
                //				lst1 = new ListItem(); 
                //				lst1.Text = "Cancelled"; 
                //				lst1.Value = "C"; 
                //				lstCallStatus.Items.Add(lst1); 
                //				lst1 = new ListItem(); 
                //				lst1.Text = "Under Lab Testing"; 
                //				lst1.Value = "U"; 
                //				lstCallStatus.Items.Add(lst1); 
                //				lst1 = new ListItem(); 
                //				lst1.Text = "Still Under Inspection"; 
                //				lst1.Value = "S"; 
                //				lstCallStatus.Items.Add(lst1);
                //				lst1 = new ListItem(); 
                //				lst1.Text = "Stage Inspection"; 
                //				lst1.Value = "G"; 
                //				lstCallStatus.Items.Add(lst1);
                //				lst1 = new ListItem(); 
                //				lst1.Text = "Withheld"; 
                //				lst1.Value = "W"; 
                //				lstCallStatus.Items.Add(lst1);
                //				-- xx--	

            }

            AcceptedFun();
            fifo_voilate_check();
            if (ACTIONAR == "R" && !(IsPostBack))
            {
                display_rejection_type();

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
            this.ddlCondignee.SelectedIndexChanged += new System.EventHandler(this.DdlCondignee_SelectedIndexChanged);
            this.CkBFile4.CheckedChanged += new System.EventHandler(this.CkBFile4_CheckedChanged);
            this.CkBFile5.CheckedChanged += new System.EventHandler(this.CkBFile5_CheckedChanged);
            this.CkBFile6.CheckedChanged += new System.EventHandler(this.CkBFile6_CheckedChanged);
            this.CkBFile7.CheckedChanged += new System.EventHandler(this.CkBFile7_CheckedChanged);
            this.CkBFile8.CheckedChanged += new System.EventHandler(this.CkBFile8_CheckedChanged);
            this.CkBFile9.CheckedChanged += new System.EventHandler(this.CkBFile9_CheckedChanged);
            this.CkBFile10.CheckedChanged += new System.EventHandler(this.CkBFile10_CheckedChanged);
            this.CkBFile11.CheckedChanged += new System.EventHandler(this.CkBFile11_CheckedChanged);
            this.CkBFile12.CheckedChanged += new System.EventHandler(this.CkBFile12_CheckedChanged);
            this.CkBFile13.CheckedChanged += new System.EventHandler(this.CkBFile13_CheckedChanged);
            this.btnSaveFiles.Click += new System.EventHandler(this.btnSaveFiles_Click);
            this.btnCancelFiles.Click += new System.EventHandler(this.btnCancelFiles_Click);
            this.btnViewIC.Click += new System.EventHandler(this.btnViewIC_Click);
            this.lstRejectionType.SelectedIndexChanged += new System.EventHandler(this.lstRejectionType_SelectedIndexChanged);
            this.btnUploadFiles.Click += new System.EventHandler(this.btnUploadFiles_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnRefreshAll.Click += new System.EventHandler(this.btnRefreshAll_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion
        void fifo_voilate_check()
        {
            try
            {
                conn.Open();
                string str1 = "SELECT count(*) FROM T17_CALL_REGISTER T17 WHERE DT_INSP_DESIRE<to_date('" + lblInpDesireDT.Text.Trim() + "','dd/mm/yyyy') and CALL_STATUS='M' AND IE_CD='" + Session["IE_CD"] + "' AND REGION_CODE='" + Session["Region"] + "' AND CALL_RECV_DT>TO_DATE('01/04/2021','DD/MM/YYYY')";
                OracleCommand myCommand2 = new OracleCommand(str1, conn);
                int wFIFOVoilate = Convert.ToInt32(myCommand2.ExecuteScalar());
                if (wFIFOVoilate > 0)
                {
                    DisplayAlert("You are Voilating the FIFO for attending Calls, kindly enter the reason for voilating FIFO!!!");
                    lblFIFO.Visible = true;
                    txtFIFO.Visible = true;

                }
                else
                {
                    lblFIFO.Visible = false;
                    txtFIFO.Visible = false;
                }
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message;
                //				Response.Write(ex);
            }
            finally
            {
                conn.Close();
                //conn.Dispose();
            }
        }
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            //Response.Redirect("Calls_Marked_To_IE.aspx?ACTION=" + Request.Params["ACTION"].ToString());
            Response.Redirect("Call_Status_Edit_Form.aspx?CASE_NO=" + CASE_NO + "&CALL_RECV_DT=" + CALL_RECV_DT + "&CALL_SNO=" + CALL_SNO + "&IE_CD=" + wIECD + "&ACTION=" + Request.Params["ACTION"].ToString() + "' Font-Names='Verdana' Font-Size='8pt'");
        }
        private void DisplayAlert(string msg)
        {
            Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
        }

        void photo_upload(string BK_NO, string SET_NO)
        {

            conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            OracleCommand cmd = new OracleCommand("select to_char(sysdate,'dd/mm/yyyy') from dual", conn);
            conn.Open();
            string ss = Convert.ToString(cmd.ExecuteScalar());
            conn.Close();
            conn.Open();
            OracleTransaction myTrans = conn.BeginTransaction();

            try
            {
                //				string MySql="";

                //				string MySql="UPDATE T49_IC_PHOTO_ENCLOSED SET IC_PHOTO='"+File1.Value+"' "+		
                //					"where "+
                //					"CASE_NO='"+txtCaseNo.Text.Trim()+"' and BK_NO='"+BK_NO+"' AND SET_NO='"+SET_NO+"'";

                //				OracleCommand cmd1 = new OracleCommand(MySql,conn);
                //				cmd1.Transaction=myTrans;
                //				cmd1.ExecuteNonQuery();
                string myUpdateQuery = "Update T49_IC_PHOTO_ENCLOSED set ";
                if (File1.PostedFile != null && File1.PostedFile.ContentLength > 0)
                {
                    string fn = "", fx = "", MyFile = "";
                    MyFile = lblCSNO.Text.Trim() + "-" + BK_NO + "-" + SET_NO;
                    fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
                    fx = System.IO.Path.GetExtension(File1.PostedFile.FileName).ToUpper().Substring(1);
                    if (fx != "" && fx != "PDF")
                    {
                        throw new System.Exception("KINDLY UPLOAD DIGITALLY SIGNED PDF FILES ONLY");
                    }
                    String SaveLocation = null;
                    SaveLocation = Server.MapPath("BILL_IC/" + MyFile + "." + fx);
                    File1.PostedFile.SaveAs(SaveLocation);
                    myUpdateQuery = myUpdateQuery + " IC_PHOTO='" + MyFile + "." + fx + "' ";
                }

                if (File2.PostedFile != null && File2.PostedFile.ContentLength > 0)
                {
                    string fn = "", fx = "", MyFile = "";
                    MyFile = lblCSNO.Text.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "A1";
                    fn = System.IO.Path.GetFileName(File2.PostedFile.FileName);
                    fx = System.IO.Path.GetExtension(File2.PostedFile.FileName).ToUpper().Substring(1);
                    if (fx != "" && fx != "PDF")
                    {
                        throw new System.Exception("KINDLY UPLOAD DIGITALLY SIGNED PDF FILES ONLY");
                    }
                    String SaveLocation = null;
                    SaveLocation = Server.MapPath("BILL_IC/" + MyFile + "." + fx);
                    File2.PostedFile.SaveAs(SaveLocation);
                    myUpdateQuery = myUpdateQuery + " , IC_PHOTO_A1='" + MyFile + "." + fx + "' ";
                }

                if (File3.PostedFile != null && File3.PostedFile.ContentLength > 0)
                {
                    string fn = "", fx = "", MyFile = "";
                    MyFile = lblCSNO.Text.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "A2";
                    fn = System.IO.Path.GetFileName(File3.PostedFile.FileName);
                    fx = System.IO.Path.GetExtension(File3.PostedFile.FileName).ToUpper().Substring(1);
                    if (fx != "" && fx != "PDF")
                    {
                        throw new System.Exception("KINDLY UPLOAD DIGITALLY SIGNED PDF FILES ONLY");
                    }
                    String SaveLocation = null;
                    SaveLocation = Server.MapPath("BILL_IC/" + MyFile + "." + fx);
                    File3.PostedFile.SaveAs(SaveLocation);
                    myUpdateQuery = myUpdateQuery + " , IC_PHOTO_A2='" + MyFile + "." + fx + "' ";
                }

                if (File14.PostedFile != null && File14.PostedFile.ContentLength > 0)
                {
                    string fn = "", fx = "", MyFile = "";
                    MyFile = lblCSNO.Text.Trim() + "-" + BK_NO + "-" + SET_NO;
                    fn = System.IO.Path.GetFileName(File14.PostedFile.FileName);
                    fx = System.IO.Path.GetExtension(File14.PostedFile.FileName).ToUpper().Substring(1);
                    if (fx != "" && fx != "PDF")
                    {
                        throw new System.Exception("KINDLY UPLOAD DIGITALLY SIGNED PDF FILES ONLY");
                    }
                    String SaveLocation = null;
                    SaveLocation = Server.MapPath("TESTPLAN/" + MyFile + "." + fx);
                    File14.PostedFile.SaveAs(SaveLocation);
                    //myUpdateQuery = myUpdateQuery + " , TESTPLAN='" + MyFile + "." + fx + "' ";
                }

                myUpdateQuery = myUpdateQuery + " where CASE_NO='" + lblCSNO.Text.Trim() + "' AND BK_NO='" + BK_NO + "' AND SET_NO='" + SET_NO + "'";
                OracleCommand myInsertCommand1 = new OracleCommand(myUpdateQuery);
                myInsertCommand1.Transaction = myTrans;
                myInsertCommand1.Connection = conn;
                myInsertCommand1.ExecuteNonQuery();
                myTrans.Commit();
                conn.Close();
                DisplayAlert("Upload Done Successfully!!!");

            }
            catch (FileNotFoundException fe)
            { Response.Write("File not found" + fe); }
            catch (System.IO.DirectoryNotFoundException de)
            { Response.Write("Directry not found" + de); }
            catch (Exception ex)
            {
                string str;
                str = ex.Message;
                string str1 = str.Replace("\n", "");
                Response.Redirect(("Error_Form.aspx?err=" + str1));
                myTrans.Rollback();
                DisplayAlert("Upload is not Successfull, Plz Try Again!!!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();

            }


        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            try
            {

                OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
                OracleCommand cmd = new OracleCommand("SELECT NVL(COUNT(*),0) FROM (SELECT T49.CASE_NO, T49.BK_NO, T49.SET_NO FROM T49_IC_PHOTO_ENCLOSED T49, IC_INTERMEDIATE IC WHERE T49.CASE_NO=IC.CASE_NO AND T49.BK_NO=IC.BK_NO AND T49.SET_NO=IC.SET_NO AND IC_PHOTO IS NULL AND T49.CASE_NO = '" + lblCSNO.Text.Trim() + "' AND T49.CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND T49.CALL_SNO = '" + CALL_SNO + "' GROUP BY T49.CASE_NO, T49.BK_NO, T49.SET_NO)", conn);
                OracleCommand cmd1 = new OracleCommand("SELECT NVL(COUNT(*),0) FROM T49_IC_PHOTO_ENCLOSED T49 WHERE T49.CASE_NO = '" + lblCSNO.Text.Trim() + "' AND T49.CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND T49.CALL_SNO = '" + CALL_SNO + "'", conn);
                conn.Open();
                int no_ic_count = Convert.ToInt32(cmd.ExecuteScalar());
                int no_of_photo = Convert.ToInt32(cmd1.ExecuteScalar());
                conn.Close();

                if (ACTIONAR.Trim() == "" || ACTIONAR == null)
                {
                    DisplayAlert("Your Call Status is Blank, Kindly Goto Mainmenu and select the call again to update!!!");

                }
                else if (ACTIONAR.Trim() == "R" && txtRejCharges.Text.Trim() == "")
                {
                    DisplayAlert("Kindly Enter Rejection Charges in Case of Rejection IC!!!");

                }
                //				else if(txtFIFO.Visible==true && txtFIFO.Text.Trim()=="")
                //				{
                //					DisplayAlert("Kindly Enter the Reason For Voilating FIFO Before Final Call Accepted/Rejected!!!");
                //
                //				}
                else if (ddlCondignee.SelectedValue == "0")
                {
                    DisplayAlert("Select Consignee from the List and then Click on Accepted/Rejected Button");
                }
                else if (no_of_photo == 0)
                {
                    DisplayAlert("Kindly upload the inspections photos and prepare the IC before updating the Call Status to Aceepted/Rejected!!!");
                }
                else if (no_ic_count > 0)
                {
                    DisplayAlert("Kindly upload the PDF file for all ICs, Before updating the Status to Aceepted/Rejected!!!");
                }
                else
                {
                    AcceptedFunc();

                }

                //                string w_call_cancel_status = "";
                //                conn.Open();
                //                OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn);
                //                string ss = Convert.ToString(cmd2.ExecuteScalar());
                //                conn.Close();

                //                //if (lblCallStatus.Text == "C" && lstCallStatus.SelectedValue != "C")
                //                //{
                //                //    string DQuery = "Delete T19_CALL_CANCEL where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + "";
                //                //    OracleCommand myDCommand = new OracleCommand(DQuery, conn);
                //                //    conn.Open();
                //                //    myDCommand.ExecuteNonQuery();
                //                //    conn.Close();
                //                //    w_call_cancel_status = "";
                //
                //                //}
                //                //else if (lstCallStatus.SelectedValue == "C" && lstCallCancelStatus.SelectedValue == "C")
                //                //{
                //                //    w_call_cancel_status = "C";
                //
                //                //}
                //                //else if (lstCallStatus.SelectedValue == "C" && lstCallCancelStatus.SelectedValue == "N")
                //                //{
                //                //    w_call_cancel_status = "N";
                //
                //                //}
                //                //else
                //                //{
                //                w_call_cancel_status = "";
                //
                //                //}
                //
                //                //if (lstCallStatus.SelectedValue == "A" || lstCallStatus.SelectedValue == "R")
                //                {
                //                    string bscheck = "";
                //                    //					w_call_cancel_status="";
                //                    if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "")
                //                    {
                //                        conn.Open();
                //                        OracleCommand cmd = new OracleCommand("Select ISSUE_TO_IECD from T10_IC_BOOKSET where TRIM(BK_NO)=upper('" + txtBKNO1.Text + "') and " + Convert.ToInt32(txtSetNo1.Text) + " between (SET_NO_FR) and (SET_NO_TO) and ISSUE_TO_IECD=" + wIECD, conn);
                //                        bscheck = Convert.ToString(cmd.ExecuteScalar());
                //                        conn.Close();
                //                    }
                //                    //if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "" && bscheck != "" && txtHologram.Text.Trim() != "" && File1.Value != "")
                //                        if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "" && bscheck != "" && File1.Value != "")
                //                        {
                //                        string str = "select NVL(count(*),0) from T49_IC_PHOTO_ENCLOSED where CASE_NO='" + lblCSNO.Text.Trim() + "' and BK_NO='" + txtBKNO1.Text + "' and SET_NO='" + txtSetNo1.Text + "'";
                //                        OracleCommand cmd1 = new OracleCommand(str, conn);
                //                        conn.Open();
                //                        int count = Convert.ToInt16(cmd1.ExecuteScalar());
                //                        conn.Close();
                //                        if (count > 0)
                //                        {
                //                            string updateQuery = "";
                //                            string updateQuery1 = "";
                //                            conn.Open();
                //                            OracleTransaction myTrans = conn.BeginTransaction();
                //                            //if (lstCallStatus.SelectedValue == "A")
                //                            {
                //                                //updateQuery = "Update T17_CALL_REGISTER set CALL_STATUS='" + lstCallStatus.SelectedValue + "',CALL_STATUS_DT=to_date('" + txtSTDT.Text + "','dd/mm/yyyy'),CALL_CANCEL_STATUS=null,BK_NO='" + txtBKNO1.Text + "',SET_NO='" + txtSetNo1.Text + "',USER_ID='" + Session["IE_EMP_NO"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'), HOLOGRAM='" + txtHologram.Text.Trim() + "' where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + "";
                //                                //updateQuery = "Update T17_CALL_REGISTER set CALL_STATUS='A',CALL_STATUS_DT=to_date('" + txtSTDT.Text + "','dd/mm/yyyy'),CALL_CANCEL_STATUS=null,BK_NO='" + txtBKNO1.Text + "',SET_NO='" + txtSetNo1.Text + "',USER_ID='" + Session["IE_EMP_NO"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'), HOLOGRAM='" + txtHologram.Text.Trim() + "' where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + "";
                //                                updateQuery = "Update T17_CALL_REGISTER set CALL_STATUS='A',CALL_STATUS_DT=to_date('" + txtSTDT.Text + "','dd/mm/yyyy'),CALL_CANCEL_STATUS=null,BK_NO='" + txtBKNO1.Text + "',SET_NO='" + txtSetNo1.Text + "',USER_ID='" + Session["IE_EMP_NO"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + "";
                //
                //                                updateQuery1 = "Update IC_INTERMEDIATE set consgn_call_status = 'A' where CASE_NO = '" + lblCSNO.Text.Trim() + "' and BK_NO = '" + txtBKNO1.Text + "' and SET_NO = '" + txtSetNo1.Text + "' AND CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CALL_SNO = '" + CALL_SNO + "' and consignee_cd = '" + Convert.ToString(ddlCondignee.SelectedValue) + "'";
                //                            }
                //                            //else if (lstCallStatus.SelectedValue == "R")
                //                            //{
                //                            //    if (lblRemarks.Text.Trim() != "")
                //                            //    {
                //                            //        updateQuery = "Update T17_CALL_REGISTER set CALL_STATUS='" + lstCallStatus.SelectedValue + "',CALL_STATUS_DT=to_date('" + txtSTDT.Text + "','dd/mm/yyyy'),CALL_CANCEL_STATUS=null,BK_NO='" + txtBKNO1.Text + "',SET_NO='" + txtSetNo1.Text + "',REMARKS='" + lblRemarks.Text.Trim() + "'||', '||'" + txtRemarks.Text.Trim() + "',USER_ID='" + Session["IE_EMP_NO"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'), HOLOGRAM='" + txtHologram.Text.Trim() + "' where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + "";
                //                            //    }
                //                            //    else
                //                            //    {
                //                            //        updateQuery = "Update T17_CALL_REGISTER set CALL_STATUS='" + lstCallStatus.SelectedValue + "',CALL_STATUS_DT=to_date('" + txtSTDT.Text + "','dd/mm/yyyy'),CALL_CANCEL_STATUS=null,BK_NO='" + txtBKNO1.Text + "',SET_NO='" + txtSetNo1.Text + "',REMARKS='" + txtRemarks.Text.Trim() + "',USER_ID='" + Session["IE_EMP_NO"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'), HOLOGRAM='" + txtHologram.Text.Trim() + "' where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + "";
                //                            //    }
                //                            //}
                //                            //OracleCommand myUpdateCommand = new OracleCommand(updateQuery);
                //                            //myUpdateCommand.Transaction = myTrans;
                //                            //myUpdateCommand.Connection = conn;
                //                            //myUpdateCommand.ExecuteNonQuery();
                //
                //
                //                            OracleCommand myUpdateCommand = new OracleCommand(updateQuery1);
                //                            myUpdateCommand.Transaction = myTrans;
                //                            myUpdateCommand.Connection = conn;
                //                            myUpdateCommand.ExecuteNonQuery();
                //
                //                            //if (lstCallStatus.SelectedValue == "R")
                //                            //{
                //                            //    string updateQuery1 = "Update T13_PO_MASTER set PENDING_CHARGES=NVL(PENDING_CHARGES,0)+1 where CASE_NO='" + lblCSNO.Text.Trim() + "'";
                //                            //    OracleCommand myUpdateCommand1 = new OracleCommand(updateQuery1, conn);
                //                            //    myUpdateCommand1.Transaction = myTrans;
                //                            //    myUpdateCommand1.Connection = conn;
                //                            //    myUpdateCommand1.ExecuteNonQuery();
                //                            //}
                //                            myTrans.Commit();
                //                            conn.Close();
                //                            photo_upload(txtBKNO1.Text.Trim(), txtSetNo1.Text.Trim());
                //                            DisplayAlert("Your Record is Saved!!!");
                //                        }
                //                        else
                //                        {
                //                            DisplayAlert("Photos against given Case No, Book No & Set No are not uploaded, So Upload Photos before changing the Call Status to [Aceepted OR Rejection]!!!");
                //                        }
                //                    }
                //                    else if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "" && bscheck == "")
                //                    {
                //                        DisplayAlert("Book No. and Set No. specified is not issued to You!!!");
                //                    }
                //                    //else if (txtBKNO1.Text.Trim() == "" || txtSetNo1.Text.Trim() == "" || txtHologram.Text == "" || File1.Value == "")
                //                        else if (txtBKNO1.Text.Trim() == "" || txtSetNo1.Text.Trim() == "" || File1.Value == "")
                //                    {
                //
                //                        DisplayAlert("Book No. , Set No., Holograms OR IC Photo cannot be left blank!!!");
                //                        //						string updateQuery="Update T17_CALL_REGISTER set CALL_STATUS='"+lstCallStatus.SelectedValue+"',CALL_STATUS_DT=to_date('"+txtSTDT.Text+"','dd/mm/yyyy'),CALL_CANCEL_STATUS=null,BK_NO='"+txtBKNO1.Text+"',SET_NO='"+txtSetNo1.Text+"',USER_ID='"+Session["IE_EMP_NO"].ToString()+"',DATETIME=to_date('"+ss+"','dd/mm/yyyy-HH24:MI:SS') where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO="+lblSNO.Text+"";
                //                        //						OracleCommand myUpdateCommand=new OracleCommand(updateQuery,conn);
                //                        //						conn.Open();
                //                        //						myUpdateCommand.ExecuteNonQuery();
                //                        //						conn.Close(); 
                //                    }
                //                }
                //                //else
                //                //{
                //                //    string updateQuery = "Update T17_CALL_REGISTER set CALL_STATUS='" + lstCallStatus.SelectedValue + "',CALL_STATUS_DT=to_date('" + txtSTDT.Text + "','dd/mm/yyyy'),CALL_CANCEL_STATUS='" + w_call_cancel_status + "',USER_ID='" + Session["IE_EMP_NO"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + "";
                //                //    OracleCommand myUpdateCommand = new OracleCommand(updateQuery, conn);
                //                //    conn.Open();
                //                //    myUpdateCommand.ExecuteNonQuery();
                //                //    conn.Close();
                //                //    DisplayAlert("Your Record is Saved!!!");
                //                //}
                //
                //                //if (lstCallStatus.SelectedValue == "C")
                //                //{
                //                //    Panel_1.Visible = true;
                //                //    Call_Cancellation_Entry();
                //
                //                //}
                //                ////				else if(lstCallStatus.SelectedValue=="A" || lstCallStatus.SelectedValue=="R")
                //                ////				{
                //                ////					HyperLink1.Visible=true;
                //                ////				}
                //                //else
                //                //{
                //                //    Panel_1.Visible = false;
                //                //}

            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message;
                string str1 = str.Replace("\n", "");
                Response.Redirect("Error_Form.aspx?err=" + str1);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            AcceptedFun();
        }

        //        void send_Vendor_Email()
        //        {
        //            try
        //            {
        //                string wRegion = "";
        //                string wPCity = "";
        //                string sender = "";
        //                OracleCommand cmd_vend = new OracleCommand("Select T13.VEND_CD,T05.VEND_NAME,NVL2(T05.VEND_ADD2,T05.VEND_ADD1||'/'||T05.VEND_ADD2,T05.VEND_ADD1) VEND_ADDRESS,T03.CITY VEND_CITY, T05.VEND_EMAIL,T13.REGION_CODE,T13.RLY_CD from T13_PO_MASTER T13,T05_VENDOR T05, T03_CITY T03 where T13.VEND_CD=T05.VEND_CD and T05.VEND_CITY_CD=T03.CITY_CD and CASE_NO='" + lblCSNO.Text.Trim() + "'", conn);
        //                conn.Open();
        //                OracleDataReader reader = cmd_vend.ExecuteReader();
        //                string vend_cd = "", vend_name = "", vend_email = "", rly_cd = "", vend_city = "";
        //                while (reader.Read())
        //                {
        //                    vend_cd = Convert.ToString(reader["VEND_CD"]);
        //                    vend_name = Convert.ToString(reader["VEND_NAME"]);
        //                    vend_city = Convert.ToString(reader["VEND_CITY"]);
        //                    vend_email = Convert.ToString(reader["VEND_EMAIL"]);
        //                    rly_cd = Convert.ToString(reader["RLY_CD"]);
        //                    if (reader["REGION_CODE"].ToString() == "N") { wRegion = "NORTHERN REGION <br> 12th FLOOR,CORE-II,SCOPE MINAR,LAXMI NAGAR, DELHI - 110092<br> Phone : +918800018691-95 <br> Fax : 011-22024665"; sender = "nrinspn@rites.com"; wPCity = "New Delhi"; }
        //                    else if (reader["REGION_CODE"].ToString() == "S") { wRegion = "SOUTHERN REGION <br> 758 ANNA SALAI [MOUNT CHAMBER], CHENNAI - 600 002 <br> Phone : 044-28523364/044-28524128 <br> Fax : 044-28525408"; sender = "srinspn@rites.com"; wPCity = "Chennai"; }
        //                    else if (reader["REGION_CODE"].ToString() == "E") { wRegion = "EASTERN REGION <br> CENTRAL STATION BUILDING(METRO), 56, C.R. AVENUE,3rd FLOOR,KOLKATA-700 012  <br> Fax : 033-22348704"; sender = "erinspn@rites.com"; wPCity = "Kolkata"; }
        //                    else if (reader["REGION_CODE"].ToString() == "W") { wRegion = "WESTERN REGION <br> CHURCHGATE STATION BLDG., 2nd FLOOR, M.K ROAD,MUMBAI-400 020 <br> Phone : 022-22012523/022-22015573 <br> Fax : 022-22081455/022-22016220"; sender = "wrinspn@rites.com"; wPCity = "Mumbai"; }
        //                    else if (reader["REGION_CODE"].ToString() == "C") { wRegion = "Central Region"; }
        //                }
        //                conn.Close();
        //
        //                OracleCommand cmd = new OracleCommand("Select T05.VEND_NAME MFG_NAME,T03.CITY MFG_CITY,T05.VEND_EMAIL,T17.MFG_CD from T05_VENDOR T05,T17_CALL_REGISTER T17,T03_CITY T03 where T05.VEND_CD=T17.MFG_CD and T05.VEND_CITY_CD=T03.CITY_CD and CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text, conn);
        //                conn.Open();
        //                string manu_mail = "", mfg_cd = "", manu_name = "", manu_city = "";
        //                OracleDataReader reader1 = cmd.ExecuteReader();
        //                while (reader1.Read())
        //                {
        //                    manu_mail = Convert.ToString(reader1["VEND_EMAIL"]);
        //                    mfg_cd = Convert.ToString(reader1["MFG_CD"]);
        //                    manu_name = Convert.ToString(reader1["MFG_NAME"]);
        //                    manu_city = Convert.ToString(reader1["MFG_CITY"]);
        //
        //                }
        //
        //                conn.Close();
        //                OracleCommand cmd1 = new OracleCommand("Select T09.IE_NAME,T09.IE_PHONE_NO,T09.IE_EMAIL,T08.CO_EMAIL  from T09_IE T09, T08_IE_CONTROLL_OFFICER T08 where T09.IE_CO_CD=T08.CO_CD and IE_CD=" + Request.Params["IE_CD"].ToString(), conn);
        //                conn.Open();
        //                string ie_phone = "", ie_name = "", ie_email = "", ie_co_email = "";
        //                OracleDataReader reader2 = cmd1.ExecuteReader();
        //                while (reader2.Read())
        //                {
        //                    ie_phone = Convert.ToString(reader2["IE_PHONE_NO"]);
        //                    ie_name = Convert.ToString(reader2["IE_NAME"]);
        //                    ie_email = Convert.ToString(reader2["IE_EMAIL"]);
        //                    ie_co_email = Convert.ToString(reader2["CO_EMAIL"]);
        //                }
        //                conn.Close();
        //                string can_reasons = "";
        //                //if (lstCallStatus.SelectedValue == "C")
        //                //{
        //                //    can_reasons = get_cancel_reasons();
        //                //}
        //                string call_letter_dt = "";
        //                if (lblCLettDT.Text.Trim() == "")
        //                {
        //                    call_letter_dt = "NIL";
        //                }
        //                else
        //                {
        //                    call_letter_dt = lblCLettDT.Text.Trim();
        //                }
        //                string mail_body = "";
        //                if (lstCallCancelStatus.SelectedValue == "C")
        //                {
        //                    mail_body = vend_name + ", " + vend_city + " / " + manu_name + ", " + manu_city + ",<br><br> Your Call Letter Dated:  " + call_letter_dt + " for inspection of material against Agency.-" + rly_cd + ", PO No. - " + lblPONO.Text + " & Date - " + lblPODT.Text + ", Case NO. -" + lblCSNO.Text + ", registered on date: " + lblCallDT.Text + ", at SNo. " + lblSNO.Text + ". is Cancelled (" + lstCallCancelStatus.SelectedItem.Text + ") on Date.-" + txtSTDT.Text + " by the concerned Inspection Engineer. - " + ie_name + " Contact No. " + ie_phone + ", Due to the following reasons.<br>" + can_reasons + "<br>";
        //                    if (lstCallCancelCharges.SelectedValue == "0")
        //                    {
        //                        mail_body = mail_body + "You are requested to submit call cancellation charges through Demand Draft for the amount calculated based on Railway Board order no. 99/RS(G)/709/4 Dated. 12-02-2016. </b> in f/o RITES LTD, Payble at " + wPCity + " along with next call.<br><b><u>Please note that call letter without call cancellation charges will not be accepted.</u></b><br>";
        //
        //                    }
        //                    else
        //                    {
        //                        mail_body = mail_body + "You are requested to submit call cancellation charges through Demand Draft for <b> Rs." + lstCallCancelCharges.SelectedValue + " + S.T. </b> in f/o RITES LTD, Payble at " + wPCity + " along with next call.<br><b><u>Please note that call letter without call cancellation charges will not be accepted.</u></b><br>";
        //                    }
        //
        //
        //                    mail_body = mail_body + "This is for your information and necessary corrective measures please. <br><br> Thanks for using RITES Inspection Services. <br><br>" + wRegion + ".";
        //                }
        //                else
        //                {
        //                    mail_body = vend_name + ", " + vend_city + " / " + manu_name + ", " + manu_city + ",<br><br> Your Call Letter Dated:  " + call_letter_dt + " for inspection of material against Agency.-" + rly_cd + ", PO No. - " + lblPONO.Text + " & Date - " + lblPODT.Text + ", Case NO. -" + lblCSNO.Text + ", registered on date: " + lblCallDT.Text + ", at SNo. " + lblSNO.Text + ". is Cancelled (" + lstCallCancelStatus.SelectedItem.Text + ") on Date.-" + txtSTDT.Text + " by the concerned Inspection Engineer. - " + ie_name + " Contact No. " + ie_phone + "<br>";
        //                    mail_body = mail_body + "This is for your information and necessary corrective measures please. <br><br> Thanks for using RITES Inspection Services. <br><br>" + wRegion + ".";
        //                }
        //                if (vend_cd == mfg_cd && manu_mail != "")
        //                {
        //                    MailMessage mail = new MailMessage();
        //                    mail.To = manu_mail;
        //                    mail.Cc = ie_co_email;
        //                    mail.Bcc = ie_email + ";nrinspn@gmail.com";
        //                    mail.BodyFormat = MailFormat.Html;
        //                    mail.From = sender;
        //                    mail.Subject = "Your Call for Inspection By RITES has Cancelled.";
        //                    mail.Body = mail_body;
        //                    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
        //                    SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
        //                    mail.Priority = MailPriority.High;
        //                    SmtpMail.Send(mail);
        //                }
        //                else if (vend_cd != mfg_cd)
        //                {
        //
        //                    if (vend_email != "")
        //                    {
        //                        MailMessage mail = new MailMessage();
        //                        mail.To = vend_email;
        //                        mail.Cc = ie_co_email;
        //                        mail.Bcc = ie_email + ";nrinspn@gmail.com";
        //                        mail.BodyFormat = MailFormat.Html;
        //                        mail.From = sender;
        //                        mail.Subject = "Your Call for Inspection By RITES has Cancelled.";
        //                        mail.Body = mail_body;
        //                        mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
        //                        SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
        //                        mail.Priority = MailPriority.High;
        //                        SmtpMail.Send(mail);
        //
        //                    }
        //                    else if (manu_mail != "")
        //                    {
        //                        MailMessage mail1 = new MailMessage();
        //                        mail1.To = manu_mail;
        //                        mail1.Cc = ie_co_email;
        //                        mail1.Bcc = ie_email + ";nrinspn@gmail.com";
        //                        mail1.BodyFormat = MailFormat.Html;
        //                        mail1.From = sender;
        //                        mail1.Subject = "Your Call for Inspection By RITES has Cancelled.";
        //                        mail1.Body = mail_body;
        //                        mail1.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");   //basic authentication
        //                        SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
        //                        mail1.Priority = MailPriority.High;
        //                        SmtpMail.Send(mail1);
        //                    }
        //
        //
        //                }
        //
        //                if (vend_email == "" && manu_mail == "")
        //                {
        //                    mail_body = mail_body + "\n As their is no email-id available for Vendor/Manufacturer, So the email cannot be send to Vendor/Manufacturer.";
        //                    MailMessage mail1 = new MailMessage();
        //                    mail1.To = ie_co_email;
        //                    mail1.Bcc = ie_email + ";nrinspn@gmail.com";
        //                    mail1.BodyFormat = MailFormat.Html;
        //                    mail1.From = sender;
        //                    mail1.Subject = "Your Call for Inspection By RITES has Cancelled.";
        //                    mail1.Body = mail_body;
        //                    mail1.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");   //basic authentication
        //                    SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
        //                    mail1.Priority = MailPriority.High;
        //                    SmtpMail.Send(mail1);
        //
        //
        //                }
        //
        //            }
        //            catch (Exception ex)
        //            {
        //                string str;
        //                str = ex.Message;
        //                //				Response.Write(ex);
        //            }
        //            finally
        //            {
        //                conn.Close();
        //                conn.Dispose();
        //            }
        //
        //
        //        }


        private void btnRefreshAll_Click(object sender, System.EventArgs e)
        {
            OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

            conn.Open();

            OracleTransaction myTrans = conn.BeginTransaction();

            OracleCommand myInsertCommand1 = null;

            //string MySql = " Update T18_CALL_DETAILS  set ITEM_DESC_PO ='" + Convert.ToString(itemDR["ITEM_DESC_PO"]).Substring(0,len_item) + "' ,QTY_PASSED ='" + itemDR["QTY_PASSED"] + "',QTY_REJECTED ='" + itemDR["QTY_REJECTED"] + "' ,QTY_DUE ='" + itemDR["QTY_DUE"] + "'  WHERE ITEM_SRNO_PO = '" + Convert.ToString(itemDR["ITEM_SRNO_PO"]) + "' AND CASE_NO = '" + CASE_NO.Trim() + "' AND CALL_SNO = '" + CALL_SNO + "' AND CALL_RECV_DT =  TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CONSIGNEE_CD = '" + Convert.ToString(ddlCondignee.SelectedValue) + "' ";
            //string MySql = " Update T18_CALL_DETAILS  set ITEM_DESC_PO ='" + Convert.ToString(itemDR["ITEM_DESC_PO"]).Substring(0,len_item) + "' ,QTY_PASSED ='" + itemDR["QTY_PASSED"] + "',QTY_REJECTED ='" + itemDR["QTY_REJECTED"] + "' ,QTY_DUE ='" + itemDR["QTY_DUE"] + "'  WHERE ITEM_SRNO_PO = '" + Convert.ToString(itemDR["ITEM_SRNO_PO"]) + "' AND CASE_NO = '" + CASE_NO.Trim() + "' AND CALL_SNO = '" + CALL_SNO + "' AND CALL_RECV_DT =  TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CONSIGNEE_CD = '" + Convert.ToString(ddlCondignee.SelectedValue) + "' ";
            string MySql = " DELETE FROM IC_INTERMEDIATE where CASE_NO = '" + lblCSNO.Text.Trim() + "' AND TO_CHAR(CALL_RECV_DT,'dd/mm/yyyy') = '" + CALL_RECV_DT + "' AND CALL_SNO = '" + CALL_SNO + "' and ((consgn_call_status != 'A' and consgn_call_status != 'R') OR consgn_call_status is null)";

            myInsertCommand1 = new OracleCommand(MySql);
            myInsertCommand1.Transaction = myTrans;
            myInsertCommand1.Connection = conn;
            myInsertCommand1.ExecuteNonQuery();

            try
            {

                myTrans.Commit();

                conn.Close();

                Response.Redirect("Calls_Marked_To_IE.aspx?ACTION=C");

                DisplayAlert("Your request has been Accepted!");
            }
            catch (Exception ex)
            {

                myTrans.Rollback();
                conn.Close();
                conn.Dispose();
                DisplayAlert("Not Accepted due to " + ex.Message);
            }


        }


        private void btnViewIC_Click(object sender, System.EventArgs e)
        {

            //////			string splchar = "~`!@#$%^&*()_+:;'<,>.?/test string";
            //////			
            //////			DisplayAlert(splchar);
            //////
            //////			string removesplcharstr = "";
            //////
            //////			removesplcharstr = RemoveSpecChr(splchar);
            //////
            //////			DisplayAlert(removesplcharstr);






            conn.Open();
            OracleDataReader ord;
            //string qry = "Delete from RPT_PRM_Inspection_Certificate Where Request_TS < CURRENT_TIMESTAMP - INTERVAL '1' MINUTE";
            //OracleCommand myOracleCommand1 = new OracleCommand(qry, conn);
            //ord = myOracleCommand1.ExecuteReader();
            //conn.Close();
            //updateQuery="Update T17_CALL_REGISTER set CALL_STATUS='"+lstCallStatus.SelectedValue+"',CALL_STATUS_DT=to_date('"+txtSTDT.Text+"','dd/mm/yyyy'),CALL_CANCEL_STATUS=null,BK_NO='"+txtBKNO1.Text+"',SET_NO='"+txtSetNo1.Text+"',USER_ID='"+Session["IE_EMP_NO"].ToString()+"',DATETIME=to_date('"+ss+"','dd/mm/yyyy-HH24:MI:SS'), HOLOGRAM='"+txtHologram.Text.Trim()+"' where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO="+lblSNO.Text+"";
            string caseNo = lblCSNO.Text.Trim();
            string callSNo = lblSNO.Text;
            string myYear, myMonth, myDay;
            myYear = lblCallDT.Text.Substring(6, 4);
            myMonth = lblCallDT.Text.Substring(3, 2);
            myDay = lblCallDT.Text.Substring(0, 2);
            string recvDtRpt = myMonth + "/" + myDay + "/" + myYear;
            //string recvDtQry = "26-NOV-2010";



            OracleCommand cmd = new OracleCommand("select COUNT(*) from RPT_PRM_Inspection_Certificate where CASE_NO= '" + caseNo + "' and  CALL_SNO= '" + callSNo + "' and CALL_RECV_DT= to_date('" + recvDtRpt + "','mm/dd/yyyy') and CONSIGNEE_CD = '" + ddlCondignee.SelectedValue + "' ", conn);
            //conn.Open();
            int ss = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();


            string qry = "";
            OracleCommand myOracleCommand1 = null;
            if (ss <= 0)
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                //conn.Open();
                qry = "INSERT INTO RPT_PRM_Inspection_Certificate VALUES ('" + caseNo + "', to_date('" + recvDtRpt + "','mm/dd/yyyy'), " + callSNo + " , NULL, NULL , CURRENT_TIMESTAMP,'" + ddlCondignee.SelectedValue + "')";
                myOracleCommand1 = new OracleCommand(qry, conn);
                ord = myOracleCommand1.ExecuteReader();
                conn.Close();
            }

            qry = "MERGE INTO RPT_PRM_Inspection_Certificate RP USING ";
            qry += "( SELECT CASE_NO, CALL_SNO, CALL_RECV_DT, COUNT(*) as NUM_VISITS, LISTAGG(TO_CHAR(Visit_DT, 'DD.MM.YYYY'), ', ') within group (order by Visit_DT ) as VISIT_DATES ";
            qry += "    FROM T47_IE_WORK_PLAN ";
            qry += "   WHERE CASE_NO = '" + caseNo + "' and CALL_SNO = " + callSNo + " and CALL_RECV_DT = to_date('" + recvDtRpt + "','mm/dd/yyyy') ";
            qry += "  GROUP BY CASE_NO, CALL_SNO, CALL_RECV_DT) WP ";
            qry += "ON(RP.CASE_NO = WP.CASE_NO AND RP.CALL_SNO = WP.CALL_SNO AND RP.CALL_RECV_DT = WP.CALL_RECV_DT) ";
            qry += "WHEN MATCHED THEN UPDATE SET ";
            qry += "RP.NUM_VISITS = WP.NUM_VISITS, ";
            qry += "RP.VISIT_DATES = WP.VISIT_DATES";
            if (conn.State != ConnectionState.Open)
                conn.Open();

            myOracleCommand1 = new OracleCommand(qry, conn);

            ord = myOracleCommand1.ExecuteReader();
            conn.Close();



            Response.Redirect("IC_RPT_Intermediate.aspx?CASE_NO=" + CASE_NO + "&CALL_RECV_DT=" + CALL_RECV_DT + "&CALL_SNO=" + CALL_SNO + "&IE_CD=" + wIECD + "&ACTIONAR=" + ACTIONAR + "&CONSIGNEE_CD=" + ddlCondignee.SelectedValue + "&ACTION=" + Request.Params["ACTION"].Trim() + "' Font-Names='Verdana' Font-Size='8pt'");
            //rbs my_rbs = new rbs();
            //CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = null;
            //rpt = new Reports.InspectionCertificate();
            ////			rpt.RecordSelectionFormula ="ToText({V22_BILL.BILL_DT},'yyyyMMdd')>='"+wDtFr+"' and ToText({V22_BILL.BILL_DT},'yyyyMMdd')<='"+wDtTo+"' and {V22_BILL.REGION_CODE}='"+Session["Region"]+"' and ("+wFormula+")";
            ////			rpt.SetParameterValue(0,Session["Region"]);
            ////			rpt.SetParameterValue(1,txtDateFr.Text);
            ////			rpt.SetParameterValue(2,txtDateTo.Text);
            //rpt.SetParameterValue("caseno", caseNo);
            //rpt.SetParameterValue(1, callSNo);
            //rpt.SetParameterValue(2, recvDtRpt);

            //MemoryStream oStream = my_rbs.showwordrep(rpt);
            //Response.Clear();
            //Response.Buffer = true;
            //Response.ContentType = "application/doc";
            //try
            //{
            //    Response.BinaryWrite(oStream.ToArray());
            //    Response.End();
            //}
            //catch (Exception err)
            //{
            //    Response.Write("< BR >");
            //    Response.Write(err.Message.ToString());
            //}
        }

        #region File Upload 

        private void AcceptedFunc()
        {
            string wFifoVoilateReason = "";
            if (txtFIFO.Visible == true)
            {
                wFifoVoilateReason = txtFIFO.Text.Trim();
            }

            OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            OracleCommand cmd = new OracleCommand("select to_char(sysdate,'dd/mm/yyyy') from dual", conn);
            conn.Open();
            string ssu = Convert.ToString(cmd.ExecuteScalar());
            conn.Close();


            conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            conn.Open();
            OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy-HH24:MI:SS') from dual", conn);
            string ss = Convert.ToString(cmd2.ExecuteScalar());
            //			conn.Close();
            //			conn.Open();
            OracleCommand cmd3 = new OracleCommand("SELECT CALL_STATUS FROM T17_CALL_REGISTER WHERE CASE_NO = '" + lblCSNO.Text.Trim() + "' AND CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CALL_SNO = '" + CALL_SNO + "'", conn);
            string CALL_STATUS = Convert.ToString(cmd3.ExecuteScalar());
            conn.Close();


            OracleConnection conn2 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

            DataSet ds = new DataSet();
            //string str = "SELECT * FROM IC_INTERMEDIATE WHERE CASE_NO = '" + lblCSNO.Text.Trim() + "' AND CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CALL_SNO = '" + CALL_SNO + "' and consignee_cd = '" + Convert.ToString(ddlCondignee.SelectedValue) + "'";
            string str = "SELECT * FROM IC_INTERMEDIATE WHERE CASE_NO = '" + lblCSNO.Text.Trim() + "' AND CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CALL_SNO = '" + CALL_SNO + "' ";

            OracleDataAdapter da = new OracleDataAdapter(str, conn2);
            OracleCommand myOracleCommand = new OracleCommand(str, conn2);
            conn2.Open();
            da.SelectCommand = myOracleCommand;
            conn2.Close();
            da.Fill(ds, "Table");


            conn2 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            conn2.Open();
            OracleTransaction myTrans = conn2.BeginTransaction();

            string MySql = "";
            try
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        OracleCommand myInsertCommand1 = null;
                        foreach (DataRow itemDR in ds.Tables[0].Rows)
                        {
                            int len_item = 0;
                            string formatedItem = "";
                            if (Convert.ToString(itemDR["ITEM_DESC_PO"]).Length > 400)
                            {
                                len_item = 390;
                            }
                            else
                            {
                                len_item = Convert.ToString(itemDR["ITEM_DESC_PO"]).Length;
                            }

                            //formatedItem = RemoveSpecChr(Convert.ToString(itemDR["ITEM_DESC_PO"]).Substring(0,len_item));

                            formatedItem = Convert.ToString(itemDR["ITEM_DESC_PO"]).Substring(0, len_item);

                            //MySql = " Update T18_CALL_DETAILS  set ITEM_DESC_PO ='" + formatedItem + "' ,QTY_PASSED ='" + itemDR["QTY_PASSED"] + "',QTY_REJECTED ='" + itemDR["QTY_REJECTED"] + "' ,QTY_DUE ='" + itemDR["QTY_DUE"] + "'  WHERE ITEM_SRNO_PO = '" + Convert.ToString(itemDR["ITEM_SRNO_PO"]) + "' AND CASE_NO = '" + CASE_NO.Trim() + "' AND CALL_SNO = '" + CALL_SNO + "' AND CALL_RECV_DT =  TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CONSIGNEE_CD = '" + Convert.ToString(ddlCondignee.SelectedValue) + "' ";
                            MySql = " Update T18_CALL_DETAILS  set ITEM_DESC_PO ='" + formatedItem + "' ,QTY_PASSED ='" + itemDR["QTY_PASSED"] + "',QTY_REJECTED ='" + itemDR["QTY_REJECTED"] + "' ,QTY_DUE ='" + itemDR["QTY_DUE"] + "'  WHERE ITEM_SRNO_PO = '" + Convert.ToString(itemDR["ITEM_SRNO_PO"]) + "' AND CASE_NO = '" + CASE_NO.Trim() + "' AND CALL_SNO = '" + CALL_SNO + "' AND CALL_RECV_DT =  TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') ";

                            myInsertCommand1 = new OracleCommand(MySql);
                            myInsertCommand1.Transaction = myTrans;
                            myInsertCommand1.Connection = conn2;
                            myInsertCommand1.ExecuteNonQuery();
                        }

                        //						if(ACTIONAR=="R")
                        //						{
                        //							MySql = "Update T17_CALL_REGISTER set CALL_STATUS='"+ACTIONAR+"',CALL_STATUS_DT=to_date('" + txtSTDT.Text + "','dd/mm/yyyy'),CALL_CANCEL_STATUS=null,BK_NO='" + txtBKNO1.Text + "',SET_NO='" + txtSetNo1.Text + "',USER_ID='" + Session["IE_EMP_NO"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'), REMARKS=REMARKS||', '||'" + itemDR["REASON_OF_REJECTION"] + "' where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + "";
                        //						}
                        //						else
                        //						{
                        //							MySql = "Update T17_CALL_REGISTER set CALL_STATUS='"+ACTIONAR+"',CALL_STATUS_DT=to_date('" + txtSTDT.Text + "','dd/mm/yyyy'),CALL_CANCEL_STATUS=null,BK_NO='" + txtBKNO1.Text + "',SET_NO='" + txtSetNo1.Text + "',USER_ID='" + Session["IE_EMP_NO"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS') where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + "";
                        //						}
                        double wRejCharges = 0;
                        string wRejType = "";
                        if (ACTIONAR == "R" && txtRejCharges.Visible == true)
                        {
                            wRejCharges = Convert.ToDouble(txtRejCharges.Text);

                        }
                        if (lstRejectionType.Visible == true)
                        {
                            wRejType = lstRejectionType.SelectedValue;
                        }

                        MySql = "Update T17_CALL_REGISTER set CALL_STATUS='" + ACTIONAR + "',CALL_STATUS_DT=to_date('" + txtSTDT.Text + "','dd/mm/yyyy'),CALL_CANCEL_STATUS=null,BK_NO='" + txtBKNO1.Text + "',SET_NO='" + txtSetNo1.Text + "',USER_ID='" + Session["IE_EMP_NO"].ToString() + "',DATETIME=to_date('" + ss + "','dd/mm/yyyy-HH24:MI:SS'),REJ_CHARGES=" + wRejCharges + ", FIFO_VOILATE_REASON='" + wFifoVoilateReason + "',LOCAL_OR_OUTS='" + wRejType + "' where CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text.Trim() + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text + "";
                        myInsertCommand1 = new OracleCommand(MySql);
                        myInsertCommand1.Transaction = myTrans;
                        myInsertCommand1.Connection = conn2;
                        myInsertCommand1.ExecuteNonQuery();

                        //MySql = "Update IC_INTERMEDIATE set consgn_call_status = '"+ACTIONAR+"',DATETIME = to_date('" + ssu + "','dd/mm/yyyy') where CASE_NO = '" + lblCSNO.Text.Trim() + "' and BK_NO = '" + txtBKNO1.Text + "' and SET_NO = '" + txtSetNo1.Text + "' AND CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CALL_SNO = '" + CALL_SNO + "' and consignee_cd = '" + Convert.ToString(ddlCondignee.SelectedValue) + "'";
                        MySql = "Update IC_INTERMEDIATE set consgn_call_status = '" + ACTIONAR + "' where CASE_NO = '" + lblCSNO.Text.Trim() + "' and BK_NO = '" + txtBKNO1.Text + "' and SET_NO = '" + txtSetNo1.Text + "' AND CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CALL_SNO = '" + CALL_SNO + "' and consignee_cd = '" + Convert.ToString(ddlCondignee.SelectedValue) + "'";
                        myInsertCommand1 = new OracleCommand(MySql);
                        myInsertCommand1.Transaction = myTrans;
                        myInsertCommand1.Connection = conn2;
                        myInsertCommand1.ExecuteNonQuery();

                        if (ACTIONAR == "R" && CALL_STATUS != "R")
                        {
                            string updateQuery1 = "Update T13_PO_MASTER set PENDING_CHARGES=NVL(PENDING_CHARGES,0)+1 where CASE_NO='" + lblCSNO.Text.Trim() + "'";
                            OracleCommand myUpdateCommand1 = new OracleCommand(updateQuery1, conn2);
                            myUpdateCommand1.Transaction = myTrans;
                            myUpdateCommand1.Connection = conn2;
                            myUpdateCommand1.ExecuteNonQuery();
                        }
                    }
                }
                if (MySql == "") { conn2.Close(); return; }

                myTrans.Commit();
                conn2.Close();

                //				photo_upload(txtBKNO1.Text.Trim(), txtSetNo1.Text.Trim());


                DisplayAlert("Your request has been accepted!!!");
            }
            catch (Exception ex)
            {
                myTrans.Rollback();
                conn2.Close();
                DisplayAlert("Not Accepted due to " + ex.Message);
            }
            if (ACTIONAR == "R")
            {
                Vendor_Rej_Email();
            }
        }
        void Vendor_Rej_Email()
        {
            try
            {
                string wRegion = "";
                string wPCity = "";
                string sender = "";
                OracleCommand cmd_vend = new OracleCommand("Select T13.VEND_CD,T05.VEND_NAME,NVL2(T05.VEND_ADD2,T05.VEND_ADD1||'/'||T05.VEND_ADD2,T05.VEND_ADD1) VEND_ADDRESS,T03.CITY VEND_CITY, T05.VEND_EMAIL,T13.REGION_CODE,T13.RLY_CD from T13_PO_MASTER T13,T05_VENDOR T05, T03_CITY T03 where T13.VEND_CD=T05.VEND_CD and T05.VEND_CITY_CD=T03.CITY_CD and CASE_NO='" + lblCSNO.Text.Trim() + "'", conn);
                conn.Open();
                OracleDataReader reader = cmd_vend.ExecuteReader();
                string vend_cd = "", vend_name = "", vend_email = "", rly_cd = "", vend_city = "";
                while (reader.Read())
                {
                    vend_cd = Convert.ToString(reader["VEND_CD"]);
                    vend_name = Convert.ToString(reader["VEND_NAME"]);
                    vend_city = Convert.ToString(reader["VEND_CITY"]);
                    vend_email = Convert.ToString(reader["VEND_EMAIL"]);
                    rly_cd = Convert.ToString(reader["RLY_CD"]);
                    if (reader["REGION_CODE"].ToString() == "N") { wRegion = "NORTHERN REGION <br> 12th FLOOR,CORE-II,SCOPE MINAR,LAXMI NAGAR, DELHI - 110092<br> Phone : +918800018691-95 <br> Fax : 011-22024665"; sender = "nrinspn@rites.com"; wPCity = "New Delhi"; }
                    else if (reader["REGION_CODE"].ToString() == "S") { wRegion = "SOUTHERN REGION <br> CTS BUILDING - 2ND FLOOR, BSNL COMPLEX, NO. 16, GREAMS ROAD,  CHENNAI - 600 006 <br> Phone : 044-28292807/044- 28292817 <br> Fax : 044-28290359"; sender = "srinspn@rites.com"; wPCity = "Chennai"; }
                    else if (reader["REGION_CODE"].ToString() == "E") { wRegion = "EASTERN REGION <br> CENTRAL STATION BUILDING(METRO), 56, C.R. AVENUE,3rd FLOOR,KOLKATA-700 012  <br> Fax : 033-22348704"; sender = "erinspn@rites.com"; wPCity = "Kolkata"; }
                    else if (reader["REGION_CODE"].ToString() == "W") { wRegion = "WESTERN REGION <BR>5TH FLOOR, REGENT CHAMBER, ABOVE STATUS RESTAURANT,NARIMAN POINT,MUMBAI-400021 <BR>Phone : 022-68943400/68943445 <BR>"; sender = "wrinspn@rites.com"; wPCity = "Mumbai"; }
                    else if (reader["REGION_CODE"].ToString() == "C") { wRegion = "Central Region"; }
                }
                conn.Close();

                OracleCommand cmd = new OracleCommand("Select T05.VEND_NAME MFG_NAME,T03.CITY MFG_CITY,T05.VEND_EMAIL,T17.MFG_CD from T05_VENDOR T05,T17_CALL_REGISTER T17,T03_CITY T03 where T05.VEND_CD=T17.MFG_CD and T05.VEND_CITY_CD=T03.CITY_CD and CASE_NO='" + lblCSNO.Text.Trim() + "' and CALL_RECV_DT=to_date('" + lblCallDT.Text + "','dd/mm/yyyy') and CALL_SNO=" + lblSNO.Text, conn);
                conn.Open();
                string manu_mail = "", mfg_cd = "", manu_name = "", manu_city = "";
                OracleDataReader reader1 = cmd.ExecuteReader();
                while (reader1.Read())
                {
                    manu_mail = Convert.ToString(reader1["VEND_EMAIL"]);
                    mfg_cd = Convert.ToString(reader1["MFG_CD"]);
                    manu_name = Convert.ToString(reader1["MFG_NAME"]);
                    manu_city = Convert.ToString(reader1["MFG_CITY"]);

                }

                conn.Close();
                OracleCommand cmd1 = new OracleCommand("Select T09.IE_NAME,T09.IE_PHONE_NO,T09.IE_EMAIL,T08.CO_EMAIL  from T09_IE T09, T08_IE_CONTROLL_OFFICER T08 where T09.IE_CO_CD=T08.CO_CD and IE_CD=" + Request.Params["IE_CD"].ToString(), conn);
                conn.Open();
                string ie_phone = "", ie_name = "", ie_email = "", ie_co_email = "";
                OracleDataReader reader2 = cmd1.ExecuteReader();
                while (reader2.Read())
                {
                    ie_phone = Convert.ToString(reader2["IE_PHONE_NO"]);
                    ie_name = Convert.ToString(reader2["IE_NAME"]);
                    ie_email = Convert.ToString(reader2["IE_EMAIL"]);
                    ie_co_email = Convert.ToString(reader2["CO_EMAIL"]);
                }
                conn.Close();
                //				string can_reasons="";
                //				if(lstCallStatus.SelectedValue=="C")
                //				{
                //					can_reasons=get_cancel_reasons();
                //				}
                string call_letter_dt = "";
                if (lblCLettDT.Text.Trim() == "")
                {
                    call_letter_dt = "NIL";
                }
                else
                {
                    call_letter_dt = lblCLettDT.Text.Trim();
                }
                string mail_body = "";

                mail_body = vend_name + ", " + vend_city + " / " + manu_name + ", " + manu_city + ",<br><br> Your Call Letter Dated:  " + call_letter_dt + " for inspection of material against Agency.-" + rly_cd + ", PO No. - " + lblPONO.Text + " & Date - " + lblPODT.Text + ", Case NO. -" + lblCSNO.Text + ", registered on date: " + lblCallDT.Text + ", at SNo. " + lblSNO.Text + ". is Rejected on Date.-" + txtSTDT.Text + " by the concerned Inspection Engineer. - " + ie_name + " Contact No. " + ie_phone + "<br>";
                //						if(lstCallCancelCharges.SelectedValue=="0")
                //						{
                mail_body = mail_body + "You are requested to submit Rejection charges for the amount of Rs. " + txtRejCharges.Text + "/- + GST, through NEFT/RTGS/Credit card/Debit card/Net banking. </b> in f/o RITES LTD, Payble at " + wPCity + " along with next call.<br><b><u>Please note that call letter without Call Rejection charges will not be accepted.</u></b><br>";

                //						}
                //						else
                //						{
                //							mail_body=mail_body + "You are requested to submit call cancellation charges through NEFT/ RTGS/ Credit card/ Debit card/ Net banking for <b> Rs."+lstCallCancelCharges.SelectedValue+" + GST </b> in f/o RITES LTD, Payble at "+wPCity+" along with next call.<br><b><u>Please note that call letter without call cancellation charges will not be accepted.</u></b><br>";
                //						}


                mail_body = mail_body + "This is for your information and necessary corrective measures please. <br><br> Thanks for using RITES Inspection Services.<br> NATIONAL INSPECTION HELP LINE NUMBER : 1800 425 7000 (TOLL FREE). <br><br>" + wRegion + ".";

                if (vend_cd == mfg_cd && manu_mail != "")
                {
                    MailMessage mail = new MailMessage();
                    mail.To = manu_mail;
                    mail.Cc = ie_co_email;
                    if (Session["Region"].ToString() == "N")
                    {
                        mail.Bcc = ie_email + ";nrinspn@gmail.com" + ";nrinspn.fin@rites.com";
                    }
                    else
                    {
                        mail.Bcc = ie_email + ";nrinspn@gmail.com";
                    }
                    mail.BodyFormat = MailFormat.Html;
                    //mail.From = sender;
                    mail.From = "nrinspn@gmail.com";
                    mail.Subject = "Your Call for Inspection By RITES has Rejected.";
                    mail.Body = mail_body;
                    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
                    SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
                    mail.Priority = MailPriority.High;
                    SmtpMail.Send(mail);
                }
                else if (vend_cd != mfg_cd && vend_email != "" && manu_mail != "")
                {


                    MailMessage mail = new MailMessage();
                    mail.To = vend_email + ";" + manu_mail;
                    mail.Cc = ie_co_email;
                    if (Session["Region"].ToString() == "N")
                    {
                        mail.Bcc = ie_email + ";nrinspn@gmail.com" + ";nrinspn.fin@rites.com";
                    }
                    else
                    {
                        mail.Bcc = ie_email + ";nrinspn@gmail.com";
                    }
                    mail.BodyFormat = MailFormat.Html;
                    //mail.From = sender;
                    mail.From = "nrinspn@gmail.com";
                    mail.Subject = "Your Call for Inspection By RITES has Rejected.";
                    mail.Body = mail_body;
                    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
                    SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
                    mail.Priority = MailPriority.High;
                    SmtpMail.Send(mail);




                }
                else if (vend_cd != mfg_cd && (vend_email != "" || manu_mail != ""))
                {
                    MailMessage mail = new MailMessage();
                    if (vend_email == "")
                    {
                        mail.To = manu_mail;
                    }
                    else if (manu_mail == "")
                    {
                        mail.To = vend_email;
                    }

                    mail.Cc = ie_co_email;
                    if (Session["Region"].ToString() == "N")
                    {
                        mail.Bcc = ie_email + ";nrinspn@gmail.com" + ";nrinspn.fin@rites.com";
                    }
                    else
                    {
                        mail.Bcc = ie_email + ";nrinspn@gmail.com";
                    }
                    mail.BodyFormat = MailFormat.Html;
                    //mail.From = sender;
                    mail.From = "nrinspn@gmail.com";
                    mail.Subject = "Your Call for Inspection By RITES has Rejected.";
                    mail.Body = mail_body;
                    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");    //basic authentication
                    SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
                    mail.Priority = MailPriority.High;
                    SmtpMail.Send(mail);

                }

                if (vend_email == "" && manu_mail == "")
                {
                    mail_body = mail_body + "\n As their is no email-id available for Vendor/Manufacturer, So the email cannot be send to Vendor/Manufacturer.";
                    MailMessage mail1 = new MailMessage();
                    mail1.To = ie_co_email;
                    if (Session["Region"].ToString() == "N")
                    {
                        mail1.Bcc = ie_email + ";nrinspn@gmail.com" + ";nrinspn.fin@rites.com";
                    }
                    else
                    {
                        mail1.Bcc = ie_email + ";nrinspn@gmail.com";
                    }
                    mail1.BodyFormat = MailFormat.Html;
                    mail1.From = sender;
                    mail1.Subject = "Your Call for Inspection By RITES has Rejected.";
                    mail1.Body = mail_body;
                    mail1.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "0");   //basic authentication
                    SmtpMail.SmtpServer = "127.0.0.1";  //your real server goes here
                    mail1.Priority = MailPriority.High;
                    SmtpMail.Send(mail1);


                }

            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message;
                //				Response.Write(ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }


        }



        private static string RemoveSpecChr(string pstr)
        {
            string rtnStr = "";
            rtnStr = Regex.Replace(pstr, "[ ](?=[ ])|[^-_A-Za-z0-9 ]+", new MatchEvaluator(CapText));
            //Regex.Replace(
            return rtnStr;
        }

        static string CapText(Match m)
        {
            //////			// Get the matched string.
            //////			string x = m.ToString();
            //////			// If the first char is lower case...
            //////			if (char.IsLower(x[0])) 
            //////			{
            //////				// Capitalize it.
            //////				return char.ToUpper(x[0]) + x.Substring(1, x.Length-1);
            //////			}
            //////			return x;
            return "";
        }




        private void MoveMatchingFile(string sourceFile, string destinationFile)
        {
            //
            //				SELECT     CLR.CASE_NO, CLR.Call_SNO, CLR.Call_Recv_dt, POM.Region_Code, POM.RLY_CD, CLR.Call_Install_No, TIE.IE_Sname, VND.Vend_Name, 
            //				VND.Vend_Add1, NVL(VND.Vend_Add2, ' ') AS Vend_Add2, VCT.City AS Vend_City, MFG.Vend_Name AS MFG_Name, MFG.Vend_Add1 AS MFG_Add1, 
            //				NVL(MFG.Vend_Add2, ' ') AS MFG_Add2, MCT.City AS MFG_City, CLR.MFG_PLACE, POM.PO_NO, POM.PO_DT, NVL(CON.CONSIGNEE_DESIG, ' ') 
            //				AS CONSIGNEE_DESIG, CON.CONSIGNEE_CD, CCT.City AS CONSIGNEE_CITYNAME, NVL(CON.CONSIGNEE_DEPT, ' ') AS CONSIGNEE_DEPT, 
            //				NVL(CON.CONSIGNEE_FIRM, ' ') AS CONSIGNEE_FIRM, NVL(PUR.CONSIGNEE_DESIG, ' ') AS PUR_DESIG, PUR.CONSIGNEE_CD AS PUR_CD, 
            //				NVL(PUR.CONSIGNEE_DEPT, ' ') AS PUR_DEPT, NVL(PUR.CONSIGNEE_FIRM, ' ') AS PUR_FIRM, NVL(PCT.City, ' ') AS PUR_City, CDT.ITEM_SRNO_PO, 
            //				CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN ICI.ITEM_DESC_PO ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN CDT.ITEM_DESC_PO ELSE
            //				CDT.ITEM_DESC_PO END END AS ITEM_DESC_PO, UOM.UOM_S_DESC, 
            //				CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN ICI.QTY_ORDERED ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN CDT.QTY_ORDERED ELSE
            //				CDT.QTY_ORDERED END END AS QTY_ORDERED, 
            //				CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN ICI.CUM_QTY_PREV_OFFERED ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN CDT.CUM_QTY_PREV_OFFERED
            //				ELSE CDT.CUM_QTY_PREV_OFFERED END END AS CUM_QTY_PREV_OFFERED, 
            //				CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN ICI.CUM_QTY_PREV_PASSED ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN CDT.CUM_QTY_PREV_PASSED
            //				ELSE CDT.CUM_QTY_PREV_PASSED END END AS CUM_QTY_PREV_PASSED, 
            //				CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN ICI.QTY_TO_INSP ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN CDT.QTY_TO_INSP ELSE CDT.QTY_TO_INSP
            //				END END AS QTY_TO_INSP, 
            //				CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN ICI.QTY_PASSED ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN CDT.QTY_PASSED ELSE CDT.QTY_PASSED
            //				END END AS QTY_PASSED, 
            //				CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN ICI.QTY_REJECTED ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN CDT.QTY_REJECTED ELSE
            //				CDT.QTY_REJECTED END END AS QTY_REJECTED, 
            //				CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN ICI.QTY_DUE ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN CDT.QTY_DUE ELSE CDT.QTY_DUE
            //				END END AS QTY_DUE, 
            //				CASE WHEN CONSGN_CALL_STATUS = 'Z' THEN ICI.HOLOGRAM ELSE CASE WHEN CONSGN_CALL_STATUS = 'A' THEN ICI.HOLOGRAM ELSE ICI.HOLOGRAM
            //				END END AS HOLOGRAM, PRM.NUM_VISITS, PRM.VISIT_DATES, BOF.BPO_NAME, BOF.BPO_ORGN, BCT.City, NVL(CLR.HOLOGRAM, '    ') 
            //				AS HOLOGRAMORG, NVL(ICI.REMARK, ' ') AS REMARK, CLR.DT_INSP_DESIRE, NVL(ICI.ITEM_REMARK, 'NO REMARK') AS ITEM_REMARK, 
            //				substr(ICI.AMENDMENT_1, 0, 99) AS AMENDMENT_1, substr(ICI.AMENDMENT_1, 100, 20) AS AMENDMENTDT_1, substr(ICI.AMENDMENT_2, 0, 99) 
            //				AS AMENDMENT_2, substr(ICI.AMENDMENT_2, 100, 20) AS AMENDMENTDT_2, substr(ICI.AMENDMENT_3, 0, 99) AS AMENDMENT_3, 
            //				substr(ICI.AMENDMENT_3, 100, 20) AS AMENDMENTDT_3, substr(ICI.AMENDMENT_4, 0, 99) AS AMENDMENT_4, substr(ICI.AMENDMENT_4, 100, 20) 
            //				AS AMENDMENTDT_4, ICI.BK_NO, ICI.SET_NO, ICI.VISITS_DATES, ICI.IE_STAMP_IMAGE
            //				FROM         RPT_PRM_Inspection_Certificate PRM INNER JOIN
            //				T17_Call_Register CLR ON CLR.CASE_NO = PRM.CASE_NO AND CLR.Call_Recv_dt = PRM.CALL_RECV_DT AND 
            //				CLR.Call_SNO = PRM.Call_SNO INNER JOIN
            //				T18_Call_Details CDT ON CLR.CASE_NO = CDT.CASE_NO AND CLR.Call_Recv_dt = CDT.Call_Recv_dt AND CLR.Call_SNO = CDT.Call_SNO INNER JOIN
            //				T13_PO_Master POM ON CLR.CASE_NO = POM.CASE_NO LEFT OUTER JOIN
            //				T15_PO_DETAIL POD ON CLR.CASE_NO = POD.CASE_NO AND CDT.ITEM_SRNO_PO = POD.ITEM_SRNO LEFT OUTER JOIN
            //				T04_UOM UOM ON POD.UOM_CD = UOM.UOM_CD LEFT OUTER JOIN
            //				T09_IE TIE ON CLR.IE_CD = TIE.IE_CD LEFT OUTER JOIN
            //				T05_Vendor VND ON POM.Vend_Cd = VND.Vend_Cd LEFT OUTER JOIN
            //				T03_City VCT ON VND.Vend_City_Cd = VCT.City_Cd LEFT OUTER JOIN
            //				T05_Vendor MFG ON CLR.MFG_CD = MFG.Vend_Cd LEFT OUTER JOIN
            //				T03_City MCT ON MFG.Vend_City_Cd = MCT.City_Cd LEFT OUTER JOIN
            //				T14_PO_BPO BPO ON CLR.CASE_NO = BPO.CASE_NO AND CDT.CONSIGNEE_CD = BPO.CONSIGNEE_CD LEFT OUTER JOIN
            //				T12_BILL_PAYING_OFFICER BOF ON BPO.BPO_CD = BOF.BPO_CD LEFT OUTER JOIN
            //				T03_City BCT ON BOF.BPO_City_Cd = BCT.City_Cd LEFT OUTER JOIN
            //				T06_Consignee CON ON BPO.CONSIGNEE_CD = CON.CONSIGNEE_CD LEFT OUTER JOIN
            //				T03_City CCT ON CON.CONSIGNEE_CITY = CCT.City_Cd LEFT OUTER JOIN
            //				T06_Consignee PUR ON POM.PURCHASER_CD = PUR.CONSIGNEE_CD LEFT OUTER JOIN
            //				T03_City PCT ON PUR.CONSIGNEE_CITY = PCT.City_Cd INNER JOIN
            //				IC_INTERMEDIATE ICI ON ICI.CASE_NO = CDT.CASE_NO AND ICI.Call_Recv_dt = CDT.Call_Recv_dt AND ICI.Call_SNO = CDT.Call_SNO AND 
            //				CDT.CONSIGNEE_CD = ICI.CONSIGNEE_CD AND CDT.ITEM_SRNO_PO = ICI.ITEM_SRNO_PO
            //				WHERE     ICI.ITEM_SRNO_PO IS NOT NULL
            //				ORDER BY CON.CONSIGNEE_CD, POD.ITEM_SRNO


            //




            if (!File.Exists(destinationFile)) File.Copy(sourceFile, destinationFile);
        }

        protected void CkBFile4_CheckedChanged(object sender, EventArgs e)
        {
            if (CkBFile4.Checked)
            {
                File4.Disabled = true;
                File4.Style.Add("width", "50%");
            }
            else
            {
                File4.Disabled = false;
                File4.Style.Add("width", "90%");
            }
        }

        protected void CkBFile5_CheckedChanged(object sender, EventArgs e)
        {
            if (CkBFile5.Checked)
            {
                File5.Disabled = true;
                File5.Style.Add("width", "50%");
            }
            else
            {
                File5.Disabled = false;
                File5.Style.Add("width", "90%");
            }

        }

        protected void CkBFile6_CheckedChanged(object sender, EventArgs e)
        {
            if (CkBFile6.Checked)
            {
                File6.Disabled = true;
                File6.Style.Add("width", "50%");
            }
            else
            {
                File6.Disabled = false;
                File6.Style.Add("width", "90%");
            }
        }

        protected void CkBFile7_CheckedChanged(object sender, EventArgs e)
        {
            if (CkBFile7.Checked)
            {
                File7.Disabled = true;
                File7.Style.Add("width", "50%");
            }
            else
            {
                File7.Disabled = false;
                File7.Style.Add("width", "90%");
            }
        }

        protected void CkBFile8_CheckedChanged(object sender, EventArgs e)
        {
            if (CkBFile8.Checked)
            {
                File8.Disabled = true;
                File8.Style.Add("width", "50%");
            }
            else
            {
                File8.Disabled = false;
                File8.Style.Add("width", "90%");
            }
        }

        protected void CkBFile9_CheckedChanged(object sender, EventArgs e)
        {
            if (CkBFile9.Checked)
            {
                File9.Disabled = true;
                File9.Style.Add("width", "50%");
            }
            else
            {
                File9.Disabled = false;
                File9.Style.Add("width", "90%");
            }
        }

        protected void CkBFile10_CheckedChanged(object sender, EventArgs e)
        {
            if (CkBFile10.Checked)
            {
                File10.Disabled = true;
                File10.Style.Add("width", "50%");
            }
            else
            {
                File10.Disabled = false;
                File10.Style.Add("width", "90%");
            }
        }

        protected void CkBFile11_CheckedChanged(object sender, EventArgs e)
        {
            if (CkBFile11.Checked)
            {
                File11.Disabled = true;
                File11.Style.Add("width", "50%");
            }
            else
            {
                File11.Disabled = false;
                File11.Style.Add("width", "90%");
            }
        }

        protected void CkBFile12_CheckedChanged(object sender, EventArgs e)
        {
            if (CkBFile12.Checked)
            {
                File12.Disabled = true;
                File12.Style.Add("width", "50%");
            }
            else
            {
                File12.Disabled = false;
                File12.Style.Add("width", "90%");
            }
        }

        protected void CkBFile13_CheckedChanged(object sender, EventArgs e)
        {
            if (CkBFile13.Checked)
            {
                File13.Disabled = true;
                File13.Style.Add("width", "50%");
            }
            else
            {
                File13.Disabled = false;
                File13.Style.Add("width", "90%");
            }
        }

        void photo_upload1(string BK_NO, string SET_NO, string CONSIGNEE_CD)
        {

            conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            OracleCommand cmd = new OracleCommand("select to_char(sysdate,'dd/mm/yyyy') from dual", conn);
            conn.Open();
            string ss = Convert.ToString(cmd.ExecuteScalar());
            conn.Close();
            conn.Open();
            OracleTransaction myTrans = conn.BeginTransaction();
            string MySql = "";
            bool checkFileVal = false;
            try
            {
                cmd = new OracleCommand("SELECT * FROM T49_IC_PHOTO_ENCLOSED  where CASE_NO='" + CASE_NO.Trim() + "' AND BK_NO='" + BK_NO + "' AND SET_NO='" + SET_NO + "' AND CALL_SNO = '" + CALL_SNO + "' AND CALL_RECV_DT =  TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy')  ", conn);
                //conn.Open();
                cmd.Transaction = myTrans;
                string BookNo = Convert.ToString(cmd.ExecuteScalar());

                if (BookNo == "")
                {
                    MySql = "Insert into T49_IC_PHOTO_ENCLOSED(CASE_NO,CALL_RECV_DT,CALL_SNO,BK_NO,SET_NO,CONSIGNEE_CD,USER_ID,DATETIME) " +
                    "values " +
                    "('" + CASE_NO.Trim() + "',to_date('" + CALL_RECV_DT.Trim() + "','dd/mm/yyyy')," + CALL_SNO + ",'" + BK_NO + "','" + SET_NO + "','" + CONSIGNEE_CD + "','" + Session["IE_EMP_NO"].ToString() + "',to_date('" + ss + "','dd/mm/yyyy'))";
                }
                else
                {
                    MySql = "Update T49_IC_PHOTO_ENCLOSED  set BK_NO ='" + BK_NO + "' ,SET_NO ='" + SET_NO + "', CONSIGNEE_CD='" + CONSIGNEE_CD + "' where CASE_NO='" + CASE_NO.Trim() + "' AND BK_NO='" + BK_NO + "' AND SET_NO='" + SET_NO + "' AND CALL_SNO = '" + CALL_SNO + "' AND CALL_RECV_DT =  TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') ";
                }
                OracleCommand cmd1 = new OracleCommand(MySql, conn);
                cmd1.Transaction = myTrans;
                cmd1.ExecuteNonQuery();


                ////
                //cmd = new OracleCommand("SELECT * FROM IC_INTERMEDIATE WHERE CASE_NO = '" + CASE_NO.Trim() + "' AND CALL_SNO = '" + CALL_SNO + "' AND CALL_RECV_DT =  TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CONSIGNEE_CD = '" + CONSIGNEE_CD + "'", conn);
                ////conn.Open();
                //cmd.Transaction = myTrans;
                //BookNo = Convert.ToString(cmd.ExecuteScalar());

                //if (BookNo == "")
                //{

                //    MySql = "Insert into IC_INTERMEDIATE(CASE_NO,CALL_RECV_DT,CALL_SNO,BK_NO,SET_NO,CONSIGNEE_CD,USER_ID,DATETIME) " +
                //        "values " +
                //        "('" + CASE_NO.Trim() + "',to_date('" + CALL_RECV_DT.Trim() + "','dd/mm/yyyy')," + CALL_SNO + ",'" + BK_NO + "','" + SET_NO + "','" + CONSIGNEE_CD + "','" + Session["IE_EMP_NO"].ToString() + "',to_date('" + ss + "','dd/mm/yyyy'))";
                //}
                //else
                //{
                //    MySql = "Update IC_INTERMEDIATE  set BK_NO ='" + BK_NO + "' ,SET_NO ='" + SET_NO + "' WHERE CASE_NO = '" + CASE_NO.Trim() + "' AND CALL_SNO = '" + CALL_SNO + "' AND CALL_RECV_DT =  TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CONSIGNEE_CD = '" + CONSIGNEE_CD + "' ";
                //}
                //cmd1 = new OracleCommand(MySql, conn);
                //cmd1.Transaction = myTrans;
                //cmd1.ExecuteNonQuery();

                //if (!Directory.Exists(Server.MapPath("IC_PHOTOS") + "/" + CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + CONSIGNEE_CD))
                //Directory.CreateDirectory(Server.MapPath("IC_PHOTOS") + "/" + CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + CONSIGNEE_CD);

                //

                string myUpdateQuery = "Update T49_IC_PHOTO_ENCLOSED set ";
                string myUpdateQueryIC = "Update IC_INTERMEDIATE set ";


                string fn = "", fx = "", MyFile = "";
                string LFILE_1 = "";
                string LFILE_2 = "";
                string LFILE_3 = "";
                string LFILE_4 = "";
                string LFILE_5 = "";
                string LFILE_6 = "";
                string LFILE_7 = "";
                string LFILE_8 = "";
                string LFILE_9 = "";
                string LFILE_10 = "";
                DataSet ds = new DataSet();
                if (CkBFile4.Checked || CkBFile5.Checked || CkBFile6.Checked || CkBFile7.Checked || CkBFile8.Checked || CkBFile9.Checked || CkBFile10.Checked || CkBFile11.Checked || CkBFile12.Checked || CkBFile13.Checked)
                {
                    //string str = "SELECT ici.BK_NO,ICI.SET_NO,t49.file_1,t49.file_2,t49.file_3,t49.file_4,t49.file_5,t49.file_6,t49.file_7,t49.file_8,t49.file_9,t49.file_10 ,ICI.file_1 AS LFILE_1,ICI.file_2 AS LFILE_2,ICI.file_3 AS LFILE_3,ICI.file_4 AS LFILE_4,ICI.file_5 AS LFILE_5,ICI.file_6 AS LFILE_6,ICI.file_7 AS LFILE_7,ICI.file_8 AS LFILE_8 ,ICI.file_9 AS LFILE_9 ,ICI.file_10 AS LFILE_10 FROM IC_INTERMEDIATE ICI inner join t49_ic_photo_enclosed T49 on ICI.CASE_NO = T49.CASE_NO AND ICI.CONSIGNEE_CD = T49.CONSIGNEE_CD AND ici.CALL_SNO = T49.CALL_SNO AND ici.CALL_RECV_DT = T49.CALL_RECV_DT WHERE ici.CASE_NO='" + CASE_NO.Trim() + "' AND ici.CALL_RECV_DT= TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND ici.CALL_SNO='" + CALL_SNO + "' AND ici.CONSIGNEE_CD ='" + CONSIGNEE_CD + "' ORDER BY ici.DATETIME DESC";
                    string str = "SELECT ici.BK_NO,ICI.SET_NO,ICI.file_1 AS LFILE_1,ICI.file_2 AS LFILE_2,ICI.file_3 AS LFILE_3,ICI.file_4 AS LFILE_4,ICI.file_5 AS LFILE_5,ICI.file_6 AS LFILE_6,ICI.file_7 AS LFILE_7,ICI.file_8 AS LFILE_8 ,ICI.file_9 AS LFILE_9 ,ICI.file_10 AS LFILE_10 FROM IC_INTERMEDIATE ICI WHERE ici.CASE_NO='" + CASE_NO.Trim() + "' AND ici.CALL_RECV_DT= TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND ici.CALL_SNO='" + CALL_SNO + "' ORDER BY ici.DATETIME DESC";
                    OracleDataAdapter da = new OracleDataAdapter(str, conn);
                    OracleCommand myOracleCommand = new OracleCommand(str, conn);
                    myOracleCommand.Transaction = myTrans;
                    da.SelectCommand = myOracleCommand;
                    da.Fill(ds, "Table");


                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow itemDR in ds.Tables[0].Rows)
                            {
                                LFILE_1 = Convert.ToString(itemDR["LFILE_1"]);
                                LFILE_2 = Convert.ToString(itemDR["LFILE_2"]);
                                LFILE_3 = Convert.ToString(itemDR["LFILE_3"]);
                                LFILE_4 = Convert.ToString(itemDR["LFILE_4"]);
                                LFILE_5 = Convert.ToString(itemDR["LFILE_5"]);
                                LFILE_6 = Convert.ToString(itemDR["LFILE_6"]);
                                LFILE_7 = Convert.ToString(itemDR["LFILE_7"]);
                                LFILE_8 = Convert.ToString(itemDR["LFILE_8"]);
                                LFILE_9 = Convert.ToString(itemDR["LFILE_9"]);
                                LFILE_10 = Convert.ToString(itemDR["LFILE_10"]);
                                break;
                            }
                        }
                    }

                }
                checkFileVal = false;
                if (CkBFile4.Checked)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow itemDR in ds.Tables[0].Rows)
                            {

                                MyFile = CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "01";
                                fx = System.IO.Path.GetExtension(LFILE_1).ToUpper().Substring(1);
                                //Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + Convert.ToString(itemDR["BK_NO"]) + "-" + Convert.ToString(itemDR["SET_NO"]) + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx);

                                //MoveMatchingFile(Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + Convert.ToString(itemDR["BK_NO"]) + "-" + Convert.ToString(itemDR["SET_NO"]) + "-" + CONSIGNEE_CD + "/" + Convert.ToString(itemDR["FILE_1"])), Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx));
                                MoveMatchingFile(Server.MapPath("IC_PHOTOS/" + LFILE_1), Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx));

                                //myUpdateQueryIC = myUpdateQueryIC + " FILE_1='" + Convert.ToString(itemDR["LFILE_1"]) + "' ";
                                myUpdateQueryIC = myUpdateQueryIC + " FILE_1='" + MyFile + "." + fx + "' ";
                                myUpdateQuery = myUpdateQuery + " FILE_1='" + MyFile + "." + fx + "' ";
                                checkFileVal = true;
                                break;
                            }
                        }
                    }
                }
                else
                {

                    if (File4.PostedFile != null && File4.PostedFile.ContentLength > 0)
                    {
                        //string fn = "", fx = "", MyFile = "";
                        MyFile = CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "01";
                        fn = System.IO.Path.GetFileName(File4.PostedFile.FileName);
                        fx = System.IO.Path.GetExtension(File4.PostedFile.FileName).ToUpper().Substring(1);
                        //
                        String SaveLocationCSN = null;
                        //SaveLocationCSN = Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx);
                        //File4.PostedFile.SaveAs(SaveLocationCSN);
                        //myUpdateQueryIC = myUpdateQueryIC + " FILE_1='" + fn + "' ";
                        myUpdateQueryIC = myUpdateQueryIC + " FILE_1='" + MyFile + "." + fx + "' ";
                        //
                        String SaveLocation = null;
                        SaveLocation = Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx);
                        File4.PostedFile.SaveAs(SaveLocation);
                        myUpdateQuery = myUpdateQuery + " FILE_1='" + MyFile + "." + fx + "' ";

                        checkFileVal = true;

                    }
                }

                if (!checkFileVal)
                {
                    myUpdateQueryIC = myUpdateQueryIC + " FILE_1='' ";
                    myUpdateQuery = myUpdateQuery + " FILE_1='' ";
                }
                checkFileVal = false;
                if (CkBFile5.Checked)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow itemDR in ds.Tables[0].Rows)
                            {
                                MyFile = CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "02";
                                fx = System.IO.Path.GetExtension(LFILE_2).ToUpper().Substring(1);
                                //Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + Convert.ToString(itemDR["BK_NO"]) + "-" + Convert.ToString(itemDR["SET_NO"]) + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx);

                                //MoveMatchingFile(Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + Convert.ToString(itemDR["BK_NO"]) + "-" + Convert.ToString(itemDR["SET_NO"]) + "-" + CONSIGNEE_CD + "/" + Convert.ToString(itemDR["FILE_2"])), Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx));
                                MoveMatchingFile(Server.MapPath("IC_PHOTOS/" + LFILE_2), Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx));

                                //myUpdateQueryIC = myUpdateQueryIC + " , FILE_2='" + Convert.ToString(itemDR["LFILE_2"]) + "' ";
                                myUpdateQueryIC = myUpdateQueryIC + " , FILE_2='" + MyFile + "." + fx + "' ";
                                myUpdateQuery = myUpdateQuery + " , FILE_2='" + MyFile + "." + fx + "' ";
                                checkFileVal = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (File5.PostedFile != null && File5.PostedFile.ContentLength > 0)
                    {
                        //string fn = "", fx = "", MyFile = "";
                        MyFile = CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "02";
                        fn = System.IO.Path.GetFileName(File5.PostedFile.FileName);
                        fx = System.IO.Path.GetExtension(File5.PostedFile.FileName).ToUpper().Substring(1);
                        //
                        String SaveLocationCSN = null;
                        //SaveLocationCSN = Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx);
                        //File5.PostedFile.SaveAs(SaveLocationCSN);
                        //myUpdateQueryIC = myUpdateQueryIC + " , FILE_2='" + fn + "' ";
                        myUpdateQueryIC = myUpdateQueryIC + " , FILE_2='" + MyFile + "." + fx + "' ";
                        //
                        String SaveLocation = null;
                        SaveLocation = Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx);
                        File5.PostedFile.SaveAs(SaveLocation);
                        myUpdateQuery = myUpdateQuery + " , FILE_2='" + MyFile + "." + fx + "' ";
                        checkFileVal = true;
                    }
                }
                if (!checkFileVal)
                {
                    myUpdateQueryIC = myUpdateQueryIC + " , FILE_2='' ";
                    myUpdateQuery = myUpdateQuery + " , FILE_2='' ";
                }
                checkFileVal = false;
                if (CkBFile6.Checked)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow itemDR in ds.Tables[0].Rows)
                            {
                                MyFile = CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "03";
                                fx = System.IO.Path.GetExtension(LFILE_3).ToUpper().Substring(1);
                                //Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + Convert.ToString(itemDR["BK_NO"]) + "-" + Convert.ToString(itemDR["SET_NO"]) + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx);

                                //MoveMatchingFile(Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + Convert.ToString(itemDR["BK_NO"]) + "-" + Convert.ToString(itemDR["SET_NO"]) + "-" + CONSIGNEE_CD + "/" + Convert.ToString(itemDR["FILE_3"])), Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx));
                                MoveMatchingFile(Server.MapPath("IC_PHOTOS/" + LFILE_3), Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx));

                                //myUpdateQueryIC = myUpdateQueryIC + " , FILE_3='" + Convert.ToString(itemDR["LFILE_3"]) + "' ";
                                myUpdateQueryIC = myUpdateQueryIC + " , FILE_3='" + MyFile + "." + fx + "' ";
                                myUpdateQuery = myUpdateQuery + " , FILE_3='" + MyFile + "." + fx + "' ";
                                checkFileVal = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (File6.PostedFile != null && File6.PostedFile.ContentLength > 0)
                    {
                        //string fn = "", fx = "", MyFile = "";
                        MyFile = CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "03";
                        fn = System.IO.Path.GetFileName(File6.PostedFile.FileName);
                        fx = System.IO.Path.GetExtension(File6.PostedFile.FileName).ToUpper().Substring(1);
                        //
                        String SaveLocationCSN = null;
                        //SaveLocationCSN = Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx);
                        //File6.PostedFile.SaveAs(SaveLocationCSN);
                        //myUpdateQueryIC = myUpdateQueryIC + " , FILE_3='" + fn + "' ";
                        myUpdateQueryIC = myUpdateQueryIC + " , FILE_3='" + MyFile + "." + fx + "' ";
                        //
                        String SaveLocation = null;
                        SaveLocation = Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx);
                        File6.PostedFile.SaveAs(SaveLocation);
                        myUpdateQuery = myUpdateQuery + " , FILE_3='" + MyFile + "." + fx + "' ";
                        checkFileVal = true;
                    }
                }
                if (!checkFileVal)
                {
                    myUpdateQueryIC = myUpdateQueryIC + " , FILE_3='' ";
                    myUpdateQuery = myUpdateQuery + " , FILE_3='' ";
                }
                checkFileVal = false;
                if (CkBFile7.Checked)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow itemDR in ds.Tables[0].Rows)
                            {
                                MyFile = CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "04";
                                fx = System.IO.Path.GetExtension(LFILE_4).ToUpper().Substring(1);
                                //Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + Convert.ToString(itemDR["BK_NO"]) + "-" + Convert.ToString(itemDR["SET_NO"]) + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx);

                                //MoveMatchingFile(Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + Convert.ToString(itemDR["BK_NO"]) + "-" + Convert.ToString(itemDR["SET_NO"]) + "-" + CONSIGNEE_CD + "/" + Convert.ToString(itemDR["FILE_4"])), Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx));
                                MoveMatchingFile(Server.MapPath("IC_PHOTOS/" + LFILE_4), Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx));

                                //myUpdateQueryIC = myUpdateQueryIC + " , FILE_4='" + Convert.ToString(itemDR["LFILE_4"]) + "' ";

                                myUpdateQueryIC = myUpdateQueryIC + " , FILE_4='" + MyFile + "." + fx + "' ";
                                myUpdateQuery = myUpdateQuery + "  , FILE_4='" + MyFile + "." + fx + "' ";
                                checkFileVal = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (File7.PostedFile != null && File7.PostedFile.ContentLength > 0)
                    {
                        //string fn = "", fx = "", MyFile = "";
                        MyFile = CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "04";
                        fn = System.IO.Path.GetFileName(File7.PostedFile.FileName);
                        fx = System.IO.Path.GetExtension(File7.PostedFile.FileName).ToUpper().Substring(1);
                        //
                        String SaveLocationCSN = null;
                        //SaveLocationCSN = Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx);
                        //File7.PostedFile.SaveAs(SaveLocationCSN);
                        //myUpdateQueryIC = myUpdateQueryIC + " , FILE_4='" + fn + "' ";
                        myUpdateQueryIC = myUpdateQueryIC + " , FILE_4='" + MyFile + "." + fx + "' ";
                        //
                        String SaveLocation = null;
                        SaveLocation = Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx);
                        File7.PostedFile.SaveAs(SaveLocation);
                        myUpdateQuery = myUpdateQuery + " , FILE_4='" + MyFile + "." + fx + "' ";
                        checkFileVal = true;
                    }
                }
                if (!checkFileVal)
                {
                    myUpdateQueryIC = myUpdateQueryIC + " , FILE_4='' ";
                    myUpdateQuery = myUpdateQuery + " , FILE_4='' ";
                }
                checkFileVal = false;
                if (CkBFile8.Checked)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow itemDR in ds.Tables[0].Rows)
                            {
                                MyFile = CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "05";
                                fx = System.IO.Path.GetExtension(LFILE_5).ToUpper().Substring(1);
                                //Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + Convert.ToString(itemDR["BK_NO"]) + "-" + Convert.ToString(itemDR["SET_NO"]) + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx);

                                //MoveMatchingFile(Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + Convert.ToString(itemDR["BK_NO"]) + "-" + Convert.ToString(itemDR["SET_NO"]) + "-" + CONSIGNEE_CD + "/" + Convert.ToString(itemDR["FILE_5"])), Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx));
                                MoveMatchingFile(Server.MapPath("IC_PHOTOS/" + LFILE_5), Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx));

                                //myUpdateQueryIC = myUpdateQueryIC + " , FILE_5='" + Convert.ToString(itemDR["LFILE_5"]) + "' ";
                                myUpdateQueryIC = myUpdateQueryIC + " , FILE_5='" + MyFile + "." + fx + "' ";
                                myUpdateQuery = myUpdateQuery + " , FILE_5='" + MyFile + "." + fx + "' ";
                                checkFileVal = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (File8.PostedFile != null && File8.PostedFile.ContentLength > 0)
                    {
                        //string fn = "", fx = "", MyFile = "";
                        MyFile = CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "05";
                        fn = System.IO.Path.GetFileName(File8.PostedFile.FileName);
                        fx = System.IO.Path.GetExtension(File8.PostedFile.FileName).ToUpper().Substring(1);
                        //
                        String SaveLocationCSN = null;
                        //SaveLocationCSN = Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx);
                        //File8.PostedFile.SaveAs(SaveLocationCSN);
                        //myUpdateQueryIC = myUpdateQueryIC + " , FILE_5='" + fn + "' ";
                        myUpdateQueryIC = myUpdateQueryIC + " , FILE_5='" + MyFile + "." + fx + "' ";
                        //
                        String SaveLocation = null;
                        SaveLocation = Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx);
                        File8.PostedFile.SaveAs(SaveLocation);
                        myUpdateQuery = myUpdateQuery + " , FILE_5='" + MyFile + "." + fx + "' ";
                        checkFileVal = true;

                    }
                }
                if (!checkFileVal)
                {
                    myUpdateQueryIC = myUpdateQueryIC + " ,  FILE_5='' ";
                    myUpdateQuery = myUpdateQuery + " , FILE_5='' ";
                }
                checkFileVal = false;
                if (CkBFile9.Checked)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow itemDR in ds.Tables[0].Rows)
                            {
                                MyFile = CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "06";
                                fx = System.IO.Path.GetExtension(LFILE_6).ToUpper().Substring(1);
                                //Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + Convert.ToString(itemDR["BK_NO"]) + "-" + Convert.ToString(itemDR["SET_NO"]) + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx);

                                //MoveMatchingFile(Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + Convert.ToString(itemDR["BK_NO"]) + "-" + Convert.ToString(itemDR["SET_NO"]) + "-" + CONSIGNEE_CD + "/" + Convert.ToString(itemDR["FILE_6"])), Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx));
                                MoveMatchingFile(Server.MapPath("IC_PHOTOS/" + LFILE_6), Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx));

                                //myUpdateQueryIC = myUpdateQueryIC + " , FILE_6='" + Convert.ToString(itemDR["LFILE_6"]) + "' ";
                                myUpdateQueryIC = myUpdateQueryIC + " , FILE_6='" + MyFile + "." + fx + "' ";
                                myUpdateQuery = myUpdateQuery + " , FILE_6='" + MyFile + "." + fx + "' ";
                                checkFileVal = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (File9.PostedFile != null && File9.PostedFile.ContentLength > 0)
                    {
                        //string fn = "", fx = "", MyFile = "";
                        MyFile = CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "06";
                        fn = System.IO.Path.GetFileName(File9.PostedFile.FileName);
                        fx = System.IO.Path.GetExtension(File9.PostedFile.FileName).ToUpper().Substring(1);
                        //
                        String SaveLocationCSN = null;
                        //SaveLocationCSN = Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx);
                        //File9.PostedFile.SaveAs(SaveLocationCSN);
                        //myUpdateQueryIC = myUpdateQueryIC + " , FILE_6='" + fn + "' ";
                        myUpdateQueryIC = myUpdateQueryIC + " , FILE_6='" + MyFile + "." + fx + "' ";
                        //
                        String SaveLocation = null;
                        SaveLocation = Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx);
                        File9.PostedFile.SaveAs(SaveLocation);
                        myUpdateQuery = myUpdateQuery + " , FILE_6='" + MyFile + "." + fx + "' ";
                        checkFileVal = true;
                    }
                }
                if (!checkFileVal)
                {
                    myUpdateQueryIC = myUpdateQueryIC + " , FILE_6='' ";
                    myUpdateQuery = myUpdateQuery + " , FILE_6='' ";
                }
                checkFileVal = false;
                if (CkBFile10.Checked)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow itemDR in ds.Tables[0].Rows)
                            {
                                MyFile = CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "07";
                                fx = System.IO.Path.GetExtension(LFILE_7).ToUpper().Substring(1);
                                //Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + Convert.ToString(itemDR["BK_NO"]) + "-" + Convert.ToString(itemDR["SET_NO"]) + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx);

                                //MoveMatchingFile(Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + Convert.ToString(itemDR["BK_NO"]) + "-" + Convert.ToString(itemDR["SET_NO"]) + "-" + CONSIGNEE_CD + "/" + Convert.ToString(itemDR["FILE_7"])), Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx));
                                MoveMatchingFile(Server.MapPath("IC_PHOTOS/" + LFILE_7), Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx));

                                //myUpdateQueryIC = myUpdateQueryIC + " , FILE_7='" + Convert.ToString(itemDR["LFILE_7"]) + "' ";
                                myUpdateQueryIC = myUpdateQueryIC + " , FILE_7='" + MyFile + "." + fx + "' ";
                                myUpdateQuery = myUpdateQuery + " , FILE_7='" + MyFile + "." + fx + "' ";
                                checkFileVal = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (File10.PostedFile != null && File10.PostedFile.ContentLength > 0)
                    {
                        //string fn = "", fx = "", MyFile = "";
                        MyFile = CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "07";
                        fn = System.IO.Path.GetFileName(File10.PostedFile.FileName);
                        fx = System.IO.Path.GetExtension(File10.PostedFile.FileName).ToUpper().Substring(1);
                        //
                        String SaveLocationCSN = null;
                        //SaveLocationCSN = Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx);
                        //File10.PostedFile.SaveAs(SaveLocationCSN);
                        //myUpdateQueryIC = myUpdateQueryIC + " , FILE_7='" + fn + "' ";
                        myUpdateQueryIC = myUpdateQueryIC + " , FILE_7='" + MyFile + "." + fx + "' ";
                        //
                        String SaveLocation = null;
                        SaveLocation = Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx);
                        File10.PostedFile.SaveAs(SaveLocation);
                        myUpdateQuery = myUpdateQuery + " , FILE_7='" + MyFile + "." + fx + "' ";
                        checkFileVal = true;
                    }
                }
                if (!checkFileVal)
                {
                    myUpdateQueryIC = myUpdateQueryIC + " , FILE_7='' ";
                    myUpdateQuery = myUpdateQuery + " , FILE_7='' ";
                }
                checkFileVal = false;
                if (CkBFile11.Checked)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow itemDR in ds.Tables[0].Rows)
                            {
                                MyFile = CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "08";
                                fx = System.IO.Path.GetExtension(LFILE_8).ToUpper().Substring(1);
                                //Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + Convert.ToString(itemDR["BK_NO"]) + "-" + Convert.ToString(itemDR["SET_NO"]) + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx);

                                //MoveMatchingFile(Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + Convert.ToString(itemDR["BK_NO"]) + "-" + Convert.ToString(itemDR["SET_NO"]) + "-" + CONSIGNEE_CD + "/" + Convert.ToString(itemDR["FILE_8"])), Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx));
                                MoveMatchingFile(Server.MapPath("IC_PHOTOS/" + LFILE_8), Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx));

                                //myUpdateQueryIC = myUpdateQueryIC + " , FILE_8='" + Convert.ToString(itemDR["LFILE_8"]) + "' ";
                                myUpdateQueryIC = myUpdateQueryIC + " , FILE_8='" + MyFile + "." + fx + "' ";
                                myUpdateQuery = myUpdateQuery + " , FILE_8='" + MyFile + "." + fx + "' ";
                                checkFileVal = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (File11.PostedFile != null && File11.PostedFile.ContentLength > 0)
                    {
                        //string fn = "", fx = "", MyFile = "";
                        MyFile = CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "08";
                        fn = System.IO.Path.GetFileName(File11.PostedFile.FileName);
                        fx = System.IO.Path.GetExtension(File11.PostedFile.FileName).ToUpper().Substring(1);
                        //
                        String SaveLocationCSN = null;
                        //SaveLocationCSN = Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx);
                        //File11.PostedFile.SaveAs(SaveLocationCSN);
                        //myUpdateQueryIC = myUpdateQueryIC + " , FILE_8='" + fn + "' ";
                        myUpdateQueryIC = myUpdateQueryIC + " , FILE_8='" + MyFile + "." + fx + "' ";
                        //
                        String SaveLocation = null;
                        SaveLocation = Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx);
                        File11.PostedFile.SaveAs(SaveLocation);
                        myUpdateQuery = myUpdateQuery + " , FILE_8='" + MyFile + "." + fx + "' ";
                        checkFileVal = true;
                    }
                }
                if (!checkFileVal)
                {
                    myUpdateQueryIC = myUpdateQueryIC + " , FILE_8='' ";
                    myUpdateQuery = myUpdateQuery + " , FILE_8='' ";
                }
                checkFileVal = false;
                if (CkBFile12.Checked)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow itemDR in ds.Tables[0].Rows)
                            {
                                MyFile = CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "09";
                                fx = System.IO.Path.GetExtension(LFILE_9).ToUpper().Substring(1);
                                //Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + Convert.ToString(itemDR["BK_NO"]) + "-" + Convert.ToString(itemDR["SET_NO"]) + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx);

                                //MoveMatchingFile(Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + Convert.ToString(itemDR["BK_NO"]) + "-" + Convert.ToString(itemDR["SET_NO"]) + "-" + CONSIGNEE_CD + "/" + Convert.ToString(itemDR["FILE_9"])), Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx));
                                MoveMatchingFile(Server.MapPath("IC_PHOTOS/" + LFILE_9), Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx));

                                //myUpdateQueryIC = myUpdateQueryIC + " , FILE_9='" + Convert.ToString(itemDR["LFILE_9"]) + "' ";
                                myUpdateQueryIC = myUpdateQueryIC + " , FILE_9='" + MyFile + "." + fx + "' ";
                                myUpdateQuery = myUpdateQuery + " , FILE_9='" + MyFile + "." + fx + "' ";
                                checkFileVal = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (File12.PostedFile != null && File12.PostedFile.ContentLength > 0)
                    {
                        //string fn = "", fx = "", MyFile = "";
                        MyFile = CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "09";
                        fn = System.IO.Path.GetFileName(File12.PostedFile.FileName);
                        fx = System.IO.Path.GetExtension(File12.PostedFile.FileName).ToUpper().Substring(1);
                        //
                        String SaveLocationCSN = null;
                        //SaveLocationCSN = Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx);
                        //File12.PostedFile.SaveAs(SaveLocationCSN);
                        //myUpdateQueryIC = myUpdateQueryIC + " , FILE_9='" + fn + "' ";
                        myUpdateQueryIC = myUpdateQueryIC + " , FILE_9='" + MyFile + "." + fx + "' ";
                        //
                        String SaveLocation = null;
                        SaveLocation = Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx);
                        File12.PostedFile.SaveAs(SaveLocation);
                        myUpdateQuery = myUpdateQuery + " , FILE_9='" + MyFile + "." + fx + "' ";
                        checkFileVal = true;
                    }
                }
                if (!checkFileVal)
                {
                    myUpdateQueryIC = myUpdateQueryIC + " , FILE_9='' ";
                    myUpdateQuery = myUpdateQuery + " , FILE_9='' ";
                }
                checkFileVal = false;
                if (CkBFile13.Checked)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow itemDR in ds.Tables[0].Rows)
                            {
                                MyFile = CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "10";
                                fx = System.IO.Path.GetExtension(LFILE_10).ToUpper().Substring(1);
                                //Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + Convert.ToString(itemDR["BK_NO"]) + "-" + Convert.ToString(itemDR["SET_NO"]) + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx);

                                //MoveMatchingFile(Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + Convert.ToString(itemDR["BK_NO"]) + "-" + Convert.ToString(itemDR["SET_NO"]) + "-" + CONSIGNEE_CD + "/" + Convert.ToString(itemDR["FILE_110"])), Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx));
                                MoveMatchingFile(Server.MapPath("IC_PHOTOS/" + LFILE_10), Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx));

                                //myUpdateQueryIC = myUpdateQueryIC + " , FILE_10='" + Convert.ToString(itemDR["LFILE_10"]) + "' ";
                                myUpdateQueryIC = myUpdateQueryIC + " , FILE_10='" + MyFile + "." + fx + "' ";
                                myUpdateQuery = myUpdateQuery + " , FILE_10='" + MyFile + "." + fx + "' ";
                                checkFileVal = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (File13.PostedFile != null && File13.PostedFile.ContentLength > 0)
                    {
                        //string fn = "", fx = "", MyFile = "";
                        MyFile = CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + "10";
                        fn = System.IO.Path.GetFileName(File13.PostedFile.FileName);
                        fx = System.IO.Path.GetExtension(File13.PostedFile.FileName).ToUpper().Substring(1);
                        //
                        String SaveLocationCSN = null;
                        //SaveLocationCSN = Server.MapPath("IC_PHOTOS/" + CASE_NO.Trim() + "-" + BK_NO + "-" + SET_NO + "-" + CONSIGNEE_CD + "/" + MyFile + "." + fx);
                        //File13.PostedFile.SaveAs(SaveLocationCSN);
                        //myUpdateQueryIC = myUpdateQueryIC + " , FILE_10='" + fn + "' ";
                        myUpdateQueryIC = myUpdateQueryIC + " , FILE_10='" + MyFile + "." + fx + "' ";
                        //
                        String SaveLocation = null;
                        SaveLocation = Server.MapPath("IC_PHOTOS/" + MyFile + "." + fx);
                        File13.PostedFile.SaveAs(SaveLocation);
                        myUpdateQuery = myUpdateQuery + " , FILE_10='" + MyFile + "." + fx + "' ";

                        checkFileVal = true;

                    }
                }
                if (!checkFileVal)
                {
                    myUpdateQueryIC = myUpdateQueryIC + " , FILE_10='' ";
                    myUpdateQuery = myUpdateQuery + " , FILE_10='' ";
                }
                checkFileVal = false;


                //
                cmd = new OracleCommand("SELECT * FROM IC_INTERMEDIATE WHERE CASE_NO = '" + CASE_NO.Trim() + "' AND CALL_SNO = '" + CALL_SNO + "' AND CALL_RECV_DT =  TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CONSIGNEE_CD = '" + CONSIGNEE_CD + "'", conn);
                //conn.Open();
                cmd.Transaction = myTrans;
                BookNo = Convert.ToString(cmd.ExecuteScalar());

                if (BookNo == "")
                {
                    //
                    //
                    OracleConnection conn2 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

                    ds = new DataSet();
                    string str = "SELECT * FROM T18_Call_Details WHERE CASE_NO = '" + lblCSNO.Text.Trim() + "' AND CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CALL_SNO = '" + CALL_SNO + "' and consignee_cd = '" + Convert.ToString(ddlCondignee.SelectedValue) + "'";

                    OracleDataAdapter da = new OracleDataAdapter(str, conn2);
                    OracleCommand myOracleCommand = new OracleCommand(str, conn2);
                    conn2.Open();
                    da.SelectCommand = myOracleCommand;
                    conn2.Close();
                    da.Fill(ds, "Table");

                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow itemDR in ds.Tables[0].Rows)
                            {
                                //
                                MySql = "Insert into IC_INTERMEDIATE(CASE_NO,CALL_RECV_DT,CALL_SNO,BK_NO,SET_NO,PO_NO,CONSIGNEE_CD,USER_ID,ITEM_SRNO_PO,ITEM_DESC_PO,QTY_PASSED,QTY_REJECTED,QTY_DUE,IE_CD,DATETIME) " +
                                    "values " +
                                    "('" + CASE_NO.Trim() + "',to_date('" + CALL_RECV_DT.Trim() + "','dd/mm/yyyy')," + CALL_SNO + ",'" + BK_NO + "','" + SET_NO + "','" + lblPONO.Text + "','" + CONSIGNEE_CD + "','" + Session["IE_EMP_NO"].ToString() + "','" + Convert.ToString(itemDR["ITEM_SRNO_PO"]) + "','" + Convert.ToString(itemDR["ITEM_DESC_PO"]) + "','" + Convert.ToString(itemDR["QTY_PASSED"]) + "','" + Convert.ToString(itemDR["QTY_REJECTED"]) + "','" + Convert.ToString(itemDR["QTY_DUE"]) + "'," + wIECD + ",to_date('" + ss + "','dd/mm/yyyy'))";

                                OracleCommand cmd11 = new OracleCommand(MySql, conn);
                                cmd11.Transaction = myTrans;
                                cmd11.ExecuteNonQuery();
                                //
                            }
                        }
                    }
                    //

                    //                    MySql = "Insert into IC_INTERMEDIATE(CASE_NO,CALL_RECV_DT,CALL_SNO,BK_NO,SET_NO,PO_NO,CONSIGNEE_CD,USER_ID,DATETIME) " +
                    //                        "values " +
                    //                        "('" + CASE_NO.Trim() + "',to_date('" + CALL_RECV_DT.Trim() + "','dd/mm/yyyy')," + CALL_SNO + ",'" + BK_NO + "','" + SET_NO + "','" + lblPONO.Text + "','" + CONSIGNEE_CD + "','" + Session["IE_EMP_NO"].ToString() + "',to_date('" + ss + "','dd/mm/yyyy'))";
                }
                else
                {
                    MySql = "Update IC_INTERMEDIATE  set BK_NO ='" + BK_NO + "' ,SET_NO ='" + SET_NO + "' WHERE CASE_NO = '" + CASE_NO.Trim() + "' AND CALL_SNO = '" + CALL_SNO + "' AND CALL_RECV_DT =  TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CONSIGNEE_CD = '" + CONSIGNEE_CD + "' ";
                    OracleCommand cmd11 = new OracleCommand(MySql, conn);
                    cmd11.Transaction = myTrans;
                    cmd11.ExecuteNonQuery();
                }


                myUpdateQuery = myUpdateQuery + " where CASE_NO='" + CASE_NO.Trim() + "' AND BK_NO='" + BK_NO + "' AND SET_NO='" + SET_NO + "' ";
                OracleCommand myInsertCommand1 = new OracleCommand(myUpdateQuery);
                myInsertCommand1.Transaction = myTrans;
                myInsertCommand1.Connection = conn;
                myInsertCommand1.ExecuteNonQuery();

                //
                myUpdateQueryIC = myUpdateQueryIC + " where CASE_NO='" + CASE_NO.Trim() + "' AND BK_NO='" + BK_NO + "' AND SET_NO='" + SET_NO + "' AND CONSIGNEE_CD='" + CONSIGNEE_CD + "'";
                OracleCommand myInsertCommand11 = new OracleCommand(myUpdateQueryIC);
                myInsertCommand11.Transaction = myTrans;
                myInsertCommand11.Connection = conn;
                myInsertCommand11.ExecuteNonQuery();
                //

                myTrans.Commit();
                conn.Close();
                FillFileNames(true);
            }
            catch (FileNotFoundException fe)
            { Response.Write("File not found" + fe); }
            catch (System.IO.DirectoryNotFoundException de)
            { Response.Write("Directry not found" + de); }
            catch (Exception ex)
            {
                string str;
                str = ex.Message;
                string str1 = str.Replace("\n", "");
                Response.Redirect(("Error_Form.aspx?err=" + str1));
                myTrans.Rollback();
                DisplayAlert("Upload is not Successfull, Plz Try Again!!!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();

            }
        }

        private void btnSaveFiles_Click(object sender, System.EventArgs e)
        {


            if (ddlCondignee.SelectedValue == "0")
            {
                DisplayAlert("Please select consignee !");

                return;
            }

            string str = "";
            int consignee_cd = 0;
            conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            conn.Open();
            OracleCommand cmd = new OracleCommand("SELECT consignee_cd FROM IC_INTERMEDIATE ICI WHERE ici.CASE_NO='" + CASE_NO.Trim() + "' AND ici.CALL_RECV_DT= TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND ici.CALL_SNO='" + CALL_SNO + "' AND ici.BK_NO='" + txtBKNO1.Text.Trim() + "' AND ici.SET_NO='" + txtSetNo1.Text.Trim() + "' ORDER BY ici.DATETIME", conn);
            consignee_cd = Convert.ToInt32(cmd.ExecuteScalar());

            if (consignee_cd > 0)
            {
                if (consignee_cd != Convert.ToInt32(ddlCondignee.SelectedValue))
                {
                    DisplayAlert("Please Enter other book no. or set no. same is used for consignee " + consignee_cd + " !!!");
                    return;
                }
            }

            if (((File4.PostedFile == null || File4.PostedFile.ContentLength <= 0) && CkBFile4.Checked == false) || ((File5.PostedFile == null || File5.PostedFile.ContentLength <= 0) && CkBFile5.Checked == false)
                || ((File6.PostedFile == null || File6.PostedFile.ContentLength <= 0) && CkBFile6.Checked == false) || ((File7.PostedFile == null || File7.PostedFile.ContentLength <= 0) && CkBFile5.Checked == false) || ((File8.PostedFile == null || File8.PostedFile.ContentLength <= 0) && CkBFile8.Checked == false))
            {
                DisplayAlert("Please select first five (5) Images !!!");

                return;
            }

            ////
            //int dlength = txtSetNo1.Text.Trim().Length;
            //if (dlength == 1)
            //{
            //    txtSetNo1.Text = "00" + txtSetNo1.Text.Trim();
            //}
            //else if (dlength == 2)
            //{
            //    txtSetNo1.Text = "0" + txtSetNo1.Text.Trim();
            //}
            ////




            if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "")
            {
                string bscheck = "";
                conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
                conn.Open();
                cmd = new OracleCommand("Select ISSUE_TO_IECD from T10_IC_BOOKSET where TRIM(BK_NO)=upper('" + txtBKNO1.Text + "') and " + Convert.ToInt32(txtSetNo1.Text) + " between (SET_NO_FR) and (SET_NO_TO) and ISSUE_TO_IECD=" + Session["IE_CD"].ToString(), conn);
                bscheck = Convert.ToString(cmd.ExecuteScalar());
                conn.Close();
                conn.Dispose();
                if (bscheck != "")
                {
                    if ((File4.PostedFile != null && File4.PostedFile.ContentLength > 0) || CkBFile4.Checked)
                    {
                        photo_upload1(txtBKNO1.Text.Trim(), txtSetNo1.Text.Trim(), ddlCondignee.SelectedValue);
                    }

                    if ((File5.PostedFile != null && File5.PostedFile.ContentLength > 0) || CkBFile5.Checked)
                    {
                        photo_upload1(txtBKNO1.Text.Trim(), txtSetNo1.Text.Trim(), ddlCondignee.SelectedValue);
                    }

                    if ((File6.PostedFile != null && File6.PostedFile.ContentLength > 0) || CkBFile6.Checked)
                    {
                        photo_upload1(txtBKNO1.Text.Trim(), txtSetNo1.Text.Trim(), ddlCondignee.SelectedValue);
                    }

                    if ((File7.PostedFile != null && File7.PostedFile.ContentLength > 0) || CkBFile7.Checked)
                    {
                        photo_upload1(txtBKNO1.Text.Trim(), txtSetNo1.Text.Trim(), ddlCondignee.SelectedValue);
                    }

                    if ((File8.PostedFile != null && File8.PostedFile.ContentLength > 0) || CkBFile8.Checked)
                    {
                        photo_upload1(txtBKNO1.Text.Trim(), txtSetNo1.Text.Trim(), ddlCondignee.SelectedValue);
                    }

                    if ((File9.PostedFile != null && File9.PostedFile.ContentLength > 0) || CkBFile9.Checked)
                    {
                        photo_upload1(txtBKNO1.Text.Trim(), txtSetNo1.Text.Trim(), ddlCondignee.SelectedValue);
                    }

                    if ((File10.PostedFile != null && File10.PostedFile.ContentLength > 0) || CkBFile10.Checked)
                    {
                        photo_upload1(txtBKNO1.Text.Trim(), txtSetNo1.Text.Trim(), ddlCondignee.SelectedValue);
                    }

                    if ((File11.PostedFile != null && File11.PostedFile.ContentLength > 0) || CkBFile11.Checked)
                    {
                        photo_upload1(txtBKNO1.Text.Trim(), txtSetNo1.Text.Trim(), ddlCondignee.SelectedValue);
                    }

                    if ((File12.PostedFile != null && File12.PostedFile.ContentLength > 0) || CkBFile12.Checked)
                    {
                        photo_upload1(txtBKNO1.Text.Trim(), txtSetNo1.Text.Trim(), ddlCondignee.SelectedValue);
                    }

                    if ((File13.PostedFile != null && File13.PostedFile.ContentLength > 0) || CkBFile13.Checked)
                    {
                        photo_upload1(txtBKNO1.Text.Trim(), txtSetNo1.Text.Trim(), ddlCondignee.SelectedValue);
                    }
                }
                else if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "" && bscheck == "")
                {
                    DisplayAlert("Book No. and Set No. specified is not issued to You!!!");
                }
            }
            else
            {
                DisplayAlert("Please enter valid book no. and set no. !");

                return;
            }
            //if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "")
            //{
            //    string bscheck = "";
            //    conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            //    conn.Open();
            //    OracleCommand cmd = new OracleCommand("Select ISSUE_TO_IECD from T10_IC_BOOKSET where TRIM(BK_NO)=upper('" + txtBKNO1.Text + "') and " + Convert.ToInt32(txtSetNo1.Text) + " between (SET_NO_FR) and (SET_NO_TO) and ISSUE_TO_IECD=" + Session["IE_CD"].ToString(), conn);
            //    bscheck = Convert.ToString(cmd.ExecuteScalar());
            //    conn.Close();
            //    conn.Dispose();
            //    if (bscheck != "")
            //    {
            //        if (File5.PostedFile != null && File5.PostedFile.ContentLength > 0)
            //        {
            //            photo_upload1(txtBKNO1.Text.Trim(), txtSetNo1.Text.Trim());
            //        }
            //    }
            //    else if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "" && bscheck == "")
            //    {
            //        DisplayAlert("Book No. and Set No. specified is not issued to You!!!");
            //    }
            //}
            //if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "")
            //{
            //    string bscheck = "";
            //    conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            //    conn.Open();
            //    OracleCommand cmd = new OracleCommand("Select ISSUE_TO_IECD from T10_IC_BOOKSET where TRIM(BK_NO)=upper('" + txtBKNO1.Text + "') and " + Convert.ToInt32(txtSetNo1.Text) + " between (SET_NO_FR) and (SET_NO_TO) and ISSUE_TO_IECD=" + Session["IE_CD"].ToString(), conn);
            //    bscheck = Convert.ToString(cmd.ExecuteScalar());
            //    conn.Close();
            //    conn.Dispose();
            //    if (bscheck != "")
            //    {
            //        if (File6.PostedFile != null && File6.PostedFile.ContentLength > 0)
            //        {
            //            photo_upload1(txtBKNO1.Text.Trim(), txtSetNo1.Text.Trim());
            //        }
            //    }
            //    else if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "" && bscheck == "")
            //    {
            //        DisplayAlert("Book No. and Set No. specified is not issued to You!!!");
            //    }
            //}
            //if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "")
            //{
            //    string bscheck = "";
            //    conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            //    conn.Open();
            //    OracleCommand cmd = new OracleCommand("Select ISSUE_TO_IECD from T10_IC_BOOKSET where TRIM(BK_NO)=upper('" + txtBKNO1.Text + "') and " + Convert.ToInt32(txtSetNo1.Text) + " between (SET_NO_FR) and (SET_NO_TO) and ISSUE_TO_IECD=" + Session["IE_CD"].ToString(), conn);
            //    bscheck = Convert.ToString(cmd.ExecuteScalar());
            //    conn.Close();
            //    conn.Dispose();
            //    if (bscheck != "")
            //    {
            //        if (File7.PostedFile != null && File7.PostedFile.ContentLength > 0)
            //        {
            //            photo_upload1(txtBKNO1.Text.Trim(), txtSetNo1.Text.Trim());
            //        }
            //    }
            //    else if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "" && bscheck == "")
            //    {
            //        DisplayAlert("Book No. and Set No. specified is not issued to You!!!");
            //    }
            //}
            //if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "")
            //{
            //    string bscheck = "";
            //    conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            //    conn.Open();
            //    OracleCommand cmd = new OracleCommand("Select ISSUE_TO_IECD from T10_IC_BOOKSET where TRIM(BK_NO)=upper('" + txtBKNO1.Text + "') and " + Convert.ToInt32(txtSetNo1.Text) + " between (SET_NO_FR) and (SET_NO_TO) and ISSUE_TO_IECD=" + Session["IE_CD"].ToString(), conn);
            //    bscheck = Convert.ToString(cmd.ExecuteScalar());
            //    conn.Close();
            //    conn.Dispose();
            //    if (bscheck != "")
            //    {
            //        if (File8.PostedFile != null && File8.PostedFile.ContentLength > 0)
            //        {
            //            photo_upload1(txtBKNO1.Text.Trim(), txtSetNo1.Text.Trim());
            //        }
            //    }
            //    else if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "" && bscheck == "")
            //    {
            //        DisplayAlert("Book No. and Set No. specified is not issued to You!!!");
            //    }
            //}
            //if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "")
            //{
            //    string bscheck = "";
            //    conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            //    conn.Open();
            //    OracleCommand cmd = new OracleCommand("Select ISSUE_TO_IECD from T10_IC_BOOKSET where TRIM(BK_NO)=upper('" + txtBKNO1.Text + "') and " + Convert.ToInt32(txtSetNo1.Text) + " between (SET_NO_FR) and (SET_NO_TO) and ISSUE_TO_IECD=" + Session["IE_CD"].ToString(), conn);
            //    bscheck = Convert.ToString(cmd.ExecuteScalar());
            //    conn.Close();
            //    conn.Dispose();
            //    if (bscheck != "")
            //    {
            //        if (File9.PostedFile != null && File9.PostedFile.ContentLength > 0)
            //        {
            //            photo_upload1(txtBKNO1.Text.Trim(), txtSetNo1.Text.Trim());
            //        }
            //    }
            //    else if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "" && bscheck == "")
            //    {
            //        DisplayAlert("Book No. and Set No. specified is not issued to You!!!");
            //    }
            //}
            //if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "")
            //{
            //    string bscheck = "";
            //    conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            //    conn.Open();
            //    OracleCommand cmd = new OracleCommand("Select ISSUE_TO_IECD from T10_IC_BOOKSET where TRIM(BK_NO)=upper('" + txtBKNO1.Text + "') and " + Convert.ToInt32(txtSetNo1.Text) + " between (SET_NO_FR) and (SET_NO_TO) and ISSUE_TO_IECD=" + Session["IE_CD"].ToString(), conn);
            //    bscheck = Convert.ToString(cmd.ExecuteScalar());
            //    conn.Close();
            //    conn.Dispose();
            //    if (bscheck != "")
            //    {
            //        if (File10.PostedFile != null && File10.PostedFile.ContentLength > 0)
            //        {
            //            photo_upload1(txtBKNO1.Text.Trim(), txtSetNo1.Text.Trim());
            //        }
            //    }
            //    else if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "" && bscheck == "")
            //    {
            //        DisplayAlert("Book No. and Set No. specified is not issued to You!!!");
            //    }
            //}
            //if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "")
            //{
            //    string bscheck = "";
            //    conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            //    conn.Open();
            //    OracleCommand cmd = new OracleCommand("Select ISSUE_TO_IECD from T10_IC_BOOKSET where TRIM(BK_NO)=upper('" + txtBKNO1.Text + "') and " + Convert.ToInt32(txtSetNo1.Text) + " between (SET_NO_FR) and (SET_NO_TO) and ISSUE_TO_IECD=" + Session["IE_CD"].ToString(), conn);
            //    bscheck = Convert.ToString(cmd.ExecuteScalar());
            //    conn.Close();
            //    conn.Dispose();
            //    if (bscheck != "")
            //    {
            //        if (File11.PostedFile != null && File11.PostedFile.ContentLength > 0)
            //        {
            //            photo_upload1(txtBKNO1.Text.Trim(), txtSetNo1.Text.Trim());
            //        }
            //    }
            //    else if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "" && bscheck == "")
            //    {
            //        DisplayAlert("Book No. and Set No. specified is not issued to You!!!");
            //    }
            //}
            //if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "")
            //{
            //    string bscheck = "";
            //    conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            //    conn.Open();
            //    OracleCommand cmd = new OracleCommand("Select ISSUE_TO_IECD from T10_IC_BOOKSET where TRIM(BK_NO)=upper('" + txtBKNO1.Text + "') and " + Convert.ToInt32(txtSetNo1.Text) + " between (SET_NO_FR) and (SET_NO_TO) and ISSUE_TO_IECD=" + Session["IE_CD"].ToString(), conn);
            //    bscheck = Convert.ToString(cmd.ExecuteScalar());
            //    conn.Close();
            //    conn.Dispose();
            //    if (bscheck != "")
            //    {
            //        if (File12.PostedFile != null && File12.PostedFile.ContentLength > 0)
            //        {
            //            photo_upload1(txtBKNO1.Text.Trim(), txtSetNo1.Text.Trim());
            //        }
            //    }
            //    else if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "" && bscheck == "")
            //    {
            //        DisplayAlert("Book No. and Set No. specified is not issued to You!!!");
            //    }
            //}
            //if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "")
            //{
            //    string bscheck = "";
            //    conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            //    conn.Open();
            //    OracleCommand cmd = new OracleCommand("Select ISSUE_TO_IECD from T10_IC_BOOKSET where TRIM(BK_NO)=upper('" + txtBKNO1.Text + "') and " + Convert.ToInt32(txtSetNo1.Text) + " between (SET_NO_FR) and (SET_NO_TO) and ISSUE_TO_IECD=" + Session["IE_CD"].ToString(), conn);
            //    bscheck = Convert.ToString(cmd.ExecuteScalar());
            //    conn.Close();
            //    conn.Dispose();
            //    if (bscheck != "")
            //    {
            //        if (File13.PostedFile != null && File13.PostedFile.ContentLength > 0)
            //        {
            //            photo_upload1(txtBKNO1.Text.Trim(), txtSetNo1.Text.Trim());
            //        }
            //    }
            //    else if (txtBKNO1.Text.Trim() != "" && txtSetNo1.Text.Trim() != "" && bscheck == "")
            //    {
            //        DisplayAlert("Book No. and Set No. specified is not issued to You!!!");
            //    }
            //}
            DisplayAlert("Upload done Successfully!!!");
        }


        private void DdlCondignee_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBKNO1.Text = "";
            txtSetNo1.Text = "";
            FillFileNames(false);

            string fpathIC = Server.MapPath("/RBS/BILL_IC/" + lblCSNO.Text.Trim() + "-" + txtBKNO1.Text.Trim() + "-" + txtSetNo1.Text.Trim() + ".PDF");
            string fpathTestPlan = Server.MapPath("/RBS/TESTPLAN/" + lblCSNO.Text.Trim() + "-" + txtBKNO1.Text.Trim() + "-" + txtSetNo1.Text.Trim() + ".PDF");
            string fpathANN1 = Server.MapPath("/RBS/BILL_IC/" + lblCSNO.Text.Trim() + "-" + txtBKNO1.Text.Trim() + "-" + txtSetNo1.Text.Trim() + "-A1.PDF");
            string fpathANN2 = Server.MapPath("/RBS/BILL_IC/" + lblCSNO.Text.Trim() + "-" + txtBKNO1.Text.Trim() + "-" + txtSetNo1.Text.Trim() + "-A2.PDF");

            if (File.Exists(fpathIC) == true)
            {
                HyperLinkIC.NavigateUrl = "/RBS/BILL_IC/" + lblCSNO.Text.Trim() + "-" + txtBKNO1.Text.Trim() + "-" + txtSetNo1.Text.Trim() + ".PDF";
                HyperLinkIC.Visible = true;
            }
            if (File.Exists(fpathTestPlan) == true)
            {
                HyperLinkTestplan.NavigateUrl = "/RBS/TESTPLAN/" + lblCSNO.Text.Trim() + "-" + txtBKNO1.Text.Trim() + "-" + txtSetNo1.Text.Trim() + ".PDF";
                HyperLinkTestplan.Visible = true;
            }
            if (File.Exists(fpathANN1) == true)
            {
                HyperLinkANN1.NavigateUrl = "/RBS/BILL_IC/" + lblCSNO.Text.Trim() + "-" + txtBKNO1.Text.Trim() + "-" + txtSetNo1.Text.Trim() + "-A1.PDF";
                HyperLinkANN1.Visible = true;
            }
            if (File.Exists(fpathANN2) == true)
            {
                HyperLinkANN2.NavigateUrl = "/RBS/BILL_IC/" + lblCSNO.Text.Trim() + "-" + txtBKNO1.Text.Trim() + "-" + txtSetNo1.Text.Trim() + "-A2.PDF";
                HyperLinkANN2.Visible = true;
            }
        }
        private void btnCancelFiles_Click(object sender, System.EventArgs e)
        {

            ddlCondignee.SelectedValue = "0";
            txtBKNO1.Text = "";
            txtSetNo1.Text = "";
            FillFileNames(false);
            //Call_Cancellation_Entry();


        }

        private void lstCallStatus_SelectedIndexChanged()
        {
            //Label32.Visible = false;
            //txtRemarks.Visible = false;
            //Label4.Visible = false;
            //Label5.Visible = true;
            //txtHologram.Visible = true;
            //Label6.Visible = true;
            Label9.Visible = true;
            File1.Visible = true;
            File2.Visible = true;
            File3.Visible = true;
            Label7.Visible = true;
            Label10.Visible = true;
            Label12.Visible = true;
            File14.Visible = true;
            btnViewIC.Enabled = false;
        }
        private void AcceptedFun()
        {
            string str = "";
            string sql = "Select Distinct T051.VEND_NAME,(T06.CONSIGNEE_DESIG||' '||T06.CONSIGNEE_FIRM) CONSIGNEE," +
                       "T18.ITEM_DESC_PO,to_char(T17.CALL_MARK_DT,'dd/mm/yyyy') CALL_MARK_DT,to_char(T17.CALL_RECV_DT,'dd/mm/yyyy') CALL_RECV_DT,to_char(DT_INSP_DESIRE,'dd/mm/yyyy')DESIRE_DT," +
                       "T09.IE_NAME,T09.IE_PHONE_NO,T13.PO_NO,to_char(T13.PO_DT,'dd/mm/yyyy')PO_DATE,T17.CASE_NO,to_char(T17.CALL_LETTER_DT,'dd/mm/yyyy') CALL_LETTER_DT," +
                       "T17.CALL_LETTER_NO,T17.CALL_STATUS,to_char(T17.CALL_STATUS_DT,'dd/mm/yyyy') CALL_STATUS_DT,T17.CALL_CANCEL_STATUS,T17.CALL_CANCEL_CHARGES,T17.BK_NO,T17.SET_NO,T17.REMARKS,T17.HOLOGRAM, T052.VEND_CONTACT_PER_1 MFG_PERS,T052.VEND_CONTACT_TEL_1 MFG_PHONE,T17.CALL_SNO," +
                       "(select count(*) from T18_CALL_DETAILS A WHERE A.CASE_NO=T18.CASE_NO AND A.CALL_RECV_DT=T18.CALL_RECV_DT) COUNT " +
                       "From T05_VENDOR T051,T06_CONSIGNEE T06,T17_CALL_REGISTER T17,T18_CALL_DETAILS T18,T13_PO_MASTER T13,T09_IE T09,T05_VENDOR T052 " +
                       "Where  T051.VEND_CD=T13.VEND_CD and  T06.CONSIGNEE_CD(+)=T13.PURCHASER_CD and  T13.CASE_NO=T17.CASE_NO  and " +
                       "T09.IE_CD =T17.IE_CD  and  T18.CASE_NO=T17.CASE_NO and T18.CALL_RECV_DT=T17.CALL_RECV_DT AND T18.CALL_SNO=T17.CALL_SNO and T17.MFG_CD=T052.VEND_CD(+) and " +
                       "(T17.CASE_NO='" + CASE_NO + "' and T17.CALL_RECV_DT=to_date('" + CALL_RECV_DT + "','dd/mm/yyyy') and T17.CALL_SNO='" + CALL_SNO + "') and " +
                       "T18.ITEM_SRNO_PO=(Select min(B.ITEM_SRNO_PO) from T18_CALL_DETAILS B where B.CASE_NO=T18.CASE_NO AND B.CALL_RECV_DT=T18.CALL_RECV_DT AND B.CALL_SNO=T18.CALL_SNO) " +
                       "Order by T051.VEND_NAME,CALL_MARK_DT";

            try
            {
                conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                OracleDataReader readerB = cmd.ExecuteReader();

                btnSaveFiles.Enabled = true;
                //txtSTDT.Enabled = true;
                txtBKNO1.Enabled = true;
                txtSetNo1.Enabled = true;
                btnSave.Enabled = true;
                btnUploadFiles.Enabled = true;
                btnRefreshAll.Enabled = true;
                //Panel_1.Visible = true;
                //HyperLink1.Visible = true;
                //Label3.Visible = true;
                //txtHologram.Enabled = true;
                Label9.Visible = true;
                File1.Visible = true;
                File2.Visible = true;
                File3.Visible = true;
                Label7.Visible = true;
                Label10.Visible = true;
                Label12.Visible = true;
                File14.Visible = true;
                //txtRemarks.Visible = true;
                //Label32.Visible = true;
                //Label4.Visible = true;



                while (readerB.Read())
                {
                    lblVend.Text = Convert.ToString(readerB["VEND_NAME"]);
                    lblPurc.Text = Convert.ToString(readerB["CONSIGNEE"]);
                    lblItem.Text = Convert.ToString(readerB["ITEM_DESC_PO"]);
                    lblCallDT.Text = Convert.ToString(readerB["CALL_RECV_DT"]);
                    lblInpDesireDT.Text = Convert.ToString(readerB["DESIRE_DT"]);
                    lblIEName1.Text = Convert.ToString(readerB["IE_NAME"]);
                    //						lblIEName.Text=Convert.ToString(readerB["IE_NAME"]);
                    lblIECON.Text = Convert.ToString(readerB["IE_PHONE_NO"]);
                    lblPONO.Text = Convert.ToString(readerB["PO_NO"]);
                    lblPODT.Text = Convert.ToString(readerB["PO_DATE"]);
                    lblCSNO.Text = Convert.ToString(readerB["CASE_NO"]);
                    lblCONPER.Text = Convert.ToString(readerB["MFG_PERS"]);
                    lblCONPERTEL.Text = Convert.ToString(readerB["MFG_PHONE"]);
                    lblSNO.Text = Convert.ToString(readerB["CALL_SNO"]);
                    //lstCallStatus.SelectedValue = Convert.ToString(readerB["CALL_STATUS"]);
                    //lblCallStatus.Text = Convert.ToString(readerB["CALL_STATUS"]);

                    //if (lstCallStatus.SelectedValue == "M" || lstCallStatus.SelectedValue == "U" || lstCallStatus.SelectedValue == "S")
                    //{
                    //    txtRemarks.Text = "";
                    //    lblRemarks.Text = Convert.ToString(readerB["REMARKS"]);
                    //}
                    //else
                    {
                        //txtRemarks.Text = Convert.ToString(readerB["REMARKS"]);
                        //txtHologram.Text = Convert.ToString(readerB["HOLOGRAM"]);
                    }
                    //if (Convert.ToString(readerB["CALL_STATUS"]) == "C")
                    //{
                    //    lstCallCancelStatus.SelectedValue = Convert.ToString(readerB["CALL_CANCEL_STATUS"]);
                    //    lstCallCancelCharges.SelectedValue = Convert.ToString(readerB["CALL_CANCEL_CHARGES"]);
                    //    Panel_1.Visible = true;
                    //    HyperLink1.Visible = false;
                    //    Label3.Visible = false;
                    //    txtRemarks.Visible = false;
                    //    Label32.Visible = false;
                    //    Label4.Visible = false;
                    //    Label5.Visible = false;
                    //    txtHologram.Visible = false;
                    //    Label6.Visible = false;
                    //    Label9.Visible = false;
                    //    File1.Visible = false;
                    //    File2.Visible = false;
                    //    File3.Visible = false;
                    //    Label7.Visible = false;
                    //    Label10.Visible = false;
                    //    btnSaveCancellation.Enabled = false;

                    //}
                    //else if (Convert.ToString(readerB["CALL_STATUS"]) == "A" || Convert.ToString(readerB["CALL_STATUS"]) == "R" || Convert.ToString(readerB["CALL_STATUS"]) == "B" || Convert.ToString(readerB["CALL_STATUS"]) == "T" || Convert.ToString(readerB["CALL_STATUS"]) == "G")
                    if (Convert.ToString(readerB["CALL_STATUS"]) == "A" || Convert.ToString(readerB["CALL_STATUS"]) == "R")
                    {

                        //
                        conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);

                        DataSet ds = new DataSet();
                        str = "SELECT * FROM IC_INTERMEDIATE WHERE CASE_NO = '" + lblCSNO.Text.Trim() + "' AND CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND CALL_SNO = '" + CALL_SNO + "' and consignee_cd = '" + Convert.ToString(ddlCondignee.SelectedValue) + "'";

                        OracleDataAdapter da = new OracleDataAdapter(str, conn);
                        OracleCommand myOracleCommand = new OracleCommand(str, conn);
                        conn.Open();
                        da.SelectCommand = myOracleCommand;
                        //conn.Close();
                        da.Fill(ds, "Table");

                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow itemDR in ds.Tables[0].Rows)
                                {
                                    if (Convert.ToString(itemDR["CONSGN_CALL_STATUS"]) == "A" || Convert.ToString(itemDR["CONSGN_CALL_STATUS"]) == "R")
                                    {
                                        //
                                        //txtRemarks.Text = Convert.ToString(readerB["REMARKS"]);
                                        //txtHologram.Text = Convert.ToString(readerB["HOLOGRAM"]);
                                        //



                                        //lstCallStatus.Enabled = false;
                                        btnSaveFiles.Enabled = false;
                                        btnRefreshAll.Enabled = false;
                                        txtSTDT.Enabled = false;
                                        txtBKNO1.Enabled = false;
                                        txtSetNo1.Enabled = false;
                                        btnSave.Enabled = false;
                                        btnUploadFiles.Enabled = false;
                                        // Panel_1.Visible = false;
                                        //HyperLink1.Visible = false;
                                        //Label3.Visible = false;
                                        //txtHologram.Enabled = false;
                                        Label9.Visible = false;
                                        File1.Visible = false;
                                        File2.Visible = false;
                                        File3.Visible = false;
                                        Label7.Visible = false;
                                        Label10.Visible = false;
                                        Label12.Visible = false;
                                        File14.Visible = false;
                                        //txtRemarks.Visible = false;
                                        //Label32.Visible = false;
                                        //Label4.Visible = false;
                                    }
                                }
                            }
                        }
                        //
                        //if (Convert.ToString(readerB["CALL_STATUS"]) == "R")
                        //{
                        //    txtRemarks.Visible = true;
                        //    Label32.Visible = true;
                        //    txtRemarks.Enabled = false;

                        //}
                        btnViewIC.Visible = true;
                    }
                    else
                    {
                        btnSaveFiles.Enabled = true;
                        //txtSTDT.Enabled = true;
                        txtBKNO1.Enabled = true;
                        txtSetNo1.Enabled = true;
                        btnSave.Enabled = true;
                        btnUploadFiles.Enabled = true;
                        btnRefreshAll.Enabled = true;
                        //Panel_1.Visible = true;
                        //HyperLink1.Visible = true;
                        //Label3.Visible = true;
                        //txtHologram.Enabled = true;
                        Label9.Visible = true;
                        File1.Visible = true;
                        File2.Visible = true;
                        File3.Visible = true;
                        Label7.Visible = true;
                        Label10.Visible = true;
                        Label12.Visible = true;
                        File14.Visible = true;
                        //txtRemarks.Visible = true;
                        //Label32.Visible = true;
                        //Label4.Visible = true;
                        //Panel_1.Visible = false;
                        //txtRemarks.Visible = false;
                        //Label32.Visible = false;
                        //Label4.Visible = false;
                        //Label4.Visible = false;
                        //Label5.Visible = false;
                        //txtHologram.Visible = false;
                        //Label6.Visible = false;
                        //Label9.Visible = false;
                        //File1.Visible = false;
                        //File2.Visible = false;
                        //File3.Visible = false;
                        //Label7.Visible = false;
                        //Label10.Visible = false;
                    }
                    //Panel_1.Visible = false;
                    lblCLettDT.Text = Convert.ToString(readerB["CALL_LETTER_DT"]);
                    lblCLettNo.Text = Convert.ToString(readerB["CALL_LETTER_NO"]);
                    txtSTDT.Text = Convert.ToString(readerB["CALL_STATUS_DT"]);
                    //txtBKNO1.Text = Convert.ToString(readerB["BK_NO"]);
                    //txtSetNo1.Text = Convert.ToString(readerB["SET_NO"]);
                    //						if(Convert.ToString(readerB["CALL_STATUS"])=="C" || Convert.ToString(readerB["CALL_STATUS"])=="R"||Convert.ToString(readerB["CALL_STATUS"])=="A")
                    //						{
                    //							lstCallStatus.SelectedValue=Convert.ToString(readerB["CALL_STATUS"]);
                    //							lstCallStatus.Enabled=false;
                    //						}
                    //						else
                    //						{
                    //							lstCallStatus.SelectedValue=Convert.ToString(readerB["CALL_STATUS"]);
                    //							lstCallStatus.Enabled=true;
                    //						}
                }
                OracleCommand cmd2 = new OracleCommand("Select to_char(sysdate,'dd/mm/yyyy') from dual", conn);
                txtSTDT.Text = Convert.ToString(cmd2.ExecuteScalar());
                conn.Close();
                //if (lstCallStatus.SelectedValue == "C")
                //{
                //    Panel_1.Visible = true;
                //    show();
                //}
            }
            catch (Exception ex)
            {
                //					string str; 
                str = ex.Message;
                string str1 = str.Replace("\n", "");
                Response.Redirect("Error_Form.aspx?err=" + str1);
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        private void btnUploadFiles_Click(object sender, System.EventArgs e)
        {
            OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            OracleCommand cmd1 = new OracleCommand("SELECT NVL(COUNT(*),0) FROM T49_IC_PHOTO_ENCLOSED T49 WHERE T49.CASE_NO = '" + lblCSNO.Text.Trim() + "' AND T49.CALL_RECV_DT = TO_date('" + CALL_RECV_DT + "', 'dd/mm/yyyy') AND T49.CALL_SNO = '" + CALL_SNO + "' and BK_NO='" + txtBKNO1.Text.Trim() + "' and SET_NO='" + txtSetNo1.Text.Trim() + "'", conn);
            conn.Open();
            int no_of_photo = Convert.ToInt32(cmd1.ExecuteScalar());
            conn.Close();

            if (ddlCondignee.SelectedValue != "0" && no_of_photo > 0)
            {
                photo_upload(txtBKNO1.Text.Trim(), txtSetNo1.Text.Trim());

                string fpathIC = Server.MapPath("/RBS/BILL_IC/" + lblCSNO.Text.Trim() + "-" + txtBKNO1.Text.Trim() + "-" + txtSetNo1.Text.Trim() + ".PDF");
                string fpathTestPlan = Server.MapPath("/RBS/TESTPLAN/" + lblCSNO.Text.Trim() + "-" + txtBKNO1.Text.Trim() + "-" + txtSetNo1.Text.Trim() + ".PDF");
                string fpathANN1 = Server.MapPath("/RBS/BILL_IC/" + lblCSNO.Text.Trim() + "-" + txtBKNO1.Text.Trim() + "-" + txtSetNo1.Text.Trim() + "-A1.PDF");
                string fpathANN2 = Server.MapPath("/RBS/BILL_IC/" + lblCSNO.Text.Trim() + "-" + txtBKNO1.Text.Trim() + "-" + txtSetNo1.Text.Trim() + "-A2.PDF");

                if (File.Exists(fpathIC) == true)
                {
                    HyperLinkIC.NavigateUrl = "/RBS/BILL_IC/" + lblCSNO.Text.Trim() + "-" + txtBKNO1.Text.Trim() + "-" + txtSetNo1.Text.Trim() + ".PDF";
                    HyperLinkIC.Visible = true;
                }
                if (File.Exists(fpathTestPlan) == true)
                {
                    HyperLinkTestplan.NavigateUrl = "/RBS/TESTPLAN/" + lblCSNO.Text.Trim() + "-" + txtBKNO1.Text.Trim() + "-" + txtSetNo1.Text.Trim() + ".PDF";
                    HyperLinkTestplan.Visible = true;
                }
                if (File.Exists(fpathANN1) == true)
                {
                    HyperLinkANN1.NavigateUrl = "/RBS/BILL_IC/" + lblCSNO.Text.Trim() + "-" + txtBKNO1.Text.Trim() + "-" + txtSetNo1.Text.Trim() + "-A1.PDF";
                    HyperLinkANN1.Visible = true;
                }
                if (File.Exists(fpathANN2) == true)
                {
                    HyperLinkANN2.NavigateUrl = "/RBS/BILL_IC/" + lblCSNO.Text.Trim() + "-" + txtBKNO1.Text.Trim() + "-" + txtSetNo1.Text.Trim() + "-A2.PDF";
                    HyperLinkANN2.Visible = true;
                }
            }
            else if (ddlCondignee.SelectedValue == "0")
            {
                DisplayAlert("Select Consignee from the List and then Click on Upload Button!!!");

            }
            else if (no_of_photo == 0)
            {
                DisplayAlert("The Inspection Photos should be uploaded first against the given Case and then Upload the Files");
            }

        }

        private void lstRejectionType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            rejection_charges();
        }
    }
}
