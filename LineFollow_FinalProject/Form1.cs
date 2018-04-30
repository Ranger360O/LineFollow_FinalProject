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
    public partial class Form1 : Form
    {
        private Thread _captureThread;
        private InputHandler videoIn = new InputHandler();
        private LineDraw lineDraw = new LineDraw();

        bool Flip = false;
        bool FirstRun = true;
        bool lines = false;
        bool FirstScan = true;
        bool enableSerial = false;
        bool didUTurn = false;

        private int SelectL;
        private int SelectR;
        private int SelectU;
        private int SelectD;
        int LastCom;
        Point topPoint;
        Point botPoint;

        Pen blackpen = new Pen(Color.Green, 3);

        int yPos = 100;
        int xPos = 100;


        String[] portNames = SerialPort.GetPortNames();

        const byte STOP = 0x7F;
        const byte FLOAT = 0x0F;
        const byte FORWARD = 0x5f;
        const byte BACKWARD = 0x6F;

        SerialPort _serialPort = new SerialPort("Com3", 2400);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            _captureThread = new Thread(DisplayWebcam);
            _captureThread.Start();

            //if (videoIn.setCamera(1))
            //{
            //    //Flip = true;
            //    videoIn.play();

            //    FirstRun = true;
            //    closeToolStripMenuItem.Enabled = true;
            //}

            //if (enableSerial)
            //{
                SerialStart();
            //}
        }

        private void DisplayWebcam()
        {
            while (true)
            {
                if (videoIn == null || !videoIn.isFrameAvailable())
                {
                    continue;
                }
                Image<Hsv, Byte> Default = videoIn.readFrame().Convert<Hsv, Byte>();

                if (FirstRun)
                {
                    setSliders(Default.Width, Default.Height);
                    FirstRun = false;
                }

                if (Flip)
                    CvInvoke.Flip(Default, Default, FlipType.Horizontal);

                Image<Hsv, Byte> TestImg = Default;
                TestImg.Erode(5).Dilate(5);
                TestImg = TestImg.SmoothGaussian(5);

                Image<Hsv, Byte> WorkImg = TestImg.Copy();


                /*HSV values [0-180, 0-255, 0-255]
                * 0/180 = red
                * 60 = green
                * 120 = blue
                */

                //output selected values and draw crosshares on center of screen;
                for (int x = 0; x < 5; x++)
                {
                    if (x != 3)
                    {
                        TestImg.Data[yPos, xPos - 3 + x, 2] = 0;
                    }
                }
                for (int y = 0; y < 7; y++)
                {
                    if (y != 3)
                        TestImg.Data[yPos - 3 + y, xPos, 2] = 0;
                }
                this.Invoke(new Action(() => label1.Text = $"Hue = {TestImg.Data[yPos, xPos, 0]}"));
                this.Invoke(new Action(() => label2.Text = $"Saturation = {TestImg.Data[yPos, xPos, 1]}"));
                this.Invoke(new Action(() => label3.Text = $"Value = {TestImg.Data[yPos, xPos, 2]}"));

                //Draw Boarder Lines(hue 60 = ignore points)
                if (lines)
                {
                    lineDraw.boarderLines(WorkImg, SelectL, SelectR, SelectU, SelectD);
                }

                int lastRowRed = 0;
                //For Selected Area, Change output colors based on what colors are seen (60,0,0 = default)
                for (int y = SelectU; y < SelectD; y++)
                {
                    int AvgX = 0;
                    int Counter = 0;
                    lastRowRed = 0;

                    for (int x = SelectL; x < SelectR; x++)
                    {
                        if ((TestImg.Data[y, x, 0] < 10 || TestImg.Data[y, x, 0] > 170) && TestImg.Data[y, x, 1] > 100) //Red
                        {
                            WorkImg.Data[y, x, 0] = 0;
                            WorkImg.Data[y, x, 1] = 255;
                            WorkImg.Data[y, x, 2] = 255;

                            lastRowRed++;
                        }
                        else if ((TestImg.Data[y, x, 1] < 35 /*&& TestImg.Data[y, x, 1] > 20*/) && TestImg.Data[y, x, 2] > 190) //white
                        {
                            WorkImg.Data[y, x, 0] = 120;
                            WorkImg.Data[y, x, 1] = 255;
                            WorkImg.Data[y, x, 2] = 255;

                            AvgX += x;
                            Counter++;
                        }
                        else //well, everything else
                        {
                            WorkImg.Data[y, x, 0] = 60;
                            WorkImg.Data[y, x, 1] = 0;
                            WorkImg.Data[y, x, 2] = 0;
                        }
                    }
                    if (Counter != 0)
                    {
                        AvgX /= Counter;

                        WorkImg.Data[y, AvgX, 0] = 90;
                        WorkImg.Data[y, AvgX, 1] = 255;
                        WorkImg.Data[y, AvgX, 2] = 255;

                        if (FirstScan)
                        {
                            topPoint = new Point { X = AvgX, Y = y };
                            FirstScan = false;
                        }
                        else
                        {
                            botPoint = new Point { X = AvgX, Y = y };
                        }
                    }
                }
                FirstScan = true;
                lineDraw.drawLine(WorkImg, topPoint, botPoint);
                this.Invoke(new Action(() => SlopeBox.Text = "" + lineDraw.getSlope()));
                int LineAvgX = (topPoint.X + botPoint.X) / 2;
                this.Invoke(new Action(() => AvgXText.Text = $"{LineAvgX}"));
                this.Invoke(new Action(() => label4.Text = $"{WorkImg.Width/3}"));

                if (lastRowRed > 10 && !didUTurn)
                {
                    //See red square, do U-Turn
                    this.Invoke(new Action(() => Direction.Text = "Saw Red, Do U-Turn"));
                    SerialWrite(FLOAT, FORWARD);
                    Thread.Sleep(1250);
                    //SerialWrite(FORWARD, FORWARD);
                    //Thread.Sleep(500);

                    didUTurn = true;
                }
                if (LineAvgX < WorkImg.Width/3)
                {
                    //Line average on Left side of screen
                    this.Invoke(new Action(() => label5.Text = $"Left Drive"));
                    LeftDrive();
                }
                else if (LineAvgX < (WorkImg.Width/3)*2)
                {
                    //Line average in center of screen
                    this.Invoke(new Action(() => label5.Text = $"Center Drive"));
                    CenterDrive();
                }
                else if (LineAvgX > (WorkImg.Width / 3) * 2)
                {
                    //line average on right side of screen
                    this.Invoke(new Action(() => label5.Text = $"Right Drive"));
                    RightDrive();
                }

                Default = Default.Resize(picBoxDef.Width, picBoxDef.Height, Emgu.CV.CvEnum.Inter.Linear);
                picBoxDef.Image = Default.Bitmap;
                WorkImg = WorkImg.Resize(picWorkImg.Width, picWorkImg.Height, Emgu.CV.CvEnum.Inter.Linear);
                picWorkImg.Image = WorkImg.Bitmap;
                TestImg = TestImg.Resize(picGrayImg.Width, picGrayImg.Height, Emgu.CV.CvEnum.Inter.Linear);
                picGrayImg.Image = TestImg.Bitmap;

            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            videoIn.Dispose();
            _captureThread.Abort();
        }

        private void SelectorL_Scroll(object sender, EventArgs e)
        {
            SelectL = SelectorL.Value;
            SelectLabelL.Text = $"Left Value: {SelectL}";
        }

        private void SelectorR_Scroll(object sender, EventArgs e)
        {
            SelectR = SelectorR.Value;
            SelectLabelR.Text = $"Right Value: {SelectR}";
        }

        private void UpSelector_Scroll(object sender, EventArgs e)
        {
            SelectU = UpSelector.Value;
            LabelUp.Text = $"Up Value: {SelectU}";
        }

        private void DownSelector_Scroll(object sender, EventArgs e)
        {
            SelectD = DownSelector.Value;
            LabelDown.Text = $"Down Value: {SelectD}";
        }


        public void SerialStart()
        {
            _serialPort.DataBits = 8;
            _serialPort.Parity = Parity.None;
            _serialPort.StopBits = StopBits.Two;
            //_serialPort.Open();
        }

        private void SerialWrite(byte lCommand, byte rCommand)
        {
            byte[] buffer = { 0x01, lCommand, rCommand };
            if (enableSerial)
            {
                _serialPort.Write(buffer, 0, 3);
            }
        }

        private void setSliders(int width, int height)
        {
            this.Invoke(new Action(() => SelectorL.Maximum = (width / 2) - 3));
            this.Invoke(new Action(() => SelectorR.Minimum = (width / 2) + 3));
            this.Invoke(new Action(() => SelectorR.Maximum = width - 1));

            this.Invoke(new Action(() => UpSelector.Maximum = (height / 2) - 3));
            this.Invoke(new Action(() => DownSelector.Minimum = (height / 2) + 3));
            this.Invoke(new Action(() => DownSelector.Maximum = height - 1));

            this.Invoke(new Action(() => SelectorL.Value = width / 6));
            this.Invoke(new Action(() => SelectorR.Value = width / 6 * 5));
            this.Invoke(new Action(() => UpSelector.Value = height / 6));
            this.Invoke(new Action(() => DownSelector.Value = height / 6 * 5));

            this.Invoke(new Action(() => SelectL = 1));
            this.Invoke(new Action(() => SelectR = width -1));
            this.Invoke(new Action(() => SelectU = 210));
            this.Invoke(new Action(() => SelectD = height -1));

            //this.Invoke(new Action(() => SelectL = SelectorL.Value));
            //this.Invoke(new Action(() => SelectR = SelectorR.Value));
            //this.Invoke(new Action(() => SelectU = UpSelector.Value));
            //this.Invoke(new Action(() => SelectD = DownSelector.Value));

            this.Invoke(new Action(() => xPosSlider.Maximum = width - 4));
            this.Invoke(new Action(() => xPosSlider.Value = width/2));
            this.Invoke(new Action(() => xPos = xPosSlider.Value));

            this.Invoke(new Action(() => yPosSlider.Maximum = height - 4));
            this.Invoke(new Action(() => yPosSlider.Value = height/2));
            this.Invoke(new Action(() => yPos = yPosSlider.Value));
        }

        private void s1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            videoIn = new InputHandler();
            if (videoIn.setImage("Video Files\\s1"))
            {
                videoIn.play();

                FirstRun = true;
                closeToolStripMenuItem.Enabled = true;
            }
        }

        private void s2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (videoIn.setImage("Video Files\\s2"))
            {
                videoIn.play();

                FirstRun = true;
                closeToolStripMenuItem.Enabled = true;
            }
        }

        private void s3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (videoIn.setImage("Video Files\\s3"))
            {
                videoIn.play();

                FirstRun = true;
                closeToolStripMenuItem.Enabled = true;
            }
        }

        private void s4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (videoIn.setImage("Video Files\\s4"))
            {
                videoIn.play();

                FirstRun = true;
                closeToolStripMenuItem.Enabled = true;
            }
        }

        private void s5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (videoIn.setImage("Video Files\\s5"))
            {
                videoIn.play();

                FirstRun = true;
                closeToolStripMenuItem.Enabled = true;
            }
        }

        private void s6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (videoIn.setImage("Video Files\\s6"))
            {
                videoIn.play();

                FirstRun = true;
                closeToolStripMenuItem.Enabled = true;
            }
        }

        private void v1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (videoIn.setVideo("Video Files\\v1"))
            {
                videoIn.play();

                FirstRun = true;
                closeToolStripMenuItem.Enabled = true;
            }
        }

        private void builtInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (videoIn.setCamera(0))
            {
                Flip = true;
                videoIn.play();

                FirstRun = true;
                closeToolStripMenuItem.Enabled = true;
            }
        }

        private void externalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (videoIn.setCamera(1))
            {
                //Flip = true;
                videoIn.play();

                FirstRun = true;
                closeToolStripMenuItem.Enabled = true;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            videoIn.Dispose();
            FirstRun = true;

            openToolStripMenuItem.Enabled = true;
            closeToolStripMenuItem.Enabled = false;
        }

        private void EnableLines_CheckedChanged(object sender, EventArgs e)
        {
            if (lines)
                lines = false;
            else
                lines = true;
        }

        private void yPosSlider_Scroll(object sender, EventArgs e)
        {
            yPos = yPosSlider.Value;
            yPosText.Text = $"Y_Pos: {yPos}";
        }

        private void xPosSlider_Scroll(object sender, EventArgs e)
        {
            xPos = xPosSlider.Value;
            xPosText.Text = $"X_Pos: {xPos}";
        }

        private void OpenSerial_CheckedChanged(object sender, EventArgs e)
        {
            if (enableSerial)
                enableSerial = false;
            else
                enableSerial = true;
        }

        private void LeftDrive()
        {
            //Center of line on left of screen

            switch (lineDraw.useSlopeLeft())        //Write commands if vehicle should turn left, right, or go straight
            {
                case 1:
                    SerialWrite(BACKWARD, FORWARD);
                    this.Invoke(new Action(() => Direction.Text = "Hard Left"));
                    LastCom = 1;
                    break;
                case 2:
                    SerialWrite(FLOAT, FORWARD);
                    this.Invoke(new Action(() => Direction.Text = "Soft Left"));
                    LastCom = 2;
                    break;
                case 3:
                    SerialWrite(FORWARD, FORWARD);
                    this.Invoke(new Action(() => Direction.Text = "Forward"));
                    LastCom = 3;
                    break;
                case 4:
                    SerialWrite(FORWARD, FLOAT);
                    this.Invoke(new Action(() => Direction.Text = "Soft Right"));
                    LastCom = 4;
                    break;
                case 5:
                    SerialWrite(FORWARD, BACKWARD);
                    this.Invoke(new Action(() => Direction.Text = "Hard Right"));
                    LastCom = 5;
                    break;
                case 0:
                    SerialWrite(STOP, STOP);
                    break;
                default:
                    switch (LastCom)
                    {
                        case '1':
                            SerialWrite(BACKWARD, FORWARD);
                            break;
                        case '2':
                            SerialWrite(FLOAT, FORWARD);
                            break;
                        case '3':
                            SerialWrite(FORWARD, FORWARD);
                            break;
                        case '4':
                            SerialWrite(FORWARD, FLOAT);
                            break;
                        case '5':
                            SerialWrite(FORWARD, BACKWARD);
                            break;
                        default:
                            SerialWrite(STOP, STOP);
                            break;
                    }
                    break;
            }
        }

        private void CenterDrive()
        {
            switch (lineDraw.useSlopeCenter())        //Write commands if vehicle should turn left, right, or go straight
            {
                case 1:
                    SerialWrite(BACKWARD, FORWARD);
                    this.Invoke(new Action(() => Direction.Text = "Hard Left"));
                    LastCom = 1;
                    break;
                case 2:
                    SerialWrite(FLOAT, FORWARD);
                    this.Invoke(new Action(() => Direction.Text = "Soft Left"));
                    LastCom = 2;
                    break;
                case 3:
                    SerialWrite(FORWARD, FORWARD);
                    this.Invoke(new Action(() => Direction.Text = "Forward"));
                    LastCom = 3;
                    break;
                case 4:
                    SerialWrite(FORWARD, FLOAT);
                    this.Invoke(new Action(() => Direction.Text = "Soft Right"));
                    LastCom = 4;
                    break;
                case 5:
                    SerialWrite(FORWARD, BACKWARD);
                    this.Invoke(new Action(() => Direction.Text = "Hard Right"));
                    LastCom = 5;
                    break;
                case 0:
                    SerialWrite(STOP, STOP);
                    break;
                default:
                    switch (LastCom)
                    {
                        case '1':
                            SerialWrite(BACKWARD, FORWARD);
                            break;
                        case '2':
                            SerialWrite(FLOAT, FORWARD);
                            break;
                        case '3':
                            SerialWrite(FORWARD, FORWARD);
                            break;
                        case '4':
                            SerialWrite(FORWARD, FLOAT);
                            break;
                        case '5':
                            SerialWrite(FORWARD, BACKWARD);
                            break;
                        default:
                            SerialWrite(STOP, STOP);
                            break;
                    }
                    break;
            }
        }

        private void RightDrive()
        {
            switch (lineDraw.useSlopeRight())        //Write commands if vehicle should turn left, right, or go straight
            {
                case 1:
                    SerialWrite(BACKWARD, FORWARD);
                    this.Invoke(new Action(() => Direction.Text = "Hard Left"));
                    LastCom = 1;
                    break;
                case 2:
                    SerialWrite(FLOAT, FORWARD);
                    this.Invoke(new Action(() => Direction.Text = "Soft Left"));
                    LastCom = 2;
                    break;
                case 3:
                    SerialWrite(FORWARD, FORWARD);
                    this.Invoke(new Action(() => Direction.Text = "Forward"));
                    LastCom = 3;
                    break;
                case 4:
                    SerialWrite(FORWARD, FLOAT);
                    this.Invoke(new Action(() => Direction.Text = "Soft Right"));
                    LastCom = 4;
                    break;
                case 5:
                    SerialWrite(FORWARD, BACKWARD);
                    this.Invoke(new Action(() => Direction.Text = "Hard Right"));
                    LastCom = 5;
                    break;
                case 0:
                    SerialWrite(STOP, STOP);
                    break;
                default:
                    switch (LastCom)
                    {
                        case '1':
                            SerialWrite(BACKWARD, FORWARD);
                            break;
                        case '2':
                            SerialWrite(FLOAT, FORWARD);
                            break;
                        case '3':
                            SerialWrite(FORWARD, FORWARD);
                            break;
                        case '4':
                            SerialWrite(FORWARD, FLOAT);
                            break;
                        case '5':
                            SerialWrite(FORWARD, BACKWARD);
                            break;
                        default:
                            SerialWrite(STOP, STOP);
                            break;
                    }
                    break;
            }
        }
    }
}

/*                    
*/