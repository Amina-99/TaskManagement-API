using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskmanagementAPI_Beta.EntityConfiguration
{
    public class TaskEntityConfiguration : IEntityTypeConfiguration<Models.Task>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Models.Task> builder)
        {
            
            builder.HasKey(t => t.TaskId);
           
            builder.Property(t => t.TaskName)
                .IsRequired();

            builder.Property(t => t.StartDate)
                .IsRequired();

            builder.Property(t => t.EndDate)
               .IsRequired();

            builder.Property(t => t.Description)
              .IsRequired();

           

        }
    }
}
