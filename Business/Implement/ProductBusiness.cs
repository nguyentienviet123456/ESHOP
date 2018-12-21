using Business.Interface;
using DataAccess.UoW;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implement
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IUnitOfWork _unitofWork;

        public ProductBusiness(IUnitOfWork unitOfWork)
        {
            _unitofWork = unitOfWork;
        }
        public void AddOrUpdate(Product product)
        {
            if(product != null)
            {
                _unitofWork.Repo<Product>().Attach(product);
                _unitofWork.Save();
            }
        }

        public void Dispose()
        {
            _unitofWork?.Dispose();
        }

        public ICollection<Product> GetAllProduct()
        {
            List<Product> products = _unitofWork.Repo<Product>().Table.ToList();
            return products;
        }

        public ICollection<Product> GetProductsByCategoryid(int id)
        {
            List<Product> products = _unitofWork.Repo<Product>().Table.Where(m => m.CategoryId == id).ToList();
            return products;
        }

        public Product GetProductById(int id)
        {
            Product product = _unitofWork.Repo<Product>().GetById(id);
            return product;
        }

        public void Remove(Product product)
        {
            if(product != null)
            {
                _unitofWork.Repo<Product>().Delete(product);
                _unitofWork.Save();
            }
        }
    }
}
