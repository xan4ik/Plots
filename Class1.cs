using Plots.Exeptions;
using System;
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

    public class ProcessBlock<T> : IDrawingProcessBlock
    {
        public DrawQueue DrawQueue => throw new NotImplementedException();

        public void Draw(IDrawer drawer, PlotToModelProjector projector)
        {
            throw new NotImplementedException();
        }
    }


    //public class PointDrawer 
    //{
    //    private List<PlotPoint> plotPoints;

    //    public PointDrawer()
    //    {
    //        plotPoints = new List<PlotPoint>();
    //    }

    //    public void Draw(IDrawer drawer, PlotToModelProjector projector)
    //    {
    //        var model = modelCreator.CreateModel(projector);
    //        viewer.ShowModel(drawer, model);
    //    }


    //    private object CreateModelValues(PlotToModelProjector projector) 
    //    {


    //    }
    //}


    //    public abstract class DrawingCpmponent<Creator, Model> : PlotComponent
    //       where: Creator
    //    {
    //    private IModelCreator<T> modelCreator;
    //    private IViewer<T> viewer;

    //    protected DrawingCpmponent(IModelCreator<T> modelCreator, IViewer<T> viewer)
    //    {
    //        this.modelCreator = modelCreator;
    //        this.viewer = viewer;
    //    }

    //    public void Draw(IDrawer drawer, PlotToModelProjector projector)
    //    {
    //        var model = modelCreator.CreateModel(projector);
    //        viewer.ShowModel(drawer, model);
    //    }
    //}

    //public abstract class DrawingCpmponent< T> : PlotComponent
    //{
    //    private IModelCreator<T> creator;
    //    private IViewer<T> viewer;

    //    protected DrawingCpmponent(IModelCreator<T> creator, IViewer<T> viewer)
    //    {
    //        this.creator = creator;
    //        this.viewer = viewer;
    //    }

    //    public void Draw(IDrawer drawer, PlotToModelProjector projector)
    //    {
    //        var model = creator.CreateModel(projector);
    //        viewer.ShowModel(drawer, model);
    //    }
    //}

    //public class MathFunctionCreator : IModelCreator<MathFunctionModel>
    //{




    //    public MathFunctionModel CreateModel(PlotToModelProjector projector)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class MathFunctionModel
    //{
    //}


    //public struct Range
    //{
    //    private int minX;
    //    private int maxX;

    //    public Range(int minX, int maxX)
    //    {
    //        if (maxX <= minX)
    //            throw new DimensionException("Max X can't be lower or equal to min X");

    //        this.minX = minX;
    //        this.maxX = maxX;
    //    }

    //    public int MinX => minX;
    //    public int MaxX => maxX;
    //}
    //public interface IMathFunction
    //{
    //    Range Range { get; }
    //    float CountFunctionOfX(float X);
    //}












    //public class AxisDrawer : DrawingCpmponent<AxisMathModel>
    //{
    //    private int someData;
    //    public AxisDrawer() : base(new AxisModelCreator(), new AxisModelViewer())
    //    {
    //    }
    //}

    //public class AxisModelViewer : IViewer<AxisMathModel>
    //{
    //    public void ShowModel(IDrawer drawer, AxisMathModel model)
    //    {
    //        drawer.DrawLine(model.X_Begin, model.X_End);
    //        drawer.DrawLine(model.Y_Begin, model.Y_End);
    //    }
    //}

    //public sealed class AxisModelCreator : IModelCreator<AxisMathModel>
    //{
    //    public AxisMathModel CreateModel(PlotToModelProjector projector)
    //    {
    //        var modelCenter = projector.ProjectPLotPointToModel(new PlotPoint(0, 0));
    //        var maxModelPoint = projector.GetMaxModelPoint();

    //        var xBegin = new PlotPoint(0, modelCenter.Y);
    //        var yBegin = new PlotPoint(modelCenter.Y, 0);
    //        var xEnd = new PlotPoint(maxModelPoint.X, modelCenter.Y);
    //        var yEnd = new PlotPoint(modelCenter.X, maxModelPoint.Y);

    //        return new AxisMathModel(xBegin, xEnd, yBegin, yEnd);
    //    }
    //}

    //public struct AxisMathModel
    //{
    //    public AxisMathModel(PlotPoint x_Begin, PlotPoint x_End, PlotPoint y_Begin, PlotPoint y_End)
    //    {
    //        this.X_Begin = x_Begin;
    //        this.X_End = x_End;
    //        this.Y_Begin = y_Begin;
    //        this.Y_End = y_End;
    //    }

    //    public PlotPoint X_Begin { get; private set; }
    //    public PlotPoint X_End { get; private set; }
    //    public PlotPoint Y_Begin { get; private set; }
    //    public PlotPoint Y_End { get; private set; }
    //}

































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
