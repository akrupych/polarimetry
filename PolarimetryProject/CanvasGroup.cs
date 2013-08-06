using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace PolarimetryProject
{
    class CanvasGroup : Panel
    {
        private class ImageCanvas : PictureBox
        {
            public ImageCanvas() { DoubleBuffered = true; }
        }

        private ImageCanvas canvasImage = new ImageCanvas();
        private ImageCanvas canvasTopProfile = new ImageCanvas();
        private ImageCanvas canvasLeftProfile = new ImageCanvas();
        private ImageCanvas canvasRightProfile = new ImageCanvas();
        private ImageCanvas canvasBottomProfile = new ImageCanvas();

        private const int margin = 4;
        private const int range = 128;

        public Image Image
        {
            set
            {
                canvasImage.Image = value;
                int width = Program.Package.CurrentPattern.Width;
                int height = Program.Package.CurrentPattern.Height;
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
                if (!canvasImage.Visible)
                {
                    canvasImage.Visible = canvasTopProfile.Visible = canvasLeftProfile.Visible =
                        canvasRightProfile.Visible = canvasBottomProfile.Visible = true;
                }
            }
        }

        public CanvasGroup()
        {
            canvasImage.BackColor = canvasLeftProfile.BackColor =
                canvasTopProfile.BackColor = canvasRightProfile.BackColor =
                canvasBottomProfile.BackColor = Color.White;
            canvasImage.Visible = canvasTopProfile.Visible = canvasLeftProfile.Visible =
                canvasRightProfile.Visible = canvasBottomProfile.Visible = false;
        }

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
