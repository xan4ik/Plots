using System;

namespace Plots.Exeptions
{
    public class DecoratorLinkException : Exception
    {
        public DecoratorLinkException() : base("Component used by another drawer")
        { }
    }
}
