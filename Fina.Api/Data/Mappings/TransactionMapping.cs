using Fina.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fina.Api.Data.Mappings;

public class TransactionMapping : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transaction");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);
        
        builder.Property(x => x.Type)
            .IsRequired(true)
            .HasColumnType("SMALLINT");
        
        builder.Property(x => x.Amount)
            .IsRequired(true)
            .HasColumnType("MONEY");
        
        builder.Property(x => x.CreatedAt)
            .IsRequired(true);
        
        builder.Property(x => x.PaidOrReceivedAt)
            .IsRequired(false);
        
        builder.Property(x => x.UserId)
            .IsRequired(true)
            .HasColumnType("VARCHAR")
            .HasMaxLength(160);
    }
}