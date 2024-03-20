using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.EntityLayer.Concrete;

namespace PMS.DataLayer.Mapping
{
	public class ProjectMap : IEntityTypeConfiguration<Project>
	{
		public void Configure(EntityTypeBuilder<Project> builder)
		{
			throw new System.NotImplementedException();
		}
	}
}
