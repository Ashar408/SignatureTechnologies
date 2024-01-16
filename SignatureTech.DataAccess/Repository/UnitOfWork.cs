using SignatureTech.DataAccess.Repository.IRepository;
using SignatureTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignatureTech.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ApplicationUser = new ApplicationUserRepository(_db);
            EmployeeDetail = new EmployeeDetailRepository(_db);
            JobInformation = new JobInformationRepository(_db);
            EmergencyContact = new EmergencyContactRepository(_db);
            ProjectManagement = new ProjectManagementRepository(_db);

        }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IEmployeeDetailRepository EmployeeDetail { get; private set; }
        public IJobInformationRepository JobInformation { get; private set; }
        public IEmergencyContactRepository EmergencyContact { get; private set; }
        public IProjectManagementRepository ProjectManagement { get; private set; }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
