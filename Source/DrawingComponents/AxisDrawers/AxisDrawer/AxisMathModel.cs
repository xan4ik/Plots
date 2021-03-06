namespace Plots
{
    public struct AxisMathModel
    {
        public AxisMathModel(PlotPoint x_Begin, PlotPoint x_End, PlotPoint y_Begin, PlotPoint y_End)
        {
            this.X_Begin = x_Begin;
            this.X_End = x_End;
            this.Y_Begin = y_Begin;
            this.Y_End = y_End;
        }

        public PlotPoint X_Begin { get; private set; }
        public PlotPoint X_End { get; private set; }
        public PlotPoint Y_Begin { get; private set; }
        public PlotPoint Y_End { get; private set; }
    }
}
