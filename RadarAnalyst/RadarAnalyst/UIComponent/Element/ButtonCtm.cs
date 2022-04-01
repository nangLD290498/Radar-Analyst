using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace RadarAnalyst.UIComponent.Element
{
    public class ButtonCtm : Button
    {
        private static Font _normalFont = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
        private static Color violetColor = ColorTranslator.FromHtml("#9b51e0");

        private static Color _back = violetColor;
        private static Color _border = violetColor;
        private static Color _activeBorder = Color.Orange;
        private static Color _fore = Color.White;

        private static Padding _margin = new Padding(5, 0, 5, 0);
        private static Padding _padding = new Padding(3, 3, 3, 3);

        private static Size _minSize = new Size(100, 30);

        private bool _active;

        private string text;

        public ButtonCtm(string text)
            : base()
        {

            Paint += new PaintEventHandler((sender, e) => set_background(sender, e, text));

            base.Font = _normalFont;
            base.BackColor = _border;
            base.ForeColor = _fore;
            FlatAppearance.BorderColor = _back;
            FlatStyle = FlatStyle.Flat;
            Margin = _margin;
            Padding = _padding;
            base.MinimumSize = _minSize;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            UseVisualStyleBackColor = false;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (!_active)
                FlatAppearance.BorderColor = _activeBorder;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (!_active)
                FlatAppearance.BorderColor = _border;
        }

        public void SetStateActive()
        {
            _active = true;
            FlatAppearance.BorderColor = _activeBorder;
        }

        public void SetStateNormal()
        {
            _active = false;
            FlatAppearance.BorderColor = _border;
        }

        private void set_background(object sender, PaintEventArgs e, string buttonName)
        {
            Graphics graphics = e.Graphics;

            //the rectangle, the same size as our Form
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);

            //define gradient's properties
            Color col1 = ColorTranslator.FromHtml("#e45735");
            Color col2 = ColorTranslator.FromHtml("#8814a9");
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
            RectangleF Rect = new RectangleF(0, 0, Width, Height);
            using (GraphicsPath GraphPath = GetRoundPath(Rect, 20))
            {
                Region = new Region(GraphPath);
                //using (Pen pen = new Pen(violetColor, 1.75f))
                //{
                //    pen.Alignment = PenAlignment.Inset;
                //    e.Graphics.DrawPath(pen, GraphPath);
                //}
            }
        }
    }
}
