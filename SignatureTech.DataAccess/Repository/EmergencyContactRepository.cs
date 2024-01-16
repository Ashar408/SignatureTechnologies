using SignatureTech.DataAccess.Repository.IRepository;
using SignatureTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignatureTech.DataAccess.Repository
{
    public class EmergencyContactRepository : Repository<EmergencyContact>, IEmergencyContactRepository
    {
        private readonly ApplicationDbContext _db;

        public EmergencyContactRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(EmergencyContact obj)
        {
            _db.EmergencyContacts.Update(obj);
        }
    }
}
