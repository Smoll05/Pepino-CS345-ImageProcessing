using System.Drawing.Imaging;

namespace ImageProcessing
{
    internal static class ImageProcessingService
    {
        public static Bitmap ApplyImageFilter(Bitmap bitmap, FilterType type, int intensityValue = 50)
        {
            double factor = (int)(intensityValue / 50.0);
            switch (type)
            {
                case FilterType.None:
                    return bitmap;
                case FilterType.Grayscale:
                    return (Bitmap)GreyScaleImage(bitmap);
                case FilterType.Invert:
                    return (Bitmap)InvertImage(bitmap);
                case FilterType.Sepia:
                    return (Bitmap)SepiaImage(bitmap);
                case FilterType.Smooth:
                    return (Bitmap)Smooth(bitmap);
                case FilterType.GaussianBlur:
                    return (Bitmap)GaussianBlur(bitmap, 20);
                case FilterType.Sharpen:
                    return (Bitmap)Sharpen(bitmap);
                case FilterType.MeanRemoval:
                    return (Bitmap)MeanRemoval(bitmap);
                case FilterType.EmbossLaplascian:
                    return (Bitmap)EmbossLaplascian(bitmap);
                case FilterType.EmbossHorizontalVertical:
                    return (Bitmap)EmbossHorizontalAndVertical(bitmap);
                case FilterType.EmbossAll:
                    return (Bitmap)EmbossAll(bitmap);
                case FilterType.EmbossLossy:
                    return (Bitmap)EmbossLossy(bitmap);
                case FilterType.EmbossHorizontal:
                    return (Bitmap)EmbossHorizontal(bitmap);
                case FilterType.EmbossVertical:
                    return (Bitmap)EmbossVertical(bitmap);
                default:
                    return bitmap;
            }
        }

        //public static Bitmap ApplyImageFilter(Bitmap bitmap, FilterType type, int intensityValue = 50)
        //{
        //    double factor = (int)(intensityValue / 50.0);
        //    switch (type)
        //    {
        //        case FilterType.None:
        //            return bitmap;
        //        case FilterType.Grayscale:
        //            return (Bitmap)GreyScaleImage(bitmap, factor);
        //        case FilterType.Invert:
        //            return (Bitmap)InvertImage(bitmap);
        //        case FilterType.Sepia:
        //            return (Bitmap)SepiaImage(bitmap);
        //        case FilterType.Smooth:
        //            return (Bitmap)Smooth(bitmap, factor);
        //        case FilterType.GaussianBlur:
        //            return (Bitmap)GaussianBlur(bitmap, factor);
        //        case FilterType.Sharpen:
        //            return (Bitmap)Sharpen(bitmap, factor);
        //        case FilterType.MeanRemoval:
        //            return (Bitmap)MeanRemoval(bitmap, factor);
        //        case FilterType.EmbossLaplascian:
        //            return (Bitmap)EmbossLaplascian(bitmap, factor);
        //        case FilterType.EmbossHorizontalVertical:
        //            return (Bitmap)EmbossHorizontalAndVertical(bitmap, factor);
        //        case FilterType.EmbossAll:
        //            return (Bitmap)EmbossAll(bitmap, factor);
        //        case FilterType.EmbossLossy:
        //            return (Bitmap)EmbossLossy(bitmap, factor);
        //        case FilterType.EmbossHorizontal:
        //            return (Bitmap)EmbossHorizontal(bitmap, factor);
        //        case FilterType.EmbossVertical:
        //            return (Bitmap)EmbossVertical(bitmap, factor);
        //        default:
        //            return bitmap;
        //    }
        //}

