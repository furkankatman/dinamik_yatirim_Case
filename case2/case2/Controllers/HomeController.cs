using case2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace case2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public List<Word>Words { get; set; }
        public IConfiguration ConfigurationBuilder;

        public HomeController(ILogger<HomeController> logger,IConfiguration configurationBuilder)
        {
            _logger = logger;
            ConfigurationBuilder = configurationBuilder;
            PopulateWords();
            
        }

        private void PopulateWords()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationBuilder.GetSection("ConnectionString").Value))
            {
                string sqlQuery = string.Format("select * from Words");
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = sqlQuery;
                var reader = cmd.ExecuteReader();
                Words = new List<Word>();
                while (reader.Read())
                {
                    Words.Add(new Word() { Id =reader.GetInt32(0), Text = reader.GetString(1) });
                }
                connection.Close();
            }
           Words= Words.OrderByDescending(x => x.Id).ToList();
        }

        public IActionResult Index()
        {
            return View(Words);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet("Words")]
        public JsonResult GetWords()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationBuilder.GetSection("ConnectionString").Value))
            {
                string sqlQuery = string.Format("select * from Words");
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = sqlQuery;
                var reader = cmd.ExecuteReader();
                Words = new List<Word>();
                while (reader.Read())
                {
                    Words.Add(new Word() { Id = reader.GetInt32(0), Text = reader.GetString(1) });
                }
                connection.Close();
            }
            Words = Words.OrderByDescending(x => x.Id).ToList();
            return new JsonResult(Words);
        }

    }
}
