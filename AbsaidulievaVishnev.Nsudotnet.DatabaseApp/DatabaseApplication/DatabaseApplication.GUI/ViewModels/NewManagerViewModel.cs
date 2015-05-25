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
        private IOrdersService _orderService;
        private ManagersViewModel _newManager;
        public string NewManager { get; set; }


        public NewManagerViewModel(IOrdersService orderService, IObservableCollection<ManagersViewModel> managerList)
        {
            _orderService = orderService;
            _managerList = managerList;
        }

        public void AddManager(){
            _newManager = new ManagersViewModel();
            _newManager.Name = NewManager;
            _orderService.AddManager(_newManager.ManagerEntity);
            _managerList.Add(_newManager);
        }


    }
}
