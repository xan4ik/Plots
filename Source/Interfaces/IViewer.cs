namespace Plots
{
    public interface IViewer<T> 
    {
        void ShowModel(IDrawer drawer, T model);
    }
}
