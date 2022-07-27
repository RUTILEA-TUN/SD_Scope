using SD_Scope.Commands;
using SD_Scope.Models;
using SD_Scope.Stores;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SD_Scope.ViewModels
{
    public class PreInspectionViewModel : ViewModelBase
    {
        private string _employeeId;
        public string EmployeeId
        {
            get 
            { 
                return _employeeId; 
            }
            set
            {
                _employeeId = value;
                OnPropertyChanged(nameof(EmployeeId));
            }
        }
        private string _lotNumber;
        public string LotNumber
        {
            get
            {
                return _lotNumber;
            }
            set
            {
                _lotNumber = value;
                OnPropertyChanged(nameof(LotNumber));
            }
        }
        private int _plannedNumber;
        public int PlannedNumber
        {
            get
            {
                return _plannedNumber;
            }
            set
            {
                _plannedNumber = value;
                OnPropertyChanged(nameof(PlannedNumber));
            }
        }
        private string _itemId;
        public string ItemId
        {
            get
            {
                return _itemId;
            }
            set
            {
                _itemId = value;
                OnPropertyChanged(nameof(ItemId));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand NavigateInspectionCommand { get; }
        public ICommand BeginInspection { get; }

        //public NavigationStore navigationStore;


        public PreInspectionViewModel(NavigationStore navigationStore)
        {
            //SubmitCommand = new BeginInspectionCommand(this, navigationStore);
            BeginInspection = new NavigateCommand(navigationStore);

        }
    }
}
