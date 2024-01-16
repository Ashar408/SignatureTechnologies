using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SignatureTech.DataAccess.Repository.IRepository;
using SignatureTech.Models;
using SignatureTech.Utility;

namespace SignatureTechnologies.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectManagementController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        public ProjectManagementController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;

        }
        public IActionResult Index()
        {
            IEnumerable<ProjectManagement> projectobj = _unitofwork.ProjectManagement.GetAll(includeProperties: "EmployeeDetail");
            return View(projectobj);
        }


        //Get Create and Update
        public IActionResult Upsert(int? id) 
        {
            IEnumerable<SelectListItem> EmpDetailList = _unitofwork.EmployeeDetail.GetAll().Select(
                u=> new SelectListItem
                {
                    Text = u.FullName,
                    Value = u.Id.ToString()
                }
                );
            ProjectManagement ProjectManage = new();
            if(id == null || id == 0)
            {
                //Create Project Manage
                ViewBag.EmpDetailList = EmpDetailList;
                return View(ProjectManage);
            }
            else
            {
                //Update Project Manage
                ProjectManagement project = _unitofwork.ProjectManagement.GetFirstOrDefault(u => u.Id == id);
                ViewBag.EmployeeDetailList = EmpDetailList;
                return View(project);
            }
            
        }
        [HttpPost]
        public IActionResult Upsert(ProjectManagement projectMange)
        {
            if (ModelState.IsValid)
            {
                if(projectMange.Id == 0)
                {
                    projectMange.Status = SD.StatusInProcessing.ToString();
                    _unitofwork.ProjectManagement.Add(projectMange);
                    TempData["success"] = "Project Detail Created Successfully";
                   
                }
                else
                {
                   
                    _unitofwork.ProjectManagement.Update(projectMange);
                    TempData["success"] = "Project Detail Updated Successfully";
                  
                }
                _unitofwork.Save();
                return RedirectToAction("Index");
            }
            return View(projectMange);
        }
        public IActionResult Delete(int? id)
        {
            IEnumerable<SelectListItem> EmpDetailList = _unitofwork.EmployeeDetail.GetAll().Select(
               u => new SelectListItem
               {
                   Text = u.FullName,
                   Value = u.Id.ToString()
               }
               );
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var projectManagefrmDb = _unitofwork.ProjectManagement.GetFirstOrDefault(u => u.Id == id);
            if(projectManagefrmDb == null)
            {
                return NotFound();
            }
            ViewBag.EmpDetailList = EmpDetailList;
            return View(projectManagefrmDb);
        }
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var projectManage = _unitofwork.ProjectManagement.GetFirstOrDefault(u => u.Id == id);
            if(projectManage == null)
            {
                return NotFound();
            }
            _unitofwork.ProjectManagement.Remove(projectManage);
            _unitofwork.Save();
            TempData["success"] = "Project Detail Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
