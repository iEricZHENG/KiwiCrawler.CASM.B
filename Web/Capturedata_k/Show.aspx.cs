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
namespace KiwiCrawler.Web.Capturedata_k
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
		KiwiCrawler.BLL.Capturedata_kBll bll=new KiwiCrawler.BLL.Capturedata_kBll();
		KiwiCrawler.Model.Capturedata_k model=bll.GetModel(kId);
		this.lblkId.Text=model.kId.ToString();
		this.lblkUrl.Text=model.kUrl;
		this.lblkContent.Text=model.kContent;
		this.lblkType.Text=model.kType;
		this.lblkCaptureDateTime.Text=model.kCaptureDateTime.ToString();
		this.lblkNumber.Text=model.kNumber.ToString();
		this.lblkNotes.Text=model.kNotes;

	}


    }
}
