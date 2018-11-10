using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using DrawingToolkit.DrawingStates;

namespace DrawingToolkit.DrawingObjects
{
    public class DobRectangle : DrawingObject,IConnectable
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;
        private List<IConnector> observers;

        public DobRectangle(int x,int y, int width, int height, Pen pen) : base(pen)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.observers = new List<IConnector>();
        }

        public override void DrawMoving()
        {
            this.graphics.DrawRectangle(this.getFocusPen(DashStyle.Solid),
                this.X, this.Y, this.Width, this.Height
            );
        }

        public override void Draw()
        {
            this.graphics.DrawRectangle(this.pen,
                this.X, this.Y, this.Width, this.Height
            );
        }

        public override void DrawPreview()
        {

            this.graphics.DrawRectangle(this.getFocusPen(DashStyle.DashDot),
                this.X, this.Y, this.Width, this.Height
            );
        }

        bool isInRange(float a, float x, float x2)
        {
            return x <= a && a <= x2;
        }

        bool isInbox(Point point)
        {
            return isInRange(point.X, this.X, this.X + this.Width) &&
                isInRange(point.Y, this.Y, this.Y + this.Height);
        }

        public override bool isClickedAt(int x, int y, bool innerClick)
        {

            if (innerClick)
            {
                return isInRange(x, this.X, this.X + this.Width) &&
                    isInRange(y, this.Y, this.Y + this.Height);

            }
            else
            {
                float halfW = this.pen.Width / 2;
                if (isInRange(y, this.Y, this.Y + this.Height))
                {
                    if (isInRange(x, this.X - halfW, this.X + halfW))
                    {
                        return true;
                    }
                    else if (isInRange(x, this.X + this.Width - halfW,
                        this.X + this.Width + halfW))
                    {
                        return true;
                    }
                }

                if (isInRange(x, this.X, this.X + this.Width))
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



        }

        public override void setMoveEnd(int x, int y)
        {
            this.X += x - this.moveStartX;
            this.Y += y - this.moveStartY;
            this.moveStartX = x;
            this.moveStartY = y;
            foreach(IConnector connector in observers)
            {
                connector.onObservedMove();
            }
        }
        public void attach(IConnector observer)
        {
            this.observers.Add(observer);
        }

        public override void SetState(DrawingState state)
        {
            base.SetState(state);
            if(state.GetType() == typeof(StaticState))
            {
                foreach (IConnector connector in observers)
                {
                    connector.onObservedStatic();
                }
            }
        }

        class LineSegment
        {
            public int x1, x2, y1, y2;
            public LineSegment(int x1,int y1,int x2,int y2)
            {
                this.x1 = x1;
                this.y1 = y1;
                this.x2 = x2;
                this.y2 = y2;
            }
        }
        private Point getIntersectPoint(LineSegment l1, LineSegment l2)
        {
            float A1 = l1.y2 - l1.y1;
            float B1 = l1.x1 - l1.x2;
            float C1 = A1 * l1.x1 + B1 * l1.y1;

            float A2 = l2.y2 - l2.y1;
            float B2 = l2.x1 - l2.x2;
            float C2 = A2 * l2.x1 + B2 * l2.y1;


            float delta = A1 * B2 - A2 * B1;

            if (delta == 0)
            {
                // line are paralel
                Debug.WriteLine("gagal");
                return new Point(-1,-1);
            }

            float x = (B2 * C1 - B1 * C2) / delta;
            float y = (A1 * C2 - A2 * C1) / delta;
            Point ret = new Point((int)x, (int)y);
            
            return (this.isInbox(ret))?ret : new Point(-1,-1);
        }

        private float euclideanDistance(float x1,float y1, float x2, float y2)
        {
            return (float)Math.Sqrt( Math.Pow(x1-x2,2) + Math.Pow(y1-y2,2) );
        }


        public Point getOutlinePointFrom(int sX, int sY)
        {
            int midX = this.X + (this.Width/2);
            int midY = this.Y + (this.Height/2);
            LineSegment line1 = new LineSegment(sX, sY, midX, midY);
            float closest = 999999999;
            Point intersection = new Point();
            Point res = new Point();

            if (sX  < this.X)
            {
                intersection = this.getIntersectPoint(line1,
                    // left
                    new LineSegment(this.X, this.Y, this.X, this.Y + this.Height)
                );
                if(intersection.X != -1 && this.euclideanDistance(
                    sX,sY,intersection.X, intersection.Y
                    ) < closest )
                {
                    res = intersection;
                }
            }
            else
            {
                intersection = this.getIntersectPoint(line1,
                    // right
                    new LineSegment(this.X + Width, this.Y, this.X + this.Width, this.Y + this.Height)
                );
                if (intersection.X != -1 && this.euclideanDistance(
                    sX, sY, intersection.X, intersection.Y
                    ) < closest)
                {
                    res = intersection;
                }

            }

            if (sY > this.Y)
            {
                intersection = this.getIntersectPoint(line1,
                    // bottom
                    new LineSegment(this.X, this.Y + this.Height, this.X + Width, this.Y + this.Height)
                );
                if (intersection.X != -1 && this.euclideanDistance(
                    sX, sY, intersection.X, intersection.Y
                    ) < closest)
                {
                    res = intersection;
                }
            }
            else
            {
                intersection = this.getIntersectPoint(line1,
                    // top
                    new LineSegment(this.X, this.Y, this.X + this.Width, this.Y)
                );
                if (intersection.X != -1 && this.euclideanDistance(
                    sX, sY, intersection.X, intersection.Y
                    ) < closest)
                {
                    res = intersection;
                }
            }

            return res;
        }

    }
}
