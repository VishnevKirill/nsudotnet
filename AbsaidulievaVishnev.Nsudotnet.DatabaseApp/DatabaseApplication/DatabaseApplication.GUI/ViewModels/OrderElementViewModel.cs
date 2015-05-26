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
    class OrderElementViewModel: PropertyChangedBase
    {
        public IObservableCollection<GoodViewModel> Goods { get; set; }
        public IObservableCollection<ProvidersViewModel> Providers { get; set; }
        public IObservableCollection<ManagersViewModel> Managers { get; set; }
        public IObservableCollection<CustomerViewModel> Customers { get; set; }
        private OrdersViewModel _order;
        private IOrdersServise _orderServise;
        private IWindowManager _wm;
        private OrdersViewModel _current;
        private IObservableCollection<OrdersViewModel> _orderList;
        private int _goodIndex = 0;
        private int _providerIndex = 0;
        private int _managerIndex;
        private int _customerIndex;
        private int ind;
        private bool update = false;
        public decimal Count { get; set; }

     
        public OrderElementViewModel(IOrdersServise orderServise, IObservableCollection<OrdersViewModel> orderList, IWindowManager wm, OrdersViewModel currentOrderViewModel){
            _wm = wm;
            _orderList = orderList;
            _orderServise = orderServise;
            _current = currentOrderViewModel;
            Goods = new BindableCollection<GoodViewModel>();
            Providers = new BindableCollection<ProvidersViewModel>();
            Managers = new BindableCollection<ManagersViewModel>();
            Customers = new BindableCollection<CustomerViewModel>();


            foreach (var good in _orderServise.GetGoods())
            {
                Goods.Add(new GoodViewModel(good));

            }
            
            foreach (var provider in _orderServise.GetProviders(Goods[_goodIndex].Id))
            {
                Providers.Add(new ProvidersViewModel(provider));
            }

            foreach (var manager in _orderServise.GetManagers())
            {
                Managers.Add(new ManagersViewModel(manager));
            }

            foreach (var customer in _orderServise.GetBuyers())
            {
                Customers.Add(new CustomerViewModel(customer));
            }
            if (_current != null)
            {
                for (int i = 0; i < Goods.Count; i++)
                {
                    if (Goods[i].Name == _current.GoodName)
                    {
                        _goodIndex = i;
                        break;
                    }

                }
                for (int i = 0; i < Managers.Count; i++)
                {
                    if (Managers[i].Name == _current.ManagerName)
                    {
                        _managerIndex = i;
                        break;
                    }

                }
                for (int i = 0; i < Providers.Count; i++)
                {
                    if (Providers[i].Name == _current.ProviderName)
                    {
                        _providerIndex = i;
                        break;
                    }

                }
                Count = _current.Count;
                update = true;

            }

        }

        public int GoodIndex
        {
            get { return _goodIndex; }
            set
            {
                if (value != _goodIndex)
                {
                    _goodIndex = value;
                    Providers.Clear();
                    foreach (var provider in _orderServise.GetProviders(Goods[_goodIndex].Id))
                    {
                        Providers.Add(new ProvidersViewModel(provider));
                    }
                    NotifyOfPropertyChange(() => Providers);
                }
            }
        }

        public int ProviderIndex
        {
            get { return _providerIndex; }
            set
            {
                if (value != _providerIndex)
                {
                    _providerIndex = value;
                   
                //    NotifyOfPropertyChange(() => Providers);
                }
            }
        }


        public int ManagerIndex
        {
            get { return _managerIndex; }
            set
            {
                if (value != _managerIndex)
                {
                    _managerIndex = value;

                    //    NotifyOfPropertyChange(() => Providers);
                }
            }
        }

        public int CustomerIndex
        {
            get { return _customerIndex; }
            set
            {
                if (value != _customerIndex)
                {
                    _customerIndex = value;

                    //    NotifyOfPropertyChange(() => Providers);
                }
            }
        }


        public void AddOrder()
        {
            if (!update)
            {
                _order = new OrdersViewModel();
            }else{
                _order = _current;

            }
                _order.OrdersEntity.goods = Goods[_goodIndex].GoodEntity;
                _order.OrdersEntity.managers = Managers[_managerIndex].ManagerEntity;
                _order.OrdersEntity.providers = Providers[_providerIndex].ProviderEntity;
                applications appl = new applications();
                appl.buyer = Customers[_customerIndex].Id;
                _orderServise.AddAplication(appl);
                _order.OrdersEntity.applications = appl;
                _order.Count = Count;
                if (!update)
                {
                    _orderServise.Create(_order.OrdersEntity);
                    _orderList.Add(_order);
                    NotifyOfPropertyChange(() => _orderList);
                  
                    update = false;
                }
                else
                {
                    _orderServise.Update(_order.OrdersEntity);
                    NotifyOfPropertyChange(() => _orderList);
                }
                
        }

        
        public void ShowAddManager()
        {
            _wm.ShowWindow(new NewManagerViewModel(_orderServise,Managers));
        }

        public void ShowAddCustomer()
        {
            _wm.ShowWindow(new NewCustomerViewModel(_orderServise, Customers));
        }


    }
}
