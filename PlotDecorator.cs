using System;
using System.Drawing;

namespace Plots_2.Decorators
{
    //[RepeatableComponent(true)]
    //public partial class PlotDecorator : DrawerDecorator
    //{
    //    private IMathFunction function;

    //    public PlotDecorator(IMathFunction function) : base(DrawingState.Process)
    //    {
    //        this.function = function;
    //    }

    //    public Color PlotColor { get; set; } = Color.Yellow;

    //    public IMathFunction MathFunction
    //    {
    //        get => function;
    //        set
    //        {
    //            if (value != null)
    //            {
    //                function = value;
    //            }
    //            else throw new ArgumentException("You tried set a Null function");
    //        }
    //    }

    //    public override void Draw(Graphics graphics)
    //    {
    //        var newDimension = RecountDimesion(Provider.Dimension, function.Range);

    //        DrawPlot(graphics, newDimension, Provider.Settings, Provider.Variables);
    //    }

    //    private void DrawPlot(Graphics graphics, DrawerDimension dimension, DrawerSettings settings, DrawerVariables variables)
    //    {
    //        if (function == null) throw new NullReferenceException("Don't set function");

    //        using (Pen pen = new Pen(PlotColor))
    //        {
    //            PointF prev;
    //            PointF next = Drawer.PointToPLotPoint(new PointF(dimension.MinX, MathFunction.CountFunctionOfX(dimension.MinX)), Provider);

    //            for (float i = dimension.MinX + variables.StepX; i <= dimension.MaxX + variables.StepX; i += variables.StepX)
    //            {
    //                prev = next;
    //                next = Drawer.PointToPLotPoint(new PointF(i, MathFunction.CountFunctionOfX(i)), Provider); // был + вместо -, нужно отнимать так как верхняя левая точка формы это (0, 0)

    //                graphics.DrawLine(pen, prev, next);
    //            }
    //        }
    //    } //метод отрисовки графика

    //    private DrawerDimension RecountDimesion(DrawerDimension dimension, Range range) 
    //    {
    //        dimension.MaxX = Math.Min(dimension.MaxX, range.MaxX);
    //        dimension.MinX = Math.Max(dimension.MinX, range.MinX);

    //        return dimension;
    //    }
    //}

    public partial class PlotDecorator 
    {
        public struct Range
        {
            private int minX;
            private int maxX;

            public Range(int minX, int maxX)
            {
                if (maxX <= minX)
                    throw new DimensionException("Max X can't be lower or equal to min X");

                this.minX = minX;
                this.maxX = maxX;
            }

            public int MinX => minX;
            public int MaxX => maxX;
        }
        public interface IMathFunction
        {
            Range Range { get; }
            float CountFunctionOfX(float X);
        }
    }
}
