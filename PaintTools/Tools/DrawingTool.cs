using System.Windows.Forms;
using DrawingToolkit.DrawingObjects;
using System.Drawing;
using DrawingToolkit.Tools;
using System;

namespace DrawingToolkit
{
    public abstract class DrawingTool
    {
        protected Button toolButton = new Button();
        IDrawingToolClickListener clickListener;
        public DrawingTool(IDrawingToolClickListener clickListener, Point position, Size size)
        {
            this.clickListener = clickListener;
            this.toolButton.Size = size;
            this.toolButton.Location = position;
            this.toolButton.UseVisualStyleBackColor = true;
            this.toolButton.TabIndex = 5;
            toolButton.MouseClick += new MouseEventHandler(this.onClick);
        }

        public void onClick(object sender, EventArgs e)
        {
            clickListener.OnDrawingToolClick(this);
        }

        public Button GetButton()
        {
            return this.toolButton;
        }

        public abstract void onMouseDown(int x ,int y);
        public abstract void onMouseUp(int x ,int y);
        public abstract void onMouseMove(int x ,int y);
        public abstract DrawingObject getDrawingObject();
        

    }
}
