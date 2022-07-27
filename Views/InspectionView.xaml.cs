using SD_Scope.utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ThridLibray;
using Image = SD_Scope.utils.Image;

namespace SD_Scope.Views
{
    /// <summary>
    /// Interaction logic for InspectionView.xaml
    /// </summary>
    public partial class InspectionView : UserControl
    {

        List<IGrabbedRawData> m_frameList = new List<IGrabbedRawData>();        // 图像缓存列表 | frame data list 
        Thread renderThread = null;         // 显示线程 | image display thread 
        bool m_bShowLoop = true;            // 线程控制变量 | thread looping flag 
        Mutex m_mutex = new Mutex();        // 锁，保证多线程安全 | mutex 
        private Graphics _g = null;
        bool m_bShowByGDI;                  // 是否使用GDI绘图 | flag of using GDI to show image 

        Bitmap filteredImage;

        //Used for load and save params to settings.txt file
        public static Prefs prefs = new Prefs("settings");

        //Hold CameraSetting or FilterSettings Window
        Window win;
        public InspectionView()
        {
            /*// Create an Image element.
            Image croppedImage = new Image();

            // Create a CroppedBitmap based off of a xaml defined resource.
            CroppedBitmap cb = new CroppedBitmap(
               (BitmapSource)this.Resources["masterImage"],
               new Int32Rect(2000, 3000, 7000, 8000));       //select region rect
            croppedImage.Source = cb;                 //set image source to cropped*/
            InitializeComponent();

            //When CameraSettings button is clicked below code will be run
            bCameraSettings.Click += (object sender, RoutedEventArgs e) =>
            {
                //Open Camera settings windows
                if (win != null) win.Close();
                win = new CameraSettingsWindow()
                {
                    ShowInTaskbar = false,
                    Left = Mouse.GetPosition(this).X,
                    Top = Mouse.GetPosition(this).Y,
                    Owner = Application.Current.MainWindow
                };

#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
                //Executes when camera settings windows closes.
                win.Closed += (object sender, EventArgs e) =>
                {

                    if (m_dev != null)
                    {

                        // set ExposureTime 
                        using (IFloatParameter p = m_dev.ParameterCollection[ParametrizeNameSet.ExposureTime])
                        {
                            p.SetValue(int.Parse(prefs.Find("exposure_time")));
                        }


                        // set Gain 
                        using (IFloatParameter p = m_dev.ParameterCollection[ParametrizeNameSet.GainRaw])
                        {
                            p.SetValue(float.Parse(prefs.Find("gain")));

                        }
                    }

                };
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).

                win.Show();
            };


            //When FilterSetting button is clicked below code will be run
            bFilterSettings.Click += (object sender, RoutedEventArgs e) =>
            {
                //Open Filter setting window
                if (win != null) win.Close();
                win = new FilterSettingsWindow()
                {
                    ShowInTaskbar = false,
                    Left = Mouse.GetPosition(this).X,
                    Top = Mouse.GetPosition(this).Y,
                    Owner = Application.Current.MainWindow
                };

                win.Show();
            };

            //When ESC pressed, current FilterSetting or CameraSetting Windows will be closed.
            this.KeyDown += new KeyEventHandler(CTRL_s);
            PreviewKeyDown += (s, e) => { if (e.Key == Key.Escape && win != null) win.Close(); };


            if (null == renderThread)
            {
                renderThread = new Thread(new ThreadStart(ShowThread));
                renderThread.Start();
            }
            m_stopWatch.Start();



            ConnectCamera();
        }

        // display thread routine 
        private void ShowThread()
        {
            while (m_bShowLoop)
            {
                if (m_frameList.Count == 0)
                {
                    Thread.Sleep(10);
                    continue;
                }

                // always get the latest frame in list 
                m_mutex.WaitOne();
                IGrabbedRawData frame = m_frameList.ElementAt(m_frameList.Count - 1);
                m_frameList.Clear();
                m_mutex.ReleaseMutex();

                // call garbage collection 
                GC.Collect();

                // control frame display rate to be 25 FPS 
                if (false == isTimeToDisplay())
                {
                    continue;
                }

                try
                {
                    // raw frame data converted to bitmap 
                    var bitmap = frame.ToBitmap(false);
                    m_bShowByGDI = false;
                    //GDI is not available in WPF so not use it
                    if (m_bShowByGDI)
                    {
                        // create graphic object 
                        //if (_g == null)
                        //{
                        //    _g = iCamera.CreateGraphics();
                        //}
                        //_g.DrawImage(bitmap, new System.Drawing.Rectangle(0, 0, pbImage.Width, pbImage.Height),
                        //new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), GraphicsUnit.Pixel);
                        //bitmap.Dispose();
                    }
                    else
                    {
                        // assign bitmap to image control will cause main window reflect slowly
                        this.Dispatcher.Invoke(() => {
                            try
                            {
                                //Assign bitmap from camera to Camera view
                                iCamera.Source = Image.BitmapToImageSource(bitmap);

                                //Apply filter based on settings and assign result to Filtered view
                                iFiltered.Source = Image.BitmapToImageSource(Image.applyFilter(prefs, bitmap));

                                //Free up memory from bitmap
                                bitmap.Dispose();
                            }
                            catch (Exception exception)
                            {
                                Catcher.Show(exception);
                            }
                        });

                    }
                }
                catch (Exception exception)
                {
                    Catcher.Show(exception);
                }
            }
        }

