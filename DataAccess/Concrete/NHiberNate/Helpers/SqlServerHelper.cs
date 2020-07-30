using Core.DataAccess.Nhibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DataAccess.Concrete.NHiberNate.Helpers
{
    public class SqlServerHelper : NHibernateHelper
    {
        private IConfiguration _configuration;
        protected override ISessionFactory InitializeFactory()
        {

            return Fluently.Configure().Database(MsSqlConfiguration.MsSql2012.ConnectionString(_configuration.GetConnectionString("NorthwindContext")))//conecction string ismi
                      .Mappings(t => t.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))//mappingleri assemblydan bul hangi assembly mevcut assemblyden bul.
                                                                                                       //dataa accestten bak mapping özelliği olanlırı bul
                      .BuildSessionFactory();//bir session dönmeli
        }
    }
}
