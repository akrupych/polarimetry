using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PolarimetryProject
{
    /// <summary>
    /// Contains all loaded patterns
    /// </summary>
    class Package
    {
        /// <summary>
        /// Gets patterns list
        /// </summary>
        public List<Pattern> Patterns { get; private set; }
        /// <summary>
        /// Gets currently selected pattern
        /// </summary>
        public Pattern CurrentPattern { get { return Patterns[CurrentIndex]; } }
        /// <summary>
        /// Gets or sets selected pattern index. You must perform boundary checking by yourself.
        /// </summary>
        public int CurrentIndex { get; set; }
        /// <summary>
        /// Selected area to perform calculations in
        /// </summary>
        public MyRectangle Selection { get; set; }

        /// <summary>
        /// Reads package from a folder with pattern images.
        /// Folder can contain any number of files.
        /// Every file with name like "R*.TIF" will be considered as pattern.
        /// However, for calculation purposes, folder must contain at least 3 pattern files.
        /// </summary>
        /// <param name="folderPath">Folder with patterns</param>
        public Package(string folderPath)
        {
            Patterns = new List<Pattern>();
            string[] files = Directory.GetFiles(folderPath);
            foreach (string file in files)
                if (Path.GetFileName(file).ToLower().StartsWith("r") &&
                    Path.GetExtension(file).ToLower().Equals(".tif"))
                    Patterns.Add(new Pattern(file));
            if (Patterns.Count > 0)
            {
                int width = Patterns[0].Width;
                int height = Patterns[0].Height;
                Selection = new MyRectangle(height / 4, width / 4, width * 3 / 4, height * 3 / 4);
            }
        }
    }
}
