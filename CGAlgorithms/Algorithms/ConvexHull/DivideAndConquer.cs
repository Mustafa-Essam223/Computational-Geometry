using CGUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGAlgorithms.Algorithms.ConvexHull
{
    public class DivideAndConquer : Algorithm
    {
        public int Quadrate(Point point)
        {
            if (point.X > 0 && point.Y > 0)
                return 1;
            else if (point.X < 0 && point.Y > 0)
                return 2;
            else if (point.X > 0 && point.Y < 0)
                return 3;
            else
                return 4;
        }
        public override void Run(List<Point> points, List<Line> lines, List<Polygon> polygons, ref List<Point> outPoints, ref List<Line> outLines, ref List<Polygon> outPolygons)
        {



        }

        public override string ToString()
        {
            return "Convex Hull - Divide & Conquer";
        }

    }
}
