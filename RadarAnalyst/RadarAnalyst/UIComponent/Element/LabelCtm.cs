using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarAnalyst.UIComponent.Element
{
    internal class LabelCtm : Label
    {
        private Color textColor = Color.Black;
        public LabelCtm()
        {
            ForeColor = textColor;
        }
    }
}
