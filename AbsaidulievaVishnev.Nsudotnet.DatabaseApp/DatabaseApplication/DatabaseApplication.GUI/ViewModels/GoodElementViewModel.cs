using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseApplication.Logic.Interfases;
using DatabaseApplication.Logic.Interfaces;
using System.Collections.ObjectModel;
using DatabaseApplication.GUI.Views;
using System.Windows;



namespace DatabaseApplication.GUI.ViewModels
{
    class GoodElementViewModel : PropertyChangedBase
    {
        public GoodElementViewModel(IGoodsServise goodServ, IObservableCollection<GoodViewModel> goodList, GoodViewModel goodView)
        {
            _currentGood = goodView;
            _goodServise = goodServ;
            _goodList = goodList;

            if (_currentGood != null)
            {
                GoodName = _currentGood.Name;
                GoodMeasure = _currentGood.Measure;
                GoodPrice = _currentGood.Price;
                update = true;
            }
        }

        private readonly IGoodsServise _goodServise;
        private GoodViewModel _currentGood;
        private IObservableCollection<GoodViewModel> _goodList;
        private GoodViewModel _newGood = new GoodViewModel(); 
        private bool update = false;


        public string GoodName { get; set; }
        public string GoodMeasure { get; set; }
        public decimal GoodPrice { get; set; }
        


        
        public void AddGood()
        {
           
            if (update)
            {
                _currentGood.Name = GoodName;
                _currentGood.Measure = GoodMeasure;
                _currentGood.Price = GoodPrice;
                _goodServise.Update(_currentGood.GoodEntity);
                NotifyOfPropertyChange(() => _goodList);
                update = false;
            }
            else
            {
                _newGood.Name = GoodName;
                _newGood.Measure = GoodMeasure;
                _newGood.Price = GoodPrice;
                _goodServise.Create(_newGood.GoodEntity);
                _goodList.Add(_newGood);
            }
           
           
        }

    }
}
