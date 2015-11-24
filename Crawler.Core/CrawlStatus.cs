// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrawlStatus.cs" company="pzcast">
//   (C) 2015 pzcast. All rights reserved.
// </copyright>
// <summary>
//   The crawl status.
//   爬行状态：1--已经完成；2--没有完成
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace KiwiCrawler.Core
{
    /// <summary>
    /// The crawl status.
    /// </summary>
    public enum CrawlStatus
    {
        /// <summary>
        /// The completed.
        /// 已经完成
        /// </summary>
        Completed = 1,

        /// <summary>
        /// The never been.
        /// 从来没有过。
        /// </summary>
        NeverBeen = 2
    }
}