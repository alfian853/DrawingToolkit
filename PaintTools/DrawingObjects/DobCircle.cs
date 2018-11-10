using DrawingToolkit.DrawingStates;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DrawingToolkit.DrawingObjects
{
    public class DobCircle : DrawingObject, IConnectable
    {
        
        public int X;
        public int Y;
        public int Width;
        public int Height;
        private List<IConnector> observers;
        
        public DobCircle(int x, int y, int width, int height, Pen pen):base(pen)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.observers = new List<IConnector>();
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

        public override bool isClickedAt(int x, int y, bool innerClick)
        {
            float a = (float)this.Width / 2;
            float b = (float)this.Height / 2;
            int centerX = this.X + this.Width / 2;
            int centerY = this.Y + this.Height / 2;
            float ax = (float)Math.Pow(x-centerX,2);
            float by = (float)Math.Pow(y-centerY,2);
            ax /= (float)Math.Pow(a,2);
            by /= (float)Math.Pow(b,2);

            return (innerClick)?Math.Abs(ax+by) <= 1 : Math.Abs(ax+by-1) <= 0.4; 
        }
        
        public override void setMoveEnd(int x, int y)
        {
            this.X += x - this.moveStartX;
            this.Y += y - this.moveStartY;
            this.moveStartX = x;
            this.moveStartY = y;
            foreach (IConnector connector in observers)
            {
                connector.onObservedMove();
            }
        }

        public override void DrawMoving()
        {
            this.graphics.DrawEllipse(this.getFocusPen(DashStyle.Solid),
                this.X, this.Y, this.Width, this.Height
            );
        }

        public Point getOutlinePointFrom(int sX, int sY)
        {
            RectangleF rect = new RectangleF(this.X,this.Y,this.Width,this.Height);
            PointF pt1 = new PointF(sX,sY);

            float cx = rect.Left + rect.Width / 2f;
            float cy = rect.Top + rect.Height / 2f;
            PointF pt2 = new PointF(cx,cy);


            rect.X -= cx;
            rect.Y -= cy;
            pt1.X -= cx;
            pt1.Y -= cy;
            pt2.X -= cx;
            pt2.Y -= cy;

            // Get the semimajor and semiminor axes.
            float a = rect.Width / 2;
            float b = rect.Height / 2;

            // Calculate the quadratic parameters.
            float A = (pt2.X - pt1.X) * (pt2.X - pt1.X) / a / a +
                      (pt2.Y - pt1.Y) * (pt2.Y - pt1.Y) / b / b;
            float B = 2 * pt1.X * (pt2.X - pt1.X) / a / a +
                      2 * pt1.Y * (pt2.Y - pt1.Y) / b / b;
            float C = pt1.X * pt1.X / a / a + pt1.Y * pt1.Y / b / b - 1;

            // Make a list of t values.
            List<float> t_values = new List<float>();
            Point point = new Point();
            // Calculate the discriminant.
            float discriminant = B * B - 4 * A * C;
            float t = 0;
            if (discriminant == 0)
            {
                // One real solution.
                t = (-B / 2 / A);
            }
            else if (discriminant > 0)
            {
                // Two real solutions.
                //t_values.Add((float)((-B + Math.Sqrt(discriminant)) / 2 / A));
                t = (float)(-B - Math.Sqrt(discriminant)) / 2 / A;
            }
            int x = (int)(pt1.X + ((pt2.X - pt1.X) * t) + cx);
            int y = (int)(pt1.Y + ((pt2.Y - pt1.Y) * t) + cy);

            return new Point(x,y);
        }

        public override void SetState(DrawingState state)
        {
            base.SetState(state);
            if (state.GetType() == typeof(StaticState))
            {
                foreach (IConnector connector in observers)
                {
                    connector.onObservedStatic();
                }
            }
        }

        public void attach(IConnector observer)
        {
            this.observers.Add(observer);
        }



    }
}
