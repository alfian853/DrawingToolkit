using DrawingToolkit.DrawingObjects;
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
        Rectangle rectangle;
        
        public RectangleTool(IDrawingToolClickListener clickListener, Point position, Size size)
            : base(clickListener, position, size)
        {
            rectangle = new Rectangle();
            this.toolButton.Name = "kotak";
            this.toolButton.BackgroundImage = global::DrawingToolkit.Properties.Resources.rectangle;
            this.toolButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }

        public override DrawingObject getDrawingObject()
        {   
            if(lastX < initX)
            {
                rectangle.X = lastX;
                rectangle.Width = initX - lastX;
            }
            else
            {
                rectangle.X = initX;
                rectangle.Width = lastX - initX;
            }

            if (lastY < initY)
            {
                rectangle.Y = lastY;
                rectangle.Height = initY - lastY;
            }
            else
            {
                rectangle.Y = initY;
                rectangle.Height = lastY - initY;
            }
            return new DobRectangle(rectangle);
        }

        public override void onMouseDown(int x, int y)
        {
            initX = x;
            initY = y;
        }

        public override void onMouseMove(int x, int y)
        {
            lastX = x;
            lastY = y;
        }

        public override void onMouseUp(int x, int y)
        {
            this.rectangle.Width = Math.Max(0, x - this.rectangle.X);
            this.rectangle.Height = Math.Max(0, y - this.rectangle.Y);
        }
    }
}
