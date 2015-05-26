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
    class ProviderScreenViewModel:PropertyChangedBase
    {
        private IProvidersServise _providerService;
        private IObservableCollection<ProvidersViewModel> _providerList;
        private IWindowManager _wm;
        private ProvidersViewModel _currentProviderViewModel;
        public ProviderScreenViewModel(IProvidersServise provServise, IWindowManager wm)
        {
            _wm = wm;
            _providerService = provServise;
            _providerList = new BindableCollection<ProvidersViewModel>();
            foreach (var provider in _providerService.GetAll())
            {
                _providerList.Add(new ProvidersViewModel(provider));
            }

        }


        public ProvidersViewModel CurrentProviderViewModel
        {
            get { return _currentProviderViewModel; }
            set
            {
                if (_currentProviderViewModel != value)
                {
                    _currentProviderViewModel = value;

                    NotifyOfPropertyChange(() => CurrentProviderViewModel);
                }
            }
        }


        public IObservableCollection<ProvidersViewModel> ProviderList
        {
            get { return _providerList; }
        }



        public void ShowAddGood()
        {
  //          _wm.ShowWindow(new ProviderElementViewModel(_providerService, _providerList, null));


        }

        public void DeleteGood()
        {
            if (CurrentProviderViewModel.ProviderEntity.id != 0)
            {
                _providerService.Delete(CurrentProviderViewModel.ProviderEntity);
                _providerList.Remove(CurrentProviderViewModel);
            }
            //       CurrentGoodViewModel = new GoodViewModel();
            //      NotifyOfPropertyChange(() => CurrentGoodViewModel);
            //     NotifyOfPropertyChange(() => _goodlist);

        }

        public void ShowChangeGood()
        {
       //     _wm.ShowWindow(new ProviderElementViewModel(_providerService, _providerList, _currentProviderViewModel));


        }


    }
}


