using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseApplication.Data.Entities;
using DatabaseApplication.Data;
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
                ICrudServise<countries> gf= new CrudServiseImpl<countries>();
                  countries cont=new countries();
                cont.country_name = "БОЛГАРИЯ";
                 gf.Create(cont);
                var  qv = from b in db.countries
                    orderby b.country_name
                    select b;
                foreach(var t in qv)
                {
                    Console.WriteLine(t.country_name);
                }
                Console.ReadKey();
            }
        }
        }
    }

