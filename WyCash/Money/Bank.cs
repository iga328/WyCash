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
            return source.Reduce( this, to );
        }

        public void AddRate( string from, string to, int rate )
        { }
    }
}
