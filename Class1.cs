using Plots.Exeptions;
using System;
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

    public class ProcessBlock<T> : IDrawingProcessBlock
    {
        public DrawQueue DrawQueue => throw new NotImplementedException();

        public void Draw(IDrawer drawer, PlotToModelProjector projector)
        {
            throw new NotImplementedException();
        }
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

        //TODO: edges? 
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






    //TODO: rename
    public class LocationAxisModelCreator : AxisModelCreator<AxisAndLocationModel>
    {
        private PlotPoint modelPoint;

        public PlotPoint Center 
        {
            set 
            {
                modelPoint = value;
            }
        }

        public override AxisAndLocationModel CreateModel(PlotToModelProjector projector)
        {
            var mathModel = GetAxisThroughtPoint(projector, modelPoint);
            var axisCenter = projector.ProjectModelToPlotPoint(modelPoint);

            return new AxisAndLocationModel(mathModel, axisCenter, modelPoint);
        }
    }

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

    public abstract class AxisModelCreator<T> : IModelCreator<T>
    {
        public abstract T CreateModel(PlotToModelProjector projector);

        protected AxisMathModel GetAxisThroughtPoint(PlotToModelProjector projector, PlotPoint modelPoint) 
        {
            var maxModelPoint = projector.GetMaxModelPoint();
            var xBegin = new PlotPoint(0, modelPoint.Y);
            var yBegin = new PlotPoint(modelPoint.Y, 0);
            var xEnd = new PlotPoint(maxModelPoint.X, modelPoint.Y);
            var yEnd = new PlotPoint(modelPoint.X, maxModelPoint.Y);

            return new AxisMathModel(xBegin, xEnd, yBegin, yEnd);
        } 
    }

    public struct AxisAndLocationModel
    {
        public AxisMathModel Axis;
        public PlotPoint PlotCenter;
        public PlotPoint ModelCenter;

        public AxisAndLocationModel(AxisMathModel axis, PlotPoint plot, PlotPoint model)
        {
            Axis = axis;
            PlotCenter = plot;
            ModelCenter = model;
        }
    }
}
