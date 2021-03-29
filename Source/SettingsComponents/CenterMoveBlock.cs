namespace Plots
{
    public class CenterMoveBlock : ISettingUpdateBlock
    {
        private float offsetX;
        private float offsetY;

        public void MoveCenter(float offsetX, float offsetY) 
        {
            this.offsetX = offsetX;
            this.offsetY = offsetY;
        }

        public PlotExtristics UpdateExtristics(PlotExtristics old)
        {
            old.Center = PlotPoint.MoveFromOrigin(old.Center, offsetX, offsetY);
            offsetX = 0;
            offsetY = 0;

            return old;
        }
    }
}
