using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Other;

namespace Repositories
{
    public class ProductRepository
    {
        public List<ProductComplex> GetList()
        {
            using (var context = new SuperDevDbContext())
            {
                return context.Products.Select(product => new ProductComplex
                {
                    Id = product.Id,
                    CategoryId = product.CategoryId,
                    CategoryName = product.Category.Name,
                    ManufacturerId = product.ManufacturerId,
                    ManufacturerName = product.ManufacturerId == null ? string.Empty : product.Manufacturer.Name,
                    Code = product.Code,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    CreatedBy = product.CreatedBy,
                    CreatedName = product.CreatedBy == null ? string.Empty : product.Creator.Username,
                    UpdatedBy = product.UpdatedBy,
                    UpdatedName = product.UpdatedBy == null ? string.Empty :  product.Updator.Username
                }).ToList();
            }
        }
    }
}
