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
    class NewCustomerViewModel:PropertyChangedBase
    {
        private IObservableCollection<CustomerViewModel> _customerList;
        private IOrdersServise _orderServise;
        private CustomerViewModel _newCustomer;
        public string NewCustomer { get; set; }

        public NewCustomerViewModel(IOrdersServise orderServ, IObservableCollection<CustomerViewModel> customerList)
        {
            _orderServise = orderServ;
            _customerList = customerList;
        }
        public void AddCustomer()
        {
            _newCustomer = new CustomerViewModel();
            _newCustomer.Name = NewCustomer;
            _orderServise.AddCustomer(_newCustomer.CustomerEntity);
            _customerList.Add(_newCustomer);
        }

    }
}
