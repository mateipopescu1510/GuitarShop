namespace GuitarShop.Models.DTOs
{
    public class ShopDTO
    {
        public ShopDTO() { }
        public ShopDTO(Shop s) { 
            Address = s.Address;
            Email = s.Email;
        }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
