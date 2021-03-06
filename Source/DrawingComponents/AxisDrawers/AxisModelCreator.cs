namespace Plots
{
    public abstract class AxisModelCreator<T> : IModelCreator<T>
    {
        public abstract T CreateModel(PlotToModelProjector projector);

        protected AxisMathModel GetAxisThroughtPoint(PlotToModelProjector projector, PlotPoint modelPoint) 
        {
            var maxModelPoint = projector.GetMaxModelPoint();
            var xBegin = new PlotPoint(0, modelPoint.Y);
            var yBegin = new PlotPoint(modelPoint.X, 0);
            var xEnd = new PlotPoint(maxModelPoint.X, modelPoint.Y);
            var yEnd = new PlotPoint(modelPoint.X, maxModelPoint.Y);

            return new AxisMathModel(xBegin, xEnd, yBegin, yEnd);
        } 
    }
}
