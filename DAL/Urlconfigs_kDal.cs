using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace KiwiCrawler.DAL
{
    /// <summary>
    /// 数据访问类:Urlconfigs_kDal
    /// </summary>
    public partial class Urlconfigs_kDal
    {
        public Urlconfigs_kDal()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("kId", "urlconfigs_k");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int kId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from urlconfigs_k");
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
        public bool Add(KiwiCrawler.Model.Urlconfigs_k model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into urlconfigs_k(");
            strSql.Append("kUrl,kPageTotal,kCaptureType,kDetailPattern,kDetailPatternType,kNextPagePattern,kNextPagePatternType,kComplateDegree,kAddressBusinessType,kKeyWords,kNotes)");
            strSql.Append(" values (");
            strSql.Append("@kUrl,@kPageTotal,@kCaptureType,@kDetailPattern,@kDetailPatternType,@kNextPagePattern,@kNextPagePatternType,@kComplateDegree,@kAddressBusinessType,@kKeyWords,@kNotes)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@kUrl", MySqlDbType.Text),
                    new MySqlParameter("@kPageTotal", MySqlDbType.Int32,11),
                    new MySqlParameter("@kCaptureType", MySqlDbType.Text),
                    new MySqlParameter("@kDetailPattern", MySqlDbType.Text),
                    new MySqlParameter("@kDetailPatternType", MySqlDbType.VarChar,255),
                    new MySqlParameter("@kNextPagePattern", MySqlDbType.Text),
                    new MySqlParameter("@kNextPagePatternType", MySqlDbType.VarChar,255),
                    new MySqlParameter("@kComplateDegree", MySqlDbType.Float),
                    new MySqlParameter("@kAddressBusinessType", MySqlDbType.Text),
                    new MySqlParameter("@kKeyWords", MySqlDbType.Text),
                    new MySqlParameter("@kNotes", MySqlDbType.VarChar, 255)};
            parameters[0].Value = model.kUrl;
            parameters[1].Value = model.kPageTotal;
            parameters[2].Value = model.kCaptureType;
            parameters[3].Value = model.kDetailPattern;
            parameters[4].Value = model.kDetailPatternType;
            parameters[5].Value = model.kNextPagePattern;
            parameters[6].Value = model.kNextPagePatternType;
            parameters[7].Value = model.kComplateDegree;
            parameters[8].Value = model.kAddressBusinessType;
            parameters[9].Value = model.kKeyWords;
            parameters[10].Value = model.kNotes;
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
        public bool Update(KiwiCrawler.Model.Urlconfigs_k model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update urlconfigs_k set ");
            strSql.Append("kUrl=@kUrl,");
            strSql.Append("kPageTotal=@kPageTotal,");
            strSql.Append("kCaptureType=@kCaptureType,");
            strSql.Append("kDetailPattern=@kDetailPattern,");
            strSql.Append("kDetailPatternType=@kDetailPatternType,");
            strSql.Append("kNextPagePattern=@kNextPagePattern,");
            strSql.Append("kNextPagePatternType=@kNextPagePatternType,");
            strSql.Append("kComplateDegree=@kComplateDegree,");
            strSql.Append("kAddressBusinessType=@kAddressBusinessType,");
            strSql.Append("kKeyWords=@kKeyWords,");
            strSql.Append("kNotes=@kNotes");
            strSql.Append(" where kId=@kId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@kUrl", MySqlDbType.Text),
                    new MySqlParameter("@kPageTotal", MySqlDbType.Int32,11),
                    new MySqlParameter("@kCaptureType", MySqlDbType.Text),
                    new MySqlParameter("@kDetailPattern", MySqlDbType.Text),
                    new MySqlParameter("@kDetailPatternType", MySqlDbType.VarChar,255),
                    new MySqlParameter("@kNextPagePattern", MySqlDbType.Text),
                    new MySqlParameter("@kNextPagePatternType", MySqlDbType.VarChar,255),
                    new MySqlParameter("@kComplateDegree", MySqlDbType.Float),
                    new MySqlParameter("@kAddressBusinessType", MySqlDbType.Text),
                    new MySqlParameter("@kKeyWords", MySqlDbType.Text),
                    new MySqlParameter("@kNotes", MySqlDbType.VarChar, 255),
                    new MySqlParameter("@kId", MySqlDbType.Int32,11)};
          
            parameters[0].Value = model.kUrl;
            parameters[1].Value = model.kPageTotal;
            parameters[2].Value = model.kCaptureType;
            parameters[3].Value = model.kDetailPattern;
            parameters[4].Value = model.kDetailPatternType;
            parameters[5].Value = model.kNextPagePattern;
            parameters[6].Value = model.kNextPagePatternType;
            parameters[7].Value = model.kComplateDegree;
            parameters[8].Value = model.kAddressBusinessType;
            parameters[9].Value = model.kKeyWords;
            parameters[10].Value = model.kNotes;
            parameters[11].Value = model.kId;

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
            strSql.Append("delete from urlconfigs_k ");
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
            strSql.Append("delete from urlconfigs_k ");
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
        public KiwiCrawler.Model.Urlconfigs_k GetModel(int kId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select kId,kUrl,kPageTotal,kCaptureType,kDetailPattern,kDetailPatternType,kNextPagePattern,kNextPagePatternType,kComplateDegree,kAddressBusinessType,kKeyWords,kNotes from urlconfigs_k ");
            strSql.Append(" where kId=@kId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@kId", MySqlDbType.Int32)
            };
            parameters[0].Value = kId;

            KiwiCrawler.Model.Urlconfigs_k model = new KiwiCrawler.Model.Urlconfigs_k();
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
        public KiwiCrawler.Model.Urlconfigs_k DataRowToModel(DataRow row)
        {
            KiwiCrawler.Model.Urlconfigs_k model = new KiwiCrawler.Model.Urlconfigs_k();
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
                if (row["kPageTotal"] != null && row["kPageTotal"].ToString() != "")
                {
                    model.kPageTotal = int.Parse(row["kPageTotal"].ToString());
                }
                if (row["kCaptureType"] != null)
                {
                    model.kCaptureType = row["kCaptureType"].ToString();
                }
                if (row["kDetailPattern"] != null)
                {
                    model.kDetailPattern = row["kDetailPattern"].ToString();
                }
                if (row["kDetailPatternType"] != null)
                {
                    model.kDetailPatternType = row["kDetailPatternType"].ToString();
                }
                if (row["kNextPagePattern"] != null)
                {
                    model.kNextPagePattern = row["kNextPagePattern"].ToString();
                }
                if (row["kNextPagePatternType"] != null)
                {
                    model.kNextPagePatternType = row["kNextPagePatternType"].ToString();
                }
                if (row["kComplateDegree"] != null && row["kComplateDegree"].ToString() != "")
                {
                    model.kComplateDegree = decimal.Parse(row["kComplateDegree"].ToString());
                }
                if (row["kAddressBusinessType"] != null)
                {
                    model.kAddressBusinessType = row["kAddressBusinessType"].ToString();
                }
                if (row["kKeyWords"] != null)
                {
                    model.kKeyWords = row["kKeyWords"].ToString();
                }
                if (row["kNotes"] != null)
                {
                    model.kNotes = row["kNotes"].ToString();
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
            strSql.Append("select kId,kUrl,kPageTotal,kCaptureType,kDetailPattern,kDetailPatternType,kNextPagePattern,kNextPagePatternType,kComplateDegree,kAddressBusinessType,kKeyWords,kNotes ");
            strSql.Append(" FROM urlconfigs_k ");
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
            strSql.Append("select count(1) FROM urlconfigs_k ");
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
            strSql.Append(")AS Row, T.*  from urlconfigs_k T ");
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
			parameters[0].Value = "urlconfigs_k";
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

