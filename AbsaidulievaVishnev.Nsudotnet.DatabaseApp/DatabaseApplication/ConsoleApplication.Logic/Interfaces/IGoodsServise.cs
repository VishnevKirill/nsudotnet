using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DatabaseApplication.Data.Entities;
using DatabaseApplication.Logic.Interfases;

namespace DatabaseApplication.Logic.Interfaces
{
    public interface IGoodsServise : ICrudServise<goods>
    {
        goods GetByName(String name);
    }
}
