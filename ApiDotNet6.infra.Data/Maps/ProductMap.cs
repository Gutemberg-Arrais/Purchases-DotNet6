using System;
using Microsoft.EntityFrameworkCore;
using ApiDotNet6.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDotNet6.infra.Data.Maps
{
	public class ProductMap : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.ToTable("product");

			builder.HasKey(c => c.Id);

			builder.Property(c => c.Id).HasColumnName("id_product").UseIdentityColumn();

			builder.Property(c => c.Name).HasColumnName("name");

			builder.Property(c => c.CodErp).HasColumnName("cod_erp");

			builder.Property(c => c.Price).HasColumnName("price");

			builder.HasMany(c => c.Purchases).WithOne(p => p.Product).HasForeignKey(x => x.ProductId);
		}
	}
}

