using System.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Disney_Stats_Viewer.Models;
using MySqlConnector;

namespace Disney_Stats_Viewer.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        string m_strMySQLConnectionString;
        m_strMySQLConnectionString = "server=localhost;userid=mnmustafa1109;database=test;port=3306;password=Lover@1109";
        MySqlConnection cnMySQL = new MySqlConnection(m_strMySQLConnectionString);
        MySqlCommand cmdMySQL = cnMySQL.CreateCommand();    
        cmdMySQL.CommandText = "SELECT * FROM actor";
        cnMySQL.Open();
        MySqlDataReader reader = cmdMySQL.ExecuteReader();
        // convert the reader to a list of strings
        List<Actor> actors = new List<Actor>();
        while (reader.Read())
        {
            actors.Add(new Actor(reader.GetInt32(0), reader.GetString(1)));
        }
        ViewData["actors"] = actors;

        cnMySQL.Close();
        
        return View();
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
}