namespace Plots
{
    public interface IDrawer 
    {
        void DrawLine(PlotPoint begin, PlotPoint end);
        void DrawString(PlotPoint position, string text);
    }
}
