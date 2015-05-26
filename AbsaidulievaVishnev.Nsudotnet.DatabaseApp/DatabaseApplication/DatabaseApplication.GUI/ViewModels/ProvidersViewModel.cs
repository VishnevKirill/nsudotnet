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
    class ProvidersViewModel:PropertyChangedBase
    {
        public ProvidersViewModel(){
            ProviderEntity = new providers();
        }
        public ProvidersViewModel(providers prov){
            ProviderEntity = prov;
        }

        public providers ProviderEntity;

        public string Name{
            get { return ProviderEntity.name; }
            set
            {
                if (value == ProviderEntity.name) return;
                ProviderEntity.name= value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        
        public int Id{ 
            get { return ProviderEntity.id; }
            set
            {
                if (value == ProviderEntity.id) return;
                ProviderEntity.id= value;
                NotifyOfPropertyChange(() => Id);
            }
        }

        
        public string Category{
            get { return ProviderEntity.providers_category.name; }
            set
            {
                if (value == ProviderEntity.providers_category.name) return;
                ProviderEntity.providers_category.name = value;
                NotifyOfPropertyChange(() => Category);
            }
        }


        public string Country{
            get { return ProviderEntity.countries.country_name; }
            set
            {
                if (value == ProviderEntity.countries.country_name) return;
                ProviderEntity.countries.country_name = value;
                NotifyOfPropertyChange(() => Country);
            }
        }

    }
}
