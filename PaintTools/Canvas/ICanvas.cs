using DrawingToolkit.DrawingObjects;
using System.Drawing;
using System.Windows.Forms;

namespace DrawingToolkit.Canvas
{
    public enum ToolMode { Drawing, Moving };
    public interface ICanvas
    {
        Control GetControl();
        void SetDrawingTool(DrawingTool tool);
        void SetPenColor(Color c);
        void SetToolMode(ToolMode toolMode);
        DrawingObject GetDrawingObjectAt(int x, int y);
        void AddDrawingObject(DrawingObject drawingObject);
    }
}
