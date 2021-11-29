using System;
using System.Drawing;

namespace PaintAppication
{
    class Triangle : Shape
    {
        int x2, y2, x3, y3;
        double a, b, c;

        public Triangle() : base()
        {

        }

        public Triangle(Color color, int x, int y, int x2, int y2, int x3, int y3) : base(color, x, y)
        {
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;
            this.a = Math.Sqrt((x2 - x) ^ 2 + (y2 - y) ^ 2);
            this.b = Math.Sqrt((x3 - x2) ^ 2 + (y3 - y2) ^ 2);
            this.c = Math.Sqrt((x - x3) ^ 2 + (y - y3) ^ 2);
        }

        public override void set(Color color, params int[] list)
        {
            this.x2 = list[1];
            this.y2 = list[2];
            this.x3 = list[3];
            this.y3 = list[4];
        }

        public override void draw(Graphics g)
        {
            Point[] points = new Point[3];
            points[0].X = this.x;
            points[0].Y = this.y;
            points[1].X = this.x2;
            points[1].Y = this.y2;
            points[2].X = this.x3;
            points[2].Y = this.y3;
            Pen p = new Pen(Color.Black, 2);
            SolidBrush b = new SolidBrush(color);
            g.FillPolygon(b, points);
            g.DrawPolygon(p, points);
        }

        public override double calcArea()
        {
            return (1 / 2) * Math.Abs(x * (y2 - y3) + x2 * (y3 - y) + x3 * (y - y2));
        }

        public override double calcPerimeter()
        {
            return a + b + c;
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.x2 + " " + this.y2 + " " + this.x3 + " " + this.y3;
        }
    }
}
