using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plots
{
    //validator
    //drawers -> PointProvider/IntristicsProvider
    //namespace of esceptions
    public sealed class PlotProvider
    {
        //validator
        public void AddComponent(PlotComponent component)
        {

        }
    }

    public abstract class PlotComponent
    {


    }

    public enum DrawQueue 
    {
        Begin, 
        Process,
        End
    }

    public interface IDrawingProcessBlock 
    {
        void Draw(IDrawer drawer, PlotToModelProjector projector);
        DrawQueue DrawQueue { get; }
    }

    public class PlotToModelProjector
    {
        private PlotExtristics extristics;

        public PlotToModelProjector(PlotExtristics extristics)
        {
            this.extristics = extristics;
        }

        //TODO: Maybe intristics will do that?
        public PlotPoint ProjectPlotPointToModel(PlotPoint plotPoint)
        {
            return new PlotPoint()
            {
                X = extristics.Center.X + plotPoint.X * extristics.MultiplierX,
                Y = extristics.Center.Y - plotPoint.Y * extristics.MultiplierY
            };
        }

        public PlotPoint ProjectModelToPlotPoint(PlotPoint model)
        {
            return new PlotPoint()
            {
                X = model.X / extristics.MultiplierX - extristics.Center.X,
                Y = model.Y / extristics.MultiplierY + extristics.Center.Y,
            };
        }

        public PlotPoint GetMaxModelPoint()
        {
            var frameSize = extristics.FrameSize;
            return new PlotPoint()
            {
                X = frameSize.WidthPixel,
                Y = frameSize.HeightPixel
            };
        }
    }
}
