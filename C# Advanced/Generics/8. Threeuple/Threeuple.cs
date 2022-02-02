using System;
using System.Collections.Generic;
using System.Text;

namespace _8._Threeuple
{
    public class Threeuple<T1,T2,T3>
    {
        public T1 ItemOne { get; set; }
        public T2 ItemTwo { get; set; }
        public T3 ItemTree { get; set; }
        public Threeuple(T1 itemOne,T2 itemTwo,T3 itemTree)
        {
            ItemOne = itemOne;
            ItemTwo = itemTwo;
            ItemTree = itemTree;
        }
        public override string ToString()
        {
            return $"{ItemOne} -> {ItemTwo} -> {ItemTree}";
        }
    }
}
