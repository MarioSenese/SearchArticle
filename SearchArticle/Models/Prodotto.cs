using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchArticle.Models
{
    public class Prodotto
    {

        /*
            Proprietà TecDoc 
        */
        public long articleId { get; set; }
        public string articleName { get; set; }
        public string articleNo { get; set; }
        public string articleSearchNo { get; set; }
        public int articleStateId { get; set; }
        public string brandName { get; set; }
        public long brandNo { get; set; }
        public string genericArticleId { get; set; }
        public int numberType { get; set; }
        public bool isTecdoc { get; set; }

        /*
            Proprietà del Database 
        */
        public string codart { get; set; }
        public string descpro { get; set; }
        public string productDestination { get; set; }
        public string immaginePrincipale { get; set; }
        public string desmar { get; set; }
        public string lisCodlis { get; set; }
        public decimal prezzoIntero { get; set; }
        public string url { get; set; }
        public long idProdotto { get; set; }
        public decimal prezzoScontato { get; set; }
        public decimal prezzoOfficina { get; set; }
        public decimal percentuale { get; set; }
        public int dispo { get; set; }
        public string codpro { get; set; }
        public string kit { get; set; }
        public string confezionamento { get; set; }
        public string gruppo { get; set; }

        public AssignedArticle assignedArticle;

        public List<Attributo> attributi { get; set; }
        public List<Documento> documenti { get; set; }
        public List<OENumber> oeNumbers { get; set; }
        public List<EANNumber> eanNumbers { get; set; }
        public List<Prodotto> figli { get; set; }
        public List<ArticleThumbnails> articleThumbnails { get; set; }

        public Prodotto() {
            attributi = new List<Attributo>();
            documenti = new List<Documento>();
            oeNumbers = new List<OENumber>();
            eanNumbers = new List<EANNumber>();
            articleThumbnails = new List<ArticleThumbnails>(); 

            figli = new List<Prodotto>();
        }


    }
}
