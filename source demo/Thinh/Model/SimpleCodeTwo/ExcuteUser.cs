using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCodeTwo
{
    public class ExcuteUser
    {
        static ProductRepository productReposity = new ProductRepository();
        public static void getList()
        {
            try
            {
                var products = productReposity.GetList();
                foreach (var product in products)
                {
                    Console.WriteLine(string.Format("Id: {0}\nCategoryName: {1}\nCode: {2}\nName: {3}\nPrice: {4}\nDescription: {5} ", product.Id, product.CategoryName, product.Code, product.Name, product.Price, product.Description));
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
          
        }
    }
}
