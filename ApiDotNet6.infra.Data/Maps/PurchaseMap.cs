using System;
using ApiDotNet6.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDotNet6.infra.Data.Maps
{
	public class PurchaseMap : IEntityTypeConfiguration<Purchase>
	{
		public void Configure(EntityTypeBuilder<Purchase> builder)
		{
			builder.ToTable("purchase");

			builder.HasKey(c => c.Id);

			builder.Property(c => c.Id).HasColumnName("id_purchase").UseIdentityColumn();

			builder.Property(c => c.Date).HasColumnName("date");

			builder.HasOne(c => c.Person).WithMany(p => p.Purchases);

            builder.HasOne(c => c.Product).WithMany(p => p.Purchases);
        }
	}
}

