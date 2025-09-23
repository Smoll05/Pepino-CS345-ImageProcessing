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
            StartCamera();
        }

        private void Video_NewFrame(object sender, NewFrameEventArgs e) { 
            if (webcamDisplay.IsDisposed || !webcamDisplay.IsHandleCreated)
                return; 
            
            Bitmap frame = (Bitmap)e.Frame.Clone(); 
            Bitmap filtered = ImageProcessingService.ApplyWebCamFilter(frame, CurrentFilter); 
            
            if (webcamDisplay.IsHandleCreated && !webcamDisplay.IsDisposed) { 
                webcamDisplay.BeginInvoke((Action)(() => { 
                    webcamDisplay.Image?.Dispose(); 
                    webcamDisplay.Image = filtered; 
                })); 
            } 
            else 
            { 
                filtered.Dispose(); 
            } 
        }

        public void StartCamera()
        {
            videoSource?.Start();
        }

        public void StopCamera()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
            webcamDisplay.Image?.Dispose();
            webcamDisplay.Image = null;
        }

        public void closeCamera()
        {
            if (videoSource != null)
            {
                StopCamera();
                videoSource.NewFrame -= Video_NewFrame;
                videoSource = null;
            }
        }
    }
}
