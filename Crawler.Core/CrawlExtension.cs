// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrawlExtension.cs" company="pzcast">
//   (C) 2015 pzcast. All rights reserved.
// </copyright>
// <summary>
//   The crawl extension.
//   获得URL的唯一标识
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace KiwiCrawler.Core
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// The crawl extension.
    /// </summary>
    public static class CrawlExtension
    {
        #region Public Methods and Operators（公共方法和操作）

        /// <summary>
        /// 获得URL的唯一标识
        /// </summary>
        /// <param name="urlInfo">
        /// The url info.
        /// </param>
        /// <returns>
        /// The <see cref="ulong"/>.
        /// </returns>
        public static ulong GetUniqueIdentifier(this UrlInfo urlInfo)
        {
            byte[] bytes = Encoding.Default.GetBytes(urlInfo.UrlString);

            var service = new MD5CryptoServiceProvider();
            byte[] hashValue = service.ComputeHash(bytes);

            return BitConverter.ToUInt64(hashValue, 0);
        }

        #endregion Public Methods and Operators（公共方法和操作）
    }
}