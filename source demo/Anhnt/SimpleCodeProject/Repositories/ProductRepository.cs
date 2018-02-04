using Models;
using Models.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Models.Product;

namespace Repositories
{
    public class ProductRepository
    {
        public List<ProductComplex> getList()
        {
            using (var context = new DbUtils())
            {
                return context.Products.Select(product => new ProductComplex
                {
                    Id = product.Id,
                    CategoryId = product.CategoryId,
                    CategoryName = product.Category.Name,
                    ManufacturerId = product.ManufacturerId,
                    Code = product.Code,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    CreatedBy = product.CreatedBy,
                    CreatedName = product.CreatedBy == null ? string.Empty : product.Creator.Username,
                    UpdateBy = product.UpdateBy,
                    UpdateName = product.UpdateBy == null ? string.Empty : product.Updator.Username
                }
                ).ToList(); //phai tra ve 1 dang list thi no moi chap nhan
            }
        }

        private static Product GetProduct(Product product)
        {
            return product;
        }
    }
}
