using SignatureTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignatureTech.DataAccess.Repository.IRepository
{
    public interface IJobInformationRepository : IRepository<JobInformation>
    {
        void Update(JobInformation obj);
    }
}
