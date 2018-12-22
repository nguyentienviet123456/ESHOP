using System.Collections.Generic;
using System.Linq;
using Business.Interface;
using DataAccess.UoW;
using Models.Entity;

namespace Business.Implement
{
    public class IntroduceBusiness: IIntroduceBusiness
    {
        private readonly IUnitOfWork _unitOfWork;

        public IntroduceBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddOrUpdate(Introduce introduce)
        {
            if (introduce != null)
            {
                _unitOfWork.Repo<Introduce>().Attach(introduce);
                _unitOfWork.Save();
            }
        }

        public ICollection<Introduce> GetIntroduce()
        {
           return _unitOfWork.Repo<Introduce>().Table.ToList();
        }
    }
}