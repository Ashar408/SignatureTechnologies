using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignatureTech.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IApplicationUserRepository ApplicationUser { get; }
        IEmployeeDetailRepository EmployeeDetail { get; }
        IJobInformationRepository JobInformation { get; }
        IEmergencyContactRepository EmergencyContact { get; }
        IProjectManagementRepository ProjectManagement { get; }
        void Save();
    }
}
