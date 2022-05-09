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

            Dictionary<Line, bool> Extreme_Segments = new Dictionary<Line, bool>();
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = 0; j < points.Count; j++)
                {
                    if (points[i] == points[j])
                        continue;
                    Line line = new Line(points[i], points[j]);
                    Extreme_Segments.Add(line, true);
                }
            }
            foreach (KeyValuePair<Line, bool> seg in Extreme_Segments)
            {
                int cntr = 0;
                for (int pnt = 0; pnt < points.Count; pnt++)
                {
                    if (seg.Key.End != points[pnt] && seg.Key.Start != points[pnt])
                    {
                        if (HelperMethods.CheckTurn(seg.Key, points[pnt]) == Enums.TurnType.Right ||
                            HelperMethods.CheckTurn(seg.Key, points[pnt]) == Enums.TurnType.Colinear)
                            cntr++;
                    }
                }
                if (!(cntr == 0||cntr==points.Count))
                {
                    Extreme_Segments[seg.Key] = false;
                }
            }
            foreach(KeyValuePair<Line, bool> seg in Extreme_Segments)
            {
                if (seg.Value==true)
                    outLines.Add(seg.Key);
            }

        }


        public override string ToString()
        {
            return "Convex Hull - Extreme Segments";
        }
    }
}
