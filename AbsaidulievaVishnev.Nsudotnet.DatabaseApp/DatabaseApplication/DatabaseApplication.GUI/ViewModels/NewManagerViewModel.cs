using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseApplication.Logic.Interfases;
using DatabaseApplication.Logic.Interfaces;
using System.Collections.ObjectModel;
using DatabaseApplication.GUI.Views;
using System.Windows;


namespace DatabaseApplication.GUI.ViewModels
{
    class NewManagerViewModel:PropertyChangedBase
    {
        private IObservableCollection<ManagersViewModel> _managerList;
        private IOrdersServise _orderServise;
        private ManagersViewModel _newManager;
        public string NewManager { get; set; }


        public NewManagerViewModel(IOrdersServise orderServise, IObservableCollection<ManagersViewModel> managerList)
        {
            _orderServise = orderServise;
            _managerList = managerList;
        }

        public void AddManager(){
            _newManager = new ManagersViewModel();
            _newManager.Name = NewManager;
            _orderServise.AddManager(_newManager.ManagerEntity);
            _managerList.Add(_newManager);
        }


    }
}
