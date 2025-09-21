using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    internal class ImageProcessingService
    {
        public Image CopyImage(Image originalImage)
        {
            try
            {
                Bitmap originalBitmap   = new Bitmap(originalImage);
                Bitmap copiedBitmap     = new Bitmap(originalBitmap.Width, originalBitmap.Height);

                for (int y = 0; y < originalBitmap.Height; y++)
                {
                    for (int x = 0; x < originalBitmap.Width; x++)
                    {
                        Color pixel = originalBitmap.GetPixel(x, y);
                        copiedBitmap.SetPixel(x, y, pixel);
                    }
                }

                return (Image)copiedBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error copying image: " + ex.Message);
            }

            return null;
        }

        public Image GreyScaleImage(Image originalImage, int intensityFactor = 50)
        {
            try
            {
                Bitmap originalBitmap   = new Bitmap(originalImage);
                Bitmap greyScaleBitmap  = new Bitmap(originalBitmap.Width, originalBitmap.Height);

                for (int y = 0; y < originalBitmap.Height; y++)
                {
                    for (int x = 0; x < originalBitmap.Width; x++)
                    {
                        Color pixel = originalBitmap.GetPixel(x, y);
                        int greyValue = (pixel.R + pixel.G + pixel.B) / 3;
                        double scale = intensityFactor / 50.0;
                        greyValue = (int)(greyValue * scale);
                        greyValue = greyValue > 255 ? 255 : greyValue;
                        Color greyPixel = Color.FromArgb(greyValue, greyValue, greyValue);
                        greyScaleBitmap.SetPixel(x, y, greyPixel);
                    }
                }

                return (Image)greyScaleBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error applying greyscale: " + ex.Message);
            }

            return null;
        }

        public Image InvertImage(Image originalImage)
        {
            try
            {
                Bitmap originalBitmap = new Bitmap(originalImage);
                Bitmap invertedBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);

                for (int y = 0; y < originalBitmap.Height; y++)
                {
                    for (int x = 0; x < originalBitmap.Width; x++)
                    {
                        Color pixel = originalBitmap.GetPixel(x, y);
                        Color greyPixel = Color.FromArgb(255-pixel.R, 255 - pixel.G, 255 - pixel.B);
                        invertedBitmap.SetPixel(x, y, greyPixel);
                    }
                }

                return (Image)invertedBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inverting image: " + ex.Message);
            }

            return null;
        }

        public bool HistogramPlot(Image originalImage, ScottPlot.WinForms.FormsPlot histogramPlot)
        {
            try
            {
                Bitmap grayBitmap = (Bitmap)GreyScaleImage(originalImage);
                int[] histogram = new int[256];

                for (int y = 0; y < grayBitmap.Height; y++)
                {
                    for (int x = 0; x < grayBitmap.Width; x++)
                    {
                        Color pixel = grayBitmap.GetPixel(x, y);
                        histogram[pixel.R]++;
                    }
                }

                double[] counts = Array.ConvertAll(histogram, i => (double)i);
                double[] bins   = Enumerable.Range(0, 256).Select(i => (double)i).ToArray();

                var hist = ScottPlot.Statistics.Histogram.WithBinSize(1, bins);

                histogramPlot.Plot.Clear();

                var barPlot = histogramPlot.Plot.Add.Bars(bins, counts);

                foreach (var bar in barPlot.Bars)
                {
                    bar.Size = hist.FirstBinSize;
                    bar.LineWidth = 0;
                    bar.FillStyle.AntiAlias = false;
                    bar.FillColor = ScottPlot.Color.FromColor(Color.Gray);
                }

                histogramPlot.Plot.Axes.Margins(bottom: 0);
                histogramPlot.Refresh();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating histogram: " + ex.Message);
            }

            return false;
        }

        public Image SepiaImage(Image originalImage)
        {
            try
            {
                Bitmap originalBitmap = new Bitmap(originalImage);
                Bitmap sepiaBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);

                for (int y = 0; y < originalBitmap.Height; y++)
                {
                    for (int x = 0; x < originalBitmap.Width; x++)
                    {
                        Color pixel = originalBitmap.GetPixel(x, y);

                        int sepiaRed    = (int)(.393 * pixel.R + .769 * pixel.G + .189 * pixel.B);
                        int sepiaGreen  = (int)(.349 * pixel.R + .686 * pixel.G + .168 * pixel.B);
                        int sepiaBlue   = (int)(.272 * pixel.R + .534 * pixel.G + .131 * pixel.B);

                        sepiaRed    = sepiaRed > 255 ? 255 : sepiaRed;
                        sepiaGreen  = sepiaGreen > 255 ? 255 : sepiaGreen;
                        sepiaBlue   = sepiaBlue > 255 ? 255 : sepiaBlue;

                        Color greyPixel = Color.FromArgb(sepiaRed, sepiaGreen, sepiaBlue);
                        sepiaBitmap.SetPixel(x, y, greyPixel);
                    }
                }

                return (Image)sepiaBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inverting image: " + ex.Message);
            }
            return null;
        }

        public Image SubtractImage(Image image, Image backgroundImage)
        {
            return subtractWithFullColor(image, backgroundImage);
        }

        private Bitmap ResizeBitmap(Image original, int newWidth, int newHeight)
        {
            Bitmap resized = new Bitmap(newWidth, newHeight);

            using (Graphics g = Graphics.FromImage(resized))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(original, 0, 0, newWidth, newHeight);
            }

            return resized;
        }

        private Image subtractWithGrey(Image image, Image backgroundImage)
        {
            try
            {
                Bitmap imageBitmap = new Bitmap(image);
                Bitmap backgroundBitmap = new Bitmap(backgroundImage);

                if (imageBitmap.Width != backgroundBitmap.Width ||
                    imageBitmap.Height != backgroundBitmap.Height)
                {
                    MessageBox.Show("Resizing Bigger Image: Images must have the same dimensions");

                    int originalArea = imageBitmap.Width * imageBitmap.Height;
                    int backgroundArea = backgroundBitmap.Width * backgroundBitmap.Height;

                    if (originalArea > backgroundArea)
                    {
                        imageBitmap = ResizeBitmap(imageBitmap, backgroundBitmap.Width, backgroundBitmap.Height);
                    }
                    else
                    {
                        backgroundBitmap = ResizeBitmap(backgroundBitmap, imageBitmap.Width, imageBitmap.Height);
                    }
                }

                if (imageBitmap.Width != backgroundBitmap.Width ||
                    imageBitmap.Height != backgroundBitmap.Height)
                {
                    MessageBox.Show("Error resizing image");
                    return null;
                }

                Bitmap resultBitmap = new Bitmap(imageBitmap.Width, imageBitmap.Height);

                using (ColorDialog cd = new ColorDialog())
                {
                    cd.AllowFullOpen = true;
                    cd.ShowHelp = true;

                    if (cd.ShowDialog() == DialogResult.OK)
                    {
                        Color subtractColor = cd.Color;
                        int greySubtractValue = (subtractColor.R + subtractColor.G + subtractColor.B) / 3;
                        int threshold = 5;

                        for (int x = 0; x < imageBitmap.Width; x++)
                        {
                            for (int y = 0; y < imageBitmap.Height; y++)
                            {
                                Color pixel = imageBitmap.GetPixel(x, y);
                                Color backPixel = backgroundBitmap.GetPixel(x, y);
                                int greyImage = (pixel.R + pixel.G + pixel.B) / 3;
                                int subtractValue = Math.Abs(greyImage - greySubtractValue);
                                if (subtractValue > threshold)
                                    resultBitmap.SetPixel(x, y, pixel);
                                else
                                    resultBitmap.SetPixel(x, y, backPixel);
                            }
                        }
                    }
                }
                return (Image)resultBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error subtracting image: " + ex.Message);
            }

            return null;
        }

        private Image subtractWithFullColor(Image image, Image backgroundImage)
        {
            try
            {
                Bitmap imageBitmap = new Bitmap(image);
                Bitmap backgroundBitmap = new Bitmap(backgroundImage);

                if (imageBitmap.Width != backgroundBitmap.Width ||
                    imageBitmap.Height != backgroundBitmap.Height)
                {
                    MessageBox.Show("Resizing Bigger Image: Images must have the same dimensions");

                    int originalArea = imageBitmap.Width * imageBitmap.Height;
                    int backgroundArea = backgroundBitmap.Width * backgroundBitmap.Height;

                    if (originalArea > backgroundArea)
                    {
                        imageBitmap = ResizeBitmap(imageBitmap, backgroundBitmap.Width, backgroundBitmap.Height);
                    }
                    else
                    {
                        backgroundBitmap = ResizeBitmap(backgroundBitmap, imageBitmap.Width, imageBitmap.Height);
                    }
                }

                if (imageBitmap.Width != backgroundBitmap.Width ||
                    imageBitmap.Height != backgroundBitmap.Height)
                {
                    MessageBox.Show("Error resizing image");
                    return null;
                }

                Bitmap resultBitmap = new Bitmap(imageBitmap.Width, imageBitmap.Height);

                using (ColorDialog cd = new ColorDialog())
                {
                    cd.AllowFullOpen = true;
                    cd.ShowHelp = true;

                    if (cd.ShowDialog() == DialogResult.OK)
                    {
                        Color subtractColor = cd.Color;
                        int threshold = 150;

                        for (int x = 0; x < imageBitmap.Width; x++)
                        {
                            for (int y = 0; y < imageBitmap.Height; y++)
                            {
                                Color pixel = imageBitmap.GetPixel(x, y);
                                Color backPixel = backgroundBitmap.GetPixel(x, y);

                                int diffR = Math.Abs(pixel.R - subtractColor.R);
                                int diffG = Math.Abs(pixel.G - subtractColor.G);
                                int diffB = Math.Abs(pixel.B - subtractColor.B);

                                double distance = Math.Sqrt(diffR * diffR + diffG * diffG + diffB * diffB);
                                if (distance > threshold)
                                    resultBitmap.SetPixel(x, y, pixel);
                                else
                                    resultBitmap.SetPixel(x, y, backPixel);
                            }
                        }
                    }
                }
                return (Image)resultBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error subtracting image: " + ex.Message);
            }

            return null;
        }
    }
}
