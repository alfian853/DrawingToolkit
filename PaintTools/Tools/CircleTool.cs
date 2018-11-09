using DrawingToolkit.DrawingObjects;
using DrawingToolkit.DrawingStates;
using DrawingToolkit.Toolbox;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DrawingToolkit.Tools
{
    class CircleTool : DrawingTool
    {
        int centerX;
        int centerY;
        int edgeX;
        int edgeY;

        DobCircle circleObject;

        public CircleTool(IDrawingToolBox drawingToolBox, Point position, Size size)
            : base(drawingToolBox, position, size)
        {
            this.toolButton.Name = "lingkaran";
            this.toolButton.BackgroundImage = global::DrawingToolkit.Properties.Resources.circle;
            this.toolButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }

        public Button GetToolButton()
        {
            throw new NotImplementedException();
        }

        public override void onMouseDown(int x, int y)
        {
            centerX = x;
            centerY = y;
            
            this.circleObject = new DobCircle(x, y, 0, 0, this.getPenClone());
            this.drawingToolBox.GetCanvas()
                .AddDrawingObject(this.circleObject);
        }

        public override void onMouseMove(int x, int y)
        {
            edgeX = x;
            edgeY = y;
            if(this.circleObject != null)
            {
                if (edgeX < centerX)
                {
                    this.circleObject.X = edgeX;
                    this.circleObject.Width = centerX - edgeX;
                }
                else
                {
                    this.circleObject.X = centerX;
                    this.circleObject.Width = edgeX - centerX;
                }

                if (edgeY < centerY)
                {
                    this.circleObject.Y = edgeY;
                    this.circleObject.Height = centerY - edgeY;
                }
                else
                {
                    this.circleObject.Y = centerY;
                    this.circleObject.Height = edgeY - centerY;
                }
            }

        }

        public override void onMouseUp(int x, int y)
        {
            this.circleObject.SetState(StaticState.GetInstance());
            this.circleObject = null;
        }
    }
}
