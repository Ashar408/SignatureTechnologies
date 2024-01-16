using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SignatureTech.DataAccess.Repository.IRepository;
using SignatureTech.Models;

namespace SignatureTechnologies.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class JobInformationController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        public JobInformationController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;

        }
        public IActionResult Index()
        {
            IEnumerable<JobInformation> objJob = _unitofwork.JobInformation.GetAll(includeProperties: "EmployeeDetail");
            return View(objJob);
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
            JobInformation JobInfo = new();
            if (id == null || id == 0)
            {
                //Create Product
                ViewBag.EmployeeDetailList = EmployeeDetailList;
                return View(JobInfo);
            }
            else
            {
                JobInformation JobInfom = _unitofwork.JobInformation.GetFirstOrDefault(u => u.Id == id);
                ViewBag.EmployeeDetailList = EmployeeDetailList;
                return View(JobInfom);
                //Update Product

            }


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(JobInformation JObInfo)
        {
            if (ModelState.IsValid)
            {
                if (JObInfo.Id == 0)
                {
                    _unitofwork.JobInformation.Add(JObInfo);
                    TempData["success"] = "Job Information Created Successfully";
                }
                else
                {
                    _unitofwork.JobInformation.Update(JObInfo);
                    TempData["success"] = "Job Information Updated Successfully";
                }

                _unitofwork.Save();

                return RedirectToAction("Index");
            }
            return View(JObInfo);
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
            var jobfromDb = _unitofwork.JobInformation.GetFirstOrDefault(u => u.Id == id);
            if (jobfromDb == null)
            {
                return NotFound();
            }
            ViewBag.EmployeeDetailList = EmployeeDetailList;
            return View(jobfromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitofwork.JobInformation.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitofwork.JobInformation.Remove(obj);
            _unitofwork.Save();
            TempData["success"] = "Job Information Deleted Successfully";
            return RedirectToAction("Index");


        }


        //#region API CALLS
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var JobList = _unitofwork.JobInformation.GetAll(includeProperties: "EmployeeDetail");
        //    return Json(new { data = JobList });
        //}

        //[HttpDelete]
        //public IActionResult Delete(int? id)
        //{
        //    var obj = _unitofwork.JobInformation.GetFirstOrDefault(u => u.Id == id);
        //    if (obj == null)
        //    {
        //        return Json(new { success = false, message = "Error While Deleting" });
        //    }
        //    _unitofwork.JobInformation.Remove(obj);
        //    _unitofwork.Save();
        //    return Json(new { success = true, message = "Delete Successfully" });
        //    return RedirectToAction("Index");


        //}
        //#endregion
    }
}
