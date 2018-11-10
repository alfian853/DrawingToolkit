using DrawingToolkit.DrawingObjects;
using DrawingToolkit.DrawingStates;
using DrawingToolkit.Toolbox;
using System.Diagnostics;
using System.Drawing;

namespace DrawingToolkit.Tools
{
    public class ConnectTool : DrawingTool
    {
        private ConnectorLine lineObject;
        private DrawingObject start;

        public ConnectTool(IDrawingToolBox drawingToolBox, Point position, Size size)
            : base(drawingToolBox, position, size)
        {
            this.toolButton.Text = "R";
        }

        public override void onMouseDown(int x, int y)
        {
            start = drawingToolBox.GetCanvas().GetDrawingObjectAt(x, y,true);
            Debug.WriteLine("drop " + x + " " + y);
            if(start != null)
            {
                lineObject = new ConnectorLine(x, y, x, y, this.getPenClone());
                drawingToolBox.GetCanvas().AddDrawingObject(lineObject);
            }
        }

        public override void onMouseMove(int x, int y)
        {
            if (this.lineObject != null)
            {
                this.lineObject.eX = x;
                this.lineObject.eY = y;
            }
        }

        public override void onMouseUp(int x, int y)
        {
            if(start != null)
            {
                DrawingObject end = drawingToolBox.GetCanvas().GetDrawingObjectAt(x, y,true);
                if(end != null)
                {
                    lineObject.setConnectable((IConnectable)start, (IConnectable) end);
                    lineObject.SetState(StaticState.GetInstance());
                }
                else if(lineObject != null)
                {
                    this.drawingToolBox.GetCanvas().RemoveDrawingObject(lineObject);
                }
            }
            lineObject = null;

        }
    }
}
