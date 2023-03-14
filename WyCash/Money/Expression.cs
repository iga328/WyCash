using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WyCash
{
    public interface Expression
    {
        Expression Plus( Expression addend );
        Money Reduce( Bank bank, string to );
    }
}
