// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrawlSettings.cs" company="pzcast">
//   (C) 2015 pzcast. All rights reserved.
// </copyright>
// <summary>
//   The crawl settings.
//  （爬虫设置）
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace KiwiCrawler.Core
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// CrawlSettings（爬虫设置）
    /// </summary>
    [Serializable]
    public class CrawlSettings
    {
        #region Fields（字段）

        /// <summary>
        /// The depth（深度）.
        /// </summary>
        private byte depth = 3;

        /// <summary>
        /// The lock host（锁定主机）.
        /// </summary>
        private bool lockHost = true;

        /// <summary>
        /// The thread count（线程数）.
        /// </summary>
        private byte threadCount = 1;

        /// <summary>
        /// The timeout（超时）.
        /// </summary>
        private int timeout = 15000;

        /// <summary>
        /// The user agent（用户代理）.
        /// </summary>
        private string userAgent =
            "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.97 Safari/537.11";

        #endregion Fields（字段）

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CrawlSettings"/> class.
        /// 初始化实例
        /// </summary>
        public CrawlSettings()
        {
            this.AutoSpeedLimit = false;
            this.EscapeLinks = new List<string>();
            this.KeepCookie = true;
            this.HrefKeywords = new List<string>();
            this.LockHost = true;
            this.RegularFilterExpressions = new List<string>();
            this.SeedsAddress = new List<string>();
        }

        #endregion Constructors and Destructors

        #region Public Properties（公共属性）

        /// <summary>
        /// Gets or sets a value indicating whether auto speed limit.
        /// 获取或设置一个值，该值指示是否进行速度限制。
        /// 限速通过使线程睡眠实现。
        ///  1~5 秒随机间隔的自动限速
        ///  if (this.Settings.AutoSpeedLimit)
        ///  {
        ///  int span = this.random.Next(1000, 5000);
        ///  Thread.Sleep(span);
        ///  }
        /// </summary>
        public bool AutoSpeedLimit { get; set; }

        /// <summary>
        /// Gets or sets the depth.
        /// 获取或设置深度。
        /// </summary>
        public byte Depth
        {
            get
            {
                return this.depth;
            }

            set
            {
                this.depth = value;
            }
        }

        /// <summary>
        /// Gets the escape links.
        /// 获取转义链接。
        /// </summary>
        public List<string> EscapeLinks { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether keep cookie.
        /// 获取或设置一个值，该值指示是否保持 cookie。
        /// </summary>
        public bool KeepCookie { get; set; }

        /// <summary>
        /// Gets the href keywords.
        /// 获取 href 关键字。
        /// </summary>
        public List<string> HrefKeywords { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether lock host.
        /// 获取或设置一个值，该值指示是否锁定主机。
        /// </summary>
        public bool LockHost
        {
            get
            {
                return this.lockHost;
            }

            set
            {
                this.lockHost = value;
            }
        }

        /// <summary>
        /// Gets the regular（规则） filter（筛选器） expressions.
        /// 获取筛选器表达式。
        /// </summary>
        public List<string> RegularFilterExpressions { get; private set; }

        /// <summary>
        /// Gets  the seeds address.
        /// 获取种子地址
        /// </summary>
        public List<string> SeedsAddress { get; private set; }

        /// <summary>
        /// Gets or sets the thread count.
        /// 获取或设置线程数。
        /// </summary>
        public byte ThreadCount
        {
            get
            {
                return this.threadCount;
            }

            set
            {
                this.threadCount = value;
            }
        }

        /// <summary>
        /// Gets or sets the timeout.
        /// 获取或设置超时时间。
        /// </summary>
        public int Timeout
        {
            get
            {
                return this.timeout;
            }

            set
            {
                this.timeout = value;
            }
        }

        /// <summary>
        /// Gets or sets the user agent.
        /// 获取或设置用户代理。
        /// </summary>
        public string UserAgent
        {
            get
            {
                return this.userAgent;
            }

            set
            {
                this.userAgent = value;
            }
        }

        #endregion Public Properties（公共属性）
    }
}