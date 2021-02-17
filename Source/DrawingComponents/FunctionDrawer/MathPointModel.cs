namespace Plots
{
    public class MathPointModel
    {
        public PlotPoint[] Points;
        public uint PointCount;

        public MathPointModel(PlotPoint[] points, uint pointCount)
        {
            PointCount = pointCount;
            Points = points;
        }
    }
}
