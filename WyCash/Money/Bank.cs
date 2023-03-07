using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WyCash
{
    public class Bank
    {
        public Money Reduce( Expression source, string to )
        {
            if( source is Money )
            {
                return ( (Money)source ).Reduce( to );
            }
            Sum sum = (Sum)source;
            return sum.Reduce( to );
        }
    }
}
