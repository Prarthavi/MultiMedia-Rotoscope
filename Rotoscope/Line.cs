using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotoscope
{
    public class Line
    {
        public Point p1;
        public Point p2;
        public Line(Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }
    }
}
