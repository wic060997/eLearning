using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SortFiltering
{
    public enum FilterOperator
    {
        Eq = 0,  // Equal
        Like = 1,  // Like "String%"
        Lt = 2,  // Lower than
        Gt = 3,  // Greater than
        Lte = 4,  // Lower than or Equal
        Gte = 5,  // Greater than or Eqaul
        Null = 6,  // Is Null
        NotNull = 7,  // Is Not Null
        In = 8   // In "1,2,3"
    }
}
