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
            this.canvasGroup = new PolarimetryProject.CanvasGroup();
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
            this.toolStrip1.Size = new System.Drawing.Size(644, 25);
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
            // canvasGroup
            // 
            this.canvasGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvasGroup.Location = new System.Drawing.Point(0, 25);
            this.canvasGroup.Name = "canvasGroup";
            this.canvasGroup.Size = new System.Drawing.Size(644, 577);
            this.canvasGroup.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(644, 602);
            this.Controls.Add(this.canvasGroup);
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
        private CanvasGroup canvasGroup;

    }
}

