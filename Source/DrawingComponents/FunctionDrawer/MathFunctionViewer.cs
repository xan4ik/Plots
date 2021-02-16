namespace Plots
{
    public class MathFunctionViewer : IViewer<MathFunctionModel>
    {
        public void ShowModel(IDrawer drawer, MathFunctionModel model)
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
