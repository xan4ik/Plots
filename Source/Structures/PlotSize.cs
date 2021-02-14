using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plots
{
    public struct PlotSize
    {
        public uint WidthPixel;
        public uint HeightPixel;

        public PlotSize(uint widthPixel, uint heightPixel)
        {
            WidthPixel = widthPixel;
            HeightPixel = heightPixel;
        }
    }
}
