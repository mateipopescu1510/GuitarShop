using GuitarShop.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GuitarShop.Models.DTOs;
using GuitarShop.Models;

namespace GuitarShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShopController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //GET api/Shops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopDTO>>> GetShops()
        {
            var shops = (await _unitOfWork.Shops.GetAll()).Select(s => new ShopDTO(s)).ToList();
            return shops;
        }

        //GET api/Shops/address
        [HttpGet("{address}")]
        public async Task<ActionResult<ShopDTO>> GetShop(string address)
        {
            var shop = await _unitOfWork.Shops.GetShopByAddress(address);
            if (shop == null)
            {
                return NotFound("Shop at this address does not exist");
            }
            return new ShopDTO(shop);
        }

        //PUT api/Shops/address
        [HttpPut("{address}")]
        public async Task<IActionResult> PutShop(string address, ShopDTO shop)
        {
            var shopInDb = await _unitOfWork.Shops.GetShopByAddress(address);
            if (shopInDb == null)
            {
                return NotFound("Shop at this address does not exist");
            }

            shopInDb.Address = shop.Address;
            shopInDb.Email = shop.Email;

            await _unitOfWork.Shops.Update(shopInDb);
            _unitOfWork.Save();

            return Ok();
        }

        //POST api/Shops
        [HttpPost]
        public async Task<ActionResult<ShopDTO>> PostShop(ShopDTO shop)
        {
            var shopToAdd = new Shop(shop);
            await _unitOfWork.Shops.Create(shopToAdd);
            _unitOfWork.Save();
            return Ok();
        }

        //DELETE api/Shops/address
        [HttpDelete("{address}")]
        public async Task <IActionResult> DeleteShop(string address)
        {
            var shopInDb = await _unitOfWork.Shops.GetShopByAddress(address);
            if (shopInDb == null)
            {
                return NotFound("Shop at this address does not exist");
            }

            await _unitOfWork.Shops.Delete(shopInDb);
            _unitOfWork.Save();
            return Ok();
        }
    }


}
