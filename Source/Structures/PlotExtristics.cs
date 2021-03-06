using System;
using System.Drawing;

namespace Plots
{
    public struct PlotExtristics
    {
        private PlotSize frameSize;
        private PlotPoint frameCenter;
        private float multiplierX;
        private float multiplierY;

        public PlotExtristics(PlotSize frameSize, PlotPoint frameCenter, float multiplierX = 1, float multiplierY = 1)
        {
            this.frameSize = frameSize;
            this.frameCenter = frameCenter;
            this.multiplierX = multiplierX;
            this.multiplierY = multiplierY;
        }

        public PlotPoint Center 
        {
            get => frameCenter;
            set => frameCenter = value;
        }

        public PlotSize FrameSize 
        {
            get => frameSize;
            set => frameSize = value;
        }

        public float MultiplierX 
        {
            get => multiplierX; 
            set => multiplierX = value; 
        }

        public float MultiplierY 
        { 
            get => multiplierY; 
            set => multiplierY = value; 
        }

        public PlotExtristics Clone()
        {
            return new PlotExtristics(frameSize, frameCenter);
        }
    }
}
