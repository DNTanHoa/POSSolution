using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POSSolution.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POSSolution.Application.Configurations
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.ToTable("Regions");
            builder.HasKey(x => x.regionId);
            builder.HasOne<Shop>(x => x.shop).WithMany(shop => shop.regions);
        }
    }
}
