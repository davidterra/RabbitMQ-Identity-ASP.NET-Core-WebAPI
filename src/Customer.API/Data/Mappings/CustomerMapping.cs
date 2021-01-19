using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Common.Core.DomainObjects;

namespace Customer.API.Data.Mappings
{
    
    using Customer.API.Models;    

    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.OwnsOne(c => c.Cpf, cpf =>
            {
                cpf.Property(c => c.Value)
                    .IsRequired()
                    .HasColumnName("Cpf")
                    .HasMaxLength(Cpf.CpfMaxLength)
                    .HasColumnType($"varchar({Cpf.CpfMaxLength})");
            });

            builder.OwnsOne(c => c.Email, email =>
            {
                email.Property(c => c.Value)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasColumnType($"varchar({Email.EmailMaxLength})");
            });

            builder.ToTable("Customers");

        }
    }
}
