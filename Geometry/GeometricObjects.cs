using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Figure
    {
        // Calculating the area of a figure without knowing its type.
        public static double GetFigureArea(IFigure figure)
        {
            return figure.GetArea();
        }
    }

    public interface IFigure
    {
        double GetArea();
    }

    public class Circle : IFigure
    {
        private double _radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius
        {
            get { return _radius; }
            set
            {
                if (value > 0)
                    _radius = value;
            }
        }

        public double GetArea()
        {
            double area = Math.PI * Math.Pow(Radius, 2);
            return area;
        }
    }

    public class Triangle : IFigure
    {
        private double _sideA;
        private double _sideB;
        private double _sideC;

        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public double SideA
        {
            get { return _sideA; }
            set
            {
                if (value > 0)
                    _sideA = value;
            }
        }
        public double SideB
        {
            get { return _sideB; }
            set
            {
                if (value > 0)
                    _sideB = value;
            }
        }
        public double SideC
        {
            get { return _sideC; }
            set
            {
                if (value > 0)
                    _sideC = value;
            }
        }

        public double GetArea()
        {
            if (!IsTriangleExists())
                return 0;

            double p = (SideA + SideB + SideC) / 2;
            double area = Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));

            return area;
        }

        public bool IsTriangleRight()
        {
            if (!IsTriangleExists())
                return false;

            double a, b, c;
            GetSidesComparison(out a, out b, out c);

            if (a * a == (b * b + c * c))
                return true;

            return false;
        }

        private bool IsTriangleExists()
        {
            double a, b, c;
            GetSidesComparison(out a, out b, out c);

            if ((b + c) > a)
                return true;

            return false;
        }

        private void GetSidesComparison(out double largeSide, out double smallerSide1, out double smallerSide2)
        {
            if (SideA >= SideB && SideA >= SideC)
            {
                largeSide = SideA;
                smallerSide1 = SideB;
                smallerSide2 = SideC;
            }
            else if (SideB >= SideA && SideB >= SideC)
            {
                largeSide = SideB;
                smallerSide1 = SideA;
                smallerSide2 = SideC;
            }
            else
            {
                largeSide = SideC;
                smallerSide1 = SideA;
                smallerSide2 = SideB;
            }
        }
    }
}
