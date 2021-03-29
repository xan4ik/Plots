using Plots.Exeptions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plots
{
    //validator
    //drawers -> PointProvider/IntristicsProvider
    //namespace of esceptions

    public enum DrawQueue 
    {
        Begin,
        Process,
        End
    }

    public interface IDrawingProcessBlock
    {
        void Draw(IDrawer drawer, PlotToModelProjector projector);
        DrawQueue DrawQueue { get; }
    }



    public class PlotDrawer 
    {
        public List<IDrawingProcessBlock> dr_blocks = new List<IDrawingProcessBlock>();
        public List<ISettingUpdateBlock> st_blocks = new List<ISettingUpdateBlock>();

        public PlotExtristics extristics;

        public PlotDrawer()
        {
            
        }

        public void Draw(IDrawer drawer) 
        {
            foreach (var item in st_blocks)
            {
                extristics = item.UpdateExtristics(extristics);
            }

            var projector = new PlotToModelProjector(extristics);
            foreach (var item in dr_blocks)
            {
                item.Draw(drawer, projector);
            }
        }


        public void AddDrawingBlock(IDrawingProcessBlock drawingBlock) 
        {
            for (int i = 0; i < dr_blocks.Count; i++)
            {
                if(drawingBlock.DrawQueue == dr_blocks[i].DrawQueue) 
                {
                    dr_blocks.Insert(i, drawingBlock);
                    break;
                }
            }
        }

        public void AddSettingBlock(ISettingUpdateBlock updateBlock) 
        {
            st_blocks.Add(updateBlock);
        }

    //    private class Vallidator<T>
    //    {
    //        private PlotDrawer parent;

    //        public Vallidator(PlotDrawer parent)
    //        {
    //            this.parent = parent;
    //        }

    //        public bool Validate(ISettingUpdateBlock value) 
    //        {
    //            return 
    //        }
    //    }
    }


    public interface ISettingUpdateBlock 
    {
        PlotExtristics UpdateExtristics(PlotExtristics old);
    }








    public class PlotToModelProjector
    {
        private PlotExtristics extristics;

        public PlotToModelProjector(PlotExtristics extristics)
        {
            this.extristics = extristics;
        }

        //TODO: Maybe intristics will do that?
        public PlotPoint ProjectPlotPointToModel(PlotPoint plotPoint)
        {
            return new PlotPoint()
            {
                X = extristics.Center.X + plotPoint.X * extristics.MultiplierX,
                Y = extristics.Center.Y - plotPoint.Y * extristics.MultiplierY
            };
        }

        public PlotPoint ProjectModelToPlotPoint(PlotPoint model)
        {
            return new PlotPoint()
            {
                X = (model.X - extristics.Center.X ) / extristics.MultiplierX,
                Y = (-model.Y + extristics.Center.Y ) / extristics.MultiplierY
            };
        }

        //TODO: edges? 
        public PlotPoint GetMaxModelPoint()
        {
            var frameSize = extristics.FrameSize;
            return new PlotPoint()
            {
                X = frameSize.WidthPixel,
                Y = frameSize.HeightPixel
            };
        }
    }
}
