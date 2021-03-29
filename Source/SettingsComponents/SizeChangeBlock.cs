namespace Plots
{
    public class SizeChangeBlock : ISettingUpdateBlock
    {
        private float step;

        public void ChangeBy(float step) 
        {
            this.step = step;
        }

        public PlotExtristics UpdateExtristics(PlotExtristics old)
        {
            old.MultiplierX += step;
            old.MultiplierY += step;
            step = 0;
            return old;
        }
    }
}
