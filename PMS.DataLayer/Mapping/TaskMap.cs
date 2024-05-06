using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS_EntityLayer.Concrete;
using System;

namespace PMS.DataLayer.Mapping
{
    public class TaskMap : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.TaskName).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Description).HasMaxLength(255);

            builder.HasOne(t => t.Project)
                   .WithMany(p => p.Tasks)
                   .HasForeignKey(t => t.ProjectId)
                   .IsRequired();

            builder.HasOne(t => t.AssignedUser)
                   .WithMany()
                   .HasForeignKey(t => t.AssignedUserId)
                   .IsRequired();

            builder.HasData(new Task
            {
                Id = Guid.Parse("8078703D-1398-4833-8BCD-80B5EFDE8B21"),
                TaskName = "Görev1",
                Description = "Description",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(1),
                Priority = EntityLayer.Enums.PriorityLevel.Medium,
                AssignedUserId = Guid.Parse("1D38A035-D954-4654-9466-25249903C517"),
                ProjectId = Guid.Parse("321599BD-3833-400A-A939-8B53DD7BD57A")
            });
        }
    }
}

