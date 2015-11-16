// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddUrlEventArgs.cs" company="pzcast">
//   (C) 2015 pzcast. All rights reserved.
// </copyright>
// <summary>
//   The add url event args.
//   添加 url 事件参数。
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace KiwiCrawler.Core
{
    using System;

    /// <summary>
    /// The add url event handler.
    /// 添加 url 事件处理。
    /// </summary>
    /// <param name="args">
    /// The args.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    public delegate bool AddUrlEventHandler(AddUrlEventArgs args);

    /// <summary>
    /// The add url event args.
    /// 添加 url 事件参数。
    /// </summary>
    public class AddUrlEventArgs : EventArgs
    {
        #region Public Properties(公共属性)

        /// <summary>
        /// Gets or sets the depth.
        /// 获得或者设置深度。
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// 获得或者设置title。
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the url.
        /// 获得或者设置URL。
        /// </summary>
        public string Url { get; set; }

        #endregion Public Properties(公共属性)
    }
}