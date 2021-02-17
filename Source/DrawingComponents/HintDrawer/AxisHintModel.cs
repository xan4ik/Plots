using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plots
{
    public class AxisHintModel
    {
        public uint HintsPerAxis;
        public float[] Y_Values;
        public float[] X_Values;
        public PlotPoint[] X_AxisBeginEnd;
        public PlotPoint[] Y_AxisBeginEnd;
        public PlotPoint[] X_ValuePositions;
        public PlotPoint[] Y_ValuePositions;
    }
}
