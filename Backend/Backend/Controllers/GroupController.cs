using Microsoft.AspNetCore.Mvc;
using Model.GroupSModel.DTO;
using Model.GroupSModel.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController: Controller
    {
        private IGroupSReoisitory groupSService;
        public GroupController(
            IGroupSReoisitory groupSService
            )
        {
            this.groupSService = groupSService;
        }

        [HttpPost("New")]
        public IActionResult NewGroup(NewGroupDTO dto)
        {
            groupSService.AddGroup(dto);
            return Ok();
        }

        [HttpGet("GetFromSchool/{id}")]
        public IActionResult GetFromSchool(Guid id)
        {
            var res = groupSService.GetAllDTOFromSchool(id);
            return Ok(res);
        }
    }
}
