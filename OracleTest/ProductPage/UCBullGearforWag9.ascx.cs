using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace RBS.ProductPage
{
    public partial class UCBullGearforWag9 : System.Web.UI.UserControl
    {
        protected System.Web.UI.HtmlControls.HtmlInputFile File1;
        protected System.Web.UI.HtmlControls.HtmlInputFile File2;
        protected System.Web.UI.HtmlControls.HtmlInputFile File3;
        protected System.Web.UI.HtmlControls.HtmlInputFile File4;
        protected System.Web.UI.HtmlControls.HtmlInputFile File5;
        protected System.Web.UI.HtmlControls.HtmlInputFile File6;
        protected System.Web.UI.HtmlControls.HtmlInputFile File7;
        protected System.Web.UI.HtmlControls.HtmlInputFile File8;
        protected System.Web.UI.HtmlControls.HtmlInputFile File9;
        protected System.Web.UI.HtmlControls.HtmlInputFile File10;


        protected System.Web.UI.WebControls.Literal litFileUpdate;
        protected System.Web.UI.WebControls.Literal litFileUpdate2;
        protected System.Web.UI.WebControls.Literal litFileUpdate3;
        protected System.Web.UI.WebControls.Literal litFileUpdate4;
        protected System.Web.UI.WebControls.Literal litFileUpdate5;


        protected System.Web.UI.WebControls.ImageButton fileDelete;
        protected System.Web.UI.WebControls.ImageButton fileDelete2;
        protected System.Web.UI.WebControls.ImageButton fileDelete3;
        protected System.Web.UI.WebControls.ImageButton fileDelete4;
        protected System.Web.UI.WebControls.ImageButton fileDelete5;

        protected System.Web.UI.WebControls.LinkButton hypSpecificationDrawing;
        protected System.Web.UI.WebControls.TextBox txtDateOfInspection;
        protected System.Web.UI.WebControls.TextBox txtCaseNo;
        protected System.Web.UI.WebControls.TextBox txtBookNo;
        protected System.Web.UI.WebControls.TextBox txtSetNo;
        protected System.Web.UI.WebControls.TextBox TXTPLNO;
        protected System.Web.UI.WebControls.Label lblSpecification;
        protected System.Web.UI.WebControls.TextBox txtPlaceofInspection;
        protected System.Web.UI.WebControls.TextBox txtSizeofLog;
        protected System.Web.UI.WebControls.TextBox txtSpecificationDrawing;
        protected System.Web.UI.WebControls.TextBox txtPoNo;

        protected System.Web.UI.WebControls.Button btnSaveTestChecks;
        protected System.Web.UI.WebControls.Button btnPeriodicTest;
        protected System.Web.UI.WebControls.Repeater dtlistExtendedheight;
        protected System.Web.UI.WebControls.Repeater dtlistCompressedhight;
        protected System.Web.UI.WebControls.Repeater dtlistDustcover;
        protected System.Web.UI.WebControls.Repeater dtlistTubeDiameter;
        protected System.Web.UI.WebControls.Repeater dtlistBarPin71mm;
        protected System.Web.UI.WebControls.Repeater dtListBarPinCD110;
        protected System.Web.UI.WebControls.Repeater dtListBarPinTotalLength;
        protected System.Web.UI.WebControls.Repeater dtList78MM;
        protected System.Web.UI.WebControls.Panel pnlI;
        protected System.Web.UI.WebControls.Panel pnlII;
        protected System.Web.UI.WebControls.Panel pnlIII;
        protected System.Web.UI.WebControls.Panel pnlIV;
        protected System.Web.UI.WebControls.Panel pnlV;

        protected System.Web.UI.WebControls.TextBox txtObservA;
        protected System.Web.UI.WebControls.TextBox txtObservB;
        protected System.Web.UI.WebControls.TextBox txtObservC;
        protected System.Web.UI.WebControls.TextBox txtObservD;
        protected System.Web.UI.WebControls.TextBox txtObservE;
        protected System.Web.UI.WebControls.TextBox txtObservF;
        protected System.Web.UI.WebControls.TextBox txtObservG;
        protected System.Web.UI.WebControls.TextBox txtObservH;
        protected System.Web.UI.WebControls.TextBox txtObservI;
        protected System.Web.UI.WebControls.TextBox txtObservJ;
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
        protected System.Web.UI.WebControls.TextBox txtObservW;
        protected System.Web.UI.WebControls.TextBox txtDatasheetRemarks1;

        protected System.Web.UI.WebControls.RadioButton rdoPassA;
        protected System.Web.UI.WebControls.RadioButton rdoPassB;
        protected System.Web.UI.WebControls.RadioButton rdoPassC;
        protected System.Web.UI.WebControls.RadioButton rdoPassD;
        protected System.Web.UI.WebControls.RadioButton rdoPassE;
        protected System.Web.UI.WebControls.RadioButton rdoPassF;
        protected System.Web.UI.WebControls.RadioButton rdoPassG;
        protected System.Web.UI.WebControls.RadioButton rdoPassH;
        protected System.Web.UI.WebControls.RadioButton rdoPassI;
        protected System.Web.UI.WebControls.RadioButton rdoPassJ;
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
        protected System.Web.UI.WebControls.RadioButton rdoPassW;


        protected System.Web.UI.WebControls.RadioButton rdoFailA;
        protected System.Web.UI.WebControls.RadioButton rdoFailB;
        protected System.Web.UI.WebControls.RadioButton rdoFailC;
        protected System.Web.UI.WebControls.RadioButton rdoFailD;
        protected System.Web.UI.WebControls.RadioButton rdoFailE;
        protected System.Web.UI.WebControls.RadioButton rdoFailF;
        protected System.Web.UI.WebControls.RadioButton rdoFailG;
        protected System.Web.UI.WebControls.RadioButton rdoFailH;
        protected System.Web.UI.WebControls.RadioButton rdoFailI;
        protected System.Web.UI.WebControls.RadioButton rdoFailJ;
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
        protected System.Web.UI.WebControls.RadioButton rdoFailW;

        protected System.Web.UI.WebControls.RadioButton rdoAPassStrength;
        protected System.Web.UI.WebControls.RadioButton rdoBPassOverAll;
        protected System.Web.UI.WebControls.RadioButton rdoCPassEndMount;
        protected System.Web.UI.WebControls.RadioButton rdoAFailStrength;
        protected System.Web.UI.WebControls.RadioButton rdoBFailOverAll;
        protected System.Web.UI.WebControls.RadioButton rdoCFailEndMount;
        protected System.Web.UI.WebControls.RadioButton rdoFinalStatementPass;
        protected System.Web.UI.WebControls.RadioButton rdoFinalStatementFail;

        protected System.Web.UI.WebControls.Literal litHeadDimension;

        protected System.Web.UI.WebControls.TextBox txtStrengthtest;
        protected System.Web.UI.WebControls.TextBox txtOverall;
        protected System.Web.UI.WebControls.TextBox txtEndMounting;



        protected System.Web.UI.WebControls.Repeater repaterTstChecks;
        protected System.Web.UI.WebControls.Repeater rptPeriodictest;
        protected System.Web.UI.WebControls.TextBox txtNoOfPices;
        protected System.Web.UI.WebControls.TextBox txtManualEntry;

        protected System.Web.UI.WebControls.Repeater rpt0;
        protected System.Web.UI.WebControls.Repeater rpt1;
        protected System.Web.UI.WebControls.Repeater rpt2;
        protected System.Web.UI.WebControls.Repeater rpt3;
        protected System.Web.UI.WebControls.Repeater rpt4;
        protected System.Web.UI.WebControls.Repeater rpt5;
        protected System.Web.UI.WebControls.Repeater rpt6;
        protected System.Web.UI.WebControls.Repeater rpt7;
        protected System.Web.UI.WebControls.Repeater rpt8;
        protected System.Web.UI.WebControls.Repeater rpt9;
        protected System.Web.UI.WebControls.Repeater rpt10;
        protected System.Web.UI.WebControls.TextBox txtRange;
        protected System.Web.UI.WebControls.TextBox txtRange1;
        protected System.Web.UI.WebControls.TextBox txtRange2;
        protected System.Web.UI.WebControls.TextBox txtRange3;
        protected System.Web.UI.WebControls.TextBox txtRange4;
        protected System.Web.UI.WebControls.TextBox txtRange5;
        protected System.Web.UI.WebControls.TextBox txtRange6;
        protected System.Web.UI.WebControls.TextBox txtRange7;
        protected System.Web.UI.WebControls.TextBox txtRange8;
        protected System.Web.UI.WebControls.TextBox txtRange9;
        protected System.Web.UI.WebControls.TextBox txtRange10;
        protected System.Web.UI.WebControls.TextBox txtOffered;



        protected System.Web.UI.WebControls.TextBox txtFinalStatement;

        protected System.Web.UI.WebControls.Button btnShowtbl2;
        protected System.Web.UI.WebControls.Button tbn3Next;
        protected System.Web.UI.WebControls.Button tbn2Back;

        //  protected System.Web.UI.WebControls.Literal litgotohome;


        protected System.Web.UI.WebControls.HyperLink hypgotomainPage;
        protected System.Web.UI.WebControls.Repeater repeaterChemical;
        protected System.Web.UI.WebControls.Repeater repeaterMachanical;


        protected System.Web.UI.WebControls.CheckBox chkInExtTstCertivate;
        protected System.Web.UI.WebControls.CheckBox chkIntTstDimesional;
        protected System.Web.UI.WebControls.CheckBox chkCalibRecord;
        protected System.Web.UI.WebControls.CheckBox chkRDSOApproval;
        protected System.Web.UI.WebControls.CheckBox chkRESOApproval;

        protected System.Web.UI.WebControls.CheckBox chkDoc1;
        protected System.Web.UI.WebControls.CheckBox chkDoc2;
        protected System.Web.UI.WebControls.CheckBox chkDoc3;
        protected System.Web.UI.WebControls.CheckBox chkDoc4;
        protected System.Web.UI.WebControls.CheckBox chkDoc5;
        protected System.Web.UI.WebControls.CheckBox chkDoc6;
        protected System.Web.UI.WebControls.CheckBox chkDoc7;
        protected System.Web.UI.WebControls.CheckBox chkDoc8;
        protected System.Web.UI.WebControls.HyperLink hypDownloadReport;


        // protected System.Web.UI.WebControls.TextBox lblSNo;

        #region Html Control
        /// <summary>
        /// Test/
        /// </summary>
        protected HtmlTableRow trSpecification;
        protected HtmlTableRow trdateOfInspec;
        protected HtmlTableRow trPlaceOfSpecification;
        protected HtmlTableRow trSizeOfLot;
        protected HtmlTableRow trSizeOfSample;
        protected HtmlTableRow trDocument;
        //protected HtmlTableRow btnShowtbl2;
        protected HtmlTable tbl1;
        protected HtmlTable tbl2;
        protected HtmlTable tbl3;
        /// <summary>
        /// Periocic Test;
        /// </summary>
        protected HtmlTableRow trTrstCheck;
        protected HtmlTableRow trTestCheckDetails;
        protected HtmlTableRow trPeriodicTest;
        protected HtmlTableRow trPeriodicTestHead;
        protected HtmlTableRow trPeriodicTestDetails;
        /// <summary>
        /// Dimension;
        /// </summary>
        protected HtmlTableRow trDiamensionHead;
        protected HtmlTableRow trDiamensionHeadCondition;
        protected HtmlTableRow trDiamensionHeadConditionexple;
        protected HtmlTableRow trDiamensionHeadFinalSatus;
        protected HtmlTableRow trHeadSave;
        protected HtmlTableRow trDiamension;
        protected HtmlTableRow trDiamensionReport;

        #endregion
        //protected System.Web.UI.WebControls.TextBox txtDateOfInspection;
        //protected System.Web.UI.WebControls.TextBox txtDateOfInspection;
        OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);


        static string wIECD, wIENAME;
        static string wDtFr;
        static string wDtTo;
        private string wColour;
        protected System.Web.UI.WebControls.Button tbn3Back;
        protected System.Web.UI.WebControls.Button btn3Next;
        protected System.Web.UI.WebControls.LinkButton lnkAdd;
        protected System.Web.UI.WebControls.Button tbn4Back;
        protected System.Web.UI.WebControls.Button btn4next;
        protected System.Web.UI.WebControls.Button btnNoOfPices;
        protected System.Web.UI.WebControls.Button btnBackSecond;
        protected System.Web.UI.WebControls.Button btnSubmit;
        protected System.Web.UI.WebControls.Button btnUpload;
        protected System.Web.UI.WebControls.Button btnfinalsubmit;
        string wVendor;
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
                    conn.Open();
                    OracleDataReader readerB = cmd.ExecuteReader();
                    if (readerB.Read())
                    {
                        TXTPLNO.Text = Convert.ToString(readerB["PL_NO"]);
                        txtDateOfInspection.Text = Convert.ToString(readerB["VISIT_DT"]);
                        txtPlaceofInspection.Text = Convert.ToString(readerB["mfg_place"]);
                        txtOffered.Text = Convert.ToString(readerB["CUM_QTY_PREV_PASSED"]);
                        txtSizeofLog.Text = Convert.ToString(readerB["QTY_TO_INSP"]);
                        ViewState["item_cd"] = Convert.ToString(readerB["ITEM_CD"]);
                        ViewState["Item_Code"] = Convert.ToString(readerB["ITEM_CD"]);
                        txtPoNo.Text = Convert.ToString(readerB["PO_NO"]);
                        ViewState["IE_CD"] = Convert.ToString(readerB["IE_CD"]);

                        ViewState["item_cd"] = Convert.ToString(readerB["item_cd"]);
                        hypDownloadReport.NavigateUrl = "~/checksheet/frmInspectTestReport.aspx?CASE_NO=" + CASE_NO + "&CALL_RECV_DT=" + CALL_RECV_DT + "&CALL_SNO=" + CALL_SNO + "&IE_CD=" + Convert.ToString(readerB["IE_CD"]) + "&ACTION=C&ReportName=RPTBULLGEAR.RPT";



                        string IE_CD, ACTIONAR, ACTION;

                        IE_CD = Request.Params["IE_CD"].ToString();
                        ACTIONAR = Request.Params["ACTIONAR"].ToString();
                        ACTION = Request.Params["ACTION"].ToString();


                        //litgotohome.Text = "<a href='/RBS/IC_InspectionTstPln.aspx?CASE_NO=" + CASE_NO + "&CALL_RECV_DT=" + CALL_RECV_DT + "&CALL_SNO=" + CALL_SNO + "&IE_CD=" + IE_CD + "&ACTIONAR=" + ACTIONAR + "&ACTION=" + ACTION + "&INSPECT_CD=" +  Convert.ToString(ViewState["INSPECT_CD"]) + "&STATUS=" + FinalStatus + "'>Go to main page</a>";
                        hypgotomainPage.NavigateUrl = "/RBS/Call_Status_Edit_Form.aspx?CASE_NO=" + CASE_NO + "&CALL_RECV_DT=" + CALL_RECV_DT + "&CALL_SNO=" + CALL_SNO + "&IE_CD=" + IE_CD + "&ACTIONAR=" + ACTIONAR + "&ACTION=" + ACTION + "&INSPECT_CD=" + Convert.ToString(ViewState["INSPECT_CD"]) + "";

                    }
                    conn.Close();
                    funBindChemicalComp();
                    funBindMachanical();
                    GetsaveData();
                    funBindGrdDimension();
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
        }
        private void GetsaveData()
        {
            string sql = "SELECT Date_Of_Inspect Date_Of_Inspect1, INSPECTION_TEST_PLN.* FROM INSPECTION_TEST_PLN WHERE CASE_NO='" + Request.Params["CASE_NO"].ToString() + "' AND CALL_SNO='" + Request.Params["CALL_SNO"].ToString() + "' and pl_no='" + TXTPLNO.Text + "'  and CALL_RECV_DT=to_date('" + Request.Params["CALL_RECV_DT"].ToString() + "', 'dd/mm/yyyy')";
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
                ViewState["INSPECT_CD"] = Convert.ToString(readerB["INSPECT_CD"]);
                txtBookNo.Text = Convert.ToString(readerB["BK_NO"]);
                txtSetNo.Text = Convert.ToString(readerB["SET_NO"]);
                lblSpecification.Text = Convert.ToString(readerB["DRAWING_SPE"]);


                txtOffered.Text = Convert.ToString(readerB["SIZE_OF_SAMPLE"]);
                txtSizeofLog.Text = Convert.ToString(readerB["SIZE_OF_LOT"]);
                lblSpecification.Text = Convert.ToString(readerB["DRAWING_SPE"]);
                txtDateOfInspection.Text = Convert.ToString(readerB["DATE_OF_INSPECT"]);
                txtPlaceofInspection.Text = Convert.ToString(readerB["PLACE_OF_INSPECT"]);
                txtDatasheetRemarks1.Text = Convert.ToString(readerB["DATASHEET_REMARKS1"]);
                ViewState["Issubmit"] = (Convert.ToString(readerB["Final_submit"]) == "S" ? "S" : "N");

                rdoFinalStatementPass.Checked = (Convert.ToString(readerB["FINAL_STATEMENT_STATUS"]) == "Pass" ? true : false);
                txtFinalStatement.Text = Convert.ToString(readerB["FINAL_STATEMENT"]);


                //txtFinalStatement.Text = Convert.ToString(readerB["FINAL_STATEMENT"]);

                sql = "SELECT * FROM INSPECTION_TEST_PLNDOC_VERIFY WHERE INSPECT_CD='" + Convert.ToString(ViewState["INSPECT_CD"]) + "'";
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
                    else if (Convert.ToString(readerdoc["HEADING"]) == chkDoc6.Text)
                    {
                        chkDoc6.Checked = (Convert.ToString(readerdoc["IS_CHECKED"]) == "Yes" ? true : false);
                    }
                    else if (Convert.ToString(readerdoc["HEADING"]) == chkDoc7.Text)
                    {
                        chkDoc7.Checked = (Convert.ToString(readerdoc["IS_CHECKED"]) == "Yes" ? true : false);
                    }
                    else if (Convert.ToString(readerdoc["HEADING"]) == chkDoc8.Text)
                    {
                        chkDoc8.Checked = (Convert.ToString(readerdoc["IS_CHECKED"]) == "Yes" ? true : false);
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
                        if (Convert.ToString(readerC["INSPT_SNO"]) == "1.")
                        {
                            txtObservA.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservA, rdoPassA, rdoFailA, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                    }
                    else if (Convert.ToString(readerC["INSPT_HEAD"]) == "Test/Checks1")
                    {
                        if (Convert.ToString(readerC["INSPT_SNO"]) == "2.a")
                        {
                            txtObservB.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservB, rdoPassB, rdoFailB, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                        else if (Convert.ToString(readerC["INSPT_SNO"]) == "2.b")
                        {
                            txtObservC.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservC, rdoPassC, rdoFailC, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                        else if (Convert.ToString(readerC["INSPT_SNO"]) == "2.c")
                        {
                            txtObservD.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservD, rdoPassD, rdoFailD, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                    }
                    else if (Convert.ToString(readerC["INSPT_HEAD"]) == "Test/Checks2")
                    {
                        if (Convert.ToString(readerC["INSPT_SNO"]) == "3.a")
                        {
                            txtObservE.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservE, rdoPassE, rdoFailE, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                        else if (Convert.ToString(readerC["INSPT_SNO"]) == "3.b")
                        {
                            txtObservF.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservF, rdoPassF, rdoFailF, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                        else if (Convert.ToString(readerC["INSPT_SNO"]) == "3.c")
                        {
                            txtObservG.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservG, rdoPassG, rdoFailG, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                        else if (Convert.ToString(readerC["INSPT_SNO"]) == "3.d")
                        {
                            txtObservH.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservH, rdoPassH, rdoFailH, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                    }
                    else if (Convert.ToString(readerC["INSPT_HEAD"]) == "Test/Checks3")
                    {
                        if (Convert.ToString(readerC["INSPT_SNO"]) == "4.a")
                        {
                            txtObservI.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservI, rdoPassI, rdoFailI, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                        else if (Convert.ToString(readerC["INSPT_SNO"]) == "4.b")
                        {
                            txtObservJ.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservJ, rdoPassJ, rdoFailJ, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                        else if (Convert.ToString(readerC["INSPT_SNO"]) == "5")
                        {
                            txtObservK.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservK, rdoPassK, rdoFailK, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                    }
                    else if (Convert.ToString(readerC["INSPT_HEAD"]) == "Test/Checks4")
                    {
                        if (Convert.ToString(readerC["INSPT_SNO"]) == "6.a")
                        {
                            txtObservL.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservL, rdoPassL, rdoFailL, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                        else if (Convert.ToString(readerC["INSPT_SNO"]) == "6.b")
                        {
                            txtObservM.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservM, rdoPassM, rdoFailM, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                        else if (Convert.ToString(readerC["INSPT_SNO"]) == "6.c")
                        {
                            txtObservN.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservN, rdoPassN, rdoFailN, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                        else if (Convert.ToString(readerC["INSPT_SNO"]) == "6.d")
                        {
                            txtObservO.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservO, rdoPassO, rdoFailO, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                        else if (Convert.ToString(readerC["INSPT_SNO"]) == "7")
                        {
                            txtObservP.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservP, rdoPassP, rdoFailP, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                        else if (Convert.ToString(readerC["INSPT_SNO"]) == "8")
                        {
                            txtObservQ.Text = Convert.ToString(readerC["OBSERVATION"]);
                            if (Convert.ToString(readerC["OBSERV_STATUS"]) != "")
                                funtxtValidate(txtObservQ, rdoPassQ, rdoFailQ, Convert.ToString(readerC["OBSERV_STATUS"]));
                        }
                    }
                    else
                    {
                        DataRow dr = dtTstPlan.NewRow();
                        dr["S_No"] = Convert.ToString(readerC["INSPT_SNO"]);
                        dr["Parameter"] = Convert.ToString(readerC["PARMETER"]);
                        dr["ValueSpeci"] = Convert.ToString(readerC["VALUE_SPECIFIED"]);
                        dr["Observation"] = Convert.ToString(readerC["OBSERVATION"]);
                        if (Convert.ToString(readerC["OBSERV_STATUS"]) == "Pass" || Convert.ToString(readerC["OBSERV_STATUS"]) == "Ok")
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

        private void funBindChemicalComp()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SNo", typeof(Int32));
            dt.Columns.Add("Element", typeof(string));
            dt.Columns.Add("FromRange", typeof(string));
            dt.Columns.Add("ToRange", typeof(string));
            dt.Columns.Add("Values", typeof(string));

            DataRow dr = dt.NewRow();
            dr["SNo"] = 1;
            dr["Element"] = "Carbon";
            dr["FromRange"] = "0.15%";
            dr["ToRange"] = "0.20%";
            dr["Values"] = "";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["SNo"] = 2;
            dr["Element"] = "Manganese";
            dr["FromRange"] = "0.40%";
            dr["ToRange"] = "0.60%";
            dr["Values"] = "";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["SNo"] = 3;
            dr["Element"] = "Phosphorus";
            dr["FromRange"] = "";
            dr["ToRange"] = "0.035% Maximum";
            dr["Values"] = "";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["SNo"] = 4;
            dr["Element"] = "Sulphur";
            dr["FromRange"] = "";
            dr["ToRange"] = "0.035% Maximum";
            dr["Values"] = "";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["SNo"] = 5;
            dr["Element"] = "Silicon";
            dr["FromRange"] = "";
            dr["ToRange"] = "0.40% Maximum";
            dr["Values"] = "";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["SNo"] = 6;
            dr["Element"] = "Nickel";
            dr["FromRange"] = "1.40%";
            dr["ToRange"] = "1.70%";
            dr["Values"] = "";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["SNo"] = 7;
            dr["Element"] = "Chromium";
            dr["FromRange"] = "1.50%";
            dr["ToRange"] = "1.80%";
            dr["Values"] = "";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["SNo"] = 8;
            dr["Element"] = "Molybdenum";
            dr["FromRange"] = "0.25%";
            dr["ToRange"] = "0.35%";
            dr["Values"] = "";
            dt.Rows.Add(dr);
            repeaterChemical.DataSource = dt;
            repeaterChemical.DataBind();
        }
        private void funBindMachanical()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SNo", typeof(Int32));
            dt.Columns.Add("Element", typeof(string));
            dt.Columns.Add("FromRange", typeof(string));
            dt.Columns.Add("Values", typeof(string));
            DataRow dr = dt.NewRow();
            dr["SNo"] = 1;
            dr["Element"] = "Test piece dia.";
            dr["FromRange"] = "16min Dia.";
            dr["Values"] = "";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["SNo"] = 2;
            dr["Element"] = "Tensile Strength (MPa)";
            dr["FromRange"] = "1100 - 1350";
            dr["Values"] = "";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["SNo"] = 3;
            dr["Element"] = "Yield Strength (MPa)";
            dr["FromRange"] = "800 Min.";
            dr["Values"] = "";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["SNo"] = 4;
            dr["Element"] = "%age Elongation (mm)";
            dr["FromRange"] = "8% Mm.";
            dr["Values"] = "";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["SNo"] = 5;
            dr["Element"] = "Reduction Area";
            dr["FromRange"] = "35% Min.";
            dr["Values"] = "";
            dt.Rows.Add(dr);

            repeaterMachanical.DataSource = dt;
            repeaterMachanical.DataBind();
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
            //bool success = Int32.TryParse(txtManualEntry.Text, out totalColumn);
            bool success = false;
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
            rpt1.DataSource = funGetData("No of Teeth", totalColumn, "Dimensions (in mm)");
            rpt1.DataBind();
            rpt2.DataSource = funGetData("Teeth OD", totalColumn, "Dimensions (in mm)");
            rpt2.DataBind();
            rpt3.DataSource = funGetData("Teeth Length", totalColumn, "Dimensions (in mm)");
            rpt3.DataBind();
            rpt4.DataSource = funGetData("Total Length", totalColumn, "Dimensions (in mm)");
            rpt4.DataBind();
            rpt5.DataSource = funGetData("Base tangent length over 15 Teeth", totalColumn, "Dimensions (in mm)");
            rpt5.DataBind();
            rpt6.DataSource = funGetData("Bore", totalColumn, "Dimensions (in mm)");
            rpt6.DataBind();
            rpt7.DataSource = funGetData("OD 1", totalColumn, "Dimensions (in mm)");
            rpt7.DataBind();
            rpt8.DataSource = funGetData("OD 2", totalColumn, "Dimensions (in mm)");
            rpt8.DataBind();
            rpt9.DataSource = funGetData("OD 3", totalColumn, "Dimensions (in mm)");
            rpt9.DataBind();
            rpt10.DataSource = funGetData("Hardness", totalColumn, "Dimensions (in mm)");
            rpt10.DataBind();
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
                        txtRange7.Visible = true;
                        txtRange8.Visible = true;
                        txtRange9.Visible = true;
                        txtRange10.Visible = true;
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
                        txtRange7.Visible = false;
                        txtRange8.Visible = false;
                        txtRange8.Visible = false;
                        txtRange9.Visible = false;
                        txtRange10.Visible = false;
                    }
                }
            }
        }
        #region Web Form Designer generated code
        //override protected void OnInit(EventArgs e)
        //{
        //    //
        //    // CODEGEN: This call is required by the ASP.NET Web Form Designer.
        //    //
        //    InitializeComponent();
        //    base.OnInit(e);
        //}

        ///// <summary>
        ///// Required method for Designer support - do not modify
        ///// the contents of this method with the code editor.
        ///// </summary>
        //private void InitializeComponent()
        //{

        //    this.Load += new System.EventHandler(this.Page_Load);
        //    hypSpecificationDrawing.Click += hypSpecificationDrawing_Click;


        //}

        void hypSpecificationDrawing_Click(object sender, EventArgs e)
        {
            if (hypSpecificationDrawing.Text == "Edit")
            {
                txtSpecificationDrawing.Visible = true;
                hypSpecificationDrawing.Text = "Close";
            }
            else
            {
                txtSpecificationDrawing.Text = "";
                txtSpecificationDrawing.Visible = false;
                hypSpecificationDrawing.Text = "Edit";
            }
        }
        #endregion

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
                string str = "SELECT INSPECT_CD FROM INSPECTION_TEST_PLN WHERE CASE_NO='" + Request.Params["CASE_NO"].ToString() + "' AND CALL_SNO='" + Request.Params["CALL_SNO"].ToString() + "' and ITEM_CD='" + Convert.ToString(ViewState["item_cd"]) + "'  and CALL_RECV_DT=to_date('" + Request.Params["CALL_RECV_DT"].ToString() + "', 'dd/mm/yyyy')";
                //OracleCommand cmd1 = new OracleCommand(str, conn);
                conn.Open();
                OracleCommand cmd2 = new OracleCommand(str, conn);
                string wCDT = Convert.ToString(cmd2.ExecuteScalar());
                conn.Close();

                string visualstatus = funStatus(rdoPassA, rdoFailA);// (rdoPassA.Checked == true) ? "Pass" : "Fail";

                if (wCDT == "")
                {
                    conn.Open();
                    String CALL_SNO = Request.Params["CALL_SNO"].ToString();
                    //System.Data.OracleClient.OracleTransaction myTrans = conn.BeginTransaction();

                    string sQuery = "INSERT INTO INSPECTION_TEST_PLN(PO_NO, REPORT_HEADER, INSPECT_CD, ITEM_CD, PL_NO, CASE_NO,CALL_SNO, BK_NO, SET_NO, DRAWING_SPE, DATE_OF_INSPECT, PLACE_OF_INSPECT, SIZE_OF_LOT, SIZE_OF_SAMPLE, DOCUMENT_VERI, IE_CD, CALL_RECV_DT) " +
                                                          " VALUES(:PPO_NO, :PREPORT_HEADER,:PINSPECT_CD, :PITEM_CD, :PPL_NO, :PCASE_NO, :PCALL_SNO, :PBK_NO, :PSET_NO, :PDRAWING_SPE, :PDATE_OF_INSPECT, :PPLACE_OF_INSPECT,:PSIZE_OF_LOT, :PSIZE_OF_SAMPLE, :PDOCUMENT_VERI, :PIE_CD, to_date(:PCALL_RECV_DT, 'dd/mm/yyyy'))";
                    OracleCommand myInsertCommand = new OracleCommand(sQuery, conn);
                    string sINSPECT_CD = Convert.ToString(ViewState["item_cd"]) + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;
                    ViewState["INSPECT_CD"] = sINSPECT_CD;
                    myInsertCommand.Parameters.Add(funParameter("PPO_NO", "string", 200, txtPoNo.Text));
                    myInsertCommand.Parameters.Add(funParameter("PREPORT_HEADER", "string", 30, "BULL GEAR FOR WAG-9 LOCO 107 TEETH"));
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
                    myInsertCommand.Parameters.Add(new OracleParameter("PCALL_RECV_DT", Request.Params["CALL_RECV_DT"].ToString()));


                    //myInsertCommand.Transaction = myTrans;
                    myInsertCommand.Connection = conn;
                    myInsertCommand.ExecuteNonQuery();

                    funSaveDocVeri(sINSPECT_CD, chkDoc1.Text, (chkDoc1.Checked == true ? "Yes" : "No"));
                    funSaveDocVeri(sINSPECT_CD, chkDoc2.Text, (chkDoc2.Checked == true ? "Yes" : "No"));
                    funSaveDocVeri(sINSPECT_CD, chkDoc3.Text, (chkDoc3.Checked == true ? "Yes" : "No"));
                    funSaveDocVeri(sINSPECT_CD, chkDoc4.Text, (chkDoc4.Checked == true ? "Yes" : "No"));
                    funSaveDocVeri(sINSPECT_CD, chkDoc5.Text, (chkDoc5.Checked == true ? "Yes" : "No"));
                    funSaveDocVeri(sINSPECT_CD, chkDoc6.Text, (chkDoc6.Checked == true ? "Yes" : "No"));
                    funSaveDocVeri(sINSPECT_CD, chkDoc7.Text, (chkDoc7.Checked == true ? "Yes" : "No"));
                    funSaveDocVeri(sINSPECT_CD, chkDoc8.Text, (chkDoc8.Checked == true ? "Yes" : "No"));


                    funSaveData(sINSPECT_CD, "Visual", "1. The surface texture of the fitting surface (bore of the gear) shall not be coarser than the values specified in the relevant drawing.\n2. No discontinuity/ step formation from the ground tooth flank and the machined root fillet shall be permitted.\n3. The gear/pinion should be free from sharp edges.\n4. The working face of the teeth shall be free from defects such as heterogeneity in metal and forging/cutting/grinding imperfections. Any repair of these surface defects shall be prohibited.\n5. The end faces of the teeth shall also not show defects similar S. No. 2 above particularly near root circle. No welding shall be permitted.", txtObservA.Text, visualstatus, "Clause 9.3,9.4,9.7,9.8 & 9.9 of RDSO Specn.No. MP.0.2800.19 REV.00(OCT-2005)", "Test/Checks", "1.");

                    conn.Close();
                    // DisplayAlert(" Data saved successfully!");
                }
                else
                {
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
                    funSaveDocVeri(wCDT, chkDoc6.Text, (chkDoc6.Checked == true ? "Yes" : "No"));
                    funSaveDocVeri(wCDT, chkDoc7.Text, (chkDoc7.Checked == true ? "Yes" : "No"));
                    funSaveDocVeri(wCDT, chkDoc8.Text, (chkDoc8.Checked == true ? "Yes" : "No"));

                    //myTrans.Commit();
                    funSaveData(wCDT, "Visual", "1. The surfacetexture of the fitting surface (bore of the gear) shall not be coarser than the values specified in the relevant drawing.\n2. No discontinuity/ step formation from the ground tooth flank and the machined root fillet shall be permitted.\n3. The gear/pinion should be free from sharp edges.\n4. The working face of the teeth shall be free from defects such as heterogeneity in metal and forging/cutting/grinding imperfections. Any repair of these surface defects shall be prohibited.\n5. The end faces of the teeth shall also not show defects similar S. No. 2 above particularly near root circle. No welding shall be permitted.", txtObservA.Text, visualstatus, "Clause 9.3,9.4,9.7,9.8 & 9.9 of RDSO Specn.No. MP.0.2800.19 REV.00(OCT-2005)", "Test/Checks", "1.");

                }
            }
        }
        private OracleParameter funParameter(string PName, string type, int plen, string pValue)
        {
            OracleParameter param = new OracleParameter();
            param.ParameterName = PName;
            if (type == "string")
            {
                param.OracleDbType = OracleDbType.NVarchar2;
                param.Size = plen;
            }
            else if (type == "date")
            {
                param.OracleDbType = OracleDbType.Date;
            }
            else if (type == "int")
            {
                param.OracleDbType = OracleDbType.Int16;
            }
            param.Value = Convert.ToString(pValue);
            return param;
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
        private void funSaveData(string pINSPECT_CD, string PPARMETER, string PVALUE_SPECIFIED, string POBSERVATION, string POBSERV_STATUS, string PREMARKS)
        {
            funSaveData(pINSPECT_CD, PPARMETER, PVALUE_SPECIFIED, POBSERVATION, POBSERV_STATUS, PREMARKS, "", "");
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
        private void funSaveData(string pINSPECT_CD, string PPARMETER, string PVALUE_SPECIFIED, string POBSERVATION, string POBSERV_STATUS, string PREMARKS, string INSPT_HEAD, string INSPT_SNO)
        {
            string str = "SELECT INSPECT_CD FROM INSPECTION_TEST_PLN_TRAN WHERE INSPECT_CD='" + pINSPECT_CD + "' AND INSPT_HEAD='" + INSPT_HEAD + "' and INSPT_SNO='" + INSPT_SNO + "' ";
            OracleCommand cmd3 = new OracleCommand(str, conn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string wCDT = Convert.ToString(cmd3.ExecuteScalar());
            //conn.Close();
            if (wCDT == "")
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                wCDT = Convert.ToString(ViewState["INSPECT_CD"]);
                string myInsertQuery = "INSERT INTO INSPECTION_TEST_PLN_TRAN(INSPECT_CD, ITEM_CD, PARMETER, VALUE_SPECIFIED, OBSERVATION, OBSERV_STATUS,REMARKS, INSPT_HEAD, INSPT_SNO) " +
                                                " VALUES(:PINSPECT_CD, :PITEM_CD, :PPARMETER, :PVALUE_SPECIFIED, :POBSERVATION, :POBSERV_STATUS,:PREMARKS, :PINSPT_HEAD, :PINSPT_SNO)";
                OracleCommand myInsertCommand = new OracleCommand(myInsertQuery, conn);
                myInsertCommand.Parameters.Add(funParameter("PINSPECT_CD", "string", 30, pINSPECT_CD));
                myInsertCommand.Parameters.Add(funParameter("PITEM_CD", "string", 20, Convert.ToString(ViewState["item_cd"])));
                myInsertCommand.Parameters.Add(funParameter("PPARMETER", "string", 2000, PPARMETER));
                myInsertCommand.Parameters.Add(funParameter("PVALUE_SPECIFIED", "string", 4000, PVALUE_SPECIFIED));
                myInsertCommand.Parameters.Add(funParameter("POBSERVATION", "string", 200, POBSERVATION));
                myInsertCommand.Parameters.Add(funParameter("POBSERV_STATUS", "string", 20, POBSERV_STATUS));
                myInsertCommand.Parameters.Add(funParameter("PREMARKS", "string", 4000, PREMARKS));
                myInsertCommand.Parameters.Add(funParameter("PINSPT_HEAD", "string", 500, INSPT_HEAD));
                myInsertCommand.Parameters.Add(funParameter("PINSPT_SNO", "string", 5, INSPT_SNO));
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
            myInsertCommand.Parameters.Add(funParameter("PINSPECT_CD", "string", 30, pINSPECT_CD));
            myInsertCommand.Parameters.Add(funParameter("PITEM_CD", "string", 20, Convert.ToString(ViewState["item_cd"])));
            myInsertCommand.Parameters.Add(funParameter("PPARMETER", "string", 2000, PPARMETER));
            myInsertCommand.Parameters.Add(funParameter("PVALUE_SPECIFIED", "string", 4000, PVALUE_SPECIFIED));
            myInsertCommand.Parameters.Add(funParameter("POBSERVATION", "string", 200, POBSERVATION));
            myInsertCommand.Parameters.Add(funParameter("POBSERV_STATUS", "string", 20, POBSERV_STATUS));
            myInsertCommand.Parameters.Add(funParameter("PREMARKS", "string", 4000, PREMARKS));
            myInsertCommand.Parameters.Add(funParameter("PINSPT_HEAD", "string", 500, INSPT_HEAD));
            myInsertCommand.Parameters.Add(funParameter("PINSPT_SNO", "string", 5, INSPT_SNO));
            // myInsertCommand.Transaction = myTrans;
            myInsertCommand.Connection = conn;
            myInsertCommand.ExecuteNonQuery();
        }

        private string SaveToString(string pValue)
        {
            string sValue = "";
            sValue = Convert.ToString(pValue).Replace("'", " ").Replace("--", "");
            return sValue;
        }
        private void SecondStep()
        {
            trTrstCheck.Visible = false;
            trTestCheckDetails.Visible = false;
            trSpecification.Visible = false;
            trdateOfInspec.Visible = false;
            trPlaceOfSpecification.Visible = false;
            trSizeOfLot.Visible = false;
            trSizeOfSample.Visible = false;
            trDocument.Visible = false;

            trPeriodicTest.Visible = true;
            trPeriodicTestHead.Visible = true;
            trPeriodicTestDetails.Visible = true;

            trDiamensionHead.Visible = false;
            trDiamensionHeadCondition.Visible = false;
            trDiamensionHeadConditionexple.Visible = false;


            trDiamensionHeadFinalSatus.Visible = false;
            trDiamensionReport.Visible = false;
            trHeadSave.Visible = false;
            trDiamension.Visible = false;
        }
        private void ThirdStep()
        {
            trPeriodicTest.Visible = false;
            trPeriodicTestHead.Visible = false;
            trPeriodicTestDetails.Visible = false;
            trDiamensionHead.Visible = true;
            trDiamensionHeadCondition.Visible = true;
            trDiamensionHeadConditionexple.Visible = true;
            trDiamensionHeadFinalSatus.Visible = true;
            trDiamensionReport.Visible = true;
            trHeadSave.Visible = true;
            trDiamension.Visible = true;
        }
        private void DisplayAlert(string msg)
        {
            Response.Write("<script language=JavaScript> alert('" + msg + "'); </script>");
        }
        protected void btnPeriodicTest_Click(object sender, EventArgs e)
        {
            //if (txtStrengthtest.Text == "")
            //{
            //    DisplayAlert("Enter Stength test");
            //    return;
            //}
            //else if (txtOverall.Text == "")
            //{
            //    DisplayAlert("Enter Endurance test");
            //    return;
            //}
            //else if (txtEndMounting.Text == "")
            //{
            //    DisplayAlert("Enter End Mountings load test ");
            //    return;
            //}
            //else
            //{


            String CALL_SNO = Request.Params["CALL_SNO"].ToString();
            string str = "SELECT INSPECT_CD FROM INSPECTION_TEST_PLN WHERE CASE_NO='" + Request.Params["CASE_NO"].ToString() + "' AND CALL_SNO='" + Request.Params["CALL_SNO"].ToString() + "' and ITEM_CD='" + Convert.ToString(ViewState["item_cd"]) + "'  and CALL_RECV_DT=to_date('" + Request.Params["CALL_RECV_DT"].ToString() + "', 'dd/mm/yyyy')";
            conn.Open();
            OracleCommand cmd2 = new OracleCommand(str, conn);
            string wCDT = Convert.ToString(cmd2.ExecuteScalar());
            conn.Close();
            if (wCDT != "")
            {
                string APassStrength = funStatus(rdoAPassStrength, rdoAFailStrength); //(rdoAPassStrength.Checked == true) ? "Pass" : "Fail";
                string BPassOverAll = funStatus(rdoBPassOverAll, rdoBFailOverAll); //(rdoBPassOverAll.Checked == true) ? "Pass" : "Fail";
                string CPassEndMount = funStatus(rdoCPassEndMount, rdoCFailEndMount); //(rdoCPassEndMount.Checked == true) ? "Pass" : "Fail";
                conn.Open();
                /*
                funSaveData(wCDT, "Strength Test", "Withstand a static comressive axial load of 30 KN when fully closed and a tensile load of 30 KN when fully extended. Overall damping characteristics checked before and after shall not vary.", txtObservB.Text, APassStrength, "", "Periodic test", "a");
                funSaveData(wCDT, "Endurance Test", "Overall force/Velocity characteristics checked after 2,5,10, & 16 lac Cycles shall not deteriorate beyond +  of rated values (Shock absorber will be cool to a temperature between 27  & 33 C before testing)", txtObservC.Text, BPassOverAll, "", "Periodic test", "b");
                funSaveData(wCDT, "End Mountings load Characteristics", "Max.Torsional angle =8 deg.Torsional stiffness should be between 2295 Kg cm to 2550 kg cm.Max Conical stiffness angle =10 deg.Conical stiffness should be between 2295 kg cm to 2550 kg cm", txtObservD.Text, CPassEndMount, "", "Periodic test", "c");
                

                for (int i = 0; i < rptPeriodictest.Items.Count; i++)
                {
                    Label lblSNo = (Label)rptPeriodictest.Items[i].FindControl("lblSNo");
                    TextBox txtParameter1 = (TextBox)rptPeriodictest.Items[i].FindControl("txtParameter1");
                    TextBox txtValueSpecified = (TextBox)rptPeriodictest.Items[i].FindControl("txtValueSpecified");
                    TextBox txtObservation = (TextBox)rptPeriodictest.Items[i].FindControl("txtObservation");
                    TextBox txtRemarks = (TextBox)rptPeriodictest.Items[i].FindControl("txtRemarks");
                    RadioButton rdoTestExtra1 = (RadioButton)rptPeriodictest.Items[i].FindControl("rdoTestExtra1");
                    string SPass = (rdoTestExtra1.Checked == true ? "Pass" : "Fail");
                    funSaveData(wCDT, txtParameter1.Text, txtValueSpecified.Text, txtObservation.Text, SPass, txtRemarks.Text, "Periodic test", lblSNo.Text);
                }
                DisplayAlert(" Data updated successfully!");
				*/
            }
            conn.Close();
            funBindGrdDimension();
        }

        protected void btnBack1_Click(object sender, EventArgs e)
        {
            trTrstCheck.Visible = true;
            trTestCheckDetails.Visible = true;
            trSpecification.Visible = true;
            trdateOfInspec.Visible = true;
            trPlaceOfSpecification.Visible = true;
            trSizeOfLot.Visible = true;
            trSizeOfSample.Visible = true;
            trDocument.Visible = true;
            trDiamensionHead.Visible = true;
            trDiamension.Visible = true;

            trDiamensionHead.Visible = false;
            trDiamensionHeadCondition.Visible = false;
            trDiamensionHeadFinalSatus.Visible = false;
            trDiamensionHeadConditionexple.Visible = false;
            trDiamensionReport.Visible = false;
            trHeadSave.Visible = false;

            trDiamension.Visible = false;
            trPeriodicTest.Visible = false;
            trPeriodicTestHead.Visible = false;
            trPeriodicTestDetails.Visible = false;
        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Repeater[] rpt = new Repeater[10];
            rpt[0] = rpt1;
            rpt[1] = rpt2;
            rpt[2] = rpt3;
            rpt[3] = rpt4;
            rpt[4] = rpt5;
            rpt[5] = rpt6;
            rpt[6] = rpt7;
            rpt[7] = rpt8;
            rpt[8] = rpt9;
            rpt[9] = rpt10;
            string[] txt = new string[10];
            txt[0] = txtRange1.Text;
            txt[1] = txtRange2.Text;
            txt[2] = txtRange3.Text;
            txt[3] = txtRange4.Text;
            txt[4] = txtRange5.Text;
            txt[5] = txtRange6.Text;
            txt[6] = txtRange7.Text;
            txt[7] = txtRange8.Text;
            txt[8] = txtRange9.Text;
            txt[9] = txtRange10.Text;

            SaveDimensionType(rpt, txt, "Dimensions (in mm)", "hidDimCD", "hidParameter", "hidValue", "txtV");

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
        private void SaveDimensionType(Repeater[] prpt, string[] pstr, string SHead, string DimCD, string Parameter, string Value, string txtV)
        {
            string str = "SELECT INSPECT_CD FROM INSPECTION_TEST_PLN WHERE CASE_NO='" + Request.Params["CASE_NO"].ToString() + "' AND CALL_SNO='" + Request.Params["CALL_SNO"].ToString() + "' and ITEM_CD='" + Convert.ToString(ViewState["item_cd"]) + "'  and CALL_RECV_DT=to_date('" + Request.Params["CALL_RECV_DT"].ToString() + "', 'dd/mm/yyyy')";
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
                    ino++;
                    for (int i = 0; i < rept.Items.Count; i++)
                    {
                        TextBox txtextheight = (TextBox)rept.Items[i].FindControl(txtV + (ino).ToString() + "");
                        Label hidDimCD = (Label)rept.Items[i].FindControl("" + DimCD + "" + (ino).ToString() + "");
                        Label hidParameter = (Label)rept.Items[i].FindControl("" + Parameter + "" + (ino).ToString() + "");
                        Label hidValue = (Label)rept.Items[i].FindControl("" + Value + "" + (ino).ToString() + "");
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
                }
            }
        }
        protected void txtV1_TextChanged(object sender, EventArgs e)
        {

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
        protected void BtnNextCheck_Click(object sender, EventArgs e)
        {
            SecondStep();
        }

        protected void btnNextCheck1_Click(object sender, EventArgs e)
        {
            ThirdStep();
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
        protected void lnkAdd_Click(object sender, EventArgs e)
        {
            DataTable dtTstPlan;
            char curS_no = 'g';
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
                curS_no = 'g';
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
                curS_no = Convert.ToChar(dv.Table.Rows[0]["S_No"]);
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

        protected void lnkPeriodictest_Click(object sender, EventArgs e)
        {
            DataTable dtPeriodictess;
            char curS_no = 'c';
            if (rptPeriodictest.Items.Count == 0)
            {
                dtPeriodictess = new DataTable();
                dtPeriodictess.Columns.Add("S_No", typeof(string));
                dtPeriodictess.Columns.Add("Parameter", typeof(string));
                dtPeriodictess.Columns.Add("ValueSpeci", typeof(string));
                dtPeriodictess.Columns.Add("Observation", typeof(string));
                dtPeriodictess.Columns.Add("StatusPass", typeof(bool));
                dtPeriodictess.Columns.Add("StatusFail", typeof(bool));
                dtPeriodictess.Columns.Add("Remarks", typeof(string));
                curS_no = 'c';
            }
            else
            {
                //dtTstPlan = (DataTable)ViewState["tstPlan"];
                dtPeriodictess = new DataTable();
                dtPeriodictess.Columns.Add("S_No", typeof(string));
                dtPeriodictess.Columns.Add("Parameter", typeof(string));
                dtPeriodictess.Columns.Add("ValueSpeci", typeof(string));
                dtPeriodictess.Columns.Add("Observation", typeof(string));
                dtPeriodictess.Columns.Add("StatusPass", typeof(bool));
                dtPeriodictess.Columns.Add("StatusFail", typeof(bool));
                dtPeriodictess.Columns.Add("Remarks", typeof(string));
                for (int i = 0; i < rptPeriodictest.Items.Count; i++)
                {
                    Label lblSNo = (Label)rptPeriodictest.Items[i].FindControl("lblSNo");
                    TextBox txtParameter1 = (TextBox)rptPeriodictest.Items[i].FindControl("txtParameter1");
                    TextBox txtValueSpecified = (TextBox)rptPeriodictest.Items[i].FindControl("txtValueSpecified");
                    TextBox txtObservation = (TextBox)rptPeriodictest.Items[i].FindControl("txtObservation");
                    TextBox txtRemarks = (TextBox)rptPeriodictest.Items[i].FindControl("txtRemarks");
                    RadioButton rdoTestExtra1 = (RadioButton)rptPeriodictest.Items[i].FindControl("rdoTestExtra1");
                    RadioButton rdoTestExtra2 = (RadioButton)rptPeriodictest.Items[i].FindControl("rdoTestExtra2");
                    // string SPass = (rdoTestExtra1.Checked == true ? "Pass" : "Fail");
                    DataRow dr1 = dtPeriodictess.NewRow();
                    dr1["S_No"] = lblSNo.Text;
                    dr1["Parameter"] = txtParameter1.Text;
                    dr1["ValueSpeci"] = txtValueSpecified.Text;
                    dr1["Observation"] = txtObservation.Text;
                    dr1["StatusPass"] = rdoTestExtra1.Checked;
                    dr1["StatusFail"] = rdoTestExtra2.Checked;
                    dr1["Remarks"] = txtRemarks.Text;
                    dtPeriodictess.Rows.Add(dr1);
                }
                DataView dv = new DataView(dtPeriodictess, "", "S_No desc", DataViewRowState.CurrentRows);
                curS_no = Convert.ToChar(dv.Table.Rows[0]["S_No"]);
            }
            DataRow dr = dtPeriodictess.NewRow();
            dr["S_No"] = getNextChar(curS_no).ToString();
            dr["Parameter"] = "";
            dr["ValueSpeci"] = "";
            dr["Observation"] = "";
            dr["StatusPass"] = false;
            dr["StatusFail"] = false;
            dr["Remarks"] = "";
            dtPeriodictess.Rows.Add(dr);
            //ViewState["tstPlan"] = dtTstPlan;
            rptPeriodictest.DataSource = dtPeriodictess;
            rptPeriodictest.DataBind();
        }

        protected void btnNoOfPices_Click(object sender, EventArgs e)
        {
            funBindGrdDimension();
        }
        private void SaveFinalStatement()
        {
            conn.Open();
            // System.Data.OracleClient.OracleTransaction myTrans = conn.BeginTransaction();
            string sQuery = "UPDATE INSPECTION_TEST_PLN SET FINAL_STATEMENT=:PFINAL_STATEMENT, FINAL_STATEMENT_STATUS=:PFINAL_STATEMENT_STATUS WHERE INSPECT_CD=:PINSPECT_CD";
            OracleCommand myUpdateCallStatusCommand = new OracleCommand(sQuery, conn);
            string CALL_SNO = Request.Params["CALL_SNO"].ToString();
            string FinalStatus = (rdoFinalStatementPass.Checked == true ? "Pass" : "Fail");
            myUpdateCallStatusCommand.Parameters.Add(new OracleParameter("PINSPECT_CD", Convert.ToString(ViewState["INSPECT_CD"])));
            myUpdateCallStatusCommand.Parameters.Add(new OracleParameter("PFINAL_STATEMENT", txtFinalStatement.Text));
            myUpdateCallStatusCommand.Parameters.Add(new OracleParameter("PFINAL_STATEMENT_STATUS", FinalStatus));
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


            //litgotohome.Text = "<a href='/RBS/IC_InspectionTstPln.aspx?CASE_NO=" + CASE_NO + "&CALL_RECV_DT=" + CALL_RECV_DT + "&CALL_SNO=" + CALL_SNO + "&IE_CD=" + IE_CD + "&ACTIONAR=" + ACTIONAR + "&ACTION=" + ACTION + "&INSPECT_CD=" + Convert.ToString(ViewState["INSPECT_CD"]) + "&STATUS=" + FinalStatus + "'>Go to main page</a>";
            hypgotomainPage.NavigateUrl = "/RBS/Call_Status_Edit_Form.aspx?CASE_NO=" + CASE_NO + "&CALL_RECV_DT=" + CALL_RECV_DT + "&CALL_SNO=" + CALL_SNO + "&IE_CD=" + IE_CD + "&ACTIONAR=" + ACTIONAR + "&ACTION=" + ACTION + "&INSPECT_CD=" + Convert.ToString(ViewState["INSPECT_CD"]) + "&STATUS=" + FinalStatus + "";

        }
        protected void rdoFinalStatementPass_CheckedChanged(object sender, EventArgs e)
        {
            SaveFinalStatement();
        }

        protected void btngoToMainPage_Click(object sender, EventArgs e)
        {
            string CASE_NO, CALL_RECV_DT, CALL_SNO, IE_CD, ACTIONAR, ACTION;
            CASE_NO = Request.Params["CASE_NO"].ToString();
            CALL_RECV_DT = Request.Params["CALL_RECV_DT"].ToString();
            CALL_SNO = Request.Params["CALL_SNO"].ToString();
            IE_CD = Request.Params["IE_CD"].ToString();
            ACTIONAR = Request.Params["ACTIONAR"].ToString();
            ACTION = Request.Params["ACTION"].ToString();
            string str = "SELECT FINAL_STATEMENT_STATUS FROM INSPECTION_TEST_PLN WHERE INSPECT_CD='" + Convert.ToString(ViewState["INSPECT_CD"]) + "' AND CALL_SNO='" + Request.Params["CALL_SNO"].ToString() + "' and ITEM_CD='" + Convert.ToString(ViewState["item_cd"]) + "' and CASE_NO='" + Request.Params["CASE_NO"].ToString() + "'  and CALL_RECV_DT=to_date('" + Request.Params["CALL_RECV_DT"].ToString() + "', 'dd/mm/yyyy')";
            conn.Open();
            OracleCommand cmd2 = new OracleCommand(str, conn);
            string wCDT = Convert.ToString(cmd2.ExecuteScalar());
            conn.Close();
            if (wCDT != "")
            {
                Response.Redirect("IC_InspectionTstPln.aspx?CASE_NO=" + CASE_NO + "&CALL_RECV_DT=" + CALL_RECV_DT + "&CALL_SNO=" + CALL_SNO + "&IE_CD=" + IE_CD + "&ACTIONAR=" + ACTIONAR + "&ACTION=" + ACTION + "&INSPECT_CD=" + Convert.ToString(ViewState["INSPECT_CD"]) + "&STATUS=" + wCDT + "");
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
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
        protected void fileDelete_Click(object sender, ImageClickEventArgs e)
        {
            string SvrPath = Server.MapPath("LabReports/");
            ImageButton btn = (ImageButton)sender;
            if (btn == fileDelete)
            {
                string str = "SELECT FILE_PATH FROM INSPECTION_TEST_PLN WHERE INSPECT_CD='" + Convert.ToString(ViewState["INSPECT_CD"]) + "' AND CALL_SNO='" + Request.Params["CALL_SNO"].ToString() + "' and ITEM_CD='" + Convert.ToString(ViewState["item_cd"]) + "' and CASE_NO='" + Request.Params["CASE_NO"].ToString() + "'  and CALL_RECV_DT=to_date('" + Request.Params["CALL_RECV_DT"].ToString() + "', 'dd/mm/yyyy')";
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
                string str = "SELECT FILE_PATH2 FROM INSPECTION_TEST_PLN WHERE INSPECT_CD='" + Convert.ToString(ViewState["INSPECT_CD"]) + "' AND CALL_SNO='" + Request.Params["CALL_SNO"].ToString() + "' and ITEM_CD='" + Convert.ToString(ViewState["item_cd"]) + "' and CASE_NO='" + Request.Params["CASE_NO"].ToString() + "' and CALL_RECV_DT=to_date('" + Request.Params["CALL_RECV_DT"].ToString() + "', 'dd/mm/yyyy')";
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
                string str = "SELECT FILE_PATH3 FROM INSPECTION_TEST_PLN WHERE INSPECT_CD='" + Convert.ToString(ViewState["INSPECT_CD"]) + "' AND CALL_SNO='" + Request.Params["CALL_SNO"].ToString() + "' and ITEM_CD='" + Convert.ToString(ViewState["item_cd"]) + "' and CASE_NO='" + Request.Params["CASE_NO"].ToString() + "'  and CALL_RECV_DT=to_date('" + Request.Params["CALL_RECV_DT"].ToString() + "', 'dd/mm/yyyy')";
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
                string str = "SELECT FILE_PATH4 FROM INSPECTION_TEST_PLN WHERE INSPECT_CD='" + Convert.ToString(ViewState["INSPECT_CD"]) + "' AND CALL_SNO='" + Request.Params["CALL_SNO"].ToString() + "' and ITEM_CD='" + Convert.ToString(ViewState["item_cd"]) + "' and CASE_NO='" + Request.Params["CASE_NO"].ToString() + "'  and CALL_RECV_DT=to_date('" + Request.Params["CALL_RECV_DT"].ToString() + "', 'dd/mm/yyyy')";
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
                string str = "SELECT FILE_PATH5 FROM INSPECTION_TEST_PLN WHERE INSPECT_CD='" + Convert.ToString(ViewState["INSPECT_CD"]) + "' AND CALL_SNO='" + Request.Params["CALL_SNO"].ToString() + "' and ITEM_CD='" + Convert.ToString(ViewState["item_cd"]) + "' and CASE_NO='" + Request.Params["CASE_NO"].ToString() + "'  and CALL_RECV_DT=to_date('" + Request.Params["CALL_RECV_DT"].ToString() + "', 'dd/mm/yyyy')";
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

        protected void rdoAFailStrength_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            funtxtValidate(txtStrengthtest, rdo, rdo.Text);
        }

        protected void rdoBPassOverAll_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            funtxtValidate(txtOverall, rdo, rdo.Text);

        }

        protected void rdoCPassEndMount_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            funtxtValidate(txtEndMounting, rdo, rdo.Text);

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

        protected void btnShowtbl2_Click(object sender, EventArgs e)
        {
            if (IsSaveValidate())
            {
                SaveData();
            }
            pnlII.Visible = true;
            pnlIII.Visible = false;
            pnlI.Visible = false;
        }

        protected void tbn3Next_Click(object sender, EventArgs e)
        {
            //tbl1.Visible = true;
            pnlII.Visible = false;
            pnlIII.Visible = true;
            pnlI.Visible = false;
            pnlIV.Visible = false;
            if (IsSaveValidate())
            {
                String CALL_SNO = Request.Params["CALL_SNO"].ToString();
                string str = "SELECT INSPECT_CD FROM INSPECTION_TEST_PLN WHERE CASE_NO='" + Request.Params["CASE_NO"].ToString() + "' AND CALL_SNO='" + Request.Params["CALL_SNO"].ToString() + "' and ITEM_CD='" + Convert.ToString(ViewState["item_cd"]) + "'  and CALL_RECV_DT=to_date('" + Request.Params["CALL_RECV_DT"].ToString() + "', 'dd/mm/yyyy')";
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                OracleCommand cmd2 = new OracleCommand(str, conn);
                string wCDT = Convert.ToString(cmd2.ExecuteScalar());
                if (wCDT != "")
                {
                    //funSaveData(wCDT, "Materail Testing ", "\n", "", "", "\n", "Test/Checks", "2");
                    funSaveData(wCDT, "Chemical Composition (one sample per cast)", "Sr.No Element	I7CrNiMo6 TO DIN 17210\n" +
"                             Minimum      Maximum\n" +
"1     Carbon	          0.15%	      0.20%\n" +
"2     Manganese	  0.40%	      0.60%\n" +
"3     Phosphorus     0.035% Maximum\n" +
"4     Sulphur	          0.035% Maximum\n" +
"5     Silicon	          0.40%  Maximum\n" +
"6     Nickel	          1.40%         1.70%\n" +
"7     Chromium	  1.50%	      1.80%\n" +
"8     Molybdenum	  0.25%	      0.35%", txtObservB.Text, funStatus(rdoPassB, rdoFailB), "As per Table 1 of MP.0.2800.19REV.00 (OCT-2005)", "Test/Checks1", "2.a");
                    funSaveData(wCDT, "Mechanical properties (one sample I per cast)", "S.No	Element	\n" +
"1	Test piece dia.	                16min Dia.\n" +
"2	Tensile Strength (MPa)	1100 - 1350\n" +
"3	Yield Strength (MPa)	        800 Min.\n" +
"4	%age Elongation (mm)	8% Mm.\n" +
"5	Reduction Area	                35% Min.", txtObservC.Text, funStatus(rdoPassC, rdoFailC), "As per Table 2 of MP.0.2800.19 REV.00 (OCT-2005)", "Test/Checks", "2.b");
                    funSaveData(wCDT, "Inclusion rating ", "The inclusion rating of the steel shall not exceed A,=2.5-1.5, B=2-1, C-0.5-0.5 & D=1-1 for both thin & thick series. ", txtObservD.Text, funStatus(rdoPassD, rdoFailD), "As per DIN 3990 part 5 or IS: 41 63 ", "Test/Checks", "2.c");
                }
                conn.Close();

            }

        }
        protected void btn4next_Click(object sender, EventArgs e)
        {
            pnlII.Visible = false;
            pnlIII.Visible = false;
            pnlV.Visible = true;
            pnlI.Visible = false;
            pnlIV.Visible = false;
            if (IsSaveValidate())
            {
                String CALL_SNO = Request.Params["CALL_SNO"].ToString();
                string str = "SELECT INSPECT_CD FROM INSPECTION_TEST_PLN WHERE CASE_NO='" + Request.Params["CASE_NO"].ToString() + "' AND CALL_SNO='" + Request.Params["CALL_SNO"].ToString() + "' and ITEM_CD='" + Convert.ToString(ViewState["item_cd"]) + "'  and CALL_RECV_DT=to_date('" + Request.Params["CALL_RECV_DT"].ToString() + "', 'dd/mm/yyyy')";
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                OracleCommand cmd2 = new OracleCommand(str, conn);
                string wCDT = Convert.ToString(cmd2.ExecuteScalar());
                if (wCDT != "")
                {
                    funSaveData(wCDT, "Shot Peening ", "Shot peen teeth & root section of teeth before grinding tooth profile using S330 hard shots to obtain 200% Min.\n coverage in root area.\nPeening intensity should be between 0.007 to 0.0100C.", txtObservK.Text, funStatus(rdoPassK, rdoFailK), "Clause No 10 of RDSQ Specn. No. MP.0.2800.19 REV.00 (OCT- 2005) ", "Test/Checks", "5");
                    //funSaveData(wCDT, "Acceptaance tests\nNote : To be witnessed as part of final inspection ", "", "", "", "", "Test/Checks", "6");
                    funSaveData(wCDT, "Dimensional", "As per SKDP-3848 ALT-NIL. Dimension sheet attached ", txtObservL.Text, funStatus(rdoPassL, rdoFailL), "", "Test/Checks4", "6.a");
                    funSaveData(wCDT, "Surface Hardness", "60 — 62 RC ", txtObservM.Text, funStatus(rdoPassM, rdoFailM), "As per Note 2 of Drg No.SKDP-3848 ALT-NIL ", "Test/Checks4", "6.b");
                    funSaveData(wCDT, "Crack Detection", "All the finished gears should be subjected to crack detection by magnaflux inspection as per IS:3703.", txtObservN.Text, funStatus(rdoPassN, rdoFailN), "As per note 11 of drawing No. SKDP-3848 ALT- NIL and as per clause 11.2(a) iii of RDSO Specification No.MP.0.2800.19 REV.00(OCT-2005) ", "Test/Checks4", "6.c");
                    funSaveData(wCDT, "Tooth Error/ Deviation", "Double Flank Total Composite Error: 0.056 Base Pitch Error: 0.016 Tooth to Tooth Pitch Error: 0.02 Profile Error: 0.02 Radial Run Out: 0.05 Flank Angle Error: 0.016 ", txtObservO.Text, funStatus(rdoPassO, rdoFailO), "As per Drg No SKDP-3848 ALT NIL ", "Test/Checks4", "6.d");
                    funSaveData(wCDT, "Marking", "All gears shall bear the following I markings on both end faces (By punching I or by electrical etching) which should be , indelible and clearly legible.\n\na) Name of Supplier/manufacturer\n\nb) Number of month and last two digits of the year of manufacture e.g. 5/96 & Gear ratio\n\nc) Material and specification of steel\n\nd) Drawing number of the part\n\ne) Manufacture/Consecutive number of-the part", txtObservP.Text, funStatus(rdoPassP, rdoFailP), "Note- 4 of Drg No-SKDP-3848 ALT-NIL", "Test/Checks4", "7");
                    funSaveData(wCDT, "Protection & Packing", "The gears shall be suitably protected against oxidation and corrosion by three coats of ready mixed paint brushing Bituminous to IS 158 or with any other approved anti-rust compound capable of being removed easily by white spirit or kerosene oil, allowing sufficient drying time between each coat. After the last coat has dried, the gear shall be covered with waterproof paper. The gears shall then suitably be placed to prevent any damage during transport and handling. ", txtObservQ.Text, funStatus(rdoPassQ, rdoFailQ), " Clause No- 15of RDSO Specification No-MP.0.2800.19 REV.00 (OCT-2005) ", "Test/Checks4", "8");

                }
                conn.Close();
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
        protected void tbn2Back_Click(object sender, EventArgs e)
        {
            pnlII.Visible = false;
            pnlIII.Visible = false;
            pnlI.Visible = true;
            pnlIV.Visible = false;
            pnlV.Visible = false;
        }
        protected void tbn3Back_Click(object sender, EventArgs e)
        {
            pnlII.Visible = true;
            pnlIII.Visible = false;
            pnlI.Visible = false;
            pnlIV.Visible = false;
            pnlV.Visible = false;
        }
        protected void tbn4Back_Click(object sender, EventArgs e)
        {
            pnlIV.Visible = false;
            pnlII.Visible = false;
            pnlIII.Visible = true;
            pnlI.Visible = false;
            pnlV.Visible = false;
        }
        protected void btnBackSecond_Click(object sender, EventArgs e)
        {
            pnlIV.Visible = true;
            pnlII.Visible = false;
            pnlIII.Visible = false;
            pnlI.Visible = false;
            pnlV.Visible = false;
        }
        protected void btn3Next_Click(object sender, EventArgs e)
        {
            pnlIV.Visible = true;
            pnlII.Visible = false;
            pnlIII.Visible = false;
            pnlI.Visible = false;
            pnlV.Visible = false;

            if (IsSaveValidate())
            {
                String CALL_SNO = Request.Params["CALL_SNO"].ToString();
                string str = "SELECT INSPECT_CD FROM INSPECTION_TEST_PLN WHERE CASE_NO='" + Request.Params["CASE_NO"].ToString() + "' AND CALL_SNO='" + Request.Params["CALL_SNO"].ToString() + "' and ITEM_CD='" + Convert.ToString(ViewState["item_cd"]) + "'  and CALL_RECV_DT=to_date('" + Request.Params["CALL_RECV_DT"].ToString() + "', 'dd/mm/yyyy')";
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                OracleCommand cmd2 = new OracleCommand(str, conn);
                string wCDT = Convert.ToString(cmd2.ExecuteScalar());
                if (wCDT != "")
                {
                    funSaveData(wCDT, "Tests on Rough Forged Gear Blanks\nNote: (1) To be witnessed in case of stage inspection. (ii) To be reviewed in case of final inspection. ", "\n", "", "", "\n", "Test/Checks2", "3");
                    funSaveData(wCDT, "Macro etch test ", "It shall reveal satisfactory flow line pattern right up to the centre of the forged blank. Note: This test will be done at the work of the forging supplier by the manufacturer. ", txtObservE.Text, funStatus(rdoPassE, rdoFailE), "Test method as per DIN 3990 Part 5 or ASTM E381 ", "Test/Checks2", "3.a");
                    funSaveData(wCDT, "Microstructure and Grain Size", "Range 6 or finer grained structure ", txtObservF.Text, funStatus(rdoPassF, rdoFailF), "Test method as per DIN 3990 Part 5 ", "Test/Checks2", "3.b");
                    funSaveData(wCDT, "Ultrasonic Test", "All forged blanks shall be ultrasonically tested before and after machining for ensuring freedom from casting and forging defects.", txtObservG.Text, funStatus(rdoPassG, rdoFailG), "Test method as per DIN 3990 Part S or Appendix A of MP.0.2800.19 REV.00 (OCT-2005)", "Test/Checks2", "3.c");
                    funSaveData(wCDT, "Hardness Test", "170-220 HB  ", txtObservH.Text, funStatus(rdoPassH, rdoFailH), "Test method as per DIN 3990 Part 5 or IS:1500", "Test/Checks2", "3.d");

                    //funSaveData(wCDT, "Tests after Pre machining Heat Treatment of forged Blanks Note: (i) To be witnessed in case of stage inspection. (ii) To be reviewed to case of final inspection.", "\n", "", "", "\n", "Test/Checks3", "4");
                    funSaveData(wCDT, "Case Depth", "	1.8 mm to 2.2 mm (At which a hardness of 500 HV 30 (5ORC] is obtained)", txtObservI.Text, funStatus(rdoPassI, rdoFailI), "As per Clause 8.2. I of RDSO Specification No¬MP.0.2800.19 REV.00 OCT-2005)", "Test/Checks3", "4.a");
                    funSaveData(wCDT, "Micro Examination (One test piece per batch", "Cementite network or free cementite should not exist. Retained austenite content of 15-30 % may be permitted.", txtObservJ.Text, funStatus(rdoPassJ, rdoFailJ), "As per DIN 3990 Part 5 or IS:4432—1988", "Test/Checks3", "4.b");


                }
                conn.Close();
            }
        }
        protected void btnfinalsubmit_Click(object sender, EventArgs e)
        {
            string sQuery = "UPDATE INSPECTION_TEST_PLN SET FINAL_SUBMIT=:PFINAL_SUBMIT, FINAL_STATEMENT=:PFINAL_STATEMENT, FINAL_STATEMENT_STATUS=:PFINAL_STATEMENT_STATUS WHERE INSPECT_CD=:PINSPECT_CD";
            OracleCommand myUpdateCallStatusCommand = new OracleCommand(sQuery, conn);
            string CALL_SNO = Request.Params["CALL_SNO"].ToString();
            string FinalStatus = (rdoFinalStatementPass.Checked == true ? "Pass" : "Fail");
            myUpdateCallStatusCommand.Parameters.Add(funParameter("PINSPECT_CD", "string", 30, Convert.ToString(ViewState["INSPECT_CD"])));
            myUpdateCallStatusCommand.Parameters.Add(funParameter("PFINAL_STATEMENT", "string", 4000, txtFinalStatement.Text));
            myUpdateCallStatusCommand.Parameters.Add(funParameter("PFINAL_STATEMENT_STATUS", "string", 20, FinalStatus));
            myUpdateCallStatusCommand.Parameters.Add(funParameter("PFINAL_SUBMIT", "string", 20, "S"));
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            myUpdateCallStatusCommand.Connection = conn;
            myUpdateCallStatusCommand.ExecuteNonQuery();
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
        protected void rdoPassK_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            funtxtValidate(txtObservK, rdo, rdo.Text);
        }
        protected void rdoPassL_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            funtxtValidate(txtObservL, rdo, rdo.Text);
        }
        protected void rdoPassM_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            funtxtValidate(txtObservM, rdo, rdo.Text);
        }
        protected void rdoPassN_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            funtxtValidate(txtObservN, rdo, rdo.Text);
        }
        protected void rdoPassO_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            funtxtValidate(txtObservO, rdo, rdo.Text);
        }
        protected void rdoPassP_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            funtxtValidate(txtObservP, rdo, rdo.Text);
        }
        protected void rdoPassQ_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            funtxtValidate(txtObservQ, rdo, rdo.Text);
        }
    }
}