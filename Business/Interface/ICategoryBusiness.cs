using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ICategoryBusiness : IDisposable
    {
        Category GetById(int id);

        void AddOrUpdate(Category category);

        List<Category> GetAll();

        void Remove(Category category);

        IEnumerable<Category> GetTop3Seller();
    }
}
