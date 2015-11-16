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
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace KiwiCrawler.Web.Capturedata_k
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int kId=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(kId);
				}
			}
		}
			
	private void ShowInfo(int kId)
	{
		KiwiCrawler.BLL.Capturedata_kBll bll=new KiwiCrawler.BLL.Capturedata_kBll();
		KiwiCrawler.Model.Capturedata_k model=bll.GetModel(kId);
		this.lblkId.Text=model.kId.ToString();
		this.txtkUrl.Text=model.kUrl;
		this.txtkContent.Text=model.kContent;
		this.txtkType.Text=model.kType;
		this.txtkCaptureDateTime.Text=model.kCaptureDateTime.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtkUrl.Text.Trim().Length==0)
			{
				strErr+="kUrl不能为空！\\n";	
			}
			if(this.txtkContent.Text.Trim().Length==0)
			{
				strErr+="kContent不能为空！\\n";	
			}
			if(this.txtkType.Text.Trim().Length==0)
			{
				strErr+="kType不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtkCaptureDateTime.Text))
			{
				strErr+="kCaptureDateTime格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int kId=int.Parse(this.lblkId.Text);
			string kUrl=this.txtkUrl.Text;
			string kContent=this.txtkContent.Text;
			string kType=this.txtkType.Text;
			DateTime kCaptureDateTime=DateTime.Parse(this.txtkCaptureDateTime.Text);


			KiwiCrawler.Model.Capturedata_k model=new KiwiCrawler.Model.Capturedata_k();
			model.kId=kId;
			model.kUrl=kUrl;
			model.kContent=kContent;
			model.kType=kType;
			model.kCaptureDateTime=kCaptureDateTime;

			KiwiCrawler.BLL.Capturedata_kBll bll=new KiwiCrawler.BLL.Capturedata_kBll();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
