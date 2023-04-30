
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Events;


using static System.Net.Mime.MediaTypeNames;

namespace Rotoscope
{
    /// <summary>
    /// Main class for managing making a rotoscoped movie.
    /// </summary>
    public class MovieMaker
    {
        #region save locations

        private int clipCount = 0;
        private string clipSaveName = "clip_";
        private string clipSavePath = "clips\\";
        private int clipSize = 120;
        private string frameSaveName = "frame_";
        private string frameSavePath = "frames\\";
        private string tempAudioSavePath = "temp\\tempAudioOutput.wav";
        private string tempVideoSavePath = "temp\\tempVideoOutput.mp4";
        private Bitmap bird;
        private Bitmap basket;
        private Bitmap me;
        private Bitmap rabbit;
        private Bitmap leaf;
        private int currLoc = 0;
        #endregion


        #region Properties

        /// <summary>
        /// The background audio for the output movie.
        /// </summary>
        public Sound Audio { get => backgroundAudio; set => backgroundAudio = value; }

        /// <summary>
        /// Current Frame being shown
        /// </summary>
        public Frame CurFrame { get => curFrame; }

        /// <summary>
        /// Current frame count written
        /// </summary>
        public int CurFrameCount { get => framenum; }

        /// <summary>
        /// Area to draw the video frame
        /// </summary>
        public Rectangle DrawArea { set => drawArea = value; }

        /// <summary>
        /// Frames per second
        /// </summary>
        public double FPS { get => fps; set => fps = value; }

        /// <summary>
        /// Height of the movie
        /// </summary>
        public int Height { get => height; set => height = value; }

        /// <summary>
        /// Movie from which to pull frames
        /// </summary>
        public Movie SourceMovie
        {
            get => sourceMovie;
            set
            {
                sourceMovie = value;
                fps = sourceMovie.FrameRate;
            }
        }

        /// <summary>
        /// Width of the movie
        /// </summary>
        public int Width { get => width; set => width = value; }

        private Sound backgroundAudio;
        private Frame curFrame;
        private double fps = 30;
        private int framenum = 0;
        private int height = 720;
        private double outputTime = 0;
        private Movie sourceMovie = null;
        private int width = 1280;
        private ProgressBar bar;
        private Rectangle drawArea = new Rectangle(100, 100, 100, 100);
        private string fmt = "00000";
        private MainForm form;
        private Font drawFont = new Font("Arial", 16);
        private SolidBrush drawBrush = new SolidBrush(Color.Red);
        private string processing = "";
        #endregion
        Rotoscope roto = new Rotoscope();
        private Frame initial = new Frame();
        private Color color = Color.Blue;
        private int lineWidth = 1;
        /// <summary>
        /// Constructor for a movie maker that taken in the form in which to draw the results
        /// </summary>
        /// <param name="form"></param>
        public MovieMaker(MainForm form)
        {
            Close();
            this.form = form;
            curFrame = new Frame(width, height);

            if (!Directory.Exists(frameSavePath))
                Directory.CreateDirectory(frameSavePath);

            if (!Directory.Exists(frameSavePath))
                Directory.CreateDirectory(frameSavePath);

            if (!Directory.Exists(clipSavePath))
                Directory.CreateDirectory(clipSavePath);

            bird = new Bitmap("res\\birdie.png");
            basket = new Bitmap("res\\basket.png");
            rabbit = new Bitmap("res\\rabbit.png");
            me = new Bitmap("res\\me.png");
          
        }

        /// <summary>
        /// Release data sources, and clean up temporary files
        /// </summary>
        public void Close()
        {
            backgroundAudio = null;
            framenum = 0;

            if (Directory.Exists(frameSavePath))
            {
                string[] files = Directory.GetFiles(frameSavePath);
                foreach (string file in files)
                {
                    File.Delete(file);
                }
            }

            if (Directory.Exists(clipSavePath))
            {
                string[] files = Directory.GetFiles(clipSavePath);
                foreach (string file in files)
                {
                    File.Delete(file);
                }
            }
        }
        public void DrawLine(int x1, int y1, int x2, int y2)
        {
            curFrame.DrawLine(x1, y1, x2, y2, color,lineWidth);

        }
        /// <summary>
        /// Handles all mouse events
        /// </summary>
        /// <param name="x">X pixel</param>
        /// <param name="y">Y pixel</param>
        public void Mouse(int x, int y)
        {
            roto.AddToDrawList(framenum, new Point(x, y));
            BuildFrame();
        }


