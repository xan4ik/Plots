using System;

namespace Plots.Exeptions
{
    public class DecoratorIsntExistException : Exception
    {
        public DecoratorIsntExistException() : base("Decorator wasn't added to drawer")
        { }
    }
}
