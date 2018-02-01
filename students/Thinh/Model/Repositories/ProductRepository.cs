using Model;
using Model.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository
    {
        public List<ProductComlex> GetList()
        {
            using (var context = new SuperDBContext())
            {
                return context.Products.Select(product => new ProductComlex
                {
                    Id = product.Id,
                    CategoryId = product.CategoryId,
                    CategoryName = product.Category.Name,
                    ManufacterId = product.ManufacterId,
                    ManufacterName = product.ManufacterId == null ? string.Empty : product.Manufacter.Name,
                    Code = product.Code,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    CreatedBy = product.CreatedBy,
                    CreatedName = product.CreatedBy == null ? string.Empty : product.Creator.Username,
                    UpdateBy = product.UpdatedBy,
                    UpdatedName = product.UpdatedBy == null ? string.Empty : product.Updator.Username
                }).ToList();
            }
        }
    }
}
