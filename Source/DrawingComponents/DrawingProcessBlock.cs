using System;

namespace Plots
{
    public class DrawingProcessBlock<T> : IDrawingProcessBlock
    {
        private IModelCreator<T> modelCreator;
        private IViewer<T> modelViewer;

        public DrawingProcessBlock(IModelCreator<T> modelCreator, IViewer<T> modelViewer)
        {
            this.modelCreator = modelCreator;
            this.modelViewer = modelViewer;
        }

        public DrawQueue DrawQueue => throw new NotImplementedException();

        public void Draw(IDrawer drawer, PlotToModelProjector projector)
        {
            var model = modelCreator.CreateModel(projector);
            modelViewer.ShowModel(drawer, model);
        }
    }
}
