using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SignatureTech.DataAccess.Repository.IRepository;
using SignatureTech.Models;

namespace SignatureTechnologies.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmergencyContactController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        public EmergencyContactController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;

        }
        public IActionResult Index()
        {
            IEnumerable<EmergencyContact> objEmerg = _unitofwork.EmergencyContact.GetAll(includeProperties: "EmployeeDetail");
            return View(objEmerg);
        }

        //Get Create and Update
        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> EmployeeDetailList = _unitofwork.EmployeeDetail.GetAll().Select(
              u => new SelectListItem
              {
                  Text = u.FullName,
                  Value = u.Id.ToString()
              }
              );
            EmergencyContact emergency = new();
            if (id == null || id == 0)
            {
                //Create Product
                ViewBag.EmployeeDetailList = EmployeeDetailList;
                return View(emergency);
            }
            else
            {
                EmergencyContact emergency1 = _unitofwork.EmergencyContact.GetFirstOrDefault(u => u.Id == id);
                ViewBag.EmployeeDetailList = EmployeeDetailList;
                return View(emergency1);
                //Update Product

            }


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(EmergencyContact emergency)
        {
            if (ModelState.IsValid)
            {
                if (emergency.Id == 0)
                {
                    _unitofwork.EmergencyContact.Add(emergency);
                    TempData["success"] = "Emergency Contact Created Successfully";
                }
                else
                {
                    _unitofwork.EmergencyContact.Update(emergency);
                    TempData["success"] = "Emergency Contact Updated Successfully";
                }

                _unitofwork.Save();

                return RedirectToAction("Index");
            }
            return View(emergency);
        }
        public IActionResult Delete(int? id)
        {
            IEnumerable<SelectListItem> EmployeeDetailList = _unitofwork.EmployeeDetail.GetAll().Select(
             u => new SelectListItem
             {
                 Text = u.FullName,
                 Value = u.Id.ToString()
             }
             );
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var emrgencyfromDb = _unitofwork.EmergencyContact.GetFirstOrDefault(u => u.Id == id);
            if (emrgencyfromDb == null)
            {
                return NotFound();
            }
            ViewBag.EmployeeDetailList = EmployeeDetailList;
            return View(emrgencyfromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitofwork.EmergencyContact.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitofwork.EmergencyContact.Remove(obj);
            _unitofwork.Save();
            TempData["success"] = "Emergency Conatct Deleted Successfully";
            return RedirectToAction("Index");


        }

    }
}
