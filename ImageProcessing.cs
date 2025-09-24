namespace ImageProcessing
{
    public partial class ImageProcessing : Form
    {
        ImageManagementService imageManagementService;
        WebcamManager webcamManager;
        bool hasImageLoaded;
        bool hasImageEdited;
        bool hasBackgroundLoaded;
        bool isCreatingHistogram;
        bool isCameraStarted;

        // 1 - Normal Edit
        // 2 - Subtract Edit
        // 3 - WebCam Subtract
        int panelNumberShown;

        public ImageProcessing()
        {
            InitializeComponent();

            cameraComboBox.Items.Insert(0, "-- None --");
            cameraComboBox.SelectedIndex = 0;
            cameraComboBox.SelectedIndexChanged += cameraComboBox_SelectedIndexChanged;


            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(subPanel1);
            subtractImageToolStripMenuItem.Visible = false;
            loadOriginalToolStripMenuItem.Visible = false;
            loadBackgroundToolStripMenuItem.Visible = false;
            subtractToolStripMenuItem.Visible = false;
            noneToolStripMenuItem.Visible = false;

            imageManagementService = new ImageManagementService();
            webcamManager = new WebcamManager(webcamDisplay);
            hasImageLoaded = false;
            hasImageEdited = false;
            isCreatingHistogram = false;
            isCameraStarted = false;
            panelNumberShown = 1;
        }

        /*
         * Form Events
         */
        private void Form1_Load(object sender, EventArgs e)
        {
            var cameras = webcamManager.GetAvailableCameras();
            cameraComboBox.Items.AddRange(cameras.ToArray());
        }
        private void ImageProcessing_FormClosing(object sender, FormClosingEventArgs e)
        {
            webcamManager.closeCamera();
            webcamManager = null;
        }

        /*
         * Image Management Service Calls
         */
        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelNumberShown == 1)
            {
                hasImageLoaded = imageManagementService.LoadImage(originalImagePicture);
            }
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelNumberShown == 3)
            {
                if (!isCameraStarted)
                {
                    MessageBox.Show("Start the Camera First");
                    return;
                }

                if (imageManagementService.SaveImage(webcamDisplay))
                {
                    MessageBox.Show("Image Saved!");
                }
                return;
            }

            if (!hasImageEdited)
            {
                MessageBox.Show("No Edited Image To Save!");
                return;
            }

            if (panelNumberShown == 1)
            {
                if (isCreatingHistogram)
                {
                    if (imageManagementService.SaveHistogram(histogramPlot))
                    {
                        MessageBox.Show("Histogram Saved Successfully!");
                    }
                }
                else
                {
                    if (imageManagementService.SaveImage(editedImagePicture))
                    {
                        MessageBox.Show("Image Saved Successfully!");
                    }
                }
            }
            else if (panelNumberShown == 2)
            {
                if (imageManagementService.SaveImage(editedImagePicture))
                {
                    MessageBox.Show("Image Saved Successfully!");
                }
            }
        }


        /*
         * Image Processing Service Calls
         */
        private void copyStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!hasImageLoaded)
            {
                MessageBox.Show("Load An Image First!");
                return;
            }

            Image editedImage = ImageProcessingService.CopyImage(originalImagePicture.Image);
            if (editedImage != null)
            {
                editedImagePicture.Image = editedImage;
                editedImagePicture.SizeMode = PictureBoxSizeMode.Zoom;
                hasImageEdited = true;
            }
        }

        private void greyscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelNumberShown == 1)
            {
                if (!hasImageLoaded)
                {
                    MessageBox.Show("Load An Image First!");
                    return;
                }

                Image editedImage = ImageProcessingService.GreyScaleImage(originalImagePicture.Image);
                if (editedImage != null)
                {
                    editedImagePicture.Image = editedImage;
                    editedImagePicture.SizeMode = PictureBoxSizeMode.Zoom;
                    hasImageEdited = true;
                }
            }
            else if (panelNumberShown == 3)
            {
                if (!isCameraStarted)
                {
                    MessageBox.Show("Start the Camera First");
                    return;
                }

                webcamManager.CurrentFilter = FilterType.Grayscale;
            }
        }

        private void inverseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelNumberShown == 1)
            {
                if (!hasImageLoaded)
                {
                    MessageBox.Show("Load An Image First!");
                    return;
                }

                Image editedImage = ImageProcessingService.InvertImage(originalImagePicture.Image);
                if (editedImage != null)
                {
                    editedImagePicture.Image = editedImage;
                    editedImagePicture.SizeMode = PictureBoxSizeMode.Zoom;
                    hasImageEdited = true;
                }
            }
            else if (panelNumberShown == 3)
            {
                if (!isCameraStarted)
                {
                    MessageBox.Show("Start the Camera First");
                    return;
                }

                webcamManager.CurrentFilter = FilterType.Invert;
            }
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!hasImageLoaded)
            {
                MessageBox.Show("Load An Image First!");
                return;
            }

            isCreatingHistogram = ImageProcessingService.HistogramPlot(originalImagePicture.Image, histogramPlot);
            hasImageEdited = isCreatingHistogram;
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelNumberShown == 1)
            {
                if (!hasImageLoaded)
                {
                    MessageBox.Show("Load An Image First!");
                    return;
                }

                Image editedImage = ImageProcessingService.SepiaImage(originalImagePicture.Image);
                if (editedImage != null)
                {
                    editedImagePicture.Image = editedImage;
                    editedImagePicture.SizeMode = PictureBoxSizeMode.Zoom;
                    hasImageEdited = true;
                }
            }
            else if (panelNumberShown == 3)
            {
                if (!isCameraStarted)
                {
                    MessageBox.Show("Start the Camera First");
                    return;
                }

                webcamManager.CurrentFilter = FilterType.Sepia;
            }
        }
        private void loadOriginalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hasImageLoaded = imageManagementService.LoadImage(subtractImagePicture);
        }
        private void loadBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hasBackgroundLoaded = imageManagementService.LoadImage(subtractBackgroundPicture);
        }


        /*
         *  Tools Menu Calls
         */
        private void normalEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(subPanel1);

            panelNumberShown = 1;
            subtractImageToolStripMenuItem.Visible = false;
            loadOriginalToolStripMenuItem.Visible = false;
            loadBackgroundToolStripMenuItem.Visible = false;
            editImageToolStripMenuItem.Visible = true;
            subtractToolStripMenuItem.Visible = false;
            copyStripMenuItem.Visible = true;
            noneToolStripMenuItem.Visible = false;

            if (isCameraStarted)
            {
                webcamManager.StopCamera();
                cameraButton.Text = "Start Camera";
                isCameraStarted = false;
            }
        }

        private void subtractEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(subPanel2);

            panelNumberShown = 2;
            loadOriginalToolStripMenuItem.Visible = true;
            loadBackgroundToolStripMenuItem.Visible = true;
            editImageToolStripMenuItem.Visible = false;
            subtractImageToolStripMenuItem.Visible = true;
            subtractToolStripMenuItem.Visible = false;
            noneToolStripMenuItem.Visible = false;

            if (isCameraStarted)
            {
                webcamManager.StopCamera();
                cameraButton.Text = "Start Camera";
                isCameraStarted = false;
            }
        }

        private void webcamSubtractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(subPanel3);

            panelNumberShown = 3;
            loadOriginalToolStripMenuItem.Visible = false;
            loadBackgroundToolStripMenuItem.Visible = false;
            editImageToolStripMenuItem.Visible = true;
            subtractToolStripMenuItem.Visible = false;
            subtractImageToolStripMenuItem.Visible = false;
            copyStripMenuItem.Visible = false;
            histogramToolStripMenuItem.Visible = false;
            noneToolStripMenuItem.Visible = true;
        }


        /*
         *  UI Calls
         */
        private void intensityBar_Scroll(object sender, EventArgs e)
        {
            int intensityFactor = intensityBar.Value;
            if (hasImageLoaded)
            {
                Image editedImage = ImageProcessingService.GreyScaleImage(originalImagePicture.Image, intensityFactor);
                if (editedImage != null)
                {
                    editedImagePicture.Image = editedImage;
                    editedImagePicture.SizeMode = PictureBoxSizeMode.Zoom;
                    hasImageEdited = true;
                }
            }
        }

        private void hideIntesnityBar_Click(object sender, EventArgs e)
        {
            intensityBarPanel.Visible = false;
        }

        private void showIntesnityBar_Click(object sender, EventArgs e)
        {
            intensityBar.Value = 50;
            intensityBarPanel.Visible = true;
        }

        private void showHistogramChart_Click(object sender, EventArgs e)
        {
            histogramPanel.Visible = true;
            resultImagePanel.Visible = false;
        }

        private void hideHistogramChart_Click(object sender, EventArgs e)
        {
            histogramPanel.Visible = false;
            resultImagePanel.Visible = true;
            isCreatingHistogram = false;
        }

        private void subtractImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!hasImageLoaded || !hasBackgroundLoaded)
            {
                MessageBox.Show("Load Both An Image And A Background First!");
                return;
            }

            Image editedImage = ImageProcessingService.SubtractImage(subtractImagePicture.Image, subtractBackgroundPicture.Image);
            if (editedImage != null)
            {
                subtractResultPicture.Image = editedImage;
                subtractResultPicture.SizeMode = PictureBoxSizeMode.Zoom;
                hasImageEdited = true;
            }
        }

        /*
         *  Camera Calls
         */

        private void cameraButton_Click(object sender, EventArgs e)
        {
            if (isCameraStarted)
            {
                webcamManager.StopCamera();
                cameraButton.Text = "Start Camera";
                isCameraStarted = false;
            }
            else
            {
                if (isCameraStarted = webcamManager.StartCamera())
                    cameraButton.Text = "Stop Camera";
            }
        }

        private void cameraComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            webcamManager.StopCamera();
            cameraButton.Text = "Start Camera";
            webcamManager.InitializeCamera(cameraComboBox.Text);
        }


        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!isCameraStarted)
            {
                MessageBox.Show("Start the Camera First");
                return;
            }

            webcamManager.CurrentFilter = FilterType.None;
        }
    }
}