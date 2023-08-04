using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RBS.Online_Payment_Reciept
{
	public partial class Online_Payment_Reciept : System.Web.UI.Page
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			//
			try
			{
				if (!IsPostBack)
				{
					System.Configuration.AppSettingsReader appSettings = new System.Configuration.AppSettingsReader();

					//NameValueCollection nvc = Request.Form;

					if (Request.Params["mmp_txn"] != null)
					{
						string respHashKey = (string)appSettings.GetValue("respHashKey", Type.GetType("System.String"));
						string postingmmp_txn = Request.Params["mmp_txn"].ToString();
						//int postingmer_txn = Convert.ToInt32(Request.Params["mer_txn"]);
						string postingmer_txn = Request.Params["mer_txn"].ToString();
						string postinamount = Request.Params["amt"].ToString();
						string postingprod = Request.Params["prod"].ToString();
						string postingdate = Request.Params["date"].ToString();
						string postingbank_txn = Request.Params["bank_txn"].ToString();
						string postingf_code = Request.Params["f_code"].ToString();
						string postingbank_name = Request.Params["bank_name"].ToString();
						string signature = Request.Params["signature"].ToString();
						string postingdiscriminator = Request.Params["discriminator"].ToString();

						Label_MMP_TRANSACTION.Text = postingmmp_txn;
						Label_MERCHANT_TRANSACTION_ID.Text = postingmer_txn.ToString();
						Label_TRANSACTION_AMOUNT.Text = postinamount;
						Label_PRODUCT.Text = postingprod;
						Label_TRANSACTION_DATE.Text = postingdate;
						Label_BANK_TRANSACTION_ID.Text = postingbank_txn;
						Label_PAYMENT_STATUS.Text = postingf_code;
						Label_BANK_NAME.Text = postingbank_name;

						//string respHashKey = "KEYRESP123657234";
						string ressignature = "";
						string strsignature = postingmmp_txn + postingmer_txn + postingf_code + postingprod + postingdiscriminator + postinamount + postingbank_txn;
						//string strsignature = postingmmp_txn + postingmer_txn1 + postingf_code + postingprod + discriminator + postinamount + postingbank_txn;
						// //INBRequest objINBRequest = new INBRequest ();
						// //byte[] bytes = Encoding.UTF8.GetBytes(respHashKey);
						// //byte[] b = new System.Security.Cryptography.HMACSHA512(bytes).ComputeHash(Encoding.UTF8.GetBytes(strsignature));
						// //ressignature = byteToHexString(b).ToLower();

						//ressignature = INBRequest.CreateSHA512Signature(strsignature, respHashKey);


						OracleConnection conn1 = new OracleConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
						//string str1 = "UPDATE ONLINE_PAYMENT SET TRANSACTION_NO='"+Label_BANK_TRANSACTION_ID.Text+"',RRN_NO='"+Label_MMP_TRANSACTION.Text+"',AUTH_CD='"+Label_vpc_AuthorizeId.Text+"',STATUS='"+Label_PAYMENT_STATUS.Text+"' WHERE MER_TXN_REF='"+Label_MERCHANT_TRANSACTION_ID.Text.Trim()+"' AND ORDER_INFO="+Label_vpc_OrderInfo.Text.Trim();
						string str1 = "UPDATE ONLINE_PAYMENT SET TRANSACTION_NO='" + Label_BANK_TRANSACTION_ID.Text + "',RRN_NO='" + Label_MMP_TRANSACTION.Text + "',STATUS='" + Label_PAYMENT_STATUS.Text + "' WHERE MER_TXN_REF='" + Label_MERCHANT_TRANSACTION_ID.Text.Trim() + "' ";
						conn1.Open();
						OracleCommand myOracleCommand = new OracleCommand(str1, conn1);
						myOracleCommand.ExecuteNonQuery();
						conn1.Close();

						if (signature.ToUpper() == ressignature.ToUpper())
						{
							//lblStatus.Text = "Signature matched...";

							lblReceiptErrorMessage.Text = "No Error!!!";
						}
						else
						{
							//lblStatus.Text = "Signature Mismatched...";
							lblReceiptErrorMessage.Text = "Signature Mismatched Error!!!";
						}
					}
				}
			}
			catch (Exception ex)
			{
				lblReceiptErrorMessage.Text = ex.Message;
			}
			//

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
	}
}