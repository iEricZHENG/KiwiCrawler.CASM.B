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
    public partial class frmComplate : Form
    {
        private Int32 _modeId;
        private Int32 _row,_page, _tail;


        public frmComplate()
        {
            InitializeComponent();
        }
        public frmComplate(Int32 modeId) : this()
        {
            _modeId = modeId;
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            KiwiCrawler.Model.Urlconfigs_k configModel = new KiwiCrawler.Model.Urlconfigs_k();
            KiwiCrawler.BLL.Urlconfigs_kBll configBll = new KiwiCrawler.BLL.Urlconfigs_kBll();
            configModel = configBll.GetModel(_modeId);
            string msg = "";
            if (!Int32.TryParse(txtRow.Text.Trim(), out _row))
            {
                msg += "每页记录数输入有误\r\n";
            }
            if (!Int32.TryParse(txtTail.Text.Trim(),out _tail))
            {
                msg += "末页记录数输入有误\r\n";
            }
            if (configModel.kPageTotal==null)
            {
                msg += "选择网站总页数有误\r\n";
            }
            
            if (!string.IsNullOrEmpty(msg.Trim()))
            {
                MessageBox.Show(msg);
            }
            _page = configModel.kPageTotal == null ? -1 : Convert.ToInt32(configModel.kPageTotal);
            //计算完成度
            // 98.33%|590/600
            Int32 pageCapture,pageTotal;
            pageTotal = _row * _page - (_row - _tail);//总的记录数
            //获得pageCapture
            //目前根据关键词搜索吧，域名不太适用
            KiwiCrawler.BLL.Capturedata_kBll capBll = new KiwiCrawler.BLL.Capturedata_kBll();
            pageCapture = capBll.GetRecordCount("kNotes="+"'"+configModel.kKeyWords+"'")-_page;
            double percentage = pageCapture * 1.0 / (pageTotal * 1.0);
             msg= (percentage*100).ToString("0.00")+"%" + "|" + pageCapture + "/" + pageTotal;
            configModel.kNotes = msg;
            configModel.kComplateDegree = (decimal)percentage;
            if (configBll.Update(configModel))
            {
                MessageBox.Show("完成情况为："+msg);
                this.Close();
            } 
        }
    }
}
