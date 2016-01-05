
/// <summary>
/// Kiwi
/// </summary>
namespace Crawler.Core
{
    using KiwiCrawler.Core;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public delegate void DynamicGoNextPageEventHandler(DynamicGoNextPageEventArgs args);
    public class DynamicGoNextPageEventArgs:EventArgs
    {
        public UrlInfo UrlInfo { get; set; }
        //public Dictionary<string, string> UrlDictionary { get; set; }                
        public WebBrowser WorkBrowser { get; set; }
        //public WebBrowser StateBrowser { get; set; }
        public Int32 PageIndex { get; set; }
    }
}
