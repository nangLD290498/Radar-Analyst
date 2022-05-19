using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarAnalyst.UIComponent.Class
{
    internal class NudPair
    {
        private NumericUpDown nud_d { get; set; }
        private NumericUpDown nud_delta_h { get; set; }

        public NudPair(NumericUpDown nudD, NumericUpDown nudDeltaH)
        {
            nud_d = nudD;
            nud_delta_h = nudDeltaH;
        }

        public NumericUpDown getNudD()
        {
            return nud_d;
        }

        public NumericUpDown getNudDeltaH()
        {
            return nud_delta_h;
        }
    }
}
