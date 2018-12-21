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
    public class CategoryBusiness : ICategoryBusiness
    {
        private readonly IUnitOfWork _unitofWork;
        public CategoryBusiness(IUnitOfWork unitOfWork)
        {
            _unitofWork = unitOfWork;
        }
        public void AddOrUpdate(Category category)
        {
            if (category != null)
            {
                _unitofWork.Repo<Category>().Attach(category);
                _unitofWork.Save();
            }
        }

        public void Dispose()
        {
            _unitofWork?.Dispose();
        }
        public List<Category> GetAll()
        {
            var categories = _unitofWork.Repo<Category>().Table.ToList();
            return categories;
        }


        public Category GetById(int id)
        {
            Category category = _unitofWork.Repo<Category>().GetById(id);
            return category;
        }

        public void Remove(Category category)
        {
            if (category != null)
            {
                _unitofWork.Repo<Category>().Delete(category);
                _unitofWork.Save();
            }
        }

        public IEnumerable<Category> GetTop3Seller()
        {
            var categories = _unitofWork.Repo<Category>().Table.OrderBy(m => m.CategoryName).Take(4).ToList();
            return categories;
        }
    }
}
