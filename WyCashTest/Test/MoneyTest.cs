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
            Money sum = Money.Dollar( 5 ).Plus( Money.Dollar( 5 ) );
            this.AreEqualByJson( Money.Dollar( 10 ), sum );
            Console.WriteLine( "Money.Dollar( 5 ).Plus( Money.Dollar( 5 ) ) = Money.Dollar( 10 )" );
        }
    }
}
