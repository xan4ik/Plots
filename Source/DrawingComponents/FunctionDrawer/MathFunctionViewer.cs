namespace Plots
{
    public class MathFunctionViewer : IViewer<MathPointModel>
    {
        public void ShowModel(IDrawer drawer, MathPointModel model)
        { 
            PlotPoint prevPoint = model.Points[0], nextPoint = model.Points[0];
            for (int i = 1; i < model.PointCount; i++)
            {
                drawer.DrawLine(prevPoint, nextPoint);
                prevPoint = nextPoint;
                nextPoint = model.Points[i];
            }
        }
    }
}
