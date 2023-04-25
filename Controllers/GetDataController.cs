using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace VoxormeliProekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetDataController : ControllerBase
    {
        //[HttpGet("GetData")]
        //public string GetData()
        //{
        //    string ConnectionString = ""
        //}


        [HttpGet("GetDB")]
        public ActionResult<List<string>> GetDataFromDB()
        {
            List<string> Currency = new List<string>();
            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=newdatabase;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT FirstName from Doctors";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Currency.Add(reader.GetString(0));
                    }
                }
            }
            return Ok(Currency);

        }
    }
}
