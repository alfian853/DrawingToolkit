using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.DrawingObjects
{
    public abstract class DrawingObject
    {
        abstract public void draw(Graphics g,Pen pen);
        abstract public void reDraw(Graphics g);
        abstract public void drawAsMovingObject(Graphics g);
        abstract public bool isClickedAt(int x, int y);
        abstract public void moveTo(int x, int y);
        protected Pen pen = new Pen(Color.Black,1);
        protected Point moveStart;
        protected bool isMoving;

        public void setPen(Pen pen)
        {
            this.pen.Color = pen.Color;
            this.pen.Width = pen.Width;
        }

        public void setMoveStop()
        {
            isMoving = false;
        }
       
        public void setMoveStart(Point point)
        {
            this.moveStart = point;
            this.isMoving = true;
        }
        public abstract void updateEndPoint(Point point);

        protected Pen getMovingDrawPen()
        {
            Pen pen2 = new Pen(
                Color.FromArgb((Math.Max((this.pen.Color.R + 80) % 255,90)),
                                this.pen.Color.G, this.pen.Color.B, 0
                               ),
               this.pen.Width + (int)Math.Max(4, pen.Width * 0.6)
            );
            pen2.Alignment = PenAlignment.Center;
            return pen2;
        }

    }
}
