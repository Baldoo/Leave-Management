using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Leave_Management.Contracts;
using Leave_Management.Data;
using Leave_Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leave_Management.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeRepository _repo;
        private readonly IMapper _mapper;

        public LeaveTypesController(ILeaveTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;   
        }

        // GET: LeaveTypes
        public ActionResult Index()
        {
            var leavetypes = _repo.FindAll().ToList(); //Se obtiene los datos de la base de datos por medio de las operaciones del repositorio
            var model = _mapper.Map<List<LeaveType>, List<LeaveTypeVM>>(leavetypes);  //Mapea los datos que vienen en formato Data a ViewModel para que los pueda leer el View()
            return View(model);
        }

        // GET: LeaveTypes/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }

            var leavetype = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeVM>(leavetype);
            return View(model);
        }

        // GET: LeaveTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveTypeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model); //Se regresa con model como argumento para regresar los elementos que el usuario ya habia introducido
                }
                var leaveType = _mapper.Map<LeaveType>(model); //Mapea la información que se obtuvo al tipo de dato que tiene del modelo en la clase data
                leaveType.DateCreated = DateTime.Now;

                var isSuccess = _repo.Create(leaveType); //Manda el modelo mapeado a la interfaz que tiene las operaciones de base de datos
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something Went Wrong"); //Crea un error y lo despliega en el <div asp-validation-summary="ModelOnly" class="text-danger"></div> del View
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong"); //Crea un error y lo despliega en el <div asp-validation-summary="ModelOnly" class="text-danger"></div> del View
                return View(model);
            }
        }

        // GET: LeaveTypes/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }

            var leavetype = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeVM>(leavetype);
            return View(model);
        }

        // POST: LeaveTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeaveTypeVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var leaveType = _mapper.Map<LeaveType>(model); 
                var isSuccess = _repo.Update(leaveType); 
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something Went Wrong"); 
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong"); //Crea un error y lo despliega en el <div asp-validation-summary="ModelOnly" class="text-danger"></div> del View
                return View(model);
            }
        }

        // GET: LeaveTypes/Delete/5
        public ActionResult Delete(int id)
        {
            /*if (!_repo.isExists(id))
            {
                return NotFound();
            }

            var leavetype = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeVM>(leavetype);
            return View(model);*/
            var leavetype = _repo.FindById(id);
            if (leavetype == null)
            {
                return NotFound();
            }
            var isSuccess = _repo.Delete(leavetype);
            if (!isSuccess)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LeaveTypeVM model)
        {
            try
            {
                var leavetype = _repo.FindById(id);
                if(leavetype == null)
                {
                    return NotFound();
                }
                var isSuccess = _repo.Delete(leavetype);
                if (!isSuccess)
                {
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}