using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskDay03.Models;

namespace TaskDay03.ConfigurationClasses
{
    internal class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> B)
        {
            B.ToTable("Books");
            B.Property(b => b.Title)
                .IsRequired(true)
                .HasMaxLength(150);
            B.Property(b => b.Price)
                .HasColumnType("decimal(8,2)");
            B.Property(b => b.PublishedDate)
                .IsRequired(false);
        }
    }
}
