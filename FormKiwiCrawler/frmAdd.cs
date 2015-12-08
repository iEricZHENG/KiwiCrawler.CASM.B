using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormKiwiCrawler
{
    public partial class frmAdd : Form
    {
        public KiwiCrawler.Model.Urlconfigs_k urlFrmMode_k { get; set; }
        public frmAdd()
        {
            InitializeComponent();
        }      
        private void btnFinish_Click(object sender, EventArgs e)
        {
            KiwiCrawler.Model.Urlconfigs_k urlFrmMode=new KiwiCrawler.Model.Urlconfigs_k();

            urlFrmMode.kAddressBusinessType = txtBusinessType.Text.Trim();
            urlFrmMode.kCaptureType = cbCaptureType.Text.Trim();
            urlFrmMode.kComplateDegree = 0;
            urlFrmMode.kDetailPattern = txtDetailPattern.Text.Trim();
            urlFrmMode.kDetailPatternType = cbDetailPatternType.Text.Trim();
            urlFrmMode.kKeyWords = txtKeyWords.Text.Trim();
            urlFrmMode.kNextPagePattern = txtNextPagePattern.Text.Trim();
            urlFrmMode.kNextPagePatternType = cbNextPagePatternType.Text.Trim();
            urlFrmMode.kPageTotal = String.IsNullOrEmpty(txtPageNum.Text.Trim()) ? -1 : Int32.Parse(txtPageNum.Text.Trim());
            urlFrmMode.kUrl = txtUrl.Text.Trim();
            string msg = "";
            //保存到数据库
            KiwiCrawler.BLL.Urlconfigs_kBll bll = new KiwiCrawler.BLL.Urlconfigs_kBll();
            if (bll.Add(urlFrmMode))
            {
                msg += "添加种子链接成功。\r\n";
            }
            else
            {
                msg += "添加种子链接失败。\r\n";
            }
            //添加到抽取配置表
            KiwiCrawler.BLL.Extractionconfig_kBll extractionconfigBll = new KiwiCrawler.BLL.Extractionconfig_kBll();
            KiwiCrawler.Model.Extractionconfig_k extractionconfigModel = new KiwiCrawler.Model.Extractionconfig_k();
            extractionconfigModel.KId = urlFrmMode.kId;
            extractionconfigModel.KUrl = urlFrmMode.kUrl;
            extractionconfigModel.KKeyword = urlFrmMode.kKeyWords;
            extractionconfigModel.KPercent = 0;
            if (extractionconfigBll.Add(extractionconfigModel))
            {
                msg += "同步抽取信息成功。\r\n";
            }
            else
            {
                msg += "同步抽取信息失败。";
            }
            MessageBox.Show(msg);
            urlFrmMode_k = urlFrmMode;
            this.Close();
        }
    }
}
