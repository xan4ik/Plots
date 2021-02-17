namespace Plots
{
    public class PointWithLocationModel 
    {
        public PlotPoint[] PlotPoints;
        public PlotPoint[] ModelPoints;
        public uint PointsCount;

        public PointWithLocationModel(PlotPoint[] plotPoints, PlotPoint[] modelPoints, uint pointsCount)
        {
            PlotPoints = plotPoints;
            ModelPoints = modelPoints;
            PointsCount = pointsCount;
        }
    }


}
