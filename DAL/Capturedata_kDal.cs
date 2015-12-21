using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace KiwiCrawler.DAL
{
    /// <summary>
    /// 数据访问类:Capturedata_kDal
    /// </summary>
    public partial class Capturedata_kDal
    {
        public Capturedata_kDal()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("kId", "capturedata_k");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int kId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from capturedata_k");
            strSql.Append(" where kId=@kId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@kId", MySqlDbType.Int32)
            };
            parameters[0].Value = kId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KiwiCrawler.Model.Capturedata_k model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into capturedata_k(");
            strSql.Append("kUrl,kContent,kType,kCaptureDateTime,kNumber,kNotes,kPageMD5,kIndexId,kUpdateTime)");
            strSql.Append(" values (");
            strSql.Append("@kUrl,@kContent,@kType,@kCaptureDateTime,@kNumber,@kNotes,@kPageMD5,@kIndexId,@kUpdateTime)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@kUrl", MySqlDbType.Text),
                    new MySqlParameter("@kContent", MySqlDbType.LongText),
                    new MySqlParameter("@kType", MySqlDbType.VarChar,255),
                    new MySqlParameter("@kCaptureDateTime", MySqlDbType.DateTime),
                    new MySqlParameter("@kNumber", MySqlDbType.Int32,11),
                    new MySqlParameter("@kNotes", MySqlDbType.Text),
                    new MySqlParameter("@kPageMD5", MySqlDbType.VarChar,32),
                    new MySqlParameter("@kIndexId", MySqlDbType.Int32,11),
                    new MySqlParameter("@kUpdateTime", MySqlDbType.DateTime)};
            parameters[0].Value = model.kUrl;
            parameters[1].Value = model.kContent;
            parameters[2].Value = model.kType;
            parameters[3].Value = model.kCaptureDateTime;
            parameters[4].Value = model.kNumber;
            parameters[5].Value = model.kNotes;
            parameters[6].Value = model.kPageMD5;
            parameters[7].Value = model.kIndexId;
            parameters[8].Value = model.kUpdateTime;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Update(KiwiCrawler.Model.Capturedata_k model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update capturedata_k set ");
            strSql.Append("kUrl=@kUrl,");
            strSql.Append("kContent=@kContent,");
            strSql.Append("kType=@kType,");
            strSql.Append("kCaptureDateTime=@kCaptureDateTime,");
            strSql.Append("kNumber=@kNumber,");
            strSql.Append("kNotes=@kNotes,");
            strSql.Append("kPageMD5=@kPageMD5,");
            strSql.Append("kIndexId=@kIndexId,");
            strSql.Append("kUpdateTime=@kUpdateTime");
            strSql.Append(" where kId=@kId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@kUrl", MySqlDbType.Text),
                    new MySqlParameter("@kContent", MySqlDbType.LongText),
                    new MySqlParameter("@kType", MySqlDbType.VarChar,255),
                    new MySqlParameter("@kCaptureDateTime", MySqlDbType.DateTime),
                    new MySqlParameter("@kNumber", MySqlDbType.Int32,11),
                    new MySqlParameter("@kNotes", MySqlDbType.Text),
                    new MySqlParameter("@kPageMD5", MySqlDbType.VarChar,32),
                    new MySqlParameter("@kIndexId", MySqlDbType.Int32,11),
                    new MySqlParameter("@kUpdateTime", MySqlDbType.DateTime),
                    new MySqlParameter("@kId", MySqlDbType.Int32,11)};
            parameters[0].Value = model.kUrl;
            parameters[1].Value = model.kContent;
            parameters[2].Value = model.kType;
            parameters[3].Value = model.kCaptureDateTime;
            parameters[4].Value = model.kNumber;
            parameters[5].Value = model.kNotes;
            parameters[6].Value = model.kPageMD5;
            parameters[7].Value = model.kIndexId;
            parameters[8].Value = model.kUpdateTime;
            parameters[9].Value = model.kId;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from capturedata_k ");
            strSql.Append(" where kId=@kId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@kId", MySqlDbType.Int32)
            };
            parameters[0].Value = kId;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string kIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from capturedata_k ");
            strSql.Append(" where kId in (" + kIdlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
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
        public KiwiCrawler.Model.Capturedata_k GetModel(int kId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select kId,kUrl,kContent,kType,kCaptureDateTime,kNumber,kNotes,kPageMD5,kIndexId,kUpdateTime from capturedata_k ");
            strSql.Append(" where kId=@kId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@kId", MySqlDbType.Int32)
            };
            parameters[0].Value = kId;

            KiwiCrawler.Model.Capturedata_k model = new KiwiCrawler.Model.Capturedata_k();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public KiwiCrawler.Model.Capturedata_k DataRowToModel(DataRow row)
        {
            KiwiCrawler.Model.Capturedata_k model = new KiwiCrawler.Model.Capturedata_k();
            if (row != null)
            {
                if (row["kId"] != null && row["kId"].ToString() != "")
                {
                    model.kId = int.Parse(row["kId"].ToString());
                }
                if (row["kUrl"] != null)
                {
                    model.kUrl = row["kUrl"].ToString();
                }
                if (row["kContent"] != null)
                {
                    model.kContent = row["kContent"].ToString();
                }
                if (row["kType"] != null)
                {
                    model.kType = row["kType"].ToString();
                }
                if (row["kCaptureDateTime"] != null && row["kCaptureDateTime"].ToString() != "")
                {
                    model.kCaptureDateTime = DateTime.Parse(row["kCaptureDateTime"].ToString());
                }
                if (row["kNumber"] != null && row["kNumber"].ToString() != "")
                {
                    model.kNumber = int.Parse(row["kNumber"].ToString());
                }
                if (row["kNotes"] != null)
                {
                    model.kNotes = row["kNotes"].ToString();
                }
                if (row["kPageMD5"] != null)
                {
                    model.kPageMD5 = row["kPageMD5"].ToString();
                }
                if (row["kIndexId"] != null && row["kIndexId"].ToString() != "")
                {
                    model.kIndexId = int.Parse(row["kIndexId"].ToString());
                }
                if (row["kUpdateTime"] != null && row["kUpdateTime"].ToString() != "")
                {
                    model.kUpdateTime = DateTime.Parse(row["kUpdateTime"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select kId,kUrl,kContent,kType,kCaptureDateTime,kNumber,kNotes,kPageMD5,kIndexId,kUpdateTime ");
            strSql.Append(" FROM capturedata_k ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM capturedata_k ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.kId desc");
            }
            strSql.Append(")AS Row, T.*  from capturedata_k T ");
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
			parameters[0].Value = "capturedata_k";
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

