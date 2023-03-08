using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WyCash
{
    public class Bank
    {
        private Dictionary<Pair, int> rates = new Dictionary<Pair, int>();

        public Money Reduce( Expression source, string to )
        {
            return source.Reduce( this, to );
        }

        public void AddRate( string from, string to, int rate )
        {
            this.rates.Add( new Pair( from, to ), rate );
        }

        public int Rate( string from, string to )
        {
            return this.rates[new Pair( from, to )];
        }
    }
}
