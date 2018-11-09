using DrawingToolkit.Canvas;
using DrawingToolkit.Tools;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DrawingToolkit.Toolbox
{
    class DrawingToolbox : IDrawingToolBox
    {
        private Panel toolbox = new Panel();
        DrawingTool rectTool;
        DrawingTool lineTool;
        DrawingTool circleTool;
        DrawingCanvas drawingCanvas;
        DrawingTool selectTool;
        Pen activePen;

        public DrawingToolbox(DrawingCanvas drawingCanvas)
        {
            this.drawingCanvas = drawingCanvas;
            this.toolbox.Size = new Size(60,295);
            this.toolbox.Location = new Point(0,21);
            this.toolbox.BackColor = Color.Silver;
            this.activePen = new Pen(Color.Black, 4);
            rectTool = new RectangleTool(this, new Point(5, 55), new Size(40, 40));
            lineTool = new LineTool(this, new Point(5, 115), new Size(40, 40));
            circleTool = new CircleTool(this, new Point(5, 175), new Size(40, 40));
            this.selectTool = new SelectTool(this, new Point(5, 235), new Size(40, 40));
            
            this.toolbox.Controls.Add(rectTool.GetButton());
            this.toolbox.Controls.Add(lineTool.GetButton());
            this.toolbox.Controls.Add(circleTool.GetButton());
            this.toolbox.Controls.Add(selectTool.GetButton());
        }

        public void OnDrawingToolClick(DrawingTool tool)
        {
            tool.Pen = this.activePen;
            Debug.WriteLine("on drawing tool click");
            drawingCanvas.SetDrawingTool(tool);
        }

        public Panel GetToolbar()
        {
            return this.toolbox;           
        }

        public ICanvas GetCanvas()
        {
            return this.drawingCanvas;
        }
    }
}
