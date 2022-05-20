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
        private TextBox tb_note { get; set; }

        private PointF point { get; set; }

        public GCKNudPair(NumericUpDown nudBeta, NumericUpDown nudAlpha, TextBox tbNote)
        {
            nud_beta = nudBeta;
            nud_alpha = nudAlpha;
            tb_note = tbNote;
        }

        public void setPoint(PointF point)
        {
            this.point = point;
        }

        public PointF getPoint()
        {
            return this.point;
        }

        public NumericUpDown getNudBeta()
        {
            return nud_beta;
        }

        public NumericUpDown getNudAlpha()
        {
            return nud_alpha;
        }
        public TextBox getTbNote()
        {
            return tb_note;
        }
    }
}
