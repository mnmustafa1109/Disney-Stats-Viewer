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
        return View();
    }
    
    [HttpPost]
    public IActionResult ExecuteQuery(QueryInputModel model)
    {
        string m_strMySQLConnectionString;
        m_strMySQLConnectionString = "server=localhost;userid=syednouman;database=test;port=3306;password=123";
        MySqlConnection cnMySQL = new MySqlConnection(m_strMySQLConnectionString);
        MySqlCommand cmdMySQL = cnMySQL.CreateCommand();
        cmdMySQL.CommandText = model.Query;
        cnMySQL.Open();
        MySqlDataReader reader = cmdMySQL.ExecuteReader();

        // Create the QueryResultModel instance
        QueryResult resultModel = new QueryResult();

        // Get the number of columns in the result set
        int columnCount = reader.FieldCount;

        // Initialize the 2D array in the QueryResultModel
        resultModel.Results = new string[reader.FieldCount, 0];

        // Convert the reader to a list of strings
        List<List<string>> results = new List<List<string>>();
        for (int i = 0; i < columnCount; i++)
        {
            results.Add(new List<string>());
        }

        while (reader.Read())
        {
            for (int i = 0; i < columnCount; i++)
            {
                results[i].Add(reader.GetValue(i).ToString());
            }
        }

        // Populate the 2D array in the QueryResultModel
        resultModel.Results = new string[columnCount, results[0].Count];
        for (int i = 0; i < columnCount; i++)
        {
            for (int j = 0; j < results[i].Count; j++)
            {
                resultModel.Results[i, j] = results[i][j];
            }
        }

        cnMySQL.Close();

        // Pass the resultModel to the view using ViewData
        ViewData["QueryResults"] = resultModel;


        return View("Results", resultModel);
    }

    // public IActionResult Index()
    // {
    //    
    //     return View();
    // }

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