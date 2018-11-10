using System;
using System.Drawing;
using System.Windows.Forms;
using DrawingToolkit.Canvas;
using DrawingToolkit.Toolbox;
using DrawingToolkit.Tools;

namespace DrawingToolkit
{
    public partial class DrawingFrame : Form
    {
        DrawingCanvas drawingCanvas;
        IToolbox drawingToolbox;
        public DrawingFrame()
        {
            // init drawing canvas
            InitializeComponent();
            drawingCanvas = new DrawingCanvas(new Point(50, 40), new Size(778, 386));
            drawingToolbox = new DrawingToolbox(drawingCanvas);

            this.Controls.Add(drawingCanvas);
            this.Controls.Add(drawingToolbox.GetToolbar());


        }

        private int getPenSize()
        {
            return (int)penSizeComboBox.Items[penSizeComboBox.SelectedIndex];
        }


        private Color getPenColor()
        {
            return this.btnPenColor.BackColor;
        }

        private void btnColorClick(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                this.btnPenColor.BackColor = c.Color;
                this.drawingCanvas.SetPenColor(c.Color);
            }
        }
        
        private void penSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            this.drawingCanvas.SetPenSize((int)cb.SelectedItem);
        }
    }
}
