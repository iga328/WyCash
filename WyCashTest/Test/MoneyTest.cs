using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WyCash;

namespace WyCashTest
{
    public class MoneyTest
    {
        [Test]
        public void Test01_Multiplication()
        {
            Dollar five = new Dollar( 5 );
            five.Times( 2 );
            Assert.AreEqual( 10, five.amount );
        }
    }
}
