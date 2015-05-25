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

        private readonly ICrudService<countries> _countService;
        private readonly IGoodsService _goodService;
        private readonly IProvidersService _providersService;
        private readonly IOrdersService _ordersService;
        private IWindowManager _wm;

        public MainViewModel(ICrudService<countries> countriesServ, IGoodsService goodsServ, IProvidersService providersServ, IOrdersService ordersServ, IWindowManager wm)
        {
            _wm = wm;
            _countService = countriesServ;
            _goodService = goodsServ;
            _providersService = providersServ;
            _ordersService = ordersServ;
            GoodScreen = new GoodScreenViewModel(_goodService,_wm);
            OrderScreen = new OrderScreenViewModel(_ordersService, wm);

        }

        public ObservableCollection<CountryViewModel> CountryList
        {
            get { return _countrylist; }
        }
      


        public GoodScreenViewModel GoodScreen { get; set; }
        public OrderScreenViewModel OrderScreen { get; set; }



    }
}
