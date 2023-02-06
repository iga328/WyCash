using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WyCash
{
    public class Dollar
    {
        public int amount;

        public Dollar( int amount )
        {
            this.amount = amount;
        }

        public Dollar Times( int multiplier )
        {
            return new Dollar( this.amount * multiplier );
        }

        public bool IsEqual( object target )
        {
            return this.amount == ( (Dollar)target ).amount;
        }
    }
}
