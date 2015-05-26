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
    public  class GoodsServiseImp : CrudServiseImpl<goods> , IGoodsServise
    {
        public GoodsServiseImp(DataModel shopContext) : base(shopContext) 
        {
          
        }

        public goods GetByName(string name)
        {
            return _dbset.Single(k => k.name == name);
        }
    }
}
