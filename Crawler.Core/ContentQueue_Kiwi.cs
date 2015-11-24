using KiwiCrawler.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crawler.Core
{
    /// <summary>
    /// 爬取结果页面队列
    /// </summary>
    public class ContentQueue_Kiwi : SecurityQueue<String>
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        private ContentQueue_Kiwi() { }
        public static ContentQueue_Kiwi Instance
        {
            get
            {
                return Nested.Inner;
            }
        }
        private static class Nested
        {
            public static readonly ContentQueue_Kiwi Inner = new ContentQueue_Kiwi();
        }
    }
    /// <summary>
    /// 爬取结果返回参数队列
    /// </summary>
    public class DataReceivedEventArgs_Kiwi : SecurityQueue<DataReceivedEventArgs>
    {
        private DataReceivedEventArgs_Kiwi() { }
        public static DataReceivedEventArgs_Kiwi Instance
        {
            get
            {
                return Nested.Inner;
            }
        }
        private static class Nested
        {
            public static readonly DataReceivedEventArgs_Kiwi Inner = new DataReceivedEventArgs_Kiwi();
        }
    }
}
