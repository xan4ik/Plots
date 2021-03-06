using System.Collections.Generic;

namespace Plots
{
    public abstract class PlotPointCreator<T> : IModelCreator<T> 
    {
        private List<PlotPoint> points;
        protected PlotPointCreator(params PlotPoint[] plotPoints)
        {
            points = new List<PlotPoint>();
            foreach (PlotPoint point in plotPoints)
            {
                points.Add(point);
            }
        }

        public void AddPoint(PlotPoint plotPoint)
        {
            points.Add(plotPoint);
        }

        public void RemovePoint(int index)
        {
            points.RemoveAt(index);
        }

        public int PointCount()
        {
            return points.Count;
        }

        public void Clear()
        {
            points.Clear();
        }

        public abstract T CreateModel(PlotToModelProjector projector);

        protected IEnumerable<PlotPoint> GetSourcePoints()
        {
            return points;
        }
    }


}
