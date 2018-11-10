using System;
using System.Windows.Forms;

namespace DrawingToolkit
{
    partial class DrawingFrame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.labelPenColor = new System.Windows.Forms.Label();
            this.btnPenColor = new System.Windows.Forms.Button();
            this.labelPenSize = new System.Windows.Forms.Label();
            this.penSizeComboBox = new System.Windows.Forms.ComboBox();
            this.panelToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelToolbar
            // 
            this.panelToolbar.Controls.Add(this.labelPenColor);
            this.panelToolbar.Controls.Add(this.btnPenColor);
            this.panelToolbar.Controls.Add(this.labelPenSize);
            this.panelToolbar.Controls.Add(this.penSizeComboBox);
            this.panelToolbar.Location = new System.Drawing.Point(1, 1);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Size = new System.Drawing.Size(798, 58);
            this.panelToolbar.TabIndex = 0;
            // 
            // labelPenColor
            // 
            this.labelPenColor.AutoSize = true;
            this.labelPenColor.Location = new System.Drawing.Point(94, 6);
            this.labelPenColor.Name = "labelPenColor";
            this.labelPenColor.Size = new System.Drawing.Size(31, 13);
            this.labelPenColor.TabIndex = 3;
            this.labelPenColor.Text = "Color";
            // 
            // btnPenColor
            // 
            this.btnPenColor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPenColor.Location = new System.Drawing.Point(71, 22);
            this.btnPenColor.Name = "btnPenColor";
            this.btnPenColor.Size = new System.Drawing.Size(75, 23);
            this.btnPenColor.TabIndex = 2;
            this.btnPenColor.UseVisualStyleBackColor = false;
            this.btnPenColor.Click += new System.EventHandler(this.btnColorClick);
            // 
            // labelPenSize
            // 
            this.labelPenSize.AutoSize = true;
            this.labelPenSize.Location = new System.Drawing.Point(11, 6);
            this.labelPenSize.Name = "labelPenSize";
            this.labelPenSize.Size = new System.Drawing.Size(49, 13);
            this.labelPenSize.TabIndex = 1;
            this.labelPenSize.Text = "Pen Size";
            // 
            // penSizeComboBox
            // 
            this.penSizeComboBox.FormattingEnabled = true;
            this.penSizeComboBox.Items.AddRange(new object[] {
            1,
            2,
            4,
            8});
            this.penSizeComboBox.Location = new System.Drawing.Point(14, 22);
            this.penSizeComboBox.Name = "penSizeComboBox";
            this.penSizeComboBox.Size = new System.Drawing.Size(37, 21);
            this.penSizeComboBox.TabIndex = 0;
            this.penSizeComboBox.Text = "4";
            this.penSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.penSizeComboBox_SelectedIndexChanged);
            // 
            // DrawingFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelToolbar);
            this.Name = "DrawingFrame";
            this.Text = "Form1";
            this.panelToolbar.ResumeLayout(false);
            this.panelToolbar.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Panel panelToolbar;
        private System.Windows.Forms.Label labelPenSize;
        private System.Windows.Forms.ComboBox penSizeComboBox;
        private Label labelPenColor;
        private Button btnPenColor;
    }
}

