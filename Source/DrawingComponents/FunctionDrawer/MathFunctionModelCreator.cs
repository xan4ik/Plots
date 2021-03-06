using System;
using System.Collections;
using System.Collections.Generic;

namespace Plots
{
    // TODO: list?
    public class MathFunctionModelCreator : IModelCreator<MathPointModel>
    {
        private IMathFunction mathFunction;
        private uint pointsCount;

        public MathFunctionModelCreator(IMathFunction mathFunction, uint pointsCount)
        {
            this.mathFunction = mathFunction;
            this.pointsCount = pointsCount;
        }

        public MathPointModel CreateModel(PlotToModelProjector projector)
        {
            var step = CalculateStepOffset();
            var points = CreateNewArray(); int index = 0;

            for (float x = mathFunction.Range.MinX; x < mathFunction.Range.MaxX - step; x += step)
            {
                var plotPoint = new PlotPoint(x, mathFunction.FunctionValueOf(x));
                var modelPoint = projector.ProjectPlotPointToModel(plotPoint);
                points[index] = modelPoint; index++;
            }

            return new MathPointModel(points, pointsCount);
        }

        private PlotPoint[] CreateNewArray() 
        {
            return new PlotPoint[pointsCount];
        }

        private float CalculateStepOffset() 
        {
            return Math.Abs(mathFunction.Range.MinX - mathFunction.Range.MaxX) / (float)pointsCount;
        }
    }
}
