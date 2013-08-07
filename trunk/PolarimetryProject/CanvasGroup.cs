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
    class CanvasGroup : Panel
    {
        /// <summary>
        /// Double-buffered PictureBox
        /// </summary>
        private class ImageCanvas : PictureBox
        {
            public MyRectangle.Edge Profile { get; set; }
            public ImageCanvas() { DoubleBuffered = true; }
            public ImageCanvas(MyRectangle.Edge edge) : this() { Profile = edge; }
        }

        /// <summary>
        /// Main image is displayed here
        /// </summary>
        private ImageCanvas canvasImage = new ImageCanvas();

        // Profiles are showing actual image byte values of
        // four edges of selection rectangle
        private ImageCanvas canvasTopProfile = new ImageCanvas(MyRectangle.Edge.Top);
        private ImageCanvas canvasLeftProfile = new ImageCanvas(MyRectangle.Edge.Left);
        private ImageCanvas canvasRightProfile = new ImageCanvas(MyRectangle.Edge.Right);
        private ImageCanvas canvasBottomProfile = new ImageCanvas(MyRectangle.Edge.Bottom);

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
            canvasLeftProfile.Paint += new PaintEventHandler(canvasProfile_Paint);
            canvasTopProfile.Paint += new PaintEventHandler(canvasProfile_Paint);
            canvasRightProfile.Paint += new PaintEventHandler(canvasProfile_Paint);
            canvasBottomProfile.Paint += new PaintEventHandler(canvasProfile_Paint);
            // bind
            Controls.AddRange(new Control[] {
                canvasImage,
                canvasLeftProfile,
                canvasRightProfile,
                canvasTopProfile,
                canvasBottomProfile
            });
        }

        /// <summary>
        /// Canvas profiles will be painted here
        /// </summary>
        void canvasProfile_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            ImageCanvas canvas = sender as ImageCanvas;
            MyRectangle selection = Program.Package.Selection;
            byte[] profile = Program.Package.CurrentPattern
                .GetProfileFromSelectionEdge(canvas.Profile);
            Point[] graph = new Point[profile.Length];
            bool isRow = canvas.Profile == MyRectangle.Edge.Top ||
                canvas.Profile == MyRectangle.Edge.Bottom;
            for (int i = 0; i < graph.Length; i++)
                graph[i] = isRow ?
                    new Point(i /*+ selection.Left*/, range - profile[i] / 2) :
                    new Point(range - profile[i] / 2, i /*+ selection.Top*/);
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
