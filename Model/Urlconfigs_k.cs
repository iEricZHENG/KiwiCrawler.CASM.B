using System;
namespace KiwiCrawler.Model
{
	/// <summary>
	/// Urlconfigs_k:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Urlconfigs_k
	{
		public Urlconfigs_k()
		{}
		#region Model
		private int _kid;
		private string _kurl;
		private int? _kpagetotal;
		private string _kcapturetype;
		private string _kdetailpattern;
		private string _kdetailpatterntype;
		private string _knextpagepattern;
		private string _knextpagepatterntype;
		private decimal? _kcomplatedegree=0M;
		private string _kaddressbusinesstype;
		private string _kkeywords;
        private string _knotes;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int kId
		{
			set{ _kid=value;}
			get{return _kid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string kUrl
		{
			set{ _kurl=value;}
			get{return _kurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? kPageTotal
		{
			set{ _kpagetotal=value;}
			get{return _kpagetotal;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string kCaptureType
		{
			set{ _kcapturetype=value;}
			get{return _kcapturetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string kDetailPattern
		{
			set{ _kdetailpattern=value;}
			get{return _kdetailpattern;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string kDetailPatternType
		{
			set{ _kdetailpatterntype=value;}
			get{return _kdetailpatterntype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string kNextPagePattern
		{
			set{ _knextpagepattern=value;}
			get{return _knextpagepattern;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string kNextPagePatternType
		{
			set{ _knextpagepatterntype=value;}
			get{return _knextpagepatterntype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? kComplateDegree
		{
			set{ _kcomplatedegree=value;}
			get{return _kcomplatedegree;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string kAddressBusinessType
		{
			set{ _kaddressbusinesstype=value;}
			get{return _kaddressbusinesstype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string kKeyWords
		{
			set{ _kkeywords=value;}
			get{return _kkeywords;}
		}

        public string kNotes
        {
            get
            {
                return _knotes;
            }

            set
            {
                _knotes = value;
            }
        }
        #endregion Model

    }
}

