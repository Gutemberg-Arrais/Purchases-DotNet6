using System;
using Microsoft.EntityFrameworkCore;
using ApiDotNet6.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDotNet6.infra.Data.Maps
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id_person")
                .UseIdentityColumn();

            builder.Property(c => c.Document).HasColumnName("document");

            builder.Property(c => c.Name).HasColumnName("name");

            builder.Property(c => c.Phone).HasColumnName("phone");

            builder.HasMany(c => c.Purchases).WithOne(p => p.Person).HasForeignKey(c => c.PersonId);
        }
    }
}

