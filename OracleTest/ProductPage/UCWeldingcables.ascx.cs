using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.ProductPage
{
    public partial class UCWeldingcables : System.Web.UI.UserControl
    {       
        OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        static string wIECD, wIENAME;
        static string wDtFr;
        static string wDtTo;
        private string wColour;
     
        string wVendor;
        protected System.Web.UI.WebControls.Panel pnlV;
        protected System.Web.UI.WebControls.Literal litHeadDimension2;
        protected System.Web.UI.WebControls.TextBox txtManualEntry2;
        protected System.Web.UI.WebControls.TextBox txtNoOfPices2;
        protected System.Web.UI.WebControls.TextBox txtRanges2;
        protected System.Web.UI.WebControls.Repeater Rept10;
        protected System.Web.UI.WebControls.Repeater Rept11;
        protected System.Web.UI.WebControls.Repeater Rept12;
        protected System.Web.UI.WebControls.Repeater Rept13;
        protected System.Web.UI.WebControls.Repeater Rept14;
        protected System.Web.UI.WebControls.Repeater Rept15;
        protected System.Web.UI.WebControls.TextBox txt11;
        protected System.Web.UI.WebControls.TextBox txt12;
        protected System.Web.UI.WebControls.TextBox txt13;
        protected System.Web.UI.WebControls.TextBox txt14;
        protected System.Web.UI.WebControls.TextBox txt15;
        //protected System.Web.UI.WebControls.CheckBox chkDoc1;
        //protected System.Web.UI.WebControls.CheckBox chkDoc2;
        //protected System.Web.UI.WebControls.CheckBox chkDoc3;
        //protected System.Web.UI.WebControls.CheckBox chkDoc4;
        //protected System.Web.UI.WebControls.CheckBox chkDoc5;
        protected System.Web.UI.WebControls.CheckBox chkDoc6;
        protected System.Web.UI.WebControls.CheckBox chkDoc7;
        protected System.Web.UI.WebControls.CheckBox chkDoc8;
        protected System.Web.UI.WebControls.CheckBox chkDoc9;
        protected System.Web.UI.WebControls.CheckBox chkDoc10;
        protected System.Web.UI.WebControls.CheckBox chkDoc11;
        protected System.Web.UI.WebControls.CheckBox chkDoc12;
        protected System.Web.UI.WebControls.CheckBox chkDoc13;

        //protected System.Web.UI.WebControls.RadioButton rdoPassA;
        //protected System.Web.UI.WebControls.RadioButton rdoPassB;
        //protected System.Web.UI.WebControls.RadioButton rdoPassC;
        //protected System.Web.UI.WebControls.RadioButton rdoPassD;
        //protected System.Web.UI.WebControls.RadioButton rdoPassE;
        //protected System.Web.UI.WebControls.RadioButton rdoPassF;
        //protected System.Web.UI.WebControls.RadioButton rdoPassG;
        //protected System.Web.UI.WebControls.RadioButton rdoPassH;
        //protected System.Web.UI.WebControls.RadioButton rdoPassI;
        //protected System.Web.UI.WebControls.RadioButton rdoPassJ;
        protected System.Web.UI.WebControls.RadioButton rdoPassK;
        protected System.Web.UI.WebControls.RadioButton rdoPassL;
        protected System.Web.UI.WebControls.RadioButton rdoPassM;
        protected System.Web.UI.WebControls.RadioButton rdoPassN;
        protected System.Web.UI.WebControls.RadioButton rdoPassO;
        protected System.Web.UI.WebControls.RadioButton rdoPassP;
        protected System.Web.UI.WebControls.RadioButton rdoPassQ;
        protected System.Web.UI.WebControls.RadioButton rdoPassR;
        protected System.Web.UI.WebControls.RadioButton rdoPassS;
        protected System.Web.UI.WebControls.RadioButton rdoPassT;
        protected System.Web.UI.WebControls.RadioButton rdoPassU;
        protected System.Web.UI.WebControls.RadioButton rdoPassV;

        //protected System.Web.UI.WebControls.RadioButton rdoFailA;
        //protected System.Web.UI.WebControls.RadioButton rdoFailB;
        //protected System.Web.UI.WebControls.RadioButton rdoFailC;
        //protected System.Web.UI.WebControls.RadioButton rdoFailD;
        //protected System.Web.UI.WebControls.RadioButton rdoFailE;
        //protected System.Web.UI.WebControls.RadioButton rdoFailF;
        //protected System.Web.UI.WebControls.RadioButton rdoFailG;
        //protected System.Web.UI.WebControls.RadioButton rdoFailH;
        //protected System.Web.UI.WebControls.RadioButton rdoFailI;
        //protected System.Web.UI.WebControls.RadioButton rdoFailJ;
        protected System.Web.UI.WebControls.RadioButton rdoFailK;
        protected System.Web.UI.WebControls.RadioButton rdoFailL;
        protected System.Web.UI.WebControls.RadioButton rdoFailM;
        protected System.Web.UI.WebControls.RadioButton rdoFailN;
        protected System.Web.UI.WebControls.RadioButton rdoFailO;
        protected System.Web.UI.WebControls.RadioButton rdoFailP;
        protected System.Web.UI.WebControls.RadioButton rdoFailQ;
        protected System.Web.UI.WebControls.RadioButton rdoFailR;
        protected System.Web.UI.WebControls.RadioButton rdoFailS;
        protected System.Web.UI.WebControls.RadioButton rdoFailT;
        protected System.Web.UI.WebControls.RadioButton rdoFailU;
        protected System.Web.UI.WebControls.RadioButton rdoFailV;

        //protected System.Web.UI.WebControls.TextBox txtObservA;
        //protected System.Web.UI.WebControls.TextBox txtObservB;
        //protected System.Web.UI.WebControls.TextBox txtObservC;
        //protected System.Web.UI.WebControls.TextBox txtObservD;
        //protected System.Web.UI.WebControls.TextBox txtObservE;
        //protected System.Web.UI.WebControls.TextBox txtObservF;
        //protected System.Web.UI.WebControls.TextBox txtObservG;
        //protected System.Web.UI.WebControls.TextBox txtObservH;
        //protected System.Web.UI.WebControls.TextBox txtObservI;
        //protected System.Web.UI.WebControls.TextBox txtObservJ;
        protected System.Web.UI.WebControls.TextBox txtObservK;
        protected System.Web.UI.WebControls.TextBox txtObservL;
        protected System.Web.UI.WebControls.TextBox txtObservM;
        protected System.Web.UI.WebControls.TextBox txtObservN;
        protected System.Web.UI.WebControls.TextBox txtObservO;
        protected System.Web.UI.WebControls.TextBox txtObservP;
        protected System.Web.UI.WebControls.TextBox txtObservQ;
        protected System.Web.UI.WebControls.TextBox txtObservR;
        protected System.Web.UI.WebControls.TextBox txtObservS;
        protected System.Web.UI.WebControls.TextBox txtObservT;
        protected System.Web.UI.WebControls.TextBox txtObservU;
        protected System.Web.UI.WebControls.TextBox txtObservV;
        //protected System.Web.UI.WebControls.TextBox txtDatasheetRemarks1;
        protected System.Web.UI.WebControls.TextBox txtDatasheetRemarks2;
        protected System.Web.UI.WebControls.TextBox txtDatasheetRemarks3;
        protected System.Web.UI.WebControls.TextBox txtDatasheetRemarks4;
        protected System.Web.UI.WebControls.TextBox txtDatasheetRemarks5;
        //protected System.Web.UI.WebControls.Repeater repaterTstChecks;
        protected System.Web.UI.WebControls.Repeater repeaterDimension;
        //protected System.Web.UI.WebControls.Repeater rpt0;
        //protected System.Web.UI.WebControls.Repeater rpt1;
        //protected System.Web.UI.WebControls.Repeater rpt2;
        //protected System.Web.UI.WebControls.Repeater rpt3;
        //protected System.Web.UI.WebControls.Repeater rpt4;
        //protected System.Web.UI.WebControls.Repeater rpt5;
        //protected System.Web.UI.WebControls.Repeater rpt6;

        protected System.Web.UI.WebControls.Repeater repeaterChemicalTest;        

        protected System.Web.UI.WebControls.Repeater repeaterChemicalTest3;
        protected System.Web.UI.WebControls.Literal litHeadDimension3;
        protected System.Web.UI.WebControls.TextBox txtManualEntry3;
        protected System.Web.UI.WebControls.TextBox txtNoOfPices3;
        protected System.Web.UI.WebControls.TextBox txtRanges3;
        protected System.Web.UI.WebControls.Repeater Rept30;
        protected System.Web.UI.WebControls.Repeater Rept31;
        protected System.Web.UI.WebControls.Repeater Rept32;
        protected System.Web.UI.WebControls.Repeater Rept33;
        protected System.Web.UI.WebControls.Repeater Rept34;
        protected System.Web.UI.WebControls.Repeater Rept35;
        protected System.Web.UI.WebControls.Repeater Rept36;
        protected System.Web.UI.WebControls.Repeater Rept37;
        protected System.Web.UI.WebControls.TextBox txt31;
        protected System.Web.UI.WebControls.TextBox txt32;
        protected System.Web.UI.WebControls.TextBox txt33;
        protected System.Web.UI.WebControls.TextBox txt34;
        protected System.Web.UI.WebControls.TextBox txt35;
        protected System.Web.UI.WebControls.TextBox txt36;
        protected System.Web.UI.WebControls.TextBox txt37;


        protected System.Web.UI.WebControls.Repeater repeaterChemicalTest4;
        protected System.Web.UI.WebControls.Literal litHeadDimension4;
        protected System.Web.UI.WebControls.TextBox txtManualEntry4;
        protected System.Web.UI.WebControls.TextBox txtNoOfPices4;
        protected System.Web.UI.WebControls.TextBox txtRanges4;
        protected System.Web.UI.WebControls.Repeater Rept40;
        protected System.Web.UI.WebControls.Repeater Rept41;
        protected System.Web.UI.WebControls.Repeater Rept42;
        protected System.Web.UI.WebControls.Repeater Rept43;
        protected System.Web.UI.WebControls.Repeater Rept44;
        protected System.Web.UI.WebControls.Repeater Rept45;
        protected System.Web.UI.WebControls.Repeater Rept46;
        protected System.Web.UI.WebControls.Repeater Rept47;
        protected System.Web.UI.WebControls.TextBox txt41;
        protected System.Web.UI.WebControls.TextBox txt42;
        protected System.Web.UI.WebControls.TextBox txt43;
        protected System.Web.UI.WebControls.TextBox txt44;
        protected System.Web.UI.WebControls.TextBox txt45;
        protected System.Web.UI.WebControls.TextBox txt46;
        protected System.Web.UI.WebControls.TextBox txt47;


        protected System.Web.UI.WebControls.Repeater repeaterChemicalTest5;
        protected System.Web.UI.WebControls.Literal litHeadDimension5;
        protected System.Web.UI.WebControls.TextBox txtManualEntry5;
        protected System.Web.UI.WebControls.TextBox txtNoOfPices5;
        protected System.Web.UI.WebControls.TextBox txtRanges5;
        protected System.Web.UI.WebControls.Repeater Rept50;
        protected System.Web.UI.WebControls.Repeater Rept51;
        protected System.Web.UI.WebControls.Repeater Rept52;
        protected System.Web.UI.WebControls.Repeater Rept53;
        protected System.Web.UI.WebControls.Repeater Rept54;
        protected System.Web.UI.WebControls.Repeater Rept55;
        protected System.Web.UI.WebControls.Repeater Rept56;
        protected System.Web.UI.WebControls.Repeater Rept57;
        protected System.Web.UI.WebControls.TextBox txt51;
        protected System.Web.UI.WebControls.TextBox txt52;
        protected System.Web.UI.WebControls.TextBox txt53;
        protected System.Web.UI.WebControls.TextBox txt54;
        protected System.Web.UI.WebControls.TextBox txt55;
        protected System.Web.UI.WebControls.TextBox txt56;
        protected System.Web.UI.WebControls.TextBox txt57;

        //protected System.Web.UI.WebControls.HyperLink hypgotomainPage;
        //protected System.Web.UI.WebControls.HyperLink hypDownloadReport;
        //protected System.Web.UI.WebControls.Literal litFileUpdate;
        //protected System.Web.UI.WebControls.Literal litFileUpdate2;
        //protected System.Web.UI.WebControls.Literal litFileUpdate3;
        //protected System.Web.UI.WebControls.Literal litFileUpdate4;
        //protected System.Web.UI.WebControls.Literal litFileUpdate5;
        protected System.Web.UI.WebControls.Repeater repeaterChemical;
        protected System.Web.UI.WebControls.Repeater repeaterMachanical;
        //protected System.Web.UI.WebControls.TextBox txtFinalStatement;
        //protected System.Web.UI.WebControls.ImageButton fileDelete;
        //protected System.Web.UI.WebControls.ImageButton fileDelete2;
        //protected System.Web.UI.WebControls.ImageButton fileDelete3;
        //protected System.Web.UI.WebControls.ImageButton fileDelete4;
        //protected System.Web.UI.WebControls.ImageButton fileDelete5;
        //protected System.Web.UI.WebControls.RadioButton rdoFinalStatementPass;
        //protected System.Web.UI.WebControls.RadioButton rdoFinalStatementFail;

        //protected System.Web.UI.HtmlControls.HtmlInputFile File1;
        //protected System.Web.UI.HtmlControls.HtmlInputFile File2;
        //protected System.Web.UI.HtmlControls.HtmlInputFile File3;
        //protected System.Web.UI.HtmlControls.HtmlInputFile File4;
        //protected System.Web.UI.HtmlControls.HtmlInputFile File5;
        protected System.Web.UI.HtmlControls.HtmlInputFile File6;
        protected System.Web.UI.HtmlControls.HtmlInputFile File7;
        protected System.Web.UI.HtmlControls.HtmlInputFile File8;
        protected System.Web.UI.HtmlControls.HtmlInputFile File9;
        protected System.Web.UI.HtmlControls.HtmlInputFile File10;
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!(IsPostBack))
            {
                string CASE_NO, CALL_RECV_DT, CALL_SNO;
                CASE_NO = Request.Params["CASE_NO"].ToString();
                CALL_RECV_DT = Request.Params["CALL_RECV_DT"].ToString();
                CALL_SNO = Request.Params["CALL_SNO"].ToString();

                string str = "";
                txtCaseNo.Text = Convert.ToString(Request.Params["CASE_NO"]);
                string sql = "Select  to_char(T47.VISIT_DT, 'DD/MM/YYYY')VISIT_DT, T13.po_no || '  &  ' || to_char(T13.po_dt, 'dd/mm/yyyy') PO_NO, T17.CASE_NO,T47.mfg_place, T18.CUM_QTY_PREV_PASSED, T18.QTY_TO_INSP, (select count(*) " +
                               " from T18_CALL_DETAILS A WHERE A.CASE_NO=T18.CASE_NO AND A.CALL_RECV_DT=T18.CALL_RECV_DT) COUNT, T062.PL_NO,T15.item_cd, T09.IE_CD  From   T05_VENDOR T051 " +
                               " inner join T13_PO_MASTER T13 on T051.VEND_CD=T13.VEND_CD inner join T15_PO_DETAIL T15 on T13.case_No=T15.Case_No left outer join T06_CONSIGNEE T06 on T06.CONSIGNEE_CD=T13.PURCHASER_CD " +
                               " inner join T17_CALL_REGISTER T17 on T13.CASE_NO=T17.CASE_NO inner join T18_CALL_DETAILS T18 on T18.CASE_NO=T17.CASE_NO and T18.CALL_RECV_DT=T17.CALL_RECV_DT AND T18.CALL_SNO=T17.CALL_SNO " +
                               " inner join T09_IE T09 on T09.IE_CD =T17.IE_CD left outer join T05_VENDOR T052 on T17.MFG_CD=T052.VEND_CD inner join T47_IE_WORK_PLAN T47 on T47.CASE_NO=T18.CASE_NO left Outer join T62_MASTER_ITEM_PLNO T062 on T15.item_cd=t062.item_cd " +
                               " Where  (T17.CASE_NO='" + CASE_NO + "' and T17.CALL_RECV_DT=to_date('" + CALL_RECV_DT + "','dd/mm/yyyy') and T17.CALL_SNO='" + CALL_SNO + "') and T18.ITEM_SRNO_PO= " +
                               " (Select min(B.ITEM_SRNO_PO) from T18_CALL_DETAILS B where B.CASE_NO=T18.CASE_NO AND B.CALL_RECV_DT=T18.CALL_RECV_DT AND B.CALL_SNO= " +
                               " T18.CALL_SNO) and Rownum=1 Order by T051.VEND_NAME,CALL_MARK_DT";
                try
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    OracleDataReader readerB = cmd.ExecuteReader();
                    if (readerB.Read())
                    {
                        TXTPLNO.Text = Convert.ToString(readerB["PL_NO"]);
                        txtDateOfInspection.Text = Convert.ToString(readerB["VISIT_DT"]);
                        txtPlaceofInspection.Text = Convert.ToString(readerB["mfg_place"]);
                        //txtOffered.Text = Convert.ToString(readerB["CUM_QTY_PREV_PASSED"]);
                        txtSizeofLog.Text = Convert.ToString(readerB["QTY_TO_INSP"]);
                        ViewState["Item_Code"] = Convert.ToString(readerB["item_cd"]);
                        txtPoNo.Text = Convert.ToString(readerB["PO_NO"]);
                        ViewState["IE_CD"] = Convert.ToString(readerB["IE_CD"]);
                        hypDownloadReport.NavigateUrl = "~/checksheet/frmInspectTestReport.aspx?CASE_NO=" + CASE_NO + "&CALL_RECV_DT=" + CALL_RECV_DT + "&CALL_SNO=" + CALL_SNO + "&IE_CD=" + Convert.ToString(readerB["IE_CD"]) + "&ACTION=C&ReportName=RPTWELDINGCABLES.RPT";
                    }
                    conn.Close();
                    GetsaveData();
                    //BindDimension();
                    funBindGrdDimension();
                    //BindChemicaleTest();
                    //BindChemicaleTest3();
                    //BindChemicaleTest4();
                    //BindChemicaleTest5();


                }
                catch (Exception ex)
                {
                    //					string str; 
                    str = ex.Message;
                    string str1 = str.Replace("</p><p>", "");
                    Response.Redirect("Error_Form.aspx?err=" + str1);
                }
                finally
                {

                    conn.Close();
                }
            }
        }
        private void BindDimension()
        {

            string sQurry = "select  DIM_CD, Parameter, Specified, Item_cd, header_code from inspection_tst_plndimension where item_cd='N000038' and header_code='Dimensions (in mm)' order by DIM_CD";
            DataTable dt = new DataTable();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = sQurry;
            cmd.Connection = conn;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            OracleDataReader readerB = cmd.ExecuteReader();
            dt.Columns.Add("SNo", typeof(string));
            dt.Columns.Add("DIM_CD", typeof(string));
            dt.Columns.Add("Parameter", typeof(string));
            dt.Columns.Add("Specified", typeof(string));
            while (readerB.Read())
            {
                DataRow dr = dt.NewRow();
                dr["SNo"] = Convert.ToString(readerB["DIM_CD"]).Replace("N000038", "").Replace("DIM", "");
                dr["DIM_CD"] = Convert.ToString(readerB["DIM_CD"]);
                dr["Parameter"] = Convert.ToString(readerB["Parameter"]);
                dr["Specified"] = Convert.ToString(readerB["Specified"]);
                dt.Rows.Add(dr);

            }
            conn.Close();
            repeaterDimension.DataSource = dt;
            repeaterDimension.DataBind();
        }

        private void BindChemicaleTest()
        {
            string sQurry = "select  DIM_CD, Parameter, Specified, Item_cd, header_code from inspection_tst_plndimension where item_cd='N000038' and header_code='Chemical test of Billet ' order by DIM_CD";
            DataTable dt = new DataTable();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = sQurry;
            cmd.Connection = conn;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            OracleDataReader readerB = cmd.ExecuteReader();
            dt.Columns.Add("SNo", typeof(string));
            dt.Columns.Add("DIM_CD", typeof(string));
            dt.Columns.Add("Parameter", typeof(string));
            dt.Columns.Add("Specified", typeof(string));
            while (readerB.Read())
            {
                DataRow dr = dt.NewRow();
                dr["SNo"] = Convert.ToString(readerB["DIM_CD"]).Replace("N000038", "").Replace("DIM", "");
                dr["DIM_CD"] = Convert.ToString(readerB["DIM_CD"]);
                dr["Parameter"] = Convert.ToString(readerB["Parameter"]);
                dr["Specified"] = Convert.ToString(readerB["Specified"]);
                dt.Rows.Add(dr);
            }
            conn.Close();
            repeaterChemicalTest.DataSource = dt;
            repeaterChemicalTest.DataBind();
            funBindGrdDimension2();
        }
        private void BindChemicaleTest3()
        {
            string sQurry = "select  DIM_CD, Parameter, Specified, Item_cd, header_code, ROW_HEIGHT from inspection_tst_plndimension where item_cd='N000038' and header_code='Physical test ' order by DIM_CD";
            DataTable dt = new DataTable();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = sQurry;
            cmd.Connection = conn;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            OracleDataReader readerB = cmd.ExecuteReader();
            dt.Columns.Add("SNo", typeof(string));
            dt.Columns.Add("DIM_CD", typeof(string));
            dt.Columns.Add("Parameter", typeof(string));
            dt.Columns.Add("Specified", typeof(string));
            dt.Columns.Add("ROW_HEIGHT", typeof(string));
            while (readerB.Read())
            {
                DataRow dr = dt.NewRow();
                dr["SNo"] = Convert.ToString(readerB["DIM_CD"]).Replace("N000038", "").Replace("DIM", "");
                dr["DIM_CD"] = Convert.ToString(readerB["DIM_CD"]);
                dr["Parameter"] = Convert.ToString(readerB["Parameter"]);
                dr["Specified"] = Convert.ToString(readerB["Specified"]);
                dr["ROW_HEIGHT"] = Convert.ToString(readerB["ROW_HEIGHT"]);
                dt.Rows.Add(dr);
            }
            conn.Close();
            repeaterChemicalTest3.DataSource = dt;
            repeaterChemicalTest3.DataBind();
            funBindGrdDimension3();
        }
        private void BindChemicaleTest4()
        {
            string sQurry = "select  DIM_CD, Parameter, Specified, Item_cd, header_code, ROW_HEIGHT from inspection_tst_plndimension where item_cd='N000038' and header_code='Chemical test of Fish plate' order by DIM_CD";
            DataTable dt = new DataTable();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = sQurry;
            cmd.Connection = conn;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            OracleDataReader readerB = cmd.ExecuteReader();
            dt.Columns.Add("SNo", typeof(string));
            dt.Columns.Add("DIM_CD", typeof(string));
            dt.Columns.Add("Parameter", typeof(string));
            dt.Columns.Add("Specified", typeof(string));
            dt.Columns.Add("ROW_HEIGHT", typeof(string));
            while (readerB.Read())
            {
                DataRow dr = dt.NewRow();
                dr["SNo"] = Convert.ToString(readerB["DIM_CD"]).Replace("N000038", "").Replace("DIM", "");
                dr["DIM_CD"] = Convert.ToString(readerB["DIM_CD"]);
                dr["Parameter"] = Convert.ToString(readerB["Parameter"]);
                dr["Specified"] = Convert.ToString(readerB["Specified"]);
                dr["ROW_HEIGHT"] = Convert.ToString(readerB["ROW_HEIGHT"]);
                dt.Rows.Add(dr);
            }
            conn.Close();
            repeaterChemicalTest4.DataSource = dt;
            repeaterChemicalTest4.DataBind();
            funBindGrdDimension4();
        }
        private void BindChemicaleTest5()
        {
            string sQurry = "select  DIM_CD, Parameter, Specified, Item_cd, header_code, ROW_HEIGHT from inspection_tst_plndimension where item_cd='N000038' and header_code='Physical test of Fish plate' order by DIM_CD";
            DataTable dt = new DataTable();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = sQurry;
            cmd.Connection = conn;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            OracleDataReader readerB = cmd.ExecuteReader();
            dt.Columns.Add("SNo", typeof(string));
            dt.Columns.Add("DIM_CD", typeof(string));
            dt.Columns.Add("Parameter", typeof(string));
            dt.Columns.Add("Specified", typeof(string));
            dt.Columns.Add("ROW_HEIGHT", typeof(string));
            while (readerB.Read())
            {
                DataRow dr = dt.NewRow();
                dr["SNo"] = Convert.ToString(readerB["DIM_CD"]).Replace("N000038", "").Replace("DIM", "");
                dr["DIM_CD"] = Convert.ToString(readerB["DIM_CD"]);
                dr["Parameter"] = Convert.ToString(readerB["Parameter"]);
                dr["Specified"] = Convert.ToString(readerB["Specified"]);
                dr["ROW_HEIGHT"] = Convert.ToString(readerB["ROW_HEIGHT"]);
                dt.Rows.Add(dr);
            }
            conn.Close();
            repeaterChemicalTest5.DataSource = dt;
            repeaterChemicalTest5.DataBind();
            funBindGrdDimension5();
        }
        protected void lnkAdd_Click(object sender, EventArgs e)
        {
            DataTable dtTstPlan;
            char curS_no = 'f';
            if (repaterTstChecks.Items.Count == 0)
            {
                dtTstPlan = new DataTable();
                dtTstPlan.Columns.Add("S_No", typeof(string));
                dtTstPlan.Columns.Add("Parameter", typeof(string));
                dtTstPlan.Columns.Add("ValueSpeci", typeof(string));
                dtTstPlan.Columns.Add("Observation", typeof(string));
                dtTstPlan.Columns.Add("StatusPass", typeof(bool));
                dtTstPlan.Columns.Add("StatusFail", typeof(bool));
                dtTstPlan.Columns.Add("Remarks", typeof(string));
                curS_no = 'f';
            }
            else
            {
                //dtTstPlan = (DataTable)ViewState["tstPlan"];
                dtTstPlan = new DataTable();
                dtTstPlan.Columns.Add("S_No", typeof(string));
                dtTstPlan.Columns.Add("Parameter", typeof(string));
                dtTstPlan.Columns.Add("ValueSpeci", typeof(string));
                dtTstPlan.Columns.Add("Observation", typeof(string));
                dtTstPlan.Columns.Add("StatusPass", typeof(bool));
                dtTstPlan.Columns.Add("StatusFail", typeof(bool));
                dtTstPlan.Columns.Add("Remarks", typeof(string));
                for (int i = 0; i < repaterTstChecks.Items.Count; i++)
                {
                    Label lblSNo = (Label)repaterTstChecks.Items[i].FindControl("lblSNo");
                    TextBox txtParameter1 = (TextBox)repaterTstChecks.Items[i].FindControl("txtParameter1");
                    TextBox txtValueSpecified = (TextBox)repaterTstChecks.Items[i].FindControl("txtValueSpecified");
                    TextBox txtObservation = (TextBox)repaterTstChecks.Items[i].FindControl("txtObservation");
                    TextBox txtRemarks = (TextBox)repaterTstChecks.Items[i].FindControl("txtRemarks");
                    RadioButton rdoTestExtra1 = (RadioButton)repaterTstChecks.Items[i].FindControl("rdoTestExtra1");
                    RadioButton rdoTestExtra2 = (RadioButton)repaterTstChecks.Items[i].FindControl("rdoTestExtra2");
                    // string SPass = (rdoTestExtra1.Checked == true ? "Pass" : "Fail");
                    DataRow dr1 = dtTstPlan.NewRow();
                    dr1["S_No"] = lblSNo.Text;
                    dr1["Parameter"] = txtParameter1.Text;
                    dr1["ValueSpeci"] = txtValueSpecified.Text;
                    dr1["Observation"] = txtObservation.Text;
                    dr1["StatusPass"] = rdoTestExtra1.Checked;
                    dr1["StatusFail"] = rdoTestExtra2.Checked;
                    dr1["Remarks"] = txtRemarks.Text;
                    dtTstPlan.Rows.Add(dr1);
                }
                DataView dv = new DataView(dtTstPlan, "", "S_No desc", DataViewRowState.CurrentRows);
                //curS_no = Convert.ToChar(dv.Rows[0].["S_No"]);
                DataRow[] drshort = dtTstPlan.Select("", "S_No desc");
                curS_no = Convert.ToChar(drshort[0]);
            }
            DataRow dr = dtTstPlan.NewRow();
            dr["S_No"] = getNextChar(curS_no).ToString();
            dr["Parameter"] = "";
            dr["ValueSpeci"] = "";
            dr["Observation"] = "";
            dr["StatusPass"] = false;
            dr["StatusFail"] = false;
            dr["Remarks"] = "";
            dtTstPlan.Rows.Add(dr);
            //ViewState["tstPlan"] = dtTstPlan;
            repaterTstChecks.DataSource = dtTstPlan;
            repaterTstChecks.DataBind();
        }
        private static char getNextChar(char c)
        {

            // convert char to ascii
            int ascii = (int)c;
            // get the next ascii
            int nextAscii = ascii + 1;
            // convert ascii to char
            char nextChar = (char)nextAscii;
            return nextChar;
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
        ///		Required method for Designer support - do not modify
        ///		the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion
        private void DisplayAlert(string msg)
        {
            Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
        }
        #region Get Save Data
        private void GetsaveData()
        {
            string sql = "SELECT * FROM INSPECTION_TEST_PLN WHERE CASE_NO='" + Request.Params["CASE_NO"].ToString() + "' AND CALL_SNO='" + Request.Params["CALL_SNO"].ToString() + "' and pl_no='" + TXTPLNO.Text + "' and CALL_RECV_DT=to_date('" + Request.Params["CALL_RECV_DT"].ToString() + "', 'dd/mm/yyyy')";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = sql;
            cmd.Connection = conn;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            DataTable dtTstPlan = new DataTable();
            dtTstPlan.Columns.Add("S_No", typeof(string));
            dtTstPlan.Columns.Add("Parameter", typeof(string));
            dtTstPlan.Columns.Add("ValueSpeci", typeof(string));
            dtTstPlan.Columns.Add("Observation", typeof(string));
            dtTstPlan.Columns.Add("StatusPass", typeof(bool));
            dtTstPlan.Columns.Add("StatusFail", typeof(bool));
            dtTstPlan.Columns.Add("Remarks", typeof(string));

            DataTable dtPeriodictess = new DataTable();
            dtPeriodictess.Columns.Add("S_No", typeof(string));
            dtPeriodictess.Columns.Add("Parameter", typeof(string));
            dtPeriodictess.Columns.Add("ValueSpeci", typeof(string));
            dtPeriodictess.Columns.Add("Observation", typeof(string));
            dtPeriodictess.Columns.Add("StatusPass", typeof(bool));
            dtPeriodictess.Columns.Add("StatusFail", typeof(bool));
            dtPeriodictess.Columns.Add("Remarks", typeof(string));

            OracleDataReader readerB = cmd.ExecuteReader();
            if (readerB.Read())
            {
                //if (Convert.ToString(readerB["FINAL_STATEMENT_STATUS"]).Length > 0)
                //{
                //    Response.Redirect("~/RBS/checksheet/frmInspectTestReport.aspx?CASE_NO=" + Request.Params["CASE_NO"].ToString() + "&CALL_RECV_DT=" + Request.Params["CALL_RECV_DT"].ToString() + "&CALL_SNO=" + Request.Params["CALL_SNO"].ToString() + "&IE_CD=" + Convert.ToString(ViewState["IE_CD"]) + "&ACTION=C&ReportName=RPTWELDINGCABLES.RPT");
                //}
                ViewState["INSPECT_CD"] = Convert.ToString(readerB["INSPECT_CD"]);
                txtBookNo.Text = Convert.ToString(readerB["BK_NO"]);
                txtSetNo.Text = Convert.ToString(readerB["SET_NO"]);
                txtOffered.Text = Convert.ToString(readerB["SIZE_OF_SAMPLE"]);
                txtSizeofLog.Text = Convert.ToString(readerB["SIZE_OF_LOT"]);
                lblSpecification.Text = Convert.ToString(readerB["DRAWING_SPE"]);
                txtDateOfInspection.Text = Convert.ToString(readerB["DATE_OF_INSPECT"]);
                txtPlaceofInspection.Text = Convert.ToString(readerB["PLACE_OF_INSPECT"]);
                txtDatasheetRemarks1.Text = Convert.ToString(readerB["DATASHEET_REMARKS1"]);
                ViewState["Issubmit"] = (Convert.ToString(readerB["Final_submit"]) == "S" ? "S" : "N");

                rdoFinalStatementPass.Checked = (Convert.ToString(readerB["FINAL_STATEMENT_STATUS"]) == "Pass" ? true : false);
                txtFinalStatement.Text = Convert.ToString(readerB["FINAL_STATEMENT"]);
                if (Convert.ToString(readerB["Final_submit"]) == "S")
                {
                    Response.Write("<script language=JavaScript>$('#form1 :input').prop('disabled', true);</script>");
                }
                if (Convert.ToString(readerB["File_Path"]) != "")
                {
                    litFileUpdate.Text = "<a href='LabReports/" + Convert.ToString(Convert.ToString(readerB["File_Path"])) + "' target=\"_blank\">Download</a>";
                    fileDelete.Visible = true;
                }
                if (Convert.ToString(readerB["File_Path2"]) != "")
                {
                    litFileUpdate2.Text = "<a href='LabReports/" + Convert.ToString(Convert.ToString(readerB["File_Path2"])) + "' target=\"_blank\">Download</a>";
                    fileDelete2.Visible = true;
                }
                if (Convert.ToString(readerB["File_Path3"]) != "")
                {
                    litFileUpdate3.Text = "<a href='LabReports/" + Convert.ToString(Convert.ToString(readerB["File_Path3"])) + "' target=\"_blank\">Download</a>";
                    fileDelete3.Visible = true;
                }
                if (Convert.ToString(readerB["File_Path4"]) != "")
                {
                    litFileUpdate4.Text = "<a href='LabReports/" + Convert.ToString(Convert.ToString(readerB["File_Path4"])) + "' target=\"_blank\">Download</a>";
                    fileDelete4.Visible = true;
                }
                if (Convert.ToString(readerB["File_Path5"]) != "")
                {
                    litFileUpdate5.Text = "<a href='LabReports/" + Convert.ToString(Convert.ToString(readerB["File_Path5"])) + "' target=\"_blank\">Download</a>";
                    fileDelete5.Visible = true;
                }
                //txtFinalStatement.Text = Convert.ToString(readerB["FINAL_STATEMENT"]);

                sql = "SELECT * FROM INSPECTION_TEST_PLNDOC_VERIFY WHERE INSPECT_CD='" + Convert.ToString(ViewState["INSPECT_CD"]) + "' order by HEADING";
                cmd = new OracleCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                OracleDataReader readerdoc = cmd.ExecuteReader();
                while (readerdoc.Read())
                {
                    if (Convert.ToString(readerdoc["HEADING"]) == chkDoc1.Text)
                    {
                        chkDoc1.Checked = (Convert.ToString(readerdoc["IS_CHECKED"]) == "Yes" ? true : false);
                    }
                    else if (Convert.ToString(readerdoc["HEADING"]) == chkDoc2.Text)
                    {
                        chkDoc2.Checked = (Convert.ToString(readerdoc["IS_CHECKED"]) == "Yes" ? true : false);
                    }
                    else if (Convert.ToString(readerdoc["HEADING"]) == chkDoc3.Text)
                    {
                        chkDoc3.Checked = (Convert.ToString(readerdoc["IS_CHECKED"]) == "Yes" ? true : false);
                    }
                    else if (Convert.ToString(readerdoc["HEADING"]) == chkDoc4.Text)
                    {
                        chkDoc4.Checked = (Convert.ToString(readerdoc["IS_CHECKED"]) == "Yes" ? true : false);
                    }
                    else if (Convert.ToString(readerdoc["HEADING"]) == chkDoc5.Text)
                    {
                        chkDoc5.Checked = (Convert.ToString(readerdoc["IS_CHECKED"]) == "Yes" ? true : false);
                    }
                }
                sql = "SELECT * FROM INSPECTION_TEST_PLN_tran WHERE INSPECT_CD='" + Convert.ToString(ViewState["INSPECT_CD"]) + "' order by inspt_sno";
                cmd = new OracleCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                OracleDataReader readerC = cmd.ExecuteReader();
                while (readerC.Read())
                {

                    if (Convert.ToString(readerC["INSPT_HEAD"]) == "Test/Checks")
                    {
                        if (Convert.ToString(readerC["INSPT_SNO"]) == "1)")
                        {
                            txtObservA.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservA, rdoPassA, rdoFailA, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                        else if (Convert.ToString(readerC["INSPT_SNO"]) == "2)")
                        {
                            txtObservB.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservB, rdoPassB, rdoFailB, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                        else if (Convert.ToString(readerC["INSPT_SNO"]) == "3)")
                        {
                            txtObservC.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidateOk(txtObservC, rdoPassC, rdoFailC, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                        else if (Convert.ToString(readerC["INSPT_SNO"]) == "4)")
                        {
                            txtObservD.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidateOk(txtObservD, rdoPassD, rdoFailD, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                        else if (Convert.ToString(readerC["INSPT_SNO"]) == "5)")
                        {
                            txtObservE.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidateOk(txtObservE, rdoPassE, rdoFailE, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                        else if (Convert.ToString(readerC["INSPT_SNO"]) == "6)")
                        {
                            txtObservF.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservF, rdoPassF, rdoFailF, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                        else if (Convert.ToString(readerC["INSPT_SNO"]) == "7)")
                        {
                            txtObservG.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservG, rdoPassG, rdoFailG, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                        else if (Convert.ToString(readerC["INSPT_SNO"]) == "8)")
                        {
                            txtObservH.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservH, rdoPassH, rdoFailH, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                        else if (Convert.ToString(readerC["INSPT_SNO"]) == "9)")
                        {
                            txtObservI.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservI, rdoPassI, rdoFailI, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                        else if (Convert.ToString(readerC["INSPT_SNO"]) == "10)")
                        {
                            txtObservJ.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservJ, rdoPassJ, rdoFailJ, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                        else if (Convert.ToString(readerC["INSPT_SNO"]) == "k")
                        {
                            txtObservK.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservK, rdoPassK, rdoFailK, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                        else if (Convert.ToString(readerC["INSPT_SNO"]) == "l")
                        {
                            txtObservL.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservL, rdoPassL, rdoFailL, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                        else if (Convert.ToString(readerC["INSPT_SNO"]) == "m")
                        {
                            txtObservM.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservM, rdoPassM, rdoFailM, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                        else if (Convert.ToString(readerC["INSPT_SNO"]) == "n")
                        {
                            txtObservN.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservN, rdoPassN, rdoFailN, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                        else if (Convert.ToString(readerC["INSPT_SNO"]) == "o")
                        {
                            txtObservO.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservO, rdoPassO, rdoFailO, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                        else if (Convert.ToString(readerC["INSPT_SNO"]) == "p")
                        {
                            txtObservP.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservP, rdoPassP, rdoFailP, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                        else
                        {
                            DataRow dr = dtTstPlan.NewRow();
                            dr["S_No"] = Convert.ToString(readerC["INSPT_SNO"]);
                            dr["Parameter"] = Convert.ToString(readerC["PARMETER"]);
                            dr["ValueSpeci"] = Convert.ToString(readerC["VALUE_SPECIFIED"]);
                            dr["Observation"] = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) == "Pass" || Convert.ToString(readerC["OBSERV_STATUS"]) == "ok")
                            {
                                dr["StatusPass"] = true;
                                dr["StatusFail"] = false;
                            }
                            else
                            {
                                dr["StatusFail"] = true;
                                dr["StatusPass"] = false;
                            }
                            dr["Remarks"] = Convert.ToString(readerC["REMARKS"]);
                            dtTstPlan.Rows.Add(dr);
                        }
                    }
                }
                repaterTstChecks.DataSource = dtTstPlan;
                repaterTstChecks.DataBind();
            }
        }
        private void funtxtValidate(TextBox txt, RadioButton rdoPass, RadioButton rdoFail, string pCondition)
        {
            if (pCondition == "Pass")
            {
                rdoPass.Checked = true;
            }
            else
            {
                rdoFail.Checked = true;
                txt.BorderColor = Color.Red;
                txt.ForeColor = Color.Red;
            }

        }
        private void funtxtValidate(TextBox txt, RadioButton rdoPass, string pCondition)
        {
            if (pCondition == "Pass")
            {
                txt.BorderColor = Color.Black;
                txt.ForeColor = Color.Black;
            }
            else
            {
                txt.BorderColor = Color.Red;
                txt.ForeColor = Color.Red;
            }

        }
        private void funtxtValidateOk(TextBox txt, RadioButton rdoPass, RadioButton rdoFail, string pCondition)
        {
            if (pCondition == "Ok" || pCondition == "Pass")
            {
                rdoPass.Checked = true;
            }
            else if (pCondition == "Not Ok")
            {
                rdoPass.Checked = true;
            }
            else
            {
                rdoFail.Checked = true;
                txt.BorderColor = Color.Red;
                txt.ForeColor = Color.Red;
            }

        }
        #endregion

        #region Saving Data
        private void SaveData()
        {
            if (txtDateOfInspection.Text == "")
            {
                DisplayAlert("Please enter date of inspection");
            }
            else if (txtPlaceofInspection.Text == "")
            {
                DisplayAlert("Enter place of inspection !!!");
                return;
            }
            else if (txtSizeofLog.Text == "")
            {
                DisplayAlert(" Enter size of lot!!!");
                return;
            }
            else
            {


                string str = "SELECT INSPECT_CD FROM INSPECTION_TEST_PLN WHERE CASE_NO='" + Request.Params["CASE_NO"].ToString() + "' AND CALL_SNO='" + Request.Params["CALL_SNO"].ToString() + "' and ITEM_CD='" + Convert.ToString(ViewState["Item_Code"]) + "' and CALL_RECV_DT=to_date('" + Request.Params["CALL_RECV_DT"].ToString() + "', 'dd/mm/yyyy')";
                //OracleCommand cmd1 = new OracleCommand(str, conn);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                OracleCommand cmd2 = new OracleCommand(str, conn);
                string wCDT = Convert.ToString(cmd2.ExecuteScalar());
                conn.Close();
                if (wCDT == "")
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    String CALL_SNO = Request.Params["CALL_SNO"].ToString();

                    string sQuery = "INSERT INTO INSPECTION_TEST_PLN(PO_NO, REPORT_HEADER, INSPECT_CD, ITEM_CD, PL_NO, CASE_NO,CALL_SNO, BK_NO, SET_NO, DRAWING_SPE, DATE_OF_INSPECT, PLACE_OF_INSPECT, SIZE_OF_LOT, SIZE_OF_SAMPLE, DOCUMENT_VERI, IE_CD, CALL_RECV_DT) " +
                                                          " VALUES(:PPO_NO, :PREPORT_HEADER,:PINSPECT_CD, :PITEM_CD, :PPL_NO, :PCASE_NO, :PCALL_SNO, :PBK_NO, :PSET_NO, :PDRAWING_SPE, :PDATE_OF_INSPECT, :PPLACE_OF_INSPECT,:PSIZE_OF_LOT, :PSIZE_OF_SAMPLE, :PDOCUMENT_VERI, :PIE_CD, to_date(:PCALL_RECV_DT, 'dd/mm/yyyy'))";
                    OracleCommand myInsertCommand = new OracleCommand(sQuery, conn);
                    string sINSPECT_CD = Convert.ToString(ViewState["Item_Code"]) + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;
                    ViewState["INSPECT_CD"] = sINSPECT_CD;
                    OracleParameter param = new OracleParameter();

                    myInsertCommand.Parameters.Add(funParameter("PPO_NO", "string", 200, txtPoNo.Text));
                    myInsertCommand.Parameters.Add(funParameter("PREPORT_HEADER", "string", 30, "Welding Cable"));
                    myInsertCommand.Parameters.Add(funParameter("PINSPECT_CD", "string", 30, sINSPECT_CD));
                    myInsertCommand.Parameters.Add(funParameter("PITEM_CD", "string", 20, Convert.ToString(ViewState["Item_Code"])));
                    myInsertCommand.Parameters.Add(funParameter("PPL_NO", "string", 20, TXTPLNO.Text));
                    myInsertCommand.Parameters.Add(funParameter("PCASE_NO", "string", 20, txtCaseNo.Text));
                    myInsertCommand.Parameters.Add(funParameter("PCALL_SNO", "string", 20, CALL_SNO));
                    myInsertCommand.Parameters.Add(funParameter("PBK_NO", "string", 20, txtBookNo.Text));
                    myInsertCommand.Parameters.Add(funParameter("PSET_NO", "string", 20, txtSetNo.Text));
                    myInsertCommand.Parameters.Add(funParameter("PDRAWING_SPE", "string", 4000, lblSpecification.Text));
                    myInsertCommand.Parameters.Add(funParameter("PDATE_OF_INSPECT", "string", 50, txtDateOfInspection.Text));
                    myInsertCommand.Parameters.Add(funParameter("PPLACE_OF_INSPECT", "string", 2000, txtPlaceofInspection.Text));
                    myInsertCommand.Parameters.Add(funParameter("PSIZE_OF_LOT", "string", 200, txtSizeofLog.Text));
                    myInsertCommand.Parameters.Add(funParameter("PSIZE_OF_SAMPLE", "string", 200, txtOffered.Text));
                    myInsertCommand.Parameters.Add(funParameter("PDOCUMENT_VERI", "string", 20, ""));
                    myInsertCommand.Parameters.Add(funParameter("PIE_CD", "string", 20, Convert.ToString(ViewState["IE_CD"])));
                    myInsertCommand.Parameters.Add(new System.Data.OracleClient.OracleParameter("PCALL_RECV_DT", Request.Params["CALL_RECV_DT"].ToString()));

                    myInsertCommand.Connection = conn;
                    myInsertCommand.ExecuteNonQuery();
                    funSaveDocVeri(sINSPECT_CD, chkDoc1.Text, (chkDoc1.Checked == true ? "Yes" : "No"));
                    funSaveDocVeri(sINSPECT_CD, chkDoc2.Text, (chkDoc2.Checked == true ? "Yes" : "No"));
                    funSaveDocVeri(sINSPECT_CD, chkDoc3.Text, (chkDoc3.Checked == true ? "Yes" : "No"));
                    funSaveDocVeri(sINSPECT_CD, chkDoc4.Text, (chkDoc4.Checked == true ? "Yes" : "No"));
                    funSaveDocVeri(sINSPECT_CD, chkDoc5.Text, (chkDoc5.Checked == true ? "Yes" : "No"));

                }
                else
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    // System.Data.OracleClient.OracleTransaction myTrans = conn.BeginTransaction();
                    string sQuery = "UPDATE INSPECTION_TEST_PLN SET PO_NO=:PPO_NO, BK_NO=:PBK_NO, SET_NO=:PSET_NO, DATE_OF_INSPECT=:PDATE_OF_INSPECT, PLACE_OF_INSPECT=:PPLACE_OF_INSPECT, SIZE_OF_SAMPLE=:PSIZE_OF_SAMPLE, SIZE_OF_LOT=:PSIZE_OF_LOT, DOCUMENT_VERI=:PDOCUMENT_VERI, IE_CD=:PIE_CD WHERE INSPECT_CD=:PINSPECT_CD";
                    OracleCommand myUpdateCallStatusCommand = new OracleCommand(sQuery, conn);
                    string CALL_SNO = Request.Params["CALL_SNO"].ToString();
                    myUpdateCallStatusCommand.Parameters.Add(funParameter("PPO_NO", "string", 200, txtPoNo.Text));
                    myUpdateCallStatusCommand.Parameters.Add(funParameter("PINSPECT_CD", "string", 30, wCDT));
                    myUpdateCallStatusCommand.Parameters.Add(funParameter("PBK_NO", "string", 20, txtBookNo.Text));
                    myUpdateCallStatusCommand.Parameters.Add(funParameter("PSET_NO", "string", 20, txtSetNo.Text));
                    myUpdateCallStatusCommand.Parameters.Add(funParameter("PDATE_OF_INSPECT", "string", 50, txtDateOfInspection.Text));
                    myUpdateCallStatusCommand.Parameters.Add(funParameter("PPLACE_OF_INSPECT", "string", 2000, txtPlaceofInspection.Text));
                    myUpdateCallStatusCommand.Parameters.Add(funParameter("PSIZE_OF_SAMPLE", "string", 200, txtOffered.Text));
                    myUpdateCallStatusCommand.Parameters.Add(funParameter("PSIZE_OF_LOT", "string", 200, txtSizeofLog.Text));
                    myUpdateCallStatusCommand.Parameters.Add(funParameter("PDOCUMENT_VERI", "string", 20, ""));
                    myUpdateCallStatusCommand.Parameters.Add(funParameter("PIE_CD", "string", 20, Convert.ToString(ViewState["IE_CD"])));


                    myUpdateCallStatusCommand.Connection = conn;
                    myUpdateCallStatusCommand.ExecuteNonQuery();


                    funSaveDocVeri(wCDT, chkDoc1.Text, (chkDoc1.Checked == true ? "Yes" : "No"));
                    funSaveDocVeri(wCDT, chkDoc2.Text, (chkDoc2.Checked == true ? "Yes" : "No"));
                    funSaveDocVeri(wCDT, chkDoc3.Text, (chkDoc3.Checked == true ? "Yes" : "No"));
                    funSaveDocVeri(wCDT, chkDoc4.Text, (chkDoc4.Checked == true ? "Yes" : "No"));
                    funSaveDocVeri(wCDT, chkDoc5.Text, (chkDoc5.Checked == true ? "Yes" : "No"));

                }
            }

        }

        private OracleParameter funParameter(string PName, string type, int plen, string pValue)
        {
            OracleParameter param = new OracleParameter();
            param.ParameterName = PName;
            if (type == "string")
            {
                param.OracleDbType = OracleDbType.Varchar2;
                param.Size = plen;
            }
            else if (type == "date")
            {
                param.OracleDbType = OracleDbType.Date;
            }
            else if (type == "int")
            {
                param.OracleDbType = OracleDbType.Int32;
            }
            param.Value = Convert.ToString(pValue);
            return param;
        }
        private void funSaveDocVeri(string pINSPECT_CD, string PPARAMETER, string PISCHECKED)
        {
            string str = "SELECT INSPECT_CD FROM INSPECTION_TEST_PLNDOC_VERIFY WHERE INSPECT_CD='" + pINSPECT_CD + "' AND HEADING='" + PPARAMETER + "' ";
            OracleCommand cmd3 = new OracleCommand(str, conn);
            string wCDT = Convert.ToString(cmd3.ExecuteScalar());
            if (wCDT == "")
            {
                string myInsertQuery = "INSERT INTO INSPECTION_TEST_PLNDOC_VERIFY(INSPECT_CD, HEADING, IS_CHECKED) " +
                                                " VALUES(:PINSPECT_CD, :PHEADING, :PIS_CHECKED)";
                OracleCommand myInsertCommand = new OracleCommand(myInsertQuery, conn);
                myInsertCommand.Parameters.Add(funParameter("PINSPECT_CD", "string", 30, pINSPECT_CD));
                myInsertCommand.Parameters.Add(funParameter("PHEADING", "string", 500, PPARAMETER));
                myInsertCommand.Parameters.Add(funParameter("PIS_CHECKED", "string", 20, PISCHECKED));
                myInsertCommand.Connection = conn;
                myInsertCommand.ExecuteNonQuery();
            }
            else
            {
                funUpdateDocVeri(pINSPECT_CD, PPARAMETER, PISCHECKED);
            }
        }
        private void funUpdateDocVeri(string pINSPECT_CD, string PPARAMETER, string PISCHECKED)
        {
            string myInsertQuery = "UPDATE INSPECTION_TEST_PLNDOC_VERIFY SET IS_CHECKED=:PISCHECKED WHERE INSPECT_CD=:PINSPECT_CD and HEADING=:PHEADING";

            OracleCommand myInsertCommand = new OracleCommand(myInsertQuery, conn);
            myInsertCommand.Parameters.Add(funParameter("PINSPECT_CD", "string", 30, pINSPECT_CD));
            myInsertCommand.Parameters.Add(funParameter("PHEADING", "string", 500, PPARAMETER));
            myInsertCommand.Parameters.Add(funParameter("PISCHECKED", "string", 20, PISCHECKED));
            // myInsertCommand.Transaction = myTrans;
            myInsertCommand.Connection = conn;
            myInsertCommand.ExecuteNonQuery();
        }
        private void SaveDimensionType(Repeater[] prpt, string[] pstr, string SHead)
        {
            string str = "SELECT INSPECT_CD FROM INSPECTION_TEST_PLN WHERE CASE_NO='" + Request.Params["CASE_NO"].ToString() + "' AND CALL_SNO='" + Request.Params["CALL_SNO"].ToString() + "' and ITEM_CD='" + Convert.ToString(ViewState["Item_Code"]) + "' and CALL_RECV_DT=to_date('" + Request.Params["CALL_RECV_DT"].ToString() + "', 'dd/mm/yyyy')";
            //OracleCommand cmd1 = new OracleCommand(str, conn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            OracleCommand cmd2 = new OracleCommand(str, conn);
            string wCDT = Convert.ToString(cmd2.ExecuteScalar());
            conn.Close();
            if (wCDT != "")
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();


                OracleCommand myUpdateCallStatusCommand;
                string sql1 = "delete from INSPECTION_TST_PLNDIM_TRAN where INSPECT_CD='" + Convert.ToString(ViewState["INSPECT_CD"]) + "' and HEADER_CODE='" + SHead + "'";
                myUpdateCallStatusCommand = new OracleCommand(sql1, conn);
                myUpdateCallStatusCommand.Connection = conn;
                myUpdateCallStatusCommand.ExecuteNonQuery();


                bool IsDelete = false;
                int ino = 0;
                foreach (Repeater rept in prpt)
                {
                    IsDelete = false;
                    for (int i = 0; i < rept.Items.Count; i++)
                    {
                        TextBox txtextheight = (TextBox)rept.Items[i].FindControl("txtV1" + (ino + 1).ToString() + "");
                        Label hidDimCD = (Label)rept.Items[i].FindControl("hidDimCD" + (ino + 1).ToString() + "");
                        Label hidParameter = (Label)rept.Items[i].FindControl("hidParameter" + (ino + 1).ToString() + "");
                        Label hidValue = (Label)rept.Items[i].FindControl("hidValue" + (ino + 1).ToString() + "");

                        //string sql = "SELECT * FROM INSPECTION_TST_PLNDIMENSION WHERE DIM_CD='" + hidDimCD.Value + "' and  ITEM_CD='" + Convert.ToString(ViewState["item_cd"]) + "' and Header_Code='" + SHead + "'";
                        //OracleCommand cmd = new OracleCommand();
                        //cmd.CommandText = sql;
                        //cmd.Connection = conn;
                        //OracleDataReader readerC = cmd.ExecuteReader();
                        //if (readerC.Read())
                        //{

                        string myInsertQuery = "";

                        myInsertQuery = "INSERT INTO INSPECTION_TST_PLNDIM_TRAN(DIM_CD, DIMPARAMETER, DIMSPECIFIED, ID, DIMSTATUS, DIMVALUES, INSPECT_CD, HEADER_CODE) " +
                                             " VALUES(:PDIM_CD, :PDIMPARAMETER, :PDIMSPECIFIED, :PID, :PDIMSTATUS, :PDIMVALUES, :PINSPECT_CD, :PHEADER_CODE)";
                        OracleCommand myInsertCommand = new OracleCommand(myInsertQuery, conn);
                        myInsertCommand.Parameters.Add(funParameter("PDIM_CD", "string", 20, hidDimCD.Text));
                        myInsertCommand.Parameters.Add(funParameter("PDIMPARAMETER", "string", 2000, hidParameter.Text));
                        myInsertCommand.Parameters.Add(funParameter("PDIMSPECIFIED", "string", 1200, hidValue.Text));
                        myInsertCommand.Parameters.Add(funParameter("PDIMSTATUS", "string", 20, "PASS"));
                        myInsertCommand.Parameters.Add(funParameter("PDIMVALUES", "string", 20, txtextheight.Text));
                        myInsertCommand.Parameters.Add(funParameter("PINSPECT_CD", "string", 30, wCDT));
                        myInsertCommand.Parameters.Add(funParameter("PID", "int", 0, (i + 1).ToString()));
                        myInsertCommand.Parameters.Add(funParameter("PHEADER_CODE", "string", 500, SHead));
                        myInsertCommand.Connection = conn;
                        myInsertCommand.ExecuteNonQuery();
                        //}
                    }
                    ino++;
                }
            }
        }
        public string funStatus(RadioButton rdo1, RadioButton rdo2)
        {
            if (rdo1.Checked == true)
            {
                return "Pass";
            }
            else if (rdo2.Checked == true)
            {
                return "Fail";
            }
            else
            {
                return "";
            }
        }
        public string funStatusOk(RadioButton rdo1, RadioButton rdo2)
        {
            if (rdo1.Checked == true)
            {
                return "Pass";
            }
            else if (rdo2.Checked == true)
            {
                return "Fail";
            }
            else
            {
                return "";
            }
        }
        private bool IsSaveValidate()
        {
            string vState = Convert.ToString(ViewState["Issubmit"]);
            if (ViewState["Issubmit"] == null)
            {
                return true;
            }
            else if (vState == "S")
            {
                DisplayAlert("Form is final submitted so data will not change");
                return false;
            }
            else
                return true;
        }
        #endregion
        protected void btnNext1_Click(object sender, EventArgs e)
        {
            if (IsSaveValidate())
            {
                SaveData();
            }
            pnlII.Visible = true;
            pnlIII.Visible = false;
            pnlI.Visible = false;
            // pnlV.Visible = false; 
            pnlIV.Visible = false;
        }
        protected void tbn2Back_Click(object sender, EventArgs e)
        {
            pnlII.Visible = false;
            pnlIII.Visible = false;
            pnlI.Visible = true;
            // pnlV.Visible = false;
            pnlIV.Visible = false;
        }
        protected void tbn3Next_Click(object sender, EventArgs e)
        {
            // pnlV.Visible = false;
            pnlIV.Visible = false;
            pnlII.Visible = false;
            pnlIII.Visible = true;
            pnlI.Visible = false;
            pnlIV.Visible = false;
        }


        protected void btnNext2_Click(object sender, EventArgs e)
        {
            pnlII.Visible = false;
            pnlIII.Visible = true;
            pnlI.Visible = false;
            //pnlV.Visible = false;
            pnlIV.Visible = false;
            if (IsSaveValidate())
            {
                if (ViewState["INSPECT_CD"] != "")
                {
                    string wCDT = Convert.ToString(ViewState["INSPECT_CD"]);
                    funSaveData(wCDT, "Visual Examination", "i)	The colour of the covering shall be black. \nii)	Single Core flexible cable. \niii)	The Conductor shall be composed of plain or tinned annealed high conductivity copper wires / aluminium wires. \niv)The conductor shall be covered with a separator. Separator shall be dry paper, polyester tape or any other suitable material. \nv) The covering/insulation shall be applied over the conductor and the separator. Covering shall be SE1 type for general service normal duty elastomeric compound or SE3 type for heat resistance, oil resistance and flame retardant(HOFR) normal duty elastomeric compound.", txtObservA.Text, funStatus(rdoPassA, rdoFailA), "Cl.No.9.5\n\n Cl. No.4\n\n CI.No.8.1 & 5.1\n\n CI.No.9.1\n\n", "Test/Checks", "1)");
                    funSaveData(wCDT, "Dimensions/ Construction\ni)	No. of Strands\n ii)	Dia of each strands\n iii)	Construction", "As per P.0\n The conductor formation shall be as per following (or as per requirement of P.0)\n i)Table 4 of IS 8130:1984 for copper conductor \nii) Table 5 of IS 8130:1984 for aluminium conductor", txtObservB.Text, funStatus(rdoPassB, rdoFailB), "CI.No.7", "Test/Checks", "2)");
                    funSaveData(wCDT, "Annealing Test", "As per IS \b8130:1984\b0", txtObservC.Text, funStatusOk(rdoPassC, rdoFailC), "CI.No.10.2 & IS 8130-1984 (After stranding Not Applicable). T/C Reviewed for before stranding.", "Test/Checks", "3)");
                    funSaveData(wCDT, "Conductor Resistance Test", "As per IS 8130:1984 and method of test as per IS : 10810(Part 5)-1984\nDrum length of cable or sample length of cable or conductor as indicated below shall constitute the test specimen: \na)All solid circular conductor – Drum length or 1 m\nb) All stranded or sector shaped solid conductors up to and including 25 sqmm size- Drum length or 5 m\nc) All stranded or sector shaped solid conductors greater than 25 sqmm size- Drum length or 10 m", txtObservD.Text, funStatusOk(rdoPassD, rdoFailD), "Cl.No.10.2 & Table 4 and Table 5 of IS 8130-1984 for copper and aluminum conductor respectively. Method of test as per IS: 10810(Part 5)-1984", "Test/Checks", "4)");
                    funSaveData(wCDT, "Test for thickness of covering/insulation", "i)The average thickness of covering shall be not less than the nominal value(tc) specified in Table-1\nii)Minimum value of thickness shall not fall below the nominal value(tc) specified in Table-1 by more than 0.1mm+0.15x tc", txtObservE.Text, funStatusOk(rdoPassE, rdoFailE), "", "Test/Checks", "5)");

                }

            }
        }
        private void funSaveData(string pINSPECT_CD, string PPARMETER, string PVALUE_SPECIFIED, string POBSERVATION, string POBSERV_STATUS, string PREMARKS, string INSPT_HEAD, string INSPT_SNO)
        {
            string str = "SELECT INSPECT_CD FROM INSPECTION_TEST_PLN_TRAN WHERE INSPECT_CD='" + pINSPECT_CD + "' AND INSPT_HEAD='" + INSPT_HEAD + "' and INSPT_SNO='" + INSPT_SNO + "' ";
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            OracleCommand cmd3 = new OracleCommand(str, conn);
            string wCDT = Convert.ToString(cmd3.ExecuteScalar());
            //conn.Close();
            if (wCDT == "")
            {
                string myInsertQuery = "INSERT INTO INSPECTION_TEST_PLN_TRAN(INSPECT_CD, ITEM_CD, PARMETER, VALUE_SPECIFIED, OBSERVATION, OBSERV_STATUS,REMARKS, INSPT_HEAD, INSPT_SNO) " +
                                                " VALUES(:PINSPECT_CD, :PITEM_CD, :PPARMETER, :PVALUE_SPECIFIED, :POBSERVATION, :POBSERV_STATUS,:PREMARKS, :PINSPT_HEAD, :PINSPT_SNO)";
                OracleCommand myInsertCommand = new OracleCommand(myInsertQuery, conn);
                //                myInsertCommand.Parameters.Add(funParameter("PINSPECT_CD", "string", 30, pINSPECT_CD));
                //                myInsertCommand.Parameters.Add(new System.Data.OracleClient.OracleParameter("PITEM_CD", Convert.ToString(ViewState["Item_Code"])));
                //                myInsertCommand.Parameters.Add(funParameter("PPARMETER", "string", 2000, PPARMETER));
                //                myInsertCommand.Parameters.Add(funParameter("PVALUE_SPECIFIED", "string", 4000, PVALUE_SPECIFIED));
                //                myInsertCommand.Parameters.Add(funParameter("POBSERVATION", "string", 200, POBSERVATION));
                //                myInsertCommand.Parameters.Add(funParameter("POBSERV_STATUS", "string", 20, POBSERV_STATUS));
                //                myInsertCommand.Parameters.Add(funParameter("PREMARKS", "string", 4000, PREMARKS));
                //                 myInsertCommand.Parameters.Add(funParameter("PINSPT_HEAD", "string", 500, INSPT_HEAD));
                //                myInsertCommand.Parameters.Add(funParameter("PINSPT_SNO", "string", 5, INSPT_SNO));

                myInsertCommand.Parameters.Add(funParameter("PINSPECT_CD", "string", 30, Convert.ToString(pINSPECT_CD)));
                myInsertCommand.Parameters.Add(funParameter("PITEM_CD", "string", 20, Convert.ToString(ViewState["Item_Code"])));
                myInsertCommand.Parameters.Add(funParameter("PPARMETER", "string", 2000, Convert.ToString(PPARMETER)));
                myInsertCommand.Parameters.Add(funParameter("PVALUE_SPECIFIED", "string", 4000, Convert.ToString(PVALUE_SPECIFIED)));
                myInsertCommand.Parameters.Add(funParameter("POBSERVATION", "string", 4000, Convert.ToString(POBSERVATION)));
                myInsertCommand.Parameters.Add(funParameter("POBSERV_STATUS", "string", 20, Convert.ToString(POBSERV_STATUS)));
                myInsertCommand.Parameters.Add(funParameter("PREMARKS", "string", 4000, Convert.ToString(PREMARKS)));
                myInsertCommand.Parameters.Add(funParameter("PINSPT_HEAD", "string", 500, Convert.ToString(INSPT_HEAD)));
                myInsertCommand.Parameters.Add(funParameter("PINSPT_SNO", "string", 5, Convert.ToString(INSPT_SNO)));
                // myInsertCommand.Transaction = myTrans;
                myInsertCommand.Connection = conn;
                myInsertCommand.ExecuteNonQuery();
            }
            else
            {
                funUpdateData(pINSPECT_CD, PPARMETER, PVALUE_SPECIFIED, POBSERVATION, POBSERV_STATUS, PREMARKS, INSPT_HEAD, INSPT_SNO);
            }
        }
        private void funUpdateData(string pINSPECT_CD, string PPARMETER, string PVALUE_SPECIFIED, string POBSERVATION, string POBSERV_STATUS, string PREMARKS)
        {
            funUpdateData(pINSPECT_CD, PPARMETER, PVALUE_SPECIFIED, POBSERVATION, POBSERV_STATUS, PREMARKS, "", "");
        }
        private void funUpdateData(string pINSPECT_CD, string PPARMETER, string PVALUE_SPECIFIED, string POBSERVATION, string POBSERV_STATUS, string PREMARKS, string INSPT_HEAD, string INSPT_SNO)
        {
            string myInsertQuery = "UPDATE INSPECTION_TEST_PLN_TRAN SET ITEM_CD=:PITEM_CD, VALUE_SPECIFIED=:PVALUE_SPECIFIED, OBSERVATION=:POBSERVATION, OBSERV_STATUS=:POBSERV_STATUS,REMARKS=:PREMARKS, PARMETER=:PPARMETER WHERE INSPECT_CD=:PINSPECT_CD AND INSPT_HEAD=:PINSPT_HEAD and INSPT_SNO=:PINSPT_SNO";

            OracleCommand myInsertCommand = new OracleCommand(myInsertQuery, conn);
            //            myInsertCommand.Parameters.Add(funParameter("PINSPECT_CD", "string", 30, pINSPECT_CD));
            //            myInsertCommand.Parameters.Add(new System.Data.OracleClient.OracleParameter("PITEM_CD", Convert.ToString(ViewState["Item_Code"])));
            //            myInsertCommand.Parameters.Add(funParameter("PPARMETER", "string", 2000, PPARMETER));
            //            myInsertCommand.Parameters.Add(funParameter("PVALUE_SPECIFIED", "string", 4000, PVALUE_SPECIFIED));
            //            myInsertCommand.Parameters.Add(funParameter("POBSERVATION", "string", 200, POBSERVATION));
            //            myInsertCommand.Parameters.Add(funParameter("POBSERV_STATUS", "string", 20, POBSERV_STATUS));
            //            myInsertCommand.Parameters.Add(funParameter("PREMARKS", "string", 4000, PREMARKS));
            //             myInsertCommand.Parameters.Add(funParameter("PINSPT_HEAD", "string", 500, INSPT_HEAD));
            //            myInsertCommand.Parameters.Add(funParameter("PINSPT_SNO", "string", 5, INSPT_SNO));



            myInsertCommand.Parameters.Add(funParameter("PINSPECT_CD", "string", 30, Convert.ToString(pINSPECT_CD)));
            myInsertCommand.Parameters.Add(funParameter("PITEM_CD", "string", 20, Convert.ToString(ViewState["Item_Code"])));
            myInsertCommand.Parameters.Add(funParameter("PPARMETER", "string", 2000, Convert.ToString(PPARMETER)));
            myInsertCommand.Parameters.Add(funParameter("PVALUE_SPECIFIED", "string", 4000, Convert.ToString(PVALUE_SPECIFIED)));
            myInsertCommand.Parameters.Add(funParameter("POBSERVATION", "string", 4000, Convert.ToString(POBSERVATION)));
            myInsertCommand.Parameters.Add(funParameter("POBSERV_STATUS", "string", 20, Convert.ToString(POBSERV_STATUS)));
            myInsertCommand.Parameters.Add(funParameter("PREMARKS", "string", 4000, Convert.ToString(PREMARKS)));
            myInsertCommand.Parameters.Add(funParameter("PINSPT_HEAD", "string", 500, Convert.ToString(INSPT_HEAD)));
            myInsertCommand.Parameters.Add(funParameter("PINSPT_SNO", "string", 5, Convert.ToString(INSPT_SNO)));
            // myInsertCommand.Transaction = myTrans;
            myInsertCommand.Connection = conn;
            myInsertCommand.ExecuteNonQuery();
        }
        protected void btnBack3_Click(object sender, EventArgs e)
        {
            pnlII.Visible = true;
            pnlIII.Visible = false;
            pnlI.Visible = false;
            pnlIV.Visible = false;
            //pnlV.Visible = false;
            pnlIV.Visible = false;
        }

        protected void btnNext3_Click(object sender, EventArgs e)
        {
            if (IsSaveValidate())
            {
                string wCDT = Convert.ToString(ViewState["INSPECT_CD"]);
                if (wCDT != "")
                {
                    funSaveData(wCDT, "High Voltage Test (Water Immersion test)", "High voltage shall be applied after the cable has been immersed in water for not less than 12 hours. The test voltage shall be applied between the water in which the cable is immersed which shall be earthed, and the conductor.The cable should withstand Ac voltage of 1000V(rms) for 5 minutes at a frequency of 40 to 60 Hz without breakdown.", txtObservF.Text, funStatus(rdoPassF, rdoFailF), "CI.No.11.1", "Test/Checks", "6)");
                    funSaveData(wCDT, "Length Verification of Coil/Drum/Reel", "As per P.O/Packing List.", txtObservG.Text, funStatus(rdoPassG, rdoFailG), "Appendix C of IS:1259", "Test/Checks", "7)");
                    funSaveData(wCDT, "Marking on cable", "i) Manufacture's identification mark should be printed or embossed or indented throughout the length of the cable. The distance between any two consecutive printings,indentations or embossing shall be not more than I m. \nii)	Cable Identification : Cables with HOFR compound shall be identified throughout the length by legend `HR 90' by printing, indenting or embossing on the cable.\niii)	Cable code shall be used as 'A' for aluminium, R for elastomeric covering for designating the cable and no code is required for copper conductor.", txtObservH.Text, funStatus(rdoPassH, rdoFailH), "CI.No.12", "Test/Checks", "8)");
                    funSaveData(wCDT, "Packing & Marking on Reels/Drums/ Coils", "The cable shall be either wound on  reels or drums or supplied in coils packed and labeled.\n The label or the stenciling on the drum shall contain the following information:\nIS Standard\nManufacturer Name\nType of Cable:\n Area of Conductor\nCable Code\nLength of Cable on Coil/Drum/Reel\nNo. of length on the Coil/Drum/Reel (if more than one)  \nDirection of rotation of the drum Approx Gross weight\n Country of Manufacturing\nYear of Manufacturing", txtObservI.Text, funStatus(rdoPassI, rdoFailI), "CI.13", "Test/Checks", "9)");
                    funSaveData(wCDT, "Cut minimum one sample for a randomly selected coil/drum, cut the sample cable preferably around Quarter(qtr)/middle/ 3/4th qtr length to ensure consistency in number of strands.", "Verify number of strands on both ends and at the end of cut length, measure insulation thickness on both ends and at cut length and record.", txtObservJ.Text, funStatus(rdoPassJ, rdoFailJ), "", "Test/Checks", "10)");
                }

                for (int i = 0; i < repaterTstChecks.Items.Count; i++)
                {
                    Label lblSNo = (Label)repaterTstChecks.Items[i].FindControl("lblSNo");
                    TextBox txtParameter1 = (TextBox)repaterTstChecks.Items[i].FindControl("txtParameter1");
                    TextBox txtValueSpecified = (TextBox)repaterTstChecks.Items[i].FindControl("txtValueSpecified");
                    TextBox txtObservation = (TextBox)repaterTstChecks.Items[i].FindControl("txtObservation");
                    TextBox txtRemarks = (TextBox)repaterTstChecks.Items[i].FindControl("txtRemarks");
                    RadioButton rdoTestExtra1 = (RadioButton)repaterTstChecks.Items[i].FindControl("rdoTestExtra1");
                    string SPass = (rdoTestExtra1.Checked == true ? "Pass" : "Fail");
                    funSaveData(wCDT, txtParameter1.Text, txtValueSpecified.Text, txtObservation.Text, SPass, rdoTestExtra1.Text, "Test/Checks", lblSNo.Text);
                }

            }
            pnlIV.Visible = true;
            pnlII.Visible = false;
            pnlIII.Visible = false;
            pnlI.Visible = false;
            // pnlV.Visible = false;
            //pnlIV.Visible = false;
        }

        protected void btnBack4_Click(object sender, EventArgs e)
        {
            pnlII.Visible = false;
            pnlIII.Visible = true;
            pnlI.Visible = false;
            //pnlV.Visible = false;
            pnlIV.Visible = false;
        }

        protected void btnSave4_Click(object sender, EventArgs e)
        {
            if (IsSaveValidate())
            {
                String CALL_SNO = Request.Params["CALL_SNO"].ToString();
                string str = "SELECT INSPECT_CD FROM INSPECTION_TEST_PLN WHERE CASE_NO='" + Request.Params["CASE_NO"].ToString() + "' AND CALL_SNO='" + Request.Params["CALL_SNO"].ToString() + "' and ITEM_CD='" + Convert.ToString(ViewState["Item_Code"]) + "' and CALL_RECV_DT=to_date('" + Request.Params["CALL_RECV_DT"].ToString() + "', 'dd/mm/yyyy')";
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                OracleCommand cmd2 = new OracleCommand(str, conn);
                string wCDT = Convert.ToString(cmd2.ExecuteScalar());
                if (wCDT != "")
                {
                    funSaveData(wCDT, "Heat Release Rate (MARHE i.e. Maximum Average Rate of Heat Emission in KW/ m2)", "RI (HL3)", txtObservM.Text, funStatus(rdoPassM, rdoFailM), "ISO- 5660-1 EN45545-2:2013 50 KW/m2", "Test/Checks", "m");
                    funSaveData(wCDT, "Deterioration of	visibility due to smoke", "Class A", txtObservN.Text, funStatus(rdoPassN, rdoFailN), "Appendix- 15 of UIC 564-2 OR Check	sheet QA/C&W-08 (Visibility on smoke)", "Test/Checks", "n");
                    funSaveData(wCDT, "Packing", "a)	Material shall be packed in form of Roll to ensure safe transportation.\nb)	Each cloth shall be packed in neat and dry condition. Each roll/bolt of cloth marked at	outer end (within 5cm)showing nomenclature of stores, category no. Mfr's Name & Trade mark, Month and year of Manufacture, meterage and lot no.\nc)	Each piece of upholstery fabric shall be neatly rolled on a LDPE/HDPE tube 19 mm. The roll shall then be packed with layer of polyethylene film 0.05mm. The	rolls so	packed	shall	be furtherpacked	in	a	layer of Hessian	Cloth(IS:2818). The seam of the hessian packed should be sewn with twine jute supply. While Stitching, care shall be taken to avoid damage to fabric.", txtObservO.Text, funStatus(rdoPassO, rdoFailO), "", "Test/Checks", "o");
                    funSaveData(wCDT, "Marking", "Each pack shall be legibly marked with indelible marking ink/paint showing the following details:\na) Nomenclature & category no of the store\nb) Qty packed, Total no. of rolls and total meterage\nc) Lot no. and sl. No.\nd) Month and year of packing\ne) Name	and	trade	mark	of	the manufacturer\nf) Name and address of the consignee\ng) Inspector's stamp\nh) PO No and date", txtObservP.Text, funStatus(rdoPassP, rdoFailP), "", "Test/Checks", "p");
                }
                conn.Close();
            }



            //Repeater[] rpt = new Repeater[6];
            //rpt[0] = rpt1;
            //rpt[1] = rpt2;
            //rpt[2] = rpt3;
            //rpt[3] = rpt4;
            //rpt[4] = rpt5;
            //rpt[5] = rpt6;
            //string[] txt = new string[6];
            //txt[0] = txtRange1.Text;
            //txt[1] = txtRange2.Text;
            //txt[2] = txtRange3.Text;
            //txt[3] = txtRange4.Text;
            //txt[4] = txtRange5.Text;
            //txt[5] = txtRange6.Text;

            //SaveDimensionType(rpt, txt, "Dimensions (in mm)");

            //Repeater[] rpt = new Repeater[5];
            //rpt[0] = Rept11;
            //rpt[1] = Rept12;
            //rpt[2] = Rept13;
            //rpt[3] = Rept14;
            //rpt[4] = Rept15;
            //string[] txt = new string[5];
            //txt[0] = txt11.Text;
            //txt[1] = txt12.Text;
            //txt[2] = txt13.Text;
            //txt[3] = txt14.Text;
            //txt[4] = txt15.Text;

            //SaveDimensionType(rpt, txt, "Chemical test of Billet ");


            //rpt = new Repeater[7];
            //rpt[0] = Rept31;
            //rpt[1] = Rept32;
            //rpt[2] = Rept33;
            //rpt[3] = Rept34;
            //rpt[4] = Rept35;
            //rpt[5] = Rept36;
            //rpt[6] = Rept37;
            //txt = new string[7];
            //txt[0] = txt31.Text;
            //txt[1] = txt32.Text;
            //txt[2] = txt33.Text;
            //txt[3] = txt34.Text;
            //txt[4] = txt35.Text;
            //txt[5] = txt36.Text;
            //txt[6] = txt37.Text;

            //SaveDimensionType(rpt, txt, "Physical test ");

            pnlII.Visible = false;
            pnlIII.Visible = false;
            pnlI.Visible = false;
            //pnlV.Visible = true;
            pnlIV.Visible = false;
        }
        protected void btnNoOfPices_Click(object sender, EventArgs e)
        {
            funBindGrdDimension();
        }

        private DataTable funGetData(string HeaderCode, int totalColumn, string Header_Code)
        {


            OracleCommand cmd = new OracleCommand();
            string sQuery = "SELECT * FROM INSPECTION_TST_PLNDIM_TRAN WHERE  INSPECT_CD='" + Convert.ToString(ViewState["INSPECT_CD"]) + "' and DIMPARAMETER='" + HeaderCode + "' and HEADER_CODE='" + Header_Code + "'";
            cmd.CommandText = sQuery;
            cmd.Connection = conn;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            OracleDataReader readerB1 = cmd.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("ObserValue1", typeof(string));
            while (readerB1.Read())
            {
                DataRow dr1 = dt1.NewRow();
                dr1["ObserValue1"] = Convert.ToString(readerB1["DIMVALUES"]);
                dt1.Rows.Add(dr1);
            }
            if (totalColumn <= dt1.Rows.Count)
            {
                totalColumn = dt1.Rows.Count;
            }
            else
            {
                totalColumn = totalColumn - dt1.Rows.Count;
                for (int i = 0; i < totalColumn; i++)
                {
                    DataRow dr = dt1.NewRow();
                    dt1.Rows.Add(dr);
                }
            }
            conn.Close();
            return dt1;
        }

        private void funBindGrdDimension()
        {
            DataTable dt = new DataTable();


            int totalColumn = 0;


            bool success = false;// Int32.TryParse(txtManualEntry.Text, out totalColumn);
            try
            {
                totalColumn = Convert.ToInt32(txtManualEntry.Text);
                success = true;
            }
            catch
            {
                success = false;
            }
            if (success == false)
            {
                totalColumn = 5;
            }

            litHeadDimension.Text = "Observed Values";// "<td style=\"font-size: 8pt; color: darkblue; width:65%; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top; text-align: center; font-weight: bold;\"  colspan=\"" + totalColumn + "\">Observed Values</td>";

            rpt0.DataSource = funGetData("As Per P.O", totalColumn, "Dimensions");
            rpt0.DataBind();
            rpt1.DataSource = funGetData("As Per P.O", totalColumn, "Dimensions");
            rpt1.DataBind();

            rpt2.DataSource = funGetData("Thickness of covering/Insulation Average(Min)", totalColumn, "Dimensions");
            rpt2.DataBind();
            rpt3.DataSource = funGetData("Thickness of  covering /Insulation  (Minimum)", totalColumn, "Dimensions");
            rpt3.DataBind();
            rpt4.DataSource = funGetData("Conductor Resistance( in 0/Km at 20 degree centigrade)", totalColumn, "Dimensions");
            rpt4.DataBind();
            rpt5.DataSource = funGetData("High Voltage Test: (1 KV for 5 Minutes)", totalColumn, "Dimensions");
            rpt5.DataBind();
            rpt6.DataSource = funGetData("Length Verification of/Drum/Reel", totalColumn, "Dimensions");
            rpt6.DataBind();
            int NoofRecord = 0;
            int noOfmanual = 0;
            bool IsNoofRecord = false;
            bool IsnoOfmanual = false;
            try
            {
                NoofRecord = Convert.ToInt32(txtNoOfPices.Text);
                IsNoofRecord = true;
            }
            catch
            {
                IsNoofRecord = false;
            }
            try
            {
                noOfmanual = Convert.ToInt32(txtManualEntry.Text);
                IsnoOfmanual = true;
            }
            catch
            {
                IsnoOfmanual = false;
            }
            if (IsNoofRecord)
            {
                if (IsnoOfmanual)
                {
                    if (noOfmanual < NoofRecord)
                    {
                        txtRange.Text = (noOfmanual + 1).ToString() + " to " + txtNoOfPices.Text;
                        txtRange1.Visible = true;
                        txtRange2.Visible = true;
                        txtRange3.Visible = true;
                        txtRange4.Visible = true;
                        txtRange5.Visible = true;
                        txtRange6.Visible = true;
                    }
                    else
                    {
                        txtRange.Text = (noOfmanual).ToString() + " to " + txtNoOfPices.Text;
                        txtRange1.Visible = false;
                        txtRange2.Visible = false;
                        txtRange3.Visible = false;
                        txtRange4.Visible = false;
                        txtRange5.Visible = false;
                        txtRange6.Visible = false;
                    }
                }
            }
        }
        protected void btnNoOfPices2_Click(object sender, EventArgs e)
        {
            funBindGrdDimension2();
        }
        private void funBindGrdDimension2()
        {
            DataTable dt = new DataTable();

            int totalColumn = 0;
            bool success = false;// Int32.TryParse(txtManualEntry.Text, out totalColumn);
            try
            {
                totalColumn = Convert.ToInt32(txtManualEntry.Text);
                success = true;
            }
            catch
            {
                success = false;
            }
            if (success == false)
            {
                totalColumn = 5;
            }
            if (success == false)
            {
                totalColumn = 5;
            }
            Rept10.DataSource = funGetData("C =", totalColumn, "Chemical test of Billet ");
            Rept10.DataBind();
            Rept11.DataSource = funGetData("C =", totalColumn, "Chemical test of Billet ");
            Rept11.DataBind();
            Rept12.DataSource = funGetData("Si =", totalColumn, "Chemical test of Billet ");
            Rept12.DataBind();
            Rept13.DataSource = funGetData("Mn=", totalColumn, "Chemical test of Billet ");
            Rept13.DataBind();
            Rept14.DataSource = funGetData("P =", totalColumn, "Chemical test of Billet ");
            Rept14.DataBind();
            Rept15.DataSource = funGetData("S =", totalColumn, "Chemical test of Billet ");
            Rept15.DataBind();


            litHeadDimension2.Text = "Observed Values";// "<td style=\"font-size: 8pt; color: darkblue; width:65%; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top; text-align: center; font-weight: bold;\"  colspan=\"" + totalColumn + "\">Observed Values</td>";

            int NoofRecord = 0;
            int noOfmanual = 0;
            bool IsNoofRecord = false;
            bool IsnoOfmanual = false;
            try
            {
                NoofRecord = Convert.ToInt32(txtNoOfPices.Text);
                IsNoofRecord = true;
            }
            catch
            {
                IsNoofRecord = false;
            }
            try
            {
                noOfmanual = Convert.ToInt32(txtManualEntry.Text);
                IsnoOfmanual = true;
            }
            catch
            {
                IsnoOfmanual = false;
            }
            if (IsNoofRecord)
            {
                if (IsnoOfmanual)
                {
                    if (noOfmanual < NoofRecord)
                    {
                        txtRanges2.Text = (noOfmanual + 1).ToString() + " to " + txtNoOfPices2.Text;
                        txt11.Visible = true;
                        txt12.Visible = true;
                        txt13.Visible = true;
                        txt14.Visible = true;
                        txt15.Visible = true;
                    }
                    else
                    {
                        txtRanges2.Text = (noOfmanual).ToString() + " to " + txtNoOfPices2.Text;
                        txt11.Visible = false;
                        txt12.Visible = false;
                        txt13.Visible = false;
                        txt14.Visible = false;
                        txt15.Visible = false;
                    }
                }
            }
        }

        protected void btnNoOfPices3_Click(object sender, EventArgs e)
        {
            funBindGrdDimension3();
        }
        private void funBindGrdDimension3()
        {
            DataTable dt = new DataTable();

            int totalColumn = 0;
            bool success = false;// Int32.TryParse(txtManualEntry.Text, out totalColumn);
            try
            {
                totalColumn = Convert.ToInt32(txtManualEntry.Text);
                success = true;
            }
            catch
            {
                success = false;
            }
            if (success == false)
            {
                totalColumn = 5;
            }
            if (success == false)
            {
                totalColumn = 5;
            }
            Rept30.DataSource = funGetData("Heat/ Cast no.", totalColumn, "Physical test ");
            Rept30.DataBind();
            Rept31.DataSource = funGetData("Heat/ Cast no.", totalColumn, "Physical test ");
            Rept31.DataBind();
            Rept32.DataSource = funGetData("(a)UTS", totalColumn, "Physical test ");
            Rept32.DataBind();
            Rept33.DataSource = funGetData("(b)Yst", totalColumn, "Physical test ");
            Rept33.DataBind();
            Rept34.DataSource = funGetData("(c)Elongation", totalColumn, "Physical test ");
            Rept34.DataBind();
            Rept35.DataSource = funGetData("(d) Hardness", totalColumn, "Physical test ");
            Rept35.DataBind();
            Rept36.DataSource = funGetData("(e)Macrostru cture— when etched transverse section as per IS:11371/198 5 ", totalColumn, "Physical test ");
            Rept36.DataBind();
            Rept37.DataSource = funGetData("Grain size as per IS:4748-1988", totalColumn, "Physical test ");
            Rept37.DataBind();


            litHeadDimension3.Text = "Observed Values";// "<td style=\"font-size: 8pt; color: darkblue; width:65%; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top; text-align: center; font-weight: bold;\"  colspan=\"" + totalColumn + "\">Observed Values</td>";

            int NoofRecord = 0;
            int noOfmanual = 0;
            bool IsNoofRecord = false;
            bool IsnoOfmanual = false;
            try
            {
                NoofRecord = Convert.ToInt32(txtNoOfPices.Text);
                IsNoofRecord = true;
            }
            catch
            {
                IsNoofRecord = false;
            }
            try
            {
                noOfmanual = Convert.ToInt32(txtManualEntry.Text);
                IsnoOfmanual = true;
            }
            catch
            {
                IsnoOfmanual = false;
            }
            if (IsNoofRecord)
            {
                if (IsnoOfmanual)
                {
                    if (noOfmanual < NoofRecord)
                    {
                        txtRanges3.Text = (noOfmanual + 1).ToString() + " to " + txtNoOfPices2.Text;
                        txt31.Visible = true;
                        txt32.Visible = true;
                        txt33.Visible = true;
                        txt34.Visible = true;
                        txt35.Visible = true;
                        txt36.Visible = true;
                        txt37.Visible = true;
                    }
                    else
                    {
                        txtRanges3.Text = (noOfmanual).ToString() + " to " + txtNoOfPices2.Text;
                        txt31.Visible = false;
                        txt32.Visible = false;
                        txt33.Visible = false;
                        txt34.Visible = false;
                        txt35.Visible = false;
                        txt36.Visible = false;
                        txt37.Visible = false;

                    }
                }
            }
        }

        protected void btnNoOfPices4_Click(object sender, EventArgs e)
        {
            funBindGrdDimension4();
        }
        private void funBindGrdDimension4()
        {
            DataTable dt = new DataTable();
            int totalColumn = 0;
            bool success = false;// Int32.TryParse(txtManualEntry.Text, out totalColumn);
            try
            {
                totalColumn = Convert.ToInt32(txtManualEntry.Text);
                success = true;
            }
            catch
            {
                success = false;
            }
            if (success == false)
            {
                totalColumn = 5;
            }
            if (success == false)
            {
                totalColumn = 5;
            }
            Rept40.DataSource = funGetData("C =", totalColumn, "Chemical test of Fish plate");
            Rept40.DataBind();
            Rept41.DataSource = funGetData("C =", totalColumn, "Chemical test of Fish plate");
            Rept41.DataBind();
            Rept42.DataSource = funGetData("Si =", totalColumn, "Chemical test of Fish plate");
            Rept42.DataBind();
            Rept43.DataSource = funGetData("Mn=", totalColumn, "Chemical test of Fish plate");
            Rept43.DataBind();
            Rept44.DataSource = funGetData("P =", totalColumn, "Chemical test of Fish plate");
            Rept44.DataBind();
            Rept45.DataSource = funGetData("S =", totalColumn, "Chemical test of Fish plate");
            Rept45.DataBind();

            litHeadDimension4.Text = "Observed Values";// "<td style=\"font-size: 8pt; color: darkblue; width:65%; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top; text-align: center; font-weight: bold;\"  colspan=\"" + totalColumn + "\">Observed Values</td>";

            Rept45.DataBind();
            int NoofRecord = 0;
            int noOfmanual = 0;
            bool IsNoofRecord = false;
            bool IsnoOfmanual = false;
            try
            {
                NoofRecord = Convert.ToInt32(txtNoOfPices.Text);
                IsNoofRecord = true;
            }
            catch
            {
                IsNoofRecord = false;
            }
            try
            {
                noOfmanual = Convert.ToInt32(txtManualEntry.Text);
                IsnoOfmanual = true;
            }
            catch
            {
                IsnoOfmanual = false;
            }
            if (IsNoofRecord)
            {
                if (IsnoOfmanual)
                {
                    if (noOfmanual < NoofRecord)
                    {
                        txtRanges4.Text = (noOfmanual + 1).ToString() + " to " + txtNoOfPices4.Text;
                        txt41.Visible = true;
                        txt42.Visible = true;
                        txt43.Visible = true;
                        txt44.Visible = true;
                        txt45.Visible = true;
                    }
                    else
                    {
                        txtRanges4.Text = (noOfmanual).ToString() + " to " + txtNoOfPices4.Text;
                        txt41.Visible = false;
                        txt42.Visible = false;
                        txt43.Visible = false;
                        txt44.Visible = false;
                        txt45.Visible = false;
                    }
                }
            }
        }
        private void funBindGrdDimension5()
        {
            DataTable dt = new DataTable();
            int totalColumn = 0;
            bool success = false;// Int32.TryParse(txtManualEntry.Text, out totalColumn);
            try
            {
                totalColumn = Convert.ToInt32(txtManualEntry.Text);
                success = true;
            }
            catch
            {
                success = false;
            }
            if (success == false)
            {
                totalColumn = 5;
            }
            if (success == false)
            {
                totalColumn = 5;
            }
            Rept50.DataSource = funGetData("(a)UTS", totalColumn, "Physical test of Fish plate");
            Rept50.DataBind();
            Rept51.DataSource = funGetData("Heat/ Cast no.", totalColumn, "Physical test of Fish plate");
            Rept51.DataBind();
            Rept52.DataSource = funGetData("(a)UTS", totalColumn, "Physical test of Fish plate");
            Rept52.DataBind();
            Rept53.DataSource = funGetData("(b)Yst", totalColumn, "Physical test of Fish plate");
            Rept53.DataBind();
            Rept54.DataSource = funGetData("(c)Elongation", totalColumn, "Physical test of Fish plate");
            Rept54.DataBind();
            Rept55.DataSource = funGetData("(d) Hardness", totalColumn, "Physical test of Fish plate");
            Rept55.DataBind();
            Rept56.DataSource = funGetData("(e)Macrostru cture— when etched transverse section as per IS:11371/198 5", totalColumn, "Physical test of Fish plate");
            Rept56.DataBind();
            Rept57.DataSource = funGetData("(f)Grain size as per IS:4748-1988", totalColumn, "Physical test of Fish plate");
            Rept57.DataBind();

            litHeadDimension5.Text = "Observed Values";// "<td style=\"font-size: 8pt; color: darkblue; width:65%; font-family: Verdana; height: 9px; padding-left: 10px; vertical-align: top; text-align: center; font-weight: bold;\"  colspan=\"" + totalColumn + "\">Observed Values</td>";

            int NoofRecord = 0;
            int noOfmanual = 0;
            bool IsNoofRecord = false;
            bool IsnoOfmanual = false;
            try
            {
                NoofRecord = Convert.ToInt32(txtNoOfPices.Text);
                IsNoofRecord = true;
            }
            catch
            {
                IsNoofRecord = false;
            }
            try
            {
                noOfmanual = Convert.ToInt32(txtManualEntry.Text);
                IsnoOfmanual = true;
            }
            catch
            {
                IsnoOfmanual = false;
            }
            if (IsNoofRecord)
            {
                if (IsnoOfmanual)
                {
                    if (noOfmanual < NoofRecord)
                    {
                        txtRanges5.Text = (noOfmanual + 1).ToString() + " to " + txtNoOfPices5.Text;
                    }
                    else
                    {
                        txtRanges5.Text = (noOfmanual).ToString() + " to " + txtNoOfPices5.Text;
                        txt51.Visible = false;
                        txt52.Visible = false;
                        txt53.Visible = false;
                        txt54.Visible = false;
                        txt55.Visible = false;
                        txt56.Visible = false;
                        txt57.Visible = false;
                    }
                }
            }
        }

        protected void btnNoOfPices5_Click(object sender, EventArgs e)
        {
            funBindGrdDimension5();
        }

        protected void btnBack5_Click(object sender, EventArgs e)
        {
            pnlII.Visible = false;
            pnlIII.Visible = false;
            pnlI.Visible = false;
            pnlV.Visible = false;
            pnlIV.Visible = true;
        }
        protected void btnSave5_Click(object sender, EventArgs e)
        {
            Repeater[] rpt = new Repeater[5];
            rpt[0] = Rept41;
            rpt[1] = Rept42;
            rpt[2] = Rept43;
            rpt[3] = Rept44;
            rpt[4] = Rept45;
            string[] txt = new string[5];
            txt[0] = txt41.Text;
            txt[1] = txt42.Text;
            txt[2] = txt43.Text;
            txt[3] = txt44.Text;
            txt[4] = txt45.Text;

            SaveDimensionType(rpt, txt, "Chemical test of Fish plate");


            rpt = new Repeater[7];
            rpt[0] = Rept51;
            rpt[1] = Rept52;
            rpt[2] = Rept53;
            rpt[3] = Rept54;
            rpt[4] = Rept55;
            rpt[5] = Rept56;
            rpt[6] = Rept57;
            txt = new string[7];
            txt[0] = txt51.Text;
            txt[1] = txt52.Text;
            txt[2] = txt53.Text;
            txt[3] = txt54.Text;
            txt[4] = txt55.Text;
            txt[5] = txt56.Text;
            txt[6] = txt57.Text;

            SaveDimensionType(rpt, txt, "Physical test of Fish plate");
        }        
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (IsSaveValidate())
            {
                string sQuery = "UPDATE INSPECTION_TEST_PLN SET FILE_PATH=:PFILE_PATH, FILE_PATH2=:PFILE_PATH2, FILE_PATH3=:PFILE_PATH3, FILE_PATH4=:PFILE_PATH4, FILE_PATH5=:PFILE_PATH5 WHERE INSPECT_CD=:PINSPECT_CD";

                OracleCommand myUpdateCallStatusCommand = new OracleCommand(sQuery, conn);
                string FName = "";
                conn.Open();
                myUpdateCallStatusCommand.Parameters.Add(funParameter("PINSPECT_CD", "string", 30, Convert.ToString(ViewState["INSPECT_CD"])));

                FName = "";
                if (File1.PostedFile != null && File1.PostedFile.ContentLength > 0)
                {
                    string fn = "", fx = "", MyFile = "";
                    MyFile = txtCaseNo.Text.Trim() + "-" + txtBookNo.Text + "-" + txtSetNo.Text + "-" + "01";
                    fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
                    fx = System.IO.Path.GetExtension(File1.PostedFile.FileName).ToUpper().Substring(1);

                    String SaveLocation = null;
                    FName = "";
                    FName = MyFile + "." + fx;
                    SaveLocation = Server.MapPath("LabReports/" + MyFile + "." + fx);
                    File1.PostedFile.SaveAs(SaveLocation);
                    litFileUpdate.Text = "<a href='LabReports/" + Convert.ToString(FName) + "' target=\"_blank\">Download</a>";
                    fileDelete.Visible = true;

                }
                myUpdateCallStatusCommand.Parameters.Add(funParameter("PFILE_PATH", "string", 500, FName));

                FName = "";
                if (File2.PostedFile != null && File2.PostedFile.ContentLength > 0)
                {
                    string fn = "", fx = "", MyFile = "";
                    MyFile = txtCaseNo.Text.Trim() + "-" + txtBookNo.Text + "-" + txtSetNo.Text + "-" + "01";
                    fn = System.IO.Path.GetFileName(File2.PostedFile.FileName);
                    fx = System.IO.Path.GetExtension(File2.PostedFile.FileName).ToUpper().Substring(1);

                    String SaveLocation = null;
                    FName = "";
                    FName = MyFile + "." + fx;
                    SaveLocation = Server.MapPath("LabReports/" + MyFile + "." + fx);
                    File2.PostedFile.SaveAs(SaveLocation);
                    litFileUpdate2.Text = "<a href='LabReports/" + Convert.ToString(FName) + "' target=\"_blank\">Download</a>";
                    fileDelete2.Visible = true;

                }
                myUpdateCallStatusCommand.Parameters.Add(funParameter("PFILE_PATH2", "string", 500, FName));

                FName = "";
                if (File3.PostedFile != null && File3.PostedFile.ContentLength > 0)
                {
                    string fn = "", fx = "", MyFile = "";
                    MyFile = txtCaseNo.Text.Trim() + "-" + txtBookNo.Text + "-" + txtSetNo.Text + "-" + "01";
                    fn = System.IO.Path.GetFileName(File3.PostedFile.FileName);
                    fx = System.IO.Path.GetExtension(File3.PostedFile.FileName).ToUpper().Substring(1);

                    String SaveLocation = null;
                    FName = "";
                    FName = MyFile + "." + fx;
                    SaveLocation = Server.MapPath("LabReports/" + MyFile + "." + fx);
                    File3.PostedFile.SaveAs(SaveLocation);
                    litFileUpdate3.Text = "<a href='LabReports/" + Convert.ToString(FName) + "' target=\"_blank\">Download</a>";
                    fileDelete3.Visible = true;

                }
                myUpdateCallStatusCommand.Parameters.Add(funParameter("PFILE_PATH3", "string", 500, FName));

                FName = "";
                if (File4.PostedFile != null && File4.PostedFile.ContentLength > 0)
                {
                    string fn = "", fx = "", MyFile = "";
                    MyFile = txtCaseNo.Text.Trim() + "-" + txtBookNo.Text + "-" + txtSetNo.Text + "-" + "01";
                    fn = System.IO.Path.GetFileName(File4.PostedFile.FileName);
                    fx = System.IO.Path.GetExtension(File4.PostedFile.FileName).ToUpper().Substring(1);

                    String SaveLocation = null;
                    FName = "";
                    FName = MyFile + "." + fx;
                    SaveLocation = Server.MapPath("LabReports/" + MyFile + "." + fx);
                    File4.PostedFile.SaveAs(SaveLocation);
                    litFileUpdate4.Text = "<a href='LabReports/" + Convert.ToString(FName) + "' target=\"_blank\">Download</a>";
                    fileDelete4.Visible = true;

                }
                myUpdateCallStatusCommand.Parameters.Add(funParameter("PFILE_PATH4", "string", 500, FName));

                FName = "";
                if (File5.PostedFile != null && File5.PostedFile.ContentLength > 0)
                {
                    string fn = "", fx = "", MyFile = "";
                    MyFile = txtCaseNo.Text.Trim() + "-" + txtBookNo.Text + "-" + txtSetNo.Text + "-" + "01";
                    fn = System.IO.Path.GetFileName(File5.PostedFile.FileName);
                    fx = System.IO.Path.GetExtension(File5.PostedFile.FileName).ToUpper().Substring(1);

                    String SaveLocation = null;
                    FName = "";
                    FName = MyFile + "." + fx;
                    SaveLocation = Server.MapPath("LabReports/" + MyFile + "." + fx);
                    File5.PostedFile.SaveAs(SaveLocation);
                    litFileUpdate5.Text = "<a href='LabReports/" + Convert.ToString(FName) + "' target=\"_blank\">Download</a>";
                    fileDelete5.Visible = true;

                }
                myUpdateCallStatusCommand.Parameters.Add(funParameter("PFILE_PATH5", "string", 500, FName));

                myUpdateCallStatusCommand.Connection = conn;
                myUpdateCallStatusCommand.ExecuteNonQuery();
            }
        }
        protected void fileDelete_Click(object sender, ImageClickEventArgs e)
        {

            string SvrPath = Server.MapPath("LabReports/");
            ImageButton btn = (ImageButton)sender;
            if (btn == fileDelete)
            {
                string str = "SELECT FILE_PATH FROM INSPECTION_TEST_PLN WHERE INSPECT_CD='" + Convert.ToString(ViewState["INSPECT_CD"]) + "' AND CALL_SNO='" + Request.Params["CALL_SNO"].ToString() + "' and ITEM_CD='" + Convert.ToString(ViewState["Item_Code"]) + "' and CASE_NO='" + Request.Params["CASE_NO"].ToString() + "' and CALL_RECV_DT=to_date('" + Request.Params["CALL_RECV_DT"].ToString() + "', 'dd/mm/yyyy')";
                conn.Open();
                OracleCommand cmd2 = new OracleCommand(str, conn);
                string wCDT = Convert.ToString(cmd2.ExecuteScalar());
                if (wCDT != "")
                {
                    if (System.IO.File.Exists(SvrPath + wCDT))
                    {
                        string sQuery = "UPDATE INSPECTION_TEST_PLN SET FILE_PATH=:PFILE_PATH WHERE INSPECT_CD=:PINSPECT_CD";
                        OracleCommand myUpdateCallStatusCommand = new OracleCommand(sQuery, conn);


                        myUpdateCallStatusCommand.Parameters.Add(funParameter("PINSPECT_CD", "string", 30, Convert.ToString(ViewState["INSPECT_CD"])));
                        //myUpdateCallStatusCommand.Parameters.Add(new System.Data.OracleClient.OracleParameter("PINSPECT_CD",  Convert.ToString(ViewState["INSPECT_CD"])));
                        myUpdateCallStatusCommand.Parameters.Add(funParameter("PFILE_PATH", "string", 30, ""));
                        //new System.Data.OracleClient.OracleParameter("PFILE_PATH", ""));
                        myUpdateCallStatusCommand.Connection = conn;
                        myUpdateCallStatusCommand.ExecuteNonQuery();
                        conn.Close();
                        System.IO.File.Delete(SvrPath + wCDT);

                        litFileUpdate.Text = "";
                        fileDelete.Visible = false;
                    }
                }
            }
            else if (btn == fileDelete2)
            {
                string str = "SELECT FILE_PATH2 FROM INSPECTION_TEST_PLN WHERE INSPECT_CD='" + Convert.ToString(ViewState["INSPECT_CD"]) + "' AND CALL_SNO='" + Request.Params["CALL_SNO"].ToString() + "' and ITEM_CD='" + Convert.ToString(ViewState["Item_Code"]) + "' and CASE_NO='" + Request.Params["CASE_NO"].ToString() + "' and CALL_RECV_DT=to_date('" + Request.Params["CALL_RECV_DT"].ToString() + "', 'dd/mm/yyyy')";
                conn.Open();
                OracleCommand cmd2 = new OracleCommand(str, conn);
                string wCDT = Convert.ToString(cmd2.ExecuteScalar());
                if (wCDT != "")
                {
                    if (System.IO.File.Exists(SvrPath + wCDT))
                    {
                        string sQuery = "UPDATE INSPECTION_TEST_PLN SET FILE_PATH2=:PFILE_PATH WHERE INSPECT_CD=:PINSPECT_CD";
                        OracleCommand myUpdateCallStatusCommand = new OracleCommand(sQuery, conn);


                        myUpdateCallStatusCommand.Parameters.Add(funParameter("PINSPECT_CD", "string", 30, Convert.ToString(ViewState["INSPECT_CD"])));
                        //myUpdateCallStatusCommand.Parameters.Add(new System.Data.OracleClient.OracleParameter("PINSPECT_CD",  Convert.ToString(ViewState["INSPECT_CD"])));
                        myUpdateCallStatusCommand.Parameters.Add(funParameter("PFILE_PATH", "string", 30, ""));
                        //new System.Data.OracleClient.OracleParameter("PFILE_PATH", ""));
                        myUpdateCallStatusCommand.Connection = conn;
                        myUpdateCallStatusCommand.ExecuteNonQuery();
                        conn.Close();
                        System.IO.File.Delete(SvrPath + wCDT);

                        litFileUpdate2.Text = "";
                        fileDelete2.Visible = false;
                    }
                }
            }
            else if (btn == fileDelete3)
            {
                string str = "SELECT FILE_PATH3 FROM INSPECTION_TEST_PLN WHERE INSPECT_CD='" + Convert.ToString(ViewState["INSPECT_CD"]) + "' AND CALL_SNO='" + Request.Params["CALL_SNO"].ToString() + "' and ITEM_CD='" + Convert.ToString(ViewState["Item_Code"]) + "' and CASE_NO='" + Request.Params["CASE_NO"].ToString() + "' and CALL_RECV_DT=to_date('" + Request.Params["CALL_RECV_DT"].ToString() + "', 'dd/mm/yyyy')";
                conn.Open();
                OracleCommand cmd2 = new OracleCommand(str, conn);
                string wCDT = Convert.ToString(cmd2.ExecuteScalar());
                if (wCDT != "")
                {
                    if (System.IO.File.Exists(SvrPath + wCDT))
                    {
                        string sQuery = "UPDATE INSPECTION_TEST_PLN SET FILE_PATH3=:PFILE_PATH WHERE INSPECT_CD=:PINSPECT_CD";
                        OracleCommand myUpdateCallStatusCommand = new OracleCommand(sQuery, conn);


                        myUpdateCallStatusCommand.Parameters.Add(funParameter("PINSPECT_CD", "string", 30, Convert.ToString(ViewState["INSPECT_CD"])));
                        //myUpdateCallStatusCommand.Parameters.Add(new System.Data.OracleClient.OracleParameter("PINSPECT_CD",  Convert.ToString(ViewState["INSPECT_CD"])));
                        myUpdateCallStatusCommand.Parameters.Add(funParameter("PFILE_PATH", "string", 30, ""));
                        //new System.Data.OracleClient.OracleParameter("PFILE_PATH", ""));
                        myUpdateCallStatusCommand.Connection = conn;
                        myUpdateCallStatusCommand.ExecuteNonQuery();
                        conn.Close();
                        System.IO.File.Delete(SvrPath + wCDT);

                        litFileUpdate3.Text = "";
                        fileDelete3.Visible = false;
                    }
                }
            }
            else if (btn == fileDelete4)
            {
                string str = "SELECT FILE_PATH4 FROM INSPECTION_TEST_PLN WHERE INSPECT_CD='" + Convert.ToString(ViewState["INSPECT_CD"]) + "' AND CALL_SNO='" + Request.Params["CALL_SNO"].ToString() + "' and ITEM_CD='" + Convert.ToString(ViewState["Item_Code"]) + "' and CASE_NO='" + Request.Params["CASE_NO"].ToString() + "' and CALL_RECV_DT=to_date('" + Request.Params["CALL_RECV_DT"].ToString() + "', 'dd/mm/yyyy')";
                conn.Open();
                OracleCommand cmd2 = new OracleCommand(str, conn);
                string wCDT = Convert.ToString(cmd2.ExecuteScalar());
                if (wCDT != "")
                {
                    if (System.IO.File.Exists(SvrPath + wCDT))
                    {
                        string sQuery = "UPDATE INSPECTION_TEST_PLN SET FILE_PATH4=:PFILE_PATH WHERE INSPECT_CD=:PINSPECT_CD";
                        OracleCommand myUpdateCallStatusCommand = new OracleCommand(sQuery, conn);


                        myUpdateCallStatusCommand.Parameters.Add(funParameter("PINSPECT_CD", "string", 30, Convert.ToString(ViewState["INSPECT_CD"])));
                        //myUpdateCallStatusCommand.Parameters.Add(new System.Data.OracleClient.OracleParameter("PINSPECT_CD",  Convert.ToString(ViewState["INSPECT_CD"])));
                        myUpdateCallStatusCommand.Parameters.Add(funParameter("PFILE_PATH", "string", 30, ""));
                        //new System.Data.OracleClient.OracleParameter("PFILE_PATH", ""));
                        myUpdateCallStatusCommand.Connection = conn;
                        myUpdateCallStatusCommand.ExecuteNonQuery();
                        conn.Close();
                        System.IO.File.Delete(SvrPath + wCDT);

                        litFileUpdate4.Text = "";
                        fileDelete4.Visible = false;
                    }
                }
            }
            else if (btn == fileDelete5)
            {
                string str = "SELECT FILE_PATH5 FROM INSPECTION_TEST_PLN WHERE INSPECT_CD='" + Convert.ToString(ViewState["INSPECT_CD"]) + "' AND CALL_SNO='" + Request.Params["CALL_SNO"].ToString() + "' and ITEM_CD='" + Convert.ToString(ViewState["Item_Code"]) + "' and CASE_NO='" + Request.Params["CASE_NO"].ToString() + "' and CALL_RECV_DT=to_date('" + Request.Params["CALL_RECV_DT"].ToString() + "', 'dd/mm/yyyy')";
                conn.Open();
                OracleCommand cmd2 = new OracleCommand(str, conn);
                string wCDT = Convert.ToString(cmd2.ExecuteScalar());
                if (wCDT != "")
                {
                    if (System.IO.File.Exists(SvrPath + wCDT))
                    {
                        string sQuery = "UPDATE INSPECTION_TEST_PLN SET FILE_PATH5=:PFILE_PATH WHERE INSPECT_CD=:PINSPECT_CD";
                        OracleCommand myUpdateCallStatusCommand = new OracleCommand(sQuery, conn);


                        myUpdateCallStatusCommand.Parameters.Add(funParameter("PINSPECT_CD", "string", 30, Convert.ToString(ViewState["INSPECT_CD"])));
                        //myUpdateCallStatusCommand.Parameters.Add(new System.Data.OracleClient.OracleParameter("PINSPECT_CD",  Convert.ToString(ViewState["INSPECT_CD"])));
                        myUpdateCallStatusCommand.Parameters.Add(funParameter("PFILE_PATH", "string", 30, ""));
                        //new System.Data.OracleClient.OracleParameter("PFILE_PATH", ""));
                        myUpdateCallStatusCommand.Connection = conn;
                        myUpdateCallStatusCommand.ExecuteNonQuery();
                        conn.Close();
                        System.IO.File.Delete(SvrPath + wCDT);

                        litFileUpdate5.Text = "";
                        fileDelete5.Visible = false;
                    }
                }

            }

        }
        private void SaveFinalStatement()
        {
            conn.Open();
            // System.Data.OracleClient.OracleTransaction myTrans = conn.BeginTransaction();
            string sQuery = "UPDATE INSPECTION_TEST_PLN SET FINAL_STATEMENT=:PFINAL_STATEMENT, FINAL_STATEMENT_STATUS=:PFINAL_STATEMENT_STATUS WHERE INSPECT_CD=:PINSPECT_CD";
            OracleCommand myUpdateCallStatusCommand = new OracleCommand(sQuery, conn);
            string CALL_SNO = Request.Params["CALL_SNO"].ToString();
            string FinalStatus = (rdoFinalStatementPass.Checked == true ? "Pass" : "Fail");
            //myUpdateCallStatusCommand.Parameters.Add(new System.Data.OracleClient.OracleParameter("PINSPECT_CD", Convert.ToString(ViewState["INSPECT_CD"])));
            myUpdateCallStatusCommand.Parameters.Add(funParameter("PINSPECT_CD", "string", 30, Convert.ToString(ViewState["INSPECT_CD"])));
            myUpdateCallStatusCommand.Parameters.Add(funParameter("PFINAL_STATEMENT", "string", 4000, txtFinalStatement.Text));
            myUpdateCallStatusCommand.Parameters.Add(funParameter("PFINAL_STATEMENT_STATUS", "string", 20, FinalStatus));
            //myUpdateCallStatusCommand.Transaction = myTrans;
            myUpdateCallStatusCommand.Connection = conn;
            myUpdateCallStatusCommand.ExecuteNonQuery();
            funtxtValidate(txtFinalStatement, rdoFinalStatementPass, rdoFinalStatementFail, FinalStatus);

            string CASE_NO, CALL_RECV_DT, IE_CD, ACTIONAR, ACTION;
            CASE_NO = Request.Params["CASE_NO"].ToString();
            CALL_RECV_DT = Request.Params["CALL_RECV_DT"].ToString();
            IE_CD = Request.Params["IE_CD"].ToString();
            ACTIONAR = Request.Params["ACTIONAR"].ToString();
            ACTION = Request.Params["ACTION"].ToString();


            //litgotohome.Text = "<a href='/RBS/IC_InspectionTstPln.aspx?CASE_NO=" + CASE_NO + "&CALL_RECV_DT=" + CALL_RECV_DT + "&CALL_SNO=" + CALL_SNO + "&IE_CD=" + IE_CD + "&ACTIONAR=" + ACTIONAR + "&ACTION=" + ACTION + "&INSPECT_CD=" +  Convert.ToString(ViewState["INSPECT_CD"]) + "&STATUS=" + FinalStatus + "'>Go to main page</a>";
            hypgotomainPage.NavigateUrl = "/Call_Status_Edit_Form.aspx?CASE_NO=" + CASE_NO + "&CALL_RECV_DT=" + CALL_RECV_DT + "&CALL_SNO=" + CALL_SNO + "&IE_CD=" + IE_CD + "&ACTIONAR=" + ACTIONAR + "&ACTION=" + ACTION + "&INSPECT_CD=" + Convert.ToString(ViewState["INSPECT_CD"]) + "&STATUS=" + FinalStatus + "";

        }
        protected void rdoFinalStatementPass_CheckedChanged(object sender, EventArgs e)
        {
            SaveFinalStatement();
        }

        protected void btnNext4_Click(object sender, EventArgs e)
        {
            if (IsSaveValidate())
            {
                Repeater[] rpt = new Repeater[6];
                rpt[0] = rpt1;
                rpt[1] = rpt2;
                rpt[2] = rpt3;
                rpt[3] = rpt4;
                rpt[4] = rpt5;
                rpt[5] = rpt6;
                string[] txt = new string[6];
                txt[0] = txtRange1.Text;
                txt[1] = txtRange2.Text;
                txt[2] = txtRange3.Text;
                txt[3] = txtRange4.Text;
                txt[4] = txtRange5.Text;
                txt[5] = txtRange6.Text;

                SaveDimensionType(rpt, txt, "Dimensions");

                string sQuery = "UPDATE INSPECTION_TEST_PLN SET DATASHEET_REMARKS1=:PDATASHEET_REMARKS1 WHERE INSPECT_CD=:PINSPECT_CD";
                OracleCommand myUpdateCallStatusCommand = new OracleCommand(sQuery, conn);
                string CALL_SNO = Request.Params["CALL_SNO"].ToString();
                string FinalStatus = (rdoFinalStatementPass.Checked == true ? "Pass" : "Fail");
                myUpdateCallStatusCommand.Parameters.Add(funParameter("PINSPECT_CD", "string", 30, Convert.ToString(ViewState["INSPECT_CD"])));
                myUpdateCallStatusCommand.Parameters.Add(funParameter("PDATASHEET_REMARKS1", "string", 4000, txtDatasheetRemarks1.Text));
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                myUpdateCallStatusCommand.Connection = conn;
                myUpdateCallStatusCommand.ExecuteNonQuery();
            }
        }

        protected void btnfinalsubmit_Click(object sender, EventArgs e)
        {
            if (IsSaveValidate())
            {
                string sQuery = "UPDATE INSPECTION_TEST_PLN SET FINAL_SUBMIT=:PFINAL_SUBMIT, FINAL_STATEMENT=:PFINAL_STATEMENT, FINAL_STATEMENT_STATUS=:PFINAL_STATEMENT_STATUS WHERE INSPECT_CD=:PINSPECT_CD";
                OracleCommand myUpdateCallStatusCommand = new OracleCommand(sQuery, conn);
                string CALL_SNO = Request.Params["CALL_SNO"].ToString();
                string FinalStatus = (rdoFinalStatementPass.Checked == true ? "Pass" : "Fail");
                myUpdateCallStatusCommand.Parameters.Add(funParameter("PINSPECT_CD", "string", 30, Convert.ToString(ViewState["INSPECT_CD"])));
                myUpdateCallStatusCommand.Parameters.Add(funParameter("PFINAL_STATEMENT", "string", 4000, txtFinalStatement.Text));
                myUpdateCallStatusCommand.Parameters.Add(funParameter("PFINAL_STATEMENT_STATUS", "string", 20, FinalStatus));
                myUpdateCallStatusCommand.Parameters.Add(funParameter("PFINAL_SUBMIT", "string", 20, "S"));

                //myUpdateCallStatusCommand.Parameters.Add(new System.Data.OracleClient.OracleParameter("PINSPECT_CD", Convert.ToString(ViewState["INSPECT_CD"])));
                //myUpdateCallStatusCommand.Parameters.Add(new System.Data.OracleClient.OracleParameter("PFINAL_STATEMENT", txtFinalStatement.Text));
                //myUpdateCallStatusCommand.Parameters.Add(new System.Data.OracleClient.OracleParameter("PFINAL_STATEMENT_STATUS", FinalStatus));
                //myUpdateCallStatusCommand.Parameters.Add(new System.Data.OracleClient.OracleParameter("PFINAL_SUBMIT", "SUBMIT"));
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                myUpdateCallStatusCommand.Connection = conn;
                myUpdateCallStatusCommand.ExecuteNonQuery();
            }
        }

        protected void rdoPassA_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            funtxtValidate(txtObservA, rdo, rdo.Text);
        }
        protected void rdoPassB_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            funtxtValidate(txtObservB, rdo, rdo.Text);
        }
        protected void rdoPassC_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            funtxtValidate(txtObservC, rdo, rdo.Text);
        }
        protected void rdoPassD_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            funtxtValidate(txtObservD, rdo, rdo.Text);
        }
        protected void rdoPassE_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            funtxtValidate(txtObservE, rdo, rdo.Text);
        }
        protected void rdoPassF_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            funtxtValidate(txtObservF, rdo, rdo.Text);
        }
        protected void rdoPassG_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            funtxtValidate(txtObservG, rdo, rdo.Text);
        }
        protected void rdoPassH_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            funtxtValidate(txtObservH, rdo, rdo.Text);
        }
        protected void rdoPassI_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            funtxtValidate(txtObservI, rdo, rdo.Text);
        }
        protected void rdoPassJ_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            funtxtValidate(txtObservJ, rdo, rdo.Text);
        }
    }
}
