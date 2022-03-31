using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace RadarAnalyst.UIComponent
{
    public class MossieButton : Button
    {
        private static Font _normalFont = new Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        private static Color violetColor = System.Drawing.ColorTranslator.FromHtml("#9b51e0");

        private static Color _back = violetColor;
        private static Color _border = violetColor;
        private static Color _activeBorder = System.Drawing.Color.Orange;
        private static Color _fore = System.Drawing.Color.White;

        private static Padding _margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
        private static Padding _padding = new System.Windows.Forms.Padding(3, 3, 3, 3);

        private static Size _minSize = new System.Drawing.Size(100, 30);

        private bool _active;

        private String text;

        public MossieButton(String text)
            : base()
        {

            base.Paint += new PaintEventHandler((sender, e) => set_background(sender, e, text));

            base.Font = _normalFont;
            base.BackColor = _border;
            base.ForeColor = _fore;
            base.FlatAppearance.BorderColor = _back;
            base.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            base.Margin = _margin;
            base.Padding = _padding;
            base.MinimumSize = _minSize;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            UseVisualStyleBackColor = false;
        }

        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            if (!_active)
                base.FlatAppearance.BorderColor = _activeBorder;
        }

        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            if (!_active)
                base.FlatAppearance.BorderColor = _border;
        }

        public void SetStateActive()
        {
            _active = true;
            base.FlatAppearance.BorderColor = _activeBorder;
        }

        public void SetStateNormal()
        {
            _active = false;
            base.FlatAppearance.BorderColor = _border;
        }

        private void set_background(Object sender, PaintEventArgs e, String buttonName)
        {
            Graphics graphics = e.Graphics;

            //the rectangle, the same size as our Form
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);

            //define gradient's properties
            System.Drawing.Color col1 = System.Drawing.ColorTranslator.FromHtml("#e45735");
            System.Drawing.Color col2 = System.Drawing.ColorTranslator.FromHtml("#8814a9");
            Brush b = new LinearGradientBrush(gradient_rectangle, col1, col2, 65f);

            // Create a StringFormat object with the each line of text, and the block
            // of text centered on the page.
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            //apply gradient         
            graphics.FillRectangle(b, gradient_rectangle);
            using (Font font1 = new Font("MonoLisa", 11F, FontStyle.Bold, GraphicsUnit.Point))
            {
                e.Graphics.DrawString(buttonName, font1, Brushes.White, gradient_rectangle, stringFormat);
            }
        }

        GraphicsPath GetRoundPath(RectangleF Rect, int radius)
        {
            float r2 = radius / 2f;
            GraphicsPath GraphPath = new GraphicsPath();
            GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
            GraphPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y);
            GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
            GraphPath.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2);
            GraphPath.AddArc(Rect.X + Rect.Width - radius,
                             Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
            GraphPath.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height);
            GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
            GraphPath.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y + r2);
            GraphPath.CloseFigure();
            return GraphPath;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            RectangleF Rect = new RectangleF(0, 0, this.Width, this.Height);
            using (GraphicsPath GraphPath = GetRoundPath(Rect, 20))
            {
                this.Region = new Region(GraphPath);
                //using (Pen pen = new Pen(violetColor, 1.75f))
                //{
                //    pen.Alignment = PenAlignment.Inset;
                //    e.Graphics.DrawPath(pen, GraphPath);
                //}
            }
        }
    }
}
