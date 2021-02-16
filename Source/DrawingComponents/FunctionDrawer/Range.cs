using Plots.Exeptions;

namespace Plots
{
    public struct Range
    {
        private int minX;
        private int maxX;

        public Range(int minX, int maxX)
        {
            if (maxX <= minX)
                throw new DimensionException("Max X can't be lower or equal to min X");

            this.minX = minX;
            this.maxX = maxX;
        }

        public int MinX => minX;
        public int MaxX => maxX;
    }
}
