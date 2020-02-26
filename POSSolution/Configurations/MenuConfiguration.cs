using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POSSolution.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POSSolution.Application.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus");
            builder.HasKey(item => item.menuId);
            builder.Property(x => x.menuId).UseIdentityColumn();
        }
    }
}
