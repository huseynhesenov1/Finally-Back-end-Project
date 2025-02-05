using LineConstruction.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LineConstruction.DAL.ConfigrationsManager
{
    public class OurTeamConfiguration : IEntityTypeConfiguration<OurTeam>
    {
        public void Configure(EntityTypeBuilder<OurTeam> builder)
        {
            builder.Property(x => x.FullName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(50).IsRequired();
        }
    }
}
