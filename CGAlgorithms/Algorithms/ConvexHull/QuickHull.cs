using CGUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGAlgorithms.Algorithms.ConvexHull
{
    public class QuickHull : Algorithm
    {
        //public string FindSide(Point P1, Point P2, Point A)
        //{
        //    double Value = (A.Y - P1.Y) * (P2.X - P1.X) - (P2.Y - P1.Y) * (A.X - P1.X);
        //    if (Value == 0)
        //        return "On-Line";
        //    else return Value > 0 ? "Right" : "Left";
        //}
        public double LineDistance(Point P1, Point P2, Point A)
        {
            double Value = (A.Y - P1.Y) * (P2.X - P1.X) - (P2.Y - P1.Y) * (A.X - P1.X);
            return Math.Abs(Value);
        }


        public override void Run(List<Point> points, List<Line> lines, List<Polygon> polygons, ref List<Point> outPoints, ref List<Line> outLines, ref List<Polygon> outPolygons)
        {
           
        }

        public override string ToString()
        {
            return "Convex Hull - Quick Hull";
        }
    }
}