        public static Image CopyImage(Image originalImage)
        {
            try
            {
                Bitmap originalBitmap = new Bitmap(originalImage);
                Bitmap copiedBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);

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

        public static Image GreyScaleImage(Image originalImage, double intensityFactor = 50)
        {
            unsafe
            {
                try
                {
                    Bitmap originalBitmap = new Bitmap(originalImage);
                    BitmapData bitmapData = originalBitmap.LockBits(
                        new Rectangle(0, 0, originalBitmap.Width, originalBitmap.Height),
                        ImageLockMode.ReadWrite,
                        originalBitmap.PixelFormat);

                    int bytesPerPixel = Bitmap.GetPixelFormatSize(originalBitmap.PixelFormat) / 8;
                    int heightInPixels = bitmapData.Height;
                    int widthInBytes = bitmapData.Width * bytesPerPixel;
                    byte* PtrFirstPixel = (byte*)bitmapData.Scan0;

                    Parallel.For(0, heightInPixels, y =>
                    {
                        byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);
                        for (int x = 0; x < widthInBytes; x += bytesPerPixel)
                        {
                            int oldBlue = currentLine[x];
                            int oldGreen = currentLine[x + 1];
                            int oldRed = currentLine[x + 2];

                            int greyValue = (oldBlue + oldGreen + oldRed) / 3;
                            double scale = intensityFactor / 50.0;
                            greyValue = (int)(greyValue * scale);
                            greyValue = greyValue > 255 ? 255 : greyValue;

                            currentLine[x] = (byte)greyValue;
                            currentLine[x + 1] = (byte)greyValue;
                            currentLine[x + 2] = (byte)greyValue;
                        }
                    });
                    originalBitmap.UnlockBits(bitmapData);

                    return (Image)originalBitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error applying greyscale: " + ex.Message);
                }

                return null;
            }
        }

        public static Image InvertImage(Image originalImage)
        {
            unsafe
            {
                try
                {
                    Bitmap originalBitmap = new Bitmap(originalImage);
                    BitmapData bitmapData = originalBitmap.LockBits(
                        new Rectangle(0, 0, originalBitmap.Width, originalBitmap.Height),
                        ImageLockMode.ReadWrite,
                        originalBitmap.PixelFormat);

                    int bytesPerPixel = Bitmap.GetPixelFormatSize(originalBitmap.PixelFormat) / 8;
                    int heightInPixels = bitmapData.Height;
                    int widthInBytes = bitmapData.Width * bytesPerPixel;
                    byte* PtrFirstPixel = (byte*)bitmapData.Scan0;

                    Parallel.For(0, heightInPixels, y =>
                    {
                        byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);
                        for (int x = 0; x < widthInBytes; x += bytesPerPixel)
                        {
                            int oldBlue = currentLine[x];
                            int oldGreen = currentLine[x + 1];
                            int oldRed = currentLine[x + 2];

                            int invertBlue = 255 - oldBlue;
                            int invertGreen = 255 - oldGreen;
                            int invertRed = 255 - oldRed;

                            currentLine[x] = (byte)invertBlue;
                            currentLine[x + 1] = (byte)invertGreen;
                            currentLine[x + 2] = (byte)invertRed;
                        }
                    });

                    originalBitmap.UnlockBits(bitmapData);

                    return (Image)originalBitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inverting image: " + ex.Message);
                }

                return null;
            }
        }

        public static bool HistogramPlot(Image originalImage, ScottPlot.WinForms.FormsPlot histogramPlot)
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
                double[] bins = Enumerable.Range(0, 256).Select(i => (double)i).ToArray();

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

