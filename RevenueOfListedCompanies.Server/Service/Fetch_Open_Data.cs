using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RevenueOfListedCompanies.Server.Service
{
    public class Fetch_Open_Data
    {
        /// <summary>
        /// 連線字串
        /// </summary>
        private static IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .Build();
        private readonly string cnStr = configuration.GetConnectionString("CompaniesDatabase");
        /// <summary>
        /// Json連結
        /// </summary>
        string opendataurl = "https://quality.data.gov.tw/dq_download_json.php?nid=18420&md5_url=44314524414150faa7ccb2800813f493";


        /// <summary>
        /// 下載Json檔
        /// </summary>
        public async Task UrlGetDataStr()
        {
            HttpClient httpClient = new HttpClient();

            try
            {
                using HttpResponseMessage response = await httpClient.GetAsync(opendataurl);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                SaveToDB(responseBody);
            }
            catch (Exception ex)
            {
                //錯誤 Log
                //Console.WriteLine($"{ex.Message}");
            }
        }

        /// <summary>
        /// 線上資料結構寫入資料庫
        /// </summary>
        /// <param name="JsonDataStr"></param>
        public void SaveToDB(string JsonDataStr)
        {
            var JsonData = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(JsonDataStr);

            var KeyArray = new string[] { "出表日期", "資料年月", "公司代號", "公司名稱", "產業別", "營業收入-當月營收", "營業收入-上月營收", "營業收入-去年當月營收", "營業收入-上月比較增減(%)", "營業收入-去年同月增減(%)", "累計營業收入-當月累計營收", "累計營業收入-去年累計營收", "累計營業收入-前期比較增減(%)", "備註" };


            if (JsonData != null)
            {

                foreach (var Jdata in JsonData)
                {
                    var Sql_Str = "INSERT_REVENUE_OF_LISTED_COMPANIES";

                    var param = new DynamicParameters();
                    param.Add("REPORT_DATE", Jdata[KeyArray[0]]);
                    param.Add("DATA_YEARMONTH", Jdata[KeyArray[1]]);
                    param.Add("COMPANY_CODE", Jdata[KeyArray[2]]);
                    param.Add("COMPANY_NAME", Jdata[KeyArray[3]]);
                    param.Add("INDUSTRY", Jdata[KeyArray[4]]);
                    param.Add("REVENUE_CURRENT", Jdata[KeyArray[5]]);
                    param.Add("REVENUE_PREV_MONTH", Jdata[KeyArray[6]]);
                    param.Add("REVENUE_LAST_YEAR", Jdata[KeyArray[7]]);
                    param.Add("MONTHLY_CHANGE", Jdata[KeyArray[8]]);
                    param.Add("YOY_CHANGE", Jdata[KeyArray[9]]);
                    param.Add("CUMULATIVE_REVENUE", Jdata[KeyArray[10]]);
                    param.Add("CUMULATIVE_LAST_YEAR", Jdata[KeyArray[11]]);
                    param.Add("CUMULATIVE_CHANGE", Jdata[KeyArray[12]]);
                    param.Add("REMARKS", Jdata[KeyArray[13]]);

                    using (var cn = new SqlConnection(cnStr))
                    {
                        cn.Execute(Sql_Str, param, commandType: CommandType.StoredProcedure);
                    }

                }

            }
            else
            {
                //沒有取得資料 Log
            }

        }
    }
}
