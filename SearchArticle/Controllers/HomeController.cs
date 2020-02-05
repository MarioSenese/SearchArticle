using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SearchArticle.Models;
using System.Web;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using log4net;

namespace SearchArticle.Controllers
{
    public class HomeController : Controller
    {
        private string keyword;
        //private Database db = Database.Open("cms|b2b|cmsNEW");
        private SqlConnection connection = new SqlConnection("Server=SDADMIN45427833/SQL2012R2STD;Database=calzaretta_b2c;User ID=sa;Password=calzaretta!123");


        // GET: Home
        public ActionResult Index() {
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
           
            //JsonResult json = Search(p);
            
            return keyword;

        }

        [Conditional("DEBUG")]
        public void ConnectDatabase() {

            try
            {
                connection.Open();
            
            }
            catch (Exception ex)
            {
                
            }

        }

    }
}
