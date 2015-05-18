using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseApplication.Data.Entities;
using DatabaseApplication.Logic.Interfases;

namespace DatabaseApplication.Logic.Interfaces
{
    interface IProvidersServise : ICrudServise<providers>
    {
        IEnumerable<countries> GetCountries();
        IEnumerable<category_attribute> GetCategories();
        void AddCountry(countries c);
        void AddCategory(category_attribute cat);
         
    }
}
