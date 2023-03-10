using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WyCash
{
    [DataContract]
    public class Money : Expression
    {
        [DataMember()]
        public int amount;

        [DataMember()]
        protected string currency;

        public Money( int amount, string currency )
        {
            this.amount = amount;
            this.currency = currency;
        }

        public Expression Times( int multiplier )
        {
            return new Money( this.amount * multiplier, this.currency );
        }

        public Expression Plus( Expression addend )
        {
            return new Sum( this, addend );
        }

        public Money Reduce( Bank bank, string to )
        {
            int rate = bank.Rate( this.currency, to );
            return new Money( this.amount / rate, to );
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
            return new Money( amount, "USD" );
        }

        public static Money Franc( int amount )
        {
            return new Money( amount, "CHF" );
        }
    }
}
