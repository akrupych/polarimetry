using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PolarimetryProject
{
    class MyRectangle
    {
        public int Top { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }

        public int Width { get { return Right - Left; } }
        public int Height { get { return Bottom - Top; } }

        public MyRectangle(int top, int left, int right, int bottom)
        {
            Top = top;
            Left = left;
            Right = right;
            Bottom = bottom;
        }

        public Rectangle ToRectangle()
        {
            return new Rectangle(Top, Bottom, Width, Height);
        }
    }
}
