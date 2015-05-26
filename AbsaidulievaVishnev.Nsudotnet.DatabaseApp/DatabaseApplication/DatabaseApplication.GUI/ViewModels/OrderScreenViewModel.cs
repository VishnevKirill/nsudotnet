using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseApplication.Data.Entities;
using DatabaseApplication.Logic.Interfases;
using DatabaseApplication.Logic.Interfaces;
using System.Collections.ObjectModel;
using DatabaseApplication.GUI.Views;

namespace DatabaseApplication.GUI.ViewModels
{
    class OrderScreenViewModel:PropertyChangedBase
    {
        public OrderScreenViewModel(IOrdersServise orderSecvise,IWindowManager wm){
            
            _wm = wm;
            _orderServise = orderSecvise;
            _orderlist = new BindableCollection<OrdersViewModel>();
            
            foreach(var order in _orderServise.GetAll()){
                OrdersViewModel orderm = new OrdersViewModel(order);
                _orderlist.Add(orderm);
            }
            _oldList = _orderlist;
        }

        private readonly IOrdersServise _orderServise;
        private IObservableCollection<OrdersViewModel> _orderlist;
        private IObservableCollection<OrdersViewModel> _newOrderList;
        private IObservableCollection<OrdersViewModel> _oldList;
        private IWindowManager _wm;
        private OrdersViewModel _currentOrderViewModel;
        private string _providerFilter;

         public OrdersViewModel CurrentOrderViewModel{
            get{ return _currentOrderViewModel;}
            set {
                if (_currentOrderViewModel != value) {
                    _currentOrderViewModel = value;
                    NotifyOfPropertyChange(() => CurrentOrderViewModel);
                }
            }
        }

        
        public IObservableCollection<OrdersViewModel> OrderList
        {
            get { return _orderlist; }
            set
            {
                if (value != _orderlist)
                {
                    _orderlist = value;
                    NotifyOfPropertyChange(() => OrderList);
                }
            }
        }

        public string ProviderFilter
        {
            get { return _providerFilter; }
            set
            {
                if (value != _providerFilter)
                {
                    _providerFilter = value;
                    NotifyOfPropertyChange(() => ProviderFilter);
                }
            }
        }



        public void ShowAddOrder()
        {
            _wm.ShowWindow(new OrderElementViewModel(_orderServise, _orderlist, _wm, null));


        }

        public void DeleteOrder() {
            if (CurrentOrderViewModel.Id != 0)
            {
                _orderServise.Delete(CurrentOrderViewModel.OrdersEntity);
                _orderlist.Remove(CurrentOrderViewModel);
            }
     //       CurrentGoodViewModel = new GoodViewModel();
      //      NotifyOfPropertyChange(() => CurrentGoodViewModel);
       //     NotifyOfPropertyChange(() => _goodlist);
            
        }

        public void ShowChangeOrder()
        {
           _wm.ShowWindow(new OrderElementViewModel(_orderServise, _orderlist, _wm,_currentOrderViewModel));


        }
        public void GetByProviders()
        {
            _newOrderList = new BindableCollection<OrdersViewModel>();
            foreach (var order in _orderServise.GetOrdersByProviders(_providerFilter))
            {
                OrdersViewModel orderm = new OrdersViewModel(order);
                _newOrderList.Add(orderm);
            }
            _orderlist = _newOrderList;
            NotifyOfPropertyChange(() => OrderList);


        }

        public void RemoveFilter()
        {
            _orderlist = _oldList;
            NotifyOfPropertyChange(() => OrderList);
        }

    }
}

