namespace Plots
{
    public class PointsModelCreator : PlotPointCreator<MathPointModel>
    {
        public PointsModelCreator(params PlotPoint[] points): base(points)
        { }

        public override MathPointModel CreateModel(PlotToModelProjector projector)
        {
            var sourceData = GetSourcePoints();
            var pointArr = new PlotPoint[PointCount()]; 
            var index = 0;

            foreach (var plotPoint in sourceData)
            {
                pointArr[index] = projector.ProjectPlotPointToModel(plotPoint);
                index++;
            }
            return new MathPointModel(pointArr, (uint)PointCount());
        }
    }
}
