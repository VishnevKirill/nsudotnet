using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseApplication.Data.Entities;
using DatabaseApplication.Logic.Interfaces;
using DatabaseApplication.Logic.Interfases;

namespace DatabaseApplication.Logic.Realisations
{
    class CashServiceImpl : CrudServiceImpl<cash>, ICashService
    {
        public CashServiceImpl(DataModel shopContext) : base(shopContext)
        {
        }

        public goods GeetGood(int order_id)
        {
            return _entity.orders.Single(e => e.id==order_id).goods;
        }
    }
}
