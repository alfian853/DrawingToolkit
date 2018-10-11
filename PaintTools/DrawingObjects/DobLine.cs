using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.DrawingObjects
{
    class DobLine : DrawingObject
    {
        Point start;
        Point end;

        public DobLine(Point start, Point end)
        {
            this.start = start;
            this.end = end;
        }

        public void setLine(Point start, Point end)
        {
            this.start = start;
            this.end = end;
        }

        public override void drawAsMovingObject(Graphics g)
        {
            if (this.isMoving)
            {
                g.DrawLine(this.getMovingDrawPen(), start, end);
            }
        }
        public override void reDraw(Graphics g)
        {
            g.DrawLine(this.pen, start, end);
        }

        public override void draw(Graphics g, Pen pen)
        {
            this.setPen(pen);
            g.DrawLine(pen, start,end);
        }

        public override void moveTo(int x, int y)
        {
            throw new NotImplementedException();
        }

        public override bool isClickedAt(int x, int y)
        {
            float a = ((float)x - start.X) / (end.X - start.X);
            float b = ((float)y - start.Y) / (end.Y - start.Y);
            return Math.Abs(a-b) <= 0.05;
        }

        public override void updateEndPoint(Point point)
        {
            start.X -= this.moveStart.X - point.X;
            start.Y -= this.moveStart.Y - point.Y;
            end.X -= this.moveStart.X - point.X;
            end.Y -= this.moveStart.Y - point.Y;
            this.moveStart = point;
        }

    }
}
