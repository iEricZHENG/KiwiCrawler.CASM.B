using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace KiwiCrawler.DAL
{
	/// <summary>
	/// 数据访问类:Extractdata_kDal
	/// </summary>
	public partial class Extractdata_kDal
	{
		public Extractdata_kDal()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("kId", "extractdata_k"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int kId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from extractdata_k");
			strSql.Append(" where kId=@kId");
			MySqlParameter[] parameters = {
					new MySqlParameter("@kId", MySqlDbType.Int32)
			};
			parameters[0].Value = kId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(KiwiCrawler.Model.Extractdata_k model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into extractdata_k(");
			strSql.Append("kUrl,kPublishDateTime,kContent,kAddress,kType,kCaptureDateTime)");
			strSql.Append(" values (");
			strSql.Append("@kUrl,@kPublishDateTime,@kContent,@kAddress,@kType,@kCaptureDateTime)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@kUrl", MySqlDbType.Text),
					new MySqlParameter("@kPublishDateTime", MySqlDbType.DateTime),
					new MySqlParameter("@kContent", MySqlDbType.Text),
					new MySqlParameter("@kAddress", MySqlDbType.Text),
					new MySqlParameter("@kType", MySqlDbType.VarChar,255),
					new MySqlParameter("@kCaptureDateTime", MySqlDbType.DateTime)};
			parameters[0].Value = model.kUrl;
			parameters[1].Value = model.kPublishDateTime;
			parameters[2].Value = model.kContent;
			parameters[3].Value = model.kAddress;
			parameters[4].Value = model.kType;
			parameters[5].Value = model.kCaptureDateTime;

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
		public bool Update(KiwiCrawler.Model.Extractdata_k model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update extractdata_k set ");
			strSql.Append("kUrl=@kUrl,");
			strSql.Append("kPublishDateTime=@kPublishDateTime,");
			strSql.Append("kContent=@kContent,");
			strSql.Append("kAddress=@kAddress,");
			strSql.Append("kType=@kType,");
			strSql.Append("kCaptureDateTime=@kCaptureDateTime");
			strSql.Append(" where kId=@kId");
			MySqlParameter[] parameters = {
					new MySqlParameter("@kUrl", MySqlDbType.Text),
					new MySqlParameter("@kPublishDateTime", MySqlDbType.DateTime),
					new MySqlParameter("@kContent", MySqlDbType.Text),
					new MySqlParameter("@kAddress", MySqlDbType.Text),
					new MySqlParameter("@kType", MySqlDbType.VarChar,255),
					new MySqlParameter("@kCaptureDateTime", MySqlDbType.DateTime),
					new MySqlParameter("@kId", MySqlDbType.Int32,11)};
			parameters[0].Value = model.kUrl;
			parameters[1].Value = model.kPublishDateTime;
			parameters[2].Value = model.kContent;
			parameters[3].Value = model.kAddress;
			parameters[4].Value = model.kType;
			parameters[5].Value = model.kCaptureDateTime;
			parameters[6].Value = model.kId;

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
		public bool Delete(int kId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from extractdata_k ");
			strSql.Append(" where kId=@kId");
			MySqlParameter[] parameters = {
					new MySqlParameter("@kId", MySqlDbType.Int32)
			};
			parameters[0].Value = kId;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string kIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from extractdata_k ");
			strSql.Append(" where kId in ("+kIdlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
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
		public KiwiCrawler.Model.Extractdata_k GetModel(int kId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select kId,kUrl,kPublishDateTime,kContent,kAddress,kType,kCaptureDateTime from extractdata_k ");
			strSql.Append(" where kId=@kId");
			MySqlParameter[] parameters = {
					new MySqlParameter("@kId", MySqlDbType.Int32)
			};
			parameters[0].Value = kId;

			KiwiCrawler.Model.Extractdata_k model=new KiwiCrawler.Model.Extractdata_k();
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
		public KiwiCrawler.Model.Extractdata_k DataRowToModel(DataRow row)
		{
			KiwiCrawler.Model.Extractdata_k model=new KiwiCrawler.Model.Extractdata_k();
			if (row != null)
			{
				if(row["kId"]!=null && row["kId"].ToString()!="")
				{
					model.kId=int.Parse(row["kId"].ToString());
				}
				if(row["kUrl"]!=null)
				{
					model.kUrl=row["kUrl"].ToString();
				}
				if(row["kPublishDateTime"]!=null && row["kPublishDateTime"].ToString()!="")
				{
					model.kPublishDateTime=DateTime.Parse(row["kPublishDateTime"].ToString());
				}
				if(row["kContent"]!=null)
				{
					model.kContent=row["kContent"].ToString();
				}
				if(row["kAddress"]!=null)
				{
					model.kAddress=row["kAddress"].ToString();
				}
				if(row["kType"]!=null)
				{
					model.kType=row["kType"].ToString();
				}
				if(row["kCaptureDateTime"]!=null && row["kCaptureDateTime"].ToString()!="")
				{
					model.kCaptureDateTime=DateTime.Parse(row["kCaptureDateTime"].ToString());
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
			strSql.Append("select kId,kUrl,kPublishDateTime,kContent,kAddress,kType,kCaptureDateTime ");
			strSql.Append(" FROM extractdata_k ");
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
			strSql.Append("select count(1) FROM extractdata_k ");
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
				strSql.Append("order by T.kId desc");
			}
			strSql.Append(")AS Row, T.*  from extractdata_k T ");
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
			parameters[0].Value = "extractdata_k";
			parameters[1].Value = "kId";
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

