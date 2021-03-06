using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plots
{
    public struct PlotPoint
    {
        public float X;
        public float Y;

        public PlotPoint(float x, float y)
        {
            X = x;
            Y = y;
        }

        public PlotPoint Move(float offsetX, float offsetY) 
        {
            return MoveFromOrigin(this, offsetX, offsetY);
        }

        public PlotPoint Move(PlotPoint axis, float offset) 
        {
            return MoveFromOrigin(this, axis, offset);
        }

        public static PlotPoint MoveFromOrigin(PlotPoint origin, float offsetX, float offsetY) 
        {
            var x = origin.X + offsetX;
            var y = origin.Y + offsetY;
            return new PlotPoint(x, y);
        }

        public static PlotPoint MoveFromOrigin(PlotPoint origin, PlotPoint axis, float offset) 
        {
            var x = origin.X + offset * axis.X;
            var y = origin.Y + offset * axis.Y;
            return new PlotPoint(x, y);
        }
    }
}
