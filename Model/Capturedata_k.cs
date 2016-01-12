using System;
namespace KiwiCrawler.Model
{
    /// <summary>
    /// Capturedata_k:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Capturedata_k
    {
        public Capturedata_k()
        { }
        #region Model
        private int _kid;
        private string _kurl;
        private string _kcontent;
        private string _ktype;
        private DateTime _kcapturedatetime;
        private int? _knumber;
        private int _kextracted = 0;
        private string _kpagemd5;
        private int _kindexid;
        private DateTime? _kupdatetime;
        private int _kisupdated = 0;
        private string _knotes;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int kId
        {
            set { _kid = value; }
            get { return _kid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string kUrl
        {
            set { _kurl = value; }
            get { return _kurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string kContent
        {
            set { _kcontent = value; }
            get { return _kcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string kType
        {
            set { _ktype = value; }
            get { return _ktype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime kCaptureDateTime
        {
            set { _kcapturedatetime = value; }
            get { return _kcapturedatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? kNumber
        {
            set { _knumber = value; }
            get { return _knumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int kExtracted
        {
            set { _kextracted = value; }
            get { return _kextracted; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string kPageMD5
        {
            set { _kpagemd5 = value; }
            get { return _kpagemd5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int kIndexId
        {
            set { _kindexid = value; }
            get { return _kindexid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? kUpdateTime
        {
            set { _kupdatetime = value; }
            get { return _kupdatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int kIsUpdated
        {
            set { _kisupdated = value; }
            get { return _kisupdated; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string kNotes
        {
            set { _knotes = value; }
            get { return _knotes; }
        }
        #endregion Model

    }
}

