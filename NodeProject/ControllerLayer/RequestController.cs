using Microsoft.AspNetCore.Mvc;
using NodeProject.DatabaseLayer.Models;
using NodeProject.ServiceLayer;
using System;
using System.Threading.Tasks;

namespace NodeProject.ControllerLayer
{
    public class RequestController : Controller
    {
        private readonly RequestService _service;

        public RequestController(RequestService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await _service.GetAllRequest());
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
                Request requestToDelete = await _service.GetRequestById(id.Value);
                if (requestToDelete == null)
                {
                    return NotFound();
                }
                int requestDeleted = await _service.DeleteRequest(requestToDelete);
                if (requestDeleted == 0)
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
