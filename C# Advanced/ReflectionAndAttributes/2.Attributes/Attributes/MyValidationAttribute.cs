using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    [AttributeUsage((AttributeTargets)384)]
    public abstract class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object obj);
    }
}
