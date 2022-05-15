using CGUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGAlgorithms.Algorithms.ConvexHull
{
    public class ExtremeSegments : Algorithm
    {

        public override void Run(List<Point> points, List<Line> lines, List<Polygon> polygons, ref List<Point> outPoints, ref List<Line> outLines, ref List<Polygon> outPolygons)
        {
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = i + 1; j < points.Count; j++)
                {
                    if (points[i].X == points[j].X && points[i].Y == points[j].Y)
                    {
                        points.RemoveAt(j);
                        j--;
                    }
                }
            }
            if (points.Count <= 2)
            {
                outPoints = points;
                return;
            }

            for (int i = 0; i < points.Count; i++)
            {
                int right_dir, left_dir, clinears;
                for (int j = i + 1; j < points.Count(); ++j)
                {
                    right_dir = left_dir = clinears = 0;
                    for (int pnt = 0; pnt < points.Count; ++pnt)
                    {
                        if (pnt == i || pnt == j)
                            continue;
                        if (HelperMethods.CheckTurn(new Line(points[i], points[j]), points[pnt])
                            == Enums.TurnType.Right)
                            right_dir++;
                        else if (HelperMethods.CheckTurn(new Line(points[i], points[j]), points[pnt])
                            == Enums.TurnType.Left)
                            left_dir++;
                        else clinears++;
                    }
                    if (right_dir == points.Count - 2 - clinears || left_dir == points.Count - 2 - clinears) //All points are in one side
                    {
                        Line extreme_seg = new Line(points[i], points[j]);
                        outLines.Add(extreme_seg);
                        if (!outPoints.Contains(points[i]))
                            outPoints.Add(points[i]);
                        if (!outPoints.Contains(points[j]))
                            outPoints.Add(points[j]);
                    }
                }
            }

        }







        public override string ToString()
        {
            return "Convex Hull - Extreme Segments";
        }
    }
}