        public static Image SepiaImage(Image originalImage)
        {
            unsafe
            {
                try
                {
                    Bitmap originalBitmap = new Bitmap(originalImage);
                    BitmapData bitmapData = originalBitmap.LockBits(
                        new Rectangle(0, 0, originalBitmap.Width, originalBitmap.Height),
                        ImageLockMode.ReadWrite,
                        originalBitmap.PixelFormat);

                    int bytesPerPixel = Bitmap.GetPixelFormatSize(originalBitmap.PixelFormat) / 8;
                    int heightInPixels = bitmapData.Height;
                    int widthInBytes = bitmapData.Width * bytesPerPixel;
                    byte* PtrFirstPixel = (byte*)bitmapData.Scan0;

                    Parallel.For(0, heightInPixels, y =>
                    {
                        byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);
                        for (int x = 0; x < widthInBytes; x += bytesPerPixel)
                        {
                            int oldBlue = currentLine[x];
                            int oldGreen = currentLine[x + 1];
                            int oldRed = currentLine[x + 2];


                            int sepiaRed = (int)(.393 * oldRed + .769 * oldGreen + .189 * oldBlue);
                            int sepiaGreen = (int)(.349 * oldRed + .686 * oldGreen + .168 * oldBlue);
                            int sepiaBlue = (int)(.272 * oldRed + .534 * oldGreen + .131 * oldBlue);

                            sepiaRed = sepiaRed > 255 ? 255 : sepiaRed;
                            sepiaGreen = sepiaGreen > 255 ? 255 : sepiaGreen;
                            sepiaBlue = sepiaBlue > 255 ? 255 : sepiaBlue;

                            currentLine[x] = (byte)sepiaBlue;
                            currentLine[x + 1] = (byte)sepiaGreen;
                            currentLine[x + 2] = (byte)sepiaRed;
                        }
                    });

                    originalBitmap.UnlockBits(bitmapData);

                    return (Image)originalBitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inverting image: " + ex.Message);
                }

                return null;
            }
        }

        public static Image SubtractImage(Image image, Image backgroundImage)
        {
            return SubtractWithFullColor(image, backgroundImage);
        }

        private static Image SubtractWithGrey(Image image, Image backgroundImage)
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
                        imageBitmap = Utils.ResizeBitmap(imageBitmap, backgroundBitmap.Width, backgroundBitmap.Height);
                    }
                    else
                    {
                        backgroundBitmap = Utils.ResizeBitmap(backgroundBitmap, imageBitmap.Width, imageBitmap.Height);
                    }
                }

                if (imageBitmap.Width != backgroundBitmap.Width ||
                    imageBitmap.Height != backgroundBitmap.Height)
                {
                    MessageBox.Show("Error resizing image");
                    return null;
                }

                Bitmap resultBitmap = new Bitmap(imageBitmap.Width, imageBitmap.Height);

                Color subtractColor = Utils.GetColor();
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
                return (Image)resultBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error subtracting image: " + ex.Message);
            }

            return null;
        }

        private static Image SubtractWithFullColor(Image image, Image backgroundImage)
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
                        imageBitmap = Utils.ResizeBitmap(imageBitmap, backgroundBitmap.Width, backgroundBitmap.Height);
                    }
                    else
                    {
                        backgroundBitmap = Utils.ResizeBitmap(backgroundBitmap, imageBitmap.Width, imageBitmap.Height);
                    }
                }

                if (imageBitmap.Width != backgroundBitmap.Width ||
                    imageBitmap.Height != backgroundBitmap.Height)
                {
                    MessageBox.Show("Error resizing image");
                    return null;
                }

                Bitmap resultBitmap = new Bitmap(imageBitmap.Width, imageBitmap.Height);

                Color subtractColor = Utils.GetColor();
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

                return (Image)resultBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error subtracting image: " + ex.Message);
            }

            return null;
        }

        public static Image Smooth(Image image, int nWeight = 1)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(1);
            m.Pixel = nWeight;
            m.Factor = nWeight + 8;
            Bitmap bitmap = new Bitmap(image);
            return Conv3x3(bitmap, m);
        }
        public static Image GaussianBlur(Image image, int nWeight = 1)
        {
            ConvMatrix m = new ConvMatrix();
            m.Set(
                1, 2, 1,
                2, nWeight, 2,
                1, 2, 1,
                nWeight + 12, 0);
            Bitmap bitmap = new Bitmap(image);
            return Conv3x3(bitmap, m);
        }

        public static Image Sharpen(Image image, int nWeight = 11)
        {
            ConvMatrix m = new ConvMatrix();
            m.Set(
                0, -2, 0,
                -2, nWeight, -2,
                0, -2, 0,
                nWeight - 8, 0);
            Bitmap bitmap = new Bitmap(image);
            return Conv3x3(bitmap, m);
        }

        public static Image MeanRemoval(Image image, int nWeight = 9)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(-1);
            m.Pixel = nWeight;
            m.Factor = nWeight - 8;
            Bitmap bitmap = new Bitmap(image);
            return Conv3x3(bitmap, m);
        }

        public static Image EmbossLaplascian(Image image, int nWeight = 4)
        {
            ConvMatrix m = new ConvMatrix();
            m.Set(
                -1, 0, -1,
                0, nWeight, 0,
                -1, 0, -1,
                nWeight - 3, 127
            );
            Bitmap bitmap = new Bitmap(image);
            return Conv3x3(bitmap, m);
        }

        public static Image EmbossHorizontalAndVertical(Image image, int nWeight = 4)
        {
            ConvMatrix m = new ConvMatrix();
            m.Set(
                0, -1, 0,
                -1, nWeight, -1,
                0, -1, 0,
                nWeight - 3, 127
            );
            Bitmap bitmap = new Bitmap(image);
            return Conv3x3(bitmap, m);
        }

        public static Image EmbossAll(Image image, int nWeight = 8)
        {
            ConvMatrix m = new ConvMatrix();
            m.SetAll(-1);
            m.Pixel = nWeight;
            m.Factor = nWeight - 7;
            m.Offset = 127;
            Bitmap bitmap = new Bitmap(image);
            return Conv3x3(bitmap, m);
        }

        public static Image EmbossLossy(Image image, int nWeight = 4)
        {
            ConvMatrix m = new ConvMatrix();
            m.Set(
                1, -2, 1,
                -2, nWeight, -2,
                -2, 1, -2,
                nWeight - 3, 127
            );
            Bitmap bitmap = new Bitmap(image);
            return Conv3x3(bitmap, m);
        }

        public static Image EmbossHorizontal(Image image, int nWeight = 2)
        {
            ConvMatrix m = new ConvMatrix();
            m.Set(
                0, 0, 0,
                -1, nWeight, -1,
                0, 0, 0,
                nWeight - 1, 127
            );
            Bitmap bitmap = new Bitmap(image);
            return Conv3x3(bitmap, m);
        }

        public static Image EmbossVertical(Image image, int nWeight = 0)
        {
            ConvMatrix m = new ConvMatrix();
            m.Set(
                0, -1, 0,
                0, nWeight, 0,
                0, 1, 0,
                nWeight + 1, 127
            );
            Bitmap bitmap = new Bitmap(image);
            return Conv3x3(bitmap, m);
        }

        private static Image Conv3x3(Bitmap b, ConvMatrix m)
        {
            if (0 == m.Factor)
            {
                MessageBox.Show("Error: Conv3x3 factor must not be zero");
                return null;
            }

            Bitmap bSrc = (Bitmap)b.Clone();

            BitmapData bmData = b.LockBits(
                new Rectangle(0, 0, b.Width, b.Height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);

            BitmapData bmSrc = bSrc.LockBits(
                new Rectangle(0, 0, bSrc.Width, bSrc.Height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            int stride2 = stride * 2;

            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr SrcScan0 = bmSrc.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)SrcScan0;
                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width - 2;
                int nHeight = b.Height - 2;

                int nPixel;

                for (int y = 0; y < nHeight; y++)
                {
                    for (int x = 0; x < nWidth; x++)
                    {
                        // Pixel Format BGR ([0] = BLUE, [1] = GREEN, [2] = RED)

                        // RED PIXEL
                        nPixel = (((
                                    (pSrc[2] * m.TopLeft) +
                                    (pSrc[5] * m.TopMid) +
                                    (pSrc[8] * m.TopRight) +
                                    (pSrc[2 + stride] * m.MidLeft) +
                                    (pSrc[5 + stride] * m.Pixel) +
                                    (pSrc[8 + stride] * m.MidRight) +
                                    (pSrc[2 + stride2] * m.BottomLeft) +
                                    (pSrc[5 + stride2] * m.BottomMid) +
                                    (pSrc[8 + stride2] * m.BottomRight))
                                / m.Factor) + m.Offset);

                        nPixel = Utils.Clamp(nPixel, 0, 255);
                        p[5 + stride] = (byte)nPixel;

                        // GREEN PIXEL
                        nPixel = (((
                                    (pSrc[1] * m.TopLeft) +
                                    (pSrc[4] * m.TopMid) +
                                    (pSrc[7] * m.TopRight) +
                                    (pSrc[1 + stride] * m.MidLeft) +
                                    (pSrc[4 + stride] * m.Pixel) +
                                    (pSrc[7 + stride] * m.MidRight) +
                                    (pSrc[1 + stride2] * m.BottomLeft) +
                                    (pSrc[4 + stride2] * m.BottomMid) +
                                    (pSrc[7 + stride2] * m.BottomRight))
                                / m.Factor) + m.Offset);

                        nPixel = Utils.Clamp(nPixel, 0, 255);
                        p[4 + stride] = (byte)nPixel;

                        // RED PIXEL
                        nPixel = (((
                                    (pSrc[0] * m.TopLeft) +
                                    (pSrc[3] * m.TopMid) +
                                    (pSrc[6] * m.TopRight) +
                                    (pSrc[0 + stride] * m.MidLeft) +
                                    (pSrc[3 + stride] * m.Pixel) +
                                    (pSrc[6 + stride] * m.MidRight) +
                                    (pSrc[0 + stride2] * m.BottomLeft) +
                                    (pSrc[3 + stride2] * m.BottomMid) +
                                    (pSrc[6 + stride2] * m.BottomRight))
                                / m.Factor) + m.Offset);


                        nPixel = Utils.Clamp(nPixel, 0, 255);
                        p[3 + stride] = (byte)nPixel;

                        // Moving to another pixel
                        p += 3;
                        pSrc += 3;
                    }
                }
            }

            // Unlock bits
            b.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);

            return (Image)b;
        }
    }
}