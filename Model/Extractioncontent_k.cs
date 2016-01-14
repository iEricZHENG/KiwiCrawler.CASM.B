/**  版本信息模板在安装目录下，可自行修改。
* Extractioncontent_k.cs
*
* 功 能： N/A
* 类 名： Extractioncontent_k
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/1/14 10:29:20   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace KiwiCrawler.Model
{
	/// <summary>
	/// Extractioncontent_k:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Extractioncontent_k
	{
		public Extractioncontent_k()
		{}
		#region Model
		private int _kid;
		private string _kurl;
		private string _ktitle;
		private DateTime? _kpublishdatetime;
		private string _kcontent;
		private string _kaddressbusinesstype;
		private string _kkeyword;
		private string _kextraciontype;
		private string _kextra;
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
		public string KExtracionType
		{
			set{ _kextraciontype=value;}
			get{return _kextraciontype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KExtra
		{
			set{ _kextra=value;}
			get{return _kextra;}
		}
		#endregion Model

	}
}

