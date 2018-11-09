using DrawingToolkit.DrawingStates;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DrawingToolkit.DrawingObjects
{
    public abstract class DrawingObject
    {
        abstract public void DrawPreview();
        abstract public void Draw();
        abstract public void DrawMoving();
        abstract public bool isClickedAt(int x, int y);
        protected Pen pen = new Pen(Color.Black, 4);
        protected int moveStartX;
        protected int moveStartY;
        protected bool isMoving;

        protected DrawingState drawingState;
        protected Graphics graphics;
        
        public DrawingObject(Pen pen){
            this.pen = pen;
            this.drawingState = PreviewState.GetInstance();
        }

        public virtual void Render()
        {
            this.drawingState.Draw(this);
        }

        public virtual void SetGraphic(Graphics g)
        {
            this.graphics = g;
        }
        

        public void setPen(Pen pen)
        {
            this.pen.Color = pen.Color;
            this.pen.Width = pen.Width;
        }

        public void setMoveStop()
        {
            isMoving = false;
        }
       
        public void setMoveStart(int x, int y)
        {
            this.moveStartX = x;
            this.moveStartY = y;
            this.isMoving = true;
        }
        public abstract void updateEndPoint(int x, int y);

        protected Pen getFocusPen(DashStyle dashStyle)
        {
            Pen pen2 = new Pen(
                Color.FromArgb((Math.Max((this.pen.Color.R + 80) % 255,90)),
                                this.pen.Color.G, this.pen.Color.B, 0
                               ),
               this.pen.Width
            );
            pen2.Alignment = PenAlignment.Center;
            pen2.DashStyle = dashStyle;
            return pen2;
        }

        public void SetState(DrawingState state)
        {
            this.drawingState = state;
        }

        public DrawingState GetState()
        {
            return this.drawingState;
        }

    }
}
