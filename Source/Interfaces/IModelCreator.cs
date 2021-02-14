namespace Plots
{
    public interface IModelCreator<T>
    
    {
        T CreateModel(PlotToModelProjector projector);
    }
}
