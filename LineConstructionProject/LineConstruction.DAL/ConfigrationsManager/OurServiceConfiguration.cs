using LineConstruction.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LineConstruction.DAL.ConfigrationsManager
{
    public class OurServiceConfiguration : IEntityTypeConfiguration<OurService>
    {
        public void Configure(EntityTypeBuilder<OurService> builder)
        {
            builder.Property(x=>x.Title).HasMaxLength(30).IsRequired();
            builder.Property(x=>x.Description).HasMaxLength(30).IsRequired();
        }
    }
}
