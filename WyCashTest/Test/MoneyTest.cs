using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using NUnit.Framework;
using WyCash;

namespace WyCashTest
{
    public class MoneyTest
    {
        private void AreEqualByJson( object expected, object actual )
        {
            DataContractJsonSerializer serializerE = new DataContractJsonSerializer( expected.GetType() );
            MemoryStream msE = new MemoryStream();
            serializerE.WriteObject( msE, expected );

            DataContractJsonSerializer serializerA = new DataContractJsonSerializer( actual.GetType() );
            MemoryStream msA = new MemoryStream();
            serializerA.WriteObject( msA, actual );

            Assert.AreEqual( msE, msA, string.Format( "expected:{0}, actual:{1}",
                             Encoding.UTF8.GetString( msE.ToArray() ), Encoding.UTF8.GetString( msA.ToArray() ) ) );
        }

        [Test]
        public void Test01_DollarMultiplication()
        {
            Money five = Money.Dollar( 5 );

            this.AreEqualByJson( Money.Dollar( 10 ), five.Times( 2 ) );
            Console.WriteLine( "Money.Dollar( 10 ) = Money.Dollar( 5 ).Times( 2 )" );

            this.AreEqualByJson( Money.Dollar( 15 ), five.Times( 3 ) );
            Console.WriteLine( "Money.Dollar( 15 ) = Money.Dollar( 5 ).Times( 3 )" );
        }

        [Test]
        public void Test02_Equality()
        {
            Assert.IsTrue( Money.Dollar( 5 ).IsEqual( Money.Dollar( 5 ) ) );
            Console.WriteLine( "Money.Dollar( 5 ).IsEqual( Money.Dollar( 5 ) ) = True" );

            Assert.IsFalse( Money.Dollar( 5 ).IsEqual( Money.Dollar( 6 ) ) );
            Console.WriteLine( "Money.Dollar( 5 ).IsEqual( Money.Dollar( 6 ) ) = False" );

            Assert.IsFalse( Money.Franc( 5 ).IsEqual( Money.Dollar( 5 ) ) );
            Console.WriteLine( "Money.Franc( 5 ).IsEqual( Money.Dollar( 5 ) ) = False" );
        }

        [Test]
        public void Test03_Currency()
        {
            Assert.AreEqual( "USD", Money.Dollar( 1 ).Currency() );
            Console.WriteLine( "Money.Dollar( 1 ).Currency() = USD" );

            Assert.AreEqual( "CHF", Money.Franc( 1 ).Currency() );
            Console.WriteLine( "Money.Franc( 1 ).Currency() = CHF" );
        }

        [Test]
        public void Test04_SimpleAddition()
        {
            Money five = Money.Dollar( 5 );
            Expression sum = five.Plus( five );
            Bank bank = new Bank();
            Money reduced = bank.Reduce( sum, "USD" );
            this.AreEqualByJson( Money.Dollar( 10 ), reduced );
            Console.WriteLine( "Money.Dollar( 5 ).Plus( Money.Dollar( 5 ) ) = Money.Dollar( 10 )" );
        }

        [Test]
        public void Test05_PlusReturnsSum()
        {
            Money five = Money.Dollar( 5 );
            Expression result = five.Plus( five );
            Sum sum = (Sum)result;
            this.AreEqualByJson( five, sum.augend );
            Console.WriteLine( "Money.Dollar( 5 ) = sum.augend" );
            this.AreEqualByJson( five, sum.addend );
            Console.WriteLine( "Money.Dollar( 5 ) = sum.addend" );
        }

        [Test]
        public void Test06_ReduceSum()
        {
            Expression sum = new Sum( Money.Dollar( 3 ), Money.Dollar( 4 ) );
            Bank bank = new Bank();
            Money result = bank.Reduce( sum, "USD" );
            this.AreEqualByJson( Money.Dollar( 7 ), result );
            Console.WriteLine( "Money.Dollar( 7 ) = bank.Reduce( new Sum( Money.Dollar( 3 ), Money.Dollar( 4 ) ), \"USD\" )" );
        }

        [Test]
        public void Test07_ReduceMoney()
        {
            Bank bank = new Bank();
            Money result = bank.Reduce( Money.Dollar( 1 ), "USD" );
            this.AreEqualByJson( Money.Dollar( 1 ), result );
            Console.WriteLine( "Money.Dollar( 1 ) = bank.Reduce( Money.Dollar( 1 ), \"USD\" )" );
        }

        [Test]
        public void Test08_ReduceMoneyDifferentCurrency()
        {
            Bank bank = new Bank();
            bank.AddRate( "CHF", "USD", 2 );
            Money result = bank.Reduce( Money.Franc( 2 ), "USD" );
            this.AreEqualByJson( Money.Dollar( 1 ), result );
            Console.WriteLine( "Money.Dollar( 1 ) = bank.Reduce( Money.Franc( 2 ), \"USD\" )" );
        }

        [Test]
        public void Test09_IdentityRate()
        {
            Assert.AreEqual( 1, new Bank().Rate( "USD", "USD" ) );
            Console.WriteLine( "new Bank().Rate( \"USD\", \"USD\" ) = 1" );

            Assert.AreEqual( 1, new Bank().Rate( "CHF", "CHF" ) );
            Console.WriteLine( "new Bank().Rate( \"CHF\", \"CHF\" ) = 1" );
        }
    }
}
