using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace KiwiCrawler.DAL
{
	/// <summary>
	/// 数据访问类:Extractionconfig_kDal
	/// </summary>
	public partial class Extractionconfig_kDal
	{
		public Extractionconfig_kDal()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(KiwiCrawler.Model.Extractionconfig_k model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into extractionconfig_k(");
			strSql.Append("KId,KUrl,KTitle,KPublishDateTime,KContent,KAddressBusinessType,KKeyword,KPercent)");
			strSql.Append(" values (");
			strSql.Append("@KId,@KUrl,@KTitle,@KPublishDateTime,@KContent,@KAddressBusinessType,@KKeyword,@KPercent)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@KId", MySqlDbType.Int32,11),
					new MySqlParameter("@KUrl", MySqlDbType.Text),
					new MySqlParameter("@KTitle", MySqlDbType.Text),
					new MySqlParameter("@KPublishDateTime", MySqlDbType.DateTime),
					new MySqlParameter("@KContent", MySqlDbType.Text),
					new MySqlParameter("@KAddressBusinessType", MySqlDbType.Text),
					new MySqlParameter("@KKeyword", MySqlDbType.Text),
					new MySqlParameter("@KPercent", MySqlDbType.Float)};
			parameters[0].Value = model.KId;
			parameters[1].Value = model.KUrl;
			parameters[2].Value = model.KTitle;
			parameters[3].Value = model.KPublishDateTime;
			parameters[4].Value = model.KContent;
			parameters[5].Value = model.KAddressBusinessType;
			parameters[6].Value = model.KKeyword;
			parameters[7].Value = model.KPercent;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(KiwiCrawler.Model.Extractionconfig_k model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update extractionconfig_k set ");
			strSql.Append("KId=@KId,");
			strSql.Append("KUrl=@KUrl,");
			strSql.Append("KTitle=@KTitle,");
			strSql.Append("KPublishDateTime=@KPublishDateTime,");
			strSql.Append("KContent=@KContent,");
			strSql.Append("KAddressBusinessType=@KAddressBusinessType,");
			strSql.Append("KKeyword=@KKeyword,");
			strSql.Append("KPercent=@KPercent");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@KId", MySqlDbType.Int32,11),
					new MySqlParameter("@KUrl", MySqlDbType.Text),
					new MySqlParameter("@KTitle", MySqlDbType.Text),
					new MySqlParameter("@KPublishDateTime", MySqlDbType.DateTime),
					new MySqlParameter("@KContent", MySqlDbType.Text),
					new MySqlParameter("@KAddressBusinessType", MySqlDbType.Text),
					new MySqlParameter("@KKeyword", MySqlDbType.Text),
					new MySqlParameter("@KPercent", MySqlDbType.Float)};
			parameters[0].Value = model.KId;
			parameters[1].Value = model.KUrl;
			parameters[2].Value = model.KTitle;
			parameters[3].Value = model.KPublishDateTime;
			parameters[4].Value = model.KContent;
			parameters[5].Value = model.KAddressBusinessType;
			parameters[6].Value = model.KKeyword;
			parameters[7].Value = model.KPercent;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from extractionconfig_k ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
			};

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public KiwiCrawler.Model.Extractionconfig_k GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select KId,KUrl,KTitle,KPublishDateTime,KContent,KAddressBusinessType,KKeyword,KPercent from extractionconfig_k ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
			};

			KiwiCrawler.Model.Extractionconfig_k model=new KiwiCrawler.Model.Extractionconfig_k();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public KiwiCrawler.Model.Extractionconfig_k DataRowToModel(DataRow row)
		{
			KiwiCrawler.Model.Extractionconfig_k model=new KiwiCrawler.Model.Extractionconfig_k();
			if (row != null)
			{
				if(row["KId"]!=null && row["KId"].ToString()!="")
				{
					model.KId=int.Parse(row["KId"].ToString());
				}
				if(row["KUrl"]!=null)
				{
					model.KUrl=row["KUrl"].ToString();
				}
				if(row["KTitle"]!=null)
				{
					model.KTitle=row["KTitle"].ToString();
				}
				if(row["KPublishDateTime"]!=null && row["KPublishDateTime"].ToString()!="")
				{
					model.KPublishDateTime=DateTime.Parse(row["KPublishDateTime"].ToString());
				}
				if(row["KContent"]!=null)
				{
					model.KContent=row["KContent"].ToString();
				}
				if(row["KAddressBusinessType"]!=null)
				{
					model.KAddressBusinessType=row["KAddressBusinessType"].ToString();
				}
				if(row["KKeyword"]!=null)
				{
					model.KKeyword=row["KKeyword"].ToString();
				}
				if(row["KPercent"]!=null && row["KPercent"].ToString()!="")
				{
					model.KPercent=decimal.Parse(row["KPercent"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select KId,KUrl,KTitle,KPublishDateTime,KContent,KAddressBusinessType,KKeyword,KPercent ");
			strSql.Append(" FROM extractionconfig_k ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM extractionconfig_k ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperMySQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from extractionconfig_k T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "extractionconfig_k";
			parameters[1].Value = "";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

