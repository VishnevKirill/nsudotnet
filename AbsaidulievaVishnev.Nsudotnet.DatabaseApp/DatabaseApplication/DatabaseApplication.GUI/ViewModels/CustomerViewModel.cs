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
    class CustomerViewModel:PropertyChangedBase
    {
        public CustomerViewModel()
        {
            CustomerEntity = new buyers();
        }

        public CustomerViewModel(buyers customer)
        {
            CustomerEntity = customer;
        }

        public buyers CustomerEntity;

        public string Name{
            get { return CustomerEntity.buyers_name; }
            set
            {
                if (value == CustomerEntity.buyers_name) return;
                CustomerEntity.buyers_name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        public int Id{
            get { return CustomerEntity.id; }
            set
            {
                if (value == CustomerEntity.id) return;
                CustomerEntity.id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }
    }
}
