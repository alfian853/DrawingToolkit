using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DrawingToolkit.DrawingObjects
{
    public class DobLine : DrawingObject
    {
        public int sX;
        public int sY;
        public int eX;
        public int eY;

        public DobLine(int sX,int sY, int eX, int eY, Pen pen) : base(pen)
        {
            this.sX = sX;
            this.sY = sY;
            this.eX = eX;
            this.eY = eY;
        }

        public override void DrawMoving()
        {
            this.graphics.DrawLine(this.getFocusPen(DashStyle.Solid), sX, sY, eX, eY);
        }
        public override void Draw()
        {
            this.graphics.DrawLine(this.pen, sX, sY, eX, eY);
        }

        public override void DrawPreview()
        {
            this.graphics.DrawLine(this.getFocusPen(DashStyle.Dot), sX, sY, eX, eY);
        }

        public override bool isClickedAt(int x, int y, bool innerClick)
        {
            float a = ((float)x - sX) / (eX - sX);
            float b = ((float)y - sY) / (eY - sY);
            return Math.Abs(a-b) <= 0.05;
        }

        public override void setMoveEnd(int x, int y)
        {
            sX -= this.moveStartX - x;
            sY -= this.moveStartY - y;
            eX -= this.moveStartX - x;
            eY -= this.moveStartY - y;
            this.moveStartX = x;
            this.moveStartY = y;
        }

    }
}
