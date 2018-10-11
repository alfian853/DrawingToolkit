using System;
using System.Drawing;

namespace DrawingToolkit.DrawingObjects
{
    class DobCircle : DrawingObject
    {
        Rectangle circle;

        public DobCircle(Rectangle cirle)
        {
            this.circle = cirle;
        }

        public void setCircleFromRectangle(Rectangle rect)
        {
            this.circle = rect;
        }

        public override void reDraw(Graphics g)
        {
            g.DrawEllipse(this.pen, circle);
        }
        public override void draw(Graphics g, Pen pen)
        {
            this.setPen(pen);
            g.DrawEllipse(pen, circle);
        }

        public override bool isClickedAt(int x, int y)
        {
            float a = (float)this.circle.Width / 2;
            float b = (float)this.circle.Height / 2;
            int centerX = this.circle.X + this.circle.Width / 2;
            int centerY = this.circle.Y + this.circle.Height / 2;
            float ax = (float)Math.Pow(x-centerX,2);
            float by = (float)Math.Pow(y-centerY,2);
            ax /= (float)Math.Pow(a,2);
            by /= (float)Math.Pow(b,2);
            return Math.Abs(ax+by-1) <= 0.4;
        }

        public override void moveTo(int x, int y)
        {
            throw new NotImplementedException();
        }

        public override void updateEndPoint(Point point)
        {
            this.circle.X += point.X - this.moveStart.X;
            this.circle.Y += point.Y - this.moveStart.Y;
            this.moveStart = point;
        }

        public override void drawAsMovingObject(Graphics g)
        {
            g.DrawEllipse(this.getMovingDrawPen(), this.circle);
        }
    }
}