        const int DEFAULT_INTERVAL = 20;
        Stopwatch m_stopWatch = new Stopwatch();

        // calculate interval to determine if it's show time now 
        private bool isTimeToDisplay()
        {
            m_stopWatch.Stop();
            long m_lDisplayInterval = m_stopWatch.ElapsedMilliseconds;
            if (m_lDisplayInterval <= DEFAULT_INTERVAL)
            {
                m_stopWatch.Start();
                return false;
            }
            else
            {
                m_stopWatch.Reset();
                m_stopWatch.Start();
                return true;
            }
        }

        //Camera device object 
        private IDevice m_dev;

        // camera open event callback 
        private void OnCameraOpen(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {

            }));
        }

        // camera close event callback 
        private void OnCameraClose(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {

            }));
        }

        // camera disconnect event callback 
        private void OnConnectLoss(object sender, EventArgs e)
        {
            m_dev.ShutdownGrab();
            m_dev.Dispose();
            m_dev = null;

            this.Dispatcher.Invoke(new Action(() =>
            {

            }));
        }


        private void ConnectCamera()
        {
            try
            {
                // device search 
                List<IDeviceInfo> li = Enumerator.EnumerateDevices();
                if (li.Count > 0)
                {
                    // get the first searched device 
                    m_dev = Enumerator.GetDeviceByIndex(0);

                    // register event callback 
                    m_dev.CameraOpened += OnCameraOpen;
                    m_dev.ConnectionLost += OnConnectLoss;
                    m_dev.CameraClosed += OnCameraClose;

                    // open device 
                    if (!m_dev.Open())
                    {
                        MessageBox.Show("Open camera failed");
                        return;
                    }



                    // set PixelFormat 
                    using (IEnumParameter p = m_dev.ParameterCollection[ParametrizeNameSet.ImagePixelFormat])
                    {
                        p.SetValue("Mono8");
                    }

                    // set ExposureTime 
                    using (IFloatParameter p = m_dev.ParameterCollection[ParametrizeNameSet.ExposureTime])
                    {
                        p.SetValue(int.Parse(prefs.Find("exposure_time")));
                    }

                    // set Gain 
                    using (IFloatParameter p = m_dev.ParameterCollection[ParametrizeNameSet.GainRaw])
                    {
                        p.SetValue(float.Parse(prefs.Find("gain")));

                    }

                    // set buffer count to 8 (default 16) 
                    m_dev.StreamGrabber.SetBufferCount(8);

                    // register grab event callback 
                    m_dev.StreamGrabber.ImageGrabbed += OnImageGrabbed;

                    // start grabbing 
                    if (!m_dev.GrabUsingGrabLoopThread())
                    {
                        MessageBox.Show(@"Start grabbing failed");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("\n1. Check camera connected correctly." +
                        "\n2. Check drivers installed." +
                        "\n3. Check camera is not open by other apps, e.g. iCentral app" +
                        "\n\n After resolving issue, restart application", "Camera(Mars series) not found",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception exception)
            {
                Catcher.Show(exception);
            }
        }

        // grab callback function 
        private void OnImageGrabbed(Object sender, GrabbedEventArgs e)
        {
            m_mutex.WaitOne();
            m_frameList.Add(e.GrabResult.Clone());
            m_mutex.ReleaseMutex();
        }

        // stop grabbing 
        private void CloseCamera(object sender, EventArgs e)
        {
            try
            {
                if (m_dev == null)
                {
                    throw new InvalidOperationException("Device is invalid");
                }

                m_dev.StreamGrabber.ImageGrabbed -= OnImageGrabbed;         //unregister grab event callback 
                m_dev.ShutdownGrab();                                       //stop grabbing 
                m_dev.Close();                                              //close camera 
            }
            catch (Exception exception)
            {
                Catcher.Show(exception);
            }
        }

        //Window Closed 
        /*protected override void OnClosed(EventArgs e)
        {
            if (m_dev != null)
            {
                m_dev.Dispose();
                m_dev = null;
            }

            m_bShowLoop = false;
            renderThread.Join();
            if (_g != null)
            {
                _g.Dispose();
                _g = null;
            }
            base.OnClosed(e);
        }*/



        //Run if any key pressed
        private void CTRL_s(object sender, KeyEventArgs e)
        {
            //Check if pressed keys are CTRL and S
            if (e.Key == Key.S && Keyboard.Modifiers == ModifierKeys.Control)
            {
                //Build file path
                string path = "C://Users/" + Environment.UserName + "/Pictures/SDScope/" + DateTime.Now.ToString("HH_mm_ss") + ".png";

                //Create dicrectory if not exists
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));

                //Save bitmap filtered image to file
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    BitmapEncoder encoder = new PngBitmapEncoder();
                    /////Alt COde
                    m_mutex.WaitOne();
                    IGrabbedRawData frame = m_frameList.ElementAt(m_frameList.Count - 1);
                    m_frameList.Clear();
                    m_mutex.ReleaseMutex();
                    var bitmap = frame.ToBitmap(false);
                    bitmap = Image.applyFilter(prefs, bitmap);
                    filteredImage = bitmap;
                    ///////
                    encoder.Frames.Add(BitmapFrame.Create(Image.BitmapToImageSource(filteredImage)));
                    encoder.Save(fileStream);
                }
            }
        }
    }
}
