using System;
using System.Collections;
using System.Collections.Generic;
using Plots.Exeptions;

namespace Plots
{
    public class MathFunctionModelCreator : IModelCreator<MathFunctionModel>
    {
        private IMathFunction mathFunction;
        private uint pointsCount;

        public MathFunctionModelCreator(IMathFunction mathFunction, uint pointsCount)
        {
            this.mathFunction = mathFunction;
            this.pointsCount = pointsCount;
        }

        public MathFunctionModel CreateModel(PlotToModelProjector projector)
        {
            var step = Math.Abs(mathFunction.Range.MinX - mathFunction.Range.MaxX) / (float)pointsCount;
            var pointArr = new PlotPoint[pointsCount];

            int i = 0;
            for (float x = mathFunction.Range.MinX; x < mathFunction.Range.MaxX; x+=step)
            {
                var plotPoint = new PlotPoint(x, mathFunction.FunctionValueOf(x));
                var modelPoint = projector.ProjectPlotPointToModel(plotPoint);

                pointArr[i++] = modelPoint;
            }

            return new MathFunctionModel(pointsCount, pointArr);
        }


    }

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

    public class MathFunctionModel
    {
        public uint PointCount;
        public PlotPoint[] Points;

        public MathFunctionModel(uint pointCount, PlotPoint[] points)
        {
            PointCount = pointCount;
            Points = points;
        }
    }


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
        float FunctionValueOf(float X);
    }
}
