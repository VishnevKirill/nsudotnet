using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseApplication.Data.Entities;
using DatabaseApplication.Logic.Interfaces;

namespace DatabaseApplication.Logic.Realisations
{
    class GoodsServiseImp : CrudServiseImpl<goods>, IGoodsServise
    {
        public goods GetByName(string name)
        {
            return _dbset.Single(k => k.name == name);
        }
    }
}
