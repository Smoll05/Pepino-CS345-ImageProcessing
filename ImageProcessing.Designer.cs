namespace ImageProcessing
{
    partial class ImageProcessing
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            loadImageToolStripMenuItem = new ToolStripMenuItem();
            saveImageToolStripMenuItem = new ToolStripMenuItem();
            editImageToolStripMenuItem = new ToolStripMenuItem();
            copyStripMenuItem = new ToolStripMenuItem();
            greyscaleToolStripMenuItem = new ToolStripMenuItem();
            inverseToolStripMenuItem = new ToolStripMenuItem();
            histogramToolStripMenuItem = new ToolStripMenuItem();
            sepiaToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            splitContainer1 = new SplitContainer();
            flowLayoutPanel1 = new FlowLayoutPanel();
            originalImagePicture = new PictureBox();
            label1 = new Label();
            resultImagePanel = new FlowLayoutPanel();
            editedImagePicture = new PictureBox();
            label2 = new Label();
            intensityBarPanel = new Panel();
            label3 = new Label();
            intensityBar = new TrackBar();
            histogramPanel = new Panel();
            histogramPlot = new ScottPlot.WinForms.FormsPlot();
            label4 = new Label();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)originalImagePicture).BeginInit();
            resultImagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)editedImagePicture).BeginInit();
            intensityBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)intensityBar).BeginInit();
            histogramPanel.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { loadImageToolStripMenuItem, saveImageToolStripMenuItem, editImageToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1262, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // loadImageToolStripMenuItem
            // 
            loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            loadImageToolStripMenuItem.Size = new Size(102, 24);
            loadImageToolStripMenuItem.Text = "Load Image";
            loadImageToolStripMenuItem.Click += loadImageToolStripMenuItem_Click;
            // 
            // saveImageToolStripMenuItem
            // 
            saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            saveImageToolStripMenuItem.Size = new Size(100, 24);
            saveImageToolStripMenuItem.Text = "Save Image";
            saveImageToolStripMenuItem.Click += saveImageToolStripMenuItem_Click;
            // 
            // editImageToolStripMenuItem
            // 
            editImageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { copyStripMenuItem, greyscaleToolStripMenuItem, inverseToolStripMenuItem, histogramToolStripMenuItem, sepiaToolStripMenuItem });
            editImageToolStripMenuItem.Name = "editImageToolStripMenuItem";
            editImageToolStripMenuItem.Size = new Size(95, 24);
            editImageToolStripMenuItem.Text = "Edit Image";
            // 
            // copyStripMenuItem
            // 
            copyStripMenuItem.Name = "copyStripMenuItem";
            copyStripMenuItem.Size = new Size(162, 26);
            copyStripMenuItem.Text = "Copy";
            copyStripMenuItem.Click += copyStripMenuItem1_Click;
            copyStripMenuItem.Click += hideIntesnityBar_Click;
            copyStripMenuItem.Click += hideHistogramChart_Click;
            // 
            // greyscaleToolStripMenuItem
            // 
            greyscaleToolStripMenuItem.Name = "greyscaleToolStripMenuItem";
            greyscaleToolStripMenuItem.Size = new Size(162, 26);
            greyscaleToolStripMenuItem.Text = "Greyscale";
            greyscaleToolStripMenuItem.Click += greyscaleToolStripMenuItem_Click;
            greyscaleToolStripMenuItem.Click += showIntesnityBar_Click;
            greyscaleToolStripMenuItem.Click += hideHistogramChart_Click;
            // 
            // inverseToolStripMenuItem
            // 
            inverseToolStripMenuItem.Name = "inverseToolStripMenuItem";
            inverseToolStripMenuItem.Size = new Size(162, 26);
            inverseToolStripMenuItem.Text = "Inverse";
            inverseToolStripMenuItem.Click += inverseToolStripMenuItem_Click;
            inverseToolStripMenuItem.Click += hideIntesnityBar_Click;
            inverseToolStripMenuItem.Click += hideHistogramChart_Click;
            // 
            // histogramToolStripMenuItem
            // 
            histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            histogramToolStripMenuItem.Size = new Size(162, 26);
            histogramToolStripMenuItem.Text = "Histogram";
            histogramToolStripMenuItem.Click += histogramToolStripMenuItem_Click;
            histogramToolStripMenuItem.Click += hideIntesnityBar_Click;
            histogramToolStripMenuItem.Click += showHistogramChart_Click;
            // 
            // sepiaToolStripMenuItem
            // 
            sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            sepiaToolStripMenuItem.Size = new Size(162, 26);
            sepiaToolStripMenuItem.Text = "Sepia";
            sepiaToolStripMenuItem.Click += sepiaToolStripMenuItem_Click;
            sepiaToolStripMenuItem.Click += hideIntesnityBar_Click;
            sepiaToolStripMenuItem.Click += hideHistogramChart_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(splitContainer1);
            panel1.Location = new Point(18, 31);
            panel1.Name = "panel1";
            panel1.Size = new Size(1232, 526);
            panel1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(resultImagePanel);
            splitContainer1.Size = new Size(1232, 526);
            splitContainer1.SplitterDistance = 608;
            splitContainer1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(originalImagePicture);
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(608, 526);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // originalImagePicture
            // 
            originalImagePicture.Location = new Point(3, 3);
            originalImagePicture.Name = "originalImagePicture";
            originalImagePicture.Size = new Size(605, 484);
            originalImagePicture.TabIndex = 1;
            originalImagePicture.TabStop = false;
            // 
            // label1
            // 
            label1.Location = new Point(3, 490);
            label1.Name = "label1";
            label1.Size = new Size(602, 23);
            label1.TabIndex = 2;
            label1.Text = "Original Image";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // resultImagePanel
            // 
            resultImagePanel.Controls.Add(editedImagePicture);
            resultImagePanel.Controls.Add(label2);
            resultImagePanel.Dock = DockStyle.Fill;
            resultImagePanel.Location = new Point(0, 0);
            resultImagePanel.Name = "resultImagePanel";
            resultImagePanel.Size = new Size(620, 526);
            resultImagePanel.TabIndex = 1;
            // 
            // editedImagePicture
            // 
            editedImagePicture.Location = new Point(3, 3);
            editedImagePicture.Name = "editedImagePicture";
            editedImagePicture.Size = new Size(605, 484);
            editedImagePicture.TabIndex = 1;
            editedImagePicture.TabStop = false;
            // 
            // label2
            // 
            label2.Location = new Point(3, 490);
            label2.Name = "label2";
            label2.Size = new Size(605, 23);
            label2.TabIndex = 3;
            label2.Text = "Result Image";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // intensityBarPanel
            // 
            intensityBarPanel.Controls.Add(label3);
            intensityBarPanel.Controls.Add(intensityBar);
            intensityBarPanel.Location = new Point(20, 573);
            intensityBarPanel.Name = "intensityBarPanel";
            intensityBarPanel.Size = new Size(1230, 85);
            intensityBarPanel.TabIndex = 3;
            intensityBarPanel.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(159, 26);
            label3.Name = "label3";
            label3.Size = new Size(86, 28);
            label3.TabIndex = 1;
            label3.Text = "Intensity";
            // 
            // intensityBar
            // 
            intensityBar.BackColor = SystemColors.Control;
            intensityBar.Cursor = Cursors.Hand;
            intensityBar.LargeChange = 10;
            intensityBar.Location = new Point(275, 26);
            intensityBar.Maximum = 100;
            intensityBar.Name = "intensityBar";
            intensityBar.Size = new Size(833, 56);
            intensityBar.SmallChange = 10;
            intensityBar.TabIndex = 0;
            intensityBar.Tag = "";
            intensityBar.TickFrequency = 10;
            intensityBar.Value = 50;
            intensityBar.Scroll += intensityBar_Scroll;
            // 
            // histogramPanel
            // 
            histogramPanel.Controls.Add(histogramPlot);
            histogramPanel.Controls.Add(label4);
            histogramPanel.Location = new Point(633, 37);
            histogramPanel.Name = "histogramPanel";
            histogramPanel.Size = new Size(614, 517);
            histogramPanel.TabIndex = 4;
            histogramPanel.Visible = false;
            // 
            // histogramPlot
            // 
            histogramPlot.DisplayScale = 1.25F;
            histogramPlot.Location = new Point(7, 3);
            histogramPlot.Name = "histogramPlot";
            histogramPlot.Size = new Size(596, 478);
            histogramPlot.TabIndex = 4;
            // 
            // label4
            // 
            label4.Location = new Point(7, 484);
            label4.Name = "label4";
            label4.Size = new Size(602, 23);
            label4.TabIndex = 3;
            label4.Text = "Histogram";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ImageProcessing
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 673);
            Controls.Add(histogramPanel);
            Controls.Add(intensityBarPanel);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "ImageProcessing";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Image Processing";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)originalImagePicture).EndInit();
            resultImagePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)editedImagePicture).EndInit();
            intensityBarPanel.ResumeLayout(false);
            intensityBarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)intensityBar).EndInit();
            histogramPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem loadImageToolStripMenuItem;
        private ToolStripMenuItem saveImageToolStripMenuItem;
        private ToolStripMenuItem editImageToolStripMenuItem;
        private ToolStripMenuItem copyStripMenuItem;
        private ToolStripMenuItem greyscaleToolStripMenuItem;
        private ToolStripMenuItem inverseToolStripMenuItem;
        private ToolStripMenuItem histogramToolStripMenuItem;
        private ToolStripMenuItem sepiaToolStripMenuItem;
        private Panel panel1;
        private SplitContainer splitContainer1;
        private Panel intensityBarPanel;
        private FlowLayoutPanel flowLayoutPanel1;
        private PictureBox originalImagePicture;
        private FlowLayoutPanel resultImagePanel;
        private PictureBox editedImagePicture;
        private Label label1;
        private Label label2;
        private TrackBar intensityBar;
        private Label label3;
        private Panel histogramPanel;
        private ScottPlot.WinForms.FormsPlot histogramPlot;
        private Label label4;
    }
}
