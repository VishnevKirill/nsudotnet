using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseApplication.Data.Entities;
using DatabaseApplication.Logic.Interfases;

namespace DatabaseApplication.GUI.ViewModels
{
    class OrdersViewModel : PropertyChangedBase
    {
        public OrdersViewModel()
        {
            OrdersEntity = new orders();
        }
        public OrdersViewModel(orders ordersEntity)
        {
            OrdersEntity = ordersEntity;
        }
        public orders OrdersEntity { get; private set; }

        public int Id
        {
            get { return OrdersEntity.id; }
            set
            {
                if (value == OrdersEntity.id) return;
                OrdersEntity.id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }

        public int ManagerId
        {
            get { return OrdersEntity.manager_id; }
            set
            {
                if (value == OrdersEntity.manager_id) return;
                OrdersEntity.manager_id = value;
                NotifyOfPropertyChange(() => ManagerId);
            }
        }


        public int ProviderId
        {
            get { return OrdersEntity.providers_id; }
            set
            {
                if (value == OrdersEntity.providers_id) return;
                OrdersEntity.providers_id = value;
                NotifyOfPropertyChange(() => ProviderId);
            }
        }

        public int GoodId
        {
            get { return OrdersEntity.good_id; }
            set
            {
                if (value == OrdersEntity.providers_id) return;
                OrdersEntity.providers_id = value;
                NotifyOfPropertyChange(() => ProviderId);
            }
        }

        public string ManagerName
        {
            get { return OrdersEntity.managers.manager_name; }
            set
            {
                if (value == OrdersEntity.managers.manager_name) return;
                OrdersEntity.managers.manager_name = value;
                NotifyOfPropertyChange(() => ManagerName);
            }

        }
        public string GoodName
        {
            get { return OrdersEntity.goods.name; }
            set
            {
                if (value == OrdersEntity.goods.name) return;
                OrdersEntity.goods.name = value;
                NotifyOfPropertyChange(() => GoodName);
            }

        }

        public string ProviderName
        {
            get { return OrdersEntity.providers.name; }
            set
            {
                if (value == OrdersEntity.providers.name) return;
                OrdersEntity.providers.name = value;
                NotifyOfPropertyChange(() => ProviderName);
            }

        }

        public decimal Count
        {
            get { return OrdersEntity.quantyty; }
            set
            {
                if (value == OrdersEntity.quantyty) return;
                OrdersEntity.quantyty = value;
                NotifyOfPropertyChange(() => Count);
            }

        }

        public int? ApplicationId
        {
            get { return OrdersEntity.aplications_id; }
            set
            {
                if (value == OrdersEntity.aplications_id) return;
                OrdersEntity.aplications_id = value;
                NotifyOfPropertyChange(() => ApplicationId);
            }

        }
        public managers Manager
        {
            get { return OrdersEntity.managers; }
            set
            {
                if (value == OrdersEntity.managers) return;
                OrdersEntity.managers = value;
                NotifyOfPropertyChange(() => ManagerId);
                NotifyOfPropertyChange(() => ManagerName);
            }

        }



    }
}

