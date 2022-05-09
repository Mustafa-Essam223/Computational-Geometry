using CGUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGAlgorithms.Algorithms.ConvexHull
{
    public class ExtremePoints : Algorithm
    {
        public override void Run(List<Point> points, List<Line> lines, List<Polygon> polygons, ref List<Point> outPoints, ref List<Line> outLines, ref List<Polygon> outPolygons)
        {
            Dictionary<Point, bool> Extreme_Points = new Dictionary<Point, bool>();

            for (int i = 0; i < points.Count; i++)
            {
                Point p = points[i];
                Extreme_Points.Add(p, true);
            }

            for (int i = 0; i < points.Count; i++)
            {
                for (int j = 0; j < points.Count; j++)
                {
                    for (int k = 0; k < points.Count; k++)
                    {
                        if (points[i] != points[j] && points[i] != points[k] && points[j] != points[k])
                        {
                            for (int pnt = 0; pnt < points.Count; pnt++)
                            {
                                if (points[pnt] != points[j] && points[pnt] != points[i] && points[pnt] != points[k])
                                {
                                    if (HelperMethods.PointInTriangle(points[pnt], points[i], points[j], points[k])
                                         == Enums.PointInPolygon.Inside ||
                                        HelperMethods.PointInTriangle(points[pnt], points[i], points[j], points[k])
                                         == Enums.PointInPolygon.OnEdge)
                                    {
                                        Extreme_Points[points[pnt]] = false;
                                    }
                                }
                            }//pnt
                        }
                    }
                }
            }

            for (int i = 0; i < points.Count; i++)
            {
                if (Extreme_Points[points[i]] == true)
                    outPoints.Add(points[i]);
            }

        }

        public override string ToString()
        {
            return "Convex Hull - Extreme Points";
        }
    }
}
