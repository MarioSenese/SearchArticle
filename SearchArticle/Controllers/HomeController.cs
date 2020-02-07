using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SearchArticle.Models;
using System.Web;

using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using DAL;

using System.Data.Odbc;

namespace SearchArticle.Controllers
{
    public class HomeController : Controller
    {
        private string keyword;

        //private Database db = Database.Open("cms|b2b|cmsNEW");
        //private SqlConnection connection = new SqlConnection("Server=SDADMIN45427833/SQL2012R2STD;Database=calzaretta_b2c;User ID=sa;Password=calzaretta!123");

        private readonly IConfiguration configuration;

        public HomeController(IConfiguration conf)
        {
            this.configuration = conf;
        }
       
        // GET: Home
        //public ActionResult Index() {
          public IActionResult Index()
        {
            connectDB();

            return View();

        }

        private void connectDB()
        {

            //string config = configuration["ConString1"];
             ConnectionStringManager connectionStringManager = new ConnectionStringManager();
             var contrs = connectionStringManager.GetConnectionString();


             Debug.Write("_configuration: " + contrs);

             SqlConnection connection = new SqlConnection(contrs);

             try {
                 connection.Open();
                 Debug.Write("Connessione al server e database avvenuta con successo");
                 Debug.WriteLine("ServerVersion: {0}", connection.ServerVersion);
                 Debug.WriteLine("State: {0}", connection.State);
             }
             catch (SqlException ex) {
                 Debug.Write("Nessuna connessione al server e al database\n" + ex.ToString());
             }

        }

        [HttpPost]
        public JsonResult Search(Prodotto prodotto) => Json(prodotto);

        [HttpPost]
        public JsonResult SearchArticleCode(Prodotto p) {
            string codice = "";
            if (p.codart != null) {
                codice = p.codart;
            }
            return Json(p);
        }

        [HttpPost]
        public JsonResult SearchArticleDescription(Prodotto p) {
            string descrizione = "";
            if (p.descpro != null) {
                descrizione = p.descpro;
            }
            return Json(p);
        }

        public string HelloWorld()
        {

            return "Hello World";

        }

        
        [HttpPost]
        public string Keyword(string key, string filter)
        {

            Prodotto p = new Prodotto();

            writeMessage("ricerca keyword...\n");

            if (filter.Equals("TextCodice"))
            {

                p.codart = key;
                keyword = p.codart;

            }
            else if (filter.Equals("TextDescrizione"))
            {
                p.codpro = key;
                keyword = p.codpro;
            }
            else {

                p.codart = p.codpro = "";
                keyword = "";

            }


            Console.WriteLine("keyword cercata: ${keyword}");
            //JsonResult json = Search(p);
            
            return keyword;

        }

        [Conditional("DEBUG")]
        public void writeMessage(object value) {
            Debug.Write(value);
        }



    }
}
