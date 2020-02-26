using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POSSolution.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POSSolution.Application.Configurations
{
    public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.ToTable("MenuItems");
            builder.HasKey(item => new { item.menuId, item.itemId });
            builder.HasOne(menuItem => menuItem.menuNavigation).WithMany(menu => menu.items);
            builder.HasOne(menuItem => menuItem.itemNavigation).WithMany(item => item.menus);
        }
    }
}
