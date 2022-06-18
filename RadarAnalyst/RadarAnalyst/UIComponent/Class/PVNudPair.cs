using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarAnalyst.UIComponent.Class
{
    internal class PVNudPair
    {
        private NumericUpDown nud_beta { get; set; }
        private NumericUpDown nud_alpha { get; set; }
        private NumericUpDown nud_h1 { get; set; }
        private NumericUpDown nud_h2 { get; set; }
        private NumericUpDown nud_h3 { get; set; }
        private PointF pointH1 { get; set; }
        private PointF pointH2 { get; set; }
        private PointF pointH3 { get; set; }
        private int numberOfCircleH1 { get; set; }
        private int numberOfCircleH2 { get; set; }
        private int numberOfCircleH3 { get; set; }

        private float radiusH1 { get; set; }
        private float radiusH2 { get; set; }
        private float radiusH3 { get; set; }

        public PVNudPair(NumericUpDown nudBeta, NumericUpDown nudAlpha, NumericUpDown nudH1, NumericUpDown nudH2, NumericUpDown nudH3)
        {
            nud_beta = nudBeta;
            nud_alpha = nudAlpha;
            nud_h1 = nudH1;
            nud_h2 = nudH2;
            nud_h3 = nudH3;
        }

        public void setRadiusH1(float radiusH1)
        {
            this.radiusH1 = radiusH1;
        }

        public float getRadiusH1()
        {
            return this.radiusH1;
        }
        public void setRadiusH2(float radiusH2)
        {
            this.radiusH2 = radiusH2;
        }

        public float getRadiusH2()
        {
            return this.radiusH2;
        }
        public void setRadiusH3(float radiusH3)
        {
            this.radiusH3 = radiusH3;
        }

        public float getRadiusH3()
        {
            return this.radiusH3;
        }

        public void setNumberOfCircleH1(int numberOfCircleH1)
        {
            this.numberOfCircleH1 = numberOfCircleH1;
        }

        public int getNumberOfCircleH1()
        {
            return this.numberOfCircleH1;
        }
        public void setNumberOfCircleH2(int numberOfCircleH2)
        {
            this.numberOfCircleH2 = numberOfCircleH2;
        }

        public int getNumberOfCircleH2()
        {
            return this.numberOfCircleH2;
        }
        public void setNumberOfCircleH3(int numberOfCircleH3)
        {
            this.numberOfCircleH3 = numberOfCircleH3;
        }
        public int getNumberOfCircleH3()
        {
            return this.numberOfCircleH3;
        }

        public void setPointH1(PointF pointH1)
        {
            this.pointH1 = pointH1;
        }

        public PointF getPointH1()
        {
            return this.pointH1;
        }

        public void setPointH2(PointF pointH2)
        {
            this.pointH2 = pointH2;
        }

        public PointF getPointH2()
        {
            return this.pointH2;
        }
        public void setPointH3(PointF pointH3)
        {
            this.pointH3 = pointH3;
        }
        public PointF getPointH3()
        {
            return this.pointH3;
        }

        public NumericUpDown getNudBeta()
        {
            return nud_beta;
        }

        public NumericUpDown getNudAlpha()
        {
            return nud_alpha;
        }

        public NumericUpDown getNudH1()
        {
            return nud_h1;
        }

        public NumericUpDown getNudH2()
        {
            return nud_h2;
        }

        public NumericUpDown getNudH3()
        {
            return nud_h3;
        }
    }
}
