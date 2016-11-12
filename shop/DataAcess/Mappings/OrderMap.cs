using shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace shop.DataAcess.Mappings
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            ToTable("Orders");
            HasKey(x => x.Id);
            HasMany(x => x.OrderPositions);
            HasRequired(x => x.Customer);
        }
    }
}