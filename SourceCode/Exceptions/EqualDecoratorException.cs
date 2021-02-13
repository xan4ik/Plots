using System;

namespace Plots.Exeptions
{
    public class EqualDecoratorException : Exception
    {
        public EqualDecoratorException(Type type) : base(type.ToString() + " this decorator is already in order")
        {}
    }
}
