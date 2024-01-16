using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SignatureTech.DataAccess.Repository.IRepository;
using SignatureTech.Models;

namespace SignatureTechnologies.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EmployeeController(IUnitOfWork unitofwork, IWebHostEnvironment webHostEnvironment)
        {
            _unitofwork = unitofwork;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {

            return View();
        }

        //Get Create and Update
        public IActionResult Upsert(int? id)
        {
            EmployeeDetail EmpDetail = new();
            if (id == null || id == 0)
            {
                //Create Product

                return View(EmpDetail);
            }
            else
            {
                EmployeeDetail EmpDetails = _unitofwork.EmployeeDetail.GetFirstOrDefault(u => u.Id == id);
                return View(EmpDetails);
                //Update Product

            }


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(EmployeeDetail EmpDetail, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var upload = Path.Combine(wwwRootPath, @"images\Employees");
                    var extension = Path.GetExtension(file.FileName);

                    if (EmpDetail.ImageUrl != null)
                    {
                        var OldImage = Path.Combine(wwwRootPath, EmpDetail.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(OldImage))
                        {
                            System.IO.File.Delete(OldImage);
                        }
                    }


                    using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    EmpDetail.ImageUrl = @"images\Employees\" + fileName + extension;
                }
                if (EmpDetail.Id == 0)
                {
                    _unitofwork.EmployeeDetail.Add(EmpDetail);
                    TempData["success"] = "Employee Detail Created Successfully";
                }
                else
                {
                    _unitofwork.EmployeeDetail.Update(EmpDetail);
                    TempData["success"] = "Employee Detail Updated Successfully";
                }

                _unitofwork.Save();

                return RedirectToAction("Index");
            }
            return View(EmpDetail);
        }


        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var employeeList = _unitofwork.EmployeeDetail.GetAll();
            return Json(new { data = employeeList });
        }
        [HttpDelete]

        public IActionResult Delete(int? id)
        {
            var obj = _unitofwork.EmployeeDetail.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }
            var OldImage = Path.Combine(_webHostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(OldImage))
            {
                System.IO.File.Delete(OldImage);
            }
            _unitofwork.EmployeeDetail.Remove(obj);
            _unitofwork.Save();
            return Json(new { success = true, message = "Delete Successfully" });
            return RedirectToAction("Index");


        }
        #endregion

    }
}
