using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()//referans tip olmalı demek (interfaces ,abstract)
    {  //IEntityden implemente edilmiş sınıf gelebilir.İnterface gelemez.New var              
        T Get(Expression<Func<T, bool>> filter);//Tek bir nesne istiyoruz
        IList<T> GetList(Expression<Func<T, bool>> filter = null);//filtre olmazsa hepsini göster diye null
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
