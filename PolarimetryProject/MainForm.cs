using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PolarimetryProject
{
    public partial class MainForm : Form
    {
        private int DisplayedIndex { get; set; }

        public MainForm()
        {
            InitializeComponent();
            DisplayedIndex = -1;
        }

        private void menuButtonOpen_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Program.Package = new Package(dialog.SelectedPath);
                LocateCanvases();
                RefreshDisplay();
            }
        }

        private void LocateCanvases()
        {
            int width = Program.Package.CurrentPattern.Image.Width;
            int height = Program.Package.CurrentPattern.Image.Height;
            // resize all canvases to fit image and profiles
            canvasImage.Size = new Size(width, height);
            canvasTopProfile.Width = canvasBottomProfile.Width = width;
            canvasLeftProfile.Height = canvasRightProfile.Height = height;
            // move right and bottom profile canvases,
            // because image canvas in the center is resized
            canvasRightProfile.Location = new Point(
                canvasImage.Right + canvasImage.Margin.Right + canvasRightProfile.Margin.Left,
                canvasRightProfile.Location.Y);
            canvasBottomProfile.Location = new Point(
                canvasBottomProfile.Location.X,
                canvasImage.Bottom + canvasImage.Margin.Bottom + canvasRightProfile.Margin.Top);
        }

        private void menuButtonPrev_Click(object sender, EventArgs e)
        {
            Program.Package.CurrentIndex--;
            RefreshDisplay();
        }

        private void menuButtonNext_Click(object sender, EventArgs e)
        {
            Program.Package.CurrentIndex++;
            RefreshDisplay();
        }

        private void RefreshDisplay()
        {
            if (DisplayedIndex != Program.Package.CurrentIndex)
            {
                int index = Program.Package.CurrentIndex;
                int count = Program.Package.Patterns.Count;
                menuLabelPath.Text = Program.Package.CurrentPattern.FileName;
                menuLabelPosition.Text = string.Format("({0}/{1})", index + 1, count);
                menuButtonPrev.Enabled = index > 0;
                menuButtonNext.Enabled = index < Program.Package.Patterns.Count - 1;
                canvasImage.BackgroundImage = Program.Package.CurrentPattern.Image;
                DisplayedIndex = index;
            }
        }
    }
}
