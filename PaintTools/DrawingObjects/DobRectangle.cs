using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DrawingToolkit.DrawingObjects
{
    class DobRectangle : DrawingObject
    {
        Rectangle rect;

        public DobRectangle(Rectangle rect)
        {
            this.rect = rect;
        }

        public void setRectangle(Rectangle rect)
        {
            this.rect = rect;
        }
        public override void drawAsMovingObject(Graphics g)
        {
            if (isMoving)
            {
                g.DrawRectangle(this.getMovingDrawPen(), this.rect);
            }
        }

        public override void reDraw(Graphics g)
        {
            g.DrawRectangle(this.pen, this.rect);
        }

        public override void draw(Graphics g, Pen pen)
        {
            this.setPen(pen);
            g.DrawRectangle(pen, this.rect);
        }

        bool isInRange(float a, float x, float x2)
        {
            return x <= a && a <= x2;
        }

        public override bool isClickedAt(int x, int y)
        {
            float halfW = this.pen.Width/2;
            if(isInRange(y, rect.Y, rect.Y + rect.Height) )
            {
                if(isInRange(x, rect.X - halfW, rect.X + halfW))
                {
                    return true;
                }
                else if (isInRange(x, rect.X + rect.Width - halfW,
                    rect.X + rect.Width + halfW) ) 
                {
                    return true;
                }
            }

            if (isInRange(x, rect.X, rect.X + rect.Width) )
            {
                if (isInRange(y, rect.Y - halfW, rect.Y + halfW))
                {
                    return true;
                }
                else if (isInRange(y, rect.Y + rect.Height - halfW,
                    rect.Y + rect.Height + halfW))
                {
                    return true;
                }
            }

            return false;

        }

        public override void moveTo(int x, int y)
        {
            throw new NotImplementedException();
        }

        public override void updateEndPoint(Point point)
        {
            this.rect.X += point.X - this.moveStart.X;
            this.rect.Y += point.Y - this.moveStart.Y;
            this.moveStart = point;
        }
    }
}
