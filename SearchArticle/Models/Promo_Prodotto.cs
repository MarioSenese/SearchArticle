using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchArticle.Models
{
    public class Promo_Prodotto
    {

        public List<Prodotto> prodotto { get; set; }
        public Promo promo { get; set; }

        public Promo_Prodotto() {
            prodotto = new List<Prodotto>();
            promo = new Promo();
        }

    }
}
