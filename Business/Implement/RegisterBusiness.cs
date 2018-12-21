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
    public class RegisterBusiness : IRegisterBusiness
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddRegister(Register model)
        {
            if(model != null)
            {
                _unitOfWork.Repo<Register>().Insert(model);
                _unitOfWork.Save();
            }
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
