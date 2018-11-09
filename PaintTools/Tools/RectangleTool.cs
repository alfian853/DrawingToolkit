using DrawingToolkit.DrawingObjects;
using DrawingToolkit.DrawingStates;
using DrawingToolkit.Toolbox;
using System;
using System.Drawing;

namespace DrawingToolkit.Tools
{
    class RectangleTool : DrawingTool
    {

        int initX;
        int initY;
        int lastX;
        int lastY;
        DobRectangle rectObject;
        
        public RectangleTool(IDrawingToolBox drawingToolBox, Point position, Size size)
            : base(drawingToolBox, position, size)
        {
            this.toolButton.Name = "kotak";
            this.toolButton.BackgroundImage = global::DrawingToolkit.Properties.Resources.rectangle;
            this.toolButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }

        public override void onMouseDown(int x, int y)
        {
            initX = x;
            initY = y;
            rectObject = new DobRectangle(
                x,y,0,0,
                this.getPenClone()
            );
            this.drawingToolBox.GetCanvas()
                .AddDrawingObject(this.rectObject);
        }

        public override void onMouseMove(int x, int y)
        {
            lastX = x;
            lastY = y;

            if(this.rectObject != null)
            {
                if (lastX < initX)
                {
                    this.rectObject.X = lastX;
                    this.rectObject.Width = initX - lastX;
                }
                else
                {
                    this.rectObject.X = initX;
                    this.rectObject.Width = lastX - initX;
                }

                if (lastY < initY)
                {
                    this.rectObject.Y = lastY;
                    this.rectObject.Height = initY - lastY;
                }
                else
                {
                    this.rectObject.Y = initY;
                    this.rectObject.Height = lastY - initY;
                }
            }
        }

        public override void onMouseUp(int x, int y)
        {
            this.rectObject.SetState(StaticState.GetInstance());
            this.rectObject = null;
        }
    }
}
