namespace Plots
{
    public class AxisModelViewer : IViewer<AxisMathModel>
    {
        public void ShowModel(IDrawer drawer, AxisMathModel model)
        {
            drawer.DrawLine(model.X_Begin, model.X_End);
            drawer.DrawLine(model.Y_Begin, model.Y_End);
        }
    }
}
