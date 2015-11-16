namespace FormKiwiCrawler
{
    using Crawler.Core;
    using KiwiCrawler.Core;
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
        #region Static Fields

        /// <summary>
        /// The settings.
        /// </summary>
        private static readonly CrawlSettings Settings = new CrawlSettings();

        /// <summary>
        /// The filter.
        /// 关于使用 Bloom 算法去除重复 URL：http://www.cnblogs.com/heaad/archive/2011/01/02/1924195.html
        /// </summary>
        private static BloomFilter<string> filter;

        private static Int32 fileId = 0;
        #region 原来的文件地址
        //private static string filePath = AppDomain.CurrentDomain.BaseDirectory + @"\Files\";
        //private static string articlePath = AppDomain.CurrentDomain.BaseDirectory + @"\Articles\";
        //private static string urlFilePath = AppDomain.CurrentDomain.BaseDirectory + @"\UrlFile\url.txt"; 
        #endregion
        //private static ContentQueue_Kiwi fileQueue = new ContentQueue_Kiwi(); 

        #endregion Static Fields
        public Main()
        {
            InitializeComponent();
        }

       

        /// <summary>
        /// The master data received event.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>

        private static void MasterDataReceivedEvent(DataReceivedEventArgs args)
        {
            // 在此处解析页面，可以用类似于 HtmlAgilityPack（页面解析组件）的东东、也可以用正则表达式、还可以自己进行字符串分析
            //NSoup.Nodes.Document doc = NSoup.NSoupClient.Parse(args.Html);

            #region 接收数据处理，//如果有问题可以使用多线程
            ContentQueue_Kiwi.Instance.EnQueue(args.Html);
            ThreadPool.QueueUserWorkItem(o =>
            {
                while (true)
                {
                    try
                    {
                        if (ContentQueue_Kiwi.Instance.Count > 0)
                        {
                            fileId++;
                            string fileContent = ContentQueue_Kiwi.Instance.DeQueue();
                            if (!String.IsNullOrEmpty(fileContent)&&fileContent.Trim() != "")
                            {
                                WriteToFiles(fileContent);
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
        #region 超链接提取的主要接口

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

        #endregion 自定义代码

        #region 添加超链接事件
        /// <summary>
        /// The master add url event.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool MasterAddUrlEvent(AddUrlEventArgs args)
        {
            if (!filter.Contains(args.Url))//不包含就添加
            {
                filter.Add(args.Url);
                #region 持久化URL
                //Console.WriteLine(args.Url);
                //File.AppendAllText(urlFilePath, args.Url + "\r\n"); 
                #endregion
                return true;
            }

            return false; // 返回 false 代表：不添加到队列中
        }
        #endregion
        #region 自定义代码
        private void btnRun_Click(object sender, EventArgs e)
        {
            filter = new BloomFilter<string>(200000);
            //const string CityName = "beijing";

            // 设置种子地址
            //Settings.SeedsAddress.Add(string.Format("http://jobs.zhaopin.com/{0}", CityName));//
            //Settings.SeedsAddress.Add("http://news.sdau.edu.cn/list.php?pid=3"); sdau
            Settings.SeedsAddress.Add("http://www.shdrc.gov.cn/gcxm/sub1.jsp?lb=001001");
            //Settings.SeedsAddress.Add("http://beijing.anjuke.com/sale/?from=navigation");
            //Settings.SeedsAddress.Add("   ");
            // 设置 URL 关键字
            //Settings.HrefKeywords.Add(string.Format("/{0}/bj", CityName));
            //Settings.HrefKeywords.Add(string.Format("/{0}/sj", CityName));

            // 设置爬取线程个数
            Settings.ThreadCount = 1;

            // 设置爬取深度
            Settings.Depth = 59;//页码数+1

            // 设置爬取时忽略的 Link，通过后缀名的方式，可以添加多个
            Settings.EscapeLinks.Add(".jpg");

            // 设置自动限速，1~5 秒随机间隔的自动限速
            Settings.AutoSpeedLimit = false;

            // 设置都是锁定域名,去除二级域名后，判断域名是否相等，相等则认为是同一个站点
            // 例如：mail.pzcast.com 和 www.pzcast.com
            Settings.LockHost = false;

            // 设置请求的 User-Agent HTTP 标头的值
            // settings.UserAgent 已提供默认值，如有特殊需求则自行设置

            // 设置请求页面的超时时间，默认值 15000 毫秒
            // settings.Timeout 按照自己的要求确定超时时间

            // 设置用于过滤的正则表达式
            //Settings.RegularFilterExpressions.Add("<a .+ href='(.+)'>下一页</a>");//  string strReg = "<a .+ href='(.+)'>下一页</a>";

            var master = new CrawlMaster(Settings);
            master.AddUrlEvent += MasterAddUrlEvent;
            master.DataReceivedEvent += MasterDataReceivedEvent;
            // master.CustomParseLinkEvent2 += Master_CustomParseLinkEvent2;
            master.CustomParseLinkEvent3 += Master_CustomParseLinkEvent3;
            master.Crawl();
        }
        /// <summary>
        /// 文件提取
        /// </summary>
        /// <param name="fileContent"></param>
        private static void WriteToFiles(string fileContent)
        {
            //NSoup.Nodes.Document doc = NSoup.NSoupClient.Parse(fileContent);
            //using (FileStream fsWriter = new FileStream(filePath + fileId + doc.Title + ".html", FileMode.Create, FileAccess.Write))
            //{
            //    byte[] buffer = System.Text.Encoding.Default.GetBytes(fileContent);
            //    fsWriter.Write(buffer, 0, buffer.Length);
            //}

            //Article article = Html2Article.GetArticle(fileContent);
            //if (!String.IsNullOrEmpty(article.Content))
            //{
            //    //Console.WriteLine(article.Content);
            //    using (FileStream fsWriter = new FileStream(articlePath + fileId + doc.Title + ".txt", FileMode.Create, FileAccess.Write))
            //    {
            //        byte[] buffer = System.Text.Encoding.Default.GetBytes(article.Content);
            //        fsWriter.Write(buffer, 0, buffer.Length);
            //    }
            //}
        }

        private static void Master_CustomParseLinkEvent3(CustomParseLinkEvent3Args args)
        {
            /*sdau
            CustomParseLink_MainList(args, "(view).+?([0-9]{5})");//去除,下一步，拼写一个大的正则表达式就好
            CustomParseLink_NextPageSdau(args, "<a .+ href='(.+)'>下一页</a>", 1);//添加，下一步，拼写一个大的正则表达式就好
            */
            //去除,下一步，拼写一个大的正则表达式就好
            CustomParseLink_MainList(args, @"detail1.jsp.*id=\d*");
            //添加，下一步，拼写一个大的正则表达式就好
            CustomParseLink_NextPageSdau(args, @"<A .*HREF=(.+) class.*>\s*下一页</A>", 1);
            //CustomParseLink_MainList(args, "http://beijing.anjuke.com/prop/view/.*commsearch_p");
            //CustomParseLink_NextPageSdau(args, "<a href='(.+)' class='aNxt'>下一页 &gt;</a>", 1);
            //CustomParseLink_NextPageSdau(args, "http://beijing.anjuke.com/prop/view/.*commsearch_p", 0);
        }
        #endregion

        private void btnAccessDB_Click(object sender, EventArgs e)
        {
            KiwiCrawler.BLL.Capturedata_kBll bll = new KiwiCrawler.BLL.Capturedata_kBll();

        }
      

    }
}
