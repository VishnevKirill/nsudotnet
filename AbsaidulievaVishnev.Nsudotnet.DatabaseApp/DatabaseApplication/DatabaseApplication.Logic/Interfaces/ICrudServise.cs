using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseApplication.Data;
using DatabaseApplication.Data.Entities;

namespace DatabaseApplication.Logic.Interfases
{
    public interface ICrudServise<TEntity> where TEntity : class, NumerableEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Create ( TEntity entity );
        void Update ( TEntity entity );
        void Delete ( TEntity entity );
    }
}

