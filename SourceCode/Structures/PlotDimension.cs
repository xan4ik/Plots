using System.Drawing;
using Plots.Exeptions;

namespace Plots
{
    public struct PlotDimension
    {
        public PlotDimension(float minX = 0, float maxX =0 , float minY= 0, float maxY=0)
        {
            if (maxX <= minX)
                throw new DimensionException("Max X is lower or equa to min X");
            if (maxY <= minY)
                throw new DimensionException("Max Y is lower or equa to min Y");

            this.MaxX = maxX;
            this.MinX = minX;

            this.MaxY = maxY;
            this.MinY = minY;
        }

        public float MaxX { get; set; }
        public float MaxY { get; set; }
        public float MinX { get; set; }
        public float MinY { get; set; }

        public bool Contains(PlotPoint point)
        {
            if (point.X < MinX || point.X > MaxX)
                return false;
            if (point.Y < MinY || point.Y > MaxY)
                return false;
            return true;
        }
    }
}
