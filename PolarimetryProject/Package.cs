using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PolarimetryProject
{
    class Package
    {
        public List<Pattern> Patterns { get; private set; }

        public Pattern CurrentPattern { get { return Patterns[CurrentIndex]; } }

        public int CurrentIndex { get; set; }

        public MyRectangle Selection { get; set; }

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
                Selection = new MyRectangle(width / 4, height / 4, width * 3 / 4, height * 3 / 4);
            }
        }
    }
}
