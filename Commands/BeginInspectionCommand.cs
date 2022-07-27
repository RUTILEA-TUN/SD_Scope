using SD_Scope.Models;
using SD_Scope.Stores;
using SD_Scope.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_Scope.Commands
{
    internal class BeginInspectionCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly PreInspectionViewModel _preInspectionViewModel;
        public BeginInspectionCommand(PreInspectionViewModel PreInspectionViewModel, NavigationStore navigationStore)
        {
            _preInspectionViewModel = PreInspectionViewModel;
            _navigationStore = navigationStore;
        }
        public override void Execute(object? parameter)
        {
            PreInspection preInspection = new PreInspection(
                _preInspectionViewModel.EmployeeId,
                _preInspectionViewModel.LotNumber,
                _preInspectionViewModel.PlannedNumber,
                _preInspectionViewModel.ItemId
                );
            Debug.WriteLine(preInspection.EmployeeId);
            _navigationStore.CurrentViewModel = new InspectionViewModel();
        }

        
    }
}
