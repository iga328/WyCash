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

        public Sum( Money augend, Money addend )
        {
            this.augend = augend;
            this.addend = addend;
        }

        public Money Reduce( Bank bank, string to )
        {
            int amount = this.augend.Reduce( bank, to ).amount + this.addend.Reduce( bank, to ).amount;
            return new Money( amount, to );
        }
    }
}
