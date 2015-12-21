using System;
namespace KiwiCrawler.Model
{
	/// <summary>
	/// Deletedrecord_k:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Deletedrecord_k
	{
		public Deletedrecord_k()
		{}
		#region Model
		private int _kid;
		private int _kcapturedataid;
		private DateTime _kdeletedatetime;
		private string _knotes;
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
		public int kCapturedataId
		{
			set{ _kcapturedataid=value;}
			get{return _kcapturedataid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime kDeleteDatetime
		{
			set{ _kdeletedatetime=value;}
			get{return _kdeletedatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string kNotes
		{
			set{ _knotes=value;}
			get{return _knotes;}
		}
		#endregion Model

	}
}

