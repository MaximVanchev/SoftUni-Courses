using System;
using System.Collections.Generic;
using System.Text;

namespace _7.Tuple
{
    public class Tuple<T1,T2>
    {
        public T1 ItemOne { get; set; }
        public T2 ItemTwo { get; set; }
        public Tuple(T1 itemOne,T2 itemTwo)
        {
            ItemOne = itemOne;
            ItemTwo = itemTwo;
        }
        public override string ToString()
        {
            return $"{ItemOne} -> {ItemTwo}";
        }
    }
}
