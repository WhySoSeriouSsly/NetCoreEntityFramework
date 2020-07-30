using Core.DataAccess.Nhibernate;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.NHiberNate
{
    public class NhProductDal:NhEntityRepository<Product>,IProductDal
    {
        private NHibernateHelper _nHibernateHelper;
        public NhProductDal(NHibernateHelper nHibernateHelper):base(nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }
    }
}
