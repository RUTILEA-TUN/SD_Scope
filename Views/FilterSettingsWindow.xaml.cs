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
using System.Windows.Shapes;

namespace SD_Scope.Views
{
    /// <summary>
    /// Interaction logic for FilterSettingsWindow.xaml
    /// </summary>
    public partial class FilterSettingsWindow : Window
    {




        public FilterSettingsWindow()
        {
            InitializeComponent();

            //Close window if esc key pressed
            PreviewKeyDown += (s, e) => { if (e.Key == Key.Escape) Close(); };


            //Set ComboBox List selected item according to last saved on


            int var = int.Parse(InspectionView.prefs.Find("index_filter"));
            Debug.WriteLine(var);


            cbFilters.SelectedIndex = int.Parse(InspectionView.prefs.Find("index_filter"));
            cbGamma.SelectedIndex = int.Parse(InspectionView.prefs.Find("index_gamma"));
            cbAlpha.SelectedIndex = int.Parse(InspectionView.prefs.Find("index_contrast_alpha"));
            cbBeta.SelectedIndex = int.Parse(InspectionView.prefs.Find("index_contrast_beta"));
            cbClipLimit.SelectedIndex = int.Parse(InspectionView.prefs.Find("index_histogram_ClipLimit"));
            cbGridSize.SelectedIndex = int.Parse(InspectionView.prefs.Find("index_histogram_GridSize"));
            cbDiff.SelectedIndex = int.Parse(InspectionView.prefs.Find("index_sobel_diff"));
            cbGridSizeSobel.SelectedIndex = int.Parse(InspectionView.prefs.Find("index_sobel_GridSize"));
        }


        //Run if Filters list item changed
        private void cbFilters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Decide to which ViewGroup(Gamma section, Contrast section,  Histogram section or sobel secion) will be visible or hidden

            //Get  selected filter name
            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            if (text == "Gamma")
            {
                //If selected filter is Gamma, make Gamma View section visible and hide other views

                spGammaFilter.Visibility = Visibility.Visible;
                spContrastFilter.Visibility = Visibility.Collapsed;
                spHistogramFilter.Visibility = Visibility.Collapsed;
                spSobelFilter.Visibility = Visibility.Collapsed;
            }
            else if (text == "Contrast")
            {
                //If selected filter is Contrast, make Contrast View section visible and hide other views
                spGammaFilter.Visibility = Visibility.Collapsed;
                spContrastFilter.Visibility = Visibility.Visible;
                spHistogramFilter.Visibility = Visibility.Collapsed;
                spSobelFilter.Visibility = Visibility.Collapsed;
            }
            else if (text == "Histogram")
            {
                //If selected filter is Historam, make Historam View section visible and hide other views
                spGammaFilter.Visibility = Visibility.Collapsed;
                spContrastFilter.Visibility = Visibility.Collapsed;
                spHistogramFilter.Visibility = Visibility.Visible;
                spSobelFilter.Visibility = Visibility.Collapsed;
            }
            else if (text == "Sobel")
            {
                //If selected filter is Sobel, make Sobel View section visible and hide other views
                spGammaFilter.Visibility = Visibility.Collapsed;
                spContrastFilter.Visibility = Visibility.Collapsed;
                spHistogramFilter.Visibility = Visibility.Collapsed;
                spSobelFilter.Visibility = Visibility.Visible;
            }

        }

        //Run if Save and apply button clicked 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Check if filter item selected
            if (cbFilters.SelectedIndex >= 0)
            {
                //Save filter name and its index and temp memory Prefs
                InspectionView.prefs.Add("index_filter", cbFilters.SelectedIndex + "");
                InspectionView.prefs.Add("filter", ((ComboBoxItem)cbFilters.SelectedItem).Content + "");



                if (cbFilters.SelectedIndex == 0)
                {
                    //If Gamma filter selected

                    //Save gamma filter params
                    InspectionView.prefs.Add("index_gamma", cbGamma.SelectedIndex + "");
                    InspectionView.prefs.Add("gamma", ((ComboBoxItem)cbGamma.SelectedItem).Content + "");

                }
                else if (cbFilters.SelectedIndex == 1)
                {
                    //If Contrast filter selected

                    //Save Contrast filter params
                    InspectionView.prefs.Add("index_contrast_alpha", cbAlpha.SelectedIndex + "");
                    InspectionView.prefs.Add("contrast_alpha", ((ComboBoxItem)cbAlpha.SelectedItem).Content + "");
                    InspectionView.prefs.Add("index_contrast_beta", cbBeta.SelectedIndex + "");
                    InspectionView.prefs.Add("contrast_beta", ((ComboBoxItem)cbBeta.SelectedItem).Content + "");

                }
                else if (cbFilters.SelectedIndex == 2)
                {
                    //If histogram filter selected

                    //Save histogram filter params
                    InspectionView.prefs.Add("index_histogram_ClipLimit", cbClipLimit.SelectedIndex + "");
                    InspectionView.prefs.Add("histogram_ClipLimit", ((ComboBoxItem)cbClipLimit.SelectedItem).Content + "");
                    InspectionView.prefs.Add("index_histogram_GridSize", cbGridSize.SelectedIndex + "");
                    InspectionView.prefs.Add("histogram_GridSize", ((ComboBoxItem)cbGridSize.SelectedItem).Content + "");

                }
                else if (cbFilters.SelectedIndex == 3)
                {
                    //If soble filter selected

                    //Save soebl filter params
                    InspectionView.prefs.Add("index_sobel_diff", cbDiff.SelectedIndex + "");
                    InspectionView.prefs.Add("sobel_diff", ((ComboBoxItem)cbDiff.SelectedItem).Content + "");
                    InspectionView.prefs.Add("index_sobel_GridSize", cbGridSizeSobel.SelectedIndex + "");
                    InspectionView.prefs.Add("sobel_GridSize", ((ComboBoxItem)cbGridSizeSobel.SelectedItem).Content + "");
                }

                //Commit all params to settings.txt file
                InspectionView.prefs.Save();

            }

            //Close filter settings window
            this.Close();
        }


    }
}
