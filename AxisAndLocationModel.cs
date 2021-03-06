namespace Plots
{
    public struct AxisAndLocationModel
    {
        public AxisMathModel Axis;
        public PlotPoint PlotCenter;
        public PlotPoint ModelCenter;

        public AxisAndLocationModel(AxisMathModel axis, PlotPoint plot, PlotPoint model)
        {
            Axis = axis;
            PlotCenter = plot;
            ModelCenter = model;
        }
    }
}
