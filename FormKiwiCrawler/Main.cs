namespace FormKiwiCrawler
{
    using Crawler.Core;
    using KiwiCrawler.BLL;
    using KiwiCrawler.Core;
    using KiwiCrawler.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Windows.Forms;

    public partial class Main : Form
    {
        #region 静态字段       
        private static readonly CrawlSettings Settings = new CrawlSettings();
        private static KiwiCrawler.Model.Urlconfigs_k configModel = new Urlconfigs_k();
        /// <summary>
        /// The filter.
        /// 关于使用 Bloom 算法去除重复 URL：http://www.cnblogs.com/heaad/archive/2011/01/02/1924195.html
        /// </summary>
        private static BloomFilter<string> filter;
        private static Int32 fileId ;
        private static ConsoleControl.ConsoleControl kiwiConsole = new ConsoleControl.ConsoleControl();
        private static bool[] kiwiThreadStatus;
        private static string strExit="";
        #endregion

        public Main()
        {
            InitializeComponent();
            tabPage4.Controls.Add(kiwiConsole);
            kiwiConsole.Dock = DockStyle.Fill;
            kiwiConsole.Show();
        }
        #region 事件
        private static bool MasterAddUrlEvent(AddUrlEventArgs args)
        {
            if (!filter.Contains(args.Url))//不包含就添加
            {
                filter.Add(args.Url);
                return true;
            }
            return false; // 返回 false 代表：不添加到队列中
        }
        private static void MasterDataReceivedEvent(DataReceivedEventArgs args)
        {
            // 在此处解析页面，可以用类似于 HtmlAgilityPack（页面解析组件）的东东、也可以用正则表达式、还可以自己进行字符串分析
            //NSoup.Nodes.Document doc = NSoup.NSoupClient.Parse(args.Html);

            #region 接收数据处理，//如果有问题可以使用多线程
            DataReceivedEventArgs_Kiwi.Instance.EnQueue(args);
            ThreadPool.QueueUserWorkItem(o =>
            {
                while (true)
                {
                    try
                    {
                        if (DataReceivedEventArgs_Kiwi.Instance.Count > 0)
                        {
                            DataReceivedEventArgs dataReceived = DataReceivedEventArgs_Kiwi.Instance.DeQueue();
                            if (!String.IsNullOrEmpty(dataReceived.Html) && dataReceived.Html.Trim() != "")
                            {
                                WriteToFiles(dataReceived);
                            }
                        }
                        else
                        {
                            Thread.Sleep(2000);
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            });

            #endregion 接收数据处理
        }
        private static void Master_CustomParseLinkEvent3(CustomParseLinkEvent3Args args)
        {

            #region 
            CustomParseLink_MainList(args, configModel.kDetailPattern);//什么都不匹配
            CustomParseLink_NextPageSdau(args, configModel.kNextPagePattern, 1);//下一页                     
            #endregion

            #region  SDAU
            //CustomParseLink_MainList(args, "(view).+?([0-9]{5})");//去除,下一步，拼写一个大的正则表达式就好
            //CustomParseLink_NextPageSdau(args, "<a .+ href='(.+)'>下一页</a>", 1);//添加，下一步，拼写一个大的正则表达式就好 
            #endregion
            #region 北京市地震局
            //CustomParseLink_MainList(args, "今天天气好晴朗，又是刮风又是下雨");//什么都不匹配
            //CustomParseLink_NextPageSdau(args, "•<A href=\"(/manage/html/[\\d\\w]{32}/_content/\\d{2}_\\d{2}/\\d{2}/\\d+\\.html)\"", 1);//详细页
            //CustomParseLink_NextPageSdau(args, "<a href=\"(index_\\d+.html)\">下一页</a>", 1);//下一页 
            #endregion
            #region 上海民政
            ////去除(保留符合正则的),下一步，拼写一个大的正则表达式就好
            //CustomParseLink_MainList(args, @"/gb/shmzj/node4/node\d+/n\d{4}/u1ai\d{5}.html");
            ////添加，下一步，拼写一个大的正则表达式就好
            //CustomParseLink_NextPageSdau(args, "<a HREF=\"(/gb\\shmzj/node4/node\\d+/n\\d{4}/index\\d+\\.html)\" class=next>下一页</a>", 1); //<a href="(List.action\?[\w\d&=]+)">下一页</a>  
            #endregion
            #region 陕西

            ////去除,下一步，拼写一个大的正则表达式就好
            //CustomParseLink_MainList(args, @"xg-xxgk-gk-[\d|-]+");//xg-xxgk-gk-[\d|-]+
            ////添加，下一步，拼写一个大的正则表达式就好
            //CustomParseLink_NextPageSdau(args, "<a href=\"(List.action\\?[\\w\\d&=]+)\">下一页</a>", 1); //<a href="(List.action\?[\w\d&=]+)">下一页</a> 
            #endregion
            #region 上海
            ////去除,下一步，拼写一个大的正则表达式就好
            //CustomParseLink_MainList(args, @"detail1.jsp.*id=\d*");
            ////添加，下一步，拼写一个大的正则表达式就好
            //CustomParseLink_NextPageSdau(args, @"<A .*HREF=(.+) class.*>\s*下一页</A>", 1); 
            #endregion
            #region 安居客
            //CustomParseLink_MainList(args, "http://beijing.anjuke.com/prop/view/.*commsearch_p");
            //CustomParseLink_NextPageSdau(args, "<a href='(.+)' class='aNxt'>下一页 &gt;</a>", 1);
            //CustomParseLink_NextPageSdau(args, "http://beijing.anjuke.com/prop/view/.*commsearch_p", 0); 
            #endregion
        }
        #endregion
        #region 方法=》链接处理

        /// <summary>
        /// 处理Html，重新过滤+做的是加法
        /// </summary>
        /// <param name="args"></param>
        /// <param name="patternStr"></param>
        /// <param name="groupIndex"></param>
        private static void CustomParseLink_NextPageSdau(CustomParseLinkEvent3Args args, string patternStr, int groupIndex)
        {
            string url = "";
            if (args != null && !string.IsNullOrEmpty(args.Html))
            {
                Regex regex = new Regex(patternStr, RegexOptions.IgnoreCase);//忽略大小写
                Match mat = regex.Match(args.Html);
                if (mat.Success)
                {
                    url = mat.Groups[groupIndex].Value;
                    var baseUri = new Uri(args.UrlInfo.UrlString);
                    Uri currentUri = url.StartsWith("http", StringComparison.OrdinalIgnoreCase)
                                         ? new Uri(url)
                                         : new Uri(baseUri, url);//根据指定的基 URI 和相对 URI 字符串，初始化 System.Uri 类的新实例。
                    //如果不包含http，则认为超链接是相对路径，根据baseUrl建立绝对路径
                    url = currentUri.AbsoluteUri;
                    //Console.WriteLine("######" + url + "######");
                    args.UrlDictionary.Add(url, Guid.NewGuid().ToString());
                }
            }
            //return args.UrlDictionary;
        }

        /// <summary>
        /// 处理UrlDictionary，筛选+做的是减法
        /// </summary>
        /// <param name="args"></param>
        /// <param name="patternStr"></param>
        private static void CustomParseLink_MainList(CustomParseLinkEvent3Args args, string patternStr)
        {
            Dictionary<string, string> temp = new Dictionary<string, string>();
            foreach (var item in args.UrlDictionary)
            {
                string href = item.Key;
                string text = item.Value;

                if (!string.IsNullOrEmpty(href))
                {
                    Regex regex = new Regex(patternStr, RegexOptions.IgnoreCase);//忽略大小写
                    Match mat = regex.Match(href);
                    if (mat.Success)
                    {
                        temp.Add(href, text);
                    }
                }
            }
            args.UrlDictionary = temp;
        }

        #endregion
        #region 方法=》数据输出
        private static void writeToLogView(DataReceivedEventArgs dataReceived)
        {
            //Kiwi-log           
            kiwiConsole.WriteOutput(DateTime.Now.ToString() + " -" + fileId + "-" + dataReceived.Url + "\r\n", Color.Green);
        }

        private static void WriteToFiles(DataReceivedEventArgs dataReceived)
        {
            KiwiCrawler.BLL.Capturedata_kBll bll = new KiwiCrawler.BLL.Capturedata_kBll();
            KiwiCrawler.Model.Capturedata_k model = new KiwiCrawler.Model.Capturedata_k();
            model.kCaptureDateTime = DateTime.Now;
            model.kContent = dataReceived.Html.Trim();
            model.kType = configModel.kAddressBusinessType.Trim();//民政部门；安全生产监督管理局；地震局
            model.kUrl = dataReceived.Url;
            fileId++;
            model.kNumber = fileId;
            model.kNotes = configModel.kKeyWords;
            bll.Add(model);
            writeToLogView(dataReceived);
            if (strExit== String.Join("", kiwiThreadStatus).ToLower())
            {
                kiwiConsole.WriteOutput(DateTime.Now.ToString()+" 任务结束",Color.OrangeRed);
            }
        }
        #endregion
        #region 方法=》设置

        private static void SettingDefaultValues()
        {
            filter = new BloomFilter<string>(200000);
            //const string CityName = "beijing";

            // 设置种子地址
            #region 设置种子地址
            //Settings.SeedsAddress.Add(string.Format("http://jobs.zhaopin.com/{0}", CityName));//招聘
            //Settings.SeedsAddress.Add("http://news.sdau.edu.cn/list.php?pid=3"); 山农大
            //Settings.SeedsAddress.Add("http://sxmwr.gov.cn/sxmwr-xxgk-dfkj-1-list-351");//陕西OK 1766+59=1825
            //Settings.SeedsAddress.Add("http://www.zsblr.gov.cn/mlx/tdsc/tdzpgxxgg/");//舟山OK 349+18=367
            //Settings.SeedsAddress.Add("http://www.bjmzj.gov.cn/templet/mzj/ShowMoreArticle.jsp?CLASS_ID=tzgg");//北京市民政部门--官网有异常
            //Settings.SeedsAddress.Add("http://www.shmzj.gov.cn/gb/shmzj/node4/node10/n2435/index.html");//上海民政局--67个时报异常
            //Settings.SeedsAddress.Add("http://www.bjdzj.gov.cn/manage/html/402881ff1ee8d7a7011ee8da76040001/zqzq/index.html");//北京市地震局--93个退出
            //Settings.SeedsAddress.Add("http://www.bjsafety.gov.cn/accidentinfor/sgkb/index.html?nav=20&sub=0");//北京安监局OK 100+5=105
            //Settings.SeedsAddress.Add("http://beijing.anjuke.com/sale/?from=navigation");//北京安居客 
            #endregion
            //Settings.SeedsAddress.Add(config.kUrl);
            // 设置 URL 关键字
            //Settings.HrefKeywords.Add(string.Format("/{0}/bj", CityName));
            //config对象里的kKeyWord属性跟这里的URL关键字不是一回事

            // 设置爬取线程个数
            Settings.ThreadCount = 1;

            // 设置爬取深度
            Settings.Depth = 100;//页码数+1

            // 设置爬取时忽略的 Link，通过后缀名的方式，可以添加多个
            Settings.EscapeLinks.Add(".jpg");

            // 设置自动限速，1~5 秒随机间隔的自动限速
            Settings.AutoSpeedLimit = true;

            // 设置都是锁定域名,去除二级域名后，判断域名是否相等，相等则认为是同一个站点
            // 例如：mail.pzcast.com 和 www.pzcast.com
            Settings.LockHost = false;
        }
        private bool SettingCustomValues(Int32 tag)
        {
            bool isOk = true;
            configModel = GetModelByRow();
            //爬虫配置
            filter = new BloomFilter<string>(200000);
            //线程
            if (radioThreadC.Checked && !(String.IsNullOrEmpty(txtThread.Text.Trim())))
            {
                Settings.ThreadCount = Convert.ToByte(txtThread.Text.Trim());
            }
            if (radioThreadM.Checked)
            {
                Settings.ThreadCount = 1;
            }
            //深度
            if (radioDepthC.Checked && !(String.IsNullOrEmpty(txtDepth.Text.Trim())))
            {
                Settings.Depth = Convert.ToByte(txtDepth.Text.Trim());
            }
            if (radioDepthM.Checked)
            {
                Settings.Depth = configModel.kPageTotal == null ? Convert.ToByte(100) : Convert.ToByte(configModel.kPageTotal + 1);
            }
            //速度1~5
            if (radioSpeedNo.Checked)
            {
                Settings.AutoSpeedLimit = false;
            }
            if (radioSpeedYes.Checked)
            {
                Settings.AutoSpeedLimit = true;
            }
            if (string.IsNullOrEmpty(configModel.kUrl))
            {
                isOk = false;
                MessageBox.Show("种子地址为空");
            }
            else
            {
                if (tag==0)//0代表单个点击模式
                {
                    Settings.SeedsAddress.Clear();
                    Settings.SeedsAddress.Add(configModel.kUrl);
                }
                
            }
            // 设置爬取时忽略的 Link，通过后缀名的方式，可以添加多个
            Settings.EscapeLinks.Add(".jpg");
            // 设置 URL 关键字
            // Settings.HrefKeywords.Add(string.Format("/{0}/bj", CityName));
            // 设置都是锁定域名,去除二级域名后，判断域名是否相等，相等则认为是同一个站点
            // 例如：mail.pzcast.com 和 www.pzcast.com
            Settings.LockHost = false;
            //URL配置
            // 设置请求的 User-Agent HTTP 标头的值
            // settings.UserAgent 已提供默认值，如有特殊需求则自行设置

            // 设置请求页面的超时时间，默认值 15000 毫秒
            // settings.Timeout 按照自己的要求确定超时时间

            // 设置用于过滤的正则表达式
            //Settings.RegularFilterExpressions.Add("<a .+ href='(.+)'>下一页</a>");//  string strReg = "<a .+ href='(.+)'>下一页</a>";

            if (configModel.kDetailPatternType == "正则表达式")
            {
                if (string.IsNullOrEmpty(configModel.kDetailPattern))
                {
                    isOk = false;
                    MessageBox.Show("详细页提取模板为空");
                }
                //else
                //{
                //    detailRegStr = model.kDetailPattern;
                //}

            }
            if (configModel.kNextPagePatternType == "正则表达式")
            {
                if (string.IsNullOrEmpty(configModel.kNextPagePattern))
                {
                    isOk = false;
                    MessageBox.Show("下一页提取模板为空");
                }
                //else
                //{
                //    nextPageStr = model.kNextPagePattern;    
                //}                
            }
            return isOk;


        }

        private static CrawlMaster SetCrawler()
        {
            //SettingDefaultValues();
            //SettingCustomValues();
            var master = new CrawlMaster(Settings);
            master.AddUrlEvent += MasterAddUrlEvent;
            master.DataReceivedEvent += MasterDataReceivedEvent;
            // master.CustomParseLinkEvent2 += Master_CustomParseLinkEvent2;
            master.CustomParseLinkEvent3 += Master_CustomParseLinkEvent3;
       
            return master;
        }
        #endregion

        #region 窗体交互

        private void btnAccessDB_Click(object sender, EventArgs e)
        {
            KiwiCrawler.BLL.Capturedata_kBll bll = new KiwiCrawler.BLL.Capturedata_kBll();
            KiwiCrawler.Model.Capturedata_k model = new KiwiCrawler.Model.Capturedata_k();
            MessageBox.Show(bll.GetMaxId().ToString());

        }
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            TabPage focusPage = e.TabPage;
            switch (focusPage.Text)
            {
                case "任务抓取":
                    dgvTaskCapture.Rows.Clear();
                    Urlconfigs_kBll urlBll = new Urlconfigs_kBll();
                    List<Urlconfigs_k> urlList = null;
                    urlList = urlBll.GetModelList("");
                    //dataGridView1.DataSource = urlList;
                    //ListToDataGridView(dgvTaskCapture,headerTitle,urlList);
                    ListToDataGridView(dgvTaskCapture, urlList);
                    break;
                default:
                    break;
            }
        }
        private void ListToDataGridView(DataGridView dgv, List<KiwiCrawler.Model.Urlconfigs_k> list)
        {
            if (list != null)
            {
                foreach (Urlconfigs_k model in list)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgv);
                    #region 添加CheckCell

                    //添加CheckCell
                    //DataGridViewCheckBoxCell checkCell = new DataGridViewCheckBoxCell();
                    //row.Cells[0] = checkCell;
                    //row.Cells[1].Value = model.kId;
                    //row.Cells[2].Value = model.kUrl;
                    //row.Cells[3].Value = model.kPageTotal;
                    //row.Cells[4].Value = model.kCaptureType;
                    //row.Cells[5].Value = model.kDetailPattern;
                    //row.Cells[6].Value = model.kDetailPatternType;
                    //row.Cells[7].Value = model.kNextPagePattern;
                    //row.Cells[8].Value = model.kNextPagePatternType;
                    //row.Cells[9].Value = model.kComplateDegree;
                    //row.Cells[10].Value = model.kAddressBusinessType;
                    //row.Cells[11].Value = model.kKeyWords;
                    //row.Cells[12].Value = "抓取"; 
                    #endregion
                    row.Cells[0].Value = model.kId;
                    row.Cells[1].Value = model.kUrl;
                    row.Cells[2].Value = model.kPageTotal;
                    row.Cells[3].Value = model.kCaptureType;
                    row.Cells[4].Value = model.kDetailPattern;
                    row.Cells[5].Value = model.kDetailPatternType;
                    row.Cells[6].Value = model.kNextPagePattern;
                    row.Cells[7].Value = model.kNextPagePatternType;
                    row.Cells[8].Value = model.kComplateDegree;
                    row.Cells[9].Value = model.kAddressBusinessType;
                    row.Cells[10].Value = model.kKeyWords;
                    row.Cells[11].Value = "抓取";
                    dgv.Rows.Add(row);
                }
            }


        }

        private void dgvTaskCapture_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region 控制CheckCell
            //if (e.ColumnIndex == 0)
            //{
            //    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dgvTaskCapture.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //    if (checkCell.Value==null)
            //    {
            //        checkCell.Value = true;
            //    }
            //    else
            //    {
            //        checkCell.Value = !(Boolean)checkCell.Value;
            //    }
            //} 
            #endregion
            if (e.ColumnIndex == 11)
            {
                //获得id
                //dgvTaskCapture.Rows[e.RowIndex].Cells[0].Value.ToString() 
                //Settings = null;         
                if (SettingCustomValues(0))
                {
                    // SetCrawler();
                    kiwiConsole.ClearOutput();
                    fileId = 0;
                    var master = SetCrawler();
                    kiwiThreadStatus = master.ThreadStatus;
                    strExit = "";
                    for (int i = 0; i < kiwiThreadStatus.Count(); i++)
                    {
                        strExit += "true";
                    }
                    master.Crawl();

                }

            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAdd frmAdd_k = new frmAdd();
            //frmAdd_k.ShowDialog();
            if (frmAdd_k.ShowDialog(this) == DialogResult.Cancel)
            {
                //为了保证一致性，不在内存中读对象。
                //KiwiCrawler.Model.Urlconfigs_k urlConfigFrmMode = frmAdd_k.urlFrmMode_k;
                dgvTaskCapture.Rows.Clear();
                Urlconfigs_kBll urlBll = new Urlconfigs_kBll();
                List<Urlconfigs_k> urlList = null;
                urlList = urlBll.GetModelList("");//后期改成分页的          
                ListToDataGridView(dgvTaskCapture, urlList);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //获得Row里的值
            KiwiCrawler.Model.Urlconfigs_k model = GetModelByRow();

            frmEdit frmEdit_k = new frmEdit(model);
            if (frmEdit_k.ShowDialog(this) == DialogResult.Cancel)
            {
                dgvTaskCapture.Rows.Clear();
                Urlconfigs_kBll urlBll = new Urlconfigs_kBll();
                List<Urlconfigs_k> urlList = null;
                urlList = urlBll.GetModelList("");//后期改成分页的          
                ListToDataGridView(dgvTaskCapture, urlList);
            }
        }

        private Urlconfigs_k GetModelByRow()
        {
            KiwiCrawler.Model.Urlconfigs_k model = new Urlconfigs_k();
            model.kId = Convert.ToInt32(dgvTaskCapture.SelectedRows[0].Cells[0].Value.ToString().Trim());
            model.kUrl = dgvTaskCapture.SelectedRows[0].Cells[1].Value.ToString().Trim();
            model.kPageTotal = dgvTaskCapture.SelectedRows[0].Cells[2].Value == null ? null : (int?)Convert.ToInt32(dgvTaskCapture.SelectedRows[0].Cells[2].Value);
            model.kCaptureType = dgvTaskCapture.SelectedRows[0].Cells[3].Value.ToString().Trim();
            model.kDetailPattern = dgvTaskCapture.SelectedRows[0].Cells[4].Value.ToString();
            model.kDetailPatternType = dgvTaskCapture.SelectedRows[0].Cells[5].Value.ToString().Trim();
            model.kNextPagePattern = dgvTaskCapture.SelectedRows[0].Cells[6].Value.ToString();
            model.kNextPagePatternType = dgvTaskCapture.SelectedRows[0].Cells[7].Value.ToString().Trim();
            model.kComplateDegree = dgvTaskCapture.SelectedRows[0].Cells[8].Value == null ? null : (decimal?)Convert.ToDecimal(dgvTaskCapture.SelectedRows[0].Cells[8].Value);
            model.kAddressBusinessType = dgvTaskCapture.SelectedRows[0].Cells[9].Value.ToString();
            model.kKeyWords = dgvTaskCapture.SelectedRows[0].Cells[10].Value.ToString().Trim();
            return model;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Urlconfigs_kBll urlBll = new Urlconfigs_kBll();
            urlBll.Delete(Convert.ToInt32(dgvTaskCapture.SelectedRows[0].Cells[0].Value));//id是自动生成的，应该不会有错
            //刷新
            dgvTaskCapture.Rows.Clear();
            List<Urlconfigs_k> urlList = null;
            urlList = urlBll.GetModelList("");//后期改成分页的            
            ListToDataGridView(dgvTaskCapture, urlList);

        }

        private void radioThreadM_CheckedChanged(object sender, EventArgs e)
        {
            txtThread.Enabled = !radioThreadM.Checked;
        }

        private void radioDepthM_CheckedChanged(object sender, EventArgs e)
        {
            txtDepth.Enabled = !radioDepthM.Checked;
        }

        #endregion
    }
}
;