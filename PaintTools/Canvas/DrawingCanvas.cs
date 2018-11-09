using DrawingToolkit.Canvas;
using DrawingToolkit.DrawingObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DrawingToolkit
{
    class DrawingCanvas : Control,ICanvas
    {
        Pen pen;
        private DrawingTool drawingTool;

        List<DrawingObject> drawingObjects = new List<DrawingObject>();

        public void SetDrawingTool(DrawingTool tool)
        {
            this.drawingTool = tool;
        }
        
        public void SetPenColor(Color c)
        {
            this.drawingTool.Pen.Color = c;
        }


        public void SetPenSize(int size)
        {
            this.drawingTool.Pen.Width = size;
        }

        public DrawingCanvas(Point location,Size size)
        {
            this.BackColor = Color.White;
            this.Location = location;
            this.Size = size;
            this.TabIndex = 1;
            this.DoubleBuffered = true;

            pen = new Pen(Color.Black, 4);
          
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if(this.drawingTool != null)
            {
                this.drawingTool.onMouseDown(e.X, e.Y);
                this.Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (this.drawingTool != null)
            {
                this.drawingTool.onMouseUp(e.X, e.Y);
                this.Invalidate();
            }
        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (this.drawingTool != null)
            {
                this.drawingTool.onMouseMove(e.X, e.Y);
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            foreach (DrawingObject obj in drawingObjects)
            {
                Debug.WriteLine("onPaint");
                obj.SetGraphic(pevent.Graphics);
                obj.Render();
            }
        }

        public Control GetControl()
        {
            return this;
        }

        public void SetToolMode(ToolMode toolMode)
        {
            
        }

        public DrawingObject GetDrawingObjectAt(int x, int y)
        {
            int doSize = drawingObjects.Count;
            
            for (int i = doSize - 1; i > -1; --i)
            {
                Debug.WriteLine("iterate : " + i);
                if (drawingObjects[i].isClickedAt(x,y))
                {
                    return drawingObjects[i];
                }
            }
            return null;
        }

        public void AddDrawingObject(DrawingObject drawingObject)
        {
            drawingObjects.Add(drawingObject);
        }
    }
}
