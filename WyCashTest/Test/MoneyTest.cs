﻿using System;
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

            Assert.IsTrue( new Dollar( 10 ).IsEqual( five.Times( 2 ) ) );
            Console.WriteLine( "new Dollar( 10 ) = Money.Dollar( 5 ).Times( 2 )" );

            Assert.IsTrue( new Dollar( 15 ).IsEqual( five.Times( 3 ) ) );
            Console.WriteLine( "new Dollar( 15 ) = Money.Dollar( 5 ).Times( 3 )" );
        }

        [Test]
        public void Test02_Equality()
        {
            Assert.IsTrue( new Dollar( 5 ).IsEqual( new Dollar( 5 ) ) );
            Console.WriteLine( "new Dollar( 5 ).IsEqual( new Dollar( 5 ) ) = True" );

            Assert.IsFalse( new Dollar( 5 ).IsEqual( new Dollar( 6 ) ) );
            Console.WriteLine( "new Dollar( 5 ).IsEqual( new Dollar( 6 ) ) = False" );

            Assert.IsTrue( new Franc( 5 ).IsEqual( new Franc( 5 ) ) );
            Console.WriteLine( "new Franc( 5 ).IsEqual( new Franc( 5 ) ) = True" );

            Assert.IsFalse( new Franc( 5 ).IsEqual( new Franc( 6 ) ) );
            Console.WriteLine( "new Franc( 5 ).IsEqual( new Franc( 6 ) ) = False" );

            Assert.IsFalse( new Franc( 5 ).IsEqual( new Dollar( 5 ) ) );
            Console.WriteLine( "new Franc( 5 ).IsEqual( new Dollar( 5 ) ) = False" );
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
