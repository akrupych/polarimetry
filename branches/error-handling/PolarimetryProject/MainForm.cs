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
    /// <summary>
    /// Main application form with action menu, main image and profiles
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Currently displayed image
        /// </summary>
        private int displayedIndex;
        /// <summary>
        /// Main image with profiles
        /// </summary>
        //private CanvasGroup canvasGroup = new CanvasGroup();

        /// <summary>
        /// Initializes all the controls
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            //canvasGroup.Bind(Controls);
            // y:=c1+ c2*cos(2*(x-c3)*pi/180);
        }

        /// <summary>
        /// User pressed on Open Package button
        /// </summary>
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

        /// <summary>
        /// User pressed on Previous Image button
        /// </summary>
        private void menuButtonPrev_Click(object sender, EventArgs e)
        {
            Program.Package.CurrentIndex--;
            RefreshDisplay();
        }

        /// <summary>
        /// User pressed on Next Image button
        /// </summary>
        private void menuButtonNext_Click(object sender, EventArgs e)
        {
            Program.Package.CurrentIndex++;
            RefreshDisplay();
        }

        /// <summary>
        /// Refreshes all control values after the image was changed
        /// </summary>
        private void RefreshDisplay()
        {
            // check if image was changed
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
