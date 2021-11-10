using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskmanagementAPI_Beta.Models;

namespace TaskmanagementAPI_Beta.EntityConfiguration
{
    public class StatusEntityConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            
            builder.HasKey(st => st.StatusId);
          
            builder.Property(st => st.StatusDescription)
                .IsRequired();
           
            builder.HasMany(st => st.Tasks)
                .WithOne(t => t.Status)
                .HasForeignKey(t => t.StatusId);
        }
    }
}
