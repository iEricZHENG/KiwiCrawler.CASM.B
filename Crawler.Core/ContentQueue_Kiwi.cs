using KiwiCrawler.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crawler.Core
{
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
}
