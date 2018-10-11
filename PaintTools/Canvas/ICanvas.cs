using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit.Canvas
{
    public enum ToolMode { Drawing, Moving };
    public interface ICanvas
    {
        Control GetControl();
        void setDrawingTool(DrawingTool tool);
        void setPenColor(Color c);
        void setToolMode(ToolMode toolMode);
    }
}
