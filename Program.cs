using System.Data.OleDb;
using System.Web.Http;
public class DataController : ApiController
{
     private static void Main()
    {
        var builder = WebApplication.CreateBuilder();
        var app = builder.Build();
    }
    public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=DataBaseAlgoritm.mdb; Persist Security Info=False;";
    //public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DataBaseAlgoritm.mdb;";
       
       [System.Web.Http.HttpGet]       
       public IHttpActionResult Get()
    {try
        {
            using OleDbConnection connection = new OleDbConnection(connectString);
            connection.Open();
   


            // ...


            Logger.Log("GET request executed successfully");

            return Ok();
        }
        catch (Exception ex)
        {
            Logger.Log($"Error executing GET request: {ex.Message}");

            return InternalServerError();
        }
    }
    [System.Web.Http.HttpPost]
    public IHttpActionResult Post([FromBody] object data)
    {
        try
        {
            using (OleDbConnection connection = new OleDbConnection(connectString))
            {
                connection.Open();

                // ...

                Logger.Log("POST request executed successfully");

                return Ok();
            }
        }
        catch (Exception ex)
        {
            Logger.Log($"Error executing POST request: {ex.Message}");

            return InternalServerError();
        }
    }

    [System.Web.Http.HttpPut]
    public IHttpActionResult Put([FromBody] object data)
    {
        try
        {
            using (OleDbConnection connection = new OleDbConnection(connectString))
            {
                connection.Open();


                // ...

                Logger.Log("PUT request executed successfully");

                return Ok();
            }
        }
        catch (Exception ex)
        {
            Logger.Log($"Error executing PUT request: {ex.Message}");

            return InternalServerError();
        }
    }

    [System.Web.Http.HttpDelete]
    public IHttpActionResult Delete()
    {
        try
        {
            using (OleDbConnection connection = new OleDbConnection(connectString))
            {
                connection.Open();


                // ...


                Logger.Log("DELETE request executed successfully");

                return Ok();
            }
        }
        catch (Exception ex)
        {

            Logger.Log($"Error executing DELETE request: {ex.Message}");

            return InternalServerError();
        }
    }
}





public static class Logger
{
    public static void Log(string message)
    {


        // ....



    }
}