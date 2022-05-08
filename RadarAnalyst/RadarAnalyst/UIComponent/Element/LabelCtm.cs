using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarAnalyst.UIComponent.Element
{
    internal class LabelCtm : Label
    {
        private Color textColor = ColorTranslator.FromHtml("#7a8696");
        public LabelCtm()
        {
            ForeColor = textColor;
        }
    }
}
