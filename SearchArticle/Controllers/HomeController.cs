using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SearchArticle.Models;
using System.Web;

namespace SearchArticle.Controllers
{
    public class HomeController : Controller
    {
       
        // GET: Home
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public JsonResult search(Prodotto p) {
            string codice = "";
            string descrizione = "";
            if (p.codart != null) {
                codice = p.codart;
            }
            if(p.descpro != null)
            {
                descrizione = p.descpro;
            }
            return Json(p);
        }

    }
}
