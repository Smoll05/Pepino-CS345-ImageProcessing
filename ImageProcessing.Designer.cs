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
            loadOriginalToolStripMenuItem = new ToolStripMenuItem();
            loadBackgroundToolStripMenuItem = new ToolStripMenuItem();
            saveImageToolStripMenuItem = new ToolStripMenuItem();
            editImageToolStripMenuItem = new ToolStripMenuItem();
            copyStripMenuItem = new ToolStripMenuItem();
            greyscaleToolStripMenuItem = new ToolStripMenuItem();
            inverseToolStripMenuItem = new ToolStripMenuItem();
            histogramToolStripMenuItem = new ToolStripMenuItem();
            sepiaToolStripMenuItem = new ToolStripMenuItem();
            subtractImageToolStripMenuItem = new ToolStripMenuItem();
            toolToolStripMenuItem = new ToolStripMenuItem();
            normalEditToolStripMenuItem = new ToolStripMenuItem();
            subtractEditToolStripMenuItem = new ToolStripMenuItem();
            webcamSubtractToolStripMenuItem = new ToolStripMenuItem();
            imagePanel1 = new Panel();
            splitContainer1 = new SplitContainer();
            flowLayoutPanel1 = new FlowLayoutPanel();
            originalImagePicture = new PictureBox();
            label1 = new Label();
            histogramPanel = new Panel();
            histogramPlot = new ScottPlot.WinForms.FormsPlot();
            label4 = new Label();
            resultImagePanel = new FlowLayoutPanel();
            editedImagePicture = new PictureBox();
            label2 = new Label();
            intensityBarPanel = new Panel();
            label3 = new Label();
            intensityBar = new TrackBar();
            mainPanel = new Panel();
            subPanel3 = new Panel();
            cameraButton = new Button();
            webcamDisplay = new PictureBox();
            label8 = new Label();
            subPanel2 = new Panel();
            subtractImagePicture = new PictureBox();
            label5 = new Label();
            subtractBackgroundPicture = new PictureBox();
            label7 = new Label();
            subtractResultPicture = new PictureBox();
            label6 = new Label();
            subPanel1 = new Panel();
            subtractToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            imagePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)originalImagePicture).BeginInit();
            histogramPanel.SuspendLayout();
            resultImagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)editedImagePicture).BeginInit();
            intensityBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)intensityBar).BeginInit();
            mainPanel.SuspendLayout();
            subPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webcamDisplay).BeginInit();
            subPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)subtractImagePicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)subtractBackgroundPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)subtractResultPicture).BeginInit();
            subPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { loadImageToolStripMenuItem, saveImageToolStripMenuItem, editImageToolStripMenuItem, subtractImageToolStripMenuItem, toolToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1262, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // loadImageToolStripMenuItem
            // 
            loadImageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadOriginalToolStripMenuItem, loadBackgroundToolStripMenuItem });
            loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            loadImageToolStripMenuItem.Size = new Size(102, 24);
            loadImageToolStripMenuItem.Text = "Load Image";
            loadImageToolStripMenuItem.Click += loadImageToolStripMenuItem_Click;
            // 
            // loadOriginalToolStripMenuItem
            // 
            loadOriginalToolStripMenuItem.Name = "loadOriginalToolStripMenuItem";
            loadOriginalToolStripMenuItem.Size = new Size(171, 26);
            loadOriginalToolStripMenuItem.Text = "Image";
            loadOriginalToolStripMenuItem.Visible = false;
            loadOriginalToolStripMenuItem.Click += loadOriginalToolStripMenuItem_Click;
            // 
            // loadBackgroundToolStripMenuItem
            // 
            loadBackgroundToolStripMenuItem.Name = "loadBackgroundToolStripMenuItem";
            loadBackgroundToolStripMenuItem.Size = new Size(171, 26);
            loadBackgroundToolStripMenuItem.Text = "Background";
            loadBackgroundToolStripMenuItem.Visible = false;
            loadBackgroundToolStripMenuItem.Click += loadBackgroundToolStripMenuItem_Click;
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
            editImageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { copyStripMenuItem, greyscaleToolStripMenuItem, inverseToolStripMenuItem, histogramToolStripMenuItem, sepiaToolStripMenuItem, subtractToolStripMenuItem });
            editImageToolStripMenuItem.Name = "editImageToolStripMenuItem";
            editImageToolStripMenuItem.Size = new Size(95, 24);
            editImageToolStripMenuItem.Text = "Edit Image";
            // 
            // copyStripMenuItem
            // 
            copyStripMenuItem.Name = "copyStripMenuItem";
            copyStripMenuItem.Size = new Size(162, 26);
            copyStripMenuItem.Text = "Copy";
            copyStripMenuItem.Click += hideIntesnityBar_Click;
            copyStripMenuItem.Click += copyStripMenuItem_Click;
            // 
            // greyscaleToolStripMenuItem
            // 
            greyscaleToolStripMenuItem.Name = "greyscaleToolStripMenuItem";
            greyscaleToolStripMenuItem.Size = new Size(162, 26);
            greyscaleToolStripMenuItem.Text = "Greyscale";
            greyscaleToolStripMenuItem.Click += showIntesnityBar_Click;
            greyscaleToolStripMenuItem.Click += greyscaleToolStripMenuItem_Click;
            // 
            // inverseToolStripMenuItem
            // 
            inverseToolStripMenuItem.Name = "inverseToolStripMenuItem";
            inverseToolStripMenuItem.Size = new Size(162, 26);
            inverseToolStripMenuItem.Text = "Inverse";
            inverseToolStripMenuItem.Click += hideIntesnityBar_Click;
            inverseToolStripMenuItem.Click += inverseToolStripMenuItem_Click;
            // 
            // histogramToolStripMenuItem
            // 
            histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            histogramToolStripMenuItem.Size = new Size(162, 26);
            histogramToolStripMenuItem.Text = "Histogram";
            histogramToolStripMenuItem.Click += hideIntesnityBar_Click;
            histogramToolStripMenuItem.Click += histogramToolStripMenuItem_Click;
            // 
            // sepiaToolStripMenuItem
            // 
            sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            sepiaToolStripMenuItem.Size = new Size(162, 26);
            sepiaToolStripMenuItem.Text = "Sepia";
            sepiaToolStripMenuItem.Click += hideIntesnityBar_Click;
            sepiaToolStripMenuItem.Click += sepiaToolStripMenuItem_Click;
            // 
            // subtractImageToolStripMenuItem
            // 
            subtractImageToolStripMenuItem.Name = "subtractImageToolStripMenuItem";
            subtractImageToolStripMenuItem.Size = new Size(124, 24);
            subtractImageToolStripMenuItem.Text = "Subtract Image";
            subtractImageToolStripMenuItem.Click += subtractImageToolStripMenuItem_Click;
            subtractImageToolStripMenuItem.Click += subtractImageToolStripMenuItem_Click;
            // 
            // toolToolStripMenuItem
            // 
            toolToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { normalEditToolStripMenuItem, subtractEditToolStripMenuItem, webcamSubtractToolStripMenuItem });
            toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            toolToolStripMenuItem.Size = new Size(58, 24);
            toolToolStripMenuItem.Text = "Tools";
            // 
            // normalEditToolStripMenuItem
            // 
            normalEditToolStripMenuItem.Name = "normalEditToolStripMenuItem";
            normalEditToolStripMenuItem.Size = new Size(209, 26);
            normalEditToolStripMenuItem.Text = "Normal Edit";
            normalEditToolStripMenuItem.Click += normalEditToolStripMenuItem_Click;
            // 
            // subtractEditToolStripMenuItem
            // 
            subtractEditToolStripMenuItem.Name = "subtractEditToolStripMenuItem";
            subtractEditToolStripMenuItem.Size = new Size(209, 26);
            subtractEditToolStripMenuItem.Text = "Subtract Edit";
            subtractEditToolStripMenuItem.Click += subtractEditToolStripMenuItem_Click;
            // 
            // webcamSubtractToolStripMenuItem
            // 
            webcamSubtractToolStripMenuItem.Name = "webcamSubtractToolStripMenuItem";
            webcamSubtractToolStripMenuItem.Size = new Size(224, 26);
            webcamSubtractToolStripMenuItem.Text = "Webcam";
            webcamSubtractToolStripMenuItem.Click += webcamSubtractToolStripMenuItem_Click;
            // 
            // imagePanel1
            // 
            imagePanel1.Controls.Add(splitContainer1);
            imagePanel1.Location = new Point(0, 3);
            imagePanel1.Name = "imagePanel1";
            imagePanel1.Size = new Size(1232, 526);
            imagePanel1.TabIndex = 2;
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
            splitContainer1.Panel2.Controls.Add(histogramPanel);
            splitContainer1.Panel2.Controls.Add(resultImagePanel);
            splitContainer1.Size = new Size(1232, 526);
            splitContainer1.SplitterDistance = 607;
            splitContainer1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(originalImagePicture);
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(607, 526);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // originalImagePicture
            // 
            originalImagePicture.BorderStyle = BorderStyle.FixedSingle;
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
            // histogramPanel
            // 
            histogramPanel.Controls.Add(histogramPlot);
            histogramPanel.Controls.Add(label4);
            histogramPanel.Location = new Point(0, 0);
            histogramPanel.Name = "histogramPanel";
            histogramPanel.Size = new Size(614, 526);
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
            // resultImagePanel
            // 
            resultImagePanel.Controls.Add(editedImagePicture);
            resultImagePanel.Controls.Add(label2);
            resultImagePanel.Dock = DockStyle.Fill;
            resultImagePanel.Location = new Point(0, 0);
            resultImagePanel.Name = "resultImagePanel";
            resultImagePanel.Size = new Size(621, 526);
            resultImagePanel.TabIndex = 1;
            // 
            // editedImagePicture
            // 
            editedImagePicture.BorderStyle = BorderStyle.FixedSingle;
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
            intensityBarPanel.Location = new Point(18, 535);
            intensityBarPanel.Name = "intensityBarPanel";
            intensityBarPanel.Size = new Size(1230, 85);
            intensityBarPanel.TabIndex = 3;
            intensityBarPanel.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(159, 26);
            label3.Name = "label3";
            label3.Size = new Size(86, 28);
            label3.TabIndex = 1;
            label3.Text = "Intensity";
            label3.TextAlign = ContentAlignment.MiddleCenter;
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
            // mainPanel
            // 
            mainPanel.Controls.Add(subPanel3);
            mainPanel.Location = new Point(18, 31);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1232, 640);
            mainPanel.TabIndex = 5;
            // 
            // subPanel3
            // 
            subPanel3.Controls.Add(cameraButton);
            subPanel3.Controls.Add(webcamDisplay);
            subPanel3.Controls.Add(label8);
            subPanel3.Dock = DockStyle.Fill;
            subPanel3.Location = new Point(0, 0);
            subPanel3.Name = "subPanel3";
            subPanel3.Size = new Size(1232, 640);
            subPanel3.TabIndex = 7;
            // 
            // cameraButton
            // 
            cameraButton.FlatStyle = FlatStyle.Flat;
            cameraButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cameraButton.Location = new Point(551, 587);
            cameraButton.Name = "cameraButton";
            cameraButton.Size = new Size(123, 43);
            cameraButton.TabIndex = 7;
            cameraButton.Text = "Start Camera";
            cameraButton.UseVisualStyleBackColor = true;
            cameraButton.Click += cameraButton_Click;
            // 
            // webcamDisplay
            // 
            webcamDisplay.Anchor = AnchorStyles.None;
            webcamDisplay.BorderStyle = BorderStyle.FixedSingle;
            webcamDisplay.Location = new Point(136, 30);
            webcamDisplay.Name = "webcamDisplay";
            webcamDisplay.Size = new Size(960, 540);
            webcamDisplay.SizeMode = PictureBoxSizeMode.Zoom;
            webcamDisplay.TabIndex = 0;
            webcamDisplay.TabStop = false;
            // 
            // label8
            // 
            label8.Location = new Point(136, 5);
            label8.Name = "label8";
            label8.Size = new Size(960, 25);
            label8.TabIndex = 6;
            label8.Text = "Webcam";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // subPanel2
            // 
            subPanel2.Controls.Add(subtractImagePicture);
            subPanel2.Controls.Add(label5);
            subPanel2.Controls.Add(subtractBackgroundPicture);
            subPanel2.Controls.Add(label7);
            subPanel2.Controls.Add(subtractResultPicture);
            subPanel2.Controls.Add(label6);
            subPanel2.Dock = DockStyle.Fill;
            subPanel2.Location = new Point(0, 0);
            subPanel2.Name = "subPanel2";
            subPanel2.Size = new Size(1232, 640);
            subPanel2.TabIndex = 6;
            // 
            // subtractImagePicture
            // 
            subtractImagePicture.BorderStyle = BorderStyle.FixedSingle;
            subtractImagePicture.Location = new Point(0, 6);
            subtractImagePicture.Name = "subtractImagePicture";
            subtractImagePicture.Size = new Size(600, 280);
            subtractImagePicture.SizeMode = PictureBoxSizeMode.StretchImage;
            subtractImagePicture.TabIndex = 6;
            subtractImagePicture.TabStop = false;
            // 
            // label5
            // 
            label5.Location = new Point(0, 290);
            label5.Name = "label5";
            label5.Size = new Size(600, 20);
            label5.TabIndex = 6;
            label5.Text = "Image";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // subtractBackgroundPicture
            // 
            subtractBackgroundPicture.BorderStyle = BorderStyle.FixedSingle;
            subtractBackgroundPicture.Location = new Point(0, 324);
            subtractBackgroundPicture.Name = "subtractBackgroundPicture";
            subtractBackgroundPicture.Size = new Size(600, 280);
            subtractBackgroundPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            subtractBackgroundPicture.TabIndex = 7;
            subtractBackgroundPicture.TabStop = false;
            // 
            // label7
            // 
            label7.Location = new Point(0, 610);
            label7.Name = "label7";
            label7.Size = new Size(600, 20);
            label7.TabIndex = 10;
            label7.Text = "Background Image";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // subtractResultPicture
            // 
            subtractResultPicture.BorderStyle = BorderStyle.FixedSingle;
            subtractResultPicture.Location = new Point(630, 155);
            subtractResultPicture.Name = "subtractResultPicture";
            subtractResultPicture.Size = new Size(600, 280);
            subtractResultPicture.SizeMode = PictureBoxSizeMode.Zoom;
            subtractResultPicture.TabIndex = 8;
            subtractResultPicture.TabStop = false;
            // 
            // label6
            // 
            label6.Location = new Point(630, 445);
            label6.Name = "label6";
            label6.Size = new Size(600, 20);
            label6.TabIndex = 9;
            label6.Text = "Result Image";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // subPanel1
            // 
            subPanel1.Controls.Add(intensityBarPanel);
            subPanel1.Controls.Add(imagePanel1);
            subPanel1.Dock = DockStyle.Fill;
            subPanel1.Location = new Point(0, 0);
            subPanel1.Name = "subPanel1";
            subPanel1.Size = new Size(1232, 640);
            subPanel1.TabIndex = 6;
            // 
            // subtractToolStripMenuItem
            // 
            subtractToolStripMenuItem.Name = "subtractToolStripMenuItem";
            subtractToolStripMenuItem.Size = new Size(224, 26);
            subtractToolStripMenuItem.Text = "Subtract";
            // 
            // ImageProcessing
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 673);
            Controls.Add(mainPanel);
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
            imagePanel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)originalImagePicture).EndInit();
            histogramPanel.ResumeLayout(false);
            resultImagePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)editedImagePicture).EndInit();
            intensityBarPanel.ResumeLayout(false);
            intensityBarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)intensityBar).EndInit();
            mainPanel.ResumeLayout(false);
            subPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)webcamDisplay).EndInit();
            subPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)subtractImagePicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)subtractBackgroundPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)subtractResultPicture).EndInit();
            subPanel1.ResumeLayout(false);
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
        private Panel imagePanel1;
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
        private Panel mainPanel;
        private Panel subPanel1;
        private Panel subPanel2;
        private Panel subPanel3;
        private PictureBox subtractImagePicture;
        private PictureBox subtractBackgroundPicture;
        private PictureBox subtractResultPicture;
        private Label label5;
        private Label label7;
        private Label label6;
        private ToolStripMenuItem toolToolStripMenuItem;
        private ToolStripMenuItem normalEditToolStripMenuItem;
        private ToolStripMenuItem subtractEditToolStripMenuItem;
        private ToolStripMenuItem webcamSubtractToolStripMenuItem;
        private PictureBox webcamDisplay;
        private Label label8;
        private ToolStripMenuItem loadOriginalToolStripMenuItem;
        private ToolStripMenuItem loadBackgroundToolStripMenuItem;
        private ToolStripMenuItem subtractImageToolStripMenuItem;
        private Button cameraButton;
        private ToolStripMenuItem subtractToolStripMenuItem;
    }
}
