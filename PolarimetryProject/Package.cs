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

        public Package(string folderPath)
        {
            Patterns = new List<Pattern>();
            string[] files = Directory.GetFiles(folderPath);
            foreach (string file in files)
                if (Path.GetFileName(file).ToLower().StartsWith("r") &&
                    Path.GetExtension(file).ToLower().Equals(".tif"))
                    Patterns.Add(new Pattern(file));
        }
    }
}
