﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseApplication.Data.Entities;
using DatabaseApplication.Data;
using DatabaseApplication.Logic.Interfaces;

namespace DatabaseApplication.Logic.Realisations
{
   public class OrdersServeceImpl :CrudServiceImpl<orders>, IOrdersService
    {
        public OrdersServeceImpl(DataModel shopContext) : base(shopContext)
        {

        }

        public IEnumerable<goods> GetGoods()
        {
            return _entity.goods.AsEnumerable();
        }

        
        public IEnumerable<providers> GetProviders(int id)
        {

           return _entity.provider_goods.Where(e=>e.good_id==id).Include(e=>e.provider_id).Select(e=>e.providers);
           

        }

        public IEnumerable<buyers> GetBuyers()
        {
            return _entity.buyers.AsEnumerable();
        }

        public IEnumerable<managers> GetManagers()
        {
            return _entity.managers.AsEnumerable();
        }

        public void AddAplication(applications a)
        {
            _entity.applications.Add(a);
            _entity.SaveChanges();
        }

        public void RemoveApplication(applications a)
        {
            _entity.applications.Remove(a);
            _entity.SaveChanges();
        }
    }
}
