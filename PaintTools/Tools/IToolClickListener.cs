using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Tools
{
    public interface IDrawingToolClickListener
    {
        void OnDrawingToolClick(DrawingTool tool);
    }
}
