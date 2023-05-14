using System.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Disney_Stats_Viewer.Models;
using Microsoft.VisualBasic.FileIO;
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
        List<List<String>> results = new List<List<String>>();
        for (int i = 0; i < reader.FieldCount; i++)
        {
            results.Add(new List<String>());
        }
        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                results[i].Add(reader.GetValue(i).ToString());
            }
        }
        foreach (List<String> result in results)
        {
            foreach (String s in result)
            {
                Console.WriteLine(s);
            }
        }
        
        

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