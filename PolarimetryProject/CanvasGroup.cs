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
            canvasImage.BackColor = canvasLeftProfile.BackColor =
                canvasTopProfile.BackColor = canvasRightProfile.BackColor =
                canvasBottomProfile.BackColor = Color.White;
            canvasImage.Size = canvasTopProfile.Size = canvasLeftProfile.Size =
                canvasRightProfile.Size = canvasBottomProfile.Size = new Size(0, 0);
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
