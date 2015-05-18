using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApplication.Data.Entities
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var db = new DataModel())
            {
                


                var qv = from b in db.countries
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
    
