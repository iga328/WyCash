using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WyCash
{
    public abstract class Money
    {
        protected int amount;

        public abstract Money Times( int multiplier );

        public bool IsEqual( object target )
        {
            Money money = (Money)target;
            return this.amount == money.amount && this.GetType().Equals( money.GetType() );
        }

        public static Money Dollar( int amount )
        {
            return new Dollar( amount );
        }
    }
}
