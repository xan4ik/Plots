namespace Plots
{
    public sealed class AxisModelCreator : IModelCreator<AxisMathModel>
    {
        public AxisMathModel CreateModel(PlotToModelProjector projector)
        {
            var modelCenter = projector.ProjectPlotPointToModel(new PlotPoint(0, 0));
            var maxModelPoint = projector.GetMaxModelPoint();

            var xBegin = new PlotPoint(0, modelCenter.Y);
            var yBegin = new PlotPoint(modelCenter.Y, 0);
            var xEnd = new PlotPoint(maxModelPoint.X, modelCenter.Y);
            var yEnd = new PlotPoint(modelCenter.X, maxModelPoint.Y);

            return new AxisMathModel(xBegin, xEnd, yBegin, yEnd);
        }
    }
}
