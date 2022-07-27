using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SD_Scope.Stores;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace SD_Scope.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        //public ViewModelBase CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;
        //public bool IsModalOpen => _modalNavigationStore.IsOpen;

        public MainViewModel(NavigationStore navigationStore, ModalNavigationStore modalNavigationStore)
        {
            _navigationStore = navigationStore;
            _modalNavigationStore = modalNavigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            //_modalNavigationStore.CurrentViewModelChanged += OnCurrentModalViewModelChanged;
            Debug.WriteLine("mAINviEWmOEL TEST");
            /// <summary>
            /// JSON CODE 
            /// </summary>
            /*JObject data = JObject.Parse(File.ReadAllText(@"c:\Users\kacem\Desktop\config.json"));
            JObject cameradata = JObject.Parse(File.ReadAllText(@"c:\Users\kacem\Desktop\camera_setting.json"));
            JArray fiterdata = JArray.Parse(File.ReadAllText(@"c:\Users\kacem\Desktop\filter_setting.json"));

            Debug.WriteLine(data);
            Debug.WriteLine(cameradata);
            Debug.WriteLine(fiterdata);

            var haha = data["defect_mode"];

            Debug.WriteLine(haha);*/

        }

        private void OnCurrentModalViewModelChanged()
        {
            //OnPropertyChanged(nameof(CurrentModalViewModel));
            //OnPropertyChanged(nameof(IsModalOpen));
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        
        
    }
}
