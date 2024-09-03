using GuitarShop.Models;
using GuitarShop.Models.DTOs;
using GuitarShop.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsibilityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ResponsibilityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //GET api/Responsibility
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponsibilityDTO>>> GetResponsibilities()
        {
            var responsibilities = (await _unitOfWork.Responsibilities.GetAll())
                                   .Select(responsibility => new ResponsibilityDTO(responsibility))
                                   .ToList();
            return responsibilities;
        }

        //GET api/Responsibility/employee/{employeeId}/instrument/{instrumentId}
        [HttpGet("employee/{employeeId}/instrument/{instrumentId}")]
        public async Task<ActionResult<ResponsibilityDTO>> GetResponsibility(Guid employeeId, Guid instrumentId)
        {
            var responsibility = await _unitOfWork.Responsibilities.GetByIds(employeeId, instrumentId);
            if (responsibility == null)
            {
                return NotFound("Responsibility not found");
            }
            return new ResponsibilityDTO(responsibility);
        }

        //PUT api/Responsibility/employee/{employeeId}/instrument/{instrumentId}
        [HttpPut("employee/{employeeId}/instrument/{instrumentId}")]
        public async Task<IActionResult> PutResponsibility(Guid employeeId, Guid instrumentId, ResponsibilityDTO responsibilityDto)
        {
            var responsibilityInDb = await _unitOfWork.Responsibilities.GetByIds(employeeId, instrumentId);
            if (responsibilityInDb == null)
            {
                return NotFound("Responsibility not found");
            }

            responsibilityInDb.EmployeeId = responsibilityDto.EmployeeId;
            responsibilityInDb.InstrumentId = responsibilityDto.InstrumentId;

            await _unitOfWork.Responsibilities.Update(responsibilityInDb);
            _unitOfWork.Save();
            return Ok();
        }

        //POST api/Responsibility
        [HttpPost]
        public async Task<ActionResult<ResponsibilityDTO>> PostResponsibility(ResponsibilityDTO responsibilityDto)
        {
            var responsibilityToAdd = new Responsibility
            {
                EmployeeId = responsibilityDto.EmployeeId,
                InstrumentId = responsibilityDto.InstrumentId
            };

            await _unitOfWork.Responsibilities.Create(responsibilityToAdd);
            _unitOfWork.Save();
            return Ok(new ResponsibilityDTO(responsibilityToAdd));
        }

        //DELETE api/Responsibility/employee/{employeeId}/instrument/{instrumentId}
        [HttpDelete("employee/{employeeId}/instrument/{instrumentId}")]
        public async Task<IActionResult> DeleteResponsibility(Guid employeeId, Guid instrumentId)
        {
            var responsibilityInDb = await _unitOfWork.Responsibilities.GetByIds(employeeId, instrumentId);
            if (responsibilityInDb == null)
            {
                return NotFound("Responsibility not found");
            }
            await _unitOfWork.Responsibilities.Delete(responsibilityInDb);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
