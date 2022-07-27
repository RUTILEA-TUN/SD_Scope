using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace SD_Scope.Views
{
    /// <summary>
    /// Interaction logic for CameraSettingsWindow.xaml
    /// </summary>
    public partial class CameraSettingsWindow : Window
    {
        public CameraSettingsWindow()
        {
            InitializeComponent();

            //Close window if esc key pressed
            PreviewKeyDown += (s, e) => { if (e.Key == Key.Escape) Close(); };


            //Set ComboBox List selected item according to last saved on
            cbExposureTime.SelectedIndex = int.Parse(InspectionView.prefs.Find("index_exposure_time"));
            cbGain.SelectedIndex = int.Parse(InspectionView.prefs.Find("index_gain"));

        }


        //Run if Save and apply button clicked
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            InspectionView.prefs.Add("index_exposure_time", cbExposureTime.SelectedIndex + "");
            var exposure_time = "";

            //Setting exposure time according to selected related item
            if (cbExposureTime.SelectedIndex == 0)
            {
                exposure_time = "50000";
            }
            else if (cbExposureTime.SelectedIndex == 1)
            {
                exposure_time = "25000";
            }
            else if (cbExposureTime.SelectedIndex == 2)
            {
                exposure_time = "10000";
            }
            InspectionView.prefs.Add("exposure_time", exposure_time + "");


            InspectionView.prefs.Add("gain", (cbGain.SelectedIndex + 1) + "");
            InspectionView.prefs.Add("index_gain", cbGain.SelectedIndex + "");


            //Commit all params to settings.txt file
            InspectionView.prefs.Save();


            //Close filter settings window
            this.Close();
        }
    }
}
