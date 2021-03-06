namespace Plots
{
    //TODO: rename
    public class LocationAxisModelCreator : AxisModelCreator<AxisAndLocationModel>
    {
        private PlotPoint modelPoint;

        public PlotPoint Center 
        {
            set 
            {
                modelPoint = value;
            }
        }

        public override AxisAndLocationModel CreateModel(PlotToModelProjector projector)
        {
            var mathModel = GetAxisThroughtPoint(projector, modelPoint);
            var axisCenter = projector.ProjectModelToPlotPoint(modelPoint);

            return new AxisAndLocationModel(mathModel, axisCenter, modelPoint);
        }
    }
}
