using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
namespace KiwiCrawler.Web.Extractdata_k
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int kId=(Convert.ToInt32(strid));
					ShowInfo(kId);
				}
			}
		}
		
	private void ShowInfo(int kId)
	{
		KiwiCrawler.BLL.Extractdata_kBll bll=new KiwiCrawler.BLL.Extractdata_kBll();
		KiwiCrawler.Model.Extractdata_k model=bll.GetModel(kId);
		this.lblkId.Text=model.kId.ToString();
		this.lblkUrl.Text=model.kUrl;
		this.lblkPublishDateTime.Text=model.kPublishDateTime.ToString();
		this.lblkContent.Text=model.kContent;
		this.lblkAddress.Text=model.kAddress;
		this.lblkType.Text=model.kType;
		this.lblkCaptureDateTime.Text=model.kCaptureDateTime.ToString();

	}


    }
}
