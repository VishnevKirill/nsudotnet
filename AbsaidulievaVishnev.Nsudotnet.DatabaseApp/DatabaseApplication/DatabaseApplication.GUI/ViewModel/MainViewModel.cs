using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DatabaseApplication.Data.Entities;
namespace DatabaseApplication.GUI.ViewModel
{
    class MainViewModel : Screen
    {
        private ObservableCollection<CountryViewModel> _countryList;

        public MainViewModel()
        {
            countries count = new countries(){id=1,country_name = "Россия"};
            CountryViewModel vm= new CountryViewModel();
            vm.setCountry(count);
            _countryList= new ObservableCollection<CountryViewModel>();
            _countryList.Add(vm);
        }

        public ObservableCollection<CountryViewModel> CountryList
        {
            get{return _countryList; }
        }
    }
}
