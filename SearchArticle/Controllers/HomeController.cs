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

        string selezionaProdottoDaListiniNETPiB2PNiB2CPi = "SELECT TOP 1 pe.CODART, ISNULL(pcl.Description, pc.DESCPRO) AS descrizione, sp.ProductDestination, sp.[Image], ma.DESMAR, lis.LIS_CODLIS, lis.LIS_PREZZO, pcl.url, pe.IDProdotto, ep.prezzo, ed.dispo, pc.CODPRO, pc.atrclpr0, ep.prezzoO, pc.ATRCLPR8, pc.ATRCLPR2  " +
                                                            "FROM eice.ProdottiCodificati pc " +
                                                            "INNER JOIN eice.ProdottiEsterni pe on pe.IDProdotto = pc.IDProdotto " +
                                                            "INNER JOIN eice.SintesiProdotti sp on pc.IDProdotto = sp.IDProdotto " +
                                                            "INNER JOIN eice.Marche ma on ma.CODMAR = sp.MARCA " +
                                                            "INNER JOIN eice.Listini lis on lis.CODPRO = pc.CODPRO " +
                                                            "INNER JOIN eice.Tlisti tl on lis.LIS_CODLIS = tl.CODTLIST " +
                                                            "INNER JOIN eice.ProdottiCodificatiLoc pcl on pc.IDProdotto = pcl.IDProdotto " +
                                                            "INNER JOIN eice.ExpProd ep ON pc.CODPRO = ep.codpro " +
                                                            "INNER JOIN eice.ExpDispo ed ON pc.CODPRO = ed.codpro " +
                                                            "INNER JOIN eice.marcat catm on ma.CODMAR = catm.CODMAR " +
                                                            "WHERE ma.DESMAR = @0 " +
                                                            "AND pe.CODART = @1 " +
                                                            "AND lis.LIS_SCAD = '9999-12-31 00:00:00' " +
                                                            "AND lis.LIS_CODLIS IN ('NETPi','B2PNi','B2CPi') " +
                                                            "AND pe.CODCAT = catm.CODCAT " +
                                                            "AND sp.ProductDestination IS NOT NULL " +
                                                            "ORDER BY tl.ID";

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
            Debug.Write("\n PROVIDER ID: " + tecDoc.jsonServiceUrl + " \n");


            /*
                Collegamento al database
            */ 
            //Database db = new Database();
            //db.Open();
            //string res = db.ExecuteQuerySQL("SELECT TOP (10) * FROM eice.Accounts a;");
           // List<string> res = db.ExecuteQuerySQL("SELECT TOP (10) * FROM eice.Accounts a;");
            //Debug.Write("numero di risultati: " + res.Count());

            /*for(int i = 0; i < res.Count(); i++)
            {
                Debug.Write(i + "): " + res[i].ToString() + "\n");
            }*/

            //db.Close();
            
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

            EseguiQuery(keyword);

            return keyword;

        }

        private void EseguiQuery(string keyword)
        {


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
