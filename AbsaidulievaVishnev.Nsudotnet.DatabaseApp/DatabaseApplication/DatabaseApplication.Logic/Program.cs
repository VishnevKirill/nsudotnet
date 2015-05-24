using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseApplication.Data.Entities;
using DatabaseApplication.Data;
using DatabaseApplication.Logic.Interfaces;
using DatabaseApplication.Logic.Interfases;
using DatabaseApplication.Logic.Realisations;

namespace DatabaseApplication.Logic
{
    class Program
    {
        static void Main(string[] args)
        {
             using (var db = new DataModel())
            {
            IGoodsServise s= new GoodsServiseImp(db);
            IProvidersServise p = new ProvidersServiseImpl(db);

                goods g = s.GetById(1);
                providers pr = p.GetById(2);
                p.addGoodForProvides(pr,g);
            }
        }
        }
    }

