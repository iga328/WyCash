using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WyCash
{
    public class Pair
    {
        private string from;
        private string to;

        public Pair( string from, string to )
        {
            this.from = from;
            this.to = to;
        }

        public override int GetHashCode()
        {
            // Dictionaryのキーで使えるようにする
            // https://mocotan.hatenablog.com/entry/2017/10/31/064738
            return this.from.GetHashCode() ^ this.to.GetHashCode();
        }

        public override bool Equals( object obj )
        {
            Pair pair = (Pair)obj;
            return this.from.Equals( pair.from ) && this.to.Equals( pair.to );
        }

        public int HashCode()
        {
            return 0;
        }
    }
}
