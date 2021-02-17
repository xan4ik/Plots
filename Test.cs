using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plots
{
    public class AxisHintModelCreator : IModelCreator<AxisHintModel>
    {
        private PlotDimension plotDimension;
        private uint hintsPerAxis;
        private float hintPixelLength;

        public AxisHintModelCreator(PlotDimension plotDimension, uint hintsPerAxis = 10, float hintLength = 5)
        {
            this.plotDimension = plotDimension;
            this.hintsPerAxis = hintsPerAxis;
            this.hintPixelLength = hintLength;
        }

        public AxisHintModel CreateModel(PlotToModelProjector projector)
        {
            var stepX = Math.Abs(plotDimension.MinX - plotDimension.MaxX) / hintsPerAxis;
            var stepY = Math.Abs(plotDimension.MinY - plotDimension.MaxY) / hintsPerAxis;
            var hintOffset = hintPixelLength / 2;
            var centerPoint = projector.ProjectPlotPointToModel(new PlotPoint(0, 0));
            var plotPoint = default(PlotPoint);

            for (float i = plotDimension.MinX; i < plotDimension.MaxX; i+= stepX) // ось Х
            {
                plotPoint.X = i;
                plotPoint.Y = centerPoint.Y;

                var modelPoint = projector.ProjectPlotPointToModel(plotPoint);
                var hintBegin = modelPoint;
                var hintEnd = modelPoint;
                hintBegin.Y -= hintOffset;
                hintBegin.Y += hintOffset;
            }

            for (float i = plotDimension.MinY; i < plotDimension.MaxY; i += stepY) // ось Х
            {
                plotPoint.X = centerPoint.X;
                plotPoint.Y = i;

                var modelPoint = projector.ProjectPlotPointToModel(plotPoint);
                var hintBegin = modelPoint;
                var hintEnd = modelPoint;
                hintBegin.X -= hintOffset;
                hintBegin.X += hintOffset;
            }

            return null;
        }
    }

    public class AxisHintViewer : IViewer<AxisHintModel>
    {
        public void ShowModel(IDrawer drawer, AxisHintModel model)
        {
            DrawHints(drawer, model.X_AxisHints, model.X_Values);
            DrawHints(drawer, model.Y_AxisHints, model.Y_Values);
        }

        public void DrawHints(IDrawer drawer, PlotPoint[] axisHints, float[] hintValues) 
        {
            for (int i = 0; i < hintValues.Length; i++)
            {
                drawer.DrawLine(axisHints[2 * i], axisHints[2 * i + 1]);
            }
        }
    }

    public class AxisHintModel
    {
        public int HintsPerAxis;
        public float[] Y_Values;
        public float[] X_Values;
        public PlotPoint[] X_AxisHints;
        public PlotPoint[] Y_AxisHints;
    }


}
