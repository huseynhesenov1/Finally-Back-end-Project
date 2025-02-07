using LineConstruction.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LineConstruction.DAL.ConfigrationsManager
{
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.Property(x => x.OurServiceId).IsRequired();
			builder.Property(x => x.OurTeamId).IsRequired();
		}
	}
}
