using System;
using System.Drawing;

namespace Library
{
    public class MyVector
    {
        public  PointF Start { get; }
        public PointF End { get; }
        public float Length
        {
            get
            {
                return (float)Math.Sqrt(Math.Pow(ProjX, 2) + Math.Pow(ProjY, 2));
            }
        }
        // проекция на ось Х
        public float ProjX
        {
            get
            {
                return End.X - Start.X;
            }
        }
        // проекция на ось У
        public float ProjY
        {
            get
            {
                return End.Y - Start.Y;
            }
        }
        public MyVector(PointF start, PointF end)
        {
            Start = start;
            End = end;
        }
        public MyVector(PointF end)
        {
            Start = new PointF(0,0);
            End = end;
        }

        public static MyVector operator -(MyVector a, MyVector b)
        {
            var end = new PointF(a.End.X - b.ProjX, a.End.Y - b.ProjY);
            return new MyVector(a.Start, end);
        }
        public static MyVector operator+(MyVector a, MyVector b)
        {
            var end = new PointF(a.End.X + b.ProjX, a.End.Y + b.ProjY);
            return new MyVector(a.Start, end);
        }
        public static MyVector operator*(MyVector a, float b)
        {
            var end = new PointF(a.Start.X + a.ProjX * b, a.Start.Y + a.ProjY * b);
            return new MyVector(a.Start, end);
        }
        public override string ToString()
        {
            return $"(X,Y) - Start = ({Start.X},{Start.Y})\n(X,Y) - End = ({End.X},{End.Y})\nLength = {Length}";
        }


    }
}
