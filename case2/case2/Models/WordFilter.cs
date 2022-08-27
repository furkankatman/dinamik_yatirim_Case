using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace case2.Models
{
    public class WordFilter
    {
        public bool isAscendingById {get; set; }
        public bool isDescendingById {get; set; }
        public bool byNameAsc { get; set; }
        public bool byNameDesc { get; set; }
        public string filterText { get; set; }

        public WordFilter()
        {
            isAscendingById = false;
            isDescendingById = true;
            byNameAsc = false;
            byNameDesc = false;
            filterText = "";
        }
        
    }
}
