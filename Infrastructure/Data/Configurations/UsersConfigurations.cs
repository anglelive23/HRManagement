using Domain.Entities.Users;
using Domain.Shared.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class UsersConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.OwnsOne(u => u.Salary, s =>
            {
                s.Property(x => x.Amount);

                s.Property(s => s.Currency)
                    .IsRequired()
                    .HasConversion(x => x.Value, x => new Currency(x));
            });
        }
    }
}
