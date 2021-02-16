using System;
using System.Collections;
using System.Collections.Generic;

namespace Plots
{
    // TODO: list?
    public class MathFunctionModelCreator : IModelCreator<MathFunctionModel>
    {
        private IMathFunction mathFunction;
        private List<PlotPoint> points;
        private uint pointsCount;

        public MathFunctionModelCreator(IMathFunction mathFunction, uint pointsCount)
        {
            this.mathFunction = mathFunction;
            this.pointsCount = pointsCount;
            this.points = new List<PlotPoint>();
        }

        public MathFunctionModel CreateModel(PlotToModelProjector projector)
        {
            var step = CalculateStepOffset();
            points.Clear();

            for (float x = mathFunction.Range.MinX; x < mathFunction.Range.MaxX; x += step)
            {
                var plotPoint = new PlotPoint(x, mathFunction.FunctionValueOf(x));
                var modelPoint = projector.ProjectPlotPointToModel(plotPoint);
                points.Add(modelPoint);
            }

            return new MathFunctionModel(pointsCount, points.ToArray());
        }

        private float CalculateStepOffset() 
        {
            return Math.Abs(mathFunction.Range.MinX - mathFunction.Range.MaxX) / (float)pointsCount;
        }
    }
}
