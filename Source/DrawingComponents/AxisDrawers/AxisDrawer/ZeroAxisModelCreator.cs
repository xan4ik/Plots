namespace Plots
{
    public sealed class ZeroAxisModelCreator : AxisModelCreator<AxisMathModel>
    {
        public override AxisMathModel CreateModel(PlotToModelProjector projector)
        {
            var modelPoint = projector.ProjectPlotPointToModel(new PlotPoint(0, 0));
            return GetAxisThroughtPoint(projector, modelPoint);
        }
    }
}
