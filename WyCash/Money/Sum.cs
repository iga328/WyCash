using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WyCash
{
    public class Sum : Expression
    {
        public Expression augend;
        public Expression addend;

        public Sum( Expression augend, Expression addend )
        {
            this.augend = augend;
            this.addend = addend;
        }

        public Expression Times( int multiplier )
        {
            return new Sum( this.augend.Times( multiplier ), this.addend.Times( multiplier ) );
        }

        public Expression Plus( Expression addend )
        {
            return new Sum( this, addend );
        }

        public Money Reduce( Bank bank, string to )
        {
            int amount = this.augend.Reduce( bank, to ).amount + this.addend.Reduce( bank, to ).amount;
            return new Money( amount, to );
        }
    }
}
