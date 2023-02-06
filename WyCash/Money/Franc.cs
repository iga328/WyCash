using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WyCash
{
    public class Franc : Money
    {
        private int amount;

        public Franc( int amount )
        {
            this.amount = amount;
        }

        public Franc Times( int multiplier )
        {
            return new Franc( this.amount * multiplier );
        }

        public bool IsEqual( object target )
        {
            return this.amount == ( (Franc)target ).amount;
        }
    }
}
