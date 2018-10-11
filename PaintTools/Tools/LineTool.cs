using DrawingToolkit.DrawingObjects;
using System.Drawing;

namespace DrawingToolkit.Tools
{

    class LineTool : DrawingTool
    {

        private Point start;
        private Point end;
        public LineTool(IDrawingToolClickListener clickListener,Point position, Size size)
            : base(clickListener,position, size)
        {
            start = new Point();
            end = new Point();
            this.toolButton.Name = "garis";
            this.toolButton.BackgroundImage = global::DrawingToolkit.Properties.Resources.line;
            this.toolButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }

        public override DrawingObject getDrawingObject()
        {
            return new DobLine(start,end);
        }

        public override void onMouseDown(int x, int y)
        {
            start.X = x;
            start.Y = y;
        }

        public override void onMouseMove(int x, int y)
        {
            end.X = x;
            end.Y = y;
        }

        public override void onMouseUp(int x, int y)
        {
            end.X = x;
            end.Y = y;
        }
    }
}
