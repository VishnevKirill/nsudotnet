using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseApplication.Data.Entities;
using DatabaseApplication.Data;
using DatabaseApplication.Logic.Interfases;



namespace DatabaseApplication.Logic.Realisations
{
    public class CrudServiseImpl<TEntity> : ICrudServise<TEntity> where TEntity : class, NumerableEntity
      {
        protected DataModel _entity;
        protected readonly IDbSet<TEntity>_dbset;

        public CrudServiseImpl(DataModel shopContext)
        {
            _entity= shopContext;
            _dbset= _entity.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbset.AsEnumerable();
        }

        public TEntity GetById(int id)
        {
            return _dbset.Find(id);
        }



        public void Create(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("not data for create");
            }
            _dbset.Add(entity);
            _entity.SaveChanges();
        }

        public void Update(TEntity entity)
        {
             if (entity == null)
            {
                throw new ArgumentException("not data for update");
            }
            _entity.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _entity.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
             if (entity == null)
            {
                throw new ArgumentException("not data for delete");
            }
            _dbset.Remove(entity);
            _entity.SaveChanges();
        }
    }


}
