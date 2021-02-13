using System;
using System.Drawing;

namespace Plots
{
    public struct PlotExtristics
    {
        private uint hintCount;
        private uint pointCount;

        public PlotExtristics( uint hintSteps = 10, uint pointCount = 120)
        {
            if(hintSteps<0)
                throw new ArgumentException("HintSteps can't be 0");
            if(pointCount < 0)
                throw new ArgumentException("PointCount can't be 0");

            this.hintCount = hintSteps;
            this.pointCount = pointCount;
        }

        public uint HintCount
        {
            get => hintCount;
            set
            {
                if (value > 0)
                {
                    hintCount = value;
                }
                else throw new ArgumentException("HintSteps can't be 0");
            }
        }

        public uint PointCount
        {
            get => pointCount;
            set
            {
                if (value > 0)
                {
                    pointCount = value;
                }
                else throw new ArgumentException("PointCount can't be 0");
            }
        }
        public PlotExtristics Clone()
        {
            return new PlotExtristics(hintCount, pointCount);
        }
    }
}
