using System;

namespace Plots
{
    public class LocationPointsViewer : IViewer<PointWithLocationModel>
    {
        public void ShowModel(IDrawer drawer, PointWithLocationModel model)
        {
            for (int i = 0; i < model.PointsCount; i++)
            {
                drawer.DrawPoint(model.ModelPoints[i]);
                drawer.DrawString(model.ModelPoints[i], CreateStringLocation(model.PlotPoints[i]));
            }
        }

        private string CreateStringLocation(PlotPoint point) 
        {
            return String.Format("({0:0.00}, {1:0.00})", point.X, point.Y);
        }
    }


}
