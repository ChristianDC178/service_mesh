using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceMesh.Accounts.Entities;
using Microsoft.EntityFrameworkCore;

namespace ServiceMesh.Accounts.Repositories
{
    public class AccountConfiguration : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property("Id").HasColumnName("EntityId");
            builder.HasKey(acc => acc.Id);
        }
    }
}