        /// <summary>
        /// Draw the current state of the makers
        /// </summary>
        /// <param name="graphics">graphics reference to drawn area</param>
        public void OnDraw(Graphics graphics)
        {
            curFrame.OnDraw(graphics, drawArea);

            graphics.DrawString(processing, drawFont, drawBrush, 100, 100);

            if (processing == "Completed")
                processing = "";
        }


        /// <summary>
        /// Destructor to clean up files that were made during processing
        /// </summary>
        ~MovieMaker()
        {
            Close(); 
        }


        #region Frame load and save

        /// <summary>
        /// Creates one frame. If a input movie is given, and the are frame left, the frame is pulled from the 
        /// next frame in the movie. If not, a blank, black frame is generated. 
        /// 
        /// Loading is done asyncrounously
        /// </summary>
        /// <returns>a generic task </returns>
        public void CreateOneFrame()
        {  
            curFrame.Clear();

            if (sourceMovie != null)
            {

                Bitmap newImage = sourceMovie.LoadNextFrameImage();
               
                //sanity chack that an image is there
                if (newImage != null)
                {
                    try
                    {
                        newImage = imageComposition(newImage).toBitmap;
                        Graphics g = Graphics.FromImage(curFrame.Image);
                        RectangleF srcRect = new RectangleF(0.0F, 0.0F, 1280.0F, 720.0F);
                        GraphicsUnit units = GraphicsUnit.Pixel;

                        

                        g.DrawImage(newImage, 0, 0,srcRect,units); //this is MUCH faster than looping through
                        newImage.Dispose(); // release the image

                        //Save a copy of the original, unmodified image
                       initial = new Frame(curFrame.Image);

                        // Write any saved drawings into the frame
                        BuildFrame();

                        
                    }
                    catch (Exception)
                    {
                        //shouldn't happen, but...
                        Debug.WriteLine("Skipped frame!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                }

                form.Invalidate();
            }
        }

        RasterImage  imageComposition(Bitmap im)
        {
            RasterImage image = new RasterImage(im);
            RasterImage background = new RasterImage(Properties.Resources.background);
            RasterImage garbageMask = new RasterImage(image.Width,image.Height);
            //GARBAGEMASK
            MakeSobelFilter(image,garbageMask);
            RasterImage newImage = new RasterImage(im);
            int height = image.Height;
            int width = image.Width;
            double a1 = 10;
            double a2 = 1.2;
            for (int r = 0; r < height && r < background.Height; r++)
            {
                for (int c = 0; c < width && r < background.Width; c++)
                {
                    Color color = image[c, r];
                    Color back = background[c, r];
                    //EQUATION
                    double alpha = ColorHelpers.Clamp((1 - a1) * (color.G - (a2 * color.R))) ;
                     Color cg = garbageMask[c, r];
                    //GARBAGEMASK
                    newImage[c, r] = ColorHelpers.ColorSubtract(ColorHelpers.ColorMultiply(alpha, color, back), cg);
                }
            }
            return newImage;
        }

        private void BuildFrame()
        {

            curFrame = new Frame(initial.Image);


            // Write any saved drawings into the frame
            LinkedList<Point> drawList = roto.GetFromDrawList(framenum);
            if (drawList != null)
            {
                foreach (Point p in drawList)
                {
                    curFrame.DrawDot(p.X, p.Y);
                }
            }
            LinkedList<Line> lines = roto.GetFromLineList(framenum);
            if (lines != null)
            {
                foreach (Line l in lines)
                {
                    curFrame.DrawLine(l.p1.X, l.p1.Y,l.p2.X,l.p2.Y,color,lineWidth) ;
                }
            }
            LinkedList<Dictionary<Point,string>> images = roto.GetFromImageList(framenum);
            if (images != null)
            {
                foreach (Dictionary<Point, string> i in images)
                {
                    Bitmap img;
                    Point p = new Point(i.Keys.ElementAt(0).X, i.Keys.ElementAt(0).Y );
                    switch(i.Values.ElementAt(0))
                    {
                        case "bird":
                            img = bird;
                            p = new Point(p.X - (img.Width / 2), p.Y - (img.Height) + 5);
                            break;
                        case "basket":
                            //BASKET
                            img = basket;
                            p = new Point( p.X - (img.Width / 2),p.Y - (img.Height) + 50);
                            
                            break;
                        default:
                            img = me;
                            p = new Point(p.X - (img.Width / 2) + 20, p.Y - (img.Height/2) - 50);
                            break;
                    }


                    curFrame.DrawImage(img, p);
                    //TRANSLATE
                    Point bPoint = translateBird(p.X + 95, p.Y - 30);
                    curFrame.DrawImage(bird, bPoint);
                   



                }
            }
            Point pt = new Point(532 - (me.Width / 2) + 20, 102 - (me.Height / 2) - 50);
            curFrame.DrawImage(me, pt);
            curFrame.DrawImage(rabbit, translateBunny());
            //curFrame.DrawImage(leaf,new Point(300, 500));
            form.Invalidate();
        }

        public static void MakeSobelFilter(RasterImage initImage, RasterImage postImage)
        {
            float initHeight = initImage.Height;
            float initWidth = initImage.Width;


            int[,] sorbelHMatrix =
            {
                {2,2,4,2,2},
                {1,1,2,1,1},
                {0,0,0,0,0},
                {-1,-1,-2,-1,-1},
                {-2,-2,-4,-2,-2}
             };
            int[,] sorbelVMatrix =
            {
              {2,1,0,-1,-2 },
              {2,1,0,-1,-2 },
              {4,2,0,-2,-4},
              {2,1,0,-1,-2 },
              {2,1,0,-1,-2 }
            };

            for (int r = 0; r < initHeight; r++)
            {

                for (int c = 0; c < initWidth; c++)
                {

                    int red = 0;
                    int blue = 0;
                    int green = 0;
                    int redY = 0;
                    int blueY = 0;
                    int greenY = 0;

                    for (int i = -2; i < 3; i++)
                    {
                        for (int j = -2; j < 3; j++)
                        {
                            if (c + j >= 0 && c + j < initWidth && r + i >= 0 && r + i < initHeight)
                            {
                                Color temp = initImage[c + j, r + i];
                                int num = sorbelHMatrix[j + 2, i + 2];
                                red += (num * temp.R);
                                blue += (num * temp.B);
                                green += (num * temp.G);
                                num = sorbelVMatrix[j + 2, i + 2];
                                redY += (num * temp.R);
                                blueY += (num * temp.B);
                                greenY += (num * temp.G);
                            }
                        }
                    }
                    Color GX = Color.FromArgb(red > 255 ? 255 : red < 0 ? 0 : red, green > 255 ? 255 : green < 0 ? 0 : green, blue > 255 ? 255 : blue < 0 ? 0 : blue);
                    Color GY = Color.FromArgb(redY > 255 ? 255 : redY < 0 ? 0 : redY, greenY > 255 ? 255 : greenY < 0 ? 0 : greenY, blueY > 255 ? 255 : blueY < 0 ? 0 : blueY);

                    red = (int)Math.Sqrt((GX.R * GX.R) + (GY.R * GY.R));
                    green = (int)Math.Sqrt((GX.G * GX.G) + (GY.G * GY.G));
                    blue = (int)Math.Sqrt((GX.B * GX.B) + (GY.B * GY.B));

                    if (red > 254 || green > 254 || blue > 254)
                    {
                        red = 255;
                        green = 255;
                        blue = 255;

                    }
                    else
                    {
                        red = 0;
                        blue = 0;
                        green = 0;

                    }    
                    postImage[c, r] = Color.FromArgb( red, green,blue) ;

                }
            }

           
        }

        public void changeColor()
        {
            color = color == Color.Red? Color.Blue : Color.Red;
        }
        private bool right = false;
        private bool jump = true;
        private int jumpCnt = 0;
        private int bunnyLoc = 0;
        private int bunnyJumpCnt = 0;
        private bool bunnyJump = true;

        public Point translateBunny()
        {
            Point p = new Point(1100, 550);
            bunnyJumpCnt++;
            bunnyLoc++;
            if (bunnyJumpCnt >= 20)
            {
                bunnyJumpCnt = 0;
                bunnyJump = bunnyJump == true ? false : true;
            }
            if (bunnyJump)
            {
                 p.Y = 550 - (bunnyJumpCnt * 2);
            }
            else
            {
                p.Y = 510 + (bunnyJumpCnt * 2);
            }
            p.X = 1100 - (bunnyLoc * 2);
            if (p.X < 0)
            {
                p.X = 1100;
                bunnyLoc = 0;
            }
           
            return p;
        }
        public Point translateBird(int x, int y)
        {
            //TRANSLATE
            Point p = new Point();
            p.Y = y;
            currLoc++;
            jumpCnt++;
            if(currLoc >= 43)
            {
                currLoc= 0;
                right = right == true ? false : true;
            }
            if(jumpCnt >= 10)
            {
                jumpCnt = 0;
                jump = jump == true? false : true;
            }
            if(!right)
            {
                p.X = x - (currLoc * 3);
            }
            else
            {
                p.X = x - 130 + (currLoc * 3);
            }
            if (jump)
            {
                p.Y = y - jumpCnt;
            }
            else
            {
                p.Y = y + jumpCnt;
            }
            //p.X = currLoc;
            
                return p;
        }

        public void changeWidth()
        {
            width = width == 1 ? 5 : 1;
        }
        public void DrawLineOnVid()
        {
             roto.DrawLine(framenum);
            BuildFrame();
        }
        /// <summary>
        /// Takes the currently made clips, and audio if given, and converts them into a movie. 
        /// It will save in in the given location.
        /// 
        /// This is done asyncrounously.
        /// </summary>
        /// <param name="savePath">the location to save the movie</param>
        /// <returns>generic task</returns>
        public void ProcClipVideo(string savePath)
        {
            //sanity check for source images
            if (framenum <= 0)
            {
                MessageBox.Show("No frames currently generated", "Processing error");
                return;
            }

            processing = "Write remaining frames...";
            form.Invalidate();

            //some frames remaining? write to clip
            if (Directory.GetFiles(frameSavePath).Count() > 0)
            {
                Task taskFrames = Task.Run(() => WriteClip());
                taskFrames.Wait();
            }

            outputTime = (double)(framenum) / fps;

            //concatenate clip to the full movie first

            processing = "Concatenating clips..";
            form.Invalidate();

            //one clip, rename to output
            if (Directory.GetFiles(clipSavePath).Count() <= 1)
            {
                string file = Directory.GetFiles(clipSavePath).First();
                if (File.Exists(tempVideoSavePath))
                {
                    File.Delete(tempVideoSavePath);
                }
                File.Move(file, tempVideoSavePath);
            }
            else
            {
                //more than one clip, concat
                try
                {
                    Task taskConcat = Task.Run(() => ConcatClips());
                    taskConcat.Wait();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Processing error");
                }
            }


            //find silent video location
            Task<IMediaInfo> taskVid = Task.Run(() => FFmpeg.GetMediaInfo(tempVideoSavePath));
            IMediaInfo mediaInfoVid = taskVid.Result;

            //grab the video stream 
            IVideoStream video = mediaInfoVid.VideoStreams.First();

            //if there is a sound object, pull the audio information
            IMediaInfo mediaInfo = null;
            if (Audio != null)
            {
                Task<IMediaInfo> taskAudio = Task.Run(() => 
                                FFmpeg.GetMediaInfo(backgroundAudio.Filename));

                mediaInfo = taskAudio.Result;
            }

            try
            {
                processing = "Adding audio...";
                form.Invalidate();

                //make a new video (overwrite if needed), with the given video stream
                IConversion convert = FFmpeg.Conversions.New()
                    .AddStream(video)
                    .SetOutput(savePath)
                    .SetFrameRate(fps)
                    .SetOverwriteOutput(true);

                //if there is audio, add that stream
                if (mediaInfo != null)
                {
                    convert.AddStream(mediaInfo.AudioStreams);
                }

                //monitor and onvert
                Task taskConvert = Task.Run(() => convert.Start());
                taskConvert.Wait();

                processing = "Completed";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Processing error");
            }
        }

        /// <summary>
        /// Takes the currently made frames, and audio if given, and converts them into a movie. 
        /// It will save in in the given location.
        /// 
        /// This is done asyncrounously.
        /// </summary>
        /// <param name="savePath">the location to save the movie</param>
        public async void ProcFrameVideo(string savePath)
        {
            //sanity check for source images
            if (framenum <= 0)
            {
                MessageBox.Show("No frames currently generated", "Processing error");
                return;
            }

            bar = new ProgressBar();
            bar.Show();

            //if there is a sound object, pull the audio
            IMediaInfo mediaInfo = null;

            //check if audio is avilable
            if (backgroundAudio != null)
            {
                //save the file locally for ease
                string tempAudio = tempAudioSavePath;
                if (File.Exists(tempAudio))
                {
                    File.Delete(tempAudio);
                }
                backgroundAudio.Save(tempAudio, SoundFileTypes.MP3);

                mediaInfo = await FFmpeg.GetMediaInfo(backgroundAudio.Filename);
            }

            try
            {

                //grab file list, and setup for stitching
                List<string> files = Directory.EnumerateFiles(frameSavePath).ToList();
                outputTime = (double)files.Count / fps;

                //make a new file, overwrite if needed, with the FPS, and using the mp4 file format for movie frames
                IConversion convert = FFmpeg.Conversions.New()
                    .SetOverwriteOutput(true)
                    .SetInputFrameRate(fps)
                    .BuildVideoFromImages(files)
                    .SetFrameRate(fps)
                    .SetPixelFormat(Xabe.FFmpeg.PixelFormat.yuv420p)
                    .SetOutput(savePath);

                //if there is audio, add that stream
                if (mediaInfo != null) {
                    convert.AddStream(mediaInfo.AudioStreams);
                }

                //monitor and onvert
                convert.OnProgress += Progress;
                await convert.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Processing error");
            }
            finally
            {
                bar.Dispose();
            }
        }

        /// <summary>
        /// Creates a image file with the current frame to later be used in making the movie.
        /// </summary>
        /// <returns>generic task</returns>
        public void WriteFrame()
        {
            string name = frameSavePath + frameSaveName + framenum.ToString(fmt) + ".png";

            curFrame.SaveFile(name, ImageFormat.Png);
            framenum++;

            if (framenum % clipSize == 0)
            {
                Task task = Task.Run(() => WriteClip());
                task.Wait();
            }
        }

        /// <summary>
        /// Helper function to concatenate saved, silent, clips in the clip directory
        /// </summary>
        /// <param name="progressBar">should a progress bar be shown</param>
        /// <returns></returns>
        private async Task ConcatClips()
        {
            string[] files = Directory.GetFiles(clipSavePath);

            //nothing to do
            if (files.Length <= 1)
                return;

            try
            {

                IConversion result = await Concatenate(tempVideoSavePath, files);
                await result.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Concatenate failure");
            }
        }


        /// <summary>
        /// Concatenate a list of videos together with no sound.
        /// </summary>
        /// <param name="output">where to save the result</param>
        /// <param name="inputVideos">a list of video file names to concatenate</param>
        /// <returns>a conversion interface that can be started later</returns>
        private async Task<IConversion> Concatenate(string output, params string[] inputVideos)
        {
            if (inputVideos.Length <= 1)
            {
                throw new ArgumentException("You must provide at least 2 files for the concatenation to work", "inputVideos");
            }

            var mediaInfos = new List<IMediaInfo>();

            //make a new video, and overwite old video if there
            IConversion conversion = FFmpeg.Conversions.New().SetOverwriteOutput(true);

            //for all videos, add them to the list
            foreach (string inputVideo in inputVideos)
            {
                IMediaInfo mediaInfo = await FFmpeg.GetMediaInfo(inputVideo);

                mediaInfos.Add(mediaInfo);
                conversion.AddParameter($"-i \"{inputVideo}\" ");
            }

            //set up FFmpeg command line argumetns to concatenate
            conversion.AddParameter($"-filter_complex \"");
            conversion.AddParameter($"concat=n={inputVideos.Length}:v=1:a=0 [v]\" -map \"[v]\"");

            return conversion.SetOutput(output);
        }

        /// <summary>
        /// Monitoring function
        /// </summary>
        /// <param name="o">the objec that sent the event</param>
        /// <param name="args">details aboutthe evernt and progress</param>
        private void Progress(object o, ConversionProgressEventArgs args)
        {
            double percent = args.Duration.TotalSeconds / outputTime;

            bar.UpdateProgress(percent);
        }


        /// <summary>
        /// Save a set of frames to a movie clip. This acts as cacheing 
        /// as movie clips take less space than idependent frames.
        /// </summary>
        /// <returns>generic task</returns>
        private async Task WriteClip()
        {
            string name = clipSavePath + clipSaveName + clipCount.ToString(fmt) + ".mp4";

            try
            {
                //grab file list, and setup for stitching
                List<string> files = Directory.EnumerateFiles(frameSavePath).ToList();

                Debug.WriteLine("Frames: " + files.ToString());
                outputTime = (double)files.Count / fps; //length of time to monitor progress

                //make a new mp4, with the curent video FPS, and frame images. Overwrite allowed
                IConversion convert = FFmpeg.Conversions.New()
                    .SetOverwriteOutput(true)
                    .SetInputFrameRate(fps)
                    .BuildVideoFromImages(files)
                    .SetFrameRate(fps)
                    .SetPixelFormat(Xabe.FFmpeg.PixelFormat.yuv420p)
                    .SetOutput(name);

                await convert.Start();

                //memory cleanup as frame files are no longer needed
                foreach (string file in files)
                {
                    MainForm.VolitilePermissionDelete(file);
                }
                clipCount++;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Clip save error");
            }
        }

        public bool OnSaveRotoscope(string filename)
        {
            //
            // Open an XML document
            //
            XmlDocument doc = new XmlDocument();

            //
            // Make first node
            XmlElement root = doc.CreateElement("movie");

            //
            // Have children save inside this node
            //
            roto.OnSaveRotoscope(doc, root);

            //Save the resulting DOM tree to a file
            doc.AppendChild(root);

            try
            {
                //
                // Make the output indented, and save
                //
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(filename, settings);
                doc.Save(writer);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Save Rotoscope Error");
                return false;
            }

            return true;
        }
        public void makeColor(Color c)
        {
            color = c;
            if(color == Color.Red || color == Color.Green)
                lineWidth = 5;
            else
                lineWidth= 1;
            string filename = "C:\\Users\\7555105\\Desktop\\MultiMedia\\Projects\\RotoScope\\Rotoscope\\res\\red.xml";
           OnOpenRotoscope(filename);
           
        }
        public void makeImage(string type)
        {
            //BASKET
            roto.makeImage(framenum,type);
            BuildFrame();
        }

        public void OnOpenRotoscope(string filename)
        {

            //
            // Open an XML document
            //
            filename = "C:\\Users\\7555105\\Desktop\\MultiMedia\\Projects\\RotoScope\\Rotoscope\\res\\25Sec.xml";
            XmlDocument reader = new XmlDocument();
            reader.Load(filename);

            //
            // Traverse the XML document in memory!!!!
            //

            foreach (XmlNode node in reader.ChildNodes)
            {
                if (node.Name == "movie")
                {
                    roto.OnOpenRotoscope(node);
                }
            }

        }

        public void OnEditClearFrame()
        {
            roto.ClearFrame(framenum);
            BuildFrame();
        }

        #endregion


    }
}
