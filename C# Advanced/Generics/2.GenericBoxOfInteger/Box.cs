using System;
using System.Collections.Generic;
using System.Text;

namespace _1._Generic_Box_of_String
{
    public class Box<T>
    {
        public T Value { get; set; }
        public Box(T value)
        {
            Value = value;
        }
        public override string ToString()
        {
            return $"{typeof(T)}: {Value}";
        }
    }
}
