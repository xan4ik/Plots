using System;

namespace Plots
{
    //TODO: think about decorator
    //TODO: is viewer good idea?
    public class AxisAndLocationViewer : IViewer<AxisAndLocationModel>
    {
        private AxisModelViewer axisViewer;
        public AxisAndLocationViewer()
        {
            axisViewer = new AxisModelViewer();
        }

        public void ShowModel(IDrawer drawer, AxisAndLocationModel model)
        {
            axisViewer.ShowModel(drawer, model.Axis);
            drawer.DrawString(model.ModelCenter, GetLocationString(model.PlotCenter));
        }

        private string GetLocationString(PlotPoint point) 
        {
            return String.Format("({0:0.00}, {1:0.00})", point.X, point.Y);
        }
    }
}
