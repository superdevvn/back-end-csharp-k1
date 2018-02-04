using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCodeProject
{
    public class ExcecuteProduct
    {

        public ExcecuteProduct()
        {

        }

        public void getList()
        {
            ProductRepository pr = new ProductRepository();
            List<ProductComplex> result = pr.getList();
            foreach (ProductComplex product in result)
            {
                Console.WriteLine("Product Id : {0} " , product.Id);
                Console.WriteLine("Product Name : {0} " , product.Name);
                Console.WriteLine("Product Price : {0} " , product.Price);
                Console.WriteLine("Product Description : {0} " , product.Description);
                Console.WriteLine("Category Id : {0} " , product.CategoryId);
                Console.WriteLine("Category Name : {0} " , product.CategoryName);
                Console.WriteLine("Manufacturer Id  : {0} " , product.ManufacturerId);
                Console.WriteLine("Code : {0} " , product.Code);
                Console.WriteLine("CreatedDate : {0} " , product.CreatedDate);
                Console.WriteLine("IsDeleted : {0} " , product.IsDeleted);
                Console.WriteLine("Updated Name : {0}" , product.UpdateName);
                Console.WriteLine("Created Name : {0}", product.CreatedName);
            }
        }
    }
}

