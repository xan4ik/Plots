using System;

namespace Plots
{
    public class AxisHintModelCreator : IModelCreator<AxisHintModel>
    {
        private PlotDimension plotDimension;
        private PlotPoint axisX;
        private PlotPoint axisY;
        private PlotPoint zero;
        private uint hintsPerAxis;
        private float hintOffset;

        public AxisHintModelCreator(PlotDimension plotDimension, uint hintsPerAxis = 10, float hintLength = 5)
        {
            this.plotDimension = plotDimension;
            this.hintsPerAxis = hintsPerAxis;
            this.hintOffset = hintLength / 2;

            axisX = new PlotPoint(1, 0);
            axisY = new PlotPoint(0, 1);
            zero = new PlotPoint(0, 0);
        }

        //TODO: offset positions
        public AxisHintModel CreateModel(PlotToModelProjector projector)
        {
            var steps = GetStepValues();
            var xValues = GetAxisValues(plotDimension.MinX, plotDimension.MaxX, steps.X);
            var yValues = GetAxisValues(plotDimension.MinY, plotDimension.MaxY, steps.Y);
            var xPositions = GetPostionsOnAxis(projector, axisX, xValues);
            var yPositions = GetPostionsOnAxis(projector, axisY, yValues);
            var xLines = GetHintLineBeginEnd(xPositions, axisY);
            var yLines = GetHintLineBeginEnd(yPositions, axisX);

            return new AxisHintModel()
            {
                HintsPerAxis = hintsPerAxis,
                X_Values = xValues,
                Y_Values = yValues,
                X_AxisBeginEnd = xLines,
                Y_AxisBeginEnd = yLines,
                X_ValuePositions = xPositions,
                Y_ValuePositions = yPositions
            };
        }

        private PlotPoint GetStepValues()
        {
            var stepX = Math.Abs(plotDimension.MinX - plotDimension.MaxX) / hintsPerAxis;
            var stepY = Math.Abs(plotDimension.MinY - plotDimension.MaxY) / hintsPerAxis;
            return new PlotPoint(stepX, stepY);
        }

        private float[] GetAxisValues(float begin, float end, float step)
        {
            float[] values = new float[hintsPerAxis]; var index = 0;
            for (float position = begin; position < end; position += step)
            {
                values[index] = position;
                index++;
            }
            return values;
        }

        private PlotPoint[] GetPostionsOnAxis(PlotToModelProjector projector, PlotPoint axis, float[] values)
        {
            PlotPoint[] positions = new PlotPoint[hintsPerAxis];
            for (int i = 0; i < values.Length; i++)
            {
                var pointOnAxis = PlotPoint.MoveFromOrigin(zero, axis, values[i]);
                var modelPoint = projector.ProjectPlotPointToModel(pointOnAxis);
                positions[i] = modelPoint;
            }

            return positions;
        }

        private PlotPoint[] GetHintLineBeginEnd(PlotPoint[] positionOnAxis, PlotPoint axis) 
        {
            PlotPoint[] linesBeginEnd = new PlotPoint[hintsPerAxis * 2];
            for (int i = 0; i < positionOnAxis.Length; i++)
            {
                linesBeginEnd[2 * i] = PlotPoint.MoveFromOrigin(positionOnAxis[i], axis, hintOffset);
                linesBeginEnd[2 * i + 1] = PlotPoint.MoveFromOrigin(positionOnAxis[i], axis, -hintOffset);
            }
            return linesBeginEnd;
        }
    }


}
