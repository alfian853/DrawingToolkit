﻿using System.Windows.Forms;
using DrawingToolkit.DrawingObjects;
using System.Drawing;
using DrawingToolkit.Tools;
using System;
using DrawingToolkit.Toolbox;

namespace DrawingToolkit
{
    public abstract class DrawingTool
    {
        protected Button toolButton = new Button();
        private Pen pen;
        protected IDrawingToolBox drawingToolBox;

        public Pen Pen { get => pen; set => pen = value; }

        public DrawingTool(IDrawingToolBox drawingToolBox, Point position, Size size)
        {
            this.drawingToolBox = drawingToolBox;
            this.toolButton.Size = size;
            this.toolButton.Location = position;
            this.toolButton.UseVisualStyleBackColor = true;
            this.toolButton.TabIndex = 5;
            toolButton.MouseClick += new MouseEventHandler(this.onClick);
            pen = new Pen(Color.Black, 4);
        }

        public void onClick(object sender, EventArgs e)
        {
            this.drawingToolBox.OnDrawingToolClick(this);
        }

        public Button GetButton()
        {
            return this.toolButton;
        }

        protected Pen getPenClone()
        {
            return (Pen)this.Pen.Clone();
        }

        public abstract void onMouseDown(int x ,int y);
        public abstract void onMouseUp(int x ,int y);
        public abstract void onMouseMove(int x ,int y);
    }
}
