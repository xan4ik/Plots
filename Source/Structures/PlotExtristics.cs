using System;
using System.Drawing;

namespace Plots
{
    public struct PlotExtristics
    {
        private PlotSize framePixelSize;
        private PlotPoint frameCenter;
        private float multiplierX;
        private float multiplierY;

        public PlotExtristics(PlotSize framePixelSize, PlotPoint frameCenter, float multiplierX = 1, float multiplierY = 1)
        {
            this.framePixelSize = framePixelSize;
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
            get => framePixelSize;
            set => framePixelSize = value;
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
            return new PlotExtristics(framePixelSize, frameCenter);
        }
    }
}
