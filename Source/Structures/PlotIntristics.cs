using System;

namespace Plots
{
    public struct PlotIntristics
    {
        public PlotIntristics(float stepX, float stepY, float multiplierX, float multiplierY, PlotPoint center = default(PlotPoint))
        {
            ///this.Center = center;
            this.StepX = stepX;
            this.StepY = stepY;

            this.MultiplierX = multiplierX;
            this.MultiplierY = multiplierY;
        }



        public float StepX { get; private set; }
        public float StepY { get; private set; }

        public float MultiplierX { get; private set; }
        public float MultiplierY { get; private set; }

        //public static PlotIntristics CountVariables(PlotDimension dimension, PlotExtristics settings) 
        //{
        //    return new PlotIntristics(Math.Abs(dimension.MaxX - dimension.MinX) / settings.PointCount,
        //                              Math.Abs(dimension.MaxY - dimension.MinY) / settings.PointCount,
        //                              settings.FrameSize.WidthPixel/ Math.Abs(dimension.MaxX - dimension.MinX),
        //                              settings.FrameSize.HeightPixel / Math.Abs(dimension.MaxY - dimension.MinY));
        //}
    }
}
