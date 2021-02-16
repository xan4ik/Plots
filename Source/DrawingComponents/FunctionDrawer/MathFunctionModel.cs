namespace Plots
{
    public class MathFunctionModel
    {
        public uint PointCount;
        public PlotPoint[] Points;

        public MathFunctionModel(uint pointCount, PlotPoint[] points)
        {
            PointCount = pointCount;
            Points = points;
        }
    }
}
