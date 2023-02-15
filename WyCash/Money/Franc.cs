using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WyCash
{
    [DataContract]
    public class Franc : Money
    {
        public Franc( int amount, string currency ) : base( amount, currency )
        { }
    }
}
