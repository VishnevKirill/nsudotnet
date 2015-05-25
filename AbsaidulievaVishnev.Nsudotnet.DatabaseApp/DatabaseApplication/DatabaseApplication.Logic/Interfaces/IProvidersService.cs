using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DatabaseApplication.Data.Entities;
using DatabaseApplication.Logic.Interfases;

namespace DatabaseApplication.Logic.Interfaces
{
    public  interface IProvidersService : ICrudService<providers>
    {
        IEnumerable<countries> GetCountries();
        IEnumerable<goods> GetGoods(); 
        IEnumerable<category_attribute> GetCategories();
        void AddCountry(countries c);
        void AddCategory(category_attribute cat);
        void AddGoodForProvides(providers p, goods g);
    }
}
