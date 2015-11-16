// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UrlInfo.cs" company="pzcast">
//   (C) 2015 pzcast. All rights reserved.
// </copyright>
// <summary>
//   The url info.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace KiwiCrawler.Core
{
    /// <summary>
    /// The url info.
    /// </summary>
    public class UrlInfo
    {
        #region Fields

        /// <summary>
        /// The url.
        /// </summary>
        private readonly string url;

        #endregion Fields

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UrlInfo"/> class.
        /// </summary>
        /// <param name="urlString">
        /// The url string.
        /// </param>
        public UrlInfo(string urlString)
        {
            this.url = urlString;
        }

        #endregion Constructors and Destructors

        #region Public Properties（公共属性）

        /// <summary>
        /// Gets or sets the depth.
        /// 获得或者设置深度。
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// Gets the url string.
        /// 获得URL
        /// </summary>
        public string UrlString
        {
            get
            {
                return this.url;
            }
        }

        /// <summary>
        /// Gets or sets the status.
        /// 获得或者设置爬行状态
        /// </summary>
        public CrawlStatus Status { get; set; }

        #endregion Public Properties（公共属性）
    }
}