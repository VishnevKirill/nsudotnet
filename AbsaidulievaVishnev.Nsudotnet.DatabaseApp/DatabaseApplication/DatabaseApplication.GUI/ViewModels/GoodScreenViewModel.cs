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
    class GoodScreenViewModel: PropertyChangedBase
    {
        public GoodScreenViewModel(IGoodsServise goodServise, IWindowManager wm)
        {
            _wm = wm;
            _goodServise = goodServise;
            _goodlist = new BindableCollection<GoodViewModel>();
            foreach (var good in _goodServise.GetAll())
            {
                GoodViewModel goodm = new GoodViewModel(good);
                _goodlist.Add(goodm);
            }

        }

        private readonly IGoodsServise _goodServise;
        private IObservableCollection<GoodViewModel> _goodlist;
        private IWindowManager _wm;
        private GoodViewModel _currentGoodViewModel;

        public GoodViewModel CurrentGoodViewModel{
            get{ return _currentGoodViewModel;}
            set {
                if (_currentGoodViewModel != value) {
                    _currentGoodViewModel = value;

                    NotifyOfPropertyChange(() => CurrentGoodViewModel);
                }
            }
        }

        
        public IObservableCollection<GoodViewModel> GoodList
        {
            get { return _goodlist; }
        }

        

        public void ShowAddGood()
        {
            _wm.ShowWindow(new GoodElementViewModel(_goodServise,_goodlist, null));


        }

        public void DeleteGood() {
            if (CurrentGoodViewModel.GoodEntity.id != 0)
            {
                _goodServise.Delete(CurrentGoodViewModel.GoodEntity);
                _goodlist.Remove(CurrentGoodViewModel);
            }
     //       CurrentGoodViewModel = new GoodViewModel();
      //      NotifyOfPropertyChange(() => CurrentGoodViewModel);
       //     NotifyOfPropertyChange(() => _goodlist);
            
        }

        public void ShowChangeGood()
        {
            _wm.ShowWindow(new GoodElementViewModel(_goodServise, _goodlist, _currentGoodViewModel));


        }

    }




}
