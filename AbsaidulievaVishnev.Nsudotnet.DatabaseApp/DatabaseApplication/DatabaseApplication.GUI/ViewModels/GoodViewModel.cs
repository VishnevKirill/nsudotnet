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
    class GoodViewModel : PropertyChangedBase
    {
        public GoodViewModel()
        {
            GoodEntity = new goods();
        }
        public GoodViewModel(goods goodsEntitty)
        {
            GoodEntity = goodsEntitty;
        }


        public goods GoodEntity { get; private set; }

        public string Name
        {
            get { return GoodEntity.name; }
            set
            {
                if (value == GoodEntity.name) return;
                GoodEntity.name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        public string Measure
        {
            get { return GoodEntity.measure; }
            set
            {
                if (value == GoodEntity.measure) return;
                GoodEntity.measure = value;
                NotifyOfPropertyChange(() => Measure);
            }
        }

        public decimal Price
        {
            get { return GoodEntity.price_per_unit; }
            set
            {
                if (value == GoodEntity.price_per_unit) return;
                GoodEntity.price_per_unit = value;
                NotifyOfPropertyChange(() => Price);
            }
        }

        public int Id
        {
            get { return GoodEntity.id; }
            set
            {
                if (value == GoodEntity.id) return;
                GoodEntity.id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }

    }
}