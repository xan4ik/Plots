using System;

namespace Plots
{
    public class AxisHintViewer : IViewer<AxisHintModel>
    {
        public void ShowModel(IDrawer drawer, AxisHintModel model)
        {
            DrawHintLines(drawer, model.X_AxisBeginEnd, model.HintsPerAxis);
            DrawHintLines(drawer, model.Y_AxisBeginEnd, model.HintsPerAxis);
            DrawHintsValues(drawer, model.X_ValuePositions, model.X_Values);
            DrawHintsValues(drawer, model.Y_ValuePositions, model.Y_Values);
        }

        public void DrawHintsValues(IDrawer drawer, PlotPoint[] valuePoitions, float[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                drawer.DrawString(valuePoitions[i], String.Format("{0: 0.00}", values[i]));
            }            
        }

        public void DrawHintLines(IDrawer drawer, PlotPoint[] axisHints, uint hintCount) 
        {
            for (int i = 0; i < hintCount; i++)
            {
                drawer.DrawLine(axisHints[2 * i], axisHints[2 * i + 1]);
            }
        }
    }


}
