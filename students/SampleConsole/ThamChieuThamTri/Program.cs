using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThamChieuThamTri
{
    public class Point
    {
        public decimal x;
        public decimal y;
    }
    class Program
    {
        static void call(Point point)
        {
            point.x++;
            point.y++;
        }

        static void call(ref decimal x, ref decimal y)
        {
            x++;
            y++;
        }
        static void Main(string[] args)
        {
            Point point = new Point();
            point.x = 1;
            point.y = 2;
            call(ref point.x,ref point.y);
            Console.WriteLine(string.Format("X: {0}, Y: {1}", point.x, point.y));
        }
    }
}
