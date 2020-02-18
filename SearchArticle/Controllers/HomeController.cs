using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SearchArticle.Models;
using System.Web;

using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;



namespace SearchArticle.Controllers
{
    public class HomeController : Controller
    {
        private string keyword;
        
        private readonly IConfiguration configuration;

        public HomeController(IConfiguration conf)
        {
            this.configuration = conf;
        }
       
        // GET: Home
        //public ActionResult Index() {
          public IActionResult Index()
           {

                TecDoc tecDoc = new TecDoc();
                tecDoc.Detail();
                Debug.Write("\n PROVIDER ID: " + tecDoc.JsonServiceUrl + " \n");


                /*
                *   Collegamento al database
                */ 
                Database db = new Database();
           
                db.Open();
           
                /*
                * Esecuzione QUERY SQL
                */
                List<string> res = db.ExecuteQuerySQL("SELECT * FROM eice.Accounts a WHERE a.Email=@paramValue;", "senese.mario90@gmail.com");
                Debug.Write("\n");
                Debug.Write("num res: "  + res.Count);
                Debug.Write("\n");
                if (res != null || res.Count > 0) {
                    string jsonParam = JsonConvert.SerializeObject(res);

                    Debug.Write("\n");
                    Debug.Write(jsonParam);
                    Debug.Write("\n");

                }
                db.Close();

                return View();

            }

        [HttpPost]
        public JsonResult Search(Prodotto prodotto) => Json(prodotto);

        [HttpPost]
        public JsonResult SearchArticleCode(Prodotto p) {
            if (p.codart != null) {
                _ = p.codart;
            }
            return Json(p);
        }

        [HttpPost]
        public JsonResult SearchArticleDescription(Prodotto p) {
            if (p.descpro != null) {
                _ = p.descpro;
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

            WriteMessage("ricerca keyword...\n");

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

            EseguiQuery(keyword);

            return keyword;

        }

        private void EseguiQuery(string keyword)
        {
            if (keyword is null)
            {
                throw new ArgumentNullException(nameof(keyword));
            }

            Debug.Write("\n\n");
            Debug.Write(keyword);
            Debug.Write("\n\n");

            /*Database db = new Database();
            db.Open();
            // istruzioni esegui query
            db.Query(selezionaProdottoDaListiniNETPiB2PNiB2CPi);
            db.Close();*/


        }

        [Conditional("DEBUG")]
        public void WriteMessage(object value) {
            Debug.Write(value);
        }



    }
}
