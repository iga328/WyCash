using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WyCash
{
    public class Franc : Money
    {
        public Franc( int amount )
        {
            this.amount = amount;
        }

        public override Money Times( int multiplier )
        {
            return new Franc( this.amount * multiplier );
        }
    }
}
