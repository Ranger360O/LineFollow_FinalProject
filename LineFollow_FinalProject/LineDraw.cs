using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.IO.Ports;

namespace LineFollow_FinalProject
{
    class LineDraw
    {
        private Point first;
        private Point last;
        double slope;
        double lastSlope = 1;

        public double getSlope(Point p1, Point p2)
        {
            slope = (double)(p1.Y - p2.Y) / (p1.X - p2.X);
            return slope;
        }
        public double getSlope()
        {
            slope = (double)(first.Y - last.Y) / (first.X - last.X);
            return slope;
        }

        public void drawLine(Image<Hsv,Byte> image, Point p1, Point p2)
        {
            first = p1;
            last = p2;
            CvInvoke.Line(image, p1, p2, new Bgr(255, 255, 255).MCvScalar, 3);
        }

        public void boarderLines(Image<Hsv,Byte> image, int L, int R, int U, int D)
        {
            for (int y = 0; y < image.Height; y++)
            {
                image.Data[y, L, 0] = 60;
                image.Data[y, L, 1] = 255;
                image.Data[y, L, 2] = 255;
                image.Data[y, R, 0] = 60;
                image.Data[y, R, 1] = 255;
                image.Data[y, R, 2] = 255;
            }
            for (int x = 0; x < image.Width; x++)
            {
                image.Data[U, x, 0] = 60;
                image.Data[U, x, 1] = 255;
                image.Data[U, x, 2] = 255;
                image.Data[D, x, 0] = 60;
                image.Data[D, x, 1] = 255;
                image.Data[D, x, 2] = 255;
            }
        }

        public int useSlopeCenter()
        {
            if (lastSlope * slope > 0)
            {
                lastSlope = slope;
                if (slope < 0) //Looks like => /
                {
                    if (slope > -1)
                        return 5;
                    else if (slope < -4)
                        return 3;
                    else
                        return 4;
                }
                else if (slope > 0) //looks like => \
                {
                    if (slope < 1)
                        return 1;
                    else if (slope > 4)
                        return 3;
                    else
                        return 2;
                }
                else //looks like => | or -
                    return 0;
            }
            else //Command was not same direction as last
            {
                lastSlope = slope;
                return 6;
            }
        }

        public int useSlopeLeft()
        {
            if (lastSlope * slope > 0)
            {
                lastSlope = slope;
                if (slope < 0) //Looks like => /
                {
                    if (slope > -0.25)
                        return 5; //Hard right
                    else if (slope < -2)
                        return 3; //Forward
                    else
                        return 4; //Soft right
                }
                else if (slope > 0) //looks like => \
                {
                    if (slope < 0.25)
                        return 1;
                    else if (slope > 2)
                        return 3;
                    else
                        return 2;
                }
                else //looks like => | or -
                    return 0;
            }
            else //Command was not same direction as last
            {
                lastSlope = slope;
                return 6;
            }
        }

        public int useSlopeRight()
        {
            if (lastSlope * slope > 0)
            {
                lastSlope = slope;
                if (slope < 0) //Looks like => /
                {
                    if (slope > -0.25)
                        return 5;
                    else if (slope < -2)
                        return 3;
                    else
                        return 4;
                }
                else if (slope > 0) //looks like => \
                {
                    if (slope < 0.25)
                        return 1;
                    else if (slope > 2)
                        return 3;
                    else
                        return 2;
                }
                else //looks like => | or -
                    return 0;
            }
            else //Command was not same direction as last
            {
                lastSlope = slope;
                return 6;
            }
        }
    }
}
