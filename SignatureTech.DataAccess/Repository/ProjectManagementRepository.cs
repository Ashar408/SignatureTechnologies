using SignatureTech.DataAccess.Repository.IRepository;
using SignatureTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignatureTech.DataAccess.Repository
{
    public class ProjectManagementRepository : Repository<ProjectManagement> , IProjectManagementRepository
    {
        private readonly ApplicationDbContext _db;

        public ProjectManagementRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(ProjectManagement obj)
        {
            _db.ProjectManagements.Update(obj);
        }
    }
}
