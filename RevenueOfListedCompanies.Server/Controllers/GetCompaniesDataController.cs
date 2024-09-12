using Microsoft.AspNetCore.Mvc;
using RevenueOfListedCompanies.Server.Service;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using RevenueOfListedCompanies.Server.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RevenueOfListedCompanies.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetCompaniesDataController : ControllerBase
    {

        private static IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .Build();
        private readonly string cnStr = configuration.GetConnectionString("CompaniesDatabase");

        // GET api/<GetCompaniesDataController>/5
        [HttpGet]
        public IEnumerable<t187ap05_L> Get(string? code = "")
        {
            using (var cn = new SqlConnection(cnStr))
            {
                return cn.Query<t187ap05_L>("SELECT_REVENUE_OF_LISTED_COMPANIES", new { COMPANY_CODE = code }, commandType: CommandType.StoredProcedure);
            }
        }

        // PUT api/<GetCompaniesDataController>/5
        [HttpPut()]
        public void Put()
        {
            var Fetch_Open_Data_Service = new Fetch_Open_Data();
            Fetch_Open_Data_Service.UrlGetDataStr();
        }

    }
}
