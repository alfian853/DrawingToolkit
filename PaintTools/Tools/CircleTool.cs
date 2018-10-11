using DrawingToolkit.DrawingObjects;
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
        Rectangle rectangle;

        public CircleTool(IDrawingToolClickListener clickListener, Point position, Size size)
            : base(clickListener, position, size)
        {
            this.toolButton.Name = "lingkaran";
            this.toolButton.BackgroundImage = global::DrawingToolkit.Properties.Resources.circle;
            this.toolButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }

        public override DrawingObject getDrawingObject()
        {
            if (edgeX < centerX)
            {
                rectangle.X = edgeX;
                rectangle.Width = centerX - edgeX;
            }
            else
            {
                rectangle.X = centerX;
                rectangle.Width = edgeX - centerX;
            }

            if (edgeY < centerY)
            {
                rectangle.Y = edgeY;
                rectangle.Height = centerY - edgeY;
            }
            else
            {
                rectangle.Y = centerY;
                rectangle.Height = edgeY - centerY;
            }
            return new DobCircle(rectangle);
        }

        public Button GetToolButton()
        {
            throw new NotImplementedException();
        }

        public override void onMouseDown(int x, int y)
        {
            centerX = x;
            centerY = y;
        }

        public override void onMouseMove(int x, int y)
        {
            edgeX = x;
            edgeY = y;
        }

        public override void onMouseUp(int x, int y)
        {
            this.rectangle.Width = Math.Max(0, x - this.rectangle.X);
            this.rectangle.Height = Math.Max(0, y - this.rectangle.Y);
        }
    }
}
