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
        private static Color violetColor = Color.Gray;

        private static Color _back = violetColor;
        private static Color _border = violetColor;
        private static Color _activeBorder = Color.Orange;
        private static Color _fore = Color.White;

        private static Padding _margin = new Padding(5, 0, 5, 0);
        private static Padding _padding = new Padding(3, 3, 3, 3);

        private static Size _minSize = new Size(100, 30);
        public bool is_active = false;
        public ButtonCtm(string text): base()
        {
            setBackColor(false);
            base.Font = _normalFont;           
            base.ForeColor = _fore;
            base.Text = text;
            FlatAppearance.BorderColor = _back;
            FlatStyle = FlatStyle.Flat;
            Margin = _margin;
            Padding = _padding;
            base.MinimumSize = _minSize;
        }

        public void setBackColor(bool is_active)
        {
            if (!is_active) base.BackColor = _border;
            else base.BackColor = _activeBorder;
            this.is_active = is_active;
        }
    }
}
