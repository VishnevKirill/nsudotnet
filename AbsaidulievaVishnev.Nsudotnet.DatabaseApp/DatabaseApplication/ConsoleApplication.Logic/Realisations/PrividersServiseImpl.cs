using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseApplication.Data.Entities;
using DatabaseApplication.Logic.Interfaces;

namespace DatabaseApplication.Logic.Realisations
{
    class PrividersServiseImpl : CrudServiseImpl<providers>, IProvidersServise
    {
        public IEnumerable<countries> GetCountries()
        {
            return _entity.countries.AsEnumerable();
        }

        public IEnumerable<category_attribute> GetCategories()
        {
           return _entity.category_attribute.AsEnumerable();
        }

        public void AddCountry(countries c)
        {
            _entity.countries.Add(c);
        }

        public void AddCategory(category_attribute cat)
         {
            _entity.category_attribute.Add(cat);
        }
    }
}
