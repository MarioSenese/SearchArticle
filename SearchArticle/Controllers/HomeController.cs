using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SearchArticle.Models;
using System.Web;

using Microsoft.Extensions.Configuration;

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

            /*
                Collegamento al database
            */ 
            Database db = new Database();
            db.connectDB();

            
            return View();

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
            
            return keyword;

        }

        [Conditional("DEBUG")]
        public void WriteMessage(object value) {
            Debug.Write(value);
        }



    }
}
