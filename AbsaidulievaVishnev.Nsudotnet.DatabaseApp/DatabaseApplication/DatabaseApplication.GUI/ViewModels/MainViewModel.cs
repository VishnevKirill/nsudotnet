using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DatabaseApplication.Data.Entities;
using DatabaseApplication.Logic.Interfases;

namespace DatabaseApplication.GUI.ViewModels
{
    class MainViewModel : Screen
    {
        private ObservableCollection<CountryViewModel> _countrylist;
        private ICrudServise<countries> _countServise; 
        public MainViewModel( ICrudServise<countries> serv )
        {
            _countServise = serv;
            _countrylist= new ObservableCollection<CountryViewModel>();
            foreach (var count in _countServise.GetAll())
            {
             CountryViewModel cm= new CountryViewModel();
                cm.setCountry(count);
                _countrylist.Add(cm);
            }
        }

        public ObservableCollection<CountryViewModel> CountryList
        {
            get { return _countrylist; }
        } 
    }
}
