using Microsoft.AspNetCore.Mvc;
using Model.HistoryDownloadingModel.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoryController : Controller
    {
        private IHistoryDownloadingService service;

        public HistoryController(
            IHistoryDownloadingService service
            )
        {
            this.service = service;
        }

        [HttpGet("Material/{id}")]
        public IActionResult HistoryMaterial (Guid id)
        {
            var res = service.getHistoryMaterial(id);
            return Ok(res);
        }
    }
}
