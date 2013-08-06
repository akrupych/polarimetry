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
        private int displayedIndex;

        private CanvasGroup canvasGroup = new CanvasGroup();

        public MainForm()
        {
            InitializeComponent();
            canvasGroup.Bind(Controls);
            // y:=c1+ c2*cos(2*(x-c3)*pi/180);
        }

        private void menuButtonOpen_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Program.Package = new Package(dialog.SelectedPath);
                displayedIndex = -1;
                RefreshDisplay();
            }
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
            if (displayedIndex != Program.Package.CurrentIndex)
            {
                int index = Program.Package.CurrentIndex;
                int count = Program.Package.Patterns.Count;
                menuLabelPath.Text = Program.Package.CurrentPattern.FileName;
                menuLabelPosition.Text = string.Format("({0}/{1})", index + 1, count);
                menuButtonPrev.Enabled = index > 0;
                menuButtonNext.Enabled = index < Program.Package.Patterns.Count - 1;
                canvasGroup.Image = Program.Package.CurrentPattern.Image;
                displayedIndex = index;
                Refresh();
            }
        }
    }
}
