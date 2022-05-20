using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarAnalyst.UIComponent.Class
{
    internal class GCKNudPair
    {
        private NumericUpDown nud_beta { get; set; }
        private NumericUpDown nud_alpha { get; set; }

        public GCKNudPair(NumericUpDown nudBeta, NumericUpDown nudAlpha)
        {
            nud_beta = nudBeta;
            nud_alpha = nudAlpha;
        }

        public NumericUpDown getNudBeta()
        {
            return nud_beta;
        }

        public NumericUpDown getNudAlpha()
        {
            return nud_alpha;
        }
    }
}
