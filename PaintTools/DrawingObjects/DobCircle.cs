using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DrawingToolkit.DrawingObjects
{
    public class DobCircle : DrawingObject
    {
        
        public int X;
        public int Y;
        public int Width;
        public int Height;

        public DobCircle(int x, int y, int width, int height, Pen pen):base(pen)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        public override void Draw()
        {
            this.graphics.DrawEllipse(this.pen,
                this.X, this.Y, this.Width, this.Height
            );
        }

        public override void DrawPreview()
        {
            this.graphics.DrawEllipse(this.getFocusPen(DashStyle.Dot),
                this.X, this.Y, this.Width, this.Height
            );
        }

        public override bool isClickedAt(int x, int y)
        {
            float a = (float)this.Width / 2;
            float b = (float)this.Height / 2;
            int centerX = this.X + this.Width / 2;
            int centerY = this.Y + this.Height / 2;
            float ax = (float)Math.Pow(x-centerX,2);
            float by = (float)Math.Pow(y-centerY,2);
            ax /= (float)Math.Pow(a,2);
            by /= (float)Math.Pow(b,2);
            return Math.Abs(ax+by-1) <= 0.4;
        }
        
        public override void updateEndPoint(int x, int y)
        {
            this.X += x - this.moveStartX;
            this.Y += y - this.moveStartY;
            this.moveStartX = x;
            this.moveStartY = y;
        }

        public override void DrawMoving()
        {
            this.graphics.DrawEllipse(this.getFocusPen(DashStyle.Solid),
                this.X, this.Y, this.Width, this.Height
            );
        }

       
    }
}
