using System;

namespace Plots.Exeptions
{
    public sealed class DimensionException : Exception
    {
        public DimensionException(string message) : base(message)
        { }
    }
}
