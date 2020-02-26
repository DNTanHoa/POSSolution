using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POSSolution.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POSSolution.Application.Configurations
{
    class TableStatusConfiguration : IEntityTypeConfiguration<TableStatus>
    {
        public void Configure(EntityTypeBuilder<TableStatus> builder)
        {
            builder.ToTable("TableStatuses");
            builder.HasKey(item => item.statusId);
            builder.Property(prop => prop.statusId).UseIdentityColumn();
        }
    }
}
