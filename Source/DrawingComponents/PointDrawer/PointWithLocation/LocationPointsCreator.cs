namespace Plots
{
    public class LocationPointsCreator : PlotPointCreator<PointWithLocationModel>
    {
        public override PointWithLocationModel CreateModel(PlotToModelProjector projector)
        {
            var sourceData = GetSourcePoints();
            var plotPoints = new PlotPoint[PointCount()];
            var modelPoints = new PlotPoint[PointCount()];
            var index = 0;

            foreach (var point in sourceData)
            {
                plotPoints[index] = projector.ProjectPlotPointToModel(point);
                modelPoints[index] = point;
                index++;
            }

            return new PointWithLocationModel(plotPoints, modelPoints, (uint)PointCount());
        }
    }


}
