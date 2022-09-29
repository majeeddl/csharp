using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain.Base;
using Products.Domain.Products;

namespace Products.Domain.Categories
{
    public class Category : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int Priority { get; set; }

        // self join
        public int? ParentCategoryId { get; set; }

        public ICollection<Product> Products { get; set; }

        // self join
        public Category ParentCategory { get; set; }

        public class CategoryConfiguration : IEntityTypeConfiguration<Category>
        {
            public void Configure(EntityTypeBuilder<Category> builder)
            {
                throw new NotImplementedException();
            }
        }
    }
}
