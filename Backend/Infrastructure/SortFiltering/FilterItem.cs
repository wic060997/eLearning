using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SortFiltering
{
    public class FilterItem
    {
        public string Property { get; set; }

        public object Value { get; set; }

        public FilterOperator Operator { get; set; }
    }
}
