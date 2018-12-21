using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entity;

namespace Business.Interface
{
    public interface IIntroduceBusiness
    {
        void AddOrUpdate(Introduce introduce);

        ICollection<Introduce> GetIntroduce();
    }
}
