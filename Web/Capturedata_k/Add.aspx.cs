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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			if(!PageValidate.IsNumber(txtkNumber.Text))
			{
				strErr+="kNumber格式错误！\\n";	
			}
			if(this.txtkNotes.Text.Trim().Length==0)
			{
				strErr+="kNotes不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string kUrl=this.txtkUrl.Text;
			string kContent=this.txtkContent.Text;
			string kType=this.txtkType.Text;
			DateTime kCaptureDateTime=DateTime.Parse(this.txtkCaptureDateTime.Text);
			int kNumber=int.Parse(this.txtkNumber.Text);
			string kNotes=this.txtkNotes.Text;

			KiwiCrawler.Model.Capturedata_k model=new KiwiCrawler.Model.Capturedata_k();
			model.kUrl=kUrl;
			model.kContent=kContent;
			model.kType=kType;
			model.kCaptureDateTime=kCaptureDateTime;
			model.kNumber=kNumber;
			model.kNotes=kNotes;

			KiwiCrawler.BLL.Capturedata_kBll bll=new KiwiCrawler.BLL.Capturedata_kBll();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
