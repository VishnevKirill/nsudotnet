using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseApplication.Data.Entities;
using DatabaseApplication.Logic.Interfaces;

namespace DatabaseApplication.Logic.Realisations
{
    public  class ProvidersServiseImpl : CrudServiseImpl<providers>, IProvidersServise
    {
        public ProvidersServiseImpl(DataModel shopContext) : base(shopContext)
        {

        }

        public IEnumerable<countries> GetCountries()
        {
            return _entity.countries.AsEnumerable();
        }

        public IEnumerable<goods> getGoods()
        {
            return _entity.goods.AsEnumerable();
        }

        public IEnumerable<category_attribute> GetCategories()
        {
           return _entity.category_attribute.AsEnumerable();
        }

        public void AddCountry(countries c)
        {
            _entity.countries.Add(c);
            _entity.SaveChanges();
        }

        public void AddCategory(category_attribute cat)
         {
            _entity.category_attribute.Add(cat);
            _entity.SaveChanges();
         }

        public void addGoodForProvides(providers p, goods g)
        {
            var pr = new provider_goods()
            {
                 good_id = g.id,
                  provider_id =p.id,
                  time_of_deliverly = DateTime.Today,
                  deliverly_cost = 142
                        


           };
            _entity.provider_goods.Add(pr);
            _entity.SaveChanges();

        }
    }
}
