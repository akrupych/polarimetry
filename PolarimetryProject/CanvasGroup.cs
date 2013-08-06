using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace PolarimetryProject
{
    /// <summary>
    /// Handles events of main image and profile canvases
    /// </summary>
    class CanvasGroup
    {
        /// <summary>
        /// Double-buffered PictureBox
        /// </summary>
        private class ImageCanvas : PictureBox
        {
            public ImageCanvas() { DoubleBuffered = true; }
        }

        /// <summary>
        /// Main image is displayed here
        /// </summary>
        private ImageCanvas canvasImage = new ImageCanvas();

        // Profiles are showing actual image byte values of
        // four edges of selection rectangle
        private ImageCanvas canvasTopProfile = new ImageCanvas();
        private ImageCanvas canvasLeftProfile = new ImageCanvas();
        private ImageCanvas canvasRightProfile = new ImageCanvas();
        private ImageCanvas canvasBottomProfile = new ImageCanvas();

        /// <summary>
        /// Distanse between canvases
        /// </summary>
        private const int margin = 4;
        /// <summary>
        /// Height of every profile plot
        /// </summary>
        private const int range = 128;

        /// <summary>
        /// Sets main image, resizes all canvases and shows profiles
        /// </summary>
        public Image Image
        {
            set
            {
                canvasImage.Image = value;
                int width = Program.Package.CurrentPattern.Width;
                int height = Program.Package.CurrentPattern.Height;
                // resize only when size is different
                if (canvasImage.Width != width || canvasImage.Height != height)
                {
                    // set sizes
                    canvasImage.Size = new Size(width, height);
                    canvasTopProfile.Width = canvasBottomProfile.Width = width;
                    canvasLeftProfile.Height = canvasRightProfile.Height = height;
                    canvasTopProfile.Height = canvasBottomProfile.Height =
                        canvasLeftProfile.Width = canvasRightProfile.Width = range;
                    // set locations
                    canvasTopProfile.Location = new Point(2 * margin + range, margin);
                    canvasLeftProfile.Location = new Point(margin, 2 * margin + range);
                    canvasImage.Location = new Point(
                        canvasLeftProfile.Right + margin,
                        canvasTopProfile.Bottom + margin);
                    canvasRightProfile.Location = new Point(
                        canvasImage.Right + margin, canvasImage.Top);
                    canvasBottomProfile.Location = new Point(
                        canvasImage.Left, canvasImage.Bottom + margin);
                }
            }
        }

        /// <summary>
        /// Sets canvases initial parameters
        /// </summary>
        public CanvasGroup()
        {
            // set view
            canvasImage.BackColor = canvasLeftProfile.BackColor =
                canvasTopProfile.BackColor = canvasRightProfile.BackColor =
                canvasBottomProfile.BackColor = Color.White;
            canvasImage.Size = canvasTopProfile.Size = canvasLeftProfile.Size =
                canvasRightProfile.Size = canvasBottomProfile.Size = new Size(0, 0);
            // set events
            canvasImage.Paint += new PaintEventHandler(canvasImage_Paint);
            canvasLeftProfile.Paint += new PaintEventHandler(canvasLeftProfile_Paint);
            canvasTopProfile.Paint += new PaintEventHandler(canvasTopProfile_Paint);
            canvasRightProfile.Paint += new PaintEventHandler(canvasRightProfile_Paint);
            canvasBottomProfile.Paint += new PaintEventHandler(canvasBottomProfile_Paint);
        }

        void canvasBottomProfile_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            byte[] profile = Program.Package.CurrentPattern.GetRowProfile(
                Program.Package.Selection.Bottom);
            Point[] graph = new Point[profile.Length];
            for (int i = 0; i < graph.Length; i++)
                graph[i] = new Point(i, range - profile[i] / 2);
            g.DrawLines(new Pen(Color.Blue), graph);
        }

        void canvasRightProfile_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            byte[] profile = Program.Package.CurrentPattern.GetColumnProfile(
                Program.Package.Selection.Right);
            Point[] graph = new Point[profile.Length];
            for (int i = 0; i < graph.Length; i++)
                graph[i] = new Point(profile[i] / 2, i);
            g.DrawLines(new Pen(Color.Blue), graph);
        }

        void canvasTopProfile_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            byte[] profile = Program.Package.CurrentPattern.GetRowProfile(
                Program.Package.Selection.Top);
            Point[] graph = new Point[profile.Length];
            for (int i = 0; i < graph.Length; i++)
                graph[i] = new Point(i, range - profile[i] / 2);
            g.DrawLines(new Pen(Color.Blue), graph);
        }

        void canvasLeftProfile_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            byte[] profile = Program.Package.CurrentPattern.GetColumnProfile(
                Program.Package.Selection.Left);
            Point[] graph = new Point[profile.Length];
            for (int i = 0; i < graph.Length; i++)
                graph[i] = new Point(profile[i] / 2, i);
            g.DrawLines(new Pen(Color.Blue), graph);
        }

        /// <summary>
        /// Main image will be painted here
        /// </summary>
        private void canvasImage_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawRectangle(new Pen(Color.Red), Program.Package.Selection.ToRectangle());
        }

        /// <summary>
        /// Adds canvases to a control collection
        /// </summary>
        /// <param name="controls">Control collection for canvases</param>
        public void Bind(Control.ControlCollection controls)
        {
            controls.AddRange(new Control[] {
                canvasImage,
                canvasLeftProfile,
                canvasRightProfile,
                canvasTopProfile,
                canvasBottomProfile
            });
        }
    }
}
