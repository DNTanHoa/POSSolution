using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POSSolution.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POSSolution.Application.Configurations
{
    public class ShopStatusConfiguration : IEntityTypeConfiguration<ShopStatus>
    {
        public void Configure(EntityTypeBuilder<ShopStatus> builder)
        {
            builder.ToTable("ShopStatuses");
            builder.HasKey(item => item.statusId);
        }
    }
}
