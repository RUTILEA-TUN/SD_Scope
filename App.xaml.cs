using Newtonsoft.Json;
using SD_Scope.Stores;
using SD_Scope.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SD_Scope
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        public App()
        {
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = new PreInspectionViewModel(_navigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore, _modalNavigationStore)
            };
            MainWindow.Show();
            Debug.WriteLine("App Test2");
            base.OnStartup(e);
            Debug.WriteLine("App Test3");
        }
    }
}
