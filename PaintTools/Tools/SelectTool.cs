using System;
using System.Drawing;
using DrawingToolkit.DrawingObjects;
using DrawingToolkit.DrawingStates;
using DrawingToolkit.Toolbox;

namespace DrawingToolkit.Tools
{
    public class SelectTool : DrawingTool
    {

        DrawingObject selectedObject;

        public SelectTool(IDrawingToolBox drawingToolBox, Point position, Size size)
            : base(drawingToolBox, position, size)
        {
            this.toolButton.Text = "M";
        }

        public override void onMouseDown(int x, int y)
        {
            this.selectedObject = this.drawingToolBox.GetCanvas().GetDrawingObjectAt(x, y);
            if(this.selectedObject != null)
            {
                this.selectedObject.SetState(MovingState.GetInstance());
                this.selectedObject.setMoveStart(x ,y);
            }
        }

        public override void onMouseMove(int x, int y)
        {
            if(this.selectedObject != null)
            {
                this.selectedObject.updateEndPoint(x, y);
            }
        }

        public override void onMouseUp(int x, int y)
        {
            if(this.selectedObject != null)
            {
                this.selectedObject.SetState(StaticState.GetInstance());
                this.selectedObject = null;
            }
        }
    }
}
