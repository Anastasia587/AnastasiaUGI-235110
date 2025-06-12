using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLine
{
    public struct Line
    {
        public double A { get; }
        public double B { get; }

        private const double Epsilon = 1e-12;

        public Line(double a, double b)
        {
            if (double.IsNaN(a) || double.IsInfinity(a))
                throw new ArgumentException("Коэффициент A должен существовать");
            if (double.IsNaN(b) || double.IsInfinity(b))
                throw new ArgumentException("Коэффициент B должен существовать");

            A = a;
            B = b;
        }

        public double AngleInDegrees
        {
            get
            {
                double angleInRadians = Math.Atan(A);
                double angleInDegrees = angleInRadians * 180.0 / Math.PI;
                if (angleInDegrees <= -90 || angleInDegrees >= 90)
                    throw new InvalidOperationException("Угол должен быть строго в пределах (-90°, 90°)");
                return angleInDegrees;
            }
        }

        public override string ToString()
        {
            string aStr = A.ToString("G", System.Globalization.CultureInfo.InvariantCulture);
            string bStr = Math.Abs(B).ToString("G", System.Globalization.CultureInfo.InvariantCulture);
            string sign = B < 0 ? " - " : " + ";
            return $"y = {aStr}x{sign}{bStr}";
        }

        public bool Equals(Line other)
        {
            return Math.Abs(A - other.A) < Epsilon && Math.Abs(B - other.B) < Epsilon;
        }

        public override bool Equals(object obj)
        {
            return obj is Line other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + A.GetHashCode();
                hash = hash * 23 + B.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(Line x, Line y) => x.Equals(y);
        public static bool operator !=(Line x, Line y) => !x.Equals(y);

        public static Line operator ~(Line line)
        {
            if (Math.Abs(line.A) < Epsilon)
                throw new InvalidOperationException("Нельзя построить перпендикулярную прямую к горизонтальной прямой.");
            double newA = -1.0 / line.A;
            return new Line(newA, 0);
        }
    }
}
