using System;

namespace Plots.Exeptions
{
    public class DecoratorAlreadyExistException : Exception
    {
        public DecoratorAlreadyExistException(Type type) : base(type.ToString() + " can't use those decorator twice to one drawer")
        { 
        }
    }
}
