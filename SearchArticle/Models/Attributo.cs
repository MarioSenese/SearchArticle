using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchArticle.Models
{
    public class Attributo
    {

        public long attrBlockNo { get; set; }
        public long attrId { get; set; }
        public bool attrIsConditional { get; set; }
        public bool attrIsInterval { get; set; }
        public bool attrIsLinked { get; set; }
        public string attrName { get; set; }
        public string attrShortName { get; set; }
        public long attrSuccessorId { get; set; }
        public string attrType { get; set; }
        public string attrUnit { get; set; }
        public string attrValue { get; set; }
        public long attrValueId { get; set; }

    }
}
