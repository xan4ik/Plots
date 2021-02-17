namespace Plots
{
    public class PointsModelViewer : IViewer<MathPointModel>
    {
        public void ShowModel(IDrawer drawer, MathPointModel model)
        {
            foreach (var point in model.Points)
            {
                drawer.DrawPoint(point);
            }
        }
    }


}
