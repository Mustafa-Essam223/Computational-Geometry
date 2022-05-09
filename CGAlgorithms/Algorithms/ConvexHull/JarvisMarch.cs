using CGUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGAlgorithms.Algorithms.ConvexHull
{
    public class JarvisMarch : Algorithm
    {
        public double CrossProduct(Point A, Point B, Point C)
        {
            double Y1 = A.Y - B.Y;
            double Y2 = A.Y - C.Y;
            double X1 = A.X - B.X;
            double X2 = A.X - C.X;
            return Y2 * X1 - Y1 * X2;
        }
        public string OrientationTest(Point P1, Point P2, Point P3)
        {
            string[] result = { "Clockewise", "CounterClockwise", "Colinear" };
            if (CrossProduct(P1, P2, P3) == 0)
                return result[2];
            return CrossProduct(P1, P2, P3) > 0 ? result[0] : result[1];
        }

        public override void Run(List<Point> points, List<Line> lines, List<Polygon> polygons, ref List<Point> outPoints, ref List<Line> outLines, ref List<Polygon> outPolygons)
        {
            if (points.Count < 3)
                return;
            int left_point = 0;
            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].X < points[left_point].X)
                    left_point = i;
            }
            int p = left_point, q;
            do
            {
                outPoints.Add(points[p]);
                q = (p + 1) % points.Count;
                for (int i = 0; i < points.Count; i++)
                {
                    if (OrientationTest(points[p], points[i], points[q]) == "Clockewise")
                    {
                        q = i;
                    }
                }
                p = q;
            } while (p != left_point);

        }


        public override string ToString()
        {
            return "Convex Hull - Jarvis March";
        }
    }
}
