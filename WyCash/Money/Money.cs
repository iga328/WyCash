using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WyCash
{
    [DataContract]
    public class Money
    {
        [DataMember()]
        protected int amount;

        [DataMember()]
        protected string currency;

        public Money( int amount, string currency )
        {
            this.amount = amount;
            this.currency = currency;
        }

        public virtual Money Times( int multiplier )
        {
            return null;
        }

        public string Currency()
        {
            return this.currency;
        }

        public bool IsEqual( object target )
        {
            Money money = (Money)target;
            return this.amount == money.amount && this.Currency().Equals( money.Currency(), StringComparison.Ordinal );
        }

        public static Money Dollar( int amount )
        {
            return new Dollar( amount, "USD" );
        }

        public static Money Franc( int amount )
        {
            return new Franc( amount, "CHF" );
        }
    }
}
