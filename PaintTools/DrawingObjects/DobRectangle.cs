using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DrawingToolkit.DrawingObjects
{
    public class DobRectangle : DrawingObject
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;

        public DobRectangle(int x,int y, int width, int height, Pen pen) : base(pen)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        public override void DrawMoving()
        {
            this.graphics.DrawRectangle(this.getFocusPen(DashStyle.Solid),
                this.X, this.Y, this.Width, this.Height
            );
        }

        public override void Draw()
        {
            Debug.WriteLine("draw rectangle");
            this.graphics.DrawRectangle(this.pen,
                this.X, this.Y, this.Width, this.Height
            );
        }

        public override void DrawPreview()
        {
            Debug.WriteLine("drawPreview rectangle");

            this.graphics.DrawRectangle(this.getFocusPen(DashStyle.DashDot),
                this.X, this.Y, this.Width, this.Height
            );
        }

        bool isInRange(float a, float x, float x2)
        {
            return x <= a && a <= x2;
        }

        public override bool isClickedAt(int x, int y)
        {
            float halfW = this.pen.Width/2;
            if(isInRange(y, this.Y, this.Y + this.Height) )
            {
                if(isInRange(x, this.X - halfW, this.X + halfW))
                {
                    return true;
                }
                else if (isInRange(x, this.X + this.Width - halfW,
                    this.X + this.Width + halfW) ) 
                {
                    return true;
                }
            }

            if (isInRange(x, this.X, this.X + this.Width) )
            {
                if (isInRange(y, this.Y - halfW, this.Y + halfW))
                {
                    return true;
                }
                else if (isInRange(y, this.Y + this.Height - halfW,
                    this.Y + this.Height + halfW))
                {
                    return true;
                }
            }

            return false;

        }

        public override void updateEndPoint(int x, int y)
        {
            this.X += x - this.moveStartX;
            this.Y += y - this.moveStartY;
            this.moveStartX = x;
            this.moveStartY = y;
        }

    }
}
