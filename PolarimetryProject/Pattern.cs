using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace PolarimetryProject
{
    /// <summary>
    /// Image for polarimetry
    /// </summary>
    class Pattern
    {
        /// <summary>
        /// Image raw data
        /// </summary>
        private ImageMatrix ImageMatrix { get; set; }
        /// <summary>
        /// Image name without path
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Gets pattern bitmap
        /// </summary>
        public Image Image { get { return ImageMatrix.ToBitmap(); } }
        /// <summary>
        /// Gets image width
        /// </summary>
        public int Width { get { return ImageMatrix.Columns; } }
        /// <summary>
        /// Gets image height
        /// </summary>
        public int Height { get { return ImageMatrix.Rows; } }

        /// <summary>
        /// Creates pattern from file
        /// </summary>
        /// <param name="filePath">Full path to the file</param>
        public Pattern(string filePath)
        {
            ImageMatrix = new ImageMatrix(filePath);
            FileName = Path.GetFileName(filePath);
        }
    }
}
