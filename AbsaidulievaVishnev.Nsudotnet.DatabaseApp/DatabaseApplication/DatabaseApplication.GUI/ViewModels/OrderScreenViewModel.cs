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
        public OrderScreenViewModel(IOrdersService orderSecvise,IWindowManager wm){
            
            _wm = wm;
            _orderService = orderSecvise;
            _orderlist = new BindableCollection<OrdersViewModel>();
            
            foreach(var order in _orderService.GetAll()){
                OrdersViewModel orderm = new OrdersViewModel(order);
                _orderlist.Add(orderm);
            }
        }

        private readonly IOrdersService _orderService;
        private IObservableCollection<OrdersViewModel> _orderlist;
        private IWindowManager _wm;
        private OrdersViewModel _currentOrderViewModel;

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
        }

        public void ShowAddOrder()
        {
            _wm.ShowWindow(new OrderElementViewModel(_orderService, _orderlist, _wm));


        }

        public void DeleteOrder() {
            if (CurrentOrderViewModel.Id != 0)
            {
                _orderService.Delete(CurrentOrderViewModel.OrdersEntity);
                _orderlist.Remove(CurrentOrderViewModel);
            }
     //       CurrentGoodViewModel = new GoodViewModel();
      //      NotifyOfPropertyChange(() => CurrentGoodViewModel);
       //     NotifyOfPropertyChange(() => _goodlist);
            
        }

        public void ShowChangeOrder()
        {
   //         _wm.ShowWindow(new GoodElementViewModel(_goodServise, _goodlist, _currentGoodViewModel));


        }


    }
}

