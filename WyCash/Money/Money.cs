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
        protected string currency;

        public abstract Money Times( int multiplier );

        public string Currency()
        {
            return this.currency;
        }

        public bool IsEqual( object target )
        {
            Money money = (Money)target;
            return this.amount == money.amount && this.GetType().Equals( money.GetType() );
        }

        public static Money Dollar( int amount )
        {
            return new Dollar( amount );
        }

        public static Money Franc( int amount )
        {
            return new Franc( amount, null );
        }
    }
}
