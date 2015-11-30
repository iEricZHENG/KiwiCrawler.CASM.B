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

            //保存到数据库
            KiwiCrawler.BLL.Urlconfigs_kBll bll = new KiwiCrawler.BLL.Urlconfigs_kBll();
            if (bll.Add(urlFrmMode))
            {
                MessageBox.Show("操作成功");
            }
            else
            {
                MessageBox.Show("操作失败");
            }
            urlFrmMode_k = urlFrmMode;
            this.Close();
        }
    }
}
