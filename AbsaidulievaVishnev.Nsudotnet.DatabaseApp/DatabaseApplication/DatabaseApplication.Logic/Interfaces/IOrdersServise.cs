using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseApplication.Data.Entities;
using DatabaseApplication.Logic.Interfases;

namespace DatabaseApplication.Logic.Interfaces
{
    public  interface IOrdersServise : ICrudServise<orders>
    {
        IEnumerable<goods> GetGoods();
        IEnumerable<providers> GetProviders(int id);
        IEnumerable<buyers> GetBuyers();
        IEnumerable<managers> GetManagers();
        void AddAplication(applications a);
        void RemoveApplication(applications a);
        void AddManager(managers m);
        void AddCustomer(buyers m);
        IEnumerable<orders> GetOrdersByProviders(string pro);
        
    }
}
