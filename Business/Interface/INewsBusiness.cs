using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface INewsBusiness: IDisposable
    {
        News GetNewsById(int id);

        News GetLastestNews();

        ICollection<News> GetAllNewss();
    }
}
