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
    public class NewsBusiness : INewsBusiness
    {
        private readonly IUnitOfWork _unitOfWork;

        public NewsBusiness( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }

        public ICollection<News> GetAllNewss()
        {
            List<News> newss = _unitOfWork.Repo<News>().Table.ToList();
            return newss;
        }

        public News GetLastestNews()
        {
            News lastest = _unitOfWork.Repo<News>().Table.OrderBy(m => m.Id).FirstOrDefault();
            return lastest;
        }

        public News GetNewsById(int id)
        {
            News news = _unitOfWork.Repo<News>().GetById(id);
            return news;
        }
    }
}
