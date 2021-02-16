namespace Plots
{
    public interface IMathFunction
    {
        Range Range { get; }
        float FunctionValueOf(float X);
    }
}
    