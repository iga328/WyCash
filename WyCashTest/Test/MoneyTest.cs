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
            Money five = Money.Dollar( 5 );

            Assert.IsTrue( Money.Dollar( 10 ).IsEqual( five.Times( 2 ) ) );
            Console.WriteLine( "Money.Dollar( 10 ) = Money.Dollar( 5 ).Times( 2 )" );

            Assert.IsTrue( Money.Dollar( 15 ).IsEqual( five.Times( 3 ) ) );
            Console.WriteLine( "Money.Dollar( 15 ) = Money.Dollar( 5 ).Times( 3 )" );
        }

        [Test]
        public void Test02_Equality()
        {
            Assert.IsTrue( Money.Dollar( 5 ).IsEqual( Money.Dollar( 5 ) ) );
            Console.WriteLine( "Money.Dollar( 5 ).IsEqual( Money.Dollar( 5 ) ) = True" );

            Assert.IsFalse( Money.Dollar( 5 ).IsEqual( Money.Dollar( 6 ) ) );
            Console.WriteLine( "Money.Dollar( 5 ).IsEqual( Money.Dollar( 6 ) ) = False" );

            Assert.IsTrue( Money.Franc( 5 ).IsEqual( Money.Franc( 5 ) ) );
            Console.WriteLine( "Money.Franc( 5 ).IsEqual( Money.Franc( 5 ) ) = True" );

            Assert.IsFalse( Money.Franc( 5 ).IsEqual( Money.Franc( 6 ) ) );
            Console.WriteLine( "Money.Franc( 5 ).IsEqual( Money.Franc( 6 ) ) = False" );

            Assert.IsFalse( Money.Franc( 5 ).IsEqual( Money.Dollar( 5 ) ) );
            Console.WriteLine( "Money.Franc( 5 ).IsEqual( Money.Dollar( 5 ) ) = False" );
        }

        [Test]
        public void Test03_FrancMultiplication()
        {
            Money five = Money.Franc( 5 );

            Assert.IsTrue( Money.Franc( 10 ).IsEqual( five.Times( 2 ) ) );
            Console.WriteLine( "Money.Franc( 10 ) = Money.Franc( 5 ).Times( 2 )" );

            Assert.IsTrue( Money.Franc( 15 ).IsEqual( five.Times( 3 ) ) );
            Console.WriteLine( "Money.Franc( 15 ) = Money.Franc( 5 ).Times( 3 )" );
        }

        [Test]
        public void Test04_Currency()
        {
            Assert.AreEqual( "USD", Money.Dollar( 1 ).Currency() );
            Console.WriteLine( "Money.Dollar( 1 ).Currency() = USD" );

            Assert.AreEqual( "CHF", Money.Franc( 1 ).Currency() );
            Console.WriteLine( "Money.Franc( 1 ).Currency() = CHF" );
        }
    }
}
