using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KiwiCrawler.BLL;
using KiwiCrawler.Model;

namespace FormKiwiCrawler.B
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Capturedata_kBll bll = new Capturedata_kBll();
            Capturedata_k model = new Capturedata_k();
            model = bll.GetModelList("").FirstOrDefault();
            geckoWebBrowser1.Document.DocumentElement.InnerHtml = model.kContent;            
        }
    }
}
