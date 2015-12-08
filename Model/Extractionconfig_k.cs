using System;
namespace KiwiCrawler.Model
{
	/// <summary>
	/// Extractionconfig_k:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Extractionconfig_k
	{
		public Extractionconfig_k()
		{}
		#region Model
		private int _kid;
		private string _kurl;
		private string _ktitle;
		private DateTime? _kpublishdatetime;
		private string _kcontent;
		private string _kaddressbusinesstype;
		private string _kkeyword;
		private decimal? _kpercent;
		/// <summary>
		/// 
		/// </summary>
		public int KId
		{
			set{ _kid=value;}
			get{return _kid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KUrl
		{
			set{ _kurl=value;}
			get{return _kurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KTitle
		{
			set{ _ktitle=value;}
			get{return _ktitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? KPublishDateTime
		{
			set{ _kpublishdatetime=value;}
			get{return _kpublishdatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KContent
		{
			set{ _kcontent=value;}
			get{return _kcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KAddressBusinessType
		{
			set{ _kaddressbusinesstype=value;}
			get{return _kaddressbusinesstype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KKeyword
		{
			set{ _kkeyword=value;}
			get{return _kkeyword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? KPercent
		{
			set{ _kpercent=value;}
			get{return _kpercent;}
		}
		#endregion Model

	}
}

