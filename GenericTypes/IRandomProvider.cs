﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes
{
    interface IRandomProvider<T> where T : IComparable<T>
    {
        public T GetRandom();

    }
}