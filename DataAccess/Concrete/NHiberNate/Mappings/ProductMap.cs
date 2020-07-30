using Entities.Concrete;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.NHiberNate.Mappings
{
    public class ProductMap:ClassMap<Product>
    {
        public ProductMap()
        {
            Table(@"Products");//Hangi tabloya gider.

            LazyLoad();

            //deaktif etme Not.LazyLoad();
            //veya
            // var conventions = new Conventions();
            // conventions.DefaultLazyLoad = false;

            Id(x => x.ProductId).Column("ProductID");//Veritabanında Bu sütuna bağlıdır.

            Map(x => x.CategoryId).Column("CategoryID");//categoryId kolonu vertabanında o kolonmdur gibi düşün.
            Map(x => x.ProductName).Column("ProductName");
            Map(x => x.QuantityPerUnit).Column("QuantityPerUnit");//Veritabanında ona maptir gibi düşün.
            Map(x => x.UnitPrice).Column("UnitPrice");
        }
       
    }
}
