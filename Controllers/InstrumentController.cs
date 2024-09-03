using GuitarShop.Models.DTOs;
using GuitarShop.Models.Enums;
using GuitarShop.Models;
using GuitarShop.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace GuitarShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public InstrumentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //GET api/Instruments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstrumentDTO>>> GetInstruments()
        {
            var instruments = (await _unitOfWork.Instruments.GetAll()).Select(instrument => new InstrumentDTO(instrument)).ToList();
            return instruments;
        }

        //GET api/Instruments/type/{type}/brand/{brand}
        [HttpGet("type/{type}/brand/{brand}")]
        public async Task<ActionResult<InstrumentDTO>> GetInstrument(string type, string brand)
        {
            brand = brand.ToUpper();
            type = type.ToUpper();

            bool isValidBrand = brand == InstrumentBrand.FENDER ||
                                brand == InstrumentBrand.IBANEZ ||
                                brand == InstrumentBrand.YAMAHA ||
                                brand == InstrumentBrand.EPIPHONE ||
                                brand == InstrumentBrand.GIBSON ||
                                brand == InstrumentBrand.OTHER;

            bool isValidType = type == InstrumentType.ELECTRIC_GUITAR ||
                               type == InstrumentType.ELECTRIC_BASS ||
                               type == InstrumentType.ACOUSTIC_GUITAR ||
                               type == InstrumentType.KEYBOARD ||
                               type == InstrumentType.DRUMS ||
                               type == InstrumentType.OTHER;

            if (isValidBrand && isValidType)
            {
                var instruments = await _unitOfWork.Instruments.GetByTypeAndBrand(type, brand);
                if (instruments == null || instruments.Count == 0)
                {
                    return NotFound("Instruments not found");
                }
                var instrumentDTOs = instruments.Select(instr => new InstrumentDTO(instr)).ToList();
                return Ok(instrumentDTOs);
            }
            else
            {
                return BadRequest($"The brand '{brand}' or type '{type}' is invalid");
            }
        }

        //PUT api/Instruments
        [HttpPut]
        public async Task<IActionResult> PutInstrument(Guid id, InstrumentDTO instrument)
        {
            var instrumentInDb = await _unitOfWork.Instruments.GetById(id);
            if (instrumentInDb == null)
            {
                return NotFound("Instrument not found");
            }
            instrumentInDb.Brand = instrument.Brand;
            instrumentInDb.Type = instrument.Type;
            instrumentInDb.Price = instrument.Price;
            instrumentInDb.ShopId = instrument.ShopId;

            await _unitOfWork.Instruments.Update(instrumentInDb);
            _unitOfWork.Save();
            return Ok();
        }

        //POST api/Instruments
        [HttpPost]
        public async Task<IActionResult> CreateInstrument(InstrumentDTO instrument)
        {
            var shop = await _unitOfWork.Shops.GetById(instrument.ShopId);
            if (shop == null)
            {
                return BadRequest("Shop does not exist");
            }

            var instrumentToAdd = new Models.Instrument(instrument);
            await _unitOfWork.Instruments.Create(instrumentToAdd);
            _unitOfWork.Save();
            return Ok();
        }

        //DELETE api/Instruments/id
        [HttpDelete]
        public async Task<IActionResult> DeleteInstrument(Guid id)
        {
            var instrmentInDb = await _unitOfWork.Instruments.GetById(id);
            if (instrmentInDb == null)
            {
                return NotFound("Instrument not found");
            }

            await _unitOfWork.Instruments.Delete(instrmentInDb);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
