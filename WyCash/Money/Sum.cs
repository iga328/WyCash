﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WyCash
{
    public class Sum : Expression
    {
        public Money augend;
        public Money addend;

        public Sum( Money augend, Money addend )
        {
            this.augend = augend;
            this.addend = addend;
        }
    }
}
