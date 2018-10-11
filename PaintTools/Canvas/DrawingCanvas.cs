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
        Graphics graphic;
        Bitmap background;//permanent
        Bitmap tmpBackground;//temporary
        bool isDrawing = false;
        bool isMoving = false;
        ToolMode mode = ToolMode.Drawing;
        Pen pen;
        private DrawingTool drawingTool;

        List<DrawingObject> drawingObjects = new List<DrawingObject>();
        DrawingObject movingObject = null;

        public void setDrawingTool(DrawingTool tool)
        {
            this.drawingTool = tool;
        }
        
        public void setPenColor(Color c)
        {
            this.pen.Color = c;
        }


        public void setPenSize(int size)
        {
            this.pen.Width = size;
        }

        public DrawingCanvas(Point location,Size size)
        {
            this.BackColor = Color.White;
            this.Location = location;
            this.Size = size;
            this.TabIndex = 1;
            background = new Bitmap(this.Width, this.Height);
            tmpBackground = new Bitmap(this.Width, this.Height);
            Graphics tmp = Graphics.FromImage(background);
            tmp.Clear(Color.White);
            tmp = Graphics.FromImage(tmpBackground);
            tmp.Clear(Color.White);
            pen = new Pen(Color.Black, 4);
          
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if(this.mode == ToolMode.Drawing)
            {
                isDrawing = true;
                this.drawingTool.onMouseDown(e.X, e.Y);
            }
            else if(this.mode == ToolMode.Moving)
            {
                int doSize = drawingObjects.Count;

                Debug.WriteLine("test dob");
                for (int i = doSize - 1; i > -1; --i)
                {
                    Debug.WriteLine("iterate : " + i);
                    if(drawingObjects[i].isClickedAt(e.X, e.Y))
                    {
                        this.isMoving = true;
                        this.movingObject = drawingObjects[i];
                        this.movingObject.setMoveStart(new Point(e.X, e.Y));
                        drawingObjects.RemoveAt(i);
                        Debug.WriteLine("catch dob");
                        break;
                    }
                }
                Graphics g = Graphics.FromImage(background);
                g.Clear(Color.White);


                foreach (DrawingObject dob in drawingObjects)
                {
                    dob.reDraw(g);
                }
                this.Invalidate();

            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            
            if(this.mode == ToolMode.Drawing)
            {
                isDrawing = false;
                Graphics g = Graphics.FromImage(background);
                drawingTool.onMouseUp(e.X, e.Y);

                DrawingObject drawingObject = drawingTool.getDrawingObject();
                drawingObjects.Add(drawingObject);
                drawingObject.draw(g, this.pen);
            }
            else if(this.mode == ToolMode.Moving)
            {
                isMoving = false;
                if (movingObject != null)
                {
                    movingObject.setMoveStop();
                    Graphics g = Graphics.FromImage(background);
                    movingObject.reDraw(g);
                    drawingObjects.Add(movingObject);
                    movingObject = null;
                    this.Invalidate();
                }
            }

        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            if(this.mode == ToolMode.Drawing)
            {
                if (this.isDrawing)
                {
                    drawingTool.onMouseMove(e.X, e.Y);
                    this.Invalidate();
                }
            }
            else if(this.mode == ToolMode.Moving)
            {
                if (this.isMoving)
                {
                    this.movingObject.updateEndPoint(new Point(e.X,e.Y));
                    this.Invalidate();
                }
            }


        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            this.tmpBackground = (Bitmap)this.background.Clone();
            this.graphic = Graphics.FromImage(this.tmpBackground);
            if (this.mode == ToolMode.Drawing)
            {
                drawingTool.getDrawingObject().draw(this.graphic, this.pen);
            }
            else if(this.mode == ToolMode.Moving && movingObject != null)
            {
                movingObject.drawAsMovingObject(this.graphic);
            }

            pevent.Graphics.DrawImage(this.tmpBackground, 0, 0);
        }

        public Control GetControl()
        {
            return this;
        }

        public void setToolMode(ToolMode toolMode)
        {
            this.mode = toolMode;
        }
    }
}
