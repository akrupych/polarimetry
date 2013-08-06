using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace PolarimetryProject
{
    class Pattern
    {
        private ImageMatrix ImageMatrix { get; set; }

        public string FileName { get; set; }

        public Image Image { get { return ImageMatrix.ToBitmap(); } }

        public int Width { get { return ImageMatrix.Columns; } }

        public int Height { get { return ImageMatrix.Rows; } }

        public Pattern(string filePath)
        {
            ImageMatrix = new ImageMatrix(filePath);
            FileName = Path.GetFileName(filePath);
        }
    }
}
