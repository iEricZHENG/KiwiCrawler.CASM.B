using System;
namespace KiwiCrawler.Model
{
	/// <summary>
	/// Extractdata_k:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Extractdata_k
	{
		public Extractdata_k()
		{}
		#region Model
		private int _kid;
		private string _kurl;
		private DateTime? _kpublishdatetime;
		private string _kcontent;
		private string _kaddress;
		private string _ktype;
		private DateTime _kcapturedatetime;
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
		public DateTime? kPublishDateTime
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
		public string kAddress
		{
			set{ _kaddress=value;}
			get{return _kaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string kType
		{
			set{ _ktype=value;}
			get{return _ktype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime kCaptureDateTime
		{
			set{ _kcapturedatetime=value;}
			get{return _kcapturedatetime;}
		}
		#endregion Model

	}
}

