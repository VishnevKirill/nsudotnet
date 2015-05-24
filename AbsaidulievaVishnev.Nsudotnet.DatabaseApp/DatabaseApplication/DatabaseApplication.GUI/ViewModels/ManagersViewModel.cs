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
    class ManagersViewModel:PropertyChangedBase
    {
        public ManagersViewModel()
        {
            ManagerEntity = new managers();
        }
        public ManagersViewModel(managers manager)
        {
            ManagerEntity = manager;
        }

        public managers ManagerEntity;

        public string Name {
            get { return ManagerEntity.manager_name; }
            set
            {
                if (value == ManagerEntity.manager_name) return;
                ManagerEntity.manager_name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        public int Id{
            get { return ManagerEntity.id; }
            set
            {
                if (value == ManagerEntity.id) return;
                ManagerEntity.id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }


    }
}

