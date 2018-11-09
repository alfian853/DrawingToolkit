using DrawingToolkit.DrawingObjects;
using DrawingToolkit.DrawingStates;
using DrawingToolkit.Toolbox;
using System.Drawing;

namespace DrawingToolkit.Tools
{

    class LineTool : DrawingTool
    {

        private DobLine lineObject;


        public LineTool(IDrawingToolBox drawingToolBox, Point position, Size size)
            : base(drawingToolBox, position, size)
        {
            this.toolButton.Name = "garis";
            this.toolButton.BackgroundImage = global::DrawingToolkit.Properties.Resources.line;
            this.toolButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }
        
        public override void onMouseDown(int x, int y)
        {
            lineObject = new DobLine(x, y, x, y, this.getPenClone());
            this.drawingToolBox.GetCanvas()
                .AddDrawingObject(this.lineObject);
        }

        public override void onMouseMove(int x, int y)
        {
            if(this.lineObject != null)
            {
                this.lineObject.eX = x;
                this.lineObject.eY = y;
            }
        }

        public override void onMouseUp(int x, int y)
        {
            this.lineObject.SetState(StaticState.GetInstance());
            lineObject = null;
        }
    }
}
