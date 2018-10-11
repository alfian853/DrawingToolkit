using DrawingToolkit.DrawingObjects;
using DrawingToolkit.Tools;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DrawingToolkit.Toolbox
{
    class DrawingToolbox : IToolbox,IDrawingToolClickListener
    {
        private Panel toolbox = new Panel();
        DrawingTool rectTool;
        DrawingTool lineTool;
        DrawingTool circleTool;
        DrawingCanvas drawingCanvas;
        Button movingTool;


        public DrawingToolbox(DrawingCanvas drawingCanvas)
        {
            this.drawingCanvas = drawingCanvas;
            this.toolbox.Size = new Size(60,295);
            this.toolbox.Location = new Point(0,21);
            this.toolbox.BackColor = Color.Silver;

            rectTool = new RectangleTool(this, new Point(5, 55), new Size(40, 40));
            lineTool = new LineTool(this, new Point(5, 115), new Size(40, 40));
            circleTool = new CircleTool(this, new Point(5, 175), new Size(40, 40));
            movingTool = new Button();
            movingTool.Location = new Point(5,235);
            movingTool.Size = new Size(40 ,40);
            movingTool.Text = "M";

            this.drawingCanvas.setDrawingTool(rectTool);
            
            this.toolbox.Controls.Add(rectTool.GetButton());
            this.toolbox.Controls.Add(lineTool.GetButton());
            this.toolbox.Controls.Add(circleTool.GetButton());
            this.toolbox.Controls.Add(movingTool);

            movingTool.MouseClick += new MouseEventHandler(this.onMovingToolSelected);
        }

        public void onMovingToolSelected(object sender, EventArgs args)
        {
            drawingCanvas.setToolMode(Canvas.ToolMode.Moving);
        }

        public void OnDrawingToolClick(DrawingTool tool)
        {
            drawingCanvas.setToolMode(Canvas.ToolMode.Drawing);
            drawingCanvas.setDrawingTool(tool);
        }

        public Panel GetToolbar()
        {
            return this.toolbox;           
        }
        

        public Button GetToolButton()
        {
            throw new System.NotImplementedException();
        }

        public DrawingObject GetDrawingObject()
        {
            throw new System.NotImplementedException();
        }
        

        
    }
}
