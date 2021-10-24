using Microsoft.AspNetCore.Mvc;
using NodeProject.DatabaseLayer.Models;
using NodeProject.Dtos;
using NodeProject.ServiceLayer;
using System;
using System.Threading.Tasks;

namespace NodeProject.ControllerLayer
{
    public class AmministratorController : Controller
    {
        private readonly AmministratorService _service;
        private readonly RequestService _requestService;

        public AmministratorController(AmministratorService service, RequestService requestService)
        {
            _service = service;
            _requestService = requestService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string searchString, int? pageNumber)
        {
            try
            {
                if (searchString != null)
                {
                    pageNumber = 1;
                }
                ViewData["CurrentFilter"] = searchString;
                return View(await _service.GetAllVacancies(searchString, pageNumber));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null || id <= 0)
                {
                    return NotFound();
                }
                Vacancy vacancy = await _service.GetVacancyById(id, true, true);
                if (vacancy != null)
                {
                    return View(vacancy);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromRoute] int id, CreateNewVacancyDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.CreateNewVacancy(id, model);
                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null || id <= 0)
                {
                    return BadRequest();
                }
                Vacancy vacancyToUpdate = await _service.GetVacancyById(id.Value, false, false);
                if (vacancyToUpdate == null)
                {
                    return NotFound();
                }
                return View(vacancyToUpdate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Vacancy vacancyToUpdate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(vacancyToUpdate);
                }
                var vacancyUpdated = await _service.UpdateVacancy(vacancyToUpdate);
                if (vacancyUpdated == 0)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null || id <= 0)
                {
                    return BadRequest();
                }
                Vacancy vacancyToDelete = await _service.GetVacancyById(id.Value, false, false);
                if (vacancyToDelete == null)
                {
                    return NotFound();
                }
                var vacancyDeleted = await _service.DeleteVacancy(vacancyToDelete);
                if (vacancyDeleted == 0)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Error = ex.Message
                });
            }
        }
    }
}
