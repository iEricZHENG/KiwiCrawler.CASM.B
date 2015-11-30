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
    public partial class frmEdit : Form
    {
        private KiwiCrawler.Model.Urlconfigs_k editFrmModel { get; set; }
        public frmEdit()
        {
            InitializeComponent();
        }
        public frmEdit(KiwiCrawler.Model.Urlconfigs_k model)
            : this()
        {
            editFrmModel = new KiwiCrawler.Model.Urlconfigs_k();
            editFrmModel = model;
        }

        private void frmEdit_Load(object sender, EventArgs e)
        {
            this.txtBusinessType.Text = editFrmModel.kAddressBusinessType.Trim();
            this.txtDetailPattern.Text = editFrmModel.kDetailPattern.Trim();
            this.txtKeyWords.Text = editFrmModel.kKeyWords.Trim();
            this.txtNextPagePattern.Text = editFrmModel.kNextPagePattern;
            this.txtPageNum.Text = editFrmModel.kPageTotal==null?"":editFrmModel.kPageTotal.ToString();
            this.txtUrl.Text = editFrmModel.kUrl.Trim();
            this.txtComplateDegree.Text = editFrmModel.kComplateDegree == null ? "0" : Convert.ToDecimal(editFrmModel.kComplateDegree).ToString("p2");
            // model.kComplateDegree == null ? "" : Convert.ToDecimal(model.kComplateDegree).ToString("p2");

            this.cbCaptureType.Text = editFrmModel.kCaptureType.Trim();
            this.cbDetailPatternType.Text = editFrmModel.kDetailPatternType.Trim();
            this.cbNextPagePatternType.Text = editFrmModel.kNextPagePatternType.Trim();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            editFrmModel.kAddressBusinessType = this.txtBusinessType.Text.Trim();
            editFrmModel.kDetailPattern = this.txtDetailPattern.Text;
            editFrmModel.kKeyWords = this.txtKeyWords.Text;
            editFrmModel.kNextPagePattern = this.txtNextPagePattern.Text;
            editFrmModel.kPageTotal = String.IsNullOrEmpty(this.txtPageNum.Text.Trim()) ? null : (int?)Convert.ToInt32(this.txtPageNum.Text.Trim());
            editFrmModel.kUrl = this.txtUrl.Text.Trim();
            editFrmModel.kComplateDegree = string.IsNullOrEmpty(this.txtComplateDegree.Text.Trim()) ? 0 : Convert.ToDecimal(this.txtComplateDegree.Text.Trim().ToString().TrimEnd('%'))/100;            

            editFrmModel.kCaptureType = this.cbCaptureType.Text;
            editFrmModel.kDetailPatternType = this.cbDetailPatternType.Text;
            editFrmModel.kNextPagePatternType = this.cbNextPagePatternType.Text;

            KiwiCrawler.BLL.Urlconfigs_kBll bll = new KiwiCrawler.BLL.Urlconfigs_kBll();
            if (bll.Update(editFrmModel))
            {
                MessageBox.Show("操作成功");
            }
            else
            {
                MessageBox.Show("操作失败");
            }
            this.Close();

        }


    }
}
