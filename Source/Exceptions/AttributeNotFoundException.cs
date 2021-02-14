using System;

namespace Plots.Exeptions
{
    public class AttributeNotFoundException : Exception
    {
        public AttributeNotFoundException(Type type) : base(type.ToString() + " this class has to use RepeatableComponentAttribute")
        {}
    }
}
