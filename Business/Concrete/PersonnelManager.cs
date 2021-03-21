using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   public class PersonnelManager : IPersonnelService
    {
        IPersonnelDal _personnelDal;

        public PersonnelManager(IPersonnelDal personnelDal)
        {
            _personnelDal = personnelDal;
        }

        public List<Personnel> GetAll()
        {
           return _personnelDal.GetAll();
        }
    }
}
