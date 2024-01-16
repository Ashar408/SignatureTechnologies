using SignatureTech.DataAccess.Repository.IRepository;
using SignatureTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignatureTech.DataAccess.Repository
{
    public class EmployeeDetailRepository: Repository<EmployeeDetail>, IEmployeeDetailRepository
    {
        private ApplicationDbContext _db;
        public EmployeeDetailRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(EmployeeDetail obj)
        {
            var objfromDb = _db.EmployeeDetails.FirstOrDefault(u => u.Id == obj.Id);
            if (objfromDb != null)
            {
                objfromDb.FullName = obj.FullName;
                objfromDb.Address = obj.Address;
                objfromDb.PhoneNumber = obj.PhoneNumber;
                objfromDb.IdCard = obj.IdCard;
                objfromDb.DOBirth = obj.DOBirth;
                objfromDb.MaritalStatus = obj.MaritalStatus;
                objfromDb.EmailAddress = obj.EmailAddress;
              
                if (obj.ImageUrl != null)
                {
                    objfromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
