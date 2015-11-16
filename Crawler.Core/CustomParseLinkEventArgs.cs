namespace KiwiCrawler.Core
{
    using System;

    public delegate UrlInfo CustomParseLinkEventHandler(DataReceivedEventArgs args);

    //public class CustomParseLinkEventArgs : EventArgs
    //{
    //    #region Public Properties

    //    /// <summary>
    //    /// Gets or sets the depth.
    //    /// </summary>
    //    public int Depth { get; set; }

    //    /// <summary>
    //    /// Gets or sets the html.
    //    /// </summary>
    //    public string Html { get; set; }

    //    /// <summary>
    //    /// Gets or sets the url.
    //    /// </summary>
    //    public string Url { get; set; }

    //    #endregion
    //}
}