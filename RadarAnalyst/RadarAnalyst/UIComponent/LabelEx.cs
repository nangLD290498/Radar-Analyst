using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarAnalyst.UIComponent
{
    internal class LabelEx : Label
    {
        private Color textColor = System.Drawing.ColorTranslator.FromHtml("#7a8696");
        public LabelEx()
        {
            this.ForeColor = textColor;
        }
    }
}
