using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadarAnalyst.UIComponent.Class
{
    internal class GCKPointNote
    {
        private PointF point { get; set; }
        private String note { get; set; }

        public GCKPointNote(PointF _point, String _note)
        {
            point = _point;
            note = _note;
        }

        public PointF getPoint()
        {
            return point;
        }

        public String getNote()
        {
            return note;
        }
    }
}
