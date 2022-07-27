using SD_Scope.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
using Image = SD_Scope.utils.Image;
using ThridLibray;
using System.Threading;
using System.Diagnostics;
using System.Drawing;
using SD_Scope.utils;

namespace SD_Scope
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<IGrabbedRawData> m_frameList = new List<IGrabbedRawData>();        // 图像缓存列表 | frame data list 
        Thread renderThread = null;         // 显示线程 | image display thread 
        bool m_bShowLoop = true;            // 线程控制变量 | thread looping flag 
        Mutex m_mutex = new Mutex();        // 锁，保证多线程安全 | mutex 
        private Graphics _g = null;
        bool m_bShowByGDI;                  // 是否使用GDI绘图 | flag of using GDI to show image 

        Bitmap filteredImage;

        //Used for load and save params to settings.txt file
        //public static Prefs prefs = new Prefs("settings");

        //Hold CameraSetting or FilterSettings Window
        Window win;
        public MainWindow()
        {
            Debug.WriteLine("MainWindow Test 1");
            InitializeComponent();
            Debug.WriteLine("MainWindow Test 2");



        }
    }
}
