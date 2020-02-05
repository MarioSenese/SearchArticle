using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchArticle.Models
{
    public class Documento
    {

        public string docFileName { get; set; }
        public string docFileTypeName { get; set; }
        public string docId { get; set; }
        public long docLinkId { get; set; }
        public string docText { get; set; }
        public long docTypeId { get; set; }
        public string docTypeName { get; set; }
        public string docUrl { get; set; }

    }
}
