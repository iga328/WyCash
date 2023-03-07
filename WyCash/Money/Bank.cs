using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WyCash
{
    public class Bank
    {
        public Money Reduce( Expression source, string to )
        {
            Sum sum = (Sum)source;
            int amount = sum.augend.amount + sum.addend.amount;
            return new Money( amount, to );
        }
    }
}
