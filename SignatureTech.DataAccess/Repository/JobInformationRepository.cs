using SignatureTech.DataAccess.Repository.IRepository;
using SignatureTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignatureTech.DataAccess.Repository
{
    public class JobInformationRepository : Repository<JobInformation>, IJobInformationRepository
    {
        private readonly ApplicationDbContext _db;

        public JobInformationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(JobInformation obj)
        {
            _db.jobInformations.Update(obj);
        }
    }
}
