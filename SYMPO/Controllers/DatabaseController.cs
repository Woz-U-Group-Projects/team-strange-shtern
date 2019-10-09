using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Sympo;

namespace Sympo.Controllers {
    // MVC is handling the routing for you.
    [Route("api/[Controller]")]
    public class DatabaseController : Controller {

        // api/database
        [HttpGet]
        public List<User> GetData() {

    // tracks will be populated with the result of the query.
    List<User> Users = new List<User>();

    //GetFullPath will return a string to complete the absolute path.
    string dataSource = "Data Source=" + Path.GetFullPath("Resident.db");

    //using will make sure that the resource is cleaned from memory after it exits.
    //conn initializes the connection to the .db file.
    using(SqliteConnection conn = new SqliteConnection(dataSource)){
        conn.Open();

         //sql is the string that will be run as an sql command
         string sql = $"select * from user4 limit 200;";

         //command combines the connection and the command string and creates the query
         using(SqliteCommand command = new SqliteCommand(sql, conn)) {

             // reader allows you to read each value that comes back and do something to it.
             using(SqliteDataReader reader = command.ExecuteReader()) {

                 // Read returns true while there are more rows to advance to. then false when done.
                 while (reader.Read()) {

                     // map the data to the model.
                      User newUser = new User() {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetInt32(2),
                        Email = reader.GetInt32(3),
                        Address = reader.GetInt32(4),
                        PhoneNumber = reader.GetInt32(5),
                        Apartment = reader.GetValue(6).ToString()
                        
                    };

                     // add each one to the list.
                     //User.AddIdentity(newUser);
                 }
             }
         }
         conn.Close();
    }     
    //return newUser;
        }
    }   
}