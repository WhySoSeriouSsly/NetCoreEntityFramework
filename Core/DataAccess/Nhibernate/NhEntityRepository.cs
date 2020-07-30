using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.Nhibernate
{
    public class NhEntityRepository<TEntity> : IEntityRepository<TEntity>
                                                 where TEntity : class, IEntity, new()
    {
        private NHibernateHelper _nHibernateHelper;

        public NhEntityRepository(NHibernateHelper nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        public void Add(TEntity entity)
        {
            using (var session = _nHibernateHelper.OpenSession())//Session açıyor.Gönderlilen veritabanına göre bir session açıyor.
            {
                session.Save(entity);
                
            }
        }

        public void Delete(TEntity entity)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                session.Delete(entity);
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                return session.Query<TEntity>().SingleOrDefault(filter);//nhibernate.linq
            }
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                return filter == null
                    ? session.Query<TEntity>().ToList()
                    : session.Query<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                session.Update(entity);
                
            }
        }

     
    }
}
