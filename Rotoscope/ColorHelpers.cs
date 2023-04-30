using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Rotoscope
{
    public class ColorHelpers
    {
        //
        // Name :         ColorMultiply(double val, Color c)
        // Description :  Multiplys a scalar onto an Color.
        //
        public static Color ColorMultiply(double val, Color c, Color b)
        {
            //EQUATION
            return Color.FromArgb(
                    ClampColorElem((val * c.R) + ((1 - val) * b.R)),
                    ClampColorElem((val * c.R) + ((1 - val) * b.G)),
                    ClampColorElem((val * c.B) + ((1 - val) * b.B)));
        }

        //
        // Name :         ClampColorElem(double val)
        // Description :  Clamps a vales to be between 0 and 255.
        //
        public static int ClampColorElem(double val)
        {
            return (int)Math.Max(Math.Min(val, 255), 0);
        }
        public static int Clamp(double val)
        {
            return (int)Math.Max(Math.Min(val, 1), 0);
        }
        //
        // Name :         ColorAddColor(Color a, Color b)
        // Description :  Adds to colors together
        //
        public static Color ColorAdd(Color a, Color b)
        {
            return Color.FromArgb(
                    ClampColorElem(a.R + b.R),
                    ClampColorElem(a.G + b.G),
                    ClampColorElem(a.B + b.B));
        }
       
        //
        // Name :         ColorEqual(Color a, Color b)
        // Description :  Check if two colors are equal
        //
        public static bool ColorEqual(Color a, Color b)
        {
            return a.R == b.R && a.G == b.G && a.B == b.B;
        }

        // These functions are needed to simplify mins and maxes...
        public static double Min4(double a, double b, double c, double d)
        {
            double r = a;
            if (b < r)
                r = b;
            if (c < r)
                r = c;
            if (d < r)
                r = d;
            return r;
        }

        public static double Max4(double a, double b, double c, double d)
        {
            double r = a;
            if (b > r)
                r = b;
            if (c > r)
                r = c;
            if (d > r)
                r = d;
            return r;
        }

        public static Color ColorSubtract(Color a, Color b)
        {
            return Color.FromArgb(
         ClampColorElem(a.R - b.R),
         ClampColorElem( a.G - b.G),
         ClampColorElem(a.B - b.B));

        }

       
    }
}
