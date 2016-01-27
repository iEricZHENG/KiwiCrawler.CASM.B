
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
		private string _kpublishdatetime;
		private string _kcontent;
		private string _kextraciontype;
		private string _kaddressbusinesstype;
		private string _kkeywords;
		private decimal? _kpercent;
		/// <summary>
		/// 
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
		public string kTitle
		{
			set{ _ktitle=value;}
			get{return _ktitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string kPublishDateTime
		{
			set{ _kpublishdatetime=value;}
			get{return _kpublishdatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string kContent
		{
			set{ _kcontent=value;}
			get{return _kcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string kExtracionType
		{
			set{ _kextraciontype=value;}
			get{return _kextraciontype;}
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
		public string kKeywords
		{
			set{ _kkeywords=value;}
			get{return _kkeywords;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? kPercent
		{
			set{ _kpercent=value;}
			get{return _kpercent;}
		}
		#endregion Model

	}
}

