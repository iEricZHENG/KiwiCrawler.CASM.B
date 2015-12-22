using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormKiwiCrawler
{
    public class CrawlerConfigMode
    {
        /*
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

            // 设置请求的 User-Agent HTTP 标头的值
            // settings.UserAgent 已提供默认值，如有特殊需求则自行设置

            // 设置请求页面的超时时间，默认值 15000 毫秒
            // settings.Timeout 按照自己的要求确定超时时间

            // 设置用于过滤的正则表达式
            //Settings.RegularFilterExpressions.Add("<a .+ href='(.+)'>下一页</a>");//  string strReg = "<a .+ href='(.+)'>下一页</a>";
         * */
        public Int32 ThreadCount { get; set; }
        public Int32 Depth { get; set; }
        //public string 
    }
}
