namespace KiwiCrawler.Core
{
    using System;
    using System.Collections.Generic;

    public delegate Dictionary<string, string> CustomParseLinkEvent2Handler(CustomParseLinkEvent2Args args);

    public class CustomParseLinkEvent2Args : EventArgs
    {
        #region Public Properties

        public UrlInfo UrlInfo { get; set; }
        public Dictionary<string, string> UrlDictionary { get; set; }

        public string Html { get; set; }

        #endregion Public Properties
    }

    public delegate void CustomParseLinkEvent3Handler(CustomParseLinkEvent3Args args);

    public class CustomParseLinkEvent3Args : EventArgs
    {
        #region Public Properties

        public UrlInfo UrlInfo { get; set; }
        public Dictionary<string, string> UrlDictionary { get; set; }

        public string Html { get; set; }

        #endregion Public Properties
    }
}