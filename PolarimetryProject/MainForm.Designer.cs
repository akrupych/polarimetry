namespace PolarimetryProject
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.menuButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.menuLabelPath = new System.Windows.Forms.ToolStripLabel();
            this.menuLabelPosition = new System.Windows.Forms.ToolStripLabel();
            this.menuButtonPrev = new System.Windows.Forms.ToolStripButton();
            this.menuButtonNext = new System.Windows.Forms.ToolStripButton();
            this.canvasLeftProfile = new System.Windows.Forms.Panel();
            this.canvasRightProfile = new System.Windows.Forms.Panel();
            this.canvasImage = new System.Windows.Forms.Panel();
            this.canvasTopProfile = new System.Windows.Forms.Panel();
            this.canvasBottomProfile = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuButtonOpen,
            this.menuLabelPath,
            this.menuLabelPosition,
            this.menuButtonPrev,
            this.menuButtonNext});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(653, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // menuButtonOpen
            // 
            this.menuButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuButtonOpen.Image = ((System.Drawing.Image)(resources.GetObject("menuButtonOpen.Image")));
            this.menuButtonOpen.ImageTransparentColor = System.Drawing.Color.White;
            this.menuButtonOpen.Name = "menuButtonOpen";
            this.menuButtonOpen.Size = new System.Drawing.Size(23, 22);
            this.menuButtonOpen.Text = "Open Package...";
            this.menuButtonOpen.Click += new System.EventHandler(this.menuButtonOpen_Click);
            // 
            // menuLabelPath
            // 
            this.menuLabelPath.Name = "menuLabelPath";
            this.menuLabelPath.Size = new System.Drawing.Size(0, 22);
            // 
            // menuLabelPosition
            // 
            this.menuLabelPosition.Name = "menuLabelPosition";
            this.menuLabelPosition.Size = new System.Drawing.Size(0, 22);
            // 
            // menuButtonPrev
            // 
            this.menuButtonPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuButtonPrev.Enabled = false;
            this.menuButtonPrev.Image = ((System.Drawing.Image)(resources.GetObject("menuButtonPrev.Image")));
            this.menuButtonPrev.ImageTransparentColor = System.Drawing.Color.White;
            this.menuButtonPrev.Name = "menuButtonPrev";
            this.menuButtonPrev.Size = new System.Drawing.Size(23, 22);
            this.menuButtonPrev.Text = "Previous Image";
            this.menuButtonPrev.Click += new System.EventHandler(this.menuButtonPrev_Click);
            // 
            // menuButtonNext
            // 
            this.menuButtonNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuButtonNext.Enabled = false;
            this.menuButtonNext.Image = ((System.Drawing.Image)(resources.GetObject("menuButtonNext.Image")));
            this.menuButtonNext.ImageTransparentColor = System.Drawing.Color.White;
            this.menuButtonNext.Name = "menuButtonNext";
            this.menuButtonNext.Size = new System.Drawing.Size(23, 22);
            this.menuButtonNext.Text = "Next Image";
            this.menuButtonNext.Click += new System.EventHandler(this.menuButtonNext_Click);
            // 
            // canvasLeftProfile
            // 
            this.canvasLeftProfile.BackColor = System.Drawing.Color.White;
            this.canvasLeftProfile.Location = new System.Drawing.Point(12, 162);
            this.canvasLeftProfile.Name = "canvasLeftProfile";
            this.canvasLeftProfile.Size = new System.Drawing.Size(128, 300);
            this.canvasLeftProfile.TabIndex = 1;
            // 
            // canvasRightProfile
            // 
            this.canvasRightProfile.BackColor = System.Drawing.Color.White;
            this.canvasRightProfile.Location = new System.Drawing.Point(512, 162);
            this.canvasRightProfile.Name = "canvasRightProfile";
            this.canvasRightProfile.Size = new System.Drawing.Size(128, 300);
            this.canvasRightProfile.TabIndex = 2;
            // 
            // canvasImage
            // 
            this.canvasImage.BackColor = System.Drawing.Color.White;
            this.canvasImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.canvasImage.Location = new System.Drawing.Point(146, 162);
            this.canvasImage.Name = "canvasImage";
            this.canvasImage.Size = new System.Drawing.Size(360, 300);
            this.canvasImage.TabIndex = 2;
            // 
            // canvasTopProfile
            // 
            this.canvasTopProfile.BackColor = System.Drawing.Color.White;
            this.canvasTopProfile.Location = new System.Drawing.Point(146, 28);
            this.canvasTopProfile.Name = "canvasTopProfile";
            this.canvasTopProfile.Size = new System.Drawing.Size(360, 128);
            this.canvasTopProfile.TabIndex = 2;
            // 
            // canvasBottomProfile
            // 
            this.canvasBottomProfile.BackColor = System.Drawing.Color.White;
            this.canvasBottomProfile.Location = new System.Drawing.Point(146, 468);
            this.canvasBottomProfile.Name = "canvasBottomProfile";
            this.canvasBottomProfile.Size = new System.Drawing.Size(360, 128);
            this.canvasBottomProfile.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(653, 606);
            this.Controls.Add(this.canvasBottomProfile);
            this.Controls.Add(this.canvasTopProfile);
            this.Controls.Add(this.canvasImage);
            this.Controls.Add(this.canvasRightProfile);
            this.Controls.Add(this.canvasLeftProfile);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "Polarimetry";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton menuButtonOpen;
        private System.Windows.Forms.ToolStripLabel menuLabelPath;
        private System.Windows.Forms.ToolStripLabel menuLabelPosition;
        private System.Windows.Forms.ToolStripButton menuButtonPrev;
        private System.Windows.Forms.ToolStripButton menuButtonNext;
        private System.Windows.Forms.Panel canvasLeftProfile;
        private System.Windows.Forms.Panel canvasRightProfile;
        private System.Windows.Forms.Panel canvasImage;
        private System.Windows.Forms.Panel canvasTopProfile;
        private System.Windows.Forms.Panel canvasBottomProfile;

    }
}

