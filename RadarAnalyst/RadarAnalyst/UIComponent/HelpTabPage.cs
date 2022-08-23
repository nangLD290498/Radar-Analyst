using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using RadarAnalyst.UIComponent.ComponentI;
using RadarAnalyst.UIComponent.Element;
using RadarAnalyst.UIComponent.Class;

namespace RadarAnalyst.UIComponent
{
    public partial class HelpTabPage : TabPage
    {
        private RichTextBox richTextBox1;

        public HelpTabPage(String text) : base(text)
        {
            Console.WriteLine("Init KTMPX Tab Page");
            this.Location = new System.Drawing.Point(4, 24);
            this.Name = Util.Constant.HELP.ToUpper();
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(1326, 633);
            this.TabIndex = 0;
            this.UseVisualStyleBackColor = true;
            this.SuspendLayout();
            // create layout
            initUI();
            this.Paint += new PaintEventHandler(set_background);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        protected void initUI()
        {

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox1.Location = new System.Drawing.Point(50, 25);
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(this.Width - 100, this.Height - 50);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.richTextBox1.ForeColor = System.Drawing.Color.Black;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            this.Controls.Add(this.richTextBox1);
        }

            protected void set_background(Object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            //the rectangle, the same size as our Form
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);

            //define gradient's properties
            System.Drawing.Color col = System.Drawing.Color.White;

            Brush b = new LinearGradientBrush(gradient_rectangle, col, col, 65f);

            //apply gradient         
            graphics.FillRectangle(b, gradient_rectangle);
        }
    }
}