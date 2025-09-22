using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Video;
using AForge.Video.DirectShow;

namespace ImageProcessing
{
    internal class WebcamManager
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private PictureBox webcamDisplay;

        public FilterType CurrentFilter { get; set; } = FilterType.None;

        public WebcamManager(PictureBox webcamDisplay)
        {
            this.webcamDisplay = webcamDisplay;
            InitializeCamera();
        }

        private void InitializeCamera()
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if(videoDevices.Count == 0)
            {
                MessageBox.Show("No Webcam Found!");
                return;
            }

            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(Video_NewFrame);

            startCamera();
        }

        private void Video_NewFrame(object sender, NewFrameEventArgs e)
        {
            Bitmap frame = (Bitmap)e.Frame.Clone();

            Bitmap filtered = ImageProcessingService.ApplyWebCamFilter(frame, CurrentFilter);

            webcamDisplay.Invoke((Action)(() =>
            {
                webcamDisplay.Image?.Dispose();
                webcamDisplay.Image = filtered;
            }));
        }

        public void startCamera()
        {
            videoSource.Start();
        }

        public void stopCamera()
        {
            videoSource.SignalToStop();
            webcamDisplay.Image = null;
        }
    }
}
