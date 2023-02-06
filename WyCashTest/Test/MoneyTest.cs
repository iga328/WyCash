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

            Dollar product = five.Times( 2 );
            Assert.AreEqual( 10, product.amount );
            Console.WriteLine( "five.amount(Times:2) = " + product.amount );

            product = five.Times( 3 );
            Assert.AreEqual( 15, product.amount );
            Console.WriteLine( "five.amount(Times:3) = " + product.amount );
        }

        [Test]
        public void Test02_Equality()
        {
            Assert.IsTrue( new Dollar( 5 ).IsEqual( new Dollar( 5 ) ) );
            Console.WriteLine( "new Dollar( 5 ).IsEqual( new Dollar( 5 ) ) = True" );

            Assert.IsFalse( new Dollar( 5 ).IsEqual( new Dollar( 6 ) ) );
            Console.WriteLine( "new Dollar( 5 ).IsEqual( new Dollar( 6 ) ) = False" );
        }
    }
}
