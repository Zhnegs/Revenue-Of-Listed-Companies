namespace RevenueOfListedCompanies.Server.Models
{
    public class t187ap05_L
    {
        /// <summary>
        /// 出表日期
        /// </summary>
        public string REPORT_DATE { get; set; }
        /// <summary>
        /// 資料年月
        /// </summary>
        public string DATA_YEARMONTH { get; set; }
        /// <summary>
        /// 公司代號
        /// </summary>
        public string COMPANY_CODE { get; set; }
        /// <summary>
        /// 公司名稱
        /// </summary>
        public string COMPANY_NAME { get; set; }
        /// <summary>
        /// 產業別
        /// </summary>
        public string INDUSTRY { get; set; }
        /// <summary>
        /// 營業收入-當月營收
        /// </summary>
        public int REVENUE_CURRENT { get; set; }
        /// <summary>
        /// 營業收入-上月營收
        /// </summary>
        public int REVENUE_PREV_MONTH { get; set; }
        /// <summary>
        ///營業收入-去年當月營收
        /// </summary>
        public int REVENUE_LAST_YEAR { get; set; }
        /// <summary>
        ///營業收入-上月比較增減(%)
        /// </summary>
        public double MONTHLY_CHANGE { get; set; }
        /// <summary>
        ///營業收入-去年同月增減(%)
        /// </summary>
        public double YOY_CHANGE { get; set; }
        /// <summary>
        ///累計營業收入-當月累計營收
        /// </summary>
        public int CUMULATIVE_REVENUE { get; set; }
        /// <summary>
        ///累計營業收入-去年累計營收
        /// </summary>
        public int CUMULATIVE_LAST_YEAR { get; set; }
        /// <summary>
        ///累計營業收入-前期比較增減(%)
        /// </summary>
        public double CUMULATIVE_CHANGE { get; set; }
        /// <summary>
        ///備註
        /// </summary>
        public string REMARKS { get; set; }

        public t187ap05_L(string rEPORT_DATE, string dATA_YEARMONTH, string cOMPANY_CODE, string cOMPANY_NAME, string iNDUSTRY, int rEVENUE_CURRENT, int rEVENUE_PREV_MONTH, int rEVENUE_LAST_YEAR, double mONTHLY_CHANGE, double yOY_CHANGE, int cUMULATIVE_REVENUE, int cUMULATIVE_LAST_YEAR, double cUMULATIVE_CHANGE, string rEMARKS)
        {
            REPORT_DATE = rEPORT_DATE;
            DATA_YEARMONTH = dATA_YEARMONTH;
            COMPANY_CODE = cOMPANY_CODE;
            COMPANY_NAME = cOMPANY_NAME;
            INDUSTRY = iNDUSTRY;
            REVENUE_CURRENT = rEVENUE_CURRENT;
            REVENUE_PREV_MONTH = rEVENUE_PREV_MONTH;
            REVENUE_LAST_YEAR = rEVENUE_LAST_YEAR;
            MONTHLY_CHANGE = mONTHLY_CHANGE;
            YOY_CHANGE = yOY_CHANGE;
            CUMULATIVE_REVENUE = cUMULATIVE_REVENUE;
            CUMULATIVE_LAST_YEAR = cUMULATIVE_LAST_YEAR;
            CUMULATIVE_CHANGE = cUMULATIVE_CHANGE;
            REMARKS = rEMARKS;
        }
    }
}
