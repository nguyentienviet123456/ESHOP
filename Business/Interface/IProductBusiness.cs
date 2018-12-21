using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IProductBusiness: IDisposable
    {
        Product GetProductById(int id);

        void AddOrUpdate(Product product);

        ICollection<Product> GetAllProduct();

        ICollection<Product> GetProductsByCategoryid( int id);

        void Remove(Product product);
    }
}
