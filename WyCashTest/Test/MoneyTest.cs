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
        public void Test01_DollarMultiplication()
        {
            Dollar five = new Dollar( 5 );

            Assert.IsTrue( new Dollar( 10 ).IsEqual( five.Times( 2 ) ) );
            Console.WriteLine( "new Dollar( 10 ) = new Dollar( 5 ).Times( 2 )" );

            Assert.IsTrue( new Dollar( 15 ).IsEqual( five.Times( 3 ) ) );
            Console.WriteLine( "new Dollar( 15 ) = new Dollar( 5 ).Times( 3 )" );
        }

        [Test]
        public void Test02_DollarEquality()
        {
            Assert.IsTrue( new Dollar( 5 ).IsEqual( new Dollar( 5 ) ) );
            Console.WriteLine( "new Dollar( 5 ).IsEqual( new Dollar( 5 ) ) = True" );

            Assert.IsFalse( new Dollar( 5 ).IsEqual( new Dollar( 6 ) ) );
            Console.WriteLine( "new Dollar( 5 ).IsEqual( new Dollar( 6 ) ) = False" );
        }

        [Test]
        public void Test03_FrancMultiplication()
        {
            Franc five = new Franc( 5 );

            Assert.IsTrue( new Franc( 10 ).IsEqual( five.Times( 2 ) ) );
            Console.WriteLine( "new Franc( 10 ) = new Franc( 5 ).Times( 2 )" );

            Assert.IsTrue( new Franc( 15 ).IsEqual( five.Times( 3 ) ) );
            Console.WriteLine( "new Franc( 15 ) = new Franc( 5 ).Times( 3 )" );
        }
    }
}
