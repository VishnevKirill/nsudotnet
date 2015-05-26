using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DatabaseApplication.Data.Entities;
using DatabaseApplication.Logic.Interfaces;
using DatabaseApplication.Logic.Interfases;

namespace DatabaseApplication.GUI.ViewModels
{
    class MainViewModel : Screen
    {
        private ObservableCollection<CountryViewModel> _countrylist;
        private ObservableCollection<GoodViewModel> _goodlist;

        private readonly ICrudServise<countries> _countServise;
        private readonly IGoodsServise _goodServise;
        private readonly IProvidersServise _providersServise;
        private readonly IOrdersServise _ordersServise;
        private IWindowManager _wm;

        public MainViewModel(ICrudServise<countries> countriesServ, IGoodsServise goodsServ, IProvidersServise providersServ, IOrdersServise ordersServ, IWindowManager wm)
        {
            _wm = wm;
            _countServise = countriesServ;
            _goodServise = goodsServ;
            _providersServise = providersServ;
            _ordersServise = ordersServ;
            GoodScreen = new GoodScreenViewModel(_goodServise,_wm);
            OrderScreen = new OrderScreenViewModel(_ordersServise, wm);
            ProviderScreen = new ProviderScreenViewModel(_providersServise, _wm);

        }

        public ObservableCollection<CountryViewModel> CountryList
        {
            get { return _countrylist; }
        }
      


        public GoodScreenViewModel GoodScreen { get; set; }
        public OrderScreenViewModel OrderScreen { get; set; }
        public ProviderScreenViewModel ProviderScreen { get; set; }



    }
}
