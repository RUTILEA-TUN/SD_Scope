using SD_Scope.Stores;
using SD_Scope.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_Scope.Commands
{
    internal class NavigateCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavigateCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new InspectionViewModel();
        }
    }
}
